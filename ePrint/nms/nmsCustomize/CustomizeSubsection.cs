using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class CustomizeSubsection : BasePage
	{
		private BaseClass objBase = new BaseClass();

		public static string COLOR;

		public string strSitepath = global.sitePath();

		public string strImagepath = global.imagePath();

		public languageClass objLanguage = new languageClass();

		public languageClass objLangClass = new languageClass();

		public commonClass cmn = new commonClass();

		private int noofaddress;

		private int noofclientcontacts;

		public int UserID;

		public int companyID;

		public int mID;

		public int noofdept;

		public string DeptName = string.Empty;

		public string WebStorePath = string.Empty;

		public string SecureDocPath = global.SecureDocPath();

		public string SecureDocFilePath = global.SecureDocFilepath();

		public string SecureSitePath = global.SecureSitePath();

		public string ServerName = ConnectionClass.ServerName;

		static CustomizeSubsection()
		{
			CustomizeSubsection.COLOR = string.Empty;
		}

		public CustomizeSubsection()
		{
		}

		public void addSubSectionLead(PlaceHolder plhSubSection, int ModuleID, string pg, string value1, string value2, string value3, string value4, string CompanyType)
		{
			int num =0;
			int num1 = 0;
			int num2 = 0;
			int count = 0;
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
			this.companyID = int.Parse(this.Session["companyID"].ToString());
			this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
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
			empty1 = "PC_company_activityhistory_select";
			empty2 = "crm_common_select_opportunity";
			str1 = "crm_common_select_attachment";
			str3 = "crm_common_select_contractapproval";
			empty4 = "crm_contract_selecthistory";
			str4 = "crm_opportunity_pricename_select";
			empty5 = "crm_common_select_email";
			empty6 = "crm_solution_select_solutionhistory";
			str6 = "crm_ticket_select_tickethistory";
			empty7 = "crm_common_select_solution";
			string lower = pg.ToLower();
			string str9 = lower;
			if (lower != null)
			{
				switch (str9)
				{
					case "lead":
					{
						empty8 = "crm_lead_select_subsection";
						str8 = "leadID";
						break;
					}
					case "client":
					{
						empty8 = "crm_client_select_subsection";
						str8 = "clientID";
						str5 = "crm_client_select_ticket";
						break;
					}
					case "contact":
					{
						empty8 = "crm_contact_select_subsection";
						str8 = "contactID";
						str5 = "crm_contact_select_ticket";
						break;
					}
					case "opportunity":
					{
						empty8 = "crm_opportunity_select_subsection";
						str8 = "opportunityID";
						break;
					}
					case "campaign":
					{
						empty8 = "crm_campaign_select_subsection";
						str8 = "campaignID";
						break;
					}
					case "product":
					{
						empty8 = "crm_product_select_subsection";
						str8 = "productID";
						break;
					}
					case "price":
					{
						empty8 = "crm_price_select_subsection";
						str8 = "priceID";
						break;
					}
					case "contract":
					{
						empty8 = "crm_contract_select_subsection";
						str8 = "contractID";
						break;
					}
					case "ticket":
					{
						empty8 = "crm_ticket_select_subsection";
						str8 = "ticketID";
						break;
					}
					case "asset":
					{
						empty8 = "crm_asset_select_subsection";
						str8 = "assetID";
						break;
					}
					case "solution":
					{
						empty8 = "crm_solution_select_subsection";
						str8 = "solutionID";
						str5 = "crm_common_select_ticket";
						break;
					}
				}
			}
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand = new SqlCommand(empty8 ?? "", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", this.companyID);
			sqlCommand.Parameters.AddWithValue(string.Concat("@", str8), ModuleID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			plhSubSection.Controls.Add(new LiteralControl("<TABLE cellSpacing=0 cellPadding=1 width=100% border=0>"));
			while (sqlDataReader.Read())
			{
				if (pg.ToLower().Trim() != "product" && pg.ToLower().Trim() != "price" && pg.ToLower().Trim() != "solution")
				{
					num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
					int.Parse(sqlDataReader["noofopenactivities"].ToString());
					DataTable dataTable = CompanyBasePage.company_activityhistory_select(this.companyID, ModuleID, "", "", "", "", "");
					count = dataTable.Rows.Count;
					num3 = int.Parse(sqlDataReader["noofattachment"].ToString());
				}
				string lower1 = pg.ToLower();
				string str10 = lower1;
				if (lower1 != null)
				{
					switch (str10)
					{
						case "lead":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							break;
						}
						case "client":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							int.Parse(sqlDataReader["noofpartner"].ToString());
							num4 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num5 = int.Parse(sqlDataReader["noofticket"].ToString());
							int.Parse(sqlDataReader["noofcontact"].ToString());
							this.noofaddress = int.Parse(sqlDataReader["noofaddress"].ToString());
							this.noofdept = Convert.ToInt32(sqlDataReader["noofdept"].ToString());
							this.noofclientcontacts = int.Parse(sqlDataReader["noofclientcontacts"].ToString());
							break;
						}
						case "asset":
						{
							break;
						}
						case "campaign":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							num4 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num6 = int.Parse(sqlDataReader["noofmarketingemail"].ToString());
							break;
						}
						case "contract":
						{
							num8 = int.Parse(sqlDataReader["noofcontracthistory"].ToString());
							num7 = int.Parse(sqlDataReader["noofapproval"].ToString());
							break;
						}
						case "opportunity":
						{
							num9 = int.Parse(sqlDataReader["noofcontactrole"].ToString());
							num10 = int.Parse(sqlDataReader["noofcompetitor"].ToString());
							num11 = int.Parse(sqlDataReader["noofstagehistory"].ToString());
							num12 = int.Parse(sqlDataReader["noofproduct"].ToString());
							break;
						}
						case "contact":
						{
							num2 = int.Parse(sqlDataReader["noofemail"].ToString());
							num4 = int.Parse(sqlDataReader["noofopportunity"].ToString());
							num5 = int.Parse(sqlDataReader["noofticket"].ToString());
							break;
						}
						case "product":
						{
							num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
							num13 = int.Parse(sqlDataReader["noofproductlist"].ToString());
							break;
						}
						case "price":
						{
							num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
							break;
						}
						case "ticket":
						{
							num16 = int.Parse(sqlDataReader["noofsolution"].ToString());
							num15 = int.Parse(sqlDataReader["nooftickethistory"].ToString());
							break;
						}
						case "solution":
						{
							num1 = int.Parse(sqlDataReader["noofrecords"].ToString());
							num3 = int.Parse(sqlDataReader["noofattachment"].ToString());
							num5 = int.Parse(sqlDataReader["noofticket"].ToString());
							num14 = int.Parse(sqlDataReader["noofsolutionhistory"].ToString());
							break;
						}
						default:
						{
							goto Label0;
						}
					}
				}
				else
				{
					goto Label0;
				}
			Label1:
				string lower2 = sqlDataReader["subsectionname"].ToString().ToLower();
				string str11 = lower2;
				if (lower2 == null)
				{
					continue;
				}
                //if (<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60026b0-3 == null)
                //{
                //    <PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60026b0-3 = new Dictionary<string, int>(21)
                //    {
                //        { "notes", 0 },
                //        { "open activities", 1 },
                //        { "active history", 2 },
                //        { "contacts", 3 },
                //        { "opportunity", 4 },
                //        { "approval request", 5 },
                //        { "ticket", 6 },
                //        { "attachment", 7 },
                //        { "partners", 8 },
                //        { "contract history", 9 },
                //        { "product", 10 },
                //        { "competitors", 11 },
                //        { "contact role", 12 },
                //        { "stage history", 13 },
                //        { "html email", 14 },
                //        { "marketing", 15 },
                //        { "standard price", 16 },
                //        { "price books", 17 },
                //        { "solution history", 18 },
                //        { "ticket history", 19 },
                //        { "solution", 20 }
                //    };
                //}
                //if (!<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60026b0-3.TryGetValue(str11, out num))
                //{
                //    continue;
                //}
				switch (num)
				{
					case 0:
					{
						if (pg.ToLower() == "campaign" || pg.ToLower() == "contact")
						{
							continue;
						}
						this.subsection_activityhistory(plhSubSection);
						this.subsection_customercontacts(plhSubSection, ModuleID, sqlDataReader["navigationcolor"].ToString(), CompanyType);
						this.subsection_dept(plhSubSection, ModuleID, sqlDataReader["navigationcolor"].ToString());
						this.subsection_address(plhSubSection, ModuleID, sqlDataReader["navigationcolor"].ToString());
						continue;
					}
					case 2:
					{
						this.subsection_ActiveHistory(plhSubSection, ModuleID, str8, count, sqlDataReader["navigationcolor"].ToString(), pg, empty1, CompanyType);
						continue;
					}
					case 4:
					{
						this.subsection_Opportunity(plhSubSection, ModuleID, num4, sqlDataReader["navigationcolor"].ToString(), pg, str8, empty2);
						continue;
					}
					case 5:
					{
						this.subsection_ApprovalRequest(plhSubSection, ModuleID, num7, sqlDataReader["navigationcolor"].ToString(), pg, str3);
						continue;
					}
					case 6:
					{
						this.subsection_Ticket(plhSubSection, ModuleID, num5, sqlDataReader["navigationcolor"].ToString(), pg, str8, str5);
						continue;
					}
					case 7:
					{
						this.subsection_Attachments(plhSubSection, ModuleID, num3, sqlDataReader["navigationcolor"].ToString(), pg, str1, CompanyType);
						continue;
					}
					case 9:
					{
						this.subsection_ContractHistory(plhSubSection, ModuleID, num8, sqlDataReader["navigationcolor"].ToString(), pg, empty4);
						continue;
					}
					case 10:
					{
						if (pg.ToLower() != "opportunity")
						{
							if (pg.ToLower() != "price")
							{
								continue;
							}
							this.subsection_PriceProduct(plhSubSection, ModuleID, num1, sqlDataReader["navigationcolor"].ToString(), pg);
							continue;
						}
						else
						{
							this.subsection_Product(plhSubSection, ModuleID, num12, sqlDataReader["navigationcolor"].ToString(), pg, str4);
							continue;
						}
					}
					case 11:
					{
						this.subsection_Competitors(plhSubSection, ModuleID, num10, sqlDataReader["navigationcolor"].ToString(), pg);
						continue;
					}
					case 12:
					{
						this.subsection_ContactRole(plhSubSection, ModuleID, num9, sqlDataReader["navigationcolor"].ToString(), pg);
						continue;
					}
					case 13:
					{
						this.subsection_StageHistory(plhSubSection, ModuleID, num11, sqlDataReader["navigationcolor"].ToString(), pg);
						continue;
					}
					case 14:
					{
						this.subsection_HTMLEmail(plhSubSection, ModuleID, num2, sqlDataReader["navigationcolor"].ToString(), pg, empty5, CompanyType);
						continue;
					}
					case 15:
					{
						this.subsection_Marketing(plhSubSection, ModuleID, num6, sqlDataReader["navigationcolor"].ToString(), pg);
						continue;
					}
					case 16:
					{
						this.subsection_StandardPrice(plhSubSection, ModuleID, num1, sqlDataReader["navigationcolor"].ToString(), pg);
						continue;
					}
					case 17:
					{
						this.subsection_PriceBooks(plhSubSection, ModuleID, num13, sqlDataReader["navigationcolor"].ToString(), pg, num1);
						continue;
					}
					case 18:
					{
						this.subsection_SolutionHistory(plhSubSection, ModuleID, num14, sqlDataReader["navigationcolor"].ToString(), pg, empty6);
						continue;
					}
					case 19:
					{
						this.subsection_ticketHistory(plhSubSection, ModuleID, num15, sqlDataReader["navigationcolor"].ToString(), pg, str6);
						continue;
					}
					case 20:
					{
						this.subsection_ticketSolution(plhSubSection, ModuleID, num16, sqlDataReader["navigationcolor"].ToString(), pg, empty7);
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
			sqlDataReader.Close();
			sqlDataReader.Dispose();
			this.cmn.closeConnection();
			this.cmn.Dispose();
			plhSubSection.Controls.Add(new LiteralControl("</TABLE>"));
			return;
		Label0:
			base.Response.Redirect("error.aspx");
			goto Label11;
        Label11:
            string s = "0";
		}

		public void imgButton_Command(object sender, CommandEventArgs e)
		{
		}

		private void imgdelete_Click(object sender, ImageClickEventArgs e)
		{
			CompanyBasePage companyBasePage = new CompanyBasePage();
			companyBasePage.address_delete(Convert.ToInt32(this.Session["companyid"]), Convert.ToInt32(e.ToString()), Convert.ToInt32(this.Session["userid"]));
		}

		private void imgdeleteHis_Command(object sender, CommandEventArgs e)
		{
			EstimateBasePage.Estimate_Delete(Convert.ToInt32(this.Session["companyid"]), Convert.ToInt64(e.CommandArgument.ToString()));
			QueryString queryString = new QueryString()
			{
				{ "clientid", base.Request.Params["clientid"].ToString() },
				{ "isnew", "2" },
				{ "bypass", "0" },
				{ "type", base.Request.Params["companytype"].ToString() }
			};
			string str = "../client/client_detail.aspx";
			QueryString queryString1 = Encryption.EncryptQueryString(queryString);
			str = string.Concat(str, queryString1.ToString());
			base.Response.Redirect(str);
		}

		public void subsection_ActiveHistory(PlaceHolder plhSubSection, int ModuleID, string ModuleIDName, int noofactivehistory, string navigationcolor, string pg, string activehistoryProce, string CompanyType)
		{
		}

		public void subsection_activityhistory(PlaceHolder plhSubSection)
		{
		}

		public void subsection_address(PlaceHolder plhSubSection, int ModuleID, string navigationcolor)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Additional Address"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New Address&nbsp;")
			};
			hyperLink.Attributes.Add("onclick", "javascript:opencontacts('address','add');");
			hyperLink.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink);
			if (this.noofaddress > 0)
			{
				HyperLink hyperLink1 = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("|&nbsp;View_All")
				};
				hyperLink1.Attributes.Add("onclick", string.Concat("javascript:viewaddress('address','view',", ModuleID, ");"));
				hyperLink1.Attributes.Add("style", "cursor:pointer");
				plhSubSection.Controls.Add(hyperLink1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			if (this.noofaddress > 5)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
				Label label = new Label()
				{
					Text = this.objLanguage.convert(string.Concat(5, " of ", this.noofaddress))
				};
				plhSubSection.Controls.Add(label);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;]&nbsp;</td></tr>"));
			}
			if (this.noofaddress != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("PC_address_select", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@clientId", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=22>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif  height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=50%>&nbsp;", this.objLanguage.convert("Address"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=10% class='bgcustomize navigatorpanel'>&nbsp;", this.objLanguage.convert("Telephone"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=10% class='bgcustomize navigatorpanel' align=center>", this.objLanguage.convert("Delivery"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=10% class='bgcustomize navigatorpanel' align=center>", this.objLanguage.convert("Billing"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=10% class='bgcustomize navigatorpanel' align=center>", this.objLanguage.convert("Post Box"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=9% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td></tr>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=7><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=50% class=normaltext style ='overflow:hidden;white-space:nowrap'>&nbsp;"));
					LinkButton linkButton = new LinkButton();
					AttributeCollection attributes = linkButton.Attributes;
					object[] str = new object[] { "javascript:return editaddress('address','edit',", sqlDataReader["addressid"].ToString(), ",", ModuleID, ");" };
					attributes.Add("onclick", string.Concat(str));
					linkButton.CssClass = "normaltext";
					string[] strArrays = new string[] { sqlDataReader["Address"].ToString(), " ", sqlDataReader["City"].ToString(), " ", sqlDataReader["State"].ToString(), " ", sqlDataReader["CountryName"].ToString() };
					linkButton.Text = string.Concat(strArrays);
					string str1 = linkButton.Text.ToString();
					linkButton.Text = (linkButton.Text.ToString().Length > 85 ? linkButton.Text.ToString().Substring(0, 85) : linkButton.Text.ToString());
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<span title='", str1, "'>")));
					plhSubSection.Controls.Add(linkButton);
					plhSubSection.Controls.Add(new LiteralControl("</span>"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=10% class=normaltext>&nbsp;", sqlDataReader["Telephone"].ToString(), "</td>")));
					HtmlAnchor htmlAnchor = new HtmlAnchor();
					object[] objArray = new object[] { global.sitePath(), "client/address_delete.aspx?clientid=", ModuleID, "&addressid=", sqlDataReader["addressid"].ToString() };
					htmlAnchor.HRef = string.Concat(objArray);
					htmlAnchor.InnerText = "Delete";
					htmlAnchor.Title = "Delete";
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
					System.Web.UI.WebControls.Image image1 = new System.Web.UI.WebControls.Image();
					System.Web.UI.WebControls.Image image2 = new System.Web.UI.WebControls.Image();
					System.Web.UI.WebControls.Image image3 = new System.Web.UI.WebControls.Image();
					System.Web.UI.WebControls.Image image4 = new System.Web.UI.WebControls.Image();
					System.Web.UI.WebControls.Image image5 = new System.Web.UI.WebControls.Image();
					plhSubSection.Controls.Add(new LiteralControl("<td width=10% align=center>"));
					if (sqlDataReader["IsDefaultDeliveryAddress"].ToString().ToLower() == "true")
					{
						image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
						plhSubSection.Controls.Add(image1);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=10% align=center>"));
					if (sqlDataReader["IsDefaultBillingAddress"].ToString().ToLower() == "true")
					{
						image3.ImageUrl = string.Concat(global.imagePath(), "check.gif");
						plhSubSection.Controls.Add(image3);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=10% align=center>"));
					if (sqlDataReader["IsDefaultPostBoxAddress"].ToString().ToLower() == "true")
					{
						image5.ImageUrl = string.Concat(global.imagePath(), "check.gif");
						plhSubSection.Controls.Add(image5);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=9% class=normaltext align=center>"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=white ><table class=border_all cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No address added."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_ApprovalRequest(PlaceHolder plhSubSection, int ModuleID, int noofapproval, string navigationcolor, string pg, string approvalProce)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Approval Requests"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New")
			};
			empty = string.Concat(global.sitePath(), "contract/contract_approval_add.aspx?contractid=", ModuleID);
			hyperLink.NavigateUrl = empty;
			plhSubSection.Controls.Add(hyperLink);
			if (noofapproval > 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				HyperLink hyperLink1 = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("View_All"),
					NavigateUrl = string.Concat(global.sitePath(), "contract/contract_approval_viewall.aspx?contractid=", ModuleID)
				};
				plhSubSection.Controls.Add(hyperLink1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=6% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=17% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Assign To")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=15% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=15% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Status")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=28% nowrap class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Approve/Reject Comment")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=6% class=normaltext>&nbsp;"));
					empty = string.Concat(global.sitePath(), "contract/contract_approval_detail.aspx?approvalid=", sqlDataReader["contractapprovalID"].ToString());
					HyperLink hyperLink2 = new HyperLink()
					{
						Text = this.objLanguage.convert("View"),
						NavigateUrl = empty
					};
					plhSubSection.Controls.Add(hyperLink2);
					if (sqlDataReader["approvalStatus"].ToString().ToLower() == "pending")
					{
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
						empty = string.Concat(global.sitePath(), "contract/contract_approval_edit.aspx?approvalid=", sqlDataReader["contractapprovalID"].ToString(), "&status=a");
						HyperLink hyperLink3 = new HyperLink()
						{
							Text = this.objLanguage.convert("Approve"),
							NavigateUrl = empty
						};
						plhSubSection.Controls.Add(hyperLink3);
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
						empty = string.Concat(global.sitePath(), "contract/contract_approval_edit.aspx?approvalid=", sqlDataReader["contractapprovalID"].ToString(), "&status=r");
						HyperLink hyperLink4 = new HyperLink()
						{
							Text = this.objLanguage.convert("Reject"),
							NavigateUrl = empty
						};
						plhSubSection.Controls.Add(hyperLink4);
					}
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createusername"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["assigntoname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.Eprint_return_Date_Before_View(sqlDataReader["createDate"].ToString(), this.companyID, this.UserID, true)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["approvalStatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=28% class=normaltext>"));
					Label label = new Label()
					{
						CssClass = "normaltext"
					};
					if (sqlDataReader["description"].ToString().Length <= 40)
					{
						label.Text = sqlDataReader["description"].ToString();
						plhSubSection.Controls.Add(label);
					}
					else
					{
						string str = sqlDataReader["description"].ToString().Substring(0, 40);
						label.Text = string.Concat(str, "...");
						plhSubSection.Controls.Add(label);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No approval request found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Attachments(PlaceHolder plhSubSection, int ModuleID, int noofattachment, string navigationcolor, string pg, string attachmentProce, string CompanyType)
		{
			Convert.ToInt32(this.Session["CompanyID"]);
			int num = Convert.ToInt32(this.Session["UserID"].ToString());
			int num1 = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLangClass.GetLanguageConversion("Notes_Attachments"), "&nbsp;&nbsp;[&nbsp;")));
			plhSubSection.Controls.Add(new LiteralControl("<div border=1 id=divattachmentadd class=CenterDiv style=position:absolute;visibility:hidden;>"));
			ControlCollection controls = plhSubSection.Controls;
			object[] objArray = new object[] { "<iframe id=attframe scrolling=no frameborder=0 class=CenterDiv style=display:none;width:448px;height:250px  src=../common/attachment_add.aspx?sectionName=", pg, "&sectionID=", ModuleID, "></iframe>" };
			controls.Add(new LiteralControl(string.Concat(objArray)));
			plhSubSection.Controls.Add(new LiteralControl("</div>"));
			plhSubSection.Controls.Add(new LiteralControl("<div id=divattachmentedit class=CenterDiv style=position:absolute;visibility:hidden;>"));
			plhSubSection.Controls.Add(new LiteralControl("<iframe id=editframe scrolling=no frameborder=0 class=CenterDiv style=display:none;width:450px;height:250px></iframe>"));
			plhSubSection.Controls.Add(new LiteralControl("</div>"));
			LinkButton linkButton = new LinkButton()
			{
				Text = this.objLanguage.convert("New")
			};
			object[] objArray1 = new object[] { "javascript:displayWindowattachmentadd('../common/attachment_add.aspx?sectionName=", pg, "&sectionID=", ModuleID, "'); return false" };
			linkButton.OnClientClick = string.Concat(objArray1);
			plhSubSection.Controls.Add(linkButton);
			if (noofattachment > 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				HyperLink hyperLink = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("View_All")
				};
				object[] objArray2 = new object[] { global.sitePath(), "common/attachment_viewall.aspx?sectionname=", pg, "&sectionid=", ModuleID, "&type=", CompanyType };
				hyperLink.NavigateUrl = string.Concat(objArray2);
				plhSubSection.Controls.Add(hyperLink);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			if (noofattachment > 5)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
				Label label = new Label()
				{
					Text = this.objLanguage.convert(string.Concat(5, " of ", noofattachment))
				};
				plhSubSection.Controls.Add(label);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;]&nbsp;</td></tr>"));
			}
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><div id=dddddd width=100%><table id=tableattachment width=100% cellspacing=0 cellpadding=0 border=0>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class='bgcustomize' align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Note")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=35% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("File Name")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=15% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Modified On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=9% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num1 = 0;
				while (sqlDataReader.Read())
				{
					num1++;
					if (num1 % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext style ='overflow:hidden;white-space:nowrap; border:0px solid red'>&nbsp;"));
					LinkButton linkButton1 = new LinkButton()
					{
						Text = this.objBase.SpecialDecode(sqlDataReader["subject"].ToString())
					};
					string str = this.objBase.SpecialDecode(sqlDataReader["subject"].ToString());
					linkButton1.Text = (linkButton1.Text.ToString().Length > 30 ? linkButton1.Text.ToString().Substring(0, 30) : linkButton1.Text.ToString());
					linkButton1.Attributes.Add("onclick", string.Concat("javascript:displayWindowattachmentedit('", sqlDataReader["attachmentid"].ToString(), "'); return false;"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<span title='", str, "'>")));
					plhSubSection.Controls.Add(linkButton1);
					plhSubSection.Controls.Add(new LiteralControl("</span>"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=35% class=normaltext>&nbsp;"));
					if (sqlDataReader["filename"].ToString().Length <= 100)
					{
						ControlCollection controlCollections = plhSubSection.Controls;
						string[] secureSitePath = new string[] { "<a href=", this.SecureSitePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", sqlDataReader["filename"].ToString(), " target=_blank>", sqlDataReader["filename"].ToString(), "</a>" };
						controlCollections.Add(new LiteralControl(string.Concat(secureSitePath)));
					}
					else
					{
						ControlCollection controls1 = plhSubSection.Controls;
						string[] strArrays = new string[] { "<a href=", this.SecureSitePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", sqlDataReader["filename"].ToString(), " target=_blank>", sqlDataReader["filename"].ToString().Substring(0, 100), "</a>" };
						controls1.Add(new LiteralControl(string.Concat(strArrays)));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.Eprint_return_Date_Before_View(sqlDataReader["createDate"].ToString(), this.companyID, num, true)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.Eprint_return_Date_Before_View(sqlDataReader["modifiedDate"].ToString(), this.companyID, num, true)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=9% align=center>"));
					object[] objArray3 = new object[] { global.sitePath(), "common/attachment_edit.aspx?attachmentid=", sqlDataReader["attachmentid"].ToString(), "&attachment=", pg, "&attachmentsectionid=", ModuleID };
					string.Concat(objArray3);
					HtmlAnchor htmlAnchor = new HtmlAnchor();
					string[] strArrays1 = new string[] { global.sitePath(), "common/attachmentdeletebyajax.aspx?attachmentid=", sqlDataReader["attachmentid"].ToString(), "&attachment=", pg };
					string str1 = string.Concat(strArrays1);
					htmlAnchor.HRef = string.Concat("javascript:ByAjaxattachmentdelete('", str1, "')");
					htmlAnchor.Title = "Delete";
					htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td></tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 bgcolor=#ffffff ><div id=dddddd width=100% ><table class=border_all cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLangClass.GetLanguageConversion("No_Notes_Attachments_Found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Competitors(PlaceHolder plhSubSection, int ModuleID, int noofcompetitor, string navigationcolor, string pg)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Competitors"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New")
			};
			QueryString queryString = new QueryString()
			{
				{ "opportunityid", ModuleID.ToString() }
			};
			string str = "opportunity/competitor_add.aspx";
			QueryString queryString1 = Encryption.EncryptQueryString(queryString);
			str = string.Concat(str, queryString1.ToString());
			empty = string.Concat(global.sitePath(), str);
			hyperLink.NavigateUrl = empty;
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			if (noofcompetitor != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_common_select_competitor", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@opportunityid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=10%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=20%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Competitor Name")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=30%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Strength")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=38%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Weakness")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td  width=1% align=right valign=top class=bgcustomize><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=6 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows >"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10%>&nbsp;"));
					QueryString queryString2 = new QueryString()
					{
						{ "competitorid", sqlDataReader["competitorid"].ToString() },
						{ "opportunityid", ModuleID.ToString() }
					};
					string str1 = "opportunity/competitor_edit.aspx";
					QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
					str1 = string.Concat(str1, queryString3.ToString());
					empty = string.Concat(global.sitePath(), str1);
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = "Edit",
						ToolTip = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(hyperLink1);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "opportunity/competitor_delete.aspx?competitorid=", sqlDataReader["competitorid"].ToString()),
						InnerText = "Delete",
						Title = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext>"));
					empty = string.Concat(global.sitePath(), "opportunity/competitor_details.aspx?competitorid=", sqlDataReader["competitorid"].ToString());
					HyperLink hyperLink2 = new HyperLink();
					if (sqlDataReader["competitorname"].ToString().Length <= 30)
					{
						hyperLink2.Text = sqlDataReader["competitorname"].ToString();
						plhSubSection.Controls.Add(hyperLink2);
					}
					else
					{
						string str2 = sqlDataReader["competitorname"].ToString().Substring(0, 20);
						hyperLink2.Text = string.Concat(str2, "...");
						plhSubSection.Controls.Add(hyperLink2);
					}
					hyperLink2.NavigateUrl = empty;
					hyperLink2.Attributes.Add("onclick", string.Concat("javascript:window.open('", empty, "', 'Competitor','width=600,height=500,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');return false;"));
					plhSubSection.Controls.Add(hyperLink2);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=30% class=normaltext>"));
					if (sqlDataReader["strength"].ToString().Length <= 35)
					{
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["strength"].ToString()));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["strength"].ToString().Substring(0, 35), "...")));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=38% class=normaltext>"));
					if (sqlDataReader["weakness"].ToString().Length <= 60)
					{
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["weakness"].ToString()));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["weakness"].ToString().Substring(0, 60), "...")));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No competitors found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Contact(PlaceHolder plhSubSection, int ModuleID, string ModuleIDName, int noofcontact, string navigationcolor, string pg, string contactsProce)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap >", this.objLanguage.convert(this.objBase.ReturnScreenName("CONTACTS", 1, "p")), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert(string.Concat("New ", this.objBase.ReturnScreenName("CONTACTS", 2, "p")))
			};
			(new QueryString()).Add(ModuleIDName, ModuleID.ToString());
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("| View All1 &nbsp;]</td></tr>"));
			if (noofcontact != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(contactsProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue(string.Concat("@", ModuleIDName), ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=30%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Contact Name", "contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=22%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Phone1", "contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=36% class='bgcustomize navigatorpanel'>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Email", "contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=7 width=100%>"));
				plhSubSection.Controls.Add(new LiteralControl("<table width=100% style='height:500px' cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10%>&nbsp;"));
					QueryString queryString = new QueryString()
					{
						{ "contactid", sqlDataReader["contactid"].ToString() },
						{ "bypass", "2" }
					};
					string str = "contact/contact_edit.aspx";
					QueryString queryString1 = Encryption.EncryptQueryString(queryString);
					str = string.Concat(str, queryString1.ToString());
					empty = string.Concat(global.sitePath(), str);
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = "Edit",
						ToolTip = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
					QueryString queryString2 = new QueryString()
					{
						{ "contactid", sqlDataReader["contactid"].ToString() }
					};
					string str1 = "contact/contact_detail.aspx";
					QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
					str1 = string.Concat(str1, queryString3.ToString());
					empty = string.Concat(global.sitePath(), str1);
					HyperLink hyperLink2 = new HyperLink()
					{
						Text = "Detail",
						ToolTip = "Detail",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "i-view.gif")
					};
					plhSubSection.Controls.Add(hyperLink2);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					ControlCollection controls = plhSubSection.Controls;
					string[] strArrays = new string[] { "<td width=30% class=normaltext><a href=", global.sitePath(), str1, ">", sqlDataReader["firstname"].ToString(), " ", sqlDataReader["lastname"].ToString(), "</a></td>" };
					controls.Add(new LiteralControl(string.Concat(strArrays)));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=22% class=normaltext>", sqlDataReader["phone1"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=36% class=normaltext>", sqlDataReader["email"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("CONTACTS", 1, "p"), " found.")), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_ContactRole(PlaceHolder plhSubSection, int ModuleID, int noofcontactrole, string navigationcolor, string pg)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Role&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New")
			};
			empty = string.Concat(global.sitePath(), "opportunity/contactrole_add.aspx?opportunityid=", ModuleID);
			hyperLink.NavigateUrl = empty;
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			if (noofcontactrole != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_common_select_contactrole", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@opportunityid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=10%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", this.objLanguage.convert("Contact Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Client Name", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Phone1", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=18%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Email", "Contact"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=18%>", this.objLanguage.convert("Role"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=22% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Primary")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=9 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1% nowrap></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10%>&nbsp;"));
					empty = string.Concat(global.sitePath(), "opportunity/contactrole_edit.aspx?opportunityid=", ModuleID);
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = "Edit",
						ToolTip = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(hyperLink1);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "opportunity/contactrole_delete.aspx?contactroleid=", sqlDataReader["contactroleid"].ToString()),
						InnerText = "Delete",
						Title = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=16% class=normaltext>"));
					QueryString queryString = new QueryString()
					{
						{ "contactid", sqlDataReader["contactid"].ToString() },
						{ "isnew", "2" }
					};
					string str = "contact/contact_detail.aspx";
					QueryString queryString1 = Encryption.EncryptQueryString(queryString);
					str = string.Concat(str, queryString1.ToString());
					if (sqlDataReader["contactname"].ToString().Length <= 50)
					{
						ControlCollection controls = plhSubSection.Controls;
						string[] strArrays = new string[] { "<a href=", global.sitePath(), str, ">", sqlDataReader["contactname"].ToString(), "</a>" };
						controls.Add(new LiteralControl(string.Concat(strArrays)));
					}
					else
					{
						ControlCollection controlCollections = plhSubSection.Controls;
						string[] strArrays1 = new string[] { "<a href=", global.sitePath(), str, ">", sqlDataReader["contactname"].ToString().Substring(0, 50), " ...</a>" };
						controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
					}
					QueryString queryString2 = new QueryString()
					{
						{ "clientid", sqlDataReader["clientid"].ToString() },
						{ "isnew", "2" }
					};
					string str1 = "client/client_detail.aspx";
					QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
					str1 = string.Concat(str1, queryString3.ToString());
					try
					{
						plhSubSection.Controls.Add(new LiteralControl("<td width=16% class=normaltext>"));
						if (sqlDataReader["clientname"].ToString().Length <= 50)
						{
							ControlCollection controls1 = plhSubSection.Controls;
							string[] strArrays2 = new string[] { "<a href=", global.sitePath(), str1, ">", sqlDataReader["clientname"].ToString(), "</a>" };
							controls1.Add(new LiteralControl(string.Concat(strArrays2)));
						}
						else
						{
							ControlCollection controlCollections1 = plhSubSection.Controls;
							string[] strArrays3 = new string[] { "<a href=", global.sitePath(), str1, ">", sqlDataReader["clientname"].ToString().Substring(0, 50), " ...</a>" };
							controlCollections1.Add(new LiteralControl(string.Concat(strArrays3)));
						}
					}
					catch
					{
						plhSubSection.Controls.Add(new LiteralControl("<td width=16% class=normaltext></td"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=16% class=normaltext>", sqlDataReader["phone1"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=18% class=normaltext>", sqlDataReader["email"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=18% class=normaltext>", sqlDataReader["role"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=22% class=normaltext>", sqlDataReader["isprimary"].ToString().Replace("True", "Yes").Replace("False", "No"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1% nowrap></td>"));
				}
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>No ", this.objBase.ReturnScreenName("CONTACTS", 2, "l"), " roles available.</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_ContractHistory(PlaceHolder plhSubSection, int ModuleID, int noofcontracthistory, string navigationcolor, string pg, string contractHistroyProce)
		{
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=headertext nowrap=nowrap>", this.objBase.ReturnScreenName("CONTRACTS", 2, "p"), " History</td><td class=subsectiontext width=99%>")));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=58% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=58% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["contractstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No history found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_customercontacts(PlaceHolder plhSubSection, int ModuleID, string navigationcolor, string CompanyType)
		{
			this.WebStorePath = "http://192.168.1.68/WebStore_Eprint/login.aspx";
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Contacts"))));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("&nbsp;[&nbsp;Add a new Contact&nbsp;")
			};
			hyperLink.Attributes.Add("onclick", string.Concat("javascript:addcontact('contact','add',", ModuleID, ");"));
			hyperLink.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("]&nbsp;"));
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
			Label label = new Label()
			{
				Text = this.objLanguage.convert(string.Concat(this.noofclientcontacts))
			};
			plhSubSection.Controls.Add(label);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]&nbsp;"));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23><td colspan=2><table id='imgisdefault' width=100% cellspacing=0 cellpadding=0 border=0 >"));
			if (this.noofclientcontacts != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("PC_client_contacts_select", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@clientId", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "yes");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr height=23 bgcolor=yellow   valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=20%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Name")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=20%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Department")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Email")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=10% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Mobile")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=10% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl("Login"));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=7% style='border:0px solid red' class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Default")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=9% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=8 width=100%>"));
				plhSubSection.Controls.Add(new LiteralControl("<div style='height:100px;overflow-y:scroll;border:1px solid #BDBDBD'><div>"));
				plhSubSection.Controls.Add(new LiteralControl("<table width=100%  cellspacing=0 cellpadding=0 border=0  class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					string str = string.Concat(sqlDataReader["firstname"].ToString(), " ", sqlDataReader["lastname"].ToString());
					plhSubSection.Controls.Add(new LiteralControl("<td style='border:0px solid red' width=1% valign=top align=left>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td style='border:0px solid red' width=21% class=normaltext nowrap=nowrap>&nbsp"));
					HtmlAnchor htmlAnchor = new HtmlAnchor();
					if (str.Length <= 35)
					{
						htmlAnchor.InnerHtml = str;
					}
					else
					{
						htmlAnchor.InnerHtml = string.Concat(str.Substring(0, 35), "...");
					}
					object[] objArray = new object[] { global.sitePath(), "contact/contact_viewdetail.aspx?action=edit&clientid=", ModuleID, "&contactid=", sqlDataReader["contactid"], "&type=", CompanyType };
					htmlAnchor.HRef = string.Concat(objArray);
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=21% style='border:0px solid red' class=normaltext nowrap=nowrap>&nbsp;"));
					if (sqlDataReader["department"].ToString().Length <= 30)
					{
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["department"].ToString()));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["department"].ToString().Substring(0, 30), "...")));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=21% style='border:0px solid red' class=normaltext>&nbsp;", sqlDataReader["Email"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=11% style='border:0px solid red' class=normaltext>&nbsp;", sqlDataReader["mobile"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td width=10% style='border:0px solid red' class=normaltext>&nbsp;"));
					if (sqlDataReader["Email"].ToString() != "" && sqlDataReader["Password"].ToString() != "")
					{
						HtmlAnchor htmlAnchor1 = new HtmlAnchor()
						{
							Title = "Click to login",
							InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "key.gif>")
						};
						AttributeCollection attributes = htmlAnchor1.Attributes;
						string[] webStorePath = new string[] { "javascript:postwith('", this.WebStorePath, "',{b2bemail:'", sqlDataReader["Email"].ToString(), "',b2bpwd:'", sqlDataReader["Password"].ToString(), "'});" };
						attributes.Add("onclick", string.Concat(webStorePath));
						htmlAnchor1.Attributes.Add("style", "cursor:pointer");
						plhSubSection.Controls.Add(htmlAnchor1);
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image()
					{
						ID = string.Concat("IsDefault", sqlDataReader["contactid"].ToString())
					};
					plhSubSection.Controls.Add(new LiteralControl("<td width=7% style='border:0px solid red' align='left' class=normaltext>&nbsp;"));
					if (sqlDataReader["DefaultContact"].ToString() == "True")
					{
						image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
						plhSubSection.Controls.Add(image);
					}
					else if (sqlDataReader["DefaultContact"].ToString() == "False")
					{
						image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
						plhSubSection.Controls.Add(image);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=9% style='border:0px solid red' class=normaltext align=center>"));
					if (sqlDataReader["DefaultContact"].ToString() != "False")
					{
						ControlCollection controls = plhSubSection.Controls;
						object[] str1 = new object[] { "<img id='ImgContact", sqlDataReader["contactid"].ToString(), "' title='Make this Contact as Default for this Company' style='cursor:pointer' src='", global.imagePath(), "1t.gif' onclick=\"javascript:Defaultcontact_click('", image.ClientID, "','Imgdelete", sqlDataReader["contactid"].ToString(), "','ImgContact", sqlDataReader["contactid"].ToString(), "','", sqlDataReader["contactid"].ToString(), "','", ModuleID, "','", this.Session["companyID"].ToString(), "')\"/>" };
						controls.Add(new LiteralControl(string.Concat(str1)));
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					}
					else
					{
						ControlCollection controlCollections = plhSubSection.Controls;
						object[] objArray1 = new object[] { "<img id='ImgContact", sqlDataReader["contactid"].ToString(), "' title='Make this Contact as Default for this Company' style='cursor:pointer'  src='", global.imagePath(), "default-contact.jpg' onclick=\"javascript:Defaultcontact_click('", image.ClientID, "','Imgdelete", sqlDataReader["contactid"].ToString(), "','ImgContact", sqlDataReader["contactid"].ToString(), "','", sqlDataReader["contactid"].ToString(), "','", ModuleID, "','", this.Session["companyID"].ToString(), "')\"/>" };
						controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
						plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					}
					HtmlAnchor htmlAnchor2 = new HtmlAnchor()
					{
						Title = "Edit",
						InnerText = "Edit",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "ico-edit.gif>")
					};
					AttributeCollection attributeCollection = htmlAnchor2.Attributes;
					object[] moduleID = new object[] { "javascript:editcontact('contact','edit',", ModuleID, ",", sqlDataReader["contactid"], ");" };
					attributeCollection.Add("onclick", string.Concat(moduleID));
					htmlAnchor2.Attributes.Add("style", "cursor:pointer");
					plhSubSection.Controls.Add(htmlAnchor2);
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
					HtmlAnchor htmlAnchor3 = new HtmlAnchor();
					object[] objArray2 = new object[] { global.sitePath(), "client/contact_delete.aspx?clientid=", ModuleID, "&contactid=", sqlDataReader["contactid"].ToString() };
					htmlAnchor3.HRef = string.Concat(objArray2);
					htmlAnchor3.InnerText = "Delete";
					htmlAnchor3.Title = "Delete";
					htmlAnchor3.Attributes.Add("style", "cursor:pointer");
					htmlAnchor3.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(htmlAnchor3);
					if (sqlDataReader["DefaultContact"].ToString() != "False")
					{
						string[] strArrays = new string[] { "<img id='Imgdelete", sqlDataReader["contactid"].ToString(), "' border=0 src=", global.imagePath(), "1t.gif>" };
						htmlAnchor3.InnerHtml = string.Concat(strArrays);
					}
					else
					{
						string[] strArrays1 = new string[] { "<img id='Imgdelete", sqlDataReader["contactid"].ToString(), "' border=0  src=", global.imagePath(), "delete.gif>" };
						htmlAnchor3.InnerHtml = string.Concat(strArrays1);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td  width=1% >&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></div></div></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0 class=border_all  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No contacts added."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=20></td></tr>"));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr></table>"));
		}

		public void subsection_dept(PlaceHolder plhSubSection, int ModuleID, string navigationcolor)
		{
			int num = 0;
			string empty = string.Empty;
			string str = string.Empty;
			string empty1 = string.Empty;
			string str1 = string.Empty;
			string empty2 = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Departments"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("Add New Department&nbsp;")
			};
			hyperLink.Attributes.Add("onclick", "javascript:opencontacts('dept','add');");
			hyperLink.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink);
			if (this.noofdept > 0)
			{
				HyperLink hyperLink1 = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("|&nbsp;View_All")
				};
				hyperLink1.Attributes.Add("onclick", "javascript:opencontacts('dept','view');");
				hyperLink1.Attributes.Add("style", "cursor:pointer");
				plhSubSection.Controls.Add(hyperLink1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			if (this.noofdept > 5)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
				Label label = new Label()
				{
					Text = this.objLanguage.convert(string.Concat(5, " of ", this.noofdept))
				};
				plhSubSection.Controls.Add(label);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;]&nbsp;</td></tr>"));
			}
			if (this.noofdept != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("PC_department_getAllDetails", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@UserID", int.Parse(this.Session["UserID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@CustomerID", ModuleID);
				sqlCommand.Parameters.AddWithValue("@DeptID", 0);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=22>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif  height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=25%>&nbsp;", this.objLanguage.convert("Department Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=25% class='bgcustomize navigatorpanel' align=left>&nbsp;", this.objLanguage.convert("Address"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=13% class='bgcustomize navigatorpanel' align=left>", this.objLanguage.convert("City"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=13% class='bgcustomize navigatorpanel' align=left>", this.objLanguage.convert("State"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=14% class='bgcustomize navigatorpanel' align=left>", this.objLanguage.convert("Country"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=10% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td></tr>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=7><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					if (sqlDataReader["AddressType"].ToString().ToLower() == "a")
					{
						str = sqlDataReader["Address"].ToString();
						empty1 = sqlDataReader["City"].ToString();
						str1 = sqlDataReader["State"].ToString();
						empty2 = sqlDataReader["Country"].ToString();
					}
					if (sqlDataReader["AddressType"].ToString().ToLower() == "m")
					{
						str = sqlDataReader["BusinessAddressLine1"].ToString();
						empty1 = sqlDataReader["BusinessAddressLine2"].ToString();
						str1 = string.Concat(sqlDataReader["BusinessAddressLine3"].ToString(), " ", sqlDataReader["BusinessAddressLine4"].ToString());
						empty2 = sqlDataReader["BusinessCountry"].ToString();
					}
					if (sqlDataReader["AddressType"].ToString().ToLower() == "c")
					{
						str = sqlDataReader["AddressLine1"].ToString();
						empty1 = sqlDataReader["AddressLine2"].ToString();
						str1 = string.Concat(sqlDataReader["AddressLine3"].ToString(), " ", sqlDataReader["AddressLine4"].ToString());
						empty2 = sqlDataReader["AddressLine5"].ToString();
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=25% class=normaltext style ='overflow:hidden;white-space:nowrap;'>&nbsp;"));
					LinkButton linkButton = new LinkButton();
					AttributeCollection attributes = linkButton.Attributes;
					object[] objArray = new object[] { "javascript:return editdept('dept','edit',", sqlDataReader["DeptID"].ToString(), ",", ModuleID, ");" };
					attributes.Add("onclick", string.Concat(objArray));
					linkButton.CssClass = "normaltext";
					linkButton.Text = sqlDataReader["DeptName"].ToString();
					this.DeptName = sqlDataReader["DeptName"].ToString();
					string str2 = linkButton.Text.ToString();
					linkButton.Text = (linkButton.Text.ToString().Length > 50 ? linkButton.Text.ToString().Substring(0, 50) : linkButton.Text.ToString());
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<span title='", str2, "'>")));
					plhSubSection.Controls.Add(linkButton);
					plhSubSection.Controls.Add(new LiteralControl("</span>"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=25% class=normaltext style='overflow:hidden;white-space:nowrap;'>&nbsp;"));
					Label label1 = new Label()
					{
						CssClass = "normaltext",
						Text = str
					};
					label1.Text = (label1.Text.ToString().Length > 30 ? label1.Text.ToString().Substring(0, 30) : label1.Text.ToString());
					plhSubSection.Controls.Add(label1);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=13% class=normaltext style='overflow:hidden;white-space:nowrap;'>&nbsp;"));
					Label label2 = new Label()
					{
						CssClass = "normaltext",
						Text = empty1
					};
					label2.Text = (label2.Text.ToString().Length > 20 ? label2.Text.ToString().Substring(0, 20) : label2.Text.ToString());
					plhSubSection.Controls.Add(label2);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=13% class=normaltext style='overflow:hidden;white-space:nowrap;'>&nbsp;"));
					Label label3 = new Label()
					{
						CssClass = "normaltext",
						Text = str1
					};
					label3.Text = (label3.Text.ToString().Length > 20 ? label3.Text.ToString().Substring(0, 20) : label3.Text.ToString());
					plhSubSection.Controls.Add(label3);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=14% class=normaltext style='overflow:hidden;white-space:nowrap;'>&nbsp;"));
					Label label4 = new Label()
					{
						CssClass = "normaltext",
						Text = empty2
					};
					label4.Text = (label4.Text.ToString().Length > 20 ? label4.Text.ToString().Substring(0, 20) : label4.Text.ToString());
					plhSubSection.Controls.Add(label4);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					HtmlAnchor htmlAnchor = new HtmlAnchor();
					object[] objArray1 = new object[] { global.sitePath(), "client/dept_delete.aspx?clientid=", ModuleID, "&DeptID=", sqlDataReader["DeptID"].ToString() };
					htmlAnchor.HRef = string.Concat(objArray1);
					htmlAnchor.InnerText = "Delete";
					htmlAnchor.Title = "Delete";
					htmlAnchor.Attributes.Add("onclick", string.Concat("javascript:return DeleteDept('", this.DeptName, "');"));
					if (this.DeptName.ToLower() != "main")
					{
						htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					}
					else
					{
						htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "nil.gif>");
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=10% class=normaltext align=center style='padding:0px 0px 0px 0px '>"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=white ><table class=border_all cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No departments added."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_HTMLEmail(PlaceHolder plhSubSection, int ModuleID, int noofemail, string navigationcolor, string pg, string HTMLStoredProce, string CompanyType)
		{
			int num = 0;
			string empty = string.Empty;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_all_email_count", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				noofemail = Convert.ToInt32(sqlDataReader["count"].ToString());
			}
			_commonClass.closeConnection();
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2  class=headertext nowrap=nowrap >", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLangClass.GetLanguageConversion("New")
			};
			string companyType = "Customer";
			companyType = CompanyType;
			object[] objArray = new object[] { global.sitePath(), "common/email_send.aspx?sectionid=", ModuleID, "&sectionname=", pg, "&type=", companyType };
			empty = string.Concat(objArray);
			hyperLink.NavigateUrl = empty;
			plhSubSection.Controls.Add(hyperLink);
			if (noofemail > 0)
			{
				HyperLink hyperLink1 = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("View_All")
				};
				object[] objArray1 = new object[] { global.sitePath(), "common/email_viewall.aspx?sectionname=", pg, "&sectionid=", ModuleID, "&type=", companyType };
				hyperLink1.NavigateUrl = string.Concat(objArray1);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				plhSubSection.Controls.Add(hyperLink1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			if (noofemail > 5)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
				Label label = new Label()
				{
					Text = this.objLanguage.convert(string.Concat(5, " of ", noofemail))
				};
				plhSubSection.Controls.Add(label);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;]&nbsp;</td></tr>"));
			}
			if (noofemail != 0)
			{
				commonClass _commonClass1 = new commonClass();
				LinkButton linkButton = new LinkButton();
				SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_all_email_new", _commonClass1.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand1.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand1.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand1.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=20%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("Subject")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=40%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Recipients")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=10%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("# Emails sent")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' align='center' width='20%' style='padding-left:10px;'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("Sent_On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=9% align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=7 width=100%><table cellspacing=0 border=0 cellpadding=0 width=100% class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader1.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td Nowrap=nowrap width=20%>&nbsp;"));
					empty = string.Concat(global.sitePath(), "common/htmlemail_detail.aspx?sl=", sqlDataReader1["sl"].ToString());
					if (sqlDataReader1["subject"].ToString().Length <= 25)
					{
						ControlCollection controls = plhSubSection.Controls;
						string[] str = new string[] { "<a style='cursor:pointer' onclick=javascript:PopupCenter('", empty, "','730','610'); return false;>", sqlDataReader1["subject"].ToString(), "</a>" };
						controls.Add(new LiteralControl(string.Concat(str)));
					}
					else
					{
						ControlCollection controlCollections = plhSubSection.Controls;
						string[] strArrays = new string[] { "<a style='cursor:pointer' onclick=javascript:PopupCenter('", empty, "','730','610'); return false;>", sqlDataReader1["subject"].ToString().Substring(0, 25), "...</a>" };
						controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td >"));
					plhSubSection.Controls.Add(new LiteralControl("<td width='40%' style='overflow:hidden;whitespace:nowrap'>&nbsp;"));
					string str1 = sqlDataReader1["TO"].ToString();
					string str2 = (str1.Length > 55 ? str1.Substring(0, 55) : str1);
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<span title='", str1, "'>")));
					plhSubSection.Controls.Add(new LiteralControl(str2));
					plhSubSection.Controls.Add(new LiteralControl("</span>"));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width='9%' align='right'>&nbsp;"));
					string[] strArrays1 = new string[] { "," };
					string[] strArrays2 = sqlDataReader1["TO"].ToString().Split(strArrays1, StringSplitOptions.RemoveEmptyEntries);
					int length = (int)strArrays2.Length;
					plhSubSection.Controls.Add(new LiteralControl(length.ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td >"));
					plhSubSection.Controls.Add(new LiteralControl("<td width='20%' align='center' style='padding-left:10px'>&nbsp;"));
					string[] strArrays3 = sqlDataReader1["datesent"].ToString().Split(new char[] { ' ' });
					string dateOnRegionalSettings = base.GetDateOnRegionalSettings(Convert.ToInt32(this.Session["CompanyID"].ToString()), strArrays3[0].ToString(), "regional");
					ControlCollection controls1 = plhSubSection.Controls;
					string[] strArrays4 = new string[] { this.cmn.Eprint_return_Date_Before_View(dateOnRegionalSettings, this.companyID, this.UserID, false), " ", strArrays3[1].ToString(), " ", strArrays3[2].ToString() };
					controls1.Add(new LiteralControl(string.Concat(strArrays4)));
					plhSubSection.Controls.Add(new LiteralControl("</td >"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10% align=center>"));
					empty = string.Concat(global.sitePath(), "common/htmlemail_detail.aspx?sl=", sqlDataReader1["sl"].ToString());
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						Title = "Delete",
						HRef = string.Concat(global.sitePath(), "common/email_delete.aspx?sl=", sqlDataReader1["sl"].ToString()),
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader1.Close();
				sqlDataReader1.Dispose();
				_commonClass1.closeConnection();
				_commonClass1.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 bgcolor=#FFFFFF><table class=border_all cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=white ><tr><td class=normaltext>", this.objLanguage.convert("No emails found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Marketing(PlaceHolder plhSubSection, int ModuleID, int noofmarketingemail, string navigationcolor, string pg)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLangClass.GetLanguageConversion("HTML_Email"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New")
			};
			object[] objArray = new object[] { global.sitePath(), "campaign/emailmarketing_add.aspx?sectionid=", ModuleID, "&sectionname=", pg };
			hyperLink.NavigateUrl = string.Concat(objArray);
			plhSubSection.Controls.Add(hyperLink);
			if (noofmarketingemail > 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				HyperLink hyperLink1 = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("View_All")
				};
				object[] objArray1 = new object[] { global.sitePath(), "campaign/emailmarketing_viewall.aspx?sectionname=", pg, "&sectionid=", ModuleID };
				hyperLink1.NavigateUrl = string.Concat(objArray1);
				plhSubSection.Controls.Add(hyperLink1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			if (noofmarketingemail != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_campaign_select_marketing", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=30% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("Subject")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=30% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("Template_Used")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=26% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("Sent_On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td nowrap width=13% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLangClass.GetLanguageConversion("No_Of_Emails")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8  width=100%><table cellspacing=0 cellpadding=0 width=100% border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=5></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=30% nowrap> "));
					ControlCollection controls = plhSubSection.Controls;
					string[] strArrays = new string[] { "<a href='", global.sitePath(), "campaign/emailmarketing_detail.aspx?sectionid=", sqlDataReader["sectionid"].ToString(), "&marketingid=", sqlDataReader["sl"].ToString(), "'>", this.objBase.SpecialDecode(sqlDataReader["subject"].ToString()), "</a>" };
					controls.Add(new LiteralControl(string.Concat(strArrays)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=30% nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["templatename"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=26% nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.Eprint_return_Date_Before_View(sqlDataReader["datesent"].ToString(), this.companyID, this.UserID, true)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=13% nowrap align=center>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["noofemail"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No emails found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Notes(PlaceHolder plhSubSection, int ModuleID, int noofrecords, string sectionname, string subsectionname, string navigationcolor, string pg, string notesStoredProce)
		{
			this.companyID = int.Parse(this.Session["companyID"].ToString());
			this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
			CustomizeSubsection.COLOR = "#D3DEE5";
			string str = "";
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Notes"), "&nbsp;&nbsp;[&nbsp;")));
			LinkButton linkButton = new LinkButton()
			{
				Text = this.objLanguage.convert("New")
			};
			object[] objArray = new object[] { global.sitePath(), "common/notes_add.aspx?notetypeid=", ModuleID, "&noteType=", pg, "&section=", sectionname, "&subsection=", subsectionname };
			string.Concat(objArray);
			linkButton.Attributes.Add("onclick", "javascript:showMe('0','0');return false");
			plhSubSection.Controls.Add(linkButton);
			if (noofrecords > 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				HyperLink hyperLink = new HyperLink()
				{
					Text = this.objLangClass.GetLanguageConversion("View_All")
				};
				object[] objArray1 = new object[] { global.sitePath(), "common/notes_viewall.aspx?notetype=", pg, "&notetypeid=", ModuleID };
				str = string.Concat(objArray1);
				AttributeCollection attributes = hyperLink.Attributes;
				object[] objArray2 = new object[] { "javascript:PopupCenter('", str, "','", 730, "','", 400, "');return false;" };
				attributes.Add("onclick", string.Concat(objArray2));
				hyperLink.Attributes.Add("style", "cursor:pointer");
				plhSubSection.Controls.Add(hyperLink);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			if (noofrecords > 5)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total Records&nbsp;[&nbsp;"));
				Label label = new Label()
				{
					Text = this.objLanguage.convert(string.Concat(5, " of ", noofrecords))
				};
				plhSubSection.Controls.Add(label);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp;]&nbsp;</td></tr>"));
			}
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=55% class='bgcustomize navigatorpanel' align=left>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Description")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=14% align=left class='bgcustomize navigatorpanel' align=left>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created On")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel' align=left>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Created By")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=9% class='bgcustomize navigatorpanel' align=center>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td  width=1% align=right valign=top class=bgcustomize><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top>"));
				plhSubSection.Controls.Add(new LiteralControl("<td colspan=7 width=100%><table cellspacing=0 width=100% border=0 cellpadding=0 class=borderWithoutTop>"));
				string str1 = "";
				num2 = 0;
				while (sqlDataReader.Read())
				{
					num2++;
					if (num2 % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					object[] objArray3 = new object[] { global.sitePath(), "common/notes_edit.aspx?notesid=", sqlDataReader["notesid"].ToString(), "&notetype=", pg, "&notetypeid=", ModuleID };
					string.Concat(objArray3);
					LinkButton linkButton1 = new LinkButton();
					object[] objArray4 = new object[] { global.sitePath(), "common/Notes_Editbyajax.aspx?notesid=", sqlDataReader["notesid"].ToString(), "&notetype=", pg, "&notetypeid=", ModuleID };
					str1 = string.Concat(objArray4);
					num = int.Parse(sqlDataReader["notesid"].ToString());
					linkButton1.OnClientClick = "javascript:showMe('2','0');";
					AttributeCollection attributeCollection = linkButton1.Attributes;
					object[] objArray5 = new object[] { "javascript:ByAjax('", str1, "','", num, "');return false" };
					attributeCollection.Add("onclick", string.Concat(objArray5));
					linkButton1.ToolTip = sqlDataReader["description"].ToString();
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=55% align=left >&nbsp;"));
					linkButton1.Text = _commonClass.replaceLineBreak(this.objBase.dispstr(sqlDataReader["description"].ToString(), 100));
					plhSubSection.Controls.Add(linkButton1);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=14% align=left class=normaltext nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.Eprint_return_Date_Before_View(sqlDataReader["createDate"].ToString(), this.companyID, this.UserID, true)));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% align=left class=normaltext nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["createname"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=9% align=center class=normaltext>"));
					HtmlAnchor htmlAnchor = new HtmlAnchor();
					num1 = int.Parse(sqlDataReader["notesid"].ToString());
					htmlAnchor.HRef = string.Concat(global.sitePath(), "common/notes_delete.aspx?notesid=", num1);
					htmlAnchor.InnerText = "Delete";
					htmlAnchor.Title = "Delete";
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%>&nbsp;</td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0 bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No notes found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_Opportunity(PlaceHolder plhSubSection, int ModuleID, int noofopportunity, string navigationcolor, string pg, string ModuleIDName, string opportunityProce)
		{
			int num = 0;
			string empty = string.Empty;
			try
			{
				if (this.Session["OPPORTUNITIES"] != null && this.Session["OPPORTUNITIES"].ToString().ToLower().Trim() == "true")
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert(this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "p") ?? ""), "&nbsp;&nbsp;[&nbsp;")));
					HyperLink hyperLink = new HyperLink()
					{
						Text = this.objLanguage.convert(string.Concat("New ", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p")))
					};
					QueryString queryString = new QueryString()
					{
						{ ModuleIDName, ModuleID.ToString() }
					};
					string str = "opportunity/opportunity_add.aspx";
					QueryString queryString1 = Encryption.EncryptQueryString(queryString);
					str = string.Concat(str, queryString1.ToString());
					hyperLink.NavigateUrl = string.Concat(global.sitePath(), str);
					plhSubSection.Controls.Add(hyperLink);
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
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
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=10%>&nbsp;"));
						plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=18%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Opportunity Name", "Opportunity"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=18%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Amount", "Opportunity"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=18%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Closed On", "Opportunity"), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=34%>"));
						plhSubSection.Controls.Add(new LiteralControl(global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Opportunity Stage", "Opportunity")));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
						plhSubSection.Controls.Add(new LiteralControl("</tr>"));
						plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=7 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
						num = 0;
						while (sqlDataReader.Read() & num < 5)
						{
							num++;
							if (num % 2 != 0)
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
							}
							else
							{
								plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
							}
							plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
							plhSubSection.Controls.Add(new LiteralControl("<td width=10% class=normaltext nowrap=nowrap>&nbsp;"));
							QueryString queryString2 = new QueryString()
							{
								{ "opportunityid", sqlDataReader["opportunityid"].ToString() },
								{ "isnew", "2" }
							};
							string str1 = "opportunity/opportunity_edit.aspx";
							QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
							str1 = string.Concat(str1, queryString3.ToString());
							empty = string.Concat(global.sitePath(), str1);
							HyperLink hyperLink1 = new HyperLink()
							{
								Text = "Edit",
								ToolTip = "Edit",
								NavigateUrl = empty,
								ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
							};
							plhSubSection.Controls.Add(hyperLink1);
							plhSubSection.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
							QueryString queryString4 = new QueryString()
							{
								{ "opportunityid", sqlDataReader["opportunityid"].ToString() }
							};
							string str2 = "opportunity/opportunity_detail.aspx";
							QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
							str2 = string.Concat(str2, queryString5.ToString());
							empty = string.Concat(global.sitePath(), str2);
							HyperLink hyperLink2 = new HyperLink()
							{
								Text = "Detail",
								ToolTip = "Detail",
								NavigateUrl = empty,
								ImageUrl = string.Concat(global.imagePath(), "i-view.gif")
							};
							plhSubSection.Controls.Add(hyperLink2);
							plhSubSection.Controls.Add(new LiteralControl("</td>"));
							ControlCollection controls = plhSubSection.Controls;
							string[] strArrays = new string[] { "<td width=18% class=normaltext><a href=", global.sitePath(), str2, ">", sqlDataReader["opportunityname"].ToString(), "</a></td>" };
							controls.Add(new LiteralControl(string.Concat(strArrays)));
							commonClass _commonClass1 = new commonClass();
							string str3 = _commonClass1.returnMyCurrency(sqlDataReader["amount"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=18% class=normaltext>", str3, "</td>")));
							commonClass _commonClass2 = new commonClass();
							string str4 = _commonClass2.return_DateTime_Before_View(sqlDataReader["closedate"].ToString(), int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userid"].ToString()));
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=18% class=normaltext>", str4, "</td>")));
							plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=34% class=normaltext>", sqlDataReader["opportunitystagename"].ToString(), "</td>")));
							plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
							plhSubSection.Controls.Add(new LiteralControl("</tr>"));
						}
						plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
						sqlDataReader.Close();
						sqlDataReader.Dispose();
						_commonClass.closeConnection();
						_commonClass.Dispose();
						plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("OPPORTUNITIES", 1, "l"), " found.")), "</td></tr></table></td></tr>")));
					}
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
				}
			}
			catch (InvalidCastException invalidCastException)
			{
			}
		}

		public void subsection_Partners(PlaceHolder plhSubSection, int ModuleID, int noofpartner, string navigationcolor, string pg, string partnersProce)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Partners"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New")
			};
			QueryString queryString = new QueryString()
			{
				{ "clientid", ModuleID.ToString() }
			};
			string str = "client/partner_add.aspx";
			QueryString queryString1 = Encryption.EncryptQueryString(queryString);
			str = string.Concat(str, queryString1.ToString());
			hyperLink.NavigateUrl = string.Concat(global.sitePath(), str);
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=30%>", this.objLanguage.convert("Partner Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=57% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Role"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=5 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10%>&nbsp;"));
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "client/partner_delete.aspx?partnerid=", sqlDataReader["partnerid"].ToString()),
						InnerText = "Delete",
						Title = "Delete"
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=30% class=normaltext>", sqlDataReader["PartnerName"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=48% class=normaltext>", sqlDataReader["Role"].ToString(), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No partners added."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_PriceBooks(PlaceHolder plhSubSection, int ModuleID, int noofproductlist, string navigationcolor, string pg, int noofrecords)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Price Books"), "&nbsp;&nbsp;")));
			if (noofrecords != 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("[&nbsp;"));
				LinkButton linkButton = new LinkButton()
				{
					Text = this.objLanguage.convert("Add to Price Book")
				};
				empty = string.Concat(global.sitePath(), "product/price_view.aspx?productid=", ModuleID);
				linkButton.PostBackUrl = empty;
				plhSubSection.Controls.Add(linkButton);
			}
			if (noofproductlist > 0)
			{
				LinkButton linkButton1 = new LinkButton()
				{
					Text = this.objLanguage.convert("Edit All")
				};
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				object[] objArray = new object[] { global.sitePath(), "product/listprice_edit.aspx?productID=", ModuleID, "&productpriceid=0&type=1" };
				linkButton1.PostBackUrl = string.Concat(objArray);
				plhSubSection.Controls.Add(linkButton1);
			}
			if (noofrecords != 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			}
			if (noofproductlist != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_product_listprice_in_subsection", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@productpriceid", 0);
				sqlCommand.Parameters.AddWithValue("@productid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@type", 1);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top><td width=20% class='bgcustomize navigatorpanel'>&nbsp;")));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("Price Book Name"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("List Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("Use Standard Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Active")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
					}
					object[] objArray1 = new object[] { global.sitePath(), "product/listprice_edit.aspx?productid=", ModuleID, "&productpriceid=", sqlDataReader["productpriceid"].ToString(), "&type=1" };
					empty = string.Concat(objArray1);
					HyperLink hyperLink = new HyperLink()
					{
						Text = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(hyperLink);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "product/listprice_delete.aspx?productpriceid=", sqlDataReader["productpriceid"].ToString()),
						InnerText = "Delete",
						Title = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = sqlDataReader["pricebookname"].ToString(),
						NavigateUrl = string.Concat(global.sitePath(), "product/price_detail.aspx?priceid=", sqlDataReader["priceid"].ToString())
					};
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(hyperLink1);
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
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_PriceProduct(PlaceHolder plhSubSection, int ModuleID, int noofrecords, string navigationcolor, string pg)
		{
			string empty = string.Empty;
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Products"), "&nbsp;&nbsp;[&nbsp;")));
			LinkButton linkButton = new LinkButton()
			{
				Text = this.objLanguage.convert("Add to Product")
			};
			empty = string.Concat(global.sitePath(), "product/product_listprice.aspx?priceid=", ModuleID);
			linkButton.PostBackUrl = empty;
			plhSubSection.Controls.Add(linkButton);
			if (noofrecords > 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
				LinkButton linkButton1 = new LinkButton()
				{
					Text = this.objLanguage.convert("Edit All")
				};
				object[] objArray = new object[] { global.sitePath(), "product/listprice_edit.aspx?productID=", ModuleID, "&productpriceid=0&type=2" };
				linkButton1.PostBackUrl = string.Concat(objArray);
				plhSubSection.Controls.Add(linkButton1);
			}
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			if (noofrecords != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_product_listprice_in_subsection", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@productpriceid", 0);
				sqlCommand.Parameters.AddWithValue("@productid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@type", 2);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top><td width=20% class='bgcustomize navigatorpanel'>&nbsp;")));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Product Name", "Product"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Product Code", "Product"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("List Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Active")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
					}
					QueryString queryString = new QueryString()
					{
						{ "productid", ModuleID.ToString() },
						{ "productpriceid", sqlDataReader["productpriceid"].ToString().ToString() },
						{ "isdirect", "2" }
					};
					string str = "product/listprice_edit.aspx";
					QueryString queryString1 = Encryption.EncryptQueryString(queryString);
					str = string.Concat(str, queryString1.ToString());
					empty = string.Concat(global.sitePath(), str);
					HyperLink hyperLink = new HyperLink()
					{
						Text = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(hyperLink);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "product/listprice_delete.aspx?productpriceid=", sqlDataReader["productpriceid"].ToString()),
						InnerText = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					HyperLink hyperLink1 = new HyperLink()
					{
						Text = sqlDataReader["productname"].ToString()
					};
					QueryString queryString2 = new QueryString()
					{
						{ "productid", sqlDataReader["productid"].ToString() },
						{ "isnew", "2" }
					};
					string str1 = "product/product_detail.aspx";
					QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
					str1 = string.Concat(str1, queryString3.ToString());
					hyperLink1.NavigateUrl = string.Concat(global.sitePath(), str1);
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(hyperLink1);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["productcode"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext nowrap>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader["listprice"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
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
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Product(PlaceHolder plhSubSection, int ModuleID, int noofproduct, string navigationcolor, string pg, string opportunityPriceProce)
		{
			int num = 0;
			string empty = string.Empty;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand(opportunityPriceProce ?? "", _commonClass.openConnection())
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
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert(string.Concat("Products (", setProperty.priceBookName, ")")), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("Add Product")
			};
			if (setProperty.priceID != 0)
			{
				empty = string.Concat(global.sitePath(), "opportunity/opportunity_listprice.aspx?priceid=", setProperty.priceID);
			}
			else
			{
				object[] objArray = new object[] { global.sitePath(), "opportunity/opportunity_pricebook_add.aspx?opportunityid=", ModuleID, "&priceid=", setProperty.priceID };
				empty = string.Concat(objArray);
			}
			hyperLink.NavigateUrl = empty;
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
			HyperLink hyperLink1 = new HyperLink()
			{
				Text = this.objLanguage.convert("Edit All")
			};
			object[] objArray1 = new object[] { global.sitePath(), "opportunity/opportunity_listprice_edit.aspx?opportunityID=", ModuleID, "&priceID=", setProperty.priceID, "&tableID=0" };
			hyperLink1.NavigateUrl = string.Concat(objArray1);
			plhSubSection.Controls.Add(hyperLink1);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
			HyperLink hyperLink2 = new HyperLink()
			{
				Text = this.objLanguage.convert("Choose Price Book")
			};
			object[] objArray2 = new object[] { global.sitePath(), "opportunity/opportunity_pricebook_add.aspx?opportunityid=", ModuleID, "&priceid=", setProperty.priceID };
			hyperLink2.NavigateUrl = string.Concat(objArray2);
			plhSubSection.Controls.Add(hyperLink2);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
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
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top><td width=15% class='bgcustomize navigatorpanel'>&nbsp;")));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=15% class='bgcustomize navigatorpanel'>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Product Name", "Product"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=15% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("Quantity\t"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=15% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("Sales Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=15% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("Date"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=15% class='bgcustomize navigatorpanel'>", this.objLanguage.convert("List Price"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' nowrap=nowrap>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Line Description")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				num = 0;
				while (sqlDataReader1.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
					}
					object[] objArray3 = new object[] { global.sitePath(), "opportunity/opportunity_listprice_edit.aspx?opportunityID=", ModuleID, "&priceID=", setProperty.priceID, "&tableID=", sqlDataReader1["tableID"].ToString() };
					empty = string.Concat(objArray3);
					HyperLink hyperLink3 = new HyperLink()
					{
						Text = "Edit",
						NavigateUrl = empty,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif")
					};
					plhSubSection.Controls.Add(hyperLink3);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "opportunity/product_delete.aspx?productid=", sqlDataReader1["tableID"].ToString()),
						InnerText = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					HyperLink hyperLink4 = new HyperLink()
					{
						Text = sqlDataReader1["productname"].ToString(),
						NavigateUrl = string.Concat(global.sitePath(), "product/product_detail.aspx?productid=", sqlDataReader1["productid"].ToString())
					};
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext>"));
					plhSubSection.Controls.Add(hyperLink4);
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
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_SolutionHistory(PlaceHolder plhSubSection, int ModuleID, int noofsolutionhistory, string navigationcolor, string pg, string solutionHistoryPrice)
		{
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=headertext nowrap=nowrap colspan=2>", this.objLanguage.convert(string.Concat(this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " History")))));
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=58% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table cellspacing=0 cellpadding=0 width=100% class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext width=1%>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=58% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["solutionstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No solution history found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_StageHistory(PlaceHolder plhSubSection, int ModuleID, int noofstagehistory, string navigationcolor, string pg)
		{
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert("Stage History"))));
			plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
			if (noofstagehistory != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_opportunity_select_stagehistory", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@sectionid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@sectionname", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr height=23 bgcolor=", navigationcolor, " valign=top>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=15%>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Stage")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=15% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Next Step")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=15%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Amount")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=15%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Probability")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=15%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Close Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=23% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Last Modified")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=15% nowrap>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["stage"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["nextstep"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.returnMyCurrency(sqlDataReader["amount"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["probablity"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=15% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["closedate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=23% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createdate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No history found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_StandardPrice(PlaceHolder plhSubSection, int ModuleID, int noofrecords, string navigationcolor, string pg)
		{
			int num = 0;
			string empty = string.Empty;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td class=headertext nowrap=nowrap width=1%>", this.objLanguage.convert("Standard Price"), "</td><td class=subsectiontext width=99%>")));
			if (noofrecords != 0)
			{
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_product_standardprice_in_subsection", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@productid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2 bgcolor=gray><table width=100% cellspacing=0 cellpadding=3 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top><td width=20% class='bgcustomize navigatorpanel'>&nbsp;")));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Standard Price")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Active")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=alternatetablerow><td class=normaltext width=1%>&nbsp;"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td class=normaltext width=1%>&nbsp;"));
					}
					empty = string.Concat(global.sitePath(), "Product/standardprice_edit.aspx?standardid=", sqlDataReader["productstandardpriceID"].ToString());
					HyperLink hyperLink = new HyperLink()
					{
						Text = "Edit",
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif"),
						NavigateUrl = empty
					};
					plhSubSection.Controls.Add(hyperLink);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						HRef = string.Concat(global.sitePath(), "product/standardprice_delete.aspx?standardid=", sqlDataReader["productstandardpriceID"].ToString()),
						InnerText = "Delete",
						Title = "Delete",
						InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>")
					};
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
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
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;["));
				LinkButton linkButton = new LinkButton()
				{
					Text = this.objLanguage.convert("New")
				};
				empty = string.Concat(global.sitePath(), "product/standardprice_add.aspx?productid=", ModuleID);
				linkButton.PostBackUrl = empty;
				plhSubSection.Controls.Add(linkButton);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No records to display."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2 height=10></td></tr>"));
		}

		public void subsection_Ticket(PlaceHolder plhSubSection, int ModuleID, int noofticket, string navigationcolor, string pg, string ModuleIDName, string storedProcedure)
		{
			int num = 0;
			if (this.Session["TICKETS"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objBase.ReturnScreenName("TICKETS", 1, "p"))));
				plhSubSection.Controls.Add(new LiteralControl("</td></tr>"));
				if (noofticket != 0)
				{
					commonClass _commonClass = new commonClass();
					SqlCommand sqlCommand = new SqlCommand(storedProcedure ?? "", _commonClass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue(string.Concat("@", ModuleIDName), ModuleID);
					sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
					sqlCommand.Parameters.AddWithValue("@selectall", "no");
					sqlCommand.Parameters.AddWithValue("@userID", int.Parse(this.Session["userID"].ToString()));
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=16%>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert(this.objBase.ReturnScreenName("TICKETS", 2, "p") ?? "")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Subject", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Ticket Priority", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=16%>"));
					plhSubSection.Controls.Add(new LiteralControl(global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), " Create Date", "ticket")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=16%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), "Ticket Status", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=19%>", global.GetScreenName(int.Parse(this.Session["companyID"].ToString()), " Ticket Owner", "ticket"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=9 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
					num = 0;
					while (sqlDataReader.Read() & num < 5)
					{
						num++;
						if (num % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
						}
						plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=16%>&nbsp;"));
						QueryString queryString = new QueryString()
						{
							{ "ticketid", sqlDataReader["ticketid"].ToString() }
						};
						string str = "ticket/ticket_detail.aspx";
						QueryString queryString1 = Encryption.EncryptQueryString(queryString);
						str = string.Concat(str, queryString1.ToString());
						ControlCollection controls = plhSubSection.Controls;
						string[] strArrays = new string[] { "<a href=", global.sitePath(), str, ">", sqlDataReader["ticketnumber"].ToString(), "</a></td>" };
						controls.Add(new LiteralControl(string.Concat(strArrays)));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=16% class=normaltext>", sqlDataReader["subject"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=16% class=normaltext>", sqlDataReader["ticketpriority"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td width=16% class=normaltext>"));
						plhSubSection.Controls.Add(new LiteralControl(_commonClass.return_DateTime_Before_View(sqlDataReader["createdate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=16% class=normaltext>", sqlDataReader["ticketstatus"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=19% class=normaltext>", sqlDataReader["owner"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
						plhSubSection.Controls.Add(new LiteralControl("</tr>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert(string.Concat("No ", this.objBase.ReturnScreenName("TICKETS", 1, "l"), " added.")), "</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}

		public void subsection_ticketHistory(PlaceHolder plhSubSection, int ModuleID, int nooftickethistory, string navigationcolor, string pg, string ticketHistoryProce)
		{
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap >", this.objBase.ReturnScreenName("TICKETS", 2, "p"), " History")));
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
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Date")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("User")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=58% class='bgcustomize navigatorpanel'>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table cellspacing=0 cellpadding=0 width=100% class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read())
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext >&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.cmn.return_DateTime_Before_View(sqlDataReader["createDate"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString()))));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["username"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=58% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["ticketstatus"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("</tr>"));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No tickets history found."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}

		public void subsection_ticketSolution(PlaceHolder plhSubSection, int ModuleID, int noofsolution, string navigationcolor, string pg, string ticketSolutionProce)
		{
			int num = 0;
			if (this.Session["SOLUTIONS"].ToString().ToLower().Trim() == "true")
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap>", this.objLanguage.convert(this.objBase.ReturnScreenName("SOLUTIONS", 2, "p") ?? ""))));
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
				TextBox textBox = new TextBox()
				{
					CssClass = "txtbox",
					ID = "_tb1",
					Width = 150
				};
				plhSubSection.Controls.Add(textBox);
				plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
				Button button = new Button()
				{
					CssClass = "button",
					BackColor = Color.FromName(base.colorCode(this.companyID, pg)),
					Text = this.objLanguage.convert(string.Concat("Find ", this.objBase.ReturnScreenName("SOLUTIONS", 1, "p")))
				};
				QueryString queryString = new QueryString()
				{
					{ "ticketid", ModuleID.ToString() }
				};
				string str = "find_ticketsolution.aspx";
				QueryString queryString1 = Encryption.EncryptQueryString(queryString);
				button.PostBackUrl = string.Concat(str, queryString1.ToString());
				plhSubSection.Controls.Add(button);
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
					plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr bgcolor=", navigationcolor, " valign=top height=23>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize align=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=20%>&nbsp;"));
					plhSubSection.Controls.Add(new LiteralControl(this.objBase.ReturnScreenName("SOLUTIONS", 2, "p")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=20%>", this.objLanguage.convert("Status"), "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=20%>", this.objBase.ReturnScreenName("SOLUTIONS", 2, "p"), " Title</td>")));
					plhSubSection.Controls.Add(new LiteralControl("<td width=38% class='bgcustomize navigatorpanel'>"));
					plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Description")));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize align=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
					plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table cellspacing=0 cellpadding=0 width=100% class=borderWithoutTop>"));
					num = 0;
					while (sqlDataReader.Read() & num < 5)
					{
						num++;
						if (num % 2 != 0)
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
						}
						plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=20% class=normaltext nowrap>&nbsp;"));
						QueryString queryString2 = new QueryString()
						{
							{ "solutionid", sqlDataReader["solutionid"].ToString() }
						};
						string str1 = "solution/solution_detail.aspx";
						QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
						str1 = string.Concat(str1, queryString3.ToString());
						ControlCollection controls = plhSubSection.Controls;
						string[] strArrays = new string[] { "<a href=", global.sitePath(), str1, ">", sqlDataReader["solutionnumber"].ToString(), "</a></td>" };
						controls.Add(new LiteralControl(string.Concat(strArrays)));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=normaltext>", sqlDataReader["solutionstatus"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=20% class=normaltext>", sqlDataReader["solutiontitle"].ToString(), "</td>")));
						plhSubSection.Controls.Add(new LiteralControl("<td width=38% class=normaltext>"));
						if (sqlDataReader["description"].ToString().Length <= 50)
						{
							plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["description"].ToString()));
						}
						else
						{
							plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["description"].ToString().Substring(0, 50), " ...")));
						}
						plhSubSection.Controls.Add(new LiteralControl("</td>"));
						plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					_commonClass.closeConnection();
					_commonClass.Dispose();
					plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else
				{
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No solutions found."), "</td></tr></table></td></tr>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
			}
		}

		public void Subsection_top5Estimate(PlaceHolder plhSubSection, string customername)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2  class=headertext nowrap=nowrap >", this.objLanguage.convert("History"), "&nbsp;&nbsp;&nbsp;")));
			plhSubSection.Controls.Add(new LiteralControl("<tr><td>"));
		}

		public void Subsection_top5invoice(PlaceHolder plhSubSection, string customername)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2  class=headertext nowrap=nowrap >", this.objLanguage.convert("Invoices"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New Invoice&nbsp;|"),
				NavigateUrl = string.Concat(global.sitePath(), "invoice/invoice_add.aspx?type=add")
			};
			hyperLink.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink);
			HyperLink hyperLink1 = new HyperLink()
			{
				Text = this.objLangClass.GetLanguageConversion("&nbsp;View_All"),
				NavigateUrl = string.Concat(global.sitePath(), "Invoice/invoice_view.aspx?custom=", customername)
			};
			hyperLink1.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink1);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			plhSubSection.Controls.Add(new LiteralControl("<tr><td>"));
			plhSubSection.Controls.Add(new LiteralControl("<tr><td>"));
		}

		public void Subsection_top5jobs(PlaceHolder plhSubSection, string customername)
		{
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2  class=headertext nowrap=nowrap >", this.objLanguage.convert("Jobs"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLangClass.GetLanguageConversion("&nbsp;View_All"),
				NavigateUrl = string.Concat(global.sitePath(), "Jobs/jobs_view.aspx?custom=", customername)
			};
			hyperLink.Attributes.Add("style", "cursor:pointer");
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]"));
			plhSubSection.Controls.Add(new LiteralControl("<tr><td>"));
			plhSubSection.Controls.Add(new LiteralControl("<tr><td>"));
		}

		public void subsectionOpenActivity(PlaceHolder plhSubSection, int ModuleID, int noofopenactivities, string sectionname, string subsectionname, string navigationcolor, string pg, string openActiveProce)
		{
			string str;
			string str1 = "";
			int num = 0;
			plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr><td colspan=2 class=headertext nowrap=nowrap >", this.objLanguage.convert("Open Activities"), "&nbsp;&nbsp;[&nbsp;")));
			HyperLink hyperLink = new HyperLink()
			{
				Text = this.objLanguage.convert("New Task")
			};
			HyperLink hyperLink1 = new HyperLink()
			{
				Text = this.objLanguage.convert("New Event")
			};
			object[] objArray = new object[] { global.sitePath(), "common/task_add.aspx?tasktypeid=", ModuleID, "&tasktype=", pg };
			str1 = string.Concat(objArray);
			hyperLink.NavigateUrl = str1;
			plhSubSection.Controls.Add(hyperLink);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
			object[] objArray1 = new object[] { global.sitePath(), "common/event_add.aspx?tasktypeid=", ModuleID, "&tasktype=", pg };
			str1 = string.Concat(objArray1);
			hyperLink1.NavigateUrl = str1;
			plhSubSection.Controls.Add(hyperLink1);
			plhSubSection.Controls.Add(new LiteralControl("&nbsp;]</td></tr>"));
			if (noofopenactivities != 0)
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand(openActiveProce ?? "", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@tasktypeid", ModuleID);
				sqlCommand.Parameters.AddWithValue("@tasktype", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
				sqlCommand.Parameters.AddWithValue("@selectall", "no");
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top><td colspan=2><table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2>"));
				plhSubSection.Controls.Add(new LiteralControl("<tr valign=top height=23>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=5 valign=top class=bgcustomize aligh=left><img src=", this.strImagepath, "lt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td width=9% class='bgcustomize navigatorpanel'>&nbsp;"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Action")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=10%>&nbsp;&nbsp;&nbsp;", this.objLanguage.convert("Section"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=17%>", this.objLangClass.GetLanguageConversion("&nbsp;&nbsp;Subject"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl("<td class='bgcustomize navigatorpanel' width=25%>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Description")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl("<td width=21% class='bgcustomize navigatorpanel' nowrap>"));
				plhSubSection.Controls.Add(new LiteralControl(this.objLanguage.convert("Assign To")));
				plhSubSection.Controls.Add(new LiteralControl("</td>"));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td class='bgcustomize navigatorpanel' width=25%>", this.objLanguage.convert("Due Date"), "</td>")));
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1% valign=top class=bgcustomize aligh=right><img src=", this.strImagepath, "rt_tabnotch.gif width=5 height=5/></td>")));
				plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table width=100% cellspacing=0 cellpadding=0 border=0 class=borderWithoutTop>"));
				num = 0;
				while (sqlDataReader.Read() & num < 5)
				{
					num++;
					if (num % 2 != 0)
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewTableRows>"));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl("<tr valign=top class=NewAlternative>"));
					}
					plhSubSection.Controls.Add(new LiteralControl("<td width=1%></td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td class=normaltext width=10%>"));
					if (sqlDataReader["tasktype"].ToString().ToLower() != "task")
					{
						object[] objArray2 = new object[] { global.sitePath(), "common/event_edit.aspx?eventid=", sqlDataReader["taskid"].ToString(), "&eventtype=", pg, "&eventtypeid=", ModuleID };
						str1 = string.Concat(objArray2);
					}
					else
					{
						object[] objArray3 = new object[] { global.sitePath(), "common/task_edit.aspx?taskid=", sqlDataReader["taskid"].ToString(), "&tasktypeid=", ModuleID, "&tasktype=", pg };
						str1 = string.Concat(objArray3);
					}
					HyperLink hyperLink2 = new HyperLink()
					{
						Text = "Edit",
						NavigateUrl = str1,
						ImageUrl = string.Concat(global.imagePath(), "ico-edit.gif"),
						ToolTip = "Edit"
					};
					plhSubSection.Controls.Add(hyperLink2);
					HtmlAnchor htmlAnchor = new HtmlAnchor()
					{
						Title = "Delete"
					};
					if (sqlDataReader["tasktype"].ToString().ToLower() != "task")
					{
						htmlAnchor.HRef = string.Concat(global.sitePath(), "common/event_delete.aspx?eventid=", sqlDataReader["taskid"].ToString());
					}
					else
					{
						htmlAnchor.HRef = string.Concat(global.sitePath(), "common/task_delete.aspx?taskid=", sqlDataReader["taskid"].ToString());
					}
					htmlAnchor.InnerText = "Delete";
					htmlAnchor.Attributes.Add("onclick", "javascript:return clickDelete();");
					htmlAnchor.InnerHtml = string.Concat("<img border=0 src=", global.imagePath(), "delete.gif>");
					plhSubSection.Controls.Add(new LiteralControl("&nbsp;"));
					plhSubSection.Controls.Add(htmlAnchor);
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=9% class=normaltext>&nbsp;", sqlDataReader["tasktype"].ToString(), "</td>")));
					if (sqlDataReader["tasktype"].ToString().ToLower() != "task")
					{
						object[] objArray4 = new object[] { global.sitePath(), "common/event_detail.aspx?eventid=", sqlDataReader["taskid"].ToString(), "&eventtype=", pg, "&eventtypeid=", ModuleID };
						str1 = string.Concat(objArray4);
					}
					else
					{
						object[] objArray5 = new object[] { global.sitePath(), "common/task_detail.aspx?taskid=", sqlDataReader["taskid"].ToString(), "&tasktypeid=", ModuleID, "&tasktype=", pg };
						str1 = string.Concat(objArray5);
					}
					HyperLink str2 = new HyperLink()
					{
						Text = sqlDataReader["subject"].ToString(),
						ToolTip = sqlDataReader["subject"].ToString(),
						NavigateUrl = str1
					};
					plhSubSection.Controls.Add(new LiteralControl("<td width=17% class=normaltext>&nbsp;&nbsp;"));
					if (sqlDataReader["subject"].ToString().Length <= 30)
					{
						str2.Text = sqlDataReader["subject"].ToString();
						plhSubSection.Controls.Add(str2);
					}
					else
					{
						string str3 = sqlDataReader["subject"].ToString().Substring(0, 20);
						str2.Text = string.Concat(str3, "..");
						plhSubSection.Controls.Add(str2);
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=25% class=normaltext>&nbsp;"));
					if (sqlDataReader["description"].ToString().Length <= 30)
					{
						plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["description"].ToString()));
					}
					else
					{
						plhSubSection.Controls.Add(new LiteralControl(string.Concat(sqlDataReader["description"].ToString().Substring(0, 25), "...")));
					}
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					plhSubSection.Controls.Add(new LiteralControl("<td width=21% class=normaltext>"));
					plhSubSection.Controls.Add(new LiteralControl(sqlDataReader["name1"].ToString()));
					plhSubSection.Controls.Add(new LiteralControl("</td>"));
					commonClass _commonClass1 = new commonClass();
					if (sqlDataReader["tasktype"].ToString().ToLower() != "task")
					{
						object[] objArray6 = new object[] { global.sitePath(), "common/event_detail.aspx?eventid=", sqlDataReader["taskid"].ToString(), "&eventtype=", pg, "&eventtypeid=", ModuleID };
						str1 = string.Concat(objArray6);
						str = _commonClass1.Eprint_return_Date_Before_View(sqlDataReader["duedate"].ToString(), this.companyID, this.UserID, true);
					}
					else
					{
						object[] objArray7 = new object[] { global.sitePath(), "common/task_detail.aspx?taskid=", sqlDataReader["taskid"].ToString(), "&tasktypeid=", ModuleID, "&tasktype=", pg };
						str1 = string.Concat(objArray7);
						str = _commonClass1.Eprint_return_Date_Before_View(sqlDataReader["duedate"].ToString(), this.companyID, this.UserID, true);
					}
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=25% class=normaltext >", str, "</td>")));
					plhSubSection.Controls.Add(new LiteralControl(string.Concat("<td width=1%><img src=", this.strImagepath, "nil.gif    width=12 height=23/></td>")));
				}
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
				sqlDataReader.Close();
				sqlDataReader.Dispose();
				_commonClass.closeConnection();
				_commonClass.Dispose();
				plhSubSection.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			else
			{
				plhSubSection.Controls.Add(new LiteralControl(string.Concat("<tr ><td colspan=2 bgcolor=#5D7B9D ><table cellspacing=1 width=100% cellpadding=4 border=0  bgcolor=white><tr><td class=normaltext>", this.objLanguage.convert("No open activities."), "</td></tr></table></td></tr>")));
			}
			plhSubSection.Controls.Add(new LiteralControl("<tr><td colspan=2><IMG height=20 alt='' src='<%=strImagepath%>nil.gif' width=1 border=0></td></tr>"));
		}
	}
}