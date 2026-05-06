using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.StoreSettings
{
    public partial class manage_email_edit : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string EmailBody = string.Empty;

        public string TagEvent = string.Empty;

        public static string EmailFor;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int IsActive;

        public int IsArtwork;

        public int IsOrderPdf;

        public int IsAttached;

        public int StatusID;

        public long EmailToCustomerID;

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

        public string ServerName = ConnectionClass.ServerName;

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

        static manage_email_edit()
        {
            manage_email_edit.EmailFor = string.Empty;
        }

        public manage_email_edit()
        {
        }

        protected void btn_cancel_click(object sender, EventArgs e)
        {
            base.Response.Redirect("../StoreSettings/manage_email.aspx");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!this.chk_Activate.Checked)
            {
                this.IsActive = 0;
            }
            else
            {
                this.IsActive = 1;
            }
            if (!this.chk_Artwork.Checked)
            {
                this.IsArtwork = 0;
            }
            else
            {
                this.IsArtwork = 1;
            }
            if (!this.chk_OrderPdf.Checked)
            {
                this.IsOrderPdf = 0;
            }
            else
            {
                this.IsOrderPdf = 1;
            }
            if (this.hdnProductName.Value != "")
            {
                if (this.hdnProductName.Value.ToLower() != "true")
                {
                    this.IsProductName = 0;
                }
                else
                {
                    this.IsProductName = 1;
                }
            }
            if (this.hdnJobName.Value != "")
            {
                if (this.hdnJobName.Value.ToLower() != "true")
                {
                    this.IsJobName = 0;
                }
                else
                {
                    this.IsJobName = 1;
                }
            }
            if (this.hdnQty.Value != "")
            {
                if (this.hdnQty.Value.ToLower() != "true")
                {
                    this.IsQty = 0;
                }
                else
                {
                    this.IsQty = 1;
                }
            }
            if (this.hdnTotalPrice.Value != "")
            {
                if (this.hdnTotalPrice.Value.ToLower() != "true")
                {
                    this.IsTotalPrice = 0;
                }
                else
                {
                    this.IsTotalPrice = 1;
                }
            }
            if (this.hdnOrderedWidth.Value != "")
            {
                if (this.hdnOrderedWidth.Value.ToLower() != "true")
                {
                    this.IsOrderedWidth = 0;
                }
                else
                {
                    this.IsOrderedWidth = 1;
                }
            }
            if (this.hdnOrderedHeight.Value != "")
            {
                if (this.hdnOrderedHeight.Value.ToLower() != "true")
                {
                    this.IsOrderedHeight = 0;
                }
                else
                {
                    this.IsOrderedHeight = 1;
                }
            }
            if (this.hdnProductWidth.Value != "")
            {
                if (this.hdnProductWidth.Value.ToLower() != "true")
                {
                    this.IsProductWidth = 0;
                }
                else
                {
                    this.IsProductWidth = 1;
                }
            }
            if (this.hdnProductHeight.Value != "")
            {
                if (this.hdnProductHeight.Value.ToLower() != "true")
                {
                    this.IsProductHeight = 0;
                }
                else
                {
                    this.IsProductHeight = 1;
                }
            }
            if (this.hdnAdditionalOption.Value != "")
            {
                if (this.hdnAdditionalOption.Value.ToLower() != "true")
                {
                    this.IsAdditionalOption = 0;
                }
                else
                {
                    this.IsAdditionalOption = 1;
                }
            }
            if (this.hdnItemNumber.Value != "")
            {
                if (this.hdnItemNumber.Value.ToLower() != "true")
                {
                    this.IsItemNumber = 0;
                }
                else
                {
                    this.IsItemNumber = 1;
                }
            }
            if (this.hdnItemCode.Value != "")
            {
                if (this.hdnItemCode.Value.ToLower() != "true")
                {
                    this.IsItemCode = 0;
                }
                else
                {
                    this.IsItemCode = 1;
                }
            }
            if (this.hdnCustomerCode.Value != "")
            {
                if (this.hdnCustomerCode.Value.ToLower() != "true")
                {
                    this.IsCustomerCode = 0;
                }
                else
                {
                    this.IsCustomerCode = 1;
                }
            }
            if (this.hdnUnitOfMeasure.Value != "")
            {
                if (this.hdnUnitOfMeasure.Value.ToLower() != "true")
                {
                    this.IsUnitOfMeasure = 0;
                }
                else
                {
                    this.IsUnitOfMeasure = 1;
                }
            }
            if (this.hdnItemDescription.Value != "")
            {
                if (this.hdnItemDescription.Value.ToLower() != "true")
                {
                    this.IsItemDescription = 0;
                }
                else
                {
                    this.IsItemDescription = 1;
                }
            }
            if (this.hdnWeight.Value != "")
            {
                if (this.hdnWeight.Value.ToLower() != "true")
                {
                    this.IsWeight = 0;
                }
                else
                {
                    this.IsWeight = 1;
                }
            }
            if (this.hdnCubicMeasurement.Value != "")
            {
                if (this.hdnCubicMeasurement.Value.ToLower() != "true")
                {
                    this.IsCubicMeasurment = 0;
                }
                else
                {
                    this.IsCubicMeasurment = 1;
                }
            }
            if (this.hdnOrderedWeight.Value != "")
            {
                if (this.hdnOrderedWeight.Value.ToLower() != "true")
                {
                    this.IsOrderedWeight = 0;
                }
                else
                {
                    this.IsOrderedWeight = 1;
                }
            }
            if (this.hdnOrderedCubicMeasurement.Value != "")
            {
                if (this.hdnOrderedCubicMeasurement.Value.ToLower() != "true")
                {
                    this.IsOrderedCubicMeasurment = 0;
                }
                else
                {
                    this.IsOrderedCubicMeasurment = 1;
                }
            }
            if (this.hdnPerQuantity.Value != "")
            {
                if (this.hdnPerQuantity.Value.ToLower() != "true")
                {
                    this.IsPerQuantity = 0;
                }
                else
                {
                    this.IsPerQuantity = 1;
                }
            }

            if (this.hdnDimensions.Value != "")
            {
                if (this.hdnDimensions.Value.ToLower() != "true")
                {
                    this.IsDimensions = 0;
                }
                else
                {
                    this.IsDimensions = 1;
                }
            }
            //if (this.hdnWidth.Value != "")
            //{
            //    if (this.hdnWidth.Value.ToLower() != "true")
            //    {
            //        this.IsWidth = 0;
            //    }
            //    else
            //    {
            //        this.IsWidth = 1;
            //    }
            //}
            //if (this.hdnHeight.Value != "")
            //{
            //    if (this.hdnHeight.Value.ToLower() != "true")
            //    {
            //        this.IsHeight = 0;
            //    }
            //    else
            //    {
            //        this.IsHeight = 1;
            //    }
            //}
            if (manage_email_edit.EmailFor.ToLower() == "admin")
            {
                WebstoreBasePage.EmailToCustomer_Update(this.EmailToCustomerID, this.CompanyID, 0, base.SpecialEncode(this.txt_Subject.Text.Trim()), this.RadEditor1.Content.Trim(), this.IsActive, DateTime.Now, "N", "", this.IsArtwork, this.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure,this.IsItemDescription,this.IsWeight,this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
                base.Response.Redirect("../StoreSettings/manage_email.aspx?mode=suc");
                return;
            }
            if (this.lbl_EventValue.Text.ToLower() != "order shipping")
            {
                WebstoreBasePage.EmailToCustomer_Update(this.EmailToCustomerID, this.CompanyID, this.AccountID, this.txt_Subject.Text.Trim(), this.RadEditor1.Content.Trim(), this.IsActive, DateTime.Now, "N", "", this.IsArtwork, this.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
                base.Response.Redirect("../StoreSettings/manage_email.aspx?mode=suc");
                return;
            }
            WebstoreBasePage.EmailToCustomer_Update(this.EmailToCustomerID, this.CompanyID, this.AccountID, this.txt_Subject.Text.Trim(), this.RadEditor1.Content.Trim(), this.IsActive, DateTime.Now, "N", "", this.IsArtwork, this.IsOrderPdf, Convert.ToInt32(this.ddlStatus.SelectedValue), this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            base.Response.Redirect("../StoreSettings/manage_email.aspx?mode=suc");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_cancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            this.btn_submit.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor1.ImageManager.UploadPaths = strArrays1;
            this.RadEditor1.ImageManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.UploadPaths = strArrays1;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays1;
            this.RadEditor1.Height = Unit.Pixel(400);
            this.RadEditor1.Width = Unit.Pixel(700);
            this.RadEditor1.EnableFilter(EditorFilters.MakeUrlsAbsolute);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
            this.plhAccountList.Controls.Add(userControl);
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str == "")
            {
                DropDownList dropDownList = (DropDownList)userControl.FindControl("ddl_accountsList");
                dropDownList.DataSource = this.objAcc.accountsList(this.CompanyID);
                dropDownList.DataTextField = "accountName";
                dropDownList.DataValueField = "Categorylist";
                dropDownList.DataBind();
                this.objBase.SetDDLValue(dropDownList, str.ToString());
                char[] chrArray = new char[] { '~' };
                this.AccountID = Convert.ToInt32(str.Split(chrArray)[0]);
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Select");
            }
            else
            {
                string[] strArrays2 = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays2[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays2[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a> > <a href=../StoreSettings/manage_email.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Manage_Emails"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Manage_Email_Edit")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Manage Email Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Email_Edit");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (base.Request.Params["id"] != null)
            {
                this.EmailToCustomerID = Convert.ToInt64(base.Request.Params["id"]);
            }
            this.txt_Subject.Focus();
            if (!base.IsPostBack)
            {
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, this.AccountID, this.EmailToCustomerID, "", "");
                foreach (DataRow row in customerSelect.Rows)
                {
                    this.lbl_EventValue.Text = row["Event"].ToString();
                    this.TagEvent = row["Event"].ToString();
                    this.txt_Subject.Text = base.SpecialDecode(row["Subject"].ToString());
                    this.EmailBody = row["Body"].ToString();
                    this.RadEditor1.Content = row["Body"].ToString();
                    manage_email_edit.EmailFor = row["EmailFor"].ToString();
                    this.StatusID = Convert.ToInt32(row["StatusID"].ToString());
                    if (row["IsProductName"].ToString().ToLower() == "true")
                    {
                        this.hdnProductName.Value = "true";
                    }
                    if (row["IsJobName"].ToString().ToLower() == "true")
                    {
                        this.hdnJobName.Value = "true";
                    }
                    if (row["IsQuantity"].ToString().ToLower() == "true")
                    {
                        this.hdnQty.Value = "true";
                    }
                    if (row["IsTotalPrice"].ToString().ToLower() == "true")
                    {
                        this.hdnTotalPrice.Value = "true";
                    }
                    if (row["IsOrderedWidth"].ToString().ToLower() == "true")
                    {
                        this.hdnOrderedWidth.Value = "true";
                    }
                    if (row["IsOrderedHeight"].ToString().ToLower() == "true")
                    {
                        this.hdnOrderedHeight.Value = "true";
                    }
                    if (row["IsProductWidth"].ToString().ToLower() == "true")
                    {
                        this.hdnProductWidth.Value = "true";
                    }
                    if (row["IsProductHeight"].ToString().ToLower() == "true")
                    {
                        this.hdnProductHeight.Value = "true";
                    }
                    if (row["IsAdditionalOption"].ToString().ToLower() == "true")
                    {
                        this.hdnAdditionalOption.Value = "true";
                    }
                    if (row["IsItemNumber"].ToString().ToLower() == "true")
                    {
                        this.hdnItemNumber.Value = "true";
                    }
                    if (row["IsItemCode"].ToString().ToLower() == "true")
                    {
                        this.hdnItemCode.Value = "true";
                    }
                    if (row["IsCustomerCode"].ToString().ToLower() == "true")
                    {
                        this.hdnCustomerCode.Value = "true";
                    }
                    if (row["IsUnitOfMeasure"].ToString().ToLower() == "true")
                    {
                        this.hdnUnitOfMeasure.Value = "true";
                    }

                    if (row["IsItemDescription"].ToString().ToLower() == "true")
                    {
                        this.hdnItemDescription.Value = "true";
                    }
                    
                    if (row["IsWeight"].ToString().ToLower() == "true")
                    {
                        this.hdnWeight.Value = "true";
                    }
                    if (row["IsCubicMeasurment"].ToString().ToLower() == "true")
                    {
                        this.hdnCubicMeasurement.Value = "true";
                    }
                    if (row["IsOrderedWeight"].ToString().ToLower() == "true")
                    {
                        this.hdnOrderedWeight.Value = "true";
                    }
                    if (row["IsOrderedCubicMeasurment"].ToString().ToLower() == "true")
                    {
                        this.hdnOrderedCubicMeasurement.Value = "true";
                    }
                    if (row["IsPerQuantity"].ToString().ToLower() == "true")
                    {
                        this.hdnPerQuantity.Value = "true";
                    }
                    if (row["IsDimensions"].ToString().ToLower() == "true")
                    {
                        this.hdnDimensions.Value = "true";
                    }
                    //if (row["IsWidth"].ToString().ToLower() == "true")
                    //{
                    //    this.hdnWidth.Value = "true";
                    //}
                    //if (row["IsHeight"].ToString().ToLower() == "true")
                    //{
                    //    this.hdnHeight.Value = "true";
                    //}
                    if (row["IsActive"].ToString().ToLower() != "true")
                    {
                        this.chk_Activate.Checked = false;
                    }
                    else
                    {
                        this.chk_Activate.Checked = true;
                    }
                    if (row["IsArtwork"].ToString().ToLower() != "true")
                    {
                        this.chk_Artwork.Checked = false;
                    }
                    else
                    {
                        this.chk_Artwork.Checked = true;
                    }
                    if (row["IsOrderPdf"].ToString().ToLower() != "true")
                    {
                        this.chk_OrderPdf.Checked = false;
                    }
                    else
                    {
                        this.chk_OrderPdf.Checked = true;
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "order shipping")
                    {
                        this.div_status.Style.Add("display", "block");
                        this.divOrderShipping.Style.Add("display", "block");
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "new user registration" || this.lbl_EventValue.Text.ToLower() == "password reminder email")
                    {
                        this.div_Artwork.Style.Add("display", "none");
                        this.lbl_selectAccount.Visible = false;
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "new order")
                    {
                        this.lbl_selectAccount.Visible = false;
                        this.div_Artwork.Style.Add("display", "block");
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "new b2b contact registration")
                    {
                        this.div_Artwork.Style.Add("display", "none");
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "thank you for your order")
                    {
                        this.div_Artwork.Style.Add("display", "block");
                    }
                    if (this.lbl_EventValue.Text.ToLower() == "b2b new user registration" || this.lbl_EventValue.Text.ToLower() == "b2b user profile modification" || this.lbl_EventValue.Text.ToLower() == "new b2b order" || this.lbl_EventValue.Text.ToLower() == "b2b user profile modified approved" || this.lbl_EventValue.Text.ToLower() == "b2b user profile modified rejected" || this.lbl_EventValue.Text.ToLower() == "b2b user order approval" || this.lbl_EventValue.Text.ToLower() == "b2b user order rejection" || this.lbl_EventValue.Text.ToLower() == "b2b new user registration approval pending")
                    {
                        this.div_Artwork.Style.Add("display", "none");
                    }
                    if (this.lbl_EventValue.Text.ToLower() != "b2b new user rejection")
                    {
                        continue;
                    }
                    this.div_Artwork.Style.Add("display", "none");
                    this.div_note.Style.Add("display", "none");
                }
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "--- Select ---", "job");
                for (int i = 0; i < this.ddlStatus.Items.Count; i++)
                {
                    if (Convert.ToInt32(this.ddlStatus.Items[i].Value) == this.StatusID)
                    {
                        this.ddlStatus.SelectedIndex = i;
                    }
                }
            }
            this.Tags_Select(this.TagEvent.Trim());
        }

        protected void RadGrid_CustomTags_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                Label label = (Label)e.Item.FindControl("lbl_TagEvent");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_TagEvent");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_TagName");
                CheckBox languageConversion = (CheckBox)e.Item.FindControl("chkProductName");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkJobName");
                CheckBox languageConversion1 = (CheckBox)e.Item.FindControl("chkQty");
                CheckBox checkBox1 = (CheckBox)e.Item.FindControl("chkTotalprice");
                CheckBox languageConversion2 = (CheckBox)e.Item.FindControl("chkOrderedHeight");
                CheckBox checkBox2 = (CheckBox)e.Item.FindControl("chkOrderedWidth");
                CheckBox languageConversion3 = (CheckBox)e.Item.FindControl("chkProductHeight");
                CheckBox checkBox3 = (CheckBox)e.Item.FindControl("chkProductWidth");
                CheckBox languageConversion4 = (CheckBox)e.Item.FindControl("chkAdditionalOptions");
                CheckBox checkBox4 = (CheckBox)e.Item.FindControl("chkOrderItemNumbers");
                CheckBox languageConversion5 = (CheckBox)e.Item.FindControl("chkItemCode");
                CheckBox checkBox5 = (CheckBox)e.Item.FindControl("chkCustomerCode");
                CheckBox languageConversion6 = (CheckBox)e.Item.FindControl("chkUnitOfMeasure");

                CheckBox checkBox6 = (CheckBox)e.Item.FindControl("chkItemDescription");
                CheckBox languageConversion7 = (CheckBox)e.Item.FindControl("chkWeight");
                CheckBox checkBox7 = (CheckBox)e.Item.FindControl("chkCubicMeasurement");
                CheckBox languageConversion8 = (CheckBox)e.Item.FindControl("chkOrderedWeight");
                CheckBox checkBox8 = (CheckBox)e.Item.FindControl("chkOrderedCubicMeasurement");
                CheckBox languageConversion9 = (CheckBox)e.Item.FindControl("chkPerQuantity");
                CheckBox checkBox9 = (CheckBox)e.Item.FindControl("chkDimensions");
                //CheckBox languageConversion10 = (CheckBox)e.Item.FindControl("chkWidth");
                //CheckBox checkBox10 = (CheckBox)e.Item.FindControl("chkHeight");


                Label label1 = (Label)e.Item.FindControl("lbl_Helptext");
                if (hiddenField.Value == "[$PRODUCT_DETAILS$]" || hiddenField.Value == "[$ORDER_LINK$]" || hiddenField.Value == "[$STORE_LINK$]" || hiddenField.Value == "[$URL$]" || hiddenField.Value == "[$CART_ADDITIONALOPTIONNAME$]" || hiddenField.Value == "[$CART_ADDITIONALOPTIONVALUE$]" || hiddenField.Value == "[$CART_ADDITIONALOPTION$]")
                {
                    label.Text = " <span style='color:red;'>*</span>";
                }
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, this.AccountID, this.EmailToCustomerID, "", "");
                foreach (DataRow row in customerSelect.Rows)
                {
                    if (row["IsProductName"].ToString().ToLower() != "true")
                    {
                        languageConversion.Checked = false;
                        this.hdnProductName.Value = "false";
                    }
                    else
                    {
                        languageConversion.Checked = true;
                        this.hdnProductName.Value = "true";
                    }
                    if (row["IsJobName"].ToString().ToLower() != "true")
                    {
                        checkBox.Checked = false;
                        this.hdnJobName.Value = "false";
                    }
                    else
                    {
                        checkBox.Checked = true;
                        this.hdnJobName.Value = "true";
                    }
                    if (row["IsQuantity"].ToString().ToLower() != "true")
                    {
                        languageConversion1.Checked = false;
                        this.hdnQty.Value = "false";
                    }
                    else
                    {
                        languageConversion1.Checked = true;
                        this.hdnQty.Value = "true";
                    }
                    if (row["IsTotalPrice"].ToString().ToLower() != "true")
                    {
                        checkBox1.Checked = false;
                        this.hdnTotalPrice.Value = "false";
                    }
                    else
                    {
                        checkBox1.Checked = true;
                        this.hdnTotalPrice.Value = "true";
                    }
                    if (row["IsOrderedWidth"].ToString().ToLower() != "true")
                    {
                        checkBox2.Checked = false;
                        this.hdnOrderedWidth.Value = "false";
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        this.hdnOrderedWidth.Value = "true";
                    }
                    if (row["IsOrderedHeight"].ToString().ToLower() != "true")
                    {
                        languageConversion2.Checked = false;
                        this.hdnOrderedHeight.Value = "false";
                    }
                    else
                    {
                        languageConversion2.Checked = true;
                        this.hdnOrderedHeight.Value = "true";
                    }
                    if (row["IsProductWidth"].ToString().ToLower() != "true")
                    {
                        checkBox3.Checked = false;
                        this.hdnProductWidth.Value = "false";
                    }
                    else
                    {
                        checkBox3.Checked = true;
                        this.hdnProductWidth.Value = "true";
                    }
                    if (row["IsProductHeight"].ToString().ToLower() != "true")
                    {
                        languageConversion3.Checked = false;
                        this.hdnProductHeight.Value = "false";
                    }
                    else
                    {
                        languageConversion3.Checked = true;
                        this.hdnProductHeight.Value = "true";
                    }
                    if (row["IsAdditionalOption"].ToString().ToLower() != "true")
                    {
                        languageConversion4.Checked = false;
                        this.hdnAdditionalOption.Value = "false";
                    }
                    else
                    {
                        languageConversion4.Checked = true;
                        this.hdnAdditionalOption.Value = "true";
                    }
                    if (row["IsItemNumber"].ToString().ToLower() != "true")
                    {
                        checkBox4.Checked = false;
                        this.hdnItemNumber.Value = "false";
                    }
                    else
                    {
                        checkBox4.Checked = true;
                        this.hdnItemNumber.Value = "true";
                    }
                    if (row["IsItemCode"].ToString().ToLower() != "true")
                    {
                        languageConversion5.Checked = false;
                        this.hdnItemCode.Value = "false";
                    }
                    else
                    {
                        languageConversion5.Checked = true;
                        this.hdnItemCode.Value = "true";
                    }
                    if (row["IsCustomerCode"].ToString().ToLower() != "true")
                    {
                        checkBox5.Checked = false;
                        this.hdnCustomerCode.Value = "false";
                    }
                    else
                    {
                        checkBox5.Checked = true;
                        this.hdnCustomerCode.Value = "true";
                    }
                    if (row["IsUnitOfMeasure"].ToString().ToLower() != "true")
                    {
                        languageConversion6.Checked = false;
                        this.hdnUnitOfMeasure.Value = "false";
                    }
                    else
                    {
                        languageConversion6.Checked = true;
                        this.hdnUnitOfMeasure.Value = "true";
                    }



                    if (row["IsItemDescription"].ToString().ToLower() != "true")
                    {
                        checkBox6.Checked = false;
                        this.hdnItemDescription.Value = "false";
                    }
                    else
                    {
                        checkBox6.Checked = true;
                        this.hdnItemDescription.Value = "true";
                    }
                    if (row["IsWeight"].ToString().ToLower() != "true")
                    {
                        languageConversion7.Checked = false;
                        this.hdnWeight.Value = "false";
                    }
                    else
                    {
                        languageConversion7.Checked = true;
                        this.hdnWeight.Value = "true";
                    }
                    if (row["IsCubicMeasurment"].ToString().ToLower() != "true")
                    {
                        checkBox7.Checked = false;
                        this.hdnCubicMeasurement.Value = "false";
                    }
                    else
                    {
                        checkBox7.Checked = true;
                        this.hdnCubicMeasurement.Value = "true";
                    }
                    if (row["IsOrderedWeight"].ToString().ToLower() != "true")
                    {
                        languageConversion8.Checked = false;
                        this.hdnOrderedWeight.Value = "false";
                    }
                    else
                    {
                        languageConversion8.Checked = true;
                        this.hdnOrderedWeight.Value = "true";
                    }
                    if (row["IsOrderedCubicMeasurment"].ToString().ToLower() != "true")
                    {
                        checkBox8.Checked = false;
                        this.hdnOrderedCubicMeasurement.Value = "false";
                    }
                    else
                    {
                        checkBox8.Checked = true;
                        this.hdnOrderedCubicMeasurement.Value = "true";
                    }
                    if (row["IsPerQuantity"].ToString().ToLower() != "true")
                    {
                        languageConversion9.Checked = false;
                        this.hdnPerQuantity.Value = "false";
                    }
                    else
                    {
                        languageConversion9.Checked = true;
                        this.hdnPerQuantity.Value = "true";
                    }

                    if (row["IsDimensions"].ToString().ToLower() != "true")
                    {
                        checkBox9.Checked = false;
                        this.hdnDimensions.Value = "false";
                    }
                    else
                    {
                        checkBox9.Checked = true;
                        this.hdnDimensions.Value = "true";
                    }
                    //if (row["IsWidth"].ToString().ToLower() != "true")
                    //{
                    //    languageConversion10.Checked = false;
                    //    this.hdnWidth.Value = "false";
                    //}
                    //else
                    //{
                    //    languageConversion10.Checked = true;
                    //    this.hdnWidth.Value = "true";
                    //}
                    //if (row["IsHeight"].ToString().ToLower() != "true")
                    //{
                    //    checkBox10.Checked = false;
                    //    this.hdnHeight.Value = "false";
                    //}
                    //else
                    //{
                    //    checkBox10.Checked = true;
                    //    this.hdnHeight.Value = "true";
                    //}
                   


                }
                if (hiddenField1.Value == "New Order" && hiddenField.Value == "[$PRODUCT_DETAILS$]")
                {
                    this.RadGrid_CustomTags.Attributes.Add("style", "width:1050px");
                    label1.Visible = true;
                    languageConversion.Visible = true;
                    checkBox.Visible = true;
                    languageConversion1.Visible = true;
                    checkBox1.Visible = true;
                    languageConversion2.Visible = true;
                    checkBox2.Visible = true;
                    languageConversion3.Visible = true;
                    checkBox3.Visible = true;
                    languageConversion4.Visible = true;
                    checkBox4.Visible = true;
                    languageConversion5.Visible = true;
                    checkBox5.Visible = true;
                    languageConversion6.Visible = true;

                    checkBox6.Visible = true;
                    languageConversion7.Visible = true;
                    checkBox7.Visible = true;
                    languageConversion8.Visible = true;
                    checkBox8.Visible = true;
                    languageConversion9.Visible = true;
                    checkBox9.Visible = true;
                    //languageConversion10.Visible = true;
                    //checkBox10.Visible = true;

                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Product_Name");
                    checkBox.Text = this.objLanguage.GetLanguageConversion("Job_Name");
                    languageConversion1.Text = this.objLanguage.GetLanguageConversion("Quantity_s");
                    checkBox1.Text = this.objLanguage.GetLanguageConversion("Total_Price_IncTax");
                    languageConversion2.Text = this.objLanguage.GetLanguageConversion("Ordered_Height");
                    checkBox2.Text = this.objLanguage.GetLanguageConversion("Ordered_Width");
                    languageConversion3.Text = this.objLanguage.GetLanguageConversion("Product_Height");
                    checkBox3.Text = this.objLanguage.GetLanguageConversion("Product_Width");
                    languageConversion4.Text = this.objLanguage.GetLanguageConversion("Additional_Options");
                    checkBox4.Text = this.objLanguage.GetLanguageConversion("Item_Number");
                    languageConversion5.Text = this.objLanguage.GetLanguageConversion("Item_Code");
                    checkBox5.Text = this.objLanguage.GetLanguageConversion("p_Customer_code");
                    //this.objLanguage.GetLanguageConversion("Unit_Of_Measure");
                    languageConversion6.Text = "Sold In Packs Of.";

                    checkBox6.Text = "Item Description";
                    languageConversion7.Text = "Weight";
                    checkBox7.Text = "Cubic Measurement";
                    languageConversion8.Text = "Ordered Weight";
                    checkBox8.Text = "Ordered Cubic Measurement";
                    languageConversion9.Text = "Per Quantity";
                    checkBox9.Text = "Dimensions";
                    //languageConversion10.Text = "Width";
                    //checkBox10.Text = "Height";

                }
                if (hiddenField1.Value == "Thank you for your order" && hiddenField.Value == "[$PRODUCT_DETAILS$]")
                {
                    this.RadGrid_CustomTags.Attributes.Add("style", "width:1050px");
                    label1.Visible = true;
                    languageConversion.Visible = true;
                    checkBox.Visible = true;
                    languageConversion1.Visible = true;
                    checkBox1.Visible = true;
                    languageConversion2.Visible = true;
                    checkBox2.Visible = true;
                    languageConversion3.Visible = true;
                    checkBox3.Visible = true;
                    languageConversion4.Visible = true;
                    checkBox4.Visible = true;
                    languageConversion5.Visible = true;
                    checkBox5.Visible = true;
                    languageConversion6.Visible = true;

                    checkBox6.Visible = true;
                    languageConversion7.Visible = true;
                    checkBox7.Visible = true;
                    languageConversion8.Visible = true;
                    checkBox8.Visible = true;
                    languageConversion9.Visible = true;
                    checkBox9.Visible = true;
                    //languageConversion10.Visible = true;
                    //checkBox10.Visible = true;

                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Product_Name");
                    checkBox.Text = this.objLanguage.GetLanguageConversion("Job_Name");
                    languageConversion1.Text = this.objLanguage.GetLanguageConversion("Quantity_s");
                    checkBox1.Text = this.objLanguage.GetLanguageConversion("Total_Price_IncTax");
                    languageConversion2.Text = this.objLanguage.GetLanguageConversion("Ordered_Height");
                    checkBox2.Text = this.objLanguage.GetLanguageConversion("Ordered_Width");
                    languageConversion3.Text = this.objLanguage.GetLanguageConversion("Product_Height");
                    checkBox3.Text = this.objLanguage.GetLanguageConversion("Product_Width");
                    languageConversion4.Text = this.objLanguage.GetLanguageConversion("Additional_Options");
                    checkBox4.Text = this.objLanguage.GetLanguageConversion("Item_Number");
                    languageConversion5.Text = this.objLanguage.GetLanguageConversion("Item_Code");
                    checkBox5.Text = this.objLanguage.GetLanguageConversion("p_Customer_code");
                    //this.objLanguage.GetLanguageConversion("Unit_Of_Measure");
                    languageConversion6.Text = "Sold In Packs Of.";

                    checkBox6.Text = "Item Description";
                    languageConversion7.Text = "Weight";
                    checkBox7.Text = "Cubic Measurement";
                    languageConversion8.Text = "Ordered Weight";
                    checkBox8.Text = "Ordered Cubic Measurement";
                    languageConversion9.Text = "Per Quantity";
                    checkBox9.Text = "Dimensions";
                    //languageConversion10.Text = "Width";
                    //checkBox10.Text = "Height";

                }
                if (hiddenField1.Value == "Order Shipping" && hiddenField.Value == "[$PRODUCT_DETAILS$]")
                {
                    this.RadGrid_CustomTags.Attributes.Add("style", "width:1050px");
                    label1.Visible = true;
                    languageConversion.Visible = true;
                    checkBox.Visible = true;
                    languageConversion1.Visible = true;
                    checkBox1.Visible = true;
                    languageConversion2.Visible = true;
                    checkBox2.Visible = true;
                    languageConversion3.Visible = true;
                    checkBox3.Visible = true;
                    languageConversion4.Visible = true;
                    checkBox4.Visible = true;
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Product_Name");
                    checkBox.Text = this.objLanguage.GetLanguageConversion("Job_Name");
                    languageConversion1.Text = this.objLanguage.GetLanguageConversion("Quantity_s");
                    checkBox1.Text = this.objLanguage.GetLanguageConversion("Total_Price_IncTax");
                    languageConversion2.Text = this.objLanguage.GetLanguageConversion("Ordered_Height");
                    checkBox2.Text = this.objLanguage.GetLanguageConversion("Ordered_Width");
                    languageConversion3.Text = this.objLanguage.GetLanguageConversion("Product_Height");
                    checkBox3.Text = this.objLanguage.GetLanguageConversion("Product_Width");
                    languageConversion4.Text = this.objLanguage.GetLanguageConversion("Additional_Options");
                    checkBox4.Text = this.objLanguage.GetLanguageConversion("Item_Number");
                }
                if (hiddenField1.Value == "Back Order" && hiddenField.Value == "[$PRODUCT_DETAILS$]")
                {
                    this.RadGrid_CustomTags.Attributes.Add("style", "width:1050px");
                    label1.Visible = true;
                    languageConversion.Visible = true;
                    checkBox.Visible = true;
                    languageConversion1.Visible = true;
                    checkBox1.Visible = true;
                    languageConversion2.Visible = true;
                    checkBox2.Visible = true;
                    languageConversion3.Visible = true;
                    checkBox3.Visible = true;
                    languageConversion4.Visible = true;
                    languageConversion5.Visible = true;
                    checkBox5.Visible = true;
                    languageConversion6.Visible = true;
                    checkBox4.Visible = true;

                    checkBox6.Visible = true;
                    languageConversion7.Visible = true;
                    checkBox7.Visible = true;
                    languageConversion8.Visible = true;
                    checkBox8.Visible = true;
                    languageConversion9.Visible = true;
                    checkBox9.Visible = true;

                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Product_Name");
                    checkBox.Text = this.objLanguage.GetLanguageConversion("Job_Name");
                    languageConversion1.Text = this.objLanguage.GetLanguageConversion("Quantity_s");
                    checkBox1.Text = this.objLanguage.GetLanguageConversion("Total_Price_IncTax");
                    languageConversion2.Text = this.objLanguage.GetLanguageConversion("Ordered_Height");
                    checkBox2.Text = this.objLanguage.GetLanguageConversion("Ordered_Width");
                    languageConversion3.Text = this.objLanguage.GetLanguageConversion("Product_Height");
                    checkBox3.Text = this.objLanguage.GetLanguageConversion("Product_Width");
                    languageConversion4.Text = this.objLanguage.GetLanguageConversion("Additional_Options");
                    checkBox4.Text = this.objLanguage.GetLanguageConversion("Item_Number");
                    languageConversion5.Text = this.objLanguage.GetLanguageConversion("Item_Code");
                    checkBox5.Text = this.objLanguage.GetLanguageConversion("p_Customer_code");
                    languageConversion6.Text = "Sold In Packs Of.";

                    checkBox6.Text = "Item Description";
                    languageConversion7.Text = "Weight";
                    checkBox7.Text = "Cubic Measurement";
                    languageConversion8.Text = "Ordered Weight";
                    checkBox8.Text = "Ordered Cubic Measurement";
                    languageConversion9.Text = "Per Quantity";
                    checkBox9.Text = "Dimensions";
                }
                if (hiddenField1.Value == "New B2B Order" && hiddenField.Value == "[$PRODUCT_DETAILS$]")
                {
                    this.RadGrid_CustomTags.Attributes.Add("style", "width:1050px");
                    label1.Visible = true;
                    languageConversion.Visible = true;
                    checkBox.Visible = true;
                    languageConversion1.Visible = true;
                    checkBox1.Visible = true;
                    languageConversion2.Visible = true;
                    checkBox2.Visible = true;
                    languageConversion3.Visible = true;
                    checkBox3.Visible = true;
                    languageConversion4.Visible = true;
                    checkBox4.Visible = true;
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Product_Name");
                    checkBox.Text = this.objLanguage.GetLanguageConversion("Job_Name");
                    languageConversion1.Text = this.objLanguage.GetLanguageConversion("Quantity_s");
                    checkBox1.Text = this.objLanguage.GetLanguageConversion("Total_Price_IncTax");
                    languageConversion2.Text = this.objLanguage.GetLanguageConversion("Ordered_Height");
                    checkBox2.Text = this.objLanguage.GetLanguageConversion("Ordered_Width");
                    languageConversion3.Text = this.objLanguage.GetLanguageConversion("Product_Height");
                    checkBox3.Text = this.objLanguage.GetLanguageConversion("Product_Width");
                    languageConversion4.Text = this.objLanguage.GetLanguageConversion("Additional_Options");
                    checkBox4.Text = this.objLanguage.GetLanguageConversion("Item_Number");
                }
            }
            catch
            {
            }
        }

        public void Tags_Select(string Event)
        {
            DataTable dataTable = WebstoreBasePage.EmailTags_Select(Event, this.AccountID);
            this.RadGrid_CustomTags.DataSource = dataTable;
            this.RadGrid_CustomTags.DataBind();
        }
    }
}