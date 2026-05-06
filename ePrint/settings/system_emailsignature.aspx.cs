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
    public partial class system_emailsignature : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private string section = string.Empty;

        private int CompanyID;

        public int totalrec;

        public string type = string.Empty;

        public string EmailTemplateName = string.Empty;

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        public Image imgno_del = new Image();

        public string hraseType = "Footer Signature";

        public int UserID;

        public string GridStyleViews = string.Empty;

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

        public system_emailsignature()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings//system_emailsignature.aspx");
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            this.EmailTemplateName = base.SpecialEncode(this.txtemailSignatureTitle.Text);
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailsignature_insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.Add("@UserID", this.UserID);
            sqlCommand.Parameters.Add("@FooterTitle", base.SpecialEncode(this.txtemailSignatureTitle.Text));
            sqlCommand.Parameters.Add("@FooterText", this.RadEditor1.Content.ToString());
            sqlCommand.Parameters.Add("@Isdefault", this.chkDefaultFooter.Checked);
            if (this.hdnmode.Value.ToLower() != "edit")
            {
                sqlCommand.Parameters.Add("@EmailFooterID", Convert.ToInt32(0));
            }
            else
            {
                sqlCommand.Parameters.Add("@EmailFooterID", Convert.ToInt32(this.lblEmailFooterID.Text));
            }
            sqlCommand.ExecuteNonQuery();
            this.FooterSignatureGridBind();
            this.hdnFooterID.Value = null;
            base.Response.Redirect("~/settings/system_emailsignature.aspx?action=edit");
            base.Message_Display(this.objLanguage.GetLanguageConversion("Footer_Title_Added_Successfully"), "msg-success", this.plhMessage);
        }

        public void FooterSignatureGridBind()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailfooter_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.RadGrid1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lnkDeleteStatus.Visible = false;
            }
            else
            {
                this.lnkDeleteStatus.Visible = true;
                this.RadGrid1.DataBind();
            }
            this.RadGrid1.DataBind();
            this.txtemailSignatureTitle.Text = string.Empty;
            this.RadEditor1.Content = string.Empty;
            this.chkDefaultFooter.Checked = false;
        }

        public void grdPraseBookEmailSignature_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                RadGrid dataItem = (RadGrid)e.Item.DataItem;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                LinkButton value = (LinkButton)e.Item.FindControl("lnkFooterTitle");
                value.Click += new EventHandler(this.lnkFooterTitle_onclick);
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnEmailFooterID");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnDefaultSig");
                this.Session.Add("hdnEmailID", hiddenField.Value);
                value.CommandName = hiddenField.Value;
                value.Text = base.SpecialDecode(value.Text);
                Label label = (Label)e.Item.FindControl("lblIsdefault");
                if (hiddenField1.Value.ToLower() != "true")
                {
                    label.Text = "";
                }
                else
                {
                    this.imgno_del.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    label.Controls.Add(this.imgno_del);
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void grdPraseBookEmailSignature_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.FooterSignatureGridBind();
        }

        protected void grdPraseBookEmailSignature_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.FooterSignatureGridBind();
        }

        public void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailsignature_deleterow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.Add("@EmailFooterID", e.CommandArgument);
            sqlCommand.ExecuteNonQuery();
            this.FooterSignatureGridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Footer_Title_Delete_Successfully"), "msg-success", this.plhMessage);
        }

        public void lnkDelete_onclick(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridDataItem item in this.RadGrid1.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkEmailFooterId1");
                num = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_emailsignature_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@EmailFooterID", num);
                sqlCommand.ExecuteNonQuery();
            }
            this.FooterSignatureGridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Footer_Title_Delete_Successfully"), "msg-success", this.plhMessage);
        }

        public void lnkFooterTitle_onclick(object sender, EventArgs e)
        {
            this.FooterSignatureGridBind();
            LinkButton linkButton = (LinkButton)sender;
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailsignature_selectedRow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@EmailFooterID", linkButton.CommandArgument.ToString());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.txtemailSignatureTitle.Text = base.SpecialDecode(sqlDataReader["FooterTitle"].ToString());
                this.RadEditor1.Content = sqlDataReader["FooterText"].ToString();
                this.chkDefaultFooter.Checked = Convert.ToBoolean(sqlDataReader["Isdefault"].ToString());
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:addnew('edit');", true);
            }
            this.hdnFooterID.Value = linkButton.CommandArgument.ToString();
            this.lblEmailFooterID.Text = linkButton.CommandArgument.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid1.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Footer_Title");
            this.RadGrid1.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.RadGrid1.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.spnTempName.InnerText = this.objLanguage.GetLanguageConversion("Title");
            this.SpnPhraseText.InnerText = this.objLanguage.GetLanguageConversion("Footer_Signature");
            this.spn_defaultSignature.InnerText = this.objLanguage.GetLanguageConversion("Set_as_Default_Signature");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            if (!base.IsPostBack)
            {
                this.FooterSignatureGridBind();
                this.hdnmode.Value = "";
            }
            this.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string empty = string.Empty;
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email"), "&nbsp;>>&nbsp;", this.objLanguage.GetLanguageConversion("Footer_Signature")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Footer_Signature");
            base.Title = this.objLanguage.convert(global.pageTitle("Email Signature", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            this.btnSave.Attributes.Add("onclick", "javascript:return Validate('');");
            if (base.Request.Params["action"] != null)
            {
                if (base.Request.Params["action"].ToString().ToLower() == "delete")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Footer_Title_Delete_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["action"].ToString().ToLower() == "edit")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Footer_Title_Saved_Successfully"), "msg-success", this.plhMessage);
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            this.lnkDeleteStatus.Attributes.Add("onclick", "javascript:return CallDelete();");
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
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }
    }
}