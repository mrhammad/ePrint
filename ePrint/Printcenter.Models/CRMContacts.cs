using nmsConnectionClass;
using nmsLanguage;
using System.Configuration;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class CRMContacts
{
	public CRMContacts()
	{
	}

	public static string ReturnContacts(string ClientID, int NotespageNummber)
	{
		int notespageNummber = 5 * NotespageNummber;
		languageClass _languageClass = new languageClass();
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		string str = string.Empty;
		string empty1 = string.Empty;
		if (ConnectionClass.FileExtension != null)
		{
			empty1 = ConnectionClass.FileExtension.ToString();
		}
		string reqHost = string.Empty;
		if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Request.Url != null)
		{
			reqHost = HttpContext.Current.Request.Url.Host.Trim().ToLower();
		}
		if (reqHost == "localhost" || reqHost == "127.0.0.1" || reqHost == "192.168.1.6")
		{
			string localB2b = ConfigurationManager.AppSettings["LocalB2BURL"];
			string localB2c = ConfigurationManager.AppSettings["LocalB2CURL"];
			string b2bBase = !string.IsNullOrWhiteSpace(localB2b) ? localB2b.Trim() : "http://localhost:2222/";
			string b2cBase = !string.IsNullOrWhiteSpace(localB2c) ? localB2c.Trim() : "http://localhost:2222/";
			empty = string.Concat(b2bBase, "login", empty1);
			str = string.Concat(b2cBase, "login", empty1);
		}
		else
		{
			if (ConnectionClass.B2BURL != null)
			{
				empty = ConnectionClass.B2BURL.ToString();
				empty = string.Concat(empty, "login", empty1);
			}
			if (ConnectionClass.B2CURL != null)
			{
				str = ConnectionClass.B2CURL.ToString();
				str = string.Concat(str, "login", empty1);
			}
		}
		Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			DataSet dataSet = DepartmentBaseClass.CRM_Select_TopFiveContact((long)Convert.ToInt32(ClientID));
			DataTable dataTable = dataSet.Tables[0].Rows.Cast<DataRow>().Take<DataRow>(notespageNummber).CopyToDataTable<DataRow>();
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append("<div style='margin-left: 1px; margin-bottom:5px;'>");
				stringBuilder.Append(string.Concat("<span Class='NotesSumm' style='font-weight:bold;'>", _languageClass.GetLanguageConversion("Contacts"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("<table id='tbOpenActivities' style='border: 0px solid red; width:97.5%' cellpadding='0' cellspacing='0'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:6%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black; margin-left:5px; font-weight:bold;'>", _languageClass.GetLanguageConversion("Action"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:7%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Default"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:18%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black; margin-left:5px; font-weight:bold;'>", _languageClass.GetLanguageConversion("Contact_Name"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:15%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Department"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:26%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Email"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:15%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Personal_Phone"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td class='bgcustomizeNew' style='width:15%;'>");
				stringBuilder.Append("<div style='margin-top:0px;'>");
				stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Approver"), "</span>"));
				stringBuilder.Append("</div>");
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td colspan='7' style='width:6%;'>");
						stringBuilder.Append("<table class='rowmousehover' style='width:100%'  cellpadding='0' cellspacing='0'>");
						stringBuilder.Append("<tr>");
						stringBuilder.Append("<td  style='width:6%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						string[] strArrays = new string[] { "<span id='ShowAttachIcon'><a href='javascript://'><img Class='rollover' src='../images/key.gif' class='rollover' onclick=\"postwith('", baseClass.SpecialEncode(row["IsFromWebStore"].ToString()), "',{b2bemail:'", baseClass.SpecialEncode(row["Email"].ToString()), "',b2bpwd:'", row["Password"].ToString(), "',id:'", row["AccountID"].ToString(), "',from:'MIS'},'", empty, "','", str, "')\"/> </a></span>" };
						stringBuilder.Append(string.Concat(strArrays));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:7%;'>");
						stringBuilder.Append("<div style='margin-left:13px;'>");
						if (row["Defaultcontact"].ToString().ToLower() != "true")
						{
							object[] item = new object[] { "<span id='ShowAttachIcon'><a href='javascript://'><img Class='rollover' src='../images/ICON_checkbox_u.gif' class='rollover' onclick=\"SetDefaultContact('", row["CompanyID"], "','", row["clientID"].ToString(), "','", row["ContactID"].ToString(), "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(item));
						}
						else
						{
							object[] objArray = new object[] { "<span id='ShowAttachIcon'><a href='javascript://'><img Class='rollover' src='../images/ICON_checkboxNew.gif' class='rollover' onclick=\"SetDefaultContact('", row["CompanyID"], "','", row["clientID"].ToString(), "','", row["ContactID"].ToString(), "');return false;\"/> </a></span>" };
							stringBuilder.Append(string.Concat(objArray));
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:18%;'>");
						stringBuilder.Append("<div style='margin-left:5px;'>");
						stringBuilder.Append(string.Concat("<span>", row["ContactName"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:15%;'>");
						stringBuilder.Append("<div style='margin-top:0px;'>");
						stringBuilder.Append(string.Concat("<span>", row["Department"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:26%;'>");
						stringBuilder.Append("<div style='margin-top:0px;'>");
						stringBuilder.Append(string.Concat("<span>", row["Email"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:15%;'>");
						stringBuilder.Append("<div style='margin-top:0px;'>");
						stringBuilder.Append(string.Concat("<span>", row["PersonalPhone"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td style='width:15%;'>");
						stringBuilder.Append("<div>");
						stringBuilder.Append(string.Concat("<span>", row["ApproverType"].ToString(), "</span>"));
						stringBuilder.Append("</div>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
					}
				}
				stringBuilder.Append("</table>");
				if (dataSet.Tables[0].Rows.Count <= 5 || dataSet.Tables[0].Rows.Count <= dataTable.Rows.Count)
				{
					stringBuilder.Append("<div align='center' style='margin-left: 1px; height:25px; margin-bottom:4px; margin-top:6px;'>");
					stringBuilder.Append("<span ID='DivHideMoreContactNew' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadHideContactByJson();return false;\" title='Hide More' alt='Hide More' src='' style='cursor:pointer;'/> </a></span>");
					stringBuilder.Append("</div>");
				}
				else
				{
					stringBuilder.Append("<div align='center' style='margin-left: 1px; margin-top: 6px; margin-bottom:4px;'>");
					stringBuilder.Append("<table>");
					stringBuilder.Append("<tr>");
					stringBuilder.Append("<td>");
					stringBuilder.Append(string.Concat("<span ID='DivShowMoreContact' style='margin-left:10px;display:block;'><a onclick='javascript:LoadMoreContactByJson();return false;'style='cursor:pointer;'>", _languageClass.GetLanguageConversion("Show_More"), "  </a></span>"));
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td>");
					stringBuilder.Append("<span ID='DivShowAllContact' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadMoreNotesByJsonss();return false;\" title='Show All' alt='Show All' src='' style='cursor:pointer;'/> </a></span>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td>");
					stringBuilder.Append("<span ID='DivHideMoreContactNew' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"LoadHideContactByJson();return false;\" title='Hide More' alt='Hide More' src='' style='cursor:pointer;'/> </a></span>");
					stringBuilder.Append("</td>");
					stringBuilder.Append("</tr>");
					stringBuilder.Append("</table>");
					stringBuilder.Append("</div>");
				}
			}
		}
		catch
		{
		}
		return stringBuilder.ToString();
	}
}