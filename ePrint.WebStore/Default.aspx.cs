using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CMS;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class Default : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected PlaceHolder plh_imageBanner;

        //protected PlaceHolder plh_imageBannerDescription;

        //protected HtmlGenericControl div_slidder;

        //protected PlaceHolder plh_ProductsDetailsList;

        //protected RadTreeView radCategoryTree;

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

        //protected Repeater RepCustomproducts;

        //protected PlaceHolder plhRightBanner;

        private MemoryStream stream = new MemoryStream();

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string strImagepath = BaseClass.SitePath;

        public BaseClass objBase = new BaseClass();

        public int arrayLength;

        public int cnt_right;

        public int cnt_left;

        public int centerDivWidth = 3;

        public int productNameLength = 40;

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

        public ArrayList IsShortDescription = new ArrayList();

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public char KeySeparator;

        public string RewriteModule = string.Empty;

        public string AccountType = "p";

        public int isRightBanner;

        public static string imagePath;

        public static string catagoryImagePath;

        public static string productImagePath;

        public static string strSitePath;

        public static string strBannerPath;

        public static string thumbImg;

        public string isProductCategory = "1";

        public string isHomeRightBanner = "1";

        public int isSlidiingBanner;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string displayverticalsep = string.Empty;

        public string centrepaneltype = string.Empty;

        public string AccountName = string.Empty;

        public long StoreUserID;

        private int RoundOff;

        public string NoProductSelected = string.Empty;

        public int CopyPriceCatalogueID;

        private string Description = string.Empty;

        private string ProductImage = string.Empty;

        private string EnableDescription = string.Empty;

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
        }

        public Default()
        {
        }

        private void AddChildNodes(int CompanyID, long AccountID, RadTreeNode node)
        {
            DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Convert.ToInt32(node.Value), this.StoreUserID);
            node.Nodes.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                empty = row["PriceCatalogueCategoryName"].ToString().Trim();
                str = row["categoryProductCnt"].ToString().Trim();
                RadTreeNode radTreeNode = new RadTreeNode()
                {
                    ImageUrl = string.Concat(Default.imagePath, "close_folder.png")
                };
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (empty.ToString().Length <= 14)
                    {
                        radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
                        radTreeNode.ToolTip = empty;
                    }
                    else
                    {
                        radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 14), "...&nbsp;(", str, ")");
                        radTreeNode.ToolTip = empty;
                    }
                }
                else if (empty.ToString().Length <= 14)
                {
                    radTreeNode.Text = empty;
                    radTreeNode.ToolTip = empty;
                }
                else
                {
                    radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 14), "...&nbsp;(", str, ")");
                    radTreeNode.ToolTip = empty;
                }
                radTreeNode.Value = ((int)row["PriceCatalogueCategoryID"]).ToString();
                radTreeNode.Target = "_new";
                if ((int)row["SubCatCount"] <= 0)
                {
                    node.Nodes.Add(radTreeNode);
                }
                else
                {
                    radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                    node.Nodes.Add(radTreeNode);
                }
            }
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
            stringBuilder.Append("<div class='productDetails_div'><div class='productDetails_innerdiv'>");
            stringBuilder.Append(string.Concat("<div class='productName_div'><label>", base.SpecialDecode(dataRow["Name"].ToString()), "</label></div><div class='clearBoth'></div>"));
            stringBuilder.Append(string.Concat("<div class='productImage_div'><a href='", empty));
            string[] strArrays = new string[] { "<img title='", dataRow["Name"].ToString(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '></a></div>" };
            stringBuilder.Append(string.Concat(strArrays));
            stringBuilder.Append(string.Concat("<div class='clearBoth'></div><div class='productCategoryDescription_div' title=''><label> ", base.SpecialDecode(dataRow["Description"].ToString()), "</label></div>"));
            stringBuilder.Append("<div class='clearBoth'></div></div></div>");
            return stringBuilder;
        }

        private void generatecategorybyrepeater(DataTable dt)
        {
            DataColumn dataColumn = new DataColumn("Productpath", typeof(string));
            dt.Columns.Add(dataColumn);
            DataColumn dataColumn1 = new DataColumn("ImagePath", typeof(string));
            dt.Columns.Add(dataColumn1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Image"].ToString().Trim() != "")
                    {
                        object[] str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_", row["Image"].ToString(), "&amp;type=c&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                        row["ImagePath"] = string.Concat(str);
                    }
                    else
                    {
                        object[] accountID = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                        row["ImagePath"] = string.Concat(accountID);
                    }
                    if (ConnectionClass.RewriteModule.ToLower() != "on")
                    {
                        row["Productpath"] = string.Concat(Default.strSitePath, "products/product.aspx?ID=", row["ID"].ToString());
                    }
                    else
                    {
                        string[] keySeparator = new string[] { Default.strSitePath, "product", ConnectionClass.KeySeparator, row["ID"].ToString(), ConnectionClass.FileExtension };
                        row["Productpath"] = base.ResolveUrl(string.Concat(keySeparator));
                    }
                }
            }
            this.RepCustomproducts.DataSource = dt;
            this.RepCustomproducts.DataBind();
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
            this.generatecategorybyrepeater(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["Type"].ToString().ToLower() != "c")
                    {
                        if (dataTable.Rows[i]["Type"].ToString().ToLower() == "b")
                        {
                            stringBuilder = stringBuilder.Append(this.generateBanner(dataTable.Rows[i]));
                        }
                        else if (dataTable.Rows[i]["Type"].ToString().ToLower() == "t")
                        {
                            stringBuilder = stringBuilder.Append(this.generateCustomeText(dataTable.Rows[i]));
                        }
                    }
                }
                this.plh_Customize_new.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            }
        }

        public void getNewProducts(int CompanyID, long AccountID, string Product_Type)
        {
            IDisposable disposable;
            object[] str;
            string[] strArrays;
            IEnumerator enumerator;
            string[] strArrays1;
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable = ProductBasePage.Select_NewProductList((long)CompanyID, AccountID, Product_Type);
            DataTable dataTable1 = ProductBasePage.Select_FeaturedProducts_Description((long)CompanyID, AccountID);
            if (dataTable1.Rows.Count > 0 && Product_Type == "featured")
            {
                foreach (DataRow row in dataTable1.Rows)
                {
                    this.PriceCatalogueID.Add(row["PriceCatalogueID"].ToString());
                }
            }
            if (dataTable.Rows.Count > 0 && Product_Type == "new")
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.PriceCatalogueID.Add(dataRow["PriceCatalogueID"].ToString());
                }
            }
            DataTable dataTable2 = new DataTable();
            if (this.PriceCatalogueID.Count <= 0)
            {
                this.plh_NewProductsDetails.Controls.Add(new LiteralControl("<div id='noRecordFound'><strong> No Record Found </strong></div>"));
            }
            else if (Product_Type == "featured")
            {
                if (dataTable1.Rows.Count <= 0)
                {
                    this.plh_NewProductsDetails.Controls.Add(new LiteralControl("<div id='noRecordFound'><strong> No Record Found </strong></div>"));
                }
                else
                {
                    foreach (DataRow copyPriceCatalogueID in dataTable1.Rows)
                    {
                        if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            this.CopyPriceCatalogueID = Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"]);
                            DataTable dataTable3 = ProductBasePage.OtherMultiple_DefaultItem_Select(Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                            if (dataTable3.Rows.Count != 0)
                            {
                                this.NoProductSelected = "false";
                            }
                            else
                            {
                                this.NoProductSelected = "true";
                                copyPriceCatalogueID["pricecatalogueid"] = this.CopyPriceCatalogueID;
                            }
                            if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["KitItemID"] != null)
                            {
                                copyPriceCatalogueID["pricecatalogueid"] = dataTable3.Rows[0]["KitItemID"];
                            }
                        }
                        stringBuilder.Append("<div valign='top'>");
                        if (base.Request.Browser.Type.ToLower().Contains("firefox"))
                        {
                            if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                str = new object[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");' class='productDetails_div'><div>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat("<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDetails_div'><div>"));
                            }
                        }
                        else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            str = new object[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");' class='productDetails_div'><div>" };
                            stringBuilder.Append(string.Concat(str));
                        }
                        else
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDetails_div'><div>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        string empty = string.Empty;
                        empty = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='div_prodname_default'" };
                        stringBuilder.Append(string.Concat(strArrays));
                        stringBuilder.Append(string.Concat("<label>", base.SpecialDecode(empty), "</label>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div class='clearBoth'></div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productImage_div'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=", copyPriceCatalogueID["ProductImage"].ToString(), "&amp;type=p&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                            else
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                        }
                        else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            dataTable2 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(copyPriceCatalogueID["pricecatalogueid"]));
                            enumerator = dataTable2.Rows.GetEnumerator();
                            try
                            {
                                if (enumerator.MoveNext())
                                {
                                    DataRow current = (DataRow)enumerator.Current;
                                    this.ProductImage = current["ProductImage"].ToString();
                                    this.Description = current["Description"].ToString();
                                    copyPriceCatalogueID["CatalogueName"] = current["CatalogueName"].ToString();
                                    copyPriceCatalogueID["MatrixType"] = current["MatrixType"].ToString();
                                    copyPriceCatalogueID["Description"] = current["Description"].ToString();
                                    copyPriceCatalogueID["IsShortDescription"] = current["IsShortDescription"];
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
                            if (this.ProductImage.ToString() != "")
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=", this.ProductImage, "&amp;type=p&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                            else
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                        }
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                            {
                                strArrays = new string[] { "<a href='", null, null, null, null, null, null };
                                strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                strArrays[2] = "'><img  title='";
                                strArrays[3] = copyPriceCatalogueID["CatalogueName"].ToString();
                                strArrays[4] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                strArrays[5] = this.finalimageName1;
                                strArrays[6] = "\" alt=' '/></a>";
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<a href='", null, null, null, null, null, null };
                                strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                strArrays[2] = "'><img  title='";
                                strArrays[3] = copyPriceCatalogueID["CatalogueName"].ToString();
                                strArrays[4] = "'  src=\"";
                                strArrays[5] = this.finalimageName1;
                                strArrays[6] = "\" alt=' '/></a>";
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            stringBuilder.Append("</div>");
                        }
                        else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                            {
                                str = new object[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.CopyPriceCatalogueID, "' title='", copyPriceCatalogueID["CatalogueName"].ToString(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.CopyPriceCatalogueID, "' title='", copyPriceCatalogueID["CatalogueName"].ToString(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            stringBuilder.Append("</div>");
                        }
                        else
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                            {
                                strArrays = new string[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img title='", copyPriceCatalogueID["CatalogueName"].ToString(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img title='", copyPriceCatalogueID["CatalogueName"].ToString(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            stringBuilder.Append("</div>");
                        }
                        this.finalimageName1 = "";
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div  class='clearBoth'></div>");
                        string empty1 = string.Empty;
                        if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            if (Convert.ToInt32(copyPriceCatalogueID["IsShortDescription"]) == 1)
                            {
                                empty1 = (copyPriceCatalogueID["Description"].ToString().Trim().Length <= this.productDescriptionLength ? this.objBase.SpecialDecode(copyPriceCatalogueID["Description"].ToString().Trim()) : string.Concat(this.objBase.SpecialDecode(copyPriceCatalogueID["Description"].ToString().Trim().Substring(0, this.productDescriptionLength)), "..."));
                            }
                        }
                        else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            empty1 = this.objBase.SpecialDecode(this.Description);
                        }
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDescription_div'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        str = new object[] { "<label id='lblDesc", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'> ", empty1, " </label>" };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div  class='clearBoth'></div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' id='div_btnsave", this.PriceCatalogueID[this.arrayLength].ToString(), "' class='productViewBtn_div DisplayBlock'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        strArrays = new string[] { "<input type='button' value='View Details' class='x-btnpro Grey main' onclick='Onclick_Product(", this.PriceCatalogueID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString().Replace("\"", "`")), "\");'/>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        this.Session["SearchKey"] = "HomePage";
                        stringBuilder.Append("</div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");'class='SaveDiv'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        stringBuilder.Append(string.Concat("<div id='div_btnsaveprocess", this.PriceCatalogueID[this.arrayLength].ToString(), "' style='display:none;margin-left:60px;margin-top:4.5px;width:76px;height:18px;' class='x-btnpro Grey main'>"));
                        stringBuilder.Append(string.Concat("<img class='trans' src='", this.strImagepath, "images/radimg1.gif'>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            if (Convert.ToBoolean(copyPriceCatalogueID["isQuickItem"]))
                            {
                                str = new object[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                HiddenField hiddenField = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxName", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField1 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxRate", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField str1 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxID", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(CompanyID, Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"]));
                                foreach (DataRow row1 in taxDetailsByProductCatalogueId.Rows)
                                {
                                    str1.Value = row1["SalesTaxRate"].ToString();
                                    hiddenField.Value = row1["TaxName"].ToString();
                                    hiddenField1.Value = row1["TaxRate"].ToString();
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
                                DataTable dataTable4 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                                HiddenField hiddenField2 = new HiddenField()
                                {
                                    ID = string.Concat("hid_PriceCatelogueName", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                    Value = this.objBase.SpecialDecode(copyPriceCatalogueID["CatalogueName"].ToString().Trim())
                                };
                                using (StringWriter stringWriter1 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter1 = new HtmlTextWriter(stringWriter1))
                                    {
                                        hiddenField2.RenderControl(htmlTextWriter1);
                                    }
                                }
                                HiddenField hiddenField3 = new HiddenField()
                                {
                                    ID = string.Concat("hid_CostExcMarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField4 = new HiddenField()
                                {
                                    ID = string.Concat("hid_priceList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField5 = new HiddenField()
                                {
                                    ID = string.Concat("hid_MarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                bool flag = false;
                                foreach (DataRow dataRow1 in dataTable4.Rows)
                                {
                                    hiddenField3.Value = string.Concat(hiddenField3.Value, dataRow1["Price"].ToString(), "µ");
                                    hiddenField4.Value = string.Concat(hiddenField4.Value, dataRow1["SellingPrice"].ToString(), "µ");
                                    hiddenField5.Value = string.Concat(hiddenField5.Value, dataRow1["Markup"].ToString(), "µ");
                                    flag = Convert.ToBoolean(dataRow1["IsPriceStartFrom"]);
                                }
                                using (StringWriter stringWriter2 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter2 = new HtmlTextWriter(stringWriter2))
                                    {
                                        hiddenField3.RenderControl(htmlTextWriter2);
                                        hiddenField4.RenderControl(htmlTextWriter2);
                                        hiddenField5.RenderControl(htmlTextWriter2);
                                    }
                                }
                                HiddenField hiddenField6 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_ProductStockManagement", this.CopyPriceCatalogueID)
                                };
                                HiddenField str2 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_AvailableQuantity", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable5 = ProductBasePage.productsDetails_Select(Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"].ToString()));
                                foreach (DataRow row2 in dataTable5.Rows)
                                {
                                    if (Convert.ToBoolean(row2["ProductStockManagement"].ToString()))
                                    {
                                        hiddenField6.Value = "true";
                                    }
                                    if (int.Parse(row2["AvailableQuantity"].ToString()) == 0 || row2["AvailableQuantity"].ToString().Trim().Length <= 0)
                                    {
                                        str2.Value = "0";
                                    }
                                    else
                                    {
                                        str2.Value = row2["AvailableQuantity"].ToString();
                                    }
                                }
                                using (StringWriter stringWriter3 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter3 = new HtmlTextWriter(stringWriter3))
                                    {
                                        hiddenField6.RenderControl(htmlTextWriter3);
                                        str2.RenderControl(htmlTextWriter3);
                                    }
                                }
                                HiddenField hiddenField7 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_qtyFromList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField8 = new HiddenField()
                                {
                                    ID = string.Concat("hid_qtyToList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField lower = new HiddenField()
                                {
                                    ID = string.Concat("hdn_IsCumulative_", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField9 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_MainProductID", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                    Value = this.CopyPriceCatalogueID.ToString()
                                };
                                HiddenField str3 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_SoldInPacks_", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow dataRow2 in dataTable4.Rows)
                                {
                                    HiddenField hiddenField10 = hiddenField7;
                                    hiddenField10.Value = string.Concat(hiddenField10.Value, dataRow2["FromQuantity"].ToString(), "µ");
                                    HiddenField hiddenField11 = hiddenField8;
                                    hiddenField11.Value = string.Concat(hiddenField11.Value, dataRow2["ToQuantity"].ToString(), "µ");
                                    lower.Value = dataRow2["IsCumulativePricing"].ToString().ToLower();
                                    str3.Value = dataRow2["SoldInPacksOf"].ToString();
                                }
                                using (StringWriter stringWriter4 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                    {
                                        hiddenField7.RenderControl(htmlTextWriter4);
                                        hiddenField8.RenderControl(htmlTextWriter4);
                                        lower.RenderControl(htmlTextWriter4);
                                        hiddenField9.RenderControl(htmlTextWriter4);
                                        str3.RenderControl(htmlTextWriter4);
                                    }
                                }
                                stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                                foreach (DataRow row3 in dataTable4.Rows)
                                {
                                    stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", copyPriceCatalogueID["ProductStockManagement"].ToString().ToLower(), "' />"));
                                    str = new object[] { "<input type='hidden' id='hdnisstockitem", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", copyPriceCatalogueID["IsStockItem"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdndrawstockfrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", copyPriceCatalogueID["DrawStockFrom"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdnisbackorder", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", copyPriceCatalogueID["IsBackOrder"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                    str = new object[] { "<input type='hidden' id='hdnavailableqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", copyPriceCatalogueID["AvailableQuantity"].ToString(), "' />" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                Label label = new Label()
                                {
                                    ID = string.Concat("lbl_priceStartsFrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                if (flag)
                                {
                                    short num = 1;
                                    foreach (DataRow dataRow3 in dataTable4.Rows)
                                    {
                                        if (num == 1)
                                        {
                                            label.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow3["SellingPrice"].ToString()), 2, "", false, false, true));
                                        }
                                        num = (short)(num + 1);
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
                                    ID = string.Concat("hdnPriceCatalogueIds", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                    Value = string.Concat(copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
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
                                    ID = string.Concat("ddlOtherMultiplrDrp", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                };
                                dropDownList.CssClass = "dropDownMultipleQuickAdd";
                                AttributeCollection attributes = dropDownList.Attributes;
                                str = new object[] { "javascript:ChnageProduct('", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "_", this.CopyPriceCatalogueID, "');" };
                                attributes.Add("onchange", string.Concat(str));
                                dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                dropDownList.EnableViewState = true;
                                dropDownList.AutoPostBack = true;
                                this.BindOtherMultipleDropdownList(dataTable6, dropDownList);
                                if (this.NoProductSelected == "true")
                                {
                                    dropDownList.Items.Insert(0, "--Select--");
                                }
                                DataTable dataTable7 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.CopyPriceCatalogueID);
                                if (dataTable7.Rows.Count > 0 && dataTable7.Rows[0]["KitItemID"] != null)
                                {
                                    this.objBase.SetDDLValue(dropDownList, dataTable7.Rows[0]["KitItemID"].ToString());
                                }
                                using (StringWriter stringWriter7 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter7 = new HtmlTextWriter(stringWriter7))
                                    {
                                        dropDownList.RenderControl(htmlTextWriter7);
                                    }
                                }
                                stringBuilder.Append("</div>");
                                if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "p")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    TextBox textBox = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox.Attributes.Add("value", "Qty");
                                    textBox.Style.Add("color", "gray");
                                    textBox.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    AttributeCollection attributeCollection = textBox.Attributes;
                                    str = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'p');" };
                                    attributeCollection.Add("onBlur", string.Concat(str));
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
                                if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;height: 25px;' >");
                                    TextBox textBox1 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox1.Attributes.Add("value", "Qty");
                                    textBox1.Style.Add("color", "gray");
                                    textBox1.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    AttributeCollection attributes1 = textBox1.Attributes;
                                    str = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                    attributes1.Add("onBlur", string.Concat(str));
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
                                if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "s")
                                {
                                    if (!Convert.ToBoolean(lower.Value))
                                    {
                                        stringBuilder.Append("<div style='padding-left: 35px;' >");
                                        DropDownList languageConversion = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                        languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        AttributeCollection attributeCollection1 = languageConversion.Attributes;
                                        str = new object[] { "javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'s');" };
                                        attributeCollection1.Add("onchange", string.Concat(str));
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
                                        stringBuilder.Append("<div style='padding-left: 35px;' >");
                                        TextBox textBox2 = new TextBox()
                                        {
                                            ID = string.Concat("txt_Cumulative_PriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox2.Attributes.Add("value", "Qty");
                                        textBox2.Style.Add("color", "gray");
                                        textBox2.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                        AttributeCollection attributes2 = textBox2.Attributes;
                                        str = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'s');" };
                                        attributes2.Add("onBlur", string.Concat(str));
                                        textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                        textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                        using (StringWriter stringWriter11 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter11 = new HtmlTextWriter(stringWriter11))
                                            {
                                                textBox2.RenderControl(htmlTextWriter11);
                                            }
                                        }
                                    }
                                }
                                str = new object[] { "<div id='divcartqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (copyPriceCatalogueID["IsStockItem"].ToString().ToLower() == "true")
                                {
                                    str = new object[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                else
                                {
                                    str = new object[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                str = new object[] { "<img id='btnQucikAddCartLoading", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<span id='btnQucikAddCartoutofstock", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                str = new object[] { "<div id='divcartWidthHeight", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'style='padding-left:35px;clear:both;'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                    TextBox textBox3 = new TextBox()
                                    {
                                        ID = string.Concat("txtWidth", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                    };
                                    textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                    textBox3.Style.Add("color", "gray");
                                    textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributeCollection2 = textBox3.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                    attributeCollection2.Add("onBlur", string.Concat(str));
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
                                        ID = string.Concat("txtHeight", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                    };
                                    textBox4.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                    textBox4.Style.Add("color", "gray");
                                    textBox4.Style.Add("margin-left", "8px");
                                    textBox4.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributes3 = textBox4.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                    attributes3.Add("onBlur", string.Concat(str));
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
                        else if (Convert.ToBoolean(copyPriceCatalogueID["isQuickItem"]))
                        {
                            strArrays = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", copyPriceCatalogueID["pricecatalogueid"].ToString(), "'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            HiddenField str4 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxName", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField str5 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxRate", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField str6 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxID", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            DataTable taxDetailsByProductCatalogueId1 = ProductBasePage.GetTaxDetails_ByProductCatalogueId(CompanyID, Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"]));
                            foreach (DataRow dataRow4 in taxDetailsByProductCatalogueId1.Rows)
                            {
                                str6.Value = dataRow4["Salestaxrate"].ToString();
                                str4.Value = dataRow4["TaxName"].ToString();
                                str5.Value = dataRow4["TaxRate"].ToString();
                            }
                            using (StringWriter stringWriter14 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter14 = new HtmlTextWriter(stringWriter14))
                                {
                                    str6.RenderControl(htmlTextWriter14);
                                    str4.RenderControl(htmlTextWriter14);
                                    str5.RenderControl(htmlTextWriter14);
                                }
                            }
                            DataTable dataTable8 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                            HiddenField hiddenField13 = new HiddenField()
                            {
                                ID = string.Concat("hid_PriceCatelogueName", copyPriceCatalogueID["pricecatalogueid"].ToString()),
                                Value = this.objBase.SpecialDecode(copyPriceCatalogueID["CatalogueName"].ToString().Trim())
                            };
                            using (StringWriter stringWriter15 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter15 = new HtmlTextWriter(stringWriter15))
                                {
                                    hiddenField13.RenderControl(htmlTextWriter15);
                                }
                            }
                            HiddenField hiddenField14 = new HiddenField()
                            {
                                ID = string.Concat("hid_CostExcMarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField15 = new HiddenField()
                            {
                                ID = string.Concat("hid_priceList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField16 = new HiddenField()
                            {
                                ID = string.Concat("hid_MarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            foreach (DataRow row5 in dataTable8.Rows)
                            {
                                hiddenField14.Value = string.Concat(hiddenField14.Value, row5["Price"].ToString(), "µ");
                                hiddenField15.Value = string.Concat(hiddenField15.Value, row5["SellingPrice"].ToString(), "µ");
                                hiddenField16.Value = string.Concat(hiddenField16.Value, row5["Markup"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter16 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter16 = new HtmlTextWriter(stringWriter16))
                                {
                                    hiddenField14.RenderControl(htmlTextWriter16);
                                    hiddenField15.RenderControl(htmlTextWriter16);
                                    hiddenField16.RenderControl(htmlTextWriter16);
                                }
                            }
                            HiddenField hiddenField17 = new HiddenField()
                            {
                                ID = "hdn_ProductStockManagement"
                            };
                            HiddenField str7 = new HiddenField()
                            {
                                ID = string.Concat("hdn_AvailableQuantity", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            DataTable dataTable9 = ProductBasePage.productsDetails_Select(Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"].ToString()));
                            foreach (DataRow dataRow5 in dataTable9.Rows)
                            {
                                if (Convert.ToBoolean(dataRow5["ProductStockManagement"].ToString()))
                                {
                                    hiddenField17.Value = "true";
                                }
                                if (int.Parse(dataRow5["AvailableQuantity"].ToString()) == 0 || dataRow5["AvailableQuantity"].ToString().Trim().Length <= 0)
                                {
                                    str7.Value = "0";
                                }
                                else
                                {
                                    str7.Value = dataRow5["AvailableQuantity"].ToString();
                                }
                            }
                            using (StringWriter stringWriter17 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                {
                                    hiddenField17.RenderControl(htmlTextWriter17);
                                    str7.RenderControl(htmlTextWriter17);
                                }
                            }
                            HiddenField hiddenField18 = new HiddenField()
                            {
                                ID = string.Concat("hdn_qtyFromList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField19 = new HiddenField()
                            {
                                ID = string.Concat("hid_qtyToList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField20 = new HiddenField()
                            {
                                ID = string.Concat("hdn_IsCumulative_", copyPriceCatalogueID["pricecatalogueid"].ToString()),
                                Value = copyPriceCatalogueID["IsCumulativePricing"].ToString().ToLower()
                            };
                            HiddenField hiddenField21 = new HiddenField()
                            {
                                ID = string.Concat("hdn_MainProductID", copyPriceCatalogueID["pricecatalogueid"].ToString()),
                                Value = "0"
                            };
                            HiddenField hiddenField22 = new HiddenField()
                            {
                                ID = string.Concat("hdn_SoldInPacks_", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                Value = copyPriceCatalogueID["SoldInPacksOf"].ToString()
                            };
                            foreach (DataRow row6 in dataTable8.Rows)
                            {
                                HiddenField hiddenField23 = hiddenField18;
                                hiddenField23.Value = string.Concat(hiddenField23.Value, row6["FromQuantity"].ToString(), "µ");
                                HiddenField hiddenField24 = hiddenField19;
                                hiddenField24.Value = string.Concat(hiddenField24.Value, row6["ToQuantity"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter18 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                {
                                    hiddenField18.RenderControl(htmlTextWriter18);
                                    hiddenField19.RenderControl(htmlTextWriter18);
                                    hiddenField20.RenderControl(htmlTextWriter18);
                                    hiddenField21.RenderControl(htmlTextWriter18);
                                    hiddenField22.RenderControl(htmlTextWriter18);
                                }
                            }
                            stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                            stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", copyPriceCatalogueID["ProductStockManagement"].ToString().ToLower(), "' />"));
                            strArrays = new string[] { "<input type='hidden' id='hdnisstockitem", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["IsStockItem"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdndrawstockfrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["DrawStockFrom"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdnisbackorder", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["IsBackOrder"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdnavailableqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["AvailableQuantity"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (Convert.ToBoolean(copyPriceCatalogueID["IsPriceStartFrom"]))
                            {
                                Label label1 = new Label();
                                short num1 = 1;
                                foreach (DataRow dataRow6 in dataTable8.Rows)
                                {
                                    if (num1 == 1)
                                    {
                                        label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow6["SellingPrice"].ToString()), 2, "", false, false, true));
                                    }
                                    num1 = (short)(num1 + 1);
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
                            if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "p")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;' >");
                                TextBox textBox5 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox5.Attributes.Add("value", "Qty");
                                textBox5.Style.Add("color", "gray");
                                textBox5.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                textBox5.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'p');"));
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
                            if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;height: 25px;' >");
                                TextBox textBox6 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox6.Attributes.Add("value", "Qty");
                                textBox6.Style.Add("color", "gray");
                                textBox6.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                textBox6.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'g');"));
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
                            if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "s")
                            {
                                if (!Convert.ToBoolean(hiddenField20.Value))
                                {
                                    stringBuilder.Append("<div style='padding-left: 50px;' >");
                                    DropDownList dropDownList1 = new DropDownList()
                                    {
                                        CssClass = "ddlPriceQtyQuickAdd",
                                        ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                    };
                                    dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                    dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                    dropDownList1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'s');"));
                                    this.SimpleMatrix_DropDownBind(dataTable8, dropDownList1);
                                    using (StringWriter stringWriter22 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter22 = new HtmlTextWriter(stringWriter22))
                                        {
                                            dropDownList1.RenderControl(htmlTextWriter22);
                                        }
                                    }
                                }
                                else
                                {
                                    stringBuilder.Append("<div style='padding-left: 60px;' >");
                                    TextBox textBox7 = new TextBox()
                                    {
                                        ID = string.Concat("txt_Cumulative_PriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox7.Attributes.Add("value", "Qty");
                                    textBox7.Style.Add("color", "gray");
                                    textBox7.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox7.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'s');"));
                                    textBox7.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox7.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter23 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter23 = new HtmlTextWriter(stringWriter23))
                                        {
                                            textBox7.RenderControl(htmlTextWriter23);
                                        }
                                    }
                                }
                            }
                            if (copyPriceCatalogueID["IsStockItem"].ToString().ToLower() == "true")
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            strArrays = new string[] { "<img id='btnQucikAddCartLoading", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<span id='btnQucikAddCartoutofstock", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("</div>");
                            if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 60px;padding-top:5px;'>");
                                TextBox textBox8 = new TextBox()
                                {
                                    ID = string.Concat("txtWidth", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                };
                                textBox8.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                textBox8.Style.Add("color", "gray");
                                textBox8.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributeCollection3 = textBox8.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'g');" };
                                attributeCollection3.Add("onBlur", string.Concat(str));
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
                                    ID = string.Concat("txtHeight", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                };
                                textBox9.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                textBox9.Style.Add("color", "gray");
                                textBox9.Style.Add("margin-left", "8px");
                                textBox9.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributes4 = textBox9.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'g');" };
                                attributes4.Add("onBlur", string.Concat(str));
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
                        stringBuilder.Append("</div></div>");
                        stringBuilder.Append("</div>");
                        if (this.arrayLength >= dataTable.Rows.Count - 1)
                        {
                            break;
                        }
                        this.arrayLength = this.arrayLength + 1;
                    }
                    this.plh_NewProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                }
            }
            else if (this.PriceCatalogueID.Count > 0)
            {
                if (dataTable.Rows.Count <= 0)
                {
                    this.plh_NewProductsDetails.Controls.Add(new LiteralControl("<div id='noRecordFound'><strong> No Record Found </strong></div>"));
                }
                else
                {
                    foreach (DataRow item in dataTable.Rows)
                    {
                        if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            this.CopyPriceCatalogueID = Convert.ToInt32(item["PriceCatalogueID"]);
                            DataTable dataTable10 = ProductBasePage.OtherMultiple_DefaultItem_Select(Convert.ToInt32(item["PriceCatalogueID"].ToString()));
                            if (dataTable10.Rows.Count != 0)
                            {
                                this.NoProductSelected = "false";
                            }
                            else
                            {
                                this.NoProductSelected = "true";
                                item["pricecatalogueid"] = this.CopyPriceCatalogueID;
                            }
                            if (dataTable10.Rows.Count > 0 && dataTable10.Rows[0]["KitItemID"] != null)
                            {
                                item["pricecatalogueid"] = dataTable10.Rows[0]["KitItemID"];
                            }
                        }
                        stringBuilder.Append("<div valign='top'>");
                        if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");'  class='productDetails_div'><div>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' class='productDetails_div'><div>"));
                        }
                        string empty2 = string.Empty;
                        empty2 = item["CatalogueName"].ToString().Trim();
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='div_prodname_default'" };
                        stringBuilder.Append(string.Concat(strArrays));
                        stringBuilder.Append(string.Concat("<label>", base.SpecialDecode(empty2), "</label>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div  class='clearBoth'></div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productImage_div'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        if (item["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            if (item["ProductImage"].ToString() != "")
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=", item["ProductImage"].ToString(), "&amp;type=p&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                            else
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                        }
                        else if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            dataTable2 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(item["pricecatalogueid"]));
                            enumerator = dataTable2.Rows.GetEnumerator();
                            try
                            {
                                if (enumerator.MoveNext())
                                {
                                    DataRow current1 = (DataRow)enumerator.Current;
                                    this.ProductImage = current1["ProductImage"].ToString();
                                    this.Description = current1["Description"].ToString();
                                    item["CatalogueName"] = current1["CatalogueName"].ToString();
                                    item["MatrixType"] = current1["MatrixType"].ToString();
                                    item["Description"] = current1["Description"].ToString();
                                    item["IsShortDescription"] = current1["IsShortDescription"];
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
                            if (this.ProductImage.ToString() != "")
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=", this.ProductImage, "&amp;type=p&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                            else
                            {
                                str = new object[] { Default.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", AccountID, "&amp;cid=", CompanyID };
                                this.finalimageName1 = string.Concat(str);
                            }
                        }
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                            {
                                strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                                if (item["ProductImage"].ToString() != "")
                                {
                                    strArrays = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                    strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty2), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                    strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                    strArrays[2] = "'><img id='imgGetID1";
                                    strArrays[3] = item["pricecatalogueid"].ToString();
                                    strArrays[4] = "'  title='";
                                    strArrays[5] = item["CatalogueName"].ToString();
                                    strArrays[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                    strArrays[7] = this.finalimageName1;
                                    strArrays[8] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                else
                                {
                                    strArrays = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                    strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty2), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                    strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                    strArrays[2] = "'><img id='imgGetID1";
                                    strArrays[3] = item["pricecatalogueid"].ToString();
                                    strArrays[4] = "'  title='";
                                    strArrays[5] = item["CatalogueName"].ToString();
                                    strArrays[6] = "'  src=\"";
                                    strArrays[7] = this.finalimageName1;
                                    strArrays[8] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                stringBuilder.Append("</div>");
                            }
                            else
                            {
                                strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                                if (item["ProductImage"].ToString() != "")
                                {
                                    strArrays = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                    strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty2), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                    strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                    strArrays[2] = "'><img id='imgGetID1";
                                    strArrays[3] = item["pricecatalogueid"].ToString();
                                    strArrays[4] = "'  title='";
                                    strArrays[5] = item["CatalogueName"].ToString();
                                    strArrays[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                    strArrays[7] = this.finalimageName1;
                                    strArrays[8] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                else
                                {
                                    strArrays = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                    strArrays1 = new string[] { Default.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(empty2), ConnectionClass.KeySeparator, this.PriceCatalogueID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                    strArrays[1] = base.ResolveUrl(string.Concat(strArrays1));
                                    strArrays[2] = "'><img id='imgGetID1";
                                    strArrays[3] = item["pricecatalogueid"].ToString();
                                    strArrays[4] = "'  title='";
                                    strArrays[5] = item["CatalogueName"].ToString();
                                    strArrays[6] = "'  src=\"";
                                    strArrays[7] = this.finalimageName1;
                                    strArrays[8] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(strArrays));
                                }
                                stringBuilder.Append("</div>");
                            }
                        }
                        else if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (item["ProductImage"].ToString() != "")
                            {
                                str = new object[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.CopyPriceCatalogueID, "' title='", item["CatalogueName"].ToString(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", this.CopyPriceCatalogueID, "' title='", item["CatalogueName"].ToString(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            stringBuilder.Append("</div>");
                        }
                        else
                        {
                            strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productName_Link'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (item["ProductImage"].ToString() != "")
                            {
                                strArrays = new string[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", item["pricecatalogueid"].ToString(), "' title='", item["CatalogueName"].ToString(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<a href='", Default.strSitePath, "products/productdetails.aspx?ID=", this.PriceCatalogueID[this.arrayLength].ToString(), "&amp;type=0'><img id='imgGetID1", item["pricecatalogueid"].ToString(), "' title='", item["CatalogueName"].ToString(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            stringBuilder.Append("</div>");
                        }
                        this.finalimageName1 = "";
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div  class='clearBoth'></div>");
                        string empty3 = string.Empty;
                        if (item["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                        {
                            if (Convert.ToInt32(item["IsShortDescription"]) == 1)
                            {
                                empty3 = (item["Description"].ToString().Trim().Length <= this.productDescriptionLength ? this.objBase.SpecialDecode(item["Description"].ToString().Trim()) : string.Concat(this.objBase.SpecialDecode(item["Description"].ToString().Trim().Substring(0, this.productDescriptionLength)), "..."));
                            }
                        }
                        else if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            empty3 = this.objBase.SpecialDecode(this.Description);
                        }
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productDescription_div'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        str = new object[] { "<label id='lblDesc", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'> ", empty3, "</label>" };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div  class='clearBoth'></div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' class='productViewBtn_div'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' id='div_btnsave", this.PriceCatalogueID[this.arrayLength].ToString(), "' class='productViewBtn_div DisplayBlock'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        strArrays = new string[] { "<input type='button' value='View Details' class='x-btnpro Grey main' onclick='Onclick_Product(", this.PriceCatalogueID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(item["CatalogueName"].ToString().Replace("\"", "`")), "\");'/>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        this.Session["SearchKey"] = "HomePage";
                        stringBuilder.Append("</div>");
                        strArrays = new string[] { "<div onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");'class='SaveDiv'>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        stringBuilder.Append(string.Concat("<div id='div_btnsaveprocess", this.PriceCatalogueID[this.arrayLength].ToString(), "' class='x-btnpro Grey main div_btnsaveprocess'style='margin-left:60px;margin-top:4.5px;width: 76px;height:18px;'>"));
                        stringBuilder.Append(string.Concat("<img class='trans' src='", this.strImagepath, "images/radimg1.gif'>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</div>");
                        if (item["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                        {
                            if (Convert.ToBoolean(item["isQuickItem"]))
                            {
                                strArrays = new string[] { "<div  onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", item["pricecatalogueid"].ToString(), "'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                                HiddenField str8 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxName", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField str9 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxRate", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField str10 = new HiddenField()
                                {
                                    ID = string.Concat("hid_TaxID", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow row7 in ProductBasePage.GetTaxDetails(CompanyID, this.StoreUserID).Rows)
                                {
                                    str10.Value = row7["TaxID"].ToString();
                                    str8.Value = row7["TaxName"].ToString();
                                    str9.Value = row7["TaxRate"].ToString();
                                }
                                using (StringWriter stringWriter26 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter26 = new HtmlTextWriter(stringWriter26))
                                    {
                                        str10.RenderControl(htmlTextWriter26);
                                        str8.RenderControl(htmlTextWriter26);
                                        str9.RenderControl(htmlTextWriter26);
                                    }
                                }
                                DataTable dataTable11 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(item["PriceCatalogueID"].ToString()));
                                HiddenField hiddenField25 = new HiddenField()
                                {
                                    ID = string.Concat("hid_PriceCatelogueName", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                    Value = this.objBase.SpecialDecode(item["CatalogueName"].ToString().Trim())
                                };
                                using (StringWriter stringWriter27 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter27 = new HtmlTextWriter(stringWriter27))
                                    {
                                        hiddenField25.RenderControl(htmlTextWriter27);
                                    }
                                }
                                HiddenField hiddenField26 = new HiddenField()
                                {
                                    ID = string.Concat("hid_CostExcMarkupList", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField27 = new HiddenField()
                                {
                                    ID = string.Concat("hid_priceList", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField28 = new HiddenField()
                                {
                                    ID = string.Concat("hid_MarkupList", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow dataRow7 in dataTable11.Rows)
                                {
                                    hiddenField26.Value = string.Concat(hiddenField26.Value, dataRow7["Price"].ToString(), "µ");
                                    hiddenField27.Value = string.Concat(hiddenField27.Value, dataRow7["SellingPrice"].ToString(), "µ");
                                    hiddenField28.Value = string.Concat(hiddenField28.Value, dataRow7["Markup"].ToString(), "µ");
                                }
                                using (StringWriter stringWriter28 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter28 = new HtmlTextWriter(stringWriter28))
                                    {
                                        hiddenField26.RenderControl(htmlTextWriter28);
                                        hiddenField27.RenderControl(htmlTextWriter28);
                                        hiddenField28.RenderControl(htmlTextWriter28);
                                    }
                                }
                                HiddenField hiddenField29 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_ProductStockManagement", this.CopyPriceCatalogueID)
                                };
                                HiddenField str11 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_AvailableQuantity", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable12 = ProductBasePage.productsDetails_Select(Convert.ToInt32(item["pricecatalogueid"].ToString()));
                                foreach (DataRow row8 in dataTable12.Rows)
                                {
                                    if (Convert.ToBoolean(row8["ProductStockManagement"].ToString()))
                                    {
                                        hiddenField29.Value = "true";
                                    }
                                    if (int.Parse(row8["AvailableQuantity"].ToString()) == 0 || row8["AvailableQuantity"].ToString().Trim().Length <= 0)
                                    {
                                        str11.Value = "0";
                                    }
                                    else
                                    {
                                        str11.Value = row8["AvailableQuantity"].ToString();
                                    }
                                }
                                using (StringWriter stringWriter29 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter29 = new HtmlTextWriter(stringWriter29))
                                    {
                                        hiddenField29.RenderControl(htmlTextWriter29);
                                        str11.RenderControl(htmlTextWriter29);
                                    }
                                }
                                HiddenField hiddenField30 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_qtyFromList", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField31 = new HiddenField()
                                {
                                    ID = string.Concat("hid_qtyToList", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField lower1 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_IsCumulative_", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                HiddenField hiddenField32 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_MainProductID", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                    Value = this.CopyPriceCatalogueID.ToString()
                                };
                                HiddenField lower2 = new HiddenField()
                                {
                                    ID = string.Concat("hdn_SoldInPacks_", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                foreach (DataRow dataRow8 in dataTable11.Rows)
                                {
                                    HiddenField hiddenField33 = hiddenField30;
                                    hiddenField33.Value = string.Concat(hiddenField33.Value, dataRow8["FromQuantity"].ToString(), "µ");
                                    HiddenField hiddenField34 = hiddenField31;
                                    hiddenField34.Value = string.Concat(hiddenField34.Value, dataRow8["ToQuantity"].ToString(), "µ");
                                    lower1.Value = dataRow8["IsCumulativePricing"].ToString().ToLower();
                                    lower2.Value = dataRow8["IsCumulativePricing"].ToString().ToLower();
                                }
                                using (StringWriter stringWriter30 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter30 = new HtmlTextWriter(stringWriter30))
                                    {
                                        hiddenField30.RenderControl(htmlTextWriter30);
                                        hiddenField31.RenderControl(htmlTextWriter30);
                                        lower1.RenderControl(htmlTextWriter30);
                                        hiddenField32.RenderControl(htmlTextWriter30);
                                        lower2.RenderControl(htmlTextWriter30);
                                    }
                                }
                                stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", item["ProductStockManagement"].ToString().ToLower(), "' />"));
                                str = new object[] { "<input type='hidden' id='hdnisstockitem", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", item["IsStockItem"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<input type='hidden' id='hdndrawstockfrom", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", item["DrawStockFrom"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<input type='hidden' id='hdnisbackorder", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", item["IsBackOrder"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<input type='hidden' id='hdnavailableqty", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", item["AvailableQuantity"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(str));
                                Label label2 = new Label()
                                {
                                    ID = string.Concat("lbl_priceStartsFrom", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                };
                                if (Convert.ToBoolean(item["IsPriceStartFrom"]))
                                {
                                    short num2 = 1;
                                    foreach (DataRow row9 in dataTable11.Rows)
                                    {
                                        if (num2 == 1)
                                        {
                                            label2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row9["SellingPrice"].ToString()), 2, "", false, false, true));
                                        }
                                        num2 = (short)(num2 + 1);
                                    }
                                    label2.CssClass = "priceStartsFromInQuickAdd";
                                }
                                using (StringWriter stringWriter31 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter31 = new HtmlTextWriter(stringWriter31))
                                    {
                                        label2.RenderControl(htmlTextWriter31);
                                    }
                                }
                                stringBuilder.Append("</div>");
                                HiddenField hiddenField35 = new HiddenField()
                                {
                                    ID = string.Concat("hdnPriceCatalogueIds", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                    Value = string.Concat(item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                };
                                DataTable dataTable13 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, CompanyID);
                                foreach (DataRow dataRow9 in dataTable13.Rows)
                                {
                                    str = new object[] { hiddenField35.Value, ",", dataRow9["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
                                    hiddenField35.Value = string.Concat(str);
                                }
                                using (StringWriter stringWriter32 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter32 = new HtmlTextWriter(stringWriter32))
                                    {
                                        hiddenField35.RenderControl(htmlTextWriter32);
                                    }
                                }
                                stringBuilder.Append("<div style='padding-left: 35px;' >");
                                DropDownList dropDownList2 = new DropDownList()
                                {
                                    CssClass = "ddlPriceQtyQuickAdd",
                                    Width = 150,
                                    Height = 22,
                                    ID = string.Concat("ddlOtherMultiplrDrp", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                };
                                dropDownList2.CssClass = "dropDownMultipleQuickAdd";
                                AttributeCollection attributeCollection4 = dropDownList2.Attributes;
                                str = new object[] { "javascript:ChnageProduct('", item["PriceCatalogueID"].ToString(), "_", this.CopyPriceCatalogueID, "');" };
                                attributeCollection4.Add("onchange", string.Concat(str));
                                dropDownList2.Attributes.Add("style", "margin-bottom:10px;");
                                dropDownList2.EnableViewState = true;
                                dropDownList2.AutoPostBack = true;
                                this.BindOtherMultipleDropdownList(dataTable13, dropDownList2);
                                if (this.NoProductSelected == "true")
                                {
                                    dropDownList2.Items.Insert(0, "--Select--");
                                }
                                DataTable dataTable14 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.CopyPriceCatalogueID);
                                if (dataTable14.Rows.Count > 0 && dataTable14.Rows[0]["KitItemID"] != null)
                                {
                                    this.objBase.SetDDLValue(dropDownList2, dataTable14.Rows[0]["KitItemID"].ToString());
                                }
                                using (StringWriter stringWriter33 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter33 = new HtmlTextWriter(stringWriter33))
                                    {
                                        dropDownList2.RenderControl(htmlTextWriter33);
                                    }
                                }
                                stringBuilder.Append("</div>");
                                if (item["MatrixType"].ToString().ToLower() == "p")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;' >");
                                    TextBox textBox10 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox10.Attributes.Add("onblur", string.Concat("javascript:quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'p');"));
                                    using (StringWriter stringWriter34 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter34 = new HtmlTextWriter(stringWriter34))
                                        {
                                            textBox10.RenderControl(htmlTextWriter34);
                                        }
                                    }
                                }
                                if (item["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='padding-left: 35px;height: 25px;' >");
                                    TextBox textBox11 = new TextBox()
                                    {
                                        ID = string.Concat("txtPriceBandQty", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox11.Attributes.Add("value", "Qty");
                                    textBox11.Style.Add("color", "gray");
                                    textBox11.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox11.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'g');"));
                                    textBox11.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox11.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter35 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter35 = new HtmlTextWriter(stringWriter35))
                                        {
                                            textBox11.RenderControl(htmlTextWriter35);
                                        }
                                    }
                                }
                                if (item["MatrixType"].ToString().ToLower() == "s")
                                {
                                    if (!Convert.ToBoolean(lower1.Value))
                                    {
                                        stringBuilder.Append("<div style='padding-left: 35px;'>");
                                        DropDownList languageConversion1 = new DropDownList()
                                        {
                                            CssClass = "ddlPriceQtyQuickAdd",
                                            ID = string.Concat("ddlPriceQty", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        languageConversion1.CssClass = "dropDownMultipleQuickAdd";
                                        languageConversion1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                        languageConversion1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'s');"));
                                        this.SimpleMatrix_DropDownBind(dataTable11, languageConversion1);
                                        using (StringWriter stringWriter36 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter36 = new HtmlTextWriter(stringWriter36))
                                            {
                                                languageConversion1.RenderControl(htmlTextWriter36);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stringBuilder.Append("<div style='padding-left: 35px;' >");
                                        TextBox textBox12 = new TextBox()
                                        {
                                            ID = string.Concat("txt_Cumulative_PriceQty", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                        };
                                        textBox12.Attributes.Add("value", "Qty");
                                        textBox12.Style.Add("color", "gray");
                                        textBox12.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                        textBox12.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'s');"));
                                        textBox12.Attributes.Add("onClick", "this.style.color = '';");
                                        textBox12.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                        using (StringWriter stringWriter37 = new StringWriter(stringBuilder))
                                        {
                                            using (HtmlTextWriter htmlTextWriter37 = new HtmlTextWriter(stringWriter37))
                                            {
                                                textBox12.RenderControl(htmlTextWriter37);
                                            }
                                        }
                                    }
                                }
                                str = new object[] { "<div id='divcartqty", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (item["IsStockItem"].ToString().ToLower() == "true")
                                {
                                    str = new object[] { "<img onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\")}'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                else
                                {
                                    str = new object[] { "<img onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\")'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                    stringBuilder.Append(string.Concat(str));
                                }
                                str = new object[] { "<img id='btnQucikAddCartLoading", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                stringBuilder.Append(string.Concat(str));
                                str = new object[] { "<span id='btnQucikAddCartoutofstock", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                str = new object[] { "<div id='divcartWidthHeight", item["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'style='padding-left:35px;clear:both;'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("</div>");
                                if (item["MatrixType"].ToString().ToLower() == "g")
                                {
                                    stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                    TextBox textBox13 = new TextBox()
                                    {
                                        ID = string.Concat("txtWidth", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                    };
                                    textBox13.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                    textBox13.Style.Add("color", "gray");
                                    textBox13.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributes5 = textBox13.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                    attributes5.Add("onBlur", string.Concat(str));
                                    textBox13.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter38 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter38 = new HtmlTextWriter(stringWriter38))
                                        {
                                            textBox13.RenderControl(htmlTextWriter38);
                                        }
                                    }
                                    TextBox textBox14 = new TextBox()
                                    {
                                        ID = string.Concat("txtHeight", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                    };
                                    textBox14.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                    textBox14.Style.Add("color", "gray");
                                    textBox14.Style.Add("margin-left", "8px");
                                    textBox14.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                    AttributeCollection attributeCollection5 = textBox14.Attributes;
                                    str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                    attributeCollection5.Add("onBlur", string.Concat(str));
                                    textBox14.Attributes.Add("onClick", "this.style.color = '';");
                                    using (StringWriter stringWriter39 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter39 = new HtmlTextWriter(stringWriter39))
                                        {
                                            textBox14.RenderControl(htmlTextWriter39);
                                        }
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                stringBuilder.Append("</div>");
                            }
                        }
                        else if (Convert.ToBoolean(item["isQuickItem"]))
                        {
                            strArrays = new string[] { "<div  onmouseover='mouseovershow(", item["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", item["pricecatalogueid"].ToString(), "'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            HiddenField str12 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxName", item["pricecatalogueid"].ToString())
                            };
                            HiddenField str13 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxRate", item["pricecatalogueid"].ToString())
                            };
                            HiddenField str14 = new HiddenField()
                            {
                                ID = string.Concat("hid_TaxID", item["pricecatalogueid"].ToString())
                            };
                            foreach (DataRow row10 in ProductBasePage.GetTaxDetails(CompanyID, this.StoreUserID).Rows)
                            {
                                str14.Value = row10["TaxID"].ToString();
                                str12.Value = row10["TaxName"].ToString();
                                str13.Value = row10["TaxRate"].ToString();
                            }
                            using (StringWriter stringWriter40 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter40 = new HtmlTextWriter(stringWriter40))
                                {
                                    str14.RenderControl(htmlTextWriter40);
                                    str12.RenderControl(htmlTextWriter40);
                                    str13.RenderControl(htmlTextWriter40);
                                }
                            }
                            DataTable dataTable15 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(item["PriceCatalogueID"].ToString()));
                            HiddenField hiddenField36 = new HiddenField()
                            {
                                ID = string.Concat("hid_PriceCatelogueName", item["pricecatalogueid"].ToString()),
                                Value = this.objBase.SpecialDecode(item["CatalogueName"].ToString().Trim())
                            };
                            using (StringWriter stringWriter41 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter41 = new HtmlTextWriter(stringWriter41))
                                {
                                    hiddenField36.RenderControl(htmlTextWriter41);
                                }
                            }
                            HiddenField hiddenField37 = new HiddenField()
                            {
                                ID = string.Concat("hid_CostExcMarkupList", item["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField38 = new HiddenField()
                            {
                                ID = string.Concat("hid_priceList", item["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField39 = new HiddenField()
                            {
                                ID = string.Concat("hid_MarkupList", item["pricecatalogueid"].ToString())
                            };
                            foreach (DataRow dataRow10 in dataTable15.Rows)
                            {
                                hiddenField37.Value = string.Concat(hiddenField37.Value, dataRow10["Price"].ToString(), "µ");
                                hiddenField38.Value = string.Concat(hiddenField38.Value, dataRow10["SellingPrice"].ToString(), "µ");
                                hiddenField39.Value = string.Concat(hiddenField39.Value, dataRow10["Markup"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter42 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter42 = new HtmlTextWriter(stringWriter42))
                                {
                                    hiddenField37.RenderControl(htmlTextWriter42);
                                    hiddenField38.RenderControl(htmlTextWriter42);
                                    hiddenField39.RenderControl(htmlTextWriter42);
                                }
                            }
                            HiddenField hiddenField40 = new HiddenField()
                            {
                                ID = "hdn_ProductStockManagement"
                            };
                            HiddenField str15 = new HiddenField()
                            {
                                ID = string.Concat("hdn_AvailableQuantity", item["pricecatalogueid"].ToString())
                            };
                            DataTable dataTable16 = ProductBasePage.productsDetails_Select(Convert.ToInt32(item["pricecatalogueid"].ToString()));
                            foreach (DataRow row11 in dataTable16.Rows)
                            {
                                if (Convert.ToBoolean(row11["ProductStockManagement"].ToString()))
                                {
                                    hiddenField40.Value = "true";
                                }
                                if (int.Parse(row11["AvailableQuantity"].ToString()) == 0 || row11["AvailableQuantity"].ToString().Trim().Length <= 0)
                                {
                                    str15.Value = "0";
                                }
                                else
                                {
                                    str15.Value = row11["AvailableQuantity"].ToString();
                                }
                            }
                            using (StringWriter stringWriter43 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter43 = new HtmlTextWriter(stringWriter43))
                                {
                                    hiddenField40.RenderControl(htmlTextWriter43);
                                    str15.RenderControl(htmlTextWriter43);
                                }
                            }
                            HiddenField hiddenField41 = new HiddenField()
                            {
                                ID = string.Concat("hdn_qtyFromList", item["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField42 = new HiddenField()
                            {
                                ID = string.Concat("hid_qtyToList", item["pricecatalogueid"].ToString())
                            };
                            HiddenField hiddenField43 = new HiddenField()
                            {
                                ID = string.Concat("hdn_IsCumulative_", item["pricecatalogueid"].ToString()),
                                Value = item["IsCumulativePricing"].ToString().ToLower()
                            };
                            HiddenField hiddenField44 = new HiddenField();
                            hiddenField43.ID = string.Concat("hdn_IsCumulative_", item["pricecatalogueid"].ToString());
                            hiddenField44.ID = string.Concat("hdn_MainProductID", item["pricecatalogueid"].ToString());
                            hiddenField44.Value = "0";
                            foreach (DataRow dataRow11 in dataTable15.Rows)
                            {
                                HiddenField hiddenField45 = hiddenField41;
                                hiddenField45.Value = string.Concat(hiddenField45.Value, dataRow11["FromQuantity"].ToString(), "µ");
                                HiddenField hiddenField46 = hiddenField42;
                                hiddenField46.Value = string.Concat(hiddenField46.Value, dataRow11["ToQuantity"].ToString(), "µ");
                            }
                            using (StringWriter stringWriter44 = new StringWriter(stringBuilder))
                            {
                                using (HtmlTextWriter htmlTextWriter44 = new HtmlTextWriter(stringWriter44))
                                {
                                    hiddenField41.RenderControl(htmlTextWriter44);
                                    hiddenField42.RenderControl(htmlTextWriter44);
                                    hiddenField43.RenderControl(htmlTextWriter44);
                                    hiddenField44.RenderControl(htmlTextWriter44);
                                }
                            }
                            stringBuilder.Append(string.Concat("<div onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                            stringBuilder.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", item["ProductStockManagement"].ToString().ToLower(), "' />"));
                            strArrays = new string[] { "<input type='hidden' id='hdnisstockitem", item["pricecatalogueid"].ToString(), "' value='", item["IsStockItem"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdndrawstockfrom", item["pricecatalogueid"].ToString(), "' value='", item["DrawStockFrom"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdnisbackorder", item["pricecatalogueid"].ToString(), "' value='", item["IsBackOrder"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<input type='hidden' id='hdnavailableqty", item["pricecatalogueid"].ToString(), "' value='", item["AvailableQuantity"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(strArrays));
                            if (Convert.ToBoolean(item["IsPriceStartFrom"]))
                            {
                                Label label3 = new Label();
                                short num3 = 1;
                                foreach (DataRow row12 in dataTable15.Rows)
                                {
                                    if (num3 == 1)
                                    {
                                        label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row12["SellingPrice"].ToString()), 2, "", false, false, true));
                                    }
                                    num3 = (short)(num3 + 1);
                                }
                                label3.CssClass = "priceStartsFromInQuickAdd";
                                using (StringWriter stringWriter45 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter45 = new HtmlTextWriter(stringWriter45))
                                    {
                                        label3.RenderControl(htmlTextWriter45);
                                    }
                                }
                            }
                            stringBuilder.Append("</div>");
                            if (item["MatrixType"].ToString().ToLower() == "p")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;' >");
                                TextBox textBox15 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", item["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox15.Attributes.Add("onblur", string.Concat("javascript:quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'p');"));
                                using (StringWriter stringWriter46 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter46 = new HtmlTextWriter(stringWriter46))
                                    {
                                        textBox15.RenderControl(htmlTextWriter46);
                                    }
                                }
                            }
                            if (item["MatrixType"].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='padding-left: 60px;height: 25px;' >");
                                TextBox textBox16 = new TextBox()
                                {
                                    ID = string.Concat("txtPriceBandQty", item["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                };
                                textBox16.Attributes.Add("value", "Qty");
                                textBox16.Style.Add("color", "gray");
                                textBox16.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                textBox16.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'g');"));
                                textBox16.Attributes.Add("onClick", "this.style.color = '';");
                                textBox16.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                using (StringWriter stringWriter47 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter47 = new HtmlTextWriter(stringWriter47))
                                    {
                                        textBox16.RenderControl(htmlTextWriter47);
                                    }
                                }
                            }
                            if (item["MatrixType"].ToString().ToLower() == "s")
                            {
                                if (!Convert.ToBoolean(hiddenField43.Value))
                                {
                                    stringBuilder.Append("<div style='padding-left: 50px;' >");
                                    DropDownList languageConversion2 = new DropDownList()
                                    {
                                        CssClass = "ddlPriceQtyQuickAdd",
                                        ID = string.Concat("ddlPriceQty", item["PriceCatalogueID"].ToString())
                                    };
                                    languageConversion2.CssClass = "dropDownMultipleQuickAdd";
                                    languageConversion2.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                    languageConversion2.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'s');"));
                                    this.SimpleMatrix_DropDownBind(dataTable15, languageConversion2);
                                    using (StringWriter stringWriter48 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter48 = new HtmlTextWriter(stringWriter48))
                                        {
                                            languageConversion2.RenderControl(htmlTextWriter48);
                                        }
                                    }
                                }
                                else
                                {
                                    stringBuilder.Append("<div style='padding-left: 60px;' >");
                                    TextBox textBox17 = new TextBox()
                                    {
                                        ID = string.Concat("txt_Cumulative_PriceQty", item["PriceCatalogueID"].ToString()),
                                        CssClass = "txtStyleQuickAdd",
                                        ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                    };
                                    textBox17.Attributes.Add("value", "Qty");
                                    textBox17.Style.Add("color", "gray");
                                    textBox17.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                    textBox17.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'s');"));
                                    textBox17.Attributes.Add("onClick", "this.style.color = '';");
                                    textBox17.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                    using (StringWriter stringWriter49 = new StringWriter(stringBuilder))
                                    {
                                        using (HtmlTextWriter htmlTextWriter49 = new HtmlTextWriter(stringWriter49))
                                        {
                                            textBox17.RenderControl(htmlTextWriter49);
                                        }
                                    }
                                }
                            }
                            if (item["IsStockItem"].ToString().ToLower() == "true")
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", item["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", item["pricecatalogueid"].ToString(), ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", item["pricecatalogueid"].ToString(), ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\",", item["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            else
                            {
                                strArrays = new string[] { "<img onmouseout='mouseOutHidediv(", item["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", item["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", item["pricecatalogueid"].ToString(), ",\"", item["MatrixType"].ToString().ToLower().Trim(), "\",", item["pricecatalogueid"].ToString(), ")'  class='basketbtnQuickAdd' src='images/StoreImages/empty_cart_icon.gif'>" };
                                stringBuilder.Append(string.Concat(strArrays));
                            }
                            strArrays = new string[] { "<img id='btnQucikAddCartLoading", item["PriceCatalogueID"].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "<span id='btnQucikAddCartoutofstock", item["PriceCatalogueID"].ToString(), "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("</div>");
                            if (item["MatrixType"].ToString().ToLower() == "g")
                            {
                                stringBuilder.Append("<div style='clear:both;'></div><div style='padding-left: 60px;padding-top:5px;'>");
                                TextBox textBox18 = new TextBox()
                                {
                                    ID = string.Concat("txtWidth", item["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                };
                                textBox18.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                textBox18.Style.Add("color", "gray");
                                textBox18.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributes6 = textBox18.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'g');" };
                                attributes6.Add("onBlur", string.Concat(str));
                                textBox18.Attributes.Add("onClick", "this.style.color = '';");
                                using (StringWriter stringWriter50 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter50 = new HtmlTextWriter(stringWriter50))
                                    {
                                        textBox18.RenderControl(htmlTextWriter50);
                                    }
                                }
                                TextBox textBox19 = new TextBox()
                                {
                                    ID = string.Concat("txtHeight", item["PriceCatalogueID"].ToString()),
                                    CssClass = "txtStyleQuickAdd",
                                    ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_height")
                                };
                                textBox19.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Height"));
                                textBox19.Style.Add("color", "gray");
                                textBox19.Style.Add("margin-left", "8px");
                                textBox19.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Height"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                AttributeCollection attributeCollection6 = textBox19.Attributes;
                                str = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", item["PriceCatalogueID"].ToString(), ",'g');" };
                                attributeCollection6.Add("onBlur", string.Concat(str));
                                textBox19.Attributes.Add("onClick", "this.style.color = '';");
                                using (StringWriter stringWriter51 = new StringWriter(stringBuilder))
                                {
                                    using (HtmlTextWriter htmlTextWriter51 = new HtmlTextWriter(stringWriter51))
                                    {
                                        textBox19.RenderControl(htmlTextWriter51);
                                    }
                                }
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("</div>");
                        }
                        stringBuilder.Append("</div></div>");
                        stringBuilder.Append("</div>");
                        if (this.arrayLength >= dataTable.Rows.Count - 1)
                        {
                            break;
                        }
                        this.arrayLength = this.arrayLength + 1;
                    }
                    this.plh_NewProductsDetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                }
                if (!this.Page.IsPostBack)
                {
                    HtmlImage htmlImage = this.imgSucess;
                    str = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&amp;aid=", AccountID, " &amp;cid=", CompanyID };
                    htmlImage.Src = string.Concat(str);
                    this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
                }
                this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
                this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
            }
            if (!this.Page.IsPostBack)
            {
                HtmlImage htmlImage1 = this.imgSucess;
                str = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&amp;aid=", AccountID, " &amp;cid=", CompanyID };
                htmlImage1.Src = string.Concat(str);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
            }
            this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
            this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
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
            foreach (DataRow row in ProductBasePage.productsCategoryList_Select((long)CompanyID, AccountID, this.StoreUserID).Rows)
            {
                string empty = string.Empty;
                empty = (row["PriceCatalogueCategoryName"].ToString().Trim().Length <= 20 ? row["PriceCatalogueCategoryName"].ToString().Trim() : string.Concat(row["PriceCatalogueCategoryName"].ToString().Trim().Substring(0, 20), "..."));
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    string[] str = new string[] { "<div class='catagoryLists'> &nbsp; &rsaquo; <a href='", Default.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "'>", empty, "<br/></a></div>" };
                    stringBuilder.Append(string.Concat(str));
                }
                else
                {
                    string[] strArrays = new string[] { "<div class='catagoryLists'> &nbsp; &rsaquo; <a href='", null, null, null, null };
                    string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, row["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                    strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                    strArrays[2] = "'>";
                    strArrays[3] = empty;
                    strArrays[4] = "<br/></a></div>";
                    stringBuilder.Append(string.Concat(strArrays));
                }
                Default cntGetProductCatagories = this;
                cntGetProductCatagories.cnt_getProductCatagories = cntGetProductCatagories.cnt_getProductCatagories + 1;
            }
            if (this.isProductCategory != "1")
            {
                this.div_ProductsDetailsList.Style.Add("display", "none");
                this.radCategoryTree.Visible = false;
                return;
            }
            if (this.cnt_getProductCatagories != 0)
            {
                this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                return;
            }
            this.plh_ProductsDetailsList.Controls.Add(new LiteralControl(string.Concat("<div id='noCategoriesFound'><strong> ", this.objLanguage.GetLanguageConversion("No_Record_Found"), "</strong></div>")));
            this.div_ProductsDetailsList.Style.Add("display", "none");
            this.radCategoryTree.Visible = false;
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
                    object[] accountID = new object[] { Default.strBannerPath, "store\\", AccountID, "\\banners\\", row["bannerImage"] };
                    empty = string.Concat(accountID);
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
                        object[] height = new object[] { "<li height='", bitmap.Height, "'><img src='", str, "' alt='", row["bannerTitle"], "' class='BorderWhite floatLeft' /></li>" };
                        controls.Add(new LiteralControl(string.Concat(height)));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.plh_imageBanner.Controls;
                        object[] objArray = new object[] { "<li height='100'><a href='", row["URL"], "'><img src='", str, "' alt='", row["bannerTitle"], "' class='BorderWhite floatLeft' /></a></li>" };
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

        private void LoadRootNodes(int CompanyID, long AccountID, int Categoryid)
        {
            this.radCategoryTree.Nodes.Clear();
            foreach (DataRow row in ProductBasePage.BindTreeView(CompanyID, AccountID, Categoryid, this.StoreUserID).Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                empty = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                str = row["categoryProductCnt"].ToString().Trim();
                row["SubCatCount"].ToString().Trim();
                RadTreeNode radTreeNode = new RadTreeNode()
                {
                    ImageUrl = string.Concat(Default.imagePath, "close_folder.png")
                };
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (empty.ToString().Length <= 17)
                    {
                        radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
                        radTreeNode.ToolTip = empty;
                    }
                    else
                    {
                        radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 17), "...&nbsp;(", str, ")");
                        radTreeNode.ToolTip = empty;
                    }
                }
                else if (empty.ToString().Length <= 17)
                {
                    radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
                    radTreeNode.ToolTip = empty;
                }
                else
                {
                    radTreeNode.Text = string.Concat(empty.Trim().Substring(0, 17), "...&nbsp;(", str, ")");
                    radTreeNode.ToolTip = empty;
                }
                radTreeNode.Value = ((int)row["PriceCatalogueCategoryID"]).ToString();
                radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                this.radCategoryTree.Nodes.Add(radTreeNode);
                if ((int)row["SubCatCount"] <= 0)
                {
                    radTreeNode.ExpandMode = TreeNodeExpandMode.ClientSide;
                }
                else
                {
                    radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='TextUnderline' href ='", BaseClass.SitePath, "Default.aspx'>", this.objLanguage.GetLanguageConversion("Product_List"), "</a><span Class='fontsize13px'>&nbsp;&nbsp;&nbsp;</span></span>" };
            label.Text = string.Concat(sitePath);
            Default.strBannerPath = ConnectionClass.ImageHandlerPath;
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
            }
            if (ConnectionClass.EnableDescription != null)
            {
                this.EnableDescription = ConnectionClass.EnableDescription;
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(Default.CompanyID);
            if (this.comm.GetDisplayValue("isProductCategory", Default.AccountID) != "false")
            {
                this.displayverticalsep = "table-cell";
            }
            else
            {
                this.isProductCategory = "0";
                this.displayverticalsep = "none";
            }
            if (this.comm.GetDisplayValue("isHomeRightBanner", Default.AccountID) == "false")
            {
                this.isHomeRightBanner = "0";
            }
            if (this.Session["StoreUserID"] == null && this.AccountType == "p" || Default.AccountID == (long)0 && Default.CompanyID == 0)
            {
                base.Response.Redirect("login.aspx");
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            }
            this.isRightBanner = this.comm.GetIsRightBanner(Default.CompanyID, Default.AccountID);
            base.Title = commonclass.pageTitle("Home", Convert.ToInt32(Default.CompanyID), Convert.ToInt32(Default.AccountID));
            this.getProductCatagories(Default.CompanyID, Default.AccountID);
            int num = 0;
            foreach (DataRow row in CMSBasePage.Select_BannerImages(Default.AccountID, 0, "L", "Home").Rows)
            {
                if (num == 0)
                {
                    this.plhLeftBanner.Controls.Add(new LiteralControl("<div class='right_div_left margin1'>"));
                }
                object[] item = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", row["bannerImage"], "&amp;type=b&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                string str = string.Concat(item);
                if (row["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhLeftBanner.Controls;
                    object[] objArray = new object[] { "<div ><img src='", str, "' class='imgWidth BorderWhite' alt='", row["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhLeftBanner.Controls;
                    object[] item1 = new object[] { "<div><a href='", row["URL"], "'><img src='", str, "' class='imgWidth BorderWhite' alt='", row["bannerTitle"], "' /></a></div>" };
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
                this.displayverticalsep = "table-cell";
            }
            if (this.isHomeRightBanner == "1")
            {
                int num1 = 0;
                foreach (DataRow dataRow in CMSBasePage.Select_BannerImages(Default.AccountID, 0, "R", "Home").Rows)
                {
                    if (num1 == 0)
                    {
                        this.plhRightBanner.Controls.Add(new LiteralControl("<div class='right_div_left margin2'>"));
                    }
                    object[] objArray1 = new object[] { Default.strSitePath, "ImageHandler.ashx?Imagename=", dataRow["bannerImage"], "&amp;type=b&amp;aid=", Default.AccountID, "&amp;cid=", Default.CompanyID };
                    string str1 = string.Concat(objArray1);
                    if (dataRow["URL"].ToString() == "")
                    {
                        ControlCollection controls1 = this.plhRightBanner.Controls;
                        object[] item2 = new object[] { "<div><img src='", str1, "' class='imgWidth BorderWhite' alt='", dataRow["bannerTitle"], "' /></div>" };
                        controls1.Add(new LiteralControl(string.Concat(item2)));
                    }
                    else
                    {
                        ControlCollection controlCollections1 = this.plhRightBanner.Controls;
                        object[] objArray2 = new object[] { "<div><a href='", dataRow["URL"], "'><img src='", str1, "' class='imgWidth BorderWhite' alt='", dataRow["bannerTitle"], "' /></a></div>" };
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
            if (Templates_Sample.AccountType.ToLower() != "p")
            {
                if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 5;
                }
                if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories != 0)
                {
                    this.centerDivWidth = 4;
                }
                if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 4;
                }
                if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories != 0)
                {
                    this.centerDivWidth = 4;
                }
                if (this.cnt_right != 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 4;
                }
            }
            else
            {
                this.centerDivWidth = 5;
                if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 7;
                }
                if (this.cnt_right == 0 && this.cnt_left == 0 && this.cnt_getProductCatagories != 0)
                {
                    this.centerDivWidth = 6;
                }
                if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 6;
                }
                if (this.cnt_right == 0 && this.cnt_left != 0 && this.cnt_getProductCatagories != 0)
                {
                    this.centerDivWidth = 6;
                }
                if (this.cnt_right != 0 && this.cnt_left == 0 && this.cnt_getProductCatagories == 0)
                {
                    this.centerDivWidth = 6;
                }
            }
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
                        this.div_slidder.Style.Add("display", "none");
                    }
                    else
                    {
                        this.div_slidder.Style.Add("display", "none");
                    }
                }
                this.lbl_centerPaneltext.Text = row1["CenterPanelText"].ToString();
                if (row1["CenterPanelOption"].ToString().ToLower() == "featured")
                {
                    this.centrepaneltype = "featured";
                    this.getNewProducts(Default.CompanyID, Default.AccountID, "featured");
                    this.div_NewProducts.Style.Add("display", "block");
                    this.div_Customize.Style.Add("display", "none");
                    this.div_Customize_new.Style.Add("display", "none");
                    this.div_FeatureProducts.Style.Add("display", "block");
                    this.divCustomTex.Style.Add("display", "block");
                }
                else if (row1["CenterPanelOption"].ToString().ToLower() == "new")
                {
                    this.centrepaneltype = "new";
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
                    this.centrepaneltype = "custom";
                    this.getCutomProductsNew(Default.CompanyID, Default.AccountID, "custom");
                    this.div_NewProducts.Style.Add("display", "none");
                    this.div_Customize.Style.Add("display", "none");
                    this.div_headerCustomer.Style.Add("display", "block");
                    this.div_Customize_new.Style.Add("display", "block");
                }
                else
                {
                    this.centrepaneltype = "html";
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
            if (!this.Page.IsPostBack)
            {
                if (this.Session["treeViewState"] == null)
                {
                    this.LoadRootNodes(Default.CompanyID, Default.AccountID, 0);
                    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
                    return;
                }
                string str2 = (string)this.Session["treeViewState"];
                this.radCategoryTree.LoadXmlString(str2);
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            this.Session["treeViewState"] = this.radCategoryTree.GetXml();
        }

        protected void radCategoryTree_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            string item = (string)this.Session["treeViewState"];
            this.radCategoryTree.LoadXmlString(item);
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                HttpResponse response = base.Response;
                string[] keySeparator = new string[] { Default.strSitePath, "products", ConnectionClass.KeySeparator, e.Node.Value.ToString(), ConnectionClass.FileExtension };
                response.Redirect(base.ResolveUrl(string.Concat(keySeparator)));
                return;
            }
            RadTreeNode radTreeNode = this.radCategoryTree.FindNodeByValue(e.Node.Value);
            if (radTreeNode != null)
            {
                radTreeNode.Selected = true;
            }
            this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            base.Response.Redirect(string.Concat(Default.strSitePath, "products/product.aspx?ID=", e.Node.Value.ToString()));
        }

        protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
        {
            Convert.ToInt32(e.Node.Value);
            this.AddChildNodes(Default.CompanyID, Default.AccountID, e.Node);
            string item = (string)this.Session["treeViewState"];
            RadTreeView radTreeView = new RadTreeView();
            radTreeView.LoadXmlString(item);
            RadTreeNode radTreeNode = radTreeView.FindNodeByValue(e.Node.Value);
            this.AddChildNodes(Default.CompanyID, Default.AccountID, radTreeNode);
            radTreeNode.Expanded = true;
            this.Session["treeViewState"] = radTreeView.GetXml();
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