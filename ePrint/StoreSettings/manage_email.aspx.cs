using Microsoft.Practices.EnterpriseLibrary.Data;
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
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.StoreSettings
{
    public partial class manage_email : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private commonClass commclass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public string ImgPath = global.imagePath();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        protected string EmailToCustomerIDs = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public long EmailToCustomerID;

        public static int IsArtwork;

        public static int IsOrderPdf;

        public string ApprovalSystemStatus = string.Empty;

        public string VersionNumber = string.Empty;

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

        static manage_email()
        {
        }

        public manage_email()
        {
        }

        public void Assign_ApprovalSystemSettings_ForAccount(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_ApprovalSystemSettings_select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables[3].Rows.Count <= 0)
            {
                this.ApprovalSystemStatus = "off";
                return;
            }
            if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[3].Rows[0]["IsApprovalFeaturesOn"].ToString().ToLower() == "true")
            {
                this.ApprovalSystemStatus = "on";
                return;
            }
            this.ApprovalSystemStatus = "off";
        }

        public void gridEmail_Bind(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailForm)
        {
            string empty = string.Empty;
            this.Assign_ApprovalSystemSettings_ForAccount((long)AccountID);
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(CompanyID, AccountID, EmailToCustomerID, TagEvent, EmailForm);
            if (customerSelect.Rows.Count > 0)
            {
                empty = customerSelect.Rows[0]["AccountType"].ToString();
            }
            if (empty.ToLower() == "x")
            {
                for (int i = 0; i < customerSelect.Rows.Count; i++)
                {
                    if (customerSelect.Rows[i].Table.Columns.Contains("Event") && customerSelect.Rows[i]["Event"].ToString().Trim() == "New B2B Contact Registration")
                    {
                        customerSelect.Rows.Remove(customerSelect.Rows[i]);
                    }
                }
            }
            if (empty.ToLower() == "p")
            {
                for (int j = 0; j < customerSelect.Rows.Count; j++)
                {
                    if (customerSelect.Rows[j].Table.Columns.Contains("Event") && customerSelect.Rows[j]["Event"].ToString().Trim() == "New User Registration")
                    {
                        customerSelect.Rows.Remove(customerSelect.Rows[j]);
                    }
                }
            }
            this.RadGrid_Email.DataSource = customerSelect;
            this.RadGrid_Email.DataBind();
            DataTable dataTable = WebstoreBasePage.EmailToCustomer_Select(CompanyID, 0, (long)0, "", "Admin");
            this.RadGrid_EmailAdmin.DataSource = dataTable;
            this.RadGrid_EmailAdmin.DataBind();
            if (this.ApprovalSystemStatus != "on")
            {
                this.RadGrid_ApproverEmail.Visible = false;
                this.div_Grid.Style.Add("margin-top", "-10px");
                this.div_Grid.Attributes.Add("style", "margin-left:10px");
                return;
            }
            DataTable customerSelect1 = WebstoreBasePage.EmailToCustomer_Select(CompanyID, AccountID, (long)0, "", "approver");
            this.RadGrid_ApproverEmail.DataSource = customerSelect1;
            this.RadGrid_ApproverEmail.DataBind();
            this.RadGrid_ApproverEmail.Visible = true;
            this.div_Grid.Style.Add("margin-top", "10px");
        }

        protected void Img_Disabled_Click(object sender, CommandEventArgs e)
        {
            this.IsEnable(Convert.ToInt64(e.CommandArgument), "disable");
            base.Response.Redirect("manage_email.aspx?mode=up");
        }

        protected void Img_Enabled_Click(object sender, CommandEventArgs e)
        {
            this.IsEnable(Convert.ToInt64(e.CommandArgument), "enable");
            base.Response.Redirect("manage_email.aspx?mode=up");
        }

        public void IsEnable(long EmailToCustomerID, string IsEnable)
        {
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, this.AccountID, EmailToCustomerID, "", "");
            foreach (DataRow row in customerSelect.Rows)
            {
                if (row["IsArtwork"].ToString().ToLower() != "true")
                {
                    manage_email.IsArtwork = 0;
                }
                else
                {
                    manage_email.IsArtwork = 1;
                }
                if (row["IsOrderPdf"].ToString().ToLower() != "true")
                {
                    manage_email.IsOrderPdf = 0;
                }
                else
                {
                    manage_email.IsOrderPdf = 1;
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
                WebstoreBasePage.EmailToCustomer_Update(EmailToCustomerID, this.CompanyID, this.AccountID, "", "", 1, DateTime.Now, "Y", "", manage_email.IsArtwork, manage_email.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
                return;
            }
            WebstoreBasePage.EmailToCustomer_Update(EmailToCustomerID, this.CompanyID, this.AccountID, "", "", 0, DateTime.Now, "Y", "", manage_email.IsArtwork, manage_email.IsOrderPdf, 0, this.IsProductName, this.IsJobName, this.IsQty, this.IsTotalPrice, this.IsOrderedWidth, this.IsOrderedHeight, this.IsProductWidth, this.IsProductHeight, this.IsAdditionalOption, this.IsItemNumber, this.IsItemCode, this.IsCustomerCode, this.IsUnitOfMeasure, this.IsItemDescription, this.IsWeight, this.IsCubicMeasurment, this.IsOrderedWeight, this.IsOrderedCubicMeasurment, this.IsPerQuantity, this.IsDimensions);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid_EmailAdmin.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Event");
            this.RadGrid_EmailAdmin.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Subject");
            this.RadGrid_EmailAdmin.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Enabled");
            this.RadGrid_Email.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Event");
            this.RadGrid_Email.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Subject");
            this.RadGrid_Email.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Enabled");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (ConnectionClass.VersionNumber != null)
            {
                this.VersionNumber = ConnectionClass.VersionNumber.ToString();
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Manage_Emails")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Manage Emails", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Emails");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() == "up")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["mode"].ToString() == "copy")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Copied_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["mode"].ToString() == "suc")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Saved_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["mode"].ToString() == "exist")
                {
                    this.objBase.Message_Display("Selected event already exist", "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["mode"].ToString() == "exists")
                {
                    this.objBase.Message_Display("Some of the selected events are already exist", "msg-success", this.plhMessageNew);
                }
            }
            if (!base.IsPostBack)
            {
                this.gridEmail_Bind(this.CompanyID, this.AccountID, (long)0, "", "Customer");
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, 0, (long)0, "", "Admin");
                this.RadGrid_EmailAdmin.DataSource = customerSelect;
                this.RadGrid_EmailAdmin.DataBind();
            }
            this.RadListBox3.Items[0].Text = this.objLanguage.GetLanguageConversion("Enable");
            this.RadListBox3.Items[1].Text = this.objLanguage.GetLanguageConversion("Disable");
            this.RadListBox3.Items[2].Text = this.objLanguage.GetLanguageConversion("Copy_Email");
            this.RadListBox1.Items[0].Text = this.objLanguage.GetLanguageConversion("Enable");
            this.RadListBox1.Items[1].Text = this.objLanguage.GetLanguageConversion("Disable");
            this.RadListBox1.Items[2].Text = this.objLanguage.GetLanguageConversion("Copy_Email");
            this.CopyEmail.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
            this.CopyEmail.Controls.Add(userControl);
        }

        protected void RadGrid_ApproverEmail_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                ImageButton imageButton = (ImageButton)e.Item.FindControl("Img_Enabled1");
                if (((HiddenField)e.Item.FindControl("hdn_Enable")).Value.ToString().ToLower() != "true")
                {
                    imageButton.ImageUrl = "~/Images/1t.gif";
                }
                else
                {
                    imageButton.ImageUrl = "~/Images/check.gif";
                }
            }
            catch
            {
            }
        }

        protected void RadGrid_Email_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                ImageButton imageButton = (ImageButton)e.Item.FindControl("Img_Enabled1");
                if (((HiddenField)e.Item.FindControl("hdn_Enable")).Value.ToString().ToLower() != "true")
                {
                    imageButton.ImageUrl = "~/Images/1t.gif";
                }
                else
                {
                    imageButton.ImageUrl = "~/Images/check.gif";
                }
            }
            catch
            {
            }
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < this.RadGrid_Email.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Email.Items[i].Cells[0].FindControl("checkBox_Email");
                if (this.RadListBox1.SelectedItem.Value.ToLower() == "enable" && htmlInputCheckBox.Checked)
                {
                    this.EmailToCustomerID = (long)Convert.ToInt32(htmlInputCheckBox.Value);
                    this.IsEnable(this.EmailToCustomerID, "enable");
                    htmlInputCheckBox.Checked = false;
                    num++;
                }
                if (this.RadListBox1.SelectedItem.Value.ToLower() == "disable" && htmlInputCheckBox.Checked)
                {
                    this.EmailToCustomerID = (long)Convert.ToInt32(htmlInputCheckBox.Value);
                    this.IsEnable(this.EmailToCustomerID, "disable");
                    htmlInputCheckBox.Checked = false;
                    num++;
                }
                if (this.RadListBox1.SelectedItem.Value.ToLower() == "copy email" && htmlInputCheckBox.Checked)
                {
                    this.EmailToCustomerIDs = string.Concat(this.EmailToCustomerIDs, htmlInputCheckBox.Value, ",");
                    htmlInputCheckBox.Checked = false;
                    this.Session["EmailToCustomerIDs"] = this.EmailToCustomerIDs;
                    this.Session["AccountID"] = this.AccountID;
                }
            }
            if (num != 0)
            {
                this.gridEmail_Bind(this.CompanyID, this.AccountID, (long)0, "", "Customer");
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
            }
        }
    }
}