using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsForecast
{
	public class forecastClass
	{
		public forecastClass()
		{
		}

		public int check_forecastName(int companyId, int userId, string forecastname)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_select_forecastname"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public string colorCode(int companyId, string pg)
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

		public void forecast_Add(int companyId, int userId, string forecastalias, string forecastname, string forecastyear, string quartername, string month1, string month2, string month3, double quoteamount1, double quoteamount2, double quoteamount3, double commitamount1, double commitamount2, double commitamount3, double bestcaseamount1, double bestcaseamount2, double bestcaseamount3, int intcategory, int createuserid, int modifyuserid, int isdelete, int issample)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_add"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@forecastalias", forecastalias);
			sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
			sqlCommand.Parameters.AddWithValue("@forecastyear", forecastyear);
			sqlCommand.Parameters.AddWithValue("@quartername", quartername);
			sqlCommand.Parameters.AddWithValue("@month1", month1);
			sqlCommand.Parameters.AddWithValue("@month2", month2);
			sqlCommand.Parameters.AddWithValue("@month3", month3);
			sqlCommand.Parameters.AddWithValue("@quoteamount1", quoteamount1);
			sqlCommand.Parameters.AddWithValue("@quoteamount2", quoteamount2);
			sqlCommand.Parameters.AddWithValue("@quoteamount3", quoteamount3);
			sqlCommand.Parameters.AddWithValue("@commitamount1", commitamount1);
			sqlCommand.Parameters.AddWithValue("@commitamount2", commitamount2);
			sqlCommand.Parameters.AddWithValue("@commitamount3", commitamount3);
			sqlCommand.Parameters.AddWithValue("@bestticketamount1", bestcaseamount1);
			sqlCommand.Parameters.AddWithValue("@bestticketamount2", bestcaseamount2);
			sqlCommand.Parameters.AddWithValue("@bestticketamount3", bestcaseamount3);
			sqlCommand.Parameters.AddWithValue("@intcategory", intcategory);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.Parameters.AddWithValue("@issample", issample);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
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

		public void forecast_Edit(int forecastId, int companyId, int userId, string forecastalias, string forecastname, string forecastyear, string quartername, string month1, string month2, string month3, double quoteamount1, double quoteamount2, double quoteamount3, double commitamount1, double commitamount2, double commitamount3, double bestcaseamount1, double bestcaseamount2, double bestcaseamount3, int intcategory, int modifyuserid, int isdelete, int issample)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_update"
			};
			sqlCommand.Parameters.AddWithValue("@forecastId", forecastId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@forecastalias", forecastalias);
			sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
			sqlCommand.Parameters.AddWithValue("@forecastyear", forecastyear);
			sqlCommand.Parameters.AddWithValue("@quartername", quartername);
			sqlCommand.Parameters.AddWithValue("@month1", month1);
			sqlCommand.Parameters.AddWithValue("@month2", month2);
			sqlCommand.Parameters.AddWithValue("@month3", month3);
			sqlCommand.Parameters.AddWithValue("@quoteamount1", quoteamount1);
			sqlCommand.Parameters.AddWithValue("@quoteamount2", quoteamount2);
			sqlCommand.Parameters.AddWithValue("@quoteamount3", quoteamount3);
			sqlCommand.Parameters.AddWithValue("@commitamount1", commitamount1);
			sqlCommand.Parameters.AddWithValue("@commitamount2", commitamount2);
			sqlCommand.Parameters.AddWithValue("@commitamount3", commitamount3);
			sqlCommand.Parameters.AddWithValue("@bestticketamount1", bestcaseamount1);
			sqlCommand.Parameters.AddWithValue("@bestticketamount2", bestcaseamount2);
			sqlCommand.Parameters.AddWithValue("@bestticketamount3", bestcaseamount3);
			sqlCommand.Parameters.AddWithValue("@intcategory", intcategory);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.Parameters.AddWithValue("@issample", issample);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader forecast_Getforecastname(int forecastid, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_getforecastname"
			};
			sqlCommand.Parameters.AddWithValue("@forecastid", forecastid);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader forecast_Pipeline_Select(int companyId, int userId, string forecastname)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_pipeline_detail"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader forecast_Select(int companyId, int userId, string forecastname)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_detail"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@forecastname", forecastname);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader forecast_Select_new(int forecastId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_detail_new"
			};
			sqlCommand.Parameters.AddWithValue("@forecastId", forecastId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader forecasthistory_Select(int forecastId, int companyId, int userId, string createDate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecasthistory_detail"
			};
			sqlCommand.Parameters.AddWithValue("@forecastId", forecastId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader select_Alluser(int companyId, int userId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_select_alluser"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader select_Opportunityvalue(int companyId, int userId, string month, string year)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_forecast_select_opportunity"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@userId", userId);
			sqlCommand.Parameters.AddWithValue("@month", month);
			sqlCommand.Parameters.AddWithValue("@year", year);
			return sqlCommand.ExecuteReader();
		}
	}
}