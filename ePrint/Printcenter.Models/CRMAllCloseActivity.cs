using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMAllCloseActivity
{
	public CRMAllCloseActivity()
	{
	}

	public static string ReturnAllCloseActivity(string CompanyID, string ClientID)
	{
		StringBuilder stringBuilder = new StringBuilder();
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		BaseClass baseClass = new BaseClass();
		dataSet = DepartmentBaseClass.rm_select_CloseActivity_SalesTarget(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num);
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
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='9' style='width:6%;'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td style='width:6%;'>");
						stringBuilder.Append("<div style='margin-top:1px;'>");
						object[] languageConversion = new object[] { "<span style='margin-left:5px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_CloseActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:9%;'>");
						stringBuilder.Append("<div style='margin-left:1px;'>");
						string str = "";
						str = (row["Status"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Status"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Status"].ToString().Substring(0, 15)), "..."));
						if (row["Status"].ToString() == "")
						{
							stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
						}
						else
						{
							string[] strArrays = new string[] { "<span  title ='", baseClass.SpecialDecode(row["Status"].ToString()), "'>", str, "</span>" };
							stringBuilder.Append(string.Concat(strArrays));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						string str1 = "";
						str1 = (row["Subject"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Subject"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Subject"].ToString().Substring(0, 15)), "..."));
						stringBuilder.Append("<td style='width:17%;'>");
						stringBuilder.Append("<div style='margin-left:4px;'>");
						object[] item = new object[] { "<span ><a id='btnclosedetails_", num2, "' href='javascript://' style='cursor:pointer;' onclick=\"Closed_Activity_details('", row["id"], "','", row["SectionName"], "',this.id);return false;\"/>", str1, " </a></span>" };
						stringBuilder.Append(string.Concat(item));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:5%;'>");
						stringBuilder.Append("<div style='margin-left:8px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["SectionName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						if (row["SectionName"].ToString().ToLower() == "call")
						{
							commonClass _commonClass = new commonClass();
							string str2 = _commonClass.Eprint_return_DateTime_Before_View(row["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:8px;'>");
							if (str2 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str3 = str2.ToString();
								char[] chrArray = new char[] { ' ' };
								string str4 = str3.Split(chrArray)[0].ToString();
								string str5 = string.Concat(str4, " ", row["CallStartTime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str5, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						else
						{
							commonClass _commonClass1 = new commonClass();
							string str6 = _commonClass1.Eprint_return_DateTime_Before_View(row["DueDate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:8px;'>");
							if (str6 == "")
							{
								stringBuilder.Append(string.Concat("<span>", _languageClass.GetLanguageConversion("NA"), "</span>"));
							}
							else
							{
								string str7 = str6.ToString();
								char[] chrArray1 = new char[] { ' ' };
								string str8 = str7.Split(chrArray1)[0].ToString();
								string str9 = string.Concat(str8, " ", row["eventtime"].ToString());
								stringBuilder.Append(string.Concat("<span>", str9, "</span>"));
							}
							stringBuilder.Append("</div>");
							stringBuilder.Append("</td>");
						}
						string str10 = "";
						str10 = (row["Contactname"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["Contactname"].ToString()) : string.Concat(baseClass.SpecialDecode(row["Contactname"].ToString().Substring(0, 15)), "..."));
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:11px;'>");
						string[] strArrays1 = new string[] { "<span title ='", baseClass.SpecialDecode(row["Contactname"].ToString()), "'>", str10, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        string str101 = (row["ContactEmailAddress"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()) : string.Concat(baseClass.SpecialDecode(row["ContactEmailAddress"].ToString().Substring(0, 15)), "..."));
                        stringBuilder.Append("<td style='width:12%;'>");
                        stringBuilder.Append("<div style='margin-left:11px;'>");
                        string[] strArrays101 = new string[] { "<span title ='", baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()), "'>", str101, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays101));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");

                        stringBuilder.Append("<td style='width:10%;'>");
						stringBuilder.Append("<div style='margin-left:12px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["ContactMobile"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:10%;'>");
						stringBuilder.Append("<div style='margin-left:12px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["Contactphone"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        string str102 = (row["DepartmentName"].ToString().Length <= 15 ? baseClass.SpecialDecode(row["DepartmentName"].ToString()) : string.Concat(baseClass.SpecialDecode(row["DepartmentName"].ToString().Substring(0, 15)), "..."));
                        stringBuilder.Append("<td style='width:12%;'>");
                        stringBuilder.Append("<div style='margin-left:11px;'>");
                        string[] strArrays102 = new string[] { "<span title ='", baseClass.SpecialDecode(row["DepartmentName"].ToString()), "'>", str102, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays102));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");

                        BaseClass baseClass1 = new BaseClass();
						string str11 = "";
						str11 = (row["AssignTo"].ToString().Length <= 15 ? baseClass1.SpecialDecode(row["AssignTo"].ToString()) : baseClass1.SpecialDecode(string.Concat(row["AssignTo"].ToString().Substring(0, 15), "...")));
						stringBuilder.Append("<td  style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:14px;'>");
						string[] strArrays2 = new string[] { "<span title ='", row["AssignTo"].ToString(), "'>", str11, "</span>" };
						stringBuilder.Append(string.Concat(strArrays2));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
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