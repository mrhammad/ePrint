using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
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
    public partial class task_edit : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

	public int taskId;

	public int tasktypeid;

	public string tasktype = "";

	public commonClass objCommon = new commonClass();

	public languageClass objLanguage = new languageClass();

	public BaseClass objBase = new BaseClass();

	public string strSitepath = global.sitePath();

	public string ddltypevalue = string.Empty;

	public string txttypevalue = string.Empty;

	public string ddltypevalue1 = string.Empty;

	public string txttypevalue1 = string.Empty;

	public string temptxt = string.Empty;

	public int UserID;

	public string tabcolor = "";

	public string DateFormat = string.Empty;

	public int companyid;

	public string VersionNumber = ConnectionClass.VersionNumber;

	public BasePage objpage = new BasePage();

	private Global gloobj = new Global();

	private SettingsBasePage objSetBase = new SettingsBasePage();

	public string newdate = string.Empty;

	private BaseClass objBC = new BaseClass();

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

	public task_edit()
	{
	}

	protected void btnDelete_OnClick(object sender, EventArgs e)
	{
		try
		{
			SettingsBasePage.settings_subject_delete(this.companyid, base.ReplaceSingleQuote(this.ddlsubject.SelectedItem.Text));
			this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
			this.ddlsubject.DataBind();
			this.ddlsubject.Items.Insert(0, " ");
			this.ddlsubject.Items[0].Text = "---Select---";
			this.ddlsubject.Items[0].Value = "0";
			this.ddlsubject.SelectedIndex = 0;
		}
		catch
		{
		}
	}

	protected void btnOK_OnClick(object sender, EventArgs e)
	{
		try
		{
			SettingsBasePage.settings_subject_insert(this.companyid, base.SpecialEncode(this.txtSubject.Text));
			this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
			this.ddlsubject.DataBind();
			this.ddlsubject.SelectedIndex = this.ddlsubject.Items.Count - 1;
			this.ddlsubject.Items.Insert(0, " ");
			this.ddlsubject.Items[0].Text = "---Select---";
			this.ddlsubject.Items[0].Value = "0";
		}
		catch
		{
		}
	}

	protected void btnsave_Click1(object sender, EventArgs e)
	{
		try
		{
			taskClass _taskClass = new taskClass();
			int num = Convert.ToInt32(this.Session["companyID"]);
			string str = base.SpecialEncode(this.ddlsubject.SelectedItem.Text);
			string str1 = base.SpecialEncode(this.ddlstatus.SelectedItem.Value);
			string str2 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, base.SpecialEncode(this.txtduedate.Text));
			string str3 = string.Concat(this.ddlhour.SelectedItem.Text, ":", this.ddlminute.SelectedItem.Text);
			str2 = str2;
			commonClass _commonClass = new commonClass();
			string str4 = "";
			string empty = string.Empty;
			empty = this.contactid_hidden.Value;
			this.ddltype.SelectedValue.ToString().ToLower();
			base.SpecialEncode(this.txtcontacttype.Value);
			base.SpecialEncode(this.txttype.Text);
			base.SpecialEncode(this.contacttxt_hidden.Value);
			base.SpecialEncode(this.typetxt_hidden.Value);
			string str5 = base.SpecialEncode(this.ddlpriority.SelectedItem.Text);
			string str6 = base.SpecialEncode(this.txtcomment.Text);
			int num1 = Convert.ToInt32(this.ddlassigneto.SelectedValue);
			int num2 = Convert.ToInt32(this.Session["userID"]);
			string str7 = DateTime.Now.ToString();
			int num3 = 0;
			long num4 = (long)0;
			_taskClass.task_Edit(this.taskId, num, str, "", str1, str2, str3, Convert.ToInt32(empty), str5, this.tasktype, num4, str6, 0, num1, num2, str7, str4, num3);
			if (this.Chkemail.Checked.ToString().ToLower() == "true")
			{
				checkEmail _checkEmail = new checkEmail();
				ArrayList arrayLists = new ArrayList();
				arrayLists.Add(str);
				arrayLists.Add(str2);
				arrayLists.Add(str6);
				_checkEmail.SendEmailToClient(this.Session["email"].ToString(), arrayLists, "Add Task", int.Parse(this.Session["companyID"].ToString()), this.Session["language"].ToString());
			}
		}
		catch
		{
		}
		base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
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
		try
		{
			this.btnOK.Text = this.objLanguage.GetLanguageConversion("Save");
			this.btnCancel_Popup.Text = this.objLanguage.GetLanguageConversion("Cancel");
			this.ImageButton5.ToolTip = this.objLanguage.GetLanguageConversion("Cancel");
			this.btnsave.Text = this.objLanguage.GetLanguageConversion("Save");
			this.btncancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
			this.ImageButton9.ToolTip = this.objLanguage.GetLanguageConversion("Add_Subject");
			this.ImageButton2.ToolTip = this.objLanguage.GetLanguageConversion("Select_User");
			this.Chkemail.Text = this.objLanguage.GetLanguageConversion("Send_Notification_Email");
			this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
			if (base.Request.Params["tasktype"].ToString() != "")
			{
				global.pageName = base.Request.Params["tasktype"].ToString();
			}
			global.pgName = "";
			this.gloobj.setpagename("home");
			this.companyid = int.Parse(this.Session["companyID"].ToString());
			this.ddlassigneto.Focus();
			this.DateFormat = this.objpage.GetRegionalSettings(this.companyid, "Dateformat");
			DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
			this.newdate = dateTime.ToShortDateString();
			this.pnlMoreThanOneRecord.Visible = false;
			this.pnlMoreThanOneRecord1.Visible = false;
			this.lblcontacterror.Visible = false;
			this.lbltxttypeerror.Visible = false;
			if (!base.IsPostBack)
			{
				this.objSetBase.Bind_User(this.ddlassigneto, this.companyid, "---Select---");
				this.objSetBase.Bind_Subject(this.ddlsubject, this.companyid, "---Select---");
				this.ddlassigneto.Items.Insert(this.ddlassigneto.Items.Count, " ");
				this.ddlassigneto.Items[this.ddlassigneto.Items.Count - 1].Text = "All";
				this.ddlassigneto.Items[this.ddlassigneto.Items.Count - 1].Value = "-1";
			}
			global.pgDetail = string.Concat(this.objLanguage.GetLanguageConversion("Task"), " >> ", this.objLanguage.GetLanguageConversion("Task_Edit"));
			if (this.Session["email"] == null)
			{
				base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
			}
			this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["tasktype"]);
			base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Edit_Task"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
			this.lblduedate_value.Text = DateTime.Now.ToShortDateString().ToString();
			try
			{
				this.tasktype = base.Request.Params["tasktype"].ToString();
				this.tasktypeid = int.Parse(base.Request.Params["tasktypeid"].ToString());
			}
			catch
			{
			}
			string str2 = this.tasktype;
			string str3 = str2;
			if (str2 != null)
			{
				switch (str3)
				{
					case "home":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Edit_Task")));
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
						string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../lead/lead_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("LEADS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str4, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("LEADS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays), "&nbsp;>&nbsp;Edit Task");
						break;
					}
					case "client":
					{
						QueryString queryString2 = new QueryString()
						{
							{ "clientid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str5 = "../client/client_detail.aspx";
						QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
						str5 = string.Concat(str5, queryString3.ToString());
						this.btncancel.PostBackUrl = str5;
						string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx style=text-decoration:underline;color:white class='subnavigator'>", this.objBase.ReturnScreenName("CLIENTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str5, " style=text-decoration:underline;color:white class='subnavigator'>", this.objBase.ReturnScreenName("CLIENTS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays1), "&nbsp;>&nbsp;Edit Task");
						break;
					}
					case "contact":
					{
						QueryString queryString4 = new QueryString()
						{
							{ "contactid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str6 = "../contact/contact_detail.aspx";
						QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
						str6 = string.Concat(str6, queryString5.ToString());
						this.btncancel.PostBackUrl = str6;
						string[] strArrays2 = new string[] { "<a href=../welcome.aspx class='subnavigator' style-decoration:underline >Home</a>&nbsp;>&nbsp;<a href=../contact/contact_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str6, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays2), "&nbsp;>&nbsp;Edit Task");
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
						string[] strArrays3 = new string[] { "<a href=../welome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../opportunity/opportunity_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str7, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays3), "&nbsp;>&nbsp;Edit Task");
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
						string[] strArrays4 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decration:underline>Home</a>&nbsp;>&nbsp;<a href=../ticket/ticket_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("TICKETS", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str8, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("TICKETS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays4), "&nbsp;>&nbsp;Edit Task");
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
						string[] strArrays5 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../campaign/campaign_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CAMPAIGN", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str9, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CAMPAIGN", 2, "p"), " Details<a/>" };
						base.Navigation_Path(string.Concat(strArrays5), "&nbsp;>&nbsp;Edit Task");
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
						string[] strArrays6 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../contract/contract_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTRACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str10, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays6), "&nbsp;>&nbsp;Edit Task");
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
						string[] strArrays7 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../asset/asset_view.aspx style=text-decoration:underline>", this.objBase.ReturnScreenName("ASSETS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str11, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("ASSETS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays7), "&nbsp;>&nbsp;Edit Task");
						break;
					}
					case "estimate":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Edit");
						break;
					}
					case "job":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Edit");
						break;
					}
					case "invoice":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Edit");
						break;
					}
					case "purchase":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Edit");
						break;
					}
				}
			}
			eventClass _eventClass = new eventClass();
			SqlDataReader sqlDataReader = _eventClass.dtrName_BasedOnId(int.Parse(base.Request.Params["tasktypeid"]), this.tasktype.Trim().ToLower(), this.companyid);
			string empty = string.Empty;
			if (this.tasktype.ToLower().Trim() == "home")
			{
			}
			while (sqlDataReader.Read())
			{
				string lower = this.tasktype.Trim().ToLower();
				string str12 = lower;
				if (lower != null)
				{
					switch (str12)
					{
						case "lead":
						{
							string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
							continue;
						}
						case "client":
						{
							sqlDataReader["clientname"].ToString().Trim();
							continue;
						}
						case "contact":
						{
							string.Concat(sqlDataReader["FirstName"].ToString().Trim(), " ", sqlDataReader["LastName"].ToString().Trim());
							continue;
						}
						case "opportunity":
						{
							sqlDataReader["opportunityname"].ToString().Trim();
							continue;
						}
						case "ticket":
						{
							sqlDataReader["ticketnumber"].ToString().Trim();
							continue;
						}
						case "campaign":
						{
							sqlDataReader["campaignname"].ToString().Trim();
							continue;
						}
						case "contract":
						{
							sqlDataReader["contractnumber"].ToString().Trim();
							continue;
						}
						case "asset":
						{
							sqlDataReader["assetname"].ToString().Trim();
							continue;
						}
						case "product":
						{
							sqlDataReader["productname"].ToString().Trim();
							continue;
						}
					}
				}
				base.Response.Redirect(global.sitePath());
			}
			sqlDataReader.Close();
			this.taskId = int.Parse(base.Request.Params["taskId"]);
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
				this.ImageButton3.Visible = false;
				if (this.Session["AssignmentSetting"].ToString().Trim() == "a")
				{
					this.ImageButton3.Visible = false;
				}
				else if (Convert.ToInt32(this.Session["iscorporateright"]) == 1 || Convert.ToInt32(this.Session["admin"]) == 1 & (Convert.ToInt32(this.Session["assignmentright"]) == 1 | Convert.ToInt32(this.Session["isTransferRights"]) == 1))
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
					int num = j * 5;
					str1 = (num >= 10 ? num.ToString() : string.Concat("0", num.ToString()));
					this.ddlminute.Items.Add(str1);
				}
				taskClass _taskClass = new taskClass();
				this.ddlstatus.DataSource = _taskClass.dtrTaskStatus(int.Parse(this.Session["companyid"].ToString()));
				this.ddlstatus.DataTextField = "taskStatus";
				this.ddlstatus.DataValueField = "taskStatus";
				this.ddlstatus.DataBind();
				for (int k = 0; k < this.ddlstatus.Items.Count; k++)
				{
					if (this.ddlstatus.Items[k].Text.Trim().ToLower() == "completed")
					{
						this.ddlstatus.Items[k].Text = this.objLanguage.convert("Completed");
					}
				}
				this.ddlstatus.Items.Insert(0, string.Concat("-----", this.objLanguage.convert("Select"), "-----"));
				this.ddlstatus.Items[0].Value = "";
				this.ddlpriority.Items.Insert(0, string.Concat("-----", this.objLanguage.convert("Select"), "-----"));
				this.ddlpriority.Items.Insert(1, this.objLanguage.convert("High"));
				this.ddlpriority.Items.Insert(2, this.objLanguage.convert("Normal"));
				this.ddlpriority.Items.Insert(3, this.objLanguage.convert("Low"));
				this.ddlpriority.Items[0].Value = "";
				this.objCommon.closeConnection();
				SqlDataReader sqlDataReader1 = _taskClass.task_Select_Reader(this.taskId, Convert.ToInt32(this.Session["companyId"]));
				while (sqlDataReader1.Read())
				{
					string str13 = sqlDataReader1["dueDate"].ToString();
					commonClass _commonClass = new commonClass();
					this.txtduedate.Text = this.objCommon.Eprint_return_Date_Before_View(str13, this.companyid, this.UserID, false);
					this.txtcomment.Text = base.dispstrtxtbox(sqlDataReader1["description"].ToString().Trim(), 120);
					this.txtcomment.Text = base.SpecialDecode(this.txtcomment.Text);
					this.txtcontacttype.Value = base.SpecialDecode(sqlDataReader1["contactname"].ToString().Trim());
					this.contacttxt_hidden.Value = sqlDataReader1["contactname"].ToString().Trim();
					for (int l = 0; l < this.ddlassigneto.Items.Count; l++)
					{
						if (this.ddlassigneto.Items[l].Value == sqlDataReader1["assigntouserid"].ToString())
						{
							this.ddlassigneto.SelectedIndex = l;
						}
					}
					for (int m = 0; m < this.ddlsubject.Items.Count; m++)
					{
						if (this.ddlsubject.Items[m].Text.Trim() == base.SpecialDecode(sqlDataReader1["subject"].ToString().Trim()))
						{
							this.ddlsubject.SelectedIndex = m;
						}
					}
					this.contactid_hidden.Value = sqlDataReader1["contactid"].ToString();
					this.assigntoid_hidden.Value = sqlDataReader1["assigntouserid"].ToString();
					this.typeid_hidden.Value = "0";
					this.tasktype = sqlDataReader1["contacttype"].ToString().Trim().ToLower();
					try
					{
						for (int n = 0; n < this.ddlhour.Items.Count; n++)
						{
							if (sqlDataReader1["taskTime"].ToString() != "" && sqlDataReader1["taskTime"].ToString().Trim().Length > 0 && this.ddlhour.Items[n].Text.Trim() == sqlDataReader1["taskTime"].ToString().Trim().Substring(0, 2))
							{
								this.ddlhour.SelectedIndex = n;
							}
						}
						for (int o = 0; o < this.ddlminute.Items.Count; o++)
						{
							if (sqlDataReader1["taskTime"].ToString() != "" && sqlDataReader1["taskTime"].ToString().Trim().Length > 0 && this.ddlminute.Items[o].Text.Trim() == sqlDataReader1["taskTime"].ToString().Trim().Substring(3, 2))
							{
								this.ddlminute.SelectedIndex = o;
							}
						}
						for (int p = 0; p < this.ddlpriority.Items.Count; p++)
						{
							if (this.ddlpriority.Items[p].Value.ToString().Trim().ToLower() == sqlDataReader1["priority"].ToString().Trim().ToLower())
							{
								this.ddlpriority.SelectedIndex = p;
							}
						}
						for (int q = 0; q < this.ddlstatus.Items.Count; q++)
						{
							if (this.ddlstatus.Items[q].Value.ToString().Trim().ToLower() == sqlDataReader1["taskstatus"].ToString().Trim().ToLower())
							{
								this.ddlstatus.SelectedIndex = q;
							}
						}
					}
					catch
					{
					}
				}
				sqlDataReader1.Close();
				this.lblcontacterror.Visible = false;
			}
			bool flag = false;
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
			string str14 = string.Concat("selecttaskassignto.aspx?pg=", base.Request.Params["tasktype"]);
			this.ImageButton3.Attributes.Add("onclick", string.Concat("javascript:window.open('", str14, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
			this.ImageButton2.Attributes.Add("onclick", "javascript:openwin2();return false;");
			this.ImageButton1.Attributes.Add("onclick", "javascript:openwin1();return false;");
			string.Concat("selectsubjectpopup.aspx?tasktype=", base.Request.Params["tasktype"]);
			this.btncancel.PostBackUrl = base.Request.UrlReferrer.ToString();
			this.txtduedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
		}
		catch
		{
		}
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