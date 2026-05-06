using ePrint.usercontrol;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class user_manager : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected HtmlGenericControl lgdrole;

        //protected RadGrid GridRole;

        //protected SqlDataSource SqlDataSource2;

        //protected HiddenField hdnFIlter;

        //protected UpdatePanel UpdatePanel1;

        //protected HtmlGenericControl lgdusr;

        //protected RadGrid RadGrid2;

        //protected SqlDataSource SqlDataSource1;

        //protected SqlDataSource SqlDataSource4;

        //protected HiddenField hdnUserfilter;

        //protected UpdatePanel UpdatePanel2;

        //protected HiddenField hidGridCount;

        //protected Panel pnlCallScroll;

        private Global gloobj = new Global();

        public int totalrec;

        public int CompanyID;

        public long UserID;

        private DataView sdsView;

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private commonClass cmn = new commonClass();

        public int UserCount;

        public int NoOfUser;

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

        public user_manager()
        {
        }

        protected void btnAddRoles_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/roles_add.aspx?type=add"));
        }

        protected void btnAddUser_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/user_add.aspx?type=add"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
        }

        protected void GridRole_Insert(object source, GridCommandEventArgs e)
        {
        }

        protected void GridRole_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Label label = (Label)e.Item.FindControl("lblGenerateType");
                    Label label1 = (Label)e.Item.FindControl("lblUserType");
                    Image image = (Image)e.Item.FindControl("imgbtnEdit");
                    Label label2 = (Label)e.Item.FindControl("lblbDescription");
                    Label label3 = (Label)e.Item.FindControl("lblUserType1");
                    label3.Text = base.SpecialDecode(label3.Text);
                    label2.Text = base.SpecialDecode(label2.Text);
                    if (label1.Text.ToLower() == "administrator" || label1.Text.ToLower() == "user")
                    {
                        label.Text = "System";
                    }
                    else
                    {
                        label.Text = "User";
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
                GridTableView masterTableView = this.GridRole.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridRole.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridRole_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridRole_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridRole.CurrentPageIndex = e.NewPageIndex;
            this.GridRole.Rebind();
        }

        protected void GridRole_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridRole.Rebind();
        }

        protected void GridRole_PreRender(object sender, EventArgs e)
        {
            if (this.GridRole.MasterTableView.FilterExpression != string.Empty)
            {
                this.RefreshCombos();
            }
        }

        protected void GridUser_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void Onclick_BtnDisableAccount(object sender, CommandEventArgs e)
        {
            try
            {
                this.UserID = Convert.ToInt64(e.CommandArgument);
                WebstoreBasePage.Update_Disable_Account(this.UserID);
                this.RadGrid2.Rebind();
            }
            catch
            {
            }
        }

        protected void Onclick_ImgLockUser(object sender, CommandEventArgs e)
        {
            try
            {
                this.UserID = Convert.ToInt64(e.CommandArgument);
                WebstoreBasePage.Update_lock_account(this.UserID);
                this.RadGrid2.Rebind();
            }
            catch
            {
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridRole.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
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
            GridFilterMenu languageConversion = this.RadGrid2.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (languageConversion.Items[j].Text == "Custom")
                {
                    languageConversion.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion.Items[j].Text.ToLower() == "isempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "isnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "between")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notbetween")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "nofilter")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion.Items[j].Text.ToLower() == "contains")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion.Items[j].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion.Items[j].Text.ToLower() == "startswith")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "endswith")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SqlDataSource1.ConnectionString = this.cmn.strConnection;
            this.SqlDataSource2.ConnectionString = this.cmn.strConnection;
            this.SqlDataSource4.ConnectionString = this.cmn.strConnection;
            this.lgdrole.InnerText = this.objLanguage.GetLanguageConversion("Roles");
            this.lgdusr.InnerText = this.objLanguage.GetLanguageConversion("Users");
            this.GridRole.MasterTableView.Columns[0].HeaderText = this.objlang.GetValueOnLang("Role");
            this.GridRole.MasterTableView.Columns[1].HeaderText = this.objlang.GetValueOnLang("Description");
            this.GridRole.MasterTableView.Columns[2].HeaderText = this.objlang.GetValueOnLang("Generated Type");
            this.RadGrid2.MasterTableView.Columns[0].HeaderText = this.objlang.GetValueOnLang("User Name");
            this.RadGrid2.MasterTableView.Columns[2].HeaderText = this.objlang.GetValueOnLang("Email");
            this.RadGrid2.MasterTableView.Columns[3].HeaderText = this.objlang.GetValueOnLang("User Role");
            this.RadGrid2.MasterTableView.Columns[4].HeaderText = this.objlang.GetValueOnLang("Description");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            DataTable dataTable = WebstoreBasePage.RestrictedUser((long)this.CompanyID);
            this.UserCount = Convert.ToInt16(dataTable.Rows[0]["UserCount"].ToString());
            this.NoOfUser = Convert.ToInt16(dataTable.Rows[0]["noofuser"].ToString());
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("User_Manager")));
            base.Title = this.objLanguage.convert(global.pageTitle("User Manager", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("User_Manager");
            this.pnlCallScroll.Visible = true;
            this.GridRole.Rebind();
            this.RadGrid2.Rebind();
            try
            {
                if (base.Request.Params["Su"].ToLower() == "in")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("New_Role_Added_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["Su"].ToLower() == "up")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Role_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["Su"].ToLower() == "i")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("New_User_Added_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["Su"].ToLower() == "u")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("User_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["Su"].ToLower() == "d")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("User_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["Su"].ToLower() == "de")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Role_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
        }

        private void paging_OnPageChange(int PageNumber)
        {
            this.GridRole.DataBind();
            Paging.intPageCount = this.GridRole.PageCount;
        }

        protected void RadGrid2_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridEditFormItem item = (GridEditFormItem)e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtUserName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtUserEmail");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtPassword");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txtConfirmPassword");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txtDescription");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlrole");
            this.SqlDataSource1.UpdateParameters.Add("Name", textBox.Text);
            this.SqlDataSource1.UpdateParameters.Add("Email", textBox1.Text);
            this.SqlDataSource1.UpdateParameters.Add("Password", textBox2.Text);
            this.SqlDataSource1.UpdateParameters.Add("Description", textBox4.Text);
            this.SqlDataSource1.UpdateParameters.Add("CompanyID", this.CompanyID.ToString());
            this.SqlDataSource1.UpdateParameters.Add("UserType", dropDownList.SelectedValue.ToString());
            this.SqlDataSource1.UpdateParameters.Add("Disable", "false");
        }

        protected void RadGrid2_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("btnAction");
                    ImageButton imageButton1 = (ImageButton)e.Item.FindControl("ImgLockUser");
                    Label label = (Label)e.Item.FindControl("lblUserName");
                    Label label1 = (Label)e.Item.FindControl("lblUserRole");
                    Label label2 = (Label)e.Item.FindControl("lblEmail");
                    label.Text = base.SpecialDecode(label.Text);
                    label1.Text = base.SpecialDecode(label1.Text);
                    label2.Text = base.SpecialDecode(label2.Text);
                    if (((DataRowView)e.Item.DataItem)["IsValid"].ToString().ToLower() != "1")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = true;
                    }
                    else
                    {
                        imageButton.Visible = true;
                        imageButton1.Visible = false;
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
                GridTableView masterTableView = this.RadGrid2.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid2.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGrid2_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid2.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid2.Rebind();
        }

        protected void RadGrid2_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid2.Rebind();
        }

        protected void RadGrid2_PreRender(object sender, EventArgs e)
        {
            if (this.RadGrid2.MasterTableView.FilterExpression != string.Empty)
            {
                this.UserRefreshCombos();
            }
        }

        protected void RadGrid2_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditFormItem item = (GridEditFormItem)e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtUserName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtUserEmail");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtPassword");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txtConfirmPassword");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txtDescription");
            Label label = (Label)e.Item.FindControl("lblUserID");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlrole");
            this.SqlDataSource1.UpdateParameters.Add("CompanyID", this.companyid.ToString());
            this.SqlDataSource1.UpdateParameters.Add("UserID", label.Text.ToString());
            this.SqlDataSource1.UpdateParameters.Add("Name", textBox.Text);
            this.SqlDataSource1.UpdateParameters.Add("Email", textBox1.Text);
            this.SqlDataSource1.UpdateParameters.Add("Password", textBox2.Text);
            this.SqlDataSource1.UpdateParameters.Add("Description", textBox4.Text);
            this.SqlDataSource1.UpdateParameters.Add("UserType", dropDownList.SelectedValue.ToString());
            this.SqlDataSource1.UpdateParameters.Add("Disable", "0");
        }

        protected void RefreshCombos()
        {
            this.hdnFIlter.Value = string.Concat(" isdelete=0 and ", this.GridRole.MasterTableView.FilterExpression.ToString());
            this.GridRole.MasterTableView.Rebind();
        }

        protected void Table_OnDataBinding(object sender, EventArgs e)
        {
        }

        protected void UserRefreshCombos()
        {
            try
            {
                this.hdnUserfilter.Value = string.Concat(" a.isdelete=0 and ", this.RadGrid2.MasterTableView.FilterExpression.ToString());
                this.RadGrid2.MasterTableView.Rebind();
            }
            catch
            {
            }
        }

        private void usrPaging1_OnPageChange(int PageNumber)
        {
            this.RadGrid2.DataBind();
        }
    }
}