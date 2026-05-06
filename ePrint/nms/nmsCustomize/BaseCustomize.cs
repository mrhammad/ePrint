using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCustomize
{
	public class BaseCustomize : BasePage
	{
		public BaseClass objBase = new BaseClass();

		private string CompanyType = string.Empty;

		public int ClientID;

		public languageClass objLangClass = new languageClass();

		public BaseCustomize()
		{
		}

		public void InputTypeCheckbox(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			CheckBox checkBox = new CheckBox()
			{
				CssClass = "chk"
			};
			if (ThisValue.ToString().ToLower().Trim() == "true" || ThisValue.ToString().ToLower().Trim() == "1")
			{
				checkBox.Checked = true;
			}
			checkBox.ID = DataBaseFieldName.Trim();
			PlhCustomize.Controls.Add(checkBox);
		}

		public void InputTypeCurrency(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			commonClass _commonClass = new commonClass();
			languageClass _languageClass = new languageClass();
			TextBox textBox = new TextBox()
			{
				CssClass = "txtbox"
			};
			CompareValidator compareValidator = new CompareValidator();
			try
			{
				if (DataBaseFieldName.Trim().ToLower() != "expectedrevenue" && DataBaseFieldName.Trim().ToLower() != "actualcost" && DataBaseFieldName.Trim().ToLower() != "budgetedcost" || Pg != "campaign")
				{
					double num = double.Parse(ThisValue);
					ThisValue = num.ToString("C").Remove(0, 1);
				}
				else if (ThisValue != "")
				{
					ThisValue = _commonClass.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.Session["companyID"]), Convert.ToInt32(this.Session["UserID"]), Convert.ToDecimal(ThisValue), 0, "", false, false, false);
				}
			}
			catch
			{
			}
			if ((DataBaseFieldName.Trim().ToLower() == "expectedrevenue" ? true : DataBaseFieldName.Trim().ToLower() == "actualcost") & (Pg == "campaign"))
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				textBox.Attributes.Add("style", "text-align:right");
				textBox.Attributes.Add("onblur", "javascript:calculateExpectedRevenuePercent();todecimal_function(this, this.value);");
				PlhCustomize.Controls.Add(textBox);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "amount") & (Pg == "opportunity"))
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				textBox.Attributes.Add("onkeyup", "javascript:expectedamount();");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (!((DataBaseFieldName.Trim().ToLower() == "expectedamount") & (Pg == "opportunity")))
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				textBox.Attributes.Add("onblur", "javascript:todecimal_function(this, this.value);");
				textBox.Attributes.Add("style", "text-align:right");
				PlhCustomize.Controls.Add(textBox);
			}
			else
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				PlhCustomize.Controls.Add(textBox);
			}
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
			if (!(DataBaseFieldName.Trim().ToLower() == "expectedrevenue") && !(DataBaseFieldName.Trim().ToLower() == "actualcost") && !(DataBaseFieldName.Trim().ToLower() == "budgetedcost") || !(Pg == "campaign"))
			{
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				compareValidator.ControlToValidate = DataBaseFieldName.Trim();
				compareValidator.CssClass = "errorMsg";
				compareValidator.Width = 200;
				compareValidator.ErrorMessage = "Please enter Numeric Value";
				compareValidator.ForeColor = Color.Black;
				compareValidator.Display = ValidatorDisplay.Dynamic;
				compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
				compareValidator.Type = ValidationDataType.Currency;
				PlhCustomize.Controls.Add(compareValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
				return;
			}
			PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
			compareValidator.ControlToValidate = DataBaseFieldName.Trim();
			compareValidator.CssClass = "errorMsg";
			compareValidator.Width = 200;
			compareValidator.ErrorMessage = "Please enter Numeric Value";
			compareValidator.ForeColor = Color.Black;
			compareValidator.Display = ValidatorDisplay.Dynamic;
			compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
			compareValidator.Type = ValidationDataType.Double;
			PlhCustomize.Controls.Add(compareValidator);
			PlhCustomize.Controls.Add(new LiteralControl("</div>"));
		}

		public void InputTypeDate(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			TextBox textBox = new TextBox();
			CompareValidator compareValidator = new CompareValidator();
			commonClass _commonClass = new commonClass();
			textBox.Width = 200;
			textBox.CssClass = "txtbox";
			ThisValue = _commonClass.Eprint_return_Date_Before_View(ThisValue, Convert.ToInt32(this.Session["CompanyID"]), Convert.ToInt32(this.Session["UserID"]), true);
			textBox.Text = ThisValue;
			BasePage basePage = new BasePage();
			string regionalSettings = basePage.GetRegionalSettings(Convert.ToInt32(this.Session["CompanyID"]), "Dateformat");
			textBox.ID = DataBaseFieldName.Trim();
			textBox.Attributes.Add("onclick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", regionalSettings, "');"));
			PlhCustomize.Controls.Add(textBox);
			PlhCustomize.Controls.Add(textBox);
			if (textBox.Text == "1/1/1900" || textBox.Text == "01/01/1900")
			{
				textBox.Text = "";
				PlhCustomize.Controls.Add(textBox);
			}
			else
			{
				PlhCustomize.Controls.Add(textBox);
			}
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
		}

		public void InputTypeDecimal(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			TextBox textBox = new TextBox()
			{
				CssClass = "txtbox"
			};
			CompareValidator compareValidator = new CompareValidator();
			if (!((DataBaseFieldName.Trim().ToLower() == "probability") & (Pg == "opportunity")))
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				PlhCustomize.Controls.Add(textBox);
			}
			else
			{
				textBox.Width = 200;
				textBox.ID = DataBaseFieldName.Trim();
				textBox.MaxLength = MaxLength;
				textBox.Text = ThisValue;
				textBox.Attributes.Add("onkeyup", "javascript:expectedamount();");
				PlhCustomize.Controls.Add(textBox);
			}
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.ForeColor = Color.Black;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
			PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
			compareValidator.ControlToValidate = DataBaseFieldName.Trim();
			compareValidator.CssClass = "errorMsg";
			compareValidator.Width = 200;
			compareValidator.ErrorMessage = _languageClass.convert("Please enter Numeric Value");
			compareValidator.Display = ValidatorDisplay.Dynamic;
			compareValidator.ForeColor = Color.Black;
			compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
			compareValidator.Type = ValidationDataType.Double;
			PlhCustomize.Controls.Add(compareValidator);
			PlhCustomize.Controls.Add(new LiteralControl("</div>"));
		}

		public void InputTypeEmail(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			RegularExpressionValidator regularExpressionValidator = new RegularExpressionValidator();
			TextBox textBox = new TextBox()
			{
				Width = 200,
				CssClass = "txtbox",
				ID = DataBaseFieldName.Trim(),
				Text = ThisValue
			};
			PlhCustomize.Controls.Add(textBox);
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
			PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
			regularExpressionValidator.ControlToValidate = DataBaseFieldName.Trim();
			regularExpressionValidator.CssClass = "errorMsg";
			regularExpressionValidator.ErrorMessage = _languageClass.convert("Please enter Valid Email ID");
			regularExpressionValidator.Width = 200;
			regularExpressionValidator.Display = ValidatorDisplay.Dynamic;
			regularExpressionValidator.ForeColor = Color.Black;
			regularExpressionValidator.ValidationExpression = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			PlhCustomize.Controls.Add(regularExpressionValidator);
			PlhCustomize.Controls.Add(new LiteralControl("</div>"));
		}

		public void InputTypeNumber(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			commonClass _commonClass = new commonClass();
			TextBox textBox = new TextBox();
			CompareValidator compareValidator = new CompareValidator();
			textBox.Width = 200;
			textBox.CssClass = "txtbox";
			textBox.ID = DataBaseFieldName.Trim();
			textBox.MaxLength = 200;
			try
			{
				if (ThisValue != "" && (DataBaseFieldName.Trim().ToLower() == "expectedresponse" || DataBaseFieldName.Trim().ToLower() == "noofindividualstargeted") && Pg == "campaign")
				{
					ThisValue = _commonClass.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.Session["companyID"]), Convert.ToInt32(this.Session["UserID"]), Convert.ToDecimal(ThisValue), 0, "", true, false, false);
				}
			}
			catch
			{
			}
			textBox.Text = ThisValue;
			if (!((DataBaseFieldName.Trim().ToLower() == "contactid") & (Pg.ToLower().Trim() == "ticket")))
			{
				if (DataBaseFieldName.Trim().ToLower() == "ticketownerid" && Pg.ToLower().Trim() == "ticket")
				{
					ControlCollection controls = PlhCustomize.Controls;
					string[] str = new string[] { "<span class=normaltext>", this.Session["firstname"].ToString(), " ", this.Session["lastname"].ToString(), "</span>" };
					controls.Add(new LiteralControl(string.Concat(str)));
					return;
				}
				if (DataBaseFieldName.Trim().ToLower() != "reporttouserid")
				{
					textBox.Attributes.Add("style", "text-align:right");
					PlhCustomize.Controls.Add(textBox);
					if (IsRequired.ToLower().Trim() == "true")
					{
						RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
						PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
						requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
						requiredFieldValidator.CssClass = "errorMsg";
						requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
						requiredFieldValidator.Width = 200;
						requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
						requiredFieldValidator.ForeColor = Color.Black;
						PlhCustomize.Controls.Add(requiredFieldValidator);
						PlhCustomize.Controls.Add(new LiteralControl("</div>"));
					}
					PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
					compareValidator.ControlToValidate = DataBaseFieldName.Trim();
					compareValidator.CssClass = "errorMsg";
					compareValidator.Width = 200;
					compareValidator.ErrorMessage = _languageClass.convert("Please enter Numeric Value");
					compareValidator.Display = ValidatorDisplay.Dynamic;
					compareValidator.ForeColor = Color.Black;
					compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
					compareValidator.Type = ValidationDataType.Integer;
					PlhCustomize.Controls.Add(compareValidator);
					PlhCustomize.Controls.Add(new LiteralControl("</div>"));
				}
				else
				{
					textBox.Width = 175;
					textBox.ID = "_REPORTTO";
					textBox.Text = ThisValue;
					PlhCustomize.Controls.Add(textBox);
					ImageButton imageButton = new ImageButton()
					{
						ID = "1235",
						CausesValidation = false
					};
					imageButton.Style.Add("vertical-align", "middle");
					imageButton.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
					string str1 = string.Concat(global.sitePath(), "contact/selectreporttoinpopup.aspx");
					imageButton.Attributes.Add("onclick", string.Concat("javascript:window.open('", str1, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
					PlhCustomize.Controls.Add(imageButton);
					if (string.IsNullOrEmpty(ThisValue))
					{
						textBox.Text = string.Concat(this.Session["firstname"].ToString(), " ", this.Session["lastname"].ToString());
					}
					if (IsRequired.ToLower().Trim() == "true")
					{
						RequiredFieldValidator d = new RequiredFieldValidator();
						PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
						d.ControlToValidate = textBox.ID;
						d.CssClass = "errorMsg";
						d.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
						d.Width = 200;
						d.Display = ValidatorDisplay.Dynamic;
						d.ForeColor = Color.Black;
						PlhCustomize.Controls.Add(d);
						PlhCustomize.Controls.Add(new LiteralControl("</div>"));
						return;
					}
				}
			}
			else
			{
				textBox.Width = 175;
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton1 = new ImageButton()
				{
					ID = "1234",
					CausesValidation = false
				};
				imageButton1.Style.Add("vertical-align", "middle");
				imageButton1.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str2 = string.Concat(global.sitePath(), "common/selectcontactinpopup.aspx");
				imageButton1.Attributes.Add("onclick", string.Concat("javascript:window.open('", str2, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton1);
				if (IsRequired.ToLower().Trim() == "true")
				{
					RequiredFieldValidator black = new RequiredFieldValidator();
					PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
					black.ControlToValidate = DataBaseFieldName.Trim();
					black.CssClass = "errorMsg";
					black.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
					black.Width = 200;
					black.Display = ValidatorDisplay.Dynamic;
					black.ForeColor = Color.Black;
					PlhCustomize.Controls.Add(black);
					PlhCustomize.Controls.Add(new LiteralControl("</div>"));
					return;
				}
			}
		}

		public void InputTypeRadioButton(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength, string OptionalValue)
		{
			string[] strArrays = OptionalValue.Split(new char[] { ',' });
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				RadioButton radioButton = new RadioButton()
				{
					ID = string.Concat(DataBaseFieldName.Trim(), strArrays[i].ToString()),
					Text = strArrays[i].ToString()
				};
				if (ThisValue.ToString().Trim().ToLower() == strArrays[i].ToString().Trim().ToLower())
				{
					radioButton.Checked = true;
				}
				radioButton.CssClass = "normaltext";
				radioButton.GroupName = DataBaseFieldName.Trim();
				radioButton.Style.Add("textalign", "middle");
				if (i == 0)
				{
					radioButton.Checked = true;
				}
				PlhCustomize.Controls.Add(radioButton);
			}
		}

		public void InputTypeSelect(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength, string DataBaseForDropDown, string OptionalValue)
		{
			RequiredFieldValidator requiredFieldValidator;
			languageClass _languageClass = new languageClass();
			DropDownList dropDownList = new DropDownList()
			{
				Width = 200,
				CssClass = "normaltext",
				ID = DataBaseFieldName.Trim()
			};
			if (DataBaseFieldName.Trim().ToLower() == "opportunitystagename" && Pg == "opportunity")
			{
				commonClass _commonClass = new commonClass();
				SqlCommand sqlCommand = new SqlCommand("crm_select_opportunity_stage", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@companyid", (int)this.Session["companyID"]);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dropDownList.Attributes.Add("onchange", "javascript:changeprobability(this.value);");
				dropDownList.Attributes.Add("onblur", "javascript:expectedamount();");
				int num = 0;
				while (sqlDataReader.Read())
				{
					dropDownList.Items.Insert(num, sqlDataReader["opportunitystage"].ToString());
					if (sqlDataReader["opportunitystage"].ToString().Trim() != "Closed & Won")
					{
						dropDownList.Items[num].Text = sqlDataReader["opportunitystage"].ToString();
					}
					else
					{
						dropDownList.Items[num].Text = _languageClass.convert(sqlDataReader["opportunitystage"].ToString());
					}
					dropDownList.Items[num].Value = string.Concat(sqlDataReader["opportunitystage"].ToString(), "~", sqlDataReader["probability"].ToString());
					num++;
				}
				_commonClass.closeConnection();
				dropDownList.Items.Insert(0, "");
				dropDownList.Items[0].Text = _languageClass.convert("None");
				dropDownList.Items[0].Value = "";
				if (!string.IsNullOrEmpty(ThisValue))
				{
					int num1 = 0;
					while (num1 < dropDownList.Items.Count)
					{
						if (dropDownList.Items[num1].Text.Trim() == _languageClass.convert(ThisValue.Trim()))
						{
							dropDownList.SelectedIndex = num1;
							PlhCustomize.Controls.Add(dropDownList);
							if (IsRequired.ToLower().Trim() == "true")
							{
								requiredFieldValidator = new RequiredFieldValidator();
								PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
								requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
								requiredFieldValidator.CssClass = "errorMsg";
								requiredFieldValidator.ErrorMessage = string.Concat(_languageClass.convert("Please select"), " ", _languageClass.convert(LabelName));
								requiredFieldValidator.Width = 200;
								requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
								requiredFieldValidator.ForeColor = Color.Black;
								PlhCustomize.Controls.Add(requiredFieldValidator);
								PlhCustomize.Controls.Add(new LiteralControl("</div>"));
							}
							return;
						}
						else if (dropDownList.Items[num1].Text.ToLower().Trim() != _languageClass.convert(ThisValue.ToLower().Trim()))
						{
							num1++;
						}
						else
						{
							dropDownList.SelectedIndex = num1;
							PlhCustomize.Controls.Add(dropDownList);
							if (IsRequired.ToLower().Trim() == "true")
							{
								requiredFieldValidator = new RequiredFieldValidator();
								PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
								requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
								requiredFieldValidator.CssClass = "errorMsg";
								requiredFieldValidator.ErrorMessage = string.Concat(_languageClass.convert("Please select"), " ", _languageClass.convert(LabelName));
								requiredFieldValidator.Width = 200;
								requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
								requiredFieldValidator.ForeColor = Color.Black;
								PlhCustomize.Controls.Add(requiredFieldValidator);
								PlhCustomize.Controls.Add(new LiteralControl("</div>"));
							}
							return;
						}
					}
				}
			}
			else if (DataBaseForDropDown.Trim() == "")
			{
				string[] strArrays = OptionalValue.Split(new char[] { ',' });
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					dropDownList.Items.Insert(i, strArrays[i].ToString());
					dropDownList.Items[i].Value = strArrays[i].ToString();
				}
				dropDownList.Items.Insert(0, "");
				dropDownList.Items[0].Text = _languageClass.convert("None");
				dropDownList.Items[0].Value = "";
				if (!string.IsNullOrEmpty(ThisValue))
				{
					int num2 = 0;
					while (num2 < dropDownList.Items.Count)
					{
						if (dropDownList.Items[num2].Value.ToLower().Trim() != ThisValue.ToLower().Trim())
						{
							num2++;
						}
						else
						{
							dropDownList.SelectedIndex = num2;
							break;
						}
					}
				}
			}
			else if (DataBaseFieldName.Trim().ToLower() != "ticketstatus")
			{
				string[] strArrays1 = DataBaseForDropDown.Trim().Split(new char[] { '|' });
				string str = strArrays1[0];
				string str1 = strArrays1[1];
				commonClass _commonClass1 = new commonClass();
				SqlCommand sqlCommand1 = new SqlCommand("crm_select_fromgiventable", _commonClass1.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand1.Parameters.AddWithValue("@companyid", Convert.ToInt32(this.Session["companyID"].ToString()));
				sqlCommand1.Parameters.AddWithValue("@tablename", str);
				sqlCommand1.Parameters.AddWithValue("@fieldname", str1);
				dropDownList.DataSource = sqlCommand1.ExecuteReader();
				dropDownList.DataTextField = str1;
				dropDownList.DataBind();
				_commonClass1.closeConnection();
				dropDownList.Items.Insert(0, "");
				dropDownList.Items[0].Text = _languageClass.convert("None");
				dropDownList.Items[0].Value = "";
				if (!string.IsNullOrEmpty(ThisValue))
				{
					int num3 = 0;
					while (num3 < dropDownList.Items.Count)
					{
						if (dropDownList.Items[num3].Value.ToLower().Trim() != ThisValue.ToLower().Trim())
						{
							num3++;
						}
						else
						{
							dropDownList.SelectedIndex = num3;
							break;
						}
					}
				}
				if (DataBaseForDropDown.Trim().ToLower() == "tb_country|country")
				{
					dropDownList.Items.Insert(7, "----------------------------");
					dropDownList.Items[7].Text = "-----------------------------";
					dropDownList.Items[7].Value = "0";
				}
			}
			else
			{
				commonClass _commonClass2 = new commonClass();
				SqlCommand sqlCommand2 = new SqlCommand("crm_select_ticket_status", _commonClass2.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand2.Parameters.AddWithValue("@companyid", (int)this.Session["companyID"]);
				SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
				int num4 = 0;
				int num5 = 0;
				while (sqlDataReader1.Read())
				{
					dropDownList.Items.Insert(num4, sqlDataReader1["ticketStatus"].ToString());
					if (sqlDataReader1["ticketStatus"].ToString() == "New")
					{
						num5 = num4;
					}
					num4++;
				}
				dropDownList.SelectedIndex = num5;
				_commonClass2.closeConnection();
				dropDownList.Items.Insert(0, "");
				dropDownList.Items[0].Text = "None";
				dropDownList.Items[0].Value = "";
			}
			PlhCustomize.Controls.Add(dropDownList);
			if (IsRequired.ToLower().Trim() == "true")
			{
				requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(_languageClass.convert("Please select"), " ", _languageClass.convert(LabelName));
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
		}

		public void InputTypeText(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength, string ClientName, string CampaignName)
		{
			try
			{
				string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
				ArrayList arrayLists = Encryption.querystrvalue(str);
				this.ClientID = int.Parse(arrayLists[1].ToString());
			}
			catch
			{
			}
			languageClass _languageClass = new languageClass();
			TextBox textBox = new TextBox();
			CompareValidator compareValidator = new CompareValidator();
			textBox.SkinID = "textPad";
			textBox.Width = 200;
			textBox.MaxLength = MaxLength;
			textBox.ID = DataBaseFieldName.Trim();
			textBox.Text = ThisValue;
			if (DataBaseFieldName.Trim().ToLower() == "parentclient")
			{
				textBox.Width = 175;
				textBox.MaxLength = 300;
				textBox.ID = "_CLIENTNAME";
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton = new ImageButton()
				{
					ID = "a1234",
					CausesValidation = false
				};
				imageButton.Style.Add("vertical-align", "middle");
				imageButton.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str1 = string.Concat(global.sitePath(), "common/selectclientinpopup.aspx");
				imageButton.Attributes.Add("onclick", string.Concat("javascript:window.open('", str1, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "account")
			{
				textBox.MaxLength = 300;
				if (this.ClientID == 0)
				{
					CompanyBasePage companyBasePage = new CompanyBasePage();
					long num = companyBasePage.Customer_code_select(Convert.ToInt32(this.Session["CompanyID"]));
					textBox.Text = num.ToString().Substring(1, num.ToString().Length - 1);
				}
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "a/copened")
			{
				BasePage basePage = new BasePage();
				string regionalSettings = basePage.GetRegionalSettings(Convert.ToInt32(this.Session["CompanyID"]), "Dateformat");
				textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", regionalSettings, "');"));
				PlhCustomize.Controls.Add(textBox);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "campaignid") & (Pg == "lead"))
			{
				textBox.Width = 175;
				textBox.MaxLength = 300;
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton1 = new ImageButton()
				{
					ID = "b1234",
					CausesValidation = false
				};
				imageButton1.Style.Add("vertical-align", "middle");
				imageButton1.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str2 = string.Concat(global.sitePath(), "common/selectcampaigninpopup.aspx");
				imageButton1.Attributes.Add("onclick", string.Concat("javascript:window.open('", str2, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton1);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "clientid") & (Pg == "contact" ? true : Pg == "contract"))
			{
				textBox.Width = 175;
				textBox.ID = "_CLIENTNAME";
				textBox.MaxLength = 200;
				if (!string.IsNullOrEmpty(ClientName))
				{
					textBox.Text = ClientName;
				}
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton2 = new ImageButton()
				{
					ID = "c1234",
					CausesValidation = false
				};
				imageButton2.Style.Add("vertical-align", "middle");
				imageButton2.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str3 = string.Concat(global.sitePath(), "common/selectclientinpopup.aspx");
				imageButton2.Attributes.Add("onclick", string.Concat("javascript:window.open('", str3, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton2);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "clientid") & (Pg == "opportunity" || Pg == "asset" ? true : Pg == "contact"))
			{
				textBox.Width = 175;
				textBox.ID = "_CLIENTNAME";
				textBox.MaxLength = 200;
				if (!string.IsNullOrEmpty(ClientName))
				{
					textBox.Text = ClientName;
				}
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton3 = new ImageButton()
				{
					ID = "d1234",
					CausesValidation = false
				};
				imageButton3.Style.Add("vertical-align", "middle");
				imageButton3.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str4 = string.Concat(global.sitePath(), "common/selectclientinpopup.aspx");
				imageButton3.Attributes.Add("onclick", string.Concat("javascript:window.open('", str4, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton3);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "campaignid") & (Pg == "opportunity"))
			{
				textBox.Width = 175;
				textBox.ID = "campaignID";
				textBox.MaxLength = 200;
				if (!string.IsNullOrEmpty(CampaignName))
				{
					textBox.Text = CampaignName;
				}
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton4 = new ImageButton()
				{
					ID = "e1235",
					CausesValidation = false
				};
				imageButton4.Style.Add("vertical-align", "middle");
				imageButton4.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str5 = string.Concat(global.sitePath(), "common/selectcampaigninpopup.aspx");
				imageButton4.Attributes.Add("onclick", string.Concat("javascript:window.open('", str5, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton4);
			}
			else if ((DataBaseFieldName.Trim().ToLower() == "contactid") & (Pg == "contract" ? true : Pg == "asset"))
			{
				textBox.Width = 175;
				textBox.ID = "contactId";
				textBox.MaxLength = 200;
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton5 = new ImageButton()
				{
					ID = "f1234",
					CausesValidation = false
				};
				imageButton5.Style.Add("vertical-align", "middle");
				imageButton5.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str6 = string.Concat(global.sitePath(), "common/selectcontactinpopup.aspx");
				imageButton5.Attributes.Add("onclick", string.Concat("javascript:window.open('", str6, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton5);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "productid")
			{
				textBox.Width = 175;
				textBox.ID = "productId";
				textBox.MaxLength = 200;
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton6 = new ImageButton()
				{
					ID = "g1234",
					CausesValidation = false
				};
				imageButton6.Style.Add("vertical-align", "middle");
				imageButton6.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str7 = string.Concat(global.sitePath(), "common/selectproductinpopup.aspx");
				imageButton6.Attributes.Add("onclick", string.Concat("javascript:window.open('", str7, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton6);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "companysignedbyid")
			{
				textBox.Width = 175;
				textBox.ID = "companySignedBy";
				textBox.MaxLength = 200;
				PlhCustomize.Controls.Add(textBox);
				ImageButton imageButton7 = new ImageButton()
				{
					ID = "h1234",
					CausesValidation = false
				};
				imageButton7.Style.Add("vertical-align", "middle");
				imageButton7.ImageUrl = string.Concat(global.imagePath(), "lookup.gif");
				string str8 = string.Concat(global.sitePath(), "contract/selectcompanysignedby.aspx");
				imageButton7.Attributes.Add("onclick", string.Concat("javascript:window.open('", str8, "', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100'); return false;"));
				PlhCustomize.Controls.Add(imageButton7);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "leadalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'lead');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'lead');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "clientalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'client');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'client');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "contactalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'contact');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'contact');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "opportunityalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'opportunity');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'opportunity');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "campaignalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'campaign');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'campaign');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "productalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'product');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'product');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if (DataBaseFieldName.Trim().ToLower() == "assetalias")
			{
				textBox.Attributes.Add("onFocus", "javascript:FillAliasBox(this,'asset');");
				textBox.Attributes.Add("onClick", "javascript:FillAliasBox(this,'asset');");
				PlhCustomize.Controls.Add(textBox);
			}
			else if ((!(DataBaseFieldName.Trim().ToLower() == "salesperson") || !(this.CompanyType != "Customer")) && (!(DataBaseFieldName.Trim().ToLower() == "taxnumber") || !(this.CompanyType != "Supplier")) && (!(DataBaseFieldName.Trim().ToLower() == "balance") || !(this.CompanyType != "Supplier")))
			{
				PlhCustomize.Controls.Add(textBox);
			}
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = textBox.ID;
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
		}

		public void InputTypeTextArea(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			TextBox textBox = new TextBox()
			{
				CssClass = "txtbox",
				Width = 200,
				TextMode = TextBoxMode.MultiLine,
				Rows = 3,
				ID = DataBaseFieldName.Trim(),
				Text = ThisValue
			};
			PlhCustomize.Controls.Add(textBox);
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
		}

		public void InputTypeTextBox(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength, string ClientName, string CampaignName, string companytype)
		{
			this.CompanyType = companytype;
			this.InputTypeText(ThisValue, this.pg, PlhCustomize, LabelName, DataBaseFieldName, IsRequired, MaxLength, ClientName, CampaignName);
		}

		public void InputTypeUrl(string ThisValue, string Pg, PlaceHolder PlhCustomize, string LabelName, string DataBaseFieldName, string IsRequired, int MaxLength)
		{
			languageClass _languageClass = new languageClass();
			RegularExpressionValidator regularExpressionValidator = new RegularExpressionValidator();
			TextBox textBox = new TextBox()
			{
				Width = 200,
				CssClass = "txtbox",
				ID = DataBaseFieldName.Trim(),
				Text = ThisValue
			};
			PlhCustomize.Controls.Add(textBox);
			if (IsRequired.ToLower().Trim() == "true")
			{
				RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
				PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
				requiredFieldValidator.ControlToValidate = DataBaseFieldName.Trim();
				requiredFieldValidator.CssClass = "errorMsg";
				requiredFieldValidator.ErrorMessage = string.Concat(this.objLangClass.GetLanguageConversion("Please_Enter"), " ", LabelName);
				requiredFieldValidator.Width = 200;
				requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
				requiredFieldValidator.ForeColor = Color.Black;
				PlhCustomize.Controls.Add(requiredFieldValidator);
				PlhCustomize.Controls.Add(new LiteralControl("</div>"));
			}
			PlhCustomize.Controls.Add(new LiteralControl("<div class=error_top>"));
			regularExpressionValidator.ControlToValidate = DataBaseFieldName.Trim();
			regularExpressionValidator.CssClass = "errorMsg";
			regularExpressionValidator.ErrorMessage = "Please enter Valid URL";
			regularExpressionValidator.Width = 200;
			regularExpressionValidator.Display = ValidatorDisplay.Dynamic;
			regularExpressionValidator.ForeColor = Color.Black;
			regularExpressionValidator.ValidationExpression = "http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
			PlhCustomize.Controls.Add(regularExpressionValidator);
			PlhCustomize.Controls.Add(new LiteralControl("</div>"));
		}

		public SqlDataReader SelectCustomizeField(string pg, string SP, int OnlySP)
		{
			SqlCommand sqlCommand;
			commonClass _commonClass = new commonClass();
			if (OnlySP != 1)
			{
				sqlCommand = new SqlCommand(SP, _commonClass.openConnection());
			}
			else
			{
				sqlCommand = new SqlCommand("crm_common_select_customizefield_new", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@pg", pg);
				sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
			}
			return sqlCommand.ExecuteReader();
		}
	}
}