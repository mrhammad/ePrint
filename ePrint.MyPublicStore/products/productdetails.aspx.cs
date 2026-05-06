using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Prefligt;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.products
{
    public partial class productdetails : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected System.Web.UI.WebControls.Label lbl_home;

        //protected System.Web.UI.WebControls.Label lbl_spliter;

        //protected System.Web.UI.WebControls.Label lbl_nav_catagoty;

        //protected System.Web.UI.WebControls.Label lbl_nav_product;

        //protected System.Web.UI.WebControls.Label lbl_nav_productName;

        //protected System.Web.UI.WebControls.Label lbl_nav;

        //protected HtmlGenericControl navigation_div;

        //protected System.Web.UI.WebControls.Label href_Searchproduct;

        //protected System.Web.UI.WebControls.Label lbl_Searchproduct;

        //protected HtmlGenericControl div_searchProduct;

        //protected PlaceHolder plhFirst;

        //protected System.Web.UI.WebControls.Label lbl_CatalogueName1;

        //protected PlaceHolder plh_innertable_starting;

        //protected HtmlImage cards;

        //protected HtmlAnchor cards1;

        //protected System.Web.UI.WebControls.Label lblPrintReadyFile;

        //protected HtmlGenericControl div_PrintReadyFile;

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

        //protected PlaceHolder plh_innertable_middle_tds;

        //protected HiddenField hdnIsBackOrder;

        //protected HiddenField hdnPriceCatalogueID;

        //protected HiddenField hdnDrawStockFrom;

        //protected HiddenField hdnStockManagement;

        //protected HiddenField hdnIsShowStock;

        //protected HiddenField hdnAvailableQty;

        //protected HiddenField hdnMashDivHeight;

        //protected HiddenField hdnIsStockItem;

        //protected HiddenField hdnWebOtherCostID;

        //protected HiddenField hdnStockAddOption;

        //protected HiddenField hdnselectedddlmultipleid;

        //protected HiddenField hdnselectedwebothercostid;

        //protected HtmlGenericControl divMask;

        //protected PlaceHolder plh_Contents;

        //protected System.Web.UI.WebControls.Label lbl_CatalogueName2;

        //protected System.Web.UI.WebControls.Label lblStockMessage;

        //protected HtmlGenericControl pnlStockMessage;

        //protected System.Web.UI.WebControls.Label lblSubProductName;

        //protected System.Web.UI.WebControls.Label lbl_Description;

        //protected System.Web.UI.WebControls.Label lblCustomerCode;

        //protected System.Web.UI.WebControls.Label lblItemCode;

        //protected System.Web.UI.WebControls.Label lblSelectOption;

        //protected HtmlGenericControl Spn_PrdoMandatory;

        //protected DropDownList ddlProductList;

        //protected HtmlGenericControl Span2;

        //protected HtmlGenericControl div_ProdSelectErrorMSG;

        //protected HtmlGenericControl div_ProductOptions;

        //protected System.Web.UI.WebControls.Label lbl_priceStartsFrom;

        //protected System.Web.UI.WebControls.Label lbl_priceStartsFrom1;

        //protected System.Web.UI.WebControls.Label lbl_stockStatus;

        //protected System.Web.UI.WebControls.Label lbl_stockStatus1;

        //protected HtmlGenericControl divStockStatus;

        //protected System.Web.UI.WebControls.Label lbl_ShowSoldInPacksOf;

        //protected System.Web.UI.WebControls.Label lbl_ShowSoldInPacksOf1;

        //protected HtmlGenericControl div_soldinpack;

        //protected PlaceHolder plh_above_div_PriceStartFrom;

        //protected PlaceHolder plhquantity;

        //protected System.Web.UI.WebControls.Label lblupload;

        //protected FileUpload fp_artwork_no_addoption1;

        //protected HtmlGenericControl spn_artworkFile1;

        //protected FileUpload fp_artwork_no_addoption2;

        //protected FileUpload fp_artwork_no_addoption3;

        //protected HtmlGenericControl div_artwork_content_fileupload_no_addoption;

        //protected HtmlGenericControl artwork_div_no_addoption;

        //protected Button btnAddtoCart1;

        //protected HtmlGenericControl div_btnAddtoCart1;

        //protected Button EditProduct1;

        //protected PlaceHolder plhPriceCalculator;

        //protected System.Web.UI.WebControls.Label Label1;

        //protected FileUpload fp_artwork;

        //protected HtmlGenericControl spn_artworkFile;

        //protected FileUpload fp_artwork1;

        //protected FileUpload fp_artwork2;

        //protected HtmlGenericControl artwork_div;

        //protected Button btnAddtoCart;

        //protected Button EditProduct2;

        //protected HtmlGenericControl Price_CalculatorWithAddition;

        //protected HtmlGenericControl div_Below_Desc;

        //protected PlaceHolder plh_below_div_Below_desc;

        //protected PlaceHolder plhRightBanner;

        //protected PlaceHolder plhLast;

        //protected Panel pnlNormalDetails;

        //protected CheckBox chkconform;

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

        //protected HiddenField hdnShowPriceSubtotalTax;

        //protected HiddenField hdn_orderedheight;

        //protected HiddenField hdn_orderedwidth;

        //protected HiddenField hdn_orderedarea;

        //protected HiddenField hdn_orderedquantity;

        //protected HiddenField hdnPrintReadyFile;

        //protected HiddenField hdnSingleQuestionValues;

        //protected Panel pnladdoptionvalidate;

        public static string TheURL;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string EprintImagePath = BaseClass.EprintImagePath();

        public char KeySeparator;

        public int AdditionalCount;

        public int IsPriceList;

        public int CompanyID;

        public int PriceCatalogueID;

        public int PriceCatalogueCategoryID;

        public long StoreUserID;

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

        public string FileName1 = string.Empty;

        public string FileName2 = string.Empty;

        public string FileName3 = string.Empty;

        public string ReportFileName1 = string.Empty;

        public string ReportFileName2 = string.Empty;

        public string ReportFileName3 = string.Empty;

        public string OriginalFileName1 = string.Empty;

        public string OriginalFileName2 = string.Empty;

        public string OriginalFileName3 = string.Empty;

        public string AccountType = string.Empty;

        public string searchProducts = string.Empty;

        public string searchCookie = string.Empty;

        public string HelpText = string.Empty;

        public string SystemName = string.Empty;

        public string PrintReadyFile = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string displayStyle = "style='display:block;'";

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

        public string PrintReadyFilePath_Verify = string.Empty;

        public string RequestType = string.Empty;

        public int AvailableQuantity;

        public int DefaultMultipleProdId;

        public bool isCustomerCode;

        public bool isItemCode;

        public bool isDisplayAdditionalOption;

        public string SecureDocPath = string.Empty;

        public string ServerName = string.Empty;

        private DropDownList ddlPriceQty = new DropDownList();

        private TextBox txt_Cumulative_PriceQty = new TextBox();

        public bool IsCumulative;

        private string MeasurementValue = string.Empty;

        public string MeasurementValue_Sq = string.Empty;

        private int RoundOff;

        public string price_calculator_Style = string.Empty;

        public string price_table_header_Style = string.Empty;

        public string AddBtn_Style = string.Empty;

        private string RightPanelCalc_Enabled = string.Empty;

        private BaseClass objBc = new BaseClass();

        public int CopiedPriceCatalogueId;

        public int MainProductID;

        public string ProductTaxName = string.Empty;

        public int ProductTaxId;

        public decimal ProductTaxRate;

        public string Rewritemodule = string.Empty; //modification

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
        }

        public productdetails()
        {
        }

        public void artwork_file(FileUpload fileUpload, long CartID, int count, string Additional, out string fileName)
        {
            string[] strArrays = fileUpload.FileName.ToString().Trim().Split(new char[] { '.' });
            string str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            string str1 = this.comm.ReplaceAllBlankSpace(fileUpload.FileName);
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
            DataTable dataTable = ProductBasePage.OtherMultiple_product_Select(PriceCatalogueID, this.CompanyID);
            this.ddlProductList.DataSource = dataTable;
            this.ddlProductList.DataTextField = "CatalogueName";
            this.ddlProductList.DataValueField = "PriceCatalogueID";
            this.ddlProductList.DataBind();
        }

        protected void btn_ConfirmEditTemplate_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "save", "javascript:Save_toCart('no');", false);
            long num = (long)0;
            long num1 = (long)0;
            string[] strArrays = this.hid_SaveToCart.Value.Split(new char[] { '»' });
            string empty = string.Empty;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
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
                    num = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num2, num3, num4,false);
                }
            }
            long priceCatalogueID = (long)this.PriceCatalogueID;
            if (this.hdnDrawStockFrom.Value == "m")
            {
                this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                priceCatalogueID = (long)this.DefaultMultipleProdId;
            }
            long num5 = (long)0;
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            long num10 = (long)0;
            string[] strArrays2 = this.hid_SaveToCartItems.Value.Split(new char[] { '»' });
            for (int k = 0; k <= (int)strArrays2.Length - 1; k++)
            {
                if (strArrays2[k] != "")
                {
                    num5 = Convert.ToInt64(strArrays2[0]);
                    num6 = Convert.ToDecimal(strArrays2[1]);
                    num7 = Convert.ToDecimal(strArrays2[2]);
                    num9 = Convert.ToDecimal(strArrays2[3]);
                    num8 = Convert.ToDecimal(strArrays2[4]);
                    num10 = Convert.ToInt64(strArrays2[5]);
                }
            }
            if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
            {
                if (this.fp_artwork.HasFile)
                {
                    this.artwork_file(this.fp_artwork, num, 1, "yes", out this.FileName);
                    this.FileName1 = this.FileName;
                    string[] strArrays3 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName1 = strArrays3[0].ToString();
                    this.ReportFileName1 = strArrays3[1].ToString();
                    this.OriginalFileName1 = this.fp_artwork.FileName;
                }
                if (this.fp_artwork1.HasFile)
                {
                    this.artwork_file(this.fp_artwork1, num, 2, "yes", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays4 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays4[0].ToString();
                    this.ReportFileName2 = strArrays4[1].ToString();
                    this.OriginalFileName2 = this.fp_artwork1.FileName;
                }
                if (this.fp_artwork2.HasFile)
                {
                    this.artwork_file(this.fp_artwork2, num, 3, "yes", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays5 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays5[0].ToString();
                    this.ReportFileName3 = strArrays5[1].ToString();
                    this.OriginalFileName3 = this.fp_artwork2.FileName;
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
                    this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName;
                }
                if (this.fp_artwork_no_addoption2.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption2, num, 2, "no", out this.FileName);
                    this.FileName2 = this.FileName;
                    string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName2 = strArrays7[0].ToString();
                    this.ReportFileName2 = strArrays7[1].ToString();
                    this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName;
                }
                if (this.fp_artwork_no_addoption3.HasFile)
                {
                    this.artwork_file(this.fp_artwork_no_addoption3, num, 3, "no", out this.FileName);
                    this.FileName3 = this.FileName;
                    string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                    this.FileName3 = strArrays8[0].ToString();
                    this.ReportFileName3 = strArrays8[1].ToString();
                    this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName;
                }
            }
            num1 = CartBasePage.Insert_into_CartItem_EditableProd(num, priceCatalogueID, "", num5, num6, this.FileName1, this.FileName2, this.FileName3, num7, num8, num9, num10, (long)this.MainProductID, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            long num11 = (long)0;
            string str = string.Empty;
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);
            long num14 = (long)0;
            decimal num15 = new decimal(0);
            decimal num16 = new decimal(0);
            string empty1 = string.Empty;
            int num17 = 0;
            long num18 = (long)0;
            string str1 = string.Empty;
            string[] strArrays9 = this.hid_SaveToAdditionalItems.Value.Split(new char[] { 'µ' });
            CartBasePage.Delete_CartAdditionalItems(num1);
            for (int l = 0; l <= (int)strArrays9.Length - 1; l++)
            {
                if (strArrays9[l] != "")
                {
                    string[] strArrays10 = strArrays9[l].ToString().Split(new char[] { '±' });
                    for (int m = 0; m <= (int)strArrays10.Length - 1; m++)
                    {
                        if (strArrays10[m] != "")
                        {
                            string[] strArrays11 = strArrays10[m].Split(new char[] { '»' });
                            if (strArrays11[0] != "")
                            {
                                if (strArrays11[0] == "OthercostID")
                                {
                                    num11 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "Formula")
                                {
                                    str = strArrays11[1];
                                }
                                else if (strArrays11[0] == "MarkUp")
                                {
                                    num12 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "TotalPrice")
                                {
                                    num13 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedID")
                                {
                                    num14 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedValue")
                                {
                                    empty1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "SelectedPrice")
                                {
                                    num16 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "MarkUpValue")
                                {
                                    num15 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SortOrderNo")
                                {
                                    num17 = Convert.ToInt32(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "ParentWebOtherCostID")
                                {
                                    num18 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "WebOtherCostType")
                                {
                                    str1 = strArrays11[1];
                                }
                            }
                        }
                    }
                    CartBasePage.Insert_into_CartAdditionalItems(num1, num11, str, num12, num13, num14, empty1, num16, num15, num17, num18, str1);
                }
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                HttpResponse response = base.Response;
                object[] keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.KeySeparator, num1, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                response.Redirect(string.Concat(keySeparator));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] fileExtension = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num1, "&ID=", priceCatalogueID };
            httpResponse.Redirect(string.Concat(fileExtension));
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            object[] keySeparator;
            string value = this.hdnSingleQuestionValues.Value;
            char[] chrArray = new char[] { 'μ' };
            string[] strArrays = value.Split(chrArray);
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                string str = strArrays[i];
                chrArray = new char[] { '»' };
                string[] strArrays1 = str.Split(chrArray);
                long num = (long)0;
                long num1 = (long)0;
                if (strArrays1[0] != "" && strArrays1[1] != "")
                {
                    num = Convert.ToInt64(strArrays1[0]);
                    CartBasePage.UpdateSingleQuestionvalues(num, Convert.ToInt64(strArrays1[1]));
                }
            }
            string value1 = this.hdnPrintReadyFile.Value;
            chrArray = new char[] { ',' };
            string[] strArrays2 = value1.Split(chrArray);
            if (strArrays2[2] != "true")
            {
                long num2 = (long)0;
                long num3 = (long)0;
                string str1 = this.hid_SaveToCart.Value;
                chrArray = new char[] { '»' };
                string[] strArrays3 = str1.Split(chrArray);
                string empty = string.Empty;
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                for (int j = 0; j <= (int)strArrays3.Length - 1; j++)
                {
                    if (strArrays3[j] != "")
                    {
                        string str2 = strArrays3[j].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = str2.Split(chrArray);
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
                                num4 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "carttax")
                            {
                                num5 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "cartshipping")
                            {
                                num6 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                        }
                    }
                    if (j == 4)
                    {
                        if (this.StoreUserID != (long)0)
                        {
                            empty = "";
                        }
                        num2 = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num4, num5, num6,false);
                    }
                }
                long priceCatalogueID = (long)this.PriceCatalogueID;
                if (this.hdnDrawStockFrom.Value == "m")
                {
                    this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                    priceCatalogueID = (long)this.DefaultMultipleProdId;
                }
                long num7 = (long)0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                long num12 = (long)0;
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                string value2 = this.hid_SaveToCartItems.Value;
                chrArray = new char[] { '»' };
                string[] strArrays5 = value2.Split(chrArray);
                for (int l = 0; l <= (int)strArrays5.Length - 1; l++)
                {
                    if (strArrays5[l] != "")
                    {
                        num7 = Convert.ToInt64(strArrays5[0]);
                        num8 = Convert.ToDecimal(strArrays5[1]);
                        num9 = Convert.ToDecimal(strArrays5[2]);
                        num11 = Convert.ToDecimal(strArrays5[3]);
                        num10 = Convert.ToDecimal(strArrays5[4]);
                        num12 = Convert.ToInt64(strArrays5[5]);
                        num13 = Convert.ToDecimal(strArrays5[6]);
                        num14 = Convert.ToDecimal(strArrays5[7]);
                    }
                }
                if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                {
                    if (this.fp_artwork.HasFile)
                    {
                        this.artwork_file(this.fp_artwork, num2, 1, "yes", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays6[0].ToString();
                        this.ReportFileName1 = strArrays6[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                    }
                    if (this.fp_artwork1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork1, num2, 2, "yes", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays7[0].ToString();
                        this.ReportFileName2 = strArrays7[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                    }
                    if (this.fp_artwork2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork2, num2, 3, "yes", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays8[0].ToString();
                        this.ReportFileName3 = strArrays8[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                    }
                }
                else
                {
                    if (this.fp_artwork_no_addoption1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption1, num2, 1, "no", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays9 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays9[0].ToString();
                        this.ReportFileName1 = strArrays9[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                    }
                    if (this.fp_artwork_no_addoption2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption2, num2, 2, "no", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays10 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays10[0].ToString();
                        this.ReportFileName2 = strArrays10[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                    }
                    if (this.fp_artwork_no_addoption3.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption3, num2, 3, "no", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays11 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays11[0].ToString();
                        this.ReportFileName3 = strArrays11[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                    }
                }
                num3 = CartBasePage.Insert_into_CartItem(num2, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num12, num13, num14, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)this.MainProductID, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
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
                string empty3 = string.Empty;
                string value3 = this.hid_SaveToAdditionalItems.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays12 = value3.Split(chrArray);
                CartBasePage.Delete_CartAdditionalItems(num3);
                for (int m = 0; m <= (int)strArrays12.Length - 1; m++)
                {
                    if (strArrays12[m] != "")
                    {
                        string str3 = strArrays12[m].ToString();
                        chrArray = new char[] { '±' };
                        string[] strArrays13 = str3.Split(chrArray);
                        for (int n = 0; n <= (int)strArrays13.Length - 1; n++)
                        {
                            if (strArrays13[n] != "")
                            {
                                string str4 = strArrays13[n];
                                chrArray = new char[] { '»' };
                                string[] strArrays14 = str4.Split(chrArray);
                                if (strArrays14[0] != "")
                                {
                                    if (strArrays14[0] == "OthercostID")
                                    {
                                        num15 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "Formula")
                                    {
                                        empty1 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "MarkUp")
                                    {
                                        num16 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "TotalPrice")
                                    {
                                        num17 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedID")
                                    {
                                        num18 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedValue")
                                    {
                                        empty2 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "SelectedPrice")
                                    {
                                        num20 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "MarkUpValue")
                                    {
                                        num19 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SortOrderNo")
                                    {
                                        num21 = Convert.ToInt32(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "ParentWebOtherCostID")
                                    {
                                        num22 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "WebOtherCostType")
                                    {
                                        empty3 = strArrays14[1];
                                    }
                                }
                            }
                        }
                        CartBasePage.Insert_into_CartAdditionalItems(num3, num15, empty1, num16, num17, num18, empty2, num20, num19, num21, num22, empty3);
                    }
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    HttpResponse response = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num2, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                    response.Redirect(string.Concat(keySeparator));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num2, "&amp;PID=", priceCatalogueID };
                httpResponse.Redirect(string.Concat(keySeparator), false);
            }
            else
            {
                if (base.Request.Params["type"] != null)
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num23 = (long)0;
                    long num24 = (long)0;
                    string value4 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays15 = value4.Split(chrArray);
                    string uniqueID = string.Empty;
                    decimal num25 = new decimal(0);
                    decimal num26 = new decimal(0);
                    decimal num27 = new decimal(0);
                    for (int o = 0; o <= (int)strArrays15.Length - 1; o++)
                    {
                        if (strArrays15[o] != "")
                        {
                            string str5 = strArrays15[o].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays16 = str5.Split(chrArray);
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
                                    num25 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                                else if (strArrays16[0].ToLower() == "carttax")
                                {
                                    num26 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                                else if (strArrays16[0].ToLower() == "cartshipping")
                                {
                                    num27 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                            }
                        }
                        if (o == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID = "";
                            }
                            num23 = CartBasePage.Insert_into_Cart(uniqueID, this.StoreUserID, num25, num26, num27,false);
                        }
                    }
                    long defaultMultipleProdId = (long)this.PriceCatalogueID;
                    if (this.hdnDrawStockFrom.Value == "m")
                    {
                        this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                        defaultMultipleProdId = (long)this.DefaultMultipleProdId;
                    }
                    long num28 = (long)0;
                    decimal num29 = new decimal(0);
                    decimal num30 = new decimal(0);
                    decimal num31 = new decimal(0);
                    decimal num32 = new decimal(0);
                    long num33 = (long)0;
                    decimal num34 = new decimal(0);
                    decimal num35 = new decimal(0);
                    string value5 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays17 = value5.Split(chrArray);
                    for (int q = 0; q <= (int)strArrays17.Length - 1; q++)
                    {
                        if (strArrays17[q] != "")
                        {
                            num28 = Convert.ToInt64(strArrays17[0]);
                            num29 = Convert.ToDecimal(strArrays17[1]);
                            num30 = Convert.ToDecimal(strArrays17[2]);
                            num32 = Convert.ToDecimal(strArrays17[3]);
                            num31 = Convert.ToDecimal(strArrays17[4]);
                            num33 = Convert.ToInt64(strArrays17[5]);
                            num34 = Convert.ToDecimal(strArrays17[6]);
                            num35 = Convert.ToDecimal(strArrays17[7]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num23, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays18 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName1 = strArrays18[0].ToString();
                            this.ReportFileName1 = strArrays18[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num23, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays19 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName2 = strArrays19[0].ToString();
                            this.ReportFileName2 = strArrays19[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num23, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays20 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName3 = strArrays20[0].ToString();
                            this.ReportFileName3 = strArrays20[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num23, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays21 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName1 = strArrays21[0].ToString();
                            this.ReportFileName1 = strArrays21[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num23, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays22 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName2 = strArrays22[0].ToString();
                            this.ReportFileName2 = strArrays22[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num23, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays23 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName3 = strArrays23[0].ToString();
                            this.ReportFileName3 = strArrays23[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                        }
                    }
                    num24 = CartBasePage.Insert_into_CartItem(num23, defaultMultipleProdId, "", num28, num29, this.FileName1, this.FileName2, this.FileName3, num30, num31, num32, num33, num34, num35, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)this.MainProductID, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    long num36 = (long)0;
                    string empty4 = string.Empty;
                    decimal num37 = new decimal(0);
                    decimal num38 = new decimal(0);
                    long num39 = (long)0;
                    decimal num40 = new decimal(0);
                    decimal num41 = new decimal(0);
                    string empty5 = string.Empty;
                    int num42 = 0;
                    long num43 = (long)0;
                    string empty6 = string.Empty;
                    string value6 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays24 = value6.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num24);
                    for (int r = 0; r <= (int)strArrays24.Length - 1; r++)
                    {
                        if (strArrays24[r] != "")
                        {
                            string str6 = strArrays24[r].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays25 = str6.Split(chrArray);
                            for (int s = 0; s <= (int)strArrays25.Length - 1; s++)
                            {
                                if (strArrays25[s] != "")
                                {
                                    string str7 = strArrays25[s];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays26 = str7.Split(chrArray);
                                    if (strArrays26[0] != "")
                                    {
                                        if (strArrays26[0] == "OthercostID")
                                        {
                                            num36 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "Formula")
                                        {
                                            empty4 = strArrays26[1];
                                        }
                                        else if (strArrays26[0] == "MarkUp")
                                        {
                                            num37 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "TotalPrice")
                                        {
                                            num38 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SelectedID")
                                        {
                                            num39 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SelectedValue")
                                        {
                                            empty5 = strArrays26[1];
                                        }
                                        else if (strArrays26[0] == "SelectedPrice")
                                        {
                                            num41 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "MarkUpValue")
                                        {
                                            num40 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SortOrderNo")
                                        {
                                            num42 = Convert.ToInt32(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "ParentWebOtherCostID")
                                        {
                                            num43 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "WebOtherCostType")
                                        {
                                            empty6 = strArrays26[1];
                                        }
                                    }
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num24, num36, empty4, num37, num38, num39, empty5, num41, num40, num42, num43, empty6);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response1 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num23, ConnectionClass.KeySeparator, defaultMultipleProdId, ConnectionClass.FileExtension };
                        response1.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    HttpResponse httpResponse1 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num23, "&amp;PID=", defaultMultipleProdId };
                    httpResponse1.Redirect(string.Concat(keySeparator));
                    return;
                }
                if (strArrays2[1] != "true")
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num44 = (long)0;
                    long num45 = (long)0;
                    string value7 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays27 = value7.Split(chrArray);
                    string uniqueID1 = string.Empty;
                    decimal num46 = new decimal(0);
                    decimal num47 = new decimal(0);
                    decimal num48 = new decimal(0);
                    for (int t = 0; t <= (int)strArrays27.Length - 1; t++)
                    {
                        if (strArrays27[t] != "")
                        {
                            string str8 = strArrays27[t].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays28 = str8.Split(chrArray);
                            for (int u = 0; u <= (int)strArrays28.Length - 1; u++)
                            {
                                if (strArrays28[0].ToLower() == "cookieid")
                                {
                                    uniqueID1 = this.comm.UniqueID;
                                }
                                else if (strArrays28[0].ToLower() == "userid")
                                {
                                    Convert.ToInt64(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "carttotalprice")
                                {
                                    num46 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "carttax")
                                {
                                    num47 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "cartshipping")
                                {
                                    num48 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                            }
                        }
                        if (t == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID1 = "";
                            }
                            num44 = CartBasePage.Insert_into_Cart(uniqueID1, this.StoreUserID, num46, num47, num48,false);
                        }
                    }
                    long priceCatalogueID1 = (long)this.PriceCatalogueID;
                    if (this.hdnDrawStockFrom.Value == "m")
                    {
                        this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                        priceCatalogueID1 = (long)this.DefaultMultipleProdId;
                    }
                    long num49 = (long)0;
                    decimal num50 = new decimal(0);
                    decimal num51 = new decimal(0);
                    decimal num52 = new decimal(0);
                    decimal num53 = new decimal(0);
                    long num54 = (long)0;
                    decimal num55 = new decimal(0);
                    decimal num56 = new decimal(0);
                    string value8 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays29 = value8.Split(chrArray);
                    for (int v = 0; v <= (int)strArrays29.Length - 1; v++)
                    {
                        if (strArrays29[v] != "")
                        {
                            num49 = Convert.ToInt64(strArrays29[0]);
                            num50 = Convert.ToDecimal(strArrays29[1]);
                            num51 = Convert.ToDecimal(strArrays29[2]);
                            num53 = Convert.ToDecimal(strArrays29[3]);
                            num52 = Convert.ToDecimal(strArrays29[4]);
                            num54 = Convert.ToInt64(strArrays29[5]);
                            num55 = Convert.ToDecimal(strArrays29[6]);
                            num56 = Convert.ToDecimal(strArrays29[7]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num44, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays30 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays30[0].ToString();
                            this.ReportFileName1 = strArrays30[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName.ToString();
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num44, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays31 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays31[0].ToString();
                            this.ReportFileName2 = strArrays31[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName.ToString();
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num44, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays32 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays32[0].ToString();
                            this.ReportFileName3 = strArrays32[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName.ToString();
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num44, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays33 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays33[0].ToString();
                            this.ReportFileName1 = strArrays33[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num44, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays34 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays34[0].ToString();
                            this.ReportFileName2 = strArrays34[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName.ToString();
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num44, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays35 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays35[0].ToString();
                            this.ReportFileName3 = strArrays35[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName.ToString();
                        }
                    }
                    num45 = CartBasePage.Insert_into_CartItem(num44, priceCatalogueID1, "", num49, num50, this.FileName1, this.FileName2, this.FileName3, num51, num52, num53, num54, num55, num56, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)this.MainProductID, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    long num57 = (long)0;
                    string empty7 = string.Empty;
                    decimal num58 = new decimal(0);
                    decimal num59 = new decimal(0);
                    long num60 = (long)0;
                    decimal num61 = new decimal(0);
                    decimal num62 = new decimal(0);
                    string empty8 = string.Empty;
                    int num63 = 0;
                    long num64 = (long)0;
                    string empty9 = string.Empty;
                    string value9 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays36 = value9.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num45);
                    for (int w = 0; w <= (int)strArrays36.Length - 1; w++)
                    {
                        if (strArrays36[w] != "")
                        {
                            string str9 = strArrays36[w].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays37 = str9.Split(chrArray);
                            for (int x = 0; x <= (int)strArrays37.Length - 1; x++)
                            {
                                if (strArrays37[x] != "")
                                {
                                    string str10 = strArrays37[x];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays38 = str10.Split(chrArray);
                                    if (strArrays38[0] != "")
                                    {
                                        if (strArrays38[0] == "OthercostID")
                                        {
                                            num57 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "Formula")
                                        {
                                            empty7 = strArrays38[1];
                                        }
                                        else if (strArrays38[0] == "MarkUp")
                                        {
                                            num58 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "TotalPrice")
                                        {
                                            num59 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SelectedID")
                                        {
                                            num60 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SelectedValue")
                                        {
                                            empty8 = strArrays38[1];
                                        }
                                        else if (strArrays38[0] == "SelectedPrice")
                                        {
                                            num62 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "MarkUpValue")
                                        {
                                            num61 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SortOrderNo")
                                        {
                                            num63 = Convert.ToInt32(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "ParentWebOtherCostID")
                                        {
                                            num64 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "WebOtherCostType")
                                        {
                                            empty9 = strArrays38[1];
                                        }
                                    }
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num45, num57, empty7, num58, num59, num60, empty8, num62, num61, num63, num64, empty9);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response2 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num44, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
                        response2.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    HttpResponse httpResponse2 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num44, "&amp;PID=", priceCatalogueID1 };
                    httpResponse2.Redirect(string.Concat(keySeparator));
                    return;
                }
                if (strArrays2[0] == "1")
                {
                    if (this.searchProducts == "")
                    {
                        this.searchProducts = "0";
                    }
                    this.pnlNormalDetails.Style.Add("display", "none");
                    this.pnlConfirmPRFile.Style.Add("display", "block");
                    this.btn_ConfirmAdd1.Style.Add("display", "block");
                    return;
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "save", "javascript:Save_toCart('no');", false);
            long num = (long)0;
            long num1 = (long)0;
            string[] strArrays = this.hid_SaveToCart.Value.Split(new char[] { '»' });
            string empty = string.Empty;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
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
                    num = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num2, num3, num4,false);
                }
            }
            long priceCatalogueID = (long)this.PriceCatalogueID;
            if (this.hdnDrawStockFrom.Value == "m")
            {
                this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                priceCatalogueID = (long)this.DefaultMultipleProdId;
            }
            long num5 = (long)0;
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            long num10 = (long)0;
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            string[] strArrays2 = this.hid_SaveToCartItems.Value.Split(new char[] { '»' });
            for (int k = 0; k <= (int)strArrays2.Length - 1; k++)
            {
                if (strArrays2[k] != "")
                {
                    num5 = Convert.ToInt64(strArrays2[0]);
                    num6 = Convert.ToDecimal(strArrays2[1]);
                    num7 = Convert.ToDecimal(strArrays2[2]);
                    num9 = Convert.ToDecimal(strArrays2[3]);
                    num8 = Convert.ToDecimal(strArrays2[4]);
                    num10 = Convert.ToInt64(strArrays2[5]);
                    num11 = Convert.ToDecimal(strArrays2[6]);
                    num12 = Convert.ToDecimal(strArrays2[7]);
                }
            }
            if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
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
            num1 = CartBasePage.Insert_into_CartItem(num, priceCatalogueID, "", num5, num6, this.FileName1, this.FileName2, this.FileName3, num7, num8, num9, num10, num11, num12, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, (long)this.MainProductID, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
            long num13 = (long)0;
            string str = string.Empty;
            decimal num14 = new decimal(0);
            decimal num15 = new decimal(0);
            long num16 = (long)0;
            decimal num17 = new decimal(0);
            decimal num18 = new decimal(0);
            string empty1 = string.Empty;
            int num19 = 0;
            long num20 = (long)0;
            string str1 = string.Empty;
            string[] strArrays9 = this.hid_SaveToAdditionalItems.Value.Split(new char[] { 'µ' });
            CartBasePage.Delete_CartAdditionalItems(num1);
            for (int l = 0; l <= (int)strArrays9.Length - 1; l++)
            {
                if (strArrays9[l] != "")
                {
                    string[] strArrays10 = strArrays9[l].ToString().Split(new char[] { '±' });
                    for (int m = 0; m <= (int)strArrays10.Length - 1; m++)
                    {
                        if (strArrays10[m] != "")
                        {
                            string[] strArrays11 = strArrays10[m].Split(new char[] { '»' });
                            if (strArrays11[0] != "")
                            {
                                if (strArrays11[0] == "OthercostID")
                                {
                                    num13 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "Formula")
                                {
                                    str = strArrays11[1];
                                }
                                else if (strArrays11[0] == "MarkUp")
                                {
                                    num14 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "TotalPrice")
                                {
                                    num15 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedID")
                                {
                                    num16 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SelectedValue")
                                {
                                    empty1 = strArrays11[1];
                                }
                                else if (strArrays11[0] == "SelectedPrice")
                                {
                                    num18 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "MarkUpValue")
                                {
                                    num17 = Convert.ToDecimal(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "SortOrderNo")
                                {
                                    num19 = Convert.ToInt32(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "ParentWebOtherCostID")
                                {
                                    num20 = Convert.ToInt64(strArrays11[1]);
                                }
                                else if (strArrays11[0] == "WebOtherCostType")
                                {
                                    str1 = strArrays11[1];
                                }
                            }
                        }
                    }
                    CartBasePage.Insert_into_CartAdditionalItems(num1, num13, str, num14, num15, num16, empty1, num18, num17, num19, num20, str1);
                }
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                HttpResponse response = base.Response;
                object[] keySeparator = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, num, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                response.Redirect(string.Concat(keySeparator));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] fileExtension = new object[] { this.strSitepath, "shoppingcart", ConnectionClass.FileExtension, "?ID=", num, "&amp;PID=", priceCatalogueID };
            httpResponse.Redirect(string.Concat(fileExtension));
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
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                string str = strArrays[i];
                chrArray = new char[] { '»' };
                string[] strArrays1 = str.Split(chrArray);
                long num = (long)0;
                long num1 = (long)0;
                if (strArrays1[0] != "" && strArrays1[1] != "")
                {
                    num = Convert.ToInt64(strArrays1[0]);
                    CartBasePage.UpdateSingleQuestionvalues(num, Convert.ToInt64(strArrays1[1]));
                }
            }
            string value1 = this.hdnPrintReadyFile.Value;
            chrArray = new char[] { ',' };
            string[] strArrays2 = value1.Split(chrArray);
            if (strArrays2[2] != "true")
            {
                long num2 = (long)0;
                long num3 = (long)0;
                string str1 = this.hid_SaveToCart.Value;
                chrArray = new char[] { '»' };
                string[] strArrays3 = str1.Split(chrArray);
                string empty = string.Empty;
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                for (int j = 0; j <= (int)strArrays3.Length - 1; j++)
                {
                    if (strArrays3[j] != "")
                    {
                        string str2 = strArrays3[j].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = str2.Split(chrArray);
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
                                num4 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "carttax")
                            {
                                num5 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                            else if (strArrays4[0].ToLower() == "cartshipping")
                            {
                                num6 = Convert.ToDecimal(strArrays4[1].ToString());
                            }
                        }
                    }
                    if (j == 4)
                    {
                        if (this.StoreUserID != (long)0)
                        {
                            empty = "";
                        }
                        num2 = CartBasePage.Insert_into_Cart(empty, this.StoreUserID, num4, num5, num6,false);
                    }
                }
                long priceCatalogueID = (long)this.PriceCatalogueID;
                if (this.hdnDrawStockFrom.Value == "m")
                {
                    this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                    priceCatalogueID = (long)this.DefaultMultipleProdId;
                }
                long num7 = (long)0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                long num12 = (long)0;
                string value2 = this.hid_SaveToCartItems.Value;
                chrArray = new char[] { '»' };
                string[] strArrays5 = value2.Split(chrArray);
                for (int l = 0; l <= (int)strArrays5.Length - 1; l++)
                {
                    if (strArrays5[l] != "")
                    {
                        num7 = Convert.ToInt64(strArrays5[0]);
                        num8 = Convert.ToDecimal(strArrays5[1]);
                        num9 = Convert.ToDecimal(strArrays5[2]);
                        num11 = Convert.ToDecimal(strArrays5[3]);
                        num10 = Convert.ToDecimal(strArrays5[4]);
                        num12 = Convert.ToInt64(strArrays5[5]);
                    }
                }
                if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                {
                    if (this.fp_artwork.HasFile)
                    {
                        this.artwork_file(this.fp_artwork, num2, 1, "yes", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays6 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays6[0].ToString();
                        this.ReportFileName1 = strArrays6[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork.FileName;
                    }
                    if (this.fp_artwork1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork1, num2, 2, "yes", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays7 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays7[0].ToString();
                        this.ReportFileName2 = strArrays7[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork1.FileName;
                    }
                    if (this.fp_artwork2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork2, num2, 3, "yes", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays8 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays8[0].ToString();
                        this.ReportFileName3 = strArrays8[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork2.FileName;
                    }
                }
                else
                {
                    if (this.fp_artwork_no_addoption1.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption1, num2, 1, "no", out this.FileName);
                        this.FileName1 = this.FileName;
                        string[] strArrays9 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName1 = strArrays9[0].ToString();
                        this.ReportFileName1 = strArrays9[1].ToString();
                        this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName;
                    }
                    if (this.fp_artwork_no_addoption2.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption2, num2, 2, "no", out this.FileName);
                        this.FileName2 = this.FileName;
                        string[] strArrays10 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName2 = strArrays10[0].ToString();
                        this.ReportFileName2 = strArrays10[1].ToString();
                        this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName;
                    }
                    if (this.fp_artwork_no_addoption3.HasFile)
                    {
                        this.artwork_file(this.fp_artwork_no_addoption3, num2, 3, "no", out this.FileName);
                        this.FileName3 = this.FileName;
                        string[] strArrays11 = this.preflight_File(this.FileName, priceCatalogueID);
                        this.FileName3 = strArrays11[0].ToString();
                        this.ReportFileName3 = strArrays11[1].ToString();
                        this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName;
                    }
                }
                num3 = CartBasePage.Insert_into_CartItem_EditableProd(num2, priceCatalogueID, "", num7, num8, this.FileName1, this.FileName2, this.FileName3, num9, num10, num11, num12, (long)this.MainProductID, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                long num13 = (long)0;
                string empty1 = string.Empty;
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                long num16 = (long)0;
                decimal num17 = new decimal(0);
                decimal num18 = new decimal(0);
                string empty2 = string.Empty;
                int num19 = 0;
                long num20 = (long)0;
                string empty3 = string.Empty;
                string value3 = this.hid_SaveToAdditionalItems.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays12 = value3.Split(chrArray);
                CartBasePage.Delete_CartAdditionalItems(num3);
                for (int m = 0; m <= (int)strArrays12.Length - 1; m++)
                {
                    if (strArrays12[m] != "")
                    {
                        string str3 = strArrays12[m].ToString();
                        chrArray = new char[] { '±' };
                        string[] strArrays13 = str3.Split(chrArray);
                        for (int n = 0; n <= (int)strArrays13.Length - 1; n++)
                        {
                            if (strArrays13[n] != "")
                            {
                                string str4 = strArrays13[n];
                                chrArray = new char[] { '»' };
                                string[] strArrays14 = str4.Split(chrArray);
                                if (strArrays14[0] != "")
                                {
                                    if (strArrays14[0] == "OthercostID")
                                    {
                                        num13 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "Formula")
                                    {
                                        empty1 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "MarkUp")
                                    {
                                        num14 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "TotalPrice")
                                    {
                                        num15 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedID")
                                    {
                                        num16 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SelectedValue")
                                    {
                                        empty2 = strArrays14[1];
                                    }
                                    else if (strArrays14[0] == "SelectedPrice")
                                    {
                                        num18 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "MarkUpValue")
                                    {
                                        num17 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "SortOrderNo")
                                    {
                                        num19 = Convert.ToInt32(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "ParentWebOtherCostID")
                                    {
                                        num20 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (strArrays14[0] == "WebOtherCostType")
                                    {
                                        empty3 = strArrays14[1];
                                    }
                                }
                            }
                        }
                        CartBasePage.Insert_into_CartAdditionalItems(num3, num13, empty1, num14, num15, num16, empty2, num18, num17, num19, num20, empty3);
                    }
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    HttpResponse response = base.Response;
                    keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.KeySeparator, num3, ConnectionClass.KeySeparator, priceCatalogueID, ConnectionClass.FileExtension };
                    response.Redirect(string.Concat(keySeparator));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num3, "&ID=", priceCatalogueID };
                httpResponse.Redirect(string.Concat(keySeparator));
            }
            else
            {
                if (base.Request.Params["type"] != null)
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num21 = (long)0;
                    long num22 = (long)0;
                    string value4 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays15 = value4.Split(chrArray);
                    string uniqueID = string.Empty;
                    decimal num23 = new decimal(0);
                    decimal num24 = new decimal(0);
                    decimal num25 = new decimal(0);
                    for (int o = 0; o <= (int)strArrays15.Length - 1; o++)
                    {
                        if (strArrays15[o] != "")
                        {
                            string str5 = strArrays15[o].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays16 = str5.Split(chrArray);
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
                                    num23 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                                else if (strArrays16[0].ToLower() == "carttax")
                                {
                                    num24 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                                else if (strArrays16[0].ToLower() == "cartshipping")
                                {
                                    num25 = Convert.ToDecimal(strArrays16[1].ToString());
                                }
                            }
                        }
                        if (o == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID = "";
                            }
                            num21 = CartBasePage.Insert_into_Cart(uniqueID, this.StoreUserID, num23, num24, num25,false);
                        }
                    }
                    long defaultMultipleProdId = (long)this.PriceCatalogueID;
                    if (this.hdnDrawStockFrom.Value == "m")
                    {
                        this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                        defaultMultipleProdId = (long)this.DefaultMultipleProdId;
                    }
                    long num26 = (long)0;
                    decimal num27 = new decimal(0);
                    decimal num28 = new decimal(0);
                    decimal num29 = new decimal(0);
                    decimal num30 = new decimal(0);
                    long num31 = (long)0;
                    string value5 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays17 = value5.Split(chrArray);
                    for (int q = 0; q <= (int)strArrays17.Length - 1; q++)
                    {
                        if (strArrays17[q] != "")
                        {
                            num26 = Convert.ToInt64(strArrays17[0]);
                            num27 = Convert.ToDecimal(strArrays17[1]);
                            num28 = Convert.ToDecimal(strArrays17[2]);
                            num30 = Convert.ToDecimal(strArrays17[3]);
                            num29 = Convert.ToDecimal(strArrays17[4]);
                            num31 = Convert.ToInt64(strArrays17[5]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num21, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays18 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName1 = strArrays18[0].ToString();
                            this.ReportFileName1 = strArrays18[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName;
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num21, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays19 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName2 = strArrays19[0].ToString();
                            this.ReportFileName2 = strArrays19[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName;
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num21, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays20 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName3 = strArrays20[0].ToString();
                            this.ReportFileName3 = strArrays20[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName;
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num21, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays21 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName1 = strArrays21[0].ToString();
                            this.ReportFileName1 = strArrays21[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName;
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num21, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays22 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName2 = strArrays22[0].ToString();
                            this.ReportFileName2 = strArrays22[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName;
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num21, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays23 = this.preflight_File(this.FileName, defaultMultipleProdId);
                            this.FileName3 = strArrays23[0].ToString();
                            this.ReportFileName3 = strArrays23[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName;
                        }
                    }
                    num22 = CartBasePage.Insert_into_CartItem_EditableProd(num21, defaultMultipleProdId, "", num26, num27, this.FileName1, this.FileName2, this.FileName3, num28, num29, num30, num31, (long)this.MainProductID, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    long num32 = (long)0;
                    string empty4 = string.Empty;
                    decimal num33 = new decimal(0);
                    decimal num34 = new decimal(0);
                    long num35 = (long)0;
                    decimal num36 = new decimal(0);
                    decimal num37 = new decimal(0);
                    string empty5 = string.Empty;
                    int num38 = 0;
                    long num39 = (long)0;
                    string empty6 = string.Empty;
                    string value6 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays24 = value6.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num22);
                    for (int r = 0; r <= (int)strArrays24.Length - 1; r++)
                    {
                        if (strArrays24[r] != "")
                        {
                            string str6 = strArrays24[r].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays25 = str6.Split(chrArray);
                            for (int s = 0; s <= (int)strArrays25.Length - 1; s++)
                            {
                                if (strArrays25[s] != "")
                                {
                                    string str7 = strArrays25[s];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays26 = str7.Split(chrArray);
                                    if (strArrays26[0] != "")
                                    {
                                        if (strArrays26[0] == "OthercostID")
                                        {
                                            num32 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "Formula")
                                        {
                                            empty4 = strArrays26[1];
                                        }
                                        else if (strArrays26[0] == "MarkUp")
                                        {
                                            num33 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "TotalPrice")
                                        {
                                            num34 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SelectedID")
                                        {
                                            num35 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SelectedValue")
                                        {
                                            empty5 = strArrays26[1];
                                        }
                                        else if (strArrays26[0] == "SelectedPrice")
                                        {
                                            num37 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "MarkUpValue")
                                        {
                                            num36 = Convert.ToDecimal(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "SortOrderNo")
                                        {
                                            num38 = Convert.ToInt32(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "ParentWebOtherCostID")
                                        {
                                            num39 = Convert.ToInt64(strArrays26[1]);
                                        }
                                        else if (strArrays26[0] == "WebOtherCostType")
                                        {
                                            empty6 = strArrays26[1];
                                        }
                                    }
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num22, num32, empty4, num33, num34, num35, empty5, num37, num36, num38, num39, empty6);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response1 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.KeySeparator, num22, ConnectionClass.KeySeparator, defaultMultipleProdId, ConnectionClass.FileExtension };
                        response1.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    HttpResponse httpResponse1 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num22, "&ID=", defaultMultipleProdId };
                    httpResponse1.Redirect(string.Concat(keySeparator));
                    return;
                }
                if (strArrays2[1] != "true")
                {
                    this.pnlNormalDetails.Style.Add("display", "block");
                    this.pnlConfirmPRFile.Style.Add("display", "none");
                    long num40 = (long)0;
                    long num41 = (long)0;
                    string value7 = this.hid_SaveToCart.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays27 = value7.Split(chrArray);
                    string uniqueID1 = string.Empty;
                    decimal num42 = new decimal(0);
                    decimal num43 = new decimal(0);
                    decimal num44 = new decimal(0);
                    for (int t = 0; t <= (int)strArrays27.Length - 1; t++)
                    {
                        if (strArrays27[t] != "")
                        {
                            string str8 = strArrays27[t].ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays28 = str8.Split(chrArray);
                            for (int u = 0; u <= (int)strArrays28.Length - 1; u++)
                            {
                                if (strArrays28[0].ToLower() == "cookieid")
                                {
                                    uniqueID1 = this.comm.UniqueID;
                                }
                                else if (strArrays28[0].ToLower() == "userid")
                                {
                                    Convert.ToInt64(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "carttotalprice")
                                {
                                    num42 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "carttax")
                                {
                                    num43 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                                else if (strArrays28[0].ToLower() == "cartshipping")
                                {
                                    num44 = Convert.ToDecimal(strArrays28[1].ToString());
                                }
                            }
                        }
                        if (t == 4)
                        {
                            if (this.StoreUserID != (long)0)
                            {
                                uniqueID1 = "";
                            }
                            num40 = CartBasePage.Insert_into_Cart(uniqueID1, this.StoreUserID, num42, num43, num44,false);
                        }
                    }
                    long priceCatalogueID1 = (long)this.PriceCatalogueID;
                    if (this.hdnDrawStockFrom.Value == "m")
                    {
                        this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
                        priceCatalogueID1 = (long)this.DefaultMultipleProdId;
                    }
                    long num45 = (long)0;
                    decimal num46 = new decimal(0);
                    decimal num47 = new decimal(0);
                    decimal num48 = new decimal(0);
                    decimal num49 = new decimal(0);
                    long num50 = (long)0;
                    string value8 = this.hid_SaveToCartItems.Value;
                    chrArray = new char[] { '»' };
                    string[] strArrays29 = value8.Split(chrArray);
                    for (int v = 0; v <= (int)strArrays29.Length - 1; v++)
                    {
                        if (strArrays29[v] != "")
                        {
                            num45 = Convert.ToInt64(strArrays29[0]);
                            num46 = Convert.ToDecimal(strArrays29[1]);
                            num47 = Convert.ToDecimal(strArrays29[2]);
                            num49 = Convert.ToDecimal(strArrays29[3]);
                            num48 = Convert.ToDecimal(strArrays29[4]);
                            num50 = Convert.ToInt64(strArrays29[5]);
                        }
                    }
                    if (this.hid_QuestionLenght.Value != "0" || this.hid_MultipleLenght.Value != "0" || this.hid_MatrixLenght.Value != "0")
                    {
                        if (this.fp_artwork.HasFile)
                        {
                            this.artwork_file(this.fp_artwork, num40, 1, "yes", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays30 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays30[0].ToString();
                            this.ReportFileName1 = strArrays30[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork.FileName;
                        }
                        if (this.fp_artwork1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork1, num40, 2, "yes", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays31 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays31[0].ToString();
                            this.ReportFileName2 = strArrays31[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork1.FileName;
                        }
                        if (this.fp_artwork2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork2, num40, 3, "yes", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays32 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays32[0].ToString();
                            this.ReportFileName3 = strArrays32[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork2.FileName;
                        }
                    }
                    else
                    {
                        if (this.fp_artwork_no_addoption1.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption1, num40, 1, "no", out this.FileName);
                            this.FileName1 = this.FileName;
                            string[] strArrays33 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName1 = strArrays33[0].ToString();
                            this.ReportFileName1 = strArrays33[1].ToString();
                            this.OriginalFileName1 = this.fp_artwork_no_addoption1.FileName;
                        }
                        if (this.fp_artwork_no_addoption2.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption2, num40, 2, "no", out this.FileName);
                            this.FileName2 = this.FileName;
                            string[] strArrays34 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName2 = strArrays34[0].ToString();
                            this.ReportFileName2 = strArrays34[1].ToString();
                            this.OriginalFileName2 = this.fp_artwork_no_addoption2.FileName;
                        }
                        if (this.fp_artwork_no_addoption3.HasFile)
                        {
                            this.artwork_file(this.fp_artwork_no_addoption3, num40, 3, "no", out this.FileName);
                            this.FileName3 = this.FileName;
                            string[] strArrays35 = this.preflight_File(this.FileName, priceCatalogueID1);
                            this.FileName3 = strArrays35[0].ToString();
                            this.ReportFileName3 = strArrays35[1].ToString();
                            this.OriginalFileName3 = this.fp_artwork_no_addoption3.FileName;
                        }
                    }
                    num41 = CartBasePage.Insert_into_CartItem_EditableProd(num40, priceCatalogueID1, "", num45, num46, this.FileName1, this.FileName2, this.FileName3, num47, num48, num49, num50, (long)this.MainProductID, this.OriginalFileName1, this.OriginalFileName2, this.OriginalFileName3, this.ReportFileName1, this.ReportFileName2, this.ReportFileName3);
                    long num51 = (long)0;
                    string empty7 = string.Empty;
                    decimal num52 = new decimal(0);
                    decimal num53 = new decimal(0);
                    long num54 = (long)0;
                    decimal num55 = new decimal(0);
                    decimal num56 = new decimal(0);
                    string empty8 = string.Empty;
                    int num57 = 0;
                    long num58 = (long)0;
                    string empty9 = string.Empty;
                    string value9 = this.hid_SaveToAdditionalItems.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays36 = value9.Split(chrArray);
                    CartBasePage.Delete_CartAdditionalItems(num41);
                    for (int w = 0; w <= (int)strArrays36.Length - 1; w++)
                    {
                        if (strArrays36[w] != "")
                        {
                            string str9 = strArrays36[w].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays37 = str9.Split(chrArray);
                            for (int x = 0; x <= (int)strArrays37.Length - 1; x++)
                            {
                                if (strArrays37[x] != "")
                                {
                                    string str10 = strArrays37[x];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays38 = str10.Split(chrArray);
                                    if (strArrays38[0] != "")
                                    {
                                        if (strArrays38[0] == "OthercostID")
                                        {
                                            num51 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "Formula")
                                        {
                                            empty7 = strArrays38[1];
                                        }
                                        else if (strArrays38[0] == "MarkUp")
                                        {
                                            num52 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "TotalPrice")
                                        {
                                            num53 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SelectedID")
                                        {
                                            num54 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SelectedValue")
                                        {
                                            empty8 = strArrays38[1];
                                        }
                                        else if (strArrays38[0] == "SelectedPrice")
                                        {
                                            num56 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "MarkUpValue")
                                        {
                                            num55 = Convert.ToDecimal(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "SortOrderNo")
                                        {
                                            num57 = Convert.ToInt32(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "ParentWebOtherCostID")
                                        {
                                            num58 = Convert.ToInt64(strArrays38[1]);
                                        }
                                        else if (strArrays38[0] == "WebOtherCostType")
                                        {
                                            empty9 = strArrays38[1];
                                        }
                                    }
                                }
                            }
                            CartBasePage.Insert_into_CartAdditionalItems(num41, num51, empty7, num52, num53, num54, empty8, num56, num55, num57, num58, empty9);
                        }
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        HttpResponse response2 = base.Response;
                        keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.KeySeparator, num41, ConnectionClass.KeySeparator, priceCatalogueID1, ConnectionClass.FileExtension };
                        response2.Redirect(string.Concat(keySeparator));
                        return;
                    }
                    HttpResponse httpResponse2 = base.Response;
                    keySeparator = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", num41, "&ID=", priceCatalogueID1 };
                    httpResponse2.Redirect(string.Concat(keySeparator));
                    return;
                }
                if (strArrays2[0] == "1")
                {
                    if (this.searchProducts == "")
                    {
                        this.searchProducts = "0";
                    }
                    this.pnlNormalDetails.Style.Add("display", "none");
                    this.pnlConfirmPRFile.Style.Add("display", "block");
                    this.btn_ConfirmAdd1.Style.Add("display", "block");
                    return;
                }
            }
        }

        protected void ddlProductList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlProductList.SelectedValue.ToLower() == "--select--")
            {
                this.DefaultMultipleProdId = Convert.ToInt32(this.Session["PriceCatalogueID"]);
            }
            else
            {
                this.DefaultMultipleProdId = Convert.ToInt32(this.ddlProductList.SelectedValue.ToString());
            }
            this.Page_Load(null, null);
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
            char[] keySeparator;
            object[] item;
            string[] strArrays;
            int num;
            this.btnAddtoCart.Text = this.objLanguage.GetLanguageConversion("Add_To_Cart");
            this.btnAddtoCart1.Text = this.objLanguage.GetLanguageConversion("Add_To_Cart");
            this.chkconform.Text = this.objLanguage.GetLanguageConversion("Print_ReadyFile_Preview_Confirmation");
            this.pnlStockMessage.Attributes.Add("style", "display:none;");
            if (base.Request.Params["type"] == null)
            {
                this.RequestType = "1";
            }
            else if (base.Request.Params["type"].ToString() == "0")
            {
                this.RequestType = "1";
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:setHeight();", true);
            string str = "normal";
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
            if (this.MeasurementValue != "In.")
            {
                this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareMeter");
            }
            else
            {
                this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareFeet");
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(this.CompanyID);
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
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["ID"] != null)
                {
                    this.PriceCatalogueID = Convert.ToInt32(base.Request.Params["ID"]);
                }
                if (base.Request.Params["type"] != null)
                {
                    this.searchProducts = base.Request.Params["type"].ToString();
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
            this.Session["PriceCatalogueID"] = this.PriceCatalogueID;
            if ((this.searchProducts != "" || this.searchProducts != null) && this.searchProducts == "1" && base.Request.Cookies["spcookie"] != null)
            {
                this.searchCookie = base.Request.Cookies["spcookie"].Value.ToString();
                this.navigation_div.Style.Add("display", "none");
                this.href_Searchproduct.Text = "Product Search";
                this.div_searchProduct.Style.Add("display", "block");
            }
            this.AccountType = this.comm.return_AccountType((long)this.CompanyID, productdetails.AccountID);
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                if (this.comm.GetDisplayValue("IsHome", productdetails.AccountID) != "true")
                {
                    this.lbl_home.Visible = false;
                    this.lbl_spliter.Visible = false;
                }
                else
                {
                    this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(productdetails.AccountID), 0);
                    this.lbl_home.Visible = true;
                    this.lbl_spliter.Visible = true;
                }
            }
            else if (this.AccountType != "x")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else if (this.comm.GetDisplayValue("IsHome", productdetails.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(productdetails.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.Session["StoreUserID"] == null && this.AccountType.ToLower() == "p" || this.CompanyID == 0 && productdetails.AccountID == (long)0)
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
            int num1 = 0;
            foreach (DataRow row in CMSBasePage.Select_BannerImages(productdetails.AccountID, 0, "R", "ProductDetails").Rows)
            {
                if (num1 == 0)
                {
                    this.plhRightBanner.Controls.Add(new LiteralControl("<div>"));
                }
                item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", row["bannerImage"], "&amp;type=b&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                string str2 = string.Concat(item);
                if (row["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhRightBanner.Controls;
                    item = new object[] { "<div><img src='", str2, "' alt='", row["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(item)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhRightBanner.Controls;
                    item = new object[] { "<div><a href='", row["URL"], "'><img src='", str2, "' alt='", row["bannerTitle"], "' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item)));
                }
                num1++;
            }
            if (num1 != 0)
            {
                this.plhRightBanner.Controls.Add(new LiteralControl("</div>"));
            }
            this.SesseionKey = this.comm.UniqueID;
            bool flag = false;
            this.hdnPriceCatalogueID.Value = this.PriceCatalogueID.ToString();
            this.hdnPriceCatalogueID.Value = this.PriceCatalogueID.ToString();
            DataTable dataTable = ProductBasePage.productsDetails_Select(this.PriceCatalogueID);
            if (dataTable.Rows.Count > 0)
            {
                this.hdnStockManagement.Value = dataTable.Rows[0]["ProductStockManagement"].ToString().ToLower();
                this.hdnIsShowStock.Value = dataTable.Rows[0]["IsShowStock"].ToString().ToLower();
                flag = Convert.ToBoolean(dataTable.Rows[0]["IsShowStock"].ToString());
                this.hdnDrawStockFrom.Value = dataTable.Rows[0]["DrawStockFrom"].ToString().Trim().ToLower();
            }
            if (!base.IsPostBack && this.hdnStockManagement.Value == "true" && this.hdnDrawStockFrom.Value.Trim().ToLower() == "m")
            {
                this.BindOtherMultipleDropdownList((long)this.PriceCatalogueID);
                DataTable dataTable1 = ProductBasePage.OtherMultiple_Default_Select((long)this.PriceCatalogueID);
                if (dataTable1.Rows.Count == 0)
                {
                    this.ddlProductList.Items.Insert(0, "--Select--");
                    this.div_ProductOptions.Style.Add("display", "block");
                    this.DefaultMultipleProdId = this.PriceCatalogueID;
                }
                if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["KitItemID"] != null)
                {
                    this.DefaultMultipleProdId = Convert.ToInt16(dataTable1.Rows[0]["KitItemID"]);
                    this.objBc.SetDDLValue(this.ddlProductList, dataTable1.Rows[0]["KitItemID"].ToString());
                    this.div_ProductOptions.Style.Add("display", "block");
                }
            }
            if (this.hdnDrawStockFrom.Value.Trim().ToLower() != "m")
            {
                this.DefaultMultipleProdId = this.PriceCatalogueID;
            }
            if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "m")
            {
                if (this.DefaultMultipleProdId == this.PriceCatalogueID)
                {
                    this.Spn_PrdoMandatory.Style.Add("visibility", "visible");
                    this.lblSubProductName.Visible = false;
                }
                else
                {
                    this.Spn_PrdoMandatory.Style.Add("visibility", "hidden");
                    this.lblSubProductName.Visible = true;
                }
            }
            this.RightPanelCalc_Enabled = ProductBasePage.IsRightPanelCalc_Enabled(productdetails.AccountID);
            if (this.DefaultMultipleProdId != 0)
            {
                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                {
                    this.AddBtn_Style = "margin-left: 5%;";
                    this.plhFirst.Controls.Add(new LiteralControl("<table class='MainTable' style='margin: 0;'><tr><td valign='top' id='leftPanel_td_div'><div id='leftPanel_div'><div id='leftPanel' style='width: 100%;'>"));
                    this.plh_innertable_starting.Controls.Add(new LiteralControl("<div class='table'><div class='row'><div class='col-lg-12 col-xs-7 productDet_left_Img_div'>"));
                    this.plh_innertable_middle_tds.Controls.Add(new LiteralControl("</div><div class='col-lg-12' valign='top'>"));
                    this.plh_Contents.Controls.Add(new LiteralControl("<div id='contents' class='contents'>"));
                    this.plh_above_div_PriceStartFrom.Controls.Add(new LiteralControl(""));
                    this.plh_below_div_Below_desc.Controls.Add(new LiteralControl("</div></div></div></div></div></div></td><td valign='top'>"));
                    this.plhLast.Controls.Add(new LiteralControl("</td></tr></table>"));
                }
                else
                {
                    this.plhFirst.Controls.Add(new LiteralControl("<div id='divRightPanelCalcMain'><table class='MainTable' style='margin: 0;'><tr><td valign='top' id='leftPanel_td_div'><div id='leftPanel_div'><div id='leftPanel' style='width: 100%;'>"));
                    this.plh_innertable_starting.Controls.Add(new LiteralControl("<table><tr><td class='productDet_left_Img_div'>"));
                    this.plh_innertable_middle_tds.Controls.Add(new LiteralControl("</td><td valign='top'>"));
                    this.plh_Contents.Controls.Add(new LiteralControl("<div id='contents' class='contents'>"));
                    this.plh_above_div_PriceStartFrom.Controls.Add(new LiteralControl("</div></td></tr></table></div></div></td><td valign='top'><div class='RightPanel_New'>"));
                    this.plh_below_div_Below_desc.Controls.Add(new LiteralControl("</div><div class='displayNone'>"));
                    this.plhLast.Controls.Add(new LiteralControl("</div></td></tr></table></div>"));
                }
            }
            if (this.hdnDrawStockFrom.Value != "m")
            {
                this.CopiedPriceCatalogueId = this.PriceCatalogueID;
            }
            else
            {
                this.CopiedPriceCatalogueId = this.DefaultMultipleProdId;
                this.MainProductID = this.PriceCatalogueID;
            }
            if (this.CopiedPriceCatalogueId != 0)
            {
                if (dataTable.Rows.Count > 0)
                {
                    this.CatalogueName = dataTable.Rows[0]["CatalogueName"].ToString();
                }
                this.lbl_CatalogueName2.Text = base.SpecialDecode(this.CatalogueName);
                this.lbl_CatalogueName2_2.Text = base.SpecialDecode(this.CatalogueName);
                this.lbl_CatalogueName3.Text = string.Concat("Select the ", this.CatalogueName);
                this.lbl_CatalogueName1.Text = base.SpecialDecode(this.CatalogueName);
                DataTable dataTable2 = ProductBasePage.productsDetails_Select(this.CopiedPriceCatalogueId);
                if (dataTable2.Rows.Count <= 0)
                {
                    HttpResponse response = base.Response;
                    item = new object[] { this.strSitepath, "products", this.KeySeparator, 0, this.FileExtension };
                    response.Redirect(string.Concat(item));
                }
                else
                {
                    foreach (DataRow dataRow in dataTable2.Rows)
                    {
                        this.ProductTaxId = Convert.ToInt32(dataRow["SalesTaxRate"]);
                        this.ProductTaxName = dataRow["TaxName"].ToString();
                        this.ProductTaxRate = Convert.ToDecimal(dataRow["TaxRate"]);
                        this.isDisplayAdditionalOption = Convert.ToBoolean(dataRow["IsDisplayAdditionalOptions"]); //modification
                        if (this.hdnDrawStockFrom.Value != "m")
                        {
                            this.lblSubProductName.Visible = false;
                        }
                        else
                        {
                            this.lblSubProductName.Text = base.SpecialDecode(dataRow["CatalogueName"].ToString());
                        }
                        string empty = string.Empty;
                        StringBuilder stringBuilder = new StringBuilder();
                        if (dataRow["ItemDesc"].ToString() == "")
                        {
                            this.lbl_Description.Text = "";
                            this.lbl_Description_2.Text = "";
                        }
                        else
                        {
                            this.lbl_Description.Text = base.SpecialDecode(dataRow["ItemDesc"].ToString());
                            this.lbl_Description_2.Text = base.SpecialDecode(dataRow["ItemDesc"].ToString());
                        }
                        if (!Convert.ToBoolean(dataRow["IsItemDescription"]))
                        {
                            this.lbl_Description.Visible = false;
                            this.lbl_Description_2.Visible = false;
                        }
                        else
                        {
                            this.lbl_Description.Visible = true;
                            this.lbl_Description_2.Visible = true;
                        }
                        this.artworkFile = dataRow["ArtworkFile"].ToString();
                        this.PriceCatalogueCategoryID = Convert.ToInt32(dataRow["PriceCatalogueCategoryID"].ToString());
                        this.PriceCatalogueCategoryName = dataRow["PriceCatalogueCategoryName"].ToString();
                        this.lbl_nav_product.Text = base.SpecialDecode(this.PriceCatalogueCategoryName);
                        this.lbl_nav_productName.Text = base.SpecialDecode(this.CatalogueName);
                        this.lbl_Searchproduct.Text = base.SpecialDecode(this.CatalogueName);
                        this.PrintReadyFile = dataRow["PrintReadyFile"].ToString();
                        this.IsPriceList = Convert.ToInt32(dataRow["IsPriceList"]);
                        if (Convert.ToBoolean(dataRow["IsPrintReadyFile"]) && this.PrintReadyFile != "")
                        {
                            item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", this.PrintReadyFile, "&amp;type=pr&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                            string str3 = string.Concat(item);
                            item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=pdf-icon.png&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                            string str4 = string.Concat(item);
                            this.div_PrintReadyFile.Attributes.Add("style", "padding: 0px 0px 10px 15px; display:block;");
                            if (ConnectionClass.SystemName.ToLower() == "ppw")
                            {
                                System.Web.UI.WebControls.Label label = this.lblPrintReadyFile;
                                strArrays = new string[] { "<div class='floatLeft'><img src='", str4, "' alt=' '/></div><div class='print_readyFile_lbl_Div'><a href='", str3, "' target='_blank'>Click here to download a line drawing PDF</a></div>" };
                                label.Text = string.Concat(strArrays);
                            }
                            else if (ConnectionClass.ServerName.ToLower() == "creativeatlanta" || ConnectionClass.ServerName.ToLower() == "creativeapproach")
                            {
                                System.Web.UI.WebControls.Label label1 = this.lblPrintReadyFile;
                                strArrays = new string[] { "<div class='floatLeft'><img src='", str4, "' alt=' '/></div><div class='print_readyFile_lbl_Div'><a style='margin-left:-40px;'  href='", str3, "' target='_blank'>Template / Print Ready Requirement</a></div>" };
                                label1.Text = string.Concat(strArrays);
                            }
                            else
                            {
                                System.Web.UI.WebControls.Label label2 = this.lblPrintReadyFile;
                                strArrays = new string[] { "<div class='floatLeft'><img src='", str4, "' alt=' '/></div><div class='print_readyFile_lbl_Div'><a class='Print_Ready_File_link' href='", str3, "' target='_blank'>Print Ready File</a></div>" };
                                label2.Text = string.Concat(strArrays);

                                System.Web.UI.WebControls.Label label3 = this.lblPrintReadyFile_2;
                                strArrays = new string[] { "<div class='floatLeft'><img src='", str4, "' alt=' '/></div><div class='print_readyFile_lbl_Div'><a class='Print_Ready_File_link' href='", str3, "' target='_blank'>Print Ready File</a></div>" };
                                label3.Text = string.Concat(strArrays);
                            }
                        }
                        this.artwork_div.Style.Add("display", "block");
                        this.artwork_div_no_addoption.Style.Add("display", "block");
                        this.fp_artwork1.Visible = true;
                        this.fp_artwork2.Visible = true;
                        this.fp_artwork_no_addoption2.Visible = true;
                        this.fp_artwork_no_addoption3.Visible = true;
                        if (this.artworkFile.ToLower().Trim() == "n")
                        {
                            this.artwork_div.Style.Add("display", "none");
                            this.artwork_div_no_addoption.Style.Add("display", "none");
                        }
                        if (this.artworkFile.ToLower().Trim() == "m" || this.artworkFile.ToLower().Trim() == "y")
                        {
                            this.Label1.Text = this.objLanguage.GetLanguageConversion("Upload_your_artwork_file");
                            this.lblupload.Text = this.objLanguage.GetLanguageConversion("Upload_your_artwork_file");
                        }
                        if (Convert.ToInt32(dataRow["ArtworkCount"].ToString()) == 1)
                        {
                            this.fp_artwork1.Visible = false;
                            this.fp_artwork2.Visible = false;
                            this.fp_artwork_no_addoption2.Visible = false;
                            this.fp_artwork_no_addoption3.Visible = false;
                        }
                        else if (Convert.ToInt32(dataRow["ArtworkCount"].ToString()) == 2)
                        {
                            this.fp_artwork2.Visible = false;
                            this.fp_artwork_no_addoption3.Visible = false;
                        }
                        productdetails.thumbImg = dataRow["ProductImage"].ToString();
                        this.hid_matixType.Value = dataRow["MatrixType"].ToString();
                        this.Session["IsEditableProduct"] = dataRow["IsEditableProduct"].ToString();
                        item = new object[] { ConnectionClass.SecureSitePath, this.ServerName, "/", this.CompanyID, "/Product/PrintReady/", dataRow["PrintReadyFile"].ToString() };
                        this.PrintReadyFilePath_Verify = string.Concat(item);
                        if (dataRow["PrintReadyFile"].ToString() == "")
                        {
                            this.hdnPrintReadyFile.Value = "0,false,false";
                        }
                        else
                        {
                            this.hdnPrintReadyFile.Value = string.Concat("1,", dataRow["IsPrintReadyFile"].ToString().Trim().ToLower(), ",", dataRow["ForcePrintReadyFile"].ToString().Trim().ToLower());
                        }
                        if (Convert.ToBoolean(dataRow["IsShowSoldInPacksOf"]).ToString().Trim().ToLower() == "true")
                        {
                            this.div_soldinpack.Style.Add("display", "block");
                        }
                        this.hdnStockManagement.Value = dataRow["ProductStockManagement"].ToString().ToLower();
                        this.hdnIsShowStock.Value = dataRow["IsShowStock"].ToString().ToLower();
                        flag = Convert.ToBoolean(dataRow["IsShowStock"].ToString());
                        this.hdnDrawStockFrom.Value = dataRow["DrawStockFrom"].ToString().Trim().ToLower();
                        this.hdnIsBackOrder.Value = dataRow["IsBackOrder"].ToString().Trim().ToLower();
                        this.hdnAvailableQty.Value = dataRow["AvailableQuantity"].ToString();
                        this.hdnShowPriceSubtotalTax.Value = dataRow["IsShowPriceSubTotalTax"].ToString();
                        this.hdnShowUnitPrice.Value = dataRow["IsShowUnitPrice"].ToString();
                        this.hdnShowPackPrice.Value = dataRow["IsShowPackedPrice"].ToString();

                        this.hdnIsStockItem.Value = dataRow["IsStockItem"].ToString();
                        if (dataRow["AvailableQuantity"].ToString() != "0" && dataRow["AvailableQuantity"].ToString() != "")
                        {
                            this.AvailableQuantity = Convert.ToInt32(dataRow["AvailableQuantity"].ToString());
                        }
                        if (Convert.ToBoolean(dataRow["isCustomerCode"]) && dataRow["CustomerCode"].ToString() != "")
                        {
                            this.isCustomerCode = true;
                            this.lblCustomerCode.Text = base.SpecialDecode(dataRow["CustomerCode"].ToString());
                        }
                        if (Convert.ToBoolean(dataRow["isItemCode"]) && dataRow["ItemCode"].ToString() != "")
                        {
                            this.isItemCode = true;
                            this.lblItemCode.Text = base.SpecialDecode(dataRow["ItemCode"].ToString());
                        }
                        if (!Convert.ToBoolean(dataRow["IsCumulativePricing"]))
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
                string str5 = productdetails.thumbImg.ToString().Trim();
                keySeparator = new char[] { '.' };
                string[] strArrays1 = str5.Split(keySeparator);
                string str6 = strArrays1[(int)strArrays1.Length - 1].ToString().ToLower().Trim();
                if (productdetails.thumbImg == "")
                {
                    HtmlImage htmlImage = this.cards;
                    item = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=m_no_image_available.png&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlImage.Src = string.Concat(item);
                    this.cards.Alt = " ";
                    HtmlAnchor htmlAnchor = this.cards1;
                    item = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=m_no_image_available.png&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlAnchor.HRef = string.Concat(item);
                    if (this.MainProductID != 0)
                    {
                        this.cards1.Title = "";
                    }
                }
                else
                {
                    HtmlImage htmlImage1 = this.cards;
                    item = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", productdetails.thumbImg.ToString(), "&amp;type=p&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlImage1.Src = string.Concat(item);
                    this.cards.Alt = " ";
                    HtmlAnchor htmlAnchor1 = this.cards1;
                    item = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", empty1.ToString(), "&amp;type=p&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID };
                    htmlAnchor1.HRef = string.Concat(item);
                    this.cards1.Title = this.CatalogueName;
                    if (this.MainProductID != 0)
                    {
                        this.cards1.Title = this.lblSubProductName.Text;
                    }
                    if (str6.ToLower() == "gif")
                    {
                        item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\", productdetails.thumbImg.ToString() };
                        System.Drawing.Image image = System.Drawing.Image.FromFile(string.Concat(item));
                        FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
                        int frameCount = image.GetFrameCount(frameDimension);
                        int num2 = 200;
                        int num3 = 150;
                        if (image.Width < 200 && image.Height < 150)
                        {
                            num2 = Convert.ToInt32(image.Width);
                            num3 = Convert.ToInt32(image.Height);
                        }
                        if (frameCount > 0)
                        {
                            this.cards.Width = num2;
                            this.cards.Height = num3;
                        }
                    }
                }
                this.Product_list(this.hid_matixType.Value, (long)this.CopiedPriceCatalogueId, this.plhPriceList, "hidemore", 1);
                this.Product_list(this.hid_matixType.Value, (long)this.CopiedPriceCatalogueId, this.plhPriceListMore, "viewmore", 6);
                if (this.IsPriceList != 1)
                {
                    this.div_ProductPriceList.Style.Add("display", "none");
                }
                else
                {
                    this.div_ProductPriceList.Style.Add("display", "block");
                }
                DataTable dataTable3 = ProductBasePage.Select_OtherCostAdditional_ItemsIDs((long)this.CopiedPriceCatalogueId);
                string empty2 = string.Empty;
                if (dataTable3.Rows.Count > 0)
                {
                    empty2 = "yes";
                }
                if (dataTable2.Rows.Count <= 0)
                {
                    this.lbl_ShowSoldInPacksOf.Visible = false;
                    this.lbl_ShowSoldInPacksOf1.Visible = false;
                }
                else if (!Convert.ToBoolean(dataTable2.Rows[0]["IsShowSoldInPacksOf"]) || Convert.ToInt32(dataTable2.Rows[0]["SoldInPacksOf"]) == 0)
                {
                    this.lbl_ShowSoldInPacksOf.Visible = false;
                    this.lbl_ShowSoldInPacksOf1.Visible = false;
                }
                else
                {
                    this.lbl_ShowSoldInPacksOf.Text = this.objLanguage.GetLanguageConversion("Sold_in_Packs_of");
                    this.lbl_ShowSoldInPacksOf1.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataTable2.Rows[0]["SoldInPacksOf"].ToString()), 2, "", false, false, true));
                }
                if (str != "outofstock")
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left_qty'>"));
                    if (this.hid_matixType.Value == "P")
                    {
                        if (this.isQuantity != "1")
                        {
                            ControlCollection controls1 = this.plhquantity.Controls;
                            item = new object[] { "<div class='displayNone' id='qty_div'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), "  </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controls1.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty displayNone'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  margin:0px 5px 0px 0px  display: none;' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  display: none;' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                        else
                        {
                            ControlCollection controlCollections1 = this.plhquantity.Controls;
                            item = new object[] { "<div id='qty_div'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                    }
                    else if (this.hid_matixType.Value == "G")
                    {
                        if (this.isQuantity != "1")
                        {
                            ControlCollection controls2 = this.plhquantity.Controls;
                            item = new object[] { "<div class='displayNone' id='qty_div'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), "  </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controls2.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty displayNone'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  margin:0px 5px 0px 0px  display: none;' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  display: none;' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                        else
                        {
                            ControlCollection controlCollections2 = this.plhquantity.Controls;
                            item = new object[] { "<div id='qty_div'><label>", this.objLanguage.GetLanguageConversion("Enter_Quantity_To_Order"), " </label><span id='starspan' class='mandatoryField'>", '*', " </span> </div>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty'>"));
                            if (this.artworkFile.ToLower().Trim() != "n")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text'  class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' class='txtStyle'   onblur='javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);CheckIsDecimal(this.value);' maxlength='8'/>"));
                            }
                        }
                    }
                    else if (this.isQuantity != "1")
                    {
                        this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='qty_div' class='displayNone'><label>Select quantity to order </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>")));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty displayNone'>"));
                        if (!this.IsCumulative)
                        {
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0'); CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                            this.ddlPriceQty.Style.Add("display", "none");
                            DataTable dataTable4 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                            this.SimpleMatrix_DropDownBind(dataTable4, this.ddlPriceQty, this.plhquantity);
                        }
                        else
                        {
                            this.txt_Cumulative_PriceQty.ID = "txt_Cumulative_PriceQty";
                            this.txt_Cumulative_PriceQty.CssClass = "txtStyle";
                            this.txt_Cumulative_PriceQty.Attributes.Add("onblur", "javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value)");
                            this.txt_Cumulative_PriceQty.Attributes.Add("onkeyup", "javascript:Tocalculate_totalPrice(this.value); CheckIsDecimal_Textbox(this,this.value);");
                            this.txt_Cumulative_PriceQty.Attributes.Add("maxlength", "8");
                            this.plhquantity.Controls.Add(this.txt_Cumulative_PriceQty);
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0'); CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                            DataTable dataTable5 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                            this.SimpleMatrix_DropDownBind(dataTable5, this.ddlPriceQty, this.plhquantity);
                        }
                    }
                    else
                    {
                        this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='qty_div'><label>Select quantity to order </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>")));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        if (this.RightPanelCalc_Enabled.ToLower() == "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty'>"));
                        }
                        else if (empty2.ToLower() != "yes")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content_right_qty marginLeft10'>"));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right_qty marginLeft2'>"));
                        }
                        if (!this.IsCumulative)
                        {
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');  CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                            DataTable dataTable6 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                            this.SimpleMatrix_DropDownBind(dataTable6, this.ddlPriceQty, this.plhquantity);
                            if (this.RightPanelCalc_Enabled.ToLower() != "true")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else
                        {
                            this.txt_Cumulative_PriceQty.ID = "txt_Cumulative_PriceQty";
                            this.txt_Cumulative_PriceQty.CssClass = "txtStyle";
                            this.txt_Cumulative_PriceQty.Attributes.Add("onblur", "javascript:Tocalculate_totalPrice(this.value); CheckStockAvailability(this.value)");
                            this.txt_Cumulative_PriceQty.Attributes.Add("onkeyup", "javascript:Tocalculate_totalPrice(this.value); CheckIsDecimal_Textbox(this,this.value);");
                            this.txt_Cumulative_PriceQty.Attributes.Add("maxlength", "8");
                            this.plhquantity.Controls.Add(this.txt_Cumulative_PriceQty);
                            this.ddlPriceQty.ID = "ddlPriceQty";
                            this.ddlPriceQty.CssClass = "dropDownMultiple75";
                            this.ddlPriceQty.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');  CheckStockAvailability('0')");
                            this.ddlPriceQty.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                            this.ddlPriceQty.Style.Add("display", "none");
                            DataTable dataTable7 = ProductBasePage.Product_CatalogueQty_Select((long)this.CopiedPriceCatalogueId);
                            this.SimpleMatrix_DropDownBind(dataTable7, this.ddlPriceQty, this.plhquantity);
                            if (this.RightPanelCalc_Enabled.ToLower() != "true")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                    this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty' class='Plz_Enter_Qty_MsgDiv' style='width: auto;'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_Quantity"), "</span></div>")));
                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                    {
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    }
                    if (this.hid_matixType.Value == "G" && this.isQuantity == "1")
                    {
                        string empty3 = string.Empty;
                        string empty4 = string.Empty;
                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div>"));
                            ControlCollection controls3 = this.plhquantity.Controls;
                            item = new object[] { "<div id='divDimension' class='floatLeft' style='padding-top:10px;margin-left: 10px;'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controls3.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<table style='margin-top:8px; margin-right: 10px;'>"));
                            empty3 = "style='width:45px;'";
                            empty4 = "style='width:45px;'";
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                            ControlCollection controlCollections3 = this.plhquantity.Controls;
                            item = new object[] { "<div id='divDimension' class='floatLeft' style='margin-top: 5px;'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label><span id='starspan' class='mandatoryField'>", '*', " </span></div>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(item)));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='floatRight'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<table style='margin-top:-1px;'>"));
                            empty3 = "style='width:109px;'";
                            empty4 = "style='width:108px;'";
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("<tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divWidth' class='lblWidthHeight'><label>", this.objLanguage.GetLanguageConversion("Width"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls4 = this.plhquantity.Controls;
                        item = new object[] { "<input id='txtWidth' type='text' class='txtStyle' ", empty3, " onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' />" };
                        controls4.Add(new LiteralControl(string.Concat(item)));
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
                        ControlCollection controlCollections4 = this.plhquantity.Controls;
                        item = new object[] { "<input id='txtHeight' type='text' class='txtStyle' ", empty4, " onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(item)));
                        if (this.RightPanelCalc_Enabled.ToLower() == "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='lblWidthHeight2'><label>", this.objLanguage.GetLanguageConversion("Height"), " </label></div>")));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</table>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        if (this.RightPanelCalc_Enabled.ToLower() != "true")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div><div class='floatRight width300px'>"));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div><div>"));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_Dimensn'><span id='spnDimensn'>", this.objLanguage.GetLanguageConversion("Please_enter_dimension"), " </span></div>")));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    }
                    int num4 = 0;
                    int num5 = 0;
                    int num6 = 0;
                    int num7 = 0;
                    int length = 0;
                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                    string empty5 = string.Empty;
                    foreach (DataRow row1 in dataTable3.Rows)
                    {
                        DataSet dataSet = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(row1["WebOtherCostID"].ToString()));
                        DataTable item1 = dataSet.Tables[0];
                        DataTable item2 = dataSet.Tables[1];
                        long num8 = Convert.ToInt64(row1["WebOtherCostID"].ToString());
                        long num9 = Convert.ToInt64(row1["AdditionalGroupID"].ToString());
                        int num10 = Convert.ToInt32(row1["IsStockAddType"]);
                        num7++;
                        string empty6 = string.Empty;
                        string empty7 = string.Empty;
                        foreach (DataRow dataRow1 in item1.Rows)
                        {
                            if (this.RightPanelCalc_Enabled.ToLower() == "true")
                            {
                                this.price_calculator_Style = "width: 102.7%; padding-top: 5px;";
                            }
                            this.MainCalculationtype = dataRow1["MainCalculationType"].ToString();
                            if (this.MainCalculationtype.ToLower() == "c")
                            {
                                num = Convert.ToInt32(dataRow1["IsCartMandatory"]);
                                empty7 = num.ToString();
                            }
                            this.HelpText = dataRow1["Description"].ToString().Replace("\n", "<br>");
                            this.OtherCostName = dataRow1["UserFriendlyName"].ToString();
                        }
                        int num11 = 0;
                        if (num9 == (long)0)
                        {
                            empty6 = "1";
                        }
                        else if (empty5 == "")
                        {
                            empty6 = "1";
                        }
                        else
                        {
                            keySeparator = new char[] { '±' };
                            string[] strArrays2 = empty5.Split(keySeparator);
                            for (int i = 0; i < (int)strArrays2.Length - 1; i++)
                            {
                                if (strArrays2[i] == "")
                                {
                                    empty6 = "1";
                                }
                                else
                                {
                                    empty6 = (num9 == (long)0 || Convert.ToInt64(strArrays2[i]) != num9 ? "1" : "0");
                                }
                            }
                        }
                        empty5 = string.Concat(empty5, row1["AdditionalGroupID"].ToString(), "±");
                        foreach (DataRow row2 in item2.Rows)
                        {
                            if (this.MainCalculationtype.ToLower() == "q")
                            {
                                string str7 = row2["formula"].ToString();
                                string str8 = row2["Question"].ToString();
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content'>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_with_AutoHeight'>"));
                                ControlCollection controls5 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<label id='lblQuestion_", num4, "' > ", base.SpecialDecode(this.OtherCostName), "<br/>", base.SpecialDecode(str8), "</label>" };
                                controls5.Add(new LiteralControl(string.Concat(item)));
                                if (this.HelpText != "")
                                {
                                    this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='#' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections5 = this.plhPriceCalculator.Controls;
                                    item = new object[] { "<img id='img_help_", num4, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:18px;' class='cart_details_HelpTextImage' /></a>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(item)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right marginLeft15'>"));
                                ControlCollection controls6 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<input id='txtQuestion_", num4, "' grpvalue='", empty6, "'  onkeyup='ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                                controls6.Add(new LiteralControl(string.Concat(item)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                }
                                else
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin-top: -4px;'>"));
                                }
                                ControlCollection controlCollections6 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<label id='lblPrice_", num4, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00 </label><label id='lblQuestionID_", num4, "' class='displayNone'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num4, "' class='displayNone'>", str7, " </label><label id='lblQuestionGroupID_", num4, "' class='displayNone'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num4, "' class='displayNone'>", num7, "</label>" };
                                controlCollections6.Add(new LiteralControl(string.Concat(item)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                num4++;
                            }
                            else if (this.MainCalculationtype.ToLower() == "c")
                            {
                                if (num11 == 0)
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                       this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content'>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content' style='margin-top: -5px;'>"));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                                    ControlCollection controls7 = this.plhPriceCalculator.Controls;
                                    item = new object[] { "<input id='chkMultiple_", num5, "' class='displayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num5, ");'/>" };
                                    controls7.Add(new LiteralControl(string.Concat(item)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_with_AutoHeight'>"));
                                    if (empty7 != "1")
                                    {
                                        ControlCollection controlCollections7 = this.plhPriceCalculator.Controls;
                                        item = new object[] { "<label id='lblMatrixName_", num5, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                        controlCollections7.Add(new LiteralControl(string.Concat(item)));
                                    }
                                    else
                                    {
                                        ControlCollection controls8 = this.plhPriceCalculator.Controls;
                                        item = new object[] { "<label id='lblMatrixName_", num5, "' > ", base.SpecialDecode(this.OtherCostName), "<span style='color:red'> *</span></label>" };
                                        controls8.Add(new LiteralControl(string.Concat(item)));
                                    }
                                    if (this.HelpText != "")
                                    {
                                        this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='#' class='tooltip' title='", this.HelpText, "'>")));
                                        ControlCollection controlCollections8 = this.plhPriceCalculator.Controls;
                                        item = new object[] { "<img id='img_help_", num11, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:18px;' class='cart_details_HelpTextImage' /></a>" };
                                        controlCollections8.Add(new LiteralControl(string.Concat(item)));
                                    }
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    if (length <= 80)
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                                    }
                                    else
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right marginLeft15'>"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num5),
                                        CssClass = "dropDownMultiple150"
                                    };
                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                    {
                                        dropDownList.Width = 300;
                                    }
                                    if (row2["CalculationType"].ToString().ToLower().Trim() != "groups")
                                    {
                                        if (num10 != 1)
                                        {
                                            AttributeCollection attributes = dropDownList.Attributes;
                                            item = new object[] { "javascript:ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();" };
                                            attributes.Add("onchange", string.Concat(item));
                                        }
                                        else
                                        {
                                            AttributeCollection attributeCollection = dropDownList.Attributes;
                                            item = new object[] { "javascript:CheckAddOptStockAvailability(this.id,", num8, ");ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();" };
                                            attributeCollection.Add("onchange", string.Concat(item));
                                            this.hdnWebOtherCostID.Value = num8.ToString();
                                            this.hdnStockAddOption.Value = dropDownList.ClientID;
                                        }
                                        dropDownList.Attributes.Add("IsMandatory", empty7);
                                        dropDownList.Attributes.Add("grpvalue", empty6);
                                    }
                                    else
                                    {
                                        AttributeCollection attributes1 = dropDownList.Attributes;
                                        item = new object[] { "javascript: VisibleAdditionaloption('", num8, "');ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();" };
                                        attributes1.Add("onchange", string.Concat(item));
                                        dropDownList.Attributes.Add("isgroup", "maingroup");
                                        dropDownList.Attributes.Add("IsMandatory", empty7);
                                        dropDownList.Attributes.Add("grpvalue", empty6);
                                        dropDownList.Attributes.Add("WeotherCostID", row1["WebOtherCostID"].ToString());
                                    }
                                    this.comm.MultipleChoice_DropDownBind(item2, dropDownList, this.plhPriceCalculator, row2["CalculationType"].ToString());
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    if (this.isDisplayAdditionalOption) //modification
                                    {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='display:none;'>"));
                                    }
                                    else {
                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                    }
                                    //this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                    ControlCollection controls9 = this.plhPriceCalculator.Controls;
                                    item = new object[] { "<label id='lblMultipleID_", num5, "' class='displayNone'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num5, "' class='displayNone'></label><label id='lblMultipleMarkup_", num5, "' class='displayNone'></label><label id='lblMultiplePrice_", num5, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num5, "' class='displayNone'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num5, "' class='displayNone'>", num7, "</label>" };
                                    controls9.Add(new LiteralControl(string.Concat(item)));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                    DataTable dataTable8 = new DataTable();
                                    DataSet dataSet1 = new DataSet();
                                    DataTable item3 = new DataTable();
                                    DataTable item4 = new DataTable();
                                    string empty8 = string.Empty;
                                    int length1 = 0;
                                    if (row2["CalculationType"].ToString().ToLower().Trim() == "groups")
                                    {
                                        for (int j = 0; j < item2.Rows.Count; j++)
                                        {
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<div style='display:none;' id='div_SubAdditionalsddl_", Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), "'>")));
                                            dataTable8 = ProductBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), Convert.ToInt32(row1["WebOtherCostID"].ToString()));
                                            if (dataTable8.Rows.Count > 0 && Convert.ToInt64(dataTable8.Rows[0]["GroupID"]) != (long)0)
                                            {
                                                for (int k = 0; k < dataTable8.Rows.Count; k++)
                                                {
                                                    num7++;
                                                    dataSet1 = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataTable8.Rows[k]["WebOtherCostID"].ToString()));
                                                    item3 = dataSet1.Tables[0];
                                                    item4 = dataSet1.Tables[1];
                                                    IEnumerator enumerator = item3.Rows.GetEnumerator();
                                                    try
                                                    {
                                                        if (enumerator.MoveNext())
                                                        {
                                                            DataRow current = (DataRow)enumerator.Current;
                                                            num = Convert.ToInt32(current["IsCartmandatory"]);
                                                            empty8 = num.ToString();
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
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content'>"));
                                                    }
                                                    else
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content' style='margin-top: -5px;'>"));
                                                    }
                                                    length1 = item3.Rows[0]["UserFriendlyName"].ToString().Trim().Length;
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_with_AutoHeight'>"));
                                                    if (empty8 != "1")
                                                    {
                                                        ControlCollection controlCollections9 = this.plhPriceCalculator.Controls;
                                                        item = new object[] { "<label id='lblMatrixName_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", base.SpecialDecode(item3.Rows[0]["UserFriendlyName"].ToString()), "</label>" };
                                                        controlCollections9.Add(new LiteralControl(string.Concat(item)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls10 = this.plhPriceCalculator.Controls;
                                                        item = new object[] { "<label id='lblMatrixName_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", base.SpecialDecode(item3.Rows[0]["UserFriendlyName"].ToString()), "</label><span style='color:Red;'> *</span>" };
                                                        controls10.Add(new LiteralControl(string.Concat(item)));
                                                    }
                                                    if (item3.Rows[0]["Description"] != null && item3.Rows[0]["Description"] != null)
                                                    {
                                                        this.HelpText = base.SpecialDecode(this.HelpText).Replace("'", "&#145");
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='#' class='tooltip' title='", item3.Rows[0]["Description"], "'>")));
                                                        ControlCollection controlCollections10 = this.plhPriceCalculator.Controls;
                                                        item = new object[] { "<img id='img_help_", num11, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:18px;' class='cart_details_HelpTextImage' /></a>" };
                                                        controlCollections10.Add(new LiteralControl(string.Concat(item)));
                                                    }
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    if (length1 <= 80)
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                                                    }
                                                    else
                                                    {
                                                        this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right marginLeft15'>"));
                                                    }
                                                    length1 = 0;
                                                    DropDownList dropDownList1 = new DropDownList();
                                                    item = new object[] { "ddlMultiple_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k };
                                                    dropDownList1.ID = string.Concat(item);
                                                    dropDownList1.CssClass = "dropDownMultiple150";
                                                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                                                    {
                                                        dropDownList1.Width = 300;
                                                    }
                                                    AttributeCollection attributeCollection1 = dropDownList1.Attributes;
                                                    item = new object[] { "javascript: VisibleAdditionaloption('", num8, "');ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();" };
                                                    attributeCollection1.Add("onchange", string.Concat(item));
                                                    dropDownList1.Attributes.Add("isgroup", "maingroup");
                                                    dropDownList1.Attributes.Add("IsMandatory", "0");
                                                    dropDownList1.Attributes.Add("grpvalue", empty6);
                                                    dropDownList1.Attributes.Add("WeotherCostID", row1["WebOtherCostID"].ToString());
                                                    this.comm.MultipleChoice_DropDownBind(item4, dropDownList1, this.plhPriceCalculator, row2["CalculationType"].ToString());
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                                    ControlCollection controls11 = this.plhPriceCalculator.Controls;
                                                    item = new object[] { "<label id='lblMultipleID_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='displayNone'>", dataTable8.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='displayNone'></label><label id='lblMultipleMarkup_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='displayNone'></label><label id='lblMultiplePrice_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label><label id='lblMultipleGroupID_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='displayNone'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num5, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' class='displayNone'>", num7, "</label>" };
                                                    controls11.Add(new LiteralControl(string.Concat(item)));
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    ControlCollection controlCollections11 = this.plhPriceCalculator.Controls;
                                                    item = new object[] { "<div id='DivSubAddition", row1["WebOtherCostID"].ToString(), "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none;'>" };
                                                    controlCollections11.Add(new LiteralControl(string.Concat(item)));
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                    this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                                }
                                            }
                                            this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    num5++;
                                }
                            }
                            else if (this.MainCalculationtype.ToLower() == "m" && num11 == 0)
                            {
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='col-lg-12 col-xs-5 price_table_content'>"));
                                row2["matrixType"].ToString();
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_left_with_AutoHeight'>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                ControlCollection controls12 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<div class='priceCalc_chkMatrix_Div'><input id='chkMatrix_", num6, "' class='displayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty6, " onclick='ForAdditional_Grouping(", num9, ",", num8, ");Tocall_mainFunc();'/></div>" };
                                controls12.Add(new LiteralControl(string.Concat(item)));
                                ControlCollection controlCollections12 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<div class='priceCalc_lblMatrixName_Div'><label id='lblMatrixName_", num6, "' > ", this.OtherCostName, "</label>" };
                                controlCollections12.Add(new LiteralControl(string.Concat(item)));
                                if (this.HelpText != "")
                                {
                                    this.plhPriceCalculator.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0)' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controls13 = this.plhPriceCalculator.Controls;
                                    item = new object[] { "<img id='img_help_", num11, "' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", productdetails.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:18px;' class='cart_details_HelpTextImage' /></a>" };
                                    controls13.Add(new LiteralControl(string.Concat(item)));
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin-top: 0px;'><div>"));
                                ControlCollection controlCollections13 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<label id='lblMatrixID_", num6, "' class='displayNone'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num6, "' class='displayNone'>", row2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num6, "' class='displayNone'></label><label id='lblMatrixGroupID_", num6, "' class='displayNone'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixSortOrderNo_", num6, "' class='displayNone'>", num7, "</label>" };
                                controlCollections13.Add(new LiteralControl(string.Concat(item)));
                                ControlCollection controls14 = this.plhPriceCalculator.Controls;
                                item = new object[] { "<label id='lblMatrixPrice_", num6, "' >", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                                controls14.Add(new LiteralControl(string.Concat(item)));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div></div>"));
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("<div class='price_table_content_right displayNone'>"));
                                if (row2["matrixType"].ToString().ToLower() != "pricebands")
                                {
                                    DropDownList dropDownList2 = new DropDownList();
                                    this.comm.MultipleChoice_DropDownBind(item2, dropDownList2, this.plhPriceCalculator, "matrix");
                                    dropDownList2.ID = string.Concat("ddlMatrix_", num6);
                                    dropDownList2.CssClass = "dropDownMultiple150";
                                    dropDownList2.Width = 300;
                                }
                                this.plhPriceCalculator.Controls.Add(new LiteralControl("</div>"));
                                num6++;
                            }
                            num11++;
                        }
                    }
                    this.hid_QuestionLenght.Value = num4.ToString();
                    this.hid_MultipleLenght.Value = num5.ToString();
                    this.hid_MatrixLenght.Value = num6.ToString();
                    if (this.Session["IsEditableProduct"] != null)
                    {
                        if (Convert.ToBoolean(this.Session["IsEditableProduct"]))
                        {
                            this.btnAddtoCart1.Style.Add("display", "none");
                            this.btnAddtoCart.Style.Add("display", "none");
                            this.EditProduct1.Style.Add("display", "block");
                            this.EditProduct2.Style.Add("display", "block");
                        }
                        else if (!Convert.ToBoolean(this.Session["IsEditableProduct"]))
                        {
                            this.btnAddtoCart1.Style.Add("display", "block");
                            this.btnAddtoCart.Style.Add("display", "block");
                            this.EditProduct1.Style.Add("display", "none");
                            this.EditProduct2.Style.Add("display", "none");
                        }
                    }
                    this.Price_CalculatorWithAddition.Style.Add("display", "block");
                    if (num4 != 0 || num5 != 0 || num6 != 0)
                    {
                        this.Price_Area(this.CompanyID, this.plhPriceCalculator, "yes");
                    }
                    else
                    {
                        this.Price_Area(this.CompanyID, this.plhquantity, "no");
                        this.Price_CalculatorWithAddition.Style.Add("display", "none");
                    }
                    int num12 = 0;
                    decimal num13 = new decimal(0);
                    decimal num14 = new decimal(0);
                    if (this.SesseionKey.Trim().Length > 0)
                    {
                        foreach (DataRow dataRow2 in CartBasePage.Select_CartItems(this.SesseionKey, "", this.StoreUserID).Rows)
                        {
                            num14 = num14 + Convert.ToDecimal(dataRow2["CartTax"].ToString());
                            num13 = num13 + Convert.ToDecimal(dataRow2["CartTotalPrice"].ToString());
                            Convert.ToDecimal(dataRow2["TotalCartAdditionalPrice"].ToString());
                            num12++;
                        }
                    }
                    this.getPageMetaDetails(this.CompanyID, Convert.ToInt32(productdetails.AccountID), 0);
                }
                this.pdfframe.Attributes["src"] = this.PrintReadyFilePath_Verify;
                this.btn_ConfirmAdd1.Attributes.Add("onclick", "javascript:return ValidatePrintReadyFile(this.id, 'divConfirmandAdd');");
                this.btn_ConfirmAdd1.Text = this.objLanguage.GetLanguageConversion("Confirm_and_Add_To_Cart");
                if (this.hdnStockManagement.Value != "true")
                {
                    this.hdnStockManagement.Value = "false";
                    this.hdnIsShowStock.Value = "false";
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
                                this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_PRoduct_is_Out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%;"));
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
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_PRoduct_is_Out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                    this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
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
                                int num16 = base.Check_MaxKit_Availability(Convert.ToInt64(this.PriceCatalogueID), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text));
                                if (num16 <= 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_PRoduct_is_Out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                    this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
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
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_PRoduct_is_Out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                    this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
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
                                DataTable dataTable9 = OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text), Convert.ToBoolean(this.hdnIsBackOrder.Value));
                                foreach (DataRow row3 in dataTable9.Rows)
                                {
                                    if (Convert.ToInt32(row3["AvailableQuantity"].ToString()) < 0)
                                    {
                                        this.divStockStatus.Attributes.Add("style", "display:none");
                                        this.pnlStockMessage.Attributes.Add("style", "display:block");
                                        this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_PRoduct_is_Out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                        this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
                                    }
                                    else
                                    {
                                        this.divStockStatus.Attributes.Add("style", "display:block");
                                        this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                        this.lbl_stockStatus1.Text = row3["AvailableQuantity"].ToString() ?? "";
                                    }
                                }
                            }
                        }
                        else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "a")
                        {
                            if (this.AvailableQuantity <= 0)
                            {
                                this.divStockStatus.Attributes.Add("style", "display:none");
                                this.pnlStockMessage.Attributes.Add("style", "display:block");
                                this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                                this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
                            }
                            else
                            {
                                this.divStockStatus.Attributes.Add("style", "display:block");
                                this.lbl_stockStatus.Text = "Stock Availability: ";
                                this.lbl_stockStatus1.Text = string.Concat(this.AvailableQuantity);
                                if (this.hid_matixType.Value == "S")
                                {
                                    this.pnladdoptionvalidate.Visible = true;
                                }
                            }
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
                            DataTable dataTable10 = OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(this.hdnPriceCatalogueID.Value), Convert.ToInt32(this.ddlPriceQty.SelectedItem.Text), Convert.ToBoolean(this.hdnIsBackOrder.Value));
                            foreach (DataRow dataRow3 in dataTable10.Rows)
                            {
                                if (Convert.ToInt32(dataRow3["AvailableQuantity"].ToString()) == 0)
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:none");
                                    this.pnlStockMessage.Attributes.Add("style", "display:block");
                                    this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), "</br>", this.objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order"));
                                }
                                else
                                {
                                    this.divStockStatus.Attributes.Add("style", "display:block");
                                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                                    this.lbl_stockStatus1.Text = dataRow3["AvailableQuantity"].ToString() ?? "";
                                }
                            }
                        }
                    }
                    else if (this.hdnDrawStockFrom.Value.Trim().ToLower() == "a")
                    {
                        if (this.AvailableQuantity <= 0)
                        {
                            this.divStockStatus.Attributes.Add("style", "display:none");
                            this.pnlStockMessage.Attributes.Add("style", "display:block");
                            this.lblStockMessage.Text = string.Concat(this.objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock"), " </br>", this.objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order"));
                            this.divMask.Attributes.Add("style", string.Concat("display:block;height:'", this.hdnMashDivHeight.Value, "';width:100%"));
                        }
                        else
                        {
                            this.divStockStatus.Attributes.Add("style", "display:block");
                            this.lbl_stockStatus.Text = "Stock Availability: ";
                            this.lbl_stockStatus1.Text = string.Concat(this.AvailableQuantity);
                            if (this.hid_matixType.Value == "S")
                            {
                                this.pnladdoptionvalidate.Visible = true;
                            }
                        }
                    }
                }
                if (this.AvailableQuantity <= 0)
                {
                    this.lbl_stockStatus1.Text = "0";
                    this.lbl_stockStatus.Text = this.objLanguage.GetLanguageConversion("Stock_Availability");
                }
            }
        }

        protected string[] preflight_File(string FileName, long ProductID)
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
            string str5 = "style='display:block'";
            StringBuilder stringBuilder = new StringBuilder();
            if (AdditionItem == "yes")
            {
                empty3 = "style=' float: right;padding-left: 0;padding-right: 79px;'";
                str3 = "style='display: none;margin-left: 0px;'";
                this.btnAddtoCart1.Style.Add("display", "none");
                this.EditProduct1.Style.Add("display", "none");
                this.artwork_div_no_addoption.Style.Add("display", "none");
                str5 = (this.isSubTotal != "1" ? "style='display:none'" : "style='display:block;'");
                if (this.hid_matixType.Value.ToLower() == "p")
                {
                    str = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='width:180px;margin:0px 0px 0px 0px;font-weight:bold;'" : "style='margin:0px 0px 0px 0px;font-weight:bold;'");
                    str4 = "style='float: right; padding-right: 0px;'";
                    empty3 = "style='float:right;margin-right: 84px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g")
                {
                    str = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='width:180px;margin:0px 0px 0px 0px;font-weight:bold;'" : "style='margin:0px 0px 0px 0px;font-weight:bold;'");
                    str4 = "style='float: right; padding-right: 0px;'";
                    empty3 = "style='float:right;margin-right: 84px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "s")
                {
                    str4 = "style='float: right;padding-right: 0px;'";
                    str = "style='font-weight: bold;'";
                }
            }
            else if (AdditionItem == "no")
            {
                empty4 = "style='margin-right: 20px;'";
                empty1 = "style='width:85px;font-weight:bold;display:none'";
                if (this.isSubTotal != "1")
                {
                    str5 = "style='display:none'";
                }
                else
                {
                    str5 = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='display:block;'" : "style='display:block; margin-left: 0px;'");
                }
                if (this.hid_matixType.Value.ToLower() == "p" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='width:180px;margin:0px 0px 0px 0px;font-weight:bold;'" : "style='margin:0px 0px 0px 0px;font-weight:bold;'");
                    str4 = "style='float: right; padding-right: 0px;'";
                    empty3 = "style='float:right;margin-right: 0px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "g" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = (this.RightPanelCalc_Enabled.ToLower() != "true" ? "style='width:180px;margin:0px 0px 0px 0px;font-weight:bold;'" : "style='margin:0px 0px 0px 0px;font-weight:bold;'");
                    str4 = "style='float: right; padding-right: 0px;'";
                    empty3 = "style='float:right;margin-right: 0px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "s" && this.artworkFile.ToLower().Trim() == "n")
                {
                    empty4 = "style='margin-right: 22px;'";
                    empty3 = "style='float:right;'";
                    str4 = "style='float: right;'";
                    str = " style='margin-left: 0px;'";
                }
                if (this.hid_matixType.Value.ToLower() == "s" && this.artworkFile.ToLower().Trim() != "n")
                {
                    str = "style='width:180px;font-weight:bold;'";
                    empty4 = "style='margin-right: 22px;'";
                    empty3 = "style='float:right;'";
                    str4 = "style='float: right;'";
                }
                if (this.hid_matixType.Value.ToLower() == "p" && this.artworkFile.ToLower().Trim() == "n")
                {
                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                    {
                        empty3 = "style='margin-left: 0px; float: right; padding-right: 0px; width: 190px; padding-left: 0px; text-align: right;'";
                        str = "style='width:189px;margin:0px 0px 0px 0px;font-weight:bold;'";
                        str4 = "style='margin-left: 0px; float: right; padding-right: 0px; width: 190px; padding-left: 0px; text-align: right;'";
                    }
                    else
                    {
                        empty3 = "style='margin-left: 0px; float: right; padding-right: 0px; padding-left: 0px; text-align: right;'";
                        str = "style='margin:0px 0px 0px 0px;font-weight:bold;'";
                        str4 = "style='margin-left: 0px; float: right; padding-right: 0px; padding-left: 0px; text-align: right;'";
                    }
                }
                if (this.hid_matixType.Value.ToLower() == "g" && this.artworkFile.ToLower().Trim() == "n")
                {
                    if (this.RightPanelCalc_Enabled.ToLower() != "true")
                    {
                        empty3 = "style='margin-left: 0px; float: right; padding-right: 0px; width: 190px; padding-left: 0px; text-align: right;'";
                        str = "style='width:189px;margin:0px 0px 0px 0px;font-weight:bold;'";
                        str4 = "style='margin-left: 0px; float: right; padding-right: 0px; width: 190px; padding-left: 0px; text-align: right;'";
                    }
                    else
                    {
                        empty3 = "style='margin-left: 0px; float: right; padding-right: 0px; padding-left: 0px; text-align: right;'";
                        str = "style='margin:0px 0px 0px 0px;font-weight:bold;'";
                        str4 = "style='margin-left: 0px; float: right; padding-right: 0px; padding-left: 0px; text-align: right;'";
                    }
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
            }
            if (this.RightPanelCalc_Enabled.ToLower() != "true")
            {
                plh.Controls.Add(new LiteralControl("</div><div class='clearBoth'></div><div>"));
            }
            else
            {
                plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div><div>"));
            }
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
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='col-lg-12 col-xs-5 price_table_content'>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_left' style='" + DisplayUnitPrice + "'><label id='lbl_unit_price'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " </label></div>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_middle' style='" + DisplayUnitPrice + "'><label id='lblunitprice'>", this.comm.GetCurrencyinRequiredFormate(("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / qty), 2, "", false, false, true) + ""), true), " </label></div>")));

            plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_left' style='" + DisplayPackPrice + "'><label id='lbl_pack_price'>", this.objLanguage.GetLanguageConversion("Pack_Price"), " </label></div>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_middle' style='" + DisplayPackPrice + "'><label id='lblpackprice'>", this.comm.GetCurrencyinRequiredFormate("" + this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, Convert.ToInt32(this.StoreUserID), Convert.ToDecimal(subTotal / (qty / soldInPacksof)), 2, "", false, false, true) + "", true), " </label></div>")));
            plh.Controls.Add(new LiteralControl("</div>"));

            plh.Controls.Add(new LiteralControl(string.Concat("<div class='col-lg-12 col-xs-5 price_table_content'", str5, ">")));
            str5 = (AdditionItem == "yes" ? "" : "style='display:none;margin-left: 10px;'");
            str5 = (!(this.hdnShowPriceSubtotalTax.Value.ToLower() == "true") || !(AdditionItem == "yes") ? "style='display:none;'" : "style='display:block; margin-top: 0px;'");
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_left' ", str5, ">")));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSubTotal'>", this.objLanguage.GetLanguageConversion("Sub_Total"), " </label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<div align='left' class='price_table_content_middle' ", str5, ">")));
            ControlCollection controls = plh.Controls;
            string[] currencyinRequiredFormate = new string[] { "<label id='lbltotal' ", empty4, ">", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label>" };
            controls.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
            plh.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' id='hdnlbltotal' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            string empty6 = string.Empty;
            if (!(this.hdnShowPriceSubtotalTax.Value.ToLower() == "true") || !(AdditionItem == "no"))
            {
                str3 = "style='display:none'";
            }
            else
            {
                str3 = (!(this.RightPanelCalc_Enabled.ToLower() == "true") || !(this.hid_matixType.Value.ToLower() != "g") ? "style='display:block;'" : "style='display:block; padding-top: 7px;'");
                empty6 = "style='padding-top:8px;'";
            }
            if (this.hid_matixType.Value.ToLower() != "g")
            {
                empty6 = "";
            }
            if (this.isPriceExTax == "1")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div ", empty6, ">")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_withoutTax' ", str3, "><div id='divPrice'>")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<label id='lblPrice_ex_Tax'>", this.objLanguage.GetLanguageConversion("Price_ex_Tax"), " </label>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                ControlCollection controlCollections = this.plhquantity.Controls;
                string[] strArrays = new string[] { "<div ", empty3, "><label id='lbl_WithoutTax' class='lblTax_padding'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label></div>" };
                controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            }
            string str6 = "";
            str6 = (this.isTax != "1" ? "style='display:none'" : "style='display:block'");
            str6 = (this.hdnShowPriceSubtotalTax.Value.ToLower() != "true" ? "style='display:none'" : "style='display:block'");
            plh.Controls.Add(new LiteralControl(string.Concat("<div ", str6, ">")));
            plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_left'", str, ">")));
            ControlCollection controls1 = plh.Controls;
            object[] languageConversion = new object[] { "<label>", this.objLanguage.GetLanguageConversion("Tax"), ": </label><label id='lblTax'>", base.SpecialDecode(this.ProductTaxName), " (", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(this.ProductTaxRate), 2, "", false, false, true)), "%) </label><label id='lblTaxID' class='displayNone'>", this.ProductTaxId, "</label>" };
            controls1.Add(new LiteralControl(string.Concat(languageConversion)));
            plh.Controls.Add(new LiteralControl("</div>"));
            if (base.Request.Browser.Browser.ToString().ToLower() == "applemac-safari")
            {
                if (this.artworkFile.ToLower() == "y" || this.artworkFile.ToLower() == "m")
                {
                    plh.Controls.Add(new LiteralControl(string.Concat("<div ", str4, "><label id='lblTotalTax' class='lblTax_padding'></label><input type='hidden' id='hdnlblTotalTax'></input></div>")));
                }
                else
                {
                    plh.Controls.Add(new LiteralControl(string.Concat("<div ", str4, "><label id='lblTotalTax' class='lblTax_padding'></label><input type='hidden' id='hdnlblTotalTax'></input></div>")));
                }
            }
            else if (this.artworkFile.ToLower() == "y" || this.artworkFile.ToLower() == "m")
            {
                plh.Controls.Add(new LiteralControl(string.Concat("<div ", str4, "><label id='lblTotalTax' class='lblTax_padding'></label><input type='hidden' id='hdnlblTotalTax'></input></div>")));
            }
            else
            {
                plh.Controls.Add(new LiteralControl(string.Concat("<div ", str4, "><label id='lblTotalTax' class='lblTax_padding'></label><input type='hidden' id='hdnlblTotalTax'></input></div>")));
            }
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='clearBoth'><br></div><div ", empty1, ">")));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblTaxRate' class='displayNone' >", this.ProductTaxRate, "</label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            string str7 = "";
            str7 = (this.isTotalPrice != "1" ? "style='display:none'" : "style='display:block'");
            str7 = (this.hdnShowPriceSubtotalTax.Value.ToLower() != "true" ? "style='display:none'" : "style='display:block'");
            if (this.RightPanelCalc_Enabled.ToLower() == "true" && AdditionItem == "no" && str7.Contains("block"))
            {
                str7 = "style='display: block; margin-left: 0px;'";
            }
            plh.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='col-lg-12 col-xs-5 price_table_content'", str7, ">")));
            if (AdditionItem == "yes")
            {
                str = "style='margin-left: 0px;'";
            }
            else if (this.artworkFile.ToLower().Trim() == "n" && this.hid_matixType.Value.ToLower() == "s")
            {
                str = "style='margin-left: 0px;'";
            }
            plh.Controls.Add(new LiteralControl(string.Concat("<div class='price_table_content_left1' ", str, ">")));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSellingPrice' class='lblSellingPrice'>", this.objLanguage.GetLanguageConversion("Total_Price_inc_tax"), " </label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            if (AdditionItem != "yes")
            {
                plh.Controls.Add(new LiteralControl("<div class='TotalSellingPrice_Div'>"));
                this.div_artwork_content_fileupload_no_addoption.Style.Add("margin", "25px 0px 0px -476px");
            }
            else
            {
                plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle1' >"));
            }
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblTotalSellingPrice' class='lblTotalSellingPrice'>", this.comm.GetCurrencyinRequiredFormate("", true), "0.00</label>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' id='hdnlblTotalSellingPrice' value='", this.comm.GetCurrencyinRequiredFormate("", true), "0.00'></input>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div></div>"));
        }

        public void Product_list(string matixType, long PriceCatalogueID, PlaceHolder plhlist, string type, int i)
        {
            plhlist.Controls.Add(new LiteralControl("<table class='price_table' cellpadding='0px' cellspacing='0px' border='0px'>"));
            plhlist.Controls.Add(new LiteralControl("<tbody>"));
            plhlist.Controls.Add(new LiteralControl("<tr>"));
            if (matixType != "G")
            {
                plhlist.Controls.Add(new LiteralControl(string.Concat("<th><div align='center'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div></th>")));
            }
            else
            {
                ControlCollection controls = plhlist.Controls;
                string[] languageConversion = new string[] { "<th><div align='center'>", this.objLanguage.GetLanguageConversion("Qty"), " (", this.MeasurementValue_Sq, ")</div></th>" };
                controls.Add(new LiteralControl(string.Concat(languageConversion)));
            }
            if (matixType == "P")
            {
                ControlCollection controlCollections = plhlist.Controls;
                string[] strArrays = new string[] { "<th><div align='center' >", this.objLanguage.GetLanguageConversion("Price_For1"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</div></th>" };
                controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
            }
            else if (matixType != "G")
            {
                ControlCollection controls1 = plhlist.Controls;
                string[] languageConversion1 = new string[] { "<th><div align='center' >", this.objLanguage.GetLanguageConversion("Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</div></th>" };
                controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
            }
            else
            {
                ControlCollection controlCollections1 = plhlist.Controls;
                string[] strArrays1 = new string[] { "<th><div align='center' >", this.objLanguage.GetLanguageConversion("Price_For1"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</div></th>" };
                controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
            }
            plhlist.Controls.Add(new LiteralControl("</tr>"));
            foreach (DataRow row in ProductBasePage.Product_CatalogueQty_Select(PriceCatalogueID).Rows)
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
                    }
                    else
                    {
                        label.Text = string.Concat(row["FromQuantity"].ToString(), " - ", row["ToQuantity"].ToString());
                        label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true);
                    }
                    if (i == 1)
                    {
                        if (!Convert.ToBoolean(row["IsPriceStartFrom"]))
                        {
                            this.lbl_priceStartsFrom.Visible = false;
                            this.lbl_priceStartsFrom1.Visible = false;
                        }
                        else
                        {
                            this.lbl_priceStartsFrom.Text = this.objLanguage.GetLanguageConversion("Price_Starts_From");
                            this.lbl_priceStartsFrom1.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SellingPrice"].ToString()), 2, "", false, false, true));
                        }
                    }
                    if (!Convert.ToBoolean(row["IsShowStock"]))
                    {
                        this.IsShowStock = "0";
                    }
                    else
                    {
                        this.IsShowStock = "1";
                    }
                    plhlist.Controls.Add(new LiteralControl("<tr><td><div align='center'>"));
                    plhlist.Controls.Add(label);
                    plhlist.Controls.Add(new LiteralControl("</div></td>"));
                    plhlist.Controls.Add(new LiteralControl("<td><div align='center'>"));
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
                    plhlist.Controls.Add(new LiteralControl("<tr><td><div align='center'>"));
                    plhlist.Controls.Add(str);
                    plhlist.Controls.Add(new LiteralControl("</div></td>"));
                    plhlist.Controls.Add(new LiteralControl("<td><div align='center'>"));
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
                i++;
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
            plhlist.Controls.Add(new LiteralControl("</tbody>"));
            plhlist.Controls.Add(new LiteralControl("</table>"));
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix, PlaceHolder plhPriceCalculator)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
            plhPriceCalculator.Controls.Add(ddlMatrix);
        }
    }
}