using System;
using System.Collections;
using System.Reflection;

namespace Chart
{
	public class ChartItemsCollection : CollectionBase
	{
		public ChartItem this[int index]
		{
			get
			{
				return (ChartItem)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ChartItemsCollection()
		{
		}

		public int Add(ChartItem value)
		{
			return base.List.Add(value);
		}

		public bool Contains(ChartItem value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ChartItem value)
		{
			return base.List.IndexOf(value);
		}

		public void Remove(ChartItem value)
		{
			base.List.Remove(value);
		}
	}
}