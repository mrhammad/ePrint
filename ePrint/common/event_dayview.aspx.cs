using nmsCommon;
using nmsConnectionClass;
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
    public partial class event_dayview : BaseClass, IRequiresSessionState
    {
        public string strpath;

        public languageClass lcs;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public DateTime ReqDate = new DateTime();

        public DateTime nextdatetime = new DateTime();

        public DateTime previousdatetime = new DateTime();

        public commonClass cmn = new commonClass();

        protected string ReqDate1 = "";

        public string DateFormat = string.Empty;

        protected string nextdatetime1 = "";

        protected string previousdatetime1 = "";

        public string disptype = "";

        public string dispstatus = "";

        public languageClass objLanguage = new languageClass();

        public int UserID;

        public string tabcolor = "";

        public int companyid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

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

        public event_dayview()
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dispstatus = this.DropDownList1.SelectedItem.Value;
            base.Response.Redirect(string.Concat("event_dayview.aspx?dispstatus=", this.dispstatus, "&ReqDate=", this.ReqDate1.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            this.ImageButton1.ToolTip = this.objLanguage.GetLanguageConversion("Day_View");
            this.ImageButton2.ToolTip = this.objLanguage.GetLanguageConversion("Week_View");
            this.ImageButton3.ToolTip = this.objLanguage.GetLanguageConversion("Month_View");
            this.ImageButton4.ToolTip = this.objLanguage.GetLanguageConversion("All_View");
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            try
            {
                this.ReqDate = Convert.ToDateTime(base.Request.Params["ReqDate"]);
            }
            catch
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                base.Response.End();
            }
            try
            {
                this.disptype = base.Request.Params["dispstatus"].ToString();
            }
            catch
            {
                this.disptype = "td";
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            if (!base.IsPostBack)
            {
                this.ImageButton1.ToolTip = this.objLanguage.convert(this.ImageButton1.ToolTip);
                this.ImageButton2.ToolTip = this.objLanguage.convert(this.ImageButton2.ToolTip);
                this.ImageButton3.ToolTip = this.objLanguage.convert(this.ImageButton3.ToolTip);
                this.ImageButton4.ToolTip = this.objLanguage.convert(this.ImageButton4.ToolTip);
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
            this.cmn.commonSectionHeader(this.plhHeader, "Day", "Day", "Day", "Add Task", "Add Event", "", "", "", "", "", "", "", "", string.Concat(global.sitePath(), "common/task_add.aspx?tasktype=home&tasktypeid=0"), string.Concat(global.sitePath(), "common/event_add.aspx?tasktype=home&tasktypeid=0"), "", "", "", "", "", "", "", "");
            this.nextdatetime = this.ReqDate.AddDays(1);
            this.previousdatetime = this.ReqDate.AddDays(-1);
            this.ReqDate1 = this.ReqDate.ToShortDateString();
            this.ReqDate1 = this.cmn.Eprint_return_Date_Before_View(this.ReqDate1.ToString(), this.companyid, this.UserID, false);
            this.nextdatetime1 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.nextdatetime.ToShortDateString()));
            this.previousdatetime1 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.date_Check(this.DateFormat, this.previousdatetime.ToShortDateString()));
            this.ImageButton1.ImageUrl = string.Concat(global.imagePath(), "day.png");
            this.ImageButton2.ImageUrl = string.Concat(global.imagePath(), "week.png");
            this.ImageButton3.ImageUrl = string.Concat(global.imagePath(), "cal.gif");
            this.ImageButton4.ImageUrl = string.Concat(global.imagePath(), "viewall.gif");
            this.ImageButton1.PostBackUrl = string.Concat(global.sitePath(), "common/event_dayview.aspx?ReqDate=", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            this.ImageButton2.PostBackUrl = string.Concat(global.sitePath(), "common/event_weekview.aspx?ReqDate=", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            this.ImageButton3.PostBackUrl = string.Concat(global.sitePath(), "common/event_monthview.aspx?ReqDate=", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            this.ImageButton4.PostBackUrl = string.Concat(global.sitePath(), "common/event_allview.aspx?ReqDate=", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            this.strpath = global.imagePath();
            global.pageName = "welcome";
            this.gloobj.setpagename("welcome");
            global.pgDetail = this.objLanguage.convert("Home");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect("../error.aspx");
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetValueOnLang("View_Day_Event"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;View Day Event");
            int num1 = 1;
            for (int i = 0; i < 24; i++)
            {
                str = (num1 % 2 != 0 ? "NewAlternative" : "NewTable");
                this.eventdayview.Controls.Add(new LiteralControl(string.Concat("<tr valign=top class=", str, ">")));
                this.eventdayview.Controls.Add(new LiteralControl("<td align=left class=normaltext>"));
                this.eventdayview.Controls.Add(new LiteralControl(string.Concat(i.ToString(), ":00")));
                this.eventdayview.Controls.Add(new LiteralControl("&nbsp&nbsp&nbsp<br />"));
                SqlCommand sqlCommand = new SqlCommand("crm_home_events_today_select", this.cmn.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@intAssignedID", this.Session["userid"]);
                sqlCommand.Parameters.AddWithValue("@intCompID", this.Session["companyID"]);
                sqlCommand.Parameters.AddWithValue("@reqdate", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int num2 = 0;
                double num3 = 0;
                int num4 = 0;
                string str1 = "";
                string str2 = "";
                while (sqlDataReader.Read())
                {
                    string str3 = sqlDataReader["EventTime"].ToString();
                    if (str3 != "")
                    {
                        string[] strArrays = str3.Split(new char[] { ':' });
                        num2 = int.Parse(strArrays[0]);
                        num3 = double.Parse(strArrays[1]);
                        num4 = num2;
                    }
                    string str4 = sqlDataReader["duration"].ToString();
                    if (str4 == "")
                    {
                        str2 = "";
                    }
                    else
                    {
                        string[] strArrays1 = str4.Split(new char[] { ':' });
                        num2 = num2 + int.Parse(strArrays1[0]);
                        num3 = num3 + double.Parse(strArrays1[1]);
                        str2 = string.Concat(num2, ":", num3);
                    }
                    if (i != num4)
                    {
                        continue;
                    }
                    this.eventdayview.Controls.Add(new LiteralControl("["));
                    this.eventdayview.Controls.Add(new LiteralControl(sqlDataReader["EventTime"].ToString()));
                    this.eventdayview.Controls.Add(new LiteralControl("--"));
                    this.eventdayview.Controls.Add(new LiteralControl(str2));
                    this.eventdayview.Controls.Add(new LiteralControl("    "));
                    str1 = string.Concat(global.sitePath(), "common/event_detail.aspx?eventtype=home&eventtypeid=0&&eventid=", sqlDataReader["eventid"].ToString());
                    HyperLink hyperLink = new HyperLink();
                    if (sqlDataReader["subject"].ToString().Length <= 30)
                    {
                        hyperLink.Text = base.SpecialDecode(sqlDataReader["subject"].ToString());
                    }
                    else
                    {
                        hyperLink.Text = string.Concat(base.SpecialDecode(sqlDataReader["subject"].ToString().Substring(0, 30)), "...");
                    }
                    hyperLink.NavigateUrl = str1;
                    this.eventdayview.Controls.Add(hyperLink);
                    this.eventdayview.Controls.Add(new LiteralControl("]"));
                    this.eventdayview.Controls.Add(new LiteralControl("<br />"));
                }
                this.eventdayview.Controls.Add(new LiteralControl("</td>"));
                this.eventdayview.Controls.Add(new LiteralControl("</tr>"));
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
            sqlCommand1.Parameters.AddWithValue("@DisplayType", "day");
            sqlCommand1.Parameters.AddWithValue("@ReqDate", base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.ReqDate1));
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            int num5 = 0;
            string str5 = "";
            string str6 = "";
            while (sqlDataReader1.Read())
            {
                str5 = (num5 % 2 != 0 ? "NewTable" : "NewAlternative");
                num5++;
                this.Taskplace.Controls.Add(new LiteralControl(string.Concat("<tr style=height:22 valign=middle class=", str5, ">")));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='1%'></td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='18%'>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left; width: 20px;'>&nbsp;"));
                this.Taskplace.Controls.Add(new LiteralControl("</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left; width: 10px;'>"));
                this.Taskplace.Controls.Add(new LiteralControl("&nbsp;</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                this.Taskplace.Controls.Add(new LiteralControl(sqlDataReader1["dueDate"].ToString()));
                this.Taskplace.Controls.Add(new LiteralControl("</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("</div>"));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width=32%>"));
                string[] strArrays2 = new string[] { global.sitePath(), "common/task_detail.aspx?tasktype=", sqlDataReader1["type"].ToString(), "&tasktypeid=", sqlDataReader1["typeId"].ToString(), "&taskid=", sqlDataReader1["taskid"].ToString() };
                str6 = string.Concat(strArrays2);
                HyperLink hyperLink1 = new HyperLink();
                if (sqlDataReader1["subject"].ToString().Length <= 30)
                {
                    hyperLink1.Text = base.SpecialDecode(sqlDataReader1["subject"].ToString());
                }
                else
                {
                    hyperLink1.Text = string.Concat(base.SpecialDecode(sqlDataReader1["subject"].ToString().Substring(0, 30)), "...");
                }
                hyperLink1.NavigateUrl = str6;
                this.Taskplace.Controls.Add(hyperLink1);
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td class=normaltext width=28%>"));
                int.Parse(sqlDataReader1["contactId"].ToString());
                this.Taskplace.Controls.Add(new LiteralControl(base.SpecialDecode(sqlDataReader1["contactname"].ToString())));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width=22%>"));
                this.Taskplace.Controls.Add(new LiteralControl(sqlDataReader1["taskstatus"].ToString()));
                this.Taskplace.Controls.Add(new LiteralControl("</td>"));
                this.Taskplace.Controls.Add(new LiteralControl("<td nowrap class=normaltext width='1%'></td>"));
                this.Taskplace.Controls.Add(new LiteralControl("</tr>"));
            }
            if (!sqlDataReader1.HasRows)
            {
                this.Taskplace.Controls.Add(new LiteralControl("<tr valign=middle style='height:23px'><td colspan=3 class=normaltext>"));
                this.Taskplace.Controls.Add(new LiteralControl(this.objLanguage.convert(" &nbsp;&nbsp;No Task on this day")));
                this.Taskplace.Controls.Add(new LiteralControl("</td></tr>"));
            }
            sqlDataReader1.Close();
            this.cmn.closeConnection();
        }

        private object split(object p, string p_2)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}