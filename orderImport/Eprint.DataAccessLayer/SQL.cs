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
				int i = 0;
				SqlParameter[] sqlParameterArray = commandParameters;
				for (int num = 0; num < (int)sqlParameterArray.Length; num++)
				{
					SqlParameter commandParameter = sqlParameterArray[num];
					if ((commandParameter.ParameterName == null ? true : commandParameter.ParameterName.Length <= 1))
					{
						throw new Exception(string.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", i, commandParameter.ParameterName));
					}
					if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
					{
						commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
					}
					i++;
				}
			}
		}

		private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null ? false : parameterValues != null))
			{
				int chkParameterLength = (int)commandParameters.Length;
				int i = 0;
				int j = (int)parameterValues.Length;
				while (i < j)
				{
					if (((SqlParameter)parameterValues[i]).ParameterName == "ReturnValue")
					{
						chkParameterLength++;
					}
					i++;
				}
				if (chkParameterLength != (int)parameterValues.Length)
				{
					throw new ArgumentException("Parameter count does not match Parameter Value count.");
				}
				i = 0;
				j = (int)commandParameters.Length;
				while (i < j)
				{
					if (parameterValues[i] is IDbDataParameter)
					{
						IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
						if (paramInstance.Value != null)
						{
							commandParameters[i].Value = paramInstance.Value;
						}
						else
						{
							commandParameters[i].Value = DBNull.Value;
						}
					}
					else if (parameterValues[i] != null)
					{
						commandParameters[i].Value = parameterValues[i];
					}
					else
					{
						commandParameters[i].Value = DBNull.Value;
					}
					i++;
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
				int i = 0;
				int j = (int)commandParameters.Length;
				while (i < j)
				{
					if (parameterValues[i] is IDbDataParameter)
					{
						IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
						if (paramInstance.Value != null)
						{
							commandParameters[i].Value = paramInstance.Value;
						}
						else
						{
							commandParameters[i].Value = DBNull.Value;
						}
					}
					else if (parameterValues[i] != null)
					{
						commandParameters[i].Value = parameterValues[i];
					}
					else
					{
						commandParameters[i].Value = DBNull.Value;
					}
					i++;
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
					SqlParameter p = sqlParameterArray[i];
					if (p != null)
					{
						if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input ? p.Value == null : false))
						{
							p.Value = DBNull.Value;
						}
						command.Parameters.Add(p);
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
			SqlCommand cmd = new SqlCommand(spName, connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			if ((sourceColumns == null ? false : (int)sourceColumns.Length > 0))
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				for (int index = 0; index < (int)sourceColumns.Length; index++)
				{
					commandParameters[index].SourceColumn = sourceColumns[index];
				}
				Eprint.DataAccessLayer.SQL.AttachParameters(cmd, commandParameters);
			}
			return cmd;
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, commandType, commandText, commandParameters);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, commandType, commandText, true, commandParameters);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand()
			{
				CommandTimeout = 3000
			};
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				DataSet ds = new DataSet();
				da.Fill(ds);
				cmd.Parameters.Clear();
				if (mustCloseConnection)
				{
					connection.Close();
				}
				dataSet = ds;
			}
			finally
			{
				if (da != null)
				{
					((IDisposable)da).Dispose();
				}
			}
			return dataSet;
		}

		public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, bool flag, params SqlParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			DataSet ds = new DataSet();
			try
			{
				SqlCommand cmd = new SqlCommand();
				bool mustCloseConnection = false;
				Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				try
				{
					da.Fill(ds);
					cmd.Parameters.Clear();
					if (mustCloseConnection)
					{
						connection.Close();
					}
				}
				finally
				{
					if (da != null)
					{
						((IDisposable)da).Dispose();
					}
				}
			}
			catch (SqlException sqlException)
			{
				SqlException ex = sqlException;
				DataTable dt = new DataTable();
				DataRow dr = dt.NewRow();
				DataColumn dc = new DataColumn("CNDBerror", typeof(string));
				dt.Columns.Add(dc);
				dc = new DataColumn("msg", typeof(string));
				dt.Columns.Add(dc);
				dr["CNDBerror"] = "yes";
				dr["msg"] = ex.Message.ToString();
				dt.Rows.InsertAt(dr, 0);
				ds.Tables.Add(dt);
			}
			return ds;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				DataSet ds = new DataSet();
				da.Fill(ds);
				cmd.Parameters.Clear();
				dataSet = ds;
			}
			finally
			{
				if (da != null)
				{
					((IDisposable)da).Dispose();
				}
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			return dataSet;
		}

		public static DataTable ExecuteDatatable(string connectionString, string strTableName)
		{
			DataTable schema;
			DataTable dt = new DataTable();
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				string[] strArrays = new string[] { null, null, strTableName, null };
				schema = connection.GetSchema("Columns", strArrays);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, commandType, commandText, commandParameters);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand()
			{
				CommandTimeout = 3000
			};
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
			int retval = 10;
			retval = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			if (mustCloseConnection)
			{
				connection.Close();
			}
			return retval;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			int retval = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return retval;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				num = 0;
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName, returnValue);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues, returnValue);
				int Return_Value = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
				if (returnValue.Equals(true))
				{
					((SqlParameter)parameterValues[(int)parameterValues.Length - 1]).Value = commandParameters[(int)commandParameters.Length - 1].Value;
				}
				num = Return_Value;
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
			int retval = 10;
			try
			{
				retval = cmd.ExecuteNonQuery();
			}
			catch (SqlException sqlException)
			{
				str = sqlException.Errors.ToString();
				return str;
			}
			catch (Exception exception)
			{
			}
			cmd.Parameters.Clear();
			if (mustCloseConnection)
			{
				connection.Close();
			}
			str = retval.ToString();
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				num = Eprint.DataAccessLayer.SQL.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			return num;
		}

		private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership connectionOwnership)
		{
			SqlDataReader dataReader;
			SqlDataReader sqlDataReader;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			bool mustCloseConnection = false;
			SqlCommand cmd = new SqlCommand();
			try
			{
				Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
				dataReader = (connectionOwnership != Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.External ? cmd.ExecuteReader(CommandBehavior.CloseConnection) : cmd.ExecuteReader());
				bool canClear = true;
				foreach (SqlParameter commandParameter in cmd.Parameters)
				{
					if (commandParameter.Direction != ParameterDirection.Input)
					{
						canClear = false;
					}
				}
				if (canClear)
				{
					cmd.Parameters.Clear();
				}
				sqlDataReader = dataReader;
			}
			catch
			{
				if (mustCloseConnection)
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
			SqlConnection connection = null;
			try
			{
				connection = new SqlConnection(connectionString);
				connection.Open();
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, null, commandType, commandText, commandParameters, Eprint.DataAccessLayer.SQL.SqlConnectionOwnership.Internal);
			}
			catch
			{
				if (connection != null)
				{
					connection.Close();
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				sqlDataReader = Eprint.DataAccessLayer.SQL.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, commandType, commandText, commandParameters);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
			object retval = cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			if (mustCloseConnection)
			{
				connection.Close();
			}
			return retval;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			object retval = cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			return retval;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connectionString, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				obj = Eprint.DataAccessLayer.SQL.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			bool mustCloseConnection = false;
			SqlCommand cmd = new SqlCommand();
			try
			{
				Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
				XmlReader retval = cmd.ExecuteXmlReader();
				cmd.Parameters.Clear();
				xmlReader = retval;
			}
			catch
			{
				if (mustCloseConnection)
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlCommand cmd = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			XmlReader retval = cmd.ExecuteXmlReader();
			cmd.Parameters.Clear();
			return retval;
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
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
			if ((dataRow == null ? true : (int)dataRow.ItemArray.Length <= 0))
			{
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, dataRow);
				xmlReader = Eprint.DataAccessLayer.SQL.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				Eprint.DataAccessLayer.SQL.FillDataset(connection, commandType, commandText, dataSet, tableNames);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				Eprint.DataAccessLayer.SQL.FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				Eprint.DataAccessLayer.SQL.FillDataset(connection, spName, dataSet, tableNames, parameterValues);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				Eprint.DataAccessLayer.SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				Eprint.DataAccessLayer.SQL.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
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
			if ((parameterValues == null ? true : (int)parameterValues.Length <= 0))
			{
				Eprint.DataAccessLayer.SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
			else
			{
				SqlParameter[] commandParameters = SqlParameterCache.GetSpParameterSet(transaction.Connection, spName);
				Eprint.DataAccessLayer.SQL.AssignParameterValues(commandParameters, parameterValues);
				Eprint.DataAccessLayer.SQL.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
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
			SqlCommand command = new SqlCommand();
			bool mustCloseConnection = false;
			Eprint.DataAccessLayer.SQL.PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			try
			{
				if ((tableNames == null ? false : (int)tableNames.Length > 0))
				{
					string tableName = "Table";
					for (int index = 0; index < (int)tableNames.Length; index++)
					{
						if ((tableNames[index] == null ? true : tableNames[index].Length == 0))
						{
							throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
						}
						dataAdapter.TableMappings.Add(tableName, tableNames[index]);
						int num = index + 1;
						tableName = string.Concat(tableName, num.ToString());
					}
				}
				dataAdapter.Fill(dataSet);
				command.Parameters.Clear();
			}
			finally
			{
				if (dataAdapter != null)
				{
					((IDisposable)dataAdapter).Dispose();
				}
			}
			if (mustCloseConnection)
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
			SqlDataAdapter dataAdapter = new SqlDataAdapter();
			try
			{
				dataAdapter.UpdateCommand = updateCommand;
				dataAdapter.InsertCommand = insertCommand;
				dataAdapter.DeleteCommand = deleteCommand;
				dataAdapter.Update(dataSet, tableName);
				dataSet.AcceptChanges();
			}
			finally
			{
				if (dataAdapter != null)
				{
					((IDisposable)dataAdapter).Dispose();
				}
			}
		}

		private enum SqlConnectionOwnership
		{
			Internal,
			External
		}
	}
}