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

public class CRMCloseActivitySearch
{
	public CRMCloseActivitySearch()
	{
	}

	public static string ReturnCloseActivitySearch(string CompanyID, string ClientID, int NotespageNummber, string WhereCondition, string Type, string SearchText)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int notespageNummber = 5 * NotespageNummber;
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		BaseClass baseClass = new BaseClass();
		dataSet = DepartmentBaseClass.Crm_select_CloseActivity_SalesTargetSearch(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num, WhereCondition, Type, SearchText);
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
				else if (Type != "Call")
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Close_Tasks"), "</span>"));
				}
				else
				{
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Close_Calls"), "</span>"));
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
					stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;margin-left:5px;'>(", current["NoCount"].ToString(), ")</span>"));
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
		stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:97.6%;margin-top:-2px;' cellpadding='0' cellspacing='0'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:12%;'>");
		stringBuilder.Append("<div style='margin-top:5px;margin-left:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Subject"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:12%;'>");
		stringBuilder.Append("<div style='margin-top:0px;margin-left:5px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Status"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:4.7%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:10%;'>");
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
				foreach (DataRow dataRow in dataTable.Rows)
				{
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='9' style='width:6%;'>");
					stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
					stringBuilder.Append("<tr>");
					string str = "";
					str = baseClass.SpecialDecode(dataRow["Subject"].ToString());
					string str1 = str.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] objArray = new object[] { "<td id='btnclosedetails_", num2, "' style='width:11%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray));
					stringBuilder.Append("<div style='margin-top:0px;margin-left:5px;'>");
					string[] strArrays = new string[] { "<span title ='", str1.Replace("'", "`"), "' >", baseClass.SpecialDecode(dataRow["Subject"].ToString()), " </a></span>" };
					stringBuilder.Append(string.Concat(strArrays));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] item1 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:13%;padding-left:1%;cursor:pointer;''href='javascript://' onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item1));
					stringBuilder.Append("<div style='margin-left:0px;margin-left:5px;'>");
					string str2 = "";
					str2 = baseClass.SpecialDecode(dataRow["Status"].ToString());
					string str3 = str2.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					if (dataRow["Status"].ToString() == "")
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
					object[] objArray1 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:4.7%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("<div style='margin-left:1px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(dataRow["SectionName"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					BaseClass baseClass1 = new BaseClass();
					string str4 = "";
					str4 = baseClass1.SpecialDecode(dataRow["AssignTo"].ToString());
					string str5 = str4.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] item2 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:9%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item2));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					string[] strArrays2 = new string[] { "<span title ='", str5.Replace("'", "`"), "'>", str4, "</span>" };
					stringBuilder.Append(string.Concat(strArrays2));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

					string str6 = "";
					str6 = baseClass.SpecialDecode(dataRow["Contactname"].ToString());
					string str7 = str6.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
					object[] objArray2 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:13%;padding-left:1%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray2));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					string[] strArrays3 = new string[] { "<span title ='", str7.Replace("'", "`"), "'>", str6, "</span>" };
					stringBuilder.Append(string.Concat(strArrays3));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");

					object[] item3 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(item3));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(dataRow["ContactMobile"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					object[] objArray3 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:10%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
					stringBuilder.Append(string.Concat(objArray3));
					stringBuilder.Append("<div style='margin-top:0px;'>");
					stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(dataRow["Contactphone"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");


					if (dataRow["SectionName"].ToString().ToLower() == "call")
					{
						commonClass _commonClass = new commonClass();
						string str8 = _commonClass.Eprint_return_DateTime_Before_View(dataRow["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] item4 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:9%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(item4));
						stringBuilder.Append("<div style='margin-top:0px;'>");
						if (str8 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str9 = str8.ToString();
							char[] chrArray = new char[] { ' ' };
							string str10 = str9.Split(chrArray)[0].ToString();
							string str11 = string.Concat(str10, " ", dataRow["CallStartTime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str11, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						commonClass _commonClass1 = new commonClass();
						string str12 = _commonClass1.Eprint_return_DateTime_Before_View(dataRow["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
						object[] objArray4 = new object[] { "<td id='btnclosedetails_", num2, "' style='width:9%;cursor:pointer;''href='javascript://'  onclick=\"Open_Activity_details('", dataRow["id"], "','", dataRow["SectionName"], "',this.id);return false;\" src=''>" };
						stringBuilder.Append(string.Concat(objArray4));
						stringBuilder.Append("<div style='margin-top:0px;'>");
						if (str12 == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string str13 = str12.ToString();
							char[] chrArray1 = new char[] { ' ' };
							string str14 = str13.Split(chrArray1)[0].ToString();
							string str15 = string.Concat(str14, " ", dataRow["eventtime"].ToString());
							stringBuilder.Append(string.Concat("<span>", str15, "</span>"));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("<td style='width:6%;'>");
					stringBuilder.Append("<div style='margin-right:5px;float:right;'>");
					object[] languageConversion = new object[] { "<span><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_CloseActivities('", dataRow["id"], "','", dataRow["CompanyId"], "','", dataRow["Clientid"], "','", dataRow["SectionName"], "');return false;\"/> </a></span>" };
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
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreCloAct' style='margin-left:10px;display:none;'><a onclick='javascript:LoadHideSearchedCloseActivityByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
				stringBuilder.Append("</div>");
			}
			else
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 5px; margin-bottom:4px;'>");
				stringBuilder.Append("<table>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowMoreCA' style='margin-left:10px;display:block;'><a onclick='javascript:LoadMoreSearchedCloseActivityByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Show_More"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowAllCA' style='margin-left:10px;display:none;'><a href='javascript://' style='cursor:pointer;color:#10357f;' onclick=\"LoadMoreClSearchedbyJson();return false;\"/>", _languageClass.GetLanguageConversion("Show_All"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreCloAct' style='margin-left:10px;display:none;'><a onclick='javascript:LoadHideSearchedCloseActivityByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
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