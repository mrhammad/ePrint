using System;

namespace Item
{
	public class ItemClass
	{
		public ItemClass()
		{
		}

		public decimal RunningSpoilage(int Quantity, decimal Printlayout, decimal RunningSpoilage)
		{
			decimal num = new decimal(0);
			if (Printlayout != new decimal(0))
			{
				num = Convert.ToDecimal(Quantity / Printlayout);
			}
			decimal num1 = Convert.ToDecimal((num * RunningSpoilage) / new decimal(100));
			return num1;
		}

		public decimal TotalPaper(int Quantity, decimal Printlayout, decimal SetupSpoilage, decimal RunningSpoilage, string EstType)
		{
			decimal num = new decimal(0);
			if (EstType != "B")
			{
				decimal num1 = new decimal(0);
				if (Printlayout != new decimal(0))
				{
					num1 = Convert.ToDecimal(Quantity / Printlayout);
				}
				decimal num2 = Convert.ToDecimal((num1 * RunningSpoilage) / new decimal(100));
				num = (num1 + SetupSpoilage) + num2;
			}
			else
			{
				decimal num3 = Convert.ToDecimal((Printlayout * RunningSpoilage) / new decimal(100));
				num = (Printlayout + SetupSpoilage) + num3;
			}
			return num;
		}
	}
}