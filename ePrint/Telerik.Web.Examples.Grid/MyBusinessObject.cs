using System;

namespace Telerik.Web.Examples.Grid
{
	public class MyBusinessObject
	{
		private int _id;

		private string _name;

		private double _unitPrice;

		private DateTime _date;

		private bool _discontinued;

		public DateTime Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
			}
		}

		public bool Discontinued
		{
			get
			{
				return this._discontinued;
			}
			set
			{
				this._discontinued = value;
			}
		}

		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public double UnitPrice
		{
			get
			{
				return this._unitPrice;
			}
			set
			{
				this._unitPrice = value;
			}
		}

		public MyBusinessObject()
		{
		}

		public MyBusinessObject(int _id, string _name, double _unitPrice, DateTime _date, bool _discontinued)
		{
			this._id = _id;
			this._name = _name;
			this._unitPrice = _unitPrice;
			this._date = _date;
			this._discontinued = _discontinued;
		}
	}
}