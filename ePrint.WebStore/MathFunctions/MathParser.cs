using System;
using System.Collections;
using System.Collections.Generic;

namespace MathFunctions
{
	public class MathParser
	{
		private Dictionary<MathFunctions.Parameters, decimal> _Parameters = new Dictionary<MathFunctions.Parameters, decimal>();

		private List<string> OperationOrder = new List<string>();

		public Dictionary<MathFunctions.Parameters, decimal> Parameters
		{
			get
			{
				return this._Parameters;
			}
			set
			{
				this._Parameters = value;
			}
		}

		public MathParser()
		{
			this.OperationOrder.Add("^");
			this.OperationOrder.Add("%");
			this.OperationOrder.Add("#");
			this.OperationOrder.Add("/");
			this.OperationOrder.Add("*");
			this.OperationOrder.Add("+");
			this.OperationOrder.Add("-");
		}

		public decimal Calculate(string Formula)
		{
			decimal num;
			try
			{
				string[] strArrays = Formula.Split("/+-*()%^#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				foreach (KeyValuePair<MathFunctions.Parameters, decimal> _Parameter in this._Parameters)
				{
					string[] strArrays1 = strArrays;
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						string str = strArrays1[i];
						if (str != _Parameter.Key.ToString() && str.EndsWith(_Parameter.Key.ToString()))
						{
							decimal num1 = Convert.ToDecimal(str.Replace(_Parameter.Key.ToString(), "")) * _Parameter.Value;
							Formula = Formula.Replace(str, num1.ToString());
						}
					}
					string str1 = _Parameter.Key.ToString();
					decimal value = _Parameter.Value;
					Formula = Formula.Replace(str1, value.ToString());
				}
				while (Formula.LastIndexOf("(") > -1)
				{
					int num2 = Formula.LastIndexOf("(");
					int num3 = Formula.IndexOf(")", num2);
					decimal num4 = this.ProcessOperation(Formula.Substring(num2 + 1, num3 - num2 - 1));
					bool flag = false;
					if (num2 > 0 && Formula.Substring(num2 - 1, 1) != "(" && !this.OperationOrder.Contains(Formula.Substring(num2 - 1, 1)))
					{
						flag = true;
					}
					Formula = string.Concat(Formula.Substring(0, num2), (flag ? "*" : ""), num4.ToString(), Formula.Substring(num3 + 1));
				}
				num = this.ProcessOperation(Formula);
			}
			catch (Exception exception)
			{
				num = new decimal(0);
			}
			return num;
		}

		private decimal CalculateByOperator(decimal number1, decimal number2, string op)
		{
			if (op == "/")
			{
				return number1 / number2;
			}
			if (op == "*")
			{
				return number1 * number2;
			}
			if (op == "-")
			{
				return number1 - number2;
			}
			if (op == "+")
			{
				return number1 + number2;
			}
			if (op == "^")
			{
				return Convert.ToDecimal(Math.Pow(Convert.ToDouble(number1), Convert.ToDouble(number2)));
			}
			if (op == "%")
			{
				return (number1 * number2) / new decimal(100);
			}
			if (op != "#")
			{
				return new decimal(0);
			}
			return number1 % number2;
		}

		private decimal ProcessOperation(string operation)
		{
			ArrayList arrayLists = new ArrayList();
			string str = "";
			for (int i = 0; i < operation.Length; i++)
			{
				string str1 = operation.Substring(i, 1);
				if (this.OperationOrder.IndexOf(str1) <= -1)
				{
					str = string.Concat(str, str1);
				}
				else
				{
					if (str != "")
					{
						arrayLists.Add(str);
					}
					arrayLists.Add(str1);
					str = "";
				}
			}
			arrayLists.Add(str);
			str = "";
			foreach (string operationOrder in this.OperationOrder)
			{
				while (arrayLists.IndexOf(operationOrder) > -1)
				{
					int num = arrayLists.IndexOf(operationOrder);
					decimal num1 = Convert.ToDecimal(arrayLists[num - 1]);
					decimal num2 = new decimal(0);
					if (arrayLists[num + 1].ToString() != "-")
					{
						num2 = Convert.ToDecimal(arrayLists[num + 1]);
					}
					else
					{
						arrayLists.RemoveAt(num + 1);
						num2 = Convert.ToDecimal(arrayLists[num + 1]) * new decimal(-1);
					}
					arrayLists[num] = this.CalculateByOperator(num1, num2, operationOrder);
					arrayLists.RemoveAt(num - 1);
					arrayLists.RemoveAt(num);
				}
			}
			return Convert.ToDecimal(arrayLists[0]);
		}
	}
}