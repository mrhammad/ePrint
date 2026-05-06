using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;


namespace ePrint.settings
{
    public partial class supplier_email : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strFilepathRad = global.filePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private SettingsBasePage objSet = new SettingsBasePage();

        public languageClass objLanguage = new languageClass();

        private string section = string.Empty;

        private int CompanyID;

        private int UserID;

        public int totalrec;

        public string type = string.Empty;

        public string EmailTemplateName = string.Empty;

        private commonClass objJava = new commonClass();

        public Image imgno_del = new Image();

        public int PageSize = 10;

        public string GridStyleViews = string.Empty;

        private BaseClass objBass = new BaseClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string EmailSettingType = "e";

        public bool IsOccy = ConnectionClass.IsOccy;

        public string serverName = ConnectionClass.ServerName;

        public string ImgPath = global.imagePath();

        private long EmailtoAdminID;

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

        public supplier_email()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridDataItem item in this.grdEmailBody.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkEmailBodyId1");
                num = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_SupplierEmailBody_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@EmailtoAdminID", num);
                sqlCommand.ExecuteNonQuery();
            }
            this.EmailBodyGridBind();
            this.grdEmailBody.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            this.EmailTemplateName = base.SpecialEncode(this.txtemailtempname.Text);
            string str = this.ddlEmailTemplateType.SelectedValue.ToString();
            string text = this.txt_Subject.Text;
            string str1 = this.RadEditor2.Content.ToString();
            if (this.lblemail.Text == "")
            {
                this.EmailtoAdminID = (long)0;
            }
            else
            {
                this.EmailtoAdminID = Convert.ToInt64(this.lblemail.Text.ToString());
            }
            int num = SettingsBasePage.Settings_SupplierEmailBody_Insert((long)this.CompanyID, str, this.EmailTemplateName, text, str1, this.EmailtoAdminID, this.chkDefaultEmailBody.Checked);
            this.EmailBodyGridBind();
            this.hiddenEmailtoAdminID.Value = null;
            if (num == 1)
            {
                base.Response.Redirect("~/settings/supplier_email.aspx?action=i");
                return;
            }
            if (num == 2)
            {
                base.Response.Redirect("~/settings/supplier_email.aspx?action=u");
            }
        }

        public void EmailBodyGridBind()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_SupplierEmailToAdmin_Select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            _commonClass.closeConnection();
            foreach (DataRow row in dataTable.Rows)
            {
                row["TemplateName"] = base.SpecialDecode(row["TemplateName"].ToString());
                row["Subject"] = base.SpecialDecode(row["Subject"].ToString());
            }
            this.grdEmailBody.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.grdEmailBody.DataBind();
            }
            this.grdEmailBody.DataBind();
        }

        protected void grdEmailBody_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.grdEmailBody.CurrentPageIndex = e.NewPageIndex;
            this.EmailBodyGridBind();
        }

        protected void grdEmailBody_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.EmailBodyGridBind();
        }

        public void grdPraseBookEmailSignature_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                LinkButton text = (LinkButton)e.Item.FindControl("lnkTemplateName");
                Label label = (Label)e.Item.FindControl("hdnEmailtoAdminID");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaulVal");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnTemplateType");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("chkEmailBodyId1");
                if (label.Text != null)
                {
                    this.chkBodyID.Value = label.Text;
                    this.Session.Add("hdnEmailtoAdminID", label.Text);
                    text.CommandName = label.Text;
                }
                Image image = (Image)e.Item.FindControl("imgdefault");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonErase");
                if (hiddenField.Value.ToLower() != "true")
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
                    imageButton.Visible = true;
                    htmlInputCheckBox.Visible = true;
                }
                else
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    imageButton.Visible = false;
                    htmlInputCheckBox.Visible = false;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdEmailBody.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdEmailBody.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void lnkBody_onClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            SqlCommand sqlCommand = new SqlCommand("PC_SupplierEmailToAdmin_SelectedRow", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@EmailtoAdminID", Convert.ToInt32(linkButton.CommandArgument.ToString()));
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(sqlCommand))
            {
                dataTable.Load(dataReader);
            }
            if (sqlDataReader.Read())
            {
                this.txtemailtempname.Text = base.SpecialDecode(sqlDataReader["TemplateName"].ToString());
                this.txt_Subject.Text = base.SpecialDecode(sqlDataReader["Subject"].ToString());
                this.RadEditor2.Content = sqlDataReader["Body"].ToString();
                this.ddlEmailTemplateType.SelectedValue = sqlDataReader["TemplateType"].ToString();
                this.chkDefaultEmailBody.Checked = Convert.ToBoolean(sqlDataReader["Isdefault"].ToString());
            }
            this.hiddenEmailtoAdminID.Value = linkButton.CommandArgument.ToString();
            this.lblemail.Text = linkButton.CommandName.ToString();
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            foreach (GridDataItem item in this.grdEmailBody.MasterTableView.Items)
            {
                SqlCommand sqlCommand = new SqlCommand("PC_settings_SupplierEmailBody_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@EmailtoAdminID", e.CommandArgument);
                sqlCommand.ExecuteNonQuery();
            }
            this.EmailBodyGridBind();
            this.grdEmailBody.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email"), "&nbsp;>>&nbsp;", this.objLanguage.GetLanguageConversion("Supplier_Quote")));
            base.Title = this.objLanguage.convert(global.pageTitle("Supplier Quote", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Supplier_Quote");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "hidetype();", true);
            this.grdEmailBody.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Template_Name");
            this.grdEmailBody.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Template_Type");
            this.grdEmailBody.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("DEfault");
            this.grdEmailBody.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.spnTempName.InnerText = this.objLanguage.GetLanguageConversion("Email_Template_Name");
            this.lbl_Subject.Text = this.objLanguage.GetLanguageConversion("Subject");
            this.lbl_templateType.Text = this.objLanguage.GetLanguageConversion("Template_Type");
            this.lblEmailBody.Text = this.objLanguage.GetLanguageConversion("Email_Type");
            this.spn_defaultSignature.InnerText = this.objLanguage.GetLanguageConversion("Set_this_template_as_Default_Body");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.lnkDeleteStatus.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.grdEmailBody.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor2.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            if (!base.IsPostBack)
            {
                this.EmailBodyGridBind();
            }
            if (base.Request.Params["action"] != null)
            {
                if (base.Request.Params["action"].ToString().ToLower() == "i")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Inserted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["action"].ToString().ToLower() == "u")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Updated_Successfully"), "msg-success", this.plhMessage);
                }
            }
            this.Tags_Select("New Quote Received");
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.serverName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor2.ImageManager.UploadPaths = strArrays1;
            this.RadEditor2.ImageManager.ViewPaths = strArrays1;
            this.RadEditor2.FlashManager.ViewPaths = strArrays1;
            this.RadEditor2.FlashManager.UploadPaths = strArrays1;
            this.RadEditor2.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor2.DocumentManager.UploadPaths = strArrays1;
        }

        protected void RadGrid_Email_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkTemplateName");
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

        public void Tags_Select(string Event)
        {
            DataTable dataTable = WebstoreBasePage.EmailTags_Select(Event, 0);
            this.RadGrid_CustomTags.DataSource = dataTable;
            this.RadGrid_CustomTags.DataBind();
        }
    }
}