using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class event_monthview : BaseClass, IRequiresSessionState
    {
        public string strpath;

        public string alltextval;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public DateTime ReqDate = new DateTime();

        public commonClass cmn = new commonClass();

        protected string ReqDate1 = "";

        public languageClass objLanguage = new languageClass();

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

        public event_monthview()
        {
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            string str;
            string str1;
            SqlCommand sqlCommand = new SqlCommand("crm_home_events_today_select", this.cmn.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@intAssignedID", this.Session["userid"]);
            sqlCommand.Parameters.AddWithValue("@intCompID", this.Session["companyID"]);
            SqlParameterCollection parameters = sqlCommand.Parameters;
            DateTime date = e.Day.Date;
            parameters.AddWithValue("@reqdate", date.ToShortDateString());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            this.alltextval = "";
            this.alltextval = string.Concat(this.alltextval, "<table cellSpacing=0 cellPadding=0 width=100% align=center border=0>");
            TimeSpan timeSpan = e.Day.Date - new DateTime(2000, 1, 1);
            timeSpan.Days.ToString();
            string str6 = global.sitePath();
            DateTime dateTime = e.Day.Date;
            str3 = string.Concat(str6, "common/event_dayview.aspx?ReqDate=", dateTime.ToShortDateString());
            string str7 = string.Concat("<a href=\"", str3, "\">", e.Day.DayNumberText);
            this.alltextval = string.Concat(this.alltextval, "<tr><td valign = top class = normaltext>", str7, "</td></tr>");
            while (sqlDataReader.Read())
            {
                string str8 = sqlDataReader["EventTime"].ToString();
                if (str8 != "")
                {
                    string[] strArrays = str8.Split(new char[] { ':' });
                    num = int.Parse(strArrays[0]);
                    num1 = int.Parse(strArrays[1]);
                }
                string str9 = sqlDataReader["duration"].ToString();
                if (str9 == "")
                {
                    str4 = "";
                }
                else
                {
                    string[] strArrays1 = str9.Split(new char[] { ':' });
                    num = num + int.Parse(strArrays1[0]);
                    str = (num.ToString().Length >= 2 ? num.ToString() : string.Concat("0", num.ToString()));
                    num1 = num1 + int.Parse(strArrays1[1]);
                    str1 = (num1.ToString().Length >= 2 ? num1.ToString() : string.Concat("0", num1.ToString()));
                    str4 = string.Concat(str, ":", str1);
                }
                str2 = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&eventid=", sqlDataReader["eventid"].ToString());
                HyperLink hyperLink = new HyperLink()
                {
                    Text = sqlDataReader["subject"].ToString(),
                    NavigateUrl = str2
                };
                str5 = string.Concat(str5, " <tr><td align = left class=normaltext><b>");
                str5 = string.Concat(str5, sqlDataReader["EventTime"].ToString(), "-", str4.ToString());
                str5 = string.Concat(str5, "</b></td></tr>");
                str5 = string.Concat(str5, " <tr><td align = left class=normaltext>&nbsp");
                string[] strArrays2 = new string[] { str5, "<a href=\"", str2, "\">", base.SpecialDecode(sqlDataReader["subject"].ToString()) };
                str5 = string.Concat(strArrays2);
                str5 = string.Concat(str5, "</td></tr>");
            }
            this.alltextval = string.Concat(this.alltextval, str5, "</table>");
            e.Cell.Text = this.alltextval;
            num2++;
            sqlDataReader.Close();
            this.cmn.closeConnection();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ImageButton1.ToolTip = this.objLanguage.GetLanguageConversion("Day_View");
            this.ImageButton2.ToolTip = this.objLanguage.GetLanguageConversion("Week_View");
            this.ImageButton3.ToolTip = this.objLanguage.GetLanguageConversion("Month_View");
            this.ImageButton4.ToolTip = this.objLanguage.GetLanguageConversion("All_View");
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            this.strpath = global.imagePath();
            global.pageName = "Welcome";
            this.gloobj.setpagename("welcome");
            global.pgDetail = this.objLanguage.convert("Home");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect("../error.aspx");
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            this.Calendar1.TitleStyle.BackColor = Color.FromName(this.tabcolor);
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Month_View_Event"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Month View Event");
            try
            {
                this.ReqDate = Convert.ToDateTime(base.Request.Params["ReqDate"]);
            }
            catch
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                base.Response.End();
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            if (!base.IsPostBack)
            {
                this.ImageButton1.ToolTip = this.objLanguage.convert(this.ImageButton1.ToolTip);
                this.ImageButton2.ToolTip = this.objLanguage.convert(this.ImageButton2.ToolTip);
                this.ImageButton3.ToolTip = this.objLanguage.convert(this.ImageButton3.ToolTip);
                this.ImageButton4.ToolTip = this.objLanguage.convert(this.ImageButton4.ToolTip);
            }
            this.cmn.commonSectionHeader(this.plhHeader, "Month", "Month", "Month", "Add Task", "Add Event", "", "", "", "", "", "", "", "", string.Concat(global.sitePath(), "common/task_add.aspx?tasktype=home&tasktypeid=0"), string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0"), "", "", "", "", "", "", "", "");
            this.ReqDate1 = this.ReqDate.ToShortDateString();
            this.Calendar1.TodaysDate = this.ReqDate;
            this.ImageButton1.ImageUrl = string.Concat(global.imagePath(), "day.png");
            this.ImageButton2.ImageUrl = string.Concat(global.imagePath(), "week.png");
            this.ImageButton3.ImageUrl = string.Concat(global.imagePath(), "cal.gif");
            this.ImageButton4.ImageUrl = string.Concat(global.imagePath(), "viewall.gif");
            string str = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.ReqDate.ToShortDateString()));
            this.ImageButton1.PostBackUrl = string.Concat(global.sitePath(), "common/event_dayview.aspx?ReqDate=", str);
            this.ImageButton2.PostBackUrl = string.Concat(global.sitePath(), "common/event_weekview.aspx?ReqDate=", str);
            this.ImageButton3.PostBackUrl = string.Concat(global.sitePath(), "common/event_monthview.aspx?ReqDate=", str);
            this.ImageButton4.PostBackUrl = string.Concat(global.sitePath(), "common/event_allview.aspx?ReqDate=", str);
        }
    }
}