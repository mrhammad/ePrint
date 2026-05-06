using System;

namespace Printcenter.BusinessAccessLayer.Estimates
{
	public class OtherCostItemClass
	{
		private double _OtherCostExMarkup;

		public double OtherCostExMarkup
		{
			get
			{
				return this._OtherCostExMarkup;
			}
			set
			{
				this._OtherCostExMarkup = value;
			}
		}

		public OtherCostItemClass()
		{
		}
	}
}