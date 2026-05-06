using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Eprint.DataAccessLayer
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
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((commandText == null ? true : commandText.Length == 0))
			{
				throw new ArgumentNullException("commandText");
			}
			string hashKey = string.Concat(connectionString, ":", commandText);
			SqlParameterCache.paramCache[hashKey] = commandParameters;
		}

		private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
		{
			SqlParameter[] clonedParameters = new SqlParameter[(int)originalParameters.Length];
			int i = 0;
			int j = (int)originalParameters.Length;
			while (i < j)
			{
				clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
				i++;
			}
			return clonedParameters;
		}

		private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
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
			connection.Open();
			SqlCommandBuilder.DeriveParameters(cmd);
			connection.Close();
			if (!includeReturnValueParameter)
			{
				cmd.Parameters.RemoveAt(0);
			}
			SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
			if (!includeReturnValueParameter)
			{
				cmd.Parameters.CopyTo(discoveredParameters, 0);
			}
			else
			{
				for (int i = 0; i < cmd.Parameters.Count; i++)
				{
					if (i != 0)
					{
						discoveredParameters[i - 1] = (SqlParameter)((ICloneable)cmd.Parameters[i]).Clone();
					}
					else
					{
						discoveredParameters[(int)discoveredParameters.Length - 1] = (SqlParameter)((ICloneable)cmd.Parameters[i]).Clone();
					}
				}
			}
			SqlParameter[] value = discoveredParameters;
			for (int j = 0; j < (int)value.Length; j++)
			{
				value[j].Value = DBNull.Value;
			}
			return discoveredParameters;
		}

		public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			SqlParameter[] sqlParameterArray;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((commandText == null ? true : commandText.Length == 0))
			{
				throw new ArgumentNullException("commandText");
			}
			string hashKey = string.Concat(connectionString, ":", commandText);
			SqlParameter[] cachedParameters = SqlParameterCache.paramCache[hashKey] as SqlParameter[];
			if (cachedParameters != null)
			{
				sqlParameterArray = SqlParameterCache.CloneParameters(cachedParameters);
			}
			else
			{
				sqlParameterArray = null;
			}
			return sqlParameterArray;
		}

		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return SqlParameterCache.GetSpParameterSet(connectionString, spName, false);
		}

		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			SqlParameter[] spParameterSetInternal;
			if ((connectionString == null ? true : connectionString.Length == 0))
			{
				throw new ArgumentNullException("connectionString");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				spParameterSetInternal = SqlParameterCache.GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
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
			SqlConnection clonedConnection = (SqlConnection)((ICloneable)connection).Clone();
			try
			{
				spParameterSetInternal = SqlParameterCache.GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
			}
			finally
			{
				if (clonedConnection != null)
				{
					((IDisposable)clonedConnection).Dispose();
				}
			}
			return spParameterSetInternal;
		}

		private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if ((spName == null ? true : spName.Length == 0))
			{
				throw new ArgumentNullException("spName");
			}
			string hashKey = string.Concat(connection.ConnectionString, ":", spName, (includeReturnValueParameter ? ":include ReturnValue Parameter" : ""));
			SqlParameter[] cachedParameters = SqlParameterCache.paramCache[hashKey] as SqlParameter[];
			if (cachedParameters == null)
			{
				SqlParameter[] spParameters = SqlParameterCache.DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
				SqlParameterCache.paramCache[hashKey] = spParameters;
				cachedParameters = spParameters;
			}
			return SqlParameterCache.CloneParameters(cachedParameters);
		}
	}
}