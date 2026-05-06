using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore.products
{
    public partial class product : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager SM;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected Button btnQuickNotificationOk;

        //protected Button btnGotoCart;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_nav_catagoty;

        //protected Label lbl_nav;

        //protected HtmlGenericControl divNavigatePannel;

        //protected PlaceHolder plh_ProductsDetailsList;

        //protected HtmlGenericControl div_ProductsDetailsList;

        //protected HtmlGenericControl spn_headding;

        //protected PlaceHolder plh_ProductsDetails;

        //protected PlaceHolder plhRightBanner;

        private commonclass comm = new commonclass();

        private MemoryStream stream = new MemoryStream();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public char KeySeparator;

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public static string imagePath;

        public static string catagoryImagePath;

        public static string productImagePath;

        public static string strSitePath;

        public static string PageName;

        public int priceCatalogueCategoryID;

        public int arrayLength;

        public int cnt_right;

        public int centerDivWidth = 4;

        public int CompanyID;

        public static int companyID;

        public static long AccountID;

        public int productNameLength = 57;

        public int productDescriptionLength = 80;

        public int cnt_getProductCatagories;

        public string marginleft = string.Empty;

        public string productmarginleft = string.Empty;

        public string paddingleft = string.Empty;

        public ArrayList productName = new ArrayList();

        public ArrayList PriceCatalogueCategoryName = new ArrayList();

        public ArrayList productImage = new ArrayList();

        public ArrayList productDescription = new ArrayList();

        public ArrayList PriceCategoryID = new ArrayList();

        public ArrayList Pricetype = new ArrayList();

        public ArrayList PriceCatalogueCategoryID = new ArrayList();

        public ArrayList IsShortDescription = new ArrayList();

        public ArrayList isQuickItem = new ArrayList();

        public ArrayList isPriceStartFrom = new ArrayList();

        public ArrayList MatrixType = new ArrayList();

        public ArrayList IsCumulativePricinig = new ArrayList();

        public ArrayList SolodinPacksof = new ArrayList();

        public static long StoreUserID;

        private bool IsStockItem;

        private int RoundOff;

        public bool IsForceUserLogin;

        public int CopyPriceCatalogueID;

        public long PriceCatalogueID;

        private string CatalogueName = string.Empty;

        private string MatrixType2 = string.Empty;

        private string ProductImage = string.Empty;

        private string ItemTitle = string.Empty;

        private string IsPriceStartsFrom = string.Empty;

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

        static product()
        {
            product.imagePath = string.Empty;
            product.catagoryImagePath = string.Empty;
            product.productImagePath = string.Empty;
            product.strSitePath = string.Empty;
            product.PageName = string.Empty;
            product.companyID = 0;
            product.AccountID = (long)0;
            product.StoreUserID = (long)0;
        }

        public product()
        {
        }

        public void BindOtherMultipleDropdownList(DataTable dtm, DropDownList OtherMultiplrDrp)
        {
            OtherMultiplrDrp.DataSource = dtm;
            OtherMultiplrDrp.DataTextField = "CatalogueName";
            OtherMultiplrDrp.DataValueField = "PriceCatalogueID";
            OtherMultiplrDrp.DataBind();
        }

        public MemoryStream corpImages(int width, int height, byte[] imgfromdatabase)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(imgfromdatabase));
            System.Drawing.Image image1 = null;
            image1 = this.ResizeImage(image, width, height, true);
            MemoryStream memoryStream = new MemoryStream();
            image1.Save(memoryStream, ImageFormat.Jpeg);
            image1.Dispose();
            image.Dispose();
            return memoryStream;
        }

        public void getProductCatagories(int CompanyID, long AccountID)
        {
            string title = "";
            DataTable dt = ProductBasePage.TopSubCatName((long)CompanyID, 0);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in ProductBasePage.productsCategoryList_Select((long)CompanyID, AccountID, product.StoreUserID).Rows)
            {
                string empty = string.Empty;
                if (this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString()).Trim().Length <= 25)
                {
                    empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                }
                else
                {
                    empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
                    empty = string.Concat(empty.Trim().Substring(0, 25), "...");
                }

                string catid = row["PriceCatalogueCategoryID"].ToString();
                title = "";
                int countSubCat = 0;
                //string subcat = "<div class='subCategory-container' > <ul class='subCategoryList' style='display:block;'>";
                string subcat = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["ParentCategoryID"].ToString()) == Convert.ToInt32(catid))
                    {
                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                        {
                            //subcat = subcat  + dt.Rows[i]["PriceCatalogueCategoryName"].ToString();
                            subcat = subcat + "<div class='subCategory-container'  style='display:none'><ul class='subCategoryList'><li> <a href ='" + product.strSitePath + "products/product.aspx?ID=" + dt.Rows[i]["PriceCatalogueCategoryID"].ToString() + "'>" + dt.Rows[i]["PriceCatalogueCategoryName"].ToString() + "</a></li></ul></div> ";
                        }
                        else
                        {
                            string[] keySeparator = new string[] { product.strSitePath, "products", ConnectionClass.KeySeparator, dt.Rows[i]["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                            subcat = subcat + "<div class='subCategory-container'  style='display:none'><ul class='subCategoryList'><li> <a href ='" + base.ResolveUrl(string.Concat(keySeparator)) + "'>" + dt.Rows[i]["PriceCatalogueCategoryName"].ToString() + "</a></li></ul></div> ";
                        }
                        title = title + dt.Rows[i]["PriceCatalogueCategoryName"].ToString();
                        title = title + "~";
                        countSubCat = countSubCat + 1;
                    }
                }
                // subcat = subcat + " </ul></div>";
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
                    //string[] str = new string[] { "<div class='catagoryLists'> &rsaquo; <a href='", product.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "' title='", this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim()), "'>", empty, "<br/></a></div>" };
                    string[] str = new string[] { "<div class='catagoryLists'> &rsaquo; <a href='", product.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "' title='", title, "'>", empty, "<br/></a></div>", subcat };
                    stringBuilder.Append(string.Concat(str));
                }
                else
                {
                    string[] strArrays = new string[] { "<div class='catagoryLists'> &rsaquo; <a href='", null, null, null, null, null, null };
                    string[] keySeparator = new string[] { product.strSitePath, "products", ConnectionClass.KeySeparator, row["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                    strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                    strArrays[2] = "' title='";
                    //strArrays[3] = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                    strArrays[3] = title;
                    strArrays[4] = "'>";
                    strArrays[5] = empty;
                    strArrays[6] = "<br/></a></div>" + subcat;
                    stringBuilder.Append(string.Concat(strArrays));
                }
                product cntGetProductCatagories = this;
                cntGetProductCatagories.cnt_getProductCatagories = cntGetProductCatagories.cnt_getProductCatagories + 1;
            }
            if (this.cnt_getProductCatagories != 0)
            {
                this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                return;
            }
            this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(string.Concat("<div id='noCategoriesFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
            this.div_ProductsDetailsList.Style.Add("display", "none");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] keySeparator;
            object[] item;
            string[] str;
            string[] strArrays;
            string empty = string.Empty;
            if (ConnectionClass.EnableDescription != null)
            {
                empty = ConnectionClass.EnableDescription;
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                product.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.CatagoryImagePath != null)
            {
                product.catagoryImagePath = ConnectionClass.CatagoryImagePath;
            }
            if (ConnectionClass.ImagePath != null)
            {
                product.imagePath = ConnectionClass.ImagePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                product.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SitePath != null)
            {
                product.strSitePath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                product.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.CompanyID != null)
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(product.companyID);
            if (!(AccountType.ToLower() == "p") || !(ConnectionClass.SystemName.ToLower() == "ppw"))
            {
                this.div_ProductsDetailsList.Visible = true;
            }
            else
            {
                this.div_ProductsDetailsList.Visible = false;
            }
            this.AccountType = this.comm.return_AccountType((long)product.companyID, product.AccountID);
            if (this.Session["StoreUserID"] == null && this.AccountType.ToLower() == "p" || this.CompanyID == 0 && product.AccountID == (long)0)
            {
                if (this.Rewritemodule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(product.strSitePath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(product.strSitePath, "login", ConnectionClass.FileExtension));
                }
            }
            if (this.Session["StoreUserID"] != null)
            {
                product.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            }
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["ID"] != null)
                {
                    this.priceCatalogueCategoryID = Convert.ToInt32(base.Request.Params["ID"]);
                }
            }
            else if (RewriteContext.Current.Params["ID"] != null)
            {
                try
                {
                    string str1 = RewriteContext.Current.Params["ID"].ToString();
                    keySeparator = new char[] { this.KeySeparator };
                    this.priceCatalogueCategoryID = Convert.ToInt32(str1.Split(keySeparator)[1]);
                }
                catch
                {
                }
            }
            if (this.comm.GetDisplayValue("IsHome", product.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(product.companyID, Convert.ToInt32(product.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            foreach (DataRow row in LoginBasePage.Select_PublicUserAccountDetails((long)this.CompanyID, product.AccountID).Rows)
            {
                this.IsForceUserLogin = Convert.ToBoolean(row["IsForceUser"]);
            }
            if (this.priceCatalogueCategoryID == 0)
            {
                base.Title = commonclass.pageTitle("Product category list", Convert.ToInt32(product.companyID), Convert.ToInt32(product.AccountID));
            }
            else
            {
                base.Title = commonclass.pageTitle("Products list", Convert.ToInt32(product.companyID), Convert.ToInt32(product.AccountID));
            }
            this.getProductCatagories(this.CompanyID, product.AccountID);
            int num = 0;
            foreach (DataRow dataRow in CMSBasePage.Select_BannerImages(product.AccountID, 0, "R", "Products").Rows)
            {
                if (num == 0)
                {
                    this.plhRightBanner.Controls.Add(new LiteralControl("<div id='right_div'>"));
                }
                item = new object[] { product.strSitePath, "ImageHandler.ashx?Imagename=", dataRow["bannerImage"], "&amp;type=b&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                string str2 = string.Concat(item);
                if (dataRow["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhRightBanner.Controls;
                    item = new object[] { "<div><img src='", str2, "' class='imgWidth cursorDefault' alt='", dataRow["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(item)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhRightBanner.Controls;
                    item = new object[] { "<div><a href='", dataRow["URL"], "'><img src='", str2, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item)));
                }
                num++;
                product cntRight = this;
                cntRight.cnt_right = cntRight.cnt_right + 1;
            }
            if (num != 0)
            {
                this.plhRightBanner.Controls.Add(new LiteralControl("</div>"));
            }
            if (AccountType.ToLower() == "p")
            {
                if (this.cnt_right != 0)
                {
                    this.centerDivWidth = 2;
                    this.marginleft = "10px";
                    this.productmarginleft = "10px";
                    this.paddingleft = "28px";
                }
                else
                {
                    this.centerDivWidth = 3;
                    this.marginleft = "13px";
                    this.productmarginleft = "13px";
                    this.paddingleft = "8px";
                }
            }
            else if (this.cnt_right != 0)
            {
                this.centerDivWidth = 2;
                this.marginleft = "10px";
                this.productmarginleft = "10px";
                this.paddingleft = "28px";
            }
            else
            {
                this.centerDivWidth = 3;
                this.marginleft = "13px";
                this.productmarginleft = "13px";
                this.paddingleft = "8px";
            }
            if (this.priceCatalogueCategoryID == 0)
            {
                try
                {
                    this.spn_headding.InnerText = this.objLanguage.GetLanguageConversion("Product_Categories");
                    this.lbl_nav.Text = string.Concat("> ", this.objLanguage.GetLanguageConversion("Product_Categories"));
                    DataTable dataTable = ProductBasePage.productsCategoryList_Select((long)product.companyID, product.AccountID, product.StoreUserID);
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        this.PriceCatalogueCategoryID.Add(row1["PriceCatalogueCategoryID"].ToString());
                        this.productName.Add(row1["PriceCatalogueCategoryName"].ToString());
                        this.productDescription.Add(row1["Description"].ToString());
                        this.productImage.Add(row1["CategoryImage"].ToString());
                    }
                    if (dataTable.Rows.Count <= 0)
                    {
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
                    }
                    else
                    {
                        int count = this.productName.Count / this.centerDivWidth;
                        double count1 = (double)this.productName.Count / Convert.ToDouble(this.centerDivWidth);
                        int num1 = 0;
                        if ((double)count != count1)
                        {
                            num1 = count + 1;
                        }
                        else
                        {
                            num1 = count;
                            if (num1 == 0)
                            {
                                num1 = count + 1;
                            }
                        }
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int i = 0; i < num1; i++)
                        {
                            stringBuilder.Append(string.Concat("<div style='text-align: -webkit-center;margin-left:", this.marginleft, ";text-align: -webkit-center;'>"));
                            stringBuilder.Append("<div class='row'>");
                            for (int j = 0; j < this.centerDivWidth; j++)
                            {
                                stringBuilder.Append(string.Concat("<div class='col-lg-4 col-md-4 col-sm-3' style='padding-left: ", this.paddingleft, "; padding-right: 1px;'>"));
                                stringBuilder.Append("<div class='productDetails_div'><div class='productDetails_Style'>");
                                string empty1 = string.Empty;
                                empty1 = (this.productName[this.arrayLength].ToString().Trim().Length <= this.productNameLength ? this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim()) : this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim().Substring(0, this.productNameLength)));
                                empty1 = this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim());
                                stringBuilder.Append("<div class='productName_div'>");
                                stringBuilder.Append(string.Concat("<label>", empty1, "</label>"));
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("<div class='clearBoth'></div>");
                                stringBuilder.Append("<div class='productImage_div'  >");
                                if (this.productImage[this.arrayLength].ToString() != "")
                                {
                                    item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_", this.productImage[this.arrayLength].ToString(), "&amp;type=c&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                    this.finalimageName1 = string.Concat(item);
                                }
                                else
                                {
                                    item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                    this.finalimageName1 = string.Concat(item);
                                }
                                string str3 = this.productImage[this.arrayLength].ToString().Trim();
                                keySeparator = new char[] { '.' };
                                string[] strArrays1 = str3.Split(keySeparator);
                                if (strArrays1[(int)strArrays1.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                {
                                    try
                                    {
                                        item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\ProductCatalogueCategory\\t_", this.productImage[this.arrayLength].ToString() };
                                        string str4 = string.Concat(item);
                                        System.Drawing.Image image = System.Drawing.Image.FromFile(str4);
                                        FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
                                        int frameCount = image.GetFrameCount(frameDimension);
                                        int num2 = 200;
                                        int num3 = 150;
                                        if (image.Width < 200 && image.Height < 150)
                                        {
                                            num2 = Convert.ToInt32(image.Width);
                                            num3 = Convert.ToInt32(image.Height);
                                        }
                                        System.Drawing.Image image1 = System.Drawing.Image.FromFile(str4);
                                        if (frameCount > 0)
                                        {
                                            string str5 = createImageThumnail.FixedSizeForGif(str4, image1, num2, num3, false);
                                            keySeparator = new char[] { '~' };
                                            string[] strArrays2 = str5.Split(keySeparator);
                                            int num4 = Convert.ToInt16(strArrays2[0]);
                                            int num5 = Convert.ToInt16(strArrays2[1]);
                                            if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                stringBuilder.Append("<div class='productList_productImage_div'>");
                                                item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img  style='height:", num5, "px;width:", num4, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" class='Catagory_Image' alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(item));
                                                stringBuilder.Append("</div>");
                                            }
                                            else
                                            {
                                                stringBuilder.Append("<div class='productList_productImage_div'>");
                                                item = new object[] { "<a href='", null, null, null, null, null, null, null, null, null, null };
                                                str = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                item[1] = base.ResolveUrl(string.Concat(str));
                                                item[2] = "'><img  style='height:";
                                                item[3] = num5;
                                                item[4] = "px;width:";
                                                item[5] = num4;
                                                item[6] = "px;' title='";
                                                item[7] = this.productName[this.arrayLength].ToString().Trim();
                                                item[8] = "' src=\"";
                                                item[9] = this.finalimageName1;
                                                item[10] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(item));
                                                stringBuilder.Append("</div>");
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            stringBuilder.Append("<div class='productList_productImage_div'>");
                                            str = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" class='Catagory_Image' alt=' '/></a>" };
                                            stringBuilder.Append(string.Concat(str));
                                            stringBuilder.Append("</div>");
                                        }
                                        else
                                        {
                                            stringBuilder.Append("<div class='productList_productImage_div'>");
                                            str = new string[] { "<a href='", null, null, null, null, null, null };
                                            strArrays = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                            str[1] = base.ResolveUrl(string.Concat(strArrays));
                                            str[2] = "'><img title='";
                                            str[3] = this.productName[this.arrayLength].ToString().Trim();
                                            str[4] = "' src=\"";
                                            str[5] = this.finalimageName1;
                                            str[6] = "\" alt=' '/></a>";
                                            stringBuilder.Append(string.Concat(str));
                                            stringBuilder.Append("</div>");
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                    }
                                }
                                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                {
                                    stringBuilder.Append("<div class='productList_productImage_div'>");
                                    str = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" class='Catagory_Image' alt=' '/></a>" };
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append("</div>");
                                }
                                else
                                {
                                    stringBuilder.Append("<div class='productList_productImage_div'>");
                                    str = new string[] { "<a href='", null, null, null, null, null, null };
                                    strArrays = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                    str[1] = base.ResolveUrl(string.Concat(strArrays));
                                    str[2] = "'><img title='";
                                    str[3] = this.productName[this.arrayLength].ToString().Trim();
                                    str[4] = "' src=\"";
                                    str[5] = this.finalimageName1;
                                    str[6] = "\" class='Catagory_Image' alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append("</div>");
                                }
                                this.finalimageName1 = "";
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("<div class='clearBoth'></div>");
                                string empty2 = string.Empty;
                                empty2 = this.objBase.SpecialDecode(this.productDescription[this.arrayLength].ToString().Trim());
                                empty2 = empty2.Replace("\n", "<br >");
                                stringBuilder.Append(string.Concat("<div class='productCategoryDescription_div' title='", this.productDescription[this.arrayLength].ToString().Trim(), "'>"));
                                if (empty.ToLower() == "true" || empty == "")
                                {
                                    stringBuilder.Append(string.Concat("<label class='heightAuto' > ", empty2, "</label>"));
                                }
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("<div class='clearBoth'></div>");
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
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                    }
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    this.spn_headding.InnerText = this.objLanguage.GetLanguageConversion("Products_List");
                    this.lbl_nav_catagoty.Text = this.objLanguage.GetLanguageConversion("Product_Categories");
                    DataTable dataTable1 = ProductBasePage.productListImage(product.companyID, this.priceCatalogueCategoryID, Convert.ToInt32(product.AccountID));
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        this.PriceCategoryID.Add(dataRow1["PriceCatalogueID"].ToString());
                        this.productName.Add(dataRow1["CatalogueName"].ToString());
                        this.productDescription.Add(dataRow1["ShortDescription"].ToString());
                        this.productImage.Add(dataRow1["ProductImage"].ToString());
                        this.PriceCatalogueCategoryName.Add(dataRow1["PriceCatalogueCategoryName"].ToString());
                        this.Pricetype.Add(dataRow1["Type"].ToString());
                        ArrayList isShortDescription = this.IsShortDescription;
                        int num6 = Convert.ToInt32(dataRow1["IsShortDescription"]);
                        isShortDescription.Add(num6.ToString());
                        ArrayList arrayLists = this.isQuickItem;
                        bool flag = Convert.ToBoolean(dataRow1["isQuickItem"]);
                        arrayLists.Add(flag.ToString());
                        this.isPriceStartFrom.Add(Convert.ToBoolean(dataRow1["IsPriceStartFrom"].ToString()));
                        this.MatrixType.Add(dataRow1["MatrixType"].ToString());
                        this.IsCumulativePricinig.Add(dataRow1["IsCumulativePricing"].ToString());
                        this.SolodinPacksof.Add(dataRow1["SoldInPacksOf"].ToString());
                    }
                    if (this.productName.Count == 0)
                    {
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
                    }
                    else
                    {
                        this.lbl_nav.Text = string.Concat(" > ", this.objBase.SpecialDecode(this.PriceCatalogueCategoryName[0].ToString()));
                        int count2 = this.productName.Count / this.centerDivWidth;
                        double count3 = (double)this.productName.Count / (double)this.centerDivWidth;
                        int num7 = 0;
                        if ((double)count2 != count3)
                        {
                            num7 = count2 + 1;
                        }
                        else
                        {
                            num7 = count2;
                            if (num7 == 0)
                            {
                                num7 = count2 + 1;
                            }
                        }
                        StringBuilder stringBuilder1 = new StringBuilder();
                        for (int k = 0; k < num7; k++)
                        {
                            stringBuilder1.Append(string.Concat("<div   style='margin-left:", this.productmarginleft, ";text-align: -webkit-center;'>"));
                            stringBuilder1.Append("<div class='row'>");
                            if (this.productName.Count <= this.centerDivWidth)
                            {
                                this.centerDivWidth = this.productName.Count;
                            }
                            for (int l = 0; l < this.centerDivWidth; l++)
                            {
                                if (this.Pricetype[this.arrayLength].ToString().ToLower() == "c")
                                {
                                    stringBuilder1.Append(string.Concat("<div class='col-lg-4 col-xs-12' style='padding-left: ", this.paddingleft, "; padding-right: 1px;'>"));
                                    stringBuilder1.Append("<div class='productDetails_div'><div class='productDetails_Style' >");
                                    string empty3 = string.Empty;
                                    empty3 = (this.productName[this.arrayLength].ToString().Trim().Length <= this.productNameLength ? this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim()) : this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim().Substring(0, this.productNameLength)));
                                    stringBuilder1.Append("<div  class='productName_div'>");
                                    stringBuilder1.Append(string.Concat("<label>", empty3, "</label>"));
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    stringBuilder1.Append("<div class='productImage_div'>");
                                    if (this.productImage[this.arrayLength].ToString() != "")
                                    {
                                        item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_", this.productImage[this.arrayLength].ToString(), "&amp;type=c&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                        this.finalimageName1 = string.Concat(item);
                                    }
                                    else
                                    {
                                        item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                        this.finalimageName1 = string.Concat(item);
                                    }
                                    string str6 = this.productImage[this.arrayLength].ToString().Trim();
                                    keySeparator = new char[] { '.' };
                                    string[] strArrays3 = str6.Split(keySeparator);
                                    if (strArrays3[(int)strArrays3.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                    {
                                        try
                                        {
                                            item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\Product\\", this.productImage[this.arrayLength].ToString() };
                                            string str7 = string.Concat(item);
                                            System.Drawing.Image image2 = System.Drawing.Image.FromFile(str7);
                                            FrameDimension frameDimension1 = new FrameDimension(image2.FrameDimensionsList[0]);
                                            int frameCount1 = image2.GetFrameCount(frameDimension1);
                                            int num8 = 200;
                                            int num9 = 150;
                                            if (image2.Width < 200 && image2.Height < 150)
                                            {
                                                num8 = Convert.ToInt32(image2.Width);
                                                num9 = Convert.ToInt32(image2.Height);
                                            }
                                            System.Drawing.Image image3 = System.Drawing.Image.FromFile(str7);
                                            if (frameCount1 > 0)
                                            {
                                                string str8 = createImageThumnail.FixedSizeForGif(str7, image3, num8, num9, false);
                                                keySeparator = new char[] { '~' };
                                                string[] strArrays4 = str8.Split(keySeparator);
                                                int num10 = Convert.ToInt16(strArrays4[0]);
                                                int num11 = Convert.ToInt16(strArrays4[1]);
                                                if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage'  style='height:", num11, "px;width:", num10, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                    stringBuilder1.Append("</div>");
                                                }
                                                else
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    item = new object[13];
                                                    item[0] = "<a href='";
                                                    str = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                    item[1] = base.ResolveUrl(string.Concat(str));
                                                    item[2] = "'><img id='imgGetID2";
                                                    item[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                    item[4] = "' onmouseover='getTitle(this.id)' runat='server'  style='height:";
                                                    item[5] = num11;
                                                    item[6] = "px;width:";
                                                    item[7] = num10;
                                                    item[8] = "px;' title='";
                                                    item[9] = this.productName[this.arrayLength].ToString().Trim();
                                                    item[10] = "' src=\"";
                                                    item[11] = this.finalimageName1;
                                                    item[12] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                    stringBuilder1.Append(string.Concat(item));
                                                    stringBuilder1.Append("</div>");
                                                }
                                            }
                                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                str = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' class='ProductCatagoryImage' runat='server' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                                stringBuilder1.Append("</div>");
                                            }
                                            else
                                            {
                                                stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                strArrays = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img id='imgGetID2";
                                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                str[4] = "' onmouseover='getTitle(this.id)' runat='server' title='";
                                                str[5] = this.productName[this.arrayLength].ToString().Trim();
                                                str[6] = "' src=\"";
                                                str[7] = this.finalimageName1;
                                                str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                stringBuilder1.Append(string.Concat(str));
                                                stringBuilder1.Append("</div>");
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                    {
                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                        str = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "'  onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder1.Append(string.Concat(str));
                                        stringBuilder1.Append("</div>");
                                    }
                                    else
                                    {
                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        strArrays = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img id='imgGetID2";
                                        str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                        str[4] = "' onmouseover='getTitle(this.id)' runat='server' title='";
                                        str[5] = this.productName[this.arrayLength].ToString().Trim();
                                        str[6] = "' src=\"";
                                        str[7] = this.finalimageName1;
                                        str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                        stringBuilder1.Append(string.Concat(str));
                                        stringBuilder1.Append("</div>");
                                    }
                                    this.finalimageName1 = "";
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    string empty4 = string.Empty;
                                    empty4 = this.objBase.SpecialDecode(this.productDescription[this.arrayLength].ToString().Trim());
                                    empty4 = empty4.Replace("\n", "<br >");
                                    stringBuilder1.Append(string.Concat("<div class='productCategoryDescription_div'  title='", this.productDescription[this.arrayLength].ToString().Trim(), "'>"));
                                    stringBuilder1.Append(string.Concat("<label> ", empty4, "</label>"));
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    stringBuilder1.Append("</div></div>");
                                    stringBuilder1.Append("</div>");
                                    if (this.arrayLength >= this.productName.Count - 1)
                                    {
                                        break;
                                    }
                                    this.arrayLength = this.arrayLength + 1;
                                }
                                else if (this.Pricetype[this.arrayLength].ToString().ToLower() == "p")
                                {
                                    DataTable dataTable2 = new DataTable();
                                    try
                                    {
                                        if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
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
                                                this.PriceCatalogueID = (long)this.CopyPriceCatalogueID;
                                            }
                                            if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["KitItemID"] != null)
                                            {
                                                this.PriceCatalogueID = Convert.ToInt64(dataTable3.Rows[0]["KitItemID"]);
                                            }
                                            dataTable2 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCatalogueID));
                                            IEnumerator enumerator = dataTable2.Rows.GetEnumerator();
                                            try
                                            {
                                                if (enumerator.MoveNext())
                                                {
                                                    DataRow current = (DataRow)enumerator.Current;
                                                    this.ProductImage = current["ProductImage"].ToString();
                                                    this.CatalogueName = current["CatalogueName"].ToString();
                                                    this.MatrixType2 = current["MatrixType"].ToString();
                                                    this.ItemTitle = current["CatalogueName"].ToString();
                                                    this.IsPriceStartsFrom = current["IsPriceStartFrom"].ToString();
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
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    stringBuilder1.Append(string.Concat("<div class='col-lg-4 col-xs-12' style='padding-left: ", this.paddingleft, "; padding-right: 1px;'>"));
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                    {
                                        str = new string[] { "<div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                                        stringBuilder1.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        item = new object[] { "<div  id='divmainHover", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' onmouseover='mouseovershow1(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\");' onmouseout='mouseOutHidediv1(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                                        stringBuilder1.Append(string.Concat(item));
                                    }
                                    string empty5 = string.Empty;
                                    empty5 = (this.productName[this.arrayLength].ToString().Trim().Length <= this.productNameLength ? this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim()) : this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim().Substring(0, this.productNameLength)));
                                    str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  class='productName_div'>" };
                                    stringBuilder1.Append(string.Concat(str));
                                    stringBuilder1.Append(string.Concat("<label>", empty5, "</label>"));
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                    {
                                        str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  class='productImage_div'>" };
                                        stringBuilder1.Append(string.Concat(str));
                                        if (this.productImage[this.arrayLength].ToString() != "")
                                        {
                                            item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=", this.productImage[this.arrayLength].ToString(), "&amp;type=p&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                            this.finalimageName1 = string.Concat(item);
                                        }
                                        else
                                        {
                                            item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                            this.finalimageName1 = string.Concat(item);
                                        }
                                    }
                                    else if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                                    {
                                        stringBuilder1.Append("<div class='productImage_div'  >");
                                        if (this.ProductImage.ToString() != "")
                                        {
                                            item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=", this.ProductImage, "&amp;type=p&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                            this.finalimageName1 = string.Concat(item);
                                        }
                                        else
                                        {
                                            item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                            this.finalimageName1 = string.Concat(item);
                                        }
                                        string str9 = this.ProductImage.ToString().Trim();
                                        keySeparator = new char[] { '.' };
                                        string[] strArrays5 = str9.Split(keySeparator);
                                        if (strArrays5[(int)strArrays5.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                        {
                                            try
                                            {
                                                item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\Product\\", this.ProductImage.ToString() };
                                                string str10 = string.Concat(item);
                                                System.Drawing.Image image4 = System.Drawing.Image.FromFile(str10);
                                                FrameDimension frameDimension2 = new FrameDimension(image4.FrameDimensionsList[0]);
                                                int frameCount2 = image4.GetFrameCount(frameDimension2);
                                                int num12 = 200;
                                                int num13 = 150;
                                                if (image4.Width < 200 && image4.Height < 150)
                                                {
                                                    num12 = Convert.ToInt32(image4.Width);
                                                    num13 = Convert.ToInt32(image4.Height);
                                                }
                                                System.Drawing.Image image5 = System.Drawing.Image.FromFile(str10);
                                                if (frameCount2 > 0)
                                                {
                                                    string str11 = createImageThumnail.FixedSizeForGif(str10, image5, num12, num13, false);
                                                    keySeparator = new char[] { '~' };
                                                    string[] strArrays6 = str11.Split(keySeparator);
                                                    int num14 = Convert.ToInt16(strArrays6[0]);
                                                    int num15 = Convert.ToInt16(strArrays6[1]);
                                                    if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                    {
                                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                        if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                        {
                                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.CopyPriceCatalogueID.ToString(), "&amp;type=0'><img id='imgGetID8", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' style='height:", num15, "px;width:", num14, "px;' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        else
                                                        {
                                                            item = new object[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.CatalogueName.ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), "\");'><img id='imgGetID8", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' class='ProductCatagoryImage' runat='server' style='height:", num15, "px;width:", num14, "px;' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        stringBuilder1.Append("</div>");
                                                    }
                                                    else
                                                    {
                                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                        if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                        {
                                                            item = new object[13];
                                                            item[0] = "<a href='";
                                                            str = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.CopyPriceCatalogueID.ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                            item[1] = base.ResolveUrl(string.Concat(str));
                                                            item[2] = "'><img  id='imgGetID7";
                                                            item[3] = this.CopyPriceCatalogueID.ToString();
                                                            item[4] = "' onmouseover='getTitle(this.id)' runat='server' style='height:";
                                                            item[5] = num15;
                                                            item[6] = "px;width:";
                                                            item[7] = num14;
                                                            item[8] = "px;'  title='";
                                                            item[9] = this.CatalogueName.ToString();
                                                            item[10] = "' src=\"";
                                                            item[11] = this.finalimageName1;
                                                            item[12] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        else
                                                        {
                                                            item = new object[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.CopyPriceCatalogueID.ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), "\");'><img  id='imgGetID7", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' style='height:", num15, "px;width:", num14, "px;'  title='", this.CatalogueName.ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        stringBuilder1.Append("</div>");
                                                    }
                                                }
                                                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                    {
                                                        str = new string[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.CopyPriceCatalogueID.ToString(), "&amp;type=0'><img id='imgGetID8", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    else
                                                    {
                                                        str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.CopyPriceCatalogueID.ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), "\");'><img id='imgGetID8", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                                else
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                    {
                                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                        strArrays = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.CopyPriceCatalogueID.ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                        str[2] = "'><img  id='imgGetID7";
                                                        str[3] = this.CopyPriceCatalogueID.ToString();
                                                        str[4] = "' onmouseover='getTitle(this.id)' runat='server' title='";
                                                        str[5] = this.CatalogueName.ToString();
                                                        str[6] = "' src=\"";
                                                        str[7] = this.finalimageName1;
                                                        str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    else
                                                    {
                                                        str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.CopyPriceCatalogueID.ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), "\");'><img  id='imgGetID7", this.CopyPriceCatalogueID.ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.CatalogueName.ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            stringBuilder1.Append("<div class='productList_productImage_div'>");
                                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                            {
                                                str = new string[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("<div class='productList_productImage_div'>");
                                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                strArrays = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img  id='imgGetID7";
                                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                str[4] = "' onmouseover='getTitle(this.id)' runat='server' title='";
                                                str[5] = this.productName[this.arrayLength].ToString();
                                                str[6] = "' src=\"";
                                                str[7] = this.finalimageName1;
                                                str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='javascript:void(0);'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");' ><img  id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                    }
                                    string str12 = this.productImage[this.arrayLength].ToString().Trim();
                                    keySeparator = new char[] { '.' };
                                    string[] strArrays7 = str12.Split(keySeparator);
                                    string str13 = strArrays7[(int)strArrays7.Length - 1].ToString().ToLower().Trim();
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                    {
                                        if (str13.ToLower() == "gif")
                                        {
                                            try
                                            {
                                                item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\Product\\", this.productImage[this.arrayLength].ToString() };
                                                string str14 = string.Concat(item);
                                                System.Drawing.Image image6 = System.Drawing.Image.FromFile(str14);
                                                FrameDimension frameDimension3 = new FrameDimension(image6.FrameDimensionsList[0]);
                                                int frameCount3 = image6.GetFrameCount(frameDimension3);
                                                int num16 = 200;
                                                int num17 = 150;
                                                if (image6.Width < 200 && image6.Height < 150)
                                                {
                                                    num16 = Convert.ToInt32(image6.Width);
                                                    num17 = Convert.ToInt32(image6.Height);
                                                }
                                                System.Drawing.Image image7 = System.Drawing.Image.FromFile(str14);
                                                if (frameCount3 > 0)
                                                {
                                                    string str15 = createImageThumnail.FixedSizeForGif(str14, image7, num16, num17, false);
                                                    keySeparator = new char[] { '~' };
                                                    string[] strArrays8 = str15.Split(keySeparator);
                                                    int num18 = Convert.ToInt16(strArrays8[0]);
                                                    int num19 = Convert.ToInt16(strArrays8[1]);
                                                    if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                    {
                                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                        if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                        {
                                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage'class='ProductCatagoryImage' style='height:", num19, "px;width:", num18, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        else
                                                        {
                                                            item = new object[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' style='height:", num19, "px;width:", num18, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        stringBuilder1.Append("</div>");
                                                    }
                                                    else
                                                    {
                                                        stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                        if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                        {
                                                            item = new object[13];
                                                            item[0] = "<a href='";
                                                            str = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                            item[1] = base.ResolveUrl(string.Concat(str));
                                                            item[2] = "'><img  id='imgGetID7";
                                                            item[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                            item[4] = "' onmouseover='getTitle(this.id)' runat='server' style='height:";
                                                            item[5] = num19;
                                                            item[6] = "px;width:";
                                                            item[7] = num18;
                                                            item[8] = "px;'  title='";
                                                            item[9] = this.productName[this.arrayLength].ToString();
                                                            item[10] = "' src=\"";
                                                            item[11] = this.finalimageName1;
                                                            item[12] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        else
                                                        {
                                                            item = new object[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img  id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' style='height:", num19, "px;width:", num18, "px;'  title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                            stringBuilder1.Append(string.Concat(item));
                                                        }
                                                        stringBuilder1.Append("</div>");
                                                    }
                                                }
                                                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                    {
                                                        str = new string[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    else
                                                    {
                                                        str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                                else
                                                {
                                                    stringBuilder1.Append("<div class='productList_productImage_div'>");
                                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                    {
                                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                        strArrays = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                        str[2] = "'><img  id='imgGetID7";
                                                        str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                        str[4] = "' onmouseover='getTitle(this.id)' runat='server' title='";
                                                        str[5] = this.productName[this.arrayLength].ToString();
                                                        str[6] = "' src=\"";
                                                        str[7] = this.finalimageName1;
                                                        str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    else
                                                    {
                                                        str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img  id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(str));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            stringBuilder1.Append("<div class='productList_productImage_div'>");
                                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                            {
                                                str = new string[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' class='ProductCatagoryImage' runat='server' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='javascript:void(0);' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("<div class='productList_productImage_div'>");
                                            if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                strArrays = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img  id='imgGetID7";
                                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                str[4] = "' onmouseover='getTitle(this.id)' class='ProductCatagoryImage' runat='server' title='";
                                                str[5] = this.productName[this.arrayLength].ToString();
                                                str[6] = "' src=\"";
                                                str[7] = this.finalimageName1;
                                                str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='javascript:void(0);'  onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");' ><img  id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' onmouseover='getTitle(this.id)' runat='server' class='ProductCatagoryImage' title='", this.productName[this.arrayLength].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                    }
                                    this.finalimageName1 = "";
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    string empty6 = string.Empty;
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                    {
                                        if (dataTable1.Rows[this.arrayLength]["ShortDescription"] != null && dataTable1.Rows[this.arrayLength]["ShortDescription"].ToString().Trim() != "" && Convert.ToBoolean(dataTable1.Rows[this.arrayLength]["IsShortDescription"]))
                                        {
                                            empty6 = this.objBase.SpecialDecode(this.productDescription[this.arrayLength].ToString().Trim());
                                        }
                                        empty6 = empty6.Replace("\n", "<br >");
                                    }
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                    {
                                        item = new object[] { "<div id='DivDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  align='center' class='productDescription_div' >" };
                                        stringBuilder1.Append(string.Concat(item));
                                    }
                                    else
                                    {
                                        foreach (DataRow row2 in dataTable2.Rows)
                                        {
                                            if (row2["Description"] == null || !(row2["Description"].ToString().Trim() != "") || !Convert.ToBoolean(row2["IsShortDescription"]))
                                            {
                                                continue;
                                            }
                                            empty6 = this.objBase.SpecialDecode(row2["Description"].ToString().Trim());
                                            break;
                                        }
                                        empty6 = empty6.Replace("\n", "<br >");
                                        item = new object[] { "<div id='DivDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  align='center' class='productDescription_div' >" };
                                        stringBuilder1.Append(string.Concat(item));
                                    }
                                    item = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' class='textalignCenter'> ", empty6, "</label>" };
                                    stringBuilder1.Append(string.Concat(item));
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("<div class='clearBoth'></div>");
                                    stringBuilder1.Append("<div class='MarginTopProductButton'>");
                                    str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productViewBtn_div' align='center'>" };
                                    stringBuilder1.Append(string.Concat(str));
                                    if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                    {
                                        str = new string[] { "<input type='button' id='btnviewdetails", this.PriceCategoryID[this.arrayLength].ToString(), "' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='WS_Buttons_Style' onclick='Onclick_Product(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'/>" };
                                        stringBuilder1.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<input type='button' id='btnviewdetails", this.PriceCategoryID[this.arrayLength].ToString(), "' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='WS_Buttons_Style' onclick='Onclick_Login(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'/>" };
                                        stringBuilder1.Append(string.Concat(str));
                                    }
                                    stringBuilder1.Append(string.Concat("<div id='div_process", this.PriceCategoryID[this.arrayLength].ToString(), "'  class='WS_Buttons_Style displayNone ppw_btn_process' align='center'>"));
                                    stringBuilder1.Append(string.Concat("<img src='", product.imagePath, "radimg1.gif'   alt='loading' border='0' style='margin-top:-2px;'/>"));
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("</div>");
                                    stringBuilder1.Append("</div>");
                                    if (dataTable1.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                                    {
                                        this.CopyPriceCatalogueID = Convert.ToInt32(this.PriceCategoryID[this.arrayLength]);
                                        if (Convert.ToBoolean(this.isQuickItem[this.arrayLength].ToString()))
                                        {
                                            stringBuilder1.Append("<div class='clearBoth'></div>");
                                            item = new object[] { "<div onmouseover='mouseovershow(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'>" };
                                            stringBuilder1.Append(string.Concat(item));
                                            HiddenField hiddenField = new HiddenField()
                                            {
                                                ID = string.Concat("hid_TaxName", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            HiddenField hiddenField1 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_TaxRate", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            HiddenField hiddenField2 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_TaxID", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                Value = "0"
                                            };
                                            hiddenField1.Value = "0";
                                            DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(this.CompanyID, Convert.ToInt32(this.PriceCatalogueID));
                                            foreach (DataRow dataRow2 in taxDetailsByProductCatalogueId.Rows)
                                            {
                                                hiddenField2.Value = dataRow2["SalesTaxRate"].ToString();
                                                hiddenField.Value = dataRow2["TaxName"].ToString();
                                                hiddenField1.Value = dataRow2["TaxRate"].ToString();
                                            }
                                            using (StringWriter stringWriter = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter))
                                                {
                                                    hiddenField2.RenderControl(htmlTextWriter);
                                                    hiddenField.RenderControl(htmlTextWriter);
                                                    hiddenField1.RenderControl(htmlTextWriter);
                                                }
                                            }
                                            HiddenField lower = new HiddenField();
                                            HiddenField hiddenField3 = new HiddenField();
                                            HiddenField hiddenField4 = new HiddenField();
                                            lower.ID = string.Concat("hdn_IsCumulative_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                            hiddenField3.ID = string.Concat("hdn_SoldInPacks_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                            hiddenField4.ID = string.Concat("hdn_MainProductID", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                            hiddenField4.Value = this.CopyPriceCatalogueID.ToString();
                                            foreach (DataRow row3 in dataTable2.Rows)
                                            {
                                                lower.Value = row3["IsCumulativePricing"].ToString().ToLower();
                                                hiddenField3.Value = row3["SoldInPacksof"].ToString();
                                            }
                                            HiddenField hiddenField5 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_PriceCatelogueName", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                Value = this.objBase.SpecialDecode(this.ItemTitle)
                                            };
                                            using (StringWriter stringWriter1 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter1 = new HtmlTextWriter(stringWriter1))
                                                {
                                                    hiddenField5.RenderControl(htmlTextWriter1);
                                                    lower.RenderControl(htmlTextWriter1);
                                                    hiddenField3.RenderControl(htmlTextWriter1);
                                                    hiddenField4.RenderControl(htmlTextWriter1);
                                                }
                                            }
                                            HiddenField hiddenField6 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_CostExcMarkupList", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            HiddenField hiddenField7 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_priceList", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            HiddenField hiddenField8 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_MarkupList", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            foreach (DataRow dataRow3 in dataTable2.Rows)
                                            {
                                                hiddenField6.Value = string.Concat(hiddenField6.Value, dataRow3["Price"].ToString(), "µ");
                                                hiddenField7.Value = string.Concat(hiddenField7.Value, dataRow3["SellingPrice"].ToString(), "µ");
                                                hiddenField8.Value = string.Concat(hiddenField8.Value, dataRow3["Markup"].ToString(), "µ");
                                            }
                                            using (StringWriter stringWriter2 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter2 = new HtmlTextWriter(stringWriter2))
                                                {
                                                    hiddenField6.RenderControl(htmlTextWriter2);
                                                    hiddenField7.RenderControl(htmlTextWriter2);
                                                    hiddenField8.RenderControl(htmlTextWriter2);
                                                }
                                            }
                                            HiddenField hiddenField9 = new HiddenField()
                                            {
                                                ID = "hdn_ProductStockManagement"
                                            };
                                            HiddenField hiddenField10 = new HiddenField()
                                            {
                                                ID = string.Concat("hdn_AvailableQuantity", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            foreach (DataRow row4 in ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCatalogueID)).Rows)
                                            {
                                                if (Convert.ToBoolean(row4["ProductStockManagement"].ToString()))
                                                {
                                                    hiddenField9.Value = "true";
                                                }
                                                if (int.Parse(row4["AvailableQuantity"].ToString()) == 0 || row4["AvailableQuantity"].ToString().Trim().Length <= 0)
                                                {
                                                    hiddenField10.Value = "0";
                                                }
                                                else
                                                {
                                                    hiddenField10.Value = row4["AvailableQuantity"].ToString();
                                                }
                                                stringBuilder1.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", row4["ProductStockManagement"].ToString().ToLower(), "' />"));
                                                item = new object[] { "<input type='hidden' id='hdnisstockitem", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", row4["IsStockItem"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdndrawstockfrom", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", row4["DrawStockFrom"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdnisbackorder", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", row4["IsBackOrder"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdnavailableqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", row4["AvailableQuantity"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                this.IsStockItem = Convert.ToBoolean(row4["IsStockItem"].ToString());
                                            }
                                            using (StringWriter stringWriter3 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter3 = new HtmlTextWriter(stringWriter3))
                                                {
                                                    hiddenField9.RenderControl(htmlTextWriter3);
                                                    hiddenField10.RenderControl(htmlTextWriter3);
                                                }
                                            }
                                            HiddenField hiddenField11 = new HiddenField()
                                            {
                                                ID = string.Concat("hdn_qtyFromList", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            HiddenField hiddenField12 = new HiddenField()
                                            {
                                                ID = string.Concat("hid_qtyToList", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            foreach (DataRow dataRow4 in dataTable2.Rows)
                                            {
                                                HiddenField hiddenField13 = hiddenField11;
                                                hiddenField13.Value = string.Concat(hiddenField13.Value, dataRow4["FromQuantity"].ToString(), "µ");
                                                HiddenField hiddenField14 = hiddenField12;
                                                hiddenField14.Value = string.Concat(hiddenField14.Value, dataRow4["ToQuantity"].ToString(), "µ");
                                            }
                                            using (StringWriter stringWriter4 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                                {
                                                    hiddenField11.RenderControl(htmlTextWriter4);
                                                    hiddenField12.RenderControl(htmlTextWriter4);
                                                }
                                            }
                                            stringBuilder1.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' style='padding-bottom: 5px;' >"));
                                            Label label = new Label()
                                            {
                                                ID = string.Concat("lbl_priceStartsFrom", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            if (Convert.ToBoolean(this.IsPriceStartsFrom.ToString()))
                                            {
                                                short num20 = 1;
                                                foreach (DataRow row5 in dataTable2.Rows)
                                                {
                                                    if (num20 == 1)
                                                    {
                                                        label.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row5["SellingPrice"].ToString()), 2, "", false, false, true));
                                                    }
                                                    num20 = (short)(num20 + 1);
                                                }
                                                label.CssClass = "priceStartsFromInQuickAdd";
                                            }
                                            using (StringWriter stringWriter5 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter5 = new HtmlTextWriter(stringWriter5))
                                                {
                                                    label.RenderControl(htmlTextWriter5);
                                                }
                                            }
                                            stringBuilder1.Append("</div>");
                                            HiddenField hiddenField15 = new HiddenField()
                                            {
                                                ID = string.Concat("hdnPriceCatalogueIds", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                Value = string.Concat(this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID)
                                            };
                                            DataTable dataTable4 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, product.companyID);
                                            foreach (DataRow dataRow5 in dataTable4.Rows)
                                            {
                                                item = new object[] { hiddenField15.Value, ",", dataRow5["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
                                                hiddenField15.Value = string.Concat(item);
                                            }
                                            using (StringWriter stringWriter6 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter6 = new HtmlTextWriter(stringWriter6))
                                                {
                                                    hiddenField15.RenderControl(htmlTextWriter6);
                                                }
                                            }
                                            stringBuilder1.Append("<div style='padding-left: 35px;' >");
                                            DropDownList dropDownList = new DropDownList()
                                            {
                                                CssClass = "ddlPriceQtyQuickAdd",
                                                Width = 150,
                                                Height = 22,
                                                ID = string.Concat("ddlOtherMultiplrDrp", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                            };
                                            dropDownList.CssClass = "dropDownMultipleQuickAdd";
                                            dropDownList.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                            AttributeCollection attributes = dropDownList.Attributes;
                                            item = new object[] { "javascript:ChnageProduct('", this.PriceCatalogueID, "_", this.CopyPriceCatalogueID, "');" };
                                            attributes.Add("onchange", string.Concat(item));
                                            dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                            dropDownList.EnableViewState = true;
                                            dropDownList.AutoPostBack = true;
                                            this.BindOtherMultipleDropdownList(dataTable4, dropDownList);
                                            if (this.NoProductSelected == "true")
                                            {
                                                dropDownList.Items.Insert(0, "--Select--");
                                            }
                                            DataTable dataTable5 = ProductBasePage.OtherMultiple_Default_Select((long)this.CopyPriceCatalogueID);
                                            if (dataTable5.Rows.Count > 0 && dataTable5.Rows[0]["KitItemID"] != null)
                                            {
                                                this.objBase.SetDDLValue(dropDownList, dataTable5.Rows[0]["KitItemID"].ToString());
                                            }
                                            using (StringWriter stringWriter7 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter7 = new HtmlTextWriter(stringWriter7))
                                                {
                                                    dropDownList.RenderControl(htmlTextWriter7);
                                                }
                                            }
                                            stringBuilder1.Append("</div>");
                                            if (this.MatrixType2.ToString().ToLower() == "p")
                                            {
                                                stringBuilder1.Append("<div style='padding-left: 35px;'>");
                                                TextBox textBox = new TextBox()
                                                {
                                                    ID = string.Concat("txtPriceBandQty", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                    CssClass = "txtStyleQuickAdd",
                                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                                };
                                                textBox.Attributes.Add("value", "Qty");
                                                textBox.Style.Add("color", "gray");
                                                textBox.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                                AttributeCollection attributeCollection = textBox.Attributes;
                                                item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'p');" };
                                                attributeCollection.Add("onBlur", string.Concat(item));
                                                textBox.Attributes.Add("onClick", "this.style.color = '';");
                                                textBox.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                                using (StringWriter stringWriter8 = new StringWriter(stringBuilder1))
                                                {
                                                    using (HtmlTextWriter htmlTextWriter8 = new HtmlTextWriter(stringWriter8))
                                                    {
                                                        textBox.RenderControl(htmlTextWriter8);
                                                    }
                                                }
                                            }
                                            if (this.MatrixType2.ToString().ToLower() == "g")
                                            {
                                                stringBuilder1.Append("<div style='padding-left: 35px;height: 25px;'>");
                                                TextBox textBox1 = new TextBox()
                                                {
                                                    ID = string.Concat("txtPriceBandQty", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                    CssClass = "txtStyleQuickAdd",
                                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                                };
                                                textBox1.Attributes.Add("value", "Qty");
                                                textBox1.Style.Add("color", "gray");
                                                textBox1.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                                AttributeCollection attributes1 = textBox1.Attributes;
                                                item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                                attributes1.Add("onBlur", string.Concat(item));
                                                textBox1.Attributes.Add("onClick", "this.style.color = '';");
                                                textBox1.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                                using (StringWriter stringWriter9 = new StringWriter(stringBuilder1))
                                                {
                                                    using (HtmlTextWriter htmlTextWriter9 = new HtmlTextWriter(stringWriter9))
                                                    {
                                                        textBox1.RenderControl(htmlTextWriter9);
                                                    }
                                                }
                                            }
                                            if (this.MatrixType2.ToString().ToLower() == "s")
                                            {
                                                stringBuilder1.Append("<div style='padding-left: 35px;' >");
                                                if (!Convert.ToBoolean(lower.Value))
                                                {
                                                    DropDownList languageConversion = new DropDownList()
                                                    {
                                                        CssClass = "ddlPriceQtyQuickAdd",
                                                        ID = string.Concat("ddlPriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                                    };
                                                    languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                                    languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                                    AttributeCollection attributeCollection1 = languageConversion.Attributes;
                                                    item = new object[] { "javascript:quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                                    attributeCollection1.Add("onchange", string.Concat(item));
                                                    this.SimpleMatrix_DropDownBind(dataTable2, languageConversion);
                                                    using (StringWriter stringWriter10 = new StringWriter(stringBuilder1))
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
                                                        ID = string.Concat("txt_Cumulative_PriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                        CssClass = "txtStyleQuickAdd",
                                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                                    };
                                                    textBox2.Attributes.Add("value", "Qty");
                                                    textBox2.Style.Add("color", "gray");
                                                    textBox2.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                                    AttributeCollection attributes2 = textBox2.Attributes;
                                                    item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                                    attributes2.Add("onBlur", string.Concat(item));
                                                    textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                                    textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                                    DropDownList dropDownList1 = new DropDownList()
                                                    {
                                                        CssClass = "ddlPriceQtyQuickAdd",
                                                        ID = string.Concat("ddlPriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                                    };
                                                    dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                                    dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                                    AttributeCollection attributeCollection2 = dropDownList1.Attributes;
                                                    item = new object[] { "javascript:quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                                    attributeCollection2.Add("onchange", string.Concat(item));
                                                    dropDownList1.Style.Add("display", "none");
                                                    this.SimpleMatrix_DropDownBind(dataTable2, dropDownList1);
                                                    using (StringWriter stringWriter11 = new StringWriter(stringBuilder1))
                                                    {
                                                        using (HtmlTextWriter htmlTextWriter11 = new HtmlTextWriter(stringWriter11))
                                                        {
                                                            dropDownList1.RenderControl(htmlTextWriter11);
                                                            textBox2.RenderControl(htmlTextWriter11);
                                                        }
                                                    }
                                                }
                                            }
                                            item = new object[] { "<div id='divcartqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'>" };
                                            stringBuilder1.Append(string.Concat(item));
                                            stringBuilder1.Append("</div>");
                                            string uniqueID = string.Empty;
                                            uniqueID = this.comm.UniqueID;
                                            HiddenField hiddenField16 = new HiddenField()
                                            {
                                                ID = string.Concat("hdncookieId", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID),
                                                Value = uniqueID
                                            };
                                            using (StringWriter stringWriter12 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter12 = new HtmlTextWriter(stringWriter12))
                                                {
                                                    hiddenField16.RenderControl(htmlTextWriter12);
                                                }
                                            }
                                            if (this.IsStockItem.ToString().ToLower() == "true")
                                            {
                                                if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                                {
                                                    item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower().Trim(), "\",\"", uniqueID, "\",", this.PriceCatalogueID, ")}'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                else
                                                {
                                                    item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.priceCatalogueCategoryID, ",\"0\");'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                            }
                                            else if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                            {
                                                item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType2.ToString().ToLower().Trim(), "\",\"", uniqueID, "\"", this.PriceCatalogueID, ")'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                stringBuilder1.Append(string.Concat(item));
                                            }
                                            else
                                            {
                                                item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "' onclick='Onclick_Login(", this.priceCatalogueCategoryID, ",\"0\");' class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                stringBuilder1.Append(string.Concat(item));
                                            }
                                            item = new object[] { "<img id='btnQucikAddCartLoading", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", product.strSitePath, "images/radimg1.gif'>" };
                                            stringBuilder1.Append(string.Concat(item));
                                            item = new object[] { "<span id='btnQucikAddCartoutofstock", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                            stringBuilder1.Append(string.Concat(item));
                                            stringBuilder1.Append("</div>");
                                            item = new object[] { "<div id='divcartWidthHeight", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'style='clear:both;padding-left:35px;padding-top:1px;'>" };
                                            stringBuilder1.Append(string.Concat(item));
                                            stringBuilder1.Append("</div>");
                                            if (this.MatrixType2.ToString().ToLower() == "g")
                                            {
                                                stringBuilder1.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                                TextBox textBox3 = new TextBox()
                                                {
                                                    ID = string.Concat("txtWidth", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                    CssClass = "txtStyleQuickAdd",
                                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                                };
                                                textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                                textBox3.Style.Add("color", "gray");
                                                textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                                AttributeCollection attributes3 = textBox3.Attributes;
                                                item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                                attributes3.Add("onBlur", string.Concat(item));
                                                textBox3.Attributes.Add("onClick", "this.style.color = '';");
                                                using (StringWriter stringWriter13 = new StringWriter(stringBuilder1))
                                                {
                                                    using (HtmlTextWriter htmlTextWriter13 = new HtmlTextWriter(stringWriter13))
                                                    {
                                                        textBox3.RenderControl(htmlTextWriter13);
                                                    }
                                                }
                                                TextBox textBox4 = new TextBox()
                                                {
                                                    ID = string.Concat("txtHeight", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                                    CssClass = "txtStyleQuickAdd",
                                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                                };
                                                textBox4.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                                textBox4.Style.Add("color", "gray");
                                                textBox4.Style.Add("margin-left", "8px");
                                                textBox4.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                                AttributeCollection attributeCollection3 = textBox4.Attributes;
                                                item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                                attributeCollection3.Add("onBlur", string.Concat(item));
                                                textBox4.Attributes.Add("onClick", "this.style.color = '';");
                                                using (StringWriter stringWriter14 = new StringWriter(stringBuilder1))
                                                {
                                                    using (HtmlTextWriter htmlTextWriter14 = new HtmlTextWriter(stringWriter14))
                                                    {
                                                        textBox4.RenderControl(htmlTextWriter14);
                                                    }
                                                }
                                                stringBuilder1.Append("</div>");
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                    }
                                    else if (Convert.ToBoolean(this.isQuickItem[this.arrayLength].ToString()))
                                    {
                                        stringBuilder1.Append("<div class='clearBoth'></div>");
                                        str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCategoryID[this.arrayLength].ToString(), "'>" };
                                        stringBuilder1.Append(string.Concat(str));
                                        HiddenField str16 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxName", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        HiddenField hiddenField17 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxRate", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        HiddenField str17 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxID", this.PriceCategoryID[this.arrayLength].ToString()),
                                            Value = "0"
                                        };
                                        hiddenField17.Value = "0";
                                        DataTable taxDetailsByProductCatalogueId1 = ProductBasePage.GetTaxDetails_ByProductCatalogueId(this.CompanyID, Convert.ToInt32(this.PriceCategoryID[this.arrayLength]));
                                        foreach (DataRow row6 in taxDetailsByProductCatalogueId1.Rows)
                                        {
                                            str17.Value = row6["SalesTaxRate"].ToString();
                                            str16.Value = row6["TaxName"].ToString();
                                            hiddenField17.Value = row6["TaxRate"].ToString();
                                        }
                                        using (StringWriter stringWriter15 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter15 = new HtmlTextWriter(stringWriter15))
                                            {
                                                str17.RenderControl(htmlTextWriter15);
                                                str16.RenderControl(htmlTextWriter15);
                                                hiddenField17.RenderControl(htmlTextWriter15);
                                            }
                                        }
                                        DataTable dataTable6 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCategoryID[this.arrayLength].ToString()));
                                        HiddenField lower1 = new HiddenField();
                                        HiddenField hiddenField18 = new HiddenField();
                                        HiddenField hiddenField19 = new HiddenField();
                                        lower1.ID = string.Concat("hdn_IsCumulative_", this.PriceCategoryID[this.arrayLength].ToString());
                                        lower1.Value = this.IsCumulativePricinig[this.arrayLength].ToString().ToLower();
                                        hiddenField18.ID = string.Concat("hdn_SoldInPacks_", this.PriceCategoryID[this.arrayLength].ToString());
                                        hiddenField18.Value = this.SolodinPacksof[this.arrayLength].ToString();
                                        hiddenField19.ID = string.Concat("hdn_MainProductID", this.PriceCategoryID[this.arrayLength].ToString());
                                        hiddenField19.Value = "0";
                                        HiddenField hiddenField20 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_PriceCatelogueName", this.PriceCategoryID[this.arrayLength].ToString()),
                                            Value = this.objBase.SpecialDecode(this.productName[this.arrayLength].ToString().Trim())
                                        };
                                        using (StringWriter stringWriter16 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter16 = new HtmlTextWriter(stringWriter16))
                                            {
                                                hiddenField20.RenderControl(htmlTextWriter16);
                                                lower1.RenderControl(htmlTextWriter16);
                                                hiddenField18.RenderControl(htmlTextWriter16);
                                                hiddenField19.RenderControl(htmlTextWriter16);
                                            }
                                        }
                                        HiddenField hiddenField21 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_CostExcMarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        HiddenField hiddenField22 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_priceList", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        HiddenField hiddenField23 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_MarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        foreach (DataRow dataRow6 in dataTable6.Rows)
                                        {
                                            hiddenField21.Value = string.Concat(hiddenField21.Value, dataRow6["Price"].ToString(), "µ");
                                            hiddenField22.Value = string.Concat(hiddenField22.Value, dataRow6["SellingPrice"].ToString(), "µ");
                                            hiddenField23.Value = string.Concat(hiddenField23.Value, dataRow6["Markup"].ToString(), "µ");
                                        }
                                        using (StringWriter stringWriter17 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                            {
                                                hiddenField21.RenderControl(htmlTextWriter17);
                                                hiddenField22.RenderControl(htmlTextWriter17);
                                                hiddenField23.RenderControl(htmlTextWriter17);
                                            }
                                        }
                                        HiddenField hiddenField24 = new HiddenField()
                                        {
                                            ID = "hdn_ProductStockManagement"
                                        };
                                        HiddenField str18 = new HiddenField()
                                        {
                                            ID = string.Concat("hdn_AvailableQuantity", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        DataTable dataTable7 = ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCategoryID[this.arrayLength].ToString()));
                                        foreach (DataRow row7 in dataTable7.Rows)
                                        {
                                            if (Convert.ToBoolean(row7["ProductStockManagement"].ToString()))
                                            {
                                                hiddenField24.Value = "true";
                                            }
                                            if (int.Parse(row7["AvailableQuantity"].ToString()) == 0 || row7["AvailableQuantity"].ToString().Trim().Length <= 0)
                                            {
                                                str18.Value = "0";
                                            }
                                            else
                                            {
                                                str18.Value = row7["AvailableQuantity"].ToString();
                                            }
                                            stringBuilder1.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", row7["ProductStockManagement"].ToString().ToLower(), "' />"));
                                            str = new string[] { "<input type='hidden' id='hdnisstockitem", row7["pricecatalogueid"].ToString(), "' value='", row7["IsStockItem"].ToString(), "' />" };
                                            stringBuilder1.Append(string.Concat(str));
                                            str = new string[] { "<input type='hidden' id='hdndrawstockfrom", row7["pricecatalogueid"].ToString(), "' value='", row7["DrawStockFrom"].ToString(), "' />" };
                                            stringBuilder1.Append(string.Concat(str));
                                            str = new string[] { "<input type='hidden' id='hdnisbackorder", row7["pricecatalogueid"].ToString(), "' value='", row7["IsBackOrder"].ToString(), "' />" };
                                            stringBuilder1.Append(string.Concat(str));
                                            str = new string[] { "<input type='hidden' id='hdnavailableqty", row7["pricecatalogueid"].ToString(), "' value='", row7["AvailableQuantity"].ToString(), "' />" };
                                            stringBuilder1.Append(string.Concat(str));
                                            this.IsStockItem = Convert.ToBoolean(row7["IsStockItem"].ToString());
                                        }
                                        using (StringWriter stringWriter18 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                            {
                                                hiddenField24.RenderControl(htmlTextWriter18);
                                                str18.RenderControl(htmlTextWriter18);
                                            }
                                        }
                                        HiddenField hiddenField25 = new HiddenField()
                                        {
                                            ID = string.Concat("hdn_qtyFromList", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        HiddenField hiddenField26 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_qtyToList", this.PriceCategoryID[this.arrayLength].ToString())
                                        };
                                        foreach (DataRow dataRow7 in dataTable6.Rows)
                                        {
                                            HiddenField hiddenField27 = hiddenField25;
                                            hiddenField27.Value = string.Concat(hiddenField27.Value, dataRow7["FromQuantity"].ToString(), "µ");
                                            HiddenField hiddenField28 = hiddenField26;
                                            hiddenField28.Value = string.Concat(hiddenField28.Value, dataRow7["ToQuantity"].ToString(), "µ");
                                        }
                                        using (StringWriter stringWriter19 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter19 = new HtmlTextWriter(stringWriter19))
                                            {
                                                hiddenField25.RenderControl(htmlTextWriter19);
                                                hiddenField26.RenderControl(htmlTextWriter19);
                                            }
                                        }
                                        stringBuilder1.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' style='padding-bottom: 5px;' >"));
                                        if (Convert.ToBoolean(this.isPriceStartFrom[this.arrayLength].ToString()))
                                        {
                                            Label label1 = new Label();
                                            short num21 = 1;
                                            foreach (DataRow row8 in dataTable6.Rows)
                                            {
                                                if (num21 == 1)
                                                {
                                                    label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row8["SellingPrice"].ToString()), 2, "", false, false, true));
                                                }
                                                num21 = (short)(num21 + 1);
                                            }
                                            label1.CssClass = "priceStartsFromInQuickAdd";
                                            using (StringWriter stringWriter20 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter20 = new HtmlTextWriter(stringWriter20))
                                                {
                                                    label1.RenderControl(htmlTextWriter20);
                                                }
                                            }
                                        }
                                        stringBuilder1.Append("</div>");
                                        if (this.MatrixType[this.arrayLength].ToString().ToLower() == "p")
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 60px;' >");
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
                                            using (StringWriter stringWriter21 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter21 = new HtmlTextWriter(stringWriter21))
                                                {
                                                    textBox5.RenderControl(htmlTextWriter21);
                                                }
                                            }
                                        }
                                        if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 60px;height: 25px;'>");
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
                                            using (StringWriter stringWriter22 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter22 = new HtmlTextWriter(stringWriter22))
                                                {
                                                    textBox6.RenderControl(htmlTextWriter22);
                                                }
                                            }
                                        }
                                        if (this.MatrixType[this.arrayLength].ToString().ToLower() == "s")
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 35px;' >");
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
                                                this.SimpleMatrix_DropDownBind(dataTable6, languageConversion1);
                                                using (StringWriter stringWriter23 = new StringWriter(stringBuilder1))
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
                                                this.SimpleMatrix_DropDownBind(dataTable6, dropDownList2);
                                                using (StringWriter stringWriter24 = new StringWriter(stringBuilder1))
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
                                                str = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")}'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                stringBuilder1.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='Onclick_Login(", this.priceCatalogueCategoryID, ",\"0\");'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                                stringBuilder1.Append(string.Concat(item));
                                            }
                                        }
                                        else if (!this.IsForceUserLogin || this.Session["StoreUserID"] != null)
                                        {
                                            str = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID1, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")'  class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                            stringBuilder1.Append(string.Concat(str));
                                        }
                                        else
                                        {
                                            item = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "' onclick='Onclick_Login(", this.priceCatalogueCategoryID, ",\"0\");' class='basketbtnQuickAdd' src='", product.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                            stringBuilder1.Append(string.Concat(item));
                                        }
                                        str = new string[] { "<img id='btnQucikAddCartLoading", this.PriceCategoryID[this.arrayLength].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", product.strSitePath, "images/radimg1.gif'>" };
                                        stringBuilder1.Append(string.Concat(str));
                                        str = new string[] { "<span id='btnQucikAddCartoutofstock", this.PriceCategoryID[this.arrayLength].ToString(), "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                        stringBuilder1.Append(string.Concat(str));
                                        stringBuilder1.Append("</div>");
                                        if (this.MatrixType[this.arrayLength].ToString().ToLower() == "g")
                                        {
                                            stringBuilder1.Append("<div style='clear:both;'></div><div style='padding-left: 60px;padding-top:5px;'>");
                                            TextBox textBox8 = new TextBox()
                                            {
                                                ID = string.Concat("txtWidth", this.PriceCategoryID[this.arrayLength].ToString()),
                                                CssClass = "txtStyleQuickAdd",
                                                ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                            };
                                            textBox8.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                            textBox8.Style.Add("color", "gray");
                                            textBox8.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                            AttributeCollection attributes4 = textBox8.Attributes;
                                            item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                            attributes4.Add("onBlur", string.Concat(item));
                                            textBox8.Attributes.Add("onClick", "this.style.color = '';");
                                            using (StringWriter stringWriter25 = new StringWriter(stringBuilder1))
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
                                            AttributeCollection attributeCollection4 = textBox9.Attributes;
                                            item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                            attributeCollection4.Add("onBlur", string.Concat(item));
                                            textBox9.Attributes.Add("onClick", "this.style.color = '';");
                                            using (StringWriter stringWriter26 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter26 = new HtmlTextWriter(stringWriter26))
                                                {
                                                    textBox9.RenderControl(htmlTextWriter26);
                                                }
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    stringBuilder1.Append("</div></div>");
                                    stringBuilder1.Append("</div>");
                                    if (this.arrayLength >= this.productName.Count - 1)
                                    {
                                        break;
                                    }
                                    this.arrayLength = this.arrayLength + 1;
                                }
                            }
                            stringBuilder1.Append("</div>");
                            stringBuilder1.Append("</div>");
                        }
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                    }
                }
                catch
                {
                }
            }
            //if (this.Session["CheckNewEntry"] != null && this.Session["CheckNewEntry"] != null)
            //{
            //    DataTable dataTable12 = ProductBasePage.BindTreeView(this.CompanyID, product.AccountID, 0, product.StoreUserID);
            //    int num26 = 0;
            //    foreach (DataRow dataRow8 in dataTable12.Rows)
            //    {
            //        num26 = num26 + Convert.ToInt32(dataRow8["categoryProductCnt"].ToString().Trim());
            //    }
            //    int count = 0;
            //    count = dataTable12.Rows.Count;
            //    if (this.Session["ProductsCount"] != null && this.Session["ProductsCount"] != null && Convert.ToInt32(this.Session["ProductsCount"].ToString()) != num26)
            //    {
            //        this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
            //        this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            //    }
            //    if (Convert.ToInt32(this.Session["CheckNewEntry"].ToString()) != count)
            //    {
            //        this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
            //        this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            //    }
            //    //this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
            //    //this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            //}
            if (!base.IsPostBack)
            {
                //if (this.Session["treeViewState"] != null)
                //{
                //    string item1 = (string)this.Session["treeViewState"];
                //    this.radCategoryTree.LoadXmlString(item1);
                //}
                //else
                //{
                //    this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
                //    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
                //}
                HtmlImage htmlImage = this.imgSucess;
                item = new object[] { product.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&aid=", product.AccountID, " &cid=", this.CompanyID };
                htmlImage.Src = string.Concat(item);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
                this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
                this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
            }
        }
        //private void LoadRootNodes(int CompanyID, long AccountID, int Categoryid)
        //{
        //    this.radCategoryTree.Nodes.Clear();
        //    DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Categoryid, product.StoreUserID);
        //    this.Session["CheckNewEntry"] = dataTable.Rows.Count;
        //    int num = 0;
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        string empty = string.Empty;
        //        string str = string.Empty;
        //        string empty1 = string.Empty;
        //        empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
        //        str = row["categoryProductCnt"].ToString().Trim();
        //        empty1 = row["SubCatCount"].ToString().Trim();
        //        num = num + Convert.ToInt32(str);
        //        RadTreeNode radTreeNode = new RadTreeNode()
        //        {
        //            ImageUrl = string.Concat(product.imagePath, "close_folder.png")
        //        };
        //        if (ConnectionClass.RewriteModule.ToLower() == "on")
        //        {
        //            if (Convert.ToInt32(empty1) != 0)
        //            {
        //                radTreeNode.Text = empty;
        //            }
        //            else
        //            {
        //                radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
        //                radTreeNode.ToolTip = empty;
        //            }
        //        }
        //        else if (Convert.ToInt32(empty1) != 0)
        //        {
        //            radTreeNode.Text = empty;
        //        }
        //        else
        //        {
        //            radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
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
        //    this.Session["ProductsCount"] = num;
        //}

        //private void AddChildNodes(int CompanyID, long AccountID, RadTreeNode node)
        //{
        //    DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Convert.ToInt32(node.Value), product.StoreUserID);
        //    node.Nodes.Clear();
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        string empty = string.Empty;
        //        string str = string.Empty;
        //        string empty1 = string.Empty;
        //        empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
        //        str = row["categoryProductCnt"].ToString().Trim();
        //        empty1 = row["SubCatCount"].ToString().Trim();
        //        RadTreeNode radTreeNode = new RadTreeNode()
        //        {
        //            ImageUrl = string.Concat(product.imagePath, "close_folder.png")
        //        };
        //        if (Convert.ToInt32(empty1) != 0)
        //        {
        //            radTreeNode.Text = empty;
        //        }
        //        else
        //        {
        //            radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
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
        //        string[] keySeparator = new string[] { product.strSitePath, "products", ConnectionClass.KeySeparator, e.Node.Value.ToString(), ConnectionClass.FileExtension };
        //        response.Redirect(base.ResolveUrl(string.Concat(keySeparator)));
        //        return;
        //    }
        //    RadTreeNode radTreeNode = this.radCategoryTree.FindNodeByValue(e.Node.Value);
        //    if (radTreeNode != null)
        //    {
        //        radTreeNode.Selected = true;
        //    }
        //    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
        //    base.Response.Redirect(string.Concat(product.strSitePath, "products/product.aspx?ID=", e.Node.Value.ToString()));
        //}

        //protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
        //{
        //    Convert.ToInt32(e.Node.Value);
        //    this.AddChildNodes(this.CompanyID, product.AccountID, e.Node);
        //    string item = (string)this.Session["treeViewState"];
        //    RadTreeView radTreeView = new RadTreeView();
        //    radTreeView.LoadXmlString(item);
        //    RadTreeNode radTreeNode = radTreeView.FindNodeByValue(e.Node.Value);
        //    this.AddChildNodes(this.CompanyID, product.AccountID, radTreeNode);
        //    radTreeNode.Expanded = true;
        //    this.Session["treeViewState"] = radTreeView.GetXml();
        //}
        public System.Drawing.Image ResizeImage(System.Drawing.Image FullsizeImage, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (OnlyResizeIfWider && FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width;
            }
            int height = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (height > MaxHeight)
            {
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                height = MaxHeight;
            }
            System.Drawing.Image thumbnailImage = FullsizeImage.GetThumbnailImage(NewWidth, height, new System.Drawing.Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
            FullsizeImage.Dispose();
            return thumbnailImage;
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
        }

        public bool ThumbnailCallback()
        {
            return true;
        }
    }
}