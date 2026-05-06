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

public class CRMCalls
{
	public CRMCalls()
	{
	}

	public static string ReturnCalls(string CompanyID, string ClientID, int NotespageNummber)
	{
		int notespageNummber = 5 * NotespageNummber;
		StringBuilder stringBuilder = new StringBuilder();
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		DataSet dataSet1 = new DataSet();
		BaseClass baseClass = new BaseClass();
		string str = global.strimagepath;
		dataSet = DepartmentBaseClass.Crm_TaskEvent_Select_SalesTerget(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num);
		dataSet1 = DepartmentBaseClass.rm_select_CloseActivity_SalesTarget(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num);
		DataTable item = dataSet.Tables[0];
		int count = dataSet1.Tables[0].Rows.Count;
		int count1 = item.Rows.Count;
		stringBuilder.Append("<div id='Opentaskncallcount' style='margin-left: 1px; margin-bottom:5px;'>");
		DataSet dataSet2 = DepartmentBaseClass.CRM_Select_SalesTarget(num, Convert.ToInt32(CompanyID));
		baseClass.Return_IsEnable_CRM(Convert.ToInt32(CompanyID));
		if (dataSet2.Tables[0].Rows.Count > 0)
		{
			stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Tasks_Calls"), "</span>"));
		}
		foreach (DataRow row in dataSet.Tables[1].Rows)
		{
			if (row["NoOfCount"].ToString() == "0")
			{
				continue;
			}
			stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;margin-left:5px;'>(", row["NoOfCount"].ToString(), ")</span>"));
			break;
		}
		stringBuilder.Append(string.Concat("<span id='Plus_CallnTask' style='padding-left:5px;cursor:pointer;><a href='javascript://'><img id='AddNewCallnTask' onclick=\"StayonCallnTaskDiv()\";  title='Add Task/Call' src='", str, "plus.gif' style='cursor:pointer;margin-bottom:-3px;'/> </a></span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("<span id='SpntbOpenActivities'>");
		stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:98%' cellpadding='0' cellspacing='0'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;margin-left:5px;'>", _languageClass.GetLanguageConversion("Subject"), "</span>"));
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
		stringBuilder.Append("<div style='margin-top:0px;float:right;margin-right:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black; margin-left:15px; font-weight:bold;'>", _languageClass.GetLanguageConversion("Action"), "</span>"));
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
				foreach (DataRow dataRow in dataTable.Rows)
				{
					BaseClass baseClass1 = new BaseClass();
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='11'>");
					stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
					stringBuilder.Append("<tr>");
					object[] objArray = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray));
					stringBuilder.Append("<div style='margin-left:5px;'>");
                    string strSubject = (dataRow["Subject"].ToString().Length <= 15 ? baseClass.SpecialDecode(dataRow["Subject"].ToString()) : string.Concat(baseClass.SpecialDecode(dataRow["Subject"].ToString().Substring(0, 15)), "..."));
                    string[] strArrays = new string[] { "<span title='", baseClass1.SpecialDecode(dataRow["Subject"].ToString()).Replace("'", "`"), "' >", strSubject, "</span>" };
					stringBuilder.Append(string.Concat(strArrays));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item1 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item1));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					if (dataRow["Status"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
					}
					else
					{
						string[] strArrays1 = new string[] { "<span  title ='", baseClass1.SpecialDecode(dataRow["Status"].ToString()).Replace("'", "`"), "'>", baseClass1.SpecialDecode(dataRow["Status"].ToString()), "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</td>");
					object[] objArray1 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:4%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(dataRow["SectionName"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item2 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item2));
					stringBuilder.Append("<div style='margin-left:1px;'>");
                    string assignedTo = baseClass1.SpecialDecode(dataRow["AssignTo"].ToString());
                    assignedTo = assignedTo.Length > 15 ? assignedTo.Substring(0, 15) + "..." : assignedTo;
                    string[] strArrays2 = new string[] { "<span title ='", baseClass1.SpecialDecode(dataRow["AssignTo"].ToString()).Replace("'", "`"), "'>", assignedTo, "</span>" };
					stringBuilder.Append(string.Concat(strArrays2));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] objArray2 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;padding-left:0%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray2));
					stringBuilder.Append("<div style='margin-left:1px;'>");
                    string contactname = baseClass1.SpecialDecode(dataRow["Contactname"].ToString());
                    contactname = contactname.Length > 15 ? contactname.Substring(0, 15) + "..." : contactname;
                    string[] strArrays3 = new string[] { "<span title ='", baseClass1.SpecialDecode(dataRow["Contactname"].ToString()).Replace("'", "`"), "'>", contactname, "</span>" };
					stringBuilder.Append(string.Concat(strArrays3));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

                    object[] item13 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
                    stringBuilder.Append(string.Concat(item13));
                    string contactEmailAddress = baseClass1.SpecialDecode(dataRow["ContactEmailAddress"].ToString());
                    contactEmailAddress = contactEmailAddress.Length > 15 ? contactEmailAddress.Substring(0, 15) + "..." : contactEmailAddress;

                    stringBuilder.Append("<div style='margin-left:0px;'>");
                    stringBuilder.Append(string.Concat("<span title='"+ baseClass1.SpecialDecode(dataRow["ContactEmailAddress"].ToString()) + "'>", contactEmailAddress, "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");

                    object[] item3 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item3));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(dataRow["ContactMobile"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

					object[] objArray3 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:10%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray3));
					stringBuilder.Append("<div style='margin-left:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(dataRow["Contactphone"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

                    object[] item14 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:11%;padding-left:0%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
                    stringBuilder.Append(string.Concat(item14));
                    stringBuilder.Append("<div style='margin-left:0px;'>");
                    stringBuilder.Append(string.Concat("<span>", baseClass1.SpecialDecode(dataRow["DepartmentName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");

                    if (dataRow["SectionName"].ToString().ToLower() == "call")
					{
						commonClass _commonClass = new commonClass();
						string str1 = _commonClass.Eprint_return_DateTime_Before_View(dataRow["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] item4 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:9%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(item4));
						stringBuilder.Append("<div style='margin-left:0px;'>");
						if (str1 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str2 = str1.ToString();
							char[] chrArray = new char[] { ' ' };
							string str3 = str2.Split(chrArray)[0].ToString();
							string str4 = string.Concat(str3, " ", dataRow["CallStartTime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str4, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						commonClass _commonClass1 = new commonClass();
						string str5 = _commonClass1.Eprint_return_DateTime_Before_View(dataRow["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] objArray4 = new object[] { "<td id='TasknCallbtnview", num2, "' style='width:9%;cursor:pointer;'href='javascript://' img onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(objArray4));
						stringBuilder.Append("<div style='margin-left:0px;'>");
						if (str5 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str6 = str5.ToString();
							char[] chrArray1 = new char[] { ' ' };
							string str7 = str6.Split(chrArray1)[0].ToString();
							string str8 = string.Concat(str7, " ", dataRow["eventtime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str8, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("<td style='width:6%;white-space:nowrap;'>");
					stringBuilder.Append("<div style='margin-top:1px;float:right;margin-right:5px;'>");
					if (dataRow["SectionName"].ToString().ToLower() == "task")
					{
						object[] languageConversion = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Task.png' title='", _languageClass.GetLanguageConversion("Complete_Task"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_Task('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion));
					}
					else if (dataRow["SectionName"].ToString().ToLower() != "call")
					{
						object[] languageConversion1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion1));
					}
					else
					{
						object[] languageConversion2 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Call.png' title='", _languageClass.GetLanguageConversion("Complete_Call"), "' style='cursor:pointer;' onclick=\"Complete_Call('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span><span style='margin-left:3px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span>" };
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
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreOA' style='margin-left:10px;display:none;'><a onclick= 'javascript:HideMoreOAByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
				stringBuilder.Append("</div>");
			}
			else
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 5px; margin-bottom:4px;'>");
				stringBuilder.Append("<table>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowMoreOA' style='margin-left:10px;display:block;'><a onclick='javascript:LoadMoreOpenActivityByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Show_More"), "  </a></span>"));
				stringBuilder.Append("<td>");
				foreach (DataRow row1 in dataSet.Tables[1].Rows)
				{
					string[] strArrays4 = new string[] { "<span ID='DivShowAllOA' style='margin-left:10px;display:none;'><a href='javascript://' style='cursor:pointer;color:#10357f;' onclick=\"LoadAllOpenActiviesbyJsonss('", row1["NoOfCount"].ToString(), "');return false;\"/>", _languageClass.GetLanguageConversion("Show_All"), "  </a></span>" };
					stringBuilder.Append(string.Concat(strArrays4));
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreOA' style='margin-left:10px;display:none;'><a onclick= 'javascript:HideMoreOAByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
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
			stringBuilder.Append("</span>");
			stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px; margin-bottom:4px; margin-top: 6px;'>");
			stringBuilder.Append("</div>");
		}
		return stringBuilder.ToString();
	}
}