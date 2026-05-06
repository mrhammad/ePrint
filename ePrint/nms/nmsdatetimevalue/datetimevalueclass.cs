using System;
using System.Web.UI;

namespace nmsdatetimevalue
{
	public class datetimevalueclass : System.Web.UI.Page
	{
		public const int Sunday = 0;

		public const int Monday = 1;

		public const int Tuesday = 2;

		public const int Wednesday = 3;

		public const int Thursday = 4;

		public const int Friday = 5;

		public const int Saturday = 6;

		public int newintdateval;

		public datetimevalueclass()
		{
		}

		public int FirstDayOfMonth(int month, int year)
		{
			int i;
			int num = 1;
			for (i = 1900; i < year; i++)
			{
				num = (num + 365) % 7;
				if (this.IsLeapYear(i))
				{
					num = (num + 1) % 7;
				}
			}
			for (i = 1; i < month; i++)
			{
				num = (num + this.MonthDays(i, year)) % 7;
			}
			return num;
		}

		public int GetYearFromUser()
		{
			int num = 1900;
			while (true)
			{
				Console.Write("Which year? ");
				num = int.Parse(Console.ReadLine());
				if (num >= 1900)
				{
					break;
				}
				Console.WriteLine("The year must be at least 1900.");
			}
			return num;
		}

		public void IndentFirstLine(int weekday)
		{
			for (int i = 0; i < weekday; i++)
			{
				Console.Write("   ");
			}
		}

		public bool IsLeapYear(int year)
		{
			if (year % 4 == 0 && year % 100 != 0)
			{
				return true;
			}
			return year % 400 == 0;
		}

		public int MonthDays(int month, int year)
		{
			int num = month;
			switch (num)
			{
				case 2:
				{
					if (this.IsLeapYear(year))
					{
						return 29;
					}
					return 28;
				}
				case 3:
				case 5:
				{
					return 31;
				}
				case 4:
				case 6:
				{
					return 30;
				}
				default:
				{
					switch (num)
					{
						case 9:
						case 11:
						{
							return 30;
						}
						case 10:
						{
							return 31;
						}
						default:
						{
							return 31;
						}
					}
					break;
				}
			}
		}

		public string MonthName(int month)
		{
			switch (month)
			{
				case 1:
				{
					return "January";
				}
				case 2:
				{
					return "February";
				}
				case 3:
				{
					return "March";
				}
				case 4:
				{
					return "April";
				}
				case 5:
				{
					return "May";
				}
				case 6:
				{
					return "June";
				}
				case 7:
				{
					return "July";
				}
				case 8:
				{
					return "August";
				}
				case 9:
				{
					return "September";
				}
				case 10:
				{
					return "October";
				}
				case 11:
				{
					return "November";
				}
				case 12:
				{
					return "December";
				}
			}
			return "Illegal month";
		}

		public void PrintCalendar(int year)
		{
			for (int i = 1; i <= 12; i++)
			{
				this.PrintCalendarMonth(i, year);
				Console.WriteLine();
			}
		}

		public void PrintCalendarMonth(int month, int year)
		{
			object[] objArray = new object[] { "    ", this.MonthName(month), " ", year };
			Console.WriteLine(string.Concat(objArray));
			Console.WriteLine(" Su Mo Tu We Th Fr Sa");
			int num = this.MonthDays(month, year);
			int num1 = this.FirstDayOfMonth(month, year);
			this.IndentFirstLine(num1);
			for (int i = 1; i <= num; i++)
			{
				if (i <= 9)
				{
					Console.Write(string.Concat("  ", i));
				}
				else
				{
					Console.Write(string.Concat(" ", i));
				}
				if (num1 == 6)
				{
					Console.WriteLine();
				}
				num1 = (num1 + 1) % 7;
			}
			if (num1 != 0)
			{
				Console.WriteLine();
			}
		}

		public int weekdayName(string dayname)
		{
			string str = dayname;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "Monday":
					{
						this.newintdateval = 1;
						break;
					}
					case "Tuesday":
					{
						this.newintdateval = 2;
						break;
					}
					case "Wednesday":
					{
						this.newintdateval = 3;
						break;
					}
					case "Thursday":
					{
						this.newintdateval = 4;
						break;
					}
					case "Friday":
					{
						this.newintdateval = 5;
						break;
					}
					case "Saturday":
					{
						this.newintdateval = 6;
						break;
					}
					case "Sunday":
					{
						this.newintdateval = 0;
						break;
					}
				}
			}
			return this.newintdateval;
		}
	}
}