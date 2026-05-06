using System;
using System.ComponentModel;
using Telerik.Web.UI;

namespace Telerik.Web.Examples.Grid
{
	public class GridGenericFilterer<T>
	{
		private GridFilterExpression _expression;

		private PropertyDescriptor _descriptor;

		private Type _propertyType;

		private GridKnownFunction _filterFunction;

		public GridGenericFilterer(GridFilterExpression expression)
		{
			this._expression = expression;
			this._descriptor = TypeDescriptor.GetProperties(this.GetType().GetGenericArguments()[0]).Find(expression.FieldName, true);
			this._propertyType = this._descriptor.PropertyType;
			this._filterFunction = (GridKnownFunction)Enum.Parse(typeof(GridKnownFunction), this._expression.FilterFunction);
		}

		public bool Filter(T item)
		{
			object value = this._descriptor.GetValue(item);
			string str = value.ToString();
			if (this._propertyType == typeof(string))
			{
				if (this._filterFunction == GridKnownFunction.Contains)
				{
					return str.Contains(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.DoesNotContain)
				{
					return !str.Contains(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.StartsWith)
				{
					return str.StartsWith(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.EndsWith)
				{
					return str.EndsWith(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.EqualTo)
				{
					return str.Equals(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.NotEqualTo)
				{
					return !str.Equals(this._expression.FieldValue);
				}
				if (this._filterFunction == GridKnownFunction.IsEmpty)
				{
					return str.Equals(string.Empty);
				}
				if (this._filterFunction == GridKnownFunction.NotIsEmpty)
				{
					return !str.Equals(string.Empty);
				}
				if (this._filterFunction == GridKnownFunction.GreaterThan)
				{
					return str.CompareTo(this._expression.FieldValue) > 0;
				}
				if (this._filterFunction == GridKnownFunction.GreaterThanOrEqualTo)
				{
					return str.CompareTo(this._expression.FieldValue) >= 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThan)
				{
					return str.CompareTo(this._expression.FieldValue) < 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThanOrEqualTo)
				{
					return str.CompareTo(this._expression.FieldValue) <= 0;
				}
			}
			else if (this._propertyType == typeof(bool))
			{
				if (this._filterFunction == GridKnownFunction.EqualTo)
				{
					bool flag = bool.Parse(str);
					return flag.Equals(bool.Parse(this._expression.FieldValue));
				}
				if (this._filterFunction == GridKnownFunction.NotEqualTo)
				{
					bool flag1 = bool.Parse(str);
					return !flag1.Equals(bool.Parse(this._expression.FieldValue));
				}
			}
			else if (this._propertyType == typeof(DateTime))
			{
				if (this._filterFunction == GridKnownFunction.EqualTo)
				{
					DateTime dateTime = DateTime.Parse(str);
					return dateTime.Equals(DateTime.Parse(this._expression.FieldValue));
				}
				if (this._filterFunction == GridKnownFunction.NotEqualTo)
				{
					DateTime dateTime1 = DateTime.Parse(str);
					return !dateTime1.Equals(DateTime.Parse(this._expression.FieldValue));
				}
				if (this._filterFunction == GridKnownFunction.GreaterThan)
				{
					DateTime dateTime2 = DateTime.Parse(str);
					return dateTime2.CompareTo(DateTime.Parse(this._expression.FieldValue)) > 0;
				}
				if (this._filterFunction == GridKnownFunction.GreaterThanOrEqualTo)
				{
					DateTime dateTime3 = DateTime.Parse(str);
					return dateTime3.CompareTo(DateTime.Parse(this._expression.FieldValue)) >= 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThan)
				{
					DateTime dateTime4 = DateTime.Parse(str);
					return dateTime4.CompareTo(DateTime.Parse(this._expression.FieldValue)) < 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThanOrEqualTo)
				{
					DateTime dateTime5 = DateTime.Parse(str);
					return dateTime5.CompareTo(DateTime.Parse(this._expression.FieldValue)) <= 0;
				}
			}
			else if (GridGenericFilterer<T>.IsNumeric(this._propertyType))
			{
				if (this._filterFunction == GridKnownFunction.EqualTo)
				{
					decimal num = decimal.Parse(str);
					return num.Equals(decimal.Parse(this._expression.FieldValue));
				}
				if (this._filterFunction == GridKnownFunction.NotEqualTo)
				{
					decimal num1 = decimal.Parse(str);
					return !num1.Equals(decimal.Parse(this._expression.FieldValue));
				}
				if (this._filterFunction == GridKnownFunction.GreaterThan)
				{
					decimal num2 = decimal.Parse(str);
					return num2.CompareTo(decimal.Parse(this._expression.FieldValue)) > 0;
				}
				if (this._filterFunction == GridKnownFunction.GreaterThanOrEqualTo)
				{
					decimal num3 = decimal.Parse(str);
					return num3.CompareTo(decimal.Parse(this._expression.FieldValue)) >= 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThan)
				{
					decimal num4 = decimal.Parse(str);
					return num4.CompareTo(decimal.Parse(this._expression.FieldValue)) < 0;
				}
				if (this._filterFunction == GridKnownFunction.LessThanOrEqualTo)
				{
					decimal num5 = decimal.Parse(str);
					return num5.CompareTo(decimal.Parse(this._expression.FieldValue)) <= 0;
				}
			}
			if (this._filterFunction == GridKnownFunction.IsNull)
			{
				return value.Equals(null);
			}
			if (this._filterFunction != GridKnownFunction.NotIsNull)
			{
				return true;
			}
			return !value.Equals(null);
		}

		private static bool IsNumeric(Type type)
		{
			if (!type.IsEnum)
			{
				switch (Type.GetTypeCode(type))
				{
					case TypeCode.Char:
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}