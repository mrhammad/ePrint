using nmsCommon;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class CustomizePrintableView : CustomizeDetail
	{
		public languageClass objLanguage = new languageClass();

		public commonClass cmn = new commonClass();

		private BaseClass objBase = new BaseClass();

		public BasePage objpage = new BasePage();

		private int rowcount;

		private string openwin = string.Empty;

		private string url = string.Empty;

		private int id;

		private int deleteid;

		private int count;

		public CustomizePrintableView()
		{
		}

		public void Customize_printable(PlaceHolder plhSubSection, int ModuleID, string pg, string OptionalValue)
		{
			int num =0;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int num17 = 0;
			int num18 = 0;
			int num19 = 0;
			int num20 = 0;
			string empty = string.Empty;
			string str = string.Empty;
			string empty1 = string.Empty;
			string str1 = string.Empty;
			string empty2 = string.Empty;
			string str2 = string.Empty;
			string empty3 = string.Empty;
			string str3 = string.Empty;
			string empty4 = string.Empty;
			string str4 = string.Empty;
			string empty5 = string.Empty;
			string str5 = string.Empty;
			string empty6 = string.Empty;
			string str6 = string.Empty;
			string empty7 = string.Empty;
			string str7 = string.Empty;
			string empty8 = string.Empty;
			string str8 = string.Empty;
			string empty9 = string.Empty;
			string str9 = string.Empty;
			string empty10 = string.Empty;
			string str10 = string.Empty;
			empty2 = "crm_common_select_openactivities_printable";
			str2 = "crm_common_select_activehistory_printable";
			empty3 = "crm_common_select_attachment_printable";
			str3 = "crm_common_select_email_printable";
			empty4 = "crm_client_select_contact";
			str4 = "crm_common_select_opportunity";
			empty5 = "crm_common_select_partner";
			str5 = "crm_common_select_contactrole";
			empty6 = "crm_common_select_competitor";
			str6 = "crm_opportunity_select_stagehistory";
			empty7 = "crm_campaign_select_marketing";
			str7 = "crm_product_standardprice_in_subsection";
			empty8 = "crm_product_listprice_in_subsection";
			str8 = "crm_common_select_contractapproval";
			empty9 = "crm_contract_selecthistory";
			str9 = "crm_solution_select_solutionhistory";
			empty10 = "crm_ticket_select_tickethistory";
			str10 = "crm_common_select_solution";
			string lower = pg.ToLower();
			string str11 = lower;
			if (lower != null)
			{
				switch (str11)
				{
					case "lead":
					{
						empty = "crm_lead_select_subsection";
						str = "leadID";
						break;
					}
					case "client":
					{
						empty = "crm_client_select_subsection";
						str = "clientID";
						empty1 = "crm_client_select_ticket";
						break;
					}
					case "contact":
					{
						empty = "crm_contact_select_subsection";
						str = "contactID";
						empty1 = "crm_contact_select_ticket";
						break;
					}
					case "opportunity":
					{
						empty = "crm_opportunity_select_subsection";
						str = "opportunityID";
						break;
					}
					case "campaign":
					{
						empty = "crm_campaign_select_subsection";
						str = "campaignID";
						break;
					}
					case "product":
					{
						empty = "crm_product_select_subsection";
						str = "productID";
						break;
					}
					case "contract":
					{
						empty = "crm_contract_select_subsection";
						str = "contractID";
						break;
					}
					case "ticket":
					{
						empty = "crm_ticket_select_subsection";
						str = "ticketID";
						break;
					}
					case "asset":
					{
						empty = "crm_asset_select_subsection";
						str = "assetID";
						break;
					}
					case "solution":
					{
						empty = "crm_solution_select_subsection";
						str = "solutionID";
						empty1 = "crm_common_select_ticket";
						break;
					}
				}
			}
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand = new SqlCommand(empty ?? "", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			sqlCommand.Parameters.AddWithValue(string.Concat("@", str), ModuleID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			plhSubSection.Controls.Add(new LiteralControl("<TABLE cellSpacing=3 cellPadding=1 width=100% border=0>"));
			while (sqlDataReader.Read())
			{
				if (pg.ToLower().Trim() != "product" && pg.ToLower().Trim() != "price" && pg.ToLower().Trim() != "solution")
				{
					num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
					num3 = int.Parse(sqlDataReader["noofopenactivities"].ToString());
					num4 = int.Parse(sqlDataReader["noofactivehistory"].ToString());
					num5 = int.Parse(sqlDataReader["noofattachment"].ToString());
				}
				string lower1 = pg.ToLower();
				string str12 = lower1;
				if (lower1 != null)
				{
					switch (str12)
					{
						case "lead":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							break;
						}
						case "client":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							num6 = int.Parse(sqlDataReader["noofpartner"].ToString());
							num7 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num8 = int.Parse(sqlDataReader["noofticket"].ToString());
							num9 = int.Parse(sqlDataReader["noofcontact"].ToString());
							break;
						}
						case "contact":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							num7 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num8 = int.Parse(sqlDataReader["noofticket"].ToString());
							break;
						}
						case "opportunity":
						{
							num13 = int.Parse(sqlDataReader["noofcontactrole"].ToString());
							num14 = int.Parse(sqlDataReader["noofcompetitor"].ToString());
							num15 = int.Parse(sqlDataReader["noofstagehistory"].ToString());
							num16 = int.Parse(sqlDataReader["noofproduct"].ToString());
							break;
						}
						case "campaign":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							num7 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num10 = int.Parse(sqlDataReader["noofmarketingemail"].ToString());
							break;
						}
						case "product":
						{
							num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
							num17 = int.Parse(sqlDataReader["noofproductlist"].ToString());
							break;
						}
						case "contract":
						{
							num12 = int.Parse(sqlDataReader["noofcontracthistory"].ToString());
							num11 = int.Parse(sqlDataReader["noofapproval"].ToString());
							break;
						}
						case "solution":
						{
							num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
							num5 = int.Parse(sqlDataReader["noofattachment"].ToString());
							num8 = int.Parse(sqlDataReader["noofticket"].ToString());
							num18 = int.Parse(sqlDataReader["noofsolutionhistory"].ToString());
							break;
						}
						case "ticket":
						{
							num20 = int.Parse(sqlDataReader["noofsolution"].ToString());
							num19 = int.Parse(sqlDataReader["nooftickethistory"].ToString());
							break;
						}
					}
				}
				string lower2 = sqlDataReader["subsectionname"].ToString().ToLower();
				string str13 = lower2;
				if (lower2 == null)
				{
					continue;
				}
                //if (<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017dc-3 == null)
                //{
                //    <PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017dc-3 = new Dictionary<string, int>(21)
                //    {
                //        { "notes", 0 },
                //        { "open activities", 1 },
                //        { "active history", 2 },
                //        { "attachment", 3 },
                //        { "html email", 4 },
                //        { "contacts", 5 },
                //        { "opportunity", 6 },
                //        { "partners", 7 },
                //        { "ticket", 8 },
                //        { "contact role", 9 },
                //        { "competitors", 10 },
                //        { "stage history", 11 },
                //        { "product", 12 },
                //        { "marketing", 13 },
                //        { "standard price", 14 },
                //        { "price books", 15 },
                //        { "approval request", 16 },
                //        { "contract history", 17 },
                //        { "ticket history", 18 },
                //        { "solution", 19 },
                //        { "solution history", 20 }
                //    };
                //}
                //if (!<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017dc-3.TryGetValue(str13, out num))
                //{
                //    continue;
                //}
				switch (num)
				{
					case 1:
					{
						if (pg.Trim().ToLower() == "campaign")
						{
							continue;
						}
						this.subsection_OpenActivity_print(plhSubSection, ModuleID, num3, pg, empty2);
						continue;
					}
					case 2:
					{
						this.subsection_ActiveHistory_print(plhSubSection, ModuleID, str, num4, pg, str2);
						continue;
					}
					case 3:
					{
						this.subsection_Attachments_print(plhSubSection, ModuleID, num5, pg, empty3);
						continue;
					}
					case 4:
					{
						this.subsection_HTMLEmail_print(plhSubSection, ModuleID, num2, pg, str3);
						continue;
					}
					case 5:
					{
						this.subsection_Contacts_print(plhSubSection, ModuleID, str, num9, pg, empty4);
						continue;
					}
					case 6:
					{
						this.subsection_Opportunity_print(plhSubSection, ModuleID, num7, sqlDataReader["navigationcolor"].ToString(), pg, str, str4);
						continue;
					}
					case 7:
					{
						this.subsection_Partners_print(plhSubSection, ModuleID, num6, pg, empty5);
						continue;
					}
					case 8:
					{
						this.subsection_Ticket_print(plhSubSection, ModuleID, str, num8, pg, empty1);
						continue;
					}
					case 9:
					{
						this.subsection_ContactRole_print(plhSubSection, ModuleID, num13, pg, str5);
						continue;
					}
					case 10:
					{
						this.subsection_Competitors_print(plhSubSection, ModuleID, num14, pg, empty6);
						continue;
					}
					case 11:
					{
						this.subsection_StageHistory_print(plhSubSection, ModuleID, num15, pg, str6);
						continue;
					}
					case 12:
					{
						if (pg.ToLower() != "opportunity")
						{
							continue;
						}
						this.subsection_Product_print(plhSubSection, ModuleID, num16, pg);
						continue;
					}
					case 13:
					{
						this.subsection_Marketing_print(plhSubSection, ModuleID, num10, pg, empty7);
						continue;
					}
					case 14:
					{
						this.subsection_StandardPrice_print(plhSubSection, ModuleID, num1, pg, str7);
						continue;
					}
					case 15:
					{
						this.subsection_PriceBooks_print(plhSubSection, ModuleID, num17, pg, num1, empty8);
						continue;
					}
					case 16:
					{
						this.subsection_ApprovalRequest_print(plhSubSection, ModuleID, num11, pg, str8);
						continue;
					}
					case 17:
					{
						this.subsection_ContractHistory_print(plhSubSection, ModuleID, num12, pg, empty9);
						continue;
					}
					case 18:
					{
						this.subsection_ticketHistory_print(plhSubSection, ModuleID, num19, pg, empty10);
						continue;
					}
					case 19:
					{
						this.subsection_ticketSolution_print(plhSubSection, ModuleID, num20, pg, str10);
						continue;
					}
					case 20:
					{
						this.subsection_SolutionHistory_print(plhSubSection, ModuleID, num18, pg, str9);
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
		}

		public void subsection_ActiveHistory_print(PlaceHolder plhSubSection, int ModuleID, string ModuleIDName, int noofactivehistory, string pg, string activehistoryProce)
		{
			string str;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Activity History"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofactivehistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(activehistoryProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@tasktypeid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@tasktype", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=2 cellpadding=2 border=0 class=tablerowcolor2>"));
				this.count = 0;
				while (sqlDataReader.Read() & this.count < 5)
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext nowrap=nowrap>", sqlDataReader["tasktype"].ToString(), ":</td>")));
					commonClass _commonClass1 = new commonClass();
					str = (sqlDataReader["tasktype"].ToString().ToLower() != "task" ? _commonClass1.return_Event_DateTime_Before_View(sqlDataReader["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString())) : _commonClass1.return_DateTime_Before_View(sqlDataReader["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString())));
					plhSubSection.Controls.Add(new LiteralControl("<td align=left width=100% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["subject"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<td colspan=2 class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["description"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 >"));
					plhSubSection.Controls.Add(new LiteralControl("<tr><td class=normaltext nowrap=nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
					plhSubSection.Controls.Add(new LiteralControl(" <b>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("</b>&nbsp;", this.objLanguage.convert("on"), "&nbsp;")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString())), "&nbsp;")));
					plhSubSection.Controls.Add(new LiteralControl("</td><td width=100% class=normaltext align=left> "));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Due on"), "&nbsp;")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(" ", str)));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>", this.objLanguage.convert("No Active History."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_ApprovalRequest_print(PlaceHolder plhSubSection, int ModuleID, int noofapproval, string pg, string approvalProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Approval Requests"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofapproval != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(approvalProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@contractid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Assigned To")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Status")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Approve/Reject Comment")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createusername"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["assigntoname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["approvalStatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["description"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No Approval Request Available."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Attachments_print(PlaceHolder plhSubSection, int ModuleID, int noofattachment, string pg, string attachmentProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap >", this.objLanguage.convert("Notes + Attachments"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofattachment != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(attachmentProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext colspan=2>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["subject"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext colspan=2>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["filename"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext nowrap=nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;<b>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createName"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</b>&nbsp;on &nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=100%>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Modified date")));
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["modifiedDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				sqlCommand.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>", this.objLanguage.convert("No Attachments."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Competitors_print(PlaceHolder plhSubSection, int ModuleID, int noofcompetitor, string pg, string competitorProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Competitors"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofcompetitor != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(competitorProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@opportunityid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% nowrap class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Competitor Name")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Strength")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Weakness")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.count = 0;
				while (sqlDataReader.Read() & this.count < 5)
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows >"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative >"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["competitorname"].ToString(), 30)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["strength"].ToString(), 30)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["weakness"].ToString(), 30)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No Competitor."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_ContactRole_print(PlaceHolder plhSubSection, int ModuleID, int noofcontactrole, string pg, string contactRoleProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Role")));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofcontactrole != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(contactRoleProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@opportunityid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", this.objLanguage.convert("Contact Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Client Name", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Phone1", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Email", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", this.objLanguage.convert("Role"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Primary")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.count = 0;
				while (sqlDataReader.Read() & this.count < 5)
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows >"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative >"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["contactname"].ToString()));
					try
					{
						plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["clientname"].ToString()));
					}
					catch
					{
						plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext></td"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["phone1"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["email"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["role"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["isprimary"].ToString().Replace("True", "Yes").Replace("False", "No"), "</td>")));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>No ", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Role.</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Contacts_print(PlaceHolder plhSubSection, int ModuleID, string ModuleIDName, int noofcontact, string pg, string contactsProce)
		{
			if (this.Session["CONTACTS"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap >", this.objBase.ReturnScreenName("CONTACTS", 2, "p"))));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				if (noofcontact != 0)
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand(contactsProce ?? "", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue("@clientid", ModuleID);
					sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
					sqlCommand.Parameters.AddWithValue("@selectall", "no");
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", this.objLanguage.convert("Contact Name"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Phone1", "contact"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Email", "contact"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					this.count = 0;
					while (sqlDataReader.Read() & this.count < 5)
					{
						CustomizePrintableView customizePrintableView = this;
						customizePrintableView.count = customizePrintableView.count + 1;
						if (this.count % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
						}
						ControlCollection controls = plhSubSection.Controls;
						string[] str = new string[] { "<td class=normaltext>", sqlDataReader["firstname"].ToString(), " ", sqlDataReader["lastname"].ToString(), "</td>" };
						controls.Add(new LiteralControl(string.Concat(str)));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["phone1"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["email"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					}
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>No ", this.objBase.ReturnScreenName("CONTACTS", 1, "p"), " Added</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}

		public void subsection_ContractHistory_print(PlaceHolder plhSubSection, int ModuleID, int noofcontracthistory, string pg, string contractHistroyProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=HeaderText colspan=2 nowrap=nowrap>", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " History</td>")));
			if (noofcontracthistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(contractHistroyProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@contractid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=17% class= navigatorpanel>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows><td class=normaltext >&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext >&nbsp;"));
					}
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["contractstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>No ", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " History Available</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_HTMLEmail_print(PlaceHolder plhSubSection, int ModuleID, int noofemail, string pg, string HTMLStoredProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap >", this.objLanguage.convert("HTML Email"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofemail != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(HTMLStoredProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td Nowrap=nowrap colspan=2><b>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["subject"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</b></td >"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top>"));
					plhSubSection.Controls.Add(new LiteralControl("<td colspan=2>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["message"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Attachmnets")));
					plhSubSection.Controls.Add(new LiteralControl(":&nbsp;"));
					if (sqlDataReader["attachment"].ToString() != "")
					{
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["attachment"].ToString()));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("No Attachments"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
					plhSubSection.Controls.Add(new LiteralControl(" <b>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</b> on "));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["datesent"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=bgcustomize><table cellspacing=1 cellpadding=4 border=0 width=100% ><tr><td class=norecords>", this.objLanguage.convert("No Email Available."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Marketing_print(PlaceHolder plhSubSection, int ModuleID, int noofmarketingemail, string pg, string marketingStoredProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Marketing"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofmarketingemail != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(marketingStoredProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td class=navigatorpanel width=30%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Subject")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel width=30%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Template Used")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel width=20%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date Sent")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel width=20%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("No. of emails")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=20% nowrap> &nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["subject"].ToString(), 30)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=30% nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["templatename"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=30% nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["datesent"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=20% nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["noofemail"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0  ><tr><td class=norecords>", this.objLanguage.convert("No Marketing Emails."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Notes_print(PlaceHolder plhSubSection, int ModuleID, int noofrecords, string pg, string notesStoredProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Notes"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofrecords != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(notesStoredProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@notetypeid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@notetype", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["description"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr><td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
					plhSubSection.Controls.Add(new LiteralControl(" <b>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</b> on "));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>", this.objLanguage.convert("No Notes Available."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_OpenActivity_print(PlaceHolder plhSubSection, int ModuleID, int noofopenactivities, string pg, string openActivityProce)
		{
			string str;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap >", this.objLanguage.convert("Open Activities"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofopenactivities != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(openActivityProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@tasktypeid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@tasktype", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=2 cellpadding=2 border=0 class=tablerowcolor2>"));
				this.count = 0;
				while (sqlDataReader.Read() & this.count < 5)
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative >"));
					}
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td nowrap=nowrap  class=normaltext>", sqlDataReader["tasktype"].ToString(), ":</td>")));
					commonClass _commonClass1 = new commonClass();
					str = (sqlDataReader["tasktype"].ToString().ToLower() != "task" ? _commonClass1.return_Event_DateTime_Before_View(sqlDataReader["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString())) : _commonClass1.return_DateTime_Before_View(sqlDataReader["duedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString())));
					plhSubSection.Controls.Add(new LiteralControl("<td align=left class=normaltext width=100%>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["subject"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext colspan=2>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.dispstr(sqlDataReader["description"].ToString(), 50)));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 >"));
					plhSubSection.Controls.Add(new LiteralControl("<tr><td class=normaltext nowrap=nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
					plhSubSection.Controls.Add(new LiteralControl(" <b>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</b> on "));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString())), "&nbsp;")));
					plhSubSection.Controls.Add(new LiteralControl("</td><td width=100% class=normaltext align=left> "));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Due on"), "&nbsp;")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat(" ", str)));
					plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No Open Activities."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Opportunity_print(PlaceHolder plhSubSection, int ModuleID, int noofopportunity, string navigationcolor, string pg, string ModuleIDName, string opportunityProce)
		{
			if (this.Session["OPPORTUNITIES"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"))));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				if (noofopportunity != 0)
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand(opportunityProce ?? "", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
					sqlCommand.Parameters.AddWithValue("@section", pg);
					sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
					sqlCommand.Parameters.AddWithValue("@selectall", "no");
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td nowrap width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Opportunity Name", "Opportunity"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td nowrap width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Amount", "Opportunity"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td nowrap width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Close Date", "Opportunity"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td nowrap class=navigatorpanel>"));
					plhSubSection.Controls.Add(new LiteralControl(global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Opportunity Stage", "Opportunity")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					this.count = 0;
					while (sqlDataReader.Read() & this.count < 5)
					{
						CustomizePrintableView customizePrintableView = this;
						customizePrintableView.count = customizePrintableView.count + 1;
						if (this.count % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
						}
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["opportunityname"].ToString(), "</td>")));
						commonClass _commonClass1 = new commonClass();
						string str = _commonClass1.returnMyCurrency(sqlDataReader["amount"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", str, "</td>")));
						commonClass _commonClass2 = new commonClass();
						string str1 = _commonClass2.return_DateTime_Before_View(sqlDataReader["closedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", str1, "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["opportunitystagename"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					}
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>No ", this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "p"), " Added</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}

		public void subsection_Partners_print(PlaceHolder plhSubSection, int ModuleID, int noofpartner, string pg, string partnersProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Partners"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofpartner != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(partnersProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@clientId", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class= navigatorpanel>", this.objLanguage.convert("Partner Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=navigatorpanel>", this.objLanguage.convert("Role"), "</td>")));
				this.count = 0;
				while (sqlDataReader.Read() & this.count < 5)
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["PartnerName"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["Role"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0  ><tr><td class=norecords>", this.objLanguage.convert("No Partner Added."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_PriceBooks_print(PlaceHolder plhSubSection, int ModuleID, int noofproductlist, string pg, int noofrecords, string priceBookProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Price Books"), "</td>")));
			if (noofproductlist != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(priceBookProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@productpriceid", 0);
				sqlCommand.Parameters.AddWithValue("@productid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@type", 1);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=navigatorpanel>", this.objLanguage.convert("Price Book Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=navigatorpanel>", this.objLanguage.convert("List Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=navigatorpanel>", this.objLanguage.convert("Use Standard Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Active")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.count = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["pricebookname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader["listprice"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["isstandard"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["isactive"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Product_print(PlaceHolder plhSubSection, int ModuleID, int noofproduct, string pg)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_pricename_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@opportunityid", ModuleID);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			SetProperties setProperty = new SetProperties();
			while (sqlDataReader.Read())
			{
				setProperty.priceID = int.Parse(sqlDataReader["priceID"].ToString());
				setProperty.priceBookName = sqlDataReader["PriceBookName"].ToString();
			}
			sqlDataReader.Close();
			sqlDataReader.Dispose();
			_commonClass.closeConnection();
			_commonClass.Dispose();
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert(string.Concat("Products (", setProperty.priceBookName, ")")))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofproduct != 0)
			{
				commonClass _commonClass1 = new commonClass();
				SqlCommand sqlCommand1 = new SqlCommand("crm_opportunity_product_select", _commonClass1.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand1.Parameters.AddWithValue("@opportunityid", ModuleID);
				sqlCommand1.Parameters.AddWithValue("@priceid", setProperty.priceID);
				sqlCommand1.Parameters.AddWithValue("@tableid", 0);
				sqlCommand1.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpane>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Product Name", "Product"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpane>", this.objLanguage.convert("Quantity\t"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpane>", this.objLanguage.convert("Sales Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpane>", this.objLanguage.convert("Date"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpane>", this.objLanguage.convert("List Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpane nowrap=nowrap>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Line Description")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.count = 0;
				while (sqlDataReader1.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.count = customizePrintableView.count + 1;
					if (this.count % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td bgcolor=", this.objpage.colorCode(Convert.ToInt32(this.Session["companyid"]), pg), ">")));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader1["productname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader1["quantity"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader1["saleprice"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader1["createdate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader1["listprice"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader1["detail"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader1.Close();
				sqlDataReader1.Dispose();
				_commonClass1.closeConnection();
				_commonClass1.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_SolutionHistory_print(PlaceHolder plhSubSection, int ModuleID, int noofsolutionhistory, string pg, string solutionHistoryPrice)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=HeaderText nowrap=nowrap colspan=2>", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " History")));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofsolutionhistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(solutionHistoryPrice ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@solutionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=17% class= navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class= navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class= navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows><td class=normaltext width=1%>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>"));
					}
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["solutionstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " History Available.")), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_StageHistory_print(PlaceHolder plhSubSection, int ModuleID, int noofstagehistory, string pg, string stageHistoryProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Stage History"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofstagehistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(stageHistoryProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=15% class=navigatorpanel>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Stage")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Next Step")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Amount")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Probability")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Close Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Last Modified")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=1% nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["stage"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["nextstep"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader["amount"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["probablity"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["closedate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createdate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No Stage History."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_StandardPrice_print(PlaceHolder plhSubSection, int ModuleID, int noofrecords, string pg, string standardpriceProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=HeaderText nowrap=nowrap>", this.objLanguage.convert("Standard Price"), "</td></tr>")));
			if (noofrecords != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(standardpriceProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@productid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Standard Price")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Active")));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top classs==NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader["standardprice"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["isactive"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Ticket_print(PlaceHolder plhSubSection, int ModuleID, string ModuleIDName, int noofticket, string pg, string storedProcedure)
		{
			if (this.Session["TICKETS"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objBase.ReturnScreenName("TICKETS", 1, "p"))));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				if (noofticket != 0)
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand(storedProcedure ?? "", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					if (ModuleIDName != "solutionID")
					{
						sqlCommand.Parameters.AddWithValue("@contactid", ModuleID);
					}
					else
					{
						sqlCommand.Parameters.AddWithValue("@solutionid", ModuleID);
					}
					sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
					sqlCommand.Parameters.AddWithValue("@selectall", "no");
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=17% class=headertext>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Ticket")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Subject", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Ticket Priority", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=navigatorpanel>"));
					plhSubSection.Controls.Add(new LiteralControl(global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), " Create Date", "ticket")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=17% class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Ticket Status", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=navigatorpanel>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), " Ticket Owner", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					this.count = 0;
					while (sqlDataReader.Read() & this.count < 5)
					{
						CustomizePrintableView customizePrintableView = this;
						customizePrintableView.count = customizePrintableView.count + 1;
						if (this.count % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=bgcustomize><td class=normaltext width=1%>&nbsp;"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
						}
						plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["ticketnumber"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["subject"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["ticketpriority"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
						plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["ticketstatus"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["owner"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					}
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0><tr><td class=norecords>No ", this.objBase.ReturnScreenName("TICKETS", 1, "p"), " Added</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}

		public void subsection_ticketHistory_print(PlaceHolder plhSubSection, int ModuleID, int nooftickethistory, string pg, string ticketHistoryProce)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap >", this.objLanguage.convert("Ticket History"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (nooftickethistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(ticketHistoryProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@ticketid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=20% class= navigatorpanel>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				this.rowcount = 0;
				while (sqlDataReader.Read())
				{
					CustomizePrintableView customizePrintableView = this;
					customizePrintableView.rowcount = customizePrintableView.rowcount + 1;
					if (this.rowcount % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows><td class=normaltext >&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext>&nbsp;"));
					}
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["ticketstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("TICKETS", 2, "p"), " History Available.")), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=10 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_ticketSolution_print(PlaceHolder plhSubSection, int ModuleID, int noofsolution, string pg, string ticketSolutionProce)
		{
			if (this.Session["SOLUTIONS"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=HeaderText nowrap=nowrap>", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"))));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				if (noofsolution != 0)
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand(ticketSolutionProce ?? "", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue("@ticketid", ModuleID);
					sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
					sqlCommand.Parameters.AddWithValue("@selectall", "no");
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr class=bgcustomize valign=top><td width=20% class=navigatorpanel>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.ReturnScreenName("SOLUTIONS", 2, "p")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=navigatorpanel>", this.objLanguage.convert("Status"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=navigatorpanel>", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " Title</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td class=navigatorpanel>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Description")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					this.count = 0;
					while (sqlDataReader.Read() & this.count < 5)
					{
						CustomizePrintableView customizePrintableView = this;
						customizePrintableView.count = customizePrintableView.count + 1;
						if (this.count % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows><td class=normaltext nowrap>&nbsp;"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext nowrap>&nbsp;"));
						}
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["solutionnumber"].ToString()));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["solutionstatus"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class=normaltext>", sqlDataReader["solutiontitle"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
						if (sqlDataReader["description"].ToString().Length <= 50)
						{
							plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["description"].ToString()));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["description"].ToString().Substring(0, 50), " ...")));
						}
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
					}
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=bgcustomize><table cellspacing=1 width=100% cellpadding=4 border=0 ><tr><td class=norecords>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " Added.")), "</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}
	}
}