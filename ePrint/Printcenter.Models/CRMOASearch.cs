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

public class CRMOASearch
{
	public CRMOASearch()
	{
	}

	public static string ReturnOASearch(string CompanyID, string ClientID, int NotespageNummber, string WhereCondition, string Type, string SearchText)
	{
		int notespageNummber = 5 * NotespageNummber;
		StringBuilder stringBuilder = new StringBuilder();
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		BaseClass baseClass = new BaseClass();
		dataSet = DepartmentBaseClass.Crm_TaskEvent_Select_SalesTerget_Search(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num, WhereCondition, Type, SearchText);
		DataTable item = dataSet.Tables[0];
		stringBuilder.Append("<div style='margin-left: 1px; margin-bottom:5px;'>");
		DataSet dataSet1 = DepartmentBaseClass.CRM_Select_SalesTarget(num, Convert.ToInt32(CompanyID));
		baseClass.Return_IsEnable_CRM(Convert.ToInt32(CompanyID));
		if (dataSet1.Tables[0].Rows.Count > 0)
		{
			foreach (DataRow row in dataSet1.Tables[0].Rows)
			{
				if (Type == "TasknCall" || Type == "")
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Tasks_Calls"), "</span>"));
				}
				else if (Type != "Task")
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Open_Calls"), "</span>"));
				}
				else
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Open_Tasks"), "</span>"));
				}
			}
		}
		foreach (DataRow dataRow in dataSet.Tables[1].Rows)
		{
			stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;margin-left:5px;'>(", dataRow["NoCount"].ToString(), ")</span>"));
		}
		stringBuilder.Append("</div>");
		stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:97.6%' cellpadding='0' cellspacing='0'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:12%;'>");
		stringBuilder.Append("<div style='margin-top:0px;margin-left:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Subject"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:12%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold; margin-left:5px;'>", _languageClass.GetLanguageConversion("Status"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:4.7%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:9.8%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Assigned_To"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:12%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Contact_Name"), "</span>"));
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
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:9%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Due_Date"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:6%;'>");
		stringBuilder.Append("<div style='margin-right:5px;float:right;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Action"), "</span>"));
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
					BaseClass baseClass1 = new BaseClass();
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='9'>");
					stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
					stringBuilder.Append("<tr>");
					string str = "";
					str = baseClass1.SpecialDecode(row1["Subject"].ToString());
					string str1 = str.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] objArray = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:11%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray));
					stringBuilder.Append("<div style='margin-left:5px;'>");
					string[] strArrays = new string[] { "<span title ='", str1.Replace("'", "`"), "' >", str, "</span>" };
					stringBuilder.Append(string.Concat(strArrays));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item1 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:13%;padding-left:1%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item1));
					stringBuilder.Append("<div style='margin-left:5px;'>");
					string str2 = "";
					str2 = baseClass1.SpecialDecode(row1["Status"].ToString());
					string str3 = str2.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					if (row1["Status"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
					}
					else
					{
						string[] strArrays1 = new string[] { "<span  title ='", str3.Replace("'", "`"), "'>", str2, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</td>");
					object[] objArray1 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:4.7%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(row1["SectionName"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					string str4 = "";
					str4 = baseClass1.SpecialDecode(row1["AssignTo"].ToString());
					string str5 = str4.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] item2 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:8.8%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item2));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					string[] strArrays2 = new string[] { "<span title ='", str5.Replace("'", "`"), "'>", str4, "</span>" };
					stringBuilder.Append(string.Concat(strArrays2));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					string str6 = "";
					str6 = baseClass1.SpecialDecode(row1["Contactname"].ToString());
					string str7 = str6.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] objArray2 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:13%;padding-left:1%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray2));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					string[] strArrays3 = new string[] { "<span title ='", str7.Replace("'", "`"), "'>", str6, "</span>" };
					stringBuilder.Append(string.Concat(strArrays3));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item3 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:10%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item3));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(row1["ContactMobile"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] objArray3 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:10%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray3));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(row1["Contactphone"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					if (row1["SectionName"].ToString().ToLower() == "call")
					{
						commonClass _commonClass = new commonClass();
						string str8 = _commonClass.Eprint_return_DateTime_Before_View(row1["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] item4 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:9%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(item4));
						stringBuilder.Append("<div style='margin-left:0px;'>");
						if (str8 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str9 = str8.ToString();
							char[] chrArray = new char[] { ' ' };
							string str10 = str9.Split(chrArray)[0].ToString();
							string str11 = string.Concat(str10, " ", row1["CallStartTime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str11, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						commonClass _commonClass1 = new commonClass();
						string str12 = _commonClass1.Eprint_return_DateTime_Before_View(row1["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] objArray4 = new object[] { "<td id='btnOpnactivitySearch_", num2, "' style='width:9%;cursor:pointer;''href='javascript://' img onclick=\"Open_Activity_details('", row1["id"], "','", row1["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(objArray4));
						stringBuilder.Append("<div style='margin-left:0px;'>");
						if (str12 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str13 = str12.ToString();
							char[] chrArray1 = new char[] { ' ' };
							string str14 = str13.Split(chrArray1)[0].ToString();
							string str15 = string.Concat(str14, " ", row1["eventtime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str15, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("<td style='width:6%;'>");
					stringBuilder.Append("<div style='margin-top:1px;margin-right:5px;float:right;'>");
					if (row1["SectionName"].ToString().ToLower() == "task")
					{
						object[] languageConversion = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Task.png' title='", _languageClass.GetLanguageConversion("Complete_Task"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_Task('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion));
					}
					else if (row1["SectionName"].ToString().ToLower() != "call")
					{
						object[] languageConversion1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion1));
					}
					else
					{
						object[] languageConversion2 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Call.png' title='", _languageClass.GetLanguageConversion("Complete_Call"), "' style='cursor:pointer;' onclick=\"Complete_Call('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span><span style='margin-left:3px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row1["id"], "','", row1["CompanyId"], "','", row1["Clientid"], "','", row1["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion2));
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("</table>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					num1++;
					num2++;
				}
			}
			stringBuilder.Append("</table>");
			if (dataSet.Tables[0].Rows.Count <= 5 || dataSet.Tables[0].Rows.Count <= dataTable.Rows.Count)
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px; margin-bottom:4px; margin-top: 6px;'>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreOA' style='margin-left:10px;display:none;'><a onclick='javascript:HideMoreSearchedOAByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
				stringBuilder.Append("</div>");
			}
			else
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 5px; margin-bottom:4px;'>");
				stringBuilder.Append("<table>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowMoreOA' style='margin-left:10px;display:block;'><a onclick='javascript:LoadMoreSearchedOpenActivityByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Show_More"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowAllOA' style='margin-left:10px;display:none;'><a href='javascript://' style='cursor:pointer;color:#10357f;' onclick=\"LoadAllSearchedOAByJsn();return false;\"/>", _languageClass.GetLanguageConversion("Show_All"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreOA' style='margin-left:10px;display:none;'><a onclick='javascript:HideMoreSearchedOAByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				stringBuilder.Append("</div>");
			}
		}
		catch
		{
		}
		if (item.Rows.Count == 0)
		{
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td colspan='9'>");
			stringBuilder.Append("<table ID='NoTasknCallRecord' class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
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