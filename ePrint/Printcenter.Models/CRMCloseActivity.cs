using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMCloseActivity
{
	public CRMCloseActivity()
	{
	}

	public static string ReturnCloseActivity(string CompanyID, string ClientID, int NotespageNummber)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int notespageNummber = 5 * NotespageNummber;
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		BaseClass baseClass = new BaseClass();
		dataSet = DepartmentBaseClass.rm_select_CloseActivity_SalesTarget(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num);
		DataTable item = dataSet.Tables[0];
		stringBuilder.Append("<div style='margin-left: 1px; margin-bottom:5px;'>");
		DataSet dataSet1 = DepartmentBaseClass.CRM_Select_SalesTarget(num, Convert.ToInt32(CompanyID));
		string str = baseClass.Return_IsEnable_CRM(Convert.ToInt32(CompanyID));
		if (str.Trim().ToLower() != "true")
		{
			stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;m'>", _languageClass.GetLanguageConversion("Close_Tasks"), "</span>"));
		}
		else if (dataSet1.Tables[0].Rows.Count > 0)
		{
			foreach (DataRow row in dataSet1.Tables[0].Rows)
			{
				if (row["IsTaskEventCall"].ToString().ToLower() != "1")
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Close_Tasks"), "</span>"));
					stringBuilder.Append(string.Concat("<span style='margin-left:6px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_CloseActivities();return false;\"/> </a></span>"));
				}
				else
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Tasks_Calls"), "</span>"));
				}
			}
		}
		if (item.Rows.Count > 0)
		{
			IEnumerator enumerator = dataSet.Tables[1].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow current = (DataRow)enumerator.Current;
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;margin-left:5px;'>(", current["NoOfCount"].ToString(), ")</span>"));
					DepartmentBaseClass.CRM_Select_SalesTarget(num, Convert.ToInt32(CompanyID));
					baseClass.Return_IsEnable_CRM(Convert.ToInt32(CompanyID));
					if (str.Trim().ToLower() != "true")
					{
						stringBuilder.Append("<table cellpadding='0' cellspacing='0' style='margin-left:120px; margin-top:-13px;'>");
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td>");
						stringBuilder.Append("<div id='Showclosedactivity'>");
						stringBuilder.Append(string.Concat("<span style='margin-left:0px;'><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Show_Close_Tasks"), "' style='cursor:pointer;' onclick=\"showclosedtaskandcall();return false;\"/> </a></span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("<td>");
						stringBuilder.Append("<td>");
						stringBuilder.Append("<div id='hideclosedactivity' style='display:none'>");
						stringBuilder.Append(string.Concat("<spanstyle='margin-left:6px;><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Hide_Close_Tasks"), "' style='cursor:pointer;' onclick=\"Hideclosedtaskandcall();return false;\"/> </a></span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("<td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
					}
					else if (dataSet1.Tables[0].Rows.Count > 0)
					{
						foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
						{
							if (dataRow["IsTaskEventCall"].ToString().ToLower() != "1")
							{
								stringBuilder.Append("<table cellpadding='0' cellspacing='0' style='margin-left:120px; margin-top:-13px;'>");
								stringBuilder.Append("<tr>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<div id='Showclosedactivity'>");
								stringBuilder.Append(string.Concat("<span style='margin-left:0px;'><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Show_Close_Tasks"), "' style='cursor:pointer;' onclick=\"showclosedtaskandcall();return false;\"/> </a></span>"));
								stringBuilder.Append("</div>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<div id='hideclosedactivity' style='display:none'>");
								stringBuilder.Append(string.Concat("<spanstyle='margin-left:6px;><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Hide_Close_Tasks"), "' style='cursor:pointer;' onclick=\"Hideclosedtaskandcall();return false;\"/> </a></span>"));
								stringBuilder.Append("</div>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("</tr>");
								stringBuilder.Append("</table>");
							}
							else
							{
								stringBuilder.Append("<table cellpadding='0' cellspacing='0' style='margin-left:182px;'>");
								stringBuilder.Append("<tr>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<div id='Showclosedactivity' style='display:none;'>");
								stringBuilder.Append(string.Concat("<span style='margin-left:0px;'><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Show_Close_Tasks_Calls"), "' style='cursor:pointer;' onclick=\"showclosedtaskandcall();return false;\"/> </a></span>"));
								stringBuilder.Append("</div>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("<div id='hideclosedactivity' style='display:none'>");
								stringBuilder.Append(string.Concat("<spanstyle='margin-left:6px;><a href='javascript://'><img src='../images/image_details.png' title='", _languageClass.GetLanguageConversion("Hide_Close_Tasks_Calls"), "' style='cursor:pointer;' onclick=\"Hideclosedtaskandcall();return false;\"/> </a></span>"));
								stringBuilder.Append("</div>");
								stringBuilder.Append("<td>");
								stringBuilder.Append("</tr>");
								stringBuilder.Append("</table>");
							}
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		stringBuilder.Append("</div>");
		stringBuilder.Append("<div id='DivclosedActivityTable'>");
		stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:98%;' cellpadding='0' cellspacing='0'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-left:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Subject"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Status"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:4%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Assigned_To"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Contact_Name"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");

        stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
        stringBuilder.Append("<div style='margin-top:0px;'>");
        stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", "Contact Email", "</span>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");

        stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Contact_Mobile"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Contact_Phone"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");

        stringBuilder.Append("<td class='bgcustomizeNew' style='width:11%;'>");
        stringBuilder.Append("<div style='margin-top:0px;'>");
        stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", "Department Name", "</span>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");

        stringBuilder.Append("<td class='bgcustomizeNew' style='width:9%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Due_Date"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:6%;'>");
		stringBuilder.Append("<div style='float:right;margin-right:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black; margin-left:5px; font-weight:bold;'>", _languageClass.GetLanguageConversion("Action"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("</tr>");
		try
		{
			DataTable dataTable = dataSet.Tables[0].Rows.Cast<DataRow>().Take<DataRow>(notespageNummber).CopyToDataTable<DataRow>();
			if (dataTable.Rows.Count > 0)
			{
				int num1 = 0;
				int num2 = 0;
				foreach (DataRow row1 in dataTable.Rows)
				{
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='11' /*style='width:6%;'*/>");
					stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
					stringBuilder.Append("<tr>");
					string str1 = "";
					str1 = (row1["Subject"].ToString().Length <= 15 ? baseClass.SpecialDecode(row1["Subject"].ToString()) : string.Concat(baseClass.SpecialDecode(row1["Subject"].ToString().Substring(0, 15)), "..."));
					object[] objArray = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray));
					stringBuilder.Append("<div style='margin-left:5px;'>");
					stringBuilder.Append(string.Concat("<span >", str1, " </span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item1 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;padding-left:0%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item1));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					if (row1["Status"].ToString() == "")
					{
						stringBuilder.Append("<span>NA</span>");
					}
					else
					{
						string[] strArrays = new string[] { "<span  title ='", baseClass.SpecialDecode(row1["Status"].ToString()), "'>", baseClass.SpecialDecode(row1["Status"].ToString()), "</span>" };
						stringBuilder.Append(string.Concat(strArrays));
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] objArray1 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:4%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row1["SectionName"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					BaseClass baseClass1 = new BaseClass();
					object[] item2 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item2));
					stringBuilder.Append("<div style='margin-top:0px;'>");
                    string assignedTo = baseClass1.SpecialDecode(row1["AssignTo"].ToString());
                    assignedTo = assignedTo.Length > 15 ? assignedTo.Substring(0, 15) + "..." : assignedTo;
					string[] strArrays1 = new string[] { "<span title ='", row1["AssignTo"].ToString(), "'>", assignedTo , "</span>" };
					stringBuilder.Append(string.Concat(strArrays1));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] objArray2 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;padding-left:0%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray2));
					stringBuilder.Append("<div style='margin-top:0px;'>");
                    string contactname = baseClass1.SpecialDecode(row1["Contactname"].ToString());
                    contactname = contactname.Length > 15 ? contactname.Substring(0, 15) + "..." : contactname;
                    string[] strArrays2 = new string[] { "<span title ='", baseClass.SpecialDecode(row1["Contactname"].ToString()), "'>", contactname, "</span>" };
					stringBuilder.Append(string.Concat(strArrays2));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

                    object[] item13 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
                    stringBuilder.Append(string.Concat(item13));
                    string contactEmailAddress = baseClass1.SpecialDecode(row1["ContactEmailAddress"].ToString());
                    contactEmailAddress = contactEmailAddress.Length > 15 ? contactEmailAddress.Substring(0, 15) + "..." : contactEmailAddress;
                    stringBuilder.Append("<div style='margin-left:0px;'>");
                    stringBuilder.Append(string.Concat("<span title='" + baseClass1.SpecialDecode(row1["ContactEmailAddress"].ToString()) + "'>", contactEmailAddress, "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");

                    object[] item3 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item3));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row1["ContactMobile"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

					object[] objArray3 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray3));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row1["Contactphone"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

                    object[] item14 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:11%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
                    stringBuilder.Append(string.Concat(item14));
                    stringBuilder.Append("<div style='margin-left:0px;'>");
                    stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(row1["DepartmentName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");

                    if (row1["SectionName"].ToString().ToLower() == "call")
					{
						commonClass _commonClass = new commonClass();
						string str2 = _commonClass.Eprint_return_DateTime_Before_View(row1["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] item4 = new object[] { "<td  id='btnclosedetails_", num2, "' style='width:9%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(item4));
						stringBuilder.Append("<div style='margin-top:0px;'>");
						if (str2 == "")
						{
							stringBuilder.Append("<span>NA</span>");
						}
						else
						{
							string str3 = str2.ToString();
							char[] chrArray = new char[] { ' ' };
							string str4 = str3.Split(chrArray)[0].ToString();
							string str5 = string.Concat(str4, " ", row1["CallStartTime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str5, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						commonClass _commonClass1 = new commonClass();
						string str6 = _commonClass1.Eprint_return_DateTime_Before_View(row1["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] objArray4 = new object[] { "<td  id='btnclosedetails_", num2, "' style='width:9%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(objArray4));
						stringBuilder.Append("<div style='margin-top:0px;'>");
						if (str6 == "")
						{
							stringBuilder.Append("<span>NA</span>");
						}
						else
						{
							string str7 = str6.ToString();
							char[] chrArray1 = new char[] { ' ' };
							string str8 = str7.Split(chrArray1)[0].ToString();
							string str9 = string.Concat(str8, " ", row1["eventtime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str9, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("<td style='width:6%;'>");
					stringBuilder.Append("<div style='margin-top:1px;float:right;margin-right:5px;'>");
					object[] languageConversion = new object[] { "<span style='margin-left:18px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_CloseActivities('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span>" };
					stringBuilder.Append(string.Concat(languageConversion));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("</table>");
					num1++;
					num2++;
				}
			}
			stringBuilder.Append("</table>");
			if (dataSet.Tables[0].Rows.Count <= 5 || dataSet.Tables[0].Rows.Count <= dataTable.Rows.Count)
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px; margin-bottom:4px; margin-top:6px;'>");
				string[] languageConversion1 = new string[] { "<span ID='DivHideMoreCloAct' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadHideCloseActivityByJson();return false;\" title='", _languageClass.GetLanguageConversion("Hide_More"), "' alt='", _languageClass.GetLanguageConversion("Hide_More"), "' src='' style='cursor:pointer;'/> </a></span>" };
				stringBuilder.Append(string.Concat(languageConversion1));
				stringBuilder.Append("</div>");
			}
			else
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 5px; margin-bottom:4px;'>");
				stringBuilder.Append("<table>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>");
				string[] languageConversion2 = new string[] { "<span ID='DivShowMoreCA' style='margin-left:10px;display:block;'><a href='javascript://'><img onclick=\"LoadMoreCloseActivityByJson();return false;\" title='", _languageClass.GetLanguageConversion("Show_More"), "' src='' alt='", _languageClass.GetLanguageConversion("Show_More"), "' style='cursor:pointer;'/> </a></span>" };
				stringBuilder.Append(string.Concat(languageConversion2));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				foreach (DataRow dataRow1 in dataSet.Tables[1].Rows)
				{
					string[] strArrays3 = new string[] { "<span ID='DivShowAllCA' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadAllCAByJson('", dataRow1["NoOfCount"].ToString(), "');return false;\" title='", _languageClass.GetLanguageConversion("Show_All"), "' alt='", _languageClass.GetLanguageConversion("Show_All"), "' src='' style='cursor:pointer;'/> </a></span>" };
					stringBuilder.Append(string.Concat(strArrays3));
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				string[] languageConversion3 = new string[] { "<span ID='DivHideMoreCloAct' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadHideCloseActivityByJson();return false;\" title='", _languageClass.GetLanguageConversion("Hide_More"), "' alt='", _languageClass.GetLanguageConversion("Hide_More"), "' src='' style='cursor:pointer;'/> </a></span>" };
				stringBuilder.Append(string.Concat(languageConversion3));
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				stringBuilder.Append("</div>");
			}
			stringBuilder.Append("</div>");
		}
		catch
		{
		}
		if (item.Rows.Count == 0)
		{
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td colspan='9'>");
			stringBuilder.Append("<table ID='NoTasknCallRecord123' class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td style='width:8.3%;'>");
			stringBuilder.Append("<div style='margin-left:5px;font-weight:bold;'>");
			stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("No_Record_Found"), "</span>"));
			stringBuilder.Append("</div>");
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px; margin-bottom:4px; margin-top: 6px;'>");
			stringBuilder.Append("</div>");
		}
		return stringBuilder.ToString();
	}
}