using nmsCommon;
using nmsLanguage;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace nmsSubsection
{
	public class Subsection : System.Web.UI.Page
	{
		public static string COLOR;

		static Subsection()
		{
			Subsection.COLOR = string.Empty;
		}

		public Subsection()
		{
		}

		public void addSubSectionLead(PlaceHolder plhSubSection, int leadid, int companyID, int userID)
		{
			string str;
			string str1;
			object[] objArray;
			string[] strArrays;
			string empty = string.Empty;
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			string str2 = "";
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			languageClass _languageClass = new languageClass();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand = new SqlCommand("crm_lead_select_subsection", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@leadid", leadid);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			plhSubSection.Controls.Add(new LiteralControl("<TABLE cellSpacing=3 cellPadding=1 width=100% border=0>"));
			while (sqlDataReader.Read())
			{
				num3 = 0;
				num3 = int.Parse(sqlDataReader["noofrecords"].ToString());
				num4 = int.Parse(sqlDataReader["noofemail"].ToString());
				num5 = int.Parse(sqlDataReader["noofopenactivities"].ToString());
				num6 = int.Parse(sqlDataReader["noofactivehistory"].ToString());
				int.Parse(sqlDataReader["noofattachment"].ToString());
				string lower = sqlDataReader["subsectionname"].ToString().ToLower();
				string str3 = lower;
				if (lower == null)
				{
					continue;
				}
				if (str3 == "notes")
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr valign=bottom><td colspan=2 class=headertext nowrap=nowrap>", _languageClass.convert("Notes"), "&nbsp;&nbsp;[&nbsp;")));
					LinkButton linkButton = new LinkButton()
					{
						Text = _languageClass.convert("New")
					};
					objArray = new object[] { global.sitePath(), "common/notes_add.aspx?notetypeid=", leadid, "&noteType=lead" };
					str2 = string.Concat(objArray);
					linkButton.Attributes.Add("onclick", "javascript: showMe('0','0'); return false");
					plhSubSection.Controls.Add(linkButton);
					if (num3 > 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
						HyperLink hyperLink = new HyperLink()
						{
							Text = _languageClass.convert("View All"),
							NavigateUrl = string.Concat(global.sitePath(), "common/notes_viewall.aspx?notetype=lead&notetypeid=", leadid)
						};
						plhSubSection.Controls.Add(hyperLink);
					}
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;<div id=showsubject  style=position:absolute;visibility::hidden;border:1px solid black></div>"));
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
					if (num3 != 0)
					{
						commonClass _commonClass1 = new commonClass();
						SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_notes", _commonClass1.openConnection())
						{
							CommandType = CommandType.StoredProcedure
						};
						sqlCommand1.Parameters.AddWithValue("@notetypeid", leadid);
						sqlCommand1.Parameters.AddWithValue("@notetype", "lead");
						sqlCommand1.Parameters.AddWithValue("@companyID", companyID);
						sqlCommand1.Parameters.AddWithValue("@selectall", "no");
						SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", sqlDataReader["navigationcolor"].ToString(), " valign=top><td width=20% class=headertext>&nbsp;")));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Action")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Date")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Created By")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Description")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						Subsection.COLOR = sqlDataReader["navigationcolor"].ToString();
						string str4 = "";
						num2 = 0;
						while (sqlDataReader1.Read())
						{
							num2++;
							if (num2 % 2 != 0)
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
							}
							str2 = string.Concat(global.sitePath(), "common/notes_edit.aspx?notesid=", sqlDataReader1["notesid"].ToString());
							ImageButton imageButton = new ImageButton();
							num1 = int.Parse(sqlDataReader1["notesid"].ToString());
							object[] objArray1 = new object[] { global.sitePath(), "common/Notes_Editbyajax.aspx?notesid=", sqlDataReader1["notesid"].ToString(), "&notetype=lead&notetypeid=", leadid };
							empty = string.Concat(objArray1);
							imageButton.OnClientClick = "javascript:showMe('2','0');";
							imageButton.ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif");
							AttributeCollection attributes = imageButton.Attributes;
							object[] objArray2 = new object[] { "javascript:ByAjax('", empty, "','", num1, "');return false" };
							attributes.Add("onclick", string.Concat(objArray2));
							plhSubSection.Controls.Add(imageButton);
							ImageButton imageButton1 = new ImageButton();
							num = int.Parse(sqlDataReader1["notesid"].ToString());
							imageButton1.Attributes.Add("onclick", string.Concat("javascript: showMe('1','", num, "'); return false"));
							imageButton1.ImageUrl = string.Concat(global.imagePath(), "delete.gif");
							plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
							plhSubSection.Controls.Add(imageButton1);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
							plhSubSection.Controls.Add(new LiteralControl(_commonClass.Eprint_return_Date_Before_View(sqlDataReader1["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()), true)));
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							plhSubSection.Controls.Add(new LiteralControl(sqlDataReader1["createname"].ToString()));
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							LinkButton linkButton1 = new LinkButton();
							str4 = string.Concat(global.sitePath(), "common/Notes_Detail_byajax.aspx?notesid=", sqlDataReader1["notesid"].ToString());
							linkButton1.OnClientClick = "javascript:displayWindow1();";
							linkButton1.Attributes.Add("onclick", string.Concat("javascript:ByAjaxsubject('", str4, "');return false;"));
							if (sqlDataReader1["description"].ToString().Length <= 100)
							{
								linkButton1.Text = sqlDataReader1["description"].ToString();
								plhSubSection.Controls.Add(linkButton1);
							}
							else
							{
								linkButton1.Text = sqlDataReader1["description"].ToString().Substring(0, 100);
								plhSubSection.Controls.Add(linkButton1);
							}
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
						}
						sqlDataReader1.Close();
						sqlDataReader1.Dispose();
						_commonClass1.closeConnection();
						_commonClass1.Dispose();
						plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
					else
					{
						ControlCollection controls = plhSubSection.Controls;
						strArrays = new string[] { "<tr><td colspan=2 bgcolor=gray><table cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=", sqlDataReader["navigationcolor"].ToString(), " ><tr><td class=normaltext>", _languageClass.convert("No Notes Available."), "</td></tr></table></td></tr>" };
						controls.Add(new LiteralControl(string.Concat(strArrays)));
						Subsection.COLOR = sqlDataReader["navigationcolor"].ToString();
					}
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
				}
				else if (str3 == "open activities")
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap width=1%>", _languageClass.convert("Open Activities"), " &nbsp;&nbsp;[&nbsp;")));
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = _languageClass.convert("New Task")
					};
					HyperLink hyperLink2 = new HyperLink()
					{
						Text = _languageClass.convert("New Event")
					};
					object[] objArray3 = new object[] { global.sitePath(), "common/task_add.aspx?tasktypeid=", leadid, "&tasktype=lead" };
					str2 = string.Concat(objArray3);
					hyperLink1.NavigateUrl = str2;
					plhSubSection.Controls.Add(hyperLink1);
					object[] objArray4 = new object[] { global.sitePath(), "common/event_add.aspx?tasktypeid=", leadid, "&tasktype=lead" };
					str2 = string.Concat(objArray4);
					hyperLink2.NavigateUrl = str2;
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
					plhSubSection.Controls.Add(hyperLink2);
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
					if (num5 != 0)
					{
						commonClass _commonClass2 = new commonClass();
						SqlCommand sqlCommand2 = new SqlCommand("crm_common_select_openactivities", _commonClass2.openConnection())
						{
							CommandType = CommandType.StoredProcedure
						};
						sqlCommand2.Parameters.AddWithValue("@tasktypeid", leadid);
						sqlCommand2.Parameters.AddWithValue("@tasktype", "lead");
						sqlCommand2.Parameters.AddWithValue("@companyID", companyID);
						sqlCommand2.Parameters.AddWithValue("@selectall", "no");
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", sqlDataReader["navigationcolor"].ToString(), " valign=top><td width=20% class=headertext>&nbsp;")));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Action")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Section"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Due Date"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Subject"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Description")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						num7 = 0;
						num2 = 0;
						while (sqlDataReader2.Read() & num7 < 5)
						{
							num7++;
							num2++;
							if (num2 % 2 != 0)
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
							}
							if (sqlDataReader2["tasktype"].ToString().ToLower() != "task")
							{
								object[] objArray5 = new object[] { global.sitePath(), "common/event_edit.aspx?eventid=", sqlDataReader2["taskid"].ToString(), "&eventtype=lead&eventtypeid=", leadid };
								str2 = string.Concat(objArray5);
							}
							else
							{
								object[] objArray6 = new object[] { global.sitePath(), "common/task_edit.aspx?taskid=", sqlDataReader2["taskid"].ToString(), "&tasktype=lead&tasktypeid=", leadid };
								str2 = string.Concat(objArray6);
							}
							HyperLink hyperLink3 = new HyperLink()
							{
								Text = "Edit",
								NavigateUrl = str2,
								ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
							};
							plhSubSection.Controls.Add(hyperLink3);
							HtmlAnchor htmlAnchor = new HtmlAnchor();
							if (sqlDataReader2["tasktype"].ToString().ToLower() != "task")
							{
								htmlAnchor.HRef = string.Concat(global.sitePath(), "common/event_delete.aspx?eventid=", sqlDataReader2["taskid"].ToString());
							}
							else
							{
								htmlAnchor.HRef = string.Concat(global.sitePath(), "common/task_delete.aspx?taskid=", sqlDataReader2["taskid"].ToString());
							}
							htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
							htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
							plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
							plhSubSection.Controls.Add(htmlAnchor);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader2["tasktype"].ToString(), "</td>")));
							commonClass _commonClass3 = new commonClass();
							if (sqlDataReader2["tasktype"].ToString().ToLower() != "task")
							{
								object[] objArray7 = new object[] { global.sitePath(), "common/event_detail.aspx?eventid=", sqlDataReader2["taskid"].ToString(), "&eventtype=lead&eventtypeid=", leadid };
								str2 = string.Concat(objArray7);
								str = _commonClass3.return_Event_DateTime_Before_View(sqlDataReader2["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							}
							else
							{
								object[] objArray8 = new object[] { global.sitePath(), "common/task_detail.aspx?taskid=", sqlDataReader2["taskid"].ToString(), "&leadid=", leadid, "&tasktypeid=", leadid, "&tasktype=lead" };
								str2 = string.Concat(objArray8);
								str = _commonClass3.return_DateTime_Before_View(sqlDataReader2["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							}
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext nowrap=nowrap>", str, "</td>")));
							HyperLink hyperLink4 = new HyperLink()
							{
								Text = sqlDataReader2["subject"].ToString(),
								NavigateUrl = str2
							};
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							plhSubSection.Controls.Add(hyperLink4);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							if (sqlDataReader2["description"].ToString().Length <= 50)
							{
								plhSubSection.Controls.Add(new LiteralControl(sqlDataReader2["description"].ToString()));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader2["description"].ToString().Substring(0, 50), " ...")));
							}
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
						}
						sqlDataReader2.Close();
						sqlDataReader2.Dispose();
						_commonClass2.closeConnection();
						_commonClass2.Dispose();
						plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
					else
					{
						ControlCollection controlCollections = plhSubSection.Controls;
						string[] strArrays1 = new string[] { "<tr><td colspan=2 bgcolor=gray><table cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=", sqlDataReader["navigationcolor"].ToString(), " ><tr><td class=normaltext>", _languageClass.convert("No Open Activies."), "</td></tr></table></td></tr>" };
						controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
					}
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
				}
				else if (str3 == "active history")
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap width=1%>", _languageClass.convert("Activity History"), "&nbsp;&nbsp;")));
					objArray = new object[] { global.sitePath(), "common/event_add.aspx?tasktypeid=", leadid, "&tasktype=lead" };
					str2 = string.Concat(objArray);
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					if (num6 != 0)
					{
						commonClass _commonClass4 = new commonClass();
						SqlCommand sqlCommand3 = new SqlCommand("crm_common_select_activehistory", _commonClass4.openConnection())
						{
							CommandType = CommandType.StoredProcedure
						};
						sqlCommand3.Parameters.AddWithValue("@tasktypeid", leadid);
						sqlCommand3.Parameters.AddWithValue("@tasktype", "lead");
						sqlCommand3.Parameters.AddWithValue("@companyID", companyID);
						sqlCommand3.Parameters.AddWithValue("@selectall", "no");
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", sqlDataReader["navigationcolor"].ToString(), " valign=top><td width=20% class=headertext>&nbsp;")));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Action")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Section"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Due Date"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=headertext>", _languageClass.convert("Subject"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Description")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						num7 = 0;
						num2 = 0;
						while (sqlDataReader3.Read() & num7 < 5)
						{
							num7++;
							num2++;
							if (num2 % 2 != 0)
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
							}
							if (sqlDataReader3["tasktype"].ToString().ToLower() != "task")
							{
								objArray = new object[] { global.sitePath(), "common/event_edit.aspx?eventid=", sqlDataReader3["taskid"].ToString(), "&eventtype=lead&eventtypeid=", leadid };
								str2 = string.Concat(objArray);
							}
							else
							{
								objArray = new object[] { global.sitePath(), "common/task_edit.aspx?taskid=", sqlDataReader3["taskid"].ToString(), "&leadid=", leadid, "&tasktypeid=", leadid, "&tasktype=lead" };
								str2 = string.Concat(objArray);
							}
							HyperLink hyperLink5 = new HyperLink()
							{
								Text = "Edit",
								NavigateUrl = str2,
								ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
							};
							plhSubSection.Controls.Add(hyperLink5);
							HtmlAnchor htmlAnchor1 = new HtmlAnchor();
							if (sqlDataReader3["tasktype"].ToString().ToLower() != "task")
							{
								htmlAnchor1.HRef = string.Concat(global.sitePath(), "common/event_delete.aspx?eventid=", sqlDataReader3["taskid"].ToString());
							}
							else
							{
								htmlAnchor1.HRef = string.Concat(global.sitePath(), "common/task_delete.aspx?taskid=", sqlDataReader3["taskid"].ToString());
							}
							htmlAnchor1.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
							htmlAnchor1.Attributes.Add("onclick", "javascript:return clickDelete();");
							plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
							plhSubSection.Controls.Add(htmlAnchor1);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader3["tasktype"].ToString(), "</td>")));
							commonClass _commonClass5 = new commonClass();
							if (sqlDataReader3["tasktype"].ToString().ToLower() != "task")
							{
								objArray = new object[] { global.sitePath(), "common/event_detail.aspx?eventid=", sqlDataReader3["taskid"].ToString(), "&eventtype=lead&eventtypeid=", leadid };
								str2 = string.Concat(objArray);
								str1 = _commonClass5.return_Event_DateTime_Before_View(sqlDataReader3["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							}
							else
							{
								objArray = new object[] { global.sitePath(), "common/task_detail.aspx?taskid=", sqlDataReader3["taskid"].ToString(), "&leadid=", leadid, "&tasktypeid=", leadid, "&tasktype=lead" };
								str2 = string.Concat(objArray);
								str1 = _commonClass5.return_DateTime_Before_View(sqlDataReader3["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							}
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", str1, "</td>")));
							HyperLink hyperLink6 = new HyperLink()
							{
								Text = sqlDataReader3["subject"].ToString(),
								NavigateUrl = str2
							};
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							plhSubSection.Controls.Add(hyperLink6);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
							if (sqlDataReader3["description"].ToString().Length <= 50)
							{
								plhSubSection.Controls.Add(new LiteralControl(sqlDataReader3["description"].ToString()));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader3["description"].ToString().Substring(0, 50), " ...")));
							}
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
						}
						sqlDataReader3.Close();
						sqlDataReader3.Dispose();
						_commonClass4.closeConnection();
						_commonClass4.Dispose();
						plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
					else
					{
						ControlCollection controls1 = plhSubSection.Controls;
						strArrays = new string[] { "<tr><td colspan=2 bgcolor=gray><table cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=", sqlDataReader["navigationcolor"].ToString(), " ><tr><td class=normaltext>", _languageClass.convert("No Active History."), "</td></tr></table></td></tr>" };
						controls1.Add(new LiteralControl(string.Concat(strArrays)));
					}
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
				}
				else if (str3 == "html email")
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap >", _languageClass.convert("HTML Email"), "&nbsp;&nbsp;[&nbsp;")));
					LinkButton linkButton2 = new LinkButton()
					{
						CausesValidation = false,
						Text = _languageClass.convert("New"),
						OnClientClick = "javascript:displayWindowemail(); return false;"
					};
					plhSubSection.Controls.Add(linkButton2);
					if (num4 > 0)
					{
						HyperLink hyperLink7 = new HyperLink()
						{
							Text = _languageClass.convert("View All"),
							NavigateUrl = string.Concat(global.sitePath(), "common/email_viewall.aspx?sectionname=lead&sectionid=", leadid)
						};
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
						plhSubSection.Controls.Add(hyperLink7);
					}
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
					if (num4 != 0)
					{
						commonClass _commonClass6 = new commonClass();
						SqlCommand sqlCommand4 = new SqlCommand("crm_common_select_email", _commonClass6.openConnection())
						{
							CommandType = CommandType.StoredProcedure
						};
						sqlCommand4.Parameters.AddWithValue("@sectionid", leadid);
						sqlCommand4.Parameters.AddWithValue("@sectionname", "lead");
						sqlCommand4.Parameters.AddWithValue("@companyID", companyID);
						sqlCommand4.Parameters.AddWithValue("@selectall", "no");
						SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><div id=divsend width=100%><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", sqlDataReader["navigationcolor"].ToString(), " valign=top><td width=20% class=headertext>&nbsp;")));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Action")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Subject")));
						plhSubSection.Controls.Add(new LiteralControl("<div id=divhtmalemaildetail style=position:absolute;visibility:Visible;border:1px solid black>"));
						plhSubSection.Controls.Add(new LiteralControl("</div>"));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Send Date")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td class=headertext>"));
						plhSubSection.Controls.Add(new LiteralControl(_languageClass.convert("Message")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						num2 = 0;
						while (sqlDataReader4.Read())
						{
							num2++;
							if (num2 % 2 != 0)
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1% nowrap>&nbsp;"));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1% nowrap>&nbsp;"));
							}
							str2 = string.Concat(global.sitePath(), "common/htmalemail_detailbyajax.aspx?sl=", sqlDataReader4["sl"].ToString());
							ImageButton imageButton2 = new ImageButton()
							{
								OnClientClick = "javascript:displayWindowselectemaildetail();",
								ImageUrl = string.Concat(global.imagePath(), "i-view.gif")
							};
							imageButton2.Attributes.Add("onclick", string.Concat("javascript:ByAjaxemailhtmldeatil('", str2, "'); return false;"));
							plhSubSection.Controls.Add(imageButton2);
							plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
							HtmlAnchor htmlAnchor2 = new HtmlAnchor();
							string str5 = string.Concat(global.sitePath(), "common/email_delete.aspx?sl=", sqlDataReader4["sl"].ToString());
							htmlAnchor2.HRef = string.Concat("javascript:ByAjaxSendmaildelete('", str5, "');");
							htmlAnchor2.InnerHtml = string.Concat("<img style=cursor:hand border=0 src=", global.imagePath(), "delete.gif>");
							htmlAnchor2.Attributes.Add("onclick", "javascript:return clickDelete();");
							plhSubSection.Controls.Add(htmlAnchor2);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td width=15% Nowrap=nowrap>"));
							plhSubSection.Controls.Add(new LiteralControl(sqlDataReader4["subject"].ToString()));
							plhSubSection.Controls.Add(new LiteralControl("</td >"));
							plhSubSection.Controls.Add(new LiteralControl("<td width=20%>"));
							plhSubSection.Controls.Add(new LiteralControl(_commonClass.Eprint_return_Date_Before_View(sqlDataReader4["datesent"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()), true)));
							plhSubSection.Controls.Add(new LiteralControl("</td >"));
							plhSubSection.Controls.Add(new LiteralControl("<td width=60%>"));
							if (sqlDataReader4["message"].ToString().Length <= 100)
							{
								plhSubSection.Controls.Add(new LiteralControl(sqlDataReader4["message"].ToString()));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader4["message"].ToString().Substring(0, 100), " ...")));
							}
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
						}
						sqlDataReader4.Close();
						sqlDataReader4.Dispose();
						_commonClass6.closeConnection();
						_commonClass6.Dispose();
						plhSubSection.Controls.Add(new LiteralControl("</table></div></td></tr>"));
					}
					else
					{
						ControlCollection controlCollections1 = plhSubSection.Controls;
						strArrays = new string[] { "<tr><td colspan=2 bgcolor=gray><div id=divsend width=100%><table cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=", sqlDataReader["navigationcolor"].ToString(), " ><tr><td class=normaltext>", _languageClass.convert("No Email Available."), "</td></tr></table></td></tr>" };
						controlCollections1.Add(new LiteralControl(string.Concat(strArrays)));
					}
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
				}
			}
			sqlDataReader.Close();
			sqlDataReader.Dispose();
			_commonClass.closeConnection();
			_commonClass.Dispose();
			plhSubSection.Controls.Add(new LiteralControl("</TABLE>"));
		}
	}
}