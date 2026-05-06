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
using System.Web.UI.WebControls;

public class CRMNotes
{
	public CRMNotes()
	{
	}

	public static string ReturnNotes(string CompanyID, string SectionID, int NotespageNummber)
	{
		int notespageNummber = 5 * NotespageNummber;
		languageClass _languageClass = new languageClass();
		StringBuilder stringBuilder = new StringBuilder();
		DataSet dataSet = DepartmentBaseClass.CRM_Select_TopFiveNotes(Convert.ToInt32(CompanyID), Convert.ToInt32(SectionID));
		BaseClass baseClass = new BaseClass();
		string str = global.strimagepath;
		DataTable item = dataSet.Tables[0];
		int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		int num1 = 0;
		stringBuilder.Append("<div style='margin-left: 1px; margin-bottom:5px;'>");
		stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Account_Notes"), "</span>"));
		IEnumerator enumerator = item.Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow current = (DataRow)enumerator.Current;
				stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;margin-left:5px;'>(", current["NoOFAttachment"].ToString(), ")</span>"));
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
		string[] languageConversion = new string[] { "<span id='Plus' style='padding-left:5px;cursor:pointer;><a href='javascript://'><img id='AddMewNote' onclick=\"OpenAddNotePopup(this.id);\" title='", _languageClass.GetLanguageConversion("Add_Note"), "' src='", str, "plus.gif' style='cursor:pointer;margin-bottom:-3px;'/> </a></span>" };
		stringBuilder.Append(string.Concat(languageConversion));
		stringBuilder.Append("</div>");
		stringBuilder.Append("<table style='border: 0px solid red; width:97.6%;' cellpadding='0' cellspacing='0'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:13.8%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;margin-left:5px'>", _languageClass.GetLanguageConversion("Note_Title"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:19%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Note_Content"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:11.5%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Created_By"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:37%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Specific_to_Contact"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:11%;'>");
		stringBuilder.Append("<div style='margin-top:0px;'>");
		stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Date"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("<td class='bgcustomizeNew' style='width:6.4%;'>");
		stringBuilder.Append("<div style='margin-right:5px;float:right;'>");
		stringBuilder.Append(string.Concat("<span style='color:black; margin-left:0px; font-weight:bold;'>", _languageClass.GetLanguageConversion("Action"), "</span>"));
		stringBuilder.Append("</div>");
		stringBuilder.Append("</td>");
		stringBuilder.Append("</tr>");
		try
		{
			DataTable dataTable = dataSet.Tables[0].Rows.Cast<DataRow>().Take<DataRow>(notespageNummber).CopyToDataTable<DataRow>();
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					commonClass _commonClass = new commonClass();
					string str1 = _commonClass.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(row["createDate"].ToString(), Convert.ToInt32(CompanyID), num, true);
					string[] strArrays = str1.ToString().Split(new char[] { ' ' });
					string empty = string.Empty;
					int num2 = Convert.ToInt32(row["attachmentId"].ToString());
					DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='6'>");
					stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
					stringBuilder.Append("<tr>");
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<td style='width:13%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://' img onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\" src=''>"));
					}
					else
					{
						stringBuilder.Append(string.Concat("<td style='width:13%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;''href='javascript://' img onclick=\"Notes_details('", num2, "');return false;\" src=''>"));
					}
					stringBuilder.Append("<div style='margin-left:5px;width:100%;'>");
					if (row["title"].ToString() == "")
					{
						string[] strArrays1 = new string[] { "<span title ='", baseClass.SpecialDecode(row["title"].ToString()).Replace("'", "`"), "'>", _languageClass.GetLanguageConversion("untitled"), "</span>" };
						stringBuilder.Append(string.Concat(strArrays1));
					}
					else
					{
						string[] strArrays2 = new string[] { "<span title ='", baseClass.SpecialDecode(row["title"].ToString()).Replace("'", "`"), "'>", baseClass.SpecialDecode(row["title"].ToString()), "</span>" };
						stringBuilder.Append(string.Concat(strArrays2));
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					int num3 = 0;
					Label label = new Label()
					{
						ID = string.Concat("lbl_notes_", num3 + 1),
						Text = row["subject"].ToString().Replace(Environment.NewLine, "~±")
					};
					string[] strArrays3 = label.Text.Split(new char[] { '~' });
					label.Text = baseClass.SpecialDecode(strArrays3[0].Replace("\n", "<br/>"));
					baseClass.SpecialDecode(row["subject"].ToString());
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<td style='width:18.8%;white-space:nowrap;overflow:hidden;max-width:0;padding-left:0.8%;cursor:pointer;''href='javascript://' img onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\" src=''>"));
					}
					else
					{
						stringBuilder.Append(string.Concat("<td style='width:18.8%;white-space:nowrap;overflow:hidden;max-width:0;padding-left:0.8%;cursor:pointer;''href='javascript://' img onclick=\"Notes_details('", num2, "');return false;\" src=''>"));
					}
					stringBuilder.Append("<div style='padding-right:20px;' class='tooltip'>");
					string[] strArrays4 = new string[] { "<span ><a style='color:black;text-decoration: none;cursor:pointer;' href='javascript:void(0);' class='crmtooltip' title ='", baseClass.SpecialEncode(label.Text), "'>", baseClass.SpecialDecode(row["subject"].ToString()), "</a></span>" };
					stringBuilder.Append(string.Concat(strArrays4));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<td style='width:11.5%;padding-left:1%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' img onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\" src=''>"));
					}
					else
					{
						stringBuilder.Append(string.Concat("<td style='width:11.5%;padding-left:1%;white-space:nowrap;overflow:hidden;max-width:0;cursor:pointer;'href='javascript://' img onclick=\"Notes_details('", num2, "');return false;\" src=''>"));
					}
					stringBuilder.Append("<div style='margin-left:0px;'>");
					string[] strArrays5 = new string[] { "<span style='width:20%'; title ='", baseClass.SpecialDecode(row["UserName"].ToString()).Replace("'", "`"), "'>", baseClass.SpecialDecode(row["UserName"].ToString()), "</span>" };
					stringBuilder.Append(string.Concat(strArrays5));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<td style='width:38%;padding-left:1%;cursor:pointer;''href='javascript://' img onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\" src=''>"));
					}
					else
					{
						stringBuilder.Append(string.Concat("<td style='width:38%;padding-left:1%;cursor:pointer;''href='javascript://' img onclick=\"Notes_details('", num2, "');return false;\" src=''>"));
					}
					stringBuilder.Append("<div style='margin-left:0px;'>");
					string[] strArrays6 = new string[] { "<span title ='", baseClass.SpecialDecode(row["SpecificName"].ToString()).Replace("'", "`"), "'>", baseClass.SpecialDecode(row["SpecificName"].ToString()), "</span>" };
					stringBuilder.Append(string.Concat(strArrays6));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append(string.Concat("<td style='width:11%;cursor:pointer;''href='javascript://' img onclick=\"Notes_detailsWithOutFile('", num2, "');return false;\" src=''>"));
					}
					else
					{
						stringBuilder.Append(string.Concat("<td style='width:11%;cursor:pointer;''href='javascript://' img onclick=\"Notes_details('", num2, "');return false;\" src=''>"));
					}
					stringBuilder.Append("<div style='margin-left:0px;'>");
					stringBuilder.Append(string.Concat("<span>", strArrays[0], "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td style='width:6.4%;'>");
					stringBuilder.Append("<div style='margin-right:5px;float:right;'>");
					if (row["filename"].ToString() != "")
					{
						object[] objArray = new object[] { "<span id='ShowAttachIcon' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(objArray));
						object[] languageConversion1 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img title='", _languageClass.GetLanguageConversion("Delete"), "' src='../images/delete.gif' style='cursor:pointer;' onclick=\"delete_note('", num2, "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion1));
					}
					else
					{
						object[] objArray1 = new object[] { "<span id='ShowAttachIcon' style='display:none; margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(objArray1));
						object[] languageConversion2 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:10px;float:left;margin-top:3px;'><a href='javascript://'><img title='", _languageClass.GetLanguageConversion("Delete"), "' src='../images/delete.gif' style='cursor:pointer;' onclick=\"delete_note('", num2, "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion2));
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
			if (dataSet.Tables[0].Rows.Count <= 5 || dataSet.Tables[0].Rows.Count <= dataTable.Rows.Count)
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px;margin-top: 6px; margin-bottom:4px;'>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreNotes' style='margin-left:10px;display:none;'><a onclick='javascript:HideMoreNotesByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
				stringBuilder.Append("</div>");
			}
			else
			{
				stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 5px; margin-bottom:4px;'>");
				stringBuilder.Append("<table>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivShowMoreNotes' style='margin-left:10px;display:block; float:left;'><a onclick='javascript:LoadMoreNotesByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Show_More"), "  </a></span>"));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				if (dataTable.Rows.Count <= 0)
				{
					object[] objArray2 = new object[] { "<span ID='DivShowAllNotes' style='margin-left:10px;display:none; float:left;'><a href='javascript://' style='cursor:pointer;color:#10357f;' onclick=\"LoadAllNotesByJson(this.id,'", 0, "');return false;\"/>", _languageClass.GetLanguageConversion("Show_All"), "  </a></span>" };
					stringBuilder.Append(string.Concat(objArray2));
				}
				else
				{
					foreach (DataRow dataRow in dataTable.Rows)
					{
						string[] str2 = new string[] { "<span ID='DivShowAllNotes' style='margin-left:10px;display:none;float:left;'><a id='imgshowallnotes' href='javascript://' style='cursor:pointer;color:#10357f;' onclick=\"LoadAllNotesByJson(this.id,'", dataRow["NoOFAttachment"].ToString(), "');return false;\"/>", _languageClass.GetLanguageConversion("Show_All"), "  </a></span>" };
						stringBuilder.Append(string.Concat(str2));
					}
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(string.Concat("<span ID='DivHideMoreNotes' style='margin-left:10px;display:none;float:left;'><a onclick='javascript:HideMoreNotesByJson();return false;'style='cursor:pointer;color:#10357f'>", _languageClass.GetLanguageConversion("Hide_More"), "  </a></span>"));
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
			stringBuilder.Append("<td colspan='6'>");
			stringBuilder.Append("<table ID='NoRecord' class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
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
			stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px;margin-top: 6px; margin-bottom:4px;'>");
			stringBuilder.Append("</div>");
		}
		return stringBuilder.ToString();
	}
}