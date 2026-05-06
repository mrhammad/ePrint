using nmsCommon;
using nmsLanguage;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsView
{
	public class BaseView : BasePage
	{
		public BaseView()
		{
		}

		public int checkValidData(string inputType, string dataType, TextBox tb, Label lbl, DropDownList ddl1)
		{
			languageClass _languageClass = new languageClass();
			int num = 1;
			lbl.Width = Unit.Pixel(519);
			string lower = inputType.ToLower();
			string str = lower;
			if (lower != null)
			{
				switch (str)
				{
					case "number":
					{
						try
						{
							int.Parse(tb.Text.ToString());
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter numeric value only") };
							lbl.Text = string.Concat(strArrays);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
					case "currency":
					{
						try
						{
							decimal.Parse(tb.Text.ToString());
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays1 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter decimal value only") };
							lbl.Text = string.Concat(strArrays1);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
					case "decimal":
					{
						try
						{
							decimal.Parse(tb.Text.ToString());
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays2 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter decimal value only") };
							lbl.Text = string.Concat(strArrays2);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
					case "checkbox":
					{
						int num1 = 5;
						try
						{
							num1 = int.Parse(tb.Text);
							if (num1 != 1 & num1 != 0)
							{
								lbl.CssClass = "errorWithTopspace";
								string[] strArrays3 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter 0(for false) or 1(for true)") };
								lbl.Text = string.Concat(strArrays3);
								lbl.Visible = true;
								num = 0;
							}
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays4 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter 0(for false) or 1(for true)") };
							lbl.Text = string.Concat(strArrays4);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
					case "none":
					{
						if (dataType.ToLower() == "datetime")
						{
							try
							{
								DateTime.Parse(tb.Text);
							}
							catch
							{
								lbl.CssClass = "errorWithTopspace";
								string[] strArrays5 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter in this format (mm/dd/yyyy)") };
								lbl.Text = string.Concat(strArrays5);
								lbl.Visible = true;
								num = 0;
							}
						}
						if (dataType.ToLower() != "bit")
						{
							break;
						}
						int num2 = 5;
						try
						{
							num2 = int.Parse(tb.Text);
							if (num2 != 1 & num2 != 0)
							{
								lbl.CssClass = "errorWithTopspace";
								string[] strArrays6 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter 0(for false) or 1(for true)") };
								lbl.Text = string.Concat(strArrays6);
								lbl.Visible = true;
								num = 0;
							}
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays7 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter 0(for false) or 1(for true)") };
							lbl.Text = string.Concat(strArrays7);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
					case "date":
					{
						try
						{
							DateTime.Parse(tb.Text);
							break;
						}
						catch
						{
							lbl.CssClass = "errorWithTopspace";
							string[] strArrays8 = new string[] { _languageClass.convert("Invalid Value for"), " ", _languageClass.convert(ddl1.SelectedItem.Text), " , ", _languageClass.convert("Please enter in this format (mm/dd/yyyy)") };
							lbl.Text = string.Concat(strArrays8);
							lbl.Visible = true;
							num = 0;
							break;
						}
						break;
					}
				}
			}
			return num;
		}

		public string CheckViewRight(string pg, int adminRight, int companyId, int userId)
		{
			string str = "";
			string empty = string.Empty;
			string str1 = pg.ToLower().Trim();
			string str2 = str1;
			if (str1 != null)
			{
				switch (str2)
				{
					case "ticket":
					{
						object[] objArray = new object[] { userId, "ticketid", "ticket", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray);
						break;
					}
					case "solution":
					{
						object[] objArray1 = new object[] { userId, "solutionid", "solution", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray1);
						break;
					}
					case "forecast":
					{
						object[] objArray2 = new object[] { userId, "forecastid", "forecast", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray2);
						break;
					}
					case "opportunity":
					{
						object[] objArray3 = new object[] { userId, "opportunityid", "opportunity", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray3);
						break;
					}
					case "lead":
					{
						object[] objArray4 = new object[] { userId, "leadid", "lead", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray4);
						break;
					}
					case "client":
					{
						object[] objArray5 = new object[] { userId, "clientid", "client", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray5);
						break;
					}
					case "contact":
					{
						object[] objArray6 = new object[] { userId, "contactid", "contact", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray6);
						break;
					}
					case "contract":
					{
						object[] objArray7 = new object[] { userId, "contractid", "contract", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray7);
						break;
					}
					case "product":
					{
						object[] objArray8 = new object[] { userId, "productid", "product", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray8);
						break;
					}
					case "asset":
					{
						object[] objArray9 = new object[] { userId, "assetid", "asset", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray9);
						break;
					}
					case "campaign":
					{
						object[] objArray10 = new object[] { userId, "campaignid", "campaign", companyId, global.databaseUserName() };
						empty = string.Format(str, objArray10);
						break;
					}
				}
			}
			return empty;
		}

		public string fieldElement(string databasefieldname, int companyId, int userId, string strDate, string inputtype, string labelname)
		{
			if (databasefieldname.ToLower().Trim() == "productid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnProductName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "campaignid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnCampaignName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "clientid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnClientName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "contactid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnContactName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntogroupid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnGroupName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "reporttouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "createuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "modifyuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (inputtype.ToLower().Trim() == "currency")
			{
				object[] str = new object[] { global.databaseUserName().ToString(), ".returnMyCurrency(IsNull(", strDate, ",0.00), ", companyId, ", ", userId, ") " };
				strDate = string.Concat(str);
			}
			else if ((inputtype.ToLower().Trim() == "date") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "createdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "modifieddate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "lastviewdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "convertdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "closedate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "activateddate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "contractenddate"))
			{
				object[] objArray = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, ", ", companyId, ", ", userId, ") " };
				strDate = string.Concat(objArray);
			}
			return strDate;
		}

		public string fieldElement_U(string databasefieldname, int companyId, int userId, string strDate, string inputtype)
		{
			if (inputtype.ToLower().Trim() == "currency")
			{
				object[] str = new object[] { global.databaseUserName().ToString(), ".returnMyCurrency_U(IsNull(", strDate, ",0.00), ", companyId, ", ", userId, ") " };
				strDate = string.Concat(str);
			}
			else if (inputtype.ToLower().Trim() == "date")
			{
				object[] objArray = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, ", ", companyId, ", ", userId, ") " };
				strDate = string.Concat(objArray);
			}
			return strDate;
		}

		public string fieldElement_US(string databasefieldname, int companyId, int userId, string strDate, string inputtype, string labelname)
		{
			if (databasefieldname.ToLower().Trim() == "productid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnProductName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "campaignid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnCampaignName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "clientid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnClientName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "contactid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnContactName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntogroupid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnGroupName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "reporttouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "createuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "modifyuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if ((inputtype.ToLower().Trim() == "date") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "createdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "modifieddate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "lastviewdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "convertdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "closedate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "activateddate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "contractenddate"))
			{
				object[] str = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, "Ç ", companyId, "Ç ", userId, ") " };
				strDate = string.Concat(str);
			}
			else if (inputtype.ToLower().Trim() == "checkbox")
			{
				object[] objArray = new object[] { global.databaseUserName().ToString(), ".returnMyYesNo(", strDate, "Ç ", companyId, "Ç ", userId, ") " };
				strDate = string.Concat(objArray);
			}
			else if (inputtype.ToLower().Trim() == "currency")
			{
				strDate = string.Concat("CONVERT(varchar(50)Ç CONVERT(moneyÇ", strDate, "))");
			}
			return strDate;
		}

		public string fieldElement_US(string databasefieldname, int companyId, int userId, string strDate, string inputtype)
		{
			if (inputtype.ToLower().Trim() == "currency")
			{
				strDate = string.Concat("CONVERT(varchar(50)Ç CONVERT(moneyÇ", strDate, "))");
			}
			else if (inputtype.ToLower().Trim() == "date")
			{
				object[] str = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, "Ç ", companyId, "Ç ", userId, ") " };
				strDate = string.Concat(str);
			}
			else if (inputtype.ToLower().Trim() == "checkbox")
			{
				object[] objArray = new object[] { global.databaseUserName().ToString(), ".returnMyYesNo(", strDate, "Ç ", companyId, "Ç ", userId, ") " };
				strDate = string.Concat(objArray);
			}
			return strDate;
		}

		public string fieldElement_US_Campaign(string databasefieldname, int companyId, int userId, string strDate, string inputtype, string labelname)
		{
			if (databasefieldname.ToLower().Trim() == "productid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnProductName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "campaignid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnCampaignName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "clientid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnClientName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "contactid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnContactName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntogroupid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnGroupName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "reporttouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "createuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() != "modifyuserid")
			{
			}
			else
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			return strDate;
		}

		public string getSearchCondition(int companyId, int userId, string condition, string operators, string values, string fieldtype, string inputtype, int customizeid, string pg)
		{
			string str;
			string[] strArrays;
			object[] shortDateString;
			DateTime dateTime;
			string str1 = "";
			string str2 = "";
			string str3 = "";
			string lower = pg.Trim().ToLower();
			string str4 = lower;
			if (lower != null)
			{
				switch (str4)
				{
					case "lead":
					{
						str1 = "leadid";
						str2 = "tb_leadcustomizevalue";
						str3 = "leadcustomizeid";
						break;
					}
					case "client":
					{
						str1 = "clientid";
						str2 = "tb_clientcustomizevalue";
						str3 = "clientcustomizeid";
						break;
					}
					case "contact":
					{
						str1 = "contactid";
						str2 = "tb_contactcustomizevalue";
						str3 = "contactcustomizeid";
						break;
					}
					case "campaign":
					{
						str1 = "campaignid";
						str2 = "tb_campaigncustomizevalue";
						str3 = "campaigncustomizeid";
						break;
					}
					case "solution":
					{
						str1 = "solutionid";
						str2 = "tb_solutioncustomizevalue";
						str3 = "solutioncustomizeid";
						break;
					}
					case "opportunity":
					{
						str1 = "opportunityid";
						str2 = "tb_opportunitycustomizevalue";
						str3 = "opportunitycustomizeid";
						break;
					}
					case "ticket":
					{
						str1 = "ticketid";
						str2 = "tb_ticketcustomizevalue";
						str3 = "casecustomizeid";
						break;
					}
					case "forecast":
					{
						str1 = "forecastid";
						str3 = "forecastcustomizeid";
						break;
					}
					case "contract":
					{
						str1 = "contractid";
						str2 = "tb_contractcustomizevalue";
						str3 = "contractcustomizeid";
						break;
					}
					case "product":
					{
						str1 = "productid";
						str2 = "tb_productcustomizevalue";
						str3 = "productcustomizeid";
						break;
					}
					case "asset":
					{
						str1 = "assetid";
						str2 = "tb_assetcustomizevalue";
						str3 = "assetcustomizeid";
						break;
					}
					case "price":
					{
						str1 = "priceid";
						str2 = "tb_pricecustomizevalue";
						str3 = "pricecustomizeid";
						break;
					}
				}
			}
			if (!((condition != "") & (operators != "") & (values != "") & (condition.ToLower().Trim() != "none")))
			{
				return "";
			}
			string[] strArrays1 = values.Split(new char[] { ',' });
			string str5 = "";
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				if (fieldtype != "d")
				{
					string lower1 = operators.Trim().ToLower();
					str4 = lower1;
					if (lower1 != null)
					{
						switch (str4)
						{
							case "=":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass = new commonClass();
									strArrays1[i] = _commonClass.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  between '", null, null, null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = "' and '";
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[3] = dateTime.ToShortDateString();
									shortDateString[4] = " 23:59:59:997'  and ";
									shortDateString[5] = str3;
									shortDateString[6] = "=";
									shortDateString[7] = customizeid;
									shortDateString[8] = " ";
									str = string.Concat(shortDateString);
								}
								else if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  = '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  = '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  = '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "!=":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass1 = new commonClass();
									strArrays1[i] = _commonClass1.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  not between '", null, null, null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = "' and '";
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[3] = dateTime.ToShortDateString();
									shortDateString[4] = " 23:59:59:997'  and ";
									shortDateString[5] = str3;
									shortDateString[6] = "=";
									shortDateString[7] = customizeid;
									shortDateString[8] = " ";
									str = string.Concat(shortDateString);
								}
								if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  != '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  != '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  != '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "startswith":
							{
								if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
								{
									goto Label0;
								}
								shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  like '", strArrays1[i], "%' and ", str3, "=", customizeid, " " };
								str = string.Concat(shortDateString);
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "contains":
							{
								if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
								{
									goto Label0;
								}
								shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  like '%", strArrays1[i], "%' and ", str3, "=", customizeid, " " };
								str = string.Concat(shortDateString);
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "notlike":
							{
								if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
								{
									goto Label0;
								}
								shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  not like '%", strArrays1[i], "%' and ", str3, "=", customizeid, " " };
								str = string.Concat(shortDateString);
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "<":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass2 = new commonClass();
									strArrays1[i] = _commonClass2.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  < '", null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = "' and ";
									shortDateString[3] = str3;
									shortDateString[4] = "=";
									shortDateString[5] = customizeid;
									shortDateString[6] = " ";
									str = string.Concat(shortDateString);
								}
								else if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  < '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  < '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  < '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case ">":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass3 = new commonClass();
									strArrays1[i] = _commonClass3.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  > '", null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = " 23:59:59:997' and ";
									shortDateString[3] = str3;
									shortDateString[4] = "=";
									shortDateString[5] = customizeid;
									shortDateString[6] = " ";
									str = string.Concat(shortDateString);
								}
								else if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  > '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  > '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  > '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case "<=":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass4 = new commonClass();
									strArrays1[i] = _commonClass4.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  <= '", null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = " 23:59:59:997' and ";
									shortDateString[3] = str3;
									shortDateString[4] = "=";
									shortDateString[5] = customizeid;
									shortDateString[6] = " ";
									str = string.Concat(shortDateString);
								}
								else if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  <= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  <= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  <= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
							case ">=":
							{
								if (inputtype == "date")
								{
									commonClass _commonClass5 = new commonClass();
									strArrays1[i] = _commonClass5.return_Date_Before_Insert(strArrays1[i].ToString(), companyId, userId);
									shortDateString = new object[] { " convert(datetime,cast(customizedvalue as nvarchar(4000)),101)  >= '", null, null, null, null, null, null };
									dateTime = DateTime.Parse(strArrays1[i]);
									shortDateString[1] = dateTime.ToShortDateString();
									shortDateString[2] = "' and ";
									shortDateString[3] = str3;
									shortDateString[4] = "=";
									shortDateString[5] = customizeid;
									shortDateString[6] = " ";
									str = string.Concat(shortDateString);
								}
								else if (inputtype == "currency")
								{
									shortDateString = new object[] { "convert(decimal,cast(customizedvalue as nvarchar(4000)))  >= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else if (inputtype != "number")
								{
									shortDateString = new object[] { " cast(customizedvalue as nvarchar(4000))  >= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								else
								{
									shortDateString = new object[] { "convert(int,cast(customizedvalue as nvarchar(4000)))  >= '", strArrays1[i], "' and ", str3, "=", customizeid, " " };
									str = string.Concat(shortDateString);
								}
								strArrays = new string[] { "or ( ", str1, " in(select ", str1, " from ", str2, " where ", str, " )) " };
								stringBuilder.Append(string.Concat(strArrays));
								goto Label0;
							}
						}
					}
					str5 = "";
				}
				else
				{
					string str6 = operators.ToLower().Trim();
					string str7 = str6;
					if (str6 != null)
					{
						switch (str7)
						{
							case "=":
							{
								if ((inputtype == "number") | (inputtype == "currency") | (inputtype == "checkbox"))
								{
									strArrays = new string[] { "or ( ", condition, " = ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
								else if (condition.ToLower() == "campaignid")
								{
									shortDateString = new object[] { "or ( ", condition, " in ( select campaignid from tb_campaign where companyId=", companyId, " and IsDelete=0 and campaignname='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(shortDateString));
									goto Label0;
								}
								else if (condition.ToLower() == "clientid")
								{
									object[] objArray = new object[] { "or ( ", condition, " in ( select clientid from tb_client where companyId=", companyId, " and IsDelete=0 and clientname='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(objArray));
									goto Label0;
								}
								else if ((condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid"))
								{
									string[] strArrays2 = new string[] { "or ( ", condition, " in ( select userid from tb_user where firstname + ' ' + lastname ='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(strArrays2));
									goto Label0;
								}
								else if (condition.ToLower() == "assigntogroupid")
								{
									string[] strArrays3 = new string[] { "or ( ", condition, " in ( select groupid from tb_group where groupname = '", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(strArrays3));
									goto Label0;
								}
								else if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
								{
									commonClass _commonClass6 = new commonClass();
									string str8 = this.Session["Dateformat"].ToString();
									string[] strArrays4 = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) = '", _commonClass6.eprint_checkdateformat_returnonlymmddyyyy(str8, strArrays1[i].ToString()), "')     " };
									stringBuilder.Append(string.Concat(strArrays4));
									goto Label0;
								}
								else if (inputtype != "textarea")
								{
									string[] strArrays5 = new string[] { "or ( ", condition, " = '", strArrays1[i], "') " };
									stringBuilder.Append(string.Concat(strArrays5));
									goto Label0;
								}
								else
								{
									string[] strArrays6 = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) = '", strArrays1[i], "') " };
									stringBuilder.Append(string.Concat(strArrays6));
									goto Label0;
								}
							}
							case "!=":
							{
								if ((inputtype == "number") | (inputtype == "currency") | (inputtype == "checkbox"))
								{
									string[] strArrays7 = new string[] { "or ( ", condition, " != ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays7));
									goto Label0;
								}
								else if (condition.ToLower() == "campaignid")
								{
									object[] objArray1 = new object[] { "or ( ", condition, " not in ( select campaignid from tb_campaign where companyId=", companyId, " and IsDelete=0 and campaignname='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(objArray1));
									goto Label0;
								}
								else if (condition.ToLower() == "clientid")
								{
									object[] objArray2 = new object[] { "or ( ", condition, " not in ( select clientid from tb_client where companyId=", companyId, " and IsDelete=0 and clientname='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(objArray2));
									goto Label0;
								}
								else if ((condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid"))
								{
									string[] strArrays8 = new string[] { "or ( ", condition, " not in ( select userid from tb_user where firstname + ' ' + lastname ='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(strArrays8));
									goto Label0;
								}
								else if (condition.ToLower() == "assigntogroupid")
								{
									string[] strArrays9 = new string[] { "or ( ", condition, " not in ( select groupid from tb_group where groupname ='", strArrays1[i], "') ) " };
									stringBuilder.Append(string.Concat(strArrays9));
									goto Label0;
								}
								else if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
								{
									commonClass _commonClass7 = new commonClass();
									string str9 = this.Session["Dateformat"].ToString();
									string[] strArrays10 = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) != '", _commonClass7.eprint_checkdateformat_returnonlymmddyyyy(str9, strArrays1[i].ToString()), "')     " };
									stringBuilder.Append(string.Concat(strArrays10));
									goto Label0;
								}
								else if (inputtype != "textarea")
								{
									string[] strArrays11 = new string[] { "or ( ", condition, " != '", strArrays1[i], "') " };
									stringBuilder.Append(string.Concat(strArrays11));
									goto Label0;
								}
								else
								{
									string[] strArrays12 = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) != '", strArrays1[i], "') " };
									stringBuilder.Append(string.Concat(strArrays12));
									goto Label0;
								}
							}
							case "startswith":
							{
								if (condition.ToLower() == "campaignid")
								{
									object[] objArray3 = new object[] { "or ( ", condition, " in ( select campaignid from tb_campaign where companyId=", companyId, " and IsDelete=0 and campaignname like '", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray3));
									goto Label0;
								}
								else if (condition.ToLower() == "clientid")
								{
									object[] objArray4 = new object[] { "or ( ", condition, " in ( select clientid from tb_client where companyId=", companyId, " and IsDelete=0 and clientname like '", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray4));
									goto Label0;
								}
								else if ((condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid"))
								{
									string[] strArrays13 = new string[] { "or ( ", condition, " in ( select userid from tb_user where firstname + ' ' + lastname like '", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays13));
									goto Label0;
								}
								else if (condition.ToLower() != "assigntogroupid")
								{
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate"))
									{
										goto Label0;
									}
									if (inputtype != "textarea")
									{
										if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
										{
											goto Label0;
										}
										string[] strArrays14 = new string[] { "or ( ", condition, " like '", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays14));
										goto Label0;
									}
									else
									{
										string[] strArrays15 = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) like '", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays15));
										goto Label0;
									}
								}
								else
								{
									string[] strArrays16 = new string[] { "or ( ", condition, " in ( select groupid from tb_group where groupname like '", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays16));
									goto Label0;
								}
							}
							case "contains":
							{
								if (condition.ToLower() == "campaignid")
								{
									object[] objArray5 = new object[] { "or ( ", condition, " in ( select campaignid from tb_campaign where companyId=", companyId, " and IsDelete=0 and campaignname like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray5));
									goto Label0;
								}
								else if (condition.ToLower() == "clientid")
								{
									object[] objArray6 = new object[] { "or ( ", condition, " in ( select clientid from tb_client where companyId=", companyId, " and IsDelete=0 and clientname like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray6));
									goto Label0;
								}
								else if ((condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid"))
								{
									string[] strArrays17 = new string[] { "or ( ", condition, " in ( select userid from tb_user where firstname + ' ' + lastname like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays17));
									goto Label0;
								}
								else if (condition.ToLower() != "assigntogroupid")
								{
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate"))
									{
										goto Label0;
									}
									if (inputtype != "textarea")
									{
										if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
										{
											goto Label0;
										}
										string[] strArrays18 = new string[] { "or ( ", condition, " like '%", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays18));
										goto Label0;
									}
									else
									{
										string[] strArrays19 = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) like '%", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays19));
										goto Label0;
									}
								}
								else
								{
									string[] strArrays20 = new string[] { "or ( ", condition, " in ( select groupid from tb_group where groupname like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays20));
									goto Label0;
								}
							}
							case "notlike":
							{
								if (condition.ToLower() == "campaignid")
								{
									object[] objArray7 = new object[] { "or ( ", condition, " in ( select campaignid from tb_campaign where companyId=", companyId, " and IsDelete=0 and campaignname not like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray7));
									goto Label0;
								}
								else if (condition.ToLower() == "clientid")
								{
									object[] objArray8 = new object[] { "or ( ", condition, " in ( select clientid from tb_client where companyId=", companyId, " and IsDelete=0 and clientname not like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(objArray8));
									goto Label0;
								}
								else if ((condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid"))
								{
									strArrays = new string[] { "or ( ", condition, " in ( select userid from tb_user where firstname + ' ' + lastname not like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
								else if (condition.ToLower() != "assigntogroupid")
								{
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate"))
									{
										goto Label0;
									}
									if (inputtype != "textarea")
									{
										if (!((inputtype != "number") & (inputtype != "currency") & (inputtype != "date") & (inputtype != "checkbox")))
										{
											goto Label0;
										}
										strArrays = new string[] { "or ( ", condition, " not like '%", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else
									{
										strArrays = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) not like '%", strArrays1[i], "%') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
								}
								else
								{
									strArrays = new string[] { "or ( ", condition, " in ( select groupid from tb_group where groupname not like '%", strArrays1[i], "%') ) " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
							}
							case "<":
							{
								if (!((inputtype == "number") | (inputtype == "currency")))
								{
									if (condition.ToLower() == "campaignid" || condition.ToLower() == "clientid" || (condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid") || condition.ToLower() == "assigntogroupid")
									{
										goto Label0;
									}
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
									{
										commonClass _commonClass8 = new commonClass();
										string str10 = this.Session["Dateformat"].ToString();
										strArrays = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) < '", _commonClass8.eprint_checkdateformat_returnonlymmddyyyy(str10, strArrays1[i].ToString()), "')     " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else if (inputtype != "textarea")
									{
										if (inputtype == "checkbox")
										{
											goto Label0;
										}
										strArrays = new string[] { "or ( ", condition, " < '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else
									{
										strArrays = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) < '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
								}
								else
								{
									strArrays = new string[] { "or ( ", condition, " < ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
							}
							case ">":
							{
								if (!((inputtype == "number") | (inputtype == "currency")))
								{
									if (condition.ToLower() == "campaignid" || condition.ToLower() == "clientid" || (condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid") || condition.ToLower() == "assigntogroupid")
									{
										goto Label0;
									}
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
									{
										commonClass _commonClass9 = new commonClass();
										string str11 = this.Session["Dateformat"].ToString();
										strArrays = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) > '", _commonClass9.eprint_checkdateformat_returnonlymmddyyyy(str11, strArrays1[i].ToString()), "')     " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else if (inputtype != "textarea")
									{
										if (inputtype == "checkbox")
										{
											goto Label0;
										}
										strArrays = new string[] { "or ( ", condition, " > '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else
									{
										strArrays = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) > '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
								}
								else
								{
									strArrays = new string[] { "or ( ", condition, " > ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
							}
							case "<=":
							{
								if (!((inputtype == "number") | (inputtype == "currency")))
								{
									if (condition.ToLower() == "campaignid" || condition.ToLower() == "clientid" || (condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid") || condition.ToLower() == "assigntogroupid")
									{
										goto Label0;
									}
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
									{
										commonClass _commonClass10 = new commonClass();
										string str12 = this.Session["Dateformat"].ToString();
										strArrays = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) <= '", _commonClass10.eprint_checkdateformat_returnonlymmddyyyy(str12, strArrays1[i].ToString()), "')     " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else if (inputtype != "textarea")
									{
										if (inputtype == "checkbox")
										{
											goto Label0;
										}
										strArrays = new string[] { "or ( ", condition, " <= '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else
									{
										strArrays = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) <= '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
								}
								else
								{
									strArrays = new string[] { "or ( ", condition, " <= ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
							}
							case ">=":
							{
								if (!((inputtype == "number") | (inputtype == "currency")))
								{
									if (condition.ToLower() == "campaignid" || condition.ToLower() == "clientid" || (condition.ToLower() == "createuserid") | (condition.ToLower() == "modifyuserid") | (condition.ToLower() == "assigntouserid") || condition.ToLower() == "assigntogroupid")
									{
										goto Label0;
									}
									if ((condition.ToLower() == "createdate") | (condition.ToLower() == "modifieddate") | (condition.ToLower() == "lastviewdate") | (condition.ToLower() == "convertdate") | (condition.ToLower() == "closedate") | (condition.ToLower() == "startdate") | (condition.ToLower() == "enddate") | (condition.ToLower() == "contractenddate") | (condition.ToLower() == "contractstartdate"))
									{
										commonClass _commonClass11 = new commonClass();
										string str13 = this.Session["Dateformat"].ToString();
										strArrays = new string[] { "or (DateAdd(d,0,DateDiff(d,0,", condition, ")) >= '", _commonClass11.eprint_checkdateformat_returnonlymmddyyyy(str13, strArrays1[i].ToString()), "')     " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else if (inputtype != "textarea")
									{
										if (inputtype == "checkbox")
										{
											goto Label0;
										}
										strArrays = new string[] { "or ( ", condition, " >= '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
									else
									{
										strArrays = new string[] { "or ( cast(", condition, "  as nvarchar(4000)) >= '", strArrays1[i], "') " };
										stringBuilder.Append(string.Concat(strArrays));
										goto Label0;
									}
								}
								else
								{
									strArrays = new string[] { "or ( ", condition, " >= ", strArrays1[i], ") " };
									stringBuilder.Append(string.Concat(strArrays));
									goto Label0;
								}
							}
						}
					}
					str5 = "";
				}
            Label0:
                string s = "";
			}
			str5 = stringBuilder.ToString();
			if (str5 != "")
			{
				str5 = str5.Substring(2);
				str5 = string.Concat("and ( ", str5, " ) ");
			}
			return str5;
		}

		public virtual void initializeArray(int companyId, string pg, ArrayList ArrayInputType, ArrayList ArrayDataType, ArrayList ArrayFieldType, ArrayList ArrayCustomizeId)
		{
			ArrayInputType.Add("none");
			ArrayDataType.Add("none");
			ArrayFieldType.Add("d");
			ArrayCustomizeId.Add("0");
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["inputtype"].ToString().ToLower().Trim() != "heading") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "description") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample")))
				{
					continue;
				}
				ArrayInputType.Add(sqlDataReader["inputtype"].ToString().ToLower().Trim());
				ArrayDataType.Add(sqlDataReader["datatype"].ToString().ToLower().Trim());
				ArrayFieldType.Add(sqlDataReader["fieldtype"].ToString().ToLower().Trim());
				ArrayCustomizeId.Add(sqlDataReader["customizeid"].ToString().ToLower().Trim());
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
		}

		public string returnMyCurrency(string databasefieldname, int companyId, int userId, string strDate, string inputtype, string labelname)
		{
			if (inputtype.ToLower().Trim() == "currency")
			{
				labelname = string.Concat(labelname, " (", Convert.ToString(this.Session["currency"]), ") ");
			}
			return labelname;
		}
	}
}