using com.eprintsoftware.www;
using nmsConnection;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsCommon
{
	public class commonclass
	{
		public SqlConnection conn;

		public string connectionStringName = "CRMConnectionString";

		public string strConnection;

		private string _UniqueID = string.Empty;

		public string UniqueID
		{
			get
			{
				HttpSessionState session = HttpContext.Current.Session;
				if (session["UniqueID"] != null)
				{
					this._UniqueID = session.SessionID.ToString();
				}
				return this._UniqueID;
			}
		}

		public commonclass()
		{
			try
			{
				this.strConnection = EprintConfigurationManager.ConnectionStrings[this.connectionStringName].ToString();
			}
			catch
			{
			}
			this.conn = new SqlConnection(this.strConnection);
		}

		public void closeConnection()
		{
			this.conn.Close();
		}

		public string date_Check_new(string DateFormat, string txtvalue)
		{
			try
			{
				string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
				if (DateFormat == "mm/dd/yyyy")
				{
					if (DateFormat == "dd/mm/yyyy")
					{
						string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
						txtvalue = string.Concat(strArrays1);
					}
					else if (DateFormat == "mm/dd/yyyy")
					{
						string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
						txtvalue = string.Concat(strArrays2);
					}
				}
				if (DateFormat == "dd/mm/yyyy")
				{
					if (DateFormat == "dd/mm/yyyy")
					{
						string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
						txtvalue = string.Concat(strArrays3);
					}
					else if (DateFormat == "mm/dd/yyyy")
					{
						string[] strArrays4 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
						txtvalue = string.Concat(strArrays4);
					}
				}
			}
			catch
			{
				txtvalue = "1/1/1900";
			}
			return txtvalue;
		}

		public string Eprint_return_Date_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
		{
			DateTime dateTime=new DateTime();
			string str="";
			string str1;
			string empty = string.Empty;
			string empty1 = string.Empty;
			string upper = string.Empty;
			if (strDate.Length > 0)
			{
				try
				{
					empty = DateTime.Parse(strDate).ToShortDateString();
				}
				catch
				{
					try
					{
						string[] strArrays = new string[5];
						char[] chrArray = new char[] { '/' };
						strArrays[0] = strDate.Split(chrArray)[1];
						strArrays[1] = "/";
						char[] chrArray1 = new char[] { '/' };
						strArrays[2] = strDate.Split(chrArray1)[0];
						strArrays[3] = "/";
						char[] chrArray2 = new char[] { '/' };
						strArrays[4] = strDate.Split(chrArray2)[2];
						str1 = string.Concat(strArrays);
						return str1;
					}
					catch
					{
						str1 = strDate;
						return str1;
					}
				}
			}
			if ((empty != "01/01/1900") & (empty != "1/1/1900"))
			{
				try
				{
					dateTime = DateTime.Parse(strDate);
					commonclass _commonclass = new commonclass();
					SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonclass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
					sqlCommand.Parameters.AddWithValue("@userID", userID);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						EprintService eprintService = new EprintService();
						if (IsSystemGenerated)
						{
							dateTime = Convert.ToDateTime(eprintService.ReturnCurrentDateTimeByTimeZoneID(dateTime, sqlDataReader["timezonekey"].ToString()));
						}
						upper = sqlDataReader["dateformat"].ToString().ToUpper();
					}
					_commonclass.closeConnection();
					string str2 = dateTime.Hour.ToString();
					string str3 = dateTime.Minute.ToString();
					string str4 = dateTime.Second.ToString();
					string str5 = dateTime.Day.ToString();
					string str6 = dateTime.Month.ToString();
					string str7 = dateTime.Year.ToString().Substring(2);
					string str8 = dateTime.Year.ToString();
					if (str2.Length == 1)
					{
						str2 = string.Concat("0", str2);
					}
					if (str3.Length == 1)
					{
						str3 = string.Concat("0", str3);
					}
					if (str4.Length == 1)
					{
						str4 = string.Concat("0", str4);
					}
					if (str5.Length == 1)
					{
						str5 = string.Concat("0", str5);
					}
					if (str6.Length == 1)
					{
						str6 = string.Concat("0", str6);
					}
					str = "";
					string str9 = upper;
					string str10 = str9;
					if (str9 != null)
					{
						switch (str10)
						{
							case "DD/MM/YYYY-HHMM":
							{
								string[] strArrays1 = new string[] { str5, "/", str6, "/", str8, "-", str2, str3 };
								str = string.Concat(strArrays1);
								break;
							}
							case "DD-MM-YYYY-HHMM":
							{
								string[] strArrays2 = new string[] { str5, "-", str6, "-", str8, "-", str2, str3 };
								str = string.Concat(strArrays2);
								break;
							}
							case "HHMM-DD-MM-YYYY":
							{
								string[] strArrays3 = new string[] { str2, str3, "-", str5, "-", str6, "-", str8 };
								str = string.Concat(strArrays3);
								break;
							}
							case "HHMM/DD/MM/YYYY":
							{
								string[] strArrays4 = new string[] { str2, str3, "/", str5, "/", str6, "-", str8 };
								str = string.Concat(strArrays4);
								break;
							}
							case "HH:MM-DD-MM-YYYY":
							{
								string[] strArrays5 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str8 };
								str = string.Concat(strArrays5);
								break;
							}
							case "HH:MM/MM/DD/YYYY":
							{
								string[] strArrays6 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str8 };
								str = string.Concat(strArrays6);
								break;
							}
							case "DD/MM/YYYY":
							{
								string[] strArrays7 = new string[] { str5, "/", str6, "/", str8 };
								str = string.Concat(strArrays7);
								break;
							}
							case "MM/DD/YYYY":
							{
								string[] strArrays8 = new string[] { str6, "/", str5, "/", str8 };
								str = string.Concat(strArrays8);
								break;
							}
							case "DD-MM-YYYY":
							{
								string[] strArrays9 = new string[] { str5, "-", str6, "-", str8 };
								str = string.Concat(strArrays9);
								break;
							}
							case "DD/MM/YY":
							{
								string[] strArrays10 = new string[] { str5, "/", str6, "/", str7 };
								str = string.Concat(strArrays10);
								break;
							}
							case "MM/DD/YY":
							{
								string[] strArrays11 = new string[] { str6, "/", str5, "/", str7 };
								str = string.Concat(strArrays11);
								break;
							}
							default:
							{
								goto Label1;
							}
						}
					}
					else
					{
						goto Label1;
					}
				//Label2:
				//	empty1 = str.ToString();
				}
				catch
				{
					str1 = strDate;
					return str1;
				}
			}
			
		Label1:
            empty1 = str.ToString();
            //goto Label2;

        //Label2:
        //    empty1 = str.ToString();

            return empty1;
        }

		public string Eprint_return_DateTime_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
		{
			string str;
			int num;
			string empty = string.Empty;
			string empty1 = string.Empty;
			string upper = string.Empty;
			if (strDate.Length > 0)
			{
				empty = DateTime.Parse(strDate).ToShortDateString();
			}
			if ((empty != "01/01/1900") & (empty != "1/1/1900"))
			{
				try
				{
					DateTime dateTime = DateTime.Parse(strDate);
					commonclass _commonclass = new commonclass();
					SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonclass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
					sqlCommand.Parameters.AddWithValue("@userID", userID);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						EprintService eprintService = new EprintService();
						if (IsSystemGenerated)
						{
							dateTime = Convert.ToDateTime(eprintService.ReturnCurrentDateTimeByTimeZoneID(dateTime, sqlDataReader["timezonekey"].ToString()));
						}
						upper = sqlDataReader["dateformat"].ToString().ToUpper();
					}
					_commonclass.closeConnection();
					string str1 = dateTime.Hour.ToString();
					if (Convert.ToInt16(str1) == 0)
					{
						num = 12;
					}
					else
					{
						num = (Convert.ToInt16(str1) > 12 ? Convert.ToInt16(str1) - 12 : (int)Convert.ToInt16(str1));
					}
					string str2 = Convert.ToString(num);
					string str3 = dateTime.Minute.ToString();
					string str4 = dateTime.Second.ToString();
					string str5 = dateTime.Day.ToString();
					string str6 = dateTime.Month.ToString();
					string str7 = dateTime.Year.ToString().Substring(2);
					string str8 = (Convert.ToInt16(str1) >= 12 ? "PM" : "AM");
					string str9 = dateTime.Year.ToString();
					if (str2.Length == 1)
					{
						str2 = string.Concat("0", str2);
					}
					if (str3.Length == 1)
					{
						str3 = string.Concat("0", str3);
					}
					if (str4.Length == 1)
					{
						str4 = string.Concat("0", str4);
					}
					if (str8.Length == 1)
					{
						str8 = string.Concat("0", str8);
					}
					if (str5.Length == 1)
					{
						str5 = string.Concat("0", str5);
					}
					if (str6.Length == 1)
					{
						str6 = string.Concat("0", str6);
					}
					string str10 = "";
					string str11 = upper;
					string str12 = str11;
					if (str11 != null)
					{
						switch (str12)
						{
							case "DD/MM/YYYY-HHMM":
							{
								string[] strArrays = new string[] { str5, "/", str6, "/", str9, "-", str2, str3 };
								str10 = string.Concat(strArrays);
								break;
							}
							case "DD-MM-YYYY-HHMM":
							{
								string[] strArrays1 = new string[] { str5, "-", str6, "-", str9, "-", str2, str3 };
								str10 = string.Concat(strArrays1);
								break;
							}
							case "HHMM-DD-MM-YYYY":
							{
								string[] strArrays2 = new string[] { str2, str3, "-", str5, "-", str6, "-", str9 };
								str10 = string.Concat(strArrays2);
								break;
							}
							case "HHMM/DD/MM/YYYY":
							{
								string[] strArrays3 = new string[] { str2, str3, "/", str5, "/", str6, "-", str9 };
								str10 = string.Concat(strArrays3);
								break;
							}
							case "HH:MM-DD-MM-YYYY":
							{
								string[] strArrays4 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str9 };
								str10 = string.Concat(strArrays4);
								break;
							}
							case "HH:MM/MM/DD/YYYY":
							{
								string[] strArrays5 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str9 };
								str10 = string.Concat(strArrays5);
								break;
							}
							case "DD/MM/YYYY":
							{
								string[] strArrays6 = new string[] { str5, "/", str6, "/", str9, " ", str2, ":", str3, ":", str4, " ", str8 };
								str10 = string.Concat(strArrays6);
								break;
							}
							case "MM/DD/YYYY":
							{
								string[] strArrays7 = new string[] { str6, "/", str5, "/", str9, " ", str2, ":", str3, ":", str4, " ", str8 };
								str10 = string.Concat(strArrays7);
								break;
							}
							case "DD-MM-YYYY":
							{
								string[] strArrays8 = new string[] { str5, "-", str6, "-", str9 };
								str10 = string.Concat(strArrays8);
								break;
							}
							case "DD/MM/YY":
							{
								string[] strArrays9 = new string[] { str5, "/", str6, "/", str7 };
								str10 = string.Concat(strArrays9);
								break;
							}
							case "MM/DD/YY":
							{
								string[] strArrays10 = new string[] { str6, "/", str5, "/", str7 };
								str10 = string.Concat(strArrays10);
								break;
							}
							default:
							{
								str10 = dateTime.ToString();
								empty1 = str10.ToString();
								return empty1;
							}
						}
					}
					else
					{
						str10 = dateTime.ToString();
						empty1 = str10.ToString();
						return empty1;
					}
					empty1 = str10.ToString();
					return empty1;
				}
				catch
				{
					str = strDate;
				}
				return str;
			}
			return empty1;
		}

		public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView)
		{
			int scale = 0;
			int num = 0;
			DataTable dataTable = ProductBasePage.default_price_for_pack_select(CompanyID);
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["Roundoff"].ToString());
				}
			}
			scale = num;
			if (Scale > 0)
			{
				scale = Scale;
			}
			if (IsQuantity && !isAddDecimalPlacesToQty)
			{
				return Math.Round(Amount, 0, MidpointRounding.AwayFromZero).ToString();
			}
			string str = string.Concat("N", scale.ToString());
			decimal num1 = Math.Round(Amount, scale, MidpointRounding.AwayFromZero);
			if (!isView)
			{
				return num1.ToString();
			}
			CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
			string str1 = string.Concat("{0:", str, "}");
			object[] objArray = new object[] { num1 };
			return string.Format(cultureInfo, str1, objArray);
		}

		public string GetAddressLabelByKey(string AddressKey)
		{
			HttpSessionState session = HttpContext.Current.Session;
			Hashtable hashtables = new Hashtable();
			Hashtable item = new Hashtable();
			if (session["StoreUserID"] == null)
			{
				commonclass _commonclass = new commonclass();
				DataTable dataTable = new DataTable();
				SqlCommand sqlCommand = new SqlCommand("PC_GetAddressLabelByKey", _commonclass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				if (session["CompanyID"] == null)
				{
					sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
				}
				else
				{
					sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
				}
				dataTable.Load(sqlCommand.ExecuteReader());
				foreach (DataRow row in dataTable.Rows)
				{
					hashtables.Add(row["AddresslKey"].ToString().ToLower(), row["AddressValue"].ToString());
					item.Add(row["AddresslKey"].ToString().ToLower(), row["isRequired"].ToString());
				}
				_commonclass.closeConnection();
			}
			else if (session["ClientAddressLabels"] != null)
			{
				hashtables = (Hashtable)session["ClientAddressLabels"];
				item = (Hashtable)session["ClientAddressMandatory"];
			}
			else
			{
				commonclass _commonclass1 = new commonclass();
				DataTable dataTable1 = new DataTable();
				SqlCommand sqlCommand1 = new SqlCommand("PC_GetAddressLabelByKey", _commonclass1.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				if (session["CompanyID"] == null)
				{
					sqlCommand1.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
				}
				else
				{
					sqlCommand1.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
				}
				dataTable1.Load(sqlCommand1.ExecuteReader());
				foreach (DataRow dataRow in dataTable1.Rows)
				{
					hashtables.Add(dataRow["AddresslKey"].ToString().ToLower(), dataRow["AddressValue"].ToString());
					item.Add(dataRow["AddresslKey"].ToString().ToLower(), dataRow["isRequired"].ToString());
				}
				session["ClientAddressLabels"] = hashtables;
				session["ClientAddressMandatory"] = item;
				_commonclass1.closeConnection();
			}
			string str = hashtables[AddressKey.ToLower()].ToString();
			if (str.Length == 0)
			{
				AddressKey = string.Concat(char.ToUpper(AddressKey[0]), AddressKey.Substring(1));
				str = AddressKey;
			}
			return str;
		}

		public string GetCurrencyinRequiredFormate(string Amount, bool isSignRequired)
		{
			return string.Concat(ConnectionClass.CurrencySymbol, Amount);
		}

		public string GetDisplayValue(string tabName, long AccountID)
		{
			DataTable displaySettings;
			HttpSessionState session = HttpContext.Current.Session;
			string empty = string.Empty;
			try
			{
				if (session["StoreUserID"] == null)
				{
					displaySettings = CMSBasePage.GetDisplaySettings(AccountID);
					if (displaySettings.Rows.Count > 0)
					{
						empty = (tabName == "CommentsDefaultValue" || tabName == "OrderTitleText" || tabName == "OrderNumberText" || tabName == "DeliveryRequiredByText" || tabName == "CommentsText" || tabName == "OrderTitleValue" || tabName == "OrderNumberValue" || tabName == "OrderInformationHeading" || tabName == "AddressInformationHeading" || tabName == "OrderConfirmationHeading" || tabName == "PaymentInformationHeading" || tabName == "ExampleNoteValue" || tabName == "OrderConfirmationValue" || tabName == "isCheckCooments" ? displaySettings.Rows[0][tabName].ToString() : displaySettings.Rows[0][tabName].ToString().ToLower());
					}
				}
				else if (session["eStoreDisplaySetting"] != null)
				{
					displaySettings = (DataTable)session["eStoreDisplaySetting"];
					if (displaySettings.Rows.Count > 0)
					{
						empty = (tabName == "CommentsDefaultValue" || tabName == "OrderTitleText" || tabName == "OrderNumberText" || tabName == "DeliveryRequiredByText" || tabName == "CommentsText" || tabName == "OrderTitleValue" || tabName == "OrderNumberValue" || tabName == "OrderInformationHeading" || tabName == "AddressInformationHeading" || tabName == "OrderConfirmationHeading" || tabName == "PaymentInformationHeading" || tabName == "ExampleNoteValue" || tabName == "OrderConfirmationValue" || tabName == "isCheckCooments" ? displaySettings.Rows[0][tabName].ToString() : displaySettings.Rows[0][tabName].ToString().ToLower());
					}
				}
			}
			catch
			{
				empty = "true";
			}
			return empty;
		}

		public int GetIsRightBanner(int CompanyID, long AccountID)
		{
			return LoginBasePage.GetIsRightBanner(CompanyID, AccountID);
		}

		public string GetMandatoryByKey(string AddressKey)
		{
			string empty = string.Empty;
			try
			{
				HttpSessionState session = HttpContext.Current.Session;
				Hashtable hashtables = new Hashtable();
				if (session["StoreUserID"] == null)
				{
					commonclass _commonclass = new commonclass();
					DataTable dataTable = new DataTable();
					SqlCommand sqlCommand = new SqlCommand("PC_GetAddressLabelByKey", _commonclass.openConnection())
					{
						CommandType = CommandType.StoredProcedure
					};
					if (session["CompanyID"] == null)
					{
						sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
					}
					else
					{
						sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
					}
					dataTable.Load(sqlCommand.ExecuteReader());
					foreach (DataRow row in dataTable.Rows)
					{
						hashtables.Add(row["AddresslKey"].ToString().ToLower(), row["isRequired"].ToString());
					}
					_commonclass.closeConnection();
				}
				else
				{
					hashtables = (Hashtable)session["ClientAddressMandatory"];
				}
				empty = hashtables[AddressKey.ToLower()].ToString();
			}
			catch
			{
			}
			return empty;
		}

		public int GetWeekNumber(string WeekDay)
		{
			int num = 0;
			string lower = WeekDay.Trim().ToLower();
			string str = lower;
			if (lower != null)
			{
				switch (str)
				{
					case "sunday":
					{
						num = 1;
						break;
					}
					case "monday":
					{
						num = 2;
						break;
					}
					case "tuesday":
					{
						num = 3;
						break;
					}
					case "wednesday":
					{
						num = 4;
						break;
					}
					case "thursday":
					{
						num = 5;
						break;
					}
					case "friday":
					{
						num = 6;
						break;
					}
					case "saturday":
					{
						num = 7;
						break;
					}
					default:
					{
						num = -1;
						return num;
					}
				}
			}
			else
			{
				num = -1;
				return num;
			}
			return num;
		}

		public bool IsPrivate_SystemName()
		{
			string empty = string.Empty;
			string str = string.Empty;
			int num = 0;
			long num1 = (long)0;
			bool flag = false;
			if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
			{
				num = Convert.ToInt32(ConnectionClass.CompanyID);
			}
			if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
			{
				num1 = Convert.ToInt64(ConnectionClass.AccountID);
			}
			if (ConnectionClass.SystemName != null)
			{
				empty = ConnectionClass.SystemName.ToString().ToLower().Trim();
			}
			foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)num, num1).Rows)
			{
				str = row["accountType"].ToString().ToLower().Trim();
			}
			if (empty == "ppw" && str == "p")
			{
				flag = true;
			}
			return flag;
		}

		public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type)
		{
			if (Type == "matrix")
			{
				ddlMutiple.DataSource = dtMul;
				ddlMutiple.DataTextField = "ToQuantity";
				ddlMutiple.DataValueField = "FormulaNew";
				ddlMutiple.DataBind();
				plhPriceCalculator.Controls.Add(ddlMutiple);
				return;
			}
			ddlMutiple.DataSource = dtMul;
			ddlMutiple.DataTextField = "Label";
			ddlMutiple.DataValueField = "FormulaNew";
			ddlMutiple.DataBind();
			plhPriceCalculator.Controls.Add(ddlMutiple);
		}

		public SqlConnection openConnection()
		{
			this.conn.Open();
			return this.conn;
		}

		public static string pageTitle(string title, int companyID, int AccountID)
		{
			string empty = string.Empty;
			foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)companyID, (long)AccountID).Rows)
			{
				empty = row["accountName"].ToString();
			}
			if (empty == "")
			{
				empty = "E-Print Software";
			}
			return string.Concat(empty, ": ", title);
		}

		public string ReplaceAllBlankSpace(string OriginalString)
		{
			return OriginalString.Replace(" ", "_");
		}

		public string return_AccountID(string WebAccountType)
		{
			string empty = string.Empty;
			if (WebAccountType.ToLower() == "private")
			{
				HttpSessionState session = HttpContext.Current.Session;
				if (session["StoreUserID"] == null)
				{
					empty = "0";
				}
				else
				{
					DataTable dataTable = LoginBasePage.StoreUser_select(Convert.ToInt64(session["StoreUserID"]));
					foreach (DataRow row in dataTable.Rows)
					{
						empty = row["AccountID"].ToString();
					}
				}
			}
			return empty;
		}

		public string return_AccountSliderTime(long CompanyID, long AccountID)
		{
			string empty = string.Empty;
			foreach (DataRow row in LoginBasePage.Select_AccountDetails(CompanyID, AccountID).Rows)
			{
				empty = row["BannerSliderTime"].ToString();
			}
			return empty;
		}

		public string return_AccountType(long CompanyID, long AccountID)
		{
			string empty = string.Empty;
			foreach (DataRow row in LoginBasePage.Select_AccountDetails(CompanyID, AccountID).Rows)
			{
				empty = row["accountType"].ToString();
			}
			return empty;
		}

		public string return_CompanyID(string WebAccountType)
		{
			HttpSessionState session = HttpContext.Current.Session;
			string str = "0";
			if (WebAccountType.ToLower() == "private")
			{
				if (session["StoreUserID"] == null)
				{
					str = "0";
				}
				else
				{
					DataTable dataTable = LoginBasePage.StoreUser_select(Convert.ToInt64(session["StoreUserID"]));
					foreach (DataRow row in dataTable.Rows)
					{
						str = row["CompanyID"].ToString();
					}
				}
			}
			else if (WebAccountType.ToLower() == "public")
			{
				DataTable dataTable1 = LoginBasePage.Select_AccountDetails((long)0, Convert.ToInt64(ConnectionClass.AccountID));
				foreach (DataRow dataRow in dataTable1.Rows)
				{
					str = dataRow["CompanyID"].ToString();
				}
				str = str.ToString();
			}
			session["CompanyID"] = str;
			return str;
		}

		public decimal ReturnExact2Decimal(decimal Amount)
		{
			Amount = Amount * new decimal(100);
			string[] strArrays = Amount.ToString().Split(new char[] { '.' });
			decimal num = new decimal(0);
			num = Convert.ToDecimal(strArrays[0]);
			Amount = num / new decimal(100);
			return Amount;
		}

		public DateTime ReturnWeekDate(DateTime TodaysDate, int WorkingDaysFrom, int WorkingDaysTo, int AddDays)
		{
			DateTime todaysDate;
			if (AddDays == 0)
			{
				return TodaysDate;
			}
			this.GetWeekNumber(TodaysDate.DayOfWeek.ToString());
			DateTime dateTime = TodaysDate;
			int num = 1;
		Label1:
			while (num <= AddDays)
			{
				try
				{
					dateTime = dateTime.AddDays(1);
					int weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
					if (WorkingDaysFrom <= WorkingDaysTo)
					{
						while (weekNumber < WorkingDaysFrom || weekNumber > WorkingDaysTo)
						{
							dateTime = dateTime.AddDays(1);
							weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
						}
					}
					else
					{
						while (weekNumber < WorkingDaysFrom)
						{
							if (weekNumber > WorkingDaysTo)
							{
								dateTime = dateTime.AddDays(1);
								weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
							}
							else
							{
								break;
							}
						}
					}
					goto Label0;
				}
				catch
				{
					todaysDate = TodaysDate;
				}
				return todaysDate;
			}
			return dateTime;
		Label0:
			num++;
			goto Label1;
		}

		public string ToRemoveDecimalPlacesIfZero(string Amount)
		{
			bool flag = false;
			if (Amount.Contains("."))
			{
				int num = Amount.IndexOf(".") + 1;
				while (num < Amount.Length)
				{
					if (Amount.Substring(num, 1) != "0")
					{
						flag = false;
						break;
					}
					else
					{
						flag = true;
						num++;
					}
				}
			}
			if (flag)
			{
				try
				{
					Amount = Amount.Substring(0, Amount.IndexOf("."));
				}
				catch
				{
				}
			}
			return Amount;
		}
	}
}