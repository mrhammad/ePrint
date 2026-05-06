using nmsCommon;
using nmsLanguage;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class CustomizeDetail : BaseCustomize
	{
		public BasePage objpage = new BasePage();

		public languageClass objLanguage = new languageClass();

		public string strImagepath = global.imagePath();

		public bool isActive = true;

		public string CompanyType = string.Empty;

		private string showIn = string.Empty;

		public CustomizeDetail()
		{
		}

		public CustomizeDetail(string PrintShowIn)
		{
			this.showIn = PrintShowIn;
		}

		public bool Detail_Customize(string pg, PlaceHolder plhLeadDetail, int sectionID, bool IsActive)
		{
			this.Detail_Customize(pg, plhLeadDetail, sectionID);
			IsActive = this.isActive;
			return IsActive;
		}

		public void Detail_Customize(string pg, PlaceHolder plhLeadDetail, int sectionID)
		{
			string[] str;
			object[] objArray;
			string str1 = "";
			StringBuilder stringBuilder = new StringBuilder();
			string str2 = "";
			StringBuilder stringBuilder1 = new StringBuilder();
			string str3 = "";
			StringBuilder stringBuilder2 = new StringBuilder();
			string str4 = "";
			StringBuilder stringBuilder3 = new StringBuilder();
			string str5 = "";
			StringBuilder stringBuilder4 = new StringBuilder();
			string str6 = "";
			StringBuilder stringBuilder5 = new StringBuilder();
			string[] strArrays = new string[50];
			string[] strArrays1 = new string[50];
			string empty = string.Empty;
			string empty1 = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string lower = pg.Trim().ToLower();
			string str7 = lower;
			if (lower != null)
			{
				switch (str7)
				{
					case "lead":
					{
						empty1 = "tb_lead";
						empty2 = "leadid";
						empty3 = "tb_leadcustomizevalue";
						empty4 = "leadcustomizeid";
						break;
					}
					case "client":
					{
						empty1 = "tb_client";
						empty2 = "clientid";
						empty3 = "tb_clientcustomizevalue";
						empty4 = "clientCustomizeID";
						break;
					}
					case "asset":
					{
						empty1 = "tb_asset";
						empty2 = "assetid";
						empty3 = "tb_assetcustomizevalue";
						empty4 = "assetCustomizeID";
						break;
					}
					case "contact":
					{
						empty1 = "tb_contact";
						empty2 = "contactid";
						empty3 = "tb_contactcustomizevalue";
						empty4 = "contactCustomizeID";
						break;
					}
					case "opportunity":
					{
						empty1 = "tb_opportunity";
						empty2 = "opportunityid";
						empty3 = "tb_opportunitycustomizevalue";
						empty4 = "opportunityCustomizeID";
						break;
					}
					case "campaign":
					{
						empty1 = "tb_campaign";
						empty2 = "campaignid";
						empty3 = "tb_campaigncustomizevalue";
						empty4 = "campaignCustomizeID";
						break;
					}
					case "contract":
					{
						empty1 = "tb_contract";
						empty2 = "contractid";
						empty3 = "tb_contractcustomizevalue";
						empty4 = "contractCustomizeID";
						break;
					}
					case "product":
					{
						empty1 = "tb_product";
						empty2 = "productid";
						empty3 = "tb_productcustomizevalue";
						empty4 = "productcustomizeid";
						break;
					}
					case "price":
					{
						empty1 = "tb_price";
						empty2 = "priceid";
						empty3 = "tb_pricecustomizevalue";
						empty4 = "priceCustomizeID";
						break;
					}
					case "ticket":
					{
						empty1 = "tb_ticket";
						empty2 = "ticketid";
						empty3 = "tb_ticketcustomizevalue";
						empty4 = "ticketCustomizeID";
						break;
					}
					case "solution":
					{
						empty1 = "tb_solution";
						empty2 = "solutionid";
						empty3 = "tb_ticketcustomizevalue";
						empty4 = "solutionCustomizeID";
						break;
					}
				}
			}
			commonClass _commonClass = new commonClass();
			SqlDataReader sqlDataReader = base.SelectCustomizeField(pg, "SP", 1);
			int num = 0;
			while (sqlDataReader.Read())
			{
				if (!(sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "copyaddress") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample"))
				{
					if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "modifieddate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
					{
						continue;
					}
					stringBuilder.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), ","));
					stringBuilder1.Append(string.Concat(sqlDataReader["labelname"].ToString(), ","));
					stringBuilder2.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), " as '", sqlDataReader["labelname"].ToString(), "' ,"));
					stringBuilder3.Append(string.Concat(sqlDataReader["inputtype"].ToString(), ","));
					stringBuilder5.Append(string.Concat(sqlDataReader["optionvalue"].ToString().ToLower().Trim(), "^"));
					if (sqlDataReader["isNewRow"].ToString().ToLower().Trim() != "true")
					{
						stringBuilder4.Append("no,");
					}
					else
					{
						stringBuilder4.Append("yes,");
					}
					num++;
				}
				else
				{
					if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "d")
					{
						stringBuilder5.Append(string.Concat(sqlDataReader["optionvalue"].ToString().ToLower().Trim(), "^"));
						stringBuilder.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), ","));
						stringBuilder1.Append(string.Concat(sqlDataReader["labelname"].ToString(), ","));
						if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "salesperson")
						{
							objArray = new object[] { " (select cast(customizedValue as nvarchar(4000)) from ", empty3, " where ", empty4, "=", sqlDataReader["CustomizeID"].ToString(), " and ", empty2, "=", sectionID, " ) as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
							stringBuilder2.Append(string.Concat(objArray));
						}
						else
						{
							objArray = new object[] { " (select cast(isnull(firstname,' ')+' '+isnull(lastname,' ') as nvarchar(4000))  from tb_user where userid =(select cast(customizedValue as nvarchar(4000)) from ", empty3, " where ", empty4, "=", sqlDataReader["CustomizeID"].ToString(), " and ", empty2, "=", sectionID, ") and companyid=", Convert.ToInt32(this.Session["companyID"]), ") as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
							stringBuilder2.Append(string.Concat(objArray));
						}
						stringBuilder3.Append(string.Concat(sqlDataReader["inputtype"].ToString(), ","));
					}
					else
					{
						stringBuilder.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), ","));
						stringBuilder1.Append(string.Concat(sqlDataReader["labelname"].ToString(), ","));
						if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createuserid")
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientid" && (pg == "contact" || pg == "contract" || pg == "asset" || pg == "opportunity" || pg == "product"))
						{
							if (!string.IsNullOrEmpty(this.showIn))
							{
								string[] strArrays2 = new string[] { global.databaseUserName(), ".ReturnClientName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays2));
							}
							else
							{
								string[] strArrays3 = new string[] { global.databaseUserName(), ".ReturnClientLink(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays3));
							}
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "contactid" && (pg == "asset" || pg == "ticket" || pg == "contract"))
						{
							if (!string.IsNullOrEmpty(this.showIn))
							{
								string[] strArrays4 = new string[] { global.databaseUserName(), ".ReturnContactName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays4));
							}
							else
							{
								string[] strArrays5 = new string[] { global.databaseUserName(), ".ReturnContactNameLink(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays5));
							}
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "campaignid" && (pg == "lead" || pg == "opportunity" || pg == "product"))
						{
							if (!string.IsNullOrEmpty(this.showIn))
							{
								string[] strArrays6 = new string[] { global.databaseUserName(), ".ReturnCampaignName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays6));
							}
							else
							{
								string[] strArrays7 = new string[] { global.databaseUserName(), ".ReturnCampaignLink(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays7));
							}
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "productid" && (pg == "asset" || pg == "price"))
						{
							if (!string.IsNullOrEmpty(this.showIn))
							{
								string[] strArrays8 = new string[] { global.databaseUserName(), ".ReturnProductName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays8));
							}
							else
							{
								string[] strArrays9 = new string[] { global.databaseUserName(), ".ReturnProductNameLink(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
								stringBuilder2.Append(string.Concat(strArrays9));
							}
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "reporttouserid" && (pg == "asset" || pg == "contact" || pg == "contract" || pg == "price"))
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "modifyuserid")
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "assigntouserid")
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "assigntogroupid")
						{
							str = new string[] { global.databaseUserName(), ".returnGroupName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ticketownerid")
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						else if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "companysignedbyid") || !(pg == "contract"))
						{
							stringBuilder2.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), " as '", sqlDataReader["labelname"].ToString(), "' ,"));
						}
						else
						{
							str = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
							stringBuilder2.Append(string.Concat(str));
						}
						stringBuilder3.Append(string.Concat(sqlDataReader["inputtype"].ToString(), ","));
						stringBuilder5.Append(string.Concat(sqlDataReader["optionvalue"].ToString().ToLower().Trim(), "^"));
					}
					if (sqlDataReader["isNewRow"].ToString().ToLower().Trim() != "true")
					{
						stringBuilder4.Append("no,");
					}
					else
					{
						stringBuilder4.Append("yes,");
					}
					num++;
				}
			}
			_commonClass.closeConnection();
			_commonClass.Dispose();
			str1 = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
			str2 = stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1);
			str5 = stringBuilder4.ToString().Substring(0, stringBuilder4.ToString().Length - 1);
			str3 = stringBuilder2.ToString().Substring(0, stringBuilder2.ToString().Length - 1);
			if (pg != "contract")
			{
				objArray = new object[] { "select ", str3, " from ", empty1, " where ", empty2, " = ", sectionID };
				str3 = string.Concat(objArray);
			}
			else
			{
				objArray = new object[] { "select ", str3, ",isactivate from ", empty1, " where ", empty2, " = ", sectionID };
				str3 = string.Concat(objArray);
			}
			str4 = stringBuilder3.ToString().Substring(0, stringBuilder3.ToString().Length - 1);
			char[] chrArray = new char[] { ',' };
			string[] strArrays10 = str4.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays11 = str2.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays12 = str1.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays13 = str5.Split(chrArray);
			chrArray = new char[] { '\u005E' };
			string[] strArrays14 = str6.Split(chrArray);
			sqlDataReader = base.SelectCustomizeField(pg, str3, 0);
			int num1 = 0;
			commonClass _commonClass1 = new commonClass();
			int num2 = 0;
			int num3 = num;
			SqlDataReader sqlDataReader1 = _commonClass1.displaysetting(pg, int.Parse(this.Session["companyid"].ToString()));
			while (sqlDataReader1.Read())
			{
				num2 = int.Parse(sqlDataReader1["displaytype"].ToString());
				num3 = int.Parse(sqlDataReader1["totalfield"].ToString());
			}
			num3 = (pg != "client" ? num3 - 1 : num3 - 3);
			sqlDataReader1.Close();
			sqlDataReader1.Dispose();
			_commonClass1.closeConnection();
			_commonClass1.Dispose();
			plhLeadDetail.Controls.Add(new LiteralControl("<table cellSpacing=0 cellPadding=0 width=99% align=center border=0><tr><td>"));
			plhLeadDetail.Controls.Add(new LiteralControl("<table cellSpacing=2 cellPadding=2 width=100% align=center border=0>"));
			if (num2 == 1)
			{
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td width=20%></td><td width=30%></td><td width=20%></td><td width=30%></td></tr>"));
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top>"));
			}
			else if (num2 == 2)
			{
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=top>"));
			}
			else if (num2 == 3)
			{
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
			}
			int num4 = 0;
			string str8 = "";
			string empty5 = string.Empty;
			while (sqlDataReader.Read())
			{
				if (pg == "contract" && sqlDataReader["isactivate"].ToString().ToLower() == "true")
				{
					this.isActive = false;
				}
				for (int i = 0; i < (int)strArrays11.Length; i++)
				{
					string empty6 = string.Empty;
					if (strArrays12[i].ToString().ToLower().Trim() != "description")
					{
						bool flag = false;
						if (strArrays13[i].ToString().Trim().ToLower() == "yes")
						{
							flag = true;
						}
						if (strArrays10[i].ToString().ToLower().Trim() == "heading")
						{
							if (num1 % 2 != 0)
							{
								plhLeadDetail.Controls.Add(new LiteralControl("<td></td></tr><tr valign=top>"));
							}
							plhLeadDetail.Controls.Add(new LiteralControl("<td class=headertext colspan=2>"));
							plhLeadDetail.Controls.Add(new LiteralControl(this.objLanguage.convert(strArrays11[i].ToString())));
							plhLeadDetail.Controls.Add(new LiteralControl("</td>"));
							plhLeadDetail.Controls.Add(new LiteralControl("</tr><tr valign=top>"));
							num1--;
						}
						else if (pg.ToLower() != "client")
						{
							_commonClass.upper_tr_Setting_Indetail(plhLeadDetail, this.objLanguage.convert(strArrays11[i].ToString()), num2, flag, num1);
						}
						else if (this.CompanyType == "Supplier")
						{
							if (strArrays12[i].ToString().ToLower().Trim() != "defaultinvoiceaddress")
							{
								_commonClass.upper_tr_Setting_Indetail_client(plhLeadDetail, this.objLanguage.convert(strArrays11[i].ToString()), num2, flag, num1, this.CompanyType);
							}
							else
							{
								num1--;
							}
						}
						else if (this.CompanyType != "Customer")
						{
							_commonClass.upper_tr_Setting_Indetail_client(plhLeadDetail, this.objLanguage.convert(strArrays11[i].ToString()), num2, flag, num1, this.CompanyType);
						}
						else if (strArrays12[i].ToString().ToLower().Trim() != "defaultpurchaseorderaddress")
						{
							_commonClass.upper_tr_Setting_Indetail_client(plhLeadDetail, this.objLanguage.convert(strArrays11[i].ToString()), num2, flag, num1, this.CompanyType);
						}
						else
						{
							num1--;
						}
						string str9 = "";
						if (strArrays10[i].ToString().ToLower().Trim() == "currency")
						{
							try
							{
								str9 = (pg.ToLower() != "campaign" ? _commonClass.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.Session["companyID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()), Convert.ToDecimal(sqlDataReader[strArrays11[i].ToString()].ToString()), 0, "", false, true, false) : _commonClass.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.Session["companyID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()), Convert.ToDecimal(sqlDataReader[strArrays11[i].ToString()].ToString()), 0, "", false, true, false));
							}
							catch
							{
							}
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "number")
						{
							if (pg.ToLower() == "campaign")
							{
								str9 = _commonClass.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.Session["companyID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()), Convert.ToDecimal(sqlDataReader[strArrays11[i].ToString()].ToString()), 0, "", true, false, false);
							}
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "checkbox")
						{
							str9 = sqlDataReader[strArrays11[i].ToString()].ToString();
							if (this.CompanyType == "Supplier" && strArrays12[i].ToString().ToLower().Trim() == "defaultpurchaseorderaddress")
							{
								str9 = " ";
								empty6 = "false";
							}
							else if (this.CompanyType == "Customer" && strArrays12[i].ToString().ToLower().Trim() == "defaultinvoiceaddress")
							{
								str9 = " ";
								empty6 = "false";
							}
							else if (!(this.CompanyType == "Prospect") || !(strArrays12[i].ToString().ToLower().Trim() == "defaultinvoiceaddress"))
							{
								str9 = (!((str9.Trim().ToLower() == "true") | (str9.Trim().ToLower() == "1")) ? "No" : "Yes");
							}
							else
							{
								str9 = " ";
								empty6 = "false";
							}
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "checkboxlist")
						{
							string str10 = strArrays14[i].ToString().Trim();
							chrArray = new char[] { ',' };
							char[] chrArray1 = chrArray;
							strArrays = str10.Split(chrArray1);
							strArrays1 = sqlDataReader[strArrays11[i].ToString()].ToString().Split(chrArray1);
							ArrayList arrayLists = new ArrayList();
							ArrayList arrayLists1 = new ArrayList();
							for (int j = 0; j < (int)strArrays.Length; j++)
							{
								arrayLists.Add(strArrays[j]);
							}
							for (int k = 0; k < (int)strArrays1.Length; k++)
							{
								arrayLists1.Add(strArrays1[k]);
							}
							for (int l = 0; l < (int)strArrays.Length; l++)
							{
								if (!arrayLists1.Contains(arrayLists[l].ToString()))
								{
									str9 = string.Concat(str9, arrayLists[l].ToString(), "&nbsp&nbsp");
								}
								else
								{
									str7 = str9;
									str = new string[] { str7, arrayLists[l].ToString(), "<img src=", global.imagePath(), "check.gif />&nbsp&nbsp" };
									str9 = string.Concat(str);
								}
							}
						}
						else if (strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "convertdate")
						{
							str9 = (!this.isActive ? _commonClass.Eprint_return_Date_Before_View(sqlDataReader[strArrays11[i].ToString()].ToString(), Convert.ToInt32(this.Session["companyID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()), true) : this.objLanguage.convert("Not Converted"));
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "date" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "createdate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "modifieddate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "lastviewdate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "closedate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "purchasedate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "installdate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "usageenddate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "activateddate" || strArrays12[i].ToString().ToLower().Trim().Replace(" ", "") == "contractenddate")
						{
							str9 = _commonClass.Eprint_return_Date_Before_View(sqlDataReader[strArrays11[i].ToString()].ToString(), Convert.ToInt32(this.Session["companyID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()), true);
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "email")
						{
							str9 = sqlDataReader[strArrays11[i].ToString()].ToString();
							if (str9 != "" && string.IsNullOrEmpty(this.showIn))
							{
								str = new string[] { "<a href='mailto:", str9, "'>", str9, "</a>" };
								str9 = string.Concat(str);
							}
						}
						else if (strArrays10[i].ToString().ToLower().Trim() == "url" || strArrays12[i].ToString().ToLower().Trim() == "website")
						{
							str9 = sqlDataReader[strArrays11[i].ToString()].ToString();
							if (str9 != "" && string.IsNullOrEmpty(this.showIn))
							{
								if (!str9.Contains("http://"))
								{
									str = new string[] { "<a href='http://", str9, "' target='_blank'>", str9, "</a>" };
									str9 = string.Concat(str);
								}
								else
								{
									str = new string[] { "<a href='", str9, "' target='_blank'>", str9, "</a>" };
									str9 = string.Concat(str);
								}
							}
						}
						else
						{
							str9 = this.objBase.SpecialDecode(sqlDataReader[strArrays11[i].ToString()].ToString());
							BaseClass baseClass = new BaseClass();
							try
							{
								str9 = sqlDataReader[strArrays11[i].ToString()].ToString();
								string[] strArrays15 = baseClass.IncrypetHrefValue(str9);
								str = new string[] { "<a href='", strArrays15[0].ToString(), "' target='_blank'>", strArrays15[1].ToString(), "</a>" };
								str9 = string.Concat(str);
							}
							catch
							{
								str9 = this.objBase.SpecialDecode(sqlDataReader[strArrays11[i].ToString()].ToString());
							}
						}
						if (empty6 != "false")
						{
							plhLeadDetail.Controls.Add(new LiteralControl(str9));
							num1++;
							_commonClass.lower_tr_Setting(plhLeadDetail, num2, flag, num1, num3);
						}
						else
						{
							num1--;
						}
					}
					else
					{
						str8 = this.objBase.SpecialDecode(sqlDataReader[strArrays11[i].ToString()].ToString());
						num4 = 1;
						empty5 = strArrays11[i].ToString().Trim();
					}
				}
				if (pg != "campaign")
				{
					if (num2 == 1)
					{
						if (num1 % 2 != 0)
						{
							plhLeadDetail.Controls.Add(new LiteralControl("<td colspan=2></td></tr>"));
						}
						else
						{
							plhLeadDetail.Controls.Add(new LiteralControl("<td colspan=4></td></tr>"));
						}
					}
					else if (num2 == 2)
					{
						plhLeadDetail.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
					}
					else if (num2 == 3)
					{
						plhLeadDetail.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
					}
					plhLeadDetail.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				if (pg != "campaign")
				{
					continue;
				}
				commonClass _commonClass2 = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_campaigndetail_select_calculatedfield", _commonClass2.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("campaignid", sectionID);
				sqlCommand.Parameters.AddWithValue("companyid", int.Parse(this.Session["companyid"].ToString()));
				sqlCommand.Parameters.AddWithValue("userid", int.Parse(this.Session["userid"].ToString()));
				SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
				if (num2 == 1)
				{
					if (num1 % 2 != 0)
					{
						plhLeadDetail.Controls.Add(new LiteralControl("<td colspan=2></td></tr>"));
					}
					else
					{
						plhLeadDetail.Controls.Add(new LiteralControl("<td colspan=4></td></tr>"));
					}
					while (sqlDataReader2.Read())
					{
						plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top>"));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>Total ", this.objBase.ReturnScreenName("LEADS", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", sqlDataReader2["noofleads"].ToString(), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>Converted ", this.objBase.ReturnScreenName("LEADS", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", sqlDataReader2["noofconvertedleads"].ToString(), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl("</tr>"));
						plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top>"));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>Total ", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", sqlDataReader2["totalopportunity"].ToString(), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>Total Won ", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", sqlDataReader2["totalwonopportunity"].ToString(), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl("</tr>"));
						plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top>"));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>Total Value ", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", _commonClass2.returnMyCurrency(sqlDataReader2["totalvalueopportunity"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString())), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left nowrap>Total Value Won ", this.objBase.ReturnScreenName("OPPORTUNITIES", 2, "p"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", _commonClass2.returnMyCurrency(sqlDataReader2["totalvaluewonopportunity"].ToString(), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userid"].ToString())), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl("</tr>"));
						plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top>"));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class='label normaltext' align=left>", this.objLanguage.convert("Total Response"), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<td class=tablerowcolor2>", sqlDataReader2["totalresponse"].ToString(), "</td>")));
						plhLeadDetail.Controls.Add(new LiteralControl("<td colspan=2></td>"));
						plhLeadDetail.Controls.Add(new LiteralControl("</tr>"));
					}
				}
				else if (num2 == 2)
				{
					plhLeadDetail.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
				}
				else if (num2 == 3)
				{
					plhLeadDetail.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
				}
				plhLeadDetail.Controls.Add(new LiteralControl("</table></td></tr>"));
				_commonClass2.closeConnection();
				_commonClass2.Dispose();
			}
			if (num4 == 1)
			{
				if (num2 == 2)
				{
					plhLeadDetail.Controls.Add(new LiteralControl("<tr><td><table cellSpacing=2 cellPadding=0 width=100% align=center border=0>"));
					plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20%>", empty5, "</td></tr>")));
					plhLeadDetail.Controls.Add(new LiteralControl("<tr valign=top><td class=tablerowcolor2>"));
					plhLeadDetail.Controls.Add(new LiteralControl(this.objBase.SpecialDecode(str8)));
					plhLeadDetail.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadDetail.Controls.Add(new LiteralControl("</table></td></tr>"));
					return;
				}
				if (num2 == 1 || num2 == 3)
				{
					plhLeadDetail.Controls.Add(new LiteralControl("<tr><td><table cellSpacing=5 cellPadding=2 width=100% align=center border=0>"));
					plhLeadDetail.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20% height=22px style='padding-left:5px'>", empty5, "</td><td width=80% colspan=3 class=tablerowcolor2>")));
					plhLeadDetail.Controls.Add(new LiteralControl(str8));
					plhLeadDetail.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadDetail.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
			}
		}

		public void Detail_Customize_Client(string pg, PlaceHolder plhLeadDetail, int sectionID, string companytype)
		{
			this.CompanyType = companytype;
			this.Detail_Customize(pg, plhLeadDetail, sectionID);
		}
	}
}