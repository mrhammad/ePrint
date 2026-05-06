using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class taskviewall : BaseClass, IRequiresSessionState
    {
        //protected Panel pnlTop;

        //protected usercontrol_AlphabetSearch ucAplhaSearch;

        //protected Panel pnlnoofrecordsperpage;

        //protected Label lblNoTask;

        //protected LinkButton Lnk2;

        //protected Panel pnlNorecord;

        //protected Label lblletter;

        //protected GridView dgrTask;

        //protected UpdatePanel UP1;

        //protected SqlDataSource SqlDataSource1;

        //protected HiddenField hdnTaskID;

        //protected Panel pnlCallScroll;

        public languageClass objLanguage = new languageClass();

        public viewClass objView = new viewClass();

        public string lnkurl = string.Empty;

        public string strImagepath;

        public int companyId;

        public int userId;

        private BaseClass objBase = new BaseClass();

        public string tabcolor = "";

        public string forecolor = "";

        public int companyid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public commonClass cmn = new commonClass();

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

        public taskviewall()
        {
        }

        protected void ddlnoofrecordsperpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgrTask.PageIndex = 0;
            this.dgrTask.DataSourceID = "SqlDataSource1";
            this.dgrTask.DataBind();
        }

        protected void ddlpageno_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.dgrTask.BottomPagerRow;
            DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
            this.dgrTask.PageIndex = dropDownList.SelectedIndex;
            this.dgrTask.DataSourceID = "SqlDataSource1";
            this.dgrTask.DataBind();
        }

        protected void dgrTask_DataBound(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.dgrTask.BottomPagerRow;
            if (this.dgrTask.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpageno");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.dgrTask.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.dgrTask.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.dgrTask.PageIndex + 1;
                    int pageCount = this.dgrTask.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.dgrTask.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.dgrTask.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.dgrTask.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.dgrTask.BottomPagerRow.FindControl("lbtnNext");
                    imageButton.ToolTip = this.objLanguage.convert("First");
                    imageButton1.ToolTip = this.objLanguage.convert("Last");
                    imageButton2.ToolTip = this.objLanguage.convert("Previous");
                    imageButton3.ToolTip = this.objLanguage.convert("Next");
                    if (pageIndex < pageCount)
                    {
                        imageButton3.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton.Enabled = false;
                        imageButton2.Enabled = false;
                    }
                    if (pageIndex == pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = false;
                        imageButton3.Enabled = false;
                    }
                    if (pageIndex > 1 && pageIndex < pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton3.Enabled = true;
                    }
                }
            }
        }

        protected void dgrTask_PageIndexChanging(object source, GridViewPageEventArgs e)
        {
            this.dgrTask.PageIndex = e.NewPageIndex;
            this.dgrTask.DataSourceID = "SqlDataSource1";
            this.dgrTask.DataBind();
        }

        protected void dgrTask_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.dgrTask.BottomPagerRow.Cells[0].FindControl("lblpageno");
            if (this.dgrTask.BottomPagerRow != null)
            {
                int pageIndex = this.dgrTask.PageIndex + 1;
                int pageCount = this.dgrTask.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void dgrTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Row.RowType != DataControlRowType.Header)
            {
                DataControlRowType rowType = e.Row.RowType;
                return;
            }
            setProperty.MakeGridViewHeaderClickable(this.dgrTask, e.Row, this.companyId, "home");
        }

        protected void lnkdetails_OnCommand(object sender, CommandEventArgs e)
        {
            HttpResponse response = base.Response;
            string[] strArrays = new string[] { global.sitePath(), "common/task_detail.aspx?taskid=", this.hdnTaskID.Value, "&tasktype=", e.CommandArgument.ToString(), "&tasktypeid=", e.CommandName.ToString() };
            response.Redirect(string.Concat(strArrays));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "welcome";
            this.gloobj.setpagename("home");
            global.pgDetail = string.Concat(this.objLanguage.convert("Home"), " >> ", this.objLanguage.convert("View All Task"));
            this.strImagepath = global.imagePath();
            this.SqlDataSource1.ConnectionString = this.cmn.strConnection;
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            this.forecolor = this.objpage.Forecolor(this.companyid, "home");
            this.companyId = int.Parse(this.Session["CompanyID"].ToString());
            this.userId = int.Parse(this.Session["userID"].ToString());
            SetProperties setProperty = new SetProperties();
            setProperty.setGridViewProprtieswithoutpagesize(this.dgrTask, int.Parse(this.Session["companyID"].ToString()), " ");
            base.Navigation_Path("<a href=../welcome.aspx style=text-decoration:underline class='subnavigator'></a>", "&nbsp;&nbsp;View All Task");
            if (!base.IsPostBack)
            {
                for (int i = 0; i < this.dgrTask.Columns.Count; i++)
                {
                    this.dgrTask.Columns[i].HeaderText = this.objLanguage.convert(this.dgrTask.Columns[i].HeaderText);
                }
                this.dgrTask.DataSourceID = "SqlDataSource1";
                this.dgrTask.DataBind();
                this.dgrTask.PageSize = 1000000;
                try
                {
                    this.lnkurl = base.Request.UrlReferrer.ToString();
                    this.Lnk2.PostBackUrl = base.Request.UrlReferrer.ToString();
                }
                catch
                {
                }
                if (this.dgrTask.Rows.Count == 0)
                {
                    this.pnlnoofrecordsperpage.Visible = false;
                }
            }
            this.dgrTask.Columns[2].HeaderText = "Contact Name";
            this.ucAplhaSearch.OnFilterChange += new SearchChangeEventHandler(this.ucAplhaSearch_OnFilterChange);
        }

        private void ucAplhaSearch_OnFilterChange(string AlphabetChar)
        {
            this.lblletter.Text = AlphabetChar;
            this.dgrTask.DataBind();
        }
    }
}