using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMContactNotes
{
	public CRMContactNotes()
	{
	}

	public static string ReturnContactNotes(string ContactID)
	{
		languageClass _languageClass = new languageClass();
		StringBuilder stringBuilder = new StringBuilder();
		DataSet dataSet = DepartmentBaseClass.CRM_Select_Contact_Notes(Convert.ToInt32(ContactID));
		try
		{
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				stringBuilder.Append("<div style='float:left;'>");
				stringBuilder.Append(string.Concat("<span style='font-weight:bold; margin-left:10px;'>", _languageClass.GetLanguageConversion("No_Notes_Found"), "</span>"));
				stringBuilder.Append("</div>");
			}
			else
			{
				int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
				int num1 = 0;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					commonClass _commonClass = new commonClass();
					string str = _commonClass.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(row["createDate"].ToString(), Convert.ToInt32(HttpContext.Current.Session["CompanyID"]), num, false);
					string empty = string.Empty;
					int num2 = Convert.ToInt32(row["attachmentId"].ToString());
					DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
					object[] objArray = new object[] { "<div style='width:750px; border-bottom:1px solid #EFEFEF; margin-left:7px;' class='Hovertable' onmouseover='javascript:ShowEditDeleteButton(", num1, "); return false;' onmouseout='javascript:HideEditDeleteButton(", num1, "); return false;'>" };
					stringBuilder.Append(string.Concat(objArray));
					stringBuilder.Append("<table>");
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td colspan='6' style='margin-top:8px;'>");
					stringBuilder.Append("<div style='float:left;'>");
					stringBuilder.Append(string.Concat("<span style='font-weight:bold;'>", row["title"].ToString(), "</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("<tr>");
					if (row["title"].ToString() == "")
					{
						stringBuilder.Append("<td colspan='6' style='margin-top:-7px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='line-height:17px;'>", row["subject"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td colspan='6'>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='line-height:17px;'>", row["subject"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					stringBuilder.Append("</tr>");
					stringBuilder.Append("<tr>");
					if (row["filename"].ToString() != "")
					{
						stringBuilder.Append("<td style='margin-bottom:7px;margin-top:-2px; width:20px;'>");
						stringBuilder.Append("<div style='float:left;'>");
						object[] languageConversion = new object[] { "<span><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFilesNew('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td style='width:5px;'>");
						stringBuilder.Append("<div style='float:left; height:17px;'>");
						object[] languageConversion1 = new object[] { "<span id='ShowAttachIcon' style='display:none;'><a href='javascript://'><img src='../images/Attachment.png' title='", _languageClass.GetLanguageConversion("View_Attached_File"), "' style='cursor:pointer;' onclick=\"ViewAttachedFilesNew('", num2, "','", row["CompanyId"], "');return false;\"/> </a></span>" };
						stringBuilder.Append(string.Concat(languageConversion1));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					BaseClass baseClass = new BaseClass();
					if (row["filename"].ToString() == "")
					{
						stringBuilder.Append("<td >");
						stringBuilder.Append("<div id='DivUserNameNew' style='float:left; margin-left:-9px;'>");
						stringBuilder.Append(string.Concat("<span style='color:#4D77E8;font-size:10px;'>", baseClass.SpecialDecode(row["UserName"].ToString()), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("<div style='float:left;'>");
						stringBuilder.Append(string.Concat("<span style='margin-left:10px; color: gray;font-size:10px;'>", str, "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
					}
					else
					{
						stringBuilder.Append("<td >");
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
					object[] objArray1 = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:8px; display:none'><a href='javascript://'><img title='", _languageClass.GetLanguageConversion("Delete"), "' src='../images/delete.gif' style='cursor:pointer;' onclick=\"delete_Contactnote('", num2, "','", row["ContactID"], "');return false;\"/> </a></span>" };
					stringBuilder.Append(string.Concat(objArray1));
					stringBuilder.Append("</div>");
					stringBuilder.Append("<div style='float:right;'>");
					stringBuilder.Append(string.Concat("<span id='Seprator_", num1, "' style='display:none;'>&nbsp;</span>"));
					stringBuilder.Append("</div>");
					stringBuilder.Append("<div style='float:right;'>");
					object[] item = new object[] { "<span id='EditNotes_", num1, "' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"Edit_Contactnotes('", num2, "','", row["ContactID"], "');return false;\" title='", _languageClass.GetLanguageConversion("Edit"), "' src='../images/Edit.gif' style='cursor:pointer;'/> </a></span>" };
					stringBuilder.Append(string.Concat(item));
					stringBuilder.Append("</div>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td style='display:none;'>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td>");
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