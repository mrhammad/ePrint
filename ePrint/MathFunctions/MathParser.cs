using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MathFunctions
{
	public class MathParser
	{
		private Dictionary<MathFunctions.Parameters, decimal> _Parameters = new Dictionary<MathFunctions.Parameters, decimal>();

		private List<string> OperationOrder = new List<string>();

		private List<string> OperationOrder_ForOtherCostFormulCalculation = new List<string>();

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
			this.OperationOrder.Add("-");
			this.OperationOrder.Add("+");
			this.OperationOrder.Add("/");
			this.OperationOrder.Add("*");
			this.OperationOrder.Add("^");
			this.OperationOrder.Add("%");
			this.OperationOrder.Add("#");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("^");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("%");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("#");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("/");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("*");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("-");
			this.OperationOrder_ForOtherCostFormulCalculation.Add("+");
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

		public decimal Calculate_ForOtherCostFormulCalculation(string Formula)
		{
			decimal num;
			try
			{
				Formula = Formula.Replace(" ", "");
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
					decimal num4 = this.ProcessOperation_ForOtherCostFormulCalculation(Formula.Substring(num2 + 1, num3 - num2 - 1));
					bool flag = false;
					if (num2 > 0 && Formula.Substring(num2 - 1, 1) != "(" && !this.OperationOrder_ForOtherCostFormulCalculation.Contains(Formula.Substring(num2 - 1, 1)))
					{
						flag = true;
					}
					Formula = string.Concat(Formula.Substring(0, num2), (flag ? "*" : ""), num4.ToString(), Formula.Substring(num3 + 1));
				}
				num = this.ProcessOperation_ForOtherCostFormulCalculation(Formula);
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

		public decimal Evaluate(string MathExpression)
		{
			decimal num = new decimal(0);
			try
			{
				CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
				CompilerParameters compilerParameter = new CompilerParameters()
				{
					GenerateExecutable = false,
					GenerateInMemory = false
				};
				string str = string.Concat("namespace ns{using System;class class1{public static decimal Eval(){return Convert.ToDecimal(", MathExpression, ");}}} ");
				string[] strArrays = new string[] { str };
				CompilerResults compilerResult = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameter, strArrays);
				if (compilerResult.Errors.Count > 0)
				{
					throw new ArgumentException(string.Concat("Expression cannot be evaluated [", MathExpression, "]"));
				}
				MethodInfo method = compilerResult.CompiledAssembly.GetType("ns.class1").GetMethod("Eval");
				num = (decimal)method.Invoke(null, null);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				object[] mathExpression = new object[] { "Expression cannot be evaluated, please use a valid C# expression [", MathExpression, "] -- Ex[", exception.Message, "][", exception.InnerException, "]" };
				throw new ArgumentException(string.Concat(mathExpression));
			}
			return num;
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

		private decimal ProcessOperation_ForOtherCostFormulCalculation(string operation)
		{
			ArrayList arrayLists = new ArrayList();
			string str = "";
			for (int i = 0; i < operation.Length; i++)
			{
				string str1 = operation.Substring(i, 1);
				if (this.OperationOrder_ForOtherCostFormulCalculation.IndexOf(str1) <= -1)
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
			foreach (string operationOrderForOtherCostFormulCalculation in this.OperationOrder_ForOtherCostFormulCalculation)
			{
				while (arrayLists.IndexOf(operationOrderForOtherCostFormulCalculation) > -1)
				{
					int num = arrayLists.IndexOf(operationOrderForOtherCostFormulCalculation);
					decimal num1 = new decimal(0);
					decimal num2 = new decimal(0);
					if (num > 0)
					{
						if (arrayLists[num - 1].ToString() == "-" && operationOrderForOtherCostFormulCalculation == "-")
						{
							arrayLists[num - 1] = "+";
							arrayLists.RemoveAt(num);
							num--;
						}
						else if (arrayLists[num - 1].ToString() == "+" && operationOrderForOtherCostFormulCalculation == "-")
						{
							arrayLists[num - 1] = "-";
							arrayLists.RemoveAt(num);
							num--;
						}
						else if (arrayLists[num - 1].ToString() == "-" && operationOrderForOtherCostFormulCalculation == "+")
						{
							arrayLists[num - 1] = "-";
							arrayLists.RemoveAt(num);
							num--;
						}
						else if (arrayLists[num - 1].ToString() == "+" && operationOrderForOtherCostFormulCalculation == "+")
						{
							arrayLists[num - 1] = "+";
							arrayLists.RemoveAt(num);
							num--;
						}
						num1 = Convert.ToDecimal(arrayLists[num - 1]);
					}
					if (arrayLists[num + 1].ToString() != "-")
					{
						num2 = Convert.ToDecimal(arrayLists[num + 1]);
					}
					else
					{
						arrayLists.RemoveAt(num + 1);
						num2 = Convert.ToDecimal(arrayLists[num + 1]) * new decimal(-1);
					}
					if (num != 0 || !(operationOrderForOtherCostFormulCalculation == "-"))
					{
						arrayLists[num] = this.CalculateByOperator(num1, num2, operationOrderForOtherCostFormulCalculation);
					}
					else
					{
						arrayLists[num + 1] = this.CalculateByOperator(num1, num2, operationOrderForOtherCostFormulCalculation);
					}
					if (num > 0)
					{
						arrayLists.RemoveAt(num - 1);
					}
					arrayLists.RemoveAt(num);
				}
			}
			return Convert.ToDecimal(arrayLists[0]);
		}
	}
}