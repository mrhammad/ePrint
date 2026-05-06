using ePrint.MyPublicStore.Templates;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore
{
    public partial class Default : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager SM;

        //protected PlaceHolder plh_imageBanner;

        //protected HiddenField hdnBannerSliderTime;

        //protected PlaceHolder plh_imageBannerDescription;

        //protected HtmlGenericControl div_slidder;

        //protected PlaceHolder plh_ProductsDetailsList;

        //protected HtmlGenericControl div_ProductsDetailsList;

        //protected PlaceHolder plhLeftBanner;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected Button btnQuickNotificationOk;

        //protected Button btnGotoCart;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected Label lblCustomText;

        //protected HtmlGenericControl divCustomTex;

        //protected Label lbl_centerPaneltext;

        //protected HtmlGenericControl div_headerCustomer;

        //protected PlaceHolder plh_ProductsDetails;

        //protected HtmlGenericControl div_FeatureProducts;

        //protected PlaceHolder plh_NewProductsDetails;

        //protected HtmlGenericControl div_NewProducts;

        //protected PlaceHolder plh_Customize;

        //protected HtmlGenericControl div_Customize;

        //protected PlaceHolder plh_Customize_new;

        //protected HtmlGenericControl div_Customize_new;

        //protected PlaceHolder plhRightBanner;

        private MemoryStream stream = new MemoryStream();

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBc = new BaseClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int arrayLength;

        public int cnt_right;

        public int cnt_left;

        public int centerDivWidth = 3;

        public int productNameLength = 56;

        public int productDescriptionLength = 70;

        public int cnt_getProductCatagories;

        public static int CompanyID;

        public static long AccountID;

        public ArrayList productName = new ArrayList();

        public ArrayList productName1 = new ArrayList();

        public ArrayList productImage = new ArrayList();

        public ArrayList productDescription = new ArrayList();

        public ArrayList PriceCatalogueCategoryID = new ArrayList();

        public ArrayList PriceCatalogueID = new ArrayList();

        public ArrayList Pricetype = new ArrayList();

        public ArrayList IsShortDescription = new ArrayList();

        public ArrayList isQuickItem = new ArrayList();

        public ArrayList isPriceStartFrom = new ArrayList();

        public ArrayList MatrixType = new ArrayList();

        public ArrayList PriceCatalogueCategoryName = new ArrayList();

        public ArrayList PriceCategoryID = new ArrayList();

        public ArrayList IsCumulativePricinig = new ArrayList();

        public ArrayList SolodinPacksof = new ArrayList();

        public ArrayList DrawStockFrom = new ArrayList();

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public char KeySeparator;

        public string RewriteModule = string.Empty;

        public string AccountType = string.Empty;

        public int isRightBanner;

        public static string imagePath;

        public static string catagoryImagePath;

        public static string productImagePath;

        public static string strSitePath;

        public static string strBannerPath;

        public static string thumbImg;

        public string SesseionKey = string.Empty;

        public string isProductCategory = "1";

        public string isHomeRightBanner = "1";

        public string count_leftbanner = "0";

        public string marginleft = string.Empty;

        public int isSlidiingBanner;

        public string productmarginleft = string.Empty;

        public string paddingleft = string.Empty;

        public int newProductCount;

        public string SecureDocPath = string.Empty;

        public string ServerName = string.Empty;

        public static long StoreUserID;

        public string BannerSliderTime = string.Empty;

        private bool IsForceUserLogin;

        private bool IsStockItem;

        private int RoundOff;

        public int CopyPriceCatalogueID;

        public string NoProductSelected = string.Empty;

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

        static Default()
        {
            Default.CompanyID = 0;
            Default.AccountID = (long)0;
            Default.imagePath = string.Empty;
            Default.catagoryImagePath = string.Empty;
            Default.productImagePath = string.Empty;
            Default.strSitePath = string.Empty;
            Default.strBannerPath = string.Empty;
            Default.thumbImg = string.Empty;
            Default.StoreUserID = (long)0;
        }

        public Default()
        {
        }

        public void BindOtherMultipleDropdownList(DataTable dtm, DropDownList OtherMultiplrDrp)
        {
            OtherMultiplrDrp.DataSource = dtm;
            OtherMultiplrDrp.DataTextField = "CatalogueName";
            OtherMultiplrDrp.DataValueField = "PriceCatalogueID";
            OtherMultiplrDrp.DataBind();
        }

        private StringBuilder generateBanner(DataRow dataRow)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            object[] item = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", dataRow["Image"], "&amp;type=b&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
            string str = string.Concat(item);
            if (dataRow["Name"].ToString().Trim() != "")
            {
                if (dataRow["URL"].ToString().Trim() == "")
                {
                    object[] objArray = new object[] { "<img src='", str, "' alt='", dataRow["Name"], "' />" };
                    empty = string.Concat(objArray);
                }
                else
                {
                    object[] objArray1 = new object[] { "<a href='", dataRow["URL"].ToString().Trim(), "'><img src='", str, "' alt='", dataRow["Name"], "' /></a>" };
                    empty = string.Concat(objArray1);
                }
            }
            stringBuilder.Append("<div class='module_cube_banner'>");
            stringBuilder.Append(empty);
            stringBuilder.Append("</div>");
            return stringBuilder;
        }

        private StringBuilder generateCategory(DataRow dataRow)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dataRow["image"].ToString().Trim() != "")
            {
                object[] str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_", dataRow["image"].ToString(), "&amp;type=c&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                this.finalimageName1 = string.Concat(str);
            }
            else
            {
                object[] accountID = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                this.finalimageName1 = string.Concat(accountID);
            }
            string empty = string.Empty;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                empty = string.Concat(Default.strSitePath, "products/product.aspx?ID=", dataRow["ID"].ToString(), "'>");
            }
            else
            {
                string[] keySeparator = new string[] { Default.strSitePath, "product", ConnectionClass.KeySeparator, dataRow["ID"].ToString(), ConnectionClass.FileExtension };
                empty = string.Concat(base.ResolveUrl(string.Concat(keySeparator)), "'>");
            }
            stringBuilder.Append(string.Concat("<div class='productDetails_div' style='", this.marginleft, "' ><div class='productDetails_Style' >"));
            stringBuilder.Append(string.Concat("<div class='productName_div' style='padding-left:1px; padding-right:1px;'><label>", dataRow["Name"].ToString(), "</label></div><div class='clearBoth'></div>"));
            stringBuilder.Append("<div class='productImage_div'>");
            stringBuilder.Append("<div class='productList_productImage_div'>");
            stringBuilder.Append(string.Concat("<a href='", empty));
            string[] strArrays = new string[] { "<img title='", dataRow["Name"].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '></a>" };
            stringBuilder.Append(string.Concat(strArrays));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append(string.Concat("<div class='clearBoth'></div><div class='productCategoryDescription_div' title=''><label> ", dataRow["Description"].ToString(), "</label></div>"));
            stringBuilder.Append("<div class='clearBoth'></div></div></div>");
            return stringBuilder;
        }

        private StringBuilder generateCustomeText(DataRow dataRow)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = new string[] { "<div class='customText' style='height:", dataRow[3].ToString().Trim(), "px; width:", dataRow[5].ToString().Trim(), "px'>" };
            stringBuilder.Append(string.Concat(strArrays));
            stringBuilder.Append(dataRow[4].ToString());
            stringBuilder.Append("</div>");
            return stringBuilder;
        }

        public void getCutomProducts(string customText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(customText);
            this.plh_Customize.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        private void getCutomProductsNew(int CompanyID, long AcountID, string Product_Type)
        {
            DataTable dataTable = ProductBasePage.productsList_Select_custom(CompanyID, Default.AccountID);
            StringBuilder stringBuilder = new StringBuilder();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["Type"].ToString().ToLower() == "c")
                    {
                        stringBuilder = stringBuilder.Append(this.generateCategory(dataTable.Rows[i]));
                    }
                    else if (dataTable.Rows[i]["Type"].ToString().ToLower() == "b")
                    {
                        stringBuilder = stringBuilder.Append(this.generateBanner(dataTable.Rows[i]));
                    }
                    else if (dataTable.Rows[i]["Type"].ToString().ToLower() == "t")
                    {
                        stringBuilder = stringBuilder.Append(this.generateCustomeText(dataTable.Rows[i]));
                    }
                }
                this.plh_Customize_new.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            }
        }

        public void getNewProducts(int CompanyID, long AccountID, string Product_Type)
        {
            IEnumerator enumerator;
            int num;
            bool flag;
            IDisposable disposable;
            object[] str;
            string[] strArrays;
            DataTable dataTable = ProductBasePage.productsList_Select((long)CompanyID, AccountID);
            DataTable dataTable1 = ProductBasePage.FeaturedProducts_Select((long)CompanyID, AccountID);
            int num1 = 0;
            if (dataTable1.Rows.Count > 0 && Product_Type == "featured")
            {
                foreach (DataRow row in dataTable1.Rows)
                {
                    DataRow[] dataRowArray = dataTable.Select(string.Concat("PriceCatalogueID=", row["PriceCatalogueID"].ToString()));
                    if ((int)dataRowArray.Length <= 0)
                    {
                        continue;
                    }
                    this.PriceCatalogueID.Add(row["PriceCatalogueID"].ToString());
                    this.productName.Add(dataRowArray[0]["CatalogueName"].ToString());
                    this.productDescription.Add(dataRowArray[0]["ShortDescription"].ToString());
                    this.productImage.Add(dataRowArray[0]["ProductImage"].ToString());
                    ArrayList isShortDescription = this.IsShortDescription;
                    num = Convert.ToInt32(dataRowArray[0]["IsShortDescription"]);
                    isShortDescription.Add(num.ToString());
                    this.PriceCatalogueCategoryName.Add(dataRowArray[0]["PriceCatalogueCategoryName"].ToString());
                    this.PriceCategoryID.Add(dataRowArray[0]["PriceCatalogueID"].ToString());
                    ArrayList arrayLists = this.isQuickItem;
                    flag = Convert.ToBoolean(dataRowArray[0]["isQuickItem"]);
                    arrayLists.Add(flag.ToString());
                    this.isPriceStartFrom.Add(Convert.ToBoolean(dataRowArray[0]["IsPriceStartFrom"].ToString()));
                    this.MatrixType.Add(dataRowArray[0]["MatrixType"].ToString());
                    this.IsCumulativePricinig.Add(dataRowArray[0]["IsCumulativePricing"].ToString());
                    this.SolodinPacksof.Add(dataRowArray[0]["SoldInPacksOf"].ToString());
                    this.DrawStockFrom.Add(dataRowArray[0]["DrawStockFrom"].ToString());
                    num1++;
                }
            }
            if (dataTable.Rows.Count > 0 && Product_Type == "new")
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.PriceCatalogueID.Add(dataRow["PriceCatalogueID"].ToString());
                    this.productName.Add(dataRow["CatalogueName"].ToString());
                    this.productDescription.Add(dataRow["ShortDescription"].ToString());
                    this.productImage.Add(dataRow["ProductImage"].ToString());
                    ArrayList isShortDescription1 = this.IsShortDescription;
                    num = Convert.ToInt32(dataRow["IsShortDescription"]);
                    isShortDescription1.Add(num.ToString());
                    this.PriceCatalogueCategoryName.Add(dataRow["PriceCatalogueCategoryName"].ToString());
                    this.PriceCategoryID.Add(dataRow["PriceCatalogueID"].ToString());
                    ArrayList arrayLists1 = this.isQuickItem;
                    flag = Convert.ToBoolean(dataRow["isQuickItem"]);
                    arrayLists1.Add(flag.ToString());
                    this.isPriceStartFrom.Add(Convert.ToBoolean(dataRow["IsPriceStartFrom"].ToString()));
                    this.MatrixType.Add(dataRow["MatrixType"].ToString());
                    this.IsCumulativePricinig.Add(dataRow["IsCumulativePricing"].ToString());
                    this.SolodinPacksof.Add(dataRow["SoldInPacksOf"].ToString());
                    this.DrawStockFrom.Add(dataRow["DrawStockFrom"].ToString());
                    num1++;
                }
            }
            if (this.PriceCatalogueID.Count <= 0)
            {
                this.newProductCount = 0;
                this.plh_NewProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
            }
            else if (num1 == 0)
            {
                this.plh_NewProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
            }
            else
            {
                this.newProductCount = num1;
                int count = this.PriceCatalogueID.Count / this.centerDivWidth;
                double count1 = (double)this.PriceCatalogueID.Count / Convert.ToDouble(this.centerDivWidth);
                int num2 = 0;
                if ((double)count != count1)
                {
                    num2 = count + 1;
                }
                else
                {
                    num2 = count;
                    if (num2 == 0)
                    {
                        num2 = count + 1;
                    }
                }
                if (Product_Type == "new" && num2 > 2)
                {
                    num2 = 2;
                }
                StringBuilder stringBuilder = new StringBuilder();
                foreach (DataRow row1 in LoginBasePage.Select_PublicUserAccountDetails((long)CompanyID, AccountID).Rows)
                {
                    this.IsForceUserLogin = Convert.ToBoolean(row1["IsForceUser"]);
                }
                for (int i = 0; i < num2; i++)
                {
                    stringBuilder.Append(string.Concat("<div  cellspacing='0'  style='margin-left:", this.productmarginleft, "' >"));
                    stringBuilder.Append("<div class='row'>");
                    DataTable dataTable2 = new DataTable();
                    for (int j = 0; j < this.centerDivWidth; j++)
                    {
                        if (this.DrawStockFrom[this.arrayLength].ToString().ToLower() == "m")
                        {
                            this.CopyPriceCatalogueID = Convert.ToInt32(this.PriceCategoryID[this.arrayLength]);
                            DataTable dataTable3 = ProductBasePage.OtherMultiple_Default_Select((long)Convert.ToInt32(this.CopyPriceCatalogueID));
                            if (dataTable3.Rows.Count != 0)
                            {
                                this.NoProductSelected = "false";
                            }
                            else
                            {
                                this.NoProductSelected = "true";
                                this.PriceCategoryID[this.arrayLength] = this.CopyPriceCatalogueID.ToString();
                            }
                            if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["KitItemID"] != null)
                            {
                                this.PriceCategoryID[this.arrayLength] = dataTable3.Rows[0]["KitItemID"].ToString();
                            }
                            dataTable2 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCategoryID[this.arrayLength]));
                            enumerator = dataTable2.Rows.GetEnumerator();
                            try
                            {
                                if (enumerator.MoveNext())
                                {
                                    DataRow current = (DataRow)enumerator.Current;
                                    this.productImage[this.arrayLength] = current["ProductImage"].ToString();
                                    this.productDescription[this.arrayLength] = current["Description"].ToString();
                                    this.MatrixType[this.arrayLength] = current["MatrixType"].ToString();
                                    this.isPriceStartFrom[this.arrayLength] = current["IsPriceStartFrom"].ToString();
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
                        }
                        //stringBuilder.Append(string.Concat("<div class='col-lg-4 col-md-4 col-sm-3' style='padding-left: ", this.paddingleft, "; padding-right: 1px;'>"));
                        stringBuilder.Append(string.Concat("<div class='col-lg-4 col-md-4 col-sm-3'>"));
                        if (this.DrawStockFrom[this.arrayLength].ToString().ToLower() != "m")
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
                        {
                            str = new object[] { "<div  id='divmainHover", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "' onmouseover='mouseovershow1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='productDetails_Style'>" };
                            stringBuilder.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<div  id='divmainHover", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "' onmouseover='mouseovershow1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='productDetails_Style'>" };
                            stringBuilder.Append(string.Concat(str));
                        }
                        string empty = string.Empty;
                        empty = (this.productName[this.arrayLength].ToString().Trim().Length <= this.productNameLength ? base.SpecialDecode(this.productName[this.arrayLength].ToString().Trim()) : base.SpecialDecode(this.productName[this.arrayLength].ToString().Trim().Substring(0, this.productNameLength)));
                        stringBuilder.Append("<div class='productName_div' style='padding-left:1px; padding-right:1px;'>");
                        stringBuilder.Append(string.Concat("<label>", empty, "</label>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        stringBuilder.Append("<div class='productImage_div'>");
                        if (this.productImage[this.arrayLength].ToString() != "")
                        {
                            str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=", this.productImage[this.arrayLength].ToString(), "&amp;type=p&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                            this.finalimageName1 = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                            this.finalimageName1 = string.Concat(str);
                        }
                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                        {
                            stringBuilder.Append("<div class='productList_productImage_dfltpg_div'>");
                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                            {
                                strArrays = new string[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID7", this.CopyPriceCatalogueID.ToString(), "' title='", this.productName[this.arrayLength].ToString(), "' class='ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<a href='javascript:void(0);' onclick=Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",'", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "');><img id='imgGetID7", this.CopyPriceCatalogueID.ToString(), "' title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            stringBuilder.Append("</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div class='productList_productImage_dfltpg_div'>");
                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                            {
                                strArrays = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                string[] strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(base.SpecialDecode(this.productName[this.arrayLength].ToString().Trim())), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                strArrays[2] = "'><img id='imgGetID7";
                                strArrays[3] = this.CopyPriceCatalogueID.ToString();
                                strArrays[4] = "'  title='";
                                strArrays[5] = this.productName[this.arrayLength].ToString();
                                strArrays[6] = "' src=\"";
                                strArrays[7] = this.finalimageName1;
                                strArrays[8] = "\" class='ProductCatagoryImage' alt=' '/></a>";
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<a href='javascript:void(0);' onclick=Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",'", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "');><img id='imgGetID7", this.CopyPriceCatalogueID.ToString(), "'  title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            stringBuilder.Append("</div>");
                        }
                        this.finalimageName1 = "";
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        string empty1 = string.Empty;
                        if (dataTable.Rows[this.arrayLength]["ShortDescription"].ToString().Trim() != "" && Convert.ToBoolean(dataTable.Rows[this.arrayLength]["IsShortDescription"]))
                        {
                            empty1 = base.SpecialDecode(this.productDescription[this.arrayLength].ToString().Trim());
                        }
                        str = new object[] { "<div id='DivDesc", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");'  align='center' class='productDescription_div' >" };
                        stringBuilder.Append(string.Concat(str));
                        str = new object[] { "<label id='lblDesc", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'> ", empty1, " </label>" };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        stringBuilder.Append("<div class='paddingTop5'>");
                        stringBuilder.Append("<div>");
                        if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                        {
                            strArrays = new string[] { "<input type='button' id='btnview", this.PriceCatalogueID[this.arrayLength].ToString(), "' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='btn btn-default WS_Buttons_Style' onclick='Onclick_Product(", this.PriceCatalogueID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'/>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else
                        {
                            strArrays = new string[] { "<input type='button' id='btnview", this.PriceCatalogueID[this.arrayLength].ToString(), "' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='btn btn-default WS_Buttons_Style' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'/>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='ViewDetailsBtn_ProcessDiv'>");
                        stringBuilder.Append(string.Concat("<div id='div_process", this.PriceCatalogueID[this.arrayLength].ToString(), "'  class='WS_Buttons_Style displayNone' >"));
                        stringBuilder.Append(string.Concat("<img src='", Default.imagePath, "radimg1.gif'   alt='loading' />"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        if (this.DrawStockFrom[this.arrayLength].ToString().ToLower() == "m")
                        {
                            if (Convert.ToBoolean(this.isQuickItem[this.arrayLength].ToString()))
                            {
                                stringBuilder.Append("<div class='clearBoth'></div>");
                                str = new object[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                HiddenField hiddenField = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxName", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField1 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxRate", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField str1 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxID", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                    Value = "0"
                                };
                                hiddenField1.Value = "0";
                                DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(CompanyID, Convert.ToInt32(this.PriceCategoryID[this.arrayLength]));
                                foreach (DataRow dataRow1 in taxDetailsByProductCatalogueId.Rows)
                                {
                                    str1.Value = dataRow1["SalesTaxRate"].ToString();
                                    hiddenField.Value = dataRow1["TaxName"].ToString();
                                    hiddenField1.Value = dataRow1["TaxRate"].ToString();
                                }
                                using (StringWriter stringWriter = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter))
                                    {
                                        str1.RenderControl(htmlTextWriter);
                                        hiddenField.RenderControl(htmlTextWriter);
                                        hiddenField1.RenderControl(htmlTextWriter);
                                    }
                                }
                                DataTable dataTable4 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCategoryID[this.arrayLength].ToString()));
                                HiddenField lower = new HiddenField();
                                HiddenField hiddenField2 = new HiddenField();
                                HiddenField str2 = new HiddenField();
                                lower.ID = string.Concat("hdn_IsCumulative_", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID);
                                hiddenField2.ID = string.Concat("hdn_SoldInPacks_", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID);
                                str2.ID = string.Concat("hdn_MainProductID", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID);
                                str2.Value = this.CopyPriceCatalogueID.ToString();
                                HiddenField hiddenField3 = new HiddenField()
                                {
                                    ID = string.Concat("hid_PriceCatelogueName", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                enumerator = dataTable2.Rows.GetEnumerator();
                                try
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        DataRow current1 = (DataRow)enumerator.Current;
                                        lower.Value = current1["IsCumulativePricing"].ToString().ToLower();
                                        hiddenField2.Value = current1["SoldInPacksof"].ToString();
                                        hiddenField3.Value = current1["CatalogueName"].ToString();
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
                                using (StringWriter stringWriter1 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter1 = new HtmlTextWriter(stringWriter1))
                                    {
                                        hiddenField3.RenderControl(htmlTextWriter1);
                                        lower.RenderControl(htmlTextWriter1);
                                        hiddenField2.RenderControl(htmlTextWriter1);
                                        str2.RenderControl(htmlTextWriter1);
                                    }
                                }
                                HiddenField hiddenField4 = new HiddenField()
                                {
                                    ID = string.Concat("hid_CostExcMarkupList", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField5 = new HiddenField()
                                {
                                    ID = string.Concat("hid_priceList", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField6 = new HiddenField()
                                {
                                    ID = string.Concat("hid_MarkupList", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow row2 in dataTable4.Rows)
                                {
                                    hiddenField4.Value = string.Concat(hiddenField4.Value, row2["Price"].ToString(), "µ");
                                    hiddenField5.Value = string.Concat(hiddenField5.Value, row2["SellingPrice"].ToString(), "µ");
                                    hiddenField6.Value = string.Concat(hiddenField6.Value, row2["Markup"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter2 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter2 = new HtmlTextWriter(stringWriter2))
                                    {
                                        hiddenField4.RenderControl(htmlTextWriter2);
                                        hiddenField5.RenderControl(htmlTextWriter2);
                                        hiddenField6.RenderControl(htmlTextWriter2);
                                    }
                                }
                                HiddenField hiddenField7 = new HiddenField()
                                {
                                    ID = "hdn_ProductStockManagement"
                                };
                                HiddenField str3 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_AvailableQuantity", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable5 = ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCategoryID[this.arrayLength].ToString()));
                                foreach (DataRow dataRow2 in dataTable5.Rows)
                                {
                                    if (Convert.ToBoolean(dataRow2["ProductStockManagement"].ToString()))
                                    {
                                        hiddenField7.Value = "true";
                                    }
                                    if (int.Parse(dataRow2["AvailableQuantity"].ToString()) == 0 || dataRow2["AvailableQuantity"].ToString().Trim().Length <= 0)
                                    {
                                        str3.Value = "0";
                                    }
                                    else
                                    {
                                        str3.Value = dataRow2["AvailableQuantity"].ToString();
                                    }
                                    stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", dataRow2["ProductStockManagement"].ToString().ToLower(), "' />"));
                                    str = new object[] { "<input type='hidden' id='hdnisstockitem", dataRow2["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", dataRow2["IsStockItem"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdndrawstockfrom", dataRow2["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", dataRow2["DrawStockFrom"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdnisbackorder", dataRow2["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", dataRow2["IsBackOrder"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdnavailableqty", dataRow2["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", dataRow2["AvailableQuantity"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    this.IsStockItem = Convert.ToBoolean(dataRow2["IsStockItem"].ToString());
                                }
                                using (StringWriter stringWriter3 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter3 = new HtmlTextWriter(stringWriter3))
                                    {
                                        hiddenField7.RenderControl(htmlTextWriter3);
                                        str3.RenderControl(htmlTextWriter3);
                                    }
                                }
                                HiddenField hiddenField8 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_qtyFromList", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField9 = new HiddenField()
                                {
                                    ID = string.Concat("hid_qtyToList", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow row3 in dataTable4.Rows)
                                {
                                    HiddenField hiddenField10 = hiddenField8;
                                    hiddenField10.Value = string.Concat(hiddenField10.Value, row3["FromQuantity"].ToString(), "µ");
                                    HiddenField hiddenField11 = hiddenField9;
                                    hiddenField11.Value = string.Concat(hiddenField11.Value, row3["ToQuantity"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter4 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                    {
                                        hiddenField8.RenderControl(htmlTextWriter4);
                                        hiddenField9.RenderControl(htmlTextWriter4);
                                    }
                                }
                                str = new object[] { "<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' style='padding-bottom: 5px;' >" };
                                stringBuilder.Append(string.Concat(str));
                                Label label = new Label()
                                {
                                    ID = string.Concat("lbl_priceStartsFrom", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                if (Convert.ToBoolean(this.isPriceStartFrom[this.arrayLength].ToString()))
                                {
                                    short num3 = 1;
                                    foreach (DataRow dataRow3 in dataTable4.Rows)
                                    {
                                        if (num3 == 1)
                                        {
                                            label.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow3["SellingPrice"].ToString()), 2, "", false, false, true));
                                        }
                                        num3 = (short)(num3 + 1);
                                    }
                                    label.CssClass = "priceStartsFromInQuickAdd";
                                }
                                using (StringWriter stringWriter5 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter5 = new HtmlTextWriter(stringWriter5))
                                    {
                                        label.RenderControl(htmlTextWriter5);
                                    }
                                }
                                stringBuilder.Append("</div>");
                                HiddenField hiddenField12 = new HiddenField()
                                {
                                    ID = string.Concat("hdnPriceCatalogueIds", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                    Value = string.Concat(this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable6 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, CompanyID);
                                foreach (DataRow row4 in dataTable6.Rows)
                                {
                                    str = new object[] { hiddenField12.Value, ",", row4["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
                                    hiddenField12.Value = string.Concat(str);
                                }
                                using (StringWriter stringWriter6 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter6 = new HtmlTextWriter(stringWriter6))
                                    {
                                        hiddenField12.RenderControl(htmlTextWriter6);
                                    }
                                }
                                stringBuilder.Append("<div style='padding-left: 35px;' >");
                                DropDownList dropDownList = new DropDownList()
                                {
                                    CssClass = "ddlPriceQtyQuickAdd",
                                    Width = 150,
                                    Height = 22,
                                    ID = string.Concat("ddlOtherMultiplrDrp", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                };
                                dropDownList.CssClass = "dropDownMultipleQuickAdd";
                                dropDownList.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                AttributeCollection attributes = dropDownList.Attributes;
                                str = new object[] { "javascript:ChnageProduct('", this.PriceCategoryID[this.arrayLength].ToString(), "_", this.CopyPriceCatalogueID, "');" };
                                attributes.Add("onchange", string.Concat(str));
                                dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                dropDownList.EnableViewState = true;
                                dropDownList.AutoPostBack = true;
                                this.BindOtherMultipleDropdownList(dataTable6, dropDownList);
                                if (this.NoProductSelected == "true")
                                {
                                    dropDownList.Items.Insert(0, "--Select--");
                                }
                                DataTable dataTable7 = ProductBasePage.OtherMultiple_Default_Select((long)this.CopyPriceCatalogueID);
                                if (dataTable7.Rows.Count > 0 && dataTable7.Rows[0]["KitItemID"] != null)
                                {
                                    this.objBc.SetDDLValue(dropDownList, dataTable7.Rows[0]["KitItemID"].ToString());
                                }
                                using (StringWriter stringWriter7 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter7 = new HtmlTextWriter(stringWriter7))
                                    {
                                        dropDownList.RenderControl(htmlTextWriter7);
                                    }
                                }
                                stringBuilder.Append("</div>");
                                if (this.MatrixType[this.arrayLength].ToString().ToLower() == "p")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    TextBox textBox = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox.Attributes.Add("value", "Qty");
                                    textBox.Style.Add("color", "gray");
                                    textBox.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'p');"));
                                    textBox.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter8 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter8 = new HtmlTextWriter(stringWriter8))
                                        {
                                            textBox.RenderControl(htmlTextWriter8);
                                        }
                                    }
                                }
                                if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;height: 25px;'>");
                                    TextBox textBox1 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox1.Attributes.Add("value", "Qty");
                                    textBox1.Style.Add("color", "gray");
                                    textBox1.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox1.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');"));
                                    textBox1.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox1.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter9 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter9 = new HtmlTextWriter(stringWriter9))
                                        {
                                            textBox1.RenderControl(htmlTextWriter9);
                                        }
                                    }
                                }
                                if (this.MatrixType[this.arrayLength].ToString().ToLower() == "s")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    if (!Convert.ToBoolean(lower.Value))
                                    {
                                        DropDownList languageConversion = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                        languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        languageConversion.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                        this.SimpleMatrix_DropDownBind(dataTable4, languageConversion);
                                        using (StringWriter stringWriter10 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter10 = new HtmlTextWriter(stringWriter10))
                                            {
                                                languageConversion.RenderControl(htmlTextWriter10);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TextBox textBox2 = new TextBox()
                                        {
                                            ID = string.Concat("txt_Cumulative_PriceQty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox2.Attributes.Add("value", "Qty");
                                        textBox2.Style.Add("color", "gray");
                                        textBox2.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                        textBox2.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                        textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                        textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                        DropDownList dropDownList1 = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                        dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        dropDownList1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                        dropDownList1.Style.Add("display", "none");
                                        this.SimpleMatrix_DropDownBind(dataTable4, dropDownList1);
                                        using (StringWriter stringWriter11 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter11 = new HtmlTextWriter(stringWriter11))
                                            {
                                                dropDownList1.RenderControl(htmlTextWriter11);
                                                textBox2.RenderControl(htmlTextWriter11);
                                            }
                                        }
                                    }
                                }
                                str = new object[] { "<div id='divcartqty", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                string uniqueID = string.Empty;
                                uniqueID = this.comm.UniqueID;
                                HiddenField hiddenField13 = new HiddenField()
                                {
                                    ID = string.Concat("hdncookieId", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                    Value = uniqueID
                                };
                                using (StringWriter stringWriter12 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter12 = new HtmlTextWriter(stringWriter12))
                                    {
                                        hiddenField13.RenderControl(htmlTextWriter12);
                                    }
                                }
                                if (this.IsStockItem.ToString().ToLower() == "true")
                                {
                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                    {
                                        str = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")}'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                }
                                else if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                {
                                    strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                else
                                {
                                    strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                str = new object[] { "<img id='btnQucikAddCartLoading", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", Default.strSitePath, "images/radimg1.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<span id='btnQucikAddCartoutofstock", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                str = new object[] { "<div id='divcartWidthHeight", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, "'style='clear:both;padding-left:35px;padding-top:1px;'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                    TextBox textBox3 = new TextBox()
                                    {
                                        ID = string.Concat("txtWidth", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                    };
                                    textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                    textBox3.Style.Add("color", "gray");
                                    textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributeCollection = textBox3.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                    attributeCollection.Add("onBlur", string.Concat(str));
                                    textBox3.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter13 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter13 = new HtmlTextWriter(stringWriter13))
                                        {
                                            textBox3.RenderControl(htmlTextWriter13);
                                        }
                                    }
                                    TextBox textBox4 = new TextBox()
                                    {
                                        ID = string.Concat("txtHeight", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                    };
                                    textBox4.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                    textBox4.Style.Add("color", "gray");
                                    textBox4.Style.Add("margin-left", "8px");
                                    textBox4.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributes1 = textBox4.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                    attributes1.Add("onBlur", string.Concat(str));
                                    textBox4.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter14 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter14 = new HtmlTextWriter(stringWriter14))
                                        {
                                            textBox4.RenderControl(htmlTextWriter14);
                                        }
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                stringBuilder.Append("</div>");
                            }
                        }
                        else if (Convert.ToBoolean(this.isQuickItem[this.arrayLength].ToString()))
                        {
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            strArrays = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCategoryID[this.arrayLength].ToString(), "'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            HiddenField str4 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxName", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField str5 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxRate", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField str6 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxID", this.PriceCategoryID[this.arrayLength].ToString()),
                                Value = "0"
                            };
                            str5.Value = "0";
                            DataTable taxDetailsByProductCatalogueId1 = ProductBasePage.GetTaxDetails_ByProductCatalogueId(CompanyID, Convert.ToInt32(this.PriceCategoryID[this.arrayLength]));
                            foreach (DataRow dataRow4 in taxDetailsByProductCatalogueId1.Rows)
                            {
                                str6.Value = dataRow4["SalesTaxRate"].ToString();
                                str4.Value = dataRow4["TaxName"].ToString();
                                str5.Value = dataRow4["TaxRate"].ToString();
                            }
                            using (StringWriter stringWriter15 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter15 = new HtmlTextWriter(stringWriter15))
                                {
                                    str6.RenderControl(htmlTextWriter15);
                                    str4.RenderControl(htmlTextWriter15);
                                    str5.RenderControl(htmlTextWriter15);
                                }
                            }
                            DataTable dataTable8 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCategoryID[this.arrayLength].ToString()));
                            HiddenField lower1 = new HiddenField();
                            HiddenField str7 = new HiddenField();
                            HiddenField hiddenField14 = new HiddenField();
                            lower1.ID = string.Concat("hdn_IsCumulative_", this.PriceCategoryID[this.arrayLength].ToString());
                            lower1.Value = this.IsCumulativePricinig[this.arrayLength].ToString().ToLower();
                            str7.ID = string.Concat("hdn_SoldInPacks_", this.PriceCategoryID[this.arrayLength].ToString());
                            str7.Value = this.SolodinPacksof[this.arrayLength].ToString();
                            hiddenField14.ID = string.Concat("hdn_MainProductID", this.PriceCategoryID[this.arrayLength].ToString());
                            hiddenField14.Value = "0";
                            HiddenField hiddenField15 = new HiddenField()
                            {
                                ID = string.Concat("hid_PriceCatelogueName", this.PriceCategoryID[this.arrayLength].ToString()),
                                Value = this.objBc.SpecialDecode(this.productName[this.arrayLength].ToString().Trim())
                            };
                            using (StringWriter stringWriter16 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter16 = new HtmlTextWriter(stringWriter16))
                                {
                                    hiddenField15.RenderControl(htmlTextWriter16);
                                    lower1.RenderControl(htmlTextWriter16);
                                    str7.RenderControl(htmlTextWriter16);
                                    hiddenField14.RenderControl(htmlTextWriter16);
                                }
                            }
                            HiddenField hiddenField16 = new HiddenField()
                            {
                                ID = string.Concat("hid_CostExcMarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField17 = new HiddenField()
                            {
                                ID = string.Concat("hid_priceList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField18 = new HiddenField()
                            {
                                ID = string.Concat("hid_MarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            foreach (DataRow row5 in dataTable8.Rows)
                            {
                                hiddenField16.Value = string.Concat(hiddenField16.Value, row5["Price"].ToString(), "µ");
                                hiddenField17.Value = string.Concat(hiddenField17.Value, row5["SellingPrice"].ToString(), "µ");
                                hiddenField18.Value = string.Concat(hiddenField18.Value, row5["Markup"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter17 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                {
                                    hiddenField16.RenderControl(htmlTextWriter17);
                                    hiddenField17.RenderControl(htmlTextWriter17);
                                    hiddenField18.RenderControl(htmlTextWriter17);
                                }
                            }
                            HiddenField hiddenField19 = new HiddenField()
                            {
                                ID = "hdn_ProductStockManagement"
                            };
                            HiddenField str8 = new HiddenField()
                            {
                                ID = string.Concat("hdn_AvailableQuantity", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            DataTable dataTable9 = ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCategoryID[this.arrayLength].ToString()));
                            foreach (DataRow dataRow5 in dataTable9.Rows)
                            {
                                if (Convert.ToBoolean(dataRow5["ProductStockManagement"].ToString()))
                                {
                                    hiddenField19.Value = "true";
                                }
                                if (int.Parse(dataRow5["AvailableQuantity"].ToString()) == 0 || dataRow5["AvailableQuantity"].ToString().Trim().Length <= 0)
                                {
                                    str8.Value = "0";
                                }
                                else
                                {
                                    str8.Value = dataRow5["AvailableQuantity"].ToString();
                                }
                                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", dataRow5["ProductStockManagement"].ToString().ToLower(), "' />"));
                                strArrays = new string[] { "<input type='hidden' id='hdnisstockitem", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["IsStockItem"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(strArrays));
                                strArrays = new string[] { "<input type='hidden' id='hdndrawstockfrom", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["DrawStockFrom"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(strArrays));
                                strArrays = new string[] { "<input type='hidden' id='hdnisbackorder", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["IsBackOrder"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(strArrays));
                                strArrays = new string[] { "<input type='hidden' id='hdnavailableqty", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["AvailableQuantity"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(strArrays));
                                this.IsStockItem = Convert.ToBoolean(dataRow5["IsStockItem"].ToString());
                            }
                            using (StringWriter stringWriter18 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                {
                                    hiddenField19.RenderControl(htmlTextWriter18);
                                    str8.RenderControl(htmlTextWriter18);
                                }
                            }
                            HiddenField hiddenField20 = new HiddenField()
                            {
                                ID = string.Concat("hdn_qtyFromList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField21 = new HiddenField()
                            {
                                ID = string.Concat("hid_qtyToList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            foreach (DataRow row6 in dataTable8.Rows)
                            {
                                HiddenField hiddenField22 = hiddenField20;
                                hiddenField22.Value = string.Concat(hiddenField22.Value, row6["FromQuantity"].ToString(), "µ");
                                HiddenField hiddenField23 = hiddenField21;
                                hiddenField23.Value = string.Concat(hiddenField23.Value, row6["ToQuantity"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter19 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter19 = new HtmlTextWriter(stringWriter19))
                                {
                                    hiddenField20.RenderControl(htmlTextWriter19);
                                    hiddenField21.RenderControl(htmlTextWriter19);
                                }
                            }
                            stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' style='padding-bottom: 5px;' >"));
                            if (Convert.ToBoolean(this.isPriceStartFrom[this.arrayLength].ToString()))
                            {
                                Label label1 = new Label();
                                short num4 = 1;
                                foreach (DataRow dataRow6 in dataTable8.Rows)
                                {
                                    if (num4 == 1)
                                    {
                                        label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow6["SellingPrice"].ToString()), 2, "", false, false, true));
                                    }
                                    num4 = (short)(num4 + 1);
                                }
                                label1.CssClass = "priceStartsFromInQuickAdd";
                                using (StringWriter stringWriter20 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter20 = new HtmlTextWriter(stringWriter20))
                                    {
                                        label1.RenderControl(htmlTextWriter20);
                                    }
                                }
                            }
                            stringBuilder.Append("</div>");
                            if (this.MatrixType[this.arrayLength].ToString().ToLower() == "p")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;' >");
                                TextBox textBox5 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", this.PriceCategoryID[this.arrayLength].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox5.Attributes.Add("value", "Qty");
                                textBox5.Style.Add("color", "gray");
                                textBox5.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                textBox5.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'p');"));
                                textBox5.Attributes.Add("onClick", "this.style.color = '';");
                                textBox5.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                using (StringWriter stringWriter21 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter21 = new HtmlTextWriter(stringWriter21))
                                    {
                                        textBox5.RenderControl(htmlTextWriter21);
                                    }
                                }
                            }
                            if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;height: 25px;'>");
                                TextBox textBox6 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", this.PriceCategoryID[this.arrayLength].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox6.Attributes.Add("value", "Qty");
                                textBox6.Style.Add("color", "gray");
                                textBox6.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                textBox6.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');"));
                                textBox6.Attributes.Add("onClick", "this.style.color = '';");
                                textBox6.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                using (StringWriter stringWriter22 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter22 = new HtmlTextWriter(stringWriter22))
                                    {
                                        textBox6.RenderControl(htmlTextWriter22);
                                    }
                                }
                            }
                            if (this.MatrixType[this.arrayLength].ToString().ToLower() == "s")
                            {
                                stringBuilder.Append("<div style='padding-left: 50px;' >");
                                if (!Convert.ToBoolean(lower1.Value))
                                {
                                    DropDownList languageConversion1 = new DropDownList()
                                    {
                                        CssClass = "ddlPriceQtyQuickAdd",
                                        ID = string.Concat("ddlPriceQty", this.PriceCategoryID[this.arrayLength].ToString())
                                    };
                                    languageConversion1.CssClass = "dropDownMultipleQuickAdd";
                                    languageConversion1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                    languageConversion1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                    this.SimpleMatrix_DropDownBind(dataTable8, languageConversion1);
                                    using (StringWriter stringWriter23 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter23 = new HtmlTextWriter(stringWriter23))
                                        {
                                            languageConversion1.RenderControl(htmlTextWriter23);
                                        }
                                    }
                                }
                                else
                                {
                                    TextBox textBox7 = new TextBox()
                                    {
                                        ID = string.Concat("txt_Cumulative_PriceQty", this.PriceCategoryID[this.arrayLength].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox7.Attributes.Add("value", "Qty");
                                    textBox7.Style.Add("color", "gray");
                                    textBox7.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox7.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                    textBox7.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox7.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    DropDownList dropDownList2 = new DropDownList()
                                    {
                                        CssClass = "ddlPriceQtyQuickAdd",
                                        ID = string.Concat("ddlPriceQty", this.PriceCategoryID[this.arrayLength].ToString())
                                    };
                                    dropDownList2.CssClass = "dropDownMultipleQuickAdd";
                                    dropDownList2.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                    dropDownList2.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                    dropDownList2.Style.Add("display", "none");
                                    this.SimpleMatrix_DropDownBind(dataTable8, dropDownList2);
                                    using (StringWriter stringWriter24 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter24 = new HtmlTextWriter(stringWriter24))
                                        {
                                            dropDownList2.RenderControl(htmlTextWriter24);
                                            textBox7.RenderControl(htmlTextWriter24);
                                        }
                                    }
                                }
                            }
                            string uniqueID1 = string.Empty;
                            uniqueID1 = this.comm.UniqueID;
                            if (this.IsStockItem.ToString().ToLower() == "true")
                            {
                                if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                {
                                    strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")}'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                else
                                {
                                    strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                            }
                            else if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\")'  class='basketbtnQuickAdd' src='", Default.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            strArrays = new string[] { "<img id='btnQucikAddCartLoading", this.PriceCategoryID[this.arrayLength].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", Default.strSitePath, "images/radimg1.gif'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<span id='btnQucikAddCartoutofstock", this.PriceCategoryID[this.arrayLength].ToString(), "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("</div>");
                            if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 60px;padding-top:5px;'>");
                                TextBox textBox8 = new TextBox()
                                {
                                    ID = string.Concat("txtWidth", this.PriceCategoryID[this.arrayLength].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                };
                                textBox8.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                textBox8.Style.Add("color", "gray");
                                textBox8.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributeCollection1 = textBox8.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                attributeCollection1.Add("onBlur", string.Concat(str));
                                textBox8.Attributes.Add("onClick", "this.style.color = '';");
                                using (StringWriter stringWriter25 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter25 = new HtmlTextWriter(stringWriter25))
                                    {
                                        textBox8.RenderControl(htmlTextWriter25);
                                    }
                                }
                                TextBox textBox9 = new TextBox()
                                {
                                    ID = string.Concat("txtHeight", this.PriceCategoryID[this.arrayLength].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                };
                                textBox9.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                textBox9.Style.Add("color", "gray");
                                textBox9.Style.Add("margin-left", "8px");
                                textBox9.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributes2 = textBox9.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                attributes2.Add("onBlur", string.Concat(str));
                                textBox9.Attributes.Add("onClick", "this.style.color = '';");
                                using (StringWriter stringWriter26 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter26 = new HtmlTextWriter(stringWriter26))
                                    {
                                        textBox9.RenderControl(htmlTextWriter26);
                                    }
                                }
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("</div>");
                        }
                        stringBuilder.Append("</div></div>");
                        stringBuilder.Append("</div>");
                        if (this.arrayLength >= this.productName.Count - 1)
                        {
                            break;
                        }
                        this.arrayLength = this.arrayLength + 1;
                    }
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</div>");
                }
                this.plh_NewProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            }
            if (!base.IsPostBack)
            {
                HtmlImage htmlImage = this.imgSucess;
                str = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&aid=", AccountID, " &cid=", CompanyID };
                htmlImage.Src = string.Concat(str);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
                this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
                this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
            }
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
                if (row["systemName"].ToString().Trim() != "home")
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

        public void getProductCatagories(int CompanyID, long AccountID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dt = ProductBasePage.TopSubCatName((long)CompanyID, 0);
            string title = "";
            foreach (DataRow row in ProductBasePage.productsCategoryList_Select((long)CompanyID, AccountID, Default.StoreUserID).Rows)
            {
                string empty = string.Empty;
                empty = (row["PriceCatalogueCategoryName"].ToString().Trim().Length <= 25 ? base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim()) : string.Concat(base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim().Substring(0, 25)), "..."));
                string catid = row["PriceCatalogueCategoryID"].ToString();
                title = "";
                int countSubCat = 0;
                // string subcat = "<div class='subCategory-container'> ";
                string subcat = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["ParentCategoryID"].ToString()) == Convert.ToInt32(catid))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                        {
                            //subcat = subcat  + dt.Rows[i]["PriceCatalogueCategoryName"].ToString();
                            subcat = subcat + "<div class='subCategory-container'  style='display:none'><ul class='subCategoryList'><li> <a href ='" + Default.strSitePath + "products/product.aspx?ID=" + dt.Rows[i]["PriceCatalogueCategoryID"].ToString() + "'>" + dt.Rows[i]["PriceCatalogueCategoryName"].ToString() + "</a></li></ul></div> ";
                        }
                        else
                        {
                            string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, dt.Rows[i]["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                            subcat = subcat + "<div class='subCategory-container'  style='display:none'><ul class='subCategoryList'><li> <a href ='" + base.ResolveUrl(string.Concat(keySeparator)) + "'>" + dt.Rows[i]["PriceCatalogueCategoryName"].ToString() + "</a></li></ul></div> ";
                        }
                        title = title + dt.Rows[i]["PriceCatalogueCategoryName"].ToString();
                        title = title + "~";
                        countSubCat = countSubCat + 1;
                    }
                }
                if (title.EndsWith("~"))
                {
                    title = title.Remove(title.Length - 1, 1);
                }
                if (countSubCat == 0)
                {
                    subcat = "";
                }
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    string[] str = new string[] { "<div  onmouseover=settooltip('" + catid + "') id = 'div" + row["PriceCatalogueCategoryID"].ToString() + "'class='catagoryLists'> &rsaquo; <a href='", Default.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "' title='", title, "'>", empty, "<br/></a></div>", subcat };
                    //string[] str = new string[] { "<div onmouseover=settooltip('" + catid + "') id = 'div" + row["PriceCatalogueCategoryID"].ToString() + "' class='catagoryLists'> &rsaquo; <a href='", Default.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "' title='", base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim()), "'>", empty, "<br/></a></div>" };
                    //string[] str = new string[] { "<div onmouseover=showsubcat('" + catid + "') id = 'div" + row["PriceCatalogueCategoryID"].ToString() + "' class='catagoryLists'> &rsaquo; <a href='", Default.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "'>", empty, "<br/></a></div>" };
                    stringBuilder.Append(string.Concat(str));
                }
                else
                {
                    string[] strArrays = new string[] { "<div class='catagoryLists'> &rsaquo; <a href='", null, null, null, null, null, null };
                    string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, row["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                    strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                    strArrays[2] = "' title='";
                    //strArrays[3] = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                    strArrays[3] = title;
                    strArrays[4] = "'>";
                    strArrays[5] = empty;
                    strArrays[6] = "<br/></a></div>" + subcat;
                    stringBuilder.Append(string.Concat(strArrays));
                }
                Default cntGetProductCatagories = this;
                cntGetProductCatagories.cnt_getProductCatagories = cntGetProductCatagories.cnt_getProductCatagories + 1;
            }
            if (this.isProductCategory != "1")
            {
                this.div_ProductsDetailsList.Style.Add("display", "none");
                return;
            }
            if (this.cnt_getProductCatagories != 0)
            {
                this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                return;
            }
            this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(string.Concat("<div id='noCategoriesFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
            this.div_ProductsDetailsList.Style.Add("display", "none");
        }

        public void getSlidingBanners(long AccountID)
        {
            int num = 0;
            DataTable dataTable = CMSBasePage.Select_BannerImages(AccountID, 0, "H", "Home");
            if (dataTable.Rows.Count <= 0)
            {
                this.isSlidiingBanner = 0;
            }
            else
            {
                this.isSlidiingBanner = 1;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                if (row["bannerImage"].ToString() != "")
                {
                    object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "\\store\\", AccountID, "\\banners\\", row["bannerImage"] };
                    empty = string.Concat(secureDocPath);
                }
                try
                {
                    Bitmap bitmap = new Bitmap(empty);
                    if (num == 0)
                    {
                        this.plh_imageBanner.Controls.Add(new LiteralControl("<ul id='gallery'>"));
                        this.plh_imageBannerDescription.Controls.Add(new LiteralControl("<ul id='excerpt'>"));
                    }
                    object[] item = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", row["bannerImage"], "&amp;type=b&amp;aid=", AccountID, "&amp;cid=", Default.CompanyID };
                    string str = string.Concat(item);
                    if (row["URL"].ToString() == "")
                    {
                        ControlCollection controls = this.plh_imageBanner.Controls;
                        object[] height = new object[] { "<li height='", bitmap.Height, "'><img src='", str, "' alt='", row["bannerTitle"], "' /></li>" };
                        controls.Add(new LiteralControl(string.Concat(height)));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.plh_imageBanner.Controls;
                        object[] objArray = new object[] { "<li height='100'><a href='", row["URL"], "'><img src='", str, "' alt='", row["bannerTitle"], "' /></a></li>" };
                        controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                    }
                    ControlCollection controls1 = this.plh_imageBannerDescription.Controls;
                    object[] item1 = new object[] { "<li><h1><label id='lbl_title_", num, "'>", row["bannerTitle"], "</label></h1>" };
                    controls1.Add(new LiteralControl(string.Concat(item1)));
                    ControlCollection controlCollections1 = this.plh_imageBannerDescription.Controls;
                    object[] objArray1 = new object[] { "<label id='lbl_description_", num, "'>", row["bannerDescription"], "</label></li>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                }
                catch
                {
                }
                num++;
            }
            if (num != 0)
            {
                this.plh_imageBanner.Controls.Add(new LiteralControl("</ul>"));
                this.plh_imageBannerDescription.Controls.Add(new LiteralControl("</ul>"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Default.strBannerPath = ConnectionClass.ImageHandlerPath;
                this.ServerName = ConnectionClass.ServerName;
                if (ConnectionClass.SecureDocPath != null)
                {
                    this.SecureDocPath = ConnectionClass.SecureDocPath;
                }
                if (ConnectionClass.FileExtension != null)
                {
                    this.FileExtension = ConnectionClass.FileExtension;
                }
                if (ConnectionClass.KeySeparator != null)
                {
                    this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
                }
                if (ConnectionClass.ProductImagePath != null)
                {
                    Default.productImagePath = ConnectionClass.ProductImagePath;
                }
                if (ConnectionClass.CatagoryImagePath != null)
                {
                    Default.catagoryImagePath = ConnectionClass.CatagoryImagePath;
                }
                if (ConnectionClass.ImagePath != null)
                {
                    Default.imagePath = ConnectionClass.ImagePath;
                }
                if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
                {
                    Default.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
                }
                if (ConnectionClass.SitePath != null)
                {
                    Default.strSitePath = ConnectionClass.SitePath;
                }
                if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
                {
                    Default.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
                    this.Session["LanguageConversion"] = LoginBasePage.Fetch_LanguageConversionFileName(Default.AccountID);

                }
                if (EprintConfigurationManager.AppSettings["AccountType"].ToString().ToLower() == "public" && ConnectionClass.SystemName != null && ConnectionClass.SystemName == "ppw")
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<div class='ppw_Decsription_Div'>");
                    stringBuilder.Append("<h2><p class='Header_Background'><b><span class='ppw_Decsription_Header'>Progress Printing</span></b></p><p class='paddingBottom10'><span class='ppw_Decsription_Content'>Since");
                    stringBuilder.Append(" our beginnings in 1994, Progress Printing has developed a strong");
                    stringBuilder.Append("reputation for high quality printing and customer service. Located in ");
                    stringBuilder.Append("Condobolin in the Central West of Regional New South Wales, Progress ");
                    stringBuilder.Append("Printing offer printing services Australia-wide. Our reliability, ");
                    stringBuilder.Append("competitive prices and modern equipment allow us to handle a wide range ");
                    stringBuilder.Append("of printing requirements. We focus on quality products, high levels of ");
                    stringBuilder.Append("customer service, satisfaction and on time delivery.<a href='http://www.progressprinting.com.au/cms~79.aspx'>More Info</a></span></p>");
                    stringBuilder.Append("<p class='Header_Background'><b><span class='ppw_Decsription_Header'>Welcome to our Brand New Progress Printing eStore</span></b></p>");
                    stringBuilder.Append("<p><span class='ppw_Decsription_Content'>");
                    stringBuilder.Append("We have set up an online store offering high quality printed and ");
                    stringBuilder.Append("promotional products that you are sure to love. Our Progress eStore is ");
                    stringBuilder.Append("easy to use &amp; navigate, secure, offers a wide range of amazing ");
                    stringBuilder.Append("products and is updated regularly.&nbsp;</span></p>");
                    stringBuilder.Append("</div>");
                    this.lblCustomText.Text = stringBuilder.ToString();
                }
                this.RoundOff = ProductBasePage.Company_RoundOff_Value(Default.CompanyID);
                if (this.comm.GetDisplayValue("isProductCategory", Default.AccountID) == "false")
                {
                    this.isProductCategory = "0";
                }
                if (this.comm.GetDisplayValue("isHomeRightBanner", Default.AccountID) == "false")
                {
                    this.isHomeRightBanner = "0";
                }
                this.AccountType = this.comm.return_AccountType((long)Default.CompanyID, Default.AccountID);
                this.BannerSliderTime = this.comm.return_AccountSliderTime((long)Default.CompanyID, Default.AccountID);
                if (this.BannerSliderTime != "0")
                {
                    this.hdnBannerSliderTime.Value = this.BannerSliderTime;
                }
                else
                {
                    this.hdnBannerSliderTime.Value = "12000";
                }
                if (this.Session["StoreUserID"] == null && this.AccountType == "p" || Default.AccountID == (long)0 && Default.CompanyID == 0)
                {
                    base.Response.Redirect("login.aspx");
                }
                if (this.Session["StoreUserID"] != null)
                {
                    Default.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                }
                this.isRightBanner = this.comm.GetIsRightBanner(Default.CompanyID, Default.AccountID);
                base.Title = commonclass.pageTitle("Home", Convert.ToInt32(Default.CompanyID), Convert.ToInt32(Default.AccountID));
                if (ConnectionClass.RewriteModule != null)
                {
                    this.RewriteModule = ConnectionClass.RewriteModule;
                }
                this.SesseionKey = this.comm.UniqueID;
                this.getProductCatagories(Default.CompanyID, Default.AccountID);
                int num = 0;
                foreach (DataRow row in CMSBasePage.Select_BannerImages(Default.AccountID, 0, "L", "Home").Rows)
                {
                    if (num == 0)
                    {
                        this.plhLeftBanner.Controls.Add(new LiteralControl("<div class='right_div_left left_Banner_Div'>"));
                    }
                    object[] item = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", row["bannerImage"], "&amp;type=b&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                    string str = string.Concat(item);
                    if (row["URL"].ToString() == "")
                    {
                        ControlCollection controls = this.plhLeftBanner.Controls;
                        object[] objArray = new object[] { "<div ><img src='", str, "' class='imgWidth' alt='", row["bannerTitle"], "' /></div>" };
                        controls.Add(new LiteralControl(string.Concat(objArray)));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.plhLeftBanner.Controls;
                        object[] item1 = new object[] { "<div><a href='", row["URL"], "'><img src='", str, "' class='imgWidth' alt='", row["bannerTitle"], "' /></a></div>" };
                        controlCollections.Add(new LiteralControl(string.Concat(item1)));
                    }
                    num++;
                    Default cntLeft = this;
                    cntLeft.cnt_left = cntLeft.cnt_left + 1;
                }
                if (num != 0)
                {
                    this.plhLeftBanner.Controls.Add(new LiteralControl("</div>"));
                }
                if (this.cnt_left > 0)
                {
                    this.count_leftbanner = "1";
                }
                if (this.isHomeRightBanner == "1")
                {
                    int num1 = 0;
                    foreach (DataRow dataRow in CMSBasePage.Select_BannerImages(Default.AccountID, 0, "R", "Home").Rows)
                    {
                        if (num1 == 0)
                        {
                            this.plhRightBanner.Controls.Add(new LiteralControl("<div class='right_div_left right_Banner_Div'>"));
                        }
                        object[] objArray1 = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", dataRow["bannerImage"], "&amp;type=b&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                        string str1 = string.Concat(objArray1);
                        if (dataRow["URL"].ToString() == "")
                        {
                            ControlCollection controls1 = this.plhRightBanner.Controls;
                            object[] item2 = new object[] { "<div><img src='", str1, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' /></div>" };
                            controls1.Add(new LiteralControl(string.Concat(item2)));
                        }
                        else
                        {
                            ControlCollection controlCollections1 = this.plhRightBanner.Controls;
                            object[] objArray2 = new object[] { "<div><a href='", dataRow["URL"], "'><img src='", str1, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' /></a></div>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(objArray2)));
                        }
                        num1++;
                        Default cntRight = this;
                        cntRight.cnt_right = cntRight.cnt_right + 1;
                    }
                    if (num1 != 0)
                    {
                        this.plhRightBanner.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                //if (Templates_Sample.AccountType.ToLower() != "p")
                //{
                //    if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                //    {
                //        this.centerDivWidth = 3;
                //    }
                //    if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 4;
                //        this.marginleft = "-4px";
                //    }
                //    if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories == 0)
                //    {
                //        this.centerDivWidth = 3;
                //    }
                //    if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 3;
                //        this.marginleft = "20px";
                //    }
                //    if (this.cnt_right != 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                //    {
                //        this.centerDivWidth = 3;
                //    }
                //    if (this.cnt_right != 0 && this.isProductCategory != "0" && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 2;
                //        this.marginleft = "17px";
                //    }
                //    if (this.cnt_left != 0 && this.isProductCategory != "0" && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 3;
                //        this.marginleft = "20px";
                //    }
                //    if (this.cnt_left != 0 && this.isProductCategory != "0" && this.cnt_getProductCatagories != 0 && this.cnt_right == 0)
                //    {
                //        this.centerDivWidth = 3;
                //        this.marginleft = "20px";
                //    }
                //    if (this.cnt_right == 0 && this.cnt_left == 0 && this.isProductCategory != "0" && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 3;
                //        this.marginleft = "20px";
                //    }
                //    if (this.cnt_right != 0 && this.cnt_left == 0 && this.cnt_getProductCatagories != 0 && this.isProductCategory == "0")
                //    {
                //        this.centerDivWidth = 3;
                //        this.marginleft = "20px";
                //    }
                //    if (this.cnt_right != 0 && this.cnt_left != 0 && this.cnt_getProductCatagories != 0)
                //    {
                //        this.centerDivWidth = 2;
                //        this.marginleft = "17px";
                //    }
                //    if (this.cnt_right != 0)
                //    {
                //        this.productmarginleft = "10px";
                //        this.paddingleft = "28px";
                //    }
                //    else
                //    {
                //        this.productmarginleft = "13px";
                //        this.paddingleft = "8px";
                //    }
                //}
                //else if (this.cnt_right != 0)
                //{
                //    this.productmarginleft = "10px";
                //    this.paddingleft = "28px";
                //}
                //else
                //{
                //    this.productmarginleft = "13px";
                //    this.paddingleft = "8px";
                //}
                DataTable dataTable = CMSBasePage.homePageSelect((long)0, Default.CompanyID, Convert.ToInt16(Default.AccountID));
                foreach (DataRow row1 in dataTable.Rows)
                {
                    if (row1["IsSliddingBanners"].ToString().ToLower() != "true")
                    {
                        this.div_slidder.Style.Add("display", "none");
                    }
                    else
                    {
                        this.getSlidingBanners(Default.AccountID);
                        if (this.isSlidiingBanner != 0)
                        {
                            this.div_slidder.Style.Add("display", "block");
                        }
                        else
                        {
                            this.div_slidder.Style.Add("display", "none");
                        }
                    }
                    this.lbl_centerPaneltext.Text = row1["CenterPanelText"].ToString();
                    if (row1["CenterPanelOption"].ToString().ToLower() == "featured")
                    {
                        this.getNewProducts(Default.CompanyID, Default.AccountID, "featured");
                        this.div_NewProducts.Style.Add("display", "block");
                        this.div_NewProducts.Style.Add("margin-top", "-10px");
                        this.div_Customize.Style.Add("display", "none");
                        this.div_Customize_new.Style.Add("display", "none");
                        this.div_FeatureProducts.Style.Add("display", "block");
                        this.divCustomTex.Style.Add("display", "block");
                    }
                    else if (row1["CenterPanelOption"].ToString().ToLower() == "new")
                    {
                        this.getNewProducts(Default.CompanyID, Default.AccountID, "new");
                        this.div_NewProducts.Style.Add("display", "block");
                        this.div_Customize.Style.Add("display", "none");
                        this.div_Customize_new.Style.Add("display", "none");
                    }
                    else if (row1["CenterPanelOption"].ToString().ToLower() != "html")
                    {
                        if (row1["CenterPanelOption"].ToString().ToLower() != "custom")
                        {
                            continue;
                        }
                        this.getCutomProductsNew(Default.CompanyID, Default.AccountID, "custom");
                        this.div_NewProducts.Style.Add("display", "none");
                        this.div_Customize.Style.Add("display", "none");
                        this.div_headerCustomer.Style.Add("display", "block");
                        this.div_Customize_new.Style.Add("display", "block");
                    }
                    else
                    {
                        this.getCutomProducts(row1["CustomText"].ToString());
                        this.div_NewProducts.Style.Add("display", "none");
                        this.div_Customize.Style.Add("display", "block");
                        this.div_headerCustomer.Style.Add("display", "block");
                        this.div_Customize_new.Style.Add("display", "none");
                        this.lbl_centerPaneltext.Text = row1["CenterPanelText"].ToString();
                    }
                }
                this.getPageMetaDetails(Default.CompanyID, Convert.ToInt32(Default.AccountID), 0);
                if (base.Request.Params["frm"] != null)
                {
                    this.Session["StoreUserID"] = "";
                    this.Session.Clear();
                    this.Session.Abandon();
                }
            }
            //if (!this.Page.IsPostBack)
            //{
            //    if (this.Session["treeViewState"] == null)
            //    {
            //        this.LoadRootNodes(Default.CompanyID, Default.AccountID, 0);
            //        this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            //        return;
            //    }
            //    string str2 = (string)this.Session["treeViewState"];
            //    this.radCategoryTree.LoadXmlString(str2);
            //}
            //this.BindNavigationPage((long)-3, Default.CompanyID, Default.AccountID);

        }
        //private void AddChildNodes(int CompanyID, long AccountID, RadTreeNode node)
        //{
        //    DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Convert.ToInt32(node.Value), Default.StoreUserID);
        //    node.Nodes.Clear();
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        string empty = string.Empty;
        //        string str = string.Empty;
        //        empty = row["PriceCatalogueCategoryName"].ToString().Trim();
        //        str = row["categoryProductCnt"].ToString().Trim();
        //        RadTreeNode radTreeNode = new RadTreeNode()
        //        {
        //            ImageUrl = string.Concat(Default.imagePath, "close_folder.png")
        //        };
        //        if (ConnectionClass.RewriteModule.ToLower() == "on")
        //        {
        //            if (empty.ToString().Length <= 14)
        //            {
        //                radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
        //                radTreeNode.ToolTip = empty;
        //            }
        //            else
        //            {
        //                radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 14), "...&nbsp;(", str, ")");
        //                radTreeNode.ToolTip = empty;
        //            }
        //        }
        //        else if (empty.ToString().Length <= 14)
        //        {
        //            radTreeNode.Text = empty;
        //            radTreeNode.ToolTip = empty;
        //        }
        //        else
        //        {
        //            radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 14), "...&nbsp;(", str, ")");
        //            radTreeNode.ToolTip = empty;
        //        }
        //        radTreeNode.Value = ((int)row["PriceCatalogueCategoryID"]).ToString();
        //        radTreeNode.Target = "_new";
        //        if ((int)row["SubCatCount"] <= 0)
        //        {
        //            node.Nodes.Add(radTreeNode);
        //        }
        //        else
        //        {
        //            radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
        //            node.Nodes.Add(radTreeNode);
        //        }
        //    }
        //}

        //private void LoadRootNodes(int CompanyID, long AccountID, int Categoryid)
        //{
        //    this.radCategoryTree.Nodes.Clear();
        //    foreach (DataRow row in ProductBasePage.BindTreeView(CompanyID, AccountID, Categoryid, Default.StoreUserID).Rows)
        //    {
        //        string empty = string.Empty;
        //        string str = string.Empty;
        //        string empty1 = string.Empty;
        //        empty = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
        //        str = row["categoryProductCnt"].ToString().Trim();
        //        row["SubCatCount"].ToString().Trim();
        //        RadTreeNode radTreeNode = new RadTreeNode()
        //        {
        //            ImageUrl = string.Concat(Default.imagePath, "close_folder.png")
        //        };
        //        if (ConnectionClass.RewriteModule.ToLower() == "on")
        //        {
        //            if (empty.ToString().Length <= 17)
        //            {
        //                radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
        //                radTreeNode.ToolTip = empty;
        //            }
        //            else
        //            {
        //                radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 17), "...&nbsp;(", str, ")");
        //                radTreeNode.ToolTip = empty;
        //            }
        //        }
        //        else if (empty.ToString().Length <= 17)
        //        {
        //            radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
        //            radTreeNode.ToolTip = empty;
        //        }
        //        else
        //        {
        //            radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 17), "...&nbsp;(", str, ")");
        //            radTreeNode.ToolTip = empty;
        //        }
        //        radTreeNode.Value = ((int)row["PriceCatalogueCategoryID"]).ToString();
        //        radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
        //        this.radCategoryTree.Nodes.Add(radTreeNode);
        //        if ((int)row["SubCatCount"] <= 0)
        //        {
        //            radTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide;
        //        }
        //        else
        //        {
        //            radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
        //        }
        //    }
        //}
        //protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        //{
        //    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
        //}

        //protected void radCategoryTree_NodeClick(object sender, RadTreeNodeEventArgs e)
        //{
        //    string item = (string)this.Session["treeViewState"];
        //    this.radCategoryTree.LoadXmlString(item);
        //    if (ConnectionClass.RewriteModule.ToLower() == "on")
        //    {
        //        HttpResponse response = base.Response;
        //        string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, e.Node.Value.ToString(), ConnectionClass.FileExtension };
        //        response.Redirect(base.ResolveUrl(string.Concat(keySeparator)));
        //        return;
        //    }
        //    RadTreeNode radTreeNode = this.radCategoryTree.FindNodeByValue(e.Node.Value);
        //    if (radTreeNode != null)
        //    {
        //        radTreeNode.Selected = true;
        //    }
        //    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
        //    base.Response.Redirect(string.Concat(Default.strSitePath, "products/product.aspx?ID=", e.Node.Value.ToString()));
        //}

        //protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
        //{
        //    Convert.ToInt32(e.Node.Value);
        //    this.AddChildNodes(Default.CompanyID, Default.AccountID, e.Node);
        //    string item = (string)this.Session["treeViewState"];
        //    RadTreeView radTreeView = new RadTreeView();
        //    radTreeView.LoadXmlString(item);
        //    RadTreeNode radTreeNode = radTreeView.FindNodeByValue(e.Node.Value);
        //    this.AddChildNodes(Default.CompanyID, Default.AccountID, radTreeNode);
        //    radTreeNode.Expanded = true;
        //    this.Session["treeViewState"] = radTreeView.GetXml();
        //}

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
        }

        public void BindAll(long ID, int CompanyID, long AccountID)
        {
            DataSet siteMapData = LoginBasePage.GetSiteMapData(ID, CompanyID, AccountID);
            this.phSiteMap.Controls.Add(new LiteralControl("<ul class='paddingLeft20'>"));
            foreach (DataRow row in siteMapData.Tables[0].Rows)
            {
                //this.phSiteMap.Controls.Add(new LiteralControl("<li class='paddingLeft10'>"));
                this.phSiteMap.Controls.Add(new LiteralControl("<li id='" + row["ID"].ToString() + "'class='paddingLeft10'>"));
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (row["PorC"].ToString().Trim().ToLower() != "p")
                    {
                        ControlCollection controls = this.phSiteMap.Controls;
                        string[] strArrays = new string[] { "<a class='cursorPointer' href='", null, null, null, null };
                        string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, row["ID"].ToString(), ConnectionClass.FileExtension };
                        strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                        strArrays[2] = "'>";
                        strArrays[3] = this.objBc.SpecialDecode(row["Name"].ToString());
                        strArrays[4] = "</a>";
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.phSiteMap.Controls;
                        string[] strArrays1 = new string[] { "<a class='cursorPointer' onclick='Onclick_Product(", row["ID"].ToString().Trim(), ", \"", row["Name"].ToString(), "\")'>", this.objBc.SpecialDecode(row["Name"].ToString()), "</a>" };
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                }
                else if (row["PorC"].ToString().Trim().ToLower() != "p")
                {
                    ControlCollection controls1 = this.phSiteMap.Controls;
                    string[] str = new string[] { "<a class='cursorPointer' href='", Default.strSitePath, "products/product.aspx?ID=", row["ID"].ToString(), "'> ", row["Name"].ToString(), "</a>" };
                    controls1.Add(new LiteralControl(string.Concat(str)));
                }
                else
                {
                    ControlCollection controlCollections1 = this.phSiteMap.Controls;
                    string[] strArrays2 = new string[] { "<a class='cursorPointer' onclick='Onclick_Product(", row["ID"].ToString().Trim(), ",\"", row["Name"].ToString(), "\")'>", row["Name"].ToString(), "</a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                if (row["PorC"].ToString().Trim().ToLower() == "c")
                {
                    this.BindAll(Convert.ToInt64(row["CategoryID"]), CompanyID, AccountID);
                }
                this.phSiteMap.Controls.Add(new LiteralControl("</li>"));
            }
            this.phSiteMap.Controls.Add(new LiteralControl("</ul>"));
        }

        public void BindNavigationPage(long ID, int CompanyID, long AccountID)
        {
            DataSet siteMapData = LoginBasePage.GetSiteMapData(ID, CompanyID, AccountID);
            foreach (DataRow row in siteMapData.Tables[0].Rows)
            {
                this.phSiteMap.Controls.Add(new LiteralControl("<ul>"));
                this.phSiteMap.Controls.Add(new LiteralControl("<li>"));
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (row["systemName"].ToString().Trim().ToLower() == "products")
                    {
                        this.phSiteMap.Controls.Add(new LiteralControl(string.Concat("<a href='#' class='cursorPointer' onclick='Onclick_Productnew();'> ", this.objBc.SpecialDecode(row["Name"].ToString()), "</a>")));
                        this.BindAll((long)0, CompanyID, AccountID);
                    }
                    else if (row["systemName"].ToString().Trim().ToLower() == "home")
                    {
                        ControlCollection controls = this.phSiteMap.Controls;
                        string[] strArrays = new string[] { "<a class='cursorPointer' href='", base.ResolveUrl(Default.strSitePath), "'> ", this.objBc.SpecialDecode(row["Name"].ToString()), "</a>" };
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    else if (row["systemName"].ToString().Trim().ToLower() != "sitemap" && this.AccountType == "x")
                    {
                        ControlCollection controlCollections = this.phSiteMap.Controls;
                        string[] strArrays1 = new string[] { "<a href='", null, null, null, null };
                        object[] objArray = new object[] { Default.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), "/", ConnectionClass.RemoveIllegalChars(row["name"].ToString()), ConnectionClass.KeySeparator, Convert.ToInt32(row["PageID"].ToString()), ConnectionClass.FileExtension };
                        strArrays1[1] = base.ResolveUrl(string.Concat(objArray));
                        strArrays1[2] = "'> ";
                        strArrays1[3] = row["Name"].ToString().Trim();
                        strArrays1[4] = " </a>";
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                }
                else if (row["systemName"].ToString().Trim().ToLower() == "products")
                {
                    this.phSiteMap.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", this.objBc.SpecialDecode(row["Name"].ToString().Trim()), " </a>")));
                    this.BindAll((long)0, CompanyID, AccountID);
                }
                else if (row["systemName"].ToString().Trim().ToLower() == "home")
                {
                    ControlCollection controls1 = this.phSiteMap.Controls;
                    string[] strArrays2 = new string[] { "<a href='", base.ResolveUrl(Default.strSitePath), "'> ", this.objBc.SpecialDecode(row["Name"].ToString()), "</a>" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                else if (row["systemName"].ToString().Trim().ToLower() != "sitemap" && this.AccountType == "x")
                {
                    ControlCollection controlCollections1 = this.phSiteMap.Controls;
                    object[] num = new object[] { "<a href='", Default.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row["PageID"].ToString()), "'> ", this.objBc.SpecialDecode(row["Name"].ToString().Trim().Trim()), "</a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(num)));
                }
                this.phSiteMap.Controls.Add(new LiteralControl("</li>"));
                this.phSiteMap.Controls.Add(new LiteralControl("</ul>"));
            }
        }
    }
}
