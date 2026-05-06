using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class Customize : BaseCustomize
	{
		public BaseClass objBase = new BaseClass();

		public BasePage objpage = new BasePage();

		public string CompanyType = string.Empty;

		public int UserID;

		public int CompanyID;

		private commonClass cmn = new commonClass();

		public Customize()
		{
		}

		public void _AddCompany(string pg, PlaceHolder plhLeadAdd, string clientName, string campaignName, string companytype)
		{
			this.CompanyType = companytype;
			this._AddCustomize(pg, plhLeadAdd, clientName, campaignName);
		}

		public void _AddCustomize(string pg, PlaceHolder plhLeadAdd, string clientName, string campaignName)
		{
			int num =0;
			this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
			this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("[crm_common_select_customizefield_new]", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num1 = 0;
			string empty = string.Empty;
			commonClass _commonClass1 = new commonClass();
			int num2 = 0;
			int num3 = 0;
			SqlDataReader sqlDataReader1 = _commonClass1.displaysetting(pg, int.Parse(this.Session["companyid"].ToString()));
			while (sqlDataReader1.Read())
			{
				num2 = int.Parse(sqlDataReader1["displaytype"].ToString());
				num3 = int.Parse(sqlDataReader1["totalfield"].ToString());
			}
			num3 = (pg != "client" ? num3 : num3 - 5);
			sqlDataReader1.Close();
			_commonClass1.closeConnection();
			plhLeadAdd.Controls.Add(new LiteralControl("<table cellSpacing=0 cellPadding=0 width=99% align=center border=0 ><tr><td>"));
			plhLeadAdd.Controls.Add(new LiteralControl("<table cellSpacing=2 cellPadding=2 width=100% align=center border=0>"));
			if (num2 == 1)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=20%></td><td width=30%></td><td width=20%></td><td width=30%></td></tr>"));
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=middle>"));
			}
			else if (num2 == 2)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
			}
			else if (num2 == 3)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=50%></td><td width=50%></td></tr>"));
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=50%><table width=100% cellSpacing=2 cellPadding=2 align=center><tr valign=middle>"));
			}
			if (pg.ToLower() == "client")
			{
				plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=middle><td class=label normaltext valign=middle height=24px>Company Type</td>"));
				plhLeadAdd.Controls.Add(new LiteralControl(string.Concat("<td valign=middle class=graytext>", this.CompanyType, "</td>")));
				plhLeadAdd.Controls.Add(new LiteralControl("<td</td></tr>"));
			}
			int num4 = 0;
			string str = "";
			string empty1 = string.Empty;
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "ticketnumber") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "solutionnumber") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "solutionstatus")))
				{
					continue;
				}
				RegularExpressionValidator regularExpressionValidator = new RegularExpressionValidator();
				TextBox textBox = new TextBox();
				CompareValidator compareValidator = new CompareValidator();
				bool flag = false;
				try
				{
					flag = bool.Parse(sqlDataReader["isNewRow"].ToString());
				}
				catch
				{
				}
				string str1 = string.Empty;
				string str2 = sqlDataReader["inputType"].ToString().ToLower().Trim();
				string str3 = str2;
				if (str2 == null)
				{
					continue;
				}
                //if (<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017f8-1 == null)
                //{
                //    <PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017f8-1 = new Dictionary<string, int>(13)
                //    {
                //        { "text", 0 },
                //        { "textarea", 1 },
                //        { "select", 2 },
                //        { "checkbox", 3 },
                //        { "radio button", 4 },
                //        { "checkboxlist", 5 },
                //        { "heading", 6 },
                //        { "date", 7 },
                //        { "currency", 8 },
                //        { "decimal", 9 },
                //        { "number", 10 },
                //        { "email", 11 },
                //        { "url", 12 }
                //    };
                //}
                //if (!<PrivateImplementationDetails>{3C970EBE-246A-43ED-A8B7-631943B1378A}.$$method0x60017f8-1.TryGetValue(str3, out num))
                //{
                //    continue;
                //}
				switch (num)
				{
					case 0:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						if (pg != "client")
						{
							base.InputTypeText(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()), clientName, campaignName);
						}
						else
						{
							base.InputTypeTextBox(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()), clientName, campaignName, this.CompanyType);
						}
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 1:
					{
						if (!((sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "description") & (sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "d")))
						{
							_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), true, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
							base.InputTypeTextArea(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
							num1++;
							_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
							continue;
						}
						else
						{
							num4 = 1;
							str = sqlDataReader["databaseFieldName"].ToString().Trim();
							empty1 = sqlDataReader["LabelName"].ToString().Trim();
							if (sqlDataReader["isrequired"].ToString().ToLower().Trim() != "true")
							{
								continue;
							}
							empty = "true";
							continue;
						}
					}
					case 2:
					{
						if (pg.ToLower() != "client")
						{
							_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						}
						else
						{
							_commonClass.upper_tr_Settingclient(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1, this.CompanyType);
						}
						if (sqlDataReader["databasefieldname"].ToString().Trim() == "Tax1")
						{
							DropDownList dropDownList = new DropDownList()
							{
								Width = 200,
								CssClass = "normaltext",
								ID = sqlDataReader["databasefieldname"].ToString()
							};
							SettingsBasePage.Bind_TaxRate(dropDownList, int.Parse(this.Session["companyID"].ToString()), "None");
							plhLeadAdd.Controls.Add(dropDownList);
						}
						else if (sqlDataReader["databasefieldname"].ToString().Trim() == "Tax2")
						{
							DropDownList dropDownList1 = new DropDownList()
							{
								Width = 200,
								CssClass = "normaltext",
								ID = sqlDataReader["databasefieldname"].ToString()
							};
							SettingsBasePage.Bind_TaxRate(dropDownList1, int.Parse(this.Session["companyID"].ToString()), "None");
							plhLeadAdd.Controls.Add(dropDownList1);
						}
						else if (sqlDataReader["databasefieldname"].ToString().Trim() == "AccountStatus")
						{
							DropDownList dropDownList2 = new DropDownList()
							{
								Width = 200,
								CssClass = "normaltext",
								ID = sqlDataReader["databasefieldname"].ToString()
							};
							SettingsBasePage settingsBasePage = new SettingsBasePage();
							settingsBasePage.Bind_Account_Status(dropDownList2, int.Parse(this.Session["companyID"].ToString()), "None");
							plhLeadAdd.Controls.Add(dropDownList2);
						}
						else if (sqlDataReader["databasefieldname"].ToString().Trim() == "SalesPerson" && this.CompanyType != "Supplier")
						{
							DropDownList dropDownList3 = new DropDownList()
							{
								Width = 200,
								CssClass = "normaltext",
								ID = sqlDataReader["databasefieldname"].ToString()
							};
							SettingsBasePage settingsBasePage1 = new SettingsBasePage();
							settingsBasePage1.Bind_User(dropDownList3, int.Parse(this.Session["companyID"].ToString()), "None");
							plhLeadAdd.Controls.Add(dropDownList3);
						}
						else if (!(sqlDataReader["databasefieldname"].ToString().Trim() == "SalesPerson") || !(this.CompanyType == "Supplier"))
						{
							base.InputTypeSelect(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()), sqlDataReader["databaseName"].ToString(), sqlDataReader["optionvalue"].ToString());
						}
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 3:
					{
						if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "ispublished") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isconverted"))
						{
							continue;
						}
						if (!(pg == "client") || !(this.CompanyType == "Supplier") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "defaultinvoiceaddress"))
						{
							if (!(pg == "client") || !(this.CompanyType == "Customer") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "defaultpurchaseorderaddress"))
							{
								continue;
							}
							_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
							base.InputTypeCheckbox(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
							num1++;
							_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
							continue;
						}
						else
						{
							_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
							base.InputTypeCheckbox(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
							num1++;
							_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
							continue;
						}
					}
					case 4:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeRadioButton(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()), sqlDataReader["optionvalue"].ToString());
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 6:
					{
						string empty2 = string.Empty;
						if (num1 % 2 != 0)
						{
							plhLeadAdd.Controls.Add(new LiteralControl("<td></td></tr><tr valign=top>"));
						}
						if (pg.ToString().ToLower().Trim() != "contact" && pg.ToString().ToLower().Trim() != "client" && pg.ToString().ToLower().Trim() != "contract")
						{
							empty2 = sqlDataReader["labelname"].ToString();
						}
						else if (sqlDataReader["databaseFieldName"].ToString().Trim().ToLower() != "copyaddress")
						{
							empty2 = sqlDataReader["labelname"].ToString();
						}
						else
						{
							string[] strArrays = new string[] { "<a class=normaltext  href='javascript://' onclick=CopyAdress('", pg.ToString().ToLower().Trim(), "');>", sqlDataReader["labelname"].ToString(), "</a>" };
							empty2 = string.Concat(strArrays);
						}
						plhLeadAdd.Controls.Add(new LiteralControl("<td class=headertext colspan=2>"));
						plhLeadAdd.Controls.Add(new LiteralControl(empty2));
						plhLeadAdd.Controls.Add(new LiteralControl("</td>"));
						plhLeadAdd.Controls.Add(new LiteralControl("</tr><tr valign=top>"));
						num1 = 0;
						continue;
					}
					case 7:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeDate(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 8:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeCurrency(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 9:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeDecimal(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 10:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeNumber(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 11:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeEmail(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					case 12:
					{
						_commonClass.upper_tr_Setting(sqlDataReader["isrequired"].ToString(), false, plhLeadAdd, sqlDataReader["labelname"].ToString(), num2, flag, num1);
						base.InputTypeUrl(str1, pg, plhLeadAdd, sqlDataReader["labelname"].ToString(), sqlDataReader["databasefieldname"].ToString(), sqlDataReader["isrequired"].ToString(), int.Parse(sqlDataReader["maxLength"].ToString()));
						num1++;
						_commonClass.lower_tr_Setting(plhLeadAdd, num2, flag, num1, num3);
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
			while (sqlDataReader.Read())
			{
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
			if (num2 == 1)
			{
				if (num1 % 2 != 0)
				{
					plhLeadAdd.Controls.Add(new LiteralControl("<td colspan=2></td></tr>"));
				}
				else
				{
					plhLeadAdd.Controls.Add(new LiteralControl("<td colspan=4></td></tr>"));
				}
			}
			else if (num2 == 2)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
			}
			else if (num2 == 3)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			plhLeadAdd.Controls.Add(new LiteralControl("</table></td></tr>"));
			if (num4 == 1)
			{
				plhLeadAdd.Controls.Add(new LiteralControl("<tr><td><table cellSpacing=5 cellPadding=2 width=100% align=center border=0>"));
				TextBox textBox1 = new TextBox()
				{
					Width = 620,
					CssClass = "txtbox",
					SkinID = "textPad",
					ID = str,
					TextMode = TextBoxMode.MultiLine,
					Columns = 400,
					Rows = 8
				};
				languageClass _languageClass = new languageClass();
				if (num2 == 2)
				{
					plhLeadAdd.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20%>&nbsp;", empty1)));
					if (empty == "true")
					{
						plhLeadAdd.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
					}
					plhLeadAdd.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadAdd.Controls.Add(new LiteralControl("<tr valign=top><td width=100%>"));
					plhLeadAdd.Controls.Add(textBox1);
					if (empty == "true")
					{
						RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
						plhLeadAdd.Controls.Add(new LiteralControl("<div class=spanerrorMsg>"));
						requiredFieldValidator.ControlToValidate = str;
						requiredFieldValidator.CssClass = "spanerrorMsg";
						requiredFieldValidator.ErrorMessage = string.Concat(_languageClass.convert("Please enter"), " ", empty1);
						requiredFieldValidator.Width = 200;
						requiredFieldValidator.ForeColor = this.objBase.TakeErrorForColors();
						requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
						plhLeadAdd.Controls.Add(requiredFieldValidator);
						plhLeadAdd.Controls.Add(new LiteralControl("</div>"));
					}
					plhLeadAdd.Controls.Add(new LiteralControl("</td></tr>"));
					plhLeadAdd.Controls.Add(new LiteralControl("</table></td></tr>"));
				}
				else if (num2 == 1 || num2 == 3)
				{
					if (pg != "price")
					{
						plhLeadAdd.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20%>&nbsp;", empty1)));
						if (empty == "true")
						{
							plhLeadAdd.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
						}
						plhLeadAdd.Controls.Add(new LiteralControl("</td><td colspan=3>"));
						plhLeadAdd.Controls.Add(textBox1);
						if (empty == "true")
						{
							RequiredFieldValidator requiredFieldValidator1 = new RequiredFieldValidator();
							plhLeadAdd.Controls.Add(new LiteralControl("<div class=spanerrorMsg>"));
							requiredFieldValidator1.ControlToValidate = str;
							requiredFieldValidator1.CssClass = "spanerrorMsg";
							requiredFieldValidator1.ErrorMessage = string.Concat(_languageClass.convert("Please enter"), " ", empty1);
							requiredFieldValidator1.Width = 200;
							requiredFieldValidator1.Display = ValidatorDisplay.Dynamic;
							requiredFieldValidator1.ForeColor = this.objBase.TakeErrorForColors();
							plhLeadAdd.Controls.Add(requiredFieldValidator1);
							plhLeadAdd.Controls.Add(new LiteralControl("</div>"));
						}
						plhLeadAdd.Controls.Add(new LiteralControl("</td></tr>"));
						plhLeadAdd.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
					else
					{
						plhLeadAdd.Controls.Add(new LiteralControl(string.Concat("<tr valign=top><td class='label normaltext' width=20%>&nbsp;", empty1)));
						if (empty == "true")
						{
							plhLeadAdd.Controls.Add(new LiteralControl("<span class=redver7>*</span>"));
						}
						plhLeadAdd.Controls.Add(new LiteralControl("</td><td colspan=3>"));
						plhLeadAdd.Controls.Add(textBox1);
						if (empty == "true")
						{
							RequiredFieldValidator requiredFieldValidator2 = new RequiredFieldValidator();
							plhLeadAdd.Controls.Add(new LiteralControl("<div class=spanerrorMsg>"));
							requiredFieldValidator2.ControlToValidate = str;
							requiredFieldValidator2.CssClass = "spanerrorMsg";
							requiredFieldValidator2.ErrorMessage = string.Concat(_languageClass.convert("Please enter"), " ", empty1);
							requiredFieldValidator2.Width = 200;
							requiredFieldValidator2.Display = ValidatorDisplay.Dynamic;
							requiredFieldValidator2.ForeColor = this.objBase.TakeErrorForColors();
							plhLeadAdd.Controls.Add(requiredFieldValidator2);
							plhLeadAdd.Controls.Add(new LiteralControl("</div>"));
						}
						plhLeadAdd.Controls.Add(new LiteralControl("</td></tr>"));
						plhLeadAdd.Controls.Add(new LiteralControl("</table></td></tr>"));
					}
				}
			}
			plhLeadAdd.Controls.Add(new LiteralControl("</table>"));
		}
	}
}