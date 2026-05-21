using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCommon
{
	public class BasePage : System.Web.UI.Page
	{
		public int companyID;

		public languageClass objLangClass = new languageClass();

		public string pg = "";

		public string BaseCompanyType = string.Empty;

		protected Random rGen;

		protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

		public BasePage()
		{
		}

		public void changeGridColor(GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				if (e.Row.RowState == DataControlRowState.Alternate)
				{
					e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFF99';");
					e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#DDDDDD';");
					return;
				}
				e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFF99';");
				e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF';");
			}
		}

		public string CheckPageName(string pgname, string type)
		{
			pgname = pgname.Trim().ToLower();
			string empty = string.Empty;
			string str = string.Empty;
			if (pgname == "moretabs")
			{
				empty = "white";
				str = "#8A8A75";
			}
			else if (pgname == "admin")
			{
				empty = "white";
				str = "#636d89";
			}
			if (type == "forecolor")
			{
				return empty;
			}
			return str;
		}

		public string colorCode(int companyId, string pg)
		{
			if (pg == "welcome")
			{
				pg = "home";
			}
			string empty = string.Empty;
			int num = Convert.ToInt32(this.Session["companyid"]);
			if (pg != null)
			{
				if (pg.ToLower() == "home" || pg.ToLower() == "campaign" || pg.ToLower() == "forecast" || pg.ToLower() == "dashboard" || pg.ToLower() == "inventory" || pg.ToLower() == "warehouse" || pg.ToLower() == "deliverynote" || pg.ToLower() == "welcome" || pg.ToLower() == "webstoreorder" || pg.ToLower() == "digitalasset" || pg.ToLower() == "productcatalogue")
				{
					pg = pg ?? "";
				}
				else if(pg.ToLower() == "proofs")
				{
					pg = pg ?? "";
				}
				else
				{
					pg = string.Concat(pg, "s");
				}
				empty = this.CheckPageName(pg, "bgcolor");
				DataTable dataTable = new DataTable();
				if (this.Session[string.Concat("TabColours", num)] != null)
				{
					dataTable = (DataTable)this.Session[string.Concat("TabColours", num)];
				}
				else if (string.IsNullOrEmpty(empty))
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand("crm_common_select_navigationcolor", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
                    sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                    sqlCommand.Parameters.AddWithValue("@pg", pg);
					sqlCommand.Parameters.AddWithValue("@companyID", num);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					dataTable.Load(sqlDataReader);
					this.Session[string.Concat("TabColours", num)] = dataTable;
					sqlDataReader.Close();
					_commonClass.closeConnection();
				}
				foreach (DataRow row in dataTable.Rows)
				{
					if (row["headername"].ToString() != pg.ToLower())
					{
						continue;
					}
					empty = row["colorcode"].ToString();
				}
			}
			return empty;
		}

		public void commonSectionHeader(PlaceHolder plhHeader, string sectionname, string subsectionname, string thissectionname, string ss1, string ss2, string ss3, string ss4, string ss5, string ss6, string ss7, string ss8, string ss9, string ss10, string link1, string link2, string link3, string link4, string link5, string link6, string link7, string link8, string link9, string link10)
		{
			BaseClass baseClass = new BaseClass();
			languageClass _languageClass = new languageClass();
			plhHeader.Controls.Add(new LiteralControl("<table cellspacing=0 cellpadding=0 width=100% border=0><tr>"));
			plhHeader.Controls.Add(new LiteralControl("<td>"));
			plhHeader.Controls.Add(new LiteralControl("<table cellspacing=0 cellpadding=0 width=100% border=0><tr>"));
			if (sectionname == "Day")
			{
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=left valign=top class=bgcustomize><img src='", global.imagePath(), "lt_tabnotch.gif' width=5 height=5></td>")));
				plhHeader.Controls.Add(new LiteralControl("<td nowrap=nowrap width=98%  class=bgcustomize height=23px><a href='#' class=subnavigator>Day View&nbsp;<a/>"));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=right valign=top class=bgcustomize><img src='", global.imagePath(), "rt_tabnotch.gif' width=5 height=5></td>")));
			}
			if (sectionname == "Week")
			{
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=left valign=top class=bgcustomize><img src='", global.imagePath(), "lt_tabnotch.gif' width=5 height=5></td>")));
				plhHeader.Controls.Add(new LiteralControl("<td nowrap=nowrap width=98% class=bgcustomize height=23px><a href='#' class=subnavigator>Week View&nbsp;<a/>"));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=right valign=top class=bgcustomize><img src='", global.imagePath(), "rt_tabnotch.gif' width=5 height=5></td>")));
			}
			if (sectionname == "Month")
			{
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=left valign=top class=bgcustomize><img src='", global.imagePath(), "lt_tabnotch.gif' width=5 height=5></td>")));
				plhHeader.Controls.Add(new LiteralControl("<td nowrap=nowrap width=98% class=bgcustomize height=23px><a href='#' class=subnavigator>Month View&nbsp;<a/>"));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=right valign=top class=bgcustomize><img src='", global.imagePath(), "rt_tabnotch.gif' width=5 height=5></td>")));
			}
			if (sectionname == "All View")
			{
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=left valign=top class=bgcustomize><img src='", global.imagePath(), "lt_tabnotch.gif' width=5 height=5></td>")));
				plhHeader.Controls.Add(new LiteralControl("<td nowrap=nowrap width=98% class=bgcustomize height=23px><a href='#' class=subnavigator>Activity All View&nbsp;<a/>"));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=1% align=right valign=top class=bgcustomize><img src='", global.imagePath(), "rt_tabnotch.gif' width=5 height=5></td>")));
			}
			if (sectionname == "Lead")
			{
				ControlCollection controls = plhHeader.Controls;
				string[] strArrays = new string[] { "<td nowrap=nowrap width=100% class=bgcustomize height=23px ><a href='", link1, "' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("LEADS", 1, "p"), "&nbsp;<a/>" };
				controls.Add(new LiteralControl(string.Concat(strArrays)));
				ControlCollection controlCollections = plhHeader.Controls;
				string[] strArrays1 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", link2, "' class=subnavigator>Add a New ", baseClass.ReturnScreenName("LEADS", 2, "p"), " &nbsp;&nbsp;</a>" };
				controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
				ControlCollection controls1 = plhHeader.Controls;
				string[] strArrays2 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "lead/lead_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("LEADS", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controls1.Add(new LiteralControl(string.Concat(strArrays2)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controlCollections1 = plhHeader.Controls;
					string[] strArrays3 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "lead/lead_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controlCollections1.Add(new LiteralControl(string.Concat(strArrays3)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Contact")
			{
				ControlCollection controls2 = plhHeader.Controls;
				string[] strArrays4 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "contact/contact_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("CONTACTS", 1, "p"), "&nbsp;<a/>" };
				controls2.Add(new LiteralControl(string.Concat(strArrays4)));
				ControlCollection controlCollections2 = plhHeader.Controls;
				string[] strArrays5 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "contact/contact_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("CONTACTS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controlCollections2.Add(new LiteralControl(string.Concat(strArrays5)));
				ControlCollection controls3 = plhHeader.Controls;
				string[] strArrays6 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "contact/contact_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("CONTACTS", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controls3.Add(new LiteralControl(string.Concat(strArrays6)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controlCollections3 = plhHeader.Controls;
					string[] strArrays7 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "contact/contact_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controlCollections3.Add(new LiteralControl(string.Concat(strArrays7)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Contract")
			{
				ControlCollection controls4 = plhHeader.Controls;
				string[] strArrays8 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "contract/contract_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("CONTRACTS", 1, "p"), "&nbsp;<a/>" };
				controls4.Add(new LiteralControl(string.Concat(strArrays8)));
				ControlCollection controlCollections4 = plhHeader.Controls;
				string[] strArrays9 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "contract/contract_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("CONTRACTS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controlCollections4.Add(new LiteralControl(string.Concat(strArrays9)));
				ControlCollection controls5 = plhHeader.Controls;
				string[] strArrays10 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "contract/contract_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("CONTRACTS", 2, "p"), " View</a>" };
				controls5.Add(new LiteralControl(string.Concat(strArrays10)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Product")
			{
				ControlCollection controlCollections5 = plhHeader.Controls;
				string[] strArrays11 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize><a href='", global.sitePath(), "product/product_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("PRODUCTS", 1, "p"), "&nbsp;<a/>" };
				controlCollections5.Add(new LiteralControl(string.Concat(strArrays11)));
				ControlCollection controls6 = plhHeader.Controls;
				string[] strArrays12 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "product/product_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("PRODUCTS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls6.Add(new LiteralControl(string.Concat(strArrays12)));
				ControlCollection controlCollections6 = plhHeader.Controls;
				string[] strArrays13 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "product/product_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("PRODUCTS", 2, "p"), " View</a>" };
				controlCollections6.Add(new LiteralControl(string.Concat(strArrays13)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Price")
			{
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=5 align=left valign=top class=bgcustomize><img src='", global.imagePath(), "lt_tabnotch.gif' width=5 height=5></td>")));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td nowrap=nowrap width=99% class=bgcustomize height=23 style=background-repeat:repeat-x><a href='", global.sitePath(), "product/price_view.aspx' class=subnavigator>View Prices&nbsp;<a/>")));
				plhHeader.Controls.Add(new LiteralControl(string.Concat(" <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "product/price_add.aspx' class=subnavigator>Add a New Price&nbsp;&nbsp;</a>")));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "product/price_createview.aspx' class=subnavigator>Create a New Price View</a>")));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
				plhHeader.Controls.Add(new LiteralControl(string.Concat("<td width=5 align=right class=bgcustomize valign=top><img src='", global.imagePath(), "rt_tabnotch.gif' width=5 height=5></td>")));
			}
			if (sectionname == "Asset")
			{
				ControlCollection controls7 = plhHeader.Controls;
				string[] strArrays14 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize><a href='", global.sitePath(), "asset/asset_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("ASSETS", 1, "p"), "&nbsp;<a/>" };
				controls7.Add(new LiteralControl(string.Concat(strArrays14)));
				ControlCollection controlCollections7 = plhHeader.Controls;
				string[] strArrays15 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "asset/asset_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("ASSETS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controlCollections7.Add(new LiteralControl(string.Concat(strArrays15)));
				ControlCollection controls8 = plhHeader.Controls;
				string[] strArrays16 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "asset/asset_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("ASSETS", 2, "p"), " View</a>" };
				controls8.Add(new LiteralControl(string.Concat(strArrays16)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Opportunity")
			{
				ControlCollection controlCollections8 = plhHeader.Controls;
				string[] strArrays17 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "opportunity/opportunity_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("OPPORTUNITIES", 1, "p"), "&nbsp;<a/>" };
				controlCollections8.Add(new LiteralControl(string.Concat(strArrays17)));
				ControlCollection controls9 = plhHeader.Controls;
				string[] strArrays18 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "opportunity/opportunity_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("OPPORTUNITIES", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls9.Add(new LiteralControl(string.Concat(strArrays18)));
				ControlCollection controlCollections9 = plhHeader.Controls;
				string[] strArrays19 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "opportunity/opportunity_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("OPPORTUNITIES", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controlCollections9.Add(new LiteralControl(string.Concat(strArrays19)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controls10 = plhHeader.Controls;
					string[] strArrays20 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "opportunity/opportunity_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controls10.Add(new LiteralControl(string.Concat(strArrays20)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Ticket")
			{
				ControlCollection controlCollections10 = plhHeader.Controls;
				string[] strArrays21 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "ticket/ticket_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("TICKETS", 1, "p"), "&nbsp;<a/>" };
				controlCollections10.Add(new LiteralControl(string.Concat(strArrays21)));
				ControlCollection controls11 = plhHeader.Controls;
				string[] strArrays22 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "ticket/ticket_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("TICKETS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls11.Add(new LiteralControl(string.Concat(strArrays22)));
				ControlCollection controlCollections11 = plhHeader.Controls;
				string[] strArrays23 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "ticket/ticket_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("TICKETS", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controlCollections11.Add(new LiteralControl(string.Concat(strArrays23)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controls12 = plhHeader.Controls;
					string[] strArrays24 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "ticket/ticket_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controls12.Add(new LiteralControl(string.Concat(strArrays24)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Campaign")
			{
				ControlCollection controlCollections12 = plhHeader.Controls;
				string[] strArrays25 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "Campaign/Campaign_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("CAMPAIGN", 1, "p"), "&nbsp;<a/>" };
				controlCollections12.Add(new LiteralControl(string.Concat(strArrays25)));
				ControlCollection controls13 = plhHeader.Controls;
				string[] strArrays26 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "Campaign/Campaign_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("CAMPAIGN", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls13.Add(new LiteralControl(string.Concat(strArrays26)));
				ControlCollection controlCollections13 = plhHeader.Controls;
				string[] strArrays27 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "Campaign/Campaign_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("CAMPAIGN", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controlCollections13.Add(new LiteralControl(string.Concat(strArrays27)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controls14 = plhHeader.Controls;
					string[] strArrays28 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "campaign/campaign_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controls14.Add(new LiteralControl(string.Concat(strArrays28)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Solution")
			{
				ControlCollection controlCollections14 = plhHeader.Controls;
				string[] strArrays29 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "Solution/Solution_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("SOLUTIONS", 1, "p"), "&nbsp;<a/>" };
				controlCollections14.Add(new LiteralControl(string.Concat(strArrays29)));
				ControlCollection controls15 = plhHeader.Controls;
				string[] strArrays30 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "Solution/Solution_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("SOLUTIONS", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls15.Add(new LiteralControl(string.Concat(strArrays30)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controlCollections15 = plhHeader.Controls;
					string[] strArrays31 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "Solution/solution_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controlCollections15.Add(new LiteralControl(string.Concat(strArrays31)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Document")
			{
				ControlCollection controls16 = plhHeader.Controls;
				string[] strArrays32 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "Documents/Document.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("DOCUMENTS", 1, "p"), "&nbsp;<a/>" };
				controls16.Add(new LiteralControl(string.Concat(strArrays32)));
				ControlCollection controlCollections16 = plhHeader.Controls;
				string[] strArrays33 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "Documents/Document_add.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("DOCUMENTS", 2, "p"), "</a>" };
				controlCollections16.Add(new LiteralControl(string.Concat(strArrays33)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Forecast")
			{
				ControlCollection controls17 = plhHeader.Controls;
				string[] strArrays34 = new string[] { "<td nowrap=nowrap width=99% class=bgcustomize height=23px><a href='", global.sitePath(), "forecast/forecast.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("FORECAST", 1, "p"), "&nbsp;<a/>" };
				controls17.Add(new LiteralControl(string.Concat(strArrays34)));
				ControlCollection controlCollections17 = plhHeader.Controls;
				string[] strArrays35 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "forecast/forecast.aspx' class=subnavigator>Add a New ", baseClass.ReturnScreenName("FORECAST", 2, "p"), "&nbsp;&nbsp;</a>" };
				controlCollections17.Add(new LiteralControl(string.Concat(strArrays35)));
				ControlCollection controls18 = plhHeader.Controls;
				string[] strArrays36 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "forecast/forecast_createview.aspx' class=subnavigator>Create a New ", baseClass.ReturnScreenName("FORECAST", 2, "p"), " View&nbsp;&nbsp;</a>" };
				controls18.Add(new LiteralControl(string.Concat(strArrays36)));
				if (global.GetTabDisplayRight(int.Parse(this.Session["CompanyID"].ToString()), int.Parse(this.Session["userID"].ToString()), "REPORTS"))
				{
					ControlCollection controlCollections18 = plhHeader.Controls;
					string[] strArrays37 = new string[] { "<strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "forecast/forecast_report.aspx' class=subnavigator>", baseClass.ReturnScreenName("REPORTS", 1, "p"), "</a>" };
					controlCollections18.Add(new LiteralControl(string.Concat(strArrays37)));
				}
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Estimate")
			{
				ControlCollection controls19 = plhHeader.Controls;
				string[] strArrays38 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "estimates/estimate_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("ESTIMATES", 1, "p"), "&nbsp;<a/>" };
				controls19.Add(new LiteralControl(string.Concat(strArrays38)));
				ControlCollection controlCollections19 = plhHeader.Controls;
				string[] strArrays39 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "estimates/estimate_add.aspx?type=add' class=subnavigator>Add a New ", baseClass.ReturnScreenName("ESTIMATES", 2, "p"), "&nbsp;&nbsp;</a>" };
				controlCollections19.Add(new LiteralControl(string.Concat(strArrays39)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Jobs")
			{
				ControlCollection controls20 = plhHeader.Controls;
				string[] strArrays40 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "jobs/jobs_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("JOBS", 1, "p"), "&nbsp;<a/>" };
				controls20.Add(new LiteralControl(string.Concat(strArrays40)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Purchase")
			{
				ControlCollection controlCollections20 = plhHeader.Controls;
				string[] strArrays41 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "purchase/purchase_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("PURCHASES", 2, "p"), "&nbsp;Orders<a/>" };
				controlCollections20.Add(new LiteralControl(string.Concat(strArrays41)));
				ControlCollection controls21 = plhHeader.Controls;
				string[] strArrays42 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "purchase/purchase_add.aspx?type=add' class=subnavigator>Add a New ", baseClass.ReturnScreenName("PURCHASES", 2, "p"), "&nbsp;Order&nbsp;</a>" };
				controls21.Add(new LiteralControl(string.Concat(strArrays42)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Invoice")
			{
				ControlCollection controlCollections21 = plhHeader.Controls;
				string[] strArrays43 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "invoice/invoice_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("INVOICES", 1, "p"), "&nbsp;<a/>" };
				controlCollections21.Add(new LiteralControl(string.Concat(strArrays43)));
				ControlCollection controls22 = plhHeader.Controls;
				string[] strArrays44 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "invoice/invoice_add.aspx?type=add' class=subnavigator>Add a New ", baseClass.ReturnScreenName("INVOICES", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls22.Add(new LiteralControl(string.Concat(strArrays44)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Inventory")
			{
				ControlCollection controlCollections22 = plhHeader.Controls;
				string[] strArrays45 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "inventory/inventory_view.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("INVENTORY", 2, "p"), "&nbsp;<a/>" };
				controlCollections22.Add(new LiteralControl(string.Concat(strArrays45)));
				ControlCollection controls23 = plhHeader.Controls;
				string[] strArrays46 = new string[] { " <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "inventory/inventory_add.aspx?type=add' class=subnavigator>Add a New ", baseClass.ReturnScreenName("INVENTORY", 2, "p"), "&nbsp;&nbsp;</a>" };
				controls23.Add(new LiteralControl(string.Concat(strArrays46)));
				plhHeader.Controls.Add(new LiteralControl(string.Concat(" <strong class=navigatorpanel style=vertical-align:top>|</strong>&nbsp;&nbsp;<a href='", global.sitePath(), "inventory/stock_adjustment.aspx' class=subnavigator>Stock Adjustment</a>")));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			if (sectionname == "Setting")
			{
				ControlCollection controlCollections23 = plhHeader.Controls;
				string[] strArrays47 = new string[] { "<td nowrap=nowrap width=99% class='bgcustomize' height=23px><a href='", global.sitePath(), "settings/settings.aspx' class=subnavigator>&nbsp;&nbsp;View ", baseClass.ReturnScreenName("SETTINGS", 1, "p"), "&nbsp;<a/>" };
				controlCollections23.Add(new LiteralControl(string.Concat(strArrays47)));
				plhHeader.Controls.Add(new LiteralControl("</td>"));
			}
			plhHeader.Controls.Add(new LiteralControl("</tr></table>"));
			plhHeader.Controls.Add(new LiteralControl("</td>"));
			plhHeader.Controls.Add(new LiteralControl("</tr></table>"));
		}

		public string Forecolor(int companyId, string pg)
		{
			if (pg == "welcome")
			{
				pg = "home";
			}
			string empty = string.Empty;
			int num = Convert.ToInt32(this.Session["companyid"]);
			if (pg != null)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_common_select_navigationcolor", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
                sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                sqlCommand.Parameters.AddWithValue("@pg", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", num);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					empty = sqlDataReader["forecolor"].ToString();
				}
				sqlDataReader.Close();
				_commonClass.closeConnection();
			}
			return empty;
		}

		public string functionCheckAll()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" <script language=JavaScript>");
			stringBuilder.Append(" function CheckAll( checkAllBox )");
			stringBuilder.Append("{");
			stringBuilder.Append("var frm = document.forms[0];");
			stringBuilder.Append("var ChkState=checkAllBox.checked;");
			stringBuilder.Append("for(i=0;i< frm.length;i++)");
			stringBuilder.Append("{");
			stringBuilder.Append("e=frm.elements[i];");
			stringBuilder.Append("if(e.type=='checkbox' && e.name.indexOf('Id') != -1)");
			stringBuilder.Append("if(e.disabled == true)");
			stringBuilder.Append("e.checked = false;");
			stringBuilder.Append("else e.checked= ChkState ;");
			stringBuilder.Append("if(e.type=='checkbox' && e.name.indexOf('All') != -1)");
			stringBuilder.Append("e.checked= ChkState ;");
			stringBuilder.Append("}");
			stringBuilder.Append("}");
			stringBuilder.Append("</script> ");
			return stringBuilder.ToString();
		}

		public string functionCheckAllButton()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" <script language=JavaScript>");
			stringBuilder.Append(" function CheckAllButton(CheckAll)");
			stringBuilder.Append(" {");
			stringBuilder.Append(" var frm = document.forms[0];");
			stringBuilder.Append(" var ChkState=true;");
			stringBuilder.Append(" var ChkAllButtonValue=CheckAll.Value;");
			stringBuilder.Append(" for(i=0;i< frm.length;i++)");
			stringBuilder.Append(" {");
			stringBuilder.Append(" e=frm.elements[i];");
			stringBuilder.Append(" if(e.type=='checkbox' && e.name.indexOf('Id') != -1)");
			stringBuilder.Append(" e.checked= ChkState ;");
			stringBuilder.Append(" if(e.type=='checkbox' && e.name.indexOf('All') != -1)");
			stringBuilder.Append(" e.checked= ChkState ;");
			stringBuilder.Append(" if(e.type=='checkbox' && e.name.indexOf('All') != -1)");
			stringBuilder.Append(" e.checked= ChkState ;");
			stringBuilder.Append(" }");
			stringBuilder.Append(" return false;");
			stringBuilder.Append(" }");
			stringBuilder.Append(" </script>");
			return stringBuilder.ToString();
		}

		public string functionCheckChange()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("");
			stringBuilder.Append("<script language=JavaScript>");
			stringBuilder.Append("function CheckChanged()");
			stringBuilder.Append("{");
			stringBuilder.Append(" var frm = document.forms[0];");
			stringBuilder.Append("  var boolAllChecked;");
			stringBuilder.Append("  boolAllChecked=true;");
			stringBuilder.Append("  for(i=0;i< frm.length;i++)");
			stringBuilder.Append(" {");
			stringBuilder.Append(" e=frm.elements[i];");
			stringBuilder.Append(" if ( e.type=='checkbox' && e.name.indexOf('Id') != -1 )");
			stringBuilder.Append(" if(e.checked== false)");
			stringBuilder.Append(" {");
			stringBuilder.Append(" boolAllChecked=false;");
			stringBuilder.Append(" break;");
			stringBuilder.Append(" }");
			stringBuilder.Append(" }");
			stringBuilder.Append(" for(i=0;i< frm.length;i++)");
			stringBuilder.Append(" {");
			stringBuilder.Append(" e=frm.elements[i];");
			stringBuilder.Append(" if ( e.type=='checkbox' && e.name.indexOf('checkAll') != -1 )");
			stringBuilder.Append(" {");
			stringBuilder.Append(" if( boolAllChecked==false)");
			stringBuilder.Append(" e.checked= false ;");
			stringBuilder.Append(" else");
			stringBuilder.Append(" e.checked= true;");
			stringBuilder.Append(" break;");
			stringBuilder.Append(" }");
			stringBuilder.Append(" }");
			stringBuilder.Append(" }");
			stringBuilder.Append(" </script>");
			return stringBuilder.ToString();
		}

		public string GenerateRandomCode(int i)
		{
			this.rGen = new Random();
			int num = 0;
			string empty = string.Empty;
			for (int i1 = 0; i1 <= i; i1++)
			{
				num = this.rGen.Next(0, 60);
				empty = string.Concat(empty, this.strCharacters[num]);
			}
			return empty;
		}

		public int getContactTypeID(string _txtcontacttype, string pg, int companyid)
		{
			int value = 0;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_getContactTypeID", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@_txtcontacttype", _txtcontacttype);
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			_commonClass.Dispose();
			return value;
		}

		public string GetDateOnRegionalSettings(int CompanyID, string txtDate, string DateType)
		{
			return SettingsBasePage.settings_getDateondateformat(CompanyID, txtDate, DateType);
		}

		public DataSet GetHeader(int CompanyID, int UserID, string SectionName, ref DataTable DataTableLower, ref string ColorCode, int Admin)
		{
			DataSet dataSet = new DataSet();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			sqlCommand.CommandText = "crm_select_UpperNavigator_new";
			sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@UserID", UserID);
			sqlCommand.Parameters.AddWithValue("@SelectedSection", SectionName);
			sqlCommand.Connection = _commonClass.openConnection();
			sqlDataAdapter.SelectCommand = sqlCommand;
			sqlDataAdapter.Fill(dataSet, "Upper");
			_commonClass.closeConnection();
			DataTableLower.Columns.Add(new DataColumn("SectionAddPage", typeof(string)));
			DataTableLower.Columns.Add(new DataColumn("DisplayName", typeof(string)));
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				object[] itemArray = row.ItemArray;
				string empty = string.Empty;
				string str = string.Empty;
				if (itemArray[1].ToString().ToUpper() == SectionName)
				{
					ColorCode = itemArray[3].ToString();
				}
				string upper = itemArray[1].ToString().ToUpper();
				string str1 = upper;
				if (upper != null)
				{
					switch (str1)
					{
						case "LEADS":
						{
							str = "New Lead";
							empty = "~/lead/lead_add.aspx";
							break;
						}
						case "CLIENTS":
						{
							str = "New Client";
							empty = "~/client/client_add.aspx";
							break;
						}
						case "OPPORTUNITIES":
						{
							str = "New Opportunity";
							empty = "~/opportunity/opportunity_add.aspx";
							break;
						}
						case "CONTACTS":
						{
							str = "New Contact";
							empty = "~/contact/contact_add.aspx";
							break;
						}
						case "TICKETS":
						{
							str = "New Ticket";
							empty = "~/ticket/ticket_add.aspx";
							break;
						}
						case "CAMPAIGN":
						{
							str = "New Campaign";
							empty = "~/campaign/campaign_add.aspx";
							break;
						}
						case "SOLUTIONS":
						{
							str = "New Solution";
							empty = "~/solution/solution_add.aspx";
							break;
						}
						case "CONTRACTS":
						{
							str = "New Contract";
							empty = "~/contract/contract_add.aspx";
							break;
						}
						case "PRODUCTS":
						{
							str = "New Product";
							empty = "~/product/product_add.aspx";
							break;
						}
						case "FORECAST":
						{
							str = "Forecast";
							empty = "~/forecast/forecast.aspx";
							break;
						}
					}
				}
				if (string.IsNullOrEmpty(str))
				{
					continue;
				}
				DataRow dataRow = DataTableLower.NewRow();
				dataRow["SectionAddPage"] = empty;
				dataRow["DisplayName"] = str;
				DataTableLower.Rows.Add(dataRow);
			}
			if (Admin == 1)
			{
				DataRow dataRow1 = DataTableLower.NewRow();
				dataRow1["SectionAddPage"] = "~/common/recyclebin.aspx";
				dataRow1["DisplayName"] = "Recycle Bin";
				DataTableLower.Rows.Add(dataRow1);
			}
			return dataSet;
		}

		public DataSet GetHeaderimage(int CompanyID, int UserID, string SectionName, ref DataTable DataTableLower, ref string ColorCode, int Admin)
		{
			BaseClass baseClass = new BaseClass();
			string str = baseClass.Return_IsEnable_CRM(Convert.ToInt32(this.companyID));
			DataSet dataSet = new DataSet();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			sqlCommand.CommandText = "crm_select_HeaderTabs_Details";
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@UserID", UserID);
			sqlCommand.Parameters.AddWithValue("@SelectedSection", SectionName);
			sqlCommand.Connection = _commonClass.openConnection();
			sqlDataAdapter.SelectCommand = sqlCommand;
			sqlDataAdapter.Fill(dataSet, "Upper");
			_commonClass.closeConnection();
			DataTableLower.Columns.Add(new DataColumn("SectionAddPage", typeof(string)));
			DataTableLower.Columns.Add(new DataColumn("DisplayName", typeof(string)));
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				object[] itemArray = row.ItemArray;
				string empty = string.Empty;
				string empty1 = string.Empty;
				if (itemArray[1].ToString().ToUpper() == SectionName)
				{
					ColorCode = itemArray[7].ToString();
				}
				string upper = itemArray[1].ToString().ToUpper();
				string str1 = upper;
				if (upper != null)
				{
					switch (str1)
					{
						case "HOME":
						{
							if (str.Trim().ToLower() != "true")
							{
								empty1 = "Tasks";
								row["ScreenName"] = "Tasks";
							}
							else
							{
								empty1 = "Dashboard";
								row["ScreenName"] = "Dashboard";
							}
							empty = "~/welcome.aspx";
							break;
						}
						case "LEADS":
						{
							empty1 = "New Lead";
							empty = "~/lead/lead_add.aspx";
							break;
						}
						case "CLIENTS":
						{
							empty1 = "New Client";
							empty = "~/client/client_add.aspx";
							break;
						}
						case "OPPORTUNITIES":
						{
							empty1 = "New Opportunity";
							empty = "~/opportunity/opportunity_add.aspx";
							break;
						}
						case "CONTACTS":
						{
							empty1 = "New Contact";
							empty = "~/contact/contact_add.aspx";
							break;
						}
						case "TICKETS":
						{
							empty1 = "New Ticket";
							empty = "~/ticket/ticket_add.aspx";
							break;
						}
						case "CAMPAIGN":
						{
							empty1 = "New Campaign";
							empty = "~/campaign/campaign_add.aspx";
							break;
						}
						case "SOLUTIONS":
						{
							empty1 = "New Solution";
							empty = "~/solution/solution_add.aspx";
							break;
						}
						case "CONTRACTS":
						{
							empty1 = "New Contract";
							empty = "~/contract/contract_add.aspx";
							break;
						}
						case "PRODUCTS":
						{
							empty1 = "New Product";
							empty = "~/product/product_add.aspx";
							break;
						}
						case "FORECAST":
						{
							empty1 = "Forecast";
							empty = "~/forecast/forecast.aspx";
							break;
						}
					}
				}
				if (string.IsNullOrEmpty(empty1))
				{
					continue;
				}
				DataRow dataRow = DataTableLower.NewRow();
				dataRow["SectionAddPage"] = empty;
				dataRow["DisplayName"] = empty1;
				DataTableLower.Rows.Add(dataRow);
			}
			if (Admin == 1)
			{
				DataRow dataRow1 = DataTableLower.NewRow();
				dataRow1["SectionAddPage"] = "~/common/recyclebin.aspx";
				dataRow1["DisplayName"] = "Recycle Bin";
				DataTableLower.Rows.Add(dataRow1);
			}
			return dataSet;
		}

		public string GetRegionalSettings(int CompanyID, string RegionalType)
		{
			string value = SettingsBasePage.settings_regionalsettings_select_by_type(CompanyID, RegionalType);
			if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(RegionalType)
				&& RegionalType.IndexOf("date", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				value = "DD/MM/YY";
			}
			return (new BaseClass()).SpecialDecode(value ?? string.Empty);
		}

		/// <summary>
		/// Lightweight logo/header for login and sign-up. Skips footer, regional/date SPs, and caches HTML in session.
		/// </summary>
		public void ApplyAuthPageLogo(PlaceHolder plhHeader, int companyId)
		{
			if (plhHeader == null)
			{
				return;
			}
			string cacheKey = string.Concat("AuthLogoHtml_", companyId);
			string logoHtml = this.Session[cacheKey] as string;
			if (string.IsNullOrEmpty(logoHtml))
			{
				logoHtml = this.BuildAuthPageLogoHtml(companyId);
				if (!string.IsNullOrEmpty(logoHtml))
				{
					this.Session[cacheKey] = logoHtml;
				}
			}
			if (!string.IsNullOrEmpty(logoHtml))
			{
				plhHeader.Controls.Clear();
				plhHeader.Controls.Add(new LiteralControl(logoHtml));
			}
		}

		private string BuildAuthPageLogoHtml(int companyId)
		{
			try
			{
				BaseClass baseClass = new BaseClass();
				DataTable dataTable = new DataTable();
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_company_logo_select", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure,
					CommandTimeout = 30
				};
				sqlCommand.Parameters.AddWithValue("@companyid", companyId);
				sqlCommand.Parameters.AddWithValue("@type", "both");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Load(sqlDataReader);
				sqlDataReader.Close();
				_commonClass.closeConnection();
				int currentYear = DateTime.Now.Year;
				int previousYear = currentYear - 1;
				var html = new StringBuilder();
				foreach (DataRow row in dataTable.Rows)
				{
					if (dataTable.Columns.Contains("type") && row["type"].ToString().ToLower() != "header")
					{
						continue;
					}
					html.Append("<table width='100%'>");
					if (row["isdefault"].ToString().ToLower() != "true")
					{
						string logotype = row["logotype"].ToString().Trim().ToLower();
						if (logotype == "text")
						{
							string text = this.ApplyAuthPageYearTokens(baseClass.SpecialDecode(row["logotext"].ToString()), currentYear, previousYear);
							html.Append("<tr><td align='left' class='topText1'>").Append(text).Append("</td></tr>");
						}
						else if (logotype == "template")
						{
							string template = this.ApplyAuthPageYearTokens(baseClass.SpecialDecode(row["logoTemplate"].ToString()), currentYear, previousYear);
							html.Append("<tr><td>").Append(template).Append("</td></tr>");
						}
						else if (logotype == "image")
						{
							string logoFile = row.Table.Columns.Contains("logoImage") ? row["logoImage"].ToString() : row["logoimage"].ToString();
							html.Append("<tr><td><img alt='' style='max-width:180px;' src='").Append(global.sitePath()).Append("docmanager.ashx?doctype=logo&amp;filename=").Append(logoFile).Append("'/></td></tr>");
						}
					}
					else
					{
						html.Append("<tr><td><img alt='' style='max-width:180px;' src='").Append(global.sitePath()).Append(EprintConfigurationManager.AppSettings["Header"].ToString()).Append("'/></td></tr>");
					}
					html.Append("</table>");
				}
				if (html.Length > 0)
				{
					return html.ToString();
				}
			}
			catch
			{
			}
			return this.BuildDefaultAuthPageLogoHtml();
		}

		private string BuildDefaultAuthPageLogoHtml()
		{
			string header = EprintConfigurationManager.AppSettings["Header"].ToString();
			if (string.IsNullOrEmpty(header))
			{
				return string.Empty;
			}
			return string.Concat("<table width='100%'><tr><td><img alt='' style='max-width:180px;' src='", global.sitePath(), header, "'/></td></tr></table>");
		}

		private string ApplyAuthPageYearTokens(string content, int currentYear, int previousYear)
		{
			if (string.IsNullOrEmpty(content))
			{
				return string.Empty;
			}
			if (content.Contains("[$CurrentYear$]"))
			{
				content = content.Replace("[$CurrentYear$]", currentYear.ToString());
			}
			if (content.Contains("[$PreviousYear$]"))
			{
				content = content.Replace("[$PreviousYear$]", previousYear.ToString());
			}
			return content;
		}

		public static void LoadAuthPageLanguageFile(int companyId, HttpSessionState session, commonClass cmn)
		{
			if (session == null || session["LanguageConversion"] != null)
			{
				return;
			}
			SqlCommand sqlCommand = new SqlCommand("PC_Select_LanguageFile", cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure,
				CommandTimeout = 30
			};
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			object result = sqlCommand.ExecuteScalar();
			cmn.closeConnection();
			if (result != null && result != DBNull.Value)
			{
				string languageFile = result.ToString().Trim();
				if (!string.IsNullOrEmpty(languageFile))
				{
					if (languageFile.IndexOf("english", StringComparison.OrdinalIgnoreCase) >= 0
						&& languageFile.IndexOf("russian", StringComparison.OrdinalIgnoreCase) < 0)
					{
						languageFile = "english_to_english";
					}
					session["LanguageConversion"] = languageFile;
				}
			}
			if (session["LanguageConversion"] == null)
			{
				session["LanguageConversion"] = "english_to_english";
			}
		}

		public static void ApplyAuthPageLoginButtonColor(int companyId, HttpSessionState session, System.Web.UI.WebControls.WebControl loginButton, commonClass cmn)
		{
			if (loginButton == null)
			{
				return;
			}
			string cacheKey = string.Concat("AuthHomeTabColor_", companyId);
			string colorName = session[cacheKey] as string;
			if (string.IsNullOrEmpty(colorName))
			{
				SqlCommand sqlCommand = new SqlCommand("crm_select_upperNavigationTab", cmn.openConnection())
				{
					CommandType = CommandType.StoredProcedure,
					CommandTimeout = 30
				};
				sqlCommand.Parameters.AddWithValue("@companyID", companyId);
				SqlDataReader reader = sqlCommand.ExecuteReader();
				while (reader.Read())
				{
					if (reader["headername"].ToString().Equals("home", StringComparison.OrdinalIgnoreCase))
					{
						colorName = reader["colorCode"].ToString();
						break;
					}
				}
				reader.Close();
				cmn.closeConnection();
				if (!string.IsNullOrEmpty(colorName))
				{
					session[cacheKey] = colorName;
				}
			}
			if (!string.IsNullOrEmpty(colorName))
			{
				try
				{
					loginButton.BackColor = Color.FromName(colorName);
				}
				catch
				{
				}
			}
		}

		public void logoSetting(PlaceHolder plhHeader, PlaceHolder plhFooter, int companyId, string type)
		{
			if (plhHeader == null)
			{
				return;
			}
			BaseClass baseClass = new BaseClass();
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_company_logo_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			sqlCommand.Parameters.AddWithValue("@type", "both");
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Load(sqlDataReader);
			sqlDataReader.Close();
			sqlCommand.Dispose();
			_commonClass.closeConnection();
			int num = 0;
			int num1 = 0;
			if (this.Session["UserID"] != null)
			{
				num = Convert.ToInt16(this.Session["UserID"].ToString());
			}
			if (this.Session["CompanyID"] != null)
			{
				num1 = Convert.ToInt16(this.Session["CompanyID"].ToString());
			}
			string regionalSettings = this.GetRegionalSettings(num1, "DateFormat");
			DateTime now = DateTime.Now;
			string str = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(regionalSettings, _commonClass.Eprint_return_Date_Before_View(now.ToString(), companyId, num, false));
			foreach (DataRow row in dataTable.Rows)
			{
				bool isHeaderRow = row["type"].ToString().ToLower() == "header";
				PlaceHolder logoPlaceHolder = isHeaderRow ? plhHeader : plhFooter;
				if (logoPlaceHolder == null)
				{
					continue;
				}
				if (!isHeaderRow)
				{
					logoPlaceHolder.Controls.Add(new LiteralControl("<table width='100%' style='padding-left: 7px;'>"));
				}
				else
				{
					logoPlaceHolder.Controls.Add(new LiteralControl("<table width='100%'>"));
				}
				if (row["isdefault"].ToString().ToLower() != "true")
				{
					string lower = row["logotype"].ToString().Trim().ToLower();
					string str1 = lower;
					if (lower != null)
					{
						if (str1 == "text")
						{
							if (row["type"].ToString().ToLower() == "header")
							{
								string str2 = "";
								string str3 = "";
								string str4 = "";
								str4 = baseClass.SpecialDecode(row["logotext"].ToString());
								if (row["logotext"].ToString().Contains("[$CurrentYear$]"))
								{
									str2 = Convert.ToDateTime(str).Year.ToString();
								}
								if (row["logotext"].ToString().Contains("[$PreviousYear$]"))
								{
									DateTime dateTime = Convert.ToDateTime(str);
									str3 = (dateTime.Year - 1).ToString();
								}
								str4 = str4.Replace("[$CurrentYear$]", str2);
								str4 = str4.Replace("[$PreviousYear$]", str3);
								plhHeader.Controls.Add(new LiteralControl(string.Concat("<tr><td align='left' class='topText1'>", str4, "</td></tr>")));
							}
							else if (row["type"].ToString().ToLower() == "footer")
							{
								string str5 = "";
								string str6 = "";
								string str7 = "";
								str7 = baseClass.SpecialDecode(row["logotext"].ToString());
								if (row["logotext"].ToString().Contains("[$CurrentYear$]"))
								{
									str5 = Convert.ToDateTime(str).Year.ToString();
								}
								if (row["logotext"].ToString().Contains("[$PreviousYear$]"))
								{
									DateTime dateTime1 = Convert.ToDateTime(str);
									str6 = (dateTime1.Year - 1).ToString();
								}
								str7 = str7.Replace("[$CurrentYear$]", str5);
								str7 = str7.Replace("[$PreviousYear$]", str6);
								plhFooter.Controls.Add(new LiteralControl(string.Concat("<tr><td align=left class=NormalText>", str7, "</td></tr>")));
							}
						}
						else if (str1 != "image")
						{
							if (str1 == "template")
							{
								if (row["type"].ToString().ToLower() == "header")
								{
									string str8 = "";
									string str9 = "";
									string str10 = "";
									str10 = baseClass.SpecialDecode(row["logoTemplate"].ToString());
									if (row["logoTemplate"].ToString().Contains("[$CurrentYear$]"))
									{
										str8 = Convert.ToDateTime(str).Year.ToString();
									}
									if (row["logoTemplate"].ToString().Contains("[$PreviousYear$]"))
									{
										DateTime dateTime2 = Convert.ToDateTime(str);
										str9 = (dateTime2.Year - 1).ToString();
									}
									str10 = str10.Replace("[$CurrentYear$]", str8);
									str10 = str10.Replace("[$PreviousYear$]", str9);
									plhHeader.Controls.Add(new LiteralControl(string.Concat("<tr><td>", str10, "</td></tr>")));
								}
								else if (row["type"].ToString().ToLower() == "footer")
								{
									string str11 = "";
									string str12 = "";
									string str13 = "";
									str13 = baseClass.SpecialDecode(row["logoTemplate"].ToString());
									if (row["logoTemplate"].ToString().Contains("[$CurrentYear$]"))
									{
										str11 = Convert.ToDateTime(str).Year.ToString();
									}
									if (row["logoTemplate"].ToString().Contains("[$PreviousYear$]"))
									{
										DateTime dateTime3 = Convert.ToDateTime(str);
										str12 = (dateTime3.Year - 1).ToString();
									}
									str13 = str13.Replace("[$CurrentYear$]", str11);
									str13 = str13.Replace("[$PreviousYear$]", str12);
									plhFooter.Controls.Add(new LiteralControl(string.Concat("<tr><td>", str13, "</td></tr>")));
								}
							}
						}
						else if (row["type"].ToString().ToLower() == "header")
						{
							ControlCollection controls = plhHeader.Controls;
							string[] strArrays = new string[] { "<tr><td><img alt='' src='", global.sitePath(), "docmanager.ashx?doctype=logo&amp;filename=", row["logoImage"].ToString(), "'/></td></tr>" };
							controls.Add(new LiteralControl(string.Concat(strArrays)));
						}
						else if (row["type"].ToString().ToLower() == "footer")
						{
							ControlCollection controlCollections = plhFooter.Controls;
							string[] strArrays1 = new string[] { "<tr><td><img alt='' src='", global.sitePath(), "docmanager.ashx?doctype=logo&amp;filename=", row["logoImage"].ToString(), "'/></td></tr>" };
							controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
						}
					}
				}
				else if (row["type"].ToString().ToLower() == "header")
				{
					plhHeader.Controls.Add(new LiteralControl(string.Concat("<tr><td><img alt='' src='", global.sitePath(), EprintConfigurationManager.AppSettings["Header"].ToString(), "'/></td></tr>")));
				}
				else if (row["type"].ToString().ToLower() == "footer")
				{
					plhFooter.Controls.Add(new LiteralControl(string.Concat("<tr><td align=left class=NormalText>", EprintConfigurationManager.AppSettings["Footer"].ToString(), "</td></tr>")));
				}
				if (row["type"].ToString().ToLower() != "header")
				{
					if (plhFooter != null)
					{
						plhFooter.Controls.Add(new LiteralControl("</table>"));
					}
				}
				else
				{
					plhHeader.Controls.Add(new LiteralControl("</table>"));
				}
			}
		}

		public PlaceHolder lower_tr_Setting(PlaceHolder plhLower, int displayType, bool isNewRow, int rowid, int totalfield)
		{
			string lower = this.Context.Request.Url.AbsolutePath.ToLower();
			if (displayType == 1)
			{
				plhLower.Controls.Add(new LiteralControl("</td>"));
				if (isNewRow)
				{
					rowid = 0;
					plhLower.Controls.Add(new LiteralControl("<td></td>"));
				}
				if (rowid % 2 == 0)
				{
					plhLower.Controls.Add(new LiteralControl("</tr><tr>"));
				}
			}
			else if (displayType == 2)
			{
				plhLower.Controls.Add(new LiteralControl("</td>"));
				plhLower.Controls.Add(new LiteralControl("</tr><tr valign=middle>"));
				int num = 0;
				num = (totalfield % 2 != 0 ? totalfield / 2 + 1 : totalfield / 2);
				if (rowid == num)
				{
					plhLower.Controls.Add(new LiteralControl("</table></td><td><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
				}
			}
			else if (displayType == 3)
			{
				plhLower.Controls.Add(new LiteralControl("</td>"));
				plhLower.Controls.Add(new LiteralControl("</tr>"));
				int num1 = 0;
				num1 = (totalfield % 2 != 0 ? totalfield / 2 + 1 : totalfield / 2);
				if (lower.Contains("campaign_detail"))
				{
					if (rowid == 9)
					{
						plhLower.Controls.Add(new LiteralControl("</table></td><td><table width=100% cellSpacing=2 cellPadding=2 align=center ><tr>"));
					}
				}
				else if (rowid == num1)
				{
					plhLower.Controls.Add(new LiteralControl("</table></td><td><table width=100% cellSpacing=2 cellPadding=2 align=center ><tr>"));
				}
			}
			return plhLower;
		}

		public decimal MakeNullToDecimal(string values)
		{
			return (string.IsNullOrEmpty(values) ? new decimal(0) : Convert.ToDecimal(values));
		}

		public int MakeNullToInteger(string values)
		{
			return (string.IsNullOrEmpty(values) ? 0 : Convert.ToInt32(values));
		}

		public string Return_Date_OnTime_Zone(string txtDate, int CompanyID, int UserID)
		{
			string empty = string.Empty;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("PC_settings_getDateonTimeZone", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@Date", txtDate);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@UserID", UserID);
			empty = (string)sqlCommand.ExecuteScalar();
			_commonClass.closeConnection();
			return empty;
		}

		public int returnNoOfLead_WithThisFirstLastName(string _txtcontacttype, int companyid, string contacttype)
		{
			int value = 0;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_matchContactTypeName", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@_txtcontacttype", _txtcontacttype);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@pg", contacttype);
			sqlCommand.ExecuteNonQuery();
			value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			_commonClass.Dispose();
			return value;
		}

		public string returnString(string name, string optionalValue)
		{
			name = name.Replace('\"'.ToString(), " ");
			name = name.Replace("'", " ");
			return name.Trim();
		}

		public string Select_GetActiveTabForeColor(int CompanyID, string HeaderName)
		{
			BaseClass baseClass = new BaseClass();
			return SettingsBasePage.SelectForecolor_GetActiveTabForeColor(CompanyID, HeaderName);
		}

		public string StoreImage(FileUpload File1, bool IsImage)
		{
			return string.Empty;
		}

		public PlaceHolder upper_tr_Setting(string isRequired, bool isTextArea, PlaceHolder plhUpper, string labeltext, int displayType, bool isNewRow, int rowid)
		{
			string empty = string.Empty;
			string str = string.Empty;
			str = (isTextArea ? "top" : "middle");
			string lower = this.Context.Request.Url.AbsolutePath.ToLower();
			if (!lower.Contains("lead") && !lower.Contains("client") && !lower.Contains("contact") && !lower.Contains("campaign") && !lower.Contains("contract") && !lower.Contains("opportunity") && !lower.Contains("product") && !lower.Contains("solution") && !lower.Contains("ticket"))
			{
				lower.Contains("asset");
			}
			if (lower.Contains("campaign"))
			{
				commonClass _commonClass = new commonClass();
				if (labeltext.Trim() == "Expected Revenue")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Expected_Revenue"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
				if (labeltext.Trim() == "Actual Cost")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Actual_Cost"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
				if (labeltext.Trim() == "Budgeted Cost")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Budgeted_Cost"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
			}
			if (displayType == 1)
			{
				if ((!(labeltext.TrimEnd(new char[0]) == "Sales Person") || !(this.BaseCompanyType != "Customer")) && (!(labeltext.TrimEnd(new char[0]) == "Tax Number") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Balance") || !(this.BaseCompanyType != "Supplier")))
				{
					if (isNewRow && rowid % 2 != 0)
					{
						plhUpper.Controls.Add(new LiteralControl("<td></td></tr><tr>"));
					}
					plhUpper.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' valign=", str, ">")));
					plhUpper.Controls.Add(new LiteralControl(labeltext));
					if (isRequired.ToLower() == "true")
					{
						plhUpper.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
					}
					plhUpper.Controls.Add(new LiteralControl("</td>"));
					plhUpper.Controls.Add(new LiteralControl(string.Concat("<td  valign=", str, ">")));
				}
			}
			else if (displayType == 2)
			{
				plhUpper.Controls.Add(new LiteralControl("<td width=40% class='label normaltext'>"));
				plhUpper.Controls.Add(new LiteralControl(labeltext));
				if (isRequired.ToLower() == "true")
				{
					plhUpper.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
				}
				plhUpper.Controls.Add(new LiteralControl("</td></tr><tr>"));
				plhUpper.Controls.Add(new LiteralControl("<td width=60%>"));
			}
			else if (displayType == 3 && (!(labeltext.TrimEnd(new char[0]) == "Sales Person") || !(this.BaseCompanyType == "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Tax Number") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Balance") || !(this.BaseCompanyType != "Supplier")))
			{
				plhUpper.Controls.Add(new LiteralControl(string.Concat("<td width=40% class='label normaltext' valign=", str, " style='padding-left:5px'>")));
				plhUpper.Controls.Add(new LiteralControl(labeltext));
				if (isRequired.ToLower() == "true")
				{
					plhUpper.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
				}
				plhUpper.Controls.Add(new LiteralControl("</td>"));
				plhUpper.Controls.Add(new LiteralControl(string.Concat("<td width=60% valign=", str, ">")));
			}
			return plhUpper;
		}

		public PlaceHolder upper_tr_Setting_Indetail(PlaceHolder plhUpper, string labeltext, int displayType, bool isNewRow, int rowid)
		{
			string empty = string.Empty;
			string lower = this.Context.Request.Url.AbsolutePath.ToLower();
			if (!lower.Contains("lead") && !lower.Contains("client") && !lower.Contains("contact") && !lower.Contains("campaign") && !lower.Contains("contract") && !lower.Contains("opportunity") && !lower.Contains("product") && !lower.Contains("solution") && !lower.Contains("ticket"))
			{
				lower.Contains("asset");
			}
			if (lower.Contains("campaign"))
			{
				commonClass _commonClass = new commonClass();
				if (labeltext.Trim() == "Expected Revenue")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Expected_Revenue"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
				if (labeltext.Trim() == "Actual Cost")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Actual_Cost"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
				if (labeltext.Trim() == "Budgeted Cost")
				{
					labeltext = string.Concat(this.objLangClass.GetLanguageConversion("Budgeted_Cost"), " (", _commonClass.GetCurrencyinRequiredFormate("", true), ")");
				}
			}
			if (displayType == 1)
			{
				if (isNewRow && rowid % 2 != 0)
				{
					plhUpper.Controls.Add(new LiteralControl("<td></td></tr><tr valign=middle>"));
				}
				if ((!(labeltext.TrimEnd(new char[0]) == "Tax Number") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Balance") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Sales Person") || !(this.BaseCompanyType == "Supplier")))
				{
					plhUpper.Controls.Add(new LiteralControl("<td class='label normaltext'>"));
					plhUpper.Controls.Add(new LiteralControl(labeltext));
					plhUpper.Controls.Add(new LiteralControl("</td>"));
					plhUpper.Controls.Add(new LiteralControl("<td class=tablerowcolor2>"));
				}
			}
			else if (displayType == 2)
			{
				plhUpper.Controls.Add(new LiteralControl("<td width=40% class='label normaltext'>"));
				plhUpper.Controls.Add(new LiteralControl(labeltext));
				plhUpper.Controls.Add(new LiteralControl("</td></tr><tr>"));
				plhUpper.Controls.Add(new LiteralControl("<td width=60% class=tablerowcolor2>"));
			}
			else if (displayType == 3 && (!(labeltext.TrimEnd(new char[0]) == "Tax Number") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Balance") || !(this.BaseCompanyType != "Supplier")) && (!(labeltext.TrimEnd(new char[0]) == "Sales Person") || !(this.BaseCompanyType == "Supplier")))
			{
				plhUpper.Controls.Add(new LiteralControl("<td width=40% class='label normaltext' height=22px style='padding-left:5px'>"));
				plhUpper.Controls.Add(new LiteralControl(labeltext));
				plhUpper.Controls.Add(new LiteralControl("</td>"));
				plhUpper.Controls.Add(new LiteralControl("<td width=60% class=tablerowcolor2>"));
			}
			return plhUpper;
		}

		public PlaceHolder upper_tr_Setting_Indetail_client(PlaceHolder plhUpper, string labeltext, int displayType, bool isNewRow, int rowid, string companytype)
		{
			this.BaseCompanyType = companytype;
			this.upper_tr_Setting_Indetail(plhUpper, labeltext, displayType, isNewRow, rowid);
			return plhUpper;
		}

		public PlaceHolder upper_tr_Settingclient(string isRequired, bool isTextArea, PlaceHolder plhUpper, string labeltext, int displayType, bool isNewRow, int rowid, string companytype)
		{
			this.BaseCompanyType = companytype;
			this.upper_tr_Setting(isRequired, isTextArea, plhUpper, labeltext, displayType, isNewRow, rowid);
			return plhUpper;
		}
	}
}