using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
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

namespace ePrint.settings
{
    public partial class litho_press_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected LinkButton btnDelete;

        //protected RadGrid RadGrid1;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hidGridCount;

        //protected HiddenField hid_Delete_IDs;

        public languageClass objlang = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private BasePage objPage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass objJava = new commonClass();

        public int CompanyID;

        public int totalrec;

        public int PageSize = 10000;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public litho_press_view()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        SettingsBasePage.settings_lithopress_delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Press_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridBind(this.CompanyID, this.PageSize, 1, "LithoPressName", "asc", "");
            this.RadGrid1.Rebind();
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        protected void GridBind(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            DataSet dataSet = SettingsBasePage.settings_litho_press_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["LithoPressName"] = base.SpecialDecode(row["LithoPressName"].ToString());
                row["Description"] = base.SpecialDecode(row["Description"].ToString());
            }
            this.RadGrid1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_Main.Style.Add("display", "block");
            this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
            this.RadGrid1.DataBind();
        }

        protected void GridDigitalPress_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void imgCopy_OnCommand(object sender, CommandEventArgs e)
        {
            SettingsBasePage.lithopress_New_Copy(Convert.ToInt64(e.CommandArgument.ToString()));
            this.GridBind(this.CompanyID, this.PageSize, 1, "LithoPressName", "asc", "");
            this.RadGrid1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Press_Copied_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_lithopress_delete(this.CompanyID, Convert.ToInt64(e.CommandArgument.ToString()));
            base.Message_Display(this.objLanguage.GetLanguageConversion("Press_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridBind(this.CompanyID, this.PageSize, 1, "LithoPressName", "asc", "");
            this.RadGrid1.Rebind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid1.MasterTableView.Columns[4].HeaderText = this.objlang.GetValueOnLang("Action");
            this.RadGrid1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Default");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_Display");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            base.Navigation_Path(string.Concat("<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Plant_Presses_Sheet_Fed_Offset_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Sheet Fed Offset View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset_View");
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            this.GridBind(this.CompanyID, this.PageSize, 1, "LithoPressName", "asc", "");
            if (!base.IsPostBack)
            {
                if (base.Request.Params["action"] != null)
                {
                    if (base.Request.Params["action"].ToString().ToLower() == "add")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Press_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    else if (base.Request.Params["action"].ToString().ToLower() == "edit")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Press_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString().ToLower() == "de")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Press_Deleted_Successfully"), "msg-success", this.plhMessage);
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
            if (this.RadGrid1.Items.Count == 0)
            {
                this.btnDelete.Visible = false;
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                BaseClass baseClass = new BaseClass();
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_DefaultDigitalPress");
                    Image image = (Image)e.Item.FindControl("img_DefaultDigitalPress");
                    if (hiddenField.Value != "True")
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkbox_u.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkboxNew.gif");
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
            catch
            {
            }
        }

        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid1.Rebind();
        }

        protected void setDefaultPress_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_litho_press_SetDefault(this.CompanyID, Convert.ToInt32(e.CommandArgument));
            this.objBase.Message_Display(this.objlang.GetLanguageConversion("Litho_press_set_successfully"), "msg-success", this.plhMessage);
            this.GridBind(this.CompanyID, this.PageSize, 1, "LithoPressName", "asc", "");
        }
    }
}