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

public class CRMAllOASearch
{
	public CRMAllOASearch()
	{
	}

	public static string ReturnAllOASearch(string CompanyID, string ClientID, int NotespageNummber, string WhereCondition, string Type, string SearchText)
	{
		int notespageNummber = 5 * NotespageNummber;
		StringBuilder stringBuilder = new StringBuilder();
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		dataSet = DepartmentBaseClass.Crm_TaskEvent_Select_SalesTerget_Search(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num, WhereCondition, Type, SearchText);
		try
		{
			DataTable dataTable = dataSet.Tables[0].Rows.Cast<DataRow>().Take<DataRow>(notespageNummber).CopyToDataTable<DataRow>();
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red;margin-top:-2px; width:100%' cellpadding='0' cellspacing='0'>");
				if (dataTable.Rows.Count > 0)
				{
					int num1 = 0;
					int num2 = 0;
					foreach (DataRow row in dataTable.Rows)
					{
						BaseClass baseClass = new BaseClass();
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='9'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						string str = "";
						str = baseClass.SpecialDecode(row["Subject"].ToString());
						stringBuilder.Append("<td style='width:17%;'>");
						stringBuilder.Append("<div style='margin-left:4px;'>");
						object[] item = new object[] { "<span ><a id='btndetails_", num2, "' href='javascript://' style='cursor:pointer;' onclick=\"Open_Activity_details('", row["id"], "','", row["SectionName"], "',this.id);return false;\"/>", str, " </a></span>" };
						stringBuilder.Append(string.Concat(item));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td  style='width:9%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						string str1 = "";
						str1 = baseClass.SpecialDecode(row["Status"].ToString());
						string str2 = str1.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						if (row["Status"].ToString() == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string[] strArrays = new string[] { "<span  title ='", str2, "'>", str1, "</span>" };
							stringBuilder.Append(string.Concat(strArrays));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:5%;'>");
						stringBuilder.Append("<div style='margin-left:7px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["SectionName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						string str3 = "";
						str3 = baseClass.SpecialDecode(row["AssignTo"].ToString());
						string str4 = str3.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						stringBuilder.Append("<td  style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:7px;'>");
						string[] strArrays1 = new string[] { "<span title ='", str4, "'>", str3, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

						string str5 = "";
						str5 = baseClass.SpecialDecode(row["Contactname"].ToString());
						string str6 = str5.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:10px;'>");
						string[] strArrays2 = new string[] { "<span title ='", str6, "'>", str5, "</span>" };
						stringBuilder.Append(string.Concat(strArrays2));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        string str51 = "";
                        str5 = baseClass.SpecialDecode(row["ContactEmailAddress"].ToString());
                        string str61 = str5.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
                        stringBuilder.Append("<td style='width:12%;'>");
                        stringBuilder.Append("<div style='margin-left:10px;'>");
                        string[] strArrays21 = new string[] { "<span title ='", str61, "'>", str51, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays21));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");

                        stringBuilder.Append("<td style='width:10%;'>");
						stringBuilder.Append("<div style='margin-left:13px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["ContactMobile"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:10%;'>");
						stringBuilder.Append("<div style='margin-left:13px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["Contactphone"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        string str512 = "";
                        str5 = baseClass.SpecialDecode(row["DepartmentName"].ToString());
                        string str612 = str5.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
                        stringBuilder.Append("<td style='width:12%;'>");
                        stringBuilder.Append("<div style='margin-left:10px;'>");
                        string[] strArrays212 = new string[] { "<span title ='", str612, "'>", str512, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays212));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");

                        if (row["SectionName"].ToString().ToLower() == "call")
						{
							commonClass _commonClass = new commonClass();
							string str7 = _commonClass.Eprint_return_DateTime_Before_View(row["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:13px;'>");
							if (str7 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str8 = str7.ToString();
								char[] chrArray = new char[] { ' ' };
								string str9 = str8.Split(chrArray)[0].ToString();
								string str10 = string.Concat(str9, " ", row["CallStartTime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str10, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						else
						{
							commonClass _commonClass1 = new commonClass();
							string str11 = _commonClass1.Eprint_return_DateTime_Before_View(row["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:13px;'>");
							if (str11 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str12 = str11.ToString();
								char[] chrArray1 = new char[] { ' ' };
								string str13 = str12.Split(chrArray1)[0].ToString();
								string str14 = string.Concat(str13, " ", row["eventtime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str14, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						stringBuilder.Append("<td style='width:7%;'>");
						stringBuilder.Append("<div style='margin-left:1px;'>");
						if (row["SectionName"].ToString().ToLower() == "task")
						{
							object[] objArray = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_OpenActivities('", row["id"], "','", row["SectionName"].ToString(), "',this.id);return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_Task('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span><span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Task.png' title='", _languageClass.GetLanguageConversion("Complete_Task"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray));
						}
						else if (row["SectionName"].ToString().ToLower() != "call")
						{
							object[] item1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_OpenActivities('", row["id"], "','", row["SectionName"].ToString(), "',this.id);return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(item1));
						}
						else
						{
							object[] objArray1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_OpenActivities('", row["id"], "','", row["SectionName"].ToString(), "',this.id);return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span><span style='margin-left:3px;'><a href='javascript://'><img src='../images/Finish-Call.png' title='", _languageClass.GetLanguageConversion("Complete_Call"), "' style='cursor:pointer;' onclick=\"Complete_Call('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray1));
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
			}
		}
		catch
		{
		}
		return stringBuilder.ToString();
	}
}