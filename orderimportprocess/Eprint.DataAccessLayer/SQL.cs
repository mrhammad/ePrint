using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;

namespace Eprint.DataAccessLayer
{
	public sealed class SQL
	{
		private SQL()
		{
		}

		private static void AssignParameterValues(SqlParameter[] commandParameters, DataRow dataRow)
		{
			if ((commandParameters == null ? false : dataRow != null))
			{
				int num = 0;
				SqlParameter[] sqlParameterArray = commandParameters;
				for (int i = 0; i < (int)sqlParameterArray.Length; i++)
				{
					SqlParameter item = sqlParameterArray[i];
					if ((item.ParameterName == null ? true : item.ParameterName.Length <= 1))
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
		}

		private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null ? false : parameterValues != null))
			{
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
				num = 0;
				length1 = (int)commandParameters.Length;
				while (num < length1)
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
		}

		private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues, bool returnValue)
		{
			if ((commandParameters == null ? false : parameterValues != null))
			{
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
						if ((value.Direction == ParameterDirection.InputOutput || value.Direction == ParameterDirection.Input ? value.Value == null : false))
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
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			SqlCommand sqlCommand = new SqlCommand(spName, connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			if ((sourceColumns == null ? false : sourceColumns.Length != 0))
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				for (int i = 0; i < (int)sourceColumns.Length; i++)
				{
					spParameterSet[i].SourceColumn = sourceColumns[i];
				}
				Eprint.DataAccessLayer.SQL.AttachParameters(sqlCommand, spParameterSet);
			}
			return sqlCommand;
		}

		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, commandType, commandText, null);
		}

		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			DataSet dataSet;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(sqlConnection, commandType, commandText, commandParameters);
			}
			return dataSet;
		}

		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, bool flag, params SqlParameter[] commandParameters)
		{
			DataSet dataSet;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(sqlConnection, commandType, commandText, true, commandParameters);
			}
			return dataSet;
		}

		public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
		{
			DataSet dataSet;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, commandType, commandText, null);
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
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
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
				Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag1);
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
			DataSet dataSet;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, commandType, commandText, null);
		}

		public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			DataSet dataSet;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
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
			DataSet dataSet;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataSet ExecuteDatasetTypedParams(string connectionString, string spName, DataRow dataRow)
		{
			DataSet dataSet;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataSet ExecuteDatasetTypedParams(SqlConnection connection, string spName, DataRow dataRow)
		{
			DataSet dataSet;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataSet ExecuteDatasetTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
		{
			DataSet dataSet;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return dataSet;
		}

		public static DataTable ExecuteDatatable(string connectionString, string strTableName)
		{
			DataTable schema;
			DataTable dataTable = new DataTable();
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				schema = sqlConnection.GetSchema("Columns", new string[] { null, null, strTableName, null });
			}
			return schema;
		}

		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, commandType, commandText, null);
		}

		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			int num;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(sqlConnection, commandType, commandText, commandParameters);
			}
			return num;
		}

		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			int num;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, commandType, commandText, null);
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
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
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
			int num;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, commandType, commandText, null);
		}

		public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			int num = sqlCommand.ExecuteNonQuery();
			sqlCommand.Parameters.Clear();
			return num;
		}

		public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			int num;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		public static int ExecuteNonQuery(string connectionString, string spName, bool returnValue, params object[] parameterValues)
		{
			int num;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				num = 0;
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName, returnValue);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues, returnValue);
				int num1 = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
				if (returnValue.Equals(true))
				{
					((SqlParameter)parameterValues[(int)parameterValues.Length - 1]).Value = spParameterSet[(int)spParameterSet.Length - 1].Value;
				}
				num = num1;
			}
			return num;
		}

		public static string ExecuteNonQuery1(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			string str;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
			int num = 10;
			try
			{
				num = sqlCommand.ExecuteNonQuery();
			}
			catch (SqlException sqlException)
			{
				str = sqlException.Errors.ToString();
				return str;
			}
			catch (Exception exception)
			{
			}
			sqlCommand.Parameters.Clear();
			if (flag)
			{
				connection.Close();
			}
			str = num.ToString();
			return str;
		}

		public static int ExecuteNonQueryTypedParams(string connectionString, string spName, DataRow dataRow)
		{
			int num;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		public static int ExecuteNonQueryTypedParams(SqlConnection connection, string spName, DataRow dataRow)
		{
			int num;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		public static int ExecuteNonQueryTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
		{
			int num;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return num;
		}

		private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership connectionOwnership)
		{
			SqlDataReader sqlDataReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			bool flag = false;
			SqlCommand sqlCommand = new SqlCommand();
			try
			{
				Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
				SqlDataReader sqlDataReader1 = (connectionOwnership != Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.External ? sqlCommand.ExecuteReader(CommandBehavior.CloseConnection) : sqlCommand.ExecuteReader());
				bool flag1 = true;
				foreach (SqlParameter parameter in sqlCommand.Parameters)
				{
					if (parameter.Direction != ParameterDirection.Input)
					{
						flag1 = false;
					}
				}
				if (flag1)
				{
					sqlCommand.Parameters.Clear();
				}
				sqlDataReader = sqlDataReader1;
			}
			catch
			{
				if (flag)
				{
					connection.Close();
				}
				throw;
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, commandType, commandText, null);
		}

		public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlDataReader sqlDataReader;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			SqlConnection sqlConnection = null;
			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(sqlConnection, null, commandType, commandText, commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.Internal);
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
			SqlDataReader sqlDataReader;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteReader(connection, commandType, commandText, null);
		}

		public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlDataReader sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, null, commandType, commandText, commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.External);
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
		{
			SqlDataReader sqlDataReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, commandType, commandText, null);
		}

		public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			SqlDataReader sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.External);
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			SqlDataReader sqlDataReader;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReaderTypedParams(string connectionString, string spName, DataRow dataRow)
		{
			SqlDataReader sqlDataReader;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReaderTypedParams(SqlConnection connection, string spName, DataRow dataRow)
		{
			SqlDataReader sqlDataReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReaderTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
		{
			SqlDataReader sqlDataReader;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return sqlDataReader;
		}

		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, commandType, commandText, null);
		}

		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			object obj;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(sqlConnection, commandType, commandText, commandParameters);
			}
			return obj;
		}

		public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
		{
			object obj;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, commandType, commandText, null);
		}

		public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
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
			object obj;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, commandType, commandText, null);
		}

		public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			object obj = sqlCommand.ExecuteScalar();
			sqlCommand.Parameters.Clear();
			return obj;
		}

		public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			object obj;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static object ExecuteScalarTypedParams(string connectionString, string spName, DataRow dataRow)
		{
			object obj;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static object ExecuteScalarTypedParams(SqlConnection connection, string spName, DataRow dataRow)
		{
			object obj;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static object ExecuteScalarTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
		{
			object obj;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return obj;
		}

		public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, commandType, commandText, null);
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
				Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters, out flag);
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
			XmlReader xmlReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return xmlReader;
		}

		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, commandType, commandText, null);
		}

		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			SqlCommand sqlCommand = new SqlCommand();
			bool flag = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			XmlReader xmlReader = sqlCommand.ExecuteXmlReader();
			sqlCommand.Parameters.Clear();
			return xmlReader;
		}

		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			XmlReader xmlReader;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return xmlReader;
		}

		public static XmlReader ExecuteXmlReaderTypedParams(SqlConnection connection, string spName, DataRow dataRow)
		{
			XmlReader xmlReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return xmlReader;
		}

		public static XmlReader ExecuteXmlReaderTypedParams(SqlTransaction transaction, string spName, DataRow dataRow)
		{
			XmlReader xmlReader;
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((dataRow == null ? true : dataRow.ItemArray.Length == 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, dataRow);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return xmlReader;
		}

		public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			if ((connectionString == null ? true : connectionString.Length == 0))
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
				Eprint.DataAccessLayer.SQL.FillDataset(sqlConnection, commandType, commandText, dataSet, tableNames);
			}
		}

		public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
		{
			if ((connectionString == null ? true : connectionString.Length == 0))
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
				Eprint.DataAccessLayer.SQL.FillDataset(sqlConnection, commandType, commandText, dataSet, tableNames, commandParameters);
			}
		}

		public static void FillDataset(string connectionString, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
		{
			if ((connectionString == null ? true : connectionString.Length == 0))
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
				Eprint.DataAccessLayer.SQL.FillDataset(sqlConnection, spName, dataSet, tableNames, parameterValues);
			}
		}

		public static void FillDataset(SqlConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			Eprint.DataAccessLayer.SQL.FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
		}

		public static void FillDataset(SqlConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
		{
			Eprint.DataAccessLayer.SQL.FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
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
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				Eprint.DataAccessLayer.SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				Eprint.DataAccessLayer.SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
			}
		}

		public static void FillDataset(SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			Eprint.DataAccessLayer.SQL.FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
		}

		public static void FillDataset(SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
		{
			Eprint.DataAccessLayer.SQL.FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
		}

		public static void FillDataset(SqlTransaction transaction, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if ((transaction == null ? false : transaction.Connection == null))
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			if ((parameterValues == null ? true : parameterValues.Length == 0))
			{
				Eprint.DataAccessLayer.SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
			else
			{
				SqlParameter[] spParameterSet = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(spParameterSet, parameterValues);
				Eprint.DataAccessLayer.SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
			}
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
			Eprint.DataAccessLayer.SQL.PrepareCommand(sqlCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
			{
				if ((tableNames == null ? false : tableNames.Length != 0))
				{
					string str = "Table";
					for (int i = 0; i < (int)tableNames.Length; i++)
					{
						if ((tableNames[i] == null ? true : tableNames[i].Length == 0))
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
			if ((commandText == null ? true : commandText.Length == 0))
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
				Eprint.DataAccessLayer.SQL.AttachParameters(command, commandParameters);
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
			if ((tableName == null ? true : tableName.Length == 0))
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
}