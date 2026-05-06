using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
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
    public partial class lowstockreminder_email : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

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

        public lowstockreminder_email()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings/lowstockreminder_email.aspx?type=lsr");
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
                SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@EmailID", num);
                sqlCommand.ExecuteNonQuery();
            }
            base.Response.Redirect("~/Settings/system_emailbody.aspx?action=delete");
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            this.EmailTemplateName = base.SpecialEncode(this.txtemailtempname.Text);
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.Add("@UserID", this.UserID);
            sqlCommand.Parameters.Add("@TemplateType", "stock reminder");
            sqlCommand.Parameters.Add("@TemplateName", this.EmailTemplateName);
            sqlCommand.Parameters.Add("@Body", this.RadEditor1.Content.ToString());
            sqlCommand.Parameters.Add("@FooterID", "");
            sqlCommand.Parameters.Add("@Isdefault", this.chkDefaultEmailBody.Checked);
            if (this.lblemail.Text == "")
            {
                sqlCommand.Parameters.Add("@EmailID", Convert.ToInt32(0));
            }
            else
            {
                sqlCommand.Parameters.Add("@EmailID", Convert.ToInt32(this.lblemail.Text.ToString()));
            }
            sqlCommand.Parameters.Add("@SpecificTo", "");
            sqlCommand.Parameters.Add("@Subject", base.SpecialDecode(this.txtSubject.Text));
            sqlCommand.ExecuteNonQuery();
            this.EmailBodyGridBind();
            this.hiddenEmailID.Value = null;
            base.Response.Redirect("~/settings/lowstockreminder_email.aspx?action=edit");
        }

        public void EmailBodyGridBind()
        {
            this.grdEmailBody.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Template_Name");
            this.grdEmailBody.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Subject");
            this.grdEmailBody.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.grdEmailBody.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.spnTempName.InnerText = this.objLanguage.GetLanguageConversion("Email_Template_Name");
            this.spnSubject.InnerText = this.objLanguage.GetLanguageConversion("Subject");
            this.SpnPhraseText.InnerText = this.objLanguage.GetLanguageConversion("Email_Body");
            this.spn_defaultSignature.InnerText = this.objLanguage.GetLanguageConversion("Set_this_text_as_Default_Body");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.grdEmailBody.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_display");
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@Type", "stock reminder");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.grdEmailBody.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count > 0)
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
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    LinkButton text = (LinkButton)e.Item.FindControl("lnkTemplateName");
                    text.Click += new EventHandler(this.lnkBody_onClick);
                    Label label = (Label)e.Item.FindControl("hdnEmailID");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaulVal");
                    LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkSubject");
                    text.Text = base.SpecialDecode(text.Text);
                    linkButton.Text = base.SpecialDecode(linkButton.Text);
                    if (label.Text != null)
                    {
                        this.chkBodyID.Value = label.Text;
                        this.Session.Add("hdnEmailID", label.Text);
                        text.CommandName = label.Text;
                    }
                    Image image = (Image)e.Item.FindControl("imgdefault");
                    if (hiddenField.Value.ToLower() != "true")
                    {
                        image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    }
                }
            }
            catch
            {
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
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_selectedRow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@EmailID", Convert.ToInt32(linkButton.CommandArgument.ToString()));
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.txtemailtempname.Text = base.SpecialDecode(sqlDataReader["TemplateName"].ToString());
                this.RadEditor1.Content = sqlDataReader["Body"].ToString();
                this.txtSubject.Text = base.SpecialDecode(sqlDataReader["Subject"].ToString());
                this.chkDefaultEmailBody.Checked = Convert.ToBoolean(sqlDataReader["Isdefault"].ToString());
            }
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:SelectTemplateType();", true);
            this.lblemail.Text = linkButton.CommandArgument.ToString();
            this.txtemailtempname.Focus();
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            foreach (GridDataItem item in this.grdEmailBody.MasterTableView.Items)
            {
                SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@EmailID", e.CommandArgument);
                sqlCommand.ExecuteNonQuery();
            }
            this.EmailBodyGridBind();
            this.grdEmailBody.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "hidetypeLowstock();", true);
            this.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.trheader.BgColor = this.objpage.colorCode(this.companyid, this.Session["pagename"].ToString());
            string empty = string.Empty;
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email"), "&nbsp;>>&nbsp;", this.objLanguage.GetLanguageConversion("Low_Stock_reminder_Email")));
            base.Title = this.objLanguage.convert(global.pageTitle("Low Stock Reminder Email", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Low_Stock_reminder_Email");
            if (!base.IsPostBack)
            {
                this.EmailBodyGridBind();
            }
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
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            if (base.Request.Params["action"] != null)
            {
                if (base.Request.Params["action"].ToString().ToLower() == "delete")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
                    return;
                }
                if (base.Request.Params["action"].ToString().ToLower() == "edit")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Saved_Successfully"), "msg-success", this.plhMessage);
                }
            }
        }
    }
}