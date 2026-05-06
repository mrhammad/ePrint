using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMNotesSearchAll
{
	public CRMNotesSearchAll()
	{
	}

	public static string ReturnNotesSearchAll(string CompanyID, string SectionID, int NotespageNummber, string WhereCondition, string SearchText)
	{
		languageClass _languageClass = new languageClass();
		StringBuilder stringBuilder = new StringBuilder();
		DataSet dataSet = DepartmentBaseClass.CRM_Select_TopFiveNotesSearch(Convert.ToInt32(CompanyID), Convert.ToInt32(SectionID), WhereCondition, SearchText);
		BaseClass baseClass = new BaseClass();
		try
		{
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
				int num1 = 0;
				stringBuilder.Append("<table style='border: 0px solid red; width:100%;' cellpadding='0' cellspacing='0'>");
				if (dataSet.Tables.Count > 0)
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						commonClass _commonClass = new commonClass();
						string str = _commonClass.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(row["createDate"].ToString(), Convert.ToInt32(CompanyID), num, false);
						string[] strArrays = str.ToString().Split(new char[] { ' ' });
						string empty = string.Empty;
						int num2 = Convert.ToInt32(row["attachmentId"].ToString());
						DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='6'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td style='width:17%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						string str1 = "";
						str1 = baseClass.SpecialDecode(row["title"].ToString());
						string str2 = str1.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						if (row["filename"].ToString() != "")
						{
							if (row["title"].ToString() == "")
							{
								object[] languageConversion = new object[] { "<span <a href='javascript://' style='cursor:pointer;' onclick=\"Notes_details('", num2, "');return false;\"/>", _languageClass.GetLanguageConversion("untitled"), " </a></span>" };
								stringBuilder.Append(string.Concat(languageConversion));
							}
							else
							{
								object[] objArray = new object[] { "<span title ='", str2.Replace("'", "`"), "'><a href='javascript://' style='cursor:pointer;' onclick=\"Notes_details('", num2, "');return false;\"/>", str1, " </a></span>" };
								stringBuilder.Append(string.Concat(objArray));
							}
						}
						else if (row["title"].ToString() == "")
						{
							object[] languageConversion1 = new object[] { "<span><a href='javascript://' style='cursor:pointer;' onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\"/>", _languageClass.GetLanguageConversion("untitled"), " </a></span>" };
							stringBuilder.Append(string.Concat(languageConversion1));
						}
						else
						{
							object[] objArray1 = new object[] { "<span title ='", str2.Replace("'", "`"), "' ><a href='javascript://' style='cursor:pointer;' onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\"/>", str1, " </a></span>" };
							stringBuilder.Append(string.Concat(objArray1));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:20%;'>");
						stringBuilder.Append("<div style='margin-left:0px;'>");
						string str3 = "";
						str3 = baseClass.SpecialDecode(row["subject"].ToString());
						string str4 = str3.Replace("<span style=background-color:yellow; >", "").Replace("</span>", "");
						string[] strArrays1 = new string[] { "<span  title ='", str4.Replace("'", "`"), "'>", str3, "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:0px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["UserName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:0px;'>");
						stringBuilder.Append(string.Concat("<span>", baseClass.SpecialDecode(row["SpecificName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:12%;'>");
						stringBuilder.Append("<div style='margin-left:0px;'>");
						stringBuilder.Append(string.Concat("<span>", strArrays[0], "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:6%;'>");
						stringBuilder.Append("<div style='margin-left:0px;'>");
						if (row["filename"].ToString() != "")
						{
							object[] languageConversion2 = new object[] { "<span id='EditNotes_", num1, "' style='margin-left:5px;float:left;margin-top:3px;'><a href='javascript://'><img onclick=\"Edit_Allnotes('", num2, "','EditNotes_", num1, "');return false;\" title='", _languageClass.GetLanguageConversion("Edit"), "' src='../images/Edit.gif' style='cursor:pointer;'/> </a></span>" };
							stringBuilder.Append(string.Concat(languageConversion2));
							object[] objArray2 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img title='", _languageClass.GetLanguageConversion("Delete"), "' src='../images/delete.gif' style='cursor:pointer;' onclick=\"deleteAll_Note('", num2, "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray2));
							object[] languageConversion3 = new object[] { "<span id='ShowAttachIcon' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(languageConversion3));
						}
						else
						{
							object[] objArray3 = new object[] { "<span id='EditNotes_", num1, "' style='margin-left:5px; float:left; margin-top:3px;'><a href='javascript://'><img onclick=\"Edit_Allnotes('", num2, "','EditNotes_", num1, "');return false;\" title='", _languageClass.GetLanguageConversion("Edit"), "' src='../images/Edit.gif' style='cursor:pointer;'/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray3));
							object[] languageConversion4 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img title='", _languageClass.GetLanguageConversion("Delete"), "' src='../images/delete.gif' style='cursor:pointer;' onclick=\"deleteAll_Note('", num2, "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(languageConversion4));
							object[] objArray4 = new object[] { "<span id='ShowAttachIcon' style='display:none; margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray4));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
						num1++;
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