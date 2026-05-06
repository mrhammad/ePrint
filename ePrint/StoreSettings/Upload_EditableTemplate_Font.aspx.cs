using java.lang;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class Upload_EditableTemplate_Font : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strFilepathRad = global.filePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ImagePathFromFrontEnd = string.Empty;

        public string EditableTemplatePath = string.Empty;

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

        public System.Web.UI.WebControls.Image imgno_del = new System.Web.UI.WebControls.Image();

        public int PageSize = 10;

        public string GridStyleViews = string.Empty;

        private BaseClass objBass = new BaseClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string EmailSettingType = "e";

        public bool IsOccy = ConnectionClass.IsOccy;

        public string serverName = ConnectionClass.ServerName;

        public static int ddlSelectedValue;

        public string ActualFontFamilyName = string.Empty;

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

        static Upload_EditableTemplate_Font()
        {
        }

        public Upload_EditableTemplate_Font()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            string[] strArrays = this.hdnIDs.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                long num = Convert.ToInt64(strArrays[i].ToString());
                SettingsBasePage.Font_Delete((long)this.CompanyID, num);
                flag = true;
            }
            if (flag)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Font_Deleted_Sucessfully"), "msg-success", this.plhMessage);
                this.GridBind();
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            if (this.fup_Fonts.HasFile)
            {
                empty = this.fup_Fonts.FileName;
                if (!Directory.Exists(string.Concat(this.SecureDocPath, "//", this.serverName, "//editabletemplatebackend//Fonts")))
                {
                    Directory.CreateDirectory(string.Concat(this.SecureDocPath, "//", this.serverName, "//editabletemplatebackend//Fonts"));
                }
                string str1 = string.Concat(this.SecureDocPath, "//", this.serverName, "//editabletemplatebackend//Fonts//");
                int num = empty.LastIndexOf(".");
                if (num >= 0)
                {
                    str = empty.Substring(num);
                }
                bool flag = false;
                if (System.IO.File.Exists(string.Concat(str1, empty)))
                {
                    flag = true;
                    privateFontCollection.AddFontFile(string.Concat(str1, empty));
                    this.ActualFontFamilyName = privateFontCollection.Families[0].Name;
                }
                if (str.ToLower() == ".ttf" && !System.IO.File.Exists(string.Concat(str1, empty)))
                {
                    flag = true;
                    this.fup_Fonts.SaveAs(string.Concat(str1, empty));
                    privateFontCollection.AddFontFile(string.Concat(str1, empty));
                    this.ActualFontFamilyName = privateFontCollection.Families[0].Name;
                }
                SettingsBasePage.Font_Insert_Update((long)this.CompanyID, this.txtFontName.Text, (long)this.UserID, this.fup_Fonts.FileName.ToString(), flag, str, this.ActualFontFamilyName);
                this.GridBind();
                if (this.ActualFontFamilyName.Length >= 31)
                {
                    this.SendMail(this.txtFontName.Text);
                }
                this.divmsg.Style.Add("padding-bottom", "0px");
                base.Message_Display(this.objLanguage.GetLanguageConversion("Font_Uploaded_Sucessfully"), "msg-success", this.plhMessage);
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.grdFont.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.grdFont.MasterTableView.FilterExpression = string.Empty;
            this.grdFont.Rebind();
        }

        protected void grdFont_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdFont.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdFont.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_IsUsedFont");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonErase");
                ImageButton languageConversion1 = (ImageButton)e.Item.FindControl("ImageBtnDwnld");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                languageConversion1.ToolTip = this.objLanguage.GetLanguageConversion("Download_this_font");
                if (hiddenField.Value == "1")
                {
                    imageButton.Visible = false;
                    htmlInputCheckBox.Disabled = true;
                    return;
                }
                imageButton.Visible = true;
                htmlInputCheckBox.Disabled = false;
            }
        }

        public void GridBind()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Font_Select((long)this.CompanyID);
            this.grdFont.DataSource = dataTable;
            this.grdFont.DataBind();
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("setting", "UploadFont", this.grdFont, "no");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("setting", "UploadFont", this.grdFont);
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = (long)Convert.ToInt32(imageButton.CommandArgument.ToString());
            SettingsBasePage.Font_Delete((long)this.CompanyID, num);
            base.Message_Display("Font Deleted Sucessfully", "msg-success", this.plhMessage);
            this.GridBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdFont.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
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
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            string empty = string.Empty;
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Upload_Font")));
            base.Title = this.objLanguage.convert(global.pageTitle("Upload Font", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Upload_Font");
            this.grdFont.MasterTableView.NoDetailRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
            this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("eStore_Settings"), ": ", this.objLanguage.GetLanguageConversion("Upload_Font"));
            this.lnkDeleteStatus.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.grdFont.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Font_Friendly_Name");
            this.grdFont.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Font_Actual_Name");
            this.grdFont.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.grdFont.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RFVFontName.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Font_Name");
            this.CustomValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_upload_only_ttf_or_otf_file");
            this.img_Anchor.Title = this.objLanguage.GetLanguageConversion("Font_File_Image_Note_ToolTip");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (ConnectionClass.EditableTemplatePath != null)
            {
                this.EditableTemplatePath = ConnectionClass.EditableTemplatePath;
            }
            if (ConnectionClass.EditableFrontEndPath != null)
            {
                this.ImagePathFromFrontEnd = ConnectionClass.EditableFrontEndPath;
            }
            this.GridBind();
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
                this.grdFont.Rebind();
            }
        }

        protected void SendMail(string FontName)
        {
            string empty = string.Empty;
            if (this.fup_Fonts.HasFile)
            {
                empty = this.fup_Fonts.FileName;
            }
            string str = string.Empty;
            //string str1 = "support@eprintsoftware.com";
            string str1 = "support@hexicomsoftware.com";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            str = "";
            string str7 = "";
            string str8 = "Urgent Upload Editable Template Font";
            if (this.Session["firstName"].ToString() != null)
            {
                str6 = base.SpecialDecode(this.Session["firstName"].ToString());
            }
            if (this.Session["lastName"].ToString() != null)
            {
                str6 = string.Concat(str6, base.SpecialDecode(this.Session["lastName"].ToString()));
            }
            if (this.Session["CompanyName"] != null)
            {
                str = this.Session["CompanyName"].ToString();
            }
            if (this.Session["email"] != null)
            {
                str7 = this.Session["email"].ToString();
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
            stringBuilder.append(string.Concat("<div id='div_right' style='float:left;width:100%;'><table><tr><td width='150px' valign='top'><b>User Name: </b></td><td valign='top'>", str6, "</td></tr>"));
            stringBuilder.append(string.Concat("<tr><td width='150px' valign='top'><b>Email: </b></td><td valign='top'>", str7, "</td></tr>"));
            stringBuilder.append(string.Concat("<tr><td width='150px' valign='top'><b>Company Name: </b></td><td valign='top'>", str, "</td></tr>"));
            stringBuilder.append(string.Concat("<tr><td width='150px' valign='top'><b>Font Name: </b></td><td valign='top'>", FontName, "</td></tr>"));
            stringBuilder.append(string.Concat("<tr><td width='150px' valign='top'><b>File Name: </b></td><td valign='top'>", empty, "</td></tr>"));
            if (this.ActualFontFamilyName.Length >= 31)
            {
                stringBuilder.append(string.Concat("<tr><td width='150px' valign='top'><b> Note: </b></td><td valign='top'> The Actual Font Name contains more than 31 characters and the Actual Font Name is ", this.ActualFontFamilyName, "</td></tr>"));
            }
            stringBuilder.append("</table><br/>");
            stringBuilder.append("</div></div><div style='clear:both'>");
            string str9 = stringBuilder.ToString();
            BaseClass.SendMailMessage(str2.Trim(), str1.Trim(), str3.Trim(), str4.Trim(), str8, str9, str5, true);
        }
    }
}