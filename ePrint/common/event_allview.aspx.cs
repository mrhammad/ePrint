using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class event_allview : BaseClass, IRequiresSessionState
    {
        public string strImagepath;

        public string pg;

        public string abcd;

        public string letter = "";

        public string searchkeyword = "";

        public string strpath;

        public string alltextval;

        public int intStartIndex;

        public string strSitepath = global.sitePath();

        public DateTime ReqDate = new DateTime();

        public commonClass cmn = new commonClass();

        protected string ReqDate1 = "";

        public languageClass objLanguage = new languageClass();

        public string tabcolor = "";

        public string forecolor = "";

        public int companyid;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        public int UserID;

        public string DateFormat = string.Empty;

        public string UrlDate = string.Empty;

        public int totalrec;

        public string para = string.Empty;

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

        public event_allview()
        {
        }

        public void BindDataGrid(string sortField, string letter1, string keyword)
        {
            if (letter1 == null | (letter1 == ""))
            {
                letter1 = "XX";
            }
            if (keyword == null | (keyword == ""))
            {
                keyword = "xx";
            }
            commonClass _commonClass = new commonClass();
            object[] str = new object[] { "crm_activity_viewall_new ", this.companyid, ",", this.Session["userid"].ToString(), ",", sortField, ",", letter1, ",", keyword };
            string str1 = string.Concat(str);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str1, _commonClass.openConnection());
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["Subject"] = base.SpecialDecode(row["Subject"].ToString());
                row["ContactName"] = base.SpecialDecode(row["Subject"].ToString());
            }
            this.dgr.DataSource = dataSet;
            this.dgr.DataKeyField = "IDVal";
            this.dgr.DataBind();
            this.lblTotalRecords.Text = this.dgr.Items.Count.ToString();
            this.totalrec = this.dgr.Items.Count;
            if (this.dgr.Items.Count > 0)
            {
                for (int i = 0; i < this.dgr.Items.Count; i++)
                {
                    HyperLink hyperLink = new HyperLink();
                    hyperLink = (HyperLink)this.dgr.Items[i].Cells[1].FindControl("HyperLink1");
                    if (this.dgr.Items[i].Cells[5].Text.ToLower().Trim() != "event")
                    {
                        Label label = new Label();
                        label = (Label)this.dgr.Items[i].Cells[1].FindControl("lbltype");
                        Label label1 = (Label)this.dgr.Items[i].Cells[1].FindControl("lbltypeId");
                        string[] strArrays = new string[] { global.sitePath(), "common/task_detail.aspx?tasktype=", label.Text, "&tasktypeid=", label1.Text, "&taskid=", this.dgr.DataKeys[i].ToString() };
                        hyperLink.NavigateUrl = string.Concat(strArrays);
                    }
                    else
                    {
                        hyperLink.NavigateUrl = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&eventid=", this.dgr.DataKeys[i].ToString());
                    }
                }
                this.dgr.Columns[6].Visible = false;
                this.dgr.Columns[7].Visible = false;
                this.dgr.Columns[8].Visible = false;
                this.dgr.Columns[9].Visible = false;
                this.dgr.Columns[10].Visible = false;
            }
            if (this.dgr.Items.Count != 0)
            {
                this.dgr.Visible = true;
                this.pnlEmptyRecords.Visible = false;
                return;
            }
            this.dgr.Visible = false;
            this.pnlEmptyRecords.Visible = true;
            this.lblNoData.Text = this.objLanguage.convert("No record(s) found");
        }

        protected void ddlpageno_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            this.dgr.CurrentPageIndex = int.Parse(dropDownList.SelectedItem.Value) - 1;
            this.BindDataGrid("title", this.letter, this.searchkeyword);
        }

        public void dgr_ItemCreated(object s, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                TableCell tableCell = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Right,
                    VerticalAlign = VerticalAlign.Middle,
                    Width = Unit.Percentage(15)
                };
                DropDownList dropDownList = new DropDownList();
                ImageButton imageButton = new ImageButton();
                ImageButton imageButton1 = new ImageButton();
                ImageButton imageButton2 = new ImageButton();
                ImageButton imageButton3 = new ImageButton();
                Label label = new Label();
                Label label1 = new Label();
                Label str = new Label();
                label.Text = this.objLanguage.convert("Page");
                label1.Text = this.objLanguage.convert("of");
                label.CssClass = "normaltext";
                label1.CssClass = "normaltext";
                dropDownList.CssClass = "normaltext";
                dropDownList.AutoPostBack = true;
                dropDownList.Items.Clear();
                for (int i = 1; i <= this.dgr.PageCount; i++)
                {
                    dropDownList.Items.Add(i.ToString());
                }
                dropDownList.SelectedIndex = this.dgr.CurrentPageIndex;
                dropDownList.SelectedIndexChanged += new EventHandler(this.ddlpageno_SelectedIndexChanged);
                imageButton.ToolTip = this.objLanguage.convert("First");
                imageButton.CommandArgument = "First";
                imageButton.CommandName = "imgbutton";
                imageButton.ImageUrl = "~/images/icn_firstrecord.gif";
                imageButton.Command += new CommandEventHandler(this.lbtnFirst_Command);
                imageButton1.ToolTip = this.objLanguage.convert("Previous");
                imageButton1.CommandArgument = "Prev";
                imageButton1.CommandName = "imgbutton";
                imageButton1.ImageUrl = "~/images/icn_previous_record.gif";
                imageButton1.Command += new CommandEventHandler(this.lbtnFirst_Command);
                imageButton2.ToolTip = this.objLanguage.convert("Next");
                imageButton2.CommandArgument = "Next";
                imageButton2.CommandName = "imgbutton";
                imageButton2.ImageUrl = "~/images/icn_next_record.gif";
                imageButton2.Command += new CommandEventHandler(this.lbtnFirst_Command);
                imageButton3.ToolTip = this.objLanguage.convert("Last");
                imageButton3.CommandArgument = "Last";
                imageButton3.CommandName = "imgbutton";
                imageButton3.ImageUrl = "~/images/icn_last_record.gif";
                imageButton3.Command += new CommandEventHandler(this.lbtnFirst_Command);
                str.Text = this.dgr.PageCount.ToString();
                int currentPageIndex = this.dgr.CurrentPageIndex + 1;
                int pageCount = this.dgr.PageCount;
                if (currentPageIndex < pageCount)
                {
                    imageButton2.Enabled = true;
                    imageButton3.Enabled = true;
                    imageButton.Enabled = false;
                    imageButton1.Enabled = false;
                }
                if (currentPageIndex == pageCount)
                {
                    imageButton.Enabled = true;
                    imageButton1.Enabled = true;
                    imageButton3.Enabled = false;
                    imageButton2.Enabled = false;
                }
                if (currentPageIndex > 1 && currentPageIndex < pageCount)
                {
                    imageButton.Enabled = true;
                    imageButton1.Enabled = true;
                    imageButton3.Enabled = true;
                    imageButton2.Enabled = true;
                }
                tableCell.Controls.Add(label);
                tableCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                tableCell.Controls.Add(dropDownList);
                tableCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                tableCell.Controls.Add(label1);
                tableCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                tableCell.Controls.Add(str);
                tableCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                tableCell.Controls.Add(imageButton);
                tableCell.Controls.Add(imageButton1);
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(imageButton2);
                tableCell.Controls.Add(imageButton3);
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                e.Item.Controls.AddAt(7, tableCell);
                if (this.dgr.PageCount == 1)
                {
                    imageButton.Visible = false;
                    imageButton1.Visible = false;
                    imageButton2.Visible = false;
                    imageButton3.Visible = false;
                    label.Visible = false;
                    dropDownList.Visible = false;
                    label1.Visible = false;
                    str.Visible = false;
                }
            }
        }

        public void dgr_PageIndexChanged(object s, DataGridPageChangedEventArgs e)
        {
            this.dgr.CurrentPageIndex = e.NewPageIndex;
            this.BindDataGrid("title", this.letter, this.searchkeyword);
        }

        public void dgr_SortCommand(object s, DataGridSortCommandEventArgs e)
        {
            this.BindDataGrid(e.SortExpression, this.letter, this.searchkeyword);
        }

        private void lbtnFirst_Command(object sender, CommandEventArgs e)
        {
            string lower = e.CommandArgument.ToString().ToLower();
            string str = lower;
            if (lower != null)
            {
                if (str == "first")
                {
                    this.dgr.CurrentPageIndex = 0;
                }
                else if (str == "next")
                {
                    if (this.dgr.CurrentPageIndex >= this.dgr.PageCount - 1)
                    {
                        this.dgr.CurrentPageIndex = this.dgr.PageCount - 1;
                    }
                    else
                    {
                        DataGrid currentPageIndex = this.dgr;
                        currentPageIndex.CurrentPageIndex = currentPageIndex.CurrentPageIndex + 1;
                    }
                }
                else if (str != "prev")
                {
                    if (str == "last")
                    {
                        this.dgr.CurrentPageIndex = this.dgr.PageCount - 1;
                    }
                }
                else if (this.dgr.CurrentPageIndex < 1)
                {
                    this.dgr.CurrentPageIndex = 0;
                }
                else
                {
                    DataGrid dataGrid = this.dgr;
                    dataGrid.CurrentPageIndex = dataGrid.CurrentPageIndex - 1;
                }
            }
            this.BindDataGrid("title", this.letter, this.searchkeyword);
        }

        protected void lnkdetails_OnCommand(object sender, CommandEventArgs e)
        {
        }

        public void OnItemDataBound1(object sender, DataGridItemEventArgs e)
        {
            e.Item.Cells[e.Item.Cells.Count - 1].Visible = false;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = (Label)e.Item.FindControl("lblDueDate");
                label.Text = this.cmn.Eprint_return_Date_Before_View(dataItem["DateVal"].ToString(), this.companyid, this.UserID, false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            this.forecolor = this.objpage.Forecolor(this.companyid, "home");
            this.dgr.HeaderStyle.BackColor = Color.FromName(this.tabcolor);
            this.dgr.HeaderStyle.ForeColor = Color.FromName(this.objpage.Forecolor(this.companyid, "home"));
            base.Title = this.objLanguage.convert(global.pageTitle("View All Event", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;View All Event");
            this.pg = "Home";
            global.pageName = "welcome";
            this.gloobj.setpagename("welcome");
            global.pgDetail = string.Concat(this.objLanguage.convert("Home"), " >> ", this.objLanguage.convert("All Activity"));
            this.strImagepath = global.imagePath();
            try
            {
                this.letter = base.Request.Params["letter"];
                this.ReqDate = Convert.ToDateTime(base.Request.Params["ReqDate"]);
            }
            catch
            {
                this.letter = "";
            }
            this.ReqDate1 = this.ReqDate.ToShortDateString();
            this.ReqDate1 = base.date_Check(this.DateFormat, this.ReqDate1);
            this.ImageButton1.ImageUrl = string.Concat(global.imagePath(), "day.png");
            this.ImageButton2.ImageUrl = string.Concat(global.imagePath(), "week.png");
            this.ImageButton3.ImageUrl = string.Concat(global.imagePath(), "cal.gif");
            this.ImageButton4.ImageUrl = string.Concat(global.imagePath(), "viewall.gif");
            this.UrlDate = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.ReqDate.ToShortDateString()));
            this.ImageButton1.PostBackUrl = string.Concat(global.sitePath(), "common/event_dayview.aspx?ReqDate=", this.UrlDate);
            this.ImageButton2.PostBackUrl = string.Concat(global.sitePath(), "common/event_weekview.aspx?ReqDate=", this.UrlDate);
            this.ImageButton3.PostBackUrl = string.Concat(global.sitePath(), "common/event_monthview.aspx?ReqDate=", this.UrlDate);
            this.ImageButton4.PostBackUrl = string.Concat(global.sitePath(), "common/event_allview.aspx?ReqDate=", this.UrlDate);
            commonClass _commonClass = new commonClass();
            _commonClass.commonSectionHeader(this.plhHeader, "All View", "All View", "All View", "", "", "", "", "", "", "", "", "", "", string.Concat(global.sitePath(), "Document/Document_view.aspx"), string.Concat(global.sitePath(), "Documents/Document_add.aspx"), "", "", "", "", "", "", "", "");
            if (!base.IsPostBack)
            {
                this.ImageButton1.ToolTip = this.objLanguage.convert(this.ImageButton1.ToolTip);
                this.ImageButton2.ToolTip = this.objLanguage.convert(this.ImageButton2.ToolTip);
                this.ImageButton3.ToolTip = this.objLanguage.convert(this.ImageButton3.ToolTip);
                this.ImageButton4.ToolTip = this.objLanguage.convert(this.ImageButton4.ToolTip);
                this.lblNoData.Text = this.objLanguage.convert(this.lblNoData.Text);
                for (int i = 0; i < this.dgr.Columns.Count; i++)
                {
                    this.dgr.Columns[i].HeaderText = this.objLanguage.convert(this.dgr.Columns[i].HeaderText);
                }
                base.Cache["pgsize"] = "10000";
                this.BindDataGrid("title", this.letter, this.searchkeyword);
            }
            if (this.searchkeyword != "")
            {
                this.BindDataGrid("title", this.letter, this.searchkeyword);
            }
            this.abcd = "";
            for (int j = 65; j < 91; j++)
            {
                string str = new string((char)j, 1);
                event_allview commonEventAllview = this;
                string str1 = commonEventAllview.abcd;
                string[] urlDate = new string[] { str1, "<td class=lettersorting1 onmouseover=changeStyle(this,'lettersorting1_over','", this.tabcolor, "') onmouseout=changeStyle(this,'lettersorting1','#ffffff') onclick=javascript:window.location.href='event_allview.aspx?Reqdate=", this.UrlDate, "&letter=", str, "'>", str, "</td>" };
                commonEventAllview.abcd = string.Concat(urlDate);
            }
            this.ucAplhaSearch.OnFilterChange += new SearchChangeEventHandler(this.ucAplhaSearch_OnFilterChange);
        }

        private void ucAplhaSearch_OnFilterChange(string AlphabetChar)
        {
            this.BindDataGrid("title", AlphabetChar, this.searchkeyword);
        }
    }
}