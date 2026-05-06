using nmsCommon;
using nmsLanguage;
using nmsView;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsSearch
{
	public class searchClass : BasePage
	{
		private languageClass objLanguage = new languageClass();

		public searchClass()
		{
		}

		public new string colorCode(int companyId, string pg)
		{
			string str = "";
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_navigationcolor", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				str = sqlDataReader["colorcode"].ToString();
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
			return str;
		}

		public string returnSearchquery(string searchkeyword, int companyId, string pg)
		{
			string str = "";
			string str1 = "";
			string str2 = "";
			string str3 = "";
			string str4 = "";
			string str5 = "";
			string str6 = "";
			string str7 = "";
			string str8 = "";
			string[] strArrays = new string[] { ",", ";", "+", "*", "-" };
			string[] strArrays1 = strArrays;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				searchkeyword = searchkeyword.Replace(strArrays1[i], " ");
			}
			string[] strArrays2 = searchkeyword.Split(new char[] { ' ' });
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_select_searchfield", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				str3 = string.Concat(str3, sqlDataReader["databasefieldname"].ToString(), ",");
				str4 = string.Concat(str4, sqlDataReader["customizeid"].ToString(), ",");
				str5 = string.Concat(str5, sqlDataReader["fieldtype"].ToString(), ",");
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
			str3 = str3.Substring(0, str3.Length - 1);
			str4 = str4.Substring(0, str4.Length - 1);
			str5 = str5.Substring(0, str5.Length - 1);
			string[] strArrays3 = str3.Split(new char[] { ',' });
			string[] strArrays4 = str4.Split(new char[] { ',' });
			string[] strArrays5 = str5.Split(new char[] { ',' });
			string lower = pg.Trim().ToLower();
			string str9 = lower;
			if (lower != null)
			{
				switch (str9)
				{
					case "lead":
					{
						str6 = "leadid";
						str7 = "tb_leadcustomizevalue";
						str8 = "leadcustomizeid";
						break;
					}
					case "client":
					{
						str6 = "clientid";
						str7 = "tb_clientcustomizevalue";
						str8 = "clientcustomizeid";
						break;
					}
					case "contact":
					{
						str6 = "contactid";
						str7 = "tb_contactcustomizevalue";
						str8 = "contactcustomizeid";
						break;
					}
					case "campaign":
					{
						str6 = "campaignid";
						str7 = "tb_campaigncustomizevalue";
						str8 = "campaigncustomizeid";
						break;
					}
					case "solution":
					{
						str6 = "solutionid";
						str7 = "tb_solutioncustomizevalue";
						str8 = "solutioncustomizeid";
						break;
					}
					case "opportunity":
					{
						str6 = "opportunityid";
						str7 = "tb_opportunitycustomizevalue";
						str8 = "opportunitycustomizeid";
						break;
					}
					case "ticket":
					{
						str6 = "ticketid";
						str7 = "tb_ticketcustomizevalue";
						str8 = "ticketcustomizeid";
						break;
					}
					case "forecast":
					{
						str6 = "forecastid";
						str8 = "forecastcustomizeid";
						break;
					}
					case "contract":
					{
						str6 = "contractid";
						str7 = "tb_contractcustomizevalue";
						str8 = "contractcustomizeid";
						break;
					}
					case "asset":
					{
						str6 = "assetid";
						str7 = "tb_assetcustomizevalue";
						str8 = "assetcustomizeid";
						break;
					}
					case "product":
					{
						str6 = "productid";
						str7 = "tb_productcustomizevalue";
						str8 = "productcustomizeid";
						break;
					}
				}
			}
			for (int j = 0; j < (int)strArrays2.Length; j++)
			{
				if (strArrays2[j].Trim().ToLower() != "and" && strArrays2[j].Trim().ToLower() != "or" && strArrays2[j].Trim().ToLower() != "not")
				{
					for (int k = 0; k < (int)strArrays3.Length; k++)
					{
						if (strArrays5[k].Trim().ToLower() == "d")
						{
							object[] objArray = new object[] { str, " (", strArrays3[k], " like '%", strArrays2[j], "%' and isdelete=0 and companyid=", companyId, ") or " };
							str = string.Concat(objArray);
						}
						else if (strArrays5[k].Trim().ToLower() == "e")
						{
							object[] objArray1 = new object[] { " cast(customizedvalue as nvarchar(4000))  like '%", strArrays2[j], "%' and ", str8, "=", strArrays4[k], " and isdelete=0 and companyid=", companyId };
							str1 = string.Concat(objArray1);
							string str10 = str2;
							string[] strArrays6 = new string[] { str10, " ( ", str6, " in (select ", str6, " from ", str7, " where ", str1, " )) or " };
							str2 = string.Concat(strArrays6);
						}
					}
				}
				str = string.Concat(str, str2);
			}
			if (str != "")
			{
				str = string.Concat("(", str.Substring(0, str.Length - 3), ")");
			}
			return str;
		}

		public GridView search_Display(string pg, GridView GridViewclient, SqlDataSource SqlDataSource1, string searchkeyword, int companyId, int userId, int adminRight)
		{
			string str = "";
			string str1 = "";
			commonClass _commonClass = new commonClass();
			BaseView baseView = new BaseView();
			string str2 = baseView.CheckViewRight(pg, adminRight, companyId, userId);
			string str3 = pg;
			string str4 = str3;
			if (str3 != null)
			{
				switch (str4)
				{
					case "client":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "client"), str2.Replace("L.", "tb_client."));
						object[] objArray = new object[] { "select clientid, clientname, clientsite, phone, industryname from tb_client where ", str, " and companyid=", companyId, " and isdelete=0" };
						str1 = string.Concat(objArray);
						break;
					}
					case "lead":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "lead"), str2.Replace("L.", "tb_lead."));
						object[] objArray1 = new object[] { "select leadid, firstname+' '+lastname as name, companyname,title, phone, email,leadstatusname, (select top 1 firstname+' '+lastname from tb_user where tb_user.userid=tb_lead.createuserid )as ownername  from tb_lead where ", str, " and companyid=", companyId, " and isdelete=0" };
						str1 = string.Concat(objArray1);
						break;
					}
					case "contact":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "contact"), str2.Replace("L.", "tb_contact."));
						object[] objArray2 = new object[] { "select contactid, firstname+' '+lastname as name, phone1, email, ", baseView.fieldElement("clientid", companyId, userId, "clientid", "text", ""), " as 'clientName', clientID,(select top 1 clientsite from tb_client where tb_client.clientid=tb_contact.clientid and tb_client.companyid=", companyId, " and tb_client.isdelete = 0) as clientsite from tb_contact where ", str, " and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray2);
						break;
					}
					case "opportunity":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "opportunity"), str2.Replace("L.", "tb_opportunity."));
						object[] objArray3 = new object[] { "select opportunityid, opportunityname, ", global.databaseUserName(), ".return_datetime_before_view(closedate,", companyId, ",", userId, ") as 'closedate',(select top 1 clientname from tb_client where tb_client.clientid=tb_opportunity.clientid) as clientname,clientid,(select top 1 clientsite from tb_client where tb_client.clientid=tb_opportunity.clientid) as clientsite from tb_opportunity where ", str, " and companyid=", companyId, " and isdelete=0" };
						str1 = string.Concat(objArray3);
						break;
					}
					case "campaign":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "campaign"), str2.Replace("L.", "tb_campaign."));
						object[] objArray4 = new object[] { "select campaignid, campaignname, (select top 1 firstname+' '+lastname from tb_user where userid=tb_campaign.createuserid) as ownername from tb_campaign where ", str, " and companyid=", companyId, " and isdelete=0" };
						str1 = string.Concat(objArray4);
						break;
					}
					case "ticket":
					{
						str = this.returnSearchquery(searchkeyword, companyId, "ticket");
						object[] objArray5 = new object[] { "select ticketid,ticketnumber, subject,ticketstatus,", global.databaseUserName(), ".return_datetime_before_view(lastviewdate,", companyId, ",", userId, ") as 'lastviewdate',(select top 1 firstname+' '+lastname from tb_user where userid=tb_ticket.ticketownerid) as ownername from tb_ticket where ", str, " and companyid=", companyId, " and isdelete=0" };
						str1 = string.Concat(objArray5);
						break;
					}
					case "contract":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "contract"), str2.Replace("L.", "tb_contract."));
						object[] objArray6 = new object[] { "select contractid, contractnumber,", baseView.fieldElement("clientid", companyId, userId, "clientid", "text", ""), " as 'clientName', status from tb_contract where ", str, " and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray6);
						break;
					}
					case "asset":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "asset"), str2.Replace("L.", "tb_asset."));
						object[] objArray7 = new object[] { "select assetid, assetname, assetstatus, productid, (select top 1 productname from tb_product where tb_product.productid= tb_asset.productid) as productname ,", global.databaseUserName(), ".return_datetime_before_view(purchasedate,", companyId, ",", userId, ") as 'purchasedate' from tb_asset where ", str, " and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray7);
						break;
					}
					case "product":
					{
						str = string.Concat(this.returnSearchquery(searchkeyword, companyId, "product"), str2.Replace("L.", "tb_product."));
						object[] objArray8 = new object[] { "select productid, productname, productcode,productcategory,isactive from tb_product where ", str, " and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray8);
						break;
					}
					case "task":
					{
						object[] objArray9 = new object[] { "select taskid,subject,contacttype as who,type as what, ", global.databaseUserName(), ".return_datetime_before_view(duedate,", companyId, ",", userId, ") as 'duedate' from tb_task where subject like '%", searchkeyword, "%' and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray9);
						pg = "home";
						break;
					}
					case "event":
					{
						object[] objArray10 = new object[] { "select EventID,Subject,ContactType as who,EventType as what, ", global.databaseUserName(), ".return_datetime_before_view(EventDate,", companyId, ",", userId, ") as 'EventDate' from tb_event where Subject like '%", searchkeyword, "%' and companyid=", companyId, "  and isdelete=0" };
						str1 = string.Concat(objArray10);
						pg = "home";
						break;
					}
				}
			}
			SqlDataSource1.SelectCommand = str1;
			GridViewclient.DataSourceID = SqlDataSource1.ID;
			this.setGridViewProprties(GridViewclient, companyId, pg);
			return GridViewclient;
		}

		public GridView setGridViewProprties(GridView GridViewclient, int companyId, string pg)
		{
			GridViewclient.AutoGenerateColumns = false;
			GridViewclient.PageSize = 5;
			GridViewclient.AllowPaging = true;
			GridViewclient.AllowSorting = true;
			GridViewclient.CellPadding = 4;
			GridViewclient.Width = Unit.Percentage(100);
			GridViewclient.HeaderStyle.BackColor = Color.FromName(this.colorCode(companyId, pg));
			GridViewclient.CssClass = "normalText_GridView";
			GridViewclient.BorderColor = Color.FromName("#5D7B9D");
			GridViewclient.BorderStyle = BorderStyle.Solid;
			GridViewclient.BorderWidth = Unit.Pixel(1);
			GridViewclient.RowStyle.CssClass = "NewTableRows";
			GridViewclient.AlternatingRowStyle.CssClass = "NewAlternative";
			GridViewclient.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
			GridViewclient.PagerSettings.FirstPageImageUrl = string.Concat(global.imagePath(), "icn_firstrecord.gif");
			GridViewclient.PagerSettings.NextPageImageUrl = string.Concat(global.imagePath(), "icn_next_record.gif");
			GridViewclient.PagerSettings.PreviousPageImageUrl = string.Concat(global.imagePath(), "icn_previous_record.gif");
			GridViewclient.PagerSettings.LastPageImageUrl = string.Concat(global.imagePath(), "icn_last_record.gif");
			GridViewclient.PagerSettings.FirstPageText = this.objLanguage.convert("First");
			GridViewclient.PagerSettings.NextPageText = this.objLanguage.convert("Next");
			GridViewclient.PagerSettings.PreviousPageText = this.objLanguage.convert("Previous");
			GridViewclient.PagerSettings.LastPageText = this.objLanguage.convert("Last");
			GridViewclient.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
			GridViewclient.PagerStyle.CssClass = "normalText_GridView";
			GridViewclient.EmptyDataText = this.objLanguage.convert("No record(s) found");
			GridViewclient.EmptyDataRowStyle.Width = Unit.Percentage(100);
			GridViewclient.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
			for (int i = 0; i < GridViewclient.Columns.Count; i++)
			{
				GridViewclient.Columns[i].HeaderText = global.GetScreenName(companyId, GridViewclient.Columns[i].HeaderText, pg.Trim());
			}
			return GridViewclient;
		}
	}
}