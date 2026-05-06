using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

public class forecast
{
	public forecast()
	{
	}

	public int check_forecastName(int CompanyId, int UserId, string forecastName)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "Select_ForecastName"
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
		sqlParameter.Direction = ParameterDirection.ReturnValue;
		sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyId);
		sqlCommand.Parameters.AddWithValue("@UserID", UserId);
		sqlCommand.Parameters.AddWithValue("@ForecastName", forecastName);
		sqlCommand.ExecuteNonQuery();
		_commonClass.closeConnection();
		return (int)sqlCommand.Parameters["ReturnValue"].Value;
	}

	public DataSet dsSaleperson(int companyID, int UserID)
	{
		SqlCommand sqlCommand = new SqlCommand("pc_Usertype_Select", (new commonClass()).openConnection())
		{
			CommandType = CommandType.StoredProcedure
		};
		sqlCommand.Parameters.AddWithValue("@companyID", companyID);
		sqlCommand.Parameters.AddWithValue("@UserID", UserID);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		return dataSet;
	}

	public void forecast_Add(int CompanyID, int UserID, string ForecastName, string ForecastYear, string QuarterName, string Month1, string Month2, string Month3, double TargetAmount1, double TargetAmount2, double TargetAmount3, double CommitAmount1, double CommitAmount2, double CommitAmount3, double BestAmount1, double BestAmount2, double BestAmount3, int Intcategory, int CreateUserID, int IsSample, int AssignToUserID)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "PC_Insert_Forecast"
		};
		sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
		sqlCommand.Parameters.AddWithValue("@UserID", UserID);
		sqlCommand.Parameters.AddWithValue("@ForecastName", ForecastName);
		sqlCommand.Parameters.AddWithValue("@ForecastYear", ForecastYear);
		sqlCommand.Parameters.AddWithValue("@QuarterName", QuarterName);
		sqlCommand.Parameters.AddWithValue("@Month1", Month1);
		sqlCommand.Parameters.AddWithValue("@Month2", Month2);
		sqlCommand.Parameters.AddWithValue("@Month3", Month3);
		sqlCommand.Parameters.AddWithValue("@TargetAmount1", TargetAmount1);
		sqlCommand.Parameters.AddWithValue("@TargetAmount2", TargetAmount2);
		sqlCommand.Parameters.AddWithValue("@TargetAmount3", TargetAmount3);
		sqlCommand.Parameters.AddWithValue("@CommitAmount1", CommitAmount1);
		sqlCommand.Parameters.AddWithValue("@CommitAmount2", CommitAmount2);
		sqlCommand.Parameters.AddWithValue("@CommitAmount3", CommitAmount3);
		sqlCommand.Parameters.AddWithValue("@BestAmount1", BestAmount1);
		sqlCommand.Parameters.AddWithValue("@BestAmount2", BestAmount2);
		sqlCommand.Parameters.AddWithValue("@BestAmount3", BestAmount3);
		sqlCommand.Parameters.AddWithValue("@Intcategory", Intcategory);
		sqlCommand.Parameters.AddWithValue("@CreateUserID", CreateUserID);
		sqlCommand.Parameters.AddWithValue("@IsSample", IsSample);
		sqlCommand.Parameters.AddWithValue("@AssignToUserID", AssignToUserID);
		sqlCommand.ExecuteNonQuery();
		_commonClass.closeConnection();
	}

	public SqlDataReader forecast_CompanySalesPerson_select(int companyId, int userId, int assignedID, string forecastname)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "pc_forecast_CompanySalesPerson_select"
		};
		sqlCommand.Parameters.AddWithValue("@CompanyID", companyId);
		sqlCommand.Parameters.AddWithValue("@UserID", userId);
		sqlCommand.Parameters.AddWithValue("@AssignToUserID", assignedID);
		sqlCommand.Parameters.AddWithValue("@ForecastName", forecastname);
		return sqlCommand.ExecuteReader();
	}

	public void forecast_Delete(int companyId, int userId, string forecastname)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "crm_forecast_delete"
		};
		sqlCommand.Parameters.AddWithValue("@companyId", companyId);
		sqlCommand.Parameters.AddWithValue("@userId", userId);
		sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
		sqlCommand.ExecuteNonQuery();
		_commonClass.closeConnection();
	}

	public SqlDataReader forecast_Pipeline_Select(int companyId, int userId, string forecastname)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "Select_forecast_pipeline_detail"
		};
		sqlCommand.Parameters.AddWithValue("@companyId", companyId);
		sqlCommand.Parameters.AddWithValue("@userId", userId);
		sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
		return sqlCommand.ExecuteReader();
	}

	public SqlDataReader forecast_Select_Userdetails(int companyId, int userId, int assignedID, string forecastname)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "pc_select_forecast_userdetails"
		};
		sqlCommand.Parameters.AddWithValue("@CompanyID", companyId);
		sqlCommand.Parameters.AddWithValue("@UserID", userId);
		sqlCommand.Parameters.AddWithValue("@AssignToUserID", assignedID);
		sqlCommand.Parameters.AddWithValue("@ForecastName", forecastname);
		return sqlCommand.ExecuteReader();
	}

	public void forecast_Update(int ForecastID, int CompanyID, int UserID, string ForecastName, string ForecastYear, string QuarterName, string Month1, string Month2, string Month3, double TargetAmount1, double TargetAmount2, double TargetAmount3, double CommitAmount1, double CommitAmount2, double CommitAmount3, double BestAmount1, double BestAmount2, double BestAmount3, int intcategory, int ModifiedUserID, int IsSample)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "Crm_Update_Forecast"
		};
		sqlCommand.Parameters.AddWithValue("@ForecastID", ForecastID);
		sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
		sqlCommand.Parameters.AddWithValue("@UserID", UserID);
		sqlCommand.Parameters.AddWithValue("@ForecastName", ForecastName);
		sqlCommand.Parameters.AddWithValue("@ForecastYear", ForecastYear);
		sqlCommand.Parameters.AddWithValue("@QuarterName", QuarterName);
		sqlCommand.Parameters.AddWithValue("@Month1", Month1);
		sqlCommand.Parameters.AddWithValue("@Month2", Month2);
		sqlCommand.Parameters.AddWithValue("@Month3", Month3);
		sqlCommand.Parameters.AddWithValue("@TargetAmount1", TargetAmount1);
		sqlCommand.Parameters.AddWithValue("@TargetAmount2", TargetAmount2);
		sqlCommand.Parameters.AddWithValue("@TargetAmount3", TargetAmount3);
		sqlCommand.Parameters.AddWithValue("@CommitAmount1", CommitAmount1);
		sqlCommand.Parameters.AddWithValue("@CommitAmount2", CommitAmount2);
		sqlCommand.Parameters.AddWithValue("@CommitAmount3", CommitAmount3);
		sqlCommand.Parameters.AddWithValue("@BestAmount1", BestAmount1);
		sqlCommand.Parameters.AddWithValue("@BestAmount2", BestAmount2);
		sqlCommand.Parameters.AddWithValue("@BestAmount3", BestAmount3);
		sqlCommand.Parameters.AddWithValue("@intcategory", intcategory);
		sqlCommand.Parameters.AddWithValue("@ModifiedUserID", ModifiedUserID);
		sqlCommand.Parameters.AddWithValue("@IsSample", IsSample);
		sqlCommand.ExecuteNonQuery();
		_commonClass.closeConnection();
	}

	public string returnMyCurrency(string strCurrency, int companyID, int userID)
	{
		double num;
		num = (strCurrency == "" ? 0 : double.Parse(strCurrency));
		return string.Format("{0:c}", num).Replace("$", "").Replace("£", "");
	}

	public DataTable Select_Exist_ForecastName(int CompanyID, string ForecastName)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("pc_ExitForecastName_Select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@ForecastName", DbType.String, ForecastName);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public SqlDataReader select_forecastdetails(int companyId, int userId, int forecastId)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "pc_select_forecastdetails"
		};
		sqlCommand.Parameters.AddWithValue("@CompanyID", companyId);
		sqlCommand.Parameters.AddWithValue("@UserID", userId);
		sqlCommand.Parameters.AddWithValue("@forecastId", forecastId);
		return sqlCommand.ExecuteReader();
	}

	public SqlDataReader select_forecastvalue(int companyId, int userId, string month, string year)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand()
		{
			Connection = _commonClass.openConnection(),
			CommandType = CommandType.StoredProcedure,
			CommandText = "pc_forecast_select_order"
		};
		sqlCommand.Parameters.AddWithValue("@companyId", companyId);
		sqlCommand.Parameters.AddWithValue("@userId", userId);
		sqlCommand.Parameters.AddWithValue("@month", month);
		sqlCommand.Parameters.AddWithValue("@year", year);
		return sqlCommand.ExecuteReader();
	}

	public DataTable SelectAllUsers(int companyID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Select_IsActivateUserForSalesTargets");
		database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, companyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}
}