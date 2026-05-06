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
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore.products
{
    public partial class searchproducts : System.Web.UI.Page, IRequiresSessionState
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

        //protected Label lbl_nav;

        //protected HtmlGenericControl spn_headding;

        //protected Label lbl_searchResult;

        //protected PlaceHolder plh_ProductsDetails;

        public char KeySeparator;

        private BaseClass objBc = new BaseClass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int priceCatalogueCategoryID;

        public int arrayLength;

        public int searchResult;

        public int productNameLength = 40;

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

        public ArrayList Pricetype = new ArrayList();

        public ArrayList IsShortDescription = new ArrayList();

        public ArrayList isQuickItem = new ArrayList();

        public ArrayList isPriceStartFrom = new ArrayList();

        public ArrayList MatrixType = new ArrayList();

        public ArrayList IsCumulativePricinig = new ArrayList();

        public ArrayList SolodinPacksof = new ArrayList();

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string searchProducts = string.Empty;

        public string searchCookie = string.Empty;

        public string IsHomePageVisible = string.Empty;

        private commonclass comm = new commonclass();

        private bool IsStockItem;

        private int RoundOff;

        public int PriceCatalogueID;

        public int CopyPriceCatalogueID;

        private string ProductImage = string.Empty;

        private string CatalogueName = string.Empty;

        private string MatrixType2 = string.Empty;

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

        static searchproducts()
        {
            searchproducts.companyID = 0;
            searchproducts.AccountID = (long)0;
            searchproducts.imagePath = string.Empty;
            searchproducts.catagoryImagePath = string.Empty;
            searchproducts.productImagePath = string.Empty;
            searchproducts.strSitePath = string.Empty;
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
            object[] priceCatalogueID;
            string[] str;
            string[] strArrays;
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
                try
                {
                    string str1 = RewriteContext.Current.Params["type"].ToString();
                    keySeparator = new char[] { this.KeySeparator };
                    this.searchProducts = str1.Split(keySeparator)[1].Trim();
                }
                catch
                {
                }
            }
            base.Title = commonclass.pageTitle("Products Search", Convert.ToInt32(searchproducts.companyID), Convert.ToInt32(searchproducts.AccountID));
            this.lbl_home.Text = ConnectionClass.PageName(searchproducts.companyID, Convert.ToInt32(searchproducts.AccountID), 0);
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.comm.GetDisplayValue("IsHome", searchproducts.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(searchproducts.companyID, Convert.ToInt32(searchproducts.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            DataTable dataTable = ProductBasePage.productSearch(searchproducts.companyID, Convert.ToInt32(searchproducts.AccountID), this.objBc.SpecialEncode(this.searchProducts));
            foreach (DataRow row in dataTable.Rows)
            {
                this.PriceCategoryID.Add(row["PriceCatalogueID"].ToString());
                this.productName.Add(row["CatalogueName"].ToString());
                this.productDescription.Add(row["ShortDescription"].ToString());
                this.productImage.Add(row["ProductImage"].ToString());
                this.PriceCatalogueCategoryName.Add(row["PriceCatalogueCategoryName"].ToString());
                this.Pricetype.Add(row["Type"].ToString());
                ArrayList isShortDescription = this.IsShortDescription;
                int num = Convert.ToInt32(row["IsShortDescription"]);
                isShortDescription.Add(num.ToString());
                ArrayList arrayLists = this.isQuickItem;
                bool flag = Convert.ToBoolean(row["isQuickItem"]);
                arrayLists.Add(flag.ToString());
                this.isPriceStartFrom.Add(Convert.ToBoolean(row["IsPriceStartFrom"].ToString()));
                this.MatrixType.Add(row["MatrixType"].ToString());
                this.IsCumulativePricinig.Add(row["IsCumulativePricing"].ToString());
                this.SolodinPacksof.Add(row["SoldInPacksOf"].ToString());
            }
            if (this.productName.Count == 0)
            {
                this.plh_ProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), " </strong></div>")));
            }
            else
            {
                int count = this.productName.Count / 5;
                double count1 = (double)this.productName.Count / 5;
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
                    stringBuilder.Append("<table>");
                    stringBuilder.Append("<tr>");
                    for (int j = 0; j < 4; j++)
                    {
                        DataTable dataTable1 = new DataTable();
                        try
                        {
                            if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                this.CopyPriceCatalogueID = Convert.ToInt32(this.PriceCategoryID[this.arrayLength]);
                                DataTable dataTable2 = ProductBasePage.OtherMultiple_Default_Select((long)Convert.ToInt32(this.CopyPriceCatalogueID));
                                if (dataTable2.Rows.Count != 0)
                                {
                                    this.NoProductSelected = "false";
                                }
                                else
                                {
                                    this.NoProductSelected = "true";
                                    this.PriceCatalogueID = this.CopyPriceCatalogueID;
                                }
                                if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["KitItemID"] != null)
                                {
                                    this.PriceCatalogueID = Convert.ToInt32(dataTable2.Rows[0]["KitItemID"]);
                                }
                                dataTable1 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCatalogueID));
                                IEnumerator enumerator = dataTable1.Rows.GetEnumerator();
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
                        stringBuilder.Append("<td>");
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
                            {
                                priceCatalogueID = new object[] { "<div  id='divmainHover", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' onmouseover='mouseovershow1(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\");' onmouseout='mouseOutHidediv1(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                            }
                            else
                            {
                                priceCatalogueID = new object[] { "<div  id='divmainHover", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' onmouseover='mouseovershow1(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\");'  class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                            }
                        }
                        else if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
                        {
                            str = new string[] { "<div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDetails_Style'>" };
                            stringBuilder.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new string[] { "<div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  class='productDetails_div'><div onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  class='productDetails_Style'>" };
                            stringBuilder.Append(string.Concat(str));
                        }
                        string str2 = null;
                        str2 = (this.productName[this.arrayLength].ToString().Trim().Length <= this.productNameLength ? this.productName[this.arrayLength].ToString().Trim() : this.productName[this.arrayLength].ToString().Trim().Substring(0, this.productNameLength));
                        str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productName_div'>" };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append(string.Concat("<label>", this.objBc.SpecialDecode(str2), "</label>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productImage_div'>" };
                            stringBuilder.Append(string.Concat(str));
                            if (this.productImage[this.arrayLength].ToString() != "")
                            {
                                priceCatalogueID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=", this.productImage[this.arrayLength].ToString(), "&amp;type=p&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                this.finalimageName1 = string.Concat(priceCatalogueID);
                            }
                            else
                            {
                                priceCatalogueID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                this.finalimageName1 = string.Concat(priceCatalogueID);
                            }
                        }
                        else if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            priceCatalogueID = new object[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='productImage_div'>" };
                            stringBuilder.Append(string.Concat(priceCatalogueID));
                            if (this.ProductImage.ToString() != "")
                            {
                                priceCatalogueID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=", this.ProductImage, "&amp;type=p&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                this.finalimageName1 = string.Concat(priceCatalogueID);
                            }
                            else
                            {
                                priceCatalogueID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", searchproducts.AccountID, "&amp;cid=", searchproducts.companyID };
                                this.finalimageName1 = string.Concat(priceCatalogueID);
                            }
                            string str3 = this.ProductImage.ToString().Trim();
                            keySeparator = new char[] { '.' };
                            string[] strArrays1 = str3.Split(keySeparator);
                            if (strArrays1[(int)strArrays1.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                            {
                                try
                                {
                                    priceCatalogueID = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", searchproducts.companyID, "\\Product\\", this.ProductImage.ToString() };
                                    string str4 = string.Concat(priceCatalogueID);
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
                                            priceCatalogueID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.CopyPriceCatalogueID.ToString(), "&amp;type=1'><img id='imgGetID8", this.CopyPriceCatalogueID, "'  style='height:", num5, "px;width:", num4, "px;' class='ProductCatagoryImage'  title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder.Append(string.Concat(priceCatalogueID));
                                        }
                                        else
                                        {
                                            priceCatalogueID = new object[13];
                                            priceCatalogueID[0] = "<a href='";
                                            str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                            priceCatalogueID[1] = base.ResolveUrl(string.Concat(str));
                                            priceCatalogueID[2] = "'><img  id='imgGetID7";
                                            priceCatalogueID[3] = this.CopyPriceCatalogueID.ToString();
                                            priceCatalogueID[4] = "'  style='height:";
                                            priceCatalogueID[5] = num5;
                                            priceCatalogueID[6] = "px;width:";
                                            priceCatalogueID[7] = num4;
                                            priceCatalogueID[8] = "px;'  title='";
                                            priceCatalogueID[9] = this.CatalogueName.Trim();
                                            priceCatalogueID[10] = "' src=\"";
                                            priceCatalogueID[11] = this.finalimageName1;
                                            priceCatalogueID[12] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                            stringBuilder.Append(string.Concat(priceCatalogueID));
                                        }
                                    }
                                    else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=1'><img id='imgGetID8", this.CopyPriceCatalogueID.ToString(), "' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' ' class='ProductCatagoryImage' /></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.CopyPriceCatalogueID.ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img id='imgGetID7";
                                        str[3] = this.CopyPriceCatalogueID.ToString();
                                        str[4] = "' title='";
                                        str[5] = this.CatalogueName.ToString().Trim();
                                        str[6] = "' src=\"";
                                        str[7] = this.finalimageName1;
                                        str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                }
                                catch
                                {
                                }
                            }
                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                            {
                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=1'><img id='imgGetID8", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' ' class='ProductCatagoryImage' /></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                str[2] = "'><img id='imgGetID7";
                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                str[4] = "' title='";
                                str[5] = this.productName[this.arrayLength].ToString().Trim();
                                str[6] = "' src=\"";
                                str[7] = this.finalimageName1;
                                str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                stringBuilder.Append(string.Concat(str));
                            }
                        }
                        string str6 = this.productImage[this.arrayLength].ToString().Trim();
                        keySeparator = new char[] { '.' };
                        string[] strArrays3 = str6.Split(keySeparator);
                        string str7 = strArrays3[(int)strArrays3.Length - 1].ToString().ToLower().Trim();
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            if (str7.ToLower() == "gif")
                            {
                                try
                                {
                                    priceCatalogueID = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", searchproducts.companyID, "\\Product\\", this.productImage[this.arrayLength].ToString() };
                                    string str8 = string.Concat(priceCatalogueID);
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
                                            priceCatalogueID = new object[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=1'><img id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "'  style='height:", num9, "px;width:", num8, "px;'  title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' ' class='ProductCatagoryImage' /></a>" };
                                            stringBuilder.Append(string.Concat(priceCatalogueID));
                                        }
                                        else
                                        {
                                            priceCatalogueID = new object[13];
                                            priceCatalogueID[0] = "<a href='";
                                            str = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                            priceCatalogueID[1] = base.ResolveUrl(string.Concat(str));
                                            priceCatalogueID[2] = "'><img  id='imgGetID7";
                                            priceCatalogueID[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                            priceCatalogueID[4] = "'  style='height:";
                                            priceCatalogueID[5] = num9;
                                            priceCatalogueID[6] = "px;width:";
                                            priceCatalogueID[7] = num8;
                                            priceCatalogueID[8] = "px;'  title='";
                                            priceCatalogueID[9] = this.productName[this.arrayLength].ToString().Trim();
                                            priceCatalogueID[10] = "' src=\"";
                                            priceCatalogueID[11] = this.finalimageName1;
                                            priceCatalogueID[12] = "\" alt=' ' class='ProductCatagoryImage'/></a>";
                                            stringBuilder.Append(string.Concat(priceCatalogueID));
                                        }
                                    }
                                    else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                    {
                                        str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=1'><img id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' ' class='ProductCatagoryImage' /></a>" };
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                    else
                                    {
                                        str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                        str[1] = base.ResolveUrl(string.Concat(strArrays));
                                        str[2] = "'><img id='imgGetID7";
                                        str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                        str[4] = "' title='";
                                        str[5] = this.productName[this.arrayLength].ToString().Trim();
                                        str[6] = "' src=\"";
                                        str[7] = this.finalimageName1;
                                        str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                        stringBuilder.Append(string.Concat(str));
                                    }
                                }
                                catch (Exception exception)
                                {
                                }
                            }
                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                            {
                                str = new string[] { "<a href='", searchproducts.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=1'><img id='imgGetID7", this.PriceCategoryID[this.arrayLength].ToString(), "' title='", this.productName[this.arrayLength].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' ' class='ProductCatagoryImage' /></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                strArrays = new string[] { searchproducts.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "1", ConnectionClass.FileExtension };
                                str[1] = base.ResolveUrl(string.Concat(strArrays));
                                str[2] = "'><img id='imgGetID7";
                                str[3] = this.PriceCategoryID[this.arrayLength].ToString();
                                str[4] = "' title='";
                                str[5] = this.productName[this.arrayLength].ToString().Trim();
                                str[6] = "' src=\"";
                                str[7] = this.finalimageName1;
                                str[8] = "\" alt=' ' class='ProductCatagoryImage' /></a>";
                                stringBuilder.Append(string.Concat(str));
                            }
                        }
                        this.finalimageName1 = "";
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        string str10 = null;
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m" && dataTable.Rows[this.arrayLength]["ShortDescription"].ToString() != "" && Convert.ToBoolean(dataTable.Rows[this.arrayLength]["IsShortDescription"]))
                        {
                            str10 = (this.productDescription[this.arrayLength].ToString().Trim().Length <= this.productDescriptionLength ? this.productDescription[this.arrayLength].ToString().Trim() : string.Concat(this.productDescription[this.arrayLength].ToString().Trim().Substring(0, this.productDescriptionLength), "..."));
                        }
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            priceCatalogueID = new object[] { "<div id='DivDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productDescription_div'>" };
                            stringBuilder.Append(string.Concat(priceCatalogueID));
                        }
                        else
                        {
                            foreach (DataRow dataRow in dataTable1.Rows)
                            {
                                if (dataRow["Description"] == null || !(dataRow["Description"].ToString().Trim() != "") || !Convert.ToBoolean(dataRow["IsShortDescription"]))
                                {
                                    continue;
                                }
                                str10 = this.objBc.SpecialDecode(dataRow["Description"].ToString().Trim());
                                break;
                            }
                            if (this.MatrixType2.ToString().ToLower() != "g")
                            {
                                priceCatalogueID = new object[] { "<div id='DivDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='productDescription_div'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                            }
                            else
                            {
                                priceCatalogueID = new object[] { "<div id='DivDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv1(", this.PriceCategoryID[this.arrayLength].ToString(), this.CopyPriceCatalogueID, ");' class='productDescription_div' style='height:26px;'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                            }
                        }
                        priceCatalogueID = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> ", str10, "</label>" };
                        stringBuilder.Append(string.Concat(priceCatalogueID));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='productViewBtn_div'>" };
                        stringBuilder.Append(string.Concat(str));
                        str = new string[] { "<input type='button' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='WS_Buttons_Style' onclick='Onclick_Product(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(this.productName[this.arrayLength].ToString()), "\");'/>" };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append("</div>");
                        if (dataTable.Rows[this.arrayLength]["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            this.CopyPriceCatalogueID = Convert.ToInt32(this.PriceCategoryID[this.arrayLength]);
                            if (Convert.ToBoolean(this.isQuickItem[this.arrayLength].ToString()))
                            {
                                stringBuilder.Append("<div class='clearBoth'></div>");
                                priceCatalogueID = new object[] { "<div  onmouseover='mouseovershow(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
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
                                foreach (DataRow row1 in ProductBasePage.GetTaxDetails_ByProductCatalogueId(searchproducts.companyID, this.PriceCatalogueID).Rows)
                                {
                                    hiddenField2.Value = row1["SalesTaxRate"].ToString();
                                    hiddenField.Value = row1["TaxName"].ToString();
                                    hiddenField1.Value = row1["TaxRate"].ToString();
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
                                HiddenField lower = new HiddenField();
                                HiddenField hiddenField3 = new HiddenField();
                                HiddenField hiddenField4 = new HiddenField();
                                lower.ID = string.Concat("hdn_IsCumulative_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                hiddenField3.ID = string.Concat("hdn_SoldInPacks_", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                hiddenField4.ID = string.Concat("hdn_MainProductID", this.PriceCatalogueID, this.CopyPriceCatalogueID);
                                hiddenField4.Value = this.CopyPriceCatalogueID.ToString();
                                foreach (DataRow dataRow1 in dataTable1.Rows)
                                {
                                    lower.Value = dataRow1["IsCumulativePricing"].ToString().ToLower();
                                    hiddenField3.Value = dataRow1["SoldInPacksof"].ToString();
                                }
                                HiddenField hiddenField5 = new HiddenField()
                                {
                                    ID = string.Concat("hid_PriceCatelogueName", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                    Value = this.objBc.SpecialDecode(this.ItemTitle)
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
                                foreach (DataRow row2 in dataTable1.Rows)
                                {
                                    hiddenField6.Value = string.Concat(hiddenField6.Value, row2["Price"].ToString(), "µ");
                                    hiddenField7.Value = string.Concat(hiddenField7.Value, row2["SellingPrice"].ToString(), "µ");
                                    hiddenField8.Value = string.Concat(hiddenField8.Value, row2["Markup"].ToString(), "µ");
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
                                    ID = "hdn_ProductStockManagement"
                                };
                                HiddenField hiddenField10 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_AvailableQuantity", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow dataRow2 in ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCatalogueID)).Rows)
                                {
                                    if (Convert.ToBoolean(dataRow2["ProductStockManagement"].ToString()))
                                    {
                                        hiddenField9.Value = "true";
                                    }
                                    if (int.Parse(dataRow2["AvailableQuantity"].ToString()) == 0 || dataRow2["AvailableQuantity"].ToString().Trim().Length <= 0)
                                    {
                                        hiddenField10.Value = "0";
                                    }
                                    else
                                    {
                                        hiddenField10.Value = dataRow2["AvailableQuantity"].ToString();
                                    }
                                    stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", dataRow2["ProductStockManagement"].ToString().ToLower(), "' />"));
                                    priceCatalogueID = new object[] { "<input type='hidden' id='hdnisstockitem", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", dataRow2["IsStockItem"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                    priceCatalogueID = new object[] { "<input type='hidden' id='hdndrawstockfrom", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", dataRow2["DrawStockFrom"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                    priceCatalogueID = new object[] { "<input type='hidden' id='hdnisbackorder", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", dataRow2["IsBackOrder"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                    priceCatalogueID = new object[] { "<input type='hidden' id='hdnavailableqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' value='", dataRow2["AvailableQuantity"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                    this.IsStockItem = Convert.ToBoolean(dataRow2["IsStockItem"].ToString());
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
                                foreach (DataRow row3 in dataTable1.Rows)
                                {
                                    HiddenField hiddenField13 = hiddenField11;
                                    hiddenField13.Value = string.Concat(hiddenField13.Value, row3["FromQuantity"].ToString(), "µ");
                                    HiddenField hiddenField14 = hiddenField12;
                                    hiddenField14.Value = string.Concat(hiddenField14.Value, row3["ToQuantity"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter4 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                    {
                                        hiddenField11.RenderControl(htmlTextWriter4);
                                        hiddenField12.RenderControl(htmlTextWriter4);
                                    }
                                }
                                stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' style='padding-bottom: 5px;' >"));
                                Label label = new Label()
                                {
                                    ID = string.Concat("lbl_priceStartsFrom", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                };
                                if (Convert.ToBoolean(this.IsPriceStartsFrom))
                                {
                                    short num10 = 1;
                                    foreach (DataRow dataRow3 in dataTable1.Rows)
                                    {
                                        if (num10 == 1)
                                        {
                                            label.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(searchproducts.companyID, 0, Convert.ToDecimal(dataRow3["SellingPrice"].ToString()), 2, "", false, false, true));
                                        }
                                        num10 = (short)(num10 + 1);
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
                                HiddenField hiddenField15 = new HiddenField()
                                {
                                    ID = string.Concat("hdnPriceCatalogueIds", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                    Value = string.Concat(this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable3 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, searchproducts.companyID);
                                foreach (DataRow row4 in dataTable3.Rows)
                                {
                                    priceCatalogueID = new object[] { hiddenField15.Value, ",", row4["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
                                    hiddenField15.Value = string.Concat(priceCatalogueID);
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
                                dropDownList.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                AttributeCollection attributes = dropDownList.Attributes;
                                priceCatalogueID = new object[] { "javascript:ChnageProduct('", this.PriceCatalogueID, "_", this.CopyPriceCatalogueID, "');" };
                                attributes.Add("onchange", string.Concat(priceCatalogueID));
                                dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                dropDownList.EnableViewState = true;
                                dropDownList.AutoPostBack = true;
                                this.BindOtherMultipleDropdownList(dataTable3, dropDownList);
                                if (this.NoProductSelected == "true")
                                {
                                    dropDownList.Items.Insert(0, "--Select--");
                                }
                                DataTable dataTable4 = ProductBasePage.OtherMultiple_Default_Select((long)this.CopyPriceCatalogueID);
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
                                if (this.MatrixType2.ToString().ToLower() == "p")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;'>");
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
                                    priceCatalogueID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'p');" };
                                    attributeCollection.Add("onBlur", string.Concat(priceCatalogueID));
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
                                if (this.MatrixType2.ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;height: 25px;'>");
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
                                    priceCatalogueID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                    attributes1.Add("onBlur", string.Concat(priceCatalogueID));
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
                                if (this.MatrixType2.ToString().ToLower() == "s")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    if (!Convert.ToBoolean(lower.Value))
                                    {
                                        DropDownList languageConversion = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                        };
                                        languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                        languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        languageConversion.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'s');"));
                                        this.SimpleMatrix_DropDownBind(dataTable1, languageConversion);
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
                                            ID = string.Concat("txt_Cumulative_PriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox2.Attributes.Add("value", "Qty");
                                        textBox2.Style.Add("color", "gray");
                                        textBox2.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                        AttributeCollection attributeCollection1 = textBox2.Attributes;
                                        priceCatalogueID = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                        attributeCollection1.Add("onBlur", string.Concat(priceCatalogueID));
                                        textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                        textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                        DropDownList dropDownList1 = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", this.PriceCatalogueID, this.CopyPriceCatalogueID)
                                        };
                                        dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                        dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        AttributeCollection attributes2 = dropDownList1.Attributes;
                                        priceCatalogueID = new object[] { "javascript:quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'s');" };
                                        attributes2.Add("onchange", string.Concat(priceCatalogueID));
                                        dropDownList1.Style.Add("display", "none");
                                        this.SimpleMatrix_DropDownBind(dataTable1, dropDownList1);
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
                                priceCatalogueID = new object[] { "<div id='divcartqty", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                                stringBuilder.Append("</div>");
                                string empty = string.Empty;
                                empty = this.comm.UniqueID;
                                HiddenField hiddenField16 = new HiddenField()
                                {
                                    ID = string.Concat("hdncookieId", this.PriceCatalogueID.ToString(), this.CopyPriceCatalogueID),
                                    Value = empty
                                };
                                using (StringWriter stringWriter12 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter12 = new HtmlTextWriter(stringWriter12))
                                    {
                                        hiddenField16.RenderControl(htmlTextWriter12);
                                    }
                                }
                                if (this.IsStockItem.ToString().ToLower() != "true")
                                {
                                    priceCatalogueID = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower().Trim(), "\",\"", empty, "\"", this.PriceCatalogueID, ")'  class='basketbtnQuickAdd' src='", searchproducts.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                }
                                else
                                {
                                    priceCatalogueID = new object[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",\"", this.MatrixType2.ToString().ToLower().Trim(), "\",\"", empty, "\",", this.PriceCatalogueID, ")}'  class='basketbtnQuickAdd' src='", searchproducts.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(priceCatalogueID));
                                }
                                priceCatalogueID = new object[] { "<img id='btnQucikAddCartLoading", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", searchproducts.strSitePath, "images/radimg1.gif'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                                priceCatalogueID = new object[] { "<span id='btnQucikAddCartoutofstock", this.PriceCatalogueID, this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                                stringBuilder.Append("</div>");
                                priceCatalogueID = new object[] { "<div style='clear:both;'></div><div id='divcartWidthHeight", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'style='padding-left:35px;padding-top:2px;'>" };
                                stringBuilder.Append(string.Concat(priceCatalogueID));
                                stringBuilder.Append("</div>");
                                if (this.MatrixType2.ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                    TextBox textBox3 = new TextBox()
                                    {
                                        ID = string.Concat("txtWidth", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                    };
                                    textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                    textBox3.Style.Add("color", "gray");
                                    textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributeCollection2 = textBox3.Attributes;
                                    priceCatalogueID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                    attributeCollection2.Add("onBlur", string.Concat(priceCatalogueID));
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
                                        ID = string.Concat("txtHeight", this.PriceCatalogueID, this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                    };
                                    textBox4.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                    textBox4.Style.Add("color", "gray");
                                    textBox4.Style.Add("margin-left", "8px");
                                    textBox4.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributes3 = textBox4.Attributes;
                                    priceCatalogueID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCatalogueID, this.CopyPriceCatalogueID, ",'g');" };
                                    attributes3.Add("onBlur", string.Concat(priceCatalogueID));
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
                            str = new string[] { "<div  onmouseover='mouseovershow(", this.PriceCategoryID[this.arrayLength].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", this.PriceCategoryID[this.arrayLength].ToString(), "'>" };
                            stringBuilder.Append(string.Concat(str));
                            HiddenField str11 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxName", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField str12 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxRate", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField str13 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxID", this.PriceCategoryID[this.arrayLength].ToString()),
                                Value = "0"
                            };
                            str12.Value = "0";
                            DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(searchproducts.companyID, Convert.ToInt32(this.PriceCategoryID[this.arrayLength]));
                            foreach (DataRow dataRow4 in taxDetailsByProductCatalogueId.Rows)
                            {
                                str13.Value = dataRow4["SalesTaxRate"].ToString();
                                str11.Value = dataRow4["TaxName"].ToString();
                                str12.Value = dataRow4["TaxRate"].ToString();
                            }
                            using (StringWriter stringWriter15 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter15 = new HtmlTextWriter(stringWriter15))
                                {
                                    str13.RenderControl(htmlTextWriter15);
                                    str11.RenderControl(htmlTextWriter15);
                                    str12.RenderControl(htmlTextWriter15);
                                }
                            }
                            DataTable dataTable5 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCategoryID[this.arrayLength].ToString()));
                            HiddenField lower1 = new HiddenField();
                            HiddenField str14 = new HiddenField();
                            HiddenField hiddenField17 = new HiddenField();
                            lower1.ID = string.Concat("hdn_IsCumulative_", this.PriceCategoryID[this.arrayLength].ToString());
                            lower1.Value = this.IsCumulativePricinig[this.arrayLength].ToString().ToLower();
                            str14.ID = string.Concat("hdn_SoldInPacks_", this.PriceCategoryID[this.arrayLength].ToString());
                            str14.Value = this.SolodinPacksof[this.arrayLength].ToString();
                            hiddenField17.ID = string.Concat("hdn_MainProductID", this.PriceCategoryID[this.arrayLength].ToString());
                            hiddenField17.Value = "0";
                            HiddenField hiddenField18 = new HiddenField()
                            {
                                ID = string.Concat("hid_PriceCatelogueName", this.PriceCategoryID[this.arrayLength].ToString()),
                                Value = this.objBc.SpecialDecode(this.productName[this.arrayLength].ToString().Trim())
                            };
                            using (StringWriter stringWriter16 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter16 = new HtmlTextWriter(stringWriter16))
                                {
                                    hiddenField18.RenderControl(htmlTextWriter16);
                                    lower1.RenderControl(htmlTextWriter16);
                                    str14.RenderControl(htmlTextWriter16);
                                    hiddenField17.RenderControl(htmlTextWriter16);
                                }
                            }
                            HiddenField hiddenField19 = new HiddenField()
                            {
                                ID = string.Concat("hid_CostExcMarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField20 = new HiddenField()
                            {
                                ID = string.Concat("hid_priceList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField21 = new HiddenField()
                            {
                                ID = string.Concat("hid_MarkupList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            foreach (DataRow row5 in dataTable5.Rows)
                            {
                                hiddenField19.Value = string.Concat(hiddenField19.Value, row5["Price"].ToString(), "µ");
                                hiddenField20.Value = string.Concat(hiddenField20.Value, row5["SellingPrice"].ToString(), "µ");
                                hiddenField21.Value = string.Concat(hiddenField21.Value, row5["Markup"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter17 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                {
                                    hiddenField19.RenderControl(htmlTextWriter17);
                                    hiddenField20.RenderControl(htmlTextWriter17);
                                    hiddenField21.RenderControl(htmlTextWriter17);
                                }
                            }
                            HiddenField hiddenField22 = new HiddenField()
                            {
                                ID = "hdn_ProductStockManagement"
                            };
                            HiddenField str15 = new HiddenField()
                            {
                                ID = string.Concat("hdn_AvailableQuantity", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            DataTable dataTable6 = ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCategoryID[this.arrayLength].ToString()));
                            foreach (DataRow dataRow5 in dataTable6.Rows)
                            {
                                if (Convert.ToBoolean(dataRow5["ProductStockManagement"].ToString()))
                                {
                                    hiddenField22.Value = "true";
                                }
                                if (int.Parse(dataRow5["AvailableQuantity"].ToString()) == 0 || dataRow5["AvailableQuantity"].ToString().Trim().Length <= 0)
                                {
                                    str15.Value = "0";
                                }
                                else
                                {
                                    str15.Value = dataRow5["AvailableQuantity"].ToString();
                                }
                                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", dataRow5["ProductStockManagement"].ToString().ToLower(), "' />"));
                                str = new string[] { "<input type='hidden' id='hdnisstockitem", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["IsStockItem"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdndrawstockfrom", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["DrawStockFrom"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdnisbackorder", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["IsBackOrder"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new string[] { "<input type='hidden' id='hdnavailableqty", dataRow5["pricecatalogueid"].ToString(), "' value='", dataRow5["AvailableQuantity"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                this.IsStockItem = Convert.ToBoolean(dataRow5["IsStockItem"].ToString());
                            }
                            using (StringWriter stringWriter18 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                {
                                    hiddenField22.RenderControl(htmlTextWriter18);
                                    str15.RenderControl(htmlTextWriter18);
                                }
                            }
                            HiddenField hiddenField23 = new HiddenField()
                            {
                                ID = string.Concat("hdn_qtyFromList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            HiddenField hiddenField24 = new HiddenField()
                            {
                                ID = string.Concat("hid_qtyToList", this.PriceCategoryID[this.arrayLength].ToString())
                            };
                            foreach (DataRow row6 in dataTable5.Rows)
                            {
                                HiddenField hiddenField25 = hiddenField23;
                                hiddenField25.Value = string.Concat(hiddenField25.Value, row6["FromQuantity"].ToString(), "µ");
                                HiddenField hiddenField26 = hiddenField24;
                                hiddenField26.Value = string.Concat(hiddenField26.Value, row6["ToQuantity"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter19 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter19 = new HtmlTextWriter(stringWriter19))
                                {
                                    hiddenField23.RenderControl(htmlTextWriter19);
                                    hiddenField24.RenderControl(htmlTextWriter19);
                                }
                            }
                            stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");' style='padding-bottom: 5px;' >"));
                            if (Convert.ToBoolean(this.isPriceStartFrom[this.arrayLength].ToString()))
                            {
                                Label label1 = new Label();
                                short num11 = 1;
                                foreach (DataRow dataRow6 in dataTable5.Rows)
                                {
                                    if (num11 == 1)
                                    {
                                        label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(searchproducts.companyID, 0, Convert.ToDecimal(dataRow6["SellingPrice"].ToString()), 2, "", false, false, true));
                                    }
                                    num11 = (short)(num11 + 1);
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
                                    this.SimpleMatrix_DropDownBind(dataTable5, languageConversion1);
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
                                    this.SimpleMatrix_DropDownBind(dataTable5, dropDownList2);
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
                            string uniqueID = string.Empty;
                            uniqueID = this.comm.UniqueID;
                            if (this.IsStockItem.ToString().ToLower() != "true")
                            {
                                str = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")'  class='basketbtnQuickAdd' src='", searchproducts.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new string[] { "<img onmouseout='mouseOutHidediv(", this.PriceCategoryID[this.arrayLength].ToString(), ");'  id='btnQucikAddCart", this.PriceCategoryID[this.arrayLength].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower(), "\")){QuickAddItemCart(", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", this.MatrixType[this.arrayLength].ToString().ToLower().Trim(), "\",\"", uniqueID, "\",", this.PriceCategoryID[this.arrayLength].ToString(), ")}'  class='basketbtnQuickAdd' src='", searchproducts.strSitePath, "images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            str = new string[] { "<img id='btnQucikAddCartLoading", this.PriceCategoryID[this.arrayLength].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", searchproducts.strSitePath, "images/radimg1.gif'>" };
                            stringBuilder.Append(string.Concat(str));
                            str = new string[] { "<span id='btnQucikAddCartoutofstock", this.PriceCategoryID[this.arrayLength].ToString(), "' style='color:red;padding-left:8px; pading-bottom-60px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                            stringBuilder.Append(string.Concat(str));
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
                                AttributeCollection attributeCollection3 = textBox8.Attributes;
                                priceCatalogueID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                attributeCollection3.Add("onBlur", string.Concat(priceCatalogueID));
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
                                AttributeCollection attributes4 = textBox9.Attributes;
                                priceCatalogueID = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", this.PriceCategoryID[this.arrayLength].ToString(), ",'g');" };
                                attributes4.Add("onBlur", string.Concat(priceCatalogueID));
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
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                        if (this.arrayLength >= this.productName.Count - 1)
                        {
                            break;
                        }
                        this.arrayLength = this.arrayLength + 1;
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                }
                this.plh_ProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                this.searchResult = this.productName.Count;
                this.lbl_searchResult.Text = string.Concat("<b>[</b> ", Convert.ToString(this.searchResult), " item(s) found <b>]</b>");
            }
            if (!base.IsPostBack)
            {
                HtmlImage htmlImage = this.imgSucess;
                priceCatalogueID = new object[] { searchproducts.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&aid=", searchproducts.AccountID, " &cid=", searchproducts.companyID };
                htmlImage.Src = string.Concat(priceCatalogueID);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
                this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
                this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
            }
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