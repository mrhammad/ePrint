using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Preflight;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Upload;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace ePrint.WebStore
{
    public partial class productdetails : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected HtmlImage cards;

        //protected HtmlAnchor cards1;

        //protected System.Web.UI.WebControls.Label lblPrintReadyFile;

        //protected HtmlGenericControl div_PrintReadyFile;

        //protected HtmlGenericControl divLine;

        //protected System.Web.UI.WebControls.Label Label;

        //protected PlaceHolder plhPriceList;

        //protected PlaceHolder plhPriceListMore;

        //protected HiddenField hid_qtyFromList;

        //protected HiddenField hid_qtyToList;

        //protected HiddenField hid_CostExcMarkupList;

        //protected HiddenField hid_MarkupList;

        //protected HiddenField hid_priceList;

        //protected HiddenField hdnsoldPackOV;

        //protected HtmlGenericControl div_ProductPriceList;

        //protected HiddenField hdnIsBackOrder;

        //protected HiddenField hdnWebOtherCostID;

        //protected HiddenField hdnStockAddOption;

        //protected HiddenField hdnPriceCatalogueID;

        //protected HiddenField hdnDrawStockFrom;

        //protected HiddenField hdnStockManagement;

        //protected HiddenField hdnIsShowStock;

        //protected HiddenField hdnAvailableQty;

        //protected HiddenField hdnMashDivHeight;

        //protected HiddenField hdnShowPriceSubtotalTax;

        //protected HiddenField hdnIsStockItem;

        //protected HiddenField hdnStockForMultipleProducts;

        //protected HtmlGenericControl divMask;

        //protected PlaceHolder plhContentTop;

        //protected System.Web.UI.WebControls.Label lbl_CatalogueName2;

        //protected System.Web.UI.WebControls.Label Label5;

        //protected System.Web.UI.WebControls.Label lblStockMessage;

        //protected HtmlGenericControl pnlStockMessage;

        //protected System.Web.UI.WebControls.Label lbl_Description;

        //protected System.Web.UI.WebControls.Label lblCustomerCode;

        //protected System.Web.UI.WebControls.Label lblItemCode;

        //protected System.Web.UI.WebControls.Label Label4;

        //protected HtmlGenericControl Spn_PrdoMandatory;

        //protected DropDownList ddlOtherMultiple;

        //protected HtmlGenericControl Span2;

        //protected HtmlGenericControl div_ProdSelectErrorMSG;

        //protected HtmlGenericControl div_OtherMultipleProducts;

        //protected HtmlGenericControl Div1;

        //protected System.Web.UI.WebControls.Label lbl_priceStartsFrom;

        //protected System.Web.UI.WebControls.Label lbl_priceStartsFrom1;

        //protected System.Web.UI.WebControls.Label lbl_ShowSoldInPacksOf;

        //protected System.Web.UI.WebControls.Label lbl_ShowSoldInPacksOf1;

        //protected HtmlGenericControl div_soldinpack;

        //protected System.Web.UI.WebControls.Label lbl_stockStatus;

        //protected System.Web.UI.WebControls.Label lbl_stockStatus1;

        //protected HtmlGenericControl divStockStatus;

        //protected PlaceHolder plhContentMiddle;

        //protected HtmlGenericControl clear;

        //protected System.Web.UI.WebControls.Label lblSelectCampaign;

        //protected DropDownList ddlCampaign;

        //protected HtmlGenericControl spn_CampaignErrMsg;

        //protected HtmlGenericControl div_CampaignErrorMsg;

        //protected HtmlGenericControl div_Campaign;

        //protected PlaceHolder plhquantity;

        //protected HiddenField hdnCampaignValue;

        //protected HiddenField hdnCampaignSelectedValue;

        //protected PlaceHolder plhPriceCalculator;

        //protected HtmlGenericControl Price_CalculatorWithAddition1;

        //protected System.Web.UI.WebControls.Label lbl_BehalfUsers;

        //protected DropDownList ddl_SelectBehalf;

        //protected HtmlGenericControl divSelectBehalf;

        //protected DropDownList ddl_BehalfUsers;

        //protected HtmlGenericControl divUserBehalf;

        //protected DropDownList ddl_BehalfDepts;

        //protected HtmlGenericControl divDeptBehalf;

        //protected DropDownList ddl_DeptUsers;

        //protected HiddenField hdnDepuUserID;

        //protected HtmlGenericControl divDeptUsers;

        //protected HtmlGenericControl divBehalfOf;

        //protected RadioButton rdbstkorder;

        //protected RadioButton rdstkbreplenish;

        //protected HtmlGenericControl div_replenishstockcontent;

        //protected System.Web.UI.WebControls.Label Label1;

        //protected HtmlGenericControl DivUploadCsvFile;

        //protected System.Web.UI.WebControls.Label lblfp_artwork;

        //protected ImageButton ImgButtonErase;

        //protected FileUpload fp_artwork;

        //protected HtmlGenericControl spn_artworkFile;

        //protected System.Web.UI.WebControls.Label lblfp_artwork1;

        //protected ImageButton ImgButtonErase1;

        //protected FileUpload fp_artwork1;

        //protected System.Web.UI.WebControls.Label lblfp_artwork2;

        //protected ImageButton ImgButtonErase2;

        //protected FileUpload fp_artwork2;

        //protected HtmlGenericControl artwork_div;

        //protected Button btnAddtoCart;

        //protected Button EditProduct2;

        //protected HtmlGenericControl Price_CalculatorWithAddition2;

        //protected System.Web.UI.WebControls.Label lblupload;

        //protected System.Web.UI.WebControls.Label lblfp_artwork_no_addoption1;

        //protected ImageButton ImgButtonErase_no_addoption1;

        //protected FileUpload fp_artwork_no_addoption1;

        //protected HtmlGenericControl spn_artworkFile1;

        //protected System.Web.UI.WebControls.Label lblfp_artwork_no_addoption2;

        //protected ImageButton ImgButtonErase_no_addoption2;

        //protected FileUpload fp_artwork_no_addoption2;

        //protected System.Web.UI.WebControls.Label lblfp_artwork_no_addoption3;

        //protected ImageButton ImgButtonErase_no_addoption3;

        //protected FileUpload fp_artwork_no_addoption3;

        //protected HtmlGenericControl div_artwork_content_fileupload_no_addoption;

        //protected HtmlGenericControl artwork_div_no_addoption;

        //protected HtmlGenericControl TempDataLine;

        //protected System.Web.UI.WebControls.Label Label2;

        //protected CustomValidator CustomValidator1;

        //protected System.Web.UI.WebControls.Label Label3;

        //protected ImageButton ImageButton1;

        //protected FileUpload Upload;

        //protected HtmlGenericControl Span1;

        //protected HtmlGenericControl div2;

        //protected HtmlAnchor DownloadCsvFile;

        //protected HtmlGenericControl DivDownloadCsvFile;

        //protected HtmlGenericControl DivUpload_DownloadCsvFile;

        //protected System.Web.UI.WebControls.Label lblUploadImageZip;

        protected FileUpload imgeZipUploader;

        //protected CustomValidator CustomValidator2;

        protected HtmlGenericControl DivUpload_ImageZipFile = new HtmlGenericControl();

        //protected Button btnAddtoCart1;

        //protected Button EditProduct1;

        //protected PlaceHolder plhAddtoCartClear;

        //protected HtmlGenericControl div_btnAddtoCart1;

        //protected HtmlGenericControl div_Below_Desc;

        //protected PlaceHolder plhContentBottom;

        //protected HtmlTableCell leftPanel_td_div;

        //protected PlaceHolder plhRightBanner;

        //protected Panel pnlNormalDetails;

        //protected CheckBox chkconform;

        //protected HiddenField hdnPdfPath;

        //protected Button btnBackToProDet;

        //protected Button btn_ConfirmAdd1;

        //protected Button btn_ConfirmEditTemplate1;

        //protected HtmlIframe pdfframe;

        //protected Panel pnlConfirmPRFile;

        //protected System.Web.UI.WebControls.Label lbl_CatalogueName3;

        //protected HiddenField hid_matixType;

        //protected HtmlGenericControl div_PriceTable;

        //protected HiddenField hid_QuantityPrice;

        //protected HiddenField hid_QuantityPriceExcMarkup;

        //protected HiddenField hid_Markup;

        //protected HiddenField hid_QuestionLenght;

        //protected HiddenField hid_MultipleLenght;

        //protected HiddenField hid_MatrixLenght;

        //protected HiddenField hid_SaveToCart;

        //protected HiddenField hid_SaveToCartItems;

        //protected HiddenField hid_SaveToAdditionalItems;

        //protected HiddenField hid_TempTotalPrice;

        //protected HiddenField hid_Quantity_Edit;

        //protected HiddenField hid_totalPrice_Edit;

        //protected HiddenField hdn_height;

        //protected HiddenField hdn_width;

        //protected HiddenField hdn_orderedheight;

        //protected HiddenField hdn_orderedwidth;

        //protected HiddenField hdn_orderedarea;

        //protected HiddenField hdn_orderedquantity;

        //protected System.Web.UI.WebControls.Label lblFileName1;

        //protected HiddenField hdnFileName1;

        //protected System.Web.UI.WebControls.Label lblFileName2;

        //protected HiddenField hdnFileName2;

        //protected System.Web.UI.WebControls.Label lblFileName3;

        //protected HiddenField hdnFileName3;

        //protected HtmlIframe Iframe1;

        //protected HiddenField hdnSelectBehalf;

        //protected HiddenField hdnUserBehalf;

        //protected HiddenField hdnDeptBehalf;

        //protected HiddenField hdnPrintReadyFile;

        //protected HiddenField hdnSingleQuestionValues;

        //protected HiddenField hdnArtWorkDeleted1;

        //protected HiddenField hdnArtWorkDeleted2;

        //protected HiddenField hdnArtWorkDeleted3;

        public static string TheURL;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public BaseClass objBase = new BaseClass();

        public string strImagepath = BaseClass.imagePath();

        public string EprintImagePath = BaseClass.EprintImagePath();

        public char KeySeparator;

        public int AdditionalCount;

        public int IsPriceList;

        public int CompanyID;

        public int CartID;

        public int CartItemID;

        public int PriceCatalogueID;

        public int PriceCatalogueCategoryID;

        public long StoreUserID;

        public string MeasurementValue_Sq = string.Empty;

        public static long AccountID;

        public string PriceCatalogueCategoryName = string.Empty;

        public string ProductImage = string.Empty;

        public string CatalogueName = string.Empty;

        public string strSitepath = string.Empty;

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        public string productImagePath = string.Empty;

        public string artworkFile = string.Empty;

        public string SesseionKey = string.Empty;

        public string FileExtension = string.Empty;

        public string FileName = string.Empty;

        public string CSvFileName = string.Empty;

        public string FileName1 = string.Empty;

        public string FileName2 = string.Empty;

        public string FileName3 = string.Empty;

        public string OriginalFileName1 = string.Empty;

        public string OriginalFileName2 = string.Empty;

        public string OriginalFileName3 = string.Empty;

        public string ReportFileName1 = string.Empty;

        public string ReportFileName2 = string.Empty;

        public string ReportFileName3 = string.Empty;

        public string AccountType = "P";

        public string searchProducts = string.Empty;

        public string searchCookie = string.Empty;

        public string HelpText = string.Empty;

        public string SystemName = string.Empty;

        public string PrintReadyFile = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string PrintReadyFilePath_Verify = string.Empty;

        public static string imagePath;

        public static string thumbImg;

        public static string eprintDocument;

        public static string eprintDocumentName;

        public static string StyleDdlQty;

        public string isPDMyCartRightPannel = "1";

        public string isPriceExTax = "1";

        public string isTax = "1";

        public string isSubTotal = "1";

        public string isTotalPrice = "1";

        public string isQuantity = "1";

        public string IsShowStock = "1";

        public static int companyID;

        public bool IsZip2taxEnabled;

        public string IsAdditionalOption = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string RequestType = string.Empty;

        public int AvailableQuantity;

        public bool isCustomerCode;

        public bool isItemCode;

        public string SecureDocPath = string.Empty;

        public string ServerName = string.Empty;

        public string ShowStockReplenish = string.Empty;

        public long SelectedDeptUser;

        public string IsCampaignEnabled = string.Empty;

        public long GetAccountID;

        private string MeasurementValue = string.Empty;

        private int RoundOff;

        public bool IsCumulative;

        private DropDownList ddlPriceQty = new DropDownList();

        private TextBox txt_Cumulative_PriceQty = new TextBox();

        private string RightPanelCalc_Enabled = string.Empty;

        private string txtWidth_Style = string.Empty;

        private string txtHeight_Style = string.Empty;

        public string BehalfOfStyle = string.Empty;

        public string ProdCategoryID = string.Empty;

        public string ProductSitePath = string.Empty;

        public int strCount;

        public int strMainCount;

        private string CSV_UploadDownload_Enabled = string.Empty;

        public long TemplateImportID;

        public int CopiedPriceCatalogueId;

        public int MainProductId;

        public string Mode = string.Empty;

        public string IsEnableHidePrice = string.Empty;

        public string IsSpendLimitEnable = string.Empty;

        public long SpendLimitAmount;

        public long SpendAmount;

        public bool IsDisplayAdditionalOptions;

        public bool isEnableAddtoCartStayButton;
        public bool isHideAddtoCartStayButton2 = false;

        public string ProductTaxName = string.Empty;

        public int ProductTaxId;

        public decimal ProductTaxRate;

        public string ZipImageFileName = string.Empty;
        public decimal Dimention = 0;

        public bool Decoration1_Mandadory;
        public bool Decoration2_Mandadory;
        public bool Decoration3_Mandadory;
        public bool Decoration4_Mandadory;
        public bool Decoration5_Mandadory;
        public bool Decoration6_Mandadory;

        public string name1;
        public string name2;
        public string name3;
        public string name4;
        public string name5;
        public string name6;
        bool IsDecoration = false;
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

        static productdetails()
        {
            productdetails.TheURL = "";
            productdetails.AccountID = (long)0;
            productdetails.imagePath = string.Empty;
            productdetails.thumbImg = string.Empty;
            productdetails.eprintDocument = string.Empty;
            productdetails.eprintDocumentName = string.Empty;
            productdetails.StyleDdlQty = string.Empty;
            productdetails.companyID = 0;
        }

        public productdetails()
        {
        }

        public void ApprovalSystem_OrderingProcess()
        {
            string str;
            string str1;
            ProductBasePage.CheckB2BApprovalSystemEnable(productdetails.AccountID);
            DataSet dataSet = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
            str = (dataSet.Tables[0].Rows.Count <= 0 ? "False" : dataSet.Tables[0].Rows[0]["MainApprover"].ToString());
            str1 = (dataSet.Tables[1].Rows.Count <= 0 ? "" : dataSet.Tables[1].Rows[0]["DeptApprover"].ToString());
            string str2 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_app");
            string str3 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_dept");
            string str4 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_user");
            string str5 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_app");
            string str6 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_dept");
            string str7 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_user");
            this.ShowStockReplenish = base.Return_ApprovalOrderingProcess_Settings("showstockreplenish");
            DataSet dataSet1 = OrderBasePage.Select_BehalfUsersOrDept(productdetails.AccountID, this.StoreUserID);
            if (dataSet1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    if (!row.Table.Columns.Contains("FirstName"))
                    {
                        continue;
                    }
                    row["FirstName"] = base.SpecialDecode(row["FirstName"].ToString());
                }
            }
            if (dataSet1.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataSet1.Tables[1].Rows)
                {
                    if (!dataRow.Table.Columns.Contains("FirstName"))
                    {
                        continue;
                    }
                    dataRow["FirstName"] = base.SpecialDecode(dataRow["FirstName"].ToString());
                }
            }
            if (dataSet1.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow row1 in dataSet1.Tables[2].Rows)
                {
                    if (!row1.Table.Columns.Contains("DeptName"))
                    {
                        continue;
                    }
                    row1["DeptName"] = base.SpecialDecode(row1["DeptName"].ToString());
                }
            }
            if (dataSet1.Tables[3].Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataSet1.Tables[3].Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("DeptName"))
                    {
                        continue;
                    }
                    dataRow1["DeptName"] = base.SpecialDecode(dataRow1["DeptName"].ToString());
                }
            }
            if (str5 == "N" && str6 == "N" && str7 == "N" || str5 == "" && str6 == "" && str7 == "")
            {
                if (str.ToLower() == "true" && str2 == "Y")
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- Select User Myself ---", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
                else if (str.ToLower() == "true" && str2 == "O")
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- Select User Myself ---", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
                else if (str1.ToLower() != "" && str3 == "Y")
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- Select User Myself ---", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
                else if (str1.ToLower() != "" && str3 == "O")
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- Select User Myself ---", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
                else if (str.ToLower() == "false" && str1.ToLower() == "" && str4 == "Y")
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
                else if (!(str.ToLower() == "false") || !(str1.ToLower() == "") || !(str4 == "O"))
                {
                    this.divBehalfOf.Visible = false;
                }
                else
                {
                    this.divUserBehalf.Style.Add("display", "block");
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    this.hdnUserBehalf.Value = "1";
                }
            }
            else if ((!(str2 == "N") || !(str3 == "N") || !(str4 == "N")) && (!(str2 == "") || !(str3 == "") || !(str4 == "")))
            {
                bool flag = false;
                if (str.ToLower() == "true" && str2 == "Y")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str5 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "true" && str2 == "O")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str5 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str1.ToLower() != "" && str3 == "Y")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str6 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str1.ToLower() != "" && str3 == "O")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str6 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "false" && str1.ToLower() == "" && str4 == "Y")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[0];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str7 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "false" && str1.ToLower() == "" && str4 == "O")
                {
                    flag = true;
                    this.ddl_BehalfUsers.DataSource = dataSet1.Tables[1];
                    this.ddl_BehalfUsers.DataTextField = "FirstName";
                    this.ddl_BehalfUsers.DataValueField = "StoreUserID";
                    this.ddl_BehalfUsers.DataBind();
                    this.ddl_BehalfUsers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select User Myself --", "0"));
                    if (str7 == "N")
                    {
                        this.hdnUserBehalf.Value = "1";
                        this.divUserBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                if (str.ToLower() == "true" && str5 == "A")
                {
                    flag = true;
                    this.divDeptBehalf.Style.Add("display", "block");
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str2 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "true" && str5 == "O")
                {
                    flag = true;
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str2 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str1.ToLower() != "" && str6 == "A")
                {
                    flag = true;
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str3 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str1.ToLower() != "" && str6 == "O")
                {
                    flag = true;
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str3 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "false" && str1.ToLower() == "" && str7 == "A")
                {
                    flag = true;
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str4 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                else if (str.ToLower() == "false" && str1.ToLower() == "" && str7 == "O")
                {
                    flag = true;
                    this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                    this.ddl_BehalfDepts.DataTextField = "DeptName";
                    this.ddl_BehalfDepts.DataValueField = "DeptID";
                    this.ddl_BehalfDepts.DataBind();
                    this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                    if (str4 == "N")
                    {
                        this.hdnDeptBehalf.Value = "1";
                        this.divDeptBehalf.Style.Add("display", "block");
                    }
                    else
                    {
                        this.divSelectBehalf.Style.Add("display", "block");
                        this.divDeptBehalf.Style.Add("display", "none");
                        this.divUserBehalf.Style.Add("display", "none");
                        this.hdnSelectBehalf.Value = "1";
                    }
                }
                if (!flag)
                {
                    this.divBehalfOf.Visible = false;
                }
            }
            else if (str.ToLower() == "true" && str5 == "A")
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            else if (str.ToLower() == "true" && str5 == "O")
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            else if (str1.ToLower() != "" && str6 == "A")
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            else if (str1.ToLower() != "" && str6 == "O")
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            else if (str.ToLower() == "false" && str1.ToLower() == "" && str7 == "A")
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[2];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            else if (!(str.ToLower() == "false") || !(str1.ToLower() == "") || !(str7 == "O"))
            {
                this.divBehalfOf.Visible = false;
            }
            else
            {
                this.divDeptBehalf.Style.Add("display", "block");
                this.ddl_BehalfDepts.DataSource = dataSet1.Tables[3];
                this.ddl_BehalfDepts.DataTextField = "DeptName";
                this.ddl_BehalfDepts.DataValueField = "DeptID";
                this.ddl_BehalfDepts.DataBind();
                this.ddl_BehalfDepts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Department--", "0"));
                this.hdnDeptBehalf.Value = "1";
            }
            if (this.hdnStockManagement.Value.ToLower() == "true" && this.hdnIsStockItem.Value.ToLower() == "true" && this.hdnDrawStockFrom.Value.ToLower() == "s")
            {
                if (this.ShowStockReplenish.ToLower() == "m")
                {
                    if (str.ToLower() == "true")
                    {
                        this.div_replenishstockcontent.Style.Add("display", "block");
                        return;
                    }
                }
                else if (this.ShowStockReplenish.ToLower() == "d")
                {
                    if (str1.ToLower() != "" || str.ToLower() == "true")
                    {
                        this.div_replenishstockcontent.Style.Add("display", "block");
                        return;
                    }
                }
                else if (this.ShowStockReplenish.ToLower() == "a")
                {
                    this.div_replenishstockcontent.Style.Add("display", "block");
                }
            }
        }

        public void artwork_file(FileUpload fileUpload, long CartID, int count, string Additional, out string fileName)
        {
            string[] strArrays = fileUpload.FileName.ToString().Trim().Split(new char[] { '.' });
            string str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            string str1 = this.comm.ReplaceAllBlankSpace(fileUpload.FileName);
            str1 = this.comm.ReplaceSplSymbol(str1);
            if (str.ToLower() != ".exe" || str.ToLower() != ".jar" || str.ToLower() != ".dll" || str.ToLower() != ".zip" || str.ToLower() != ".asmx" || str.ToLower() != ".asmx.cs" || str.ToLower() != ".aspx" || str.ToLower() != ".aspx.cs" || str.ToLower() != ".ascx" || str.ToLower() != ".ascx.cs" || str.ToLower() != ".asax" || str.ToLower() != ".asax.cs")
            {
                if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//store")))
                {
                    Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//store"));
                }
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork" };
                if (!Directory.Exists(string.Concat(secureDocPath1)))
                {
                    object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork" };
                    Directory.CreateDirectory(string.Concat(objArray1));
                }
                object[] secureDocPath2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                if (!Directory.Exists(string.Concat(secureDocPath2)))
                {
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                    Directory.CreateDirectory(string.Concat(objArray2));
                }
                if (Additional == "yes")
                {
                    if (count == 1)
                    {
                        object[] cartID = new object[] { CartID, "_", count, "_", str1 };
                        productdetails.eprintDocumentName = string.Concat(cartID);
                        FileUpload fpArtwork = this.fp_artwork;
                        object[] secureDocPath3 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                        fpArtwork.SaveAs(string.Concat(secureDocPath3));
                        FileUpload fpArtwork1 = this.fp_artwork;
                        object[] objArray3 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                        fpArtwork1.SaveAs(string.Concat(objArray3));
                    }
                    else if (count == 2)
                    {
                        object[] cartID1 = new object[] { CartID, "_", count, "_", str1 };
                        productdetails.eprintDocumentName = string.Concat(cartID1);
                        FileUpload fpArtwork11 = this.fp_artwork1;
                        object[] secureDocPath4 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                        fpArtwork11.SaveAs(string.Concat(secureDocPath4));
                        FileUpload fileUpload1 = this.fp_artwork1;
                        object[] objArray4 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                        fileUpload1.SaveAs(string.Concat(objArray4));
                    }
                    else if (count == 3)
                    {
                        object[] cartID2 = new object[] { CartID, "_", count, "_", str1 };
                        productdetails.eprintDocumentName = string.Concat(cartID2);
                        FileUpload fpArtwork2 = this.fp_artwork2;
                        object[] secureDocPath5 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                        fpArtwork2.SaveAs(string.Concat(secureDocPath5));
                        FileUpload fpArtwork21 = this.fp_artwork2;
                        object[] objArray5 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                        fpArtwork21.SaveAs(string.Concat(objArray5));
                    }
                }
                else if (count == 1)
                {
                    object[] cartID3 = new object[] { CartID, "_", count, "_", str1 };
                    productdetails.eprintDocumentName = string.Concat(cartID3);
                    FileUpload fpArtworkNoAddoption1 = this.fp_artwork_no_addoption1;
                    object[] secureDocPath6 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption1.SaveAs(string.Concat(secureDocPath6));
                    FileUpload fpArtworkNoAddoption11 = this.fp_artwork_no_addoption1;
                    object[] objArray6 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption11.SaveAs(string.Concat(objArray6));
                }
                else if (count == 2)
                {
                    object[] cartID4 = new object[] { CartID, "_", count, "_", str1 };
                    productdetails.eprintDocumentName = string.Concat(cartID4);
                    FileUpload fpArtworkNoAddoption2 = this.fp_artwork_no_addoption2;
                    object[] secureDocPath7 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption2.SaveAs(string.Concat(secureDocPath7));
                    FileUpload fpArtworkNoAddoption21 = this.fp_artwork_no_addoption2;
                    object[] objArray7 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption21.SaveAs(string.Concat(objArray7));
                }
                else if (count == 3)
                {
                    object[] cartID5 = new object[] { CartID, "_", count, "_", str1 };
                    productdetails.eprintDocumentName = string.Concat(cartID5);
                    FileUpload fpArtworkNoAddoption3 = this.fp_artwork_no_addoption3;
                    object[] secureDocPath8 = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption3.SaveAs(string.Concat(secureDocPath8));
                    FileUpload fpArtworkNoAddoption31 = this.fp_artwork_no_addoption3;
                    object[] objArray8 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", productdetails.eprintDocumentName };
                    fpArtworkNoAddoption31.SaveAs(string.Concat(objArray8));
                }
            }
            else
            {
                this.spn_artworkFile.InnerHtml = string.Concat("Please select valid file, your file extension is '", str, "'.");
            }
            fileName = productdetails.eprintDocumentName;
        }

        public void BindOtherMultipleDropdownList(long PriceCatalogueID)
        {
            DataTable dataTable = ProductBasePage.OtherMultiple_product_Select(PriceCatalogueID, productdetails.companyID);
            this.ddlOtherMultiple.DataSource = dataTable;
            this.ddlOtherMultiple.DataTextField = "CatalogueName";
            this.ddlOtherMultiple.DataValueField = "PriceCatalogueID";
            this.ddlOtherMultiple.DataBind();
        }

        public void BindOtherMultipleDropdownList1(long PriceCatalogueID)
        {
            DataTable dataTable = ProductBasePage.OtherMultiple_product_Select(PriceCatalogueID, productdetails.companyID);
            this.ddlOtherMultiple1.DataSource = dataTable;
            this.ddlOtherMultiple1.DataTextField = "CatalogueName";
            this.ddlOtherMultiple1.DataValueField = "PriceCatalogueID";
            this.ddlOtherMultiple1.DataBind();
        }

        protected void btn_ConfirmEditTemplate_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "save", "javascript:Save_toCart('no','div_btnsave','div_btnsaveprocess');", false);
            long num = (long)0;
            long num1 = (long)0;
            string[] strArrays = this.hid_SaveToCart.Value.Split(new char[] { '»' });
            string empty = string.Empty;
            long num2 = (long)0;
            int num3 = 0;
            if (this.rdstkbreplenish.Checked)
            {
                num3 = 1;
            }
            if (this.ddlCampaign.SelectedValue != "0")
            {
                num2 = Convert.ToInt64(this.ddlCampaign.SelectedItem.Value);
            }
            DataSet dataSet = new DataSet();
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                if (RewriteContext.Current.Params["CartItemID"] != null)
                {
                    string str = RewriteContext.Current.Params["CartItemID"].ToString();
                    char[] keySeparator = new char[] { this.KeySeparator };
                    num1 = (long)Convert.ToInt32(str.Split(keySeparator)[1]);
                    dataSet = ProductBasePage.Cart_Details_Edit(num1);
                }
            }
            else if (base.Request.Params["CartItemID"] != null)
            {
                num1 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                dataSet = ProductBasePage.Cart_Details_Edit(num1);
            }
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '~' });
                    for (int j = 0; j <= (int)strArrays1.Length - 1; j++)
                    {
                        if (strArrays1[0].ToLower() == "cookieid")
                        {
                            empty = this.comm.UniqueID;
                        }
                        else if (strArrays1[0].ToLower() == "userid")
                        {
                            Convert.ToInt64(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "carttotalprice")
                        {
                            num4 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "carttax")
                        {
                            num5 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "cartshipping")
                        {
                            num6 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                    }
                }
                if (i == 4)
                {
                    if (this.StoreUserID != (long)0)
                    {
                        empty = "";
                    }
                    if (num1 <= (long)0)
                    {
                        num = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num4, num5, num6, false);
                    }
                    else
                    {
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            num = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_Cart(empty, num, num1, this.StoreUserID, num4, num5, num6);
                    }
                }
            }
            long priceCatalogueID = (long)this.PriceCatalogueID;
            long num7 = (long)0;
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);
            long num14 = (long)0;
            string[] strArrays2 = this.hid_SaveToCartItems.Value.Split(new char[] { '»' });
            for (int k = 0; k <= (int)strArrays2.Length - 1; k++)
            {
                if (strArrays2[k] != "")
                {
                    num7 = Convert.ToInt64(strArrays2[0]);
                    num8 = Convert.ToDecimal(strArrays2[1]);
                    num9 = Convert.ToDecimal(strArrays2[2]);
                    num11 = Convert.ToDecimal(strArrays2[3]);
                    num10 = Convert.ToDecimal(strArrays2[4]);
                    num14 = Convert.ToInt64(strArrays2[5]);
                    num12 = Convert.ToDecimal(strArrays2[6]);
                    num13 = Convert.ToDecimal(strArrays2[7]);
                }
            }
            if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
            {
                if (this.fp_artwork.HasFile)
                {
                    this.artwork_file(this.fp_artwork, num, 1, "yes", out this.FileName);
                    this.FileName1 = this.FileName;
                    string[] strArrays3 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName1 = strArrays3[0].ToString();
                    this.ReportFileName1 = strArrays3[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                }
                else if (this.lblfp_artwork.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                {
                    this.FileName1 = this.lblFileName1.Text;
                    this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                    this.OriginalFileName1 = this.lblfp_artwork.Text;
                }
                if (this.fp_artwork1.HasFile)
                {
                    this.artwork_file(this.fp_artwork1, num, 2, "yes", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays4 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays4[0].ToString();
                    this.ReportFileName2 = strArrays4[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork1.FileName.ToString();
                }
                else if (this.lblfp_artwork1.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                {
                    this.FileName2 = this.lblFileName2.Text;
                    this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                    this.OriginalFileName2 = this.lblfp_artwork1.Text;
                }
                if (this.fp_artwork2.HasFile)
                {
                    this.artwork_file(this.fp_artwork2, num, 3, "yes", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays5 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays5[0].ToString();
                    this.ReportFileName3 = strArrays5[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork2.FileName.ToString();
                }
                else if (this.lblfp_artwork2.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                {
                    this.FileName3 = this.lblFileName3.Text;
                    this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                    this.OriginalFileName3 = this.lblfp_artwork2.Text;
                }
            }
            else
            {
                if (this.fp_artwork_no_addoption1.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption1, num, 1, "no", out this.FileName);
                    this.FileName1 = this.FileName;
                    string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName1 = strArrays6[0].ToString();
                    this.ReportFileName1 = strArrays6[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                }
                else if (this.lblfp_artwork_no_addoption1.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                {
                    this.FileName1 = this.lblFileName1.Text;
                    this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                    this.OriginalFileName1 = this.lblfp_artwork_no_addoption1.Text;
                }
                if (this.fp_artwork_no_addoption2.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption2, num, 2, "no", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays7[0].ToString();
                    this.ReportFileName2 = strArrays7[1].ToString();
                    this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                }
                else if (this.lblfp_artwork_no_addoption2.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                {
                    this.FileName2 = this.lblFileName2.Text;
                    this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                    this.OriginalFileName2 = this.lblfp_artwork_no_addoption2.Text;
                }
                if (this.fp_artwork_no_addoption3.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption3, num, 3, "no", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays8[0].ToString();
                    this.ReportFileName3 = strArrays8[1].ToString();
                    this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                }
                else if (this.lblfp_artwork_no_addoption3.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                {
                    this.FileName3 = this.lblFileName3.Text;
                    this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                    this.OriginalFileName3 = this.lblfp_artwork_no_addoption3.Text;
                }
            }
            if (num1 <= (long)0)
            {
                if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                {
                    this.hdnDeptBehalf.Value = "1";
                }
                else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                {
                    this.hdnDeptBehalf.Value = "0";
                    this.hdnUserBehalf.Value = "0";
                }
                else
                {
                    this.hdnUserBehalf.Value = "1";
                }
                if (this.hdnUserBehalf.Value == "1")
                {
                    num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num3, num2, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                else if (this.hdnDeptBehalf.Value != "1")
                {
                    num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num3, num2, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                else
                {
                    try
                    {
                        Convert.ToInt64(this.hdnDepuUserID.Value);
                    }
                    catch
                    {
                        this.hdnDepuUserID.Value = "0";
                    }
                    num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num3, num2, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
            }
            else
            {
                if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedValue) > (long)0 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                {
                    this.hdnDeptBehalf.Value = "1";
                }
                if (this.hdnUserBehalf.Value == "1")
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        num = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                    }
                    CartBasePage.Update_CartItem(num, num1, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), (long)0, num3, num2, num12, num13, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                else if (this.hdnDeptBehalf.Value != "1")
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        num = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                    }
                    CartBasePage.Update_CartItem(num, num1, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num3, num2, num12, num13, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                else
                {
                    try
                    {
                        Convert.ToInt64(this.hdnDepuUserID.Value);
                    }
                    catch
                    {
                        this.hdnDepuUserID.Value = "0";
                    }
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        num = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                    }
                    CartBasePage.Update_CartItem(num, num1, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), num3, num2, num12, num13, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
            }
            long num15 = (long)0;
            string empty1 = string.Empty;
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            long num18 = (long)0;
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            string str1 = string.Empty;
            int num21 = 0;
            long num22 = (long)0;
            string empty2 = string.Empty;
            string[] strArrays9 = this.hid_SaveToAdditionalItems.Value.Split(new char[] { 'µ' });
            CartBasePage.Delete_CartAdditionalItems(num1);
            for (int l = 0; l <= (int)strArrays9.Length - 1; l++)
            {
                if (strArrays9[l] != "")
                {
                    string[] strArrays10 = strArrays9[l].ToString().Split(new char[] { '±' });
                    string freeTextQuestionLong = string.Empty;
                    string calculation_type = string.Empty;
                    for (int m = 0; m <= (int)strArrays10.Length - 1; m++)
                    {
                        if (strArrays10[m] != "")
                        {
                            string[] strArrays11 = strArrays10[m].Split(new char[] { '»' });
                            if (strArrays11[0] != "")
                            {
                                if (strArrays11[0] == "OthercostID")
                                {
                                    num15 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "Formula")
                                {
                                    empty1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "MarkUp")
                                {
                                    num16 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "TotalPrice")
                                {
                                    num17 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedID")
                                {
                                    num18 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedValue")
                                {
                                    str1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "SelectedPrice")
                                {
                                    num20 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "MarkUpValue")
                                {
                                    num19 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SortOrderNo")
                                {
                                    num21 = Convert.ToInt32(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "ParentWebOtherCostID")
                                {
                                    num22 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "WebOtherCostType")
                                {
                                    empty2 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "CalculationType")
                                {
                                    calculation_type = strArrays11[1];
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(calculation_type))
                    {
                        if (calculation_type == "l")
                        {
                            freeTextQuestionLong = str1;
                        }
                    }
                    if (dataSet.Tables.Count <= 1)
                    {
                        CartBasePage.Insert_into_CartAdditionalItems(num1, num15, empty1, num16, num17, num18, str1, num20, num19, num21, num22, empty2,freeTextQuestionLong);
                    }
                    else if (dataSet.Tables[2].Rows.Count <= 0)
                    {
                        CartBasePage.Insert_into_CartAdditionalItems(num1, num15, empty1, num16, num17, num18, str1, num20, num19, num21, num22, empty2,freeTextQuestionLong);
                    }
                    else
                    {
                        CartBasePage.Update_CartAdditionalItems(num1, num15, empty1, num16, num17, num18, str1, num20, num19, num21, num22, empty2, freeTextQuestionLong);
                    }
                }
            }
            if (base.Request.Params["OrdKey"] != null)
            {
                if (base.Request.Params["CartItemID"] != null)
                {
                    num1 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                    CartBasePage.Insert_NotesOnEditItem(num1, this.StoreUserID);
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "order.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString()));
            }
            if (this.Session["IsEditableProduct"] != null)
            {
                if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                {
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response = base.Response;
                        object[] objArray = new object[] { this.strSitepath, "editable_template", ConnectionClass.KeySeparator, num1, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                        response.Redirect(string.Concat(objArray));
                        return;
                    }
                    HttpResponse httpResponse = base.Response;
                    object[] fileExtension = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num1, "&ID=", priceCatalogueID };
                    httpResponse.Redirect(string.Concat(fileExtension));
                    return;
                }
                if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                {
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response1 = base.Response;
                        object[] keySeparator1 = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                        response1.Redirect(string.Concat(keySeparator1));
                        return;
                    }
                    HttpResponse httpResponse1 = base.Response;
                    object[] fileExtension1 = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num, "&amp;PID=", priceCatalogueID };
                    httpResponse1.Redirect(string.Concat(fileExtension1));
                }
            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            addtoCart(false);
            //object[] keySeparator;
            //string value = this.hdnSingleQuestionValues.Value;
            //int num = 0;
            //long num1 = (long)0;
            //if (this.rdstkbreplenish.Checked)
            //{
            //    num = 1;
            //}
            //if (this.ddlCampaign.SelectedValue != "0")
            //{
            //    num1 = Convert.ToInt64(this.ddlCampaign.SelectedItem.Value);
            //}
            //string str = this.hdnPrintReadyFile.Value;
            //char[] chrArray = new char[] { ',' };
            //string[] strArrays = str.Split(chrArray);
            //if (strArrays[2] != "true")
            //{
            //    long num2 = (long)0;
            //    long num3 = (long)0;
            //    string value1 = this.hid_SaveToCart.Value;
            //    chrArray = new char[] { '»' };
            //    string[] strArrays1 = value1.Split(chrArray);
            //    string empty = string.Empty;
            //    decimal num4 = new decimal(0);
            //    decimal num5 = new decimal(0);
            //    decimal num6 = new decimal(0);
            //    for (int i = 0; i <= (int)strArrays1.Length - 1; i++)
            //    {
            //        if (strArrays1[i] != "")
            //        {
            //            string str1 = strArrays1[i].ToString();
            //            chrArray = new char[] { '~' };
            //            string[] strArrays2 = str1.Split(chrArray);
            //            for (int j = 0; j <= (int)strArrays2.Length - 1; j++)
            //            {
            //                if (strArrays2[0].ToLower() == "cookieid")
            //                {
            //                    empty = this.comm.UniqueID;
            //                }
            //                else if (strArrays2[0].ToLower() == "userid")
            //                {
            //                    Convert.ToInt64(strArrays2[1].ToString());
            //                }
            //                else if (strArrays2[0].ToLower() == "carttotalprice")
            //                {
            //                    num4 = Convert.ToDecimal(strArrays2[1].ToString());
            //                }
            //                else if (strArrays2[0].ToLower() == "carttax")
            //                {
            //                    num5 = Convert.ToDecimal(strArrays2[1].ToString());
            //                }
            //                else if (strArrays2[0].ToLower() == "cartshipping")
            //                {
            //                    num6 = Convert.ToDecimal(strArrays2[1].ToString());
            //                }
            //            }
            //        }
            //        if (i == 4)
            //        {
            //            if (this.StoreUserID != (long)0)
            //            {
            //                empty = "";
            //            }
            //            num2 = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num4, num5, num6);
            //        }
            //    }
            //    long priceCatalogueID = (long)this.PriceCatalogueID;
            //    if (this.hdnStockForMultipleProducts.Value == "m")
            //    {
            //        priceCatalogueID = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
            //    }
            //    long num7 = (long)0;
            //    decimal num8 = new decimal(0);
            //    decimal num9 = new decimal(0);
            //    decimal num10 = new decimal(0);
            //    decimal num11 = new decimal(0);
            //    decimal num12 = new decimal(0);
            //    decimal num13 = new decimal(0);
            //    long num14 = (long)0;
            //    string value2 = this.hid_SaveToCartItems.Value;
            //    chrArray = new char[] { '»' };
            //    string[] strArrays3 = value2.Split(chrArray);
            //    for (int k = 0; k <= (int)strArrays3.Length - 1; k++)
            //    {
            //        if (strArrays3[k] != "")
            //        {
            //            num7 = Convert.ToInt64(strArrays3[0]);
            //            num8 = Convert.ToDecimal(strArrays3[1]);
            //            num9 = Convert.ToDecimal(strArrays3[2]);
            //            num11 = Convert.ToDecimal(strArrays3[3]);
            //            num10 = Convert.ToDecimal(strArrays3[4]);
            //            num14 = Convert.ToInt64(strArrays3[5]);
            //            num12 = Convert.ToDecimal(strArrays3[6]);
            //            num13 = Convert.ToDecimal(strArrays3[7]);
            //        }
            //    }
            //    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
            //    {
            //        if (this.fp_artwork.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork, num2, 1, "yes", out this.FileName);
            //            this.FileName1 = this.FileName;
            //            string[] strArrays4 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName1 = strArrays4[0].ToString();
            //            this.ReportFileName1 = strArrays4[1].ToString();
            //            this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
            //        }
            //        if (this.fp_artwork1.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork1, num2, 2, "yes", out this.FileName);
            //            this.FileName2 = this.FileName;
            //            string[] strArrays5 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName2 = strArrays5[0].ToString();
            //            this.ReportFileName2 = strArrays5[1].ToString();
            //            this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
            //        }
            //        if (this.fp_artwork2.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork2, num2, 3, "yes", out this.FileName);
            //            this.FileName3 = this.FileName;
            //            string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName3 = strArrays6[0].ToString();
            //            this.ReportFileName3 = strArrays6[1].ToString();
            //            this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
            //        }
            //    }
            //    else
            //    {
            //        if (this.fp_artwork_no_addoption1.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork_no_addoption1, num2, 1, "no", out this.FileName);
            //            this.FileName1 = this.FileName;
            //            string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName1 = strArrays7[0].ToString();
            //            this.ReportFileName1 = strArrays7[1].ToString();
            //            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
            //        }
            //        if (this.fp_artwork_no_addoption2.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork_no_addoption2, num2, 2, "no", out this.FileName);
            //            this.FileName2 = this.FileName;
            //            string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName2 = strArrays8[0].ToString();
            //            this.ReportFileName2 = strArrays8[1].ToString();
            //            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
            //        }
            //        if (this.fp_artwork_no_addoption3.HasFile)
            //        {
            //            this.artwork_file(this.fp_artwork_no_addoption3, num2, 3, "no", out this.FileName);
            //            this.FileName3 = this.FileName;
            //            string[] strArrays9 = this.preflight_File(this.FileName, priceCatalogueID);
            //            this.FileName3 = strArrays9[0].ToString();
            //            this.ReportFileName3 = strArrays9[1].ToString();
            //            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
            //        }
            //    }
            //    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
            //    {
            //        this.hdnDeptBehalf.Value = "1";
            //    }
            //    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
            //    {
            //        this.hdnDeptBehalf.Value = "0";
            //        this.hdnUserBehalf.Value = "0";
            //    }
            //    else
            //    {
            //        this.hdnUserBehalf.Value = "1";
            //    }
            //    if (this.hdnUserBehalf.Value == "1")
            //    {
            //        num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //    }
            //    else if (this.hdnDeptBehalf.Value != "1")
            //    {
            //        num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //    }
            //    else
            //    {
            //        try
            //        {
            //            Convert.ToInt64(this.hdnDepuUserID.Value);
            //        }
            //        catch
            //        {
            //            this.hdnDepuUserID.Value = "0";
            //        }
            //        num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //    }
            //    long num15 = (long)0;
            //    string empty1 = string.Empty;
            //    decimal num16 = new decimal(0);
            //    decimal num17 = new decimal(0);
            //    long num18 = (long)0;
            //    decimal num19 = new decimal(0);
            //    decimal num20 = new decimal(0);
            //    string empty2 = string.Empty;
            //    int num21 = 0;
            //    long num22 = (long)0;
            //    string str2 = string.Empty;
            //    string value3 = this.hid_SaveToAdditionalItems.Value;
            //    chrArray = new char[] { 'µ' };
            //    string[] strArrays10 = value3.Split(chrArray);
            //    CartBasePage.Delete_CartAdditionalItems(num3);
            //    for (int l = 0; l <= (int)strArrays10.Length - 1; l++)
            //    {
            //        if (strArrays10[l] != "")
            //        {
            //            string str3 = strArrays10[l].ToString();
            //            chrArray = new char[] { '±' };
            //            string[] strArrays11 = str3.Split(chrArray);
            //            for (int m = 0; m <= (int)strArrays11.Length - 1; m++)
            //            {
            //                if (strArrays11[m] != "")
            //                {
            //                    string str4 = strArrays11[m];
            //                    chrArray = new char[] { '»' };
            //                    string[] strArrays12 = str4.Split(chrArray);
            //                    if (strArrays12[0] != "")
            //                    {
            //                        if (strArrays12[0] == "OthercostID")
            //                        {
            //                            num15 = Convert.ToInt64(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "Formula")
            //                        {
            //                            empty1 = strArrays12[1];
            //                        }
            //                        else if (strArrays12[0] == "MarkUp")
            //                        {
            //                            num16 = Convert.ToDecimal(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "TotalPrice")
            //                        {
            //                            num17 = Convert.ToDecimal(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "SelectedID")
            //                        {
            //                            num18 = Convert.ToInt64(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "SelectedValue")
            //                        {
            //                            empty2 = strArrays12[1];
            //                        }
            //                        else if (strArrays12[0] == "SelectedPrice")
            //                        {
            //                            num20 = Convert.ToDecimal(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "MarkUpValue")
            //                        {
            //                            num19 = Convert.ToDecimal(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "SortOrderNo")
            //                        {
            //                            num21 = Convert.ToInt32(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "ParentWebOtherCostID")
            //                        {
            //                            num22 = Convert.ToInt64(strArrays12[1]);
            //                        }
            //                        else if (strArrays12[0] == "WebOtherCostType")
            //                        {
            //                            str2 = strArrays12[1];
            //                        }
            //                    }
            //                }
            //            }
            //            CartBasePage.Insert_into_CartAdditionalItems(num3, num15, empty1, num16, num17, num18, empty2, num20, num19, num21, num22, str2);
            //        }
            //    }
            //    if (ConnectionClass.RewriteModule.ToLower() == "on")
            //    {
            //        HttpResponse response = base.Response;
            //        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num2, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
            //        response.Redirect(string.Concat(keySeparator));
            //        return;
            //    }
            //    if (base.Request.Params["CID"] != null)
            //    {
            //        int num23 = Convert.ToInt32(base.Request.Params["CID"]);
            //        HttpResponse httpResponse = base.Response;
            //        keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num2, "&amp;PID=", priceCatalogueID, "&CID=", num23 };
            //        httpResponse.Redirect(string.Concat(keySeparator));
            //        return;
            //    }
            //    HttpResponse response1 = base.Response;
            //    keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num2, "&amp;PID=", priceCatalogueID, "&CID=0" };
            //    response1.Redirect(string.Concat(keySeparator));
            //}
            //else
            //{
            //    if (base.Request.Params["type"] != null)
            //    {
            //        this.pnlNormalDetails.Style.Add("display", "block");
            //        this.pnlConfirmPRFile.Style.Add("display", "none");
            //        long num24 = (long)0;
            //        long num25 = (long)0;
            //        string value4 = this.hid_SaveToCart.Value;
            //        chrArray = new char[] { '»' };
            //        string[] strArrays13 = value4.Split(chrArray);
            //        string uniqueID = string.Empty;
            //        decimal num26 = new decimal(0);
            //        decimal num27 = new decimal(0);
            //        decimal num28 = new decimal(0);
            //        for (int n = 0; n <= (int)strArrays13.Length - 1; n++)
            //        {
            //            if (strArrays13[n] != "")
            //            {
            //                string str5 = strArrays13[n].ToString();
            //                chrArray = new char[] { '~' };
            //                string[] strArrays14 = str5.Split(chrArray);
            //                for (int o = 0; o <= (int)strArrays14.Length - 1; o++)
            //                {
            //                    if (strArrays14[0].ToLower() == "cookieid")
            //                    {
            //                        uniqueID = this.comm.UniqueID;
            //                    }
            //                    else if (strArrays14[0].ToLower() == "userid")
            //                    {
            //                        Convert.ToInt64(strArrays14[1].ToString());
            //                    }
            //                    else if (strArrays14[0].ToLower() == "carttotalprice")
            //                    {
            //                        num26 = Convert.ToDecimal(strArrays14[1].ToString());
            //                    }
            //                    else if (strArrays14[0].ToLower() == "carttax")
            //                    {
            //                        num27 = Convert.ToDecimal(strArrays14[1].ToString());
            //                    }
            //                    else if (strArrays14[0].ToLower() == "cartshipping")
            //                    {
            //                        num28 = Convert.ToDecimal(strArrays14[1].ToString());
            //                    }
            //                }
            //            }
            //            if (n == 4)
            //            {
            //                if (this.StoreUserID != (long)0)
            //                {
            //                    uniqueID = "";
            //                }
            //                num24 = CartBasePage.Insert_into_Cart(uniqueID, this.StoreUserID, num26, num27, num28);
            //            }
            //        }
            //        long priceCatalogueID1 = (long)this.PriceCatalogueID;
            //        if (this.hdnStockForMultipleProducts.Value == "m")
            //        {
            //            priceCatalogueID1 = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
            //        }
            //        long num29 = (long)0;
            //        decimal num30 = new decimal(0);
            //        decimal num31 = new decimal(0);
            //        decimal num32 = new decimal(0);
            //        decimal num33 = new decimal(0);
            //        decimal num34 = new decimal(0);
            //        decimal num35 = new decimal(0);
            //        long num36 = (long)0;
            //        string value5 = this.hid_SaveToCartItems.Value;
            //        chrArray = new char[] { '»' };
            //        string[] strArrays15 = value5.Split(chrArray);
            //        for (int p = 0; p <= (int)strArrays15.Length - 1; p++)
            //        {
            //            if (strArrays15[p] != "")
            //            {
            //                num29 = Convert.ToInt64(strArrays15[0]);
            //                num30 = Convert.ToDecimal(strArrays15[1]);
            //                num31 = Convert.ToDecimal(strArrays15[2]);
            //                num33 = Convert.ToDecimal(strArrays15[3]);
            //                num32 = Convert.ToDecimal(strArrays15[4]);
            //                num36 = Convert.ToInt64(strArrays15[5]);
            //                num34 = Convert.ToDecimal(strArrays15[6]);
            //                num35 = Convert.ToDecimal(strArrays15[7]);
            //            }
            //        }
            //        if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
            //        {
            //            if (this.fp_artwork.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork, num24, 1, "yes", out this.FileName);
            //                this.FileName1 = this.FileName;
            //                string[] strArrays16 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName1 = strArrays16[0].ToString();
            //                this.ReportFileName1 = strArrays16[1].ToString();
            //                this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
            //            }
            //            if (this.fp_artwork1.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork1, num24, 2, "yes", out this.FileName);
            //                this.FileName2 = this.FileName;
            //                string[] strArrays17 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName2 = strArrays17[0].ToString();
            //                this.ReportFileName2 = strArrays17[1].ToString();
            //                this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
            //            }
            //            if (this.fp_artwork2.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork2, num24, 3, "yes", out this.FileName);
            //                this.FileName3 = this.FileName;
            //                string[] strArrays18 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName3 = strArrays18[0].ToString();
            //                this.ReportFileName3 = strArrays18[1].ToString();
            //                this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
            //            }
            //        }
            //        else
            //        {
            //            if (this.fp_artwork_no_addoption1.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption1, num24, 1, "no", out this.FileName);
            //                this.FileName1 = this.FileName;
            //                string[] strArrays19 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName1 = strArrays19[0].ToString();
            //                this.ReportFileName1 = strArrays19[1].ToString();
            //                this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
            //            }
            //            if (this.fp_artwork_no_addoption2.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption2, num24, 2, "no", out this.FileName);
            //                this.FileName2 = this.FileName;
            //                string[] strArrays20 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName2 = strArrays20[0].ToString();
            //                this.ReportFileName2 = strArrays20[1].ToString();
            //                this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
            //            }
            //            if (this.fp_artwork_no_addoption3.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption3, num24, 3, "no", out this.FileName);
            //                this.FileName3 = this.FileName;
            //                string[] strArrays21 = this.preflight_File(this.FileName, priceCatalogueID1);
            //                this.FileName3 = strArrays21[0].ToString();
            //                this.ReportFileName3 = strArrays21[1].ToString();
            //                this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
            //            }
            //        }
            //        if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
            //        {
            //            this.hdnDeptBehalf.Value = "1";
            //        }
            //        else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
            //        {
            //            this.hdnDeptBehalf.Value = "0";
            //            this.hdnUserBehalf.Value = "0";
            //        }
            //        else
            //        {
            //            this.hdnUserBehalf.Value = "1";
            //        }
            //        if (this.hdnUserBehalf.Value == "1")
            //        {
            //            num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, "", num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        else if (this.hdnDeptBehalf.Value != "1")
            //        {
            //            num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, "", num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        else
            //        {
            //            try
            //            {
            //                Convert.ToInt64(this.hdnDepuUserID.Value);
            //            }
            //            catch
            //            {
            //                this.hdnDepuUserID.Value = "0";
            //            }
            //            num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, "", num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        long num37 = (long)0;
            //        string empty3 = string.Empty;
            //        string empty4 = string.Empty;
            //        decimal num38 = new decimal(0);
            //        decimal num39 = new decimal(0);
            //        long num40 = (long)0;
            //        decimal num41 = new decimal(0);
            //        decimal num42 = new decimal(0);
            //        string empty5 = string.Empty;
            //        int num43 = 0;
            //        long num44 = (long)0;
            //        string empty6 = string.Empty;
            //        string value6 = this.hid_SaveToAdditionalItems.Value;
            //        chrArray = new char[] { 'µ' };
            //        string[] strArrays22 = value6.Split(chrArray);
            //        CartBasePage.Delete_CartAdditionalItems(num25);
            //        for (int q = 0; q <= (int)strArrays22.Length - 1; q++)
            //        {
            //            if (strArrays22[q] != "")
            //            {
            //                string str6 = strArrays22[q].ToString();
            //                chrArray = new char[] { '±' };
            //                string[] strArrays23 = str6.Split(chrArray);
            //                for (int r = 0; r <= (int)strArrays23.Length - 1; r++)
            //                {
            //                    if (strArrays23[r] != "")
            //                    {
            //                        string str7 = strArrays23[r];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays24 = str7.Split(chrArray);
            //                        if (strArrays24[0] != "")
            //                        {
            //                            if (strArrays24[0] == "OthercostID")
            //                            {
            //                                num37 = Convert.ToInt64(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "Formula")
            //                            {
            //                                empty3 = strArrays24[1];
            //                            }
            //                            else if (strArrays24[0] == "MarkUp")
            //                            {
            //                                num38 = Convert.ToDecimal(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "TotalPrice")
            //                            {
            //                                num39 = Convert.ToDecimal(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "SelectedID")
            //                            {
            //                                num40 = Convert.ToInt64(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "SelectedValue")
            //                            {
            //                                empty5 = strArrays24[1];
            //                            }
            //                            else if (strArrays24[0] == "SelectedPrice")
            //                            {
            //                                num42 = Convert.ToDecimal(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "MarkUpValue")
            //                            {
            //                                num41 = Convert.ToDecimal(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "SortOrderNo")
            //                            {
            //                                num43 = Convert.ToInt32(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "ParentWebOtherCostID")
            //                            {
            //                                num44 = Convert.ToInt64(strArrays24[1]);
            //                            }
            //                            else if (strArrays24[0] == "WebOtherCostType")
            //                            {
            //                                empty6 = strArrays24[1];
            //                            }
            //                        }
            //                    }
            //                }
            //                CartBasePage.Insert_into_CartAdditionalItems(num25, num37, empty3, num38, num39, num40, empty5, num42, num41, num43, num44, empty6);
            //            }
            //        }
            //        if (ConnectionClass.RewriteModule.ToLower() == "on")
            //        {
            //            HttpResponse httpResponse1 = base.Response;
            //            keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num24, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
            //            httpResponse1.Redirect(string.Concat(keySeparator));
            //            return;
            //        }
            //        if (base.Request.Params["CID"] == null)
            //        {
            //            HttpResponse response2 = base.Response;
            //            keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num24, "&amp;PID=", priceCatalogueID1, "&CID=0" };
            //            response2.Redirect(string.Concat(keySeparator));
            //            return;
            //        }
            //        int num45 = Convert.ToInt32(base.Request.Params["CID"]);
            //        HttpResponse httpResponse2 = base.Response;
            //        keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num24, "&amp;PID=", priceCatalogueID1, "&CID=", num45 };
            //        httpResponse2.Redirect(string.Concat(keySeparator));
            //        return;
            //    }
            //    if (strArrays[1] != "true")
            //    {
            //        this.pnlNormalDetails.Style.Add("display", "block");
            //        this.pnlConfirmPRFile.Style.Add("display", "none");
            //        long num46 = (long)0;
            //        long num47 = (long)0;
            //        string value7 = this.hid_SaveToCart.Value;
            //        chrArray = new char[] { '»' };
            //        string[] strArrays25 = value7.Split(chrArray);
            //        string uniqueID1 = string.Empty;
            //        decimal num48 = new decimal(0);
            //        decimal num49 = new decimal(0);
            //        decimal num50 = new decimal(0);
            //        for (int s = 0; s <= (int)strArrays25.Length - 1; s++)
            //        {
            //            if (strArrays25[s] != "")
            //            {
            //                string str8 = strArrays25[s].ToString();
            //                chrArray = new char[] { '~' };
            //                string[] strArrays26 = str8.Split(chrArray);
            //                for (int t = 0; t <= (int)strArrays26.Length - 1; t++)
            //                {
            //                    if (strArrays26[0].ToLower() == "cookieid")
            //                    {
            //                        uniqueID1 = this.comm.UniqueID;
            //                    }
            //                    else if (strArrays26[0].ToLower() == "userid")
            //                    {
            //                        Convert.ToInt64(strArrays26[1].ToString());
            //                    }
            //                    else if (strArrays26[0].ToLower() == "carttotalprice")
            //                    {
            //                        num48 = Convert.ToDecimal(strArrays26[1].ToString());
            //                    }
            //                    else if (strArrays26[0].ToLower() == "carttax")
            //                    {
            //                        num49 = Convert.ToDecimal(strArrays26[1].ToString());
            //                    }
            //                    else if (strArrays26[0].ToLower() == "cartshipping")
            //                    {
            //                        num50 = Convert.ToDecimal(strArrays26[1].ToString());
            //                    }
            //                }
            //            }
            //            if (s == 4)
            //            {
            //                if (this.StoreUserID != (long)0)
            //                {
            //                    uniqueID1 = "";
            //                }
            //                num46 = CartBasePage.Insert_into_Cart(uniqueID1, this.StoreUserID, num48, num49, num50);
            //            }
            //        }
            //        long priceCatalogueID2 = (long)this.PriceCatalogueID;
            //        if (this.hdnStockForMultipleProducts.Value == "m")
            //        {
            //            priceCatalogueID2 = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
            //        }
            //        long num51 = (long)0;
            //        decimal num52 = new decimal(0);
            //        decimal num53 = new decimal(0);
            //        decimal num54 = new decimal(0);
            //        decimal num55 = new decimal(0);
            //        decimal num56 = new decimal(0);
            //        decimal num57 = new decimal(0);
            //        long num58 = (long)0;
            //        string value8 = this.hid_SaveToCartItems.Value;
            //        chrArray = new char[] { '»' };
            //        string[] strArrays27 = value8.Split(chrArray);
            //        for (int u = 0; u <= (int)strArrays27.Length - 1; u++)
            //        {
            //            if (strArrays27[u] != "")
            //            {
            //                num51 = Convert.ToInt64(strArrays27[0]);
            //                num52 = Convert.ToDecimal(strArrays27[1]);
            //                num53 = Convert.ToDecimal(strArrays27[2]);
            //                num55 = Convert.ToDecimal(strArrays27[3]);
            //                num54 = Convert.ToDecimal(strArrays27[4]);
            //                num58 = Convert.ToInt64(strArrays27[5]);
            //                num56 = Convert.ToDecimal(strArrays27[6]);
            //                num57 = Convert.ToDecimal(strArrays27[7]);
            //            }
            //        }
            //        if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
            //        {
            //            if (this.fp_artwork.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork, num46, 1, "yes", out this.FileName);
            //                this.FileName1 = this.FileName;
            //                string[] strArrays28 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName1 = strArrays28[0].ToString();
            //                this.ReportFileName1 = strArrays28[1].ToString();
            //                this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
            //            }
            //            if (this.fp_artwork1.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork1, num46, 2, "yes", out this.FileName);
            //                this.FileName2 = this.FileName;
            //                string[] strArrays29 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName2 = strArrays29[0].ToString();
            //                this.ReportFileName2 = strArrays29[1].ToString();
            //                this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
            //            }
            //            if (this.fp_artwork2.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork2, num46, 3, "yes", out this.FileName);
            //                this.FileName3 = this.FileName;
            //                string[] strArrays30 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName3 = strArrays30[0].ToString();
            //                this.ReportFileName3 = strArrays30[1].ToString();
            //                this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
            //            }
            //        }
            //        else
            //        {
            //            if (this.fp_artwork_no_addoption1.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption1, num46, 1, "no", out this.FileName);
            //                this.FileName1 = this.FileName;
            //                string[] strArrays31 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName1 = strArrays31[0].ToString();
            //                this.ReportFileName1 = strArrays31[1].ToString();
            //                this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
            //            }
            //            if (this.fp_artwork_no_addoption2.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption2, num46, 2, "no", out this.FileName);
            //                this.FileName2 = this.FileName;
            //                string[] strArrays32 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName2 = strArrays32[0].ToString();
            //                this.ReportFileName2 = strArrays32[1].ToString();
            //                this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
            //            }
            //            if (this.fp_artwork_no_addoption3.HasFile)
            //            {
            //                this.artwork_file(this.fp_artwork_no_addoption3, num46, 3, "no", out this.FileName);
            //                this.FileName3 = this.FileName;
            //                string[] strArrays33 = this.preflight_File(this.FileName, priceCatalogueID2);
            //                this.FileName3 = strArrays33[0].ToString();
            //                this.ReportFileName3 = strArrays33[1].ToString();
            //                this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
            //            }
            //        }
            //        if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
            //        {
            //            this.hdnDeptBehalf.Value = "1";
            //        }
            //        else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
            //        {
            //            this.hdnDeptBehalf.Value = "0";
            //            this.hdnUserBehalf.Value = "0";
            //        }
            //        else
            //        {
            //            this.hdnUserBehalf.Value = "1";
            //        }
            //        if (this.hdnUserBehalf.Value == "1")
            //        {
            //            num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        else if (this.hdnDeptBehalf.Value != "1")
            //        {
            //            num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        else
            //        {
            //            try
            //            {
            //                Convert.ToInt64(this.hdnDepuUserID.Value);
            //            }
            //            catch
            //            {
            //                this.hdnDepuUserID.Value = "0";
            //            }
            //            num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            //        }
            //        long num59 = (long)0;
            //        string empty7 = string.Empty;
            //        decimal num60 = new decimal(0);
            //        decimal num61 = new decimal(0);
            //        long num62 = (long)0;
            //        decimal num63 = new decimal(0);
            //        decimal num64 = new decimal(0);
            //        string empty8 = string.Empty;
            //        int num65 = 0;
            //        long num66 = (long)0;
            //        string empty9 = string.Empty;
            //        string value9 = this.hid_SaveToAdditionalItems.Value;
            //        chrArray = new char[] { 'µ' };
            //        string[] strArrays34 = value9.Split(chrArray);
            //        CartBasePage.Delete_CartAdditionalItems(num47);
            //        for (int v = 0; v <= (int)strArrays34.Length - 1; v++)
            //        {
            //            if (strArrays34[v] != "")
            //            {
            //                string str9 = strArrays34[v].ToString();
            //                chrArray = new char[] { '±' };
            //                string[] strArrays35 = str9.Split(chrArray);
            //                for (int w = 0; w <= (int)strArrays35.Length - 1; w++)
            //                {
            //                    if (strArrays35[w] != "")
            //                    {
            //                        string str10 = strArrays35[w];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays36 = str10.Split(chrArray);
            //                        if (strArrays36[0] != "")
            //                        {
            //                            if (strArrays36[0] == "OthercostID")
            //                            {
            //                                num59 = Convert.ToInt64(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "Formula")
            //                            {
            //                                empty7 = strArrays36[1];
            //                            }
            //                            else if (strArrays36[0] == "MarkUp")
            //                            {
            //                                num60 = Convert.ToDecimal(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "TotalPrice")
            //                            {
            //                                num61 = Convert.ToDecimal(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "SelectedID")
            //                            {
            //                                num62 = Convert.ToInt64(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "SelectedValue")
            //                            {
            //                                empty8 = strArrays36[1];
            //                            }
            //                            else if (strArrays36[0] == "SelectedPrice")
            //                            {
            //                                num64 = Convert.ToDecimal(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "MarkUpValue")
            //                            {
            //                                num63 = Convert.ToDecimal(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "SortOrderNo")
            //                            {
            //                                num65 = Convert.ToInt32(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "ParentWebOtherCostID")
            //                            {
            //                                num66 = Convert.ToInt64(strArrays36[1]);
            //                            }
            //                            else if (strArrays36[0] == "WebOtherCostType")
            //                            {
            //                                empty9 = strArrays36[1];
            //                            }
            //                        }
            //                    }
            //                }
            //                CartBasePage.Insert_into_CartAdditionalItems(num47, num59, empty7, num60, num61, num62, empty8, num64, num63, num65, num66, empty9);
            //            }
            //        }
            //        if (ConnectionClass.RewriteModule.ToLower() == "on")
            //        {
            //            HttpResponse response3 = base.Response;
            //            keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num46, ConnectionClass.KeySeparator, priceCatalogueID2, ConnectionClass.FileExtension };
            //            response3.Redirect(string.Concat(keySeparator));
            //            return;
            //        }
            //        if (base.Request.Params["CID"] == null)
            //        {
            //            HttpResponse httpResponse3 = base.Response;
            //            keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num46, "&amp;PID=", priceCatalogueID2, "&CID=0" };
            //            httpResponse3.Redirect(string.Concat(keySeparator));
            //            return;
            //        }
            //        int num67 = Convert.ToInt32(base.Request.Params["CID"]);
            //        HttpResponse response4 = base.Response;
            //        keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num46, "&amp;PID=", priceCatalogueID2, "&CID=", num67 };
            //        response4.Redirect(string.Concat(keySeparator));
            //        return;
            //    }
            //    if (strArrays[0] == "1")
            //    {
            //        if (this.searchProducts == "")
            //        {
            //            this.searchProducts = "0";
            //        }
            //        this.pnlNormalDetails.Style.Add("display", "none");
            //        this.pnlConfirmPRFile.Style.Add("display", "block");
            //        this.btn_ConfirmAdd1.Style.Add("display", "block");
            //        this.btn_ConfirmEditTemplate1.Style.Add("display", "none");
            //        return;
            //    }
            //}
        }

        protected void btnAddtoCartStay_Click(object sender, EventArgs e)
        {
            addtoCart(true);
        }
        protected void btnAddtoCartStay1_Click(object sender, EventArgs e)
        {
            addtoCart(true);
        }
        protected void addtoCart(bool stay)
        {
            object[] keySeparator;
            string value = this.hdnSingleQuestionValues.Value;
            int num = 0;
            long num1 = (long)0;
            double? DecorationCost1 = null;
            double? DecorationCost2 = null;
            double? DecorationCost3 = null;
            double? DecorationCost4 = null;
            double? DecorationCost5 = null;
            double? DecorationCost6 = null;

            double DecorCost1;
            double DecorCost2;
            double DecorCost3;
            double DecorCost4;
            double DecorCost5;
            double DecorCost6;


            var Result = double.TryParse(hdnDecorationCost1.Value, out DecorCost1);
            if (DecorCost1 > 0)
            {
                DecorationCost1 = DecorCost1;
            }
            Result = double.TryParse(hdnDecorationCost2.Value, out DecorCost2);
            if (DecorCost2 > 0)
            {
                DecorationCost2 = DecorCost2;
            }
            Result = double.TryParse(hdnDecorationCost3.Value, out DecorCost3);
            if (DecorCost3 > 0)
            {
                DecorationCost3 = DecorCost3;
            }
            Result = double.TryParse(hdnDecorationCost4.Value, out DecorCost4);
            if (DecorCost4 > 0)
            {
                DecorationCost4 = DecorCost4;
            }
            Result = double.TryParse(hdnDecorationCost5.Value, out DecorCost5);
            if (DecorCost5 > 0)
            {
                DecorationCost5 = DecorCost5;
            }
            Result = double.TryParse(hdnDecorationCost6.Value, out DecorCost6);
            if (DecorCost6 > 0)
            {
                DecorationCost6 = DecorCost6;
            }
            if (this.rdstkbreplenish.Checked)
            {
                num = 1;
            }
            if (this.ddlCampaign.SelectedValue != "0")
            {
                num1 = Convert.ToInt64(this.ddlCampaign.SelectedItem.Value);
            }
            string str = this.hdnPrintReadyFile.Value;
            char[] chrArray = new char[] { ',' };
            string[] strArrays = str.Split(chrArray);
            if (strArrays[2] != "true")
            {
                long num2 = (long)0;
                long num3 = (long)0;
                string value1 = this.hid_SaveToCart.Value;
                chrArray = new char[] { '»' };
                string[] strArrays1 = value1.Split(chrArray);
                string empty = string.Empty;
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                for (int i = 0; i <= (int)strArrays1.Length - 1; i++)
                {
                    if (strArrays1[i] != "")
                    {
                        string str1 = strArrays1[i].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays2 = str1.Split(chrArray);
                        for (int j = 0; j <= (int)strArrays2.Length - 1; j++)
                        {
                            if (strArrays2[0].ToLower() == "cookieid")
                            {
                                empty = this.comm.UniqueID;
                            }
                            else if (strArrays2[0].ToLower() == "userid")
                            {
                                Convert.ToInt64(strArrays2[1].ToString());
                            }
                            else if (strArrays2[0].ToLower() == "carttotalprice")
                            {
                                num4 = Convert.ToDecimal(strArrays2[1].ToString());
                            }
                            else if (strArrays2[0].ToLower() == "carttax")
                            {
                                num5 = Convert.ToDecimal(strArrays2[1].ToString());
                            }
                            else if (strArrays2[0].ToLower() == "cartshipping")
                            {
                                num6 = Convert.ToDecimal(strArrays2[1].ToString());
                            }
                        }
                    }
                    if (i == 4)
                    {
                        if (this.StoreUserID != (long)0)
                        {
                            empty = "";
                        }
                        num2 = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num4, num5, num6, false);
                    }
                }
                long priceCatalogueID = (long)this.PriceCatalogueID;
                if (this.hdnStockForMultipleProducts.Value == "m")
                {
                    if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                    {
                        priceCatalogueID = Convert.ToInt64(this.ddlOtherMultiple.Items[1].Value);
                    }
                    else
                    {
                        priceCatalogueID = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
                    }
                }





                long num7 = (long)0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                long num14 = (long)0;
                string value2 = this.hid_SaveToCartItems.Value;
                chrArray = new char[] { '»' };
                string[] strArrays3 = value2.Split(chrArray);
                for (int k = 0; k <= (int)strArrays3.Length - 1; k++)
                {
                    if (strArrays3[k] != "")
                    {
                        num7 = Convert.ToInt64(strArrays3[0]);
                        num8 = Convert.ToDecimal(strArrays3[1]);
                        num9 = Convert.ToDecimal(strArrays3[2]);
                        num11 = Convert.ToDecimal(strArrays3[3]);
                        num10 = Convert.ToDecimal(strArrays3[4]);
                        num14 = Convert.ToInt64(strArrays3[5]);
                        num12 = Convert.ToDecimal(strArrays3[6]);
                        num13 = Convert.ToDecimal(strArrays3[7]);
                    }
                }
                if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
                {
                    if (this.fp_artwork.HasFile)
                    {
                        this.artwork_file(this.fp_artwork, num2, 1, "yes", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays4 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays4[0].ToString();
                        this.ReportFileName1 = strArrays4[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                    }
                    if (this.fp_artwork1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork1, num2, 2, "yes", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays5 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays5[0].ToString();
                        this.ReportFileName2 = strArrays5[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                    }
                    if (this.fp_artwork2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork2, num2, 3, "yes", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays6[0].ToString();
                        this.ReportFileName3 = strArrays6[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                    }
                }
                else
                {
                    if (this.fp_artwork_no_addoption1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption1, num2, 1, "no", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays7[0].ToString();
                        this.ReportFileName1 = strArrays7[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                    }
                    if (this.fp_artwork_no_addoption2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption2, num2, 2, "no", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays8[0].ToString();
                        this.ReportFileName2 = strArrays8[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                    }
                    if (this.fp_artwork_no_addoption3.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption3, num2, 3, "no", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays9 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays9[0].ToString();
                        this.ReportFileName3 = strArrays9[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                    }
                }
                if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                {
                    this.hdnDeptBehalf.Value = "1";
                }
                else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                {
                    this.hdnDeptBehalf.Value = "0";
                    this.hdnUserBehalf.Value = "0";
                }
                else
                {
                    this.hdnUserBehalf.Value = "1";
                }
                if (this.hdnUserBehalf.Value == "1")
                {
                    num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, this.hdnJobName.Value, num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                else if (this.hdnDeptBehalf.Value != "1")
                {
                    if (this.hdnStockForMultipleProducts.Value == "m")
                    {
                        if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                        {
                            string Matrixvalue = '%' + this.hid_MultipleMatrixValues.Value;
                            chrArray = new char[] { '%' };
                            string[] strArrays20 = Matrixvalue.Split(chrArray);

                            if (this.ddlOtherMultiple.Items.Count > 0)
                            {
                                for (int m = 1; m <= this.ddlOtherMultiple.Items.Count - 1; m++)
                                {
                                    chrArray = new char[] { '»' };
                                    string[] strArrays21 = strArrays20[m].Split(chrArray);

                                    string uniqueID = string.Empty;
                                    long num26 = (long)0;
                                    decimal num27 = new decimal(0);
                                    decimal num28 = new decimal(0);
                                    for (int n = 0; n <= (int)strArrays21.Length - 1; n++)
                                    {
                                        if (strArrays21[n] != "")
                                        {
                                            string str5 = strArrays21[n].ToString();
                                            chrArray = new char[] { '~' };
                                            string[] strArrays22 = str5.Split(chrArray);
                                            for (int o = 0; o <= (int)strArrays22.Length - 1; o++)
                                            {
                                                if (strArrays22[0].ToLower() == "cookieid")
                                                {
                                                    uniqueID = this.comm.UniqueID;
                                                }
                                                else if (strArrays22[0].ToLower() == "userid")
                                                {
                                                    Convert.ToInt64(strArrays22[1].ToString());
                                                }
                                                else if (strArrays22[0].ToLower() == "carttotalprice")
                                                {
                                                    num26 = Convert.ToInt64(strArrays22[1].ToString());
                                                }
                                                else if (strArrays22[0].ToLower() == "carttax")
                                                {
                                                    num27 = Convert.ToDecimal(strArrays22[1].ToString());
                                                }
                                                else if (strArrays22[0].ToLower() == "cartshipping")
                                                {
                                                    num28 = Convert.ToDecimal(strArrays22[1].ToString());
                                                }
                                            }
                                        }
                                    }

                                    if (num26 > 0)
                                    {
                                        num3 = CartBasePage.Insert_into_CartItem(num2, Convert.ToInt64(this.ddlOtherMultiple.Items[m].Value), this.hdnJobName.Value, num26, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                                    }

                                }
                            }

                        }
                        else
                        {
                            num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, this.hdnJobName.Value, num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                        }
                    }
                    else
                    {
                        num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, this.hdnJobName.Value, num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                }
                else
                {
                    try
                    {
                        Convert.ToInt64(this.hdnDepuUserID.Value);
                    }
                    catch
                    {
                        this.hdnDepuUserID.Value = "0";
                    }
                    num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, this.hdnJobName.Value, num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                }
                long num15 = (long)0;
                string empty1 = string.Empty;
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                long num18 = (long)0;
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                string empty2 = string.Empty;
                int num21 = 0;
                long num22 = (long)0;
                string str2 = string.Empty;
                string value3 = this.hid_SaveToAdditionalItems.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays10 = value3.Split(chrArray);
                CartBasePage.Delete_CartAdditionalItems(num3);
                for (int l = 0; l <= (int)strArrays10.Length - 1; l++)
                {
                    if (strArrays10[l] != "")
                    {
                        string str3 = strArrays10[l].ToString();
                        string freeTextQuestionLong = string.Empty;
                        string calculation_type = string.Empty;
                        chrArray = new char[] { '±' };
                        string[] strArrays11 = str3.Split(chrArray);
                        for (int m = 0; m <= (int)strArrays11.Length - 1; m++)
                        {
                            if (strArrays11[m] != "")
                            {
                                string str4 = strArrays11[m];
                                chrArray = new char[] { '»' };
                                string[] strArrays12 = str4.Split(chrArray);
                                if (strArrays12[0] != "")
                                {
                                    if (strArrays12[0] == "OthercostID")
                                    {
                                        num15 = Convert.ToInt64(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "Formula")
                                    {
                                        empty1 = strArrays12[1];
                                    }
                                    else if (strArrays12[0] == "MarkUp")
                                    {
                                        num16 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "TotalPrice")
                                    {
                                        num17 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "SelectedID")
                                    {
                                        num18 = Convert.ToInt64(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "SelectedValue")
                                    {
                                        empty2 = strArrays12[1];
                                    }
                                    else if (strArrays12[0] == "SelectedPrice")
                                    {
                                        num20 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "MarkUpValue")
                                    {
                                        num19 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "SortOrderNo")
                                    {
                                        num21 = Convert.ToInt32(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "ParentWebOtherCostID")
                                    {
                                        num22 = Convert.ToInt64(strArrays12[1]);
                                    }
                                    else if (strArrays12[0] == "WebOtherCostType")
                                    {
                                        str2 = strArrays12[1];
                                    }
                                    else if (strArrays12[0] == "CalculationType")
                                    {
                                        calculation_type = strArrays12[1];
                                    }
                                }
                            }
                        }
                        if(!string.IsNullOrEmpty(calculation_type))
                        {
                            if(calculation_type == "l")
                            {
                                freeTextQuestionLong = empty2;
                            }
                        }
                        CartBasePage.Insert_into_CartAdditionalItems(num3, num15, empty1, num16, num17, num18, empty2, num20, num19, num21, num22, str2, freeTextQuestionLong);
                    }
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    HttpResponse response = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num2, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                    if (!stay)
                    {
                        response.Redirect(string.Concat(keySeparator));
                    }
                    return;
                }
                if (base.Request.Params["CID"] != null)
                {
                    int num23 = Convert.ToInt32(base.Request.Params["CID"]);
                    HttpResponse httpResponse = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num2, "&amp;PID=", priceCatalogueID, "&CID=", num23 };
                    if (!stay)
                    {
                        httpResponse.Redirect(string.Concat(keySeparator));
                    }

                    return;
                }
                HttpResponse response1 = base.Response;
                keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num2, "&amp;PID=", priceCatalogueID, "&CID=0" };
                if (!stay)
                {
                    response1.Redirect(string.Concat(keySeparator));
                }
            }
            else
            {
                if (base.Request.Params["type"] != null)
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num24 = (long)0;
                    long num25 = (long)0;
                    string value4 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays13 = value4.Split(chrArray);
                    string uniqueID = string.Empty;
                    decimal num26 = new decimal(0);
                    decimal num27 = new decimal(0);
                    decimal num28 = new decimal(0);
                    for (int n = 0; n <= (int)strArrays13.Length - 1; n++)
                    {
                        if (strArrays13[n] != "")
                        {
                            string str5 = strArrays13[n].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays14 = str5.Split(chrArray);
                            for (int o = 0; o <= (int)strArrays14.Length - 1; o++)
                            {
                                if (strArrays14[0].ToLower() == "cookieid")
                                {
                                    uniqueID = this.comm.UniqueID;
                                }
                                else if (strArrays14[0].ToLower() == "userid")
                                {
                                    Convert.ToInt64(strArrays14[1].ToString());
                                }
                                else if (strArrays14[0].ToLower() == "carttotalprice")
                                {
                                    num26 = Convert.ToDecimal(strArrays14[1].ToString());
                                }
                                else if (strArrays14[0].ToLower() == "carttax")
                                {
                                    num27 = Convert.ToDecimal(strArrays14[1].ToString());
                                }
                                else if (strArrays14[0].ToLower() == "cartshipping")
                                {
                                    num28 = Convert.ToDecimal(strArrays14[1].ToString());
                                }
                            }
                        }
                        if (n == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID = "";
                            }
                            num24 = CartBasePage.Insert_into_Cart(uniqueID, this.StoreUserID, num26, num27, num28, false);
                        }
                    }
                    long priceCatalogueID1 = (long)this.PriceCatalogueID;
                    if (this.hdnStockForMultipleProducts.Value == "m")
                    {
                        priceCatalogueID1 = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
                    }
                    long num29 = (long)0;
                    decimal num30 = new decimal(0);
                    decimal num31 = new decimal(0);
                    decimal num32 = new decimal(0);
                    decimal num33 = new decimal(0);
                    decimal num34 = new decimal(0);
                    decimal num35 = new decimal(0);
                    long num36 = (long)0;
                    string value5 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays15 = value5.Split(chrArray);
                    for (int p = 0; p <= (int)strArrays15.Length - 1; p++)
                    {
                        if (strArrays15[p] != "")
                        {
                            num29 = Convert.ToInt64(strArrays15[0]);
                            num30 = Convert.ToDecimal(strArrays15[1]);
                            num31 = Convert.ToDecimal(strArrays15[2]);
                            num33 = Convert.ToDecimal(strArrays15[3]);
                            num32 = Convert.ToDecimal(strArrays15[4]);
                            num36 = Convert.ToInt64(strArrays15[5]);
                            num34 = Convert.ToDecimal(strArrays15[6]);
                            num35 = Convert.ToDecimal(strArrays15[7]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num24, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays16 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays16[0].ToString();
                            this.ReportFileName1 = strArrays16[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num24, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays17 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays17[0].ToString();
                            this.ReportFileName2 = strArrays17[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num24, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays18 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays18[0].ToString();
                            this.ReportFileName3 = strArrays18[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num24, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays19 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays19[0].ToString();
                            this.ReportFileName1 = strArrays19[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num24, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays20 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays20[0].ToString();
                            this.ReportFileName2 = strArrays20[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num24, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays21 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays21[0].ToString();
                            this.ReportFileName3 = strArrays21[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                        }
                    }
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, this.hdnJobName.Value, num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, this.hdnJobName.Value, num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        num25 = CartBasePage.Insert_into_CartItem(num24, priceCatalogueID1, this.hdnJobName.Value, num29, num30, this.FileName1, this.FileName2, this.FileName3, num31, num32, num33, num36, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num34, num35, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    long num37 = (long)0;
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    decimal num38 = new decimal(0);
                    decimal num39 = new decimal(0);
                    long num40 = (long)0;
                    decimal num41 = new decimal(0);
                    decimal num42 = new decimal(0);
                    string empty5 = string.Empty;
                    int num43 = 0;
                    long num44 = (long)0;
                    string empty6 = string.Empty;
                    string value6 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays22 = value6.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num25);
                    for (int q = 0; q <= (int)strArrays22.Length - 1; q++)
                    {
                        if (strArrays22[q] != "")
                        {
                            string str6 = strArrays22[q].ToString();
                            string freeTextQuestionLong = string.Empty;
                            string calculation_type = string.Empty;
                            chrArray = new char[] { '±' };
                            string[] strArrays23 = str6.Split(chrArray);
                            for (int r = 0; r <= (int)strArrays23.Length - 1; r++)
                            {
                                if (strArrays23[r] != "")
                                {
                                    string str7 = strArrays23[r];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays24 = str7.Split(chrArray);
                                    if (strArrays24[0] != "")
                                    {
                                        if (strArrays24[0] == "OthercostID")
                                        {
                                            num37 = Convert.ToInt64(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "Formula")
                                        {
                                            empty3 = strArrays24[1];
                                        }
                                        else if (strArrays24[0] == "MarkUp")
                                        {
                                            num38 = Convert.ToDecimal(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "TotalPrice")
                                        {
                                            num39 = Convert.ToDecimal(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "SelectedID")
                                        {
                                            num40 = Convert.ToInt64(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "SelectedValue")
                                        {
                                            empty5 = strArrays24[1];
                                        }
                                        else if (strArrays24[0] == "SelectedPrice")
                                        {
                                            num42 = Convert.ToDecimal(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "MarkUpValue")
                                        {
                                            num41 = Convert.ToDecimal(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "SortOrderNo")
                                        {
                                            num43 = Convert.ToInt32(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "ParentWebOtherCostID")
                                        {
                                            num44 = Convert.ToInt64(strArrays24[1]);
                                        }
                                        else if (strArrays24[0] == "WebOtherCostType")
                                        {
                                            empty6 = strArrays24[1];
                                        }
                                        else if (strArrays24[0] == "CalculationType")
                                        {
                                            calculation_type = strArrays24[1];
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(calculation_type))
                            {
                                if (calculation_type == "l")
                                {
                                    freeTextQuestionLong = empty5;
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num25, num37, empty3, num38, num39, num40, empty5, num42, num41, num43, num44, empty6, freeTextQuestionLong);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num24, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
                        if (!stay)
                        {
                            httpResponse1.Redirect(string.Concat(keySeparator));
                        }
                        return;
                    }
                    if (base.Request.Params["CID"] == null)
                    {
                        HttpResponse response2 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num24, "&amp;PID=", priceCatalogueID1, "&CID=0" };
                        if (!stay)
                        {
                            response2.Redirect(string.Concat(keySeparator));
                        }
                        return;
                    }
                    int num45 = Convert.ToInt32(base.Request.Params["CID"]);
                    HttpResponse httpResponse2 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num24, "&amp;PID=", priceCatalogueID1, "&CID=", num45 };
                    if (!stay)
                    {
                        httpResponse2.Redirect(string.Concat(keySeparator));
                    }
                    return;
                }
                if (strArrays[1] != "true")
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num46 = (long)0;
                    long num47 = (long)0;
                    string value7 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays25 = value7.Split(chrArray);
                    string uniqueID1 = string.Empty;
                    decimal num48 = new decimal(0);
                    decimal num49 = new decimal(0);
                    decimal num50 = new decimal(0);
                    for (int s = 0; s <= (int)strArrays25.Length - 1; s++)
                    {
                        if (strArrays25[s] != "")
                        {
                            string str8 = strArrays25[s].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays26 = str8.Split(chrArray);
                            for (int t = 0; t <= (int)strArrays26.Length - 1; t++)
                            {
                                if (strArrays26[0].ToLower() == "cookieid")
                                {
                                    uniqueID1 = this.comm.UniqueID;
                                }
                                else if (strArrays26[0].ToLower() == "userid")
                                {
                                    Convert.ToInt64(strArrays26[1].ToString());
                                }
                                else if (strArrays26[0].ToLower() == "carttotalprice")
                                {
                                    num48 = Convert.ToDecimal(strArrays26[1].ToString());
                                }
                                else if (strArrays26[0].ToLower() == "carttax")
                                {
                                    num49 = Convert.ToDecimal(strArrays26[1].ToString());
                                }
                                else if (strArrays26[0].ToLower() == "cartshipping")
                                {
                                    num50 = Convert.ToDecimal(strArrays26[1].ToString());
                                }
                            }
                        }
                        if (s == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID1 = "";
                            }
                            num46 = CartBasePage.Insert_into_Cart(uniqueID1, this.StoreUserID, num48, num49, num50, false);
                        }
                    }
                    long priceCatalogueID2 = (long)this.PriceCatalogueID;
                    if (this.hdnStockForMultipleProducts.Value == "m")
                    {
                        priceCatalogueID2 = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
                    }
                    long num51 = (long)0;
                    decimal num52 = new decimal(0);
                    decimal num53 = new decimal(0);
                    decimal num54 = new decimal(0);
                    decimal num55 = new decimal(0);
                    decimal num56 = new decimal(0);
                    decimal num57 = new decimal(0);
                    long num58 = (long)0;
                    string value8 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays27 = value8.Split(chrArray);
                    for (int u = 0; u <= (int)strArrays27.Length - 1; u++)
                    {
                        if (strArrays27[u] != "")
                        {
                            num51 = Convert.ToInt64(strArrays27[0]);
                            num52 = Convert.ToDecimal(strArrays27[1]);
                            num53 = Convert.ToDecimal(strArrays27[2]);
                            num55 = Convert.ToDecimal(strArrays27[3]);
                            num54 = Convert.ToDecimal(strArrays27[4]);
                            num58 = Convert.ToInt64(strArrays27[5]);
                            num56 = Convert.ToDecimal(strArrays27[6]);
                            num57 = Convert.ToDecimal(strArrays27[7]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num46, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays28 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName1 = strArrays28[0].ToString();
                            this.ReportFileName1 = strArrays28[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num46, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays29 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName2 = strArrays29[0].ToString();
                            this.ReportFileName2 = strArrays29[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num46, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays30 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName3 = strArrays30[0].ToString();
                            this.ReportFileName3 = strArrays30[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num46, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays31 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName1 = strArrays31[0].ToString();
                            this.ReportFileName1 = strArrays31[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num46, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays32 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName2 = strArrays32[0].ToString();
                            this.ReportFileName2 = strArrays32[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num46, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays33 = this.preflight_File(this.FileName, priceCatalogueID2);
                            this.FileName3 = strArrays33[0].ToString();
                            this.ReportFileName3 = strArrays33[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                        }
                    }
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        num47 = CartBasePage.Insert_into_CartItem(num46, priceCatalogueID2, "", num51, num52, this.FileName1, this.FileName2, this.FileName3, num53, num54, num55, num58, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num56, num57, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    long num59 = (long)0;
                    string empty7 = string.Empty;
                    decimal num60 = new decimal(0);
                    decimal num61 = new decimal(0);
                    long num62 = (long)0;
                    decimal num63 = new decimal(0);
                    decimal num64 = new decimal(0);
                    string empty8 = string.Empty;
                    int num65 = 0;
                    long num66 = (long)0;
                    string empty9 = string.Empty;
                    string value9 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays34 = value9.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num47);
                    for (int v = 0; v <= (int)strArrays34.Length - 1; v++)
                    {
                        if (strArrays34[v] != "")
                        {
                            string str9 = strArrays34[v].ToString();
                            string freeTextQuestionLong = string.Empty;
                            string calculation_type = string.Empty;
                            chrArray = new char[] { '±' };
                            string[] strArrays35 = str9.Split(chrArray);
                            for (int w = 0; w <= (int)strArrays35.Length - 1; w++)
                            {
                                if (strArrays35[w] != "")
                                {
                                    string str10 = strArrays35[w];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays36 = str10.Split(chrArray);
                                    if (strArrays36[0] != "")
                                    {
                                        if (strArrays36[0] == "OthercostID")
                                        {
                                            num59 = Convert.ToInt64(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "Formula")
                                        {
                                            empty7 = strArrays36[1];
                                        }
                                        else if (strArrays36[0] == "MarkUp")
                                        {
                                            num60 = Convert.ToDecimal(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "TotalPrice")
                                        {
                                            num61 = Convert.ToDecimal(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "SelectedID")
                                        {
                                            num62 = Convert.ToInt64(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "SelectedValue")
                                        {
                                            empty8 = strArrays36[1];
                                        }
                                        else if (strArrays36[0] == "SelectedPrice")
                                        {
                                            num64 = Convert.ToDecimal(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "MarkUpValue")
                                        {
                                            num63 = Convert.ToDecimal(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "SortOrderNo")
                                        {
                                            num65 = Convert.ToInt32(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "ParentWebOtherCostID")
                                        {
                                            num66 = Convert.ToInt64(strArrays36[1]);
                                        }
                                        else if (strArrays36[0] == "WebOtherCostType")
                                        {
                                            empty9 = strArrays36[1];
                                        }
                                        else if (strArrays36[0] == "CalculationType")
                                        {
                                            calculation_type = strArrays36[1];
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(calculation_type))
                            {
                                if (calculation_type == "l")
                                {
                                    freeTextQuestionLong = empty8;
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num47, num59, empty7, num60, num61, num62, empty8, num64, num63, num65, num66, empty9, freeTextQuestionLong);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response3 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num46, ConnectionClass.KeySeparator, priceCatalogueID2, ConnectionClass.FileExtension };
                        if (!stay)
                        {
                            response3.Redirect(string.Concat(keySeparator));
                        }
                        return;
                    }
                    if (base.Request.Params["CID"] == null)
                    {
                        HttpResponse httpResponse3 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num46, "&amp;PID=", priceCatalogueID2, "&CID=0" };
                        if (!stay)
                        {
                            httpResponse3.Redirect(string.Concat(keySeparator));
                        }
                        return;
                    }
                    int num67 = Convert.ToInt32(base.Request.Params["CID"]);
                    HttpResponse response4 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num46, "&amp;PID=", priceCatalogueID2, "&CID=", num67 };
                    if (!stay)
                    {
                        response4.Redirect(string.Concat(keySeparator));
                    }
                    return;
                }
                if (strArrays[0] == "1")
                {
                    if (this.searchProducts == "")
                    {
                        this.searchProducts = "0";
                    }
                    this.pnlNormalDetails.Style.Add("display", "none");
                    this.pnlConfirmPRFile.Style.Add("display", "block");
                    this.btn_ConfirmAdd1.Style.Add("display", "block");
                    this.btn_ConfirmEditTemplate1.Style.Add("display", "none");
                    return;
                }
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "save", "javascript:Save_toCart('no','div_btnsave','div_btnsaveprocess');", false);
            long num = (long)0;
            long num1 = (long)0;
            string[] strArrays = this.hid_SaveToCart.Value.Split(new char[] { '»' });
            string empty = string.Empty;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            long num5 = (long)0;
            int num6 = 0;
            if (this.rdstkbreplenish.Checked)
            {
                num6 = 1;
            }
            if (this.ddlCampaign.SelectedValue != "0")
            {
                num5 = Convert.ToInt64(this.ddlCampaign.SelectedItem.Value);
            }
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '~' });
                    for (int j = 0; j <= (int)strArrays1.Length - 1; j++)
                    {
                        if (strArrays1[0].ToLower() == "cookieid")
                        {
                            empty = this.comm.UniqueID;
                        }
                        else if (strArrays1[0].ToLower() == "userid")
                        {
                            Convert.ToInt64(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "carttotalprice")
                        {
                            num2 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "carttax")
                        {
                            num3 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                        else if (strArrays1[0].ToLower() == "cartshipping")
                        {
                            num4 = Convert.ToDecimal(strArrays1[1].ToString());
                        }
                    }
                }
                if (i == 4)
                {
                    if (this.StoreUserID != (long)0)
                    {
                        empty = "";
                    }
                    num = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num2, num3, num4, false);
                }
            }
            long priceCatalogueID = (long)this.PriceCatalogueID;
            long num7 = (long)0;
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);
            long num14 = (long)0;
            string[] strArrays2 = this.hid_SaveToCartItems.Value.Split(new char[] { '»' });
            for (int k = 0; k <= (int)strArrays2.Length - 1; k++)
            {
                if (strArrays2[k] != "")
                {
                    num7 = Convert.ToInt64(strArrays2[0]);
                    num8 = Convert.ToDecimal(strArrays2[1]);
                    num9 = Convert.ToDecimal(strArrays2[2]);
                    num11 = Convert.ToDecimal(strArrays2[3]);
                    num10 = Convert.ToDecimal(strArrays2[4]);
                    num14 = Convert.ToInt64(strArrays2[5]);
                    num12 = Convert.ToDecimal(strArrays2[6]);
                    num13 = Convert.ToDecimal(strArrays2[7]);
                }
            }
            if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
            {
                if (this.fp_artwork.HasFile)
                {
                    this.artwork_file(this.fp_artwork, num, 1, "yes", out this.FileName);
                    this.FileName1 = this.FileName;
                    string[] strArrays3 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName1 = strArrays3[0].ToString();
                    this.ReportFileName1 = strArrays3[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                }
                if (this.fp_artwork1.HasFile)
                {
                    this.artwork_file(this.fp_artwork1, num, 2, "yes", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays4 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays4[0].ToString();
                    this.ReportFileName2 = strArrays4[1].ToString();
                    this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                }
                if (this.fp_artwork2.HasFile)
                {
                    this.artwork_file(this.fp_artwork2, num, 3, "yes", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays5 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays5[0].ToString();
                    this.ReportFileName3 = strArrays5[1].ToString();
                    this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                }
            }
            else
            {
                if (this.fp_artwork_no_addoption1.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption1, num, 1, "no", out this.FileName);
                    this.FileName1 = this.FileName;
                    string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName1 = strArrays6[0].ToString();
                    this.ReportFileName1 = strArrays6[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                }
                if (this.fp_artwork_no_addoption2.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption2, num, 2, "no", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays7[0].ToString();
                    this.ReportFileName2 = strArrays7[1].ToString();
                    this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                }
                if (this.fp_artwork_no_addoption3.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption3, num, 3, "no", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays8[0].ToString();
                    this.ReportFileName3 = strArrays8[1].ToString();
                    this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                }
            }
            if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
            {
                this.hdnDeptBehalf.Value = "1";
            }
            else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
            {
                this.hdnDeptBehalf.Value = "0";
                this.hdnUserBehalf.Value = "0";
            }
            else
            {
                this.hdnUserBehalf.Value = "1";
            }
            if (this.hdnUserBehalf.Value == "1")
            {
                num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num6, num5, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            }
            else if (this.hdnDeptBehalf.Value != "1")
            {
                num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num6, num5, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            }
            else
            {
                try
                {
                    Convert.ToInt64(this.hdnDepuUserID.Value);
                }
                catch
                {
                    this.hdnDepuUserID.Value = "0";
                }
                num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num14, "C", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num6, num5, num12, num13, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            }
            long num15 = (long)0;
            string str = string.Empty;
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            long num18 = (long)0;
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            string empty1 = string.Empty;
            int num21 = 0;
            long num22 = (long)0;
            string str1 = string.Empty;
            string[] strArrays9 = this.hid_SaveToAdditionalItems.Value.Split(new char[] { 'µ' });
            CartBasePage.Delete_CartAdditionalItems(num1);
            for (int l = 0; l <= (int)strArrays9.Length - 1; l++)
            {
                if (strArrays9[l] != "")
                {
                    string[] strArrays10 = strArrays9[l].ToString().Split(new char[] { '±' });
                    string freeTextQuestionLong = string.Empty;
                    string calculation_type = string.Empty;
                    for (int m = 0; m <= (int)strArrays10.Length - 1; m++)
                    {
                        if (strArrays10[m] != "")
                        {
                            string[] strArrays11 = strArrays10[m].Split(new char[] { '»' });
                            if (strArrays11[0] != "")
                            {
                                if (strArrays11[0] == "OthercostID")
                                {
                                    num15 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "Formula")
                                {
                                    str = strArrays11[1];
                                }
                                else if (strArrays11[0] == "MarkUp")
                                {
                                    num16 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "TotalPrice")
                                {
                                    num17 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedID")
                                {
                                    num18 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedValue")
                                {
                                    empty1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "SelectedPrice")
                                {
                                    num20 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "MarkUpValue")
                                {
                                    num19 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SortOrderNo")
                                {
                                    num21 = Convert.ToInt32(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "ParentWebOtherCostID")
                                {
                                    num22 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "WebOtherCostType")
                                {
                                    str1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "CalculationType")
                                {
                                    calculation_type = strArrays11[1];
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(calculation_type))
                    {
                        if (calculation_type == "l")
                        {
                            freeTextQuestionLong = empty1;
                        }
                    }
                    CartBasePage.Insert_into_CartAdditionalItems(num1, num15, str, num16, num17, num18, empty1, num20, num19, num21, num22, str1, freeTextQuestionLong);
                }
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                HttpResponse response = base.Response;
                object[] keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                response.Redirect(string.Concat(keySeparator));
                return;
            }
            if (base.Request.Params["CID"] == null)
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num, "&amp;PID=", priceCatalogueID, "&CID=0" };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            int num23 = Convert.ToInt32(base.Request.Params["CID"]);
            HttpResponse response1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "shoppingcart.aspx?ID=", num, "&amp;PID=", priceCatalogueID, "&CID=", num23 };
            response1.Redirect(string.Concat(objArray1));
        }

        protected void btnBackToProDet_Click(object sender, EventArgs e)
        {
            this.pnlNormalDetails.Style.Add("display", "block");
            this.pnlConfirmPRFile.Style.Add("display", "none");
        }

        protected void btnEditTemplate_Click(object sender, EventArgs e)
        {
            object[] keySeparator;
            string value = this.hdnSingleQuestionValues.Value;
            char[] chrArray = new char[] { 'μ' };
            string[] strArrays = value.Split(chrArray);
            int num = 0;
            long num1 = (long)0;
            if (this.rdstkbreplenish.Checked)
            {
                num = 1;
            }
            if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
            {
                this.UploadCsvFile_Click(this, null);
            }
            if (this.hdnCampaignSelectedValue.Value != "0")
            {
                num1 = Convert.ToInt64(this.hdnCampaignSelectedValue.Value);
            }
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                string str = strArrays[i];
                chrArray = new char[] { '»' };
                string[] strArrays1 = str.Split(chrArray);
                long num2 = (long)0;
                long num3 = (long)0;
                if (strArrays1[0] != "" && strArrays1[1] != "")
                {
                    num2 = Convert.ToInt64(strArrays1[0]);
                    CartBasePage.UpdateSingleQuestionvalues(num2, Convert.ToInt64(strArrays1[1]));
                }
            }
            string value1 = this.hdnPrintReadyFile.Value;
            chrArray = new char[] { ',' };
            string[] strArrays2 = value1.Split(chrArray);
            if (strArrays2[2] != "true")
            {
                long num4 = (long)0;
                long num5 = (long)0;
                string str1 = this.hid_SaveToCart.Value;
                chrArray = new char[] { '»' };
                string[] strArrays3 = str1.Split(chrArray);
                string empty = string.Empty;
                DataSet dataSet = new DataSet();
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (RewriteContext.Current.Params["CartItemID"] != null)
                    {
                        string str2 = RewriteContext.Current.Params["CartItemID"].ToString();
                        chrArray = new char[] { this.KeySeparator };
                        num5 = (long)Convert.ToInt32(str2.Split(chrArray)[1]);
                        dataSet = ProductBasePage.Cart_Details_Edit(num5);
                    }
                }
                else if (base.Request.Params["CartItemID"] != null)
                {
                    num5 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                    dataSet = ProductBasePage.Cart_Details_Edit(num5);
                }
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                for (int j = 0; j <= (int)strArrays3.Length - 1; j++)
                {
                    if (strArrays3[j] != "")
                    {
                        string str3 = strArrays3[j].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = str3.Split(chrArray);
                        for (int k = 0; k <= (int)strArrays4.Length - 1; k++)
                        {
                            if (strArrays4[0].ToLower() == "cookieid")
                            {
                                empty = this.comm.UniqueID;
                            }
                            else if (strArrays4[0].ToLower() == "userid")
                            {
                                Convert.ToInt64(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "carttotalprice")
                            {
                                num6 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "carttax")
                            {
                                num7 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "cartshipping")
                            {
                                num8 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                        }
                    }
                    if (j == 4)
                    {
                        if (this.StoreUserID != (long)0)
                        {
                            empty = "";
                        }
                        if (num5 <= (long)0)
                        {
                            num4 = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num6, num7, num8, false);
                        }
                        else
                        {
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                num4 = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                            }
                            CartBasePage.Update_Cart(empty, num4, num5, this.StoreUserID, num6, num7, num8);
                        }
                    }
                }
                long priceCatalogueID = (long)this.PriceCatalogueID;
                if (this.hdnStockForMultipleProducts.Value == "m")
                {
                    priceCatalogueID = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
                }
                long num9 = (long)0;
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                long num16 = (long)0;
                string value2 = this.hid_SaveToCartItems.Value;
                chrArray = new char[] { '»' };
                string[] strArrays5 = value2.Split(chrArray);
                for (int l = 0; l <= (int)strArrays5.Length - 1; l++)
                {
                    if (strArrays5[l] != "")
                    {
                        num9 = Convert.ToInt64(strArrays5[0]);
                        num10 = Convert.ToDecimal(strArrays5[1]);
                        num11 = Convert.ToDecimal(strArrays5[2]);
                        num13 = Convert.ToDecimal(strArrays5[3]);
                        num12 = Convert.ToDecimal(strArrays5[4]);
                        num16 = Convert.ToInt64(strArrays5[5]);
                        num14 = Convert.ToDecimal(strArrays5[6]);
                        num15 = Convert.ToDecimal(strArrays5[7]);
                    }
                }
                if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
                {
                    if (this.fp_artwork.HasFile)
                    {
                        this.artwork_file(this.fp_artwork, num4, 1, "yes", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays6[0].ToString();
                        this.ReportFileName1 = strArrays6[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                    }
                    else if (this.lblfp_artwork.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                    {
                        this.FileName1 = this.lblFileName1.Text;
                        this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                        this.OriginalFileName1 = this.lblfp_artwork.Text;
                    }
                    if (this.fp_artwork1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork1, num4, 2, "yes", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays7[0].ToString();
                        this.ReportFileName2 = strArrays7[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                    }
                    else if (this.lblfp_artwork1.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                    {
                        this.FileName2 = this.lblFileName2.Text;
                        this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                        this.OriginalFileName2 = this.lblfp_artwork1.Text;
                    }
                    if (this.fp_artwork2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork2, num4, 3, "yes", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays8[0].ToString();
                        this.ReportFileName3 = strArrays8[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                    }
                    else if (this.lblfp_artwork2.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                    {
                        this.FileName3 = this.lblFileName3.Text;
                        this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                        this.OriginalFileName3 = this.lblfp_artwork2.Text;
                    }
                }
                else
                {
                    if (this.fp_artwork_no_addoption1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption1, num4, 1, "no", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays9 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays9[0].ToString();
                        this.ReportFileName1 = strArrays9[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption1.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                    {
                        this.FileName1 = this.lblFileName1.Text;
                        this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                        this.OriginalFileName1 = this.lblfp_artwork_no_addoption1.Text;
                    }
                    if (this.fp_artwork_no_addoption2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption2, num4, 2, "no", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays10 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays10[0].ToString();
                        this.ReportFileName2 = strArrays10[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption2.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                    {
                        this.FileName2 = this.lblFileName2.Text;
                        this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                        this.OriginalFileName2 = this.lblfp_artwork_no_addoption2.Text;
                    }
                    if (this.fp_artwork_no_addoption3.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption3, num4, 3, "no", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays11 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays11[0].ToString();
                        this.ReportFileName3 = strArrays11[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption3.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                    {
                        this.FileName3 = this.lblFileName3.Text;
                        this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                        this.OriginalFileName3 = this.lblfp_artwork_no_addoption3.Text;
                    }
                }
                if (num5 <= (long)0)
                {
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        num5 = CartBasePage.Insert_into_CartItem(num4, priceCatalogueID, "", num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num14, num15, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        num5 = CartBasePage.Insert_into_CartItem(num4, priceCatalogueID, "", num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num14, num15, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        num5 = CartBasePage.Insert_into_CartItem(num4, priceCatalogueID, "", num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), Convert.ToInt64(this.hdnDepuUserID.Value), num, num1, num14, num15, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                }
                else
                {
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            num4 = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num4, num5, priceCatalogueID, this.hdnJobName.Value, num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), (long)0, num, num1, num14, num15, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            num4 = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num4, num5, priceCatalogueID, this.hdnJobName.Value, num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num14, num15, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            num4 = (long)Convert.ToInt32(dataSet.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num4, num5, priceCatalogueID, this.hdnJobName.Value, num9, num10, this.FileName1, this.FileName2, this.FileName3, num11, num12, num13, num16, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), num, num1, num14, num15, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    if (base.Request.Params["OrdKey"] != null)
                    {
                        this.CartItemID = Convert.ToInt32(base.Request.Params["CartItemID"]);
                        var approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                        var isReapproval = base.Return_ApprovalSystem_Settings("reapproval");
                        var ApprovalStatus = false;

                        var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
                        if (table.Rows.Count > 0)
                        {
                            ApprovalStatus = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
                        }
                        if (ApprovalStatus && approvalType == "da" && isReapproval == "True")
                        {
                            if (this.Session["IsEditableProduct"] != null)
                            {
                                if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                                {
                                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                                    {
                                        if (!this.Upload.HasFile)
                                        {
                                            HttpResponse response = base.Response;
                                            keySeparator = new object[] { this.strSitepath, "editable_template", ConnectionClass.KeySeparator, num5, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                                            response.Redirect(string.Concat(keySeparator));
                                            return;
                                        }
                                        CartBasePage.Update_PDFNameC(Convert.ToInt64(num5), "", "", "", "");
                                        HttpResponse httpResponse = base.Response;
                                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num4, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                                        httpResponse.Redirect(string.Concat(keySeparator));
                                        return;
                                    }
                                    if (!this.Upload.HasFile)
                                    {
                                        HttpResponse response1 = base.Response;
                                        keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num5, "&ID=", priceCatalogueID };
                                        response1.Redirect(string.Concat(keySeparator));
                                        return;
                                    }
                                    CartBasePage.Update_PDFNameC(Convert.ToInt64(num5), "", "", "", "");
                                    HttpResponse httpResponse1 = base.Response;
                                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num4, "&amp;PID=", priceCatalogueID };
                                    httpResponse1.Redirect(string.Concat(keySeparator));
                                    return;
                                }
                                if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                                {

                                    if (ApprovalStatus && approvalType == "da" && isReapproval == "True")
                                    {
                                        HttpResponse response = base.Response;
                                        string[] sitePath = new string[] { strSitepath, "order.aspx?OrderID=" + table.Rows[0]["EstimateID"].ToString() };
                                        response.Redirect(string.Concat(sitePath));
                                    }

                                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                                    {
                                        HttpResponse response2 = base.Response;
                                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num4, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                                        response2.Redirect(string.Concat(keySeparator));
                                        return;
                                    }
                                    HttpResponse httpResponse2 = base.Response;
                                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num4, "&amp;PID=", priceCatalogueID };
                                    httpResponse2.Redirect(string.Concat(keySeparator));
                                }
                            }
                            if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                            {
                                this.hdnDeptBehalf.Value = "1";
                            }
                            else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                            {
                                this.hdnDeptBehalf.Value = "0";
                                this.hdnUserBehalf.Value = "0";
                            }
                            else
                            {
                                this.hdnUserBehalf.Value = "1";
                            }
                            if (this.hdnUserBehalf.Value == "1")
                            {
                                if (Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value) != (long)0)
                                {
                                    OrderBasePage.OrderBehalf_DeptOrUser_Update(base.Request.Params["OrdKey"].ToString(), Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), (long)0);
                                }
                            }
                            else if (this.hdnDeptBehalf.Value == "1")
                            {
                                try
                                {
                                    Convert.ToInt64(this.hdnDepuUserID.Value);
                                }
                                catch
                                {
                                    this.hdnDepuUserID.Value = "0";
                                }
                                if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedValue) != (long)0)
                                {
                                    OrderBasePage.OrderBehalf_DeptOrUser_Update(base.Request.Params["OrdKey"].ToString(), Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value));
                                }
                            }
                        }
                    }
                }
                long num17 = (long)0;
                string empty1 = string.Empty;
                decimal num18 = new decimal(0);
                decimal num19 = new decimal(0);
                long num20 = (long)0;
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                string empty2 = string.Empty;
                int num23 = 0;
                long num24 = (long)0;
                string empty3 = string.Empty;
                string value3 = this.hid_SaveToAdditionalItems.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays12 = value3.Split(chrArray);
                CartBasePage.Delete_CartAdditionalItems(num5);
                for (int m = 0; m <= (int)strArrays12.Length - 1; m++)
                {
                    if (strArrays12[m] != "")
                    {
                        string str4 = strArrays12[m].ToString();
                        string freeTextQuestionLong = string.Empty;
                        string calculation_type = string.Empty;
                        chrArray = new char[] { '±' };
                        string[] strArrays13 = str4.Split(chrArray);
                        for (int n = 0; n <= (int)strArrays13.Length - 1; n++)
                        {
                            if (strArrays13[n] != "")
                            {
                                string str5 = strArrays13[n];
                                chrArray = new char[] { '»' };
                                string[] strArrays14 = str5.Split(chrArray);
                                if (strArrays14[0] != "")
                                {
                                    if (strArrays14[0] == "OthercostID")
                                    {
                                        num17 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "Formula")
                                    {
                                        empty1 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "MarkUp")
                                    {
                                        num18 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "TotalPrice")
                                    {
                                        num19 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedID")
                                    {
                                        num20 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedValue")
                                    {
                                        empty2 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "SelectedPrice")
                                    {
                                        num22 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "MarkUpValue")
                                    {
                                        num21 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SortOrderNo")
                                    {
                                        num23 = Convert.ToInt32(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "ParentWebOtherCostID")
                                    {
                                        num24 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "WebOtherCostType")
                                    {
                                        empty3 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "CalculationType")
                                    {
                                        calculation_type = strArrays14[1];
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(calculation_type))
                        {
                            if (calculation_type == "l")
                            {
                                freeTextQuestionLong = empty2;
                            }
                        }
                        if (dataSet.Tables.Count <= 1)
                        {
                            CartBasePage.Insert_into_CartAdditionalItems(num5, num17, empty1, num18, num19, num20, empty2, num22, num21, num23, num24, empty3, freeTextQuestionLong);
                        }
                        else if (dataSet.Tables[2].Rows.Count <= 0)
                        {
                            CartBasePage.Insert_into_CartAdditionalItems(num5, num17, empty1, num18, num19, num20, empty2, num22, num21, num23, num24, empty3, freeTextQuestionLong);
                        }
                        else
                        {
                            CartBasePage.Update_CartAdditionalItems(num5, num17, empty1, num18, num19, num20, empty2, num22, num21, num23, num24, empty3, freeTextQuestionLong);
                        }
                    }
                }
                CartBasePage.Update_OrderMarkup(num5);
                if (num5 > (long)0)
                {
                    foreach (DataRow row in CartBasePage.Select_OrderDetails(num5).Rows)
                    {
                        long num25 = Convert.ToInt64(row["EstimateItemID"].ToString());
                        long num26 = Convert.ToInt64(row["OrderID"].ToString());
                        long num27 = Convert.ToInt64(row["OrderItemID"].ToString());
                        bool flag = Convert.ToBoolean(row["IsStockReplenish"].ToString());
                        BaseClass baseClass = new BaseClass();
                        string str6 = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str7 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str8 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string lower = string.Empty;
                        string empty4 = string.Empty;
                        DataTable dataTable = new DataTable();
                        DataTable dataTable1 = baseClass.ProductStockType_Select(Convert.ToInt64(this.CompanyID), priceCatalogueID);
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            lower = dataRow["DrawStockFrom"].ToString().ToLower();
                            if (dataRow["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select(priceCatalogueID, (long)0, Convert.ToInt64(this.CompanyID), "self", num25);
                            }
                            else if (dataRow["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select((long)0, priceCatalogueID, Convert.ToInt64(this.CompanyID), "others", num25);
                            }
                            else if (dataRow["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                if (dataRow["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    continue;
                                }
                                dataTable = baseClass.StockProductRerunDetails_Select(priceCatalogueID, (long)0, Convert.ToInt64(this.CompanyID), "additional option", num25);
                            }
                            else
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select(priceCatalogueID, (long)0, Convert.ToInt64(this.CompanyID), "multiple_b2b", num25);
                            }
                        }
                        if (flag.ToString().ToLower() == "true")
                        {
                            continue;
                        }
                        foreach (DataRow row1 in dataTable.Rows)
                        {
                            if ((long)Convert.ToInt32(row1["TotalOldQty"].ToString()) == num9 || !(str6 == "a") && !(str6 == "p"))
                            {
                                continue;
                            }
                            if (lower == "s")
                            {
                                if (baseClass.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID, (long)0, "self", num25, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID, (long)0, Convert.ToInt32(num9), str7, "self", Convert.ToBoolean(str8), num25, "Job", num10, this.StoreUserID);
                            }
                            else if (lower == "o")
                            {
                                if (baseClass.StockCancellationProcess(Convert.ToInt64(this.CompanyID), (long)0, priceCatalogueID, "others", num25, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocation_Others(Convert.ToInt64(this.CompanyID), priceCatalogueID, Convert.ToInt32(num9), str7, Convert.ToBoolean(str8), num25, "Job", num10, this.StoreUserID);
                            }
                            else if (lower != "a")
                            {
                                if (!(lower == "m") || !(baseClass.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID, (long)0, "multiple", num25, "Job", this.StoreUserID, "a").ToLower() == "success"))
                                {
                                    continue;
                                }
                                DataTable dataTable2 = OrderBasePage.OtherMultipleProductDetails_Select(priceCatalogueID, Convert.ToInt32(num9), true);
                                foreach (DataRow dataRow1 in dataTable2.Rows)
                                {
                                    baseClass.StockAllocationProcess(Convert.ToInt64(this.CompanyID), Convert.ToInt64(dataRow1["KitItemID"].ToString()), priceCatalogueID, Convert.ToInt32(num9), str7, "multiple", Convert.ToBoolean(str8), num25, "Job", num10, this.StoreUserID);
                                }
                            }
                            else
                            {
                                if (baseClass.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID, (long)0, "additional option", num25, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationForAdditionalOption(Convert.ToInt64(this.CompanyID), priceCatalogueID, Convert.ToInt32(num9), str7, "additional option", Convert.ToBoolean(str8), num25, "Job", num10, this.StoreUserID, num26, num27);
                            }
                        }
                    }
                }
                if (base.Request.Params["OrdKey"] != null && this.Session["IsEditableProduct"] == null)
                {
                    if (base.Request.Params["CartItemID"] != null)
                    {
                        num5 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                        CartBasePage.Insert_NotesOnEditItem(num5, this.StoreUserID);
                    }
                    if (base.Request.Params["IsUserdesignated"] == null)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "order.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString()));
                    }
                    else
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "orderapproval.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString()));
                    }
                }
                if (this.Session["IsEditableProduct"] != null)
                {
                    if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            if (!this.Upload.HasFile)
                            {
                                HttpResponse response = base.Response;
                                keySeparator = new object[] { this.strSitepath, "editable_template", ConnectionClass.KeySeparator, num5, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                                response.Redirect(string.Concat(keySeparator));
                                return;
                            }
                            CartBasePage.Update_PDFNameC(Convert.ToInt64(num5), "", "", "", "");
                            HttpResponse httpResponse = base.Response;
                            keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num4, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                            httpResponse.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        if (!this.Upload.HasFile)
                        {
                            HttpResponse response1 = base.Response;
                            keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num5, "&ID=", priceCatalogueID, "&OrderId=", base.Request.Params["OrderId"] };
                            response1.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        CartBasePage.Update_PDFNameC(Convert.ToInt64(num5), "", "", "", "");
                        HttpResponse httpResponse1 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num4, "&amp;PID=", priceCatalogueID };
                        httpResponse1.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            HttpResponse response2 = base.Response;
                            keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num4, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                            response2.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        HttpResponse httpResponse2 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num4, "&amp;PID=", priceCatalogueID };
                        httpResponse2.Redirect(string.Concat(keySeparator));
                    }
                }
            }
            else if (base.Request.Params["type"] != null)
            {
                this.pnlNormalDetails.Style.Add("display", "block");
                this.pnlConfirmPRFile.Style.Add("display", "none");
                long num28 = (long)0;
                long num29 = (long)0;
                string value4 = this.hid_SaveToCart.Value;
                chrArray = new char[] { '»' };
                string[] strArrays15 = value4.Split(chrArray);
                string uniqueID = string.Empty;
                DataSet dataSet1 = new DataSet();
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (RewriteContext.Current.Params["CartItemID"] != null)
                    {
                        string str9 = RewriteContext.Current.Params["CartItemID"].ToString();
                        chrArray = new char[] { this.KeySeparator };
                        num29 = (long)Convert.ToInt32(str9.Split(chrArray)[1]);
                        dataSet1 = ProductBasePage.Cart_Details_Edit(num29);
                    }
                }
                else if (base.Request.Params["CartItemID"] != null)
                {
                    num29 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                    dataSet1 = ProductBasePage.Cart_Details_Edit(num29);
                }
                decimal num30 = new decimal(0);
                decimal num31 = new decimal(0);
                decimal num32 = new decimal(0);
                for (int o = 0; o <= (int)strArrays15.Length - 1; o++)
                {
                    if (strArrays15[o] != "")
                    {
                        string str10 = strArrays15[o].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays16 = str10.Split(chrArray);
                        for (int p = 0; p <= (int)strArrays16.Length - 1; p++)
                        {
                            if (strArrays16[0].ToLower() == "cookieid")
                            {
                                uniqueID = this.comm.UniqueID;
                            }
                            else if (strArrays16[0].ToLower() == "userid")
                            {
                                Convert.ToInt64(strArrays16[1].ToString());
                            }
                            else if (strArrays16[0].ToLower() == "carttotalprice")
                            {
                                num30 = Convert.ToDecimal(strArrays16[1].ToString());
                            }
                            else if (strArrays16[0].ToLower() == "carttax")
                            {
                                num31 = Convert.ToDecimal(strArrays16[1].ToString());
                            }
                            else if (strArrays16[0].ToLower() == "cartshipping")
                            {
                                num32 = Convert.ToDecimal(strArrays16[1].ToString());
                            }
                        }
                    }
                    if (o == 4)
                    {
                        if (this.StoreUserID != (long)0)
                        {
                            uniqueID = "";
                        }
                        if (num29 <= (long)0)
                        {
                            num28 = CartBasePage.Insert_into_Cart(uniqueID, this.StoreUserID, num30, num31, num32, false);
                        }
                        else
                        {
                            if (dataSet1.Tables[0].Rows.Count > 0)
                            {
                                num28 = (long)Convert.ToInt32(dataSet1.Tables[0].Rows[0]["CartID"].ToString());
                            }
                            CartBasePage.Update_Cart(uniqueID, num28, num29, this.StoreUserID, num30, num31, num32);
                        }
                    }
                }
                long priceCatalogueID1 = (long)this.PriceCatalogueID;
                if (this.hdnStockForMultipleProducts.Value == "m")
                {
                    priceCatalogueID1 = Convert.ToInt64(this.ddlOtherMultiple.SelectedValue);
                }
                long num33 = (long)0;
                decimal num34 = new decimal(0);
                decimal num35 = new decimal(0);
                decimal num36 = new decimal(0);
                decimal num37 = new decimal(0);
                long num38 = (long)0;
                decimal num39 = new decimal(0);
                decimal num40 = new decimal(0);
                string value5 = this.hid_SaveToCartItems.Value;
                chrArray = new char[] { '»' };
                string[] strArrays17 = value5.Split(chrArray);
                for (int q = 0; q <= (int)strArrays17.Length - 1; q++)
                {
                    if (strArrays17[q] != "")
                    {
                        num33 = Convert.ToInt64(strArrays17[0]);
                        num34 = Convert.ToDecimal(strArrays17[1]);
                        num35 = Convert.ToDecimal(strArrays17[2]);
                        num37 = Convert.ToDecimal(strArrays17[3]);
                        num36 = Convert.ToDecimal(strArrays17[4]);
                        num38 = Convert.ToInt64(strArrays17[5]);
                        num39 = Convert.ToDecimal(strArrays17[6]);
                        num40 = Convert.ToDecimal(strArrays17[7]);
                    }
                }
                if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0" || this.hid_QuestionTextFreeLenght.Value != "0")
                {
                    if (this.fp_artwork.HasFile)
                    {
                        this.artwork_file(this.fp_artwork, num28, 1, "yes", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays18 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName1 = strArrays18[0].ToString();
                        this.ReportFileName1 = strArrays18[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                    }
                    else if (this.lblfp_artwork.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                    {
                        this.FileName1 = this.lblFileName1.Text;
                        this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                        this.OriginalFileName1 = this.lblfp_artwork.Text;
                    }
                    if (this.fp_artwork1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork1, num28, 2, "yes", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays19 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName2 = strArrays19[0].ToString();
                        this.ReportFileName2 = strArrays19[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                    }
                    else if (this.lblfp_artwork1.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                    {
                        this.FileName2 = this.lblFileName2.Text;
                        this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                        this.OriginalFileName2 = this.lblfp_artwork1.Text;
                    }
                    if (this.fp_artwork2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork2, num28, 3, "yes", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays20 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName3 = strArrays20[0].ToString();
                        this.ReportFileName3 = strArrays20[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                    }
                    else if (this.lblfp_artwork2.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                    {
                        this.FileName3 = this.lblFileName3.Text;
                        this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                        this.OriginalFileName3 = this.lblfp_artwork2.Text;
                    }
                }
                else
                {
                    if (this.fp_artwork_no_addoption1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption1, num28, 1, "no", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays21 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName1 = strArrays21[0].ToString();
                        this.ReportFileName1 = strArrays21[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption1.Text != "" && this.hdnArtWorkDeleted1.Value != "true")
                    {
                        this.FileName1 = this.lblFileName1.Text;
                        this.ReportFileName1 = this.hdnFileName1.Value.ToString();
                        this.OriginalFileName1 = this.lblfp_artwork_no_addoption1.Text;
                    }
                    if (this.fp_artwork_no_addoption2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption2, num28, 2, "no", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays22 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName2 = strArrays22[0].ToString();
                        this.ReportFileName2 = strArrays22[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption2.Text != "" && this.hdnArtWorkDeleted2.Value != "true")
                    {
                        this.FileName2 = this.lblFileName2.Text;
                        this.ReportFileName2 = this.hdnFileName2.Value.ToString();
                        this.OriginalFileName2 = this.lblfp_artwork_no_addoption2.Text;
                    }
                    if (this.fp_artwork_no_addoption3.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption3, num28, 3, "no", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays23 = this.preflight_File(this.FileName, priceCatalogueID1);
                        this.FileName3 = strArrays23[0].ToString();
                        this.ReportFileName3 = strArrays23[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                    }
                    else if (this.lblfp_artwork_no_addoption3.Text != "" && this.hdnArtWorkDeleted3.Value != "true")
                    {
                        this.FileName3 = this.lblFileName3.Text;
                        this.ReportFileName3 = this.hdnFileName3.Value.ToString();
                        this.OriginalFileName3 = this.lblfp_artwork_no_addoption3.Text;
                    }
                }
                if (num29 <= (long)0)
                {
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        num29 = CartBasePage.Insert_into_CartItem(num28, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), num, num1, num39, num40, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        num29 = CartBasePage.Insert_into_CartItem(num28, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num39, num40, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        num29 = CartBasePage.Insert_into_CartItem(num28, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, "N", this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), num, num1, num39, num40, this.TemplateImportID, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                }
                else
                {
                    if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                    {
                        this.hdnDeptBehalf.Value = "1";
                    }
                    else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                    {
                        this.hdnDeptBehalf.Value = "0";
                        this.hdnUserBehalf.Value = "0";
                    }
                    else
                    {
                        this.hdnUserBehalf.Value = "1";
                    }
                    if (this.hdnUserBehalf.Value == "1")
                    {
                        if (dataSet1.Tables[0].Rows.Count > 0)
                        {
                            num28 = (long)Convert.ToInt32(dataSet1.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num28, num29, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), (long)0, num, num1, num39, num40, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else if (this.hdnDeptBehalf.Value != "1")
                    {
                        if (dataSet1.Tables[0].Rows.Count > 0)
                        {
                            num28 = (long)Convert.ToInt32(dataSet1.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num28, num29, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)0, (long)0, num, num1, num39, num40, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(this.hdnDepuUserID.Value);
                        }
                        catch
                        {
                            this.hdnDepuUserID.Value = "0";
                        }
                        if (dataSet1.Tables[0].Rows.Count > 0)
                        {
                            num28 = (long)Convert.ToInt32(dataSet1.Tables[0].Rows[0]["CartID"].ToString());
                        }
                        CartBasePage.Update_CartItem(num28, num29, priceCatalogueID1, "", num33, num34, this.FileName1, this.FileName2, this.FileName3, num35, num36, num37, num38, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value), num, num1, num39, num40, this.MainProductId, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    }
                    if (base.Request.Params["OrdKey"] != null)
                    {
                        if (Convert.ToInt64(this.ddl_BehalfDepts.SelectedIndex) > (long)-1 || Convert.ToInt64(this.ddl_SelectBehalf.SelectedValue) > (long)0)
                        {
                            this.hdnDeptBehalf.Value = "1";
                        }
                        else if (this.ddl_BehalfUsers.SelectedIndex <= -1 || this.ddl_BehalfDepts.SelectedIndex != -1)
                        {
                            this.hdnDeptBehalf.Value = "0";
                            this.hdnUserBehalf.Value = "0";
                        }
                        else
                        {
                            this.hdnUserBehalf.Value = "1";
                        }
                        if (this.hdnUserBehalf.Value == "1")
                        {
                            if (Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value) != (long)0)
                            {
                                OrderBasePage.OrderBehalf_DeptOrUser_Update(base.Request.Params["OrdKey"].ToString(), Convert.ToInt64(this.ddl_BehalfUsers.SelectedItem.Value), (long)0);
                            }
                        }
                        else if (this.hdnDeptBehalf.Value == "1" && Convert.ToInt64(this.ddl_BehalfDepts.SelectedValue) != (long)0)
                        {
                            try
                            {
                                Convert.ToInt64(this.hdnDepuUserID.Value);
                            }
                            catch
                            {
                                this.hdnDepuUserID.Value = "0";
                            }
                            OrderBasePage.OrderBehalf_DeptOrUser_Update(base.Request.Params["OrdKey"].ToString(), Convert.ToInt64(this.hdnDepuUserID.Value), Convert.ToInt64(this.ddl_BehalfDepts.SelectedItem.Value));
                        }
                    }
                }
                long num41 = (long)0;
                string empty5 = string.Empty;
                decimal num42 = new decimal(0);
                decimal num43 = new decimal(0);
                long num44 = (long)0;
                decimal num45 = new decimal(0);
                decimal num46 = new decimal(0);
                string empty6 = string.Empty;
                int num47 = 0;
                long num48 = (long)0;
                string empty7 = string.Empty;
                string value6 = this.hid_SaveToAdditionalItems.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays24 = value6.Split(chrArray);
                CartBasePage.Delete_CartAdditionalItems(num29);
                for (int r = 0; r <= (int)strArrays24.Length - 1; r++)
                {
                    if (strArrays24[r] != "")
                    {
                        string str11 = strArrays24[r].ToString();
                        string freeTextQuestionLong = string.Empty;
                        string calculation_type = string.Empty;
                        chrArray = new char[] { '±' };
                        string[] strArrays25 = str11.Split(chrArray);
                        for (int s = 0; s <= (int)strArrays25.Length - 1; s++)
                        {
                            if (strArrays25[s] != "")
                            {
                                string str12 = strArrays25[s];
                                chrArray = new char[] { '»' };
                                string[] strArrays26 = str12.Split(chrArray);
                                if (strArrays26[0] != "")
                                {
                                    if (strArrays26[0] == "OthercostID")
                                    {
                                        num41 = Convert.ToInt64(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "Formula")
                                    {
                                        empty5 = strArrays26[1];
                                    }
                                    else if (strArrays26[0] == "MarkUp")
                                    {
                                        num42 = Convert.ToDecimal(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "TotalPrice")
                                    {
                                        num43 = Convert.ToDecimal(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "SelectedID")
                                    {
                                        num44 = Convert.ToInt64(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "SelectedValue")
                                    {
                                        empty6 = strArrays26[1];
                                    }
                                    else if (strArrays26[0] == "SelectedPrice")
                                    {
                                        num46 = Convert.ToDecimal(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "MarkUpValue")
                                    {
                                        num45 = Convert.ToDecimal(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "SortOrderNo")
                                    {
                                        num47 = Convert.ToInt32(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "ParentWebOtherCostID")
                                    {
                                        num48 = Convert.ToInt64(strArrays26[1]);
                                    }
                                    else if (strArrays26[0] == "WebOtherCostType")
                                    {
                                        empty7 = strArrays26[1];
                                    }
                                    else if (strArrays26[0] == "CalculationType")
                                    {
                                        calculation_type = strArrays26[1];
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(calculation_type))
                        {
                            if (calculation_type == "l")
                            {
                                freeTextQuestionLong = empty6;
                            }
                        }
                        if (dataSet1.Tables.Count <= 1)
                        {
                            CartBasePage.Insert_into_CartAdditionalItems(num29, num41, empty5, num42, num43, num44, empty6, num46, num45, num47, num48, empty7, freeTextQuestionLong);
                        }
                        else if (dataSet1.Tables[2].Rows.Count <= 0)
                        {
                            CartBasePage.Insert_into_CartAdditionalItems(num29, num41, empty5, num42, num43, num44, empty6, num46, num45, num47, num48, empty7, freeTextQuestionLong);
                        }
                        else
                        {
                            CartBasePage.Update_CartAdditionalItems(num29, num41, empty5, num42, num43, num44, empty6, num46, num45, num47, num48, empty7, freeTextQuestionLong);
                        }
                    }
                }
                if (num29 > (long)0)
                {
                    foreach (DataRow row2 in CartBasePage.Select_OrderDetails(num29).Rows)
                    {
                        long num49 = Convert.ToInt64(row2["EstimateItemID"].ToString());
                        long num50 = Convert.ToInt64(row2["OrderID"].ToString());
                        long num51 = Convert.ToInt64(row2["OrderItemID"].ToString());
                        bool flag1 = Convert.ToBoolean(row2["IsStockReplenish"].ToString());
                        BaseClass baseClass1 = new BaseClass();
                        string str13 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str14 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str15 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string lower1 = string.Empty;
                        string empty8 = string.Empty;
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = baseClass1.ProductStockType_Select(Convert.ToInt64(this.CompanyID), priceCatalogueID1);
                        foreach (DataRow dataRow2 in dataTable4.Rows)
                        {
                            lower1 = dataRow2["DrawStockFrom"].ToString().ToLower();
                            if (dataRow2["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable3 = baseClass1.StockProductRerunDetails_Select(priceCatalogueID1, (long)0, Convert.ToInt64(this.CompanyID), "self", num49);
                            }
                            else if (dataRow2["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                dataTable3 = baseClass1.StockProductRerunDetails_Select((long)0, priceCatalogueID1, Convert.ToInt64(this.CompanyID), "others", num49);
                            }
                            else if (dataRow2["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                if (dataRow2["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    continue;
                                }
                                dataTable3 = baseClass1.StockProductRerunDetails_Select(priceCatalogueID1, (long)0, Convert.ToInt64(this.CompanyID), "additional option", num49);
                            }
                            else
                            {
                                dataTable3 = baseClass1.StockProductRerunDetails_Select(priceCatalogueID1, (long)0, Convert.ToInt64(this.CompanyID), "multiple_b2b", num49);
                            }
                        }
                        if (flag1.ToString().ToLower() == "true")
                        {
                            continue;
                        }
                        foreach (DataRow row3 in dataTable3.Rows)
                        {
                            if ((long)Convert.ToInt32(row3["TotalOldQty"].ToString()) == num33 || !(str13 == "a") && !(str13 == "p"))
                            {
                                continue;
                            }
                            if (lower1 == "s")
                            {
                                if (baseClass1.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID1, (long)0, "self", num49, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID1, (long)0, Convert.ToInt32(num33), str14, "self", Convert.ToBoolean(str15), num49, "Job", num34, this.StoreUserID);
                            }
                            else if (lower1 == "o")
                            {
                                if (baseClass1.StockCancellationProcess(Convert.ToInt64(this.CompanyID), (long)0, priceCatalogueID1, "others", num49, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocation_Others(Convert.ToInt64(this.CompanyID), priceCatalogueID1, Convert.ToInt32(num33), str14, Convert.ToBoolean(str15), num49, "Job", num34, this.StoreUserID);
                            }
                            else if (lower1 != "a")
                            {
                                if (!(lower1 == "m") || !(baseClass1.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID1, (long)0, "multiple", num49, "Job", this.StoreUserID, "a").ToLower() == "success"))
                                {
                                    continue;
                                }
                                DataTable dataTable5 = OrderBasePage.OtherMultipleProductDetails_Select(priceCatalogueID1, Convert.ToInt32(num33), true);
                                foreach (DataRow dataRow3 in dataTable5.Rows)
                                {
                                    baseClass1.StockAllocationProcess(Convert.ToInt64(this.CompanyID), Convert.ToInt64(dataRow3["KitItemID"].ToString()), priceCatalogueID1, Convert.ToInt32(num33), str14, "multiple", Convert.ToBoolean(str15), num49, "Job", num34, this.StoreUserID);
                                }
                            }
                            else
                            {
                                if (baseClass1.StockCancellationProcess(Convert.ToInt64(this.CompanyID), priceCatalogueID1, (long)0, "additional option", num49, "Job", this.StoreUserID, "a").ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationForAdditionalOption(Convert.ToInt64(this.CompanyID), priceCatalogueID1, Convert.ToInt32(num33), str14, "additional option", Convert.ToBoolean(str15), num49, "Job", num34, this.StoreUserID, num50, num51);
                            }
                        }
                    }
                }
                if (base.Request.Params["OrdKey"] != null)
                {
                    if (base.Request.Params["CartItemID"] != null)
                    {
                        num29 = (long)Convert.ToInt32(base.Request.Params["CartItemID"]);
                        CartBasePage.Insert_NotesOnEditItem(num29, this.StoreUserID);
                    }
                    if (base.Request.Params["IsUserdesignated"] == null)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "order.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString()));
                    }
                    else
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "orderapproval.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString()));
                    }
                }
                if (this.Session["IsEditableProduct"] != null)
                {
                    if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            HttpResponse response3 = base.Response;
                            keySeparator = new object[] { this.strSitepath, "editable_template", ConnectionClass.KeySeparator, num29, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
                            response3.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        HttpResponse httpResponse3 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num29, "&ID=", priceCatalogueID1 };
                        httpResponse3.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            HttpResponse response4 = base.Response;
                            keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num28, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
                            response4.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        HttpResponse httpResponse4 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num28, "&amp;PID=", priceCatalogueID1 };
                        httpResponse4.Redirect(string.Concat(keySeparator));
                        return;
                    }
                }
            }
            else if (strArrays2[1] == "true" && strArrays2[0] == "1")
            {
                if (this.searchProducts == "")
                {
                    this.searchProducts = "0";
                }
                this.pnlNormalDetails.Style.Add("display", "none");
                this.pnlConfirmPRFile.Style.Add("display", "block");
                this.btn_ConfirmAdd1.Style.Add("display", "none");
                this.btn_ConfirmEditTemplate1.Style.Add("display", "block");
                return;
            }
        }

        protected string CleanCSVString(string input)
        {
            string str = string.Concat("\"", input.Replace("\"", "\"\"").Replace("\r\n", " ").Replace("\r", " ").Replace("\n", ""), "\"");
            return str;
        }

        public void ddlOtherMultiple1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOtherMultiple.SelectedItem.Value != "-1")
            {
                if (this.ddlOtherMultiple.SelectedItem.Value != "--Select--")
                {
                    this.CopiedPriceCatalogueId = Convert.ToInt32(this.ddlOtherMultiple.SelectedItem.Value);
                    DataTable dataTable = ProductBasePage.OtherMultiple_product_Select(this.CopiedPriceCatalogueId, productdetails.companyID);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (ddlOtherMultiple1.SelectedIndex == -1)
                        {
                            this.BindOtherMultipleDropdownList1((long)this.CopiedPriceCatalogueId);
                            this.hdnStockForMultipleProducts.Value = "m";
                            DataTable dataTable3 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.PriceCatalogueID);
                            if (dataTable3.Rows.Count == 0)
                            {
                                this.ddlOtherMultiple1.Items.Insert(0, "--Select--");
                                this.CopiedPriceCatalogueId = this.PriceCatalogueID;
                            }
                        }
                        this.div_OtherMultipleProducts1.Visible = true;
                        this.div_OtherMultipleProducts1.Style.Add("display", "block");
                    }
                }
                else if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
                {
                    this.CopiedPriceCatalogueId = Convert.ToInt32(base.Request.QueryString["ID"]);
                }
                this.lblfp_artwork.Text = "";
                this.lblfp_artwork1.Text = "";
                this.lblfp_artwork2.Text = "";
                this.lblfp_artwork_no_addoption1.Text = "";
                this.lblfp_artwork_no_addoption2.Text = "";
                this.lblfp_artwork_no_addoption3.Text = "";
                this.hid_qtyToList.Value = "";
                this.hid_priceList.Value = "";
                this.hid_qtyFromList.Value = "";
                this.hid_CostExcMarkupList.Value = "";
                this.hid_MarkupList.Value = "";
                this.Page_Load(null, null);
            }
        }
        public void ddlOtherMultiple2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOtherMultiple1.SelectedItem.Value != "-1")
            {
                if (this.ddlOtherMultiple1.SelectedItem.Value != "--Select--")
                {
                    this.CopiedPriceCatalogueId = Convert.ToInt32(this.ddlOtherMultiple1.SelectedItem.Value);
                    DataTable dataTable = ProductBasePage.OtherMultiple_product_Select(this.CopiedPriceCatalogueId, productdetails.companyID);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (ddlOtherMultiple2.SelectedIndex == -1)
                        {
                            this.BindOtherMultipleDropdownList1((long)this.CopiedPriceCatalogueId);
                            this.hdnStockForMultipleProducts.Value = "m";
                            DataTable dataTable3 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.PriceCatalogueID);
                            if (dataTable3.Rows.Count == 0)
                            {
                                this.ddlOtherMultiple2.Items.Insert(0, "--Select--");
                                this.CopiedPriceCatalogueId = this.PriceCatalogueID;
                            }
                        }
                        this.div_OtherMultipleProducts2.Style.Add("display", "block");
                    }
                }
                else if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
                {
                    this.CopiedPriceCatalogueId = Convert.ToInt32(base.Request.QueryString["ID"]);
                }
                this.lblfp_artwork.Text = "";
                this.lblfp_artwork1.Text = "";
                this.lblfp_artwork2.Text = "";
                this.lblfp_artwork_no_addoption1.Text = "";
                this.lblfp_artwork_no_addoption2.Text = "";
                this.lblfp_artwork_no_addoption3.Text = "";
                this.hid_qtyToList.Value = "";
                this.hid_priceList.Value = "";
                this.hid_qtyFromList.Value = "";
                this.hid_CostExcMarkupList.Value = "";
                this.hid_MarkupList.Value = "";
                this.Page_Load(null, null);
            }
        }
        protected void DownloadCsvFile_Click(object sender, EventArgs e)
        {
            long num = (long)0;
            DataSet dataSet = ProductBasePage.Select_TemplateID((long)this.PriceCatalogueID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                num = Convert.ToInt64(dataSet.Tables[0].Rows[0]["TemplateID"].ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            string item = base.Request.QueryString["ID"];
            DataTable templatePropertiesFriendlyName = ProductBasePage.Get_TemplateProperties_FriendlyName(Convert.ToInt32(num));
            int count = templatePropertiesFriendlyName.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(",");
                }
                DataColumn dataColumn = templatePropertiesFriendlyName.Columns[i];
                string str = this.CleanCSVString(dataColumn.ColumnName.ToString());
                stringBuilder.Append(str);
            }
            stringBuilder.Append(Environment.NewLine);
            foreach (DataColumn column in templatePropertiesFriendlyName.Columns)
            {
                string str1 = templatePropertiesFriendlyName.Rows[0][column.ColumnName].ToString();
                string str2 = this.CleanCSVString(str1.ToString());
                stringBuilder.Append(str2);
                stringBuilder.Append(",");
            }
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=download.csv");
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.Write(stringBuilder.ToString());
            HttpContext.Current.Response.End();
        }

        public void GenerateBreadcrums(int CategoryID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            this.ProdCategoryID = CategoryID.ToString();
            DataTable dataTable = ProductBasePage.ProductCategoryNameSelect_Navigation(this.CompanyID, Convert.ToInt32(this.ProdCategoryID));
            foreach (DataRow row in dataTable.Rows)
            {
                empty1 = row["PriceCatalogueCategoryName"].ToString().Trim();
                empty = row["PriceCatalogueCategoryName"].ToString().Trim();
                if (this.strMainCount > empty.Length + 4)
                {
                    this.strMainCount = this.strMainCount - (empty.Length + 4);
                    object[] objArray = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                else if (this.strMainCount <= 4)
                {
                    empty = "..";
                    this.strMainCount = this.strMainCount - empty.Length;
                    object[] objArray1 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray1);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                else
                {
                    this.strMainCount = this.strMainCount - 4;
                    if (this.strMainCount <= 2)
                    {
                        empty = empty.Substring(0, this.strMainCount);
                    }
                    else
                    {
                        empty = empty.Substring(0, this.strMainCount - 2);
                        empty = string.Concat(empty, "..");
                    }
                    this.strMainCount = this.strMainCount - empty.Length;
                    object[] objArray2 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray2);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                if (this.strMainCount <= 0 || Convert.ToInt32(row["ParentCategoryID"]) <= 0)
                {
                    continue;
                }
                this.GenerateBreadcrums(Convert.ToInt32(row["ParentCategoryID"]));
            }
        }

        public void GetCampaignsValue()
        {
            DataTable dataTable = ProductBasePage.Select_CampaignValues(productdetails.AccountID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["EventName"] = base.SpecialDecode(row["EventName"].ToString());
            }
            this.ddlCampaign.DataSource = dataTable;
            this.ddlCampaign.DataTextField = "EventName";
            this.ddlCampaign.DataValueField = "ManageID";
            this.ddlCampaign.DataBind();
            this.ddlCampaign.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --", "0"));
        }

        public void getPageMetaDetails(int CompanyID, int AccountID, int PageID)
        {
            HtmlMeta htmlMetum = new HtmlMeta();
            HtmlMeta htmlMetum1 = new HtmlMeta();
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable = CMSBasePage.CMSPages_get(CompanyID, AccountID, PageID);
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)base.Master.FindControl("head");
            foreach (DataRow row in dataTable.Rows)
            {
                row["systemName"].ToString().Trim();
                if (row["systemName"].ToString().ToLower().Trim() != "products")
                {
                    continue;
                }
                htmlMetum.Name = "Keywords";
                htmlMetum.Content = row["metaKeywords"].ToString().Trim();
                contentPlaceHolder.Controls.Add(htmlMetum);
                htmlMetum1.Name = "Description";
                htmlMetum1.Content = row["metaDescription"].ToString().Trim();
                contentPlaceHolder.Controls.Add(htmlMetum1);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IDisposable disposable;
            string[] sitePath;
            object[] secureSitePath;
            char[] keySeparator;
            int num;
            IEnumerator enumerator;
            this.Label.Text = this.objLanguage.GetLanguageConversion("Price_List");
            if (ConnectionClass.AccountName == "A-Plus-Test-Customer")
            {
                this.Label1.Text = "Upload your files";
                this.lblupload.Text = "Upload your files";
                this.diveArtWorkHide.Visible = false;
            }
            else
            {
                this.Label1.Text = this.objLanguage.GetLanguageConversion("Upload_your_artwork_file");
                this.lblupload.Text = this.objLanguage.GetLanguageConversion("Upload_your_artwork_file");
            }

            this.btnAddtoCart.Text = this.objLanguage.GetLanguageConversion("Add_To_Cart");
            this.btnAddtoCart1.Text = this.objLanguage.GetLanguageConversion("Add_To_Cart");
            this.chkconform.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Print_ReadyFile_Preview_Confirmation"));
            this.ddl_SelectBehalf.Items[0].Text = string.Concat("--", this.objLanguage.GetLanguageConversion("Myself"), "--");
            this.ddl_SelectBehalf.Items[1].Text = this.objLanguage.GetLanguageConversion("Users");
            this.ddl_SelectBehalf.Items[2].Text = this.objLanguage.GetLanguageConversion("Departments");
            bool isPostBack = base.IsPostBack;
            this.pnlStockMessage.Attributes.Add("style", "display:none;");
            if (base.Request.Params["type"] == null)
            {
                this.RequestType = "1";
            }
            else if (base.Request.Params["type"].ToString() == "0")
            {
                this.RequestType = "1";
            }
            string item = "";
            string str = "";
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                productdetails.AccountID = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Product details", Convert.ToInt32(this.CompanyID), Convert.ToInt32(productdetails.AccountID));
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select(productdetails.AccountID, (long)this.CompanyID);
            this.IsZip2taxEnabled = CartBasePage.Select_IsZip2taxEnabled(this.CompanyID, productdetails.AccountID);
            if (dataTable.Rows.Count <= 0)
            {
                this.IsSpendLimitEnable = "false";
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();
                    this.IsSpendLimitEnable = row["IsSpendlimitEnabled"].ToString();
                }
            }
            if (this.MeasurementValue != "In.")
            {
                this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareMeter");
            }
            else
            {
                this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareFeet");
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(this.CompanyID);
            this.RightPanelCalc_Enabled = ProductBasePage.IsRightPanelCalc_Enabled(productdetails.AccountID);
            if (this.RightPanelCalc_Enabled.ToLower() != "true")
            {
                this.BehalfOfStyle = "clearBoth clear";
                this.ddlCampaign.Style.Add("width", "240px");
                this.txtWidth_Style = "style='width:45px;'";
                this.txtHeight_Style = "style='width:45px;'";
                this.plhContentTop.Controls.Add(new LiteralControl("<div id='contents' class='contents'>"));
                this.plhContentMiddle.Controls.Add(new LiteralControl(""));
                this.plhContentBottom.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                this.BehalfOfStyle = "clearBoth paddingBottom5";
                this.txtWidth_Style = "style='width:109px;'";
                this.txtHeight_Style = "style='width:108px;'";
                this.plhContentTop.Controls.Add(new LiteralControl("<div id='contents' class='contents' style='width: auto;'><table><tr><td style='width: 480px;'>"));
                this.plhContentMiddle.Controls.Add(new LiteralControl("</td><td><div class='RightPanel_New'>"));
                this.plhContentBottom.Controls.Add(new LiteralControl("</div></td></tr></table></div>"));
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.eprintDocument == null)
            {
                productdetails.eprintDocument = "";
            }
            else
            {
                productdetails.eprintDocument = ConnectionClass.eprintDocument;
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
            if (ConnectionClass.ImagePath == null)
            {
                productdetails.imagePath = "";
            }
            else
            {
                productdetails.imagePath = ConnectionClass.ImagePath;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                this.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (ConnectionClass.SystemName != null)
            {
                this.SystemName = ConnectionClass.SystemName;
            }
            if (this.comm.GetDisplayValue("isPDPriceExTax", productdetails.AccountID) == "false")
            {
                this.isPriceExTax = "0";
            }
            if (this.comm.GetDisplayValue("isPDTax", productdetails.AccountID) == "false")
            {
                this.isTax = "0";
            }
            if (this.comm.GetDisplayValue("isPDTotalPrice", productdetails.AccountID) == "false")
            {
                this.isTotalPrice = "0";
            }
            if (this.comm.GetDisplayValue("isPDQuantity", productdetails.AccountID) == "false")
            {
                this.isQuantity = "0";
            }
            if (this.comm.GetDisplayValue("isPDSubTotal", productdetails.AccountID) == "false")
            {
                this.isSubTotal = "0";
            }
            if (this.comm.GetDisplayValue("isPDMyCartRightPannel", productdetails.AccountID) == "false")
            {
                this.isPDMyCartRightPannel = "0";
            }
            if (!(this.ServerName.ToString().ToLower().Trim() == "fsg") || productdetails.AccountID != (long)267)
            {
                this.lbl_BehalfUsers.Text = this.objLanguage.GetLanguageConversion("Order_On_Behalf_Of");
            }
            else
            {
                this.lbl_BehalfUsers.Text = this.objLanguage.GetLanguageConversion("Select_your_department");
            }
            try
            {
                if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
                {
                    item = base.Request.QueryString["ID"];
                    DataTable dataTable1 = ProductBasePage.WS_CategoryName_SubCategory_Select_for_Navigation(Convert.ToInt32(item), productdetails.companyID, this.PriceCatalogueID);
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        dataRow["PriceCatalogueCategoryName"].ToString().Trim();
                        str = dataRow["CatalogueName"].ToString().Trim();
                        this.strMainCount = 75;
                        if (this.Session["Notification"] != null)
                        {
                            if (this.Session["Notification"] != null)
                            {
                                this.strMainCount = 75;
                            }
                            else
                            {
                                this.strMainCount = 90;
                            }
                        }
                        this.strMainCount = this.strMainCount - 12;
                        if (this.strMainCount > str.Length + 4)
                        {
                            this.strMainCount = this.strMainCount - str.Length + 4;
                            if (this.ProductSitePath == "")
                            {
                                sitePath = new string[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><div class='div_prodname_navigation'>", base.SpecialDecode(str), "</div><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/productdetails.aspx'></a>" };
                                this.ProductSitePath = string.Concat(sitePath);
                            }
                        }
                        if (this.strMainCount > 0 && Convert.ToInt32(dataRow["PriceCatalogueCategoryID"]) > 0)
                        {
                            this.GenerateBreadcrums(Convert.ToInt32(dataRow["PriceCatalogueCategoryID"]));
                        }
                        if (!base.IsPostBack)
                        {
                            System.Web.UI.WebControls.Label label = (System.Web.UI.WebControls.Label)base.Master.FindControl("lblPathLink");
                            sitePath = new string[] { "<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "Default.aspx' ></a><span Class='floatLeft'></span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx'>", this.objLanguage.GetLanguageConversion("Product_List"), "</a>", this.ProductSitePath };
                            label.Text = string.Concat(sitePath);
                        }
                        secureSitePath = new object[] { ConnectionClass.SecureSitePath, this.ServerName, "/", this.CompanyID, "/Product/PrintReady/", dataRow["PrintReadyFile"].ToString() };
                        this.PrintReadyFilePath_Verify = string.Concat(secureSitePath);
                        if (dataRow["PrintReadyFile"].ToString() == "")
                        {
                            this.hdnPrintReadyFile.Value = "0,false,false";
                        }
                        else
                        {
                            this.hdnPrintReadyFile.Value = string.Concat("1,", dataRow["IsPrintReadyFile"].ToString().Trim().ToLower(), ",", dataRow["ForcePrintReadyFile"].ToString().Trim().ToLower());
                        }
                    }


                    //if (dataTable1.Rows.Count > 0)
                    //{


                    //    DataRow row = dataTable1.Rows[0];
                    //    var name1 = row["Decoration1_Name"].ToString();
                    //    var name2 = row["Decoration2_Name"].ToString();
                    //    var name3 = row["Decoration3_Name"].ToString();
                    //    var name4 = row["Decoration4_Name"].ToString();
                    //    var name5 = row["Decoration5_Name"].ToString();
                    //    var name6 = row["Decoration6_Name"].ToString();

                    //    var Decoration1_Mandadory = Convert.ToBoolean(row["Decoration1_Mandadory"]);
                    //    var Decoration2_Mandadory = Convert.ToBoolean(row["Decoration2_Mandadory"]);
                    //    var Decoration3_Mandadory = Convert.ToBoolean(row["Decoration3_Mandadory"]);
                    //    var Decoration4_Mandadory = Convert.ToBoolean(row["Decoration4_Mandadory"]);
                    //    var Decoration5_Mandadory = Convert.ToBoolean(row["Decoration5_Mandadory"]);
                    //    var Decoration6_Mandadory = Convert.ToBoolean(row["Decoration6_Mandadory"]);
                    //    if (string.IsNullOrEmpty(name1) == true)
                    //    {
                    //        price_table_content_Decoration1.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration1.InnerText = Decoration1_Mandadory ? name1 + "*" : name1;
                    //        SetDDItems(ddlDecoration1, Decoration1_Mandadory ? "" : "No", Decoration1_Mandadory);
                    //        lblDecoration1Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration1.Value = Convert.ToDouble(row["Decoration1_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration1_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration1_MinimiumCost"]);
                    //        this.ddlDecoration1.Attributes.Add("onchange", "javascript:calculateDecoration('1');Tocall_mainFunc();");
                    //    }

                    //    if (string.IsNullOrEmpty(name2) == true)
                    //    {
                    //        price_table_content_Decoration2.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration2.InnerText = Decoration2_Mandadory ? name2 + "*" : name2;

                    //        SetDDItems(ddlDecoration2, Decoration2_Mandadory ? "" : "No", Decoration2_Mandadory);
                    //        lblDecoration2Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration2.Value = Convert.ToDouble(row["Decoration2_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration2_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration2_MinimiumCost"]);
                    //        this.ddlDecoration2.Attributes.Add("onchange", "javascript:calculateDecoration('2');Tocall_mainFunc();");
                    //    }

                    //    if (string.IsNullOrEmpty(name3) == true)
                    //    {
                    //        price_table_content_Decoration3.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration3.InnerText = Decoration3_Mandadory ? name3 + "*" : name3;

                    //        SetDDItems(ddlDecoration3, Decoration3_Mandadory ? "" : "No", Decoration3_Mandadory);
                    //        lblDecoration3Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration3.Value = Convert.ToDouble(row["Decoration3_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration3_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration3_MinimiumCost"]);
                    //        this.ddlDecoration3.Attributes.Add("onchange", "javascript:calculateDecoration('3');Tocall_mainFunc();");
                    //    }

                    //    if (string.IsNullOrEmpty(name4) == true)
                    //    {
                    //        price_table_content_Decoration4.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration4.InnerText = Decoration4_Mandadory ? name4 + "*" : name4;
                    //        SetDDItems(ddlDecoration4, Decoration4_Mandadory ? "" : "No", Decoration4_Mandadory);
                    //        lblDecoration4Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration4.Value = Convert.ToDouble(row["Decoration4_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration4_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration4_MinimiumCost"]);
                    //        this.ddlDecoration4.Attributes.Add("onchange", "javascript:calculateDecoration('4');Tocall_mainFunc();");
                    //    }

                    //    if (string.IsNullOrEmpty(name5) == true)
                    //    {
                    //        price_table_content_Decoration5.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration5.InnerText = Decoration5_Mandadory ? name5 + "*" : name5;
                    //        SetDDItems(ddlDecoration5, Decoration5_Mandadory ? "" : "No", Decoration5_Mandadory);
                    //        lblDecoration5Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration5.Value = Convert.ToDouble(row["Decoration5_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration5_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration5_MinimiumCost"]);
                    //        this.ddlDecoration5.Attributes.Add("onchange", "javascript:calculateDecoration('5');Tocall_mainFunc();");
                    //    }

                    //    if (string.IsNullOrEmpty(name6) == true)
                    //    {
                    //        price_table_content_Decoration6.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDecoration6.InnerText = Decoration6_Mandadory ? name6 + "*" : name6;
                    //        SetDDItems(ddlDecoration6, Decoration6_Mandadory ? "" : "No", Decoration6_Mandadory);
                    //        lblDecoration6Cost.InnerText = this.comm.GetCurrencyinRequiredFormate("0.00", true);
                    //        hdnDecoration6.Value = Convert.ToDouble(row["Decoration6_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration6_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration6_MinimiumCost"]);
                    //        this.ddlDecoration6.Attributes.Add("onchange", "javascript:calculateDecoration('6');Tocall_mainFunc();");
                    //    }

                    //    //SetDDItems(ddlDecoration2, "", false);
                    //    //SetDDItems(ddlDecoration3, "", false);
                    //    //SetDDItems(ddlDecoration4, "", false);
                    //    //SetDDItems(ddlDecoration5, "", false);
                    //    //SetDDItems(ddlDecoration6, "", false);
                    //}
                }
            }
            catch
            {
            }
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["ID"] != null)
                {
                    this.PriceCatalogueID = Convert.ToInt32(base.Request.Params["ID"]);
                }
                if (base.Request.Params["type"] != null)
                {
                    this.searchProducts = base.Request.Params["type"].ToString();
                    this.Mode = base.Request.Params["type"].ToString();
                }
            }
            else
            {
                if (RewriteContext.Current.Params["ID"] != null)
                {
                    string str1 = RewriteContext.Current.Params["ID"].ToString();
                    keySeparator = new char[] { this.KeySeparator };
                    this.PriceCatalogueID = Convert.ToInt32(str1.Split(keySeparator)[1]);
                }
                if (RewriteContext.Current.Params["type"] != null)
                {
                    this.searchProducts = RewriteContext.Current.Params["type"].ToString();
                }
            }
            if ((this.searchProducts != "" || this.searchProducts != null) && this.searchProducts == "1" && base.Request.Cookies["spcookie"] != null)
            {
                this.searchCookie = base.Request.Cookies["spcookie"].Value.ToString();
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (base.Request.Params["OrderMode"] == "edit" && base.Request.Params["Store_UserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Request.Params["Store_UserID"]);
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && productdetails.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            int num1 = 0;
            foreach (DataRow row1 in CMSBasePage.Select_BannerImages(productdetails.AccountID, 0, "R", "ProductDetails").Rows)
            {
                if (num1 == 0)
                {
                    this.plhRightBanner.Controls.Add(new LiteralControl("<div>"));
                }
                secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", row1["bannerImage"], "&amp;type=b&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                string str2 = string.Concat(secureSitePath);
                if (row1["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhRightBanner.Controls;
                    secureSitePath = new object[] { "<div><img src='", str2, "' alt='", row1["bannerTitle"], "' class='BorderWhite' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(secureSitePath)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhRightBanner.Controls;
                    secureSitePath = new object[] { "<div><a href='", row1["URL"], "'><img src='", str2, "' alt='", row1["bannerTitle"], "' class='BorderWhite' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(secureSitePath)));
                }
                num1++;
            }
            if (num1 != 0)
            {
                this.plhRightBanner.Controls.Add(new LiteralControl("</div>"));
            }
            this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(productdetails.AccountID);
            this.hdnCampaignValue.Value = this.IsCampaignEnabled;
            if (this.IsCampaignEnabled.ToLower() != "true")
            {
                this.clear.Visible = false;
            }
            else
            {
                this.div_Campaign.Style.Add("display", "block");
            }
            if (!base.IsPostBack)
            {
                this.GetCampaignsValue();
            }
            this.SesseionKey = this.comm.UniqueID;
            BaseClass baseClass = new BaseClass();
            try
            {
                if (!base.IsPostBack)
                {
                    this.hdnStockForMultipleProducts.Value = "";
                    if (this.Session["ProductStockManagement"] != null && this.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
                    {
                        DataTable dataTable2 = baseClass.ProductStockType_Select((long)this.CompanyID, (long)this.PriceCatalogueID);
                        if (dataTable2.Rows.Count > 0)
                        {
                            foreach (DataRow dataRow1 in dataTable2.Rows)
                            {
                                if (dataRow1["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    this.div_OtherMultipleProducts.Visible = false;
                                    this.div_OtherMultipleProducts1.Visible = false;
                                    this.div_OtherMultipleProducts2.Visible = false;
                                    this.div_PriceMatrix.Visible = false;
                                }
                                else
                                {
                                    if (Convert.ToBoolean(dataRow1["IsEnableSubDetail"]))
                                    {
                                        if (dataRow1["MatrixType"].ToString().ToLower() == "p" || dataRow1["MatrixType"].ToString().ToLower() == "s")
                                        {
                                            this.GridInkCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Item_Name");
                                            this.GridInkCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Quantity_Ordered");
                                            if (Convert.ToBoolean(dataRow1["IsShowStock"]))
                                            {
                                                this.GridInkCostView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Quantity_In_Stock");
                                            }
                                            else
                                            {
                                                this.GridInkCostView.Columns[2].HeaderText = "";
                                            }
                                            if (Convert.ToBoolean(dataRow1["IsShowPriceSubTotalTax"]))
                                            {
                                                this.GridInkCostView.Columns[3].HeaderText = string.Concat("Price", "($)");
                                            }
                                            else
                                            {
                                                this.GridInkCostView.Columns[3].HeaderText = "";
                                                this.GridInkCostView.Columns[3].Visible = false;
                                            }
                                            DataTable dataTableMatrix = ProductBasePage.OtherMultiple_product_ForMatrix((long)this.PriceCatalogueID, productdetails.companyID);
                                            this.GridInkCostView.DataSource = dataTableMatrix;
                                            this.GridInkCostView.DataBind();

                                            this.div_OtherMultipleProducts.Visible = false;
                                            this.div_OtherMultipleProducts1.Visible = false;
                                            this.div_OtherMultipleProducts2.Visible = false;
                                            this.hdnMatrixCheckMultipleProduct.Value = Convert.ToString(dataRow1["IsEnableSubDetail"]);
                                        }
                                    }
                                    else
                                    {
                                        this.div_PriceMatrix.Visible = false;
                                    }

                                    this.BindOtherMultipleDropdownList((long)this.PriceCatalogueID);
                                    this.hdnStockForMultipleProducts.Value = "m";
                                    DataTable dataTable3 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.PriceCatalogueID);
                                    if (dataTable3.Rows.Count == 0)
                                    {
                                        this.ddlOtherMultiple.Items.Insert(0, "--Select--");
                                        this.CopiedPriceCatalogueId = this.PriceCatalogueID;
                                    }
                                    if (dataTable3.Rows.Count <= 0 || dataTable3.Rows[0]["KitItemID"] == null)
                                    {
                                        continue;
                                    }
                                    this.CopiedPriceCatalogueId = Convert.ToInt16(dataTable3.Rows[0]["KitItemID"]);
                                    baseClass.SetDDLValue(this.ddlOtherMultiple, dataTable3.Rows[0]["KitItemID"].ToString());
                                    this.div_OtherMultipleProducts.Visible = true;
                                    //this.div_OtherMultipleProducts1.Visible = false;
                                    this.div_OtherMultipleProducts1.Style.Add("display", "none");
                                    this.div_OtherMultipleProducts2.Visible = true;
                                }
                            }
                        }
                    }
                    if (base.Request.Params["type"].ToString() != null && base.Request.Params["type"].ToString() == "ed")
                    {
                        this.CopiedPriceCatalogueId = Convert.ToInt16(base.Request.Params["SubID"]);
                        baseClass.SetDDLValue(this.ddlOtherMultiple, this.CopiedPriceCatalogueId.ToString());
                    }
                }
            }
            catch
            {
            }
            if (this.hdnStockForMultipleProducts.Value == "m")
            {
                this.MainProductId = this.PriceCatalogueID;
            }
            else
            {
                this.Label5.Visible = false;
                this.div_OtherMultipleProducts.Visible = false;
                this.div_OtherMultipleProducts1.Visible = false;
                this.div_OtherMultipleProducts2.Visible = false;
                this.CopiedPriceCatalogueId = this.PriceCatalogueID;
            }
            if (this.hdnStockForMultipleProducts.Value.Trim().ToLower() == "m")
            {
                if (this.MainProductId == this.CopiedPriceCatalogueId)
                {
                    this.Spn_PrdoMandatory.Style.Add("visibility", "visible");
                    this.Label5.Visible = false;
                }
                else
                {
                    this.Spn_PrdoMandatory.Style.Add("visibility", "hidden");
                    this.Label5.Visible = true;
                }
            }
            bool flag = false;
            string MatrixType = "";
            if (this.CopiedPriceCatalogueId != 0)
            {
                this.hdnPriceCatalogueID.Value = this.PriceCatalogueID.ToString();
                foreach (DataRow row2 in ProductBasePage.productsDetails_Select(this.PriceCatalogueID).Rows)
                {
                    this.CatalogueName = base.SpecialDecode(row2["CatalogueName"].ToString());
                    this.lbl_CatalogueName2.Text = this.CatalogueName;
                    this.IsDisplayAdditionalOptions = Convert.ToBoolean(row2["IsDisplayAdditionalOptions"].ToString().ToLower().Trim());
                    MatrixType = row2["MatrixType"].ToString();

                    this.isEnableAddtoCartStayButton = Convert.ToBoolean(row2["isAddtoCartandStay"]);
                    enableAddtoCartStayButton(this.isEnableAddtoCartStayButton);
                }
                DataTable dataTable4 = ProductBasePage.productsDetails_Select(this.CopiedPriceCatalogueId);


                var datatableCart = CartBasePage.Select_CartItems("", "", this.StoreUserID);

                foreach (DataRow row in datatableCart.Rows)
                {

                    if (Convert.ToInt32(row["ProductID"]) == CopiedPriceCatalogueId && MatrixType == "G" && Convert.ToInt32(base.Request.Params["CartItemID"]) != Convert.ToInt32(row["CartItemID"]) && Convert.ToBoolean(row["AllowGroupRun"]))
                    {
                        Dimention = Dimention + Convert.ToInt32(row["Quantity"]) * ((Convert.ToInt32(row["Height"]) * Convert.ToInt32(row["Width"])) / 1000000);
                    }



                }
                if (dataTable4.Rows.Count <= 0)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                }
                else
                {
                    foreach (DataRow dataRow2 in dataTable4.Rows)
                    {
                        DataTable taxPrecedence = ProductBasePage.TaxPrecedence_Select(Convert.ToInt32(productdetails.AccountID));
                        if (taxPrecedence.Rows.Count > 0)
                        {
                            foreach (DataRow oRow2 in taxPrecedence.Rows)
                            {
                                this.ProductTaxId = Convert.ToInt32(oRow2["SalesTaxRate"]);
                                this.ProductTaxName = oRow2["TaxName"].ToString();
                                this.ProductTaxRate = Convert.ToDecimal(oRow2["TaxRate"]);
                            }
                        }
                        else
                        {

                            this.ProductTaxId = Convert.ToInt32(dataRow2["SalesTaxRate"]);
                            this.ProductTaxName = dataRow2["TaxName"].ToString();
                            this.ProductTaxRate = Convert.ToDecimal(dataRow2["TaxRate"]);
                        }
                        this.Label5.Text = base.SpecialDecode(dataRow2["CatalogueName"].ToString());
                        this.lbl_CatalogueName3.Text = string.Concat("Select the ", this.CatalogueName);
                        string empty = string.Empty;
                        StringBuilder stringBuilder = new StringBuilder();
                        this.lbl_Description.Text = base.SpecialDecode(dataRow2["ItemDesc"].ToString());
                        if (!Convert.ToBoolean(dataRow2["IsItemDescription"]))
                        {
                            this.lbl_Description.Visible = false;
                        }
                        else
                        {
                            this.lbl_Description.Visible = true;
                        }
                        this.artworkFile = dataRow2["ArtworkFile"].ToString();
                        this.PriceCatalogueCategoryID = Convert.ToInt32(dataRow2["PriceCatalogueCategoryID"].ToString());
                        this.PriceCatalogueCategoryName = dataRow2["PriceCatalogueCategoryName"].ToString();
                        this.PrintReadyFile = dataRow2["PrintReadyFile"].ToString();
                        this.IsPriceList = Convert.ToInt32(dataRow2["IsPriceList"]);
                        this.IsDisplayAdditionalOptions = Convert.ToBoolean(dataRow2["IsDisplayAdditionalOptions"].ToString().ToLower().Trim());

                        this.isEnableAddtoCartStayButton = Convert.ToBoolean(dataRow2["isAddtoCartandStay"]);
                        enableAddtoCartStayButton(this.isEnableAddtoCartStayButton);
                        var PrintReadyFileWaterMark = dataRow2["PrintReadyFileWaterMark"].ToString();
                        var IsPrintReadyFileWaterMark = Convert.ToBoolean(dataRow2["IsPrintReadyFileWaterMark"]);
                        if (Convert.ToBoolean(dataRow2["IsPrintReadyFile"]) && this.PrintReadyFile != "")
                        {
                            if (Convert.ToBoolean(dataRow2["IsPrintReadyFileWaterMark"]))  // PrintReadyFileWaterMark == "" && 
                                PrintReadyFileWaterMark = CreateWaterMarkPDF(this.PrintReadyFile, PrintReadyFileWaterMark, PriceCatalogueID, dataRow2["PrintReadyFileWaterMarkText"].ToString() == "" ? "Test" : dataRow2["PrintReadyFileWaterMarkText"].ToString());

                            secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", IsPrintReadyFileWaterMark == true ? PrintReadyFileWaterMark : PrintReadyFile, "&amp;type=pr&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                            string str3 = string.Concat(secureSitePath);
                            secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=pdf_icon.jpg&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                            string str4 = string.Concat(secureSitePath);
                            this.div_PrintReadyFile.Attributes.Add("style", "padding: 7px 0px 10px 0px; display:block;");
                            this.lblPrintReadyFile.Width = Unit.Pixel(260);
                            System.Web.UI.WebControls.Label label1 = this.lblPrintReadyFile;
                            sitePath = new string[] { "<div class='floatLeft'><img src='", str4, "' alt=' '/></div><div id='div_PrintReadyFile_link'><a class='MarginLeft_120px' href='", str3, "' target='_blank'>", this.objLanguage.GetLanguageConversion("Print_Ready_File"), "</a></div>" };
                            label1.Text = string.Concat(sitePath);

                            secureSitePath = new object[] { ConnectionClass.SecureSitePath, this.ServerName, "/", this.CompanyID, "/Product/PrintReady/", IsPrintReadyFileWaterMark == true ? PrintReadyFileWaterMark : PrintReadyFile };
                            this.PrintReadyFilePath_Verify = string.Concat(secureSitePath);

                        }
                        if (this.artworkFile.ToLower().Trim() != "n")
                        {
                            this.artwork_div.Style.Add("display", "block");
                            this.artwork_div_no_addoption.Style.Add("display", "block");
                        }
                        else
                        {
                            this.artwork_div.Style.Add("display", "none");
                            this.artwork_div_no_addoption.Style.Add("display", "none");
                            this.TempDataLine.Style.Add("display", "block");
                        }
                        this.fp_artwork1.Visible = true;
                        this.fp_artwork2.Visible = true;
                        this.fp_artwork_no_addoption2.Visible = true;
                        this.fp_artwork_no_addoption3.Visible = true;
                        this.lblfp_artwork1.Visible = true;
                        this.lblfp_artwork2.Visible = true;
                        this.lblfp_artwork_no_addoption2.Visible = true;
                        this.lblfp_artwork_no_addoption3.Visible = true;
                        if (Convert.ToInt32(dataRow2["ArtworkCount"].ToString()) == 1)
                        {
                            this.fp_artwork1.Visible = false;
                            this.fp_artwork2.Visible = false;
                            this.fp_artwork_no_addoption2.Visible = false;
                            this.fp_artwork_no_addoption3.Visible = false;
                            this.lblfp_artwork1.Visible = false;
                            this.lblfp_artwork2.Visible = false;
                            this.lblfp_artwork_no_addoption2.Visible = false;
                            this.lblfp_artwork_no_addoption3.Visible = false;
                        }
                        else if (Convert.ToInt32(dataRow2["ArtworkCount"].ToString()) == 2)
                        {
                            this.fp_artwork2.Visible = false;
                            this.fp_artwork_no_addoption3.Visible = false;
                            this.lblfp_artwork2.Visible = false;
                            this.lblfp_artwork_no_addoption3.Visible = false;
                        }
                        productdetails.thumbImg = dataRow2["ProductImage"].ToString();
                        this.hid_matixType.Value = dataRow2["MatrixType"].ToString();
                        this.Session["IsEditableProduct"] = dataRow2["IsEditableProduct"].ToString();
                        if (Convert.ToBoolean(dataRow2["IsShowSoldInPacksOf"]).ToString().Trim().ToLower() == "true")
                        {
                            this.div_soldinpack.Style.Add("display", "block");
                        }
                        this.hdnStockManagement.Value = dataRow2["ProductStockManagement"].ToString().ToLower();
                        this.hdnIsShowStock.Value = dataRow2["IsShowStock"].ToString().ToLower();
                        flag = Convert.ToBoolean(dataRow2["IsShowStock"].ToString());
                        this.hdnDrawStockFrom.Value = dataRow2["DrawStockFrom"].ToString().Trim().ToLower();
                        this.hdnIsBackOrder.Value = dataRow2["IsBackOrder"].ToString().Trim().ToLower();
                        this.hdnAvailableQty.Value = dataRow2["AvailableQuantity"].ToString();
                        this.hdnShowPriceSubtotalTax.Value = dataRow2["IsShowPriceSubTotalTax"].ToString();
                        this.hdnShowUnitPrice.Value = dataRow2["IsShowUnitPrice"].ToString();
                        this.hdnShowPackPrice.Value = dataRow2["IsShowPackedPrice"].ToString();
                        this.hdnShowJobName.Value = dataRow2["IsShowJobName"].ToString();

                        this.hdnIsStockItem.Value = dataRow2["IsStockItem"].ToString();
                        if (dataRow2["AvailableQuantity"].ToString() != "0" && dataRow2["AvailableQuantity"].ToString() != "")
                        {
                            this.AvailableQuantity = Convert.ToInt32(dataRow2["AvailableQuantity"].ToString());
                        }
                        if (Convert.ToBoolean(dataRow2["isCustomerCode"]) && dataRow2["CustomerCode"].ToString() != "")
                        {
                            this.isCustomerCode = true;
                            this.lblCustomerCode.Text = base.SpecialDecode(dataRow2["CustomerCode"].ToString());
                        }
                        if (Convert.ToBoolean(dataRow2["isItemCode"]) && dataRow2["ItemCode"].ToString() != "")
                        {
                            this.isItemCode = true;
                            this.lblItemCode.Text = base.SpecialDecode(dataRow2["ItemCode"].ToString());
                        }
                        if (!Convert.ToBoolean(dataRow2["IsCumulativePricing"]))
                        {
                            continue;
                        }
                        this.IsCumulative = true;
                    }
                }
                string empty1 = string.Empty;
                if (productdetails.thumbImg != "")
                {
                    productdetails.thumbImg = productdetails.thumbImg.Remove(0, 2);
                    productdetails.thumbImg = string.Concat("m_", productdetails.thumbImg);
                    empty1 = productdetails.thumbImg.Remove(0, 2);
                }
                if (productdetails.thumbImg == "")
                {
                    HtmlImage htmlImage = this.cards;
                    secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=m_no_image_available.png&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlImage.Src = string.Concat(secureSitePath);
                    this.cards.Alt = " ";
                    HtmlAnchor htmlAnchor = this.cards1;
                    secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=m_no_image_available.png&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlAnchor.HRef = string.Concat(secureSitePath);
                    if (this.hdnStockForMultipleProducts.Value == "m")
                    {
                        this.cards1.Title = "";
                    }
                }
                else
                {
                    HtmlImage htmlImage1 = this.cards;
                    secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", productdetails.thumbImg.ToString(), "&amp;type=p&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlImage1.Src = string.Concat(secureSitePath);
                    this.cards.Alt = " ";
                    HtmlAnchor htmlAnchor1 = this.cards1;
                    secureSitePath = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", empty1.ToString(), "&amp;type=p&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlAnchor1.HRef = string.Concat(secureSitePath);
                    this.cards1.Title = this.CatalogueName;
                    if (this.hdnStockForMultipleProducts.Value == "m")
                    {
                        this.cards1.Title = this.Label5.Text;
                    }
                }
                this.Product_list(this.hid_matixType.Value, (long)this.CopiedPriceCatalogueId, this.plhPriceList, "hidemore", 1);
                this.Product_list(this.hid_matixType.Value, (long)this.CopiedPriceCatalogueId, this.plhPriceListMore, "viewmore", 6);
                if (this.IsPriceList != 1 || !(this.IsEnableHidePrice == "false"))
                {
                    this.div_ProductPriceList.Style.Add("display", "none");
                    this.divLine.Style.Add("display", "none");
                }
                else
                {
                    this.div_ProductPriceList.Style.Add("display", "block");
                    this.divLine.Style.Add("display", "block");
                }
                DataTable dataTable5 = ProductBasePage.Select_OtherCostAdditional_ItemsIDs((long)this.CopiedPriceCatalogueId);
                if (dataTable5.Rows.Count > 0)
                {
                    this.IsAdditionalOption = "yes";
                }
                if (!base.IsPostBack)
                {
                    this.ddl_BehalfUsers.Items.Clear();
                    this.ddl_BehalfDepts.Items.Clear();
                    this.ApprovalSystem_OrderingProcess();
                }
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    if (base.Request.Params["OrdKey"] != null)
                    {
                        System.Web.UI.WebControls.Label label2 = (System.Web.UI.WebControls.Label)base.Master.FindControl("lblPathLink");
                        sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/myorder.aspx'>", this.objLanguage.GetLanguageConversion("Orders"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "order.aspx?OrdKey=", base.Request.Params["OrdKey"].ToString(), "'>", this.objLanguage.GetLanguageConversion("Orders_Details"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft' href ='", BaseClass.SitePath, "product/productdetails.aspx'></a>", this.objLanguage.GetLanguageConversion("Product_List") };
                        label2.Text = string.Concat(sitePath);
                    }
                    else if (base.Request.Params["CartItemID"] != null && base.Request.Params["OrdKey"] == null)
                    {
                        System.Web.UI.WebControls.Label label3 = (System.Web.UI.WebControls.Label)base.Master.FindControl("lblPathLink");
                        sitePath = new string[] { "<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "Default.aspx'></a><span Class='floatLeft' ></span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "ShoppingCart.aspx?ID=0&PID=0'>", this.objLanguage.GetLanguageConversion("Shopping_Cart"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft' href ='", BaseClass.SitePath, "product/productdetails.aspx'></a>", this.objLanguage.GetLanguageConversion("Product_List") };
                        label3.Text = string.Concat(sitePath);
                    }
                    this.ImgButtonErase.Visible = false;
                    this.fp_artwork.Style.Add("display", "block");
                    this.ImgButtonErase_no_addoption1.Visible = false;
                    this.fp_artwork_no_addoption1.Style.Add("display", "block");
                    this.ImgButtonErase1.Visible = false;
                    this.fp_artwork1.Style.Add("display", "block");
                    this.ImgButtonErase_no_addoption2.Visible = false;
                    this.fp_artwork_no_addoption2.Style.Add("display", "block");
                    this.ImgButtonErase2.Visible = false;
                    this.fp_artwork2.Style.Add("display", "block");
                    this.ImgButtonErase_no_addoption3.Visible = false;
                    this.fp_artwork_no_addoption3.Style.Add("display", "block");
                    if (!base.IsPostBack && base.Request.Params["CartItemID"] != null)
                    {
                        this.CartItemID = Convert.ToInt32(base.Request.Params["CartItemID"]);
                        DataSet dataSet = ProductBasePage.Cart_Details_Edit((long)this.CartItemID);
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[1].Rows.Count > 0)
                        {
                            this.hid_Quantity_Edit.Value = dataSet.Tables[1].Rows[0]["Quantity"].ToString();
                            this.hid_totalPrice_Edit.Value = dataSet.Tables[0].Rows[0]["CartTotalPrice"].ToString();
                            this.lblFileName1.Text = dataSet.Tables[1].Rows[0]["UploadFile"].ToString();
                            this.lblFileName2.Text = dataSet.Tables[1].Rows[0]["UploadFile1"].ToString();
                            this.lblFileName3.Text = dataSet.Tables[1].Rows[0]["UploadFile2"].ToString();
                            this.hdnFileName1.Value = dataSet.Tables[1].Rows[0]["UploadFile_Report"].ToString();
                            this.hdnFileName2.Value = dataSet.Tables[1].Rows[0]["UploadFile1_Report"].ToString();
                            this.hdnFileName3.Value = dataSet.Tables[1].Rows[0]["UploadFile2_Report"].ToString();
                            this.lblfp_artwork.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename"].ToString();
                            this.lblfp_artwork1.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename1"].ToString();
                            this.lblfp_artwork2.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename2"].ToString();
                            this.lblfp_artwork_no_addoption1.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename"].ToString();
                            this.lblfp_artwork_no_addoption2.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename1"].ToString();
                            this.lblfp_artwork_no_addoption3.Text = dataSet.Tables[1].Rows[0]["originalUploadfilename2"].ToString();
                            if (this.lblfp_artwork.Text != "")
                            {
                                this.ImgButtonErase.Visible = true;
                                this.fp_artwork.Style.Add("display", "none");
                                this.ImgButtonErase_no_addoption1.Visible = true;
                                this.fp_artwork_no_addoption1.Style.Add("display", "none");
                            }
                            if (this.lblfp_artwork1.Text != "")
                            {
                                this.ImgButtonErase1.Visible = true;
                                this.fp_artwork1.Style.Add("display", "none");
                                this.ImgButtonErase_no_addoption2.Visible = true;
                                this.fp_artwork_no_addoption2.Style.Add("display", "none");
                            }
                            if (this.lblfp_artwork2.Text != "")
                            {
                                this.ImgButtonErase2.Visible = true;
                                this.fp_artwork2.Style.Add("display", "none");
                                this.ImgButtonErase_no_addoption3.Visible = true;
                                this.fp_artwork_no_addoption3.Style.Add("display", "none");
                            }
                            this.hdn_height.Value = dataSet.Tables[1].Rows[0]["Height"].ToString();
                            this.hdn_width.Value = dataSet.Tables[1].Rows[0]["Width"].ToString();
                            if (!base.IsPostBack)
                            {
                                this.hdnCampaignSelectedValue.Value = dataSet.Tables[1].Rows[0]["CampaignID"].ToString();
                                string str5 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_app");
                                string str6 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_app");
                                if (dataSet.Tables[1].Rows[0]["Order_Behalf_UserID"].ToString() != "0" && dataSet.Tables[1].Rows[0]["Order_Behalf_DeptID"].ToString() == "0" && str5.Trim().ToLower() != "n")
                                {
                                    this.ddl_SelectBehalf.SelectedValue = "1";
                                    this.setddlval(this.ddl_BehalfUsers, Convert.ToInt32(dataSet.Tables[1].Rows[0]["Order_Behalf_UserID"]));
                                    this.hdnUserBehalf.Value = "1";
                                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "show", "javascript:ShowBehalfOfDiv();", true);
                                }
                                else if (dataSet.Tables[1].Rows[0]["Order_Behalf_DeptID"].ToString() != "0" && dataSet.Tables[1].Rows[0]["Order_Behalf_UserID"].ToString() != "0" && str6.Trim().ToLower() != "n")
                                {
                                    this.ddl_SelectBehalf.SelectedValue = "2";
                                    this.setddlval(this.ddl_BehalfDepts, Convert.ToInt32(dataSet.Tables[1].Rows[0]["Order_Behalf_DeptID"]));
                                    this.SelectedDeptUser = Convert.ToInt64(dataSet.Tables[1].Rows[0]["Order_Behalf_UserID"]);
                                    this.hdnDeptBehalf.Value = "1";
                                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "show", "javascript:ShowBehalfOfDiv();LoadSelectedDeptUsers();", true);
                                }
                            }
                            if (!base.IsPostBack && dataSet.Tables[1].Rows[0]["IsStockReplenish"].ToString().ToLower() == "true")
                            {
                                this.rdstkbreplenish.Checked = true;
                                this.rdbstkorder.Checked = false;
                            }
                        }
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:GetDetails_Edit();", true);

                        //DataTable dtDecoration = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID);

                        //string decoration1Value = "No";
                        //string decoration2Value = "No";
                        //string decoration3Value = "No";
                        //string decoration4Value = "No";
                        //string decoration5Value = "No";
                        //string decoration6Value = "No";


                        //foreach (DataRow dtitem in dtDecoration.Rows)
                        //{
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 101)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration1Value = strSelectedValue[1];

                        //        SetDDLValueForProductPage(ddlDecoration1, decoration1Value);
                        //    }
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 102)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration2Value = strSelectedValue[1];
                        //        SetDDLValueForProductPage(ddlDecoration2, decoration2Value);


                        //    }
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 103)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration3Value = strSelectedValue[1];
                        //        SetDDLValueForProductPage(ddlDecoration3, decoration3Value);


                        //    }
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 104)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration4Value = strSelectedValue[1];
                        //        SetDDLValueForProductPage(ddlDecoration4, decoration4Value);


                        //    }
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 105)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration5Value = strSelectedValue[1];
                        //        SetDDLValueForProductPage(ddlDecoration5, decoration5Value);


                        //    }
                        //    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 106)
                        //    {
                        //        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        //        decoration6Value = strSelectedValue[1];
                        //        SetDDLValueForProductPage(ddlDecoration6, decoration6Value);

                        //    }


                        //}


                    }
                }
                else if (RewriteContext.Current.Params["CartItemID"] != null)
                {
                    string str7 = RewriteContext.Current.Params["CartItemID"].ToString();
                    keySeparator = new char[] { this.KeySeparator };
                    this.CartItemID = Convert.ToInt32(str7.Split(keySeparator)[1]);
                    DataSet dataSet1 = ProductBasePage.Cart_Details_Edit((long)this.CartItemID);
                    if (dataSet1.Tables.Count > 0 && dataSet1.Tables[1].Rows.Count > 0)
                    {
                        this.hid_Quantity_Edit.Value = dataSet1.Tables[1].Rows[0]["Quantity"].ToString();
                        this.hid_totalPrice_Edit.Value = dataSet1.Tables[0].Rows[0]["CartTotalPrice"].ToString();
                        this.hdn_height.Value = dataSet1.Tables[1].Rows[0]["Height"].ToString();
                        this.hdn_width.Value = dataSet1.Tables[1].Rows[0]["Width"].ToString();
                        this.hdnCampaignSelectedValue.Value = dataSet1.Tables[1].Rows[0]["CampaignID"].ToString();
                    }
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:GetDetails_Edit();", true);
                }
                if (this.CopiedPriceCatalogueId != 0)
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<div class='div_plhquantity'>"));
                    if (this.hid_matixType.Value == "P")
                    {
                        if (this.isQuantity != "1")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div  id='qty_div' class='DisplayNone floatLeft'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label></div>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='DisplayNone floatRight'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                        else
                        {
                            ControlCollection controls1 = this.plhquantity.Controls;
                            if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                            {
                                secureSitePath = new object[] { "<div id='qty_div' class='floatLeft'><label>", this.objLanguage.GetLanguageConversion("Total_Quantity"), " </label></div>" };
                            }
                            else
                            {
                                secureSitePath = new object[] { "<div id='qty_div' class='floatLeft'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            }
                            controls1.Add(new LiteralControl(string.Concat(secureSitePath)));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8' readonly/>"));
                                }
                                else
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                                }
                            }
                        }
                    }
                    else if (this.hid_matixType.Value == "G")
                    {
                        if (this.isQuantity != "1")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div  id='qty_div' class='DisplayNone floatLeft'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label></div>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='DisplayNone floatRight'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value.0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                        else
                        {
                            ControlCollection controlCollections1 = this.plhquantity.Controls;
                            secureSitePath = new object[] { "<div id='qty_div' class='floatLeft'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(secureSitePath)));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                    }
                    else if (this.isQuantity != "1")
                    {
                        this.plhquantity.Controls.Add(new LiteralControl("<div id='qty_div' class='DisplayNone floatLeft'></div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='DisplayNone floatRight'>"));
                        DataTable dataTable6 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                        if (!this.IsCumulative)
                        {
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0','0');");
                            if (this.CartItemID <= 0)
                            {
                                this.SimpleMatrix_DropDownBind(dataTable6, this.ddlPriceQty, this.plhquantity);
                            }
                            else
                            {
                                this.SimpleMatrix_DropDownBind_Edit(dataTable6, this.ddlPriceQty, this.plhquantity, this.hid_Quantity_Edit.Value);
                            }
                        }
                        else
                        {
                            this.txt_Cumulative_PriceQty.ID = "txt_Cumulative_PriceQty";
                            this.txt_Cumulative_PriceQty.CssClass = "txtStyle";
                            this.txt_Cumulative_PriceQty.Attributes.Add("onblur", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                            this.txt_Cumulative_PriceQty.Attributes.Add("onkeyup", "javascript:Tocalculate_totalPrice('0','0');CheckIsDecimal_Textbox(this,this.value)");
                            if (!(this.hid_Quantity_Edit.Value != "0") || !(this.hid_Quantity_Edit.Value != ""))
                            {
                                this.txt_Cumulative_PriceQty.Text = "0";
                                this.txt_Cumulative_PriceQty.Attributes.Add("value", "0");
                            }
                            else
                            {
                                this.txt_Cumulative_PriceQty.Text = this.hid_Quantity_Edit.Value;
                                this.txt_Cumulative_PriceQty.Attributes.Add("value", this.hid_Quantity_Edit.Value);
                            }
                            this.plhquantity.Controls.Add(this.txt_Cumulative_PriceQty);
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0','0');");
                            this.ddlPriceQty.Style.Add("display", "none");
                            if (this.CartItemID <= 0)
                            {
                                this.SimpleMatrix_DropDownBind(dataTable6, this.ddlPriceQty, this.plhquantity);
                            }
                            else
                            {
                                this.SimpleMatrix_DropDownBind_Edit(dataTable6, this.ddlPriceQty, this.plhquantity, this.hid_Quantity_Edit.Value);
                            }
                        }
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_Cal", "javascript:Tocalculate_totalPrice('0','0');", true);
                    }
                    else
                    {
                        if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='qty_div' class='floatLeft'><label>Total Quantity </label></div>")));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='qty_div' class='floatLeft'><label>Select quantity to order </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>")));
                        }
                        if (Convert.ToBoolean(this.hdnMatrixCheckMultipleProduct.Value))
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='MarginLeft2px floatRight'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value,0); CheckStockAvailability(this.value); Tocall_mainFunc();' onkeyup='javascript:Tocalculate_totalPrice(this.value,0); CheckIsDecimal(this.value);' maxlength='8' readonly/>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div><div class='floatRight width300px'>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_Quantity"), "</span></div></div>")));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        }
                        else
                        {
                            if (this.IsAdditionalOption.ToLower() != "yes")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='MarginLeft7px floatRight'>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='MarginLeft2px floatRight'>"));
                            }
                            DataTable dataTable7 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                            if (!this.IsCumulative)
                            {
                                this.ddlPriceQty.ID = "ddlPriceQty";
                                this.ddlPriceQty.CssClass = "dropDownMultiple75";
                                this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                                this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0','0');");
                                if (this.CartItemID <= 0)
                                {
                                    this.SimpleMatrix_DropDownBind(dataTable7, this.ddlPriceQty, this.plhquantity);
                                }
                                else
                                {
                                    this.SimpleMatrix_DropDownBind_Edit(dataTable7, this.ddlPriceQty, this.plhquantity, this.hid_Quantity_Edit.Value);
                                }
                            }
                            else
                            {
                                this.txt_Cumulative_PriceQty.ID = "txt_Cumulative_PriceQty";
                                this.txt_Cumulative_PriceQty.CssClass = "txtStyle";
                                this.txt_Cumulative_PriceQty.Attributes.Add("onblur", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                                this.txt_Cumulative_PriceQty.Attributes.Add("onkeyup", "javascript:Tocalculate_totalPrice('0','0');CheckIsDecimal_Textbox(this,this.value)");
                                if (!(this.hid_Quantity_Edit.Value != "0") || !(this.hid_Quantity_Edit.Value != ""))
                                {
                                    this.txt_Cumulative_PriceQty.Text = "0";
                                    this.txt_Cumulative_PriceQty.Attributes.Add("value", "0");
                                }
                                else
                                {
                                    this.txt_Cumulative_PriceQty.Text = this.hid_Quantity_Edit.Value;
                                    this.txt_Cumulative_PriceQty.Attributes.Add("value", this.hid_Quantity_Edit.Value);
                                }
                                this.plhquantity.Controls.Add(this.txt_Cumulative_PriceQty);
                                this.ddlPriceQty.ID = "ddlPriceQty";
                                this.ddlPriceQty.CssClass = "dropDownMultiple75";
                                this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0','0'); CheckStockAvailability('0')");
                                this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0','0');");
                                this.ddlPriceQty.Style.Add("display", "none");
                                if (this.CartItemID <= 0)
                                {
                                    this.SimpleMatrix_DropDownBind(dataTable7, this.ddlPriceQty, this.plhquantity);
                                }
                                else
                                {
                                    this.SimpleMatrix_DropDownBind_Edit(dataTable7, this.ddlPriceQty, this.plhquantity, this.hid_Quantity_Edit.Value);
                                }
                            }
                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_Cal", "javascript:Tocalculate_totalPrice('0','0');", true);
                        }
                        //this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div><div class='floatRight width300px'>"));
                        //this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_Quantity"), "</span></div></div>")));
                        //this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div><div class='floatRight width300px'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_Quantity"), "</span></div></div>")));
                    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    if (this.hid_matixType.Value == "G" && this.isQuantity == "1")
                    {
                        this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div>"));
                        ControlCollection controls2 = this.plhquantity.Controls;
                        secureSitePath = new object[] { "<div id='divDimension'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                        controls2.Add(new LiteralControl(string.Concat(secureSitePath)));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<table class='DimensionTable'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divWidth' class='lblWidthHeight'><label>", this.objLanguage.GetLanguageConversion("Width"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections2 = this.plhquantity.Controls;
                        secureSitePath = new object[] { "<input id='txtWidth' type='text' class='txtStyle' ", this.txtWidth_Style, " onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id,0);' />" };
                        controlCollections2.Add(new LiteralControl(string.Concat(secureSitePath)));
                        if (this.RightPanelCalc_Enabled.ToLower() == "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='lblWidthHeight1'><label>", this.objLanguage.GetLanguageConversion("Width"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divHeight' class='lblWidthHeight'><label>", this.objLanguage.GetLanguageConversion("Height"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls3 = this.plhquantity.Controls;
                        secureSitePath = new object[] { "<input id='txtHeight' type='text' class='txtStyle' ", this.txtHeight_Style, " onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id,0);' />" };
                        controls3.Add(new LiteralControl(string.Concat(secureSitePath)));
                        if (this.RightPanelCalc_Enabled.ToLower() == "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='lblWidthHeight2'><label>", this.objLanguage.GetLanguageConversion("Height"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</table>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div><div class='floatRight width300px'>"));
                        this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_Dimensn'><span id='spnDimensn'>", this.objLanguage.GetLanguageConversion("Please_enter_dimension"), " </div>")));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='DimnsnEndDiv'></div>"));
                    }
                }
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int length = 0;
                int num68 = 0;
                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                string empty2 = string.Empty;
                foreach (DataRow row3 in dataTable5.Rows)
                {
                    if (this.CartItemID <= 0)
                    {
                        DataSet dataSet2 = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(row3["WebOtherCostID"].ToString()));
                        DataTable item1 = dataSet2.Tables[0];
                        DataTable item2 = dataSet2.Tables[1];
                        if (dataSet2.Tables[1].Rows.Count > 0)
                        {
                            this.isHideAddtoCartStayButton2 = true;
                        }
                        long num6 = Convert.ToInt64(row3["WebOtherCostID"].ToString());
                        long num7 = Convert.ToInt64(row3["AdditionalGroupID"].ToString());
                        int num8 = Convert.ToInt32(row3["IsStockAddType"]);
                        num5++;
                        string empty3 = string.Empty;
                        string empty4 = string.Empty;
                        foreach (DataRow dataRow3 in item1.Rows)
                        {
                            this.MainCalculationtype = dataRow3["MainCalculationType"].ToString();
                            if (this.MainCalculationtype.ToLower() == "c" || this.MainCalculationtype.ToLower() == "m")
                            {
                                num = Convert.ToInt32(dataRow3["IsCartmandatory"]);
                                empty4 = num.ToString();
                            }
                            this.HelpText = dataRow3["Description"].ToString().Replace("\n", "<br>");
                            this.OtherCostName = dataRow3["UserFriendlyName"].ToString();
                        }
                        int num9 = 0;
                        if (num7 == (long)0)
                        {
                            empty3 = "1";
                        }
                        else if (empty2 == "")
                        {
                            empty3 = "1";
                        }
                        else
                        {
                            keySeparator = new char[] { '±' };
                            string[] strArrays = empty2.Split(keySeparator);
                            for (int i = 0; i < (int)strArrays.Length - 1; i++)
                            {
                                if (strArrays[i] == "")
                                {
                                    empty3 = "1";
                                }
                                else
                                {
                                    empty3 = (num7 == (long)0 || Convert.ToInt64(strArrays[i]) != num7 ? "1" : "0");
                                }
                            }
                        }
                        empty2 = string.Concat(empty2, row3["AdditionalGroupID"].ToString(), "±");
                        foreach (DataRow row4 in item2.Rows)
                        {
                            if (this.MainCalculationtype.ToLower() == "q")
                            {
                                string str8 = row4["formula"].ToString();
                                string str9 = row4["Question"].ToString();
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }
                                ControlCollection controlCollections3 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<label id='lblQuestion_", num2, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str9), "</label>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(secureSitePath)));
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controls4 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num2, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }

                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                ControlCollection controlCollections4 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<input id='txtQuestion_", num2, "' grpvalue='", empty3, "'  onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' /><div style='margin-bottom:5px;'></div>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B' >"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B paddingTop3' >"));
                                }
                                if (this.IsEnableHidePrice != "false")
                                {
                                    ControlCollection controls5 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str8, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controls5.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                }
                                else if (!this.IsDisplayAdditionalOptions)
                                {
                                    ControlCollection controlCollections5 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str8, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                }
                                else
                                {
                                    ControlCollection controlCollections5 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str8, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                num2++;
                            }
                            else if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                            {
                                string str8 = row4["formula"].ToString();
                                string str9 = row4["Question"].ToString();
                                bool hideAdditionalOptionName = Convert.ToBoolean(row4["HideAdditionalOptionName"].ToString());
                                bool MandatoryField = Convert.ToBoolean(row4["IsMandatoryField"].ToString());
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }

                                ControlCollection controlCollections3 = this.plhPriceCalculator.Controls;
                                if (hideAdditionalOptionName)
                                {
                                    secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' >", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                }
                                else
                                {
                                    secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                }
                                controlCollections3.Add(new LiteralControl(string.Concat(secureSitePath)));

                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controls4 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num68, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }

                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                ControlCollection controlCollections4 = this.plhPriceCalculator.Controls;
                                //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty3, "'  onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' class='txtStyle' type='text' /><div style='margin-bottom:5px;'></div>" };
                                //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty3, "' onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' style='width:100%' rows='3'></textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", MandatoryField, "'/><div style='margin-bottom:5px;'></div>" };

                                //int charLimit = 0;
                                //if(this.MainCalculationtype.ToLower() == "f")
                                //{
                                //    charLimit = 100;
                                //}
                                //else
                                //{
                                //    charLimit = 1000;
                                //}

                                //secureSitePath = new object[]
                                //{
                                //    "<textarea id='txtFreeTextQuestion_", num68,
                                //    "' grpvalue='", empty3,
                                //    "' maxlength='", charLimit,
                                //    "' onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();updateCharCount(this,", charLimit, ");'",
                                //    " onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();'",
                                //    " oninput='updateCharCount(this,", charLimit, ");'",
                                //    " style='width:100%' rows='3'></textarea>",

                                //    "<div style='color:red;'><span id='charCount_", num68, "'>0</span>/", charLimit, " characters</div>",

                                //    "<input type='hidden' id='hdn_FreeTextQuestion_", num68,
                                //    "' value='", MandatoryField,
                                //    "'/><input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", num68,
                                //    "' value='", this.MainCalculationtype.ToLower(),"'/><div style='margin-bottom:5px;'></div>"
                                //};
                                secureSitePath = BuildFreeTextBlockWithCharLimit(
                                    num68,
                                    empty3,
                                    num7,
                                    num6,
                                    "",
                                    MandatoryField,
                                    this.MainCalculationtype
                                );
                                controlCollections4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div></div>"));
                                num68++;
                            }
                            else if (this.MainCalculationtype.ToLower() == "c")
                            {
                                if (num9 == 0)
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth' ></div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
                                    ControlCollection controls6 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<input id='chkMultiple_", num3, "' class='DisplayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num3, ");'/>" };
                                    controls6.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                    }
                                    if (empty4 != "1")
                                    {
                                        ControlCollection controlCollections6 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                        controlCollections6.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else
                                    {
                                        ControlCollection controls7 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label><span style='color:Red;'> *</span>" };
                                        controls7.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    if (this.HelpText != "")
                                    {
                                        this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<span class='tooltip' title='", this.HelpText.Replace("<br>", ""), "'>")));
                                        ControlCollection controlCollections7 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<img id='img_help_", num9, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px'  /></span>" };
                                        controlCollections7.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                    if (length <= 80)
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num3),
                                        CssClass = "dropDownMultiple150"
                                    };
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        dropDownList.Width = 300;
                                    }
                                    if (row4["CalculationType"].ToString().ToLower().Trim() != "groups")
                                    {
                                        if (num8 != 1)
                                        {
                                            AttributeCollection attributes = dropDownList.Attributes;
                                            secureSitePath = new object[] { "javascript:ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();" };
                                            attributes.Add("onchange", string.Concat(secureSitePath));
                                        }
                                        else
                                        {
                                            AttributeCollection attributeCollection = dropDownList.Attributes;
                                            secureSitePath = new object[] { "javascript:CheckAddOptStockAvailability(this.id,", num6, ");ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();" };
                                            attributeCollection.Add("onchange", string.Concat(secureSitePath));
                                            this.hdnWebOtherCostID.Value = num6.ToString();
                                            this.hdnStockAddOption.Value = dropDownList.ClientID;
                                        }
                                        dropDownList.Attributes.Add("IsMandatory", empty4);
                                        dropDownList.Attributes.Add("grpvalue", empty3);
                                    }
                                    else
                                    {
                                        AttributeCollection attributes1 = dropDownList.Attributes;
                                        secureSitePath = new object[] { "javascript: VisibleAdditionaloption('", num6, "');ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();" };
                                        attributes1.Add("onchange", string.Concat(secureSitePath));
                                        dropDownList.Attributes.Add("isgroup", "maingroup");
                                        dropDownList.Attributes.Add("WeotherCostID", row3["WebOtherCostID"].ToString());
                                        dropDownList.Attributes.Add("IsMandatory", empty4);
                                    }
                                    row4["CalculationType"].ToString();
                                    this.comm.MultipleChoice_DropDownBind(item2, dropDownList, this.plhPriceCalculator, row4["CalculationType"].ToString());
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B'>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_innerDiv2'>"));
                                    if (this.IsEnableHidePrice != "false")
                                    {
                                        ControlCollection controls8 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "' style='display:none;'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controls8.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else if (!this.IsDisplayAdditionalOptions)
                                    {
                                        ControlCollection controls8 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controls8.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections8 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "'style='display:none;'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controlCollections8.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    DataTable dataTable8 = new DataTable();
                                    DataSet dataSet3 = new DataSet();
                                    DataTable item3 = new DataTable();
                                    DataTable item4 = new DataTable();
                                    string empty5 = string.Empty;
                                    int length1 = 0;
                                    if (row4["CalculationType"].ToString().ToLower().Trim() == "groups")
                                    {
                                        for (int j = 0; j < item2.Rows.Count; j++)
                                        {
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<div style='display:none;' id='div_SubAdditionalsddl_", Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), "'>")));
                                            dataTable8 = ProductBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), Convert.ToInt32(row3["WebOtherCostID"].ToString()));
                                            if (dataTable8.Rows.Count > 0 && Convert.ToInt64(dataTable8.Rows[0]["GroupID"]) != (long)0)
                                            {
                                                for (int k = 0; k < dataTable8.Rows.Count; k++)
                                                {
                                                    num5++;
                                                    dataSet3 = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataTable8.Rows[k]["WebOtherCostID"].ToString()));
                                                    item3 = dataSet3.Tables[0];
                                                    item4 = dataSet3.Tables[1];
                                                    enumerator = item3.Rows.GetEnumerator();
                                                    try
                                                    {
                                                        if (enumerator.MoveNext())
                                                        {
                                                            DataRow current = (DataRow)enumerator.Current;
                                                            num = Convert.ToInt32(current["IsCartmandatory"]);
                                                            empty5 = num.ToString();
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        disposable = enumerator as IDisposable;
                                                        if (disposable != null)
                                                        {
                                                            disposable.Dispose();
                                                        }
                                                    }
                                                    if (item3.Rows[0]["MainCalculationType"].ToString() == "f" || item3.Rows[0]["MainCalculationType"].ToString() == "l")
                                                    {
                                                        string str8 = item4.Rows[0]["formula"].ToString();
                                                        string str9 = item4.Rows[0]["Question"].ToString();
                                                        bool hideAdditionalOptionName = Convert.ToBoolean(item4.Rows[0]["HideAdditionalOptionName"].ToString());
                                                        bool MandatoryField = Convert.ToBoolean(item4.Rows[0]["IsMandatoryField"].ToString());
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                                        }

                                                        ControlCollection controlCollections3 = this.plhPriceCalculator.Controls;
                                                        if (hideAdditionalOptionName)
                                                        {
                                                            secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' >", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                                        }
                                                        else
                                                        {
                                                            secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                                        }
                                                        controlCollections3.Add(new LiteralControl(string.Concat(secureSitePath)));

                                                        if (this.HelpText != "")
                                                        {
                                                            this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                                            ControlCollection controls4 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<img id='img_help_", num68, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                                            controls4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }

                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        ControlCollection controlCollections4 = this.plhPriceCalculator.Controls;
                                                        //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty3, "'  onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' class='txtStyle' type='text' /><div style='margin-bottom:5px;'></div>" };
                                                        //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty3, "' onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' style='width:100%' rows='3'></textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", MandatoryField, "'/><div style='margin-bottom:5px;'></div>" };
//                                                        int charLimit = 0;
//                                                        if (this.MainCalculationtype.ToLower() == "f")
//                                                        {
//                                                            charLimit = 100;
//                                                        }
//                                                        else
//                                                        {
//                                                            charLimit = 1000;
//                                                        }
//                                                        secureSitePath = new object[]
//{                                                           "<textarea id='txtFreeTextQuestion_", num68,
//                                                            "' grpvalue='", empty3,
//                                                            "' maxlength='", charLimit,
//                                                            "' onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();updateCharCount(this,", charLimit, ");'",
//                                                            "' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();'",
//                                                            "' oninput='updateCharCount(this,", charLimit, ");'",
//                                                            "' style='width:100%' rows='3'></textarea>",

//                                                            "<div style='color:red;'><span id='charCount_", num68, "'>0</span>/", charLimit, " characters</div>",

//                                                            "<input type='hidden' id='hdn_FreeTextQuestion_", num68,
//                                                            "' value='", MandatoryField,
//                                                            "'/><input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", num68,
//                                                            "' value='", this.MainCalculationtype.ToLower(),
//                                                            "'/><div style='margin-bottom:5px;'></div>"
//                                                        };

                                                        secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                           num68,
                                                           empty3,
                                                           num7,
                                                           num6,
                                                           "",
                                                           MandatoryField,
                                                           item3.Rows[0]["MainCalculationType"].ToString()
                                                       );
                                                        controlCollections4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div></div>"));
                                                        num68++;
                                                    }
                                                    else
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth' ></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                                        length1 = item3.Rows[0]["UserFriendlyName"].ToString().Trim().Length;
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                                        }
                                                        if (empty5 != "1")
                                                        {
                                                            ControlCollection controls9 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", base.SpecialDecode(item3.Rows[0]["UserFriendlyName"].ToString()), "</label>" };
                                                            controls9.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else
                                                        {
                                                            ControlCollection controlCollections9 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", base.SpecialDecode(item3.Rows[0]["UserFriendlyName"].ToString()), "</label><span style='color:Red;'> *</span>" };
                                                            controlCollections9.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        if (item3.Rows[0]["Description"] != null && item3.Rows[0]["Description"].ToString() != "")
                                                        {
                                                            this.HelpText = base.SpecialDecode(item3.Rows[0]["Description"].ToString().Trim()).Replace("'", "&#145");
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", item3.Rows[0]["Description"].ToString(), "'>")));
                                                            ControlCollection controls10 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<img id='img_help_", num9, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px'  /></a>" };
                                                            controls10.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                                        if (length1 <= 80)
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        }
                                                        length1 = 0;
                                                        DropDownList dropDownList1 = new DropDownList();
                                                        secureSitePath = new object[] { "ddlMultiple_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k };
                                                        dropDownList1.ID = string.Concat(secureSitePath);
                                                        dropDownList1.CssClass = "dropDownMultiple150";
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            dropDownList1.Width = 300;
                                                        }
                                                        dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                                        dropDownList1.Attributes.Add("isgroup", "subgroup");
                                                        dropDownList1.Attributes.Add("WeotherCostID", dataTable8.Rows[k]["WebOtherCostID"].ToString());
                                                        dropDownList1.Attributes.Add("IsMandatory", empty5);
                                                        this.comm.MultipleChoice_DropDownBind(item4, dropDownList1, this.plhPriceCalculator, item4.Rows[0]["CalculationType"].ToString().ToString());
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B'>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_innerDiv2'>"));
                                                        if (this.IsEnableHidePrice != "false")
                                                        {
                                                            ControlCollection controlCollections10 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", dataTable8.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none;'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", num5, "</label>" };
                                                            controlCollections10.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else if (!this.IsDisplayAdditionalOptions)
                                                        {
                                                            ControlCollection controls11 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", dataTable8.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", num5, "</label>" };
                                                            controls11.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else
                                                        {
                                                            ControlCollection controlCollections11 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", dataTable8.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "'></label><label id='lblMultipleGroupID_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='DisplayNone'>", num5, "</label>" };
                                                            controlCollections11.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    }
                                                }
                                            }
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    num3++;
                                }
                            }
                            else if (this.MainCalculationtype.ToLower() == "m" && num9 == 0)
                            {
                                //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content' >"));
                                //row4["matrixType"].ToString();
                                //if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                //{
                                //    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                //}
                                //else
                                //{
                                //    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                //}
                                //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                ////ControlCollection controls12 = this.plhPriceCalculator.Controls;
                                ////secureSitePath = new object[] { "<div class='div_Chk_Matrix'><input id='chkMatrix_", num4, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty3, " onclick='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();'/></div>" };
                                ////controls12.Add(new LiteralControl(string.Concat(secureSitePath)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
                                ControlCollection controlCollections30 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<input id='chkMultiple_", num3, "' class='DisplayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num3, ");'/>" };
                                controlCollections30.Add(new LiteralControl(string.Concat(secureSitePath)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                length = this.OtherCostName.Length;
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }
                                if (empty4 != "1")
                                {
                                    ControlCollection controls19 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                    controls19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    ControlCollection controlCollections19 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label><span style='color:Red;'> *</span>" };
                                    controlCollections19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                    }
                                    ControlCollection controls20 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num9, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls20.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                if (length <= 80)
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                }


                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                DropDownList dropDownList1 = new DropDownList();
                                secureSitePath = new object[] { "chkMatrix_", num4 };
                                dropDownList1.ID = string.Concat(secureSitePath);
                                dropDownList1.CssClass = "dropDownMultiple150";
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    dropDownList1.Width = 300;
                                }

                                DataTable dt = new DataTable();
                                dt.Clear();
                                dt.Columns.Add("FormulaNew");
                                dt.Columns.Add("Label");
                                DataRow _row = dt.NewRow();
                                _row["FormulaNew"] = "0";
                                _row["Label"] = "---Select---";
                                dt.Rows.Add(_row);

                                _row = dt.NewRow();
                                _row["FormulaNew"] = "1";
                                _row["Label"] = "Yes";
                                dt.Rows.Add(_row);

                                _row = dt.NewRow();
                                _row["FormulaNew"] = "2";
                                _row["Label"] = "No";
                                dt.Rows.Add(_row);



                                //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                AttributeCollection attributes = dropDownList1.Attributes;
                                secureSitePath = new object[] { "javascript:ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();" };
                                attributes.Add("onchange", string.Concat(secureSitePath));
                                attributes.Add("grpvalue", empty3);
                                //dropDownList1.Attributes.Add("isgroup", "subgroup");
                                //dropDownList1.Attributes.Add("WeotherCostID", dataTable8.Rows[k]["WebOtherCostID"].ToString());
                                dropDownList1.Attributes.Add("IsMandatory", empty4);
                                this.comm.MultipleChoice_DropDownBind(dt, dropDownList1, this.plhPriceCalculator, "");
                                //if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                //{
                                //    ControlCollection controlCollections12 = this.plhPriceCalculator.Controls;
                                //    secureSitePath = new object[] { "<div class='floatLeft clearTop clearBottom'><label id='lblMatrixName_", num4, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                //    controlCollections12.Add(new LiteralControl(string.Concat(secureSitePath)));
                                //}
                                //else
                                //{
                                //    ControlCollection controls13 = this.plhPriceCalculator.Controls;
                                //    secureSitePath = new object[] { "<div class='divchkMatrix_lbl'><label id='lblMatrixName_", num4, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                //    controls13.Add(new LiteralControl(string.Concat(secureSitePath)));
                                //}
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections13 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num9, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controlCollections13.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='DisplayNone'>"));
                                if (row4["matrixType"].ToString().ToLower() != "pricebands")
                                {
                                    DropDownList dropDownList2 = new DropDownList();
                                    this.comm.MultipleChoice_DropDownBind(item2, dropDownList2, this.plhPriceCalculator, "matrix");
                                    dropDownList2.ID = string.Concat("ddlMatrix_", num4);
                                    dropDownList2.CssClass = "dropDownMultiple150";
                                    dropDownList2.Width = 300;
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() == "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatRight'><div class='price_table_content_right_innerDiv3'>"));
                                ControlCollection controls14 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<label id='lblMatrixID_", num4, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num4, "' class='DisplayNone'>", row4["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num4, "' class='DisplayNone'></label><label id='lblMatrixGroupID_", num4, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixSortOrderNo_", num4, "' class='DisplayNone'>", num5, "</label>" };
                                controls14.Add(new LiteralControl(string.Concat(secureSitePath)));
                                if (this.IsEnableHidePrice != "false")
                                {
                                    ControlCollection controlCollections14 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controlCollections14.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else if (!this.IsDisplayAdditionalOptions)
                                {
                                    ControlCollection controls15 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controls15.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    ControlCollection controls15 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controls15.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                num4++;
                            }
                            num9++;
                        }

                    }
                    else
                    {
                        DataSet dataSet4 = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(row3["WebOtherCostID"].ToString()));
                        DataTable item5 = dataSet4.Tables[0];
                        DataTable item6 = dataSet4.Tables[1];
                        long num10 = Convert.ToInt64(row3["WebOtherCostID"].ToString());
                        long num11 = Convert.ToInt64(row3["AdditionalGroupID"].ToString());
                        int num12 = Convert.ToInt32(row3["IsStockAddType"]);
                        num5++;
                        string empty6 = string.Empty;
                        string empty7 = string.Empty;
                        foreach (DataRow dataRow4 in item5.Rows)
                        {
                            this.MainCalculationtype = dataRow4["MainCalculationType"].ToString();
                            if (this.MainCalculationtype.ToLower() == "c" || this.MainCalculationtype.ToLower() == "m")
                            {
                                num = Convert.ToInt32(dataRow4["IsCartmandatory"]);
                                empty7 = num.ToString();
                            }
                            this.HelpText = dataRow4["Description"].ToString().Replace("\n", "<br>");
                            this.OtherCostName = dataRow4["UserFriendlyName"].ToString();
                        }
                        int num13 = 0;
                        if (num11 == (long)0)
                        {
                            empty6 = "1";
                        }
                        else if (empty2 == "")
                        {
                            empty6 = "1";
                        }
                        else
                        {
                            keySeparator = new char[] { '±' };
                            string[] strArrays1 = empty2.Split(keySeparator);
                            for (int l = 0; l < (int)strArrays1.Length - 1; l++)
                            {
                                if (strArrays1[l] == "")
                                {
                                    empty6 = "1";
                                }
                                else
                                {
                                    empty6 = (num11 == (long)0 || Convert.ToInt64(strArrays1[l]) != num11 ? "1" : "0");
                                }
                            }
                        }
                        empty2 = string.Concat(empty2, row3["AdditionalGroupID"].ToString(), "±");
                        foreach (DataRow row5 in item6.Rows)
                        {
                            if (this.MainCalculationtype.ToLower() == "q")
                            {
                                string str10 = row5["formula"].ToString();
                                string str11 = row5["Question"].ToString();
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }
                                ControlCollection controlCollections15 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<label id='lblQuestion_", num2, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str11), "</label>" };
                                controlCollections15.Add(new LiteralControl(string.Concat(secureSitePath)));
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                    }
                                    ControlCollection controls16 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num2, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls16.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                DataTable dataTable9 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                if (dataTable9.Rows.Count <= 0)
                                {
                                    if (num11 != (long)0)
                                    {
                                        empty6 = "0";
                                    }
                                    ControlCollection controlCollections16 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<input id='txtQuestion_", num2, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' /><div style='margin-bottom:5px;'></div>" };
                                    controlCollections16.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    empty6 = "1";
                                    ControlCollection controls17 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<input id='txtQuestion_", num2, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' value=", dataTable9.Rows[0]["SelectedValue"].ToString(), "  />" };
                                    controls17.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatRight paddingTop3'>"));
                                }
                                if (this.IsEnableHidePrice != "false")
                                {
                                    ControlCollection controlCollections17 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "' class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str10, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controlCollections17.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else if (!this.IsDisplayAdditionalOptions)
                                {
                                    ControlCollection controls18 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str10, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controls18.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    ControlCollection controls18 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblPrice_", num2, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num2, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num2, "' class='DisplayNone'>", str10, " </label><label id='lblQuestionGroupID_", num2, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num2, "' class='DisplayNone'>", num5, "</label>" };
                                    controls18.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                num2++;
                            }
                            else if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                            {
                                string str10 = row5["formula"].ToString();
                                string str11 = row5["Question"].ToString();
                                bool IsHideAdditionalOptionName = Convert.ToBoolean(row5["HideAdditionalOptionName"].ToString());
                                bool IsMandatoryField = Convert.ToBoolean(row5["IsMandatoryField"].ToString());
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }
                                ControlCollection controlCollections15 = this.plhPriceCalculator.Controls;
                                if (IsHideAdditionalOptionName)
                                {
                                    secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' > ", base.SpecialDecode(str11), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                }
                                else
                                {
                                    secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str11), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                }
                                controlCollections15.Add(new LiteralControl(string.Concat(secureSitePath)));
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                    }
                                    ControlCollection controls16 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num68, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls16.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                DataTable dataTable9 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                if (dataTable9.Rows.Count <= 0)
                                {
                                    if (num11 != (long)0)
                                    {
                                        empty6 = "0";
                                    }
                                    ControlCollection controlCollections16 = this.plhPriceCalculator.Controls;
                                    //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' /><div style='margin-bottom:5px;'></div>" };
                                    //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "' onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();'style='width:100%' rows='3'></textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", IsMandatoryField, "'/><div style='margin-bottom:5px;'></div>" };
                                    secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                           num68,
                                                           empty6,
                                                           num11,
                                                           num10,
                                                           "",
                                                           IsMandatoryField,
                                                           this.MainCalculationtype
                                                       );
                                    controlCollections16.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    empty6 = "1";
                                    ControlCollection controls17 = this.plhPriceCalculator.Controls;
                                    //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' value=", dataTable9.Rows[0]["SelectedValue"].ToString(), "  />" };
                                    //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "' onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' style='width:100%' rows='3'>", dataTable9.Rows[0]["SelectedValue"].ToString(), "  </textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", IsMandatoryField, "'/>" };
                                    secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                            num68,
                                                            empty6,
                                                            num11,
                                                            num10,
                                                            dataTable9.Rows[0]["SelectedValue"].ToString(),
                                                            IsMandatoryField,
                                                            this.MainCalculationtype
                                                        );
                                    controls17.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                num68++;
                            }

                            else if (this.MainCalculationtype.ToLower() == "c")
                            {
                                if (num13 == 0)
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
                                    ControlCollection controlCollections18 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<input id='chkMultiple_", num3, "' class='DisplayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num3, ");'/>" };
                                    controlCollections18.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                    }
                                    if (empty7 != "1")
                                    {
                                        ControlCollection controls19 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                        controls19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections19 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label><span style='color:Red;'> *</span>" };
                                        controlCollections19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    if (this.HelpText != "")
                                    {
                                        this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                        if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                        {
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                        }
                                        else
                                        {
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                        }
                                        ControlCollection controls20 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<img id='img_help_", num13, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                        controls20.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                    if (length <= 80)
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList3 = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num3),
                                        CssClass = "dropDownMultiple150"
                                    };
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        dropDownList3.Width = 300;
                                    }
                                    if (row5["CalculationType"].ToString().ToLower().Trim() != "groups")
                                    {
                                        if (num12 != 1)
                                        {
                                            AttributeCollection attributeCollection1 = dropDownList3.Attributes;
                                            secureSitePath = new object[] { "javascript:ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();" };
                                            attributeCollection1.Add("onchange", string.Concat(secureSitePath));
                                        }
                                        else
                                        {
                                            AttributeCollection attributes2 = dropDownList3.Attributes;
                                            secureSitePath = new object[] { "javascript:CheckAddOptStockAvailability(this.id,", num10, ");ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();" };
                                            attributes2.Add("onchange", string.Concat(secureSitePath));
                                            this.hdnWebOtherCostID.Value = num10.ToString();
                                            this.hdnStockAddOption.Value = dropDownList3.ClientID;
                                        }
                                        dropDownList3.Attributes.Add("IsMandatory", empty7);
                                        dropDownList3.Attributes.Add("grpvalue", empty6);
                                    }
                                    else
                                    {
                                        AttributeCollection attributeCollection2 = dropDownList3.Attributes;
                                        secureSitePath = new object[] { "javascript: VisibleAdditionaloption('", num10, "');ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();" };
                                        attributeCollection2.Add("onchange", string.Concat(secureSitePath));
                                        dropDownList3.Attributes.Add("isgroup", "maingroup");
                                        dropDownList3.Attributes.Add("IsMandatory", empty7);
                                        dropDownList3.Attributes.Add("grpvalue", empty6);
                                        dropDownList3.Attributes.Add("WeotherCostID", row3["WebOtherCostID"].ToString());
                                    }
                                    DataTable dataTable10 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                    if (dataTable10.Rows.Count <= 0)
                                    {
                                        if (num11 != (long)0)
                                        {
                                            empty6 = "0";
                                        }
                                        this.comm.MultipleChoice_DropDownBind(item6, dropDownList3, this.plhPriceCalculator, row5["CalculationType"].ToString());
                                    }
                                    else
                                    {
                                        empty6 = "1";
                                        this.comm.MultipleChoice_DropDownBind_Edit(item6, dropDownList3, this.plhPriceCalculator, row5["CalculationType"].ToString(), dataTable10.Rows[0]["SelectedValue"].ToString());
                                    }
                                    dropDownList3.Attributes.Add("grpvalue", empty6);
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B'>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_innerDiv'>"));
                                    if (this.IsEnableHidePrice != "false")
                                    {
                                        ControlCollection controlCollections20 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "'style='display:none;>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controlCollections20.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else if (!this.IsDisplayAdditionalOptions)
                                    {
                                        ControlCollection controls21 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "'class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controls21.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    else
                                    {
                                        ControlCollection controls21 = this.plhPriceCalculator.Controls;
                                        secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "'class='DisplayNone'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "' class='DisplayNone'>", num5, "</label>" };
                                        controls21.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    DataTable dataTable11 = new DataTable();
                                    DataSet dataSet5 = new DataSet();
                                    DataTable item7 = new DataTable();
                                    DataTable item8 = new DataTable();
                                    string empty8 = string.Empty;
                                    int length2 = 0;
                                    if (row5["CalculationType"].ToString().ToLower().Trim() == "groups")
                                    {
                                        for (int m = 0; m < item6.Rows.Count; m++)
                                        {
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<div style='display:none;' id='div_SubAdditionalsddl_", Convert.ToInt32(item6.Rows[m]["SelectedID"].ToString()), "'>")));
                                            dataTable11 = ProductBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(item6.Rows[m]["SelectedID"].ToString()), Convert.ToInt32(row3["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable11.Rows[0]["GroupID"]) != (long)0)
                                            {
                                                for (int n = 0; n < dataTable11.Rows.Count; n++)
                                                {
                                                    num5++;
                                                    dataSet5 = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataTable11.Rows[n]["WebOtherCostID"].ToString()));
                                                    item7 = dataSet5.Tables[0];
                                                    item8 = dataSet5.Tables[1];
                                                    enumerator = item7.Rows.GetEnumerator();
                                                    try
                                                    {
                                                        if (enumerator.MoveNext())
                                                        {
                                                            DataRow current1 = (DataRow)enumerator.Current;
                                                            num = Convert.ToInt32(current1["IsCartmandatory"]);
                                                            empty8 = num.ToString();
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        disposable = enumerator as IDisposable;
                                                        if (disposable != null)
                                                        {
                                                            disposable.Dispose();
                                                        }
                                                    }
                                                    if (item7.Rows[0]["MainCalculationType"].ToString() == "f" || item7.Rows[0]["MainCalculationType"].ToString() == "l")
                                                    {
                                                        string str8 = item8.Rows[0]["formula"].ToString();
                                                        string str9 = item8.Rows[0]["Question"].ToString();
                                                        bool hideAdditionalOptionName = Convert.ToBoolean(item8.Rows[0]["HideAdditionalOptionName"].ToString());
                                                        bool MandatoryField = Convert.ToBoolean(item8.Rows[0]["IsMandatoryField"].ToString());
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                                        }

                                                        ControlCollection controlCollections3 = this.plhPriceCalculator.Controls;
                                                        if (hideAdditionalOptionName)
                                                        {
                                                            secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' >", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                                        }
                                                        else
                                                        {
                                                            secureSitePath = new object[] { "<label id='lblFreeTextQuestion_", num68, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str9), "</label><label id='lblFreeTextQuestionID_", num68, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblTextQuestionSortOrderNo_", num68, "' class='DisplayNone'>", num5, "</label>" };
                                                        }
                                                        controlCollections3.Add(new LiteralControl(string.Concat(secureSitePath)));

                                                        if (this.HelpText != "")
                                                        {
                                                            this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                                            ControlCollection controls4 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<img id='img_help_", num68, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                                            controls4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }

                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div >"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        ControlCollection controlCollections4 = this.plhPriceCalculator.Controls;
                                                        //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty3, "'  onkeyup='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num7, ",", num6, ");Tocall_mainFunc();' class='txtStyle' type='text' /><div style='margin-bottom:5px;'></div>" };
                                                        //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "' onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' style='width:100%' rows='3'></textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", MandatoryField, "'/>" };
                                                      //  secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                      //    num68,
                                                      //    empty6,
                                                      //    num11,
                                                      //    num10,
                                                      //    "",
                                                      //    MandatoryField,
                                                      //    item7.Rows[0]["MainCalculationType"].ToString()
                                                      //);

                                                        DataTable dataTable9 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                                        if (dataTable9.Rows.Count <= 0)
                                                        {
                                                            if (num11 != (long)0)
                                                            {
                                                                empty6 = "0";
                                                            }
                                                            ControlCollection controlCollections16 = this.plhPriceCalculator.Controls;
                                                            //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' /><div style='margin-bottom:5px;'></div>" };
                                                            //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "' onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();'style='width:100%' rows='3'></textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", IsMandatoryField, "'/><div style='margin-bottom:5px;'></div>" };
                                                            secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                                                   num68,
                                                                                   empty6,
                                                                                   num11,
                                                                                   num10,
                                                                                   "",
                                                                                   MandatoryField,
                                                                                   item7.Rows[0]["MainCalculationType"].ToString()
                                                                               );
                                                            controlCollections16.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else
                                                        {
                                                            empty6 = "1";
                                                            ControlCollection controls17 = this.plhPriceCalculator.Controls;
                                                            //secureSitePath = new object[] { "<input id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' value=", dataTable9.Rows[0]["SelectedValue"].ToString(), "  />" };
                                                            //secureSitePath = new object[] { "<textarea id='txtFreeTextQuestion_", num68, "' grpvalue='", empty6, "' onkeyup='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' style='width:100%' rows='3'>", dataTable9.Rows[0]["SelectedValue"].ToString(), "  </textarea><input type='hidden' id='hdn_FreeTextQuestion_", num68, "' value='", IsMandatoryField, "'/>" };
                                                            secureSitePath = BuildFreeTextBlockWithCharLimit(
                                                                                    num68,
                                                                                    empty6,
                                                                                    num11,
                                                                                    num10,
                                                                                    dataTable9.Rows[0]["SelectedValue"].ToString(),
                                                                                    MandatoryField,
                                                                                    item7.Rows[0]["MainCalculationType"].ToString()
                                                                                );
                                                            controls17.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        //controlCollections4.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div></div>"));
                                                        num68++;
                                                    }
                                                    else
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth' ></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                                        length2 = item7.Rows[0]["UserFriendlyName"].ToString().Trim().Length;
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                                        }
                                                        if (empty8 != "1")
                                                        {
                                                            ControlCollection controlCollections21 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' > ", base.SpecialDecode(item7.Rows[0]["UserFriendlyName"].ToString()), "</label>" };
                                                            controlCollections21.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else
                                                        {
                                                            ControlCollection controls22 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' > ", base.SpecialDecode(item7.Rows[0]["UserFriendlyName"].ToString()), "</label><span style='color:Red;'> *</span>" };
                                                            controls22.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        if (item7.Rows[0]["Description"] != null && item7.Rows[0]["Description"] != null)
                                                        {
                                                            this.HelpText = base.SpecialDecode(item7.Rows[0]["Description"].ToString().Trim()).Replace("'", "&#145");
                                                            if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                                            {
                                                                this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                                            }
                                                            else
                                                            {
                                                                this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                                            }
                                                            ControlCollection controlCollections22 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<img id='img_help_", num13, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                                            controlCollections22.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                                        if (length2 <= 80)
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        }
                                                        else
                                                        {
                                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                                        }
                                                        length2 = 0;
                                                        DropDownList dropDownList4 = new DropDownList();
                                                        secureSitePath = new object[] { "ddlMultiple_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n };
                                                        dropDownList4.ID = string.Concat(secureSitePath);
                                                        dropDownList4.CssClass = "dropDownMultiple150";
                                                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                        {
                                                            dropDownList4.Width = 300;
                                                        }
                                                        dropDownList4.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                                        dropDownList4.Attributes.Add("isgroup", "subgroup");
                                                        dropDownList4.Attributes.Add("WeotherCostID", dataTable11.Rows[n]["WebOtherCostID"].ToString());
                                                        dropDownList4.Attributes.Add("IsMandatory", empty8);
                                                        dropDownList4.Attributes.Add("grpvalue", empty6);
                                                        DataTable dataTable12 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                                        if (dataTable12.Rows.Count <= 0)
                                                        {
                                                            this.comm.MultipleChoice_DropDownBind(item8, dropDownList4, this.plhPriceCalculator, row5["CalculationType"].ToString());
                                                        }
                                                        else
                                                        {
                                                            this.comm.MultipleChoice_DropDownBind_Edit(item8, dropDownList4, this.plhPriceCalculator, row5["CalculationType"].ToString(), dataTable12.Rows[0]["SelectedValue"].ToString());
                                                        }
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B'>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_innerDiv2'>"));
                                                        if (this.IsEnableHidePrice == "false" || !this.IsDisplayAdditionalOptions)
                                                        {
                                                            ControlCollection controls23 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", dataTable11.Rows[n]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", num5, "</label>" };
                                                            controls23.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        else
                                                        {
                                                            ControlCollection controlCollections23 = this.plhPriceCalculator.Controls;
                                                            secureSitePath = new object[] { "<label id='lblMultipleID_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", dataTable11.Rows[n]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' style='display:none;'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num3, "_", item6.Rows[m]["SelectedID"].ToString(), "_", n, "' class='DisplayNone'>", num5, "</label>" };
                                                            controlCollections23.Add(new LiteralControl(string.Concat(secureSitePath)));
                                                        }
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    }

                                                }
                                            }
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    num3++;
                                }
                            }
                            else if (this.MainCalculationtype.ToLower() == "m" && num13 == 0)
                            {
                                //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                //row5["matrixType"].ToString();
                                //if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                //{
                                //    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B'>"));
                                //}
                                //else
                                //{
                                //    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                //}
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
                                ControlCollection controlCollections30 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<input id='chkMultiple_", num3, "' class='DisplayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num3, ");'/>" };
                                controlCollections30.Add(new LiteralControl(string.Concat(secureSitePath)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                length = this.OtherCostName.Length;
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
                                }
                                if (empty7 != "1")
                                {
                                    ControlCollection controls19 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                    controls19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    ControlCollection controlCollections19 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixName_", num3, "' > ", base.SpecialDecode(this.OtherCostName), "</label><span style='color:Red;'> *</span>" };
                                    controlCollections19.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    if (!base.Request.ServerVariables["HTTP_USER_AGENT"].Contains("MSIE"))
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip' title='", this.HelpText, "'>")));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' class='tooltip_IE' title='", this.HelpText, "'>")));
                                    }
                                    ControlCollection controls20 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num13, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                                    controls20.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div style='margin-bottom:2px;'></div>"));
                                if (length <= 80)
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
                                }

                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                DataTable dataTable13 = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID, num5);
                                if (dataTable13.Rows.Count <= 0)
                                {
                                    //ControlCollection controls24 = this.plhPriceCalculator.Controls;
                                    //secureSitePath = new object[] { "<div class='div_Chk_Matrix'><input id='chkMatrix_", num4, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty6, " onclick='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();'/></div>" };
                                    //controls24.Add(new LiteralControl(string.Concat(secureSitePath)));

                                    DropDownList dropDownList1 = new DropDownList();
                                    secureSitePath = new object[] { "chkMatrix_", num4 };
                                    dropDownList1.ID = string.Concat(secureSitePath);
                                    dropDownList1.CssClass = "dropDownMultiple150";
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        dropDownList1.Width = 300;
                                    }

                                    DataTable dt = new DataTable();
                                    dt.Clear();
                                    dt.Columns.Add("FormulaNew");
                                    dt.Columns.Add("Label");
                                    DataRow _row = dt.NewRow();
                                    _row["FormulaNew"] = "0";
                                    _row["Label"] = "---Select---";
                                    dt.Rows.Add(_row);

                                    _row = dt.NewRow();
                                    _row["FormulaNew"] = "1";
                                    _row["Label"] = "Yes";
                                    dt.Rows.Add(_row);

                                    _row = dt.NewRow();
                                    _row["FormulaNew"] = "2";
                                    _row["Label"] = "No";
                                    dt.Rows.Add(_row);



                                    //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                    //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                    AttributeCollection attributes = dropDownList1.Attributes;
                                    secureSitePath = new object[] { "javascript:ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();" };
                                    attributes.Add("onchange", string.Concat(secureSitePath));
                                    attributes.Add("grpvalue", empty6);
                                    //dropDownList1.Attributes.Add("isgroup", "subgroup");
                                    //dropDownList1.Attributes.Add("WeotherCostID", dataTable8.Rows[k]["WebOtherCostID"].ToString());
                                    dropDownList1.Attributes.Add("IsMandatory", empty7);
                                    this.comm.MultipleChoice_DropDownBind(dt, dropDownList1, this.plhPriceCalculator, "");


                                }
                                else if (dataTable13.Rows[0]["SelectedValue"].ToString() != "false")
                                {
                                    empty6 = "1";
                                    //ControlCollection controlCollections24 = this.plhPriceCalculator.Controls;
                                    //secureSitePath = new object[] { "<div class='div_Chk_Matrix'><input id='chkMatrix_", num4, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty6, " onchange='javascript:ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();' checked='true' /></div>" };
                                    //controlCollections24.Add(new LiteralControl(string.Concat(secureSitePath)));
                                    DropDownList dropDownList1 = new DropDownList();
                                    secureSitePath = new object[] { "chkMatrix_", num4 };
                                    dropDownList1.ID = string.Concat(secureSitePath);
                                    dropDownList1.CssClass = "dropDownMultiple150";
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        dropDownList1.Width = 300;
                                    }

                                    DataTable dt = new DataTable();
                                    dt.Clear();
                                    dt.Columns.Add("FormulaNew");
                                    dt.Columns.Add("Label");
                                    DataRow _row = dt.NewRow();
                                    _row["FormulaNew"] = "0";
                                    _row["Label"] = "---Select---";
                                    dt.Rows.Add(_row);

                                    _row = dt.NewRow();
                                    _row["FormulaNew"] = "1";
                                    _row["Label"] = "Yes";
                                    dt.Rows.Add(_row);

                                    _row = dt.NewRow();
                                    _row["FormulaNew"] = "2";
                                    _row["Label"] = "No";
                                    dt.Rows.Add(_row);



                                    //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                    //dropDownList1.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                                    AttributeCollection attributes = dropDownList1.Attributes;
                                    secureSitePath = new object[] { "javascript:ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();" };
                                    attributes.Add("onchange", string.Concat(secureSitePath));
                                    attributes.Add("grpvalue", empty6);
                                    //dropDownList1.Attributes.Add("isgroup", "subgroup");
                                    //dropDownList1.Attributes.Add("WeotherCostID", dataTable8.Rows[k]["WebOtherCostID"].ToString());
                                    //dropDownList1.Attributes.Add("IsMandatory", empty5);
                                    this.comm.MultipleChoice_DropDownBind(dt, dropDownList1, this.plhPriceCalculator, "");
                                    dropDownList1.Items.FindByValue("1").Selected = true;

                                }
                                else
                                {
                                    if (num11 != (long)0)
                                    {
                                        empty6 = "0";
                                    }
                                    ControlCollection controls25 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<div class='div_Chk_Matrix'><input id='chkMatrix_", num4, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty6, " onclick='ForAdditional_Grouping(", num11, ",", num10, ");Tocall_mainFunc();'/></div>" };
                                    controls25.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                //if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                //{
                                //    ControlCollection controlCollections25 = this.plhPriceCalculator.Controls;
                                //    secureSitePath = new object[] { "<div class='floatLeft clearTop clearBottom'><label id='lblMatrixName_", num4, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                //    controlCollections25.Add(new LiteralControl(string.Concat(secureSitePath)));
                                //}
                                //else
                                //{
                                //    ControlCollection controls26 = this.plhPriceCalculator.Controls;
                                //    secureSitePath = new object[] { "<div class='divchkMatrix_lbl'><label id='lblMatrixName_", num4, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                //    controls26.Add(new LiteralControl(string.Concat(secureSitePath)));
                                //}
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0)' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections26 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<img id='img_help_", num13, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px'  /></a>" };
                                    controlCollections26.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div></div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() == "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatRight'><div class='price_table_content_right_innerDiv3'>"));
                                ControlCollection controls27 = this.plhPriceCalculator.Controls;
                                secureSitePath = new object[] { "<label id='lblMatrixID_", num4, "' class='DisplayNone'>", row3["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num4, "' class='DisplayNone'>", row5["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num4, "' class='DisplayNone'></label><label id='lblMatrixGroupID_", num4, "' class='DisplayNone'>", row3["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixSortOrderNo_", num4, "' class='DisplayNone'>", num5, "</label>" };
                                controls27.Add(new LiteralControl(string.Concat(secureSitePath)));
                                if (this.IsEnableHidePrice != "false")
                                {
                                    ControlCollection controlCollections27 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controlCollections27.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else if (!this.IsDisplayAdditionalOptions)
                                {
                                    ControlCollection controls28 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controls28.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                else
                                {
                                    ControlCollection controls28 = this.plhPriceCalculator.Controls;
                                    secureSitePath = new object[] { "<label id='lblMatrixPrice_", num4, "'class='Visibilityhidden' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                    controls28.Add(new LiteralControl(string.Concat(secureSitePath)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right DisplayNone'>"));
                                if (row5["matrixType"].ToString().ToLower() != "pricebands")
                                {
                                    DropDownList dropDownList5 = new DropDownList();
                                    this.comm.MultipleChoice_DropDownBind(item6, dropDownList5, this.plhPriceCalculator, "matrix");
                                    dropDownList5.ID = string.Concat("ddlMatrix_", num4);
                                    dropDownList5.CssClass = "dropDownMultiple150";
                                    dropDownList5.Width = 300;
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                num4++;
                            }
                            num13++;
                        }
                    }
                }
                //DataTable dataTable1 = new DataTable();
                if (dataTable4.Rows.Count > 0)
                {


                    DataRow row = dataTable4.Rows[0];
                    name1 = row["Decoration1_Name"].ToString();
                    name2 = row["Decoration2_Name"].ToString();
                    name3 = row["Decoration3_Name"].ToString();
                    name4 = row["Decoration4_Name"].ToString();
                    name5 = row["Decoration5_Name"].ToString();
                    name6 = row["Decoration6_Name"].ToString();

                    Decoration1_Mandadory = Convert.ToBoolean(row["Decoration1_Mandadory"]);
                    Decoration2_Mandadory = Convert.ToBoolean(row["Decoration2_Mandadory"]);
                    Decoration3_Mandadory = Convert.ToBoolean(row["Decoration3_Mandadory"]);
                    Decoration4_Mandadory = Convert.ToBoolean(row["Decoration4_Mandadory"]);
                    Decoration5_Mandadory = Convert.ToBoolean(row["Decoration5_Mandadory"]);
                    Decoration6_Mandadory = Convert.ToBoolean(row["Decoration6_Mandadory"]);

                    string decoration1Value = "";
                    string decoration2Value = "";
                    string decoration3Value = "";
                    string decoration4Value = "";
                    string decoration5Value = "";
                    string decoration6Value = "";
                    if ((long)this.CartItemID > 0)
                    {


                        DataTable dtDecoration = ProductBasePage.AdditionalOptions_Value((long)this.CartItemID);




                        foreach (DataRow dtitem in dtDecoration.Rows)
                        {
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 101)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration1Value = strSelectedValue[1];


                            }
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 102)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration2Value = strSelectedValue[1];


                            }
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 103)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration3Value = strSelectedValue[1];


                            }
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 104)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration4Value = strSelectedValue[1];


                            }
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 105)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration5Value = strSelectedValue[1];


                            }
                            if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 106)
                            {
                                string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                                decoration6Value = strSelectedValue[1];


                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(name1) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration1.Value = Convert.ToDouble(row["Decoration1_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration1_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration1_MinimiumCost"]);
                        AddDecoration(1, name1, Decoration1_Mandadory, decoration1Value);
                    }

                    if (!string.IsNullOrEmpty(name2) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration2.Value = Convert.ToDouble(row["Decoration2_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration2_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration2_MinimiumCost"]);
                        AddDecoration(2, name2, Decoration2_Mandadory, decoration2Value);
                    }

                    if (!string.IsNullOrEmpty(name3) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration3.Value = Convert.ToDouble(row["Decoration3_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration3_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration3_MinimiumCost"]);
                        AddDecoration(3, name3, Decoration3_Mandadory, decoration3Value);
                    }

                    if (!string.IsNullOrEmpty(name4) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration4.Value = Convert.ToDouble(row["Decoration4_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration4_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration4_MinimiumCost"]);
                        AddDecoration(4, name4, Decoration4_Mandadory, decoration4Value);
                    }

                    if (!string.IsNullOrEmpty(name5) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration5.Value = Convert.ToDouble(row["Decoration5_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration5_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration5_MinimiumCost"]);
                        AddDecoration(5, name5, Decoration5_Mandadory, decoration5Value);
                    }

                    if (!string.IsNullOrEmpty(name6) == true)

                    {
                        IsDecoration = true;
                        hdnDecoration6.Value = Convert.ToDouble(row["Decoration6_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration6_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration6_MinimiumCost"]);
                        AddDecoration(6, name6, Decoration6_Mandadory, decoration6Value);
                    }

                }

                this.hid_QuestionLenght.Value = num2.ToString();
                this.hid_MultipleLenght.Value = num3.ToString();
                this.hid_MatrixLenght.Value = num4.ToString();
                this.hid_QuestionTextFreeLenght.Value = num68.ToString();
                if (this.Session["IsEditableProduct"] != null)
                {
                    if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        this.btnAddtoCart1.Style.Add("display", "none");
                        this.btnAddtoCart.Style.Add("display", "none");
                        this.btnAddtoCartStay.Style.Add("display", "none");
                        this.btnAddtoCartStay1.Style.Add("display", "none");
                        this.EditProduct1.Style.Add("display", "block");
                        this.EditProduct2.Style.Add("display", "block");
                        long num14 = (long)0;
                        DataSet dataSet6 = ProductBasePage.Select_TemplateID((long)this.PriceCatalogueID);
                        if (dataSet6.Tables[0].Rows.Count > 0)
                        {
                            num14 = Convert.ToInt64(dataSet6.Tables[0].Rows[0]["TemplateID"].ToString());
                        }
                        DataTable selectTemplateIDExist = ProductBasePage.Get_Select_TemplateID_Exist(Convert.ToInt32(num14));
                        if (selectTemplateIDExist.Rows.Count > 0)
                        {
                            foreach (DataRow dataRow5 in selectTemplateIDExist.Rows)
                            {
                                this.DivUpload_DownloadCsvFile.Style.Add("display", "block");
                            }
                        }
                        if (!ConnectionClass.IsImageUploadEnable)
                        {
                            this.DivUpload_ImageZipFile.Style.Add("display", "none");
                        }
                        this.CSV_UploadDownload_Enabled = ProductBasePage.CSV_UploadDownload_Enabled(num14);
                        if (this.CSV_UploadDownload_Enabled == "false")
                        {
                            this.DivUpload_DownloadCsvFile.Style.Add("display", "none");
                            this.DivUpload_ImageZipFile.Style.Add("display", "none");
                        }
                    }
                    else if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        this.btnAddtoCart1.Style.Add("display", "block");
                        this.btnAddtoCart.Style.Add("display", "block");
                        this.btnAddtoCartStay.Style.Add("display", "block");
                        if (this.isHideAddtoCartStayButton2)
                        {
                            this.btnAddtoCartStay1.Style.Add("display", "none");
                        }
                        else
                        {
                            this.btnAddtoCartStay1.Style.Add("display", "block");
                        }

                        this.EditProduct1.Style.Add("display", "none");
                        this.EditProduct2.Style.Add("display", "none");
                        this.DivUpload_DownloadCsvFile.Style.Add("display", "none");
                        this.DivUpload_ImageZipFile.Style.Add("display", "none");
                    }
                }
                if (num2 != 0 || num3 != 0 || num4 != 0 || IsDecoration || num68 != 0)
                {
                    this.Price_Area(this.CompanyID, this.plhPriceCalculator, "yes");
                    this.Price_CalculatorWithAddition1.Style.Add("display", "block");
                    this.Price_CalculatorWithAddition2.Style.Add("display", "block");
                }
                else
                {
                    this.Price_Area(this.CompanyID, this.plhquantity, "no");
                    this.Price_CalculatorWithAddition1.Style.Add("display", "none");
                    this.Price_CalculatorWithAddition2.Style.Add("display", "none");
                    this.plhAddtoCartClear.Controls.Add(new LiteralControl("<div class='clearBoth clear'></div>"));
                }
                this.getPageMetaDetails(this.CompanyID, Convert.ToInt32(productdetails.AccountID), 0);
                this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Add_To_Cart");
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (RewriteContext.Current.Params["CartItemID"] != null)
                    {
                        this.btnAddtoCart1.Style.Add("display", "none");
                        this.btnAddtoCart.Style.Add("display", "none");
                        this.btnAddtoCartStay.Style.Add("display", "none");
                        this.btnAddtoCartStay1.Style.Add("display", "none");
                        if (this.IsAdditionalOption == "yes")
                        {
                            this.EditProduct1.Style.Add("display", "none");
                            this.EditProduct2.Style.Add("display", "block");
                            this.EditProduct2.Text = this.objLanguage.GetLanguageConversion("Update_Cart");
                        }
                        else if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                        {
                            this.EditProduct1.Style.Add("display", "block");
                            this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Update_Cart");
                            this.EditProduct2.Style.Add("display", "none");
                        }
                        else
                        {
                            this.EditProduct1.Style.Add("display", "block");
                            this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Edit_Product");
                            this.EditProduct2.Style.Add("display", "none");
                        }
                    }
                }
                else if (base.Request.Params["OrdKey"] != null && base.Request.Params["CartItemID"] != null)
                {
                    this.btnAddtoCart1.Style.Add("display", "none");
                    this.btnAddtoCart.Style.Add("display", "none");
                    this.btnAddtoCartStay.Style.Add("display", "none");
                    this.btnAddtoCartStay1.Style.Add("display", "none");
                    if (this.IsAdditionalOption == "yes")
                    {
                        this.EditProduct1.Style.Add("display", "none");
                        this.EditProduct2.Style.Add("display", "block");
                        this.EditProduct2.Text = this.objLanguage.GetLanguageConversion("Update_Order");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Order");
                    }
                    else if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        this.EditProduct1.Style.Add("display", "block");
                        this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Update_Order");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Order");
                        this.EditProduct2.Style.Add("display", "none");
                    }
                    else
                    {
                        this.EditProduct1.Style.Add("display", "block");
                        this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Edit_Product");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Order");
                        this.EditProduct2.Style.Add("display", "none");
                    }
                    DataTable dataTable14 = ProductBasePage.Select_SpendLimitAmount(this.StoreUserID, productdetails.AccountID, base.Request.Params["OrdKey"], this.CompanyID);
                    foreach (DataRow row6 in dataTable14.Rows)
                    {
                        this.IsSpendLimitEnable = Convert.ToString(row6["IsSpendlimitEnabled"]).ToLower();
                        this.SpendLimitAmount = Convert.ToInt64(row6["SpendLimitAmount"]);
                        this.SpendAmount = Convert.ToInt64(row6["EstimateAmountSpent"]);
                    }
                }
                else if (base.Request.Params["CartItemID"] != null)
                {
                    this.btnAddtoCart1.Style.Add("display", "none");
                    this.btnAddtoCart.Style.Add("display", "none");
                    this.btnAddtoCartStay.Style.Add("display", "none");
                    this.btnAddtoCartStay1.Style.Add("display", "none");
                    if (this.IsAdditionalOption == "yes")
                    {
                        this.EditProduct1.Style.Add("display", "none");
                        this.EditProduct2.Style.Add("display", "block");
                        this.EditProduct2.Text = this.objLanguage.GetLanguageConversion("Update_Cart");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Cart");
                    }
                    else if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                    {
                        this.EditProduct1.Style.Add("display", "block");
                        this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Update_Cart");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Cart");
                        this.EditProduct2.Style.Add("display", "none");
                    }
                    else
                    {
                        this.EditProduct1.Style.Add("display", "block");
                        this.EditProduct1.Text = this.objLanguage.GetLanguageConversion("Edit_Product");
                        this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Update_Cart");
                        this.EditProduct2.Style.Add("display", "none");
                    }
                }
                this.ddl_SelectBehalf.Attributes.Add("onchange", "javascript:ShowBehalfOfDiv();");
                this.ddl_BehalfDepts.Attributes.Add("onchange", "javascript:LoadSelectedDeptUsers();");
                this.hdnPdfPath.Value = this.PrintReadyFilePath_Verify;
                this.btn_ConfirmAdd1.Attributes.Add("onclick", "javascript:return ValidatePrintReadyFile(this.id,'divConfirmandAdd');");
                this.btn_ConfirmEditTemplate1.Attributes.Add("onclick", "javascript:return ValidatePrintReadyFile(this.id,'divConfirmandEditTemplate');");
                if (this.hdnStockManagement.Value != "true")
                {
                    this.hdnIsShowStock.Value = "false";
                    this.hdnStockManagement.Value = "false";
                    this.divStockStatus.Attributes.Add("style", "display:none");
                    this.pnlStockMessage.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.hdnStockManagement.Value = "true";
                    if (!flag)
                    {
                        this.divStockStatus.Attributes.Add("style", "display:none");
                        this.pnlStockMessage.Attributes.Add("style", "display:none");
                    }
                    else if (this.hdnIsBackOrder.Value.Trim().ToLower() == "false")
                    {
                        if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "s")
                        {
                            if (this.AvailableQuantity <= 0)
                            {
                                this.divStockStatus.Attributes.Add("style", "display:none");
                                this.pnlStockMessage.Attributes.Add("style", "display:block");
                                this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                            }
                            else
                            {
                                this.divStockStatus.Attributes.Add("style", "display:block");
                                this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                this.lbl_stockStatus1.Text = string.Concat(this.AvailableQuantity);
                            }
                        }
                        else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "o")
                        {
                            if (this.hid_matixType.Value == "P")
                            {
                                int num15 = base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), 0);
                                if (num15 <= 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                }
                                else
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:block");
                                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                    this.lbl_stockStatus1.Text = string.Concat(num15);
                                }
                            }
                            else if (this.hid_matixType.Value != "G")
                            {
                                int num16 = 0;
                                num16 = (!this.IsCumulative ? base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text)) : base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), this.SimpleMatrixCumulativePriceingQty(Convert.ToInt32(this.txt_Cumulative_PriceQty.Text), Convert.ToInt32(this.PriceCatalogueID))));
                                if (num16 <= 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                }
                                else
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:block");
                                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                    this.lbl_stockStatus1.Text = string.Concat(num16);
                                }
                            }
                            else
                            {
                                int num17 = base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), 0);
                                if (num17 <= 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                }
                                else
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:block");
                                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                    this.lbl_stockStatus1.Text = string.Concat(num17);
                                }
                            }
                        }
                        else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "m")
                        {
                            if (this.hid_matixType.Value != "S")
                            {
                                this.divStockStatus.Attributes.Add("style", "display:none");
                                this.pnlStockMessage.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                DataTable dataTable15 = new DataTable();
                                dataTable15 = (!this.IsCumulative ? OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text), Convert.ToBoolean(this.hdnIsBackOrder.Value)) : OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), this.SimpleMatrixCumulativePriceingQty(Convert.ToInt32(this.txt_Cumulative_PriceQty.Text), Convert.ToInt32(this.hdnPriceCatalogueID.Value)), Convert.ToBoolean(this.hdnIsBackOrder.Value)));
                                foreach (DataRow dataRow6 in dataTable15.Rows)
                                {
                                    if (Convert.ToInt32(dataRow6["AvailableQuantity"].ToString()) < 0)
                                    {
                                        this.divStockStatus.Attributes.Add("style", "display:none");
                                        this.pnlStockMessage.Attributes.Add("style", "display:block");
                                        this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                    }
                                    else
                                    {
                                        this.divStockStatus.Attributes.Add("style", "display:block");
                                        this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                        this.lbl_stockStatus1.Text = dataRow6["AvailableQuantity"].ToString() ?? "";
                                    }
                                }
                            }
                        }
                        else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "a")
                        {
                            this.pnlStockMessage.Attributes.Add("style", "display:none");
                            this.divStockStatus.Attributes.Add("style", "display:none");
                        }
                    }
                    else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "s")
                    {
                        this.divStockStatus.Attributes.Add("style", "display:block");
                        this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                        this.lbl_stockStatus1.Text = string.Concat(this.AvailableQuantity);
                        if (this.AvailableQuantity <= 0)
                        {
                            this.pnlStockMessage.Attributes.Add("style", "display:block");
                            this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order"));
                        }
                    }
                    else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "o")
                    {
                        int num18 = base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), 0);
                        if (num18 <= 0)
                        {
                            this.divStockStatus.Attributes.Add("style", "display:none");
                            this.pnlStockMessage.Attributes.Add("style", "display:block");
                            this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order"));
                        }
                        else
                        {
                            this.divStockStatus.Attributes.Add("style", "display:block");
                            this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                            this.lbl_stockStatus1.Text = string.Concat(num18);
                        }
                    }
                    else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "m")
                    {
                        if (this.hid_matixType.Value != "S")
                        {
                            this.divStockStatus.Attributes.Add("style", "display:none");
                            this.pnlStockMessage.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            DataTable dataTable16 = new DataTable();
                            dataTable16 = (!this.IsCumulative ? OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text), Convert.ToBoolean(this.hdnIsBackOrder.Value)) : OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), this.SimpleMatrixCumulativePriceingQty(Convert.ToInt32(this.txt_Cumulative_PriceQty.Text), Convert.ToInt32(this.hdnPriceCatalogueID.Value)), Convert.ToBoolean(this.hdnIsBackOrder.Value)));
                            foreach (DataRow row7 in dataTable16.Rows)
                            {
                                if (Convert.ToInt32(row7["AvailableQuantity"].ToString()) == 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order"));
                                }
                                else
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:block");
                                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                    this.lbl_stockStatus1.Text = row7["AvailableQuantity"].ToString() ?? "";
                                }
                            }
                        }
                    }
                    else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "a")
                    {
                        this.divStockStatus.Attributes.Add("style", "display:none");
                        this.pnlStockMessage.Attributes.Add("style", "display:none");
                    }
                }
                if (this.AvailableQuantity <= 0)
                {
                    this.lbl_stockStatus1.Text = "0";
                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                }
            }

        }
        private object[] BuildFreeTextBlockWithCharLimit(int questionId,string groupValue,long groupNum1,long groupNum2,string selectedValue,bool isMandatoryField,string calculationType)
        {
            int charLimit = calculationType.ToLower() == "f" ? 100 : 1000;
            return new object[]
            {
                "<textarea id='txtFreeTextQuestion_", questionId,
                "' grpvalue='", groupValue,
                "' maxlength='", charLimit,
                "' onkeyup='ForAdditional_Grouping(", groupNum1, ",", groupNum2, ");Tocall_mainFunc();updateCharCount(this,", charLimit, ");'",
                "' onblur='ForAdditional_Grouping(", groupNum1, ",", groupNum2, ");Tocall_mainFunc();'",
                "' oninput='updateCharCount(this,", charLimit, ");'",
                "' style='width:100%' rows='3'>", selectedValue, "</textarea>",

                "<div style='color:#F68D1A;'><span id='charCount_", questionId, "'>0</span>/", charLimit, " characters</div>",

                "<input type='hidden' id='hdn_FreeTextQuestion_", questionId,
                "' value='", isMandatoryField,
                "'/><input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", questionId,
                "' value='", calculationType.ToLower(), "'/>"
            };
        }
        protected void enableAddtoCartStayButton(bool enable)
        {
            if (this.isEnableAddtoCartStayButton)
            {
                //btnAddtoCartStay.Enabled = true;
                //btnAddtoCartStay1.Enabled = true;
                btnAddtoCartStay.Visible = true;
                btnAddtoCartStay1.Visible = true;
                div_btnsave1.Style.Add("float", "left !important");
                div_btnsave.Style.Add("float", "left !important");
                //this.btnAddtoCartStay.Style.Add("display", "block");
                //this.btnAddtoCartStay1.Style.Add("display", "block");
                //this.btnAddtoCart1Stay.Style.Add("enabled", "true");
            }
            else
            {
                //btnAddtoCartStay.Enabled = false;
                //btnAddtoCartStay1.Enabled = false;

                btnAddtoCartStay.Visible = false;
                btnAddtoCartStay1.Visible = false;
                div_btnsave1.Style.Add("float", "right");
                div_btnsave.Style.Add("float", "right");
                //this.btnAddtoCartStay.Style.Add("display", "none");
                //this.btnAddtoCartStay1.Style.Add("display", "none");
                //this.btnAddtoCartStay.Style.Add("enabled", "false");
                //this.btnAddtoCart1Stay.Style.Add("enabled", "false");
            }
        }

        private string CreateWaterMarkPDF(string PrintReadyPDF, string PrintReadyPDFWaterMark, Int64 PriceCatalogueId, string WatermarkText)
        {
            var secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady" };
            var PrintReadyPDFPath = Path.Combine(string.Concat(secureDocPath), PrintReadyPDF);
            if (PrintReadyPDFWaterMark == "")
            {
                PrintReadyPDFWaterMark = Guid.NewGuid().ToString() + ".pdf";

            }
            var PrintReadyPDFWaterMarkPath = Path.Combine(string.Concat(secureDocPath), PrintReadyPDFWaterMark);
            if (File.Exists(PrintReadyPDFWaterMarkPath))
            {
                File.Delete(PrintReadyPDFWaterMarkPath);
            }
            if (!File.Exists(PrintReadyPDFWaterMarkPath))
            {
                //File.Copy(PrintReadyPDFPath, PrintReadyPDFWaterMarkPath);
                FileInfo fileInfo = new FileInfo(PrintReadyPDFPath);

                //CreateWaterMark(fileInfo, "Sample");
                File.WriteAllBytes(PrintReadyPDFWaterMarkPath, this.CreateWaterMark(fileInfo, WatermarkText));

                CartBasePage.Product_CataloguePdfNameWaterMark_Update(PriceCatalogueId, PrintReadyPDFWaterMark);
            }

            return PrintReadyPDFWaterMark;
        }

        public byte[] CreateWaterMark(FileInfo sourceFile, string stringToWriteToPdf)
        {
            byte[] array;
            PdfReader pdfReader = new PdfReader(sourceFile.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
                for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                {
                    iTextSharp.text.Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(i);
                    //Ticket #8529 SMP-watermark on editable product previews with images not show
                    //PdfContentByte overContent = pdfStamper.GetUnderContent(i);

                    PdfContentByte overContent = pdfStamper.GetOverContent(i);
                    overContent.BeginText();
                    PdfGState gstate = new PdfGState();
                    gstate.FillOpacity = 0.3f;
                    gstate.StrokeOpacity = 0.3f;
                    overContent.SetGState(gstate);
                    //BaseFont baseFont = BaseFont.CreateFont("Helvetica", "Cp1252", false);
                    //overContent.SetFontAndSize(baseFont, (float)Convert.ToInt16(35));
                    overContent.SetRGBColorFill(242, 242, 242);
                    float hypotenuseAngleInDegreesFrom = (float)this.GetHypotenuseAngleInDegreesFrom((double)pageSizeWithRotation.Height, (double)pageSizeWithRotation.Width);
                    //overContent.ShowTextAligned(1, stringToWriteToPdf, pageSizeWithRotation.Width / 2f, pageSizeWithRotation.Height / 2f - 16f, hypotenuseAngleInDegreesFrom);
                    //water mark
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                    BaseColor bc = new BaseColor(0, 0, 0, 65);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 50f, iTextSharp.text.Font.NORMAL, bc);

                    // Dim wfont = New Font(BaseFont.TIMES_ROMAN, 1.0F, BaseFont.COURIER, BaseColor.LIGHT_GRAY)
                    ColumnText.ShowTextAligned(overContent, Element.ALIGN_CENTER, new Phrase(stringToWriteToPdf, times), pageSizeWithRotation.Width / 2f, pageSizeWithRotation.Height / 2f - 16f, hypotenuseAngleInDegreesFrom);

                    //End water mark

                    overContent.EndText();
                }
                pdfStamper.Close();
                pdfReader.Close();
                array = memoryStream.ToArray();
            }
            return array;
        }
        public double GetHypotenuseAngleInDegreesFrom(double opposite, double adjacent)
        {
            return Math.Atan2(opposite, adjacent) * 57.2957795130823;
        }
        public string[] preflight_File(string FileName, long ProductID)
        {
            string[] strArrays = FileName.ToString().Trim().Split(new char[] { '.' });
            string str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            string empty = string.Empty;
            string reportFile = string.Empty;
            List<string[]> strArrays1 = new List<string[]>();
            string[] strArrays2 = new string[2];
            if (str.ToLower() != "pdf")
            {
                empty = FileName;
                reportFile = "";
            }
            else
            {
                Preflight_documents preflightDocument = new Preflight_documents();
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", productdetails.AccountID, "//artwork//" };
                string str1 = string.Concat(secureDocPath);
                object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/" };
                string str2 = string.Concat(objArray);
                PreflightParameters preflightParameter = preflightDocument.Preflight_file(FileName, ProductID, "PDF_X-4 Verify", productdetails.AccountID.ToString(), this.CompanyID.ToString(), str1, str2);
                if (!preflightParameter.IsPreflighted)
                {
                    empty = FileName;
                    reportFile = "";
                }
                else
                {
                    empty = preflightParameter.CorrectedFile;
                    reportFile = preflightParameter.ReportFile;
                }
            }
            strArrays2[0] = empty;
            strArrays2[1] = reportFile;
            return strArrays2;
        }

        public void Price_Area(int CompanyID, PlaceHolder plh, string AdditionItem)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
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
            string str7 = "style='display:block'";
            StringBuilder stringBuilder = new StringBuilder();
            if (AdditionItem == "yes")
            {
                str3 = "style='display: none;margin-left: 0px;'";
                this.btnAddtoCart1.Style.Add("display", "none");
                this.EditProduct1.Style.Add("display", "none");
                this.artwork_div_no_addoption.Style.Add("display", "none");
                str7 = (this.isSubTotal != "1" ? "style='display:none'" : "style='display:block;'");
                if (this.hid_matixType.Value.ToLower() == "p")
                {
                    str = "style='width:190px;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g")
                {
                    str = "style='width:190px;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                str6 = "style='padding-left:0px; float:left; height:19px;'";
                empty7 = "style='padding-left:0px;'";
            }
            else if (AdditionItem == "no")
            {
                empty4 = "style='margin-right: 20px;'";
                empty1 = "style='width:85px;font-weight:bold;display:none'";
                str7 = (this.isSubTotal != "1" ? "style='display:none'" : "style='display:block;'");
                if (this.hid_matixType.Value.ToLower() == "p" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = "style='width:50%;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = "style='width:50%;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                if (this.hid_matixType.Value.ToLower() == "s" && this.artworkFile.ToLower().Trim() == "n")
                {
                    empty4 = "style='margin-right: 22px;'";
                    str = " style='margin-left: 0px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "s" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = "style='width:50%;font-weight:bold;'";
                    empty4 = "style='margin-right: 22px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "p" && this.artworkFile.ToLower().Trim() == "n")
                {
                    str = "style='width:50%;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g" && this.artworkFile.ToLower().Trim() == "n")
                {
                    str = "style='width:50%;margin:0px 0px 0px 0px;font-weight:bold;'";
                }
                if (this.hid_matixType.Value.ToLower() == "p")
                {
                    str3 = "style ='display:block;margin-left: 0px;'";
                    empty4 = "style='display: block; margin-left: 0px; float: left; width: 400px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g")
                {
                    str3 = "style ='display:block;margin-left: 0px;'";
                    empty4 = "style='display: block; margin-left: 0px; float: left; width: 400px;'";
                }
                str6 = "style='padding-left:0px; float:left; height:19px; width:50%;'";
                empty7 = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='padding-left:0px; width:50%;'" : "style='padding-left:0px;'");
            }
            //if (!base.IsPostBack)
            //{
            string DisplayJobName = string.Empty;
            string jobName = string.Empty;
            bool settingJobName = false;
            string jobScreenName = string.Empty;
            DataTable _datatable = CartBasePage.OrderMangerOptions_Select(Convert.ToInt32(this.CompanyID), Convert.ToInt32(AccountID));
            foreach (DataRow row in _datatable.Rows)
            {
                if (Convert.ToBoolean(row["CartJobNameShow"]))
                {
                    settingJobName = true;
                }
                else
                {
                    settingJobName = false;
                }
                if (!Convert.ToBoolean(row["CartJobNameIsMandatory"]))
                {
                    this.hdnCartJobNameIsMandatory.Value = "0";
                }
                else
                {
                    this.hdnCartJobNameIsMandatory.Value = "1";
                }
                jobScreenName = row["CartJobScreenName"].ToString();
            }

            if (settingJobName)
            {
                if (this.hdnShowJobName.Value.ToLower() == "true")
                {
                    DisplayJobName = "display:block";
                }
                else
                {
                    DisplayJobName = "display:none";
                }
            }
            else
            {
                DisplayJobName = "display:none";
            }

            int CartItemID = Convert.ToInt32(base.Request.Params["CartItemID"]);
            int ProductID = Convert.ToInt32(base.Request.Params["ID"]);
            if (CartItemID > 0)
            {
                DataTable _dt = CartBasePage.Select_B2B_CartItem(CartItemID, ProductID);
                foreach (DataRow row in _dt.Rows)
                {
                    jobName = row["JobName"].ToString();
                }
            }
            ControlCollection controlsJobName = plh.Controls;
            string[] strArraysJobName = new string[] { "<div class='price_table_content_left_B2B'>" };
            controlsJobName.Add(new LiteralControl(string.Concat(strArraysJobName)));
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='paddingJobName' style='" + DisplayJobName + "'><label id='lbl_job_name'>", jobScreenName, " </label></div>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_left_B2B'>")));
            if (CartItemID == 0)
            {
                plh.Controls.Add(new LiteralControl("<div class='paddingJobName' style='" + DisplayJobName + "'><input id='txtJobName' style='width:292px;' maxlength='100' type='text' class='txtStyle' /></div>"));
            }
            else
            {
                plh.Controls.Add(new LiteralControl("<div class='paddingJobName' style='" + DisplayJobName + "'><input id='txtJobName' style='width:292px;' type='text' maxlength='100' class='txtStyle' value='" + jobName + "' /></div>"));
            }
            plh.Controls.Add(new LiteralControl("<div style='margin-bottom:3px;'></div></div>"));
            //}
            if (this.CopiedPriceCatalogueId != 0)
            {
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content'", str7, ">")));
                str7 = (!(this.hdnShowPriceSubtotalTax.Value.ToLower() == "true") || !(AdditionItem == "yes") ? "style='display:none;'" : "style='display:block; padding-bottom: 3px;'");
                DataTable qtyDataTable = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                double qty = double.Parse(qtyDataTable.Rows[0]["ToQuantity"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                double subTotal = double.Parse(qtyDataTable.Rows[0]["SellingPrice"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                double soldInPacksof = double.Parse(qtyDataTable.Rows[0]["SoldInPacksof"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                string DisplayUnitPrice = string.Empty;
                string DisplayPackPrice = string.Empty;
                if (this.hdnShowUnitPrice.Value.ToLower() == "true")
                {
                    DisplayUnitPrice = "display:block";
                }
                else
                {
                    DisplayUnitPrice = "display:none";
                }
                if (this.hdnShowPackPrice.Value.ToLower() == "true")
                {
                    DisplayPackPrice = "display:block";
                }
                else
                {
                    DisplayPackPrice = "display:none";
                }

                ControlCollection controlsUnitPackPrice = plh.Controls;
                string[] _strArrays = new string[] { "<div class='price_table_content_left_B2B'>" };
                controlsUnitPackPrice.Add(new LiteralControl(string.Concat(_strArrays)));
                plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lbl_unit_price'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " </label></div>")));
                plh.Controls.Add(new LiteralControl(string.Concat("<div style='" + DisplayPackPrice + "'><label id='lbl_pack_price'>", this.objLanguage.GetLanguageConversion("Pack_Price"), " </label></div>")));
                plh.Controls.Add(new LiteralControl("</div>"));

                plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_right_B2B'>")));
                plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lblunitprice'>", this.comm.GetCurrencyinRequiredFormate(("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / qty), 2, "", false, false, true) + ""), true), " </label></div>")));
                plh.Controls.Add(new LiteralControl(string.Concat("<div style='" + DisplayPackPrice + "'><label id='lblpackprice'>", this.comm.GetCurrencyinRequiredFormate("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / (qty / soldInPacksof)), 2, "", false, false, true) + "", true), " </label></div>")));
                plh.Controls.Add(new LiteralControl("</div>"));

                if (this.IsEnableHidePrice != "false")
                {
                    ControlCollection controls = plh.Controls;
                    string[] strArrays = new string[] { "<div class='price_table_content_left_B2B' ", str7, " ", str6, ">" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lbl_unit_price'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " </label></div>")));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayPackPrice + "'><label id='lbl_pack_price'>", this.objLanguage.GetLanguageConversion("Pack_Price"), " </label></div>")));
                    plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop DisplayNone'><label id='lblSub_total'>", this.objLanguage.GetLanguageConversion("Sub_Total"), " </label></div>")));

                    plh.Controls.Add(new LiteralControl("</div>"));



                    plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_right_B2B' ", str7, ">")));
                    ControlCollection controlCollections = plh.Controls;
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lblunitprice'>", this.comm.GetCurrencyinRequiredFormate(("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / qty), 2, "", false, false, true) + ""), true), " </label></div>")));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayPackPrice + "'><label id='lblpackprice'>", this.comm.GetCurrencyinRequiredFormate("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / (qty / soldInPacksof)), 2, "", false, false, true) + "", true), " </label></div>")));
                    string[] currencyinRequiredFormate = new string[] { "<div class='clearTop DisplayNone'><label id='lbltotal' ", empty4, ">", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><input type='hidden' id='hdnlbltotal' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));

                    plh.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    ControlCollection controls1 = plh.Controls;
                    string[] strArrays1 = new string[] { "<div class='price_table_content_left_B2B' ", str7, " ", str6, ">" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lbl_unit_price'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " </label></div>")));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayPackPrice + "'><label id='lbl_pack_price'>", this.objLanguage.GetLanguageConversion("Pack_Price"), " </label></div>")));
                    plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop'><label id='lblSub_total'>", this.objLanguage.GetLanguageConversion("Sub_Total"), " </label></div>")));

                    plh.Controls.Add(new LiteralControl("</div>"));
                    plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_right_B2B' ", str7, ">")));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayUnitPrice + "'><label id='lblunitprice'>", this.comm.GetCurrencyinRequiredFormate("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / qty), 2, "", false, false, true) + "", true), " </label></div>")));
                    //plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearTop' style='" + DisplayPackPrice + "'><label id='lblpackprice'>", this.comm.GetCurrencyinRequiredFormate("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / (qty / soldInPacksof)), 2, "", false, false, true) + "", true), " </label></div>")));
                    ControlCollection controlCollections1 = plh.Controls;
                    string[] currencyinRequiredFormate1 = new string[] { "<div class='clearTop'><label id='lbltotal' ", empty4, ">", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><input type='hidden' id='hdnlbltotal' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input></div>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(currencyinRequiredFormate1)));

                    plh.Controls.Add(new LiteralControl("</div>"));
                }
                string empty8 = string.Empty;
                if (!(this.hdnShowPriceSubtotalTax.Value.ToLower() == "true") || !(AdditionItem == "no"))
                {
                    str3 = "style='display:none'";
                }
                else
                {
                    str3 = "style='display:block'";
                    empty8 = "style='padding-top:8px;'";
                }
                if (this.hid_matixType.Value.ToLower() != "g")
                {
                    empty8 = "";
                }
                if (!(this.isPriceExTax == "1") || !(this.IsEnableHidePrice == "false"))
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_leftmost_B2B' ", empty8, ">")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_withoutTax' ", str3, " class='price_table_content_left_B2B'><div id='divPrice'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<label id='lblPrice_ex_Tax' class='DisplayNone'>", this.objLanguage.GetLanguageConversion("Price_ex_Tax"), " </label>")));
                    this.plhquantity.Controls.Add(new LiteralControl("</div></div>"));
                    ControlCollection controls2 = this.plhquantity.Controls;
                    string[] currencyinRequiredFormate2 = new string[] { "<div ", str3, " class='floatRight TextAlignRight'><div class='floatRight'><label id='lbl_WithoutTax' class='DisplayNone'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div></div>" };
                    controls2.Add(new LiteralControl(string.Concat(currencyinRequiredFormate2)));
                    this.plhquantity.Controls.Add(new LiteralControl("</div</div>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_leftmost_B2B' ", empty8, ">")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_withoutTax' ", str3, " class='price_table_content_left_B2B'><div id='divPrice'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<label id='lblPrice_ex_Tax' >", this.objLanguage.GetLanguageConversion("Price_ex_Tax"), " </label>")));
                    this.plhquantity.Controls.Add(new LiteralControl("</div></div>"));
                    ControlCollection controlCollections2 = this.plhquantity.Controls;
                    string[] strArrays2 = new string[] { "<div ", str3, " class='floatRight TextAlignRight'><div class='floatRight'><label id='lbl_WithoutTax'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div></div>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(strArrays2)));
                    this.plhquantity.Controls.Add(new LiteralControl("</div</div>"));
                }
                string str8 = "";
                str8 = (this.isTax != "1" ? "style='display:none'" : "style='display:block'");
                str8 = (this.hdnShowPriceSubtotalTax.Value.ToLower() != "true" ? "style='display:none'" : "style='display:block'");
                plh.Controls.Add(new LiteralControl(string.Concat("<div ", str8, ">")));
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                string empty9 = string.Empty;
                plh.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
                ControlCollection controls3 = plh.Controls;
                string[] strArrays3 = new string[] { "<div class='price_table_content_left_B2B' ", empty7, " ", str, ">" };
                controls3.Add(new LiteralControl(string.Concat(strArrays3)));
                if (this.IsEnableHidePrice != "false" || this.IsZip2taxEnabled != false)
                {
                    if (this.IsZip2taxEnabled == true)
                    {
                        this.ProductTaxRate = 0;
                    }
                    ControlCollection controlCollections3 = plh.Controls;
                    object[] objArray = new object[] { "<div><label></label><label id='lblTax' class='DisplayNone'>", base.SpecialDecode(this.ProductTaxName), " (", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(this.ProductTaxRate), 2, "", false, false, true)), "%) </label><label id='lblTaxID' class='DisplayNone'>", this.ProductTaxId, "</label>" };
                    controlCollections3.Add(new LiteralControl(string.Concat(objArray)));
                }
                else
                {
                    ControlCollection controls4 = plh.Controls;
                    object[] objArray1 = new object[] { "<div><label></label><label id='lblTax'>", base.SpecialDecode(this.ProductTaxName), " (", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(this.ProductTaxRate), 2, "", false, false, true)), "%) </label><label id='lblTaxID' class='DisplayNone'>", this.ProductTaxId, "</label>" };
                    controls4.Add(new LiteralControl(string.Concat(objArray1)));
                }
                plh.Controls.Add(new LiteralControl("</div></div>"));
                if (this.IsEnableHidePrice == "true" || this.IsZip2taxEnabled == true)
                {
                    plh.Controls.Add(new LiteralControl("<div align='left' class='price_table_content_right_B2B'><div><label id='lblTotalTax' class='DisplayNone'></label><input type='hidden' id='hdnlblTotalTax'></input></div></div>"));
                }
                else if (base.Request.Browser.Browser.ToString().ToLower() == "applemac-safari")
                {
                    if (this.artworkFile.ToLower() == "y" || this.artworkFile.ToLower() == "m")
                    {
                        plh.Controls.Add(new LiteralControl("<div align='left' class='price_table_content_right_B2B'><div><label id='lblTotalTax'></label><input type='hidden' id='hdnlblTotalTax'></input></div></div>"));
                    }
                    else
                    {
                        plh.Controls.Add(new LiteralControl("<div align='left' class='price_table_content_right_B2B'><div><label id='lblTotalTax'></label><input type='hidden' id='hdnlblTotalTax'></input></div></div>"));
                    }
                }
                else if (this.artworkFile.ToLower() == "y" || this.artworkFile.ToLower() == "m")
                {
                    plh.Controls.Add(new LiteralControl("<div align='left' class='price_table_content_right_B2B'><div><label id='lblTotalTax' ></label><input type='hidden' id='hdnlblTotalTax'></input></div></div>"));
                }
                else
                {
                    plh.Controls.Add(new LiteralControl("<div align='left' class='price_table_content_right_B2B'><div><label id='lblTotalTax' ></label><input type='hidden' id='hdnlblTotalTax'></input></div></div>"));
                }
                plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearBoth'><br></div><div ", empty1, ">")));
                plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblTaxRate' class='DisplayNone' >", this.ProductTaxRate, "</label>")));
                plh.Controls.Add(new LiteralControl("</div>"));
                plh.Controls.Add(new LiteralControl("</div>"));
                plh.Controls.Add(new LiteralControl("</div>"));
                string str9 = "";
                str9 = (this.isTotalPrice != "1" ? "style='display:none'" : "style='display:block'");
                str9 = (this.hdnShowPriceSubtotalTax.Value.ToLower() != "true" ? "style='display:none'" : "style='display:block'");
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content'", str9, ">")));
                if (AdditionItem == "yes")
                {
                    str = "style='padding-left: 12px;'";
                }
                else if (this.artworkFile.ToLower().Trim() == "n" && this.hid_matixType.Value.ToLower() == "s")
                {
                    str = "style='padding-left: 0px; width:50%;'";
                }
                plh.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop20'  >"));
                if (this.IsEnableHidePrice != "false")
                {
                    plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSellingPrice' class='lblSellingPrice DisplayNone'>", this.objLanguage.GetLanguageConversion("Total_Price_inc_tax"), " </label>")));
                }
                else
                {
                    if (this.IsZip2taxEnabled != true)
                    {
                        plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSellingPrice' class='lblSellingPrice'>", this.objLanguage.GetLanguageConversion("Total_Price_inc_tax"), " </label>")));
                    }
                    else
                    {
                        plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSellingPrice' class='lblSellingPrice'>", this.objLanguage.GetLanguageConversion("Total_Price"), " </label>")));
                    }
                }
                plh.Controls.Add(new LiteralControl("</div>"));
                if (AdditionItem != "yes")
                {
                    plh.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B paddingTop20'>"));
                }
                else
                {
                    plh.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B paddingTop20'>"));
                }
                if (this.IsEnableHidePrice != "false")
                {
                    ControlCollection controlCollections4 = plh.Controls;
                    string[] currencyinRequiredFormate3 = new string[] { "<label id='lblTotalSellingPrice' class='lblTotalSellingPrice DisplayNone' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><input type='hidden' id='hdnlblTotalSellingPrice' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(currencyinRequiredFormate3)));
                }
                else
                {
                    ControlCollection controls5 = plh.Controls;
                    string[] currencyinRequiredFormate4 = new string[] { "<label id='lblTotalSellingPrice' class='lblTotalSellingPrice' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><input type='hidden' id='hdnlblTotalSellingPrice' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input>" };
                    controls5.Add(new LiteralControl(string.Concat(currencyinRequiredFormate4)));
                }
                plh.Controls.Add(new LiteralControl("</div>"));
                plh.Controls.Add(new LiteralControl("</div>"));
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
            }
        }

        public void Product_list(string matixType, long PriceCatalogueID, PlaceHolder plhlist, string type, short i)
        {
            if (PriceCatalogueID != (long)0)
            {
                plhlist.Controls.Add(new LiteralControl("<table class='price_table' cellpadding='10px' cellspacing='0px' border='0px'>"));
                plhlist.Controls.Add(new LiteralControl("<tbody>"));
                plhlist.Controls.Add(new LiteralControl("<tr class='width210pxnotImportant'>"));
                if (matixType != "G")
                {
                    plhlist.Controls.Add(new LiteralControl(string.Concat("<th class='DisplayInlineBlock'><div align='left' class='paddingLeft5'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div></th>")));
                }
                else
                {
                    ControlCollection controls = plhlist.Controls;
                    string[] languageConversion = new string[] { "<th class='DisplayInlineBlock'><div align='left' class='paddingLeft5'>", this.objLanguage.GetLanguageConversion("Qty"), " (", this.MeasurementValue_Sq, ")</div></th>" };
                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (matixType == "P")
                {
                    ControlCollection controlCollections = plhlist.Controls;
                    string[] strArrays = new string[] { "<th class='width140pxnotImportant'><div align='right' class='div_PriceFor1_ExGST'>", this.objLanguage.GetLanguageConversion("Price_Each"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </div></th>" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                }
                else if (matixType != "G")
                {
                    ControlCollection controls1 = plhlist.Controls;
                    string[] languageConversion1 = new string[] { "<th class='width110pxnotImportant'><div align='center' style= 'margin-left:2px'; class='div_Price_ExGST'>", this.objLanguage.GetLanguageConversion("Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ") </div></th>" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
                }
                else
                {
                    ControlCollection controlCollections1 = plhlist.Controls;
                    string[] strArrays1 = new string[] { "<th class='width140pxnotImportant'><div align='right' class='div_PriceFor1_ExGST'>", this.objLanguage.GetLanguageConversion("Price_Each"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </div></th>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                plhlist.Controls.Add(new LiteralControl("</tr>"));
                foreach (DataRow row in ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId).Rows)
                {
                    if (i <= 5 && type == "hidemore")
                    {
                        System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label()
                        {
                            ID = string.Concat("lblquantity", i)
                        };
                        System.Web.UI.WebControls.Label label1 = new System.Web.UI.WebControls.Label()
                        {
                            ID = string.Concat("lblPrice", i)
                        };
                        if (this.hid_matixType.Value == "P")
                        {
                            label.Text = string.Concat(row["FromQuantity"].ToString(), " - ", row["ToQuantity"].ToString());
                            label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                        }
                        else if (this.hid_matixType.Value != "G")
                        {
                            label.Text = row["ToQuantity"].ToString();
                            label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_Cal", "javascript:Tocalculate_totalPrice('0','0');", true);
                        }
                        else
                        {
                            label.Text = string.Concat(row["FromQuantity"].ToString(), " - ", row["ToQuantity"].ToString());
                            label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                        }
                        if (i == 1)
                        {
                            try
                            {
                                if (!Convert.ToBoolean(row["IsPriceStartFrom"]) || !(this.IsEnableHidePrice == "false"))
                                {
                                    this.lbl_priceStartsFrom.Visible = false;
                                    this.lbl_priceStartsFrom1.Visible = false;
                                }
                                else
                                {
                                    this.lbl_priceStartsFrom.Text = this.objLanguage.GetLanguageConversion("Price_Starts_From");
                                    this.lbl_priceStartsFrom1.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true));
                                }
                                if (!Convert.ToBoolean(row["IsShowSoldInPacksOf"]) || Convert.ToInt32(row["SoldInPacksOf"]) == 0)
                                {
                                    this.lbl_ShowSoldInPacksOf.Visible = false;
                                    this.lbl_ShowSoldInPacksOf1.Visible = false;
                                }
                                else
                                {
                                    this.lbl_ShowSoldInPacksOf.Text = this.objLanguage.GetLanguageConversion("Sold_in_Packs_of");
                                    this.lbl_ShowSoldInPacksOf1.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SoldInPacksOf"].ToString()), 2, "", false, false, true));
                                }
                                if (!Convert.ToBoolean(row["IsShowStock"]))
                                {
                                    this.IsShowStock = "0";
                                }
                                else
                                {
                                    this.IsShowStock = "1";
                                }
                            }
                            catch
                            {
                            }
                        }
                        plhlist.Controls.Add(new LiteralControl("<tr><td class='height20px'><div align='left' class='paddingTop5 paddingLeft5'>"));
                        plhlist.Controls.Add(label);
                        plhlist.Controls.Add(new LiteralControl("</div></td>"));
                        plhlist.Controls.Add(new LiteralControl("<td class='height20px'><div align='center' class='paddingTop5'>"));
                        plhlist.Controls.Add(label1);
                        plhlist.Controls.Add(new LiteralControl("</div></td></tr>"));
                    }
                    else if (type != "hidemore" && type == "viewmore")
                    {
                        System.Web.UI.WebControls.Label str = new System.Web.UI.WebControls.Label()
                        {
                            ID = string.Concat("lblquantity", i)
                        };
                        System.Web.UI.WebControls.Label label2 = new System.Web.UI.WebControls.Label()
                        {
                            ID = string.Concat("lblPrice", i)
                        };
                        if (this.hid_matixType.Value == "P")
                        {
                            str.Text = string.Concat(row["FromQuantity"].ToString(), " - ", row["ToQuantity"].ToString());
                            label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                        }
                        else if (this.hid_matixType.Value != "G")
                        {
                            str.Text = row["ToQuantity"].ToString();
                            label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                        }
                        else
                        {
                            str.Text = string.Concat(row["FromQuantity"].ToString(), " - ", row["ToQuantity"].ToString());
                            label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                        }
                        plhlist.Controls.Add(new LiteralControl("<tr><td class='height20px'><div align='left' class='paddingTop5 paddingLeft5'>"));
                        plhlist.Controls.Add(str);
                        plhlist.Controls.Add(new LiteralControl("</div></td>"));
                        plhlist.Controls.Add(new LiteralControl("<td class='height20px'><div align='center' class='paddingTop5'>"));
                        plhlist.Controls.Add(label2);
                        plhlist.Controls.Add(new LiteralControl("</div></td></tr>"));
                        this.hid_qtyFromList.Value = string.Concat(this.hid_qtyFromList.Value, row["FromQuantity"].ToString(), "µ");
                        this.hid_qtyToList.Value = string.Concat(this.hid_qtyToList.Value, row["ToQuantity"].ToString(), "µ");
                        this.hid_CostExcMarkupList.Value = string.Concat(this.hid_CostExcMarkupList.Value, row["Price"].ToString(), "µ");
                        this.hid_MarkupList.Value = string.Concat(this.hid_MarkupList.Value, row["Markup"].ToString(), "µ");
                        this.hid_priceList.Value = string.Concat(this.hid_priceList.Value, row["SellingPrice"].ToString(), "µ");
                        if (Convert.ToInt32(row["SoldInPacksOf"]) == 0)
                        {
                            this.hdnsoldPackOV.Value = "1";
                        }
                        else
                        {
                            this.hdnsoldPackOV.Value = row["SoldInPacksOf"].ToString();
                        }
                    }
                    i = (short)(i + 1);
                }
                if (i > 6)
                {
                    if (type != "viewmore")
                    {
                        plhlist.Controls.Add(new LiteralControl("<tr><td>&nbsp;</td><td><div class='center_div_content' align='right'>"));
                        plhlist.Controls.Add(new LiteralControl(string.Concat("<a onclick='PriceList_OpenPopup(\"viewmore\");'>(", this.objLanguage.GetLanguageConversion("View_More"), ")</a>")));
                        plhlist.Controls.Add(new LiteralControl("</div></td></tr>"));
                    }
                    else
                    {
                        plhlist.Controls.Add(new LiteralControl("<tr><td>&nbsp;</td><td><div class='center_div_content' align='right'>"));
                        plhlist.Controls.Add(new LiteralControl(string.Concat("<a onclick='PriceList_OpenPopup(\"hidemore\");'>(", this.objLanguage.GetLanguageConversion("Hide_More"), ")</a>")));
                        plhlist.Controls.Add(new LiteralControl("</div></td></tr>"));
                    }
                }
                plhlist.Controls.Add(new LiteralControl("<tr><td colspan='2'></td></tr><tr><td colspan='2'><div class='Example-Style' align='left' width='auto' style='padding-left:5px;'>"));
                if (!(this.ServerName.ToString().ToLower().Trim() == "fsg") || productdetails.AccountID != (long)267)
                {
                    plhlist.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("All_Price_Are_EX_GST_Or_EX_VAT") ?? ""));
                }
                else
                {
                    plhlist.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("All_Price_Are_EX_GST") ?? ""));
                }
                plhlist.Controls.Add(new LiteralControl("</div></td></tr>"));
                plhlist.Controls.Add(new LiteralControl("</tbody>"));
                plhlist.Controls.Add(new LiteralControl("</table>"));
            }
        }

        public void setddlval(DropDownList ddl, int value)
        {
            System.Web.UI.WebControls.ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }

        public void SetDDLValueForProductPage(DropDownList ddl, string Value)
        {
            try
            {
                System.Web.UI.WebControls.ListItem listItem = ddl.Items.FindByValue(Value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix, PlaceHolder plhPriceCalculator)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
            plhPriceCalculator.Controls.Add(ddlMatrix);
        }

        public void SimpleMatrix_DropDownBind_Edit(DataTable dtMul, DropDownList ddlMatrix, PlaceHolder plhPriceCalculator, string Qnty)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
            (new BaseClass()).SetDDLText(ddlMatrix, Qnty);
            plhPriceCalculator.Controls.Add(ddlMatrix);
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

        private void UpdateProgressContext()
        {
            RadProgressContext current = RadProgressContext.Current;
            current.Speed = "N/A";
            for (int i = 0; i < 100; i++)
            {
                current.SecondaryTotal = 100;
                current.SecondaryValue = i;
                current.SecondaryPercent = i;
                current.CurrentOperationText = string.Concat(i.ToString(), "%");
                if (!base.Response.IsClientConnected)
                {
                    return;
                }
                current.TimeEstimated = (100 - i) * 100;
                Thread.Sleep(8);
            }
        }

        protected void UploadCsvFile_Click(object sender, EventArgs e)
        {
            long num = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            DataSet dataSet = ProductBasePage.Select_TemplateID((long)this.PriceCatalogueID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                num = Convert.ToInt64(dataSet.Tables[0].Rows[0]["TemplateID"].ToString());
            }
            Guid guid = Guid.NewGuid();
            string str1 = guid.ToString().Substring(0, 10);
            long priceCatalogueID = (long)this.PriceCatalogueID;
            if (!this.Upload.HasFile)
            {
                return;
            }
            if (this.Upload.HasFile)
            {
                this.CSvFileName = string.Concat(str1, "_", DateTime.Now.ToFileTime(), "_", this.Upload.FileName.ToString());
                empty = this.Upload.FileName.ToString();
                this.CSvFileName = this.comm.ReplaceAllBlankSpace(this.CSvFileName);
                this.ZipImageFileName = string.Empty;
                object[] secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//TemplateCsvFile" };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//TemplateCsvFile" };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                object[] secureDocPath1 = new object[] { this.SecureDocPath, "//", this.ServerName, "//store//", productdetails.AccountID, "//artwork" };
                if (!Directory.Exists(string.Concat(secureDocPath1)))
                {
                    object[] objArray1 = new object[] { this.SecureDocPath, "//", this.ServerName, "//store//", productdetails.AccountID, "//artwork" };
                    Directory.CreateDirectory(string.Concat(objArray1));
                }
                object[] secureDocPath2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                if (!Directory.Exists(string.Concat(secureDocPath2)))
                {
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                    Directory.CreateDirectory(string.Concat(objArray2));
                }
                FileUpload upload = this.Upload;
                object[] secureDocPath3 = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//TemplateCsvFile/", this.CSvFileName };
                upload.SaveAs(string.Concat(secureDocPath3));
                FileUpload fileUpload = this.Upload;
                object[] objArray3 = new object[] { this.SecureDocPath, "//", this.ServerName, "//store//", productdetails.AccountID, "//artwork/", this.CSvFileName };
                fileUpload.SaveAs(string.Concat(objArray3));
                FileUpload upload1 = this.Upload;
                object[] secureDocPath4 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", this.CSvFileName };
                upload1.SaveAs(string.Concat(secureDocPath4));

                if (this.imgeZipUploader != null)
                    if (this.imgeZipUploader.HasFile)
                    {
                        this.ZipImageFileName = string.Concat(str1, "_", this.imgeZipUploader.FileName.ToString());
                        this.imgeZipUploader.FileName.ToString();
                        this.ZipImageFileName = this.comm.ReplaceAllBlankSpace(this.ZipImageFileName);
                        FileUpload fileUpload1 = this.imgeZipUploader;
                        object[] objArray4 = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//TemplateCsvFile/", this.ZipImageFileName };
                        fileUpload1.SaveAs(string.Concat(objArray4));
                        FileUpload fileUpload2 = this.imgeZipUploader;
                        object[] secureDocPath5 = new object[] { this.SecureDocPath, "//", this.ServerName, "//store//", productdetails.AccountID, "//artwork/", this.ZipImageFileName };
                        fileUpload2.SaveAs(string.Concat(secureDocPath5));
                        FileUpload fileUpload3 = this.imgeZipUploader;
                        object[] objArray5 = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", this.ZipImageFileName };
                        fileUpload3.SaveAs(string.Concat(objArray5));
                    }
                this.TemplateImportID = LoginBasePage.Ws_UploadCSVFile(this.CSvFileName, Convert.ToInt32(priceCatalogueID), Convert.ToInt32(num), Convert.ToInt32(this.StoreUserID), Convert.ToInt32(productdetails.AccountID), 0, "Insert", 0, empty, this.CompanyID, this.ZipImageFileName);
            }
            this.UpdateProgressContext();
        }

        public void SetDDItems(DropDownList ddl, string selectedText, bool IsMandatory)
        {
            try
            {
                if (IsMandatory)
                {
                    ddl.Items.Add("--select--");
                }
                ddl.Items.Add("Yes");
                ddl.Items.Add("No");
                ListItem listItem = ddl.Items.FindByValue(selectedText);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        protected void GridInkCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["Price"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdninkType");
                Label label1 = (Label)e.Item.FindControl("lbl_CostPrice");
                Label label2 = (Label)e.Item.FindControl("lbl_SellingPrice");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnQty");
                Label label8 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                DataTable dataTable2 = ProductBasePage.ProductStockType_Select((long)this.CompanyID, (long)this.PriceCatalogueID);
                DataTable dataTable6 = ProductBasePage.Product_CatalogueQty_SelectMMX((long)Convert.ToInt32(hiddenField.Value));
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    if (!Convert.ToBoolean(row1["isshowstock"]))
                    {
                        label8.Text = "";
                    }
                    else
                    {
                        foreach (DataRow row in dataTable6.Rows)
                        {
                            if (!Convert.ToBoolean(row["isstockitem"]))
                            {
                                label8.Text = "N/A";
                            }
                        }
                    }
                }
                DropDownList ddlMarkup = (DropDownList)e.Item.FindControl("ddl_Markup");
                ddlMarkup.DataSource = dataTable6;
                ddlMarkup.DataTextField = "ToQuantity";
                ddlMarkup.DataValueField = "NewPrice";
                ddlMarkup.Attributes.Add("onchange", "javascript:TocalculateMatrix_totalPrice('0','0' , this , 'S'); CheckStockAvailability('0')");
                //ddlMarkup.Attributes.Add("onchange", "javascript:TocalculateMatrix_totalPrice('0','0' , this , 'S'); PriceOnBlur_Total(this)");
                //ddlMarkup.Attributes.Add("onmouseout", "javascript:TocalculateMatrix_totalPrice('0','0' , this , 'S');");
                ddlMarkup.DataBind();
                TextBox textBox = (TextBox)e.Item.FindControl("txt_Markup");
                textBox.Text = textBox.Text.ToString();
                textBox.Attributes.Add("onkeyup", "javascript:TocalculateMatrix_totalPrice(this.value," + hiddenField.Value + ",this , 'P')");
                //textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);TocalculateMatrix_totalPrice(this.value," + hiddenField.Value + ", this,'P');PriceOnBlur_Matrix(this);");
                textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);TocalculateMatrix_totalPrice(this.value," + hiddenField.Value + ", this,'P');");
                textBox.Attributes.Add("onclick", "javascript:this.select();");
                foreach (DataRow row in dataTable6.Rows)
                {
                    if (row["MatrixType"].ToString().ToLower() == "s")
                    {
                        textBox.Visible = false;
                    }
                    else
                    {
                        ddlMarkup.Visible = false;
                    }
                }
                Label label9 = (Label)e.Item.FindControl("lbl_paperlength");
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                if (hiddenField.Value.ToLower() == "m")
                {
                    label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text.ToString()), 0, "", false, false, true);
                }
            }
        }


        void AddDecoration(Int32 DecorationNo, string DecorationLabel, Boolean Decoration1_Mandadory, string SelectedValue)
        {
            DecorationLabel = Decoration1_Mandadory ? DecorationLabel + "*" : DecorationLabel;



            object[] secureSitePath;
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth' ></div>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost_B2B'>"));
            ControlCollection controls6 = this.plhPriceCalculator.Controls;

            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
            Int32 length = this.OtherCostName.Length;
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
            if (this.RightPanelCalc_Enabled.ToLower() != "true")
            {
                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5 paddingBottom5'>"));
            }
            else
            {
                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_B2B paddingTop5'>"));
            }
            //if (empty4 != "1")
            //{
            ControlCollection controlCollections6 = this.plhPriceCalculator.Controls;
            secureSitePath = new object[] { "<label id='lblDecoration", DecorationNo, "' > ", DecorationLabel, "</label>" };
            controlCollections6.Add(new LiteralControl(string.Concat(secureSitePath)));

            if (length <= 80)
            {
                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
            }
            else
            {
                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div>"));
            }
            length = 0;
            DropDownList dropDownList = new DropDownList()
            {
                ID = string.Concat("ddlDecoration", DecorationNo),
                CssClass = "dropDownMultiple150"
            };
            if (this.RightPanelCalc_Enabled.ToLower() != "true")
            {
                dropDownList.Width = 300;
            }
            dropDownList.Attributes.Add("onchange", "javascript:calculateDecoration(1);Tocall_mainFunc();");
            SetDDItems(dropDownList, Decoration1_Mandadory ? "--select--" : "No", Decoration1_Mandadory);
            if (SelectedValue != "")
            {
                SetDDLValueForProductPage(dropDownList, SelectedValue);
            }
            plhPriceCalculator.Controls.Add(dropDownList);

            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_B2B'>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right_innerDiv2'>"));

            ControlCollection controls8 = this.plhPriceCalculator.Controls;
            secureSitePath = new object[] { "<label id='lblDecoration", DecorationNo, "Cost", "' class='block'>", this.comm.GetCurrencyinRequiredFormate("0.00", true), "</label>" };
            controls8.Add(new LiteralControl(string.Concat(secureSitePath)));


            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));

        }
    }
}