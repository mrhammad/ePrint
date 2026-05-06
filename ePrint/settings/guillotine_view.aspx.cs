using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.settings
{
    public partial class guillotine_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton btnDelete;

        //protected HtmlGenericControl deletedropdown;

        //protected RadGrid GridGuillotine;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hidGridCount;

        //protected HiddenField hid_Delete_IDs;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public int totalrec;

        private BasePage objPage = new BasePage();

        private commonClass objJava = new commonClass();

        public int CompanyID;

        public int PageSize = 10000;

        public languageClass objlang = new languageClass();

        public string IsLarge = string.Empty;

        public string ParaForLarge = string.Empty;

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

        public guillotine_view()
        {
        }

        public void AddBoundColumns(DataTable dt, GridView gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    BoundField boundField = new BoundField()
                    {
                        HeaderText = dt.Columns[i].ColumnName,
                        SortExpression = dt.Columns[i].ColumnName,
                        DataField = dt.Columns[i].ColumnName
                    };
                    this.GridGuillotine.Columns.Add(boundField);
                }
                for (int j = 0; j < this.GridGuillotine.Columns.Count; j++)
                {
                    this.GridGuillotine.Columns[j].HeaderStyle.ForeColor = Color.White;
                    this.GridGuillotine.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridGuillotine.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "guillotineid")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "limitguillotinename")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "limitdescription")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "rownumber")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    if (this.GridGuillotine.Columns[j].SortExpression.ToLower() == "guillotinename")
                    {
                        this.GridGuillotine.Columns[j].Visible = false;
                    }
                    this.GridGuillotine.Columns[6].Visible = false;
                }
            }
        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.IsLarge, "yes", true) == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "Settings/guillotine_add.aspx?type=add&islarge=yes"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/guillotine_add.aspx?type=add"));
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
                        SettingsBasePage.Settings_Guillotine_Delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
            }
            this.GridBind(this.CompanyID, this.PageSize, 1, "GuillotineID", "desc", "");
            if (this.IsLarge != "yes")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Guillotine_Deleted_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Cutting_Table_Deleted_Successfully"), "msg-success", this.plhMessage);
            }
            string.Compare(this.IsLarge, "yes", true);
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
            DataSet dataSet = SettingsBasePage.settings_guillotine_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, this.IsLarge);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["GuillotineName"] = base.SpecialDecode(row["GuillotineName"].ToString());
                row["Description"] = base.SpecialDecode(row["Description"].ToString());
            }
            this.GridGuillotine.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.deletedropdown.Visible = false;
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
            }
            else
            {
                this.div_Main.Style.Add("display", "block");
                this.GridGuillotine.DataBind();
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
            }
            this.GridGuillotine.Rebind();
        }

        protected void GridGuillotine_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridGuillotine.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridGuillotine.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridGuillotine_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridGuillotine_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridGuillotine.CurrentPageIndex = e.NewPageIndex;
            this.GridGuillotine.Rebind();
        }

        protected void GridGuillotine_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridGuillotine.Rebind();
            if (this.IsLarge == "yes")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Cutting_Table_Deleted_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Guillotine_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgCopy_OnCommand(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Guillotine_New_Copy(Convert.ToInt64(e.CommandArgument.ToString()));
            this.GridBind(this.CompanyID, this.PageSize, 1, "GuillotineID", "desc", "");
            this.GridGuillotine.Rebind();
            if (this.IsLarge == "yes")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Cutting_Table_Copied_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Guillotine_Copied_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDelete_OnCommand(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Settings_Guillotine_Delete(this.CompanyID, Convert.ToInt64(e.CommandArgument));
            this.GridBind(this.CompanyID, this.PageSize, 1, "GuillotineID", "desc", "");
            if (this.IsLarge == "yes")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Cutting_Table_Deleted_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Guillotine_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void OnRowDataBound_GridGuillotine(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridGuillotine.MasterTableView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.GridGuillotine.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_Display");
            this.GridGuillotine.MasterTableView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Guillotine_Name");
            if (base.Request.Params["islarge"] != null)
            {
                this.IsLarge = "yes";
                this.ParaForLarge = "&islarge=yes";
            }
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Plant_Presses_Guillotine_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Guillotine View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Guillotine_View");
            try
            {
                if (base.Request.Params["islarge"].ToString() != null && base.Request.Params["islarge"].ToString() == "yes")
                {
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Plant_Presses_Cutting_Table_View")));
                    base.Title = this.objLanguage.convert(global.pageTitle(" Cutting Table View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.lblheader.Text = "Settings: Cutting Table View";
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Cutting_Table_View");
                    this.GridGuillotine.MasterTableView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Cutting_Table_Name");
                }
            }
            catch
            {
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.GridBind(this.CompanyID, this.PageSize, 1, "GuillotineID", "desc", "");
            if (base.Request.Params["suc"] != null)
            {
                string lower = base.Request.Params["suc"].ToString().ToLower();
                if (lower == "ins")
                {
                    if (this.IsLarge != "yes")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Guillotine_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    else
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Cutting_Table_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                else if (lower == "del")
                {
                    if (this.IsLarge != "yes")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Guillotine_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                    else
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Cutting_Table_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                else if (lower == "up")
                {
                    if (this.IsLarge != "yes")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Guillotine_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                    else
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Cutting_Table_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
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
            if (this.GridGuillotine.Items.Count == 0)
            {
                this.btnDelete.Visible = false;
            }
            this.btnDelete.Attributes.Add("onclick", "javascript:return CallDelete();");
        }
    }
}