using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class task_detail : BaseClass, IRequiresSessionState
    {
    public string strImagepath = global.imagePath();

	public languageClass objLanguage = new languageClass();

	private commonClass commclass = new commonClass();

	public int UserID;

	public int taskId;

	public int tasktypeid;

	public BaseClass objBase = new BaseClass();

	public string tasktype;

	public string strSitepath = global.sitePath();

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

    public task_detail()
	{
	}

	protected void btncancel_OnClick(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
	}

	protected void btndelete_Click(object sender, EventArgs e)
	{
		try
		{
			string str = "aa";
			taskClass _taskClass = new taskClass();
			_taskClass.task_Delete(str, this.taskId, int.Parse(this.Session["companyid"].ToString()));
			string str1 = this.tasktype;
			string str2 = str1;
			if (str1 != null)
			{
				switch (str2)
				{
					case "lead":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "lead/lead_detail.aspx?leadid=", this.tasktypeid));
						break;
					}
					case "contact":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "contact/contact_detail.aspx?contactid=", this.tasktypeid));
						break;
					}
					case "client":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "client/client_detail.aspx?clientid=", this.tasktypeid));
						break;
					}
					case "opportunity":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "opportunity/opportunity_detail.aspx?opportunityid=", this.tasktypeid));
						break;
					}
					case "ticket":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "ticket/ticket_detail.aspx?ticketid=", this.tasktypeid));
						break;
					}
					case "campaign":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "campaign/campaign_detail.aspx?campaignid=", this.tasktypeid));
						break;
					}
					case "contract":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "contract/contract_detail.aspx?contractid=", this.tasktypeid));
						break;
					}
					case "asset":
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "asset/asset_detail.aspx?assetid=", this.tasktypeid));
						break;
					}
					default:
					{
						base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
						return;
					}
				}
			}
			else
			{
				base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
				return;
			}
		}
		catch
		{
		}
	}

	protected void btnedit_Click(object sender, EventArgs e)
	{
		HttpResponse response = base.Response;
		object[] objArray = new object[] { global.sitePath(), "common/task_edit.aspx?taskId=", this.taskId.ToString(), "&tasktype=", this.tasktype, "&tasktypeid=", this.tasktypeid };
		response.Redirect(string.Concat(objArray));
	}

	protected void btnfollowupevent_Click(object sender, EventArgs e)
	{
		HttpResponse response = base.Response;
		object[] objArray = new object[] { global.sitePath(), "common/event_followup.aspx?eventid=", this.taskId.ToString(), "&cfrom=task&eventtype=", this.tasktype, "&eventtypeid=", this.tasktypeid };
		response.Redirect(string.Concat(objArray));
	}

	protected void btnfollowuptast_Click(object sender, EventArgs e)
	{
		HttpResponse response = base.Response;
		object[] objArray = new object[] { global.sitePath(), "common/task_followup.aspx?taskId=", this.taskId.ToString(), "&cfrom=task&tasktype=", this.tasktype, "&tasktypeid=", this.tasktypeid };
		response.Redirect(string.Concat(objArray));
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			this.btnfollowupevent.Text = this.objLanguage.GetLanguageConversion("Follow_Up_Event");
			this.btnfollowuptast.Text = this.objLanguage.GetLanguageConversion("Follow_Up_Task");
			this.btndelete.Text = this.objLanguage.GetLanguageConversion("Delete");
			this.btnedit.Text = this.objLanguage.GetLanguageConversion("Edit");
			this.btncancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
			this.lbltask.Text = string.Concat(this.objLanguage.GetLanguageConversion("Task"), ":");
			this.companyid = Convert.ToInt32(this.Session["CompanyID"]);
			this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
			global.pageName = base.Request.Params["tasktype"].ToString();
			global.pgName = "";
			this.gloobj.setpagename("home");
			if (!base.IsPostBack)
			{
				this.lbltask.Text = this.objLanguage.convert(this.lbltask.Text);
				this.lblsubject.Text = this.objLanguage.convert(this.lblsubject.Text);
				this.lblstatus.Text = this.objLanguage.convert(this.lblstatus.Text);
				this.lblduedate.Text = this.objLanguage.convert(this.lblduedate.Text);
				this.lblphone.Text = this.objLanguage.convert(this.lblphone.Text);
				this.lblemail.Text = this.objLanguage.convert(this.lblemail.Text);
				this.lblcomment.Text = this.objLanguage.convert(this.lblcomment.Text);
				this.btnedit.Text = this.objLanguage.convert(this.btnedit.Text);
				this.btndelete.Text = this.objLanguage.convert(this.btndelete.Text);
				this.btnfollowuptast.Text = this.objLanguage.convert(this.btnfollowuptast.Text);
				this.btnfollowupevent.Text = this.objLanguage.convert(this.btnfollowupevent.Text);
				this.btncancel.Text = this.objLanguage.convert(this.btncancel.Text);
			}
			if (this.Session["email"] == null)
			{
				base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
			}
			this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["tasktype"]);
			this.btnfollowupevent.BackColor = Color.FromName(this.tabcolor);
			this.btnfollowuptast.BackColor = Color.FromName(this.tabcolor);
			base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Task_Detail"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
			global.pgDetail = string.Concat(this.objLanguage.GetLanguageConversion("Task"), " >> ", this.objLanguage.GetLanguageConversion("Task_Detail"));
			try
			{
				this.taskId = int.Parse(base.Request.Params["taskId"]);
				this.tasktypeid = int.Parse(base.Request.Params["tasktypeid"]);
				this.tasktype = base.Request.Params["tasktype"].ToString().Trim().ToLower();
			}
			catch
			{
				base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
			}
			base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Task_Detail"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
			string str = this.tasktype;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "home":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Detail");
						break;
					}
					case "lead":
					{
						QueryString queryString = new QueryString()
						{
							{ "leadid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str2 = "../lead/lead_detail.aspx";
						QueryString queryString1 = Encryption.EncryptQueryString(queryString);
						str2 = string.Concat(str2, queryString1.ToString());
						string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../lead/lead_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("LEADS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str2, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("LEADS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "client":
					{
						QueryString queryString2 = new QueryString()
						{
							{ "clientid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str3 = "../client/client_detail.aspx";
						QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
						str3 = string.Concat(str3, queryString3.ToString());
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline; color:white'>Home</a>&nbsp;>&nbsp;", "Task Detail");
						break;
					}
					case "contact":
					{
						QueryString queryString4 = new QueryString()
						{
							{ "contactid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str4 = "../contact/contact_detail.aspx";
						QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
						str4 = string.Concat(str4, queryString5.ToString());
						string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../contact/contact_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str4, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays1), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "opportunity":
					{
						QueryString queryString6 = new QueryString()
						{
							{ "opportunityid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str5 = "../opportunity/opportunity_detail.aspx";
						QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
						str5 = string.Concat(str5, queryString7.ToString());
						string[] strArrays2 = new string[] { "<a href=../welome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../opportunity/opportunity_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str5, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays2), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "ticket":
					{
						QueryString queryString8 = new QueryString()
						{
							{ "ticketid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str6 = "../ticket/ticket_detail.aspx";
						QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
						str6 = string.Concat(str6, queryString9.ToString());
						string[] strArrays3 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decration:underline>Home</a>&nbsp;>&nbsp;<a href=../ticket/ticket_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("TICKETS", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str6, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("TICKETS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays3), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "campaign":
					{
						QueryString queryString10 = new QueryString()
						{
							{ "campaignid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str7 = "../campaign/campaign_detail.aspx";
						QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
						str7 = string.Concat(str7, queryString11.ToString());
						string[] strArrays4 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../campaign/campaign_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CAMPAIGN", 1, "p"), "<a/>&nbsp;>&nbsp;<a href=", str7, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CAMPAIGN", 2, "p"), " Details<a/>" };
						base.Navigation_Path(string.Concat(strArrays4), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "contract":
					{
						QueryString queryString12 = new QueryString()
						{
							{ "contractid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str8 = "../contract/contract_detail.aspx";
						QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
						str8 = string.Concat(str8, queryString13.ToString());
						string[] strArrays5 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../contract/contract_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTRACTS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str8, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays5), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "asset":
					{
						QueryString queryString14 = new QueryString()
						{
							{ "assetid", this.tasktypeid.ToString() },
							{ "isnew", "2" }
						};
						string str9 = "../asset/asset_detail.aspx";
						QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
						str9 = string.Concat(str9, queryString15.ToString());
						string[] strArrays6 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=../asset/asset_view.aspx style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("ASSETS", 1, "p"), "</a>&nbsp;>&nbsp;<a href=", str9, " style=text-decoration:underline class='subnavigator'>", this.objBase.ReturnScreenName("ASSETS", 2, "p"), " Details</a>" };
						base.Navigation_Path(string.Concat(strArrays6), "&nbsp;>&nbsp;Task Detail");
						break;
					}
					case "estimate":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Detail");
						break;
					}
					case "job":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Detail");
						break;
					}
					case "invoice":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Detail");
						break;
					}
					case "purchase":
					{
						base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline></a>", "&nbsp;Task Detail");
						break;
					}
				}
			}
			taskClass _taskClass = new taskClass();
			commonClass _commonClass = new commonClass();
			SqlDataReader sqlDataReader = _taskClass.task_Select_detail(this.taskId, Convert.ToInt32(this.Session["companyId"]));
			while (sqlDataReader.Read())
			{
				this.lbltaskname.Text = base.SpecialDecode(sqlDataReader["subject"].ToString().Trim());
				this.lblsubject_value.Text = base.dispstr(_commonClass.replaceLineBreak(sqlDataReader["subject"].ToString().Trim()), 40);
				this.lblsubject_value.Text = base.SpecialDecode(this.lblsubject_value.Text);
				if (sqlDataReader["taskstatus"].ToString().Trim().ToLower() != "completed")
				{
					this.lblstatus_value.Text = base.dispstr(_commonClass.replaceLineBreak(sqlDataReader["taskstatus"].ToString().Trim()), 40);
				}
				else
				{
					this.lblstatus_value.Text = base.dispstr(_commonClass.replaceLineBreak(this.objLanguage.convert(sqlDataReader["taskstatus"].ToString().Trim())), 45);
				}
				this.lblstatus_value.Text = base.SpecialDecode(this.lblstatus_value.Text);
				string str10 = sqlDataReader["dueDate"].ToString();
				sqlDataReader["taskTime"].ToString();
				this.lblduedate_value.Text = this.commclass.Eprint_return_Date_Before_View(str10, this.companyid, this.UserID, false);
				this.lblemail_value.Text = base.dispstr(_commonClass.replaceLineBreak(sqlDataReader["email"].ToString().Trim()), 40);
				this.lblcomment_value.Text = BaseClass.WrapString(sqlDataReader["description"].ToString().Trim(), 125);
				this.lblcomment_value.Text = base.SpecialDecode(this.lblcomment_value.Text);
				this.label1.Text = this.objLanguage.GetLanguageConversion("Priority");
				this.label1_value.Text = base.SpecialDecode(sqlDataReader["priority"].ToString().Trim());
				this.lblname.Text = this.objLanguage.GetLanguageConversion("Contact_Name");
				this.lblname_value.Text = base.SpecialDecode(sqlDataReader["contactname"].ToString().Trim());
				this.lblLinkedTo_value.Text = base.SpecialDecode(sqlDataReader["linkedTo"].ToString().Trim());
				this.lblAssignedToValue.Text = base.SpecialDecode(sqlDataReader["assigntousername"].ToString().Trim());
				string empty = string.Empty;
				if (this.lblLinkedTo_value.Text.ToLower().Contains("est"))
				{
					empty = this.lblLinkedTo_value.Text;
					this.lblLinkedTo_value.Text = string.Concat("Estimate - ", empty);
				}
				if (this.lblLinkedTo_value.Text.ToLower().Contains("job"))
				{
					empty = this.lblLinkedTo_value.Text;
					this.lblLinkedTo_value.Text = string.Concat("Job - ", empty);
				}
				if (this.lblLinkedTo_value.Text.ToLower().Contains("inv"))
				{
					empty = this.lblLinkedTo_value.Text;
					this.lblLinkedTo_value.Text = string.Concat("Invoice - ", empty);
				}
				if (this.lblLinkedTo_value.Text.ToLower().Contains("po"))
				{
					empty = this.lblLinkedTo_value.Text;
					this.lblLinkedTo_value.Text = string.Concat("Purchase - ", empty);
				}
				if (!this.lblLinkedTo_value.Text.ToLower().Contains("del"))
				{
					continue;
				}
				empty = this.lblLinkedTo_value.Text;
				this.lblLinkedTo_value.Text = string.Concat("Delivery Note - ", empty);
			}
			sqlDataReader.Close();
			string languageConversion = this.objLanguage.GetLanguageConversion("Are_You_Sure_To_Delete_This_Task");
			this.btndelete.Attributes.Add("onclick", string.Concat("javascript:var a=window.confirm('", languageConversion, "');if(a)loadingimage(this.id,'div_deleteprocess');return a;"));
		}
		catch
		{
		}
	}
}
}