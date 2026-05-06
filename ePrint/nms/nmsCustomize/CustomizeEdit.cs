using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class CustomizeEdit : BaseCustomize
	{
		public static string temp_name;

		public languageClass objLanguage = new languageClass();

		public string strImagepath = global.imagePath();

		public BasePage objpage = new BasePage();

		public string ComType = string.Empty;

		public CustomizeEdit()
		{
		}

		public void edit_customize(string pg, PlaceHolder plhLeadEdit, int sectionID)
		{
			string empty;
			object[] str;
			string[] strArrays;
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
			string str7 = "";
			StringBuilder stringBuilder6 = new StringBuilder();
			string str8 = "";
			StringBuilder stringBuilder7 = new StringBuilder();
			string str9 = "";
			StringBuilder stringBuilder8 = new StringBuilder();
			string empty1 = string.Empty;
			string str10 = "";
			string str11 = "";
			string str12 = "";
			string str13 = "";
			string str14 = "";
			string lower = pg.Trim().ToLower();
			string str15 = lower;
			if (lower != null)
			{
				switch (str15)
				{
					case "lead":
					{
						str10 = "tb_lead";
						str11 = "leadid";
						str12 = "tb_leadcustomizevalue";
						str13 = "leadCustomizeID";
						break;
					}
					case "client":
					{
						str10 = "tb_client";
						str11 = "clientid";
						str12 = "tb_clientcustomizevalue";
						str13 = "clientCustomizeID";
						str14 = "clientname";
						break;
					}
					case "contact":
					{
						str10 = "tb_contact";
						str11 = "contactid";
						str12 = "tb_contactcustomizevalue";
						str13 = "contactcustomizeid";
						str14 = "contactname";
						break;
					}
					case "opportunity":
					{
						str10 = "tb_opportunity";
						str11 = "opportunityid";
						str12 = "tb_opportunitycustomizevalue";
						str13 = "opportunityCustomizeID";
						str14 = "opportunityname";
						break;
					}
					case "campaign":
					{
						str10 = "tb_campaign";
						str11 = "campaignid";
						str12 = "tb_campaigncustomizevalue";
						str13 = "campaigncustomizeid";
						str14 = "campaignname";
						break;
					}
					case "contract":
					{
						str10 = "tb_contract";
						str11 = "contractid";
						str12 = "tb_contractcustomizevalue";
						str13 = "contractCustomizeID";
						str14 = "contractname";
						break;
					}
					case "ticket":
					{
						str10 = "tb_ticket";
						str11 = "ticketid";
						str12 = "tb_ticketcustomizevalue";
						str13 = "ticketCustomizeID";
						str14 = "ticketname";
						break;
					}
					case "asset":
					{
						str10 = "tb_asset";
						str11 = "assetid";
						str12 = "tb_assetcustomizevalue";
						str13 = "assetCustomizeID";
						str14 = "assetname";
						break;
					}
					case "solution":
					{
						str10 = "tb_solution";
						str11 = "solutionid";
						str12 = "tb_solutioncustomizevalue";
						str13 = "solutionCustomizeID";
						str14 = "solutionname";
						break;
					}
					case "product":
					{
						str10 = "tb_product";
						str11 = "productid";
						str12 = "tb_productcustomizevalue";
						str13 = "productCustomizeID";
						str14 = "productname";
						break;
					}
					case "price":
					{
						str10 = "tb_price";
						str11 = "priceid";
						str12 = "tb_pricecustomizevalue";
						str13 = "priceCustomizeID";
						str14 = "pricebookname";
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
		Label3:
			commonClass _commonClass = new commonClass();
			SqlDataReader sqlDataReader = base.SelectCustomizeField(pg, "", 1);
			while (sqlDataReader.Read())
			{
				if (!(sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ispublished") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "solutionnumber") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "ticketnumber"))
				{
					continue;
				}
				if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "d")
				{
					stringBuilder.Append(string.Concat(sqlDataReader["labelname"].ToString(), ","));
					if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "salesperson")
					{
						str = new object[] { " (select cast(customizedValue as nvarchar(4000)) from ", str12, " where ", str13, "=", sqlDataReader["CustomizeID"].ToString(), " and ", str11, "=", sectionID, " and isdelete=0 ) as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
						stringBuilder1.Append(string.Concat(str));
					}
					else
					{
						str = new object[] { " (select cast(isnull(firstname,' ')+' '+isnull(lastname,' ') as nvarchar(4000))  from tb_user where userid =(select cast(customizedValue as nvarchar(4000)) from ", str12, " where ", str13, "=", sqlDataReader["CustomizeID"].ToString(), " and ", str11, "=", sectionID, ") and companyid=", Convert.ToInt32(this.Session["companyID"]), ") as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
						stringBuilder1.Append(string.Concat(str));
					}
					stringBuilder2.Append(string.Concat(sqlDataReader["inputType"].ToString().ToLower().Trim(), ","));
					stringBuilder3.Append(string.Concat(sqlDataReader["maxlength"].ToString().ToLower().Trim(), ","));
					stringBuilder4.Append(string.Concat(sqlDataReader["CustomizeID"].ToString().ToLower().Trim(), ","));
					stringBuilder5.Append(string.Concat(sqlDataReader["isrequired"].ToString().ToLower().Trim(), ","));
					stringBuilder6.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), ","));
					stringBuilder7.Append(string.Concat(sqlDataReader["databasename"].ToString().ToLower().Trim(), ","));
					stringBuilder8.Append(string.Concat(sqlDataReader["optionvalue"].ToString().Trim(), "^"));
				}
				else
				{
					stringBuilder.Append(string.Concat(sqlDataReader["labelname"].ToString(), ","));
					if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "parentclient" && pg.ToLower() == "client")
					{
						str = new object[] { " isnull((select top 1 clientname from ", str10, " where isdelete=0 and clientname in (select parentclient from ", str10, " where isDelete=0 and ", str11, "=", sectionID, " )),'') as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
						stringBuilder1.Append(string.Concat(str));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "contactid" && (pg.ToLower() == "contract" || pg.ToLower() == "asset" || pg.ToLower() == "ticket"))
					{
						strArrays = new string[] { global.databaseUserName(), ".ReturnContactName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "companysignedbyid" && pg.ToLower() == "contract" || sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "assigntouserid" && pg.ToLower() == "lead")
					{
						strArrays = new string[] { global.databaseUserName(), ".returnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "reporttouserid" && (pg.ToLower() == "contract" || pg.ToLower() == "contact" || pg.ToLower() == "product"))
					{
						strArrays = new string[] { global.databaseUserName(), ".ReturnUserName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientid" && (pg.ToLower() == "contract" || pg == "contact"))
					{
						strArrays = new string[] { "isnull((select  clientname from tb_client where isDelete=0 and clientid=", str10, ".clientid),'') as '", sqlDataReader["labelname"].ToString().Replace("'", "''"), "'," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "productid" && (pg == "asset" || pg == "price"))
					{
						strArrays = new string[] { global.databaseUserName(), ".ReturnProductName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "campaignid" && (pg == "lead" || pg == "opportunity"))
					{
						strArrays = new string[] { global.databaseUserName(), ".ReturnCampaignName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					else if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientid") || !(pg == "opportunity") && !(pg == "asset"))
					{
						stringBuilder1.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), " as '", sqlDataReader["labelname"].ToString(), "' ,"));
					}
					else
					{
						strArrays = new string[] { global.databaseUserName(), ".ReturnClientName(", sqlDataReader["databasefieldname"].ToString(), ") as '", sqlDataReader["labelname"].ToString(), "' ," };
						stringBuilder1.Append(string.Concat(strArrays));
					}
					stringBuilder2.Append(string.Concat(sqlDataReader["inputType"].ToString().ToLower().Trim(), ","));
					stringBuilder3.Append(string.Concat(sqlDataReader["maxlength"].ToString().ToLower().Trim(), ","));
					stringBuilder4.Append(string.Concat(sqlDataReader["CustomizeID"].ToString().ToLower().Trim(), ","));
					stringBuilder5.Append(string.Concat(sqlDataReader["isrequired"].ToString().ToLower().Trim(), ","));
					stringBuilder6.Append(string.Concat(sqlDataReader["databasefieldname"].ToString(), ","));
					stringBuilder7.Append(string.Concat(sqlDataReader["databasename"].ToString().ToLower().Trim(), ","));
					stringBuilder8.Append(string.Concat(sqlDataReader["optionvalue"].ToString().ToLower().Trim(), "^"));
				}
			}
			_commonClass.closeConnection();
			_commonClass.Dispose();
			str1 = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
			str2 = stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1);
			str3 = stringBuilder2.ToString().Substring(0, stringBuilder2.ToString().Length - 1);
			str4 = stringBuilder3.ToString().Substring(0, stringBuilder3.ToString().Length - 1);
			str5 = stringBuilder4.ToString().Substring(0, stringBuilder4.ToString().Length - 1);
			str6 = stringBuilder5.ToString().Substring(0, stringBuilder5.ToString().Length - 1);
			str7 = stringBuilder6.ToString().Substring(0, stringBuilder6.ToString().Length - 1);
			str8 = stringBuilder7.ToString().Substring(0, stringBuilder7.ToString().Length - 1);
			str9 = stringBuilder8.ToString().Substring(0, stringBuilder8.ToString().Length - 1);
			str = new object[] { "select ", str2, " from ", str10, " where ", str11, " = ", sectionID };
			str2 = string.Concat(str);
			char[] chrArray = new char[] { ',' };
			string[] strArrays1 = str1.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays2 = str3.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays3 = str4.Split(chrArray);
			chrArray = new char[] { ',' };
			str5.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays4 = str6.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays5 = str7.Split(chrArray);
			chrArray = new char[] { ',' };
			string[] strArrays6 = str8.Split(chrArray);
			chrArray = new char[] { '\u005E' };
			string[] strArrays7 = str9.Split(chrArray);
			sqlDataReader = base.SelectCustomizeField(pg, str2.ToString(), 0);
			int num = 0;
			commonClass _commonClass1 = new commonClass();
			int num1 = 0;
			int num2 = 0;
			SqlDataReader sqlDataReader1 = _commonClass1.displaysetting(pg, int.Parse(this.Session["companyid"].ToString()));
			while (sqlDataReader1.Read())
			{
				num1 = int.Parse(sqlDataReader1["displaytype"].ToString());
				num2 = int.Parse(sqlDataReader1["totalfield"].ToString());
			}
			num2 = (pg != "client" ? num2 - 1 : num2 - 4);
			sqlDataReader1.Close();
			sqlDataReader1.Dispose();
			_commonClass1.closeConnection();
			_commonClass1.Dispose();
			plhLeadEdit.Controls.Add(new LiteralControl("<table cellSpacing=0 cellPadding=0 width=99% align=center border=0><tr><td>"));
			plhLeadEdit.Controls.Add(new LiteralControl("<table cellSpacing=2 cellPadding=2 width=100% align=center border=0>"));
			if (num1 == 1)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=20%></td><td width=30%></td><td width=20%></td><td width=30%></td></tr>"));
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=middle>"));
			}
			else if (num1 == 2)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
			}
			else if (num1 == 3)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
			}
			int num3 = 0;
			string str16 = "";
			string str17 = "";
			string empty2 = string.Empty;
			while (sqlDataReader.Read())
			{
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					if (strArrays5[i].ToString().ToLower().Trim() != "description")
					{
						string str18 = this.objBase.SpecialDecode(sqlDataReader[strArrays1[i].ToString()].ToString());
						RegularExpressionValidator regularExpressionValidator = new RegularExpressionValidator();
						TextBox textBox = new TextBox();
						CompareValidator compareValidator = new CompareValidator();
						if (strArrays5[i].ToString().ToLower() == str14)
						{
							CustomizeEdit.temp_name = str18;
						}
						bool flag = false;
						try
						{
							flag = bool.Parse(sqlDataReader["isNewRow"].ToString());
						}
						catch
						{
						}
						string empty3 = string.Empty;
						string empty4 = string.Empty;
						string str19 = strArrays2[i].ToString().ToLower().Trim();
						str15 = str19;
						if (str19 != null)
						{
							switch (str15)
							{
								case "text":
								{
									if (pg.ToLower().Trim() != "client")
									{
										_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
										base.InputTypeText(str18, pg, plhLeadEdit, strArrays1[i].ToString(), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()), empty3, empty4);
									}
									else
									{
										_commonClass.upper_tr_Settingclient(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num, this.ComType);
										base.InputTypeTextBox(str18, pg, plhLeadEdit, strArrays1[i].ToString(), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()), empty3, empty4, this.ComType);
									}
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "textarea":
								{
									if (strArrays5[i].ToString().ToLower().Trim() != "description")
									{
										_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), true, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
										base.InputTypeTextArea(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
										num++;
										_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
										break;
									}
									else
									{
										num3 = 1;
										str17 = strArrays5[i].ToString().Trim();
										empty2 = strArrays1[i].ToString().Trim();
										break;
									}
								}
								case "select":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									if (strArrays5[i].ToString().ToLower().Trim() == "tax1")
									{
										DropDownList dropDownList = new DropDownList()
										{
											Width = 200,
											CssClass = "normaltext",
											ID = strArrays5[i].ToString().ToLower().Trim()
										};
										SettingsBasePage.Bind_TaxRate(dropDownList, int.Parse(this.Session["companyID"].ToString()), "None");
										for (int j = 0; j < dropDownList.Items.Count; j++)
										{
											if (dropDownList.Items[j].Text.Trim() == str18.Trim())
											{
												dropDownList.SelectedIndex = j;
											}
										}
										plhLeadEdit.Controls.Add(dropDownList);
									}
									else if (strArrays5[i].ToString().ToLower().Trim() == "tax2")
									{
										DropDownList dropDownList1 = new DropDownList()
										{
											Width = 200,
											CssClass = "normaltext",
											ID = strArrays5[i].ToString().ToLower().Trim()
										};
										SettingsBasePage.Bind_TaxRate(dropDownList1, int.Parse(this.Session["companyID"].ToString()), "None");
										for (int k = 0; k < dropDownList1.Items.Count; k++)
										{
											if (dropDownList1.Items[k].Text.Trim() == str18.Trim())
											{
												dropDownList1.SelectedIndex = k;
											}
										}
										plhLeadEdit.Controls.Add(dropDownList1);
									}
									else if (strArrays5[i].ToString().ToLower().Trim() == "accountstatus")
									{
										DropDownList dropDownList2 = new DropDownList()
										{
											Width = 200,
											CssClass = "normaltext",
											ID = strArrays5[i].ToString().ToLower().Trim()
										};
										SettingsBasePage settingsBasePage = new SettingsBasePage();
										settingsBasePage.Bind_Account_Status(dropDownList2, int.Parse(this.Session["companyID"].ToString()), "None");
										for (int l = 0; l < dropDownList2.Items.Count; l++)
										{
											if (dropDownList2.Items[l].Text.Trim() == str18.Trim())
											{
												dropDownList2.SelectedIndex = l;
											}
										}
										plhLeadEdit.Controls.Add(dropDownList2);
									}
									else if (strArrays5[i].ToString().ToLower().Trim() == "salesperson")
									{
										string str20 = this.ComType.ToLower().Trim();
										if (str20 == "customer")
										{
											DropDownList dropDownList3 = new DropDownList()
											{
												Width = 200,
												CssClass = "normaltext",
												ID = strArrays5[i].ToString().ToLower().Trim()
											};
											SettingsBasePage settingsBasePage1 = new SettingsBasePage();
											settingsBasePage1.Bind_User(dropDownList3, int.Parse(this.Session["companyID"].ToString()), "None");
											for (int m = 0; m < dropDownList3.Items.Count; m++)
											{
												if (dropDownList3.Items[m].Text.Trim() == str18.Trim())
												{
													dropDownList3.SelectedIndex = m;
												}
											}
											plhLeadEdit.Controls.Add(dropDownList3);
										}
										else if (!(str20 == "supplier") && str20 == "prospect")
										{
											DropDownList dropDownList4 = new DropDownList()
											{
												Width = 200,
												CssClass = "normaltext",
												ID = strArrays5[i].ToString().ToLower().Trim()
											};
											SettingsBasePage settingsBasePage2 = new SettingsBasePage();
											settingsBasePage2.Bind_User(dropDownList4, int.Parse(this.Session["companyID"].ToString()), "None");
											for (int n = 0; n < dropDownList4.Items.Count; n++)
											{
												if (dropDownList4.Items[n].Text.Trim() == str18.Trim())
												{
													dropDownList4.SelectedIndex = n;
												}
											}
											plhLeadEdit.Controls.Add(dropDownList4);
										}
									}
									else if (!(strArrays5[i].ToString().ToLower().Trim() == "salesperson") || !(this.ComType != "Customer"))
									{
										base.InputTypeSelect(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()), strArrays6[i].ToString().Trim(), strArrays7[i].ToString().Trim());
									}
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "checkbox":
								{
									empty = string.Empty;
									string lower1 = pg.ToLower();
									str15 = lower1;
									if (lower1 == null)
									{
										goto Label1;
									}
									else if (str15 == "lead")
									{
										if (strArrays5[i].ToString().ToLower().Trim() != "isconverted" && strArrays5[i].ToString().ToLower().Trim() != "isread")
										{
											empty = "go";
										}
									}
									else if (str15 != "client")
									{
										if (str15 != "product")
										{
											goto Label1;
										}
										if (strArrays5[i].ToString().ToLower().Trim() != "isdelete")
										{
											empty = "go";
										}
									}
									else if (strArrays5[i].ToString().ToLower().Trim() != "issample" && strArrays5[i].ToString().ToLower().Trim() != "isdelete")
									{
										empty = "go";
									}
								Label4:
									if (empty != "go")
									{
										break;
									}
									if (!(pg == "client") || !(this.ComType == "Supplier") || !(strArrays5[i].ToString().ToLower().Trim() != "defaultinvoiceaddress"))
									{
										if (!(pg == "client") || !(this.ComType == "Customer") || !(strArrays5[i].ToString().ToLower().Trim() != "defaultpurchaseorderaddress"))
										{
											break;
										}
										_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
										base.InputTypeCheckbox(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
										num++;
										_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
										break;
									}
									else
									{
										_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
										base.InputTypeCheckbox(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
										num++;
										_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
										break;
									}
								}
								case "radio button":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeRadioButton(str18, pg, plhLeadEdit, strArrays1[i].ToString(), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()), strArrays7[i].ToString().Trim());
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "heading":
								{
									string empty5 = string.Empty;
									if (num % 2 != 0)
									{
										plhLeadEdit.Controls.Add(new LiteralControl("<td></td></tr><tr valign=top>"));
									}
									if (strArrays5[i].ToString().Trim().ToLower() != "copyaddress")
									{
										empty5 = strArrays1[i].ToString();
									}
									else
									{
										strArrays = new string[] { "<a class=normaltext  href='javascript://' onclick=CopyAdress('", pg.ToString().ToLower().Trim(), "');>", strArrays1[i].ToString(), "</a>" };
										empty5 = string.Concat(strArrays);
									}
									plhLeadEdit.Controls.Add(new LiteralControl("<td class=headertext colspan=2>"));
									plhLeadEdit.Controls.Add(new LiteralControl(this.objLanguage.convert(empty5)));
									plhLeadEdit.Controls.Add(new LiteralControl("</td>"));
									plhLeadEdit.Controls.Add(new LiteralControl("</tr><tr valign=top>"));
									num = 0;
									break;
								}
								case "date":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeDate(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "currency":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeCurrency(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "decimal":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeDecimal(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "number":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeNumber(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "email":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeEmail(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
								case "url":
								{
									_commonClass.upper_tr_Setting(strArrays4[i].ToString().ToLower().Trim(), false, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), num1, flag, num);
									base.InputTypeUrl(str18, pg, plhLeadEdit, this.objLanguage.convert(strArrays1[i].ToString()), strArrays5[i].ToString().Trim(), strArrays4[i].ToString().ToLower().Trim(), int.Parse(strArrays3[i].ToString()));
									num++;
									_commonClass.lower_tr_Setting(plhLeadEdit, num1, flag, num, num2);
									break;
								}
							}
						}
					}
					else
					{
						str16 = this.objBase.SpecialDecode(sqlDataReader[strArrays1[i].ToString()].ToString());
						num3 = 1;
						str17 = strArrays5[i].ToString().Trim();
						empty2 = strArrays1[i].ToString().Trim();
						if (strArrays4[i].ToString().ToLower().Trim() == "true")
						{
							empty1 = "true";
						}
					}
				}
			}
			if (num1 == 1)
			{
				if (num % 2 != 0)
				{
					plhLeadEdit.Controls.Add(new LiteralControl("<td colspan=2></td></tr>"));
				}
				else
				{
					plhLeadEdit.Controls.Add(new LiteralControl("<td colspan=4></td></tr>"));
				}
			}
			else if (num1 == 2)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
			}
			else if (num1 == 3)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
			}
			plhLeadEdit.Controls.Add(new LiteralControl("</table></td></tr>"));
			if (num3 == 1)
			{
				plhLeadEdit.Controls.Add(new LiteralControl("<tr><td><table cellSpacing=5 cellPadding=2 width=100% align=center border=0>"));
				TextBox textBox1 = new TextBox()
				{
					CssClass = "txtbox",
					Width = 620,
					TextMode = TextBoxMode.MultiLine,
					Rows = 8,
					ID = str17,
					Text = str16
				};
				if (num1 == 2)
				{
					plhLeadEdit.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20%>", empty2)));
					if (empty1 == "true")
					{
						plhLeadEdit.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
					}
					plhLeadEdit.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadEdit.Controls.Add(new LiteralControl("<tr valign=top><td width=100%>"));
					plhLeadEdit.Controls.Add(textBox1);
					if (empty1 == "true")
					{
						RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
						plhLeadEdit.Controls.Add(new LiteralControl("<div class=error_top>"));
						requiredFieldValidator.ControlToValidate = str17;
						requiredFieldValidator.CssClass = "error";
						requiredFieldValidator.ErrorMessage = string.Concat(this.objLanguage.convert("Please enter"), " ", this.objLanguage.convert(empty2));
						requiredFieldValidator.Width = 200;
						requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
						requiredFieldValidator.ForeColor = this.objBase.TakeErrorForColors();
						plhLeadEdit.Controls.Add(requiredFieldValidator);
						plhLeadEdit.Controls.Add(new LiteralControl("</div>"));
					}
					plhLeadEdit.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadEdit.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else if (num1 == 1 || num1 == 3)
				{
					plhLeadEdit.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20% style='padding-left:5px'>", empty2)));
					if (empty1 == "true")
					{
						plhLeadEdit.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
					}
					plhLeadEdit.Controls.Add(new LiteralControl("</td><td colspan=3>"));
					plhLeadEdit.Controls.Add(textBox1);
					if (empty1 == "true")
					{
						RequiredFieldValidator requiredFieldValidator1 = new RequiredFieldValidator();
						plhLeadEdit.Controls.Add(new LiteralControl("<div class=error_top>"));
						requiredFieldValidator1.ControlToValidate = str17;
						requiredFieldValidator1.CssClass = "error";
						requiredFieldValidator1.ErrorMessage = string.Concat(this.objLanguage.convert("Please enter"), " ", this.objLanguage.convert(empty2));
						requiredFieldValidator1.Width = 200;
						requiredFieldValidator1.Display = ValidatorDisplay.Dynamic;
						requiredFieldValidator1.ForeColor = this.objBase.TakeErrorForColors();
						plhLeadEdit.Controls.Add(requiredFieldValidator1);
						plhLeadEdit.Controls.Add(new LiteralControl("</div>"));
					}
					plhLeadEdit.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadEdit.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
			}
			plhLeadEdit.Controls.Add(new LiteralControl("</table>"));
			return;
		Label0:
			base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
			goto Label3;
		Label1:
			empty = "go";
			goto Label44;
        Label44:
            string s = "";
		}

		public void Edit_Customize_Client(string pg, PlaceHolder plhLeadEdit, int sectionID, string companyType)
		{
			this.ComType = companyType;
			this.edit_customize(pg, plhLeadEdit, sectionID);
		}
	}
}