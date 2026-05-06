using System;

namespace Components
{
	public class VisualReport
	{
		private string _categoryName;

		private decimal _sales;

		public string CategoryName
		{
			get
			{
				return this._categoryName;
			}
			set
			{
				this._categoryName = value;
			}
		}

		public decimal Sales
		{
			get
			{
				return this._sales;
			}
			set
			{
				this._sales = value;
			}
		}

		public VisualReport()
		{
		}

		public static VisualReportCollection GetCategorySales(string innerSubquery, string subtotal2)
		{
			return new VisualReportCollection();
		}
	}
}