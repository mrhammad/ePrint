using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.StoreSettings
{
    public partial class account_list : System.Web.UI.UserControl
    {
        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSetting = new SettingsBasePage();

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        protected string EmailToCustomerIDs = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int EmailAccountID;

        public int IsActive;

        public int IsArtwork;

        public int IsOrderPdf;

        public int categoryID;

        public int BannerID;

        public int IsProductName;

        public int IsJobName;

        public int IsQty;

        public int IsTotalPrice;

        public int IsOrderedWidth;

        public int IsOrderedHeight;

        public int IsProductWidth;

        public int IsProductHeight;

        public int IsAdditionalOption;

        public int IsItemNumber;

        public int IsItemCode;

        public int IsCustomerCode;

        public int IsUnitOfMeasure;

        public int IsItemDescription;
        public int IsWeight;
        public int IsCubicMeasurment;
        public int IsOrderedWeight;
        public int IsOrderedCubicMeasurment;
        public int IsPerQuantity;
        public int IsDimensions;
        //public int IsWidth;
        //public int IsHeight;

        public string ServerName = string.Empty;

        public string SelectedAccountID = string.Empty;

        public languageClass objlang = new languageClass();

        public languageClass objLangClass = new languageClass();

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

        public account_list()
        {
        }

        protected void btn_Copy_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().Contains("/productcatalogue/productcataloguecategory.aspx"))
            {
                RadGrid radGrid = (RadGrid)this.Parent.FindControl("GridView1");
                for (int i = 0; i < radGrid.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)radGrid.Items[i].Cells[0].FindControl("checkBox_Copy1");
                    if (htmlInputCheckBox.Checked)
                    {
                        this.categoryID = Convert.ToInt32(htmlInputCheckBox.Value);
                        for (int j = 0; j < this.lstAccountPrivate_popup.Items.Count; j++)
                        {
                            if (this.lstAccountPrivate_popup.Items[j].Selected)
                            {
                                int num = Convert.ToInt32(this.lstAccountPrivate_popup.Items[j].Value);
                                WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(this.categoryID), Convert.ToInt64(num), (long)0, "S", (long)0, "A");
                            }
                        }
                        for (int k = 0; k < this.lstAccountPublic_popup.Items.Count; k++)
                        {
                            if (this.lstAccountPublic_popup.Items[k].Selected)
                            {
                                int num1 = Convert.ToInt32(this.lstAccountPublic_popup.Items[k].Value);
                                WebstoreBasePage.ProductCatalogueCategoryCustomer_Insert(Convert.ToInt64(this.categoryID), (long)0, Convert.ToInt64(num1), "S", (long)0, "A");
                            }
                        }
                        if (this.chk_Copy.Checked)
                        {
                            for (int l = 0; l < this.lstAccountPrivate_popup.Items.Count; l++)
                            {
                                if (this.lstAccountPrivate_popup.Items[l].Selected)
                                {
                                    int num2 = Convert.ToInt32(this.lstAccountPrivate_popup.Items[l].Value);
                                    WebstoreBasePage.Assign_ProductCatatoryToAccountsOrCustomer(Convert.ToInt64(this.categoryID), Convert.ToInt64(num2), (long)0);
                                }
                            }
                            for (int m = 0; m < this.lstAccountPublic_popup.Items.Count; m++)
                            {
                                if (this.lstAccountPublic_popup.Items[m].Selected)
                                {
                                    int num3 = Convert.ToInt32(this.lstAccountPublic_popup.Items[m].Value);
                                    WebstoreBasePage.Assign_ProductCatatoryToAccountsOrCustomer(Convert.ToInt64(this.categoryID), (long)0, Convert.ToInt64(num3));
                                }
                            }
                        }
                        htmlInputCheckBox.Checked = false;
                    }
                }
                this.SetToDefault();
                radGrid.Rebind();
                ScriptManager.RegisterClientScriptBlock(this.up_btnSave, this.up_btnSave.GetType(), "Call", "hideDiv('copy');UnCheckAll();Bind_Grid('catagory');", true);
            }
            if (base.Request.Url.ToString().ToLower().Contains("/productcatalogue/pricecatalogue.aspx"))
            {
                RadGrid radGrid1 = (RadGrid)this.Parent.FindControl("GridPriceCatalogue");
                RadMenu radMenu = (RadMenu)this.Parent.FindControl("RadMenu1");
                for (int n = 0; n < radGrid1.Items.Count; n++)
                {
                    HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox();
                    htmlInputCheckBox1 = (HtmlInputCheckBox)radGrid1.Items[n].Cells[0].FindControl("checkBox_Copy1");
                    if (htmlInputCheckBox1.Checked)
                    {
                        this.categoryID = Convert.ToInt32(htmlInputCheckBox1.Value);
                        if (radMenu.SelectedValue.ToString().ToLower() == "allocate")
                        {
                            for (int o = 0; o < this.lstAccountPrivate_popup.Items.Count; o++)
                            {
                                if (this.lstAccountPrivate_popup.Items[o].Selected)
                                {
                                    int num4 = Convert.ToInt32(this.lstAccountPrivate_popup.Items[o].Value);
                                    WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(this.categoryID), Convert.ToInt64(num4), (long)0, "S");
                                }
                            }
                            for (int p = 0; p < this.lstAccountPublic_popup.Items.Count; p++)
                            {
                                if (this.lstAccountPublic_popup.Items[p].Selected)
                                {
                                    int num5 = Convert.ToInt32(this.lstAccountPublic_popup.Items[p].Value);
                                    WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(this.categoryID), (long)0, Convert.ToInt64(num5), "S");
                                }
                            }
                            base.Session["option"] = "copyto";
                        }
                        if (radMenu.SelectedValue.ToString().ToLower() == "additional")
                        {
                            for (int q = 0; q < this.lstAddOption.Items.Count; q++)
                            {
                                if (this.lstAddOption.Items[q].Selected)
                                {
                                    WebstoreBasePage.settings_Product_CatalogueAdditional_insert(this.CompanyID, Convert.ToInt64(this.categoryID), Convert.ToInt64(this.lstAddOption.Items[q].Value), (long)0);
                                }
                            }
                            base.Session["option"] = "additionoption";
                        }
                        if (radMenu.SelectedValue.ToString().ToLower() == "couponcode")
                        {
                            for (int r = 0; r < this.lst_CouponCode_list.Items.Count; r++)
                            {
                                if (this.lst_CouponCode_list.Items[r].Selected)
                                {
                                    int companyID = this.CompanyID;
                                    long num6 = (long)Convert.ToInt32(htmlInputCheckBox1.Value);
                                    string str = this.lst_CouponCode_list.Items[r].Value.ToString();
                                    char[] chrArray = new char[] { '~' };
                                    WebstoreBasePage.Product_CatalogueCouponCode_insert(companyID, num6, Convert.ToInt64(str.Split(chrArray)[0]));
                                }
                            }
                            base.Session["option"] = "couponcode";
                        }
                        htmlInputCheckBox1.Checked = false;
                    }
                }
                this.SetToDefault();
                radGrid1.Rebind();
                if (base.Session["option"] != null)
                {
                    if (base.Session["option"] == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.up_AddOption, this.up_AddOption.GetType(), "Call", "hideDiv('addoption');hideDiv('copy');UnCheckAll();Bind_Grid('product');", true);
                    }
                    if (base.Session["option"] == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.up_btnSave, this.up_btnSave.GetType(), "Call", "hideDiv('copy');UnCheckAll();Bind_Grid('product');", true);
                    }
                    if (base.Session["option"] == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.up_CouponCode_Allocate_Save, this.up_CouponCode_Allocate_Save.GetType(), "Call", "hideDiv('couponcode');UnCheckAll();Bind_Grid('product');", true);
                    }
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("/storesettings/cart_additional_options_view.aspx"))
            {
                HiddenField hiddenField = (HiddenField)this.Parent.FindControl("hid_Allocate_IDs");
                int num7 = 0;
                if (hiddenField.Value != "")
                {
                    string[] strArrays = hiddenField.Value.Split(new char[] { ',' });
                    for (int s = 0; s < (int)strArrays.Length; s++)
                    {
                        if (strArrays[s].ToString() != "")
                        {
                            num7 = Convert.ToInt32(strArrays[s]);
                            for (int t = 0; t < this.lstAccountPrivate_popup.Items.Count; t++)
                            {
                                if (this.lstAccountPrivate_popup.Items[t].Selected)
                                {
                                    int num8 = Convert.ToInt32(this.lstAccountPrivate_popup.Items[t].Value);
                                    WebstoreBasePage.OtherCost_WebStore_AllocatetoOtherAccounts(num7, num8, "Customer");
                                }
                            }
                            for (int u = 0; u < this.lstAccountPublic_popup.Items.Count; u++)
                            {
                                if (this.lstAccountPublic_popup.Items[u].Selected)
                                {
                                    int num9 = Convert.ToInt32(this.lstAccountPublic_popup.Items[u].Value);
                                    WebstoreBasePage.OtherCost_WebStore_AllocatetoOtherAccounts(num7, num9, "Public");
                                }
                            }
                        }
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options_view.aspx?su=al"));
                }
            }
        }

        protected void btn_CouponCode_Allocate_Save_Click(object sender, EventArgs e)
        {
        }

        public void btn_mngbannerSave(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_banner.aspx"))
            {
                if (base.Request.Cookies["CopyBanners"] != null)
                {
                    if (base.Request.Cookies["CopyBanners"].Value.ToLower() == "home")
                    {
                        RadGrid radGrid = (RadGrid)this.Parent.FindControl("RadGrid_bannerHome");
                        for (int i = 0; i < radGrid.Items.Count; i++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                            htmlInputCheckBox = (HtmlInputCheckBox)radGrid.Items[i].Cells[0].FindControl("checkBox_Home");
                            if (htmlInputCheckBox.Checked)
                            {
                                this.BannerID = Convert.ToInt32(htmlInputCheckBox.Value);
                                for (int j = 0; j < this.list_mngbannerlist.Items.Count; j++)
                                {
                                    if (this.list_mngbannerlist.Items[j].Selected)
                                    {
                                        int num = Convert.ToInt32(this.list_mngbannerlist.Items[j].Value);
                                        this.CopyBannerImageToAccountID(num, this.CompanyID, this.BannerID, "p", "H");
                                    }
                                }
                                htmlInputCheckBox.Checked = false;
                            }
                        }
                        radGrid.Rebind();
                    }
                    if (base.Request.Cookies["CopyBanners"].Value.ToLower() == "left")
                    {
                        RadGrid radGrid1 = (RadGrid)this.Parent.FindControl("RadGrid_bannerLeft");
                        for (int k = 0; k < radGrid1.Items.Count; k++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox();
                            htmlInputCheckBox1 = (HtmlInputCheckBox)radGrid1.Items[k].Cells[0].FindControl("checkBox_Left");
                            if (htmlInputCheckBox1.Checked)
                            {
                                this.BannerID = Convert.ToInt32(htmlInputCheckBox1.Value);
                                for (int l = 0; l < this.list_mngbannerlist.Items.Count; l++)
                                {
                                    if (this.list_mngbannerlist.Items[l].Selected)
                                    {
                                        int num1 = Convert.ToInt32(this.list_mngbannerlist.Items[l].Value);
                                        this.CopyBannerImageToAccountID(num1, this.CompanyID, this.BannerID, "p", "L");
                                    }
                                }
                                htmlInputCheckBox1.Checked = false;
                            }
                        }
                        radGrid1.Rebind();
                    }
                    if (base.Request.Cookies["CopyBanners"].Value.ToLower() == "right")
                    {
                        RadGrid radGrid2 = (RadGrid)this.Parent.FindControl("RadGrid_bannerRight");
                        for (int m = 0; m < radGrid2.Items.Count; m++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox2 = new HtmlInputCheckBox();
                            htmlInputCheckBox2 = (HtmlInputCheckBox)radGrid2.Items[m].Cells[0].FindControl("checkBox_Right");
                            if (htmlInputCheckBox2.Checked)
                            {
                                this.BannerID = Convert.ToInt32(htmlInputCheckBox2.Value);
                                for (int n = 0; n < this.list_mngbannerlist.Items.Count; n++)
                                {
                                    if (this.list_mngbannerlist.Items[n].Selected)
                                    {
                                        int num2 = Convert.ToInt32(this.list_mngbannerlist.Items[n].Value);
                                        this.CopyBannerImageToAccountID(num2, this.CompanyID, this.BannerID, "p", "R");
                                    }
                                }
                                htmlInputCheckBox2.Checked = false;
                            }
                        }
                        radGrid2.Rebind();
                    }
                    this.SetToDefault();
                }
                this.pnlMngbannerupdate.Visible = true;
            }
        }

        public void btn_saveEmail_OnClick(object sender, EventArgs e)
        {
            long num = (long)1;
            long num1 = (long)1;
            string[] strArrays = this.hdn_lst_EmailaccountsList.Value.Split(new char[] { ',' });
            if (base.Session["EmailToCustomerIDs"] != null)
            {
                this.EmailToCustomerIDs = base.Session["EmailToCustomerIDs"].ToString();
            }
            if (base.Session["AccountID"] != null)
            {
                this.AccountID = Convert.ToInt32(base.Session["AccountID"].ToString());
            }
            if (this.EmailToCustomerIDs != "" && this.AccountID != 0)
            {
                string[] strArrays1 = this.EmailToCustomerIDs.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    int num2 = 0;
                    this.EmailAccountID = Convert.ToInt32(strArrays[i]);
                    if (this.EmailAccountID != 0)
                    {
                        for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                        {
                            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, this.AccountID, Convert.ToInt64(strArrays1[num2]), "", "");
                            foreach (DataRow row in customerSelect.Rows)
                            {
                                if (WebstoreBasePage.EmailToCustomer_Update(Convert.ToInt64(strArrays1[num2]), this.CompanyID, this.EmailAccountID, row["Subject"].ToString(), row["Body"].ToString(), this.IsActive, DateTime.Now, "N", "IsFromCopyCheck", this.IsArtwork, this.IsOrderPdf, Convert.ToInt32(row["StatusID"]), this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions) != (long)0)
                                {
                                    continue;
                                }
                                num1 = (long)0;
                                break;
                            }
                            if (num1 > (long)0)
                            {
                                foreach (DataRow dataRow in customerSelect.Rows)
                                {
                                    if (dataRow["IsActive"].ToString().ToLower() != "true")
                                    {
                                        this.IsActive = 0;
                                    }
                                    else
                                    {
                                        this.IsActive = 1;
                                    }
                                    if (dataRow["IsArtwork"].ToString().ToLower() != "true")
                                    {
                                        this.IsArtwork = 0;
                                    }
                                    else
                                    {
                                        this.IsArtwork = 1;
                                    }
                                    if (dataRow["IsOrderPdf"].ToString().ToLower() != "true")
                                    {
                                        this.IsOrderPdf = 0;
                                    }
                                    else
                                    {
                                        this.IsOrderPdf = 1;
                                    }
                                    if (dataRow["IsProductName"].ToString().ToLower() != "true")
                                    {
                                        this.IsProductName = 0;
                                    }
                                    else
                                    {
                                        this.IsProductName = 1;
                                    }
                                    if (dataRow["IsJobName"].ToString().ToLower() != "true")
                                    {
                                        this.IsJobName = 0;
                                    }
                                    else
                                    {
                                        this.IsJobName = 1;
                                    }
                                    if (dataRow["IsQuantity"].ToString().ToLower() != "true")
                                    {
                                        this.IsQty = 0;
                                    }
                                    else
                                    {
                                        this.IsQty = 1;
                                    }
                                    if (dataRow["IsTotalPrice"].ToString().ToLower() != "true")
                                    {
                                        this.IsTotalPrice = 0;
                                    }
                                    else
                                    {
                                        this.IsTotalPrice = 1;
                                    }
                                    if (dataRow["IsOrderedWidth"].ToString().ToLower() != "true")
                                    {
                                        this.IsOrderedWidth = 0;
                                    }
                                    else
                                    {
                                        this.IsOrderedWidth = 1;
                                    }
                                    if (dataRow["IsOrderedHeight"].ToString().ToLower() != "true")
                                    {
                                        this.IsOrderedHeight = 0;
                                    }
                                    else
                                    {
                                        this.IsOrderedHeight = 1;
                                    }
                                    if (dataRow["IsProductWidth"].ToString().ToLower() != "true")
                                    {
                                        this.IsProductWidth = 0;
                                    }
                                    else
                                    {
                                        this.IsProductWidth = 1;
                                    }
                                    if (dataRow["IsProductHeight"].ToString().ToLower() != "true")
                                    {
                                        this.IsProductHeight = 0;
                                    }
                                    else
                                    {
                                        this.IsProductHeight = 1;
                                    }
                                    if (dataRow["IsAdditionalOption"].ToString().ToLower() != "true")
                                    {
                                        this.IsAdditionalOption = 0;
                                    }
                                    else
                                    {
                                        this.IsAdditionalOption = 1;
                                    }
                                    if (dataRow["IsItemNumber"].ToString().ToLower() != "true")
                                    {
                                        this.IsItemNumber = 0;
                                    }
                                    else
                                    {
                                        this.IsItemNumber = 1;
                                    }
                                    if (dataRow["IsItemCode"].ToString().ToLower() != "true")
                                    {
                                        this.IsItemCode = 0;
                                    }
                                    else
                                    {
                                        this.IsItemCode = 1;
                                    }
                                    if (dataRow["IsCustomerCode"].ToString().ToLower() != "true")
                                    {
                                        this.IsCustomerCode = 0;
                                    }
                                    else
                                    {
                                        this.IsCustomerCode = 1;
                                    }
                                    if (dataRow["IsUnitOfMeasure"].ToString().ToLower() != "true")
                                    {
                                        this.IsUnitOfMeasure = 0;
                                    }
                                    else
                                    {
                                        this.IsUnitOfMeasure = 1;
                                    }

                                    if (dataRow["IsItemDescription"].ToString().ToLower() != "true")
                                    {
                                        this.IsItemDescription = 0;
                                    }
                                    else
                                    {
                                        this.IsItemDescription = 1;
                                    }

                                    if (dataRow["IsWeight"].ToString().ToLower() != "true")
                                    {
                                        this.IsWeight = 0;
                                    }
                                    else
                                    {
                                        this.IsWeight = 1;
                                    }
                                    if (dataRow["IsCubicMeasurment"].ToString().ToLower() != "true")
                                    {
                                        this.IsCubicMeasurment = 0;
                                    }
                                    else
                                    {
                                        this.IsCubicMeasurment = 1;
                                    }
                                    if (dataRow["IsOrderedWeight"].ToString().ToLower() != "true")
                                    {
                                        this.IsOrderedWeight = 0;
                                    }
                                    else
                                    {
                                        this.IsOrderedWeight = 1;
                                    }
                                    if (dataRow["IsOrderedCubicMeasurment"].ToString().ToLower() != "true")
                                    {
                                        this.IsOrderedCubicMeasurment = 0;
                                    }
                                    else
                                    {
                                        this.IsOrderedCubicMeasurment = 1;
                                    }
                                    if (dataRow["IsPerQuantity"].ToString().ToLower() != "true")
                                    {
                                        this.IsPerQuantity = 0;
                                    }
                                    else
                                    {
                                        this.IsPerQuantity = 1;
                                    }
                                    if (dataRow["IsDimensions"].ToString().ToLower() != "true")
                                    {
                                        this.IsDimensions = 0;
                                    }
                                    else
                                    {
                                        this.IsDimensions = 1;
                                    }
                                    //if (dataRow["IsWidth"].ToString().ToLower() != "true")
                                    //{
                                    //    this.IsWidth = 0;
                                    //}
                                    //else
                                    //{
                                    //    this.IsWidth = 1;
                                    //}
                                    //if (dataRow["IsHeight"].ToString().ToLower() != "true")
                                    //{
                                    //    this.IsHeight = 0;
                                    //}
                                    //else
                                    //{
                                    //    this.IsHeight = 1;
                                    //}

                                    WebstoreBasePage.EmailToCustomer_Update(Convert.ToInt64(strArrays1[num2]), this.CompanyID, this.EmailAccountID, dataRow["Subject"].ToString(), dataRow["Body"].ToString(), this.IsActive, DateTime.Now, "N", "IsFromCopy", this.IsArtwork, this.IsOrderPdf, Convert.ToInt32(dataRow["StatusID"]), this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
                                    num2++;
                                }
                            }
                        }
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_email.aspx"))
                {
                    if ((int)strArrays.Length > 1 && num1 == (long)0)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email.aspx?&mode=exists"));
                        return;
                    }
                    if ((int)strArrays.Length == 1 && num1 == (long)0)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email.aspx?&mode=exist"));
                        return;
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email.aspx?&mode=copy"));
                }
            }
        }

        public void btn_saveReorder_OnClick(object sender, EventArgs e)
        {
            if (this.ddl_accountsList.SelectedValue != "0")
            {
                if (this.ddl_accountsList.SelectedItem != null)
                {
                    string[] strArrays = this.ddl_accountsList.SelectedValue.ToString().Split(new char[] { '~' });
                    this.hdn_AccountName.Value = this.ddl_accountsList.SelectedItem.ToString();
                    this.hdn_AccountID.Value = strArrays[0].ToString();
                    base.Session["HomeBanner"] = null;
                    base.Session["LeftBanner"] = null;
                    base.Session["RightBanner"] = null;
                    base.Session["AccountType"] = WebstoreBasePage.SelectAccountType(Convert.ToInt32(this.hdn_AccountID.Value));
                    SettingsBasePage.UpdateSelectedAccountID((long)this.UserID, Convert.ToInt64(this.hdn_AccountID.Value));
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/customize_footer.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/customize_footer.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/customize_header.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/customize_header.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/edit_style_sheet.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/edit_style_sheet.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_banner.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_banner.aspx"));
                    return;
                }
                if (!base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx"))
                {
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_email.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_email_edit.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email_edit.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_page.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_page.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_page_edit.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_page_edit.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/payment_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/payment_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/productcategory_reorder.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/productcategory_reorder.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/shipping_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/shipping_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/products_reorder.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/products_reorder.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/termsandconditions.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/TermsAndConditions.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/estore_email_settings.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/estore_email_settings.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/approval_system.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/approval_system.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/registration_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/registration_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/ordering_process.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/ordering_process.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("storesettings/estoredisplaysettings_new.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreDisplaySettings_new.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/cart_additional_options_view.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options_view.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/cart_additional_options.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options.aspx"));
                    }
                }
                else
                {
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=em"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=em"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=bli"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=bli"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=lo"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=lo"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=li"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=li"));
                        return;
                    }
                }
            }
        }

        public void CopyBannerImageToAccountID(int ID, int CompanyID, int BannerID, string AccountType, string Type)
        {
            int d = ID;
            string empty = string.Empty;
            DataSet dataSet = WebstoreBasePage.bannerSelect(BannerID, CompanyID, this.AccountID, Type);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["bannerImage"].ToString().Trim();
            }
            if (AccountType == "p")
            {
                foreach (DataRow dataRow in AccountsBaseClass.accounts_getDetails(ID, CompanyID, 0).Rows)
                {
                    d = Convert.ToInt32(dataRow["accountID"].ToString());
                }
            }
            string str = string.Empty;
            string empty1 = string.Empty;
            object[] secureDocPath = new object[] { this.objBase.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners" };
            string str1 = string.Concat(secureDocPath);
            object[] objArray = new object[] { this.objBase.SecureDocPath, this.ServerName, "//store//", d, "//banners" };
            string str2 = string.Concat(objArray);
            if (!Directory.Exists(str1))
            {
                Directory.CreateDirectory(str1);
            }
            if (!Directory.Exists(str2))
            {
                Directory.CreateDirectory(str2);
            }
            str = empty;
            empty1 = this.ReturnFileName(empty, 0, d);
            if (File.Exists(string.Concat(str1, "//", str)))
            {
                File.Copy(string.Concat(str1, "//", str), string.Concat(str2, "//", empty1));
            }
            WebstoreBasePage.CopyBanners(BannerID, d, Type, empty1);
        }

        protected void ddl_CouponCode_Accountlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyID = this.CompanyID;
            string str = this.ddl_CouponCode_Accountlist.SelectedValue.ToString();
            char[] chrArray = new char[] { '~' };
            this.GetCouponCodeOptionList(companyID, Convert.ToInt32(str.Split(chrArray)[0]));
        }

        public void ddlcategoty_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAdditionalOptionList(this.CompanyID, Convert.ToInt32(this.ddl_categoty.SelectedValue));
        }

        public void GetAccountListForApprovalSystem(DataTable dt)
        {
            this.ddl_accountsList.DataSource = dt;
            this.ddl_accountsList.DataTextField = "displayclientname";
            this.ddl_accountsList.DataValueField = "Categorylist";
            this.ddl_accountsList.DataBind();
            int num = 0;
            int num1 = 1;
            foreach (DataRow row in dt.Rows)
            {
                string str = row["accountType"].ToString();
                if (num == 0 && str == "p")
                {
                    this.ddl_accountsList.Items.Insert(num, "-----Private-----");
                }
                else if (num1 == 1 && str == "x")
                {
                    this.ddl_accountsList.Items.Insert(num + 1, "-----Public-----");
                    num1++;
                }
                num++;
            }
        }

        public void GetAccountListForNonApprovalSystem(DataTable dt)
        {
            this.ddl_accountsList.DataSource = dt;
            this.ddl_accountsList.DataTextField = "DisplayClientName";
            this.ddl_accountsList.DataValueField = "Categorylist";
            this.ddl_accountsList.DataBind();
            int num = 0;
            int num1 = 1;
            foreach (DataRow row in dt.Rows)
            {
                string str = row["accountType"].ToString();
                if (num == 0 && str == "p")
                {
                    this.ddl_accountsList.Items.Insert(num, "-----Private-----");
                }
                else if (num1 == 1 && str == "x")
                {
                    this.ddl_accountsList.Items.Insert(num + 1, "-----Public-----");
                    num1++;
                }
                num++;
            }
        }

        public void GetAccountListList(int CompanyID)
        {
            DataTable dataTable = this.objAcc.accountsList(CompanyID);
            this.ddl_CouponCode_Accountlist.DataSource = dataTable;
            this.ddl_CouponCode_Accountlist.DataTextField = "accountName";
            this.ddl_CouponCode_Accountlist.DataValueField = "Categorylist";
            this.ddl_CouponCode_Accountlist.DataBind();
        }

        public void GetAdditionalOptionList(int CompanyID, int Category)
        {
            DataTable dataTable = WebstoreBasePage.AdditionalOption_Select(CompanyID, Convert.ToInt32(this.ddl_categoty.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                row["WebOtherCostName"] = this.objBase.SpecialDecode(row["WebOtherCostName"].ToString());
            }
            this.lstAddOption.DataSource = dataTable;
            this.lstAddOption.DataTextField = "WebOtherCostName";
            this.lstAddOption.DataValueField = "WebOtherCostID";
            this.lstAddOption.DataBind();
            if (dataTable.Rows.Count == 0)
            {
                this.div_SelectAll.Style.Add("display", "none");
            }
        }

        public void GetCategoryList(int CompanyID)
        {
            DataTable dataTable = SettingsBasePage.settings_othercostcategory_selectall_new(CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["OtherCostCategoryName"] = this.objBase.SpecialDecode(row["OtherCostCategoryName"].ToString());
            }
            this.ddl_categoty.DataSource = dataTable;
            this.ddl_categoty.DataTextField = "OtherCostCategoryName";
            this.ddl_categoty.DataValueField = "OtherCostCategoryID";
            this.ddl_categoty.DataBind();
        }

        public void GetCouponCodeOptionList(int CompanyID, int AccountID)
        {
            DataTable dataTable = WebstoreBasePage.CouponCodeOption_Select(CompanyID, AccountID);
            this.lst_CouponCode_list.DataSource = dataTable;
            this.lst_CouponCode_list.DataTextField = "CouponCodeName";
            this.lst_CouponCode_list.DataValueField = "CouponCodeID";
            this.lst_CouponCode_list.DataBind();
            if (dataTable.Rows.Count == 0)
            {
                this.div_SelectAll.Style.Add("display", "none");
            }
        }

        public void GetPrivateAccountList(int CompanyID)
        {
            DataTable dataTable = this.objAcc.accountsList(CompanyID);
            this.lst_EmailaccountsList.DataSource = dataTable;
            this.lst_EmailaccountsList.DataTextField = "accountName";
            this.lst_EmailaccountsList.DataValueField = "AccountID";
            this.lst_EmailaccountsList.DataBind();
            int num = 0;
            int num1 = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                string str = row["accountType"].ToString();
                if (num == 0 && str == "p")
                {
                    this.lst_EmailaccountsList.Items.Insert(num, "-----Private-----");
                }
                else if (num1 == 1 && str == "x")
                {
                    this.lst_EmailaccountsList.Items.Insert(num + 1, "-----Public-----");
                    num1++;
                }
                num++;
            }
        }

        public void GetPrivateAccountListforMngBanner(int CompanyID)
        {
            DataTable dataTable = this.objAcc.accountsList(CompanyID);
            this.list_mngbannerlist.DataSource = dataTable;
            this.list_mngbannerlist.DataTextField = "DisplayClientName";
            this.list_mngbannerlist.DataValueField = "AccountID";
            this.list_mngbannerlist.DataBind();
            int num = 0;
            int num1 = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                string str = row["accountType"].ToString();
                if (num == 0 && str == "p")
                {
                    this.list_mngbannerlist.Items.Insert(num, "----------- Private ----------");
                }
                else if (num1 == 1 && str == "x")
                {
                    this.list_mngbannerlist.Items.Insert(num + 1, "---------- Public -----------");
                    num1++;
                }
                num++;
            }
        }

        public void GetPublicAccountList(int CompanyID)
        {
            DropDownList dropDownList = new DropDownList();
            this.objAcc.publicAccount_bind('x', CompanyID, dropDownList);
            if (dropDownList.Items.Count > 0)
            {
                for (int i = 0; i < dropDownList.Items.Count; i++)
                {
                    if (dropDownList.Items[i].Value == "0")
                    {
                        ListItem listItem = new ListItem();
                        if (i == 0)
                        {
                            listItem.Text = "none";
                            listItem.Value = "0";
                            this.lstAccountPublic_popup.Items.Add(listItem);
                        }
                    }
                    else
                    {
                        ListItem listItem1 = new ListItem()
                        {
                            Text = dropDownList.Items[i].Text,
                            Value = dropDownList.Items[i].Value
                        };
                        this.lstAccountPublic_popup.Items.Add(listItem1);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_saveReorder.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnSavemngbanner.Attributes.Add("OnClientClick", "javascript:validate();");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            DataTable dataTable = new DataTable();
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (base.Request.Url.ToString().ToLower().Contains("/storesettings/approval_system.aspx") || base.Request.Url.ToString().ToLower().Contains("/storesettings/registration_option.aspx") || base.Request.Url.ToString().ToLower().Contains("/storesettings/ordering_process.aspx"))
            {
                dataTable = this.objAcc.AccountsListforApprovalSystem(this.CompanyID);
                this.GetAccountListForApprovalSystem(dataTable);
            }
            else
            {
                dataTable = this.objAcc.accountsList(this.CompanyID);
                this.GetAccountListForNonApprovalSystem(dataTable);
            }
            if (!base.Request.Url.ToString().ToLower().Contains("productcatalogue/productcataloguecategory.aspx") && !base.Request.Url.ToString().ToLower().Contains("productcatalogue/pricecatalogue.aspx") && dataTable.Rows.Count == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"));
            }
            if (base.Request.Url.ToString().ToLower().Contains("/productcatalogue/productcataloguecategory.aspx"))
            {
                this.div_Copy.Style.Add("display", "block");
            }
            if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_banner.aspx"))
            {
                this.div_accountLocation.Style.Add("display", "block");
            }
            this.cataloguewindow.Title = this.objLangClass.GetLanguageConversion("Customer_List");
            this.RadWindowEmailToCustomer.Title = this.objLangClass.GetLanguageConversion("Email_Accounts_List");
            this.RadWindowShoppingCart.Title = this.objLangClass.GetLanguageConversion("Accounts_List");
            this.RadWindowManageBanner.Title = this.objLangClass.GetLanguageConversion("Accounts_List");
            if (!base.IsPostBack)
            {
                this.GetPrivateAccountList(this.CompanyID);
                this.GetPublicAccountList(this.CompanyID);
                this.GetCategoryList(this.CompanyID);
                this.GetAdditionalOptionList(this.CompanyID, 0);
                this.GetPrivateAccountListforMngBanner(this.CompanyID);
                this.SelectedAccountID = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
                this.GetCouponCodeOptionList(this.CompanyID, 0);
                this.GetAccountListList(this.CompanyID);
            }
            if (this.SelectedAccountID != "")
            {
                this.objBase.SetDDLValue(this.ddl_accountsList, this.SelectedAccountID);
            }
            if (base.Session["EmailToCustomerIDs"] != null)
            {
                this.EmailToCustomerIDs = base.Session["EmailToCustomerIDs"].ToString();
            }
            if (base.Session["AccountID"] != null)
            {
                this.AccountID = Convert.ToInt32(base.Session["AccountID"].ToString());
            }
        }

        public string ReturnFileName(string fileName, int Number, int Account_ID)
        {
            string empty = string.Empty;
            object[] secureDocPath = new object[] { this.objBase.SecureDocPath, this.ServerName, "//store//", Account_ID, "//banners//" };
            string str = string.Concat(secureDocPath);
            string str1 = string.Concat(str, fileName);
            string str2 = fileName.Substring(0, fileName.LastIndexOf("."));
            string str3 = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
            if (!File.Exists(str1))
            {
                empty = fileName;
            }
            else
            {
                string str4 = string.Concat("_", Number.ToString());
                empty = string.Concat(str2, str4, str3);
            }
            if (!File.Exists(string.Concat(str, empty)))
            {
                return empty;
            }
            return this.ReturnFileName(fileName, Number + 1, Account_ID);
        }

        public void SetToDefault()
        {
            for (int i = 0; i < this.lstAccountPrivate_popup.Items.Count; i++)
            {
                this.lstAccountPrivate_popup.Items[i].Selected = false;
            }
            this.href_selectAll_Private_popup.Style.Add("display", "block");
            this.href_selectNone_Private_popup.Style.Add("display", "none");
            for (int j = 0; j < this.lstAccountPublic_popup.Items.Count; j++)
            {
                this.lstAccountPublic_popup.Items[j].Selected = false;
            }
            this.href_selectAll_Public_popup.Style.Add("display", "block");
            this.href_selectNone_Public_popup.Style.Add("display", "none");
            for (int k = 0; k < this.lstAddOption.Items.Count; k++)
            {
                this.lstAddOption.Items[k].Selected = false;
            }
            this.href_selectAll_AddOption.Style.Add("display", "block");
            this.href_selectNone_AddOption.Style.Add("display", "none");
            for (int l = 0; l < this.list_mngbannerlist.Items.Count; l++)
            {
                this.list_mngbannerlist.Items[l].Selected = false;
            }
            this.href_selectAll_All_popup.Style.Add("display", "block");
            this.href_selectNone_All_popup_none.Style.Add("display", "none");
        }
    }
}