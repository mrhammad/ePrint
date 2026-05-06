using nmsCommon;
using nmsConnectionClass;
using nmsdatetimevalue;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class event_weekview : BaseClass, IRequiresSessionState
    {
        public string strpath;

        public string strdayname;

        public int weekdayvalint;

        public languageClass lcs;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public DateTime ReqDate = new DateTime();

        public DateTime nextweek = new DateTime();

        public DateTime nextdatetime = new DateTime();

        public DateTime previousdatetime = new DateTime();

        public DateTime newdatetime = new DateTime();

        public commonClass cmn = new commonClass();

        public datetimevalueclass dateval = new datetimevalueclass();

        public languageClass objLanguage = new languageClass();

        protected string ReqDate1 = "";

        protected string nextweek1 = "";

        protected string nextdatetime1 = "";

        protected string previousdatetime1 = "";

        protected string wekdayname = "";

        public string disptype = "";

        public string dispstatus = "";

        public int UserID;

        public string tabcolor = "";

        public int companyid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        public string DateFormat = string.Empty;

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

        public event_weekview()
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dispstatus = this.DropDownList1.SelectedItem.Value;
            base.Response.Redirect(string.Concat("event_weekview.aspx?dispstatus=", this.dispstatus, "&ReqDate=", this.ReqDate1.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            string str1;
            string str2;
            this.ImageButton1.ToolTip = this.objLanguage.GetLanguageConversion("Day_View");
            this.ImageButton2.ToolTip = this.objLanguage.GetLanguageConversion("Week_View");
            this.ImageButton3.ToolTip = this.objLanguage.GetLanguageConversion("Month_View");
            this.ImageButton4.ToolTip = this.objLanguage.GetLanguageConversion("All_View");
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            try
            {
                this.ReqDate = Convert.ToDateTime(base.Request.Params["ReqDate"]);
                this.disptype = "td";
            }
            catch
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                base.Response.End();
            }
            if (!base.IsPostBack)
            {
                this.ImageButton1.ToolTip = this.objLanguage.convert(this.ImageButton1.ToolTip);
                this.ImageButton2.ToolTip = this.objLanguage.convert(this.ImageButton2.ToolTip);
                this.ImageButton3.ToolTip = this.objLanguage.convert(this.ImageButton3.ToolTip);
                this.ImageButton4.ToolTip = this.objLanguage.convert(this.ImageButton4.ToolTip);
                try
                {
                    this.disptype = base.Request.Params["dispstatus"].ToString();
                }
                catch
                {
                    this.disptype = "td";
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
            }
            this.cmn.commonSectionHeader(this.plhHeader, "Week", "Week", "Week", "Add Task", "Add Event", "", "", "", "", "", "", "", "", string.Concat(global.sitePath(), "common/task_add.aspx?tasktype=home&tasktypeid=0"), string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0"), "", "", "", "", "", "", "", "");
            this.ReqDate1 = this.ReqDate.ToShortDateString();
            this.strpath = global.imagePath();
            global.pageName = "Welcome";
            this.gloobj.setpagename("welcome");
            global.pgDetail = this.objLanguage.convert("Home");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect("../error.aspx");
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetValueOnLang("Week_View_Event"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Week View Event");
            this.wekdayname = this.ReqDate.DayOfWeek.ToString();
            this.weekdayvalint = this.dateval.weekdayName(this.wekdayname);
            switch (this.weekdayvalint)
            {
                case 0:
                    {
                        this.strdayname = "SunDay";
                        this.newdatetime = this.ReqDate.AddDays(-6);
                        break;
                    }
                case 1:
                    {
                        this.strdayname = "MonDay";
                        this.newdatetime = this.ReqDate;
                        break;
                    }
                case 2:
                    {
                        this.strdayname = "TuesDay";
                        this.newdatetime = this.ReqDate.AddDays(-1);
                        break;
                    }
                case 3:
                    {
                        this.strdayname = "WednesDay";
                        this.newdatetime = this.ReqDate.AddDays(-2);
                        break;
                    }
                case 4:
                    {
                        this.strdayname = "ThursDay";
                        this.newdatetime = this.ReqDate.AddDays(-3);
                        break;
                    }
                case 5:
                    {
                        this.strdayname = "FriDay";
                        this.newdatetime = this.ReqDate.AddDays(-4);
                        break;
                    }
                case 6:
                    {
                        this.strdayname = "SaturDay";
                        this.newdatetime = this.ReqDate.AddDays(-5);
                        break;
                    }
            }
            this.nextdatetime = this.newdatetime.AddDays(7);
            this.previousdatetime = this.newdatetime.AddDays(-7);
            this.nextweek = this.newdatetime.AddDays(6);
            this.ReqDate1 = this.cmn.Eprint_return_Date_Before_View(this.newdatetime.ToShortDateString(), this.companyid, this.UserID, false);
            this.nextweek1 = this.cmn.Eprint_return_Date_Before_View(this.nextweek.ToShortDateString(), this.companyid, this.UserID, false);
            this.nextdatetime1 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.nextdatetime.ToShortDateString()));
            this.previousdatetime1 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.previousdatetime.ToShortDateString()));
            this.ImageButton1.ImageUrl = string.Concat(global.imagePath(), "day.png");
            this.ImageButton2.ImageUrl = string.Concat(global.imagePath(), "week.png");
            this.ImageButton3.ImageUrl = string.Concat(global.imagePath(), "cal.gif");
            this.ImageButton4.ImageUrl = string.Concat(global.imagePath(), "viewall.gif");
            string str3 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.ReqDate.ToShortDateString()));
            this.ImageButton1.PostBackUrl = string.Concat(global.sitePath(), "common/event_dayview.aspx?ReqDate=", str3);
            this.ImageButton2.PostBackUrl = string.Concat(global.sitePath(), "common/event_weekview.aspx?ReqDate=", str3);
            this.ImageButton3.PostBackUrl = string.Concat(global.sitePath(), "common/event_monthview.aspx?ReqDate=", str3);
            this.ImageButton4.PostBackUrl = string.Concat(global.sitePath(), "common/event_allview.aspx?ReqDate=", str3);
            int num1 = 1;
            for (int i = 0; i < 7; i++)
            {
                str = (num1 % 2 != 0 ? "NewAlternative" : "NewTable");
                this.eventdayview.Controls.Add(new LiteralControl(string.Concat("<tr valign=top class=", str, ">")));
                this.eventdayview.Controls.Add(new LiteralControl("<td nowrap align=left class=normaltext><b>"));
                ControlCollection controls = this.eventdayview.Controls;
                DateTime dateTime = this.newdatetime.AddDays((double)i);
                controls.Add(new LiteralControl(dateTime.ToLongDateString().ToString()));
                this.eventdayview.Controls.Add(new LiteralControl("</b></td>"));
                this.eventdayview.Controls.Add(new LiteralControl("<td nowrap align=right class=normaltext>--</td>"));
                this.eventdayview.Controls.Add(new LiteralControl("<td nowrap align=right class=normaltext>"));
                string str4 = "";
                str4 = string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0");
                HyperLink hyperLink = new HyperLink()
                {
                    Text = this.objLanguage.GetValueOnLang("New"),
                    NavigateUrl = str4
                };
                this.eventdayview.Controls.Add(hyperLink);
                this.eventdayview.Controls.Add(new LiteralControl("</td>"));
                this.eventdayview.Controls.Add(new LiteralControl("</tr>"));
                SqlCommand sqlCommand = new SqlCommand("crm_home_events_today_select", this.cmn.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@intAssignedID", this.Session["userid"]);
                sqlCommand.Parameters.AddWithValue("@intCompID", this.Session["companyID"]);
                SqlParameterCollection parameters = sqlCommand.Parameters;
                DateTime dateTime1 = this.newdatetime.AddDays((double)i);
                parameters.AddWithValue("@reqdate", dateTime1.ToShortDateString().ToString());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int num2 = 0;
                int num3 = 0;
                string str5 = "";
                string str6 = "";
                while (sqlDataReader.Read())
                {
                    string str7 = sqlDataReader["EventTime"].ToString();
                    if (str7 != "")
                    {
                        string[] strArrays = str7.Split(new char[] { ':' });
                        num2 = int.Parse(strArrays[0]);
                        num3 = int.Parse(strArrays[1]);
                    }
                    string str8 = sqlDataReader["duration"].ToString();
                    if (str8 == "")
                    {
                        str6 = "";
                    }
                    else
                    {
                        string[] strArrays1 = str8.Split(new char[] { ':' });
                        num2 = num2 + int.Parse(strArrays1[0]);
                        str1 = (num2.ToString().Length >= 2 ? num2.ToString() : string.Concat("0", num2.ToString()));
                        num3 = num3 + int.Parse(strArrays1[1]);
                        str2 = (num3.ToString().Length >= 2 ? num3.ToString() : string.Concat("0", num3.ToString()));
                        str6 = string.Concat(str1, ":", str2);
                    }
                    this.eventdayview.Controls.Add(new LiteralControl("<tr valign=top><td colspan=3>"));
                    this.eventdayview.Controls.Add(new LiteralControl("<table cellSpacing=0 cellPadding=5 width=99% align=center border=0"));
                    this.eventdayview.Controls.Add(new LiteralControl("<tr valign=top>"));
                    this.eventdayview.Controls.Add(new LiteralControl("<td nowrap class = normaltext>"));
                    this.eventdayview.Controls.Add(new LiteralControl(sqlDataReader["EventTime"].ToString()));
                    this.eventdayview.Controls.Add(new LiteralControl("-"));
                    this.eventdayview.Controls.Add(new LiteralControl(str6));
                    this.eventdayview.Controls.Add(new LiteralControl("</td>"));
                    this.eventdayview.Controls.Add(new LiteralControl("<td nowrap align=left class = normaltext>"));
                    str5 = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&eventid=", sqlDataReader["eventid"].ToString());
                    HyperLink hyperLink1 = new HyperLink();
                    if (sqlDataReader["subject"].ToString().Length <= 30)
                    {
                        hyperLink1.Text = base.SpecialDecode(sqlDataReader["subject"].ToString());
                    }
                    else
                    {
                        hyperLink1.Text = string.Concat(base.SpecialDecode(sqlDataReader["subject"].ToString().Substring(0, 30)), "..");
                    }
                    hyperLink1.NavigateUrl = str5;
                    this.eventdayview.Controls.Add(hyperLink1);
                    this.eventdayview.Controls.Add(new LiteralControl("</td>"));
                    this.eventdayview.Controls.Add(new LiteralControl("<td></td>"));
                    this.eventdayview.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
                }
                num1++;
                sqlDataReader.Close();
                this.cmn.closeConnection();
            }
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1 = new SqlCommand("PC_home_task_select_on_date", this.cmn.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@CompanyID", this.Session["companyID"]);
            sqlCommand1.Parameters.AddWithValue("@DisplayType", "week");
            sqlCommand1.Parameters.AddWithValue("@ReqDate", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            int num4 = 0;
            string str9 = "";
            string str10 = "";
            while (sqlDataReader1.Read())
            {
                str9 = (num4 % 2 != 0 ? "NewTable" : "NewAlternative");
                num4++;
                this.Taskplace.Controls.Add(new LiteralControl(string.Concat("<tr style=height:22 valign=middle class=", str9, ">")));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='1%'></td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width=18%>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left;width:20px;'>&nbsp;"));
                this.Taskplace.Controls.Add(new LiteralControl("</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left;width:10px;'>&nbsp;</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                this.Taskplace.Controls.Add(new LiteralControl(sqlDataReader1["dueDate"].ToString()));
                this.Taskplace.Controls.Add(new LiteralControl("</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='32%'>"));
                string[] strArrays2 = new string[] { global.sitePath(), "common/task_detail.aspx?tasktype=", sqlDataReader1["type"].ToString(), "&tasktypeid=", sqlDataReader1["typeId"].ToString(), "&taskid=", sqlDataReader1["taskid"].ToString() };
                str10 = string.Concat(strArrays2);
                HyperLink hyperLink2 = new HyperLink();
                if (sqlDataReader1["subject"].ToString().Length <= 30)
                {
                    hyperLink2.Text = base.SpecialDecode(sqlDataReader1["subject"].ToString());
                }
                else
                {
                    hyperLink2.Text = string.Concat(base.SpecialDecode(sqlDataReader1["subject"].ToString().Substring(0, 30)), "...");
                }
                hyperLink2.NavigateUrl = str10;
                this.Taskplace.Controls.Add(hyperLink2);
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td class=normaltext width=28%>"));
                int.Parse(sqlDataReader1["contactId"].ToString());
                this.Taskplace.Controls.Add(new LiteralControl(base.SpecialDecode(base.SpecialDecode(sqlDataReader1["contactname"].ToString()))));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext  width='22%' >"));
                this.Taskplace.Controls.Add(new LiteralControl(base.SpecialDecode(sqlDataReader1["taskstatus"].ToString())));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='1%'></td>"));
                this.Taskplace.Controls.Add(new LiteralControl("</tr>"));
            }
            if (!sqlDataReader1.HasRows)
            {
                this.Taskplace.Controls.Add(new LiteralControl("<tr valign=top><td colspan=3 class=normaltext>"));
                this.Taskplace.Controls.Add(new LiteralControl(this.objLanguage.convert("No Task on this week")));
                this.Taskplace.Controls.Add(new LiteralControl("</td></tr>"));
            }
            sqlDataReader1.Close();
            this.cmn.closeConnection();
        }

        private object split(object p, string p_2)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void weekdaysval(DateTime ReqDate, int strWeekDay)
        {
            switch (strWeekDay)
            {
                case 1:
                    {
                        this.strdayname = "SunDay";
                        this.newdatetime = ReqDate.AddDays(-6);
                        return;
                    }
                case 2:
                    {
                        this.strdayname = "MonDay";
                        this.newdatetime = ReqDate;
                        return;
                    }
                case 3:
                    {
                        this.strdayname = "TuesDay";
                        this.newdatetime = ReqDate.AddDays(-1);
                        return;
                    }
                case 4:
                    {
                        this.strdayname = "WednesDay";
                        this.newdatetime = ReqDate.AddDays(-2);
                        return;
                    }
                case 5:
                    {
                        this.strdayname = "ThursDay";
                        this.newdatetime = ReqDate.AddDays(-3);
                        return;
                    }
                case 6:
                    {
                        this.strdayname = "FriDay";
                        this.newdatetime = ReqDate.AddDays(-4);
                        return;
                    }
                case 7:
                    {
                        this.strdayname = "SaturDay";
                        this.newdatetime = ReqDate.AddDays(-5);
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}