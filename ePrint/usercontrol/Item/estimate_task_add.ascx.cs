using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Telerik.Web.UI.Gantt;

namespace ePrint.usercontrol.Item
{
    public partial class estimate_task_add : System.Web.UI.UserControl
    {

        private BaseClass Objclss = new BaseClass();

        public languageClass objLanguage = new languageClass();

        public commonClass objCommon = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string tasktype = "";

        public BaseClass objBase = new BaseClass();

        public string DateFormat = string.Empty;

        public languageClass objLangClass = new languageClass();

        public int tasktypeid;

        private taskClass objTaskClass = new taskClass();

        public string currentdate = DateTime.Now.ToShortDateString();

        public string ddltypevalue = string.Empty;

        public string txttypevalue = string.Empty;

        public string ddltypevalue1 = string.Empty;

        public string txttypevalue1 = string.Empty;

        public string temptxt = string.Empty;

        public string tabcolor = "";

        public int companyid;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        private SettingsBasePage objSetBase = new SettingsBasePage();

        public string newdate = string.Empty;

        private BaseClass objBC = new BaseClass();

        private long EstID;

        private string NewReqType = "estimate";

        public string pg = string.Empty;

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

        public estimate_task_add()
        {
        }

        protected void btnaddmore_Click1(object sender, EventArgs e)
        {
            int num = 0;
            bool flag = true;
            string str = "";
            int num1 = 0;
            string str1 = "";
            this.CommonAdd(ref num, ref flag, ref str, ref num1, ref str1);
            if (flag)
            {
                HttpResponse response = base.Response;
                object[] objArray = new object[] { "../common/task_add.aspx?tasktypeid=", this.tasktypeid, "&tasktype=", this.tasktype, "&isnew=1" };
                response.Redirect(string.Concat(objArray));
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_subject_insert(this.companyid, this.objBC.SpecialEncode(this.txtSubject.Text));
            this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
            this.ddlsubject.SelectedIndex = this.ddlsubject.Items.Count - 1;
            this.hdn_Subject.Value = this.objBase.SpecialDecode(this.ddlsubject.SelectedItem.Text);
        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(base.Session["companyID"]);
            string text = this.ddlsubject.SelectedItem.Text;
            string str = this.objBC.ReplaceSingleQuote(this.ddlstatus.SelectedItem.Text);
            string str1 = this.objBC.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.objBC.ReplaceSingleQuote(this.txtduedate.Text));
            string str2 = string.Concat(this.ddlhour.SelectedItem.Text, ":", this.ddlminute.SelectedItem.Text);
            str1 = str1;
            commonClass _commonClass = new commonClass();
            this.objBC.ReplaceSingleQuote(this.txtcontacttype.Value);
            this.objBC.ReplaceSingleQuote(this.txttype.Text);
            this.objBC.ReplaceSingleQuote(this.contacttxt_hidden.Value);
            this.objBC.ReplaceSingleQuote(this.typetxt_hidden.Value);
            this.objBC.ReplaceSingleQuote(this.ddlpriority.SelectedItem.Text);
            string str3 = base.Server.HtmlEncode(this.objBC.ReplaceSingleQuote(this.txtcomment.Text));
            int num1 = Convert.ToInt32(this.ddlassigneto.SelectedValue);
            int num2 = Convert.ToInt32(base.Session["userID"]);
            int num3 = Convert.ToInt32(base.Session["userID"]);
            string str4 = DateTime.Now.ToString();
            string str5 = DateTime.Now.ToString();
            int num4 = 0;
            long num5 = (long)0;
            if (this.tasktype != "home")
            {
                num5 = Convert.ToInt64(this.ddllinkedto.SelectedItem.Value);
            }
            this.objTaskClass.task_Add("", num, text, "", str, str1, str2, Convert.ToInt32(this.contactid_hidden.Value), this.ddlpriority.SelectedValue, this.tasktype, num5, str3, 0, num1, num2, num3, str4, str5, "", num4);
            if (this.tasktype == "estimate")
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "estimates/estimate_item_form.aspx?frm=view&estid=", this.EstID));
                return;
            }
            if (this.tasktype == "job")
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "jobs/job_item_form.aspx?frm=view&estid=", this.EstID));
                return;
            }
            if (this.tasktype == "invoice")
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "invoice/invoice_item_form.aspx?frm=view&estid=", this.EstID));
                return;
            }
            if (this.tasktype != "purchase")
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(global.sitePath(), "purchase/purchase_add.aspx?type=edit&id=", this.EstID));
        }

        protected void btnSaveTask_OnClick(object sender, EventArgs e)
        {
            if (this.pg.ToLower() == "home" || this.pg.ToLower() == "client")
            {
                this.FollowUpTask();
                this.LoadTaskGrid();
            }
        }

        public void CommonAdd(ref int contactId, ref bool _AddTask, ref string type, ref int typeId, ref string contactType)
        {
            int num = Convert.ToInt32(base.Session["companyID"]);
            string text = this.ddlsubject.SelectedItem.Text;
            base.Response.Write(this.ddlsubject.SelectedItem.Text);
            base.Response.End();
            string str = "";
            string str1 = this.objBC.ReplaceSingleQuote(this.ddlstatus.SelectedItem.Text);
            string str2 = this.objBC.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.objBC.ReplaceSingleQuote(this.txtduedate.Text));
            string str3 = string.Concat(this.ddlhour.SelectedItem.Text, ":", this.ddlminute.SelectedItem.Text);
            str2 = string.Concat(str2, " ", str3);
            commonClass _commonClass = new commonClass();
            type = this.ddltype.SelectedValue.ToString().ToLower();
            this.objBC.ReplaceSingleQuote(this.txtcontacttype.Value);
            this.objBC.ReplaceSingleQuote(this.txttype.Text);
            this.objBC.ReplaceSingleQuote(this.contacttxt_hidden.Value);
            contactType = "";
            this.objBC.ReplaceSingleQuote(this.typetxt_hidden.Value);
            if (_AddTask)
            {
                string str4 = this.objBC.ReplaceSingleQuote(this.ddlpriority.SelectedItem.Text);
                string str5 = base.Server.HtmlEncode(this.objBC.ReplaceSingleQuote(this.txtcomment.Text));
                int num1 = 0;
                int num2 = Convert.ToInt32(this.ddlassigneto.SelectedValue);
                int num3 = Convert.ToInt32(base.Session["userID"]);
                int num4 = Convert.ToInt32(base.Session["userID"]);
                string str6 = DateTime.Now.ToString();
                string str7 = DateTime.Now.ToString();
                int num5 = 0;
                this.objTaskClass.task_Add(this.tasktype, num, text, str, str1, str2, str3, contactId, str4, type, (long)typeId, str5, num1, num2, num3, num4, str6, str7, contactType, num5);
                if (this.Chkemail.Checked)
                {
                    checkEmail _checkEmail = new checkEmail();
                    ArrayList arrayLists = new ArrayList();
                    arrayLists.Add(text);
                    arrayLists.Add(str2);
                    arrayLists.Add(str5);
                    _checkEmail.SendEmailToClient(base.Session["email"].ToString(), arrayLists, "Add Task", int.Parse(base.Session["companyID"].ToString()), base.Session["language"].ToString());
                }
            }
        }

        private void FollowUpTask()
        {
            Convert.ToInt64(base.Request.Params["estid"]);
            int num = 0;
            num = Convert.ToInt32(base.Session["CompanyID"]);
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string value = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string text = string.Empty;
            BasePage basePage = new BasePage();
            int num1 = Convert.ToInt32(base.Session["userID"]);
            string str3 = DateTime.Now.ToString();
            string str4 = DateTime.Now.ToString();
            empty = this.ddlassigneto.SelectedValue;
            string selectedValue = this.ddlstatus.SelectedValue;
            string selectedValue1 = this.ddlsubject.SelectedValue;
            string selectedValue2 = this.ddlpriority.SelectedValue;
            value = this.contactid_hidden.Value;
            text = this.txtcomment.Text;
            string.Concat(str2, ":", empty3);
            taskClass _taskClass = new taskClass();
            _taskClass.task_Add("", num, "test", "", "In process", "12/12/2011", "10:00", Convert.ToInt32(value), "high", "", (long)1, text, 0, Convert.ToInt32(empty), num1, 0, str3, str4, "", 0);
        }

        protected int getContactTypeID(string _txtcontacttype, string pg, int companyid)
        {
            int num = 0;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_getContactTypeID", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@_txtcontacttype", _txtcontacttype);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.ExecuteNonQuery();
            num = Convert.ToInt32(sqlCommand.Parameters["ReturnValue"].Value);
            _commonClass.closeConnection();
            return num;
        }

        protected void LoadTaskGrid()
        {
            if (this.objAddnewTask != null)
            {
                this.objAddnewTask();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            string str1;
            global.pageName = this.NewReqType;
            global.pgName = "";
            this.gloobj.setpagename(base.Session["PageName"].ToString().ToLower());
            this.pg = base.Session["PageName"].ToString().ToLower();
            try
            {
                this.tasktype = this.NewReqType;
                this.tasktypeid = 0;
            }
            catch
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.companyid = int.Parse(base.Session["companyID"].ToString());
            this.DateFormat = this.objpage.GetRegionalSettings(this.companyid, "Dateformat");
            BaseClass baseClass = this.objBC;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            this.ddlassigneto.Focus();
            this.pnlMoreThanOneRecord.Visible = false;
            this.pnlMoreThanOneRecord1.Visible = false;
            this.lblcontacterror.Visible = false;
            this.lbltxttypeerror.Visible = false;
            this.pnlLinkedTo.Visible = false;
            if (!base.IsPostBack)
            {
                this.txtduedate.Text = "";
                this.objSetBase.Bind_User(this.ddlassigneto, this.companyid, "---Select---");
                this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
                this.ddlassigneto.Items.Insert(this.ddlassigneto.Items.Count, " ");
                this.ddlassigneto.Items[this.ddlassigneto.Items.Count - 1].Text = "All";
                this.ddlassigneto.Items[this.ddlassigneto.Items.Count - 1].Value = "-1";
                string empty = string.Empty;
                int num = 0;
                while (num < this.ddlassigneto.Items.Count)
                {
                    if (!this.ddlassigneto.Items[num].Text.Equals(base.Session["firstName"].ToString()))
                    {
                        num++;
                    }
                    else
                    {
                        empty = this.ddlassigneto.Items[num].Value;
                        break;
                    }
                }
                this.ddlassigneto.SelectedValue = empty;
            }
            global.pgDetail = string.Concat(this.objLanguage.convert("Task"), " >> ", this.objLanguage.convert("Task Add"));
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, this.NewReqType);
            this.lblduedate_value.Text = DateTime.Now.ToShortDateString().ToString();
            if (this.tasktype == "home")
            {
                this.pnlLinkedTo.Visible = false;
            }
            try
            {
                if(base.Request.Params["isnew"] != null)
                {
                    if (base.Request.Params["isnew"].ToString() == "1")
                    {
                        this.lblsuccessfull.Text = "Task Added Sucessfully";
                        this.lblsuccessfull.Visible = true;
                    }
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                this.lblstatus.Text = this.objLanguage.convert(this.lblstatus.Text);
                this.lblsubject.Text = this.objLanguage.convert(this.lblsubject.Text);
                this.lblpriority.Text = this.objLanguage.convert(this.lblpriority.Text);
                this.lblcontacterror.Text = this.objLanguage.convert(this.lblcontacterror.Text);
                this.lblduedate.Text = this.objLanguage.convert(this.lblduedate.Text);
                this.lblduedate_value.Text = this.objLanguage.convert(this.lblduedate_value.Text);
                this.lbltxttypeerror.Text = this.objLanguage.convert(this.lbltxttypeerror.Text);
                this.lblcomment.Text = this.objLanguage.convert(this.lblcomment.Text);
                this.Chkemail.Text = this.objLanguage.convert(this.Chkemail.Text);
                this.btnsave.Text = this.objLanguage.convert(this.btnsave.Text);
                this.btncancel.Text = this.objLanguage.convert(this.btncancel.Text);
                this.btnaddmore.Text = this.objLanguage.convert(this.btnaddmore.Text);
                this.ImageButton3.Visible = false;
                if (base.Session["AssignmentSetting"].ToString().Trim() == "a")
                {
                    this.ImageButton3.Visible = false;
                }
                else if (Convert.ToInt32(base.Session["iscorporateright"]) == 1 || Convert.ToInt32(base.Session["admin"]) == 1 & (Convert.ToInt32(base.Session["assignmentright"]) == 1 | Convert.ToInt32(base.Session["isTransferRights"]) == 1))
                {
                    this.ImageButton3.Visible = false;
                }
                for (int i = 0; i <= 23; i++)
                {
                    str = (i >= 10 ? i.ToString() : string.Concat("0", i.ToString()));
                    this.ddlhour.Items.Add(str);
                }
                for (int j = 0; j <= 11; j++)
                {
                    int num1 = j * 5;
                    str1 = (num1 >= 10 ? num1.ToString() : string.Concat("0", num1.ToString()));
                    this.ddlminute.Items.Add(str1);
                }
                this.ddlhour.SelectedIndex = 10;
                this.ddlminute.SelectedIndex = 0;
                taskClass _taskClass = new taskClass();
                this.ddlstatus.DataSource = _taskClass.dtrTaskStatus(int.Parse(base.Session["companyID"].ToString()));
                this.ddlstatus.DataTextField = "taskStatus";
                this.ddlstatus.DataValueField = "taskStatusId";
                this.ddlstatus.DataBind();
                this.ddlstatus.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlstatus.Items[0].Value = "";
                this.ddlstatus.SelectedIndex = 4;
                this.ddlpriority.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlpriority.Items.Insert(1, this.objLanguage.convert("High"));
                this.ddlpriority.Items.Insert(2, this.objLanguage.convert("Normal"));
                this.ddlpriority.Items.Insert(3, this.objLanguage.convert("Low"));
                this.ddlpriority.Items[0].Value = "";
                this.ddlpriority.SelectedIndex = 2;
                this.objCommon.closeConnection();
                eventClass _eventClass = new eventClass();
                this.assigntoid_hidden.Value = base.Session["userid"].ToString();
                if (this.tasktype.ToLower().Trim() == "home")
                {
                    this.txtcontacttype.Value = "";
                    this.contacttxt_hidden.Value = "";
                    this.contactid_hidden.Value = "0";
                    this.typeid_hidden.Value = "0";
                    global.pgDetail = string.Concat(this.objLanguage.convert("Home"), " >> ", this.objLanguage.convert("Add Task"));
                }
                bool flag = false;
                if (this.tasktype.ToLower() == "contact")
                {
                    commonClass _commonClass = new commonClass();
                    int num2 = int.Parse(base.Request.Params["tasktypeid"].ToString());
                    string name = _commonClass.getName(num2, int.Parse(base.Session["companyID"].ToString()), "contact");
                    this.txttype.Text = name;
                }
                if (this.tasktype.ToLower() == "lead")
                {
                    this.ImageButton1.Enabled = false;
                    this.ImageButton1.Width = 0;
                    this.txttype.Enabled = false;
                }
                else if (!flag)
                {
                    this.ImageButton1.Enabled = false;
                    this.ImageButton1.Width = 0;
                    this.txttype.Enabled = false;
                }
                else
                {
                    this.ImageButton1.Enabled = true;
                    this.txttype.Enabled = true;
                }
            }
            string str2 = this.tasktype;
            string str3 = str2;
            if (str2 != null)
            {
                switch (str3)
                {
                    case "home":
                        {
                            this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "welcome.aspx");
                            break;
                        }
                    case "lead":
                        {
                            QueryString queryString = new QueryString()
					{
						{ "leadid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str4 = "../lead/lead_detail.aspx";
                            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                            str4 = string.Concat(str4, queryString1.ToString());
                            this.btncancel.PostBackUrl = str4;
                            break;
                        }
                    case "contact":
                        {
                            QueryString queryString2 = new QueryString()
					{
						{ "contactid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str5 = "../contact/contact_detail.aspx";
                            QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                            str5 = string.Concat(str5, queryString3.ToString());
                            this.btncancel.PostBackUrl = str5;
                            break;
                        }
                    case "client":
                        {
                            QueryString queryString4 = new QueryString()
					{
						{ "clientid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str6 = "../client/client_detail.aspx";
                            QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                            str6 = string.Concat(str6, queryString5.ToString());
                            this.btncancel.PostBackUrl = str6;
                            break;
                        }
                    case "opportunity":
                        {
                            QueryString queryString6 = new QueryString()
					{
						{ "opportunityid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str7 = "../opportunity/opportunity_detail.aspx";
                            QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                            str7 = string.Concat(str7, queryString7.ToString());
                            this.btncancel.PostBackUrl = str7;
                            break;
                        }
                    case "ticket":
                        {
                            QueryString queryString8 = new QueryString()
					{
						{ "ticketid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str8 = "../ticket/ticket_detail.aspx";
                            QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                            str8 = string.Concat(str8, queryString9.ToString());
                            this.btncancel.PostBackUrl = str8;
                            break;
                        }
                    case "campaign":
                        {
                            QueryString queryString10 = new QueryString()
					{
						{ "campaignid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str9 = "../campaign/campaign_detail.aspx";
                            QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                            str9 = string.Concat(str9, queryString11.ToString());
                            this.btncancel.PostBackUrl = str9;
                            break;
                        }
                    case "contract":
                        {
                            QueryString queryString12 = new QueryString()
					{
						{ "contractid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str10 = "../contract/contract_detail.aspx";
                            QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                            str10 = string.Concat(str10, queryString13.ToString());
                            this.btncancel.PostBackUrl = str10;
                            break;
                        }
                    case "asset":
                        {
                            QueryString queryString14 = new QueryString()
					{
						{ "assetid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str11 = "../asset/asset_detail.aspx";
                            QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                            str11 = string.Concat(str11, queryString15.ToString());
                            this.btncancel.PostBackUrl = str11;
                            break;
                        }
                    case "product":
                        {
                            QueryString queryString16 = new QueryString()
					{
						{ "productid", this.tasktypeid.ToString() },
						{ "isnew", "2" }
					};
                            string str12 = "../product/product_detail.aspx";
                            QueryString queryString17 = Encryption.EncryptQueryString(queryString16);
                            str12 = string.Concat(str12, queryString17.ToString());
                            this.btncancel.PostBackUrl = str12;
                            break;
                        }
                    case "estimate":
                        {
                            this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "estimates/estimate_item_form.aspx?frm=view&estid=", this.EstID);
                            break;
                        }
                    case "job":
                        {
                            this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "jobs/job_item_form.aspx?frm=view&estid=", this.EstID);
                            break;
                        }
                    case "invoice":
                        {
                            this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "invoice/invoice_item_form.aspx?frm=view&estid=", this.EstID);
                            break;
                        }
                    case "purchase":
                        {
                            this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "purchase/purchase_add.aspx?type=edit&id=", this.EstID);
                            break;
                        }
                    default:
                        {
                            goto Label0;
                        }
                }
            }
            else
            {
                goto Label0;
            }
        Label1:
            string str13 = string.Concat("selecttaskassignto.aspx?pg=", this.tasktype);
            this.ImageButton3.Attributes.Add("onclick", string.Concat("javascript:window.open('", str13, "', 'Lead','width=745,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
            this.ImageButton2.Attributes.Add("onclick", "javascript:openwin2();return false;");
            this.ImageButton1.Attributes.Add("onclick", "javascript:openwin1();return false;");
            string str14 = string.Concat("selectsubjectpopup.aspx?tasktype=", this.tasktype);
            this.ImageButton9.Attributes.Add("onclick", string.Concat("javascript:window.open('", str14, "', 'subject','width=750,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
            this.ddltype.Attributes.Add("OnSelectedIndexChanged", "javascript:window.return('You have Change the Dropdown');");
            this.ddltype.Attributes.Add("onchange", "javaScript:showddltype();");
            if (!base.IsPostBack)
            {
                this.txttypevalue = this.objBC.ReplaceSingleQuote(this.txttype.Text);
            }
            this.txtduedate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
            this.txtduedate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
            this.txtduedate.Attributes.Add("onFocus", "javascript:txtduedate_onfocus();");
            this.txtduedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            if (!base.IsPostBack && (this.pg == "purchase" || this.pg == "deliverynote") && base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                HiddenField hiddenField = (HiddenField)this.Parent.FindControl("hdnTaskID");
                SqlDataReader sqlDataReader = this.objTaskClass.task_Select_Reader(Convert.ToInt32(hiddenField.Value), Convert.ToInt32(base.Session["companyId"]));
                while (sqlDataReader.Read())
                {
                    string str15 = sqlDataReader["dueDate"].ToString();
                    commonClass _commonClass1 = new commonClass();
                    this.txtduedate.Text = this.objCommon.Eprint_return_Date_Before_View(str15, this.companyid, Convert.ToInt32(base.Session["UserID"]), false);
                    this.txtcomment.Text = this.Objclss.dispstrtxtbox(_commonClass1.replaceLineBreak(sqlDataReader["description"].ToString().Trim()), 120);
                    this.txtcomment.Text = this.objBase.SpecialDecode(this.txtcomment.Text);
                    this.txtcontacttype.Value = this.objBase.SpecialDecode(sqlDataReader["contactname"].ToString().Trim());
                    this.contacttxt_hidden.Value = sqlDataReader["contactname"].ToString().Trim();
                    for (int k = 0; k < this.ddlassigneto.Items.Count; k++)
                    {
                        if (this.ddlassigneto.Items[k].Value == sqlDataReader["assigntouserid"].ToString())
                        {
                            this.ddlassigneto.SelectedIndex = k;
                        }
                    }
                    for (int l = 0; l < this.ddlsubject.Items.Count; l++)
                    {
                        if (this.ddlsubject.Items[l].Text.Trim() == this.objBase.SpecialDecode(sqlDataReader["subject"].ToString().Trim()))
                        {
                            this.ddlsubject.SelectedIndex = l;
                        }
                    }
                    this.hdn_Subject.Value = this.ddlsubject.SelectedItem.Text;
                    this.contactid_hidden.Value = sqlDataReader["contactid"].ToString();
                    this.assigntoid_hidden.Value = sqlDataReader["assigntouserid"].ToString();
                    this.typeid_hidden.Value = "0";
                    this.tasktype = sqlDataReader["contacttype"].ToString().Trim().ToLower();
                    for (int m = 0; m < this.ddlhour.Items.Count; m++)
                    {
                        if (this.ddlhour.Items[m].Text.Trim() == sqlDataReader["taskTime"].ToString().Trim().Substring(0, 2))
                        {
                            this.ddlhour.SelectedIndex = m;
                        }
                    }
                    for (int n = 0; n < this.ddlminute.Items.Count; n++)
                    {
                        if (this.ddlminute.Items[n].Text.Trim() == sqlDataReader["taskTime"].ToString().Trim().Substring(3, 2))
                        {
                            this.ddlminute.SelectedIndex = n;
                        }
                    }
                    for (int o = 0; o < this.ddlpriority.Items.Count; o++)
                    {
                        if (this.ddlpriority.Items[o].Value.ToString().Trim().ToLower() == sqlDataReader["priority"].ToString().Trim().ToLower())
                        {
                            this.ddlpriority.SelectedIndex = o;
                        }
                    }
                    for (int p = 0; p < this.ddlstatus.Items.Count; p++)
                    {
                        if (this.ddlstatus.Items[p].Text.ToString().Trim().ToLower() == sqlDataReader["taskstatus"].ToString().Trim().ToLower())
                        {
                            this.ddlstatus.SelectedIndex = p;
                        }
                    }
                }
                sqlDataReader.Close();
            }
            this.Label6.Text = this.objLangClass.GetLanguageConversion("Assigned_To");
            this.lblstatus.Text = this.objLangClass.GetLanguageConversion("Status");
            this.lblsubject.Text = this.objLangClass.GetLanguageConversion("Subject");
            this.lblpriority.Text = this.objLangClass.GetLanguageConversion("Priority");
            this.lblcontacts.Text = this.objLangClass.GetLanguageConversion("Contacts");
            this.lblsubject.Text = this.objLangClass.GetLanguageConversion("Subject");
            this.Button2.Text = this.objLangClass.GetLanguageConversion("Save");
            return;
        Label0:
            base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
            goto Label1;
        }

        protected int returnNoOfLead_WithThisFirstLastName(string _txtcontacttype, int companyid, string contacttype)
        {
            int num = 0;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_matchContactTypeName", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@_txtcontacttype", _txtcontacttype);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@pg", contacttype);
            sqlCommand.ExecuteNonQuery();
            num = Convert.ToInt32(sqlCommand.Parameters["ReturnValue"].Value);
            _commonClass.closeConnection();
            return num;
        }

        public event AddNewTaskEventHandler objAddnewTask;
    }
}