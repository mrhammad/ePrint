using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CMS;
using Printcenter.UI.Products;
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
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class product : System.Web.UI.Page, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected PlaceHolder plh_ProductsDetailsList;

        //protected RadTreeView radCategoryTree;

        //protected HtmlGenericControl div_ProductsDetailsList;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected Button btnQuickNotificationOk;

        //protected Button btnGotoCart;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected HtmlGenericControl spn_headding;

        //protected PlaceHolder plh_ProductsDetails;

        //protected PlaceHolder plhRightBanner;

        public string strImagepath = BaseClass.SitePath;

        private commonclass comm = new commonclass();

        private MemoryStream stream = new MemoryStream();

        public languageClass objLanguage = new languageClass();

        public BaseClass objBase = new BaseClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public char KeySeparator;

        public string finalimageName1 = string.Empty;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string AccountType = "p";

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

        public int productNameLength = 38;

        public int productDescriptionLength = 80;

        public int cnt_getProductCatagories;

        public ArrayList productName = new ArrayList();

        public ArrayList PriceCatalogueCategoryName = new ArrayList();

        public ArrayList productImage = new ArrayList();

        public ArrayList productDescription = new ArrayList();

        public ArrayList PriceCategoryID = new ArrayList();

        public ArrayList Pricetype = new ArrayList();

        public ArrayList PriceCatalogueCategoryID = new ArrayList();

        public ArrayList IsShortDescription = new ArrayList();

        public static long StoreUserID;

        public string strSitepath = string.Empty;

        private int RoundOff;

        public string ProdCategoryID = string.Empty;

        public string ProductSitePath = string.Empty;

        public int strMainCount;

        public int PriceCatalogueID;

        public int CopyPriceCatalogueID;

        private string Description = string.Empty;

        private bool Is_ShortDescription1;

        private string CatalogueName = string.Empty;

        private string ProductImage = string.Empty;

        public string IsEnableHidePrice = string.Empty;

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

        private void AddChildNodes(int CompanyID, long AccountID, RadTreeNode node)
        {
            DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Convert.ToInt32(node.Value), product.StoreUserID);
            node.Nodes.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                str = row["categoryProductCnt"].ToString().Trim();
                empty1 = row["SubCatCount"].ToString().Trim();
                RadTreeNode radTreeNode = new RadTreeNode()
                {
                    ImageUrl = string.Concat(product.imagePath, "close_folder.png")
                };
                if (Convert.ToInt32(empty1) != 0)
                {
                    radTreeNode.Text = empty;
                }
                else
                {
                    radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
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

        public void BindTreeView(int CompanyID, long AccountID, int Categoryid, RadTreeNodeEventArgs e)
        {
            foreach (DataRow row in ProductBasePage.BindTreeView(CompanyID, AccountID, Categoryid, product.StoreUserID).Rows)
            {
                string empty = string.Empty;
                empty = string.Concat(this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim()), "&nbsp;(", row["categoryProductCnt"].ToString(), ")");
                RadTreeNode radTreeNode = new RadTreeNode();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    string[] str = new string[] { "<span class='folderImage width55px'>&nbsp;&nbsp;&nbsp;&nbsp;<a href='", product.strSitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"].ToString(), "'>", empty, "</a></span>" };
                    radTreeNode.Text = string.Concat(str);
                }
                else
                {
                    string[] strArrays = new string[] { "<span class='folderImage width55px'>&nbsp;&nbsp;&nbsp;&nbsp;<a href='", null, null, null, null };
                    string[] keySeparator = new string[] { product.strSitePath, "products", ConnectionClass.KeySeparator, row["PriceCatalogueCategoryID"].ToString(), ConnectionClass.FileExtension };
                    strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                    strArrays[2] = "'>";
                    strArrays[3] = empty;
                    strArrays[4] = "<br/></a></span>";
                    radTreeNode.Text = string.Concat(strArrays);
                }
                radTreeNode.Value = row["PriceCatalogueCategoryID"].ToString();
                radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                if (e == null)
                {
                    this.radCategoryTree.Nodes.Add(radTreeNode);
                }
                else
                {
                    e.Node.Nodes.Add(radTreeNode);
                }
            }
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
                    object[] objArray = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", this.objBase.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", this.objBase.SpecialDecode(empty), " </a>" };
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
                    object[] objArray1 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", this.objBase.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", this.objBase.SpecialDecode(empty), " </a>" };
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
                    object[] objArray2 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", this.objBase.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", this.objBase.SpecialDecode(empty), " </a>" };
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

        [WebMethod(EnableSession = true)]
        public static IList<Properties.GetQuantity> LoadQuantity(string ChangedProductID)
        {
            IList<Properties.GetQuantity> getQuantities;
            try
            {
                getQuantities = ProductBasePage.Product_CatalogueQty_SelectFor_OtherMultiple((long)Convert.ToInt16(ChangedProductID));
            }
            catch
            {
                getQuantities = null;
            }
            return getQuantities;
        }

        private void LoadRootNodes(int CompanyID, long AccountID, int Categoryid)
        {
            this.radCategoryTree.Nodes.Clear();
            DataTable dataTable = ProductBasePage.BindTreeView(CompanyID, AccountID, Categoryid, product.StoreUserID);
            this.Session["CheckNewEntry"] = dataTable.Rows.Count;
            int num = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                empty = this.objBase.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                str = row["categoryProductCnt"].ToString().Trim();
                empty1 = row["SubCatCount"].ToString().Trim();
                num = num + Convert.ToInt32(str);
                RadTreeNode radTreeNode = new RadTreeNode()
                {
                    ImageUrl = string.Concat(product.imagePath, "close_folder.png")
                };
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (Convert.ToInt32(empty1) != 0)
                    {
                        radTreeNode.Text = empty;
                    }
                    else
                    {
                        radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
                        radTreeNode.ToolTip = empty;
                    }
                }
                else if (Convert.ToInt32(empty1) != 0)
                {
                    radTreeNode.Text = empty;
                }
                else
                {
                    radTreeNode.Text = string.Concat(empty, "&nbsp;(", str, ")");
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
            this.Session["ProductsCount"] = num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IDisposable disposable;
            object[] item;
            char[] chrArray;
            string[] keySeparator;
            IEnumerator enumerator;
            string str = "";
            string str1 = "";
            string empty = string.Empty;
            if (ConnectionClass.EnableDescription != null)
            {
                empty = ConnectionClass.EnableDescription;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                product.productImagePath = ConnectionClass.ProductImagePath;
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
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select(product.AccountID, (long)this.CompanyID);
            if (dataTable.Rows.Count <= 0)
            {
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();
                }
            }
            this.RoundOff = ProductBasePage.Company_RoundOff_Value(this.CompanyID);
            this.div_ProductsDetailsList.Visible = true;
            try
            {
                if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
                {
                    str = base.Request.QueryString["ID"];
                    DataTable dataTable1 = ProductBasePage.ProductCategoryNameSelect_Navigation(product.companyID, Convert.ToInt32(str));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        str1 = dataRow["PriceCatalogueCategoryName"].ToString();
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
                        if (this.strMainCount > str1.Length + 4)
                        {
                            this.strMainCount = this.strMainCount - str1.Length + 4;
                            if (this.ProductSitePath == "")
                            {
                                this.ProductSitePath = string.Concat("<span Class='floatLeft'>&nbsp;>>&nbsp;</span> <span Class='floatLeft'></span> <span>&nbsp;", this.objBase.SpecialDecode(str1), "</span> ");
                            }
                        }
                        if (Convert.ToInt32(dataRow["ParentCategoryID"]) <= 0)
                        {
                            continue;
                        }
                        this.GenerateBreadcrums(Convert.ToInt32(dataRow["ParentCategoryID"]));
                    }
                }
            }
            catch
            {
            }
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx' >", this.objLanguage.GetLanguageConversion("Product_List"), "</a>", this.ProductSitePath };
            label.Text = string.Concat(sitePath);
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && product.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(product.strSitePath, "login.aspx"));
            }
            if (this.Session["StoreUserID"] != null)
            {
                product.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            }
            if (base.Request.Params["ID"] != null)
            {
                this.priceCatalogueCategoryID = Convert.ToInt32(base.Request.Params["ID"]);
            }
            if (this.priceCatalogueCategoryID == 0)
            {
                base.Title = commonclass.pageTitle("Product category list", Convert.ToInt32(product.companyID), Convert.ToInt32(product.AccountID));
            }
            else
            {
                base.Title = commonclass.pageTitle("Products list", Convert.ToInt32(product.companyID), Convert.ToInt32(product.AccountID));
            }
            int num = 0;
            foreach (DataRow row1 in CMSBasePage.Select_BannerImages(product.AccountID, 0, "R", "Products").Rows)
            {
                if (num == 0)
                {
                    this.plhRightBanner.Controls.Add(new LiteralControl("<div id='right_div'><div class='right_div_left'>"));
                }
                item = new object[] { product.strSitePath, "ImageHandler.ashx?Imagename=", row1["bannerImage"], "&amp;type=b&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                string str2 = string.Concat(item);
                if (row1["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhRightBanner.Controls;
                    item = new object[] { "<div><img border='0' src='", str2, "' class='imgWidth rightBanner_TitlewithoutURL' alt='", row1["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(item)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhRightBanner.Controls;
                    item = new object[] { "<div><a href='", row1["URL"], "'><img border='0' src='", str2, "' alt='", row1["bannerTitle"], "' class='rightBanner_TitlewithURL' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item)));
                }
                num++;
                product cntRight = this;
                cntRight.cnt_right = cntRight.cnt_right + 1;
            }
            if (num != 0)
            {
                this.plhRightBanner.Controls.Add(new LiteralControl("</div></div>"));
            }
            if (this.cnt_right != 0)
            {
                this.centerDivWidth = 6;
            }
            else
            {
                this.centerDivWidth = 7;
            }
            if (this.priceCatalogueCategoryID == 0)
            {
                try
                {
                    this.spn_headding.InnerText = this.objLanguage.GetLanguageConversion("Product_List");
                    DataTable dataTable2 = ProductBasePage.productsCategoryList_Select((long)product.companyID, product.AccountID, product.StoreUserID);
                    for (int i = 0; i < dataTable2.Columns.Count; i++)
                    {
                        dataTable2.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow dataRow1 in dataTable2.Rows)
                    {
                        dataRow1["PriceCatalogueCategoryName"] = this.objBase.SpecialDecode(dataRow1["PriceCatalogueCategoryName"].ToString());
                        dataRow1["DEscription"] = this.objBase.SpecialDecode(dataRow1["DEscription"].ToString());
                    }
                    StringBuilder stringBuilder = new StringBuilder();
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in dataTable2.Rows)
                        {
                            this.PriceCatalogueCategoryID.Add(row2["PriceCatalogueCategoryID"].ToString());
                        }
                    }
                    if (dataTable2.Rows.Count <= 0)
                    {
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl("<div id='noRecordFound'><strong>No Record Found </strong></div>"));
                        this.spn_headding.Visible = false;
                    }
                    else
                    {
                        foreach (DataRow dataRow2 in dataTable2.Rows)
                        {
                            stringBuilder.Append("<div class='productDetails_div'><div>");
                            string empty1 = string.Empty;
                            empty1 = this.objBase.SpecialDecode(dataRow2["PriceCatalogueCategoryName"].ToString().Trim());
                            stringBuilder.Append(string.Concat("<div class='productName_div' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "'>"));
                            stringBuilder.Append(string.Concat("<label class='div_prodname'>", empty1, "</label>"));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            stringBuilder.Append("<div class='productImage_div clearTop'>");
                            if (dataRow2["CategoryImage"].ToString() != "")
                            {
                                item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_", dataRow2["CategoryImage"].ToString(), "&amp;type=c&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                this.finalimageName1 = string.Concat(item);
                            }
                            else
                            {
                                item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                this.finalimageName1 = string.Concat(item);
                            }
                            string str3 = dataRow2["CategoryImage"].ToString().Trim();
                            chrArray = new char[] { '.' };
                            string[] strArrays = str3.Split(chrArray);
                            if (strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                            {
                                try
                                {
                                    item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\ProductCatalogueCategory\\t_", dataRow2["CategoryImage"].ToString() };
                                    string str4 = string.Concat(item);
                                    System.Drawing.Image image = System.Drawing.Image.FromFile(str4);
                                    FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
                                    int frameCount = image.GetFrameCount(frameDimension);
                                    int num1 = 200;
                                    int num2 = 150;
                                    if (image.Width < 200 && image.Height < 150)
                                    {
                                        num1 = Convert.ToInt32(image.Width);
                                        num2 = Convert.ToInt32(image.Height);
                                    }
                                    System.Drawing.Image image1 = System.Drawing.Image.FromFile(str4);
                                    if (frameCount > 0)
                                    {
                                        string str5 = createImageThumnail.FixedSizeForGif(str4, image1, num1, num2, false);
                                        chrArray = new char[] { '~' };
                                        string[] strArrays1 = str5.Split(chrArray);
                                        int num3 = Convert.ToInt16(strArrays1[0]);
                                        int num4 = Convert.ToInt16(strArrays1[1]);
                                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            stringBuilder.Append("<div class='productName_Link'>");
                                            if (dataRow2["CategoryImage"].ToString() != "")
                                            {
                                                item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' style='height:", num4, "px;width:", num3, "px;'  title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "'  class='ProductsImgBorder Catagory_Image' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(item));
                                            }
                                            else
                                            {
                                                item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' style='height:", num4, "px;width:", num3, "px;' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder.Append(string.Concat(item));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                        else
                                        {
                                            stringBuilder.Append("<div class='productName_Link'>");
                                            if (dataRow2["CategoryImage"].ToString() != "")
                                            {
                                                item = new object[] { "<a href='", null, null, null, null, null, null, null, null, null, null };
                                                sitePath = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                item[2] = "'><img border='0' style='height:";
                                                item[3] = num4;
                                                item[4] = "px;width:";
                                                item[5] = num3;
                                                item[6] = "px;' title='";
                                                item[7] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                                item[8] = "'  class='ProductsImgBorder Catagory_Image' src=\"";
                                                item[9] = this.finalimageName1;
                                                item[10] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(item));
                                            }
                                            else
                                            {
                                                item = new object[] { "<a href='", null, null, null, null, null, null, null, null, null, null };
                                                sitePath = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                item[2] = "'><img border='0' style='height:";
                                                item[3] = num4;
                                                item[4] = "px;width:";
                                                item[5] = num3;
                                                item[6] = "px;' title='";
                                                item[7] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                                item[8] = "'   src=\"";
                                                item[9] = this.finalimageName1;
                                                item[10] = "\" alt=' '/></a>";
                                                stringBuilder.Append(string.Concat(item));
                                            }
                                            stringBuilder.Append("</div>");
                                        }
                                    }
                                    else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                    {
                                        stringBuilder.Append("<div class='productName_Link'>");
                                        if (dataRow2["CategoryImage"].ToString() != "")
                                        {
                                            sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "'  class='ProductsImgBorder Catagory_Image' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder.Append(string.Concat(sitePath));
                                        }
                                        else
                                        {
                                            sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder.Append(string.Concat(sitePath));
                                        }
                                        stringBuilder.Append("</div>");
                                    }
                                    else
                                    {
                                        stringBuilder.Append("<div class='productName_Link'>");
                                        if (dataRow2["CategoryImage"].ToString() != "")
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img border='0' title='";
                                            sitePath[3] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                            sitePath[4] = "'  class='ProductsImgBorder Catagory_Image' src=\"";
                                            sitePath[5] = this.finalimageName1;
                                            sitePath[6] = "\" alt=' '/></a>";
                                            stringBuilder.Append(string.Concat(sitePath));
                                        }
                                        else
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img border='0' title='";
                                            sitePath[3] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                            sitePath[4] = "'   src=\"";
                                            sitePath[5] = this.finalimageName1;
                                            sitePath[6] = "\" alt=' '/></a>";
                                            stringBuilder.Append(string.Concat(sitePath));
                                        }
                                        stringBuilder.Append("</div>");
                                    }
                                }
                                catch (Exception exception)
                                {
                                }
                            }
                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                            {
                                stringBuilder.Append("<div class='productName_Link'>");
                                if (dataRow2["CategoryImage"].ToString() != "")
                                {
                                    sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "'  class='ProductsImgBorder Catagory_Image' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                    stringBuilder.Append(string.Concat(sitePath));
                                }
                                else
                                {
                                    sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCatalogueCategoryID[this.arrayLength].ToString(), "'><img border='0' title='", dataRow2["PriceCatalogueCategoryName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                    stringBuilder.Append(string.Concat(sitePath));
                                }
                                stringBuilder.Append("</div>");
                            }
                            else
                            {
                                stringBuilder.Append("<div class='productName_Link'>");
                                if (dataRow2["CategoryImage"].ToString() != "")
                                {
                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null };
                                    keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                    sitePath[2] = "'><img border='0' title='";
                                    sitePath[3] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                    sitePath[4] = "'  class='ProductsImgBorder Catagory_Image' src=\"";
                                    sitePath[5] = this.finalimageName1;
                                    sitePath[6] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(sitePath));
                                }
                                else
                                {
                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null };
                                    keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCatalogueCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                    sitePath[2] = "'><img border='0' title='";
                                    sitePath[3] = dataRow2["PriceCatalogueCategoryName"].ToString().Trim();
                                    sitePath[4] = "'   src=\"";
                                    sitePath[5] = this.finalimageName1;
                                    sitePath[6] = "\" alt=' '/></a>";
                                    stringBuilder.Append(string.Concat(sitePath));
                                }
                                stringBuilder.Append("</div>");
                            }
                            this.finalimageName1 = "";
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            string empty2 = string.Empty;
                            empty2 = this.objBase.SpecialDecode(dataRow2["Description"].ToString()).Trim();
                            empty2 = empty2.Replace("\n", "<br >");
                            stringBuilder.Append(string.Concat("<div class='productCategoryDescription_div' title='", dataRow2["Description"].ToString().Trim(), "'>"));
                            if (empty.ToLower() == "true" || empty == "")
                            {
                                item = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> ", empty2, "</label>" };
                                stringBuilder.Append(string.Concat(item));
                            }
                            else
                            {
                                item = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> </label>" };
                                stringBuilder.Append(string.Concat(item));
                            }
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div class='clearBoth'></div>");
                            stringBuilder.Append("</div></div>");
                            if (this.arrayLength >= dataTable2.Rows.Count - 1)
                            {
                                break;
                            }
                            this.arrayLength = this.arrayLength + 1;
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
                    this.spn_headding.InnerText = "Products List";
                    DataTable dataTable3 = ProductBasePage.productListImage(product.companyID, this.priceCatalogueCategoryID, Convert.ToInt32(product.AccountID), product.StoreUserID);
                    StringBuilder stringBuilder1 = new StringBuilder();
                    if (dataTable3.Rows.Count > 0)
                    {
                        foreach (DataRow row3 in dataTable3.Rows)
                        {
                            dataTable3.Columns["PriceCatalogueID"].ReadOnly = false;
                            this.PriceCategoryID.Add(row3["PriceCatalogueID"].ToString());
                        }
                    }
                    if (dataTable3.Rows.Count <= 0)
                    {
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(string.Concat("<div id='noRecordFound'><strong>", this.objLanguage.GetLanguageConversion("No_Records_Found"), " </strong></div>")));
                        this.spn_headding.Visible = false;
                    }
                    else
                    {
                        
                        foreach (DataRow copyPriceCatalogueID in dataTable3.Rows)
                        {
                            if (copyPriceCatalogueID["Type"].ToString().ToLower() != "c")
                            {
                                if (copyPriceCatalogueID["Type"].ToString().ToLower() != "p")
                                {
                                    continue;
                                }
                                DataTable dataTable4 = new DataTable();
                                stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDetails_div'    ><div>"));
                                string empty3 = string.Empty;
                                empty3 = this.objBase.SpecialDecode(copyPriceCatalogueID["CatalogueName"].ToString().Trim());
                                sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_div' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'>" };
                                stringBuilder1.Append(string.Concat(sitePath));
                                stringBuilder1.Append(string.Concat("<div class='div_prodname'<label>", empty3, "</label></div>"));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                {
                                    sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productImage_div clearTop'>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                    {
                                        item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=", copyPriceCatalogueID["ProductImage"].ToString(), "&amp;type=p&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                        this.finalimageName1 = string.Concat(item);
                                    }
                                    else
                                    {
                                        item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_no_image_available.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                        this.finalimageName1 = string.Concat(item);
                                    }
                                }
                                else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                                {
                                    try
                                    {
                                        this.CopyPriceCatalogueID = Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"]);
                                        DataTable dataTable5 = ProductBasePage.OtherMultiple_DefaultItem_Select(Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                                        if (dataTable5.Rows.Count != 0)
                                        {
                                            this.NoProductSelected = "false";
                                        }
                                        else
                                        {
                                            this.NoProductSelected = "true";
                                            this.PriceCatalogueID = this.CopyPriceCatalogueID;
                                        }
                                        if (dataTable5.Rows.Count > 0 && dataTable5.Rows[0]["KitItemID"] != null)
                                        {
                                            this.PriceCatalogueID = Convert.ToInt32(dataTable5.Rows[0]["KitItemID"]);
                                        }
                                        dataTable4 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(this.PriceCatalogueID));
                                        enumerator = dataTable4.Rows.GetEnumerator();
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
                                    string str6 = this.ProductImage.ToString().Trim();
                                    chrArray = new char[] { '.' };
                                    string[] strArrays2 = str6.Split(chrArray);
                                    if (strArrays2[(int)strArrays2.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                    {
                                        try
                                        {
                                            item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\Product\\", this.ProductImage.ToString() };
                                            string str7 = string.Concat(item);
                                            System.Drawing.Image image2 = System.Drawing.Image.FromFile(str7);
                                            FrameDimension frameDimension1 = new FrameDimension(image2.FrameDimensionsList[0]);
                                            int frameCount1 = image2.GetFrameCount(frameDimension1);
                                            int num5 = 200;
                                            int num6 = 150;
                                            if (image2.Width < 200 && image2.Height < 150)
                                            {
                                                num5 = Convert.ToInt32(image2.Width);
                                                num6 = Convert.ToInt32(image2.Height);
                                            }
                                            System.Drawing.Image image3 = System.Drawing.Image.FromFile(str7);
                                            if (frameCount1 > 0)
                                            {
                                                string str8 = createImageThumnail.FixedSizeForGif(str7, image3, num5, num6, false);
                                                chrArray = new char[] { '~' };
                                                string[] strArrays3 = str8.Split(chrArray);
                                                int num7 = Convert.ToInt16(strArrays3[0]);
                                                int num8 = Convert.ToInt16(strArrays3[1]);
                                                if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                {
                                                    stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                                    int num9 = 0;
                                                    if (base.Request.Params["ID"] != "")
                                                    {
                                                        num9 = Convert.ToInt32(base.Request.Params["ID"]);
                                                    }
                                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                    {
                                                        item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num9, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' style='height:", num8, "px;width:", num7, "px;' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    else
                                                    {
                                                        item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num9, "'><img id='imgGetID", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' style='height:", num8, "px;width:", num7, "px;' border='0' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                                else
                                                {
                                                    stringBuilder1.Append("<div class='productName_Link'>");
                                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                    {
                                                        item = new object[13];
                                                        item[0] = "<a href='";
                                                        sitePath = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                        item[2] = "'><img id='imgGetID4";
                                                        item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                        item[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' style='height:";
                                                        item[5] = num8;
                                                        item[6] = "px;width:";
                                                        item[7] = num7;
                                                        item[8] = "px;' title='";
                                                        item[9] = this.ProductImage.ToString().Trim();
                                                        item[10] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                        item[11] = this.finalimageName1;
                                                        item[12] = "\" alt=' '/></a>";
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    else
                                                    {
                                                        item = new object[13];
                                                        item[0] = "<a href='";
                                                        sitePath = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                        item[2] = "'><img id='imgGetID3";
                                                        item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                        item[4] = "' onmouseover='getTitle(this.id)' runat='server' style='height:";
                                                        item[5] = num8;
                                                        item[6] = "px;width:";
                                                        item[7] = num7;
                                                        item[8] = "px;' border='0' title='";
                                                        item[9] = this.ProductImage.ToString().Trim();
                                                        item[10] = "'  src=\"";
                                                        item[11] = this.finalimageName1;
                                                        item[12] = "\" alt=' '/></a>";
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                            }
                                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                                int num10 = 0;
                                                if (base.Request.Params["ID"] != "")
                                                {
                                                    num10 = Convert.ToInt32(base.Request.Params["ID"]);
                                                }
                                                if (this.ProductImage.ToString() != "")
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num10, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                else
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num10, "'><img id='imgGetID", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                stringBuilder1.Append("</div>");
                                            }
                                            else
                                            {
                                                stringBuilder1.Append("<div class='productName_Link'>");
                                                if (this.ProductImage.ToString() != "")
                                                {
                                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                    keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                    sitePath[2] = "'><img id='imgGetID4";
                                                    sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                    sitePath[5] = this.CatalogueName.ToString().Trim();
                                                    sitePath[6] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                    sitePath[7] = this.finalimageName1;
                                                    sitePath[8] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(sitePath));
                                                }
                                                else
                                                {
                                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                    keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                    sitePath[2] = "'><img id='imgGetID3";
                                                    sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                    sitePath[5] = this.CatalogueName.ToString().Trim();
                                                    sitePath[6] = "'  src=\"";
                                                    sitePath[7] = this.finalimageName1;
                                                    sitePath[8] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(sitePath));
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
                                        stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                        int num11 = 0;
                                        if (base.Request.Params["ID"] != "")
                                        {
                                            num11 = Convert.ToInt32(base.Request.Params["ID"]);
                                        }
                                        if (this.ProductImage.ToString() != "")
                                        {
                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num11, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", this.CatalogueName.ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder1.Append(string.Concat(item));
                                        }
                                        else
                                        {
                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num11, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", this.CatalogueName.ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder1.Append(string.Concat(item));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    else
                                    {
                                        stringBuilder1.Append("<div class='productName_Link'>");
                                        if (this.ProductImage.ToString() != "")
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img id='imgGetID4";
                                            sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                            sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                            sitePath[5] = this.CatalogueName.ToString().Trim();
                                            sitePath[6] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                            sitePath[7] = this.finalimageName1;
                                            sitePath[8] = "\" alt=' '/></a>";
                                            stringBuilder1.Append(string.Concat(sitePath));
                                        }
                                        else
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.CatalogueName.ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img id='imgGetID3";
                                            sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                            sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                            sitePath[5] = this.CatalogueName.ToString().Trim();
                                            sitePath[6] = "'  src=\"";
                                            sitePath[7] = this.finalimageName1;
                                            sitePath[8] = "\" alt=' '/></a>";
                                            stringBuilder1.Append(string.Concat(sitePath));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                }
                                if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                {
                                    string str9 = copyPriceCatalogueID["ProductImage"].ToString().Trim();
                                    chrArray = new char[] { '.' };
                                    string[] strArrays4 = str9.Split(chrArray);
                                    if (strArrays4[(int)strArrays4.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                    {
                                        try
                                        {
                                            item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\Product\\", copyPriceCatalogueID["ProductImage"].ToString() };
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
                                                chrArray = new char[] { '~' };
                                                string[] strArrays5 = str11.Split(chrArray);
                                                int num14 = Convert.ToInt16(strArrays5[0]);
                                                int num15 = Convert.ToInt16(strArrays5[1]);
                                                if (ConnectionClass.RewriteModule.ToLower() != "on")
                                                {
                                                    stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                                    int num16 = 0;
                                                    if (base.Request.Params["ID"] != "")
                                                    {
                                                        num16 = Convert.ToInt32(base.Request.Params["ID"]);
                                                    }
                                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                    {
                                                        item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num16, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' style='height:", num15, "px;width:", num14, "px;' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    else
                                                    {
                                                        item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num16, "'><img id='imgGetID", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' style='height:", num15, "px;width:", num14, "px;' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                                else
                                                {
                                                    stringBuilder1.Append("<div class='productName_Link'>");
                                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                    {
                                                        item = new object[13];
                                                        item[0] = "<a href='";
                                                        sitePath = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                        item[2] = "'><img id='imgGetID4";
                                                        item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                        item[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' style='height:";
                                                        item[5] = num15;
                                                        item[6] = "px;width:";
                                                        item[7] = num14;
                                                        item[8] = "px;' title='";
                                                        item[9] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                        item[10] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                        item[11] = this.finalimageName1;
                                                        item[12] = "\" alt=' '/></a>";
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    else
                                                    {
                                                        item = new object[13];
                                                        item[0] = "<a href='";
                                                        sitePath = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                        item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                        item[2] = "'><img id='imgGetID3";
                                                        item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                        item[4] = "' onmouseover='getTitle(this.id)' runat='server' style='height:";
                                                        item[5] = num15;
                                                        item[6] = "px;width:";
                                                        item[7] = num14;
                                                        item[8] = "px;' border='0' title='";
                                                        item[9] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                        item[10] = "'  src=\"";
                                                        item[11] = this.finalimageName1;
                                                        item[12] = "\" alt=' '/></a>";
                                                        stringBuilder1.Append(string.Concat(item));
                                                    }
                                                    stringBuilder1.Append("</div>");
                                                }
                                            }
                                            else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                                int num17 = 0;
                                                if (base.Request.Params["ID"] != "")
                                                {
                                                    num17 = Convert.ToInt32(base.Request.Params["ID"]);
                                                }
                                                if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num17, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                else
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num17, "'><img id='imgGetID", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                stringBuilder1.Append("</div>");
                                            }
                                            else
                                            {
                                                stringBuilder1.Append("<div class='productName_Link'>");
                                                if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                {
                                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                    keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                    sitePath[2] = "'><img id='imgGetID4";
                                                    sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                    sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                    sitePath[6] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                    sitePath[7] = this.finalimageName1;
                                                    sitePath[8] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(sitePath));
                                                }
                                                else
                                                {
                                                    sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                    keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                                    sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                    sitePath[2] = "'><img id='imgGetID3";
                                                    sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                    sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                    sitePath[6] = "'  src=\"";
                                                    sitePath[7] = this.finalimageName1;
                                                    sitePath[8] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(sitePath));
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
                                        stringBuilder1.Append(string.Concat("<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productName_Link'>"));
                                        int num18 = 0;
                                        if (base.Request.Params["ID"] != "")
                                        {
                                            num18 = Convert.ToInt32(base.Request.Params["ID"]);
                                        }
                                        if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                        {
                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num18, "'><img id='imgGetID1", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' class='ProductsImgBorder ProductCatagoryImage' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder1.Append(string.Concat(item));
                                        }
                                        else
                                        {
                                            item = new object[] { "<a href='", product.strSitePath, "products/productdetails.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "&amp;type=0&CID=", num18, "'><img id='imgGetID", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                            stringBuilder1.Append(string.Concat(item));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    else
                                    {
                                        stringBuilder1.Append("<div class='productName_Link'>");
                                        if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img id='imgGetID4";
                                            sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                            sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                            sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                            sitePath[6] = "' class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                            sitePath[7] = this.finalimageName1;
                                            sitePath[8] = "\" alt=' '/></a>";
                                            stringBuilder1.Append(string.Concat(sitePath));
                                        }
                                        else
                                        {
                                            sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                            keySeparator = new string[] { product.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                                            sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                            sitePath[2] = "'><img id='imgGetID3";
                                            sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                            sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                            sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                            sitePath[6] = "'  src=\"";
                                            sitePath[7] = this.finalimageName1;
                                            sitePath[8] = "\" alt=' '/></a>";
                                            stringBuilder1.Append(string.Concat(sitePath));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                }
                                this.finalimageName1 = "";
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                string empty4 = string.Empty;
                                bool flag = false;
                                if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() != "m")
                                {
                                    empty4 = copyPriceCatalogueID["ShortDescription"].ToString().Trim();
                                    flag = Convert.ToBoolean(copyPriceCatalogueID["IsShortDescription"]);
                                    sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDescription_div'>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    if (flag)
                                    {
                                        stringBuilder1.Append(string.Concat("<label> ", empty4, "</label>"));
                                    }
                                    stringBuilder1.Append("</div>");
                                }
                                else if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                                {
                                    empty4 = this.Description.ToString().Trim();
                                    sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='productDescription_div'>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    if (!this.Is_ShortDescription1)
                                    {
                                        item = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> </label>" };
                                        stringBuilder1.Append(string.Concat(item));
                                    }
                                    else
                                    {
                                        item = new object[] { "<label id='lblDesc", this.PriceCatalogueID, this.CopyPriceCatalogueID, "'> ", empty4, "</label>" };
                                        stringBuilder1.Append(string.Concat(item));
                                    }
                                    stringBuilder1.Append("</div>");
                                }
                                empty4 = empty4.Replace("\n", "<br >");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' id='div_btnsave", this.PriceCategoryID[this.arrayLength].ToString(), "' class='productViewBtn_div1 DisplayBlock'>" };
                                stringBuilder1.Append(string.Concat(sitePath));
                                if (base.Request.Params["ID"] != "")
                                {
                                    int num19 = Convert.ToInt32(base.Request.Params["ID"]);
                                    item = new object[] { "<input type='button' value='", this.objLanguage.GetLanguageConversion("View_Details"), "' class='x-btnpro Grey main' onclick='Onclick_ProductNew(", num19, ",", this.PriceCategoryID[this.arrayLength].ToString(), ",\"", ConnectionClass.RemoveIllegalChars(copyPriceCatalogueID["CatalogueName"].ToString()), "\");'/>" };
                                    stringBuilder1.Append(string.Concat(item));
                                    this.Session["SearchKey"] = "";
                                }
                                stringBuilder1.Append("</div>");
                                sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='SaveDiv'>" };
                                stringBuilder1.Append(string.Concat(sitePath));
                                stringBuilder1.Append(string.Concat("<div id='div_btnsaveprocess", this.PriceCategoryID[this.arrayLength].ToString(), "' class='x-btnpro Grey main SaveBtnLding'>"));
                                stringBuilder1.Append(string.Concat("<img border='0' class='trans' src='", this.strImagepath, "images/radimg1.gif'>"));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>");
                                if (copyPriceCatalogueID["DrawStockFrom"].ToString().ToLower().Trim() == "m")
                                {
                                    this.CopyPriceCatalogueID = Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"]);
                                    if (Convert.ToBoolean(copyPriceCatalogueID["isQuickItem"]))
                                    {
                                        sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", copyPriceCatalogueID["pricecatalogueid"].ToString(), "'>" };
                                        stringBuilder1.Append(string.Concat(sitePath));
                                        DataTable dataTable6 = ProductBasePage.OtherMultiple_DefaultItem_Select(Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                                        if (dataTable6.Rows.Count == 0)
                                        {
                                            copyPriceCatalogueID["PriceCatalogueID"] = this.CopyPriceCatalogueID;
                                        }
                                        if (dataTable6.Rows.Count > 0 && dataTable6.Rows[0]["KitItemID"] != null)
                                        {
                                            copyPriceCatalogueID["PriceCatalogueID"] = dataTable6.Rows[0]["KitItemID"];
                                        }
                                        HiddenField hiddenField = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxName", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField1 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxRate", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField2 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_TaxID", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                            Value = "0"
                                        };
                                        hiddenField1.Value = "0";
                                        DataTable taxDetailsByProductCatalogueId = ProductBasePage.GetTaxDetails_ByProductCatalogueId(product.companyID, Convert.ToInt32(copyPriceCatalogueID["PriceCatalogueID"]));
                                        foreach (DataRow dataRow3 in taxDetailsByProductCatalogueId.Rows)
                                        {
                                            hiddenField2.Value = dataRow3["SalesTaxRate"].ToString();
                                            hiddenField.Value = dataRow3["TaxName"].ToString();
                                            hiddenField1.Value = dataRow3["TaxRate"].ToString();
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
                                        string empty5 = string.Empty;
                                        string empty6 = string.Empty;
                                        string empty7 = string.Empty;
                                        enumerator = dataTable4.Rows.GetEnumerator();
                                        try
                                        {
                                            if (enumerator.MoveNext())
                                            {
                                                DataRow current1 = (DataRow)enumerator.Current;
                                                empty7 = current1["MatrixType"].ToString();
                                                empty5 = current1["CatalogueName"].ToString();
                                                empty6 = current1["IsPriceStartFrom"].ToString();
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
                                        HiddenField lower = new HiddenField();
                                        HiddenField hiddenField3 = new HiddenField();
                                        HiddenField hiddenField4 = new HiddenField();
                                        lower.ID = string.Concat("hdn_IsCumulative_", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID);
                                        hiddenField3.ID = string.Concat("hdn_SoldInPacks_", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID);
                                        hiddenField4.ID = string.Concat("hdn_MainProductID", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID);
                                        hiddenField4.Value = this.CopyPriceCatalogueID.ToString();
                                        enumerator = dataTable4.Rows.GetEnumerator();
                                        try
                                        {
                                            if (enumerator.MoveNext())
                                            {
                                                DataRow current2 = (DataRow)enumerator.Current;
                                                lower.Value = current2["IsCumulativePricing"].ToString().ToLower();
                                                hiddenField3.Value = current2["SoldInPacksOf"].ToString();
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
                                            ID = string.Concat("hid_PriceCatelogueName", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID),
                                            Value = this.objBase.SpecialDecode(empty5)
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
                                            ID = string.Concat("hid_CostExcMarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField7 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_priceList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField8 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_MarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        foreach (DataRow row4 in dataTable4.Rows)
                                        {
                                            hiddenField6.Value = string.Concat(hiddenField6.Value, row4["Price"].ToString(), "µ");
                                            hiddenField7.Value = string.Concat(hiddenField7.Value, row4["SellingPrice"].ToString(), "µ");
                                            hiddenField8.Value = string.Concat(hiddenField8.Value, row4["Markup"].ToString(), "µ");
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
                                            ID = string.Concat("hdn_ProductStockManagement", this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField10 = new HiddenField()
                                        {
                                            ID = string.Concat("hdn_AvailableQuantity", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        DataTable dataTable7 = ProductBasePage.productsDetails_Select(Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"].ToString()));
                                        foreach (DataRow dataRow4 in dataTable7.Rows)
                                        {
                                            if (Convert.ToBoolean(dataRow4["ProductStockManagement"].ToString()))
                                            {
                                                hiddenField9.Value = "true";
                                            }
                                            if (int.Parse(dataRow4["AvailableQuantity"].ToString()) == 0 || dataRow4["AvailableQuantity"].ToString().Trim().Length <= 0)
                                            {
                                                hiddenField10.Value = "0";
                                            }
                                            else
                                            {
                                                hiddenField10.Value = dataRow4["AvailableQuantity"].ToString();
                                            }
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
                                            ID = string.Concat("hdn_qtyFromList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        HiddenField hiddenField12 = new HiddenField()
                                        {
                                            ID = string.Concat("hid_qtyToList", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        foreach (DataRow row5 in dataTable4.Rows)
                                        {
                                            HiddenField hiddenField13 = hiddenField11;
                                            hiddenField13.Value = string.Concat(hiddenField13.Value, row5["FromQuantity"].ToString(), "µ");
                                            HiddenField hiddenField14 = hiddenField12;
                                            hiddenField14.Value = string.Concat(hiddenField14.Value, row5["ToQuantity"].ToString(), "µ");
                                        }
                                        using (StringWriter stringWriter4 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter4 = new HtmlTextWriter(stringWriter4))
                                            {
                                                hiddenField11.RenderControl(htmlTextWriter4);
                                                hiddenField12.RenderControl(htmlTextWriter4);
                                            }
                                        }
                                        stringBuilder1.Append(string.Concat("<div onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                                        enumerator = dataTable4.Rows.GetEnumerator();
                                        try
                                        {
                                            if (enumerator.MoveNext())
                                            {
                                                DataRow current3 = (DataRow)enumerator.Current;
                                                stringBuilder1.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", current3["ProductStockManagement"].ToString().ToLower(), "' />"));
                                                item = new object[] { "<input type='hidden' id='hdnisstockitem", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", current3["IsStockItem"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdndrawstockfrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", current3["DrawStockFrom"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdnisbackorder", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", current3["IsBackOrder"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
                                                item = new object[] { "<input type='hidden' id='hdnavailableqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "' value='", current3["AvailableQuantity"].ToString(), "' />" };
                                                stringBuilder1.Append(string.Concat(item));
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
                                        Label label1 = new Label()
                                        {
                                            ID = string.Concat("lbl_priceStartsFrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        if (Convert.ToBoolean(empty6))
                                        {
                                            short num20 = 1;
                                            foreach (DataRow dataRow5 in dataTable4.Rows)
                                            {
                                                if (num20 == 1)
                                                {
                                                    label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow5["SellingPrice"].ToString()), 2, "", false, false, true));
                                                }
                                                num20 = (short)(num20 + 1);
                                            }
                                        }
                                        if (this.IsEnableHidePrice != "false")
                                        {
                                            label1.CssClass = "priceStartsFromInQuickAdd Visibilityhidden";
                                        }
                                        else
                                        {
                                            label1.CssClass = "priceStartsFromInQuickAdd";
                                        }
                                        using (StringWriter stringWriter5 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter5 = new HtmlTextWriter(stringWriter5))
                                            {
                                                label1.RenderControl(htmlTextWriter5);
                                            }
                                        }
                                        stringBuilder1.Append("</div>");
                                        HiddenField hiddenField15 = new HiddenField()
                                        {
                                            ID = string.Concat("hdnPriceCatalogueIds", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                            Value = string.Concat(copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        DataTable dataTable8 = ProductBasePage.OtherMultiple_product_Select((long)this.CopyPriceCatalogueID, product.companyID);
                                        foreach (DataRow row6 in dataTable8.Rows)
                                        {
                                            item = new object[] { hiddenField15.Value, ",", row6["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID };
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
                                            ID = string.Concat("ddlOtherMultiplrDrp", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                        };
                                        dropDownList.CssClass = "dropDownMultipleQuickAdd";
                                        AttributeCollection attributes = dropDownList.Attributes;
                                        item = new object[] { "javascript:ChnageProduct('", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "_", this.CopyPriceCatalogueID, "');" };
                                        attributes.Add("onchange", string.Concat(item));
                                        dropDownList.Attributes.Add("style", "margin-bottom:10px;");
                                        dropDownList.EnableViewState = true;
                                        dropDownList.AutoPostBack = true;
                                        this.BindOtherMultipleDropdownList(dataTable8, dropDownList);
                                        if (this.NoProductSelected == "true")
                                        {
                                            dropDownList.Items.Insert(0, "--Select--");
                                        }
                                        DataTable dataTable9 = ProductBasePage.OtherMultiple_DefaultItem_Select(this.CopyPriceCatalogueID);
                                        if (dataTable9.Rows.Count > 0 && dataTable9.Rows[0]["KitItemID"] != null)
                                        {
                                            this.objBase.SetDDLValue(dropDownList, dataTable9.Rows[0]["KitItemID"].ToString());
                                        }
                                        using (StringWriter stringWriter7 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter7 = new HtmlTextWriter(stringWriter7))
                                            {
                                                dropDownList.RenderControl(htmlTextWriter7);
                                            }
                                        }
                                        stringBuilder1.Append("</div>");
                                        if (empty7.ToString().ToLower() == "p")
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 35px;' >");
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
                                            item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'p');" };
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
                                        if (empty7.ToString().ToLower() == "g")
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 35px;height: 25px;' >");
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
                                            item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
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
                                        if (empty7.ToString().ToLower() == "s")
                                        {
                                            if (!Convert.ToBoolean(lower.Value))
                                            {
                                                stringBuilder1.Append("<div style='padding-left: 35px;'>");
                                                DropDownList languageConversion = new DropDownList()
                                                {
                                                    CssClass = "ddlPriceQtyQuickAdd",
                                                    ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID)
                                                };
                                                languageConversion.CssClass = "dropDownMultipleQuickAdd";
                                                languageConversion.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                                AttributeCollection attributeCollection1 = languageConversion.Attributes;
                                                item = new object[] { "javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'s');" };
                                                attributeCollection1.Add("onchange", string.Concat(item));
                                                this.SimpleMatrix_DropDownBind(dataTable4, languageConversion);
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
                                                stringBuilder1.Append("<div style='padding-left: 35px;' >");
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
                                                item = new object[] { "if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'s');" };
                                                attributes2.Add("onBlur", string.Concat(item));
                                                textBox2.Attributes.Add("onClick", "this.style.color = '';");
                                                textBox2.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                                DropDownList dropDownList1 = new DropDownList()
                                                {
                                                    CssClass = "ddlPriceQtyQuickAdd",
                                                    ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                                };
                                                dropDownList1.CssClass = "dropDownMultipleQuickAdd";
                                                dropDownList1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                                AttributeCollection attributeCollection2 = dropDownList1.Attributes;
                                                item = new object[] { "javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'s');" };
                                                attributeCollection2.Add("onchange", string.Concat(item));
                                                dropDownList1.Style.Add("display", "none");
                                                this.SimpleMatrix_DropDownBind(dataTable4, dropDownList1);
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
                                        item = new object[] { "<div id='divcartqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'>" };
                                        stringBuilder1.Append(string.Concat(item));
                                        stringBuilder1.Append("</div>");
                                        item = new object[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", empty7.ToString().ToLower().Trim(), "\")){QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, ",\"", empty7.ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                        stringBuilder1.Append(string.Concat(item));
                                        item = new object[] { "<img id='btnQucikAddCartLoading", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                        stringBuilder1.Append(string.Concat(item));
                                        item = new object[] { "<span id='btnQucikAddCartoutofstock", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;padding-top:33px;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                        stringBuilder1.Append(string.Concat(item));
                                        stringBuilder1.Append("</div>");
                                        item = new object[] { "<div id='divcartWidthHeight", copyPriceCatalogueID["pricecatalogueid"].ToString(), this.CopyPriceCatalogueID, "'style='padding-left:35px;clear:both;'>" };
                                        stringBuilder1.Append(string.Concat(item));
                                        stringBuilder1.Append("</div>");
                                        if (empty7.ToString().ToLower() == "g")
                                        {
                                            stringBuilder1.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                            TextBox textBox3 = new TextBox()
                                            {
                                                ID = string.Concat("txtWidth", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID),
                                                CssClass = "txtStyleQuickAdd",
                                                ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                            };
                                            textBox3.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                            textBox3.Style.Add("color", "gray");
                                            textBox3.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                            AttributeCollection attributes3 = textBox3.Attributes;
                                            item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                            attributes3.Add("onBlur", string.Concat(item));
                                            textBox3.Attributes.Add("onClick", "this.style.color = '';");
                                            using (StringWriter stringWriter12 = new StringWriter(stringBuilder1))
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
                                            AttributeCollection attributeCollection3 = textBox4.Attributes;
                                            item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), this.CopyPriceCatalogueID, ",'g');" };
                                            attributeCollection3.Add("onBlur", string.Concat(item));
                                            textBox4.Attributes.Add("onClick", "this.style.color = '';");
                                            using (StringWriter stringWriter13 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter13 = new HtmlTextWriter(stringWriter13))
                                                {
                                                    textBox4.RenderControl(htmlTextWriter13);
                                                }
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                }
                                else if (Convert.ToBoolean(copyPriceCatalogueID["isQuickItem"]))
                                {
                                    sitePath = new string[] { "<div  onmouseover='mouseovershow(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' class='QuickAddItemView' id='divQuickAdd", copyPriceCatalogueID["pricecatalogueid"].ToString(), "'>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    HiddenField str12 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxName", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                    };
                                    HiddenField str13 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxRate", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                    };
                                    HiddenField str14 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_TaxID", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                        Value = "0"
                                    };
                                    str13.Value = "0";
                                    str14.Value = copyPriceCatalogueID["SalesTaxRate"].ToString();
                                    str12.Value = copyPriceCatalogueID["TaxName"].ToString();
                                    str13.Value = copyPriceCatalogueID["TaxRate"].ToString();
                                    using (StringWriter stringWriter14 = new StringWriter(stringBuilder1))
                                    {
                                        using (HtmlTextWriter htmlTextWriter14 = new HtmlTextWriter(stringWriter14))
                                        {
                                            str14.RenderControl(htmlTextWriter14);
                                            str12.RenderControl(htmlTextWriter14);
                                            str13.RenderControl(htmlTextWriter14);
                                        }
                                    }
                                    DataTable dataTable10 = ProductBasePage.Product_CatalogueQty_Select(Convert.ToInt64(copyPriceCatalogueID["PriceCatalogueID"].ToString()));
                                    HiddenField lower1 = new HiddenField();
                                    HiddenField str15 = new HiddenField();
                                    HiddenField hiddenField16 = new HiddenField();
                                    lower1.ID = string.Concat("hdn_IsCumulative_", copyPriceCatalogueID["pricecatalogueid"].ToString());
                                    lower1.Value = copyPriceCatalogueID["IsCumulativePricing"].ToString().ToLower();
                                    str15.ID = string.Concat("hdn_SoldInPacks_", copyPriceCatalogueID["pricecatalogueid"].ToString());
                                    str15.Value = copyPriceCatalogueID["SoldInPacksOf"].ToString();
                                    hiddenField16.ID = string.Concat("hdn_MainProductID", copyPriceCatalogueID["pricecatalogueid"].ToString());
                                    hiddenField16.Value = "0";
                                    HiddenField hiddenField17 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_PriceCatelogueName", copyPriceCatalogueID["pricecatalogueid"].ToString()),
                                        Value = this.objBase.SpecialDecode(copyPriceCatalogueID["CatalogueName"].ToString().Trim())
                                    };
                                    using (StringWriter stringWriter15 = new StringWriter(stringBuilder1))
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
                                        ID = string.Concat("hid_CostExcMarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    HiddenField hiddenField19 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_priceList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    HiddenField hiddenField20 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_MarkupList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    foreach (DataRow dataRow6 in dataTable10.Rows)
                                    {
                                        hiddenField18.Value = string.Concat(hiddenField18.Value, dataRow6["Price"].ToString(), "µ");
                                        hiddenField19.Value = string.Concat(hiddenField19.Value, dataRow6["SellingPrice"].ToString(), "µ");
                                        hiddenField20.Value = string.Concat(hiddenField20.Value, dataRow6["Markup"].ToString(), "µ");
                                    }
                                    using (StringWriter stringWriter16 = new StringWriter(stringBuilder1))
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
                                        ID = string.Concat("hdn_AvailableQuantity", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    DataTable dataTable11 = ProductBasePage.productsDetails_Select(Convert.ToInt32(copyPriceCatalogueID["pricecatalogueid"].ToString()));
                                    foreach (DataRow row7 in dataTable11.Rows)
                                    {
                                        if (Convert.ToBoolean(row7["ProductStockManagement"].ToString()))
                                        {
                                            hiddenField21.Value = "true";
                                        }
                                        if (int.Parse(row7["AvailableQuantity"].ToString()) == 0 || row7["AvailableQuantity"].ToString().Trim().Length <= 0)
                                        {
                                            str16.Value = "0";
                                        }
                                        else
                                        {
                                            str16.Value = row7["AvailableQuantity"].ToString();
                                        }
                                    }
                                    using (StringWriter stringWriter17 = new StringWriter(stringBuilder1))
                                    {
                                        using (HtmlTextWriter htmlTextWriter17 = new HtmlTextWriter(stringWriter17))
                                        {
                                            hiddenField21.RenderControl(htmlTextWriter17);
                                            str16.RenderControl(htmlTextWriter17);
                                        }
                                    }
                                    HiddenField hiddenField22 = new HiddenField()
                                    {
                                        ID = string.Concat("hdn_qtyFromList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    HiddenField hiddenField23 = new HiddenField()
                                    {
                                        ID = string.Concat("hid_qtyToList", copyPriceCatalogueID["pricecatalogueid"].ToString())
                                    };
                                    foreach (DataRow dataRow7 in dataTable10.Rows)
                                    {
                                        HiddenField hiddenField24 = hiddenField22;
                                        hiddenField24.Value = string.Concat(hiddenField24.Value, dataRow7["FromQuantity"].ToString(), "µ");
                                        HiddenField hiddenField25 = hiddenField23;
                                        hiddenField25.Value = string.Concat(hiddenField25.Value, dataRow7["ToQuantity"].ToString(), "µ");
                                    }
                                    using (StringWriter stringWriter18 = new StringWriter(stringBuilder1))
                                    {
                                        using (HtmlTextWriter htmlTextWriter18 = new HtmlTextWriter(stringWriter18))
                                        {
                                            hiddenField22.RenderControl(htmlTextWriter18);
                                            hiddenField23.RenderControl(htmlTextWriter18);
                                        }
                                    }
                                    stringBuilder1.Append(string.Concat("<div onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");' style='padding-bottom: 5px;' >"));
                                    stringBuilder1.Append(string.Concat("<input type='hidden' id='hdnstockmanagement'  value='", copyPriceCatalogueID["ProductStockManagement"].ToString().ToLower(), "' />"));
                                    sitePath = new string[] { "<input type='hidden' id='hdnisstockitem", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["IsStockItem"].ToString(), "' />" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    sitePath = new string[] { "<input type='hidden' id='hdndrawstockfrom", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["DrawStockFrom"].ToString(), "' />" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    sitePath = new string[] { "<input type='hidden' id='hdnisbackorder", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["IsBackOrder"].ToString(), "' />" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    
                                    if (copyPriceCatalogueID["DrawStockFrom"].ToString().Trim() == "O")
                                    {
                                        //zee                                                                               
                                        int num1 = this.objBase.Check_MaxKit_Availability(long.Parse(copyPriceCatalogueID["pricecatalogueid"].ToString()), 0);
                                        sitePath = new string[] { "<input type='hidden' id='hdnavailableqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", num1.ToString(), "' />" };
                                    }
                                    else
                                    {
                                        sitePath = new string[] { "<input type='hidden' id='hdnavailableqty", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' value='", copyPriceCatalogueID["AvailableQuantity"].ToString(), "' />" };
                                    }

                                    stringBuilder1.Append(string.Concat(sitePath));
                                    if (Convert.ToBoolean(copyPriceCatalogueID["IsPriceStartFrom"]))
                                    {
                                        Label label2 = new Label();
                                        short num21 = 1;
                                        foreach (DataRow row8 in dataTable10.Rows)
                                        {
                                            if (num21 == 1)
                                            {
                                                label2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Price_Starts_From"), " :", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row8["SellingPrice"].ToString()), 2, "", false, false, true));
                                            }
                                            num21 = (short)(num21 + 1);
                                        }
                                        if (this.IsEnableHidePrice != "false")
                                        {
                                            label2.CssClass = "priceStartsFromInQuickAdd Visibilityhidden";
                                        }
                                        else
                                        {
                                            label2.CssClass = "priceStartsFromInQuickAdd";
                                        }
                                        using (StringWriter stringWriter19 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter19 = new HtmlTextWriter(stringWriter19))
                                            {
                                                label2.RenderControl(htmlTextWriter19);
                                            }
                                        }
                                    }
                                    stringBuilder1.Append("</div>");
                                    if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "p")
                                    {
                                        stringBuilder1.Append("<div style='padding-left: 35px;' >");
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
                                        using (StringWriter stringWriter20 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter20 = new HtmlTextWriter(stringWriter20))
                                            {
                                                textBox5.RenderControl(htmlTextWriter20);
                                            }
                                        }
                                    }
                                    if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                                    {
                                        stringBuilder1.Append("<div style='padding-left: 35px;height: 25px;' >");
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
                                        using (StringWriter stringWriter21 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter21 = new HtmlTextWriter(stringWriter21))
                                            {
                                                textBox6.RenderControl(htmlTextWriter21);
                                            }
                                        }
                                    }
                                    if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "s")
                                    {
                                        if (!Convert.ToBoolean(lower1.Value))
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 50px;' >");
                                            DropDownList languageConversion1 = new DropDownList()
                                            {
                                                CssClass = "ddlPriceQtyQuickAdd",
                                                ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                            };
                                            languageConversion1.CssClass = "dropDownMultipleQuickAdd";
                                            languageConversion1.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                            languageConversion1.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'s');"));
                                            this.SimpleMatrix_DropDownBind(dataTable10, languageConversion1);
                                            using (StringWriter stringWriter22 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter22 = new HtmlTextWriter(stringWriter22))
                                                {
                                                    languageConversion1.RenderControl(htmlTextWriter22);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("<div style='padding-left: 60px;' >");
                                            TextBox textBox7 = new TextBox()
                                            {
                                                ID = string.Concat("txt_Cumulative_PriceQty", dataTable3.Rows[this.arrayLength]["PriceCatalogueID"].ToString()),
                                                CssClass = "txtStyleQuickAdd",
                                                ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_enter_qty")
                                            };
                                            textBox7.Attributes.Add("value", "Qty");
                                            textBox7.Style.Add("color", "gray");
                                            textBox7.Attributes.Add("onFocus", "if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
                                            textBox7.Attributes.Add("onBlur", string.Concat("if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(", dataTable3.Rows[this.arrayLength]["PriceCatalogueID"].ToString(), ",'s');"));
                                            textBox7.Attributes.Add("onClick", "this.style.color = '';");
                                            textBox7.Attributes.Add("onkeypress", "if(validateNumberOnly(event)){}else{return false;}");
                                            DropDownList dropDownList2 = new DropDownList()
                                            {
                                                CssClass = "ddlPriceQtyQuickAdd",
                                                ID = string.Concat("ddlPriceQty", copyPriceCatalogueID["PriceCatalogueID"].ToString())
                                            };
                                            dropDownList2.CssClass = "dropDownMultipleQuickAdd";
                                            dropDownList2.ToolTip = this.objLanguage.GetLanguageConversion("QuickAdd_select_qty");
                                            dropDownList2.Attributes.Add("onchange", string.Concat("javascript:quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'s');"));
                                            dropDownList2.Style.Add("display", "none");
                                            this.SimpleMatrix_DropDownBind(dataTable10, dropDownList2);
                                            using (StringWriter stringWriter23 = new StringWriter(stringBuilder1))
                                            {
                                                using (HtmlTextWriter htmlTextWriter23 = new HtmlTextWriter(stringWriter23))
                                                {
                                                    dropDownList2.RenderControl(htmlTextWriter23);
                                                    textBox7.RenderControl(htmlTextWriter23);
                                                }
                                            }
                                        }
                                    }
                                    if (copyPriceCatalogueID["IsStockItem"].ToString().ToLower() == "true")
                                    {
                                        sitePath = new string[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='if(quickaddvalidate(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\")){QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")}'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    else
                                    {
                                        sitePath = new string[] { "<img onmouseout='mouseOutHidediv(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ");'  id='btnQucikAddCart", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' Title='", this.objLanguage.GetLanguageConversion("QuickAdd_to_cart"), "'  onclick='QuickAddItemCart(", copyPriceCatalogueID["pricecatalogueid"].ToString(), ",\"", copyPriceCatalogueID["MatrixType"].ToString().ToLower().Trim(), "\",", copyPriceCatalogueID["pricecatalogueid"].ToString(), ")'  class='basketbtnQuickAdd' src='../images/StoreImages/empty_cart_icon.gif'>" };
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    sitePath = new string[] { "<img id='btnQucikAddCartLoading", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "'  style='padding-left: 25px !important; display:none;' border='0' src='", this.strImagepath, "images/radimg1.gif'>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    sitePath = new string[] { "<span id='btnQucikAddCartoutofstock", copyPriceCatalogueID["PriceCatalogueID"].ToString(), "' style='color:red;padding-left:8px;margin-bottom:-10px;!important; display:none;'>", this.objLanguage.GetLanguageConversion("out_of_Stock"), "</span>" };
                                    stringBuilder1.Append(string.Concat(sitePath));
                                    stringBuilder1.Append("</div>");
                                    if (copyPriceCatalogueID["MatrixType"].ToString().ToLower() == "g")
                                    {
                                        stringBuilder1.Append("<div style='clear:both;'></div><div style='padding-left: 35px;padding-top:5px;'>");
                                        TextBox textBox8 = new TextBox()
                                        {
                                            ID = string.Concat("txtWidth", copyPriceCatalogueID["PriceCatalogueID"].ToString()),
                                            CssClass = "txtStyleQuickAdd",
                                            ToolTip = this.objLanguage.GetLanguageConversion("Please_enter_width")
                                        };
                                        textBox8.Attributes.Add("value", this.objLanguage.GetLanguageConversion("Width"));
                                        textBox8.Style.Add("color", "gray");
                                        textBox8.Attributes.Add("onFocus", string.Concat("if(this.value == '", this.objLanguage.GetLanguageConversion("Width"), "') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}"));
                                        AttributeCollection attributes4 = textBox8.Attributes;
                                        item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'g');" };
                                        attributes4.Add("onBlur", string.Concat(item));
                                        textBox8.Attributes.Add("onClick", "this.style.color = '';");
                                        using (StringWriter stringWriter24 = new StringWriter(stringBuilder1))
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
                                        AttributeCollection attributeCollection4 = textBox9.Attributes;
                                        item = new object[] { "roundUp(this.id,this.value,", this.RoundOff, "); quickaddvalidate(", copyPriceCatalogueID["PriceCatalogueID"].ToString(), ",'g');" };
                                        attributeCollection4.Add("onBlur", string.Concat(item));
                                        textBox9.Attributes.Add("onClick", "this.style.color = '';");
                                        using (StringWriter stringWriter25 = new StringWriter(stringBuilder1))
                                        {
                                            using (HtmlTextWriter htmlTextWriter25 = new HtmlTextWriter(stringWriter25))
                                            {
                                                textBox9.RenderControl(htmlTextWriter25);
                                            }
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    stringBuilder1.Append("</div>");
                                }
                                stringBuilder1.Append("</div></div>");
                                if (this.arrayLength >= dataTable3.Rows.Count - 1)
                                {
                                    break;
                                }
                                this.arrayLength = this.arrayLength + 1;
                            }
                            else
                            {
                                stringBuilder1.Append("<div class='productDetails_div'><div>");
                                string empty8 = string.Empty;
                                empty8 = this.objBase.SpecialDecode(copyPriceCatalogueID["CatalogueName"].ToString().Trim());
                                stringBuilder1.Append(string.Concat("<div class='productName_div' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'>"));
                                stringBuilder1.Append(string.Concat("<div class='div_prodname'><label>", empty8, "</label></div>"));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                stringBuilder1.Append("<div class='productImage_div clearTop'>");
                                if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                {
                                    item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_", copyPriceCatalogueID["ProductImage"].ToString(), "&amp;type=c&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                    this.finalimageName1 = string.Concat(item);
                                }
                                else
                                {
                                    item = new object[] { product.strSitePath, "ImageHandler.ashx?ImageName=t_category-icon.png&amp;type=r&amp;aid=", product.AccountID, "&amp;cid=", this.CompanyID };
                                    this.finalimageName1 = string.Concat(item);
                                }
                                string str17 = copyPriceCatalogueID["ProductImage"].ToString().Trim();
                                chrArray = new char[] { '.' };
                                string[] strArrays6 = str17.Split(chrArray);
                                if (strArrays6[(int)strArrays6.Length - 1].ToString().ToLower().Trim().ToLower() == "gif")
                                {
                                    try
                                    {
                                        item = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", product.companyID, "\\ProductCatalogueCategory\\t_", copyPriceCatalogueID["ProductImage"].ToString() };
                                        string str18 = string.Concat(item);
                                        System.Drawing.Image image6 = System.Drawing.Image.FromFile(str18);
                                        FrameDimension frameDimension3 = new FrameDimension(image6.FrameDimensionsList[0]);
                                        int frameCount3 = image6.GetFrameCount(frameDimension3);
                                        int num22 = 200;
                                        int num23 = 150;
                                        if (image6.Width < 200 && image6.Height < 150)
                                        {
                                            num22 = Convert.ToInt32(image6.Width);
                                            num23 = Convert.ToInt32(image6.Height);
                                        }
                                        System.Drawing.Image image7 = System.Drawing.Image.FromFile(str18);
                                        if (frameCount3 > 0)
                                        {
                                            string str19 = createImageThumnail.FixedSizeForGif(str18, image7, num22, num23, false);
                                            chrArray = new char[] { '~' };
                                            string[] strArrays7 = str19.Split(chrArray);
                                            int num24 = Convert.ToInt16(strArrays7[0]);
                                            int num25 = Convert.ToInt16(strArrays7[1]);
                                            if (ConnectionClass.RewriteModule.ToLower() != "on")
                                            {
                                                stringBuilder1.Append("<div class='productName_Link'>");
                                                if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID6", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' style='height:", num25, "px;width:", num24, "px;' runat='server' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                else
                                                {
                                                    item = new object[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img border='0' id='imgGetID5", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' style='height:", num25, "px;width:", num24, "px;' runat='server' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                stringBuilder1.Append("</div>");
                                            }
                                            else
                                            {
                                                stringBuilder1.Append("<div class='productName_Link'>");
                                                if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                                {
                                                    item = new object[13];
                                                    item[0] = "<a href='";
                                                    sitePath = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                    item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                    item[2] = "'><img  id='imgGetID8";
                                                    item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    item[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' style='height:";
                                                    item[5] = num25;
                                                    item[6] = "px;width:";
                                                    item[7] = num24;
                                                    item[8] = "px;' title='";
                                                    item[9] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                    item[10] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                    item[11] = this.finalimageName1;
                                                    item[12] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                else
                                                {
                                                    item = new object[13];
                                                    item[0] = "<a href='";
                                                    sitePath = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                    item[1] = base.ResolveUrl(string.Concat(sitePath));
                                                    item[2] = "'><img id='imgGetID7";
                                                    item[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                    item[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' style='height:";
                                                    item[5] = num25;
                                                    item[6] = "px;width:";
                                                    item[7] = num24;
                                                    item[8] = "px;' title='";
                                                    item[9] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                    item[10] = "' src=\"";
                                                    item[11] = this.finalimageName1;
                                                    item[12] = "\" alt=' '/></a>";
                                                    stringBuilder1.Append(string.Concat(item));
                                                }
                                                stringBuilder1.Append("</div>");
                                            }
                                        }
                                        else if (ConnectionClass.RewriteModule.ToLower() != "on")
                                        {
                                            stringBuilder1.Append("<div class='productName_Link'>");
                                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                            {
                                                sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID6", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(sitePath));
                                            }
                                            else
                                            {
                                                sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img border='0' id='imgGetID5", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                                stringBuilder1.Append(string.Concat(sitePath));
                                            }
                                            stringBuilder1.Append("</div>");
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("<div class='productName_Link'>");
                                            if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                            {
                                                sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                sitePath[2] = "'><img  id='imgGetID8";
                                                sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                sitePath[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                                sitePath[7] = this.finalimageName1;
                                                sitePath[8] = "\" alt=' '/></a>";
                                                stringBuilder1.Append(string.Concat(sitePath));
                                            }
                                            else
                                            {
                                                sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                                keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                                sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                                sitePath[2] = "'><img id='imgGetID7";
                                                sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                                sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                                sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                                sitePath[6] = "' src=\"";
                                                sitePath[7] = this.finalimageName1;
                                                sitePath[8] = "\" alt=' '/></a>";
                                                stringBuilder1.Append(string.Concat(sitePath));
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
                                    stringBuilder1.Append("<div class='productName_Link'>");
                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                    {
                                        sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img id='imgGetID6", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' border='0' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "'  class='ProductsImgBorder ProductCatagoryImage' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    else
                                    {
                                        sitePath = new string[] { "<a href='", product.strSitePath, "products/product.aspx?ID=", this.PriceCategoryID[this.arrayLength].ToString(), "'><img border='0' id='imgGetID5", copyPriceCatalogueID["pricecatalogueid"].ToString(), "' onmouseover='getTitle(this.id)' runat='server' title='", copyPriceCatalogueID["CatalogueName"].ToString().Trim(), "' src=\"", this.finalimageName1, "\" alt=' '/></a>" };
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    stringBuilder1.Append("</div>");
                                }
                                else
                                {
                                    stringBuilder1.Append("<div class='productName_Link'>");
                                    if (copyPriceCatalogueID["ProductImage"].ToString() != "")
                                    {
                                        sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                        sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                        sitePath[2] = "'><img  id='imgGetID8";
                                        sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                        sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                        sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                        sitePath[6] = "'  class='ProductsImgBorder ProductCatagoryImage' src=\"";
                                        sitePath[7] = this.finalimageName1;
                                        sitePath[8] = "\" alt=' '/></a>";
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    else
                                    {
                                        sitePath = new string[] { "<a href='", null, null, null, null, null, null, null, null };
                                        keySeparator = new string[] { product.strSitePath, "product", ConnectionClass.KeySeparator, this.PriceCategoryID[this.arrayLength].ToString(), ConnectionClass.FileExtension };
                                        sitePath[1] = base.ResolveUrl(string.Concat(keySeparator));
                                        sitePath[2] = "'><img id='imgGetID7";
                                        sitePath[3] = copyPriceCatalogueID["pricecatalogueid"].ToString();
                                        sitePath[4] = "' onmouseover='getTitle(this.id)' runat='server' border='0' title='";
                                        sitePath[5] = copyPriceCatalogueID["CatalogueName"].ToString().Trim();
                                        sitePath[6] = "' src=\"";
                                        sitePath[7] = this.finalimageName1;
                                        sitePath[8] = "\" alt=' '/></a>";
                                        stringBuilder1.Append(string.Concat(sitePath));
                                    }
                                    stringBuilder1.Append("</div>");
                                }
                                this.finalimageName1 = "";
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                string empty9 = string.Empty;
                                empty9 = this.objBase.SpecialDecode(copyPriceCatalogueID["ShortDescription"].ToString()).Trim();
                                empty9 = empty9.Replace("\n", "<br >");
                                stringBuilder1.Append(string.Concat("<div class='productCategoryDescription_div' title='", copyPriceCatalogueID["ShortDescription"].ToString().Trim(), "'>"));
                                stringBuilder1.Append(string.Concat("<label> ", empty9, "</label>"));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div class='clearBoth'></div>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>");
                                if (this.arrayLength >= dataTable3.Rows.Count - 1)
                                {
                                    break;
                                }
                                this.arrayLength = this.arrayLength + 1;
                            }
                        }
                        this.plh_ProductsDetails.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                    }
                }
                catch
                {
                }
            }
            if (this.Session["CheckNewEntry"] != null && this.Session["CheckNewEntry"] != null)
            {
                DataTable dataTable12 = ProductBasePage.BindTreeView(this.CompanyID, product.AccountID, 0, product.StoreUserID);
                int num26 = 0;
                foreach (DataRow dataRow8 in dataTable12.Rows)
                {
                    num26 = num26 + Convert.ToInt32(dataRow8["categoryProductCnt"].ToString().Trim());
                }
                int count = 0;
                count = dataTable12.Rows.Count;
                if (this.Session["ProductsCount"] != null && this.Session["ProductsCount"] != null && Convert.ToInt32(this.Session["ProductsCount"].ToString()) != num26)
                {
                    this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
                    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
                }
                if (Convert.ToInt32(this.Session["CheckNewEntry"].ToString()) != count)
                {
                    this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
                    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
                }
            }
            if (!this.Page.IsPostBack)
            {
                if (this.Session["treeViewState"] != null)
                {
                    string item1 = (string)this.Session["treeViewState"];
                    this.radCategoryTree.LoadXmlString(item1);
                }
                else
                {
                    this.LoadRootNodes(this.CompanyID, product.AccountID, 0);
                    this.Session["treeViewState"] = this.radCategoryTree.GetXml();
                }
                HtmlImage htmlImage = this.imgSucess;
                item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&amp;aid=", product.AccountID, " &amp;cid=", this.CompanyID };
                htmlImage.Src = string.Concat(item);
                this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("quickadd_confirmation");
            }
            this.btnQuickNotificationOk.Text = this.objLanguage.GetLanguageConversion("Continue_Shopping");
            this.btnGotoCart.Text = this.objLanguage.GetLanguageConversion("Go_to_Shopping_Cart");
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
                string[] keySeparator = new string[] { product.strSitePath, "products", ConnectionClass.KeySeparator, e.Node.Value.ToString(), ConnectionClass.FileExtension };
                response.Redirect(base.ResolveUrl(string.Concat(keySeparator)));
                return;
            }
            RadTreeNode radTreeNode = this.radCategoryTree.FindNodeByValue(e.Node.Value);
            if (radTreeNode != null)
            {
                radTreeNode.Selected = true;
            }
            this.Session["treeViewState"] = this.radCategoryTree.GetXml();
            base.Response.Redirect(string.Concat(product.strSitePath, "products/product.aspx?ID=", e.Node.Value.ToString()));
        }

        protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
        {
            Convert.ToInt32(e.Node.Value);
            this.AddChildNodes(this.CompanyID, product.AccountID, e.Node);
            string item = (string)this.Session["treeViewState"];
            RadTreeView radTreeView = new RadTreeView();
            radTreeView.LoadXmlString(item);
            RadTreeNode radTreeNode = radTreeView.FindNodeByValue(e.Node.Value);
            this.AddChildNodes(this.CompanyID, product.AccountID, radTreeNode);
            radTreeNode.Expanded = true;
            this.Session["treeViewState"] = radTreeView.GetXml();
        }

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