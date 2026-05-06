using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.ProductCatalogue
{
    public partial class ProductCatalogueCategory : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BasePage objpage = new BasePage();

        public static BaseClass objBase;

        private commonClass commclass = new commonClass();

        private Global gloobj = new Global();

        private DataTable dtsearch = new DataTable();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private WebstoreBasePage objPro = new WebstoreBasePage();

        public languageClass objlang = new languageClass();

        public static int CompanyID;

        public static int UserID;

        public int AccountID;

        public int count;

        public int PageSize = 10000;

        public int PageNumber;

        public int PageIndex = 1;

        public int totalrec;

        public int sortcount;

        public int publicAccountCnt;

        public string action = "add";

        public string para = "";

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string SecureVirtualPath = string.Empty;

        public static string whereCondition;

        public static string sortdirection;

        public static string sortedBy;

        public string colorformat = string.Empty;

        public string companyType = "Customer";

        public string catagoryType = string.Empty;

        public string catagoryImage = string.Empty;

        public string imgToSave = string.Empty;

        public string t_catagoryImage = string.Empty;

        public string m_catagoryImage = string.Empty;

        public static string catagoryImageName;

        public static string OrigFile_image;

        public static string NewFile_image;

        public static int defaultImageWidth;

        public static int defaultImageHeight;

        public static int categoryID;

        public int totalPublicNo;

        public int totalPublicNo_Selected;

        public string lstValue = "no";

        public long PriceCatalogueCategoryID;

        public string WebStore = string.Empty;

        public string checkBoxID = string.Empty;

        public string filename = string.Empty;

        public string postback = string.Empty;

        public string frompage = string.Empty;

        public string ServerName = string.Empty;

        public string SecDocumentSitePath = string.Empty;

        public static long catID;

        public string categoryid_new = string.Empty;

        public string AddStatus = string.Empty;

        public string DeleteStatus = string.Empty;

        private bool flag;

        private bool Err_flag = true;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static ProductCatalogueCategory()
        {
            ProductCatalogueCategory.objBase = new BaseClass();
            ProductCatalogueCategory.CompanyID = 0;
            ProductCatalogueCategory.UserID = 0;
            ProductCatalogueCategory.whereCondition = string.Empty;
            ProductCatalogueCategory.sortdirection = string.Empty;
            ProductCatalogueCategory.sortedBy = string.Empty;
            ProductCatalogueCategory.catagoryImageName = string.Empty;
            ProductCatalogueCategory.OrigFile_image = string.Empty;
            ProductCatalogueCategory.NewFile_image = string.Empty;
            ProductCatalogueCategory.defaultImageWidth = 0;
            ProductCatalogueCategory.defaultImageHeight = 0;
            ProductCatalogueCategory.categoryID = 0;
            ProductCatalogueCategory.catID = (long)0;
        }

        public ProductCatalogueCategory()
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.postback == "")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?&mode=add"));
            }
            else if (this.postback.ToLower() == "settings" && this.frompage.ToLower() == "product")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx"));
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string value = this.hdn_finalvalues.Value;
            string[] strArrays = this.hdn_finalvalues.Value.Split(new char[] { '\u005E' });
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueCategoryID)] = null;
            if (this.chkvisibletocustomer.Checked)
            {
                num = 1;
            }
            if (this.chkParentCategoryAlloc.Checked)
            {
                num1 = 1;
            }
            if (this.chkcatagorynotapproval.Checked)
            {
                num2 = 1;
            }
            if (base.Request.Params["mode"].ToString() != null)
            {
                if (!(base.Request.Params["mode"].ToString() == "edit") || !(this.hdn_validateflag.Value.ToLower() != "allocatemultiple"))
                {
                    if (this.hdn_validateflag.Value.ToLower() == "allocatemultiple" && base.Request.Params["mode"].ToString() == "add" || base.Request.Params["mode"].ToString() == "edit")
                    {
                        for (int i = 0; i < this.GridView1.Items.Count; i++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                            htmlInputCheckBox = (HtmlInputCheckBox)this.GridView1.Items[i].Cells[0].FindControl("checkBox_Copy1");
                            if (htmlInputCheckBox.Checked)
                            {
                                ProductCatalogueCategory.categoryID = Convert.ToInt32(htmlInputCheckBox.Value);
                                long num4 = (long)0;
                                string str = "A";
                                for (int j = 0; j < (int)strArrays.Length - 1; j++)
                                {
                                    string[] strArrays1 = strArrays[j].Split(new char[] { '\u00B6' });
                                    if (strArrays1[0] != "" && strArrays1[0] != null)
                                    {
                                        num4 = (long)Convert.ToInt32(strArrays1[0]);
                                        str = strArrays1[1].ToString();
                                        num3 = WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(ProductCatalogueCategory.categoryID), Convert.ToInt64(num4), (long)0, "S", (long)0, str);
                                        if (str.ToLower() == "s")
                                        {
                                            string[] strArrays2 = strArrays1[2].Split(new char[] { ',' });
                                            for (int k = 0; k < (int)strArrays2.Length; k++)
                                            {
                                                if (strArrays2[k] != null && strArrays2[k] != "")
                                                {
                                                    WebstoreBasePage.ProductCategory_CustomerDepartment_insert(num3, Convert.ToInt64(strArrays2[k]));
                                                }
                                            }
                                        }
                                        else if (str.ToLower() == "a")
                                        {
                                            WebstoreBasePage.pricecatalogue_Categorycustomer_delete(Convert.ToInt64(ProductCatalogueCategory.categoryID), num3);
                                        }
                                    }
                                }
                                if (this.hdn_iscopychecked.Value == "true")
                                {
                                    for (int l = 0; l < (int)strArrays.Length; l++)
                                    {
                                        if (strArrays[l] != "")
                                        {
                                            string[] strArrays3 = strArrays[l].Split(new char[] { '\u00B6' });
                                            if (strArrays3[0] != "" && strArrays3[0] != null)
                                            {
                                                num4 = (long)Convert.ToInt32(strArrays3[0]);
                                            }
                                            WebstoreBasePage.Assign_ProductCatatoryToAccountsOrCustomer(Convert.ToInt64(ProductCatalogueCategory.categoryID), Convert.ToInt64(num4), (long)0);
                                        }
                                    }
                                }
                                htmlInputCheckBox.Checked = false;
                            }
                        }
                        return;
                    }
                    if (base.Request.Params["mode"].ToString() == "add" && this.hdn_validateflag.Value.ToLower() != "allocatemultiple")
                    {
                        int num5 = 0;
                        this.Err_flag = true;
                        if (this.rdSelectedAll.Checked)
                        {
                            this.catagoryType = "A";
                        }
                        else if (this.rdSelectedCustomer.Checked)
                        {
                            this.catagoryType = "S";
                        }
                        else if (this.rdCustomerNone.Checked)
                        {
                            this.catagoryType = "N";
                        }
                        HttpCookie item = base.Request.Cookies["cke_uploadimageName"];
                        if (item != null)
                        {
                            this.catagoryImage = item["uploadImgname"];
                            item.Expires = DateTime.Now.AddDays(-1);
                            base.Response.Cookies.Add(item);
                        }
                        if (this.Err_flag)
                        {
                            num5 = WebstoreBasePage.ProductCatalogueCategory_Insert_Update((long)0, this.txtCategoryName.Text, this.txtDescription.Text, this.catagoryType, ProductCatalogueCategory.CompanyID, Convert.ToInt64(ProductCatalogueCategory.UserID), this.catagoryImage, Convert.ToInt64(this.ddlCategoryList.SelectedValue), num, Convert.ToBoolean(num1), Convert.ToBoolean(num2));
                            if (this.catagoryImage != "")
                            {
                                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", ProductCatalogueCategory.CompanyID, "//ProductCatalogueCategory//" };
                                string str1 = string.Concat(secureDocPath);
                                string str2 = string.Concat(str1, this.catagoryImage);
                                string str3 = string.Concat(str1, "m_", this.catagoryImage);
                                string str4 = string.Concat(str1, "t_", this.catagoryImage);
                                object[] objArray = new object[] { str1, num5, "_", this.catagoryImage };
                                string str5 = string.Concat(objArray);
                                object[] objArray1 = new object[] { str1, "m_", num5, "_", this.catagoryImage };
                                string str6 = string.Concat(objArray1);
                                object[] objArray2 = new object[] { str1, "t_", num5, "_", this.catagoryImage };
                                string str7 = string.Concat(objArray2);
                                File.Copy(str2, str5);
                                File.Copy(str3, str6);
                                File.Copy(str4, str7);
                                File.Delete(str2);
                                File.Delete(str3);
                                File.Delete(str4);
                            }
                            this.imgToSave = string.Concat(num5, "_", this.catagoryImage);
                            if (this.catagoryImage != "")
                            {
                                this.catagoryImage = string.Concat(num5, this.catagoryImage);
                                object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//", ProductCatalogueCategory.CompanyID, "//ProductCatalogueCategory//", this.imgToSave };
                                string.Concat(secureDocPath1);
                                WebstoreBasePage.ProductCatalogueCategory_UpdateImage(num5, this.imgToSave);
                            }
                            if (this.catagoryType == "S" || this.catagoryType == "A")
                            {
                                long num6 = (long)0;
                                string str8 = "A";
                                for (int m = 0; m < (int)strArrays.Length - 1; m++)
                                {
                                    string[] strArrays4 = strArrays[m].Split(new char[] { '\u00B6' });
                                    if (strArrays4[0] != "" && strArrays4[0] != null)
                                    {
                                        num6 = (long)Convert.ToInt32(strArrays4[0]);
                                        str8 = strArrays4[1].ToString();
                                        num3 = WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert((long)num5, Convert.ToInt64(num6), (long)0, this.catagoryType, (long)0, str8);
                                        if (str8.ToLower() == "s")
                                        {
                                            string[] strArrays5 = strArrays4[2].Split(new char[] { ',' });
                                            for (int n = 0; n < (int)strArrays5.Length; n++)
                                            {
                                                if (strArrays5[n] != null && strArrays5[n] != "")
                                                {
                                                    WebstoreBasePage.ProductCategory_CustomerDepartment_insert(num3, Convert.ToInt64(strArrays5[n]));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            for (int o = 0; o < this.lstStatus.Items.Count; o++)
                            {
                                if (this.lstStatus.Items[o].Checked)
                                {
                                    int num7 = Convert.ToInt32(this.lstStatus.Items[o].Value);
                                    WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(num5), (long)0, Convert.ToInt64(num7), "", (long)0, "A");
                                }
                            }
                            if (this.postback == "")
                            {
                                if (this.hdn_fromflag.Value.ToLower() == "allocate")
                                {
                                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?suc=in&mode=edit&catagoryID=", num5));
                                    return;
                                }
                                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?suc=in&mode=add"));
                            }
                            else if (this.postback.ToLower() == "settings" && this.frompage.ToLower() == "product" && base.Request.Params["postmode"].ToString() == "edit" && (base.Request.Params["id"].ToString() !="" || base.Request.Params["id"].ToString() != null))
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=",base.Request.Params["id"].ToString()));
                                return;
                            }
                            else if (this.postback.ToLower() == "settings" && this.frompage.ToLower() == "product")
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?catid=", num5));
                                return;
                            }
                        }
                    }
                }
                else
                {
                    ProductCatalogueCategory.categoryID = Convert.ToInt32(base.Request.Params["catagoryID"].ToString());
                    if (this.rdSelectedAll.Checked)
                    {
                        this.catagoryType = "A";
                    }
                    else if (this.rdSelectedCustomer.Checked)
                    {
                        this.catagoryType = "S";
                    }
                    else if (this.rdCustomerNone.Checked)
                    {
                        this.catagoryType = "N";
                    }
                    this.Err_flag = true;
                    HttpCookie httpCookie = base.Request.Cookies["cke_uploadimageName"];
                    if (httpCookie != null)
                    {
                        this.imgToSave = httpCookie["uploadImgname"];
                        this.catagoryImage = httpCookie["catagoryImage"];
                        httpCookie.Expires = DateTime.Now.AddDays(-1);
                        base.Response.Cookies.Add(httpCookie);
                    }
                    if (this.Err_flag)
                    {
                        if (this.catagoryImage == "")
                        {
                            WebstoreBasePage.ProductCatalogueCategory_Insert_Update((long)ProductCatalogueCategory.categoryID, base.SpecialEncode(this.txtCategoryName.Text), base.SpecialEncode(this.txtDescription.Text), this.catagoryType, ProductCatalogueCategory.CompanyID, Convert.ToInt64(ProductCatalogueCategory.UserID), this.hdn_catagoryImageName.Value, Convert.ToInt64(this.ddlCategoryList.SelectedValue), num, Convert.ToBoolean(num1), Convert.ToBoolean(num2));
                        }
                        else
                        {
                            WebstoreBasePage.ProductCatalogueCategory_Insert_Update((long)ProductCatalogueCategory.categoryID, base.SpecialEncode(this.txtCategoryName.Text), base.SpecialEncode(this.txtDescription.Text), this.catagoryType, ProductCatalogueCategory.CompanyID, Convert.ToInt64(ProductCatalogueCategory.UserID), this.imgToSave, Convert.ToInt64(this.ddlCategoryList.SelectedValue), num, Convert.ToBoolean(num1), Convert.ToBoolean(num2));
                        }
                        if (this.catagoryType == "S" || this.catagoryType == "A")
                        {
                            if (this.catagoryType == "S" && (int)strArrays.Length > 1)
                            {
                                WebstoreBasePage.pricecatalogue_Categorycustomer_delete(Convert.ToInt64(base.Request.Params["catagoryID"].ToString()), (long)0);
                            }
                            long num8 = (long)0;
                            string str9 = "A";
                            for (int p = 0; p < (int)strArrays.Length - 1; p++)
                            {
                                string[] strArrays6 = strArrays[p].Split(new char[] { '\u00B6' });
                                if (strArrays6[0] != "" && strArrays6[0] != null)
                                {
                                    num8 = (long)Convert.ToInt32(strArrays6[0]);
                                    str9 = strArrays6[1].ToString();
                                    num3 = WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(base.Request.Params["catagoryID"].ToString()), Convert.ToInt64(num8), (long)0, this.catagoryType, (long)0, str9);
                                    string str10 = strArrays6[2];
                                    char[] chrArray = new char[] { ',' };
                                    if ((int)str10.Split(chrArray).Length > 1 && str9.ToLower() == "s")
                                    {
                                        string[] strArrays7 = strArrays6[2].Split(new char[] { ',' });
                                        for (int q = 0; q < (int)strArrays7.Length; q++)
                                        {
                                            if (strArrays7[q] != null && strArrays7[q] != "")
                                            {
                                                WebstoreBasePage.ProductCategory_CustomerDepartment_insert(num3, Convert.ToInt64(strArrays7[q]));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            WebstoreBasePage.ProductCatalogueCategoryCustomer_Delete(Convert.ToInt64(base.Request.Params["catagoryID"].ToString()));
                        }
                        WebstoreBasePage.ProductCatalogueCategoryCustomer_Public_Delete(Convert.ToInt64(base.Request.Params["catagoryID"]));
                        for (int r = 0; r < this.lstStatus.CheckedItems.Count; r++)
                        {
                            long num9 = Convert.ToInt64(this.lstStatus.CheckedItems[r].Value);
                            WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(base.Request.Params["catagoryID"]), (long)0, num9, "", (long)0, "S");
                        }
                        base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?suc=up&mode=add"));
                        return;
                    }
                }
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridView1.MasterTableView.Rebind();
        }

        public void gridBinding(int CompanyID, int UserID, string sortedBy, string sortdirection, string whereCondition, int PageSize, int PageNumber)
        {
            DataSet dataSet = WebstoreBasePage.ProductCatalogueCategory_SelectViewAll(CompanyID, UserID, sortedBy, sortdirection, whereCondition);
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            this.GridView1.DataSource = dataSet;
        }

        private void GridStateLoad()
        {
            this.commclass.GridStateLoadNew("setting", "ProductCatalogueCategory", this.GridView1, "no");
        }

        private void GridStateSave()
        {
            this.commclass.GridStateSaveNew("setting", "ProductCatalogueCategory", this.GridView1);
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            ProductCatalogueCategory.sortedBy = e.SortExpression;
            ProductCatalogueCategory.sortdirection = e.NewSortOrder.ToString();
            if (ProductCatalogueCategory.sortdirection.ToLower() == "ascending")
            {
                ProductCatalogueCategory.sortdirection = "ASC";
            }
            else if (ProductCatalogueCategory.sortdirection.ToLower() != "descending")
            {
                ProductCatalogueCategory.sortdirection = "ASC";
            }
            else
            {
                ProductCatalogueCategory.sortdirection = "DESC";
            }
            this.GridView1.CurrentPageIndex = 0;
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
        }

        protected void imgDelete_click(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            ProductCatalogueCategory.categoryID = Convert.ToInt32(imageButton.CommandArgument.ToString());
            WebstoreBasePage.productCategory_Delete(Convert.ToInt32(ProductCatalogueCategory.categoryID));
            base.Message_Display(this.objlang.GetLanguageConversion("Product_categorys_deleted_successfully"), "msg-success", this.plhMessage_Delete);
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
            this.GridView1.Rebind();
        }

        protected void imgDelete_OnCommand(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.productCategory_Delete(Convert.ToInt32(e.CommandArgument));
            base.Message_Display(this.objlang.GetLanguageConversion("Product_categorys_deleted_successfully"), "msg-success", this.plhMessage_Delete);
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
            this.GridView1.Rebind();
        }

        protected void lnkallocatepublic_onclick(object sender, EventArgs e)
        {
            string value = this.hdn_finalvalues.Value;
            string[] strArrays = this.hdn_finalvalues.Value.Split(new char[] { ',' });
            for (int i = 0; i < this.GridView1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridView1.Items[i].Cells[0].FindControl("checkBox_Copy1");
                if (htmlInputCheckBox.Checked)
                {
                    ProductCatalogueCategory.categoryID = Convert.ToInt32(htmlInputCheckBox.Value);
                    for (int j = 0; j < (int)strArrays.Length - 1; j++)
                    {
                        if (strArrays[j] != "")
                        {
                            WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(ProductCatalogueCategory.categoryID), (long)0, Convert.ToInt64(strArrays[j]), "S", (long)0, "A");
                        }
                    }
                    if (this.hdn_iscopychecked.Value == "true")
                    {
                        for (int k = 0; k < (int)strArrays.Length; k++)
                        {
                            if (strArrays[k] != "")
                            {
                                WebstoreBasePage.Assign_ProductCatatoryToAccountsOrCustomer(Convert.ToInt64(ProductCatalogueCategory.categoryID), (long)0, Convert.ToInt64(strArrays[k]));
                            }
                        }
                    }
                    htmlInputCheckBox.Checked = false;
                }
            }
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridView1.Items[i].Cells[0].FindControl(this.checkBoxID);
                if (htmlInputCheckBox.Checked)
                {
                    ProductCatalogueCategory.categoryID = Convert.ToInt32(htmlInputCheckBox.Value);
                    WebstoreBasePage.productCategory_Delete(ProductCatalogueCategory.categoryID);
                    this.flag = true;
                    htmlInputCheckBox.Checked = false;
                }
            }
            if (this.flag)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Product_categorys_deleted_successfully"), "msg-success", this.plhMessage_Delete);
            }
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
            this.GridView1.Rebind();
        }

        protected void lnkloadCatagory_click(object sender, EventArgs e)
        {
            this.GridView1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Category_Copied_Successfully"), "msg-success", this.plhMessage_Delete);
        }

        protected override void OnInit(EventArgs e)
        {
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.SecureVirtualPath != null)
            {
                this.SecureVirtualPath = ConnectionClass.SecureVirtualPath;
            }
            this.SecDocumentSitePath = this.SecureSitePath;
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
            this.GridView1.Columns[1].HeaderText = this.objlang.GetValueOnLang("Category Name");
            this.GridView1.Columns[2].HeaderText = this.objlang.GetValueOnLang("Description");
            this.GridView1.Columns[3].HeaderText = this.objlang.GetValueOnLang("Parent Category");
            this.GridView1.Columns[4].HeaderText = this.objlang.GetValueOnLang("Action");
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            GridTableView masterTableView = this.GridView1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("div_AddNewRecord");
            if (this.AddStatus.Trim().ToLower() != "false")
            {
                htmlControl.Visible = true;
            }
            else
            {
                htmlControl.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgDelete");
                ImageButton imageButton1 = (ImageButton)e.Item.FindControl("Image_Attachment");
                Label label = (Label)e.Item.FindControl("lblallocatedcust");
                Label label1 = (Label)e.Item.FindControl("lblaccname");
                label1.Text = base.SpecialDecode(((DataRowView)e.Item.DataItem)[8].ToString());
                label1.ToolTip = base.SpecialDecode(((DataRowView)e.Item.DataItem)[8].ToString());
                if (label.Text.ToLower() != "allocated")
                {
                    imageButton1.Visible = false;
                }
                else
                {
                    imageButton1.Visible = true;
                }
                if (this.DeleteStatus.Trim().ToLower() != "false")
                {
                    imageButton.Visible = true;
                }
                else
                {
                    imageButton.Visible = false;
                }
                e.Item.Visible = false;
                QueryString queryString = new QueryString()
			{
				{ "catagoryName", ((DataRowView)e.Item.DataItem)[0].ToString() }
			};
                string str = string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?&mode=edit");
                try
                {
                    ProductCatalogueCategory.categoryID = Convert.ToInt32(((DataRowView)e.Item.DataItem)[2].ToString());
                }
                catch
                {
                }
                str = string.Concat(str, "&categoryID=", this.categoryid_new);
                GridDataItem item = (GridDataItem)e.Item;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCatalogueCategory.objBase.ReturnRoles_Privileges_Tabs("productcatalogue", "isadd", "");
            BaseClass baseClass = new BaseClass();
            this.AddStatus = baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isadd", this.Page.Request.Url.ToString());
            this.DeleteStatus = baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdelete", this.Page.Request.Url.ToString());
            string str = baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isview", this.Page.Request.Url.ToString());
            if (this.AddStatus.Trim().ToLower() != "false")
            {
                this.btnSave.Visible = true;
            }
            else
            {
                this.btnSave.Visible = false;
            }
            if (str.Trim().ToLower() != "false")
            {
                this.Hidefieldset.Visible = true;
            }
            else
            {
                this.Hidefieldset.Visible = false;
            }
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() == "add")
            {
                this.hidmode.Value = base.Request.Params["mode"].ToString();
            }
            this.catagoryType = "N";
            if (ConnectionClass.WebStore != null)
            {
                this.WebStore = ConnectionClass.WebStore.ToString();
            }
            this.gloobj.setpagename("productcatalogue");
            ProductCatalogueCategory.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            ProductCatalogueCategory.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Navigation_Path(string.Concat("<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator' style=text-decoration:underline>", this.objlang.GetLanguageConversion("Products"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Product_Catalogue_Category")));
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue Category", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(ProductCatalogueCategory.CompanyID, "colour");
            if (this.WebStore.ToString().ToLower() == "yes")
            {
                this.checkBoxID = "checkBox_Copy1";
                this.GridView1.MasterTableView.Columns[0].Visible = true;
                this.GridView1.MasterTableView.Columns[1].Visible = false;
                this.div_categoryvisiblefield.Style.Add("display", "block");
            }
            else
            {
                this.checkBoxID = "checkBox_Copy";
                this.GridView1.MasterTableView.Columns[0].Visible = false;
                this.GridView1.MasterTableView.Columns[1].Visible = true;
                this.GridView1.MasterTableView.Columns[6].Visible = false;
                this.div_categoryvisiblefield.Style.Add("display", "none");
            }
            if (this.Session["CategoryID"] == null || !(this.Session["CategoryID"].ToString() != "-----Private-----") || !(this.Session["CategoryID"].ToString() != "-----Public-----"))
            {
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
                this.plhAccountList.Controls.Add(userControl);
                RadWindow radWindow = (RadWindow)userControl.FindControl("cataloguewindow");
                DropDownList dropDownList = radWindow.ContentContainer.FindControl("ddl_accountsList") as DropDownList;
                dropDownList.DataSource = this.objAcc.accountsList(ProductCatalogueCategory.CompanyID);
                dropDownList.DataTextField = "accountName";
                dropDownList.DataValueField = "Categorylist";
                dropDownList.DataBind();
                if (dropDownList.SelectedItem != null)
                {
                    this.Session["accountList"] = dropDownList.SelectedItem.ToString();
                    this.Session["CategoryID"] = dropDownList.SelectedValue.ToString();
                    string[] strArrays = this.Session["CategoryID"].ToString().Split(new char[] { '~' });
                    this.AccountID = Convert.ToInt32(strArrays[0]);
                }
            }
            else if (this.Session["CategoryID"].ToString() != "0")
            {
                string[] strArrays1 = this.Session["CategoryID"].ToString().Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays1[0]);
            }
            ProductCatalogueCategory.sortdirection = "asc";
            if (base.Request.Params["mode"] != null)
            {
                this.action = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit" && base.Request.Params["catagoryID"] != null)
            {
                this.PriceCatalogueCategoryID = Convert.ToInt64(base.Request.Params["catagoryID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
                this.txtCategoryName.Focus();
                this.GridView1.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Category_Name");
                this.GridView1.MasterTableView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Description");
                this.GridView1.MasterTableView.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Parent_Category");
                this.GridView1.MasterTableView.Columns[5].HeaderText = this.objlang.GetLanguageConversion("Allocated_Customers");
                this.GridView1.MasterTableView.Columns[6].HeaderText = this.objlang.GetLanguageConversion("Public_Accounts");
                this.GridView1.MasterTableView.Columns[7].HeaderText = this.objlang.GetLanguageConversion("Action");
                this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
                this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
                DataTable dataTable = WebstoreBasePage.Select_ProductCategory_List((long)ProductCatalogueCategory.CompanyID, "ProductCategory", this.PriceCatalogueCategoryID);
                this.ddlCategoryList.DataSource = dataTable;
                this.ddlCategoryList.DataTextField = "MultiLevelCategory";
                this.ddlCategoryList.DataValueField = "CategoryID";
                this.ddlCategoryList.DataBind();
                DropDownList dropDownList1 = new DropDownList();
                this.objAcc.publicAccount_bind('x', ProductCatalogueCategory.CompanyID, dropDownList1);
                if (this.WebStore.ToLower() != "yes")
                {
                    this.publicAccount_label.Style.Add("display", "none");
                }
                else if (dropDownList1.Items.Count > 0)
                {
                    this.publicAccount_label.Style.Add("display", "block");
                    for (int i = 0; i < dropDownList1.Items.Count; i++)
                    {
                        if (dropDownList1.Items[i].Value == "0")
                        {
                            RadListBoxItem radListBoxItem = new RadListBoxItem();
                            if (i == 0)
                            {
                                radListBoxItem.Text = "";
                                radListBoxItem.Value = "0";
                                this.lstStatus.Items.Add(radListBoxItem);
                            }
                        }
                        else
                        {
                            RadListBoxItem radListBoxItem1 = new RadListBoxItem()
                            {
                                Text = dropDownList1.Items[i].Text,
                                Value = dropDownList1.Items[i].Value
                            };
                            this.lstStatus.Items.Add(radListBoxItem1);
                        }
                    }
                }
                if (this.action != "edit")
                {
                    this.lstStatus.SelectedValue = " None";
                }
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "in")
                    {
                        ProductCatalogueCategory.objBase.Message_Display(this.objlang.GetLanguageConversion("Product_Category_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "del")
                    {
                        ProductCatalogueCategory.objBase.Message_Display(this.objlang.GetLanguageConversion("Product_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "up")
                    {
                        ProductCatalogueCategory.objBase.Message_Display(this.objlang.GetLanguageConversion("Product_Category_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                this.div_changeImage.Visible = false;
                if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit")
                {
                    DataTable dataTable1 = WebstoreBasePage.ProductCatalogueCategory_Select(Convert.ToInt32(base.Request.Params["catagoryID"].ToString()));
                    if (base.Request.Params["catagoryID"] != null)
                    {
                        this.categoryid_new = base.Request.Params["catagoryID"].ToString();
                    }
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        this.txtCategoryName.Text = row["PriceCatalogueCategoryName"].ToString().Trim();
                        this.hdn_categoryName.Value = this.txtCategoryName.Text;
                        this.txtDescription.Text = row["Description"].ToString().Trim();
                        this.catagoryType = row["CategoryType"].ToString().Trim();
                        this.lnkFileName.InnerHtml = row["CategoryImage"].ToString().Trim();
                        QueryString queryString = new QueryString()
					{
						{ "doctype", "category" },
						{ "catid", Convert.ToString(this.PriceCatalogueCategoryID) }
					};
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        this.lnkFileName.HRef = string.Concat(this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim());
                        this.lnkFileName.Target = "_blank";
                        ProductCatalogueCategory.catagoryImageName = row["CategoryImage"].ToString().Trim();
                        this.hdn_catagoryImageName.Value = row["CategoryImage"].ToString().Trim();
                        this.ddlCategoryList.SelectedValue = row["ParentCategoryID"].ToString();
                        if (row["IsCategoryVisible"].ToString().ToLower() != "true")
                        {
                            this.chkvisibletocustomer.Checked = false;
                        }
                        else
                        {
                            this.chkvisibletocustomer.Checked = true;
                        }
                        if (row["IsApprovalNotRequired"].ToString().ToLower() != "true")
                        {
                            this.chkcatagorynotapproval.Checked = false;
                        }
                        else
                        {
                            this.chkcatagorynotapproval.Checked = true;
                        }
                    }
                    if (this.catagoryType == "S")
                    {
                        this.rdSelectedCustomer.Checked = true;
                    }
                    else if (this.catagoryType != "A")
                    {
                        this.rdCustomerNone.Checked = true;
                    }
                    else
                    {
                        this.rdSelectedAll.Checked = true;
                    }
                    if (this.lnkFileName.InnerHtml.Trim() != "")
                    {
                        this.div_changeImage.Visible = true;
                        this.div_fuCategory.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.div_fuCategory.Attributes.Add("style", "display:block");
                        this.div_changeImage.Visible = false;
                    }
                    DataTable dataTable2 = WebstoreBasePage.ProductCatalogueCategoryCustomer_Select(Convert.ToInt64(base.Request.Params["catagoryID"].ToString()), (long)-1);
                    foreach (DataRow dataRow in dataTable2.Rows)
                    {
                        for (int j = 0; j < this.lstStatus.Items.Count; j++)
                        {
                            if (this.lstStatus.Items[j].Value == dataRow[3].ToString())
                            {
                                this.lstStatus.Items[j].Checked = true;
                                this.totalPublicNo_Selected = this.totalPublicNo_Selected + 1;
                            }
                        }
                    }
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.commclass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.commclass.functionCheckChange());
            }
            ImageButton imageButton = (ImageButton)base.Master.FindControl("ImageButton1");
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
            if (base.Request.Params["post"] != null && base.Request.Params["type"] != null)
            {
                this.postback = base.Request.Params["post"].ToString();
                this.frompage = base.Request.Params["type"].ToString();
            }
            AttributeCollection attributes = this.Exclude.Attributes;
            object[] priceCatalogueCategoryID = new object[] { "javascript:openPopUp('E','", this.PriceCatalogueCategoryID, "','", base.SpecialEncode(this.hdn_categoryName.Value.Replace("&", "%26")), "','", this.action, "');" };
            attributes.Add("onclick", string.Concat(priceCatalogueCategoryID));
            AttributeCollection attributeCollection = this.Select.Attributes;
            object[] objArray = new object[] { "javascript:openPopUp('I','", this.PriceCatalogueCategoryID, "','", base.SpecialEncode(this.hdn_categoryName.Value.Replace("&", "%26")), "','", this.action, "');" };
            attributeCollection.Add("onclick", string.Concat(objArray));
            this.divParentCategoryAlloc.Style.Add("display", "none");
            if (Convert.ToInt32(WebstoreBasePage.IsApprovalFeaturesOn_Select((long)ProductCatalogueCategory.CompanyID)) != 1)
            {
                this.div_categoryapproval.Style.Add("display", "none");
            }
            else
            {
                this.div_categoryapproval.Style.Add("display", "block");
            }
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() != "add")
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueCategoryID)] = null;
                }
                else if (!base.IsPostBack)
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueCategoryID)] = null;
                }
            }
            this.rdSelectedCustomer.Text = this.objlang.GetLanguageConversion("Specific_To_Customers");
            this.rdSelectedAll.Text = this.objlang.GetLanguageConversion("All");
            this.rdCustomerNone.Text = this.objlang.GetLanguageConversion("None");
        }

        protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (this.RadMenu1.SelectedValue.ToString() == "Delete")
            {
                for (int i = 0; i < this.GridView1.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.GridView1.Items[i].Cells[0].FindControl(this.checkBoxID);
                    if (htmlInputCheckBox.Checked)
                    {
                        ProductCatalogueCategory.categoryID = Convert.ToInt32(htmlInputCheckBox.Value);
                        WebstoreBasePage.productCategory_Delete(ProductCatalogueCategory.categoryID);
                        this.flag = true;
                        htmlInputCheckBox.Checked = false;
                    }
                }
                if (this.flag)
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Product_categorys_deleted_successfully"), "msg-success", this.plhMessage_Delete);
                }
                this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(this.Session["UserID"].ToString()), ProductCatalogueCategory.sortedBy, ProductCatalogueCategory.sortdirection, ProductCatalogueCategory.whereCondition, this.PageSize, this.PageNumber);
                this.GridView1.Rebind();
            }
        }
    }
}