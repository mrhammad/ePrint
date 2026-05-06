using System;
using System.Runtime.CompilerServices;

public static class Extensions
{
	public static int DBNullToInt32(this object Value)
	{
		return (Value == DBNull.Value ? 0 : Convert.ToInt32(Value));
	}

	public static long DBNullToint64(this object Value)
	{
		return (Value == DBNull.Value ? (long)0 : Convert.ToInt64(Value));
	}

	public static long DBNullToLong(this object Value)
	{
		return (Value == DBNull.Value ? (long)0 : (long)Value);
	}

	public static string DBNullToString(this object Value)
	{
		return (Value == DBNull.Value ? "" : Value.ToString());
	}

	public static string EmptyIfNull(this object value)
	{
		return (value != null ? value.ToString() : "");
	}
}