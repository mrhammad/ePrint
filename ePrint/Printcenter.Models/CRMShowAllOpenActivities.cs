using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMShowAllOpenActivities
{
	public CRMShowAllOpenActivities()
	{
	}

	public static string ReturnAllOpenActivities(string CompanyID, string ClientID)
	{
		StringBuilder stringBuilder = new StringBuilder();
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		dataSet = DepartmentBaseClass.Crm_TaskEvent_Select_SalesTerget(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num);
		try
		{
			if (dataSet.Tables.Count > 0)
			{
				stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:100%' cellpadding='0' cellspacing='0'>");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					int num1 = 0;
					int num2 = 0;
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						BaseClass baseClass = new BaseClass();
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='11'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						string str = "";
						str = (row["Subject"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Subject"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Subject"].ToString().Substring(0, 15)), "..."));
						stringBuilder.Append("<td style='width:17%;'>");
						stringBuilder.Append("<div style='margin-left:4px;'>");
						object[] item = new object[] { "<span ><a id='btndetails_", num2, "' href='javascript://' style='cursor:pointer;' onclick=\"Open_Activity_details('", row["id"], "','", row["SectionName"], "',this.id);return false;\"/>", str, " </a></span>" };
						stringBuilder.Append(string.Concat(item));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td  style='width:9%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						string str1 = "";
						str1 = (row["Status"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Status"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Status"].ToString().Substring(0, 15)), "..."));
						if (row["Status"].ToString() == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string[] strArrays = new string[] { "<span  title ='", baseClass.SpecialDecode(row["Status"].ToString()), "'>", str1, "</span>" };
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
						string str2 = "";
						str2 = (row["AssignTo"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["AssignTo"].ToString()) : baseClass.SpecialDecode(string.Concat(row["AssignTo"].ToString().Substring(0, 15), "...")));
						stringBuilder.Append("<td  style='width:10%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						string[] strArrays1 = new string[] { "<span title ='", row["AssignTo"].ToString(), "'>", str2, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						string str3 = "";
						str3 = (row["Contactname"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Contactname"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Contactname"].ToString().Substring(0, 15)), "..."));
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:10px;'>");
						string[] strArrays2 = new string[] { "<span title ='", baseClass.SpecialDecode(row["Contactname"].ToString()), "'>", str3, "</span>" };
						stringBuilder.Append(string.Concat(strArrays2));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        str3 = "";
                        str3 = (row["ContactEmailAddress"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()) : string.Concat(baseClass.SpecialDecode(row["ContactEmailAddress"].ToString().Substring(0, 15)), "..."));
                        stringBuilder.Append("<td style='width:12.3%;'>");
                        stringBuilder.Append("<div style='margin-left:10px;'>");
                        string[] strArrays3 = new string[] { "<span title ='", baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()), "'>", str3, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays3));
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

                        stringBuilder.Append("<td style='width:10%;'>");
                        stringBuilder.Append("<div style='margin-left:13px;'>");
                        stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["DepartmentName"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");


                        if (row["SectionName"].ToString().ToLower() == "call")
						{
							commonClass _commonClass = new commonClass();
							string str4 = _commonClass.Eprint_return_DateTime_Before_View(row["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:13px;'>");
							if (str4 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str5 = str4.ToString();
								char[] chrArray = new char[] { ' ' };
								string str6 = str5.Split(chrArray)[0].ToString();
								string str7 = string.Concat(str6, " ", row["CallStartTime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str7, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						else
						{
							commonClass _commonClass1 = new commonClass();
							string str8 = _commonClass1.Eprint_return_DateTime_Before_View(row["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:13px;'>");
							if (str8 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str9 = str8.ToString();
								char[] chrArray1 = new char[] { ' ' };
								string str10 = str9.Split(chrArray1)[0].ToString();
								string str11 = string.Concat(str10, " ", row["eventtime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str11, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						stringBuilder.Append("<td style='width:7%;'>");
						stringBuilder.Append("<div style='margin-top:1px;'>");
						if (row["SectionName"].ToString().ToLower() == "task")
						{
							object[] objArray = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_AllOpenActivities('", row["id"], "','", row["SectionName"].ToString(), "');return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_Task('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span><span style='margin-left:5px;'><a href='javascript://'><img src='../images/Finish-Task.png' title='", _languageClass.GetLanguageConversion("Complete_Task"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray));
						}
						else if (row["SectionName"].ToString().ToLower() != "call")
						{
							object[] item1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_AllOpenActivities('", row["id"], "','", row["SectionName"].ToString(), "');return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(item1));
						}
						else
						{
							object[] objArray1 = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img id='imgEdit_", num1, "' onclick=\"Edit_AllOpenActivities('", row["id"], "','", row["SectionName"].ToString(), "');return false;\" src='../images/Edit.gif' title='", _languageClass.GetLanguageConversion("Edit"), "' style='cursor:pointer;'/> </a><span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_OpenActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span><span style='margin-left:3px;'><a href='javascript://'><img src='../images/Finish-Call.png' title='", _languageClass.GetLanguageConversion("Complete_Call"), "' style='cursor:pointer;' onclick=\"Complete_Call('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
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