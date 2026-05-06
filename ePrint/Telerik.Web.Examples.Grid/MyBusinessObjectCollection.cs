using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace Telerik.Web.Examples.Grid
{
	public class MyBusinessObjectCollection
	{
		private const int _maxItems = 100000;

		private string[] names = new string[] { "kumar", "kumar", "kumar", "kumar", "kumar", "kumar", "kumar", "kumar", "kumar", "kumar" };

		private double[] prizes = new double[] { 23.25, 9, 45.6, 32, 14, 19, 263.5, 18.4, 3, 14 };

		private DateTime[] dates = new DateTime[] { new DateTime(2007, 5, 10), new DateTime(2008, 9, 13), new DateTime(2008, 2, 22), new DateTime(2009, 1, 2), new DateTime(2007, 4, 13), new DateTime(2008, 5, 12), new DateTime(2008, 1, 19), new DateTime(2008, 8, 26), new DateTime(2008, 7, 31), new DateTime(2007, 7, 16) };

		private bool[] bools = new bool[] { true, false, true, false, true, false, true, false, true, false };

		public MyBusinessObjectCollection()
		{
		}

		public List<MyBusinessObject> Select()
		{
			if (HttpContext.Current.Cache["data"] == null)
			{
				HttpContext.Current.Cache["data"] = this.Select(0, 100000);
			}
			return (List<MyBusinessObject>)HttpContext.Current.Cache["data"];
		}

		public List<MyBusinessObject> Select(int startRowIndex, int maximumRows)
		{
			Random random = new Random();
			List<MyBusinessObject> myBusinessObjects = new List<MyBusinessObject>();
			for (int i = startRowIndex; i < Math.Min(100000, startRowIndex + maximumRows); i++)
			{
				MyBusinessObject myBusinessObject = new MyBusinessObject()
				{
					ID = i,
					Name = this.names[random.Next(9)],
					UnitPrice = this.prizes[random.Next(9)],
					Date = this.dates[random.Next(9)],
					Discontinued = this.bools[random.Next(9)]
				};
				myBusinessObjects.Add(myBusinessObject);
			}
			return myBusinessObjects;
		}

		public int SelectCount()
		{
			return 100000;
		}
	}
}