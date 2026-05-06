using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsLogin;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint
{
    public partial class welcome : BaseClass, IRequiresSessionState
    {
        public int UserID;

        public string strpath;

        public languageClass lcs;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.sitePath();

        public commonClass cmn = new commonClass();

        public DateTime ReqDate = new DateTime();

        public string dispstatus;

        public string disptype;

        public languageClass objLanguage = new languageClass();

        private loginClass login = new loginClass();

        private Global gloobj = new Global();

        public string pg = "home";

        public int companyid;

        public string pnlTask = "none";

        public string Check = string.Empty;

        public string Check1 = string.Empty;

        public string bgcolor = string.Empty;

        public string strRedirect = string.Empty;

        public string tabcolor = "";

        private string msg = "";

        private string ddlvalue = string.Empty;

        public BaseClass objBase = new BaseClass();

        public BasePage objpage = new BasePage();

        public string Delete_Row_Selection_Alert = string.Empty;

        public string DateFormat = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private languageClass objLangClass = new languageClass();

        private commonClass objJava = new commonClass();

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

        public welcome()
        {
        }

        protected void BindGrid_Today()
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_home_events_today_select");
            database.AddInParameter(storedProcCommand, "@intCompID", DbType.Int32, this.companyid);
            database.AddInParameter(storedProcCommand, "@intAssignedID", DbType.Int32, this.UserID);
            database.AddInParameter(storedProcCommand, "@reqdate", DbType.DateTime, Convert.ToDateTime(this.hdnreqDate.Value));
            dataSet = database.ExecuteDataSet(storedProcCommand);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["Subject"] = base.SpecialDecode(row["Subject"].ToString());
                row["Location"] = base.SpecialDecode(row["Location"].ToString());
            }
            this.GridView1.DataSource = dataSet;
            this.GridView1.DataBind();
        }

        protected void BindGrid_Tomorrow()
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_home_events_today_select");
            database.AddInParameter(storedProcCommand, "@intCompID", DbType.Int32, this.companyid);
            database.AddInParameter(storedProcCommand, "@intAssignedID", DbType.Int32, this.UserID);
            database.AddInParameter(storedProcCommand, "@reqdate", DbType.DateTime, Convert.ToDateTime(this.hdnreqDate1.Value));
            dataSet = database.ExecuteDataSet(storedProcCommand);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["Subject"] = base.SpecialDecode(row["Subject"].ToString());
                row["Location"] = base.SpecialDecode(row["Location"].ToString());
            }
            this.GridView2.DataSource = dataSet;
            this.GridView2.DataBind();
        }

        protected void BindGridTask()
        {
            try
            {
                DataSet dataSet = new DataSet();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("crm_home_TaskView_select");
                database.AddInParameter(storedProcCommand, "@intCompID", DbType.Int32, this.companyid);
                database.AddInParameter(storedProcCommand, "@intAssignedID", DbType.Int32, this.UserID);
                database.AddInParameter(storedProcCommand, "@strTime", DbType.Int32, 0);
                database.AddInParameter(storedProcCommand, "@disptype", DbType.String, this.DropDownList1.SelectedValue);
                dataSet = database.ExecuteDataSet(storedProcCommand);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    row["Subject"] = base.SpecialDecode(row["Subject"].ToString());
                    row["ContactName"] = base.SpecialDecode(row["ContactName"].ToString());
                    row["Description"] = base.SpecialDecode(row["Description"].ToString());
                    row["AssignToUserName"] = base.SpecialDecode(row["AssignToUserName"].ToString());
                    row["ClientName"] = base.SpecialDecode(row["ClientName"].ToString());
                }
                this.GridViewTask.DataSource = dataSet;
                this.GridViewTask.DataBind();
            }
            catch
            {
            }
        }

        public void btnAddEvent_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0"));
        }

        public void btnAddtask_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "common/task_add.aspx?tasktype=home&tasktypeid=0"));
        }

        protected void btnNewEvent_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0"));
        }

        protected void btnnewtask_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "common/task_add.aspx?tasktype=home&tasktypeid=0"));
        }

        protected void btnRedirectToClient_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(this.hdnRedirectPath.Value);
        }

        protected void Calendar_And_Event(DateTime DatePara)
        {
            this.ImageButton1.ImageUrl = string.Concat(global.imagePath(), "day.png");
            this.ImageButton2.ImageUrl = string.Concat(global.imagePath(), "week.png");
            this.ImageButton3.ImageUrl = string.Concat(global.imagePath(), "cal.gif");
            this.ImageButton4.ImageUrl = string.Concat(global.imagePath(), "viewall.gif");
            this.ImageButton1.PostBackUrl = string.Concat(global.sitePath(), "common/event_dayview.aspx?ReqDate=", DatePara.ToShortDateString());
            this.ImageButton2.PostBackUrl = string.Concat(global.sitePath(), "common/event_weekview.aspx?ReqDate=", DatePara.ToShortDateString());
            this.ImageButton3.PostBackUrl = string.Concat(global.sitePath(), "common/event_monthview.aspx?ReqDate=", DatePara.ToShortDateString());
            this.ImageButton4.PostBackUrl = string.Concat(global.sitePath(), "common/event_allview.aspx?ReqDate=", DatePara.ToShortDateString());
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.hdnreqDate.Value = this.Calendar1.SelectedDate.ToShortDateString();
            this.Calendar_And_Event(Convert.ToDateTime(this.hdnreqDate.Value));
            this.BindGrid_Today();
            this.Check = this.cmn.Eprint_return_Date_Before_View(this.hdnreqDate.Value, this.companyid, this.UserID, false);
            HiddenField shortDateString = this.hdnreqDate1;
            DateTime selectedDate = this.Calendar1.SelectedDate;
            shortDateString.Value = selectedDate.AddDays(1).ToShortDateString();
            this.BindGrid_Tomorrow();
            this.Check1 = this.cmn.Eprint_return_Date_Before_View(this.hdnreqDate1.Value, this.companyid, this.UserID, false);
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            this.hdnreqDate.Value = this.Calendar1.VisibleDate.ToShortDateString();
            string str = base.date_Check(this.DateFormat, this.hdnreqDate.Value);
            this.Calendar_And_Event(Convert.ToDateTime(str));
            this.BindGrid_Today();
            this.Check = str;
            HiddenField shortDateString = this.hdnreqDate1;
            DateTime visibleDate = this.Calendar1.VisibleDate;
            shortDateString.Value = visibleDate.AddDays(1).ToShortDateString();
            this.BindGrid_Tomorrow();
            this.Check1 = base.date_Check(this.DateFormat, this.hdnreqDate1.Value);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dispstatus = this.DropDownList1.SelectedItem.Value;
            base.Response.Redirect(string.Concat("welcome.aspx?dispstatus=", this.DropDownList1.SelectedItem.Value));
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.GridView1.BottomPagerRow;
            if (this.GridView1.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpageno");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.GridView1.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.GridView1.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.GridView1.PageIndex + 1;
                    int pageCount = this.GridView1.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnNext");
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

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.GridView1.BottomPagerRow.Cells[0].FindControl("lblpageno");
            if (this.GridView1.BottomPagerRow != null)
            {
                int pageIndex = this.GridView1.PageIndex + 1;
                int pageCount = this.GridView1.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.Cells[1].FindControl("lnksubject");
                Label label1 = (Label)e.Row.Cells[1].FindControl("lblEventID");
                string str = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&eventid=", label1.Text);
                string[] text = new string[] { "<a href=", str, " title='", label.Text, "' >", label.Text, "</a>" };
                label.Text = string.Concat(text);
            }
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.GridView2.BottomPagerRow;
            if (this.GridView2.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpageno");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.GridView2.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.GridView2.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.GridView2.PageIndex + 1;
                    int pageCount = this.GridView2.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.GridView2.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.GridView2.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.GridView2.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.GridView2.BottomPagerRow.FindControl("lbtnNext");
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.Cells[1].FindControl("lnksubject");
                Label label1 = (Label)e.Row.Cells[1].FindControl("lblEventID");
                string str = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&eventid=", label1.Text);
                string[] text = new string[] { "<a href=", str, " title='", label.Text, "' >", label.Text, "</a>" };
                label.Text = string.Concat(text);
            }
        }

        protected void GridViewTask_DataBound(object sender, EventArgs e)
        {
            this.GridViewTask.PageSize = 10000;
            GridViewRow bottomPagerRow = this.GridViewTask.BottomPagerRow;
            if (this.GridViewTask.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpageno");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.GridViewTask.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.GridViewTask.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.GridViewTask.PageIndex + 1;
                    int pageCount = this.GridViewTask.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.GridViewTask.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.GridViewTask.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.GridViewTask.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.GridViewTask.BottomPagerRow.FindControl("lbtnNext");
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

        protected void GridViewTask_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.GridViewTask.BottomPagerRow.Cells[0].FindControl("lblpageno");
            if (this.GridViewTask.BottomPagerRow != null)
            {
                int pageIndex = this.GridViewTask.PageIndex + 1;
                int pageCount = this.GridViewTask.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void GridViewTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((DataRowView)e.Row.DataItem)[0].ToString();
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                HtmlInputCheckBox str = (HtmlInputCheckBox)e.Row.FindControl("Id");
                str.Value = ((DataRowView)e.Row.DataItem)[0].ToString();
                setProperty.MakeGridViewRowStyle(this.GridViewTask, e.Row);
                this.Session["Popup"] = "Popup";
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkdetails");
                QueryString queryString = new QueryString()
			{
				{ "clientid", dataItem["clientid"].ToString() },
				{ "isnew", "2" },
				{ "bypass", "1" },
				{ "type", dataItem["CustomerType"].ToString() },
				{ "TaskID", dataItem["taskID"].ToString() },
				{ "ActivityType", "task" }
			};
                string empty = string.Empty;
                empty = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                string str1 = string.Concat(empty, queryString1.ToString());
                linkButton.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                Label label = (Label)e.Row.FindControl("lbl_assignToUserName");
                HiddenField hiddenField = (HiddenField)e.Row.FindControl("hdn_assignToUserId");
                Label label1 = (Label)e.Row.FindControl("lblCompanyname");
                Label label2 = (Label)e.Row.FindControl("lblContactname");
                if (hiddenField.Value != "-1" && hiddenField.Value != "0")
                {
                    label.Text = BaseClass.WrapString(label.Text.ToString().Trim(), 28);
                }
                else if (hiddenField.Value != "-1")
                {
                    label.Text = "";
                }
                else
                {
                    label.Text = "All";
                }
                Label label3 = (Label)e.Row.FindControl("lblDueDAte");
                label3.Text = this.cmn.Eprint_return_Date_Before_View(dataItem["dueDate"].ToString(), this.companyid, this.UserID, false);
                label1.ToolTip = base.SpecialDecode(dataItem["ClientName"].ToString());
                label2.ToolTip = base.SpecialDecode(dataItem["ContactName"].ToString());
            }
        }

        protected void lnkdetails_OnCommand(object sender, CommandEventArgs e)
        {
            HttpResponse response = base.Response;
            string[] strArrays = new string[] { global.sitePath(), "common/task_detail.aspx?taskid=", this.hdnTaskID.Value, "&tasktype=", e.CommandArgument.ToString(), "&tasktypeid=", e.CommandName.ToString() };
            response.Redirect(string.Concat(strArrays));
        }

        public void lnkTaskDelete_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnTaskIDs.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                taskClass _taskClass = new taskClass();
                _taskClass.task_Delete(this.pg, Convert.ToInt32(strArrays[i]), int.Parse(this.Session["companyid"].ToString()));
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Task_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            this.BindGridTask();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if ((new BaseClass()).Return_IsEnable_CRM(Convert.ToInt32(this.companyid)).Trim().ToLower() == "true")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "dashboard.aspx"));
            }
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.ImageButton1.ToolTip = this.objLanguage.GetLanguageConversion("Day_View");
            this.ImageButton2.ToolTip = this.objLanguage.GetLanguageConversion("Week_View");
            this.ImageButton3.ToolTip = this.objLanguage.GetLanguageConversion("Month_View");
            this.ImageButton4.ToolTip = this.objLanguage.GetLanguageConversion("All_View");
            this.DropDownList1.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
            this.DropDownList1.Items[1].Text = this.objLangClass.GetLanguageConversion("Today_Plus_Overdue");
            this.DropDownList1.Items[2].Text = this.objLangClass.GetLanguageConversion("Tomorrow");
            this.DropDownList1.Items[3].Text = this.objLangClass.GetLanguageConversion("Next_7_Days");
            this.DropDownList1.Items[4].Text = this.objLangClass.GetLanguageConversion("Next_7_Days_Plus_Overdue");
            this.DropDownList1.Items[5].Text = this.objLangClass.GetLanguageConversion("This_Month");
            this.DropDownList1.Items[6].Text = this.objLangClass.GetLanguageConversion("All_Open");
            this.DropDownList1.Items[7].Text = this.objLangClass.GetLanguageConversion("All");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect("error.aspx");
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.strpath = global.imagePath();
            global.pageName = "welcome";
            global.pgDetail = this.objLanguage.convert("Home");
            this.gloobj.setpagename("home");
            this.ImageButton1.ToolTip = this.objLanguage.convert(this.ImageButton1.ToolTip);
            this.ImageButton2.ToolTip = this.objLanguage.convert(this.ImageButton2.ToolTip);
            this.ImageButton3.ToolTip = this.objLanguage.convert(this.ImageButton3.ToolTip);
            this.ImageButton4.ToolTip = this.objLanguage.convert(this.ImageButton4.ToolTip);
            this.Calendar1.ToolTip = this.objLanguage.convert(this.Calendar1.ToolTip);
            this.Calendar1.TitleStyle.BackColor = Color.FromName(this.objpage.colorCode(this.companyid, "home"));
            this.Calendar1.TitleStyle.ForeColor = Color.FromName(this.objpage.Forecolor(this.companyid, "home"));
            BaseClass baseClass = new BaseClass();
            if (!base.IsPostBack)
            {
                HiddenField hiddenField = this.hdnreqDate;
                commonClass _commonClass = this.cmn;
                DateTime now = DateTime.Now;
                hiddenField.Value = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.companyid, this.UserID, true);
                this.Check = this.hdnreqDate.Value;
                this.hdnreqDate.Value = this.cmn.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.hdnreqDate.Value);
                this.Calendar_And_Event(Convert.ToDateTime(this.hdnreqDate.Value));
                HiddenField hiddenField1 = this.hdnreqDate1;
                commonClass _commonClass1 = this.cmn;
                DateTime dateTime = DateTime.Now.AddDays(1);
                hiddenField1.Value = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.companyid, Convert.ToInt32(this.Session["UserID"]), true);
                commonClass _commonClass2 = this.cmn;
                DateTime dateTime1 = DateTime.Now.AddDays(1);
                this.Check1 = _commonClass2.Eprint_return_Date_Before_View(dateTime1.ToString(), this.companyid, Convert.ToInt32(this.Session["UserID"]), true);
                this.hdnreqDate1.Value = this.cmn.eprint_checkdateformat_returnonlymmddyyyy("mm/dd/yyyy", this.hdnreqDate1.Value);
                this.Calendar_And_Event(Convert.ToDateTime(this.hdnreqDate.Value));
                this.Calendar1.TodaysDate = Convert.ToDateTime(this.hdnreqDate.Value);
                this.BindGrid_Today();
                this.BindGrid_Tomorrow();
                this.BindGridTask();
                this.hdnIDs.Value = "";
            }
            try
            {
                if (base.Request.QueryString["msg"] == "1")
                {
                    this.lblsuccessfull.Visible = true;
                    this.lblsuccessfull.Text = "Quick Settings Updated Successfully";
                }
            }
            catch
            {
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, this.pg);
            base.Title = this.objLanguage.convert(global.pageTitle("Home", int.Parse(this.Session["companyID"].ToString()), this.Session["companyName"].ToString()));
            this.pnlTask = "block";
            this.disptype = "";
            if (base.Request.Params["dispstatus"] == null || !(base.Request.Params["dispstatus"].ToString() != ""))
            {
                this.disptype = "ao";
            }
            else
            {
                this.disptype = base.Request.Params["dispstatus"].ToString();
            }
            if (!base.IsPostBack)
            {
                for (int i = 0; i < this.DropDownList1.Items.Count; i++)
                {
                    this.DropDownList1.Items[i].Text = this.objLanguage.convert(this.DropDownList1.Items[i].Text);
                }
                int num = 0;
                while (num < this.DropDownList1.Items.Count)
                {
                    if (this.DropDownList1.Items[num].Value != this.disptype)
                    {
                        num++;
                    }
                    else
                    {
                        this.DropDownList1.SelectedIndex = num;
                        break;
                    }
                }
                this.BindGridTask();
            }
            SqlCommand sqlCommand = new SqlCommand("crm_selecttheme", this.cmn.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@companyId", Convert.ToInt32(this.Session["CompanyID"]));
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                this.strImagepath = string.Concat(global.sitePath(), sqlDataReader["ImageFolder"].ToString(), "/");
            }
            sqlDataReader.Close();
            this.cmn.closeConnection();
            this.SqlDataSource1.ConnectionString = this.cmn.strConnection;
            this.SqlDataSource4.ConnectionString = this.cmn.strConnection;
            this.SqlDataSource5.ConnectionString = this.cmn.strConnection;
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
        }
    }
}