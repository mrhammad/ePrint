using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ePrint.settings;
using System.Data;
using Printcenter.UI.Setting;
using nmsConnectionClass;
using nmsCommon;
using nmsLanguage;
using System.Web.Profile;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.settings
{
    public partial class FTPFailureEmail : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strFilepathRad = global.filePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private SettingsBasePage objSet = new SettingsBasePage();

        private string section = string.Empty;

        private int CompanyID;

        private int UserID;

        public int totalrec;

        public string type = string.Empty;

        public string EmailTemplateName = string.Empty;

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        public Image imgno_del = new Image();

        public int PageSize = 10;

        public string GridStyleViews = string.Empty;

        private BaseClass objBass = new BaseClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string EmailSettingType = "e";

        public bool IsOccy = ConnectionClass.IsOccy;

        public string serverName = ConnectionClass.ServerName;

        public static int ddlSelectedValue;


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

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings/FTPFailureEmail.aspx");
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
                sqlCommand.Parameters.Add("@CompanyID", CompanyID);
                sqlCommand.Parameters.Add("@EmailID", num);
                sqlCommand.ExecuteNonQuery();
            }
            this.EmailBodyGridBind();
            this.grdEmailBody.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            this.EmailTemplateName = base.SpecialEncode(this.txtemailtempname.Text);
            string str = "FTP Failure Emails";
            string str1 = "";
            string CC = base.SpecialDecode(TextAreaCC.Value);
            string BCC = base.SpecialDecode(TextAreaBCC.Value);
            string TO = base.SpecialDecode(TextAreaTo.Value);
            SqlCommand sqlCommand = new SqlCommand("PC_Settings_FtpEmail_Insert_Update", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", CompanyID);
            sqlCommand.Parameters.Add("@UserID", this.UserID);
            sqlCommand.Parameters.Add("@TemplateType", str);
            sqlCommand.Parameters.Add("@TemplateName", this.EmailTemplateName);
            sqlCommand.Parameters.Add("@Body", this.RadEditor1.Content.ToString());
            sqlCommand.Parameters.Add("@FooterID", this.ddlFooterSignature.SelectedValue);
            sqlCommand.Parameters.Add("@Isdefault", this.chkDefaultEmailBody.Checked);
            sqlCommand.Parameters.Add("@SpecificTo", str1);
            if (this.lblemail.Text == "")
            {
                sqlCommand.Parameters.Add("@EmailID", Convert.ToInt32(0));
            }
            else
            {
                sqlCommand.Parameters.Add("@EmailID", Convert.ToInt32(this.lblemail.Text.ToString()));
            }
            sqlCommand.Parameters.Add("@Subject", this.txttemplatesubject.Text);
            sqlCommand.Parameters.Add("@CC", CC);
            sqlCommand.Parameters.Add("@BCC", BCC);
            sqlCommand.Parameters.Add("@TO", TO);
            sqlCommand.ExecuteNonQuery();
            this.EmailBodyGridBind();
            this.drpLoadFooterTitle();
            this.hiddenEmailID.Value = null;
            base.Response.Redirect("~/settings/FTPFailureEmail.aspx?action=edit");
        }

        public void DefaultFooterSelect()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            SqlCommand sqlCommand = new SqlCommand("PC_SlectDefaultFooterSignature", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.objBass.SetDDLValue(this.ddlFooterSignature, sqlDataReader["EmailFooterID"].ToString());
            }
        }

        public void drpLoadFooterTitle()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Select_EmailSignature(this.CompanyID);
            this.ddlFooterSignature.DataSource = dataTable;
            this.ddlFooterSignature.DataTextField = "FooterTitle";
            this.ddlFooterSignature.DataValueField = "EmailFooterID";
            this.ddlFooterSignature.DataBind();
            this.ddlFooterSignature.Items.Insert(0, "--- Select ---");
            this.ddlFooterSignature.Items[0].Text = "--- Select ---";
            this.ddlFooterSignature.Items[0].Value = "0";
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Isdefault"].ToString().ToLower() != "true")
                {
                    system_emailbody.ddlSelectedValue = 0;
                }
                else
                {
                    this.objBass.SetDDLValue(this.ddlFooterSignature, row["EmailFooterID"].ToString());
                    system_emailbody.ddlSelectedValue = Convert.ToInt16(row["EmailFooterID"]);
                    break;
                }
            }
            this.txtemailtempname.Text = string.Empty;
            this.RadEditor1.Content = string.Empty;
            this.chkDefaultEmailBody.Checked = false;
            this.Session.Add("hdnEmailID", null);
        }

        public void drpSpecificUserselect()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_User_Select_ForEmailBody", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
        }

        public void EmailBodyGridBind()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_ProofApproval_emailbody_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@Type", "FTP Failure Emails");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.grdEmailBody.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lnkDeleteStatus.Visible = false;
            }
            else
            {
                this.lnkDeleteStatus.Visible = true;
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
                Label label = (Label)e.Item.FindControl("hdnEmailID");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaulVal");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnTemplateType");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnSpecificTo");
                Label label1 = (Label)e.Item.FindControl("lblSpecificTo");
                label1.Text = base.SpecialDecode(label1.Text);
                text.Text = base.SpecialDecode(text.Text);
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

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            int num = SettingsBasePage.settings_EmailBody_Copy(this.CompanyID, Convert.ToInt32(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "Settings/FTPFailureEmail.aspx?type=mb", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray));
        }

        public void lnkAddNew_OnClik(object sender, EventArgs e)
        {
            this.RadEditor1.Content = "";
            this.objBass.SetDDLValue(this.ddlFooterSignature, system_emailbody.ddlSelectedValue.ToString());
            this.txtemailtempname.Focus();
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
                HtmlTextArea textAreaCC = this.TextAreaCC;
                HtmlTextArea textAreaBCC = this.TextAreaBCC;
                HtmlTextArea textAreaTo = this.TextAreaTo;
                this.txtemailtempname.Text = sqlDataReader["TemplateName"].ToString();
                this.RadEditor1.Content = sqlDataReader["Body"].ToString();
                this.objBass.SetDDLValue(this.ddlFooterSignature, sqlDataReader["FooterID"].ToString());
                this.chkDefaultEmailBody.Checked = Convert.ToBoolean(sqlDataReader["Isdefault"].ToString());
                //base.SetDDLValue(this.ddlSpecificType, sqlDataReader["SpecificTo"].ToString());
                this.txttemplatesubject.Text = sqlDataReader["Subject"].ToString();
                textAreaCC.Value = base.SpecialDecode(sqlDataReader["CC"].ToString());
                textAreaBCC.Value = base.SpecialDecode(sqlDataReader["BCC"].ToString());
                textAreaTo.Value = base.SpecialDecode(sqlDataReader["EmailTo"].ToString());
                this.txtemailtempname.Focus();
            }
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "SelectTemplateType();", true);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "SetBCCAndCCValues('" + TextAreaCC.Value + "','" + TextAreaBCC.Value + "','" + TextAreaTo.Value + "');", true);
            this.lblemail.Text = linkButton.CommandName.ToString();
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
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "hidetype();", true);
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.serverName, "/", this.Session["CompanyID"].ToString(), "/" };
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
            this.trheader.BgColor = this.objpage.colorCode(this.companyid, this.Session["pagename"].ToString());
            string empty = string.Empty;
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("FTP"), "&nbsp;>>&nbsp;", this.objLanguage.GetLanguageConversion("FTP_Emails")));
            base.Title = this.objLanguage.convert(global.pageTitle("Email Body", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("FTP_Emails");
            DataTable dataTable = SettingsBasePage.settings_emailsetting_select(this.CompanyID, Convert.ToInt32(this.Session["UserID"].ToString()));
            foreach (DataRow row in dataTable.Rows)
            {
                this.EmailSettingType = row["EmailSettingType"].ToString();
            }
            this.grdEmailBody.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Template_Name");
            this.grdEmailBody.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Template_Type");
            this.grdEmailBody.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Specific_To");
            this.grdEmailBody.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.grdEmailBody.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.spnTempName.InnerText = this.objLanguage.GetLanguageConversion("Failure_Template_Name");
            //this.lbl_SpecificTo.Text = this.objLanguage.GetLanguageConversion("Specific_To_User");
            //this.lbl_TemplateType.Text = this.objLanguage.GetLanguageConversion("Template_Type");
            this.lbl_emailSignature.Text = this.objLanguage.GetLanguageConversion("Specific_Email_Signature");
            this.spn_defaultSignature.InnerText = this.objLanguage.GetLanguageConversion("Set_This_Text_As_Default_Body");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.spnCC.InnerText = this.objLanguage.GetLanguageConversion("CC");
            this.spnBCC.InnerText = this.objLanguage.GetLanguageConversion("BCC");
            this.spnTo.InnerText = this.objLanguage.GetLanguageConversion("Email_To");
            this.grdEmailBody.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_Found");
            if (!base.IsPostBack)
            {
                this.drpSpecificUserselect();
                this.drpLoadFooterTitle();
                this.EmailBodyGridBind();
                this.DefaultFooterSelect();
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
                }
                else if (base.Request.Params["action"].ToString().ToLower() == "edit")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Saved_Successfully"), "msg-success", this.plhMessage);
                }
            }
            this.lnkDeleteStatus.Attributes.Add("onclick", "javascript:return CallDelete();");
        }
    }
}