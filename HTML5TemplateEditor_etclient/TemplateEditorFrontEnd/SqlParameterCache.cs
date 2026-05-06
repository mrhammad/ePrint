using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TemplateEditorFrontEnd
{
	public sealed class SqlParameterCache
	{
		private static Hashtable paramCache;

		static SqlParameterCache()
		{
			SqlParameterCache.paramCache = Hashtable.Synchronized(new Hashtable());
		}

		private SqlParameterCache()
		{
		}

		public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0)
			{
				throw new ArgumentNullException("connectionString");
			}
			if (commandText == null || commandText.Length == 0)
			{
				throw new ArgumentNullException("commandText");
			}
			string str = string.Concat(connectionString, ":", commandText);
			SqlParameterCache.paramCache[str] = commandParameters;
		}

		private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
		{
			SqlParameter[] sqlParameterArray = new SqlParameter[(int)originalParameters.Length];
			int num = 0;
			int length = (int)originalParameters.Length;
			while (num < length)
			{
				sqlParameterArray[num] = (SqlParameter)((ICloneable)originalParameters[num]).Clone();
				num++;
			}
			return sqlParameterArray;
		}

		private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
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
			connection.Open();
			SqlCommandBuilder.DeriveParameters(sqlCommand);
			connection.Close();
			if (!includeReturnValueParameter)
			{
				sqlCommand.Parameters.RemoveAt(0);
			}
			SqlParameter[] sqlParameterArray = new SqlParameter[sqlCommand.Parameters.Count];
			if (!includeReturnValueParameter)
			{
				sqlCommand.Parameters.CopyTo(sqlParameterArray, 0);
			}
			else
			{
				for (int i = 0; i < sqlCommand.Parameters.Count; i++)
				{
					if (i != 0)
					{
						sqlParameterArray[i - 1] = (SqlParameter)((ICloneable)sqlCommand.Parameters[i]).Clone();
					}
					else
					{
						sqlParameterArray[(int)sqlParameterArray.Length - 1] = (SqlParameter)((ICloneable)sqlCommand.Parameters[i]).Clone();
					}
				}
			}
			SqlParameter[] value = sqlParameterArray;
			for (int j = 0; j < (int)value.Length; j++)
			{
				value[j].Value = DBNull.Value;
			}
			return sqlParameterArray;
		}

		public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			if (connectionString == null || connectionString.Length == 0)
			{
				throw new ArgumentNullException("connectionString");
			}
			if (commandText == null || commandText.Length == 0)
			{
				throw new ArgumentNullException("commandText");
			}
			string str = string.Concat(connectionString, ":", commandText);
			SqlParameter[] item = SqlParameterCache.paramCache[str] as SqlParameter[];
			if (item == null)
			{
				return null;
			}
			return SqlParameterCache.CloneParameters(item);
		}

		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return SqlParameterCache.GetSpParameterSet(connectionString, spName, false);
		}

		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			SqlParameter[] spParameterSetInternal;
			if (connectionString == null || connectionString.Length == 0)
			{
				throw new ArgumentNullException("connectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				spParameterSetInternal = SqlParameterCache.GetSpParameterSetInternal(sqlConnection, spName, includeReturnValueParameter);
			}
			return spParameterSetInternal;
		}

		public static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName)
		{
			return SqlParameterCache.GetSpParameterSet(connection, spName, false);
		}

		public static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
		{
			SqlParameter[] spParameterSetInternal;
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			using (SqlConnection sqlConnection = (SqlConnection)((ICloneable)connection).Clone())
			{
				spParameterSetInternal = SqlParameterCache.GetSpParameterSetInternal(sqlConnection, spName, includeReturnValueParameter);
			}
			return spParameterSetInternal;
		}

		private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			string str = string.Concat(connection.ConnectionString, ":", spName, (includeReturnValueParameter ? ":include ReturnValue Parameter" : ""));
			SqlParameter[] item = SqlParameterCache.paramCache[str] as SqlParameter[];
			item = null;
			if (item == null)
			{
				SqlParameter[] sqlParameterArray = SqlParameterCache.DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
				SqlParameterCache.paramCache[str] = sqlParameterArray;
				item = sqlParameterArray;
			}
			return SqlParameterCache.CloneParameters(item);
		}
	}
}