using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class task_add : BaseClass, IRequiresSessionState
    {
        //protected Label lbltask;

        //protected Label lbltask_value;

        //protected HtmlInputHidden assigntoid_hidden;

        //protected HtmlInputHidden contactid_hidden;

        //protected HtmlInputHidden typeid_hidden;

        //protected HtmlInputHidden contacttxt_hidden;

        //protected HtmlInputHidden typetxt_hidden;

        //protected Label lblsuccessfull;

        //protected Label Label6;

        //protected ImageButton ImageButton3;

        //protected DropDownList ddlassigneto;

        //protected Label lblstatus;

        //protected DropDownList ddlstatus;

        //protected Label lblsubject;

        //protected ImageButton ImageButton9;

        //protected DropDownList ddlsubject;

        //protected ImageButton ImageButton4;

        //protected UpdatePanel up12;

        //protected Label lblpriority;

        //protected DropDownList ddlpriority;

        //protected Label lblcontacts;

        //protected ImageButton ImageButton2;

        //protected HtmlInputText txtcontacttype;

        //protected Label lblcontacterror;

        //protected Label lblduedate;

        //protected TextBox txtduedate;

        //protected DropDownList ddlhour;

        //protected DropDownList ddlminute;

        //protected Label lblduedate_value;

        //protected Label Label1;

        //protected DropDownList ddllinkedto;

        //protected PlaceHolder pnlLinkedTo;

        //protected DropDownList ddltype;

        //protected TextBox txttype;

        //protected ImageButton ImageButton1;

        //protected Label lbltxttypeerror;

        //protected Label lblcomment;

        //protected TextBox txtcomment;

        //protected CheckBox Chkemail;

        //protected Button btncancel;

        //protected Button btnsave;

        //protected Button btnaddmore;

        //protected Label lblSubject_popup;

        //protected TextBox txtSubject;

        //protected Button btnCancel_Popup;

        //protected Button btnOK;

        //protected Button btnDelete;

        //protected RadWindow cataloguewindow;

        //protected RadWindowManager Radwinmanagercatalogue;

        //protected RadWindowManager RadWindowManager1;

        //protected Panel pnlMoreThanOneRecord;

        //protected Panel pnlMoreThanOneRecord1;

        private string _callbackResult;

        public languageClass objLanguage = new languageClass();

        public commonClass objCommon = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string tasktype = "";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BaseClass objBase = new BaseClass();

        public string DateFormat = string.Empty;

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

        public int UserID;

        private long EstID;

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

        public task_add()
        {
        }

        protected void btnaddmore_Click1(object sender, EventArgs e)
        {
            try
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
            catch
            {
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_subject_delete(this.companyid, base.ReplaceSingleQuote(this.ddlsubject.SelectedItem.Text));
            this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
            this.ddlsubject.DataBind();
            this.ddlsubject.Items.Insert(0, " ");
            this.ddlsubject.Items[0].Text = "---Select---";
            this.ddlsubject.Items[0].Value = "0";
            this.ddlsubject.SelectedIndex = 0;
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_subject_insert(this.companyid, base.SpecialEncode(this.txtSubject.Text));
            this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
            this.ddlsubject.DataBind();
            this.ddlsubject.SelectedIndex = this.ddlsubject.Items.Count - 1;
            this.ddlsubject.Items.Insert(0, " ");
            this.ddlsubject.Items[0].Text = "---Select---";
            this.ddlsubject.Items[0].Value = "0";
        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.Session["companyID"]);
                string str = base.SpecialEncode(this.ddlsubject.SelectedItem.Text);
                string str1 = base.SpecialEncode(this.ddlstatus.SelectedItem.Text);
                string str2 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.ReplaceSingleQuote(this.txtduedate.Text));
                string str3 = string.Concat(this.ddlhour.SelectedItem.Text, ":", this.ddlminute.SelectedItem.Text);
                str2 = str2;
                commonClass _commonClass = new commonClass();
                base.SpecialEncode(this.txtcontacttype.Value);
                base.SpecialEncode(this.txttype.Text);
                base.SpecialEncode(this.contacttxt_hidden.Value);
                base.SpecialEncode(this.typetxt_hidden.Value);
                base.SpecialEncode(this.ddlpriority.SelectedItem.Text);
                string str4 = base.SpecialEncode(this.txtcomment.Text);
                int num1 = Convert.ToInt32(this.ddlassigneto.SelectedValue);
                int num2 = Convert.ToInt32(this.Session["userID"]);
                int num3 = Convert.ToInt32(this.Session["userID"]);
                string str5 = DateTime.Now.ToString();
                string str6 = DateTime.Now.ToString();
                int num4 = 0;
                long num5 = (long)0;
                if (this.tasktype != "home")
                {
                    num5 = Convert.ToInt64(this.ddllinkedto.SelectedItem.Value);
                }
                this.objTaskClass.task_Add("", num, str, "", str1, str2, str3, Convert.ToInt32(this.contactid_hidden.Value), this.ddlpriority.SelectedValue, this.tasktype, num5, str4, 0, num1, num2, num3, str5, str6, "", num4);
                if (this.tasktype == "estimate")
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "estimates/estimate_item_form.aspx?frm=view&estid=", this.EstID));
                }
                else if (this.tasktype == "job")
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "jobs/job_item_form.aspx?frm=view&estid=", this.EstID));
                }
                else if (this.tasktype == "invoice")
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "invoice/invoice_item_form.aspx?frm=view&estid=", this.EstID));
                }
                else if (this.tasktype != "purchase")
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "purchase/purchase_add.aspx?type=edit&id=", this.EstID));
                }
            }
            catch
            {
            }
        }

        public void CommonAdd(ref int contactId, ref bool _AddTask, ref string type, ref int typeId, ref string contactType)
        {
            try
            {
                int num = Convert.ToInt32(this.Session["companyID"]);
                string text = this.ddlsubject.SelectedItem.Text;
                base.Response.Write(this.ddlsubject.SelectedItem.Text);
                base.Response.End();
                string str = "";
                string str1 = base.ReplaceSingleQuote(this.ddlstatus.SelectedItem.Text);
                string str2 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.ReplaceSingleQuote(this.txtduedate.Text));
                string str3 = string.Concat(this.ddlhour.SelectedItem.Text, ":", this.ddlminute.SelectedItem.Text);
                str2 = string.Concat(str2, " ", str3);
                commonClass _commonClass = new commonClass();
                type = this.ddltype.SelectedValue.ToString().ToLower();
                base.ReplaceSingleQuote(this.txtcontacttype.Value);
                base.ReplaceSingleQuote(this.txttype.Text);
                base.ReplaceSingleQuote(this.contacttxt_hidden.Value);
                contactType = "";
                base.ReplaceSingleQuote(this.typetxt_hidden.Value);
                if (_AddTask)
                {
                    string str4 = base.ReplaceSingleQuote(this.ddlpriority.SelectedItem.Text);
                    string str5 = base.Server.HtmlEncode(base.ReplaceSingleQuote(this.txtcomment.Text));
                    int num1 = 0;
                    int num2 = Convert.ToInt32(this.ddlassigneto.SelectedValue);
                    int num3 = Convert.ToInt32(this.Session["userID"]);
                    int num4 = Convert.ToInt32(this.Session["userID"]);
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
                        _checkEmail.SendEmailToClient(this.Session["email"].ToString(), arrayLists, "Add Task", int.Parse(this.Session["companyID"].ToString()), this.Session["language"].ToString());
                    }
                }
            }
            catch
            {
            }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            string str1;
            string[] strArrays;
            object[] estID;
            try
            {
                this.btncancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
                this.btnsave.Text = this.objLanguage.GetLanguageConversion("Save");
                this.btnaddmore.Text = this.objLanguage.GetLanguageConversion("Save_AddMore");
                this.lbltask.Text = string.Concat(this.objLanguage.GetLanguageConversion("Task"), ":&nbsp;");
                this.btnCancel_Popup.ToolTip = this.objLanguage.GetLanguageConversion("Cancel");
                this.btnOK.Text = this.objLanguage.GetLanguageConversion("Save");
                this.btnDelete.Text = this.objLanguage.GetLanguageConversion("Delete");
                global.pageName = base.Request.Params["tasktype"].ToString();
                global.pgName = "";
                this.gloobj.setpagename(base.Request.Params["tasktype"].ToString());
                this.companyid = int.Parse(this.Session["companyID"].ToString());
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.DateFormat = this.objpage.GetRegionalSettings(this.companyid, "Dateformat");
                this.ddlassigneto.Focus();
                this.pnlMoreThanOneRecord.Visible = false;
                this.pnlMoreThanOneRecord1.Visible = false;
                this.lblcontacterror.Visible = false;
                this.lbltxttypeerror.Visible = false;
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
                        if (!this.ddlassigneto.Items[num].Text.Equals(this.Session["firstName"].ToString()))
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
                if (this.Session["email"] == null)
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                }
                this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["tasktype"]);
                base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Add_Task"), int.Parse(this.Session["companyID"].ToString()), this.Session["companyName"].ToString()));
                Label lblduedateValue = this.lblduedate_value;
                DateTime now = DateTime.Now;
                lblduedateValue.Text = now.ToShortDateString().ToString();
                try
                {
                    this.tasktype = base.Request.Params["tasktype"].ToString();
                    this.tasktypeid = int.Parse(base.Request.Params["tasktypeid"].ToString());
                }
                catch
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                }
                if (this.tasktype != "home")
                {
                    this.EstID = Convert.ToInt64(base.Request.Params["estID"].ToString());
                    if (!base.IsPostBack)
                    {
                        IDataReader dataReader = EstimateBasePage.estimates_number_estid_select(this.companyid, this.tasktype);
                        this.ddllinkedto.DataSource = dataReader;
                        this.ddllinkedto.DataTextField = "EstimateNumber";
                        this.ddllinkedto.DataValueField = "EstimateID";
                        this.ddllinkedto.DataBind();
                        dataReader.Dispose();
                        dataReader.Close();
                        for (int i = 0; i < this.ddllinkedto.Items.Count; i++)
                        {
                            if (this.EstID == Convert.ToInt64(this.ddllinkedto.Items[i].Value))
                            {
                                this.ddllinkedto.SelectedIndex = i;
                            }
                        }
                    }
                }
                else
                {
                    this.pnlLinkedTo.Visible = false;
                }
                try
                {
                    if (base.Request.Params["isnew"].ToString() == "1")
                    {
                        this.lblsuccessfull.Text = "Task Added Sucessfully";
                        this.lblsuccessfull.Visible = true;
                    }
                }
                catch
                {
                }
                if (!base.IsPostBack)
                {
                    if (this.Session["LEADS"] != null || this.Session["TICKETS"] != null || this.Session["OPPORTUNITIES"] != null)
                    {
                    }
                    this.lbltask.Text = this.objLanguage.convert(this.lbltask.Text);
                    this.lbltask_value.Text = this.objLanguage.convert(this.lbltask_value.Text);
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
                    if (this.Session["AssignmentSetting"].ToString().Trim() == "a")
                    {
                        this.ImageButton3.Visible = false;
                    }
                    else if (Convert.ToInt32(this.Session["iscorporateright"]) == 1 || Convert.ToInt32(this.Session["admin"]) == 1 & (Convert.ToInt32(this.Session["assignmentright"]) == 1 | Convert.ToInt32(this.Session["isTransferRights"]) == 1))
                    {
                        this.ImageButton3.Visible = false;
                    }
                    for (int j = 0; j <= 23; j++)
                    {
                        str = (j >= 10 ? j.ToString() : string.Concat("0", j.ToString()));
                        this.ddlhour.Items.Add(str);
                    }
                    for (int k = 0; k <= 11; k++)
                    {
                        int num1 = k * 5;
                        str1 = (num1 >= 10 ? num1.ToString() : string.Concat("0", num1.ToString()));
                        this.ddlminute.Items.Add(str1);
                    }
                    this.ddlhour.SelectedIndex = 10;
                    this.ddlminute.SelectedIndex = 0;
                    taskClass _taskClass = new taskClass();
                    this.ddlstatus.DataSource = _taskClass.dtrTaskStatus(int.Parse(this.Session["companyID"].ToString()));
                    this.ddlstatus.DataTextField = "taskStatus";
                    this.ddlstatus.DataValueField = "taskStatusId";
                    this.ddlstatus.DataBind();
                    this.ddlstatus.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                    this.ddlstatus.Items[0].Value = "";
                    this.ddlstatus.SelectedIndex = 4;
                    this.ddlpriority.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                    this.ddlpriority.Items.Insert(1, this.objLanguage.convert("High"));
                    this.ddlpriority.Items.Insert(2, this.objLanguage.convert("Low"));
                    this.ddlpriority.Items.Insert(3, this.objLanguage.convert("Normal"));
                    this.ddlpriority.Items[0].Value = "";
                    this.ddlpriority.SelectedIndex = 3;
                    this.objCommon.closeConnection();
                    eventClass _eventClass = new eventClass();
                    SqlDataReader sqlDataReader = _eventClass.dtrName_BasedOnId(int.Parse(base.Request.Params["tasktypeid"]), this.tasktype.Trim().ToLower(), int.Parse(this.Session["companyID"].ToString()));
                    this.assigntoid_hidden.Value = this.Session["userid"].ToString();
                    if (this.tasktype.ToLower().Trim() == "home")
                    {
                        this.txtcontacttype.Value = "";
                        this.contacttxt_hidden.Value = "";
                        this.contactid_hidden.Value = "0";
                        this.typeid_hidden.Value = "0";
                        global.pgDetail = string.Concat(this.objLanguage.GetLanguageConversion("Home_Page_Details"), " >> ", this.objLanguage.GetLanguageConversion("Add_Task"));
                    }
                    bool flag = false;
                    while (sqlDataReader.Read())
                    {
                        string lower = this.tasktype.Trim().ToLower();
                        string str2 = lower;
                        if (lower != null)
                        {
                            switch (str2)
                            {
                                case "lead":
                                    {
                                        this.txtcontacttype.Value = string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
                                        this.contacttxt_hidden.Value = string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
                                        this.contactid_hidden.Value = this.tasktypeid.ToString();
                                        this.typeid_hidden.Value = "0";
                                        strArrays = new string[] { this.objLanguage.convert("Lead"), " >> ", this.objLanguage.convert("Lead Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays);
                                        continue;
                                    }
                                case "client":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["clientname"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["clientname"].ToString().Trim();
                                        int num2 = 0;
                                        while (num2 < this.ddltype.Items.Count)
                                        {
                                            num2++;
                                        }
                                        string[] strArrays1 = new string[] { this.objLanguage.convert("Client"), " >> ", this.objLanguage.convert("Client Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays1);
                                        continue;
                                    }
                                case "contact":
                                    {
                                        this.txtcontacttype.Value = string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
                                        this.contacttxt_hidden.Value = string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
                                        this.contactid_hidden.Value = this.tasktypeid.ToString();
                                        this.typeid_hidden.Value = "0";
                                        string[] strArrays2 = new string[] { this.objLanguage.convert("Contact"), " >> ", this.objLanguage.convert("Contact Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays2);
                                        continue;
                                    }
                                case "opportunity":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["opportunityname"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["opportunityname"].ToString().Trim();
                                        string[] strArrays3 = new string[] { this.objLanguage.convert("Opportunity"), " >> ", this.objLanguage.convert("Opportunity Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays3);
                                        continue;
                                    }
                                case "ticket":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["ticketnumber"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["ticketnumber"].ToString().Trim();
                                        string[] strArrays4 = new string[] { this.objLanguage.convert("Ticket"), " >> ", this.objLanguage.convert("Ticket Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays4);
                                        continue;
                                    }
                                case "campaign":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["campaignname"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["campaignname"].ToString().Trim();
                                        string[] strArrays5 = new string[] { this.objLanguage.convert("Campaign"), " >> ", this.objLanguage.convert("Campaign Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays5);
                                        continue;
                                    }
                                case "contract":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["contractnumber"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["contractnumber"].ToString().Trim();
                                        string[] strArrays6 = new string[] { this.objLanguage.convert("Contract"), " >> ", this.objLanguage.convert("Contract Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays6);
                                        continue;
                                    }
                                case "asset":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["assetname"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["assetname"].ToString().Trim();
                                        string[] strArrays7 = new string[] { this.objLanguage.convert("Asset"), " >> ", this.objLanguage.convert("Asset Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays7);
                                        continue;
                                    }
                                case "product":
                                    {
                                        this.typeid_hidden.Value = this.tasktypeid.ToString();
                                        this.contactid_hidden.Value = "0";
                                        this.txttype.Text = sqlDataReader["product"].ToString().Trim();
                                        this.typetxt_hidden.Value = sqlDataReader["productname"].ToString().Trim();
                                        string[] strArrays8 = new string[] { this.objLanguage.convert("Product"), " >> ", this.objLanguage.convert("Product Detail"), " >> ", this.objLanguage.convert("Add Task") };
                                        global.pgDetail = string.Concat(strArrays8);
                                        continue;
                                    }
                            }
                        }
                        base.Response.Redirect(global.sitePath());
                    }
                    sqlDataReader.Close();
                    if (this.tasktype.ToLower() == "contact")
                    {
                        commonClass _commonClass = new commonClass();
                        int num3 = int.Parse(base.Request.Params["tasktypeid"].ToString());
                        string name = _commonClass.getName(num3, int.Parse(this.Session["companyID"].ToString()), "contact");
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
                string str3 = this.tasktype;
                string str4 = str3;
                if (str3 != null)
                {
                    switch (str4)
                    {
                        case "home":
                            {
                                this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "welcome.aspx");
                                base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "lead":
                            {
                                QueryString queryString = new QueryString()
                        {
                            { "leadid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str5 = "../lead/lead_detail.aspx";
                                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                                str5 = string.Concat(str5, queryString1.ToString());
                                this.btncancel.PostBackUrl = str5;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../lead/lead_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("LEADS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str5, " style=text-decoration:underline>", this.objBase.ReturnScreenName("LEADS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "contact":
                            {
                                QueryString queryString2 = new QueryString()
                        {
                            { "contactid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str6 = "../contact/contact_detail.aspx";
                                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                                str6 = string.Concat(str6, queryString3.ToString());
                                this.btncancel.PostBackUrl = str6;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../contact/contact_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("CONTACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str6, " style=text-decoration:underline>", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "client":
                            {
                                QueryString queryString4 = new QueryString()
                        {
                            { "clientid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str7 = "../client/client_detail.aspx";
                                QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                                str7 = string.Concat(str7, queryString5.ToString());
                                this.btncancel.PostBackUrl = str7;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("CLIENTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href =", str7, " style=text-decoration:underline>", this.objBase.ReturnScreenName("CLIENTS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "opportunity":
                            {
                                QueryString queryString6 = new QueryString()
                        {
                            { "opportunityid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str8 = "../opportunity/opportunity_detail.aspx";
                                QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                                str8 = string.Concat(str8, queryString7.ToString());
                                this.btncancel.PostBackUrl = str8;
                                strArrays = new string[] { "<a href=../welome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../opportunity/opportunity_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str8, " style=text-decoration:underline>", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "ticket":
                            {
                                QueryString queryString8 = new QueryString()
                        {
                            { "ticketid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str9 = "../ticket/ticket_detail.aspx";
                                QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                                str9 = string.Concat(str9, queryString9.ToString());
                                this.btncancel.PostBackUrl = str9;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decration:underline>Home</a>&nbsp;>&nbsp;<a href=../ticket/ticket_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("TICKETS", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str9, " style=text-decoration:underline>", this.objBase.ReturnScreenName("TICKETS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "campaign":
                            {
                                QueryString queryString10 = new QueryString()
                        {
                            { "campaignid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str10 = "../campaign/campaign_detail.aspx";
                                QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                                str10 = string.Concat(str10, queryString11.ToString());
                                this.btncancel.PostBackUrl = str10;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../campaign/campaign_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("CAMPAIGN", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str10, " style=text-decoration:underline>", this.objBase.ReturnScreenName("CAMPAIGN", 2, "p"), " Details<a/>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "contract":
                            {
                                QueryString queryString12 = new QueryString()
                        {
                            { "contractid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str11 = "../contract/contract_detail.aspx";
                                QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                                str11 = string.Concat(str11, queryString13.ToString());
                                this.btncancel.PostBackUrl = str11;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../contract/contract_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("CONTRACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str11, " style=text-decoration:underline>", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "asset":
                            {
                                QueryString queryString14 = new QueryString()
                        {
                            { "assetid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str12 = "../asset/asset_detail.aspx";
                                QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                                str12 = string.Concat(str12, queryString15.ToString());
                                this.btncancel.PostBackUrl = str12;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../asset/asset_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("ASSETS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str12, " style=text-decoration:underline>", this.objBase.ReturnScreenName("ASSETS", 2, "p"), " Details</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "product":
                            {
                                QueryString queryString16 = new QueryString()
                        {
                            { "productid", this.tasktypeid.ToString() },
                            { "isnew", "2" }
                        };
                                string str13 = "../product/product_detail.aspx";
                                QueryString queryString17 = Encryption.EncryptQueryString(queryString16);
                                str13 = string.Concat(str13, queryString17.ToString());
                                this.btncancel.PostBackUrl = str13;
                                strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../product/product_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("PRODUCTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str13, " style=text-decoration:underline>", this.objBase.ReturnScreenName("PRODUCTS", 2, "p"), "</a>" };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "estimate":
                            {
                                this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "estimates/estimate_item_form.aspx?frm=view&estid=", this.EstID);
                                estID = new object[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a class=subnavigator href=", this.strSitepath, "estimates/estimate_item_form.aspx?frm=view&estid=", this.EstID, " style=text-decoration:underline>Estimate Summary</a>&nbsp;>&nbsp;" };
                                base.Navigation_Path(string.Concat(estID), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "job":
                            {
                                this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "jobs/job_item_form.aspx?frm=view&estid=", this.EstID);
                                estID = new object[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a class=subnavigator href=", this.strSitepath, "jobs/job_item_form.aspx?frm=view&estid=", this.EstID, " style=text-decoration:underline>Job Summary</a>&nbsp;>&nbsp;" };
                                base.Navigation_Path(string.Concat(estID), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "invoice":
                            {
                                this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "invoice/invoice_item_form.aspx?frm=view&estid=", this.EstID);
                                estID = new object[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a class=subnavigator href=", this.strSitepath, "invoice/invoice_item_form.aspx?frm=view&estid=", this.EstID, " style=text-decoration:underline>Invoice Summary</a>&nbsp;>&nbsp;" };
                                base.Navigation_Path(string.Concat(estID), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
                                break;
                            }
                        case "purchase":
                            {
                                this.btncancel.PostBackUrl = string.Concat(global.sitePath(), "purchase/purchase_add.aspx?type=edit&id=", this.EstID);
                                estID = new object[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a class=subnavigator href=", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", this.EstID, " style=text-decoration:underline>Purchase Edit</a>&nbsp;>&nbsp;" };
                                base.Navigation_Path(string.Concat(estID), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Add_Task")));
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
                string str14 = string.Concat("selecttaskassignto.aspx?pg=", this.tasktype);
                this.ImageButton3.Attributes.Add("onclick", string.Concat("javascript:window.open('", str14, "', 'Lead','width=745,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
                this.ImageButton2.Attributes.Add("onclick", "javascript:openwin2();return false;");
                this.ImageButton1.Attributes.Add("onclick", "javascript:openwin1();return false;");
                string str15 = string.Concat("selectsubjectpopup.aspx?tasktype=", this.tasktype);
                this.ImageButton9.Attributes.Add("onclick", string.Concat("javascript:window.open('", str15, "', 'subject','width=750,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
                this.ddltype.Attributes.Add("OnSelectedIndexChanged", "javascript:window.return('You have Change the Dropdown');");
                this.ddltype.Attributes.Add("onchange", "javaScript:showddltype();");
                if (!base.IsPostBack)
                {
                    this.txttypevalue = base.ReplaceSingleQuote(this.txttype.Text);
                }
                this.txtduedate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
                now = DateTime.Now;
                now = Convert.ToDateTime(now.ToString());
                this.newdate = now.ToShortDateString();
                this.txtduedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
                this.txtduedate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
            }
            catch
            {
            }
            return;
        Label0:
            base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
            //goto Label1;
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
    }
}