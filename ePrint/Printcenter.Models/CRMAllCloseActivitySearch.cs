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

public class CRMAllCloseActivitySearch
{
	public CRMAllCloseActivitySearch()
	{
	}

	public static string ReturnAllCloseActivitySearch(string CompanyID, string ClientID, int NotespageNummber, string WhereCondition, string Type, string SearchText)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int notespageNummber = 5 * NotespageNummber;
		languageClass _languageClass = new languageClass();
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		DataSet dataSet = new DataSet();
		BaseClass baseClass = new BaseClass();
		dataSet = DepartmentBaseClass.Crm_select_CloseActivity_SalesTargetSearch(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), num, WhereCondition, Type, SearchText);
		try
		{
			DataTable dataTable = dataSet.Tables[0].Rows.Cast<DataRow>().Take<DataRow>(notespageNummber).CopyToDataTable<DataRow>();
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red;margin-top:-2px; width:100% cellpadding='0' cellspacing='0'>");
				if (dataTable.Rows.Count > 0)
				{
					int num1 = 0;
					int num2 = 0;
					foreach (DataRow row in dataTable.Rows)
					{
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='9' style='width:6%;'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						string str = "";
						str = baseClass.SpecialDecode(row["Subject"].ToString());
						stringBuilder.Append("<td style='width:17%;'>");
						stringBuilder.Append("<div style='margin-left:4px;'>");
						object[] item = new object[] { "<span ><a id='btnclosedetails_", num2, "' href='javascript://' style='cursor:pointer;' onclick=\"Open_Activity_details('", row["id"], "','", row["SectionName"], "',this.id);return false;\"/>", str, " </a></span>" };
						stringBuilder.Append(string.Concat(item));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:9%;'>");
						stringBuilder.Append("<div style='margin-left:1px;'>");
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
						stringBuilder.Append("<td style='width:5%;'>");
						stringBuilder.Append("<div style='margin-left:8px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["SectionName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						BaseClass baseClass1 = new BaseClass();
						string str3 = "";
						str3 = baseClass1.SpecialDecode(row["AssignTo"].ToString());
						string str4 = str3.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						stringBuilder.Append("<td  style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:6px;'>");
						string[] strArrays1 = new string[] { "<span title ='", str4, "'>", str3, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						string str5 = "";

						str5 = baseClass.SpecialDecode(row["Contactname"].ToString());
						string str6 = str5.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:11px;'>");
						string[] strArrays2 = new string[] { "<span title ='", str6, "'>", str5, "</span>" };
						stringBuilder.Append(string.Concat(strArrays2));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");

                        string str51 = baseClass.SpecialDecode(row["ContactEmailAddress"].ToString());
                        string str61 = str5.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
                        stringBuilder.Append("<td style='width:12%;'>");
                        stringBuilder.Append("<div style='margin-left:11px;'>");
                        string[] strArrays21 = new string[] { "<span title ='", str61, "'>", str51, "</span>" };
                        stringBuilder.Append(string.Concat(strArrays2));
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

                        stringBuilder.Append("<td style='width:10%;'>");
                        stringBuilder.Append("<div style='margin-left:12px;'>");
                        stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["DepartmentName"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");

                        if (row["SectionName"].ToString().ToLower() == "call")
						{
							commonClass _commonClass = new commonClass();
							string str7 = _commonClass.Eprint_return_DateTime_Before_View(row["CallStartdate"].ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(num), false);
							stringBuilder.Append("<td  style='width:12%;'>");
							stringBuilder.Append("<div style='margin-left:12px;'>");
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
							stringBuilder.Append("<div style='margin-left:12px;'>");
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
						stringBuilder.Append("<td style='width:6%;'>");
						stringBuilder.Append("<div style='margin-left:1px;'>");
						object[] languageConversion = new object[] { "<span style='margin-left:25px;'><a href='javascript://'><img src='../images/delete.gif' title='", _languageClass.GetLanguageConversion("Delete"), "' style='cursor:pointer;' onclick=\"delete_CloseActivities('", row["id"], "','", row["CompanyId"], "','", row["Clientid"], "','", row["SectionName"], "');return false;\"/> </a></span>" };
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
			}
		}
		catch
		{
		}
		return stringBuilder.ToString();
	}
}