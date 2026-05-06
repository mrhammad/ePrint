using System;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Web.UI;

namespace Telerik.Web.Examples.Grid
{
	public class GridGenericSorter<T> : IComparer<T>
	{
		private GridSortExpression _expression;

		private PropertyDescriptor _descriptor;

		public GridGenericSorter(GridSortExpression expression)
		{
			this._descriptor = TypeDescriptor.GetProperties(this.GetType().GetGenericArguments()[0]).Find(expression.FieldName, true);
			this._expression = expression;
		}

		public int Compare(T o1, T o2)
		{
			IComparable value = (IComparable)this._descriptor.GetValue(o1);
			IComparable comparable = (IComparable)this._descriptor.GetValue(o2);
			if (this._expression.SortOrder == GridSortOrder.Ascending)
			{
				return value.CompareTo(comparable);
			}
			return comparable.CompareTo(value);
		}
	}
}