using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLoginclass;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BaseClass : System.Web.UI.Page
{
	public static string imagepath;

	public static string strimagepath;

	public static string SitePath;

	static BaseClass()
	{
		BaseClass.imagepath = EprintConfigurationManager.AppSettings["ImagePath"].ToString();
		BaseClass.strimagepath = "";
		BaseClass.SitePath = EprintConfigurationManager.AppSettings["SitePath"].ToString();
	}

	public BaseClass()
	{
	}

	public int Check_MaxKit_Availability(long PriceCatalogueID, int NumberOfKit)
	{
		string empty = string.Empty;
		int num = 0;
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DataSet dataSet = new DataSet();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActualKitStockDetails_Select");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@NumberOfKit", DbType.Int32, NumberOfKit);
		dataSet = database.ExecuteDataSet(storedProcCommand);
		if (dataSet.Tables.Count > 0)
		{
			DataTable item = dataSet.Tables[0];
			int[] numArray = new int[item.Rows.Count];
			for (int i = 0; i < item.Rows.Count; i++)
			{
				numArray[i] = Convert.ToInt32(item.Rows[i]["MaxNumKitAvailable"].ToString());
			}
			num = ((int)numArray.Length <= 0 ? 0 : numArray.Min());
		}
		if (num != 0)
		{
			return num;
		}
		return num;
	}

	public static string EprintImagePath()
	{
		return BaseClass.imagepath;
	}

	public long GetParentIDOfOtherMultipleProduct(long KitItemID)
	{
		long num = (long)0;
		DataSet dataSet = new DataSet();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetParentIDOfOtherMultipleProduct");
		database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, KitItemID);
		dataSet = database.ExecuteDataSet(storedProcCommand);
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			num = Convert.ToInt64(row["PriceCatalogueID"].ToString());
		}
		return num;
	}

	public static string imagePath()
	{
		return BaseClass.strimagepath;
	}

	public void KitStockAllocationOrReduction(long PriceCatalogueID, int Quantity, char Type, long CreatedBy)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Kit_AllocationOrReduction");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Quantity);
		database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
		database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
		database.ExecuteNonQuery(storedProcCommand);
	}

	protected override void OnInit(EventArgs e)
	{
		this.Session_Check();
	}

	public void Page_Error(object sender, EventArgs e)
	{
        string sitePath = ConnectionClass.SitePath;
        string empty = string.Empty;
        if (this.Session["CompanyName"] != null)
        {
            empty = this.SpecialDecode(this.Session["CompanyName"].ToString());
        }
        Exception baseException = base.Server.GetLastError().GetBaseException();
        StringBuilder stringBuilder = new StringBuilder();
        string[] str = new string[] { "[", EprintConfigurationManager.AppSettings["ServerName"].ToString(), "] ", empty, " an error occured." };
        string str1 = string.Concat(str);
        stringBuilder.Append(" An error has been occoured \n");
        stringBuilder.Append(string.Concat("\n Error in: ", base.Request.Url.ToString(), "\n"));
        stringBuilder.Append(string.Concat("\n Error Message: ", baseException.Message.ToString(), "\n"));
        stringBuilder.Append(string.Concat("\n Stack Trace:", baseException.StackTrace.ToString(), "\n"));
        stringBuilder.Append("\n");
        stringBuilder.Append("\n Thanks ");
        stringBuilder.Append("\n Regards ");
        stringBuilder.Append("\n support@eprintsoftware.com \n");
        DateTime now = DateTime.Now;
        stringBuilder.Append(string.Concat("\n Date:", now.ToString()));
        if (stringBuilder.ToString().Trim().ToLower().IndexOf("invalid length for a base-64 char array") == -1 && stringBuilder.ToString().Trim().ToLower().IndexOf("unable to read beyond the end of the stream") == -1)
        {
            EmailClass.SendMailMessage("errorlogs@hexicomsoftware.com", "errorlogs@hexicomsoftware.com", "emaillogs@hexicomsoftware.com", "", str1, stringBuilder.ToString(), "", false);
        }
        base.Server.ClearError();
        base.Response.Redirect(string.Concat(sitePath, "error_report.aspx?returnUrl=", base.Request.Url.ToString()));
    }

	public DataTable ProductStockType_Select(long CompanyID, long PriceCatalogueID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStockType_Select");
		database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public string ReplaceSingleQuote(string OriginalString)
	{
		return OriginalString.Replace("'", "`");
	}

	public string Return_StockManagementSettings(string Name)
	{
		string empty = string.Empty;
		if (this.Session["ProductStockManagement"] != null && this.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true" && this.Session["CompanyID"] != null)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementSettings_Select");
			database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"]));
			dataSet = database.ExecuteDataSet(storedProcCommand);
			if (dataSet.Tables.Count > 0)
			{
				DataTable item = dataSet.Tables[0];
				foreach (DataRow row in item.Rows)
				{
					foreach (DataColumn column in item.Columns)
					{
						if (column.ColumnName.ToString().Trim().ToLower() != Name.ToLower())
						{
							continue;
						}
						empty = row[column.ColumnName].ToString();
					}
				}
			}
		}
		return empty;
	}

	public void Session_Check()
	{
		if (HttpContext.Current.Session["StoreUserID"] == null && this.Context.Request.Cookies["ResumeSessionID"] != null)
		{
			HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
			if (item != null)
			{
				commonclass _commonclass = new commonclass();
				SqlCommand sqlCommand = new SqlCommand("[Ws_Select_ResumeSessionStore]", _commonclass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					loginclass _loginclass = new loginclass();
					_loginclass.LogIn_FromBaseClass(sqlDataReader["Email"].ToString(), sqlDataReader["Password"].ToString());
				}
				sqlDataReader.Close();
				_commonclass.closeConnection();
			}
		}
	}

	public void SetDDLText(DropDownList ddl, string text)
	{
		try
		{
			ListItem listItem = ddl.Items.FindByText(text);
			ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
		}
		catch
		{
		}
	}

	public void SetDDLValue(DropDownList ddl, string value)
	{
		try
		{
			ListItem listItem = ddl.Items.FindByValue(value);
			ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
		}
		catch
		{
		}
	}

	public string SpecialDecode(string OriginalString)
	{
		OriginalString = OriginalString.Replace("%27", "'");
		OriginalString = OriginalString.Replace("%22", "\"");
		return OriginalString;
	}

	public string SpecialEncode(string OriginalString)
	{
		OriginalString = OriginalString.Replace("'", "%27");
		OriginalString = OriginalString.Replace("\"", "%22");
		return OriginalString;
	}

	public void StockAllocation(long PriceCatalogueID, long PricecatalogueStockID, int AllocatedQty, long CreatedBy)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
		database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
		database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public string StockAllocation_Others(long CompanyID, long PriceCatalogueID, int MaxKitAvailable, string MetohdType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
	{
		string empty = string.Empty;
		long num = (long)0;
		int num1 = 0;
		empty = "No stock available";
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DataSet dataSet = new DataSet();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FinalKitStockDetails_Select");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@NumberOfKit", DbType.Int32, MaxKitAvailable);
		dataSet = database.ExecuteDataSet(storedProcCommand);
		if (dataSet.Tables.Count > 0)
		{
			DataTable item = dataSet.Tables[0];
			if (item.Rows.Count <= 0)
			{
				empty = "No Stock Available";
			}
			else
			{
				foreach (DataRow row in item.Rows)
				{
					num = Convert.ToInt64(row["KitItemID"].ToString());
					num1 = Convert.ToInt32(row["TotalRequiredQtyPerKit"].ToString());
					empty = this.StockAllocationProcess(CompanyID, num, PriceCatalogueID, num1, MetohdType, "others", IsPickStockFromOneLocation, ModuleID, ModuleName, Price, CreatedBy);
					if (empty == null || !(empty != ""))
					{
						continue;
					}
					empty = string.Concat(empty, ",");
				}
				if (empty.Contains("Stock allocated with back order successfully") || empty.Contains("Stock allocated successfully"))
				{
					string str = string.Empty;
					bool flag = false;
					if (empty.Contains("Stock allocated with back order successfully"))
					{
						flag = true;
						string str1 = string.Concat("Stock allocated with backorder for Job #", ModuleID);
						str = str1;
						str = str1;
					}
					else if (empty.Contains("Stock allocated successfully"))
					{
						flag = false;
						str = string.Concat("Stock allocated for Job #", ModuleID);
					}
					long num2 = this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, PriceCatalogueID, ModuleID, ModuleName, "others", (long)0, MaxKitAvailable, 0, "Allocated", Price, CreatedBy, flag);
					this.KitStockAllocationOrReduction(PriceCatalogueID, MaxKitAvailable, 'a', CreatedBy);
					this.StockAllocationManagementHistory_Save(num2, PriceCatalogueID, "Allocated", str, MaxKitAvailable, 0, 0, 0, CreatedBy, (long)0);
				}
			}
		}
		return empty;
	}

	public void StockAllocationAddOpt(long PriceCatalogueID, long PricecatalogueStockAdditionalId, int AllocatedQty, long CreatedBy)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation_AdditionalOption");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@PricecatalogueStockAdditionalId", DbType.Int64, PricecatalogueStockAdditionalId);
		database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
		database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public string StockAllocationForAdditionalOption(long CompanyID, long PriceCatalogueID, int Quantity, string MetohdType, string ProcessType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy, long OrderID, long OrderItemID)
	{
		string empty = string.Empty;
		string str = string.Empty;
		int quantity = 0;
		int num = 0;
		int num1 = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		bool flag = false;
		string empty1 = string.Empty;
		empty = "No stock available";
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DataSet dataSet = new DataSet();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_StockAdditionalOptionsDetails_Select");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
		database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
		database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		dataSet = database.ExecuteDataSet(storedProcCommand);
		if (dataSet.Tables.Count > 0)
		{
			DataTable item = dataSet.Tables[0];
			DataTable dataTable = dataSet.Tables[1];
			DataTable item1 = dataSet.Tables[2];
			DataTable dataTable1 = dataSet.Tables[3];
			foreach (DataRow row in dataTable.Rows)
			{
				flag = Convert.ToBoolean(row["IsBackOrder"].ToString());
			}
			foreach (DataRow dataRow in item1.Rows)
			{
				string str1 = dataRow["webothercostName"].ToString();
				dataRow["Label"].ToString();
				dataRow["webothercostid"].ToString();
				string str2 = dataRow["ChoiceID"].ToString();
				foreach (DataRow row1 in dataTable1.Rows)
				{
					if (!(str1 == row1["OptionName"].ToString()) || !(str2 == row1["choiceid"].ToString()))
					{
						continue;
					}
					empty1 = (Convert.ToInt32(row1["AvailableStock"].ToString()) < Quantity ? string.Concat(empty1, "true,") : string.Concat(empty1, "false,"));
				}
			}
			foreach (DataRow dataRow1 in item1.Rows)
			{
				quantity = Quantity;
				if (empty1.Contains("false"))
				{
					foreach (DataRow row2 in item.Rows)
					{
						long num6 = Convert.ToInt64(row2["PricecatalogueStockAdditionalId"].ToString());
						num3 = Convert.ToInt32(row2["OpeningStock"].ToString());
						num2 = Convert.ToInt32(row2["AllocatedStock"].ToString());
						num1 = Convert.ToInt32(row2["AvailableStock"].ToString());
						int num7 = Convert.ToInt32(row2["webothercostid"].ToString());
						string str3 = row2["webothercostName"].ToString();
						row2["Label"].ToString();
						string str4 = row2["ChoiceID"].ToString();
						if (quantity == 0 || !(dataRow1["webothercostName"].ToString() == str3) || !(dataRow1["ChoiceID"].ToString() == str4) || Convert.ToInt32(dataRow1["webothercostid"].ToString()) != num7)
						{
							continue;
						}
						if (quantity > num1)
						{
							num = num1;
							if (num1 < 0)
							{
								num = 0;
							}
							quantity = quantity - num;
							num1 = 0;
						}
						else
						{
							num = quantity;
							num1 = num1 - num;
							quantity = 0;
						}
						num2 = num2 + num;
						str = string.Concat("Additional Options Stock allocated for Job #", ModuleID);
						if (num == 0)
						{
							continue;
						}
						long num8 = this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, ProcessType, num6, num, 0, "Allocated", Price, CreatedBy, false);
						this.StockAllocationAddOpt(PriceCatalogueID, num6, num, CreatedBy);
						this.StockAllocationManagementHistory_Save(num8, PriceCatalogueID, "Allocated", str, num, num3, num2, num1, CreatedBy, num6);
					}
					empty = "Stock allocated successfully";
				}
				else if (!flag)
				{
					empty = "Back order not available for this stock";
				}
				else
				{
					foreach (DataRow dataRow2 in dataTable1.Rows)
					{
						string str5 = dataRow1["webothercostName"].ToString();
						dataRow1["Label"].ToString();
						dataRow1["webothercostid"].ToString();
						string str6 = dataRow1["ChoiceID"].ToString();
						if (!(str5 == dataRow2["OptionName"].ToString()) || !(str6 == dataRow2["choiceid"].ToString()))
						{
							continue;
						}
						num5 = Convert.ToInt32(dataRow2["AvailableStock"].ToString());
					}
					num4 = quantity - num5;
					foreach (DataRow row3 in item.Rows)
					{
						long num9 = Convert.ToInt64(row3["PricecatalogueStockAdditionalId"].ToString());
						num3 = Convert.ToInt32(row3["OpeningStock"].ToString());
						num2 = Convert.ToInt32(row3["AllocatedStock"].ToString());
						num1 = Convert.ToInt32(row3["AvailableStock"].ToString());
						int num10 = Convert.ToInt32(row3["webothercostid"].ToString());
						string str7 = row3["webothercostName"].ToString();
						string str8 = row3["Label"].ToString();
						if (quantity == 0 || !(dataRow1["webothercostName"].ToString() == str7) || !(dataRow1["Label"].ToString() == str8) || Convert.ToInt32(dataRow1["webothercostid"].ToString()) != num10)
						{
							continue;
						}
						if (quantity > num1)
						{
							num = num1;
							if (num1 < 0)
							{
								num = 0;
							}
							quantity = quantity - num;
							num1 = 0;
						}
						else
						{
							num = quantity;
							num1 = num1 - num;
							quantity = 0;
						}
						num2 = num2 + num;
						str = string.Concat("Stock allocated with backorder for Job #", ModuleID);
						if (num4 == quantity)
						{
							num = num + num4;
							num2 = num2 + num4;
							num1 = num3 - num2;
							quantity = 0;
						}
						if (num == 0)
						{
							continue;
						}
						long num11 = this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, ProcessType, num9, num, 0, "Allocated", Price, CreatedBy, false);
						this.StockAllocationAddOpt(PriceCatalogueID, num9, num, CreatedBy);
						this.StockAllocationManagementHistory_Save(num11, PriceCatalogueID, "Allocated", str, num, num3, num2, num1, CreatedBy, num9);
					}
					empty = "Stock allocated with back order successfully";
				}
			}
		}
		return empty;
	}

	public void StockAllocationManagementHistory_Save(long TransactionID, long PriceCatalogueID, string ActionType, string Notes, int Quantity, int StockInHand, int AllocatedStock, int AvailableStock, long CreatedBy, long PricecatalogueStockID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementHistory_Save");
		database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
		database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
		database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
		database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
		database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
		database.AddInParameter(storedProcCommand, "@AllocatedStock", DbType.Int32, AllocatedStock);
		database.AddInParameter(storedProcCommand, "@AvailableStock", DbType.Int32, AvailableStock);
		database.AddInParameter(storedProcCommand, "@StockInHand", DbType.Int32, StockInHand);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public string StockAllocationProcess(long CompanyID, long PriceCatalogueID, long KitID, int Quantity, string MetohdType, string ProcessType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
	{
		string empty = string.Empty;
		string str = string.Empty;
		int quantity = Quantity;
		int num = 0;
		int num1 = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		empty = "No stock available";
		if (ProcessType.ToLower() != "multiple" && KitID == (long)0)
		{
			KitID = this.GetParentIDOfOtherMultipleProduct(PriceCatalogueID);
		}
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DataSet dataSet = new DataSet();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockDetails_Select");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
		database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
		database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		dataSet = database.ExecuteDataSet(storedProcCommand);
		if (dataSet.Tables.Count > 0)
		{
			DataTable item = dataSet.Tables[0];
			DataTable dataTable = dataSet.Tables[1];
			Queue queues = new Queue();
			foreach (DataRow row in item.Rows)
			{
				string[] strArrays = new string[] { row["PricecatalogueStockID"].ToString(), "~", row["AvailableStock"].ToString(), "~", row["AllocatedStock"].ToString(), "~", row["OpeningStock"].ToString() };
				queues.Enqueue(string.Concat(strArrays));
			}
			foreach (DataRow dataRow in dataTable.Rows)
			{
				if (Convert.ToInt32(dataRow["AvailableQuantity"].ToString()) < Quantity)
				{
					bool flag = false;
					if (!(ProcessType.ToLower() != "others") || !(ProcessType.ToLower() != "multiple"))
					{
						DataSet dataSet1 = new DataSet();
						DbCommand dbCommand = database.GetStoredProcCommand("PC_CheckKitBackorder");
						database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, KitID);
						dataSet1 = database.ExecuteDataSet(dbCommand);
						foreach (DataRow row1 in dataSet1.Tables[0].Rows)
						{
							flag = Convert.ToBoolean(row1["IsBackOrder"].ToString());
						}
					}
					else
					{
						flag = Convert.ToBoolean(dataRow["IsBackOrder"].ToString());
					}
					if (!flag)
					{
						empty = "Back order not available for this stock";
					}
					else
					{
						num5 = Convert.ToInt32(dataRow["AvailableQuantity"].ToString());
						num4 = quantity - num5;
						if (queues.Count <= 0)
						{
							continue;
						}
						while (quantity != 0)
						{
							if (queues.Count <= 0)
							{
								num4 = quantity;
								foreach (DataRow dataRow1 in item.Rows)
								{
									string[] str1 = new string[] { dataRow1["PricecatalogueStockID"].ToString(), "~", dataRow1["AvailableStock"].ToString(), "~", dataRow1["AllocatedStock"].ToString(), "~", dataRow1["OpeningStock"].ToString() };
									queues.Enqueue(string.Concat(str1));
								}
							}
							else
							{
								string str2 = queues.Dequeue().ToString();
								string[] strArrays1 = str2.Split(new char[] { '~' });
								num1 = Convert.ToInt32(strArrays1[1].ToString());
								num2 = Convert.ToInt32(strArrays1[2].ToString());
								num3 = Convert.ToInt32(strArrays1[3].ToString());
								if (quantity > num1)
								{
									num = num1;
									if (num1 < 0)
									{
										num = 0;
									}
									quantity = quantity - num;
									num1 = 0;
								}
								else
								{
									num = quantity;
									num1 = num1 - num;
									quantity = 0;
								}
								num2 = num2 + num;
								str = string.Concat("Stock allocated with backorder for Job #", ModuleID);
								if (num4 == quantity && (Convert.ToInt32(strArrays1[1].ToString()) > 0 || queues.Count == 0))
								{
									num = num + num4;
									num2 = num2 + num4;
									num1 = num3 - num2;
									quantity = 0;
								}
								if (num == 0)
								{
									continue;
								}
								long num6 = this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, ProcessType, Convert.ToInt64(strArrays1[0].ToString()), num, 0, "Allocated", Price, CreatedBy, true);
								this.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays1[0].ToString()), num, CreatedBy);
								this.StockAllocationManagementHistory_Save(num6, PriceCatalogueID, "Allocated", str, num, num3, num2, num1, CreatedBy, Convert.ToInt64(strArrays1[0].ToString()));
							}
						}
						empty = "Stock allocated with back order successfully";
					}
				}
				else
				{
					if (queues.Count <= 0)
					{
						continue;
					}
					while (quantity != 0)
					{
						if (queues.Count <= 0)
						{
							continue;
						}
						string str3 = queues.Dequeue().ToString();
						string[] strArrays2 = str3.Split(new char[] { '~' });
						num1 = Convert.ToInt32(strArrays2[1].ToString());
						num2 = Convert.ToInt32(strArrays2[2].ToString());
						num3 = Convert.ToInt32(strArrays2[3].ToString());
						if (quantity > num1)
						{
							num = num1;
							if (num1 < 0)
							{
								num = 0;
							}
							quantity = quantity - num;
							num1 = 0;
						}
						else
						{
							num = quantity;
							num1 = num1 - num;
							quantity = 0;
						}
						num2 = num2 + num;
						str = string.Concat("Stock allocated for Job #", ModuleID);
						if (num == 0)
						{
							continue;
						}
						long num7 = this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, ProcessType, Convert.ToInt64(strArrays2[0].ToString()), num, 0, "Allocated", Price, CreatedBy, false);
						this.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays2[0].ToString()), num, CreatedBy);
						this.StockAllocationManagementHistory_Save(num7, PriceCatalogueID, "Allocated", str, num, num3, num2, num1, CreatedBy, Convert.ToInt64(strArrays2[0].ToString()));
					}
					empty = "Stock allocated successfully";
				}
			}
		}
		return empty;
	}

	public long StockManagementTransaction_Save(long TransactionID, long CompanyID, long PriceCatalogueID, long KITTransactionID, long ModuleID, string ModuleName, string DrawStockFrom, long PricecatalogueStockID, int AllocatedQty, int ReleasedQty, string ActionType, decimal Price, long CreatedBy, bool IsbackOrder)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementTransaction_Save");
		database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@KITTransactionID", DbType.Int64, KITTransactionID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		database.AddInParameter(storedProcCommand, "@DrawStockFrom", DbType.String, DrawStockFrom);
		database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
		database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
		database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
		database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
		database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
		database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
		database.AddInParameter(storedProcCommand, "@IsbackOrder", DbType.Boolean, IsbackOrder);
		database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
		database.ExecuteNonQuery(storedProcCommand);
		object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
		return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
	}

    public string Return_ApprovalRegistration_Settings(string fieldName)
    {
        string empty = string.Empty;
        if (this.Session["ApprovalRegistrationSettings"] != null)
        {
            DataTable item = (DataTable)this.Session["ApprovalRegistrationSettings"];
            foreach (DataRow row in item.Rows)
            {
                foreach (DataColumn column in item.Columns)
                {
                    if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                    {
                        continue;
                    }
                    empty = row[column.ColumnName].ToString();
                }
            }
        }
        return empty;
    }
}