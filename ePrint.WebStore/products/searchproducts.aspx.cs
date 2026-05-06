using nmsCommon;
using nmsConnection;
using nmsLanguage;
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


namespace ePrint.WebStore
{
    public partial class searchproducts : System.Web.UI.Page, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected Button btnQuickNotificationOk;

        //protected Button btnGotoCart;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected HtmlGenericControl spn_headding;

        //protected Label lbl_searchResult;

        //protected PlaceHolder plh_ProductsDetails;

        public char KeySeparator;

        private BaseClass objBc = new BaseClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        public int priceCatalogueCategoryID;

        public int arrayLength;

        public int searchResult;

        public int productNameLength = 38;

        public int productDescriptionLength = 80;

        public static int companyID;

        public static long AccountID;

        public static string imagePath;

        public static string catagoryImagePath;

        public static string productImagePath;

        public static string strSitePath;

        public ArrayList productName = new ArrayList();

        public ArrayList PriceCatalogueCategoryName = new ArrayList();

        public ArrayList productImage = new ArrayList();

        public ArrayList productDescription = new ArrayList();

        public ArrayList PriceCategoryID = new ArrayList();

        public ArrayList PriceCatalogueCategoryID = new ArrayList();

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string searchProducts = string.Empty;

        public string searchCookie = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string strImagepath = BaseClass.SitePath;

        private commonclass comm = new commonclass();

        private int RoundOff;

        public ArrayList Is_ShortDescription = new ArrayList();

        public int CopyPriceCatalogueID;

        public long PriceCatalogueID;

        private string Description = string.Empty;

        private bool Is_ShortDescription1;

        private string ProductImage = string.Empty;

        private string CatalogueName = string.Empty;

        public static long StoreUserID;

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

        static searchproducts()
        {
            searchproducts.companyID = 0;
            searchproducts.AccountID = (long)0;
            searchproducts.imagePath = string.Empty;
            searchproducts.catagoryImagePath = string.Empty;
            searchproducts.productImagePath = string.Empty;
            searchproducts.strSitePath = string.Empty;
            searchproducts.StoreUserID = (long)0;
        }

        public searchproducts()
        {
        }

        public void BindOtherMultipleDropdownList(DataTable dtm, DropDownList OtherMultiplrDrp)
        {
            OtherMultiplrDrp.DataSource = dtm;
            OtherMultiplrDrp.DataTextField = "CatalogueName";
            OtherMultiplrDrp.DataValueField = "PriceCatalogueID";
            OtherMultiplrDrp.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] keySeparator;
            IEnumerator enumerator;
            IDisposable disposable;
            string[] str;
            object[] accountID;
            string[] strArrays;
            this.Session["SearchKey"] = "";
            if (ConnectionClass.ProductImagePath != null)
            {
                searchproducts.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.CatagoryImagePath != null)
            {
                searchproducts.catagoryImagePath = ConnectionClass.CatagoryImagePath;
            }
            if (ConnectionClass.ImagePath != null)
            {
                searchproducts.imagePath = ConnectionClass.ImagePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                searchproducts.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SitePath != null)
            {
                searchproducts.strSitePath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                searchproducts.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(searchproducts.companyID);
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["sp"] != null)
                {
                    this.searchProducts = base.Request.Params["sp"].ToString().Trim();
                }
            }
            else if (RewriteContext.Current.Params["type"] != null)
            {
                string str1 = RewriteContext.Current.Params["type"].ToString();
                keySeparator = new char[] { this.KeySeparator };
                this.searchProducts = str1.Split(keySeparator)[1].Trim();
            }
            base.Title = commonclass.pageTitle("Products Search", Convert.ToInt32(searchproducts.companyID), Convert.ToInt32(searchproducts.AccountID));
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            searchproducts.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            if (this.searchProducts != "")
            {
                DataTable item = ProductBasePage.productSearch(searchproducts.companyID, Convert.ToInt32(searchproducts.AccountID), this.objBc.SpecialEncode(this.searchProducts), searchproducts.StoreUserID);
                foreach (DataRow row in item.Rows)
                {
                    this.PriceCategoryID.Add(row["PriceCatalogueID"].ToString());
                    this.productName.Add(this.objBc.SpecialDecode(row["CatalogueName"].ToString()));
                    this.productDescription.Add(this.objBc.SpecialDecode(row["ShortDescription"].ToString()));
                    this.productImage.Add(row["ProductImage"].ToString());
                    this.Is_ShortDescription.Add(row["IsShortDescription"].ToString());
                }
                if (this.productName.Count == 0)
                {
                    this.plh_ProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_records_Found"), " </strong></div>")));
                }
                else
                {
                    int count = this.productName.Count / 17;
                    double num = (double)this.productName.Count / 5;
                    int num1 = 0;
                    if ((double)count != num)
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
                        stringBuilder.Append("<div class='width100p'>");
                        for (int j = 0; j < 17; j++)
                        {
                            if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
                            {
                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productDetails_div'>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat("<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productDetails_div'>"));
                            }
                            string str2 = null;
                            str2 = this.productName[this.arrayLength].ToString().Trim();
                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_div' title='", this.productName[this.arrayLength].ToString().Trim(), "'>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append(string.Concat("<label>", str2, "</label>"));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            if (item.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                            {
                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productImage_div clearTop'>" };
                                stringBuilder.Append(string.Concat(str));
                                if (this.productImage[this.arrayLength].ToString() != "")
                                {
                                    accountID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=", this.productImage[this.arrayLength].ToString(), "&amp;type=p&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                    this.finalimageName1 = string.Concat(accountID);
                                }
                                else
                                {
                                    accountID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                    this.finalimageName1 = string.Concat(accountID);
                                }
                            }
                            else if (item.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                DataTable dataTable = new DataTable();
                                try
                                {
                                    this.CopyPriceCatalogueID = Convert.ToInt32(item.Rows[this.arrayLength]["PriceCatalogueID"]);
                                    DataTable dataTable1 = ProductBasePage.OtherMultiple_DefaultItem_Select(Convert.ToInt32(this.CopyPriceCatalogueID));
                                    if (dataTable1.Rows.Count != 0)
                                    {
                                        this.NoProductSelected = "false";
                                    }
                                    else
                                    {
                                        this.NoProductSelected = "true";
                                        this.PriceCatalogueID = (long)this.CopyPriceCatalogueID;
                                    }
                                    if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["KitItemID"] != null)
                                    {
                                        this.PriceCatalogueID = Convert.ToInt64(dataTable1.Rows[0]["KitItemID"]);
                                    }
                                    dataTable = ProductBasePage.Product_CatalogueQty_Select(this.PriceCatalogueID);
                                    enumerator = dataTable.Rows.GetEnumerator();
                                    try
                                    {
                                        if (enumerator.MoveNext())
                                        {
                                            DataRow current = (DataRow)enumerator.Current;
                                            this.ProductImage = current["ProductImage"].ToString();
                                            this.CatalogueName = current["CatalogueName"].ToString();
                                            this.Description = current["Description"].ToString();
                                            this.Is_ShortDescription1 = Convert.ToBoolean(current["IsShortDescription"].ToString());
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
                                catch
                                {
                                }
                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productImage_div clearTop'>" };
                                stringBuilder.Append(string.Concat(str));
                                if (this.ProductImage.ToString() != "")
                                {
                                    accountID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=", this.ProductImage, "&amp;type=p&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                    this.finalimageName1 = string.Concat(accountID);
                                }
                                else
                                {
                                    accountID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                    this.finalimageName1 = string.Concat(accountID);
                                }
                                string str3 = this.ProductImage.ToString().Trim();
                                keySeparator = new char[] { '.' };
                                string[] strArrays1 = str3.Split(keySeparator);
                                if (strArrays1[(int)strArrays1.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                {
                                    try
                                    {
                                        accountID = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", searchproducts.companyID, "\\Product\\", this.ProductImage.ToString() };
                                        string str4 = string.Concat(accountID);
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
                                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                                stringBuilder.Append(string.Concat(str));
                                                if (this.ProductImage.ToString() != "")
                                                {
                                                    accountID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' style='height:", num5, "px;width:", num4, "px;' title='", this.CatalogueName.ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                else
                                                {
                                                    accountID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' style='height:", num5, "px;width:", num4, "px;' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                stringBuilder.Append("</div>");
                                            }
                                            else
                                            {
                                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                                stringBuilder.Append(string.Concat(str));
                                                if (this.productImage[this.arrayLength].ToString() != "")
                                                {
                                                    accountID = new object[13];
                                                    accountID[0] = "<a href='";
                                                    str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                    accountID[1] = base.ResolveUrl(string.Concat(str));
                                                    accountID[2] = "'><img id='imgGetID1";
                                                    accountID[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                    accountID[4] = "' style='height:";
                                                    accountID[5] = num5;
                                                    accountID[6] = "px;width:";
                                                    accountID[7] = num4;
                                                    accountID[8] = "px;' title='";
                                                    accountID[9] = this.ProductImage.ToString().Trim();
                                                    accountID[10] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                    accountID[11] = this.finalimageName1;
                                                    accountID[12] = "\" alt=' '/></a>";
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                else
                                                {
                                                    accountID = new object[13];
                                                    accountID[0] = "<a href='";
                                                    str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                    accountID[1] = base.ResolveUrl(string.Concat(str));
                                                    accountID[2] = "'><img id='imgGetID1";
                                                    accountID[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                    accountID[4] = "' style='height:";
                                                    accountID[5] = num5;
                                                    accountID[6] = "px;width:";
                                                    accountID[7] = num4;
                                                    accountID[8] = "px;' title='";
                                                    accountID[9] = this.ProductImage.ToString().Trim();
                                                    accountID[10] = "'  src=\"";
                                                    accountID[11] = this.finalimageName1;
                                                    accountID[12] = "\" alt=' '/></a>";
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                stringBuilder.Append("</div>");
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                            stringBuilder.Append(string.Concat(str));
                                            if (this.ProductImage.ToString() != "")
                                            {
                                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.CatalogueName.ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                        else
                                        {
                                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                            stringBuilder.Append(string.Concat(str));
                                            if (this.ProductImage.ToString() != "")
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img id='imgGetID1";
                                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                str[4] = "' title='";
                                                str[5] = this.CatalogueName.ToString().Trim();
                                                str[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                str[7] = this.finalimageName1;
                                                str[8] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img id='imgGetID1";
                                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                                str[4] = "' title='";
                                                str[5] = this.CatalogueName.ToString().Trim();
                                                str[6] = "'  src=\"";
                                                str[7] = this.finalimageName1;
                                                str[8] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                {
                                    str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                    stringBuilder.Append(string.Concat(str));
                                    if (this.productImage[this.arrayLength].ToString() != "")
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.CatalogueName.ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                else
                                {
                                    str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                    stringBuilder.Append(string.Concat(str));
                                    if (this.ProductImage.ToString() != "")
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img id='imgGetID1";
                                        str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                        str[4] = "' title='";
                                        str[5] = this.CatalogueName.ToString().Trim();
                                        str[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                        str[7] = this.finalimageName1;
                                        str[8] = "\" alt=' '/></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img id='imgGetID1";
                                        str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                        str[4] = "' title='";
                                        str[5] = this.CatalogueName.ToString().Trim();
                                        str[6] = "'  src=\"";
                                        str[7] = this.finalimageName1;
                                        str[8] = "\" alt=' '/></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                            }
                            string str6 = this.productImage[this.arrayLength].ToString().Trim();
                            keySeparator = new char[] { '.' };
                            string[] strArrays3 = str6.Split(keySeparator);
                            string str7 = strArrays3[(int)strArrays3.Length - 1].ToString().ToLower().Trim();
                            if (item.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                            {
                                if (str7.ToLower() == "gif")
                                {
                                    try
                                    {
                                        accountID = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", searchproducts.companyID, "\\Product\\", this.productImage[this.arrayLength].ToString() };
                                        string str8 = string.Concat(accountID);
                                        System.Drawing.Image image2 = System.Drawing.Image.FromFile(str8);
                                        FrameDimension frameDimension1 = new FrameDimension(image2.FrameDimensionsList[0]);
                                        int frameCount1 = image2.GetFrameCount(frameDimension1);
                                        int num6 = 200;
                                        int num7 = 150;
                                        if (image2.Width < 200 && image2.Height < 150)
                                        {
                                            num6 = Convert.ToInt32(image2.Width);
                                            num7 = Convert.ToInt32(image2.Height);
                                        }
                                        System.Drawing.Image image3 = System.Drawing.Image.FromFile(str8);
                                        if (frameCount1 > 0)
                                        {
                                            string str9 = createImageThumnail.FixedSizeForGif(str8, image3, num6, num7, false);
                                            keySeparator = new char[] { '~' };
                                            string[] strArrays4 = str9.Split(keySeparator);
                                            int num8 = Convert.ToInt16(strArrays4[0]);
                                            int num9 = Convert.ToInt16(strArrays4[1]);
                                            if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                                stringBuilder.Append(string.Concat(str));
                                                if (this.productImage[this.arrayLength].ToString() != "")
                                                {
                                                    accountID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img style='height:", num9, "px;width:", num8, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                else
                                                {
                                                    accountID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img style='height:", num9, "px;width:", num8, "px;' title='", this.productName[this.arrayLength].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                stringBuilder.Append("</div>");
                                            }
                                            else
                                            {
                                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                                stringBuilder.Append(string.Concat(str));
                                                if (this.productImage[this.arrayLength].ToString() != "")
                                                {
                                                    accountID = new object[] { "<a href='", null, null, null, null, null, null, null, null, null, null };
                                                    str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                    accountID[1] = base.ResolveUrl(string.Concat(str));
                                                    accountID[2] = "'><img style='height:";
                                                    accountID[3] = num9;
                                                    accountID[4] = "px;width:";
                                                    accountID[5] = num8;
                                                    accountID[6] = "px;' title='";
                                                    accountID[7] = this.productName[this.arrayLength].ToString().Trim();
                                                    accountID[8] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                    accountID[9] = this.finalimageName1;
                                                    accountID[10] = "\" alt=' '/></a>";
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                else
                                                {
                                                    accountID = new object[] { "<a href='", null, null, null, null, null, null, null, null, null, null };
                                                    str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                    accountID[1] = base.ResolveUrl(string.Concat(str));
                                                    accountID[2] = "'><img style='height:";
                                                    accountID[3] = num9;
                                                    accountID[4] = "px;width:";
                                                    accountID[5] = num8;
                                                    accountID[6] = "px;' title='";
                                                    accountID[7] = this.productName[this.arrayLength].ToString().Trim();
                                                    accountID[8] = "'  src=\"";
                                                    accountID[9] = this.finalimageName1;
                                                    accountID[10] = "\" alt=' '/></a>";
                                                    stringBuilder.Append(string.Concat(accountID));
                                                }
                                                stringBuilder.Append("</div>");
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                            stringBuilder.Append(string.Concat(str));
                                            if (this.productImage[this.arrayLength].ToString() != "")
                                            {
                                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img title='", this.productName[this.arrayLength].ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img title='", this.productName[this.arrayLength].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                        else
                                        {
                                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                            stringBuilder.Append(string.Concat(str));
                                            if (this.productImage[this.arrayLength].ToString() != "")
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null };
                                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img title='";
                                                str[3] = this.productName[this.arrayLength].ToString().Trim();
                                                str[4] = "'  class='ProductsImgBorde ProductCatagoryImager' src=\"";
                                                str[5] = this.finalimageName1;
                                                str[6] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            else
                                            {
                                                str = new string[] { "<a href='", null, null, null, null, null, null };
                                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                                str[2] = "'><img title='";
                                                str[3] = this.productName[this.arrayLength].ToString().Trim();
                                                str[4] = "'  src=\"";
                                                str[5] = this.finalimageName1;
                                                str[6] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(str));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                {
                                    str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                    stringBuilder.Append(string.Concat(str));
                                    if (this.productImage[this.arrayLength].ToString() != "")
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img title='", this.productName[this.arrayLength].ToString().Trim(), "' class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0'><img title='", this.productName[this.arrayLength].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                else
                                {
                                    str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                    stringBuilder.Append(string.Concat(str));
                                    if (this.productImage[this.arrayLength].ToString() != "")
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img title='";
                                        str[3] = this.productName[this.arrayLength].ToString().Trim();
                                        str[4] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                        str[5] = this.finalimageName1;
                                        str[6] = "\" alt=' '/></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img title='";
                                        str[3] = this.productName[this.arrayLength].ToString().Trim();
                                        str[4] = "'  src=\"";
                                        str[5] = this.finalimageName1;
                                        str[6] = "\" alt=' '/></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                            }
                            this.finalimageName1 = "";
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            string str10 = null;
                            string str11 = null;
                            str11 = this.Is_ShortDescription[this.arrayLength].ToString();
                            if (Convert.ToBoolean(str11))
                            {
                                str10 = this.productDescription[this.arrayLength].ToString().Trim();
                            }
                            if (item.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                if (this.Is_ShortDescription1)
                                {
                                    str10 = this.Description.ToString().Trim();
                                }
                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productDescription_div' title='", str10, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                if (!this.Is_ShortDescription1)
                                {
                                    accountID = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> </label>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                }
                                else
                                {
                                    accountID = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> ", str10, "</label>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                }
                                stringBuilder.Append("</div>");
                            }
                            else
                            {
                                str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='productDescription_div' title='", str10, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                if (str11.ToLower() == "true")
                                {
                                    stringBuilder.Append(string.Concat("<label> ", str10, "</label>"));
                                }
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' id='div_btnsave", this.PriceCategoryID[this.arrayLength].ToString(), "' class='productViewBtn_div1 DisplayBlock'>" };
                            stringBuilder.Append(string.Concat(str));
                            str = new string[] { "<input type='button' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='x-btnpro Grey main' onclick='Onclick_Product(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.objBc.SpecialEncode(this.productName[this.arrayLength].ToString()), "\");'/>" };
                            stringBuilder.Append(string.Concat(str));
                            if (base.Request.Params["sp"] != null)
                            {
                                this.Session["SearchKey"] = base.Request.Params["sp"];
                            }
                            stringBuilder.Append("</div>");
                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='SaveDiveSearch'>" };
                            stringBuilder.Append(string.Concat(str));
                            str = new string[] { "<div onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' id='div_btnsaveprocess", this.PriceCategoryID[this.arrayLength].ToString(), "' style='display:none;' class='x-btnpro Grey main SerachSavebtnldng'>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append(string.Concat("<img border='0' class='trans' src='", this.strImagepath, "images/radimg1.gif'>"));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</div>");
                            if (item.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                this.CopyPriceCatalogueID = Convert.ToInt32(item.Rows[this.arrayLength]["PriceCatalogueID"]);
                                if (Convert.ToBoolean(item.Rows[this.arrayLength]["isQuickItem"]))
                                {
                                    str = new string[] { "<div  onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "'>" };
                                    stringBuilder.Append(string.Concat(str));
                                    HiddenField hiddenField = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxName", this.PriceCatalogueID, item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                    };
                                    HiddenField hiddenField1 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxRate", this.PriceCatalogueID, item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                    };
                                    HiddenField hiddenField2 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxID", this.PriceCatalogueID, item.Rows[this.arrayLength]["pricecatalogueid"].ToString()),
                                        Value = "0"
                                    };
                                    hiddenField1.Value = "0";
                                    DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(searchproducts.companyID, Convert.ToInt32(this.PriceCatalogueID));
                                    foreach (DataRow dataRow in taxDetailsByProductCatalogueId.Rows)
                                    {
                                        hiddenField2.Value = dataRow["SalesTaxRate"].ToString();
                                        hiddenField.Value = dataRow["TaxName"].ToString();
                                        hiddenField1.Value = dataRow["TaxRate"].ToString();
                                    }
                                    using (StringWriter stringWriter = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter))
                                        {
                                            hiddenField2.RenderControl(htmlTextWriter);
                                            hiddenField.RenderControl(htmlTextWriter);
                                            hiddenField1.RenderControl(htmlTextWriter);
                                        }
                                    }
                                    DataTable dataTable2 = ProductBasePage.Product_CatalogueQty_Select(this.PriceCatalogueID);
                                    string empty = string.Empty;
                                    string empty1 = string.Empty;
                                    foreach (DataRow row1 in dataTable2.Rows)
                                    {
                                        item.Rows[this.arrayLength]["MatrixType"] = row1["MatrixType"];
                                        empty = row1["CatalogueName"].ToString();
                                        empty1 = row1["IsPriceStartFrom"].ToString();
                                    }
                                    HiddenField lower = new HiddenField();
                                    HiddenField hiddenField3 = new HiddenField();
                                    HiddenField hiddenField4 = new HiddenField();
                                    lower.ID = string.Concat("hdn_IsCumulative_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                    hiddenField3.ID = string.Concat("hdn_SoldInPacks_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                    hiddenField4.ID = string.Concat("hdn_MainProductID", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                    hiddenField4.Value = this.CopyPriceCatalogueID.ToString();
                                    enumerator = dataTable2.Rows.GetEnumerator();
                                    try
                                    {
                                        if (enumerator.MoveNext())
                                        {
                                            DataRow current1 = (DataRow)enumerator.Current;
                                            hiddenField3.Value = current1["SoldInPacksOf"].ToString();
                                            lower.Value = current1["IsCumulativePricing"].ToString().ToLower();
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
                                    HiddenField hiddenField5 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_PriceCatelogueName", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                        Value = this.objBc.SpecialDecode(empty)
                                    };
                                    using (StringWriter stringWriter1 = new StringWriter(stringBuilder))
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
                                    foreach (DataRow dataRow1 in dataTable2.Rows)
                                    {
                                        hiddenField6.Value = string.Concat(hiddenField6.Value, dataRow1["Price"].ToString(), "µ");
                                        hiddenField7.Value = string.Concat(hiddenField7.Value, dataRow1["SellingPrice"].ToString(), "µ");
                                        hiddenField8.Value = string.Concat(hiddenField8.Value, dataRow1["Markup"].ToString(), "µ");
                                    }
                                    using (StringWriter stringWriter2 = new StringWriter(stringBuilder))
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
                                        ID = string.Concat("hdn_ProductStockManagement", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                    };
                                    HiddenField hiddenField10 = new HiddenField()
                                    {
                                        ID = string.Concat("hdn_AvailableQuantity", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                    };
                                    foreach (DataRow row2 in ProductBasePage.productsDetails_Select(Convert.ToInt32(this.CopyPriceCatalogueID)).Rows)
                                    {
                                        if (Convert.ToBoolean(row2["ProductStockManagement"].ToString()))
                                        {
                                            hiddenField9.Value = "true";
                                        }
                                        if (int.Parse(row2["AvailableQuantity"].ToString()) == 0 || row2["AvailableQuantity"].ToString().Trim().Length <= 0)
                                        {
                                            hiddenField10.Value = "0";
                                        }
                                        else
                                        {
                                            hiddenField10.Value = row2["AvailableQuantity"].ToString();
                                        }
                                    }
                                    using (StringWriter stringWriter3 = new StringWriter(stringBuilder))
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
                                    foreach (DataRow dataRow2 in dataTable2.Rows)
                                    {
                                        HiddenField hiddenField13 = hiddenField11;
                                        hiddenField13.Value = string.Concat(hiddenField13.Value, dataRow2["FromQuantity"].ToString(), "µ");
                                        HiddenField hiddenField14 = hiddenField12;
                                        hiddenField14.Value = string.Concat(hiddenField14.Value, dataRow2["ToQuantity"].ToString(), "µ");
                                    }
                                    using (StringWriter stringWriter4 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                        {
                                            hiddenField11.RenderControl(htmlTextWriter4);
                                            hiddenField12.RenderControl(htmlTextWriter4);
                                        }
                                    }
                                    stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCatalogueID.ToString(), ");' style='padding-bottom: 5px;'>"));
                                    enumerator = dataTable2.Rows.GetEnumerator();
                                    try
                                    {
                                        if (enumerator.MoveNext())
                                        {
                                            DataRow current2 = (DataRow)enumerator.Current;
                                            stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", current2["ProductStockManagement"].ToString().ToLower(), "' />"));
                                            accountID = new object[] { "<input type='hidden' id='hdnisstockitem", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", current2["IsStockItem"].ToString(), "' />" };
                                            stringBuilder.Append(string.Concat(accountID));
                                            accountID = new object[] { "<input type='hidden' id='hdndrawstockfrom", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", current2["DrawStockFrom"].ToString(), "' />" };
                                            stringBuilder.Append(string.Concat(accountID));
                                            accountID = new object[] { "<input type='hidden' id='hdnisbackorder", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", current2["IsBackOrder"].ToString(), "' />" };
                                            stringBuilder.Append(string.Concat(accountID));
                                            accountID = new object[] { "<input type='hidden' id='hdnavailableqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", current2["AvailableQuantity"].ToString(), "' />" };
                                            stringBuilder.Append(string.Concat(accountID));
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
                                    Label label = new Label()
                                    {
                                        ID = string.Concat("lbl_priceStartsFrom", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                    };
                                    if (Convert.ToBoolean(empty1))
                                    {
                                        short num10 = 1;
                                        foreach (DataRow row3 in dataTable2.Rows)
                                        {
                                            if (num10 == 1)
                                            {
                                                label.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(searchproducts.companyID, 0, Convert.ToDecimal(row3["SellingPrice"].ToString()), 2, "", false, false, true));
                                            }
                                            num10 = (short)(num10 + 1);
                                        }
                                    }
                                    label.CssClass = "priceStartsFromInQuickAdd";
                                    using (StringWriter stringWriter5 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter5 = new HtmlTextWriter(stringWriter5))
                                        {
                                            label.RenderControl(htmlTextWriter5);
                                        }
                                    }
                                    stringBuilder.Append("</div>");
                                    HiddenField hiddenField15 = new HiddenField()
                                    {
                                        ID = string.Concat("hdnPriceCatalogueIds", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                        Value = string.Concat(item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                    };
                                    DataTable dataTable3 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, searchproducts.companyID);
                                    foreach (DataRow dataRow3 in dataTable3.Rows)
                                    {
                                        accountID = new object[] { hiddenField15.Value, ",", dataRow3["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
                                        hiddenField15.Value = string.Concat(accountID);
                                    }
                                    using (StringWriter stringWriter6 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter6 = new HtmlTextWriter(stringWriter6))
                                        {
                                            hiddenField15.RenderControl(htmlTextWriter6);
                                        }
                                    }
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    DropDownList dropDownList = new DropDownList()
                                    {
                                        CssClass = "ddlPriceQtyQuickAdd",
                                        Width = 150,
                                        Height = 22,
                                        ID = string.Concat("ddlOtherMultiplrDrp", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                    };
                                    dropDownList.CssClass = "dropDownMultipleQuickAdd";
                                    AttributeCollection attributes = dropDownList.Attributes;
                                    accountID = new object[] { "javascript:ChnageProduct('", this.PriceCatalogueID, "_", this.CopyPriceCatalogueID, "');" };
                                    attributes.Add("onchange", string.Concat(accountID));
                                    dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                    dropDownList.EnableViewState = true;
                                    dropDownList.AutoPostBack = true;
                                    this.BindOtherMultipleDropdownList(dataTable3, dropDownList);
                                    if (this.NoProductSelected == "true")
                                    {
                                        dropDownList.Items.Insert(0, "--Select--");
                                    }
                                    DataTable dataTable4 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.CopyPriceCatalogueID);
                                    if (dataTable4.Rows.Count > 0 && dataTable4.Rows[0]["KitItemID"] != null)
                                    {
                                        this.objBc.SetDDLValue(dropDownList, dataTable4.Rows[0]["KitItemID"].ToString());
                                    }
                                    using (StringWriter stringWriter7 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter7 = new HtmlTextWriter(stringWriter7))
                                        {
                                            dropDownList.RenderControl(htmlTextWriter7);
                                        }
                                    }
                                    stringBuilder.Append("</div>");
                                    if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "p")
                                    {
                                        stringBuilder.Append("<div style='padding-left: 35px;height:25px;'>");
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
                                        accountID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'p');" };
                                        attributeCollection.Add("onBlur", string.Concat(accountID));
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
                                    if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "g")
                                    {
                                        stringBuilder.Append("<div style='padding-left: 35px; height:25px;' >");
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
                                        accountID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                        attributes1.Add("onBlur", string.Concat(accountID));
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
                                    if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "s")
                                    {
                                        if (!Convert.ToBoolean(lower.Value))
                                        {
                                            stringBuilder.Append("<div style='padding-left: 35px;' >");
                                            DropDownList languageConversion = new DropDownList()
                                            {
                                                CssClass = "ddlPriceQtyQuickAdd",
                                                ID = string.Concat("ddlPriceQty", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID)
                                            };
                                            languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                            languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                            AttributeCollection attributeCollection1 = languageConversion.Attributes;
                                            accountID = new object[] { "javascript:quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                            attributeCollection1.Add("onchange", string.Concat(accountID));
                                            this.SimpleMatrix_DropDownBind(dataTable2, languageConversion);
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
                                            stringBuilder.Append("<div style='padding-left: 35px;' >");
                                            TextBox textBox2 = new TextBox()
                                            {
                                                ID = string.Concat("txt_Cumulative_PriceQty", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID),
                                                CssClass = "txtStyleQuickAdd",
                                                ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                            };
                                            textBox2.Attributes.Add("value", "Qty");
                                            textBox2.Style.Add("color", "gray");
                                            textBox2.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                            AttributeCollection attributes2 = textBox2.Attributes;
                                            accountID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                            attributes2.Add("onBlur", string.Concat(accountID));
                                            textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                            textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                            DropDownList dropDownList1 = new DropDownList()
                                            {
                                                CssClass = "ddlPriceQtyQuickAdd",
                                                ID = string.Concat("ddlPriceQty", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID)
                                            };
                                            dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                            dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                            AttributeCollection attributeCollection2 = dropDownList1.Attributes;
                                            accountID = new object[] { "javascript:quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                            attributeCollection2.Add("onchange", string.Concat(accountID));
                                            dropDownList1.Style.Add("display", "none");
                                            this.SimpleMatrix_DropDownBind(dataTable2, dropDownList1);
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
                                    accountID = new object[] { "<div id='divcartqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                    stringBuilder.Append("</div>");
                                    accountID = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCatalogueID, ");'  id='btnQucikAddCart", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower().Trim(), "\",", this.PriceCatalogueID, ")}'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                    accountID = new object[] { "<img id='btnQucikAddCartLoading", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                    accountID = new object[] { "<span id='btnQucikAddCartoutofstock", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;padding-top:33px;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                    stringBuilder.Append("</div>");
                                    accountID = new object[] { "<div id='divcartWidthHeight", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'style='padding-left:35px;padding-top:5px;clear:both;'>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                    stringBuilder.Append("</div>");
                                    if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "g")
                                    {
                                        stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 35px;'>");
                                        TextBox textBox3 = new TextBox()
                                        {
                                            ID = string.Concat("txtWidth", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                        textBox3.Style.Add("color", "gray");
                                        textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                        AttributeCollection attributes3 = textBox3.Attributes;
                                        accountID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                        attributes3.Add("onBlur", string.Concat(accountID));
                                        textBox3.Attributes.Add("onClick", "this.style.color = '';");
                                        using (StringWriter stringWriter12 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter12 = new HtmlTextWriter(stringWriter12))
                                            {
                                                textBox3.RenderControl(htmlTextWriter12);
                                            }
                                        }
                                        TextBox textBox4 = new TextBox()
                                        {
                                            ID = string.Concat("txtHeight", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox4.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                        textBox4.Style.Add("color", "gray");
                                        textBox4.Style.Add("margin-left", "8px");
                                        textBox4.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                        AttributeCollection attributeCollection3 = textBox4.Attributes;
                                        accountID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                        attributeCollection3.Add("onBlur", string.Concat(accountID));
                                        textBox4.Attributes.Add("onClick", "this.style.color = '';");
                                        using (StringWriter stringWriter13 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter13 = new HtmlTextWriter(stringWriter13))
                                            {
                                                textBox4.RenderControl(htmlTextWriter13);
                                            }
                                        }
                                        stringBuilder.Append("</div>");
                                    }
                                    stringBuilder.Append("</div>");
                                }
                            }
                            else if (Convert.ToBoolean(item.Rows[this.arrayLength]["isQuickItem"]))
                            {
                                str = new string[] { "<div  onmouseover='mouseovershow(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "'>" };
                                stringBuilder.Append(string.Concat(str));
                                HiddenField str12 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxName", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                HiddenField str13 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxRate", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                HiddenField str14 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxID", item.Rows[this.arrayLength]["pricecatalogueid"].ToString()),
                                    Value = "0"
                                };
                                str13.Value = "0";
                                DataTable taxDetailsByProductCatalogueId1 = ProductBasePage.GetTaxDetails_ByProductCatalogueId(searchproducts.companyID, Convert.ToInt32(item.Rows[this.arrayLength]["pricecatalogueid"]));
                                foreach (DataRow row4 in taxDetailsByProductCatalogueId1.Rows)
                                {
                                    str14.Value = row4["SalesTaxRate"].ToString();
                                    str12.Value = row4["TaxName"].ToString();
                                    str13.Value = row4["TaxRate"].ToString();
                                }
                                using (StringWriter stringWriter14 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter14 = new HtmlTextWriter(stringWriter14))
                                    {
                                        str14.RenderControl(htmlTextWriter14);
                                        str12.RenderControl(htmlTextWriter14);
                                        str13.RenderControl(htmlTextWriter14);
                                    }
                                }
                                DataTable dataTable5 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()));
                                HiddenField lower1 = new HiddenField();
                                HiddenField str15 = new HiddenField();
                                HiddenField hiddenField16 = new HiddenField();
                                lower1.ID = string.Concat("hdn_IsCumulative_", item.Rows[this.arrayLength]["pricecatalogueid"].ToString());
                                lower1.Value = item.Rows[this.arrayLength]["IsCumulativePricing"].ToString().ToLower();
                                str15.ID = string.Concat("hdn_SoldInPacks_", item.Rows[this.arrayLength]["pricecatalogueid"].ToString());
                                str15.Value = item.Rows[this.arrayLength]["SoldInPacksOf"].ToString();
                                hiddenField16.ID = string.Concat("hdn_MainProductID", item.Rows[this.arrayLength]["pricecatalogueid"].ToString());
                                hiddenField16.Value = "0";
                                HiddenField hiddenField17 = new HiddenField()
                                {
                                    ID = string.Concat("hid_PriceCatelogueName", item.Rows[this.arrayLength]["pricecatalogueid"].ToString()),
                                    Value = this.objBc.SpecialDecode(item.Rows[this.arrayLength]["CatalogueName"].ToString().Trim())
                                };
                                using (StringWriter stringWriter15 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter15 = new HtmlTextWriter(stringWriter15))
                                    {
                                        hiddenField17.RenderControl(htmlTextWriter15);
                                        lower1.RenderControl(htmlTextWriter15);
                                        str15.RenderControl(htmlTextWriter15);
                                        hiddenField16.RenderControl(htmlTextWriter15);
                                    }
                                }
                                HiddenField hiddenField18 = new HiddenField()
                                {
                                    ID = string.Concat("hid_CostExcMarkupList", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                HiddenField hiddenField19 = new HiddenField()
                                {
                                    ID = string.Concat("hid_priceList", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                HiddenField hiddenField20 = new HiddenField()
                                {
                                    ID = string.Concat("hid_MarkupList", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                foreach (DataRow dataRow4 in dataTable5.Rows)
                                {
                                    hiddenField18.Value = string.Concat(hiddenField18.Value, dataRow4["Price"].ToString(), "µ");
                                    hiddenField19.Value = string.Concat(hiddenField19.Value, dataRow4["SellingPrice"].ToString(), "µ");
                                    hiddenField20.Value = string.Concat(hiddenField20.Value, dataRow4["Markup"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter16 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter16 = new HtmlTextWriter(stringWriter16))
                                    {
                                        hiddenField18.RenderControl(htmlTextWriter16);
                                        hiddenField19.RenderControl(htmlTextWriter16);
                                        hiddenField20.RenderControl(htmlTextWriter16);
                                    }
                                }
                                HiddenField hiddenField21 = new HiddenField()
                                {
                                    ID = "hdn_ProductStockManagement"
                                };
                                HiddenField str16 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_AvailableQuantity", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                DataTable dataTable6 = ProductBasePage.productsDetails_Select(Convert.ToInt32(item.Rows[this.arrayLength]["pricecatalogueid"].ToString()));
                                foreach (DataRow row5 in dataTable6.Rows)
                                {
                                    if (Convert.ToBoolean(row5["ProductStockManagement"].ToString()))
                                    {
                                        hiddenField21.Value = "true";
                                    }
                                    if (int.Parse(row5["AvailableQuantity"].ToString()) == 0 || row5["AvailableQuantity"].ToString().Trim().Length <= 0)
                                    {
                                        str16.Value = "0";
                                    }
                                    else
                                    {
                                        str16.Value = row5["AvailableQuantity"].ToString();
                                    }
                                }
                                using (StringWriter stringWriter17 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                    {
                                        hiddenField21.RenderControl(htmlTextWriter17);
                                        str16.RenderControl(htmlTextWriter17);
                                    }
                                }
                                HiddenField hiddenField22 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_qtyFromList", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                HiddenField hiddenField23 = new HiddenField()
                                {
                                    ID = string.Concat("hid_qtyToList", item.Rows[this.arrayLength]["pricecatalogueid"].ToString())
                                };
                                foreach (DataRow dataRow5 in dataTable5.Rows)
                                {
                                    HiddenField hiddenField24 = hiddenField22;
                                    hiddenField24.Value = string.Concat(hiddenField24.Value, dataRow5["FromQuantity"].ToString(), "µ");
                                    HiddenField hiddenField25 = hiddenField23;
                                    hiddenField25.Value = string.Concat(hiddenField25.Value, dataRow5["ToQuantity"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter18 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                    {
                                        hiddenField22.RenderControl(htmlTextWriter18);
                                        hiddenField23.RenderControl(htmlTextWriter18);
                                    }
                                }
                                stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;'>"));
                                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", item.Rows[this.arrayLength]["ProductStockManagement"].ToString().ToLower(), "' />"));
                                str = new string[] { "<input type='hidden' id='hdnisstockitem", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "' value='", item.Rows[this.arrayLength]["IsStockItem"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdndrawstockfrom", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "' value='", item.Rows[this.arrayLength]["DrawStockFrom"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdnisbackorder", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "' value='", item.Rows[this.arrayLength]["IsBackOrder"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdnavailableqty", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), "' value='", item.Rows[this.arrayLength]["AvailableQuantity"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                if (Convert.ToBoolean(item.Rows[this.arrayLength]["IsPriceStartFrom"]))
                                {
                                    Label label1 = new Label();
                                    short num11 = 1;
                                    foreach (DataRow row6 in dataTable5.Rows)
                                    {
                                        if (num11 == 1)
                                        {
                                            label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(searchproducts.companyID, 0, Convert.ToDecimal(row6["SellingPrice"].ToString()), 2, "", false, false, true));
                                        }
                                        num11 = (short)(num11 + 1);
                                    }
                                    label1.CssClass = "priceStartsFromInQuickAdd";
                                    using (StringWriter stringWriter19 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter19 = new HtmlTextWriter(stringWriter19))
                                        {
                                            label1.RenderControl(htmlTextWriter19);
                                        }
                                    }
                                }
                                stringBuilder.Append("</div>");
                                if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "p")
                                {
                                    stringBuilder.Append("<div style='padding-left: 60px; height:25px;' >");
                                    TextBox textBox5 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox5.Attributes.Add("value", "Qty");
                                    textBox5.Style.Add("color", "gray");
                                    textBox5.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox5.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'p');"));
                                    textBox5.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox5.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter20 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter20 = new HtmlTextWriter(stringWriter20))
                                        {
                                            textBox5.RenderControl(htmlTextWriter20);
                                        }
                                    }
                                }
                                if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='padding-left: 60px; height:25px;' >");
                                    TextBox textBox6 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox6.Attributes.Add("value", "Qty");
                                    textBox6.Style.Add("color", "gray");
                                    textBox6.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox6.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'g');"));
                                    textBox6.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox6.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter21 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter21 = new HtmlTextWriter(stringWriter21))
                                        {
                                            textBox6.RenderControl(htmlTextWriter21);
                                        }
                                    }
                                }
                                if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "s")
                                {
                                    if (!Convert.ToBoolean(lower1.Value))
                                    {
                                        stringBuilder.Append("<div style='padding-left: 60px;' >");
                                        DropDownList languageConversion1 = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString())
                                        };
                                        languageConversion1.CssClass = "dropDownMultipleQuickAdd";
                                        languageConversion1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        languageConversion1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'s');"));
                                        this.SimpleMatrix_DropDownBind(dataTable5, languageConversion1);
                                        using (StringWriter stringWriter22 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter22 = new HtmlTextWriter(stringWriter22))
                                            {
                                                languageConversion1.RenderControl(htmlTextWriter22);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stringBuilder.Append("<div style='padding-left: 60px;' >");
                                        TextBox textBox7 = new TextBox()
                                        {
                                            ID = string.Concat("txt_Cumulative_PriceQty", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox7.Attributes.Add("value", "Qty");
                                        textBox7.Style.Add("color", "gray");
                                        textBox7.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                        textBox7.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'s');"));
                                        textBox7.Attributes.Add("onClick", "this.style.color = '';");
                                        textBox7.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                        DropDownList dropDownList2 = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString())
                                        };
                                        dropDownList2.CssClass = "dropDownMultipleQuickAdd";
                                        dropDownList2.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        dropDownList2.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'s');"));
                                        dropDownList2.Style.Add("display", "none");
                                        this.SimpleMatrix_DropDownBind(dataTable5, dropDownList2);
                                        using (StringWriter stringWriter23 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter23 = new HtmlTextWriter(stringWriter23))
                                            {
                                                dropDownList2.RenderControl(htmlTextWriter23);
                                                textBox7.RenderControl(htmlTextWriter23);
                                            }
                                        }
                                    }
                                }
                                if (item.Rows[this.arrayLength]["IsStockItem"].ToString().ToLower() == "true")
                                {
                                    str = new string[] { "<img onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ",\"", item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ",\"", item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower().Trim(), "\",", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                else
                                {
                                    accountID = new object[] { "<img onmouseout='mouseOutHidediv(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", item.Rows[this.arrayLength]["pricecatalogueid"].ToString(), ",\"", item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower().Trim(), "\",", item.Rows[this.arrayLength]["pricecatalogueid"], ")'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(accountID));
                                }
                                str = new string[] { "<img id='btnQucikAddCartLoading", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<span id='btnQucikAddCartoutofstock", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (item.Rows[this.arrayLength]["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 60px;'>");
                                    TextBox textBox8 = new TextBox()
                                    {
                                        ID = string.Concat("txtWidth", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox8.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                    textBox8.Style.Add("color", "gray");
                                    textBox8.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributes4 = textBox8.Attributes;
                                    accountID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'g');" };
                                    attributes4.Add("onBlur", string.Concat(accountID));
                                    textBox8.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter24 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter24 = new HtmlTextWriter(stringWriter24))
                                        {
                                            textBox8.RenderControl(htmlTextWriter24);
                                        }
                                    }
                                    TextBox textBox9 = new TextBox()
                                    {
                                        ID = string.Concat("txtHeight", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox9.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                    textBox9.Style.Add("color", "gray");
                                    textBox9.Style.Add("margin-left", "8px");
                                    textBox9.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributeCollection4 = textBox9.Attributes;
                                    accountID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'g');" };
                                    attributeCollection4.Add("onBlur", string.Concat(accountID));
                                    textBox9.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter25 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter25 = new HtmlTextWriter(stringWriter25))
                                        {
                                            textBox9.RenderControl(htmlTextWriter25);
                                        }
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("</div>");
                            if (this.arrayLength >= this.productName.Count - 1)
                            {
                                break;
                            }
                            this.arrayLength = this.arrayLength + 1;
                        }
                        stringBuilder.Append("</div>");
                    }
                    this.plh_ProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                    this.searchResult = this.productName.Count;
                    Label lblSearchResult = this.lbl_searchResult;
                    str = new string[] { "<span class='fontBold'>[</span> ", Convert.ToString(this.searchResult), " ", this.objLanguage.GetLanguageConversion("items_found"), " <span class='fontBold'>]</span>" };
                    lblSearchResult.Text = string.Concat(str);
                }
            }
            if (!this.Page.IsPostBack)
            {
                HtmlImage htmlImage = this.imgSucess;
                accountID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&amp;aid=", searchproducts.AccountID, " &amp;cid=", searchproducts.companyID };
                htmlImage.Src = string.Concat(accountID);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
            }
            this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
            this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
        }
    }
}