using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
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


namespace ePrint.usercontrol.StoreSettings
{
    public partial class phrase_book : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string ImgPath = global.imagePath();

        private BaseClass objBase = new BaseClass();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        private string section = string.Empty;

        public int CompanyID;

        public int AccountID;

        public long UserID;

        protected string EmailToCustomerIDs = string.Empty;

        public long EmailToCustomerID;

        public static int IsArtwork;

        public static int IsOrderPdf;

        public string strLo = string.Empty;

        public string type = string.Empty;

        public bool DefaultPhrase;

        public bool Deleted;

        public string ApprovalSystemStatus = string.Empty;

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

        static phrase_book()
        {
        }

        public phrase_book()
        {
        }

        public void IsEnable(long EmailToCustomerID, string IsEnable)
        {
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, this.AccountID, EmailToCustomerID, "", "");
            foreach (DataRow row in customerSelect.Rows)
            {
                if (row["IsArtwork"].ToString().ToLower() != "true")
                {
                    phrase_book.IsArtwork = 0;
                }
                else
                {
                    phrase_book.IsArtwork = 1;
                }
                if (row["IsOrderPdf"].ToString().ToLower() != "true")
                {
                    phrase_book.IsOrderPdf = 0;
                }
                else
                {
                    phrase_book.IsOrderPdf = 1;
                }
                if (row["IsProductName"].ToString().ToLower() != "true")
                {
                    this.IsProductName = 0;
                }
                else
                {
                    this.IsProductName = 1;
                }
                if (row["IsJobName"].ToString().ToLower() != "true")
                {
                    this.IsJobName = 0;
                }
                else
                {
                    this.IsJobName = 1;
                }
                if (row["IsQuantity"].ToString().ToLower() != "true")
                {
                    this.IsQty = 0;
                }
                else
                {
                    this.IsQty = 1;
                }
                if (row["IsTotalPrice"].ToString().ToLower() != "true")
                {
                    this.IsTotalPrice = 0;
                }
                else
                {
                    this.IsTotalPrice = 1;
                }
                if (row["IsOrderedWidth"].ToString().ToLower() != "true")
                {
                    this.IsOrderedWidth = 0;
                }
                else
                {
                    this.IsOrderedWidth = 1;
                }
                if (row["IsOrderedHeight"].ToString().ToLower() != "true")
                {
                    this.IsOrderedHeight = 0;
                }
                else
                {
                    this.IsOrderedHeight = 1;
                }
                if (row["IsProductWidth"].ToString().ToLower() != "true")
                {
                    this.IsProductWidth = 0;
                }
                else
                {
                    this.IsProductWidth = 1;
                }
                if (row["IsProductHeight"].ToString().ToLower() != "true")
                {
                    this.IsProductHeight = 0;
                }
                else
                {
                    this.IsProductHeight = 1;
                }
                if (row["IsAdditionalOption"].ToString().ToLower() != "true")
                {
                    this.IsAdditionalOption = 0;
                }
                else
                {
                    this.IsAdditionalOption = 1;
                }
                if (row["IsItemNumber"].ToString().ToLower() != "true")
                {
                    this.IsItemNumber = 0;
                }
                else
                {
                    this.IsItemNumber = 1;
                }
                if (row["IsItemCode"].ToString().ToLower() != "true")
                {
                    this.IsItemCode = 0;
                }
                else
                {
                    this.IsItemCode = 1;
                }
                if (row["IsCustomerCode"].ToString().ToLower() != "true")
                {
                    this.IsCustomerCode = 0;
                }
                else
                {
                    this.IsCustomerCode = 1;
                }
                if (row["IsUnitOfMeasure"].ToString().ToLower() != "true")
                {
                    this.IsUnitOfMeasure = 0;
                }
                else
                {
                    this.IsUnitOfMeasure = 1;
                }
                if (row["IsItemDescription"].ToString().ToLower() != "true")
                {
                    this.IsItemDescription = 0;
                }
                else
                {
                    this.IsItemDescription = 1;
                }

                if (row["IsWeight"].ToString().ToLower() != "true")
                {
                    this.IsWeight = 0;
                }
                else
                {
                    this.IsWeight = 1;
                }
                if (row["IsCubicMeasurment"].ToString().ToLower() != "true")
                {
                    this.IsCubicMeasurment = 0;
                }
                else
                {
                    this.IsCubicMeasurment = 1;
                }
                if (row["IsOrderedWeight"].ToString().ToLower() != "true")
                {
                    this.IsOrderedWeight = 0;
                }
                else
                {
                    this.IsOrderedWeight = 1;
                }
                if (row["IsOrderedCubicMeasurment"].ToString().ToLower() != "true")
                {
                    this.IsOrderedCubicMeasurment = 0;
                }
                else
                {
                    this.IsOrderedCubicMeasurment = 1;
                }
                if (row["IsPerQuantity"].ToString().ToLower() != "true")
                {
                    this.IsPerQuantity = 0;
                }
                else
                {
                    this.IsPerQuantity = 1;
                }
                if (row["IsDimensions"].ToString().ToLower() != "true")
                {
                    this.IsDimensions = 0;
                }
                else
                {
                    this.IsDimensions = 1;
                }
                //if (row["IsWidth"].ToString().ToLower() != "true")
                //{
                //    this.IsWidth = 0;
                //}
                //else
                //{
                //    this.IsWidth = 1;
                //}
                //if (row["IsHeight"].ToString().ToLower() != "true")
                //{
                //    this.IsHeight = 0;
                //}
                //else
                //{
                //    this.IsHeight = 1;
                //}
            }
            if (IsEnable.ToLower() == "enable")
            {
                WebstoreBasePage.EmailToCustomer_Update(EmailToCustomerID, this.CompanyID, this.AccountID, "", "", 1, DateTime.Now, "Y", "", phrase_book.IsArtwork, phrase_book.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
                return;
            }
            WebstoreBasePage.EmailToCustomer_Update(EmailToCustomerID, this.CompanyID, this.AccountID, "", "", 0, DateTime.Now, "Y", "", phrase_book.IsArtwork, phrase_book.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblheader.Text = "Settings: eStore Phrasebook";
            this.RadGrid1.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Phrase_Text");
            this.RadGrid1.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Default_Phrase");
            this.RadGrid1.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = (long)Convert.ToInt32(base.Session["USerID"].ToString());
            string str = SettingsBasePage.Fetch_SelectedAccountID(this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            if (this.AccountID == 0)
            {
                this.divnoaccount.Attributes.CssStyle.Add("display", "block");
                this.content.Attributes.CssStyle.Add("display", "none");
            }
            string lower = base.Request.Params["type"].ToLower();
            string str1 = lower;
            if (lower != null)
            {
                if (str1 == "lo")
                {
                    this.divPhraseBook.Visible = true;
                    this.divEmailsHeader.Visible = false;
                    this.divOtherHeader.Visible = true;
                    this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), " : ", this.objLanguage.GetLanguageConversion("eStore_Phrasebook_Logout_Messages"));
                    this.section = "Logout Messages";
                }
                else if (str1 == "li")
                {
                    this.divPhraseBook.Visible = true;
                    this.divEmailsHeader.Visible = false;
                    this.divOtherHeader.Visible = true;
                    this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), " : ", this.objLanguage.GetLanguageConversion("eStore_Phrasebook_Login_Messages"));
                    this.section = "Login Messages";
                }
                else if (str1 == "bli")
                {
                    this.divPhraseBook.Visible = true;
                    this.divEmailsHeader.Visible = false;
                    this.divOtherHeader.Visible = true;
                    this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), " : ", this.objLanguage.GetLanguageConversion("eStore_Phrasebook_Login_Messages"));
                    this.section = "Below Login Messages";
                }
            }
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() == "up")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["mode"].ToString() == "copy")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Copied_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["mode"].ToString() == "suc")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Saved_Successfully"), "msg-success", this.plhMessage);
                }
            }
        }

        protected void RadGrid1_DeleteCommand(object source, CommandEventArgs e)
        {
            WebstoreBasePage.estore_phrasebook_delete(Convert.ToInt32(e.CommandArgument));
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_successfully_deleted"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            RadEditor radEditor = (RadEditor)e.Item.FindControl("txtPhraseText");
            if (((CheckBox)e.Item.FindControl("chkedit")).Checked)
            {
                this.DefaultPhrase = true;
            }
            string str = this.objBase.SpecialEncode(radEditor.Content);
            WebstoreBasePage.estore_phrasebook_insert(Convert.ToInt32(base.Session["companyID"].ToString()), this.section.ToString(), str.ToString(), this.DefaultPhrase, Convert.ToInt64(this.AccountID.ToString()));
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_Successfully_Inserted"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_ItemCreated(object source, GridItemEventArgs e)
        {
        }

        protected void radGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridItem[] items = this.RadGrid1.MasterTableView.GetItems(new GridItemType[] { GridItemType.CommandItem });
            for (int i = 0; i < (int)items.Length; i++)
            {
                LinkButton languageConversion = (LinkButton)((GridCommandItem)items[i]).FindControl("InitInsertButton");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Add_New_Record");
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                RadEditor radEditor = (RadEditor)e.Item.FindControl("txtPhraseText");
                Label label = (Label)e.Item.FindControl("lblcnt");
                RadButton radButton = (RadButton)e.Item.FindControl("RadButton8");
                RadButton languageConversion1 = (RadButton)e.Item.FindControl("RadButton1");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Save");
                radButton.Text = this.objLanguage.GetLanguageConversion("Cancel");
                radEditor.Content = this.objBase.SpecialDecode(label.Text);
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                RadEditor radEditor1 = (e.Item as GridEditableItem).FindControl("txtPhraseText") as RadEditor;
                radEditor1.Focus();
                try
                {
                    this.type = base.Request.Params["type"].ToLower();
                    this.strLo = this.type.ToLower();
                    if (this.strLo == "em" || this.strLo == "li" || this.strLo == "lo")
                    {
                        radEditor1.Height = Unit.Pixel(205);
                        radEditor1.Width = Unit.Pixel(600);
                    }
                    else
                    {
                        radEditor1.Width = Unit.Pixel(600);
                    }
                }
                catch
                {
                }
            }
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Image image = new Image();
                Label label1 = (Label)item.FindControl("lblIsDefaultPhrase");
                if (label1.Text.ToLower().Trim() == "yes")
                {
                    image.ImageUrl = string.Concat(this.ImgPath, "check.gif");
                    label1.Controls.Add(image);
                    return;
                }
                label1.Text = "";
            }
        }

        protected void RadGrid1_ItemUpdated(object source, GridUpdatedEventArgs e)
        {
            GridEditableItem item = e.Item;
            ((RadEditor)e.Item.FindControl("txtPhraseText")).Focus();
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = WebstoreBasePage.estore_phrasebook_select(Convert.ToInt32(base.Session["CompanyID"].ToString()), this.section.ToString(), this.AccountID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["PhraseText"] = this.objBase.SpecialDecode(row["PhraseText"].ToString());
            }
            this.RadGrid1.DataSource = dataTable;
        }

        protected void RadGrid1_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid1.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid1.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGrid1_PazeIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_PazeSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            RadEditor radEditor = (RadEditor)e.Item.FindControl("txtPhraseText");
            if (((CheckBox)e.Item.FindControl("chkedit")).Checked)
            {
                this.DefaultPhrase = true;
            }
            string str = this.objBase.SpecialEncode(radEditor.Content);
            WebstoreBasePage.estore_phrasebook_update(Convert.ToInt32(e.CommandArgument), this.section.ToString(), str.ToString(), this.DefaultPhrase);
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_successfully_updated"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
        }

        protected void RadListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("checkBox_Email");
                if (this.RadListBox2.SelectedItem.Value.ToLower() == "delete" && htmlInputCheckBox.Checked)
                {
                    WebstoreBasePage.estore_phrasebook_delete(Convert.ToInt32(htmlInputCheckBox.Value));
                    this.RadGrid1.Rebind();
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_successfully_deleted"), "msg-success", this.plhMessage);
                }
            }
        }
    }
}