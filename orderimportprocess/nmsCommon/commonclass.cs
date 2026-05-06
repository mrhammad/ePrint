using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class commonclass
	{
		public SqlConnection conn;

		public string connectionStringName = "ConnectionString";

		public string strConnection;

		public commonclass()
		{
			try
			{
				this.strConnection = ConfigurationManager.ConnectionStrings[this.connectionStringName].ToString();
			}
			catch
			{
			}
			this.conn = new SqlConnection(this.strConnection);
		}

		public void closeConnection()
		{
			this.conn.Close();
		}

		public SqlConnection openConnection()
		{
			this.conn.Open();
			return this.conn;
		}



        public string Return_Date_Before_View1(string strDate,string strDateFormat)
        {
            DateTime dateTime;
            string str;
            string str1;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string upper = string.Empty;
            if (strDate.Length > 0)
            {
                try
                {
                    empty = DateTime.Parse(strDate).ToShortDateString();
                }
                catch
                {
                    try
                    {
                        string[] strArrays = new string[5];
                        char[] chrArray = new char[] { '/' };
                        strArrays[0] = strDate.Split(chrArray)[1];
                        strArrays[1] = "/";
                        char[] chrArray1 = new char[] { '/' };
                        strArrays[2] = strDate.Split(chrArray1)[0];
                        strArrays[3] = "/";
                        char[] chrArray2 = new char[] { '/' };
                        strArrays[4] = strDate.Split(chrArray2)[2];
                        str1 = string.Concat(strArrays);
                        return str1;
                    }
                    catch
                    {
                        str1 = strDate;
                        return str1;
                    }
                }
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    dateTime = DateTime.Parse(strDate);
                    upper = strDateFormat.ToUpper();
                    string str2 = dateTime.Hour.ToString();
                    string str3 = dateTime.Minute.ToString();
                    string str4 = dateTime.Second.ToString();
                    string str5 = dateTime.Day.ToString();
                    string str6 = dateTime.Month.ToString();
                    string str7 = dateTime.Year.ToString().Substring(2);
                    string str8 = dateTime.Year.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = string.Concat("0", str2);
                    }
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    str = "";
                    string str9 = upper;
                    string str10 = str9;
                    if (str9 != null)
                    {
                        switch (str10)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str5, "/", str6, "/", str8, "-", str2, str3 };
                                    str = string.Concat(strArrays1);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays2 = new string[] { str5, "-", str6, "-", str8, "-", str2, str3 };
                                    str = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays3 = new string[] { str2, str3, "-", str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays3);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays4 = new string[] { str2, str3, "/", str5, "/", str6, "-", str8 };
                                    str = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays5 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays5);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str8 };
                                    str = string.Concat(strArrays6);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str5, "/", str6, "/", str8 };
                                    str = string.Concat(strArrays7);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays8 = new string[] { str6, "/", str5, "/", str8 };
                                    str = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays9 = new string[] { str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays9);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays10 = new string[] { str5, "/", str6, "/", str7 };
                                    str = string.Concat(strArrays10);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays11 = new string[] { str6, "/", str5, "/", str7 };
                                    str = string.Concat(strArrays11);
                                    break;
                                }
                            default:
                                {
                                    goto Label1;
                                }
                        }
                    }
                    else
                    {
                        goto Label1;
                    }
                    Label2:
                    empty1 = str.ToString();
                }
                catch
                {
                    str1 = strDate;
                    return str1;
                }
            }
            return empty1;
            Label1:
            str = dateTime.ToString();
            //goto Label2;
            return "";
        }


    }
}