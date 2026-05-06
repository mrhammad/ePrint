using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public class CRMNotesPrint
{
	public CRMNotesPrint()
	{
	}

	public static string ReturnNotesPrint(string CompanyID, string SectionID)
	{
		languageClass _languageClass = new languageClass();
		StringBuilder stringBuilder = new StringBuilder();
		DataSet dataSet = DepartmentBaseClass.CRM_Select_TopFiveNotes(Convert.ToInt32(CompanyID), Convert.ToInt32(SectionID));
		try
		{
			if (dataSet.Tables.Count > 0)
			{
				int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
				int num1 = 0;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					BaseClass baseClass = new BaseClass();
					commonClass _commonClass = new commonClass();
					string str = _commonClass.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(row["createDate"].ToString(), Convert.ToInt32(CompanyID), num, false);
					string empty = string.Empty;
					int num2 = Convert.ToInt32(row["attachmentId"].ToString());
					DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
					stringBuilder.Append("<div style='width:800px; border-bottom:1px solid #EFEFEF;'>");
					stringBuilder.Append("<table>");
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='6' style='margin-top:8px; width:800px'>");
					stringBuilder.Append("<div style='float:left;'>");
					stringBuilder.Append(string.Concat("<span style='font-weight:bold;'>", baseClass.SpecialDecode(row["title"].ToString()), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("<tr>");
					int num3 = 0;
					Label label = new Label()
					{
						ID = string.Concat("lbl_notes_", num3 + 1),
						Text = row["subject"].ToString().Replace(Environment.NewLine, "~±")
					};
					string[] strArrays = label.Text.Split(new char[] { '~' });
					string empty1 = string.Empty;
					if ((int)strArrays.Length > 0)
					{
						for (int i = 0; i < (int)strArrays.Length; i++)
						{
							empty1 = string.Concat(empty1, baseClass.InsertAtIntervals(strArrays[i], 180, "<br/>"));
						}
					}
					label.Text = baseClass.SpecialDecode(empty1.Replace("\n", "<br/>"));
					if (row["title"].ToString() == "")
					{
						stringBuilder.Append("<td colspan='6' style='margin-top:-7px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span>", HttpUtility.HtmlDecode(label.Text), "</span>"));
						stringBuilder.Append("<div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td colspan='6'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span>", HttpUtility.HtmlDecode(label.Text), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("</tr>");
					stringBuilder.Append("<tr>");
					if (row["filename"].ToString() != "")
					{
						stringBuilder.Append("<td style='margin-bottom:7px;margin-top:-2px; width:20px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						object[] languageConversion = new object[] { "<span><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td style='height:18px;display:none'>");
						stringBuilder.Append("<div style='float:left; width:20px; '>");
						object[] objArray = new object[] { "<span><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFiles('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(objArray));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append("<td style='margin-bottom:7px;height:18px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='color:#4D77E8;font-size:10px;'>", baseClass.SpecialDecode(row["UserName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='margin-left:10px; color: gray;font-size:10px;'>", str, "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td style='margin-bottom:7px;height:18px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='color:#4D77E8; font-size:10px;'>", baseClass.SpecialDecode(row["UserName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='margin-left:10px; color: gray;font-size:10px;'>", str, "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("<td>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td>");
					stringBuilder.Append("<div style='float:right;'>");
					object[] objArray1 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:5px; display:none'><a href='javascript://'><img title='Delete Note' src='../images/delete.gif' style='cursor:pointer;' onclick=\"delete_note('", num2, "');return false;\"/> </a></span>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("</div>");
					stringBuilder.Append("<div style='float:right;'>");
					stringBuilder.Append(string.Concat("<span id='Seprator_", num1, "' style='display:none;'>&nbsp;</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("<div style='float:right;'>");
					object[] objArray2 = new object[] { "<span id='EditNotes_", num1, "' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"Edit_notes('", num2, "');return false;\" title='Edit Note' src='../images/Edit.gif' style='cursor:pointer;'/> </a></span>" };
					stringBuilder.Append(string.Concat(objArray2));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td style='float:right; display:none;'>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td style='float:right'>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("</table>");
					stringBuilder.Append("</div>");
					num1++;
				}
			}
		}
		catch
		{
		}
		return stringBuilder.ToString();
	}
}