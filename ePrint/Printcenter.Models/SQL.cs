using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Xml;

public sealed class SQL
{
	private SQL()
	{
	}

	private static void AssignParameterValues(SqlParameter[] commandParameters, DataRow dataRow)
	{
		if (commandParameters == null || dataRow == null)
		{
			return;
		}
		int num = 0;
		SqlParameter[] sqlParameterArray = commandParameters;
		for (int i = 0; i < (int)sqlParameterArray.Length; i++)
		{
			SqlParameter item = sqlParameterArray[i];
			if (item.ParameterName == null || item.ParameterName.Length <= 1)
			{
				throw new Exception(string.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", num, item.ParameterName));
			}
			if (dataRow.Table.Columns.IndexOf(item.ParameterName.Substring(1)) != -1)
			{
				item.Value = dataRow[item.ParameterName.Substring(1)];
			}
			num++;
		}
	}

	private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
	{
		if (commandParameters == null || parameterValues == null)
		{
			return;
		}
		int length = (int)commandParameters.Length;
		int num = 0;
		int length1 = (int)parameterValues.Length;
		while (num < length1)
		{
			if (((SqlParameter)parameterValues[num]).ParameterName == "ReturnValue")
			{
				length++;
			}
			num++;
		}
		if (length != (int)parameterValues.Length)
		{
			throw new ArgumentException("Parameter count does not match Parameter Value count.");
		}
		int num1 = 0;
		int length2 = (int)commandParameters.Length;
		while (num1 < length2)
		{
			if (parameterValues[num1] is IDbDataParameter)
			{
				IDbDataParameter dbDataParameter = (IDbDataParameter)parameterValues[num1];
				if (dbDataParameter.Value != null)
				{
					commandParameters[num1].Value = dbDataParameter.Value;
				}
				else
				{
					commandParameters[num1].Value = DBNull.Value;
				}
			}
			else if (parameterValues[num1] != null)
			{
				commandParameters[num1].Value = parameterValues[num1];
			}
			else
			{
				commandParameters[num1].Value = DBNull.Value;
			}
			num1++;
		}
	}

	private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues, bool returnValue)
	{
		if (commandParameters == null || parameterValues == null)
		{
			return;
		}
		if ((int)commandParameters.Length != (int)parameterValues.Length)
		{
			throw new ArgumentException("Parameter count does not match Parameter Value count.");
		}
		int num = 0;
		int length = (int)commandParameters.Length;
		while (num < length)
		{
			if (parameterValues[num] is IDbDataParameter)
			{
				IDbDataParameter dbDataParameter = (IDbDataParameter)parameterValues[num];
				if (dbDataParameter.Value != null)
				{
					commandParameters[num].Value = dbDataParameter.Value;
				}
				else
				{
					commandParameters[num].Value = DBNull.Value;
				}
			}
			else if (parameterValues[num] != null)
			{
				commandParameters[num].Value = parameterValues[num];
			}
			else
			{
				commandParameters[num].Value = DBNull.Value;
			}
			num++;
		}
	}

	private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (commandParameters != null)
		{
			SqlParameter[] sqlParameterArray = commandParameters;
			for (int i = 0; i < (int)sqlParameterArray.Length; i++)
			{
				SqlParameter value = sqlParameterArray[i];
				if (value != null)
				{
					if ((value.Direction == ParameterDirection.InputOutput || value.Direction == ParameterDirection.Input) && value.Value == null)
					{
						value.Value = DBNull.Value;
					}
					command.Parameters.Add(value);
				}
			}
		}
	}

	public static SqlCommand CreateCommand(SqlConnection connection, string spName, params string[] sourceColumns)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		SqlCommand sqlCommand = new SqlCommand(spName, connection)
		{
			CommandType = CommandType.StoredProcedure
		};
		if (sourceColumns != null && (int)sourceColumns.Length > 0)
		{
			SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
			for (int i = 0; i < (int)sourceColumns.Length; i++)
			{
				spParameterSet[i].SourceColumn = sourceColumns[i];
			}
			SQL.AttachParameters(sqlCommand, spParameterSet);
		}
		return sqlCommand;
	}

	public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
	{
		return SQL.ExecuteDataset(connectionString, commandType, commandText, null);
	}

	public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		DataSet dataSet;
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			dataSet = SQL.ExecuteDataset(sqlConnection, commandType, commandText, commandParameters);
		}
		return dataSet;
	}

	public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, bool flag, params SqlParameter[] commandParameters)
	{
		DataSet dataSet;
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			dataSet = SQL.ExecuteDataset(sqlConnection, commandType, commandText, true, commandParameters);
		}
		return dataSet;
	}

	public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
	{
		return SQL.ExecuteDataset(connection, commandType, commandText, null);
	}

	public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		DataSet dataSet;
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		SqlCommand sqlCommand = new SqlCommand()
		{
			CommandTimeout = 3000
		};
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
		{
			DataSet dataSet1 = new DataSet();
			sqlDataAdapter.Fill(dataSet1);
			sqlCommand.Parameters.Clear();
			if (flag)
			{
				connection.Close();
			}
			dataSet = dataSet1;
		}
		return dataSet;
	}

	public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, bool flag, params SqlParameter[] commandParameters)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand sqlCommand = new SqlCommand();
			bool flag1 = false;
			SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag1);
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
			{
				sqlDataAdapter.Fill(dataSet);
				sqlCommand.Parameters.Clear();
				if (flag1)
				{
					connection.Close();
				}
			}
		}
		catch (SqlException sqlException1)
		{
			SqlException sqlException = sqlException1;
			DataTable dataTable = new DataTable();
			DataRow str = dataTable.NewRow();
			DataColumn dataColumn = new DataColumn("CNDBerror", typeof(string));
			dataTable.Columns.Add(dataColumn);
			dataColumn = new DataColumn("msg", typeof(string));
			dataTable.Columns.Add(dataColumn);
			str["CNDBerror"] = "yes";
			str["msg"] = sqlException.Message.ToString();
			dataTable.Rows.InsertAt(str, 0);
			dataSet.Tables.Add(dataTable);
		}
		return dataSet;
	}

	public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
	{
		return SQL.ExecuteDataset(transaction, commandType, commandText, null);
	}

	public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		DataSet dataSet;
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
		{
			DataSet dataSet1 = new DataSet();
			sqlDataAdapter.Fill(dataSet1);
			sqlCommand.Parameters.Clear();
			dataSet = dataSet1;
		}
		return dataSet;
	}

	public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataSet ExecuteDatasetTypedParams(string connectionString, string spName, DataRow dataRow)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataSet ExecuteDatasetTypedParams(SqlConnection connection, string spName, DataRow dataRow)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataSet ExecuteDatasetTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static DataTable ExecuteDatatable(string connectionString, string strTableName)
	{
		DataTable schema;
		DataTable dataTable = new DataTable();
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			string[] strArrays = new string[] { null, null, strTableName, null };
			schema = sqlConnection.GetSchema("Columns", strArrays);
		}
		return schema;
	}

	public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
	{
		return SQL.ExecuteNonQuery(connectionString, commandType, commandText, null);
	}

	public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		int num;
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			num = SQL.ExecuteNonQuery(sqlConnection, commandType, commandText, commandParameters);
		}
		return num;
	}

	public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
	{
		return SQL.ExecuteNonQuery(connection, commandType, commandText, null);
	}

	public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		SqlCommand sqlCommand = new SqlCommand()
		{
			CommandTimeout = 3000
		};
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
		int num = 10;
		num = sqlCommand.ExecuteNonQuery();
		sqlCommand.Parameters.Clear();
		if (flag)
		{
			connection.Close();
		}
		return num;
	}

	public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
	{
		return SQL.ExecuteNonQuery(transaction, commandType, commandText, null);
	}

	public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
		int num = sqlCommand.ExecuteNonQuery();
		sqlCommand.Parameters.Clear();
		return num;
	}

	public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static int ExecuteNonQuery(string connectionString, string spName, bool returnValue, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return 0;
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName, returnValue);
		SQL.AssignParameterValues(spParameterSet, parameterValues, returnValue);
		int num = SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
		if (returnValue.Equals(true))
		{
			((SqlParameter)parameterValues[(int)parameterValues.Length - 1]).Value = spParameterSet[(int)spParameterSet.Length - 1].Value;
		}
		return num;
	}

	public static string ExecuteNonQuery1(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
		int num = 10;
		try
		{
			num = sqlCommand.ExecuteNonQuery();
		}
		catch (SqlException sqlException)
		{
			return sqlException.Errors.ToString();
		}
		catch (Exception exception)
		{
			HttpContext.Current.Response.Write(exception.Message.ToString());
		}
		sqlCommand.Parameters.Clear();
		if (flag)
		{
			connection.Close();
		}
		return num.ToString();
	}

	public static int ExecuteNonQueryTypedParams(string connectionString, string spName, DataRow dataRow)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static int ExecuteNonQueryTypedParams(SqlConnection connection, string spName, DataRow dataRow)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static int ExecuteNonQueryTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SQL.SqlConnectionOwnership connectionOwnership)
	{
		SqlDataReader sqlDataReader;
		SqlDataReader sqlDataReader1;
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		bool flag = false;
		SqlCommand sqlCommand = new SqlCommand();
		try
		{
			SQL.PrepareCommand(sqlCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
			sqlDataReader = (connectionOwnership != SQL.SqlConnectionOwnership.External ? sqlCommand.ExecuteReader(CommandBehavior.CloseConnection) : sqlCommand.ExecuteReader());
			bool flag1 = true;
			foreach (SqlParameter parameter in sqlCommand.Parameters)
			{
				if (parameter.Direction == ParameterDirection.Input)
				{
					continue;
				}
				flag1 = false;
			}
			if (flag1)
			{
				sqlCommand.Parameters.Clear();
			}
			sqlDataReader1 = sqlDataReader;
		}
		catch
		{
			if (flag)
			{
				connection.Close();
			}
			throw;
		}
		return sqlDataReader1;
	}

	public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
	{
		return SQL.ExecuteReader(connectionString, commandType, commandText, null);
	}

	public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		SqlDataReader sqlDataReader;
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		SqlConnection sqlConnection = null;
		try
		{
			sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			sqlDataReader = SQL.ExecuteReader(sqlConnection, null, commandType, commandText, commandParameters, SQL.SqlConnectionOwnership.Internal);
		}
		catch
		{
			if (sqlConnection != null)
			{
				sqlConnection.Close();
			}
			throw;
		}
		return sqlDataReader;
	}

	public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
	{
		return SQL.ExecuteReader(connection, commandType, commandText, null);
	}

	public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		return SQL.ExecuteReader(connection, null, commandType, commandText, commandParameters, SQL.SqlConnectionOwnership.External);
	}

	public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
	{
		return SQL.ExecuteReader(transaction, commandType, commandText, null);
	}

	public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		return SQL.ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SQL.SqlConnectionOwnership.External);
	}

	public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static SqlDataReader ExecuteReaderTypedParams(string connectionString, string spName, DataRow dataRow)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static SqlDataReader ExecuteReaderTypedParams(SqlConnection connection, string spName, DataRow dataRow)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static SqlDataReader ExecuteReaderTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
	{
		return SQL.ExecuteScalar(connectionString, commandType, commandText, null);
	}

	public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		object obj;
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			obj = SQL.ExecuteScalar(sqlConnection, commandType, commandText, commandParameters);
		}
		return obj;
	}

	public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
	{
		return SQL.ExecuteScalar(connection, commandType, commandText, null);
	}

	public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
		object obj = sqlCommand.ExecuteScalar();
		sqlCommand.Parameters.Clear();
		if (flag)
		{
			connection.Close();
		}
		return obj;
	}

	public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
	{
		return SQL.ExecuteScalar(transaction, commandType, commandText, null);
	}

	public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
		object obj = sqlCommand.ExecuteScalar();
		sqlCommand.Parameters.Clear();
		return obj;
	}

	public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalarTypedParams(string connectionString, string spName, DataRow dataRow)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalarTypedParams(SqlConnection connection, string spName, DataRow dataRow)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static object ExecuteScalarTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
	{
		return SQL.ExecuteXmlReader(connection, commandType, commandText, null);
	}

	public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		XmlReader xmlReader;
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		bool flag = false;
		SqlCommand sqlCommand = new SqlCommand();
		try
		{
			SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
			XmlReader xmlReader1 = sqlCommand.ExecuteXmlReader();
			sqlCommand.Parameters.Clear();
			xmlReader = xmlReader1;
		}
		catch
		{
			if (flag)
			{
				connection.Close();
			}
			throw;
		}
		return xmlReader;
	}

	public static XmlReader ExecuteXmlReader(SqlConnection connection, string spName, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
	{
		return SQL.ExecuteXmlReader(transaction, commandType, commandText, null);
	}

	public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
		XmlReader xmlReader = sqlCommand.ExecuteXmlReader();
		sqlCommand.Parameters.Clear();
		return xmlReader;
	}

	public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			return SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		return SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static XmlReader ExecuteXmlReaderTypedParams(SqlConnection connection, string spName, DataRow dataRow)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static XmlReader ExecuteXmlReaderTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (dataRow == null || (int)dataRow.ItemArray.Length <= 0)
		{
			return SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, dataRow);
		return SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
	}

	public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			SQL.FillDataset(sqlConnection, commandType, commandText, dataSet, tableNames);
		}
	}

	public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			SQL.FillDataset(sqlConnection, commandType, commandText, dataSet, tableNames, commandParameters);
		}
	}

	public static void FillDataset(string connectionString, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
	{
		if (connectionString == null || connectionString.Length == 0)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			SQL.FillDataset(sqlConnection, spName, dataSet, tableNames, parameterValues);
		}
	}

	public static void FillDataset(SqlConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
	{
		SQL.FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
	}

	public static void FillDataset(SqlConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
	{
		SQL.FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
	}

	public static void FillDataset(SqlConnection connection, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
			return;
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
	}

	public static void FillDataset(SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
	{
		SQL.FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
	}

	public static void FillDataset(SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
	{
		SQL.FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
	}

	public static void FillDataset(SqlTransaction transaction, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		if (transaction != null && transaction.Connection == null)
		{
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (spName == null || spName.Length == 0)
		{
			throw new ArgumentNullException("spName");
		}
		if (parameterValues == null || (int)parameterValues.Length <= 0)
		{
			SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
			return;
		}
		SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
		SQL.AssignParameterValues(spParameterSet, parameterValues);
		SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
	}

	private static void FillDataset(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		SqlCommand sqlCommand = new SqlCommand();
		bool flag = false;
		SQL.PrepareCommand(sqlCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
		{
			if (tableNames != null && (int)tableNames.Length > 0)
			{
				string str = "Table";
				for (int i = 0; i < (int)tableNames.Length; i++)
				{
					if (tableNames[i] == null || tableNames[i].Length == 0)
					{
						throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
					}
					sqlDataAdapter.TableMappings.Add(str, tableNames[i]);
					int num = i + 1;
					str = string.Concat(str, num.ToString());
				}
			}
			sqlDataAdapter.Fill(dataSet);
			sqlCommand.Parameters.Clear();
		}
		if (flag)
		{
			connection.Close();
		}
	}

	private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (commandText == null || commandText.Length == 0)
		{
			throw new ArgumentNullException("commandText");
		}
		if (connection.State == ConnectionState.Open)
		{
			mustCloseConnection = false;
		}
		else
		{
			mustCloseConnection = true;
			connection.Open();
		}
		command.Connection = connection;
		command.CommandText = commandText;
		if (transaction != null)
		{
			if (transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			command.Transaction = transaction;
		}
		command.CommandType = commandType;
		if (commandParameters != null)
		{
			SQL.AttachParameters(command, commandParameters);
		}
	}

	public static void UpdateDataset(SqlCommand insertCommand, SqlCommand deleteCommand, SqlCommand updateCommand, DataSet dataSet, string tableName)
	{
		if (insertCommand == null)
		{
			throw new ArgumentNullException("insertCommand");
		}
		if (deleteCommand == null)
		{
			throw new ArgumentNullException("deleteCommand");
		}
		if (updateCommand == null)
		{
			throw new ArgumentNullException("updateCommand");
		}
		if (tableName == null || tableName.Length == 0)
		{
			throw new ArgumentNullException("tableName");
		}
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
		{
			sqlDataAdapter.UpdateCommand = updateCommand;
			sqlDataAdapter.InsertCommand = insertCommand;
			sqlDataAdapter.DeleteCommand = deleteCommand;
			sqlDataAdapter.Update(dataSet, tableName);
			dataSet.AcceptChanges();
		}
	}

	private enum SqlConnectionOwnership
	{
		Internal,
		External
	}
}