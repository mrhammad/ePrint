using nmsCommon;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ePrint.ePrintUtilities
{
    public class DurationFilters
    {
        private commonClass objCommon = new commonClass();
        int CompanyID;
        int UserID;
        string DateFormat;
        string fromDate;
        string toDate;

        public DurationFilters(int CompanyID, int UserID, string DateFormat, string fromDate = "", string toDate = "")
        {
            this.CompanyID = CompanyID;
            this.UserID = UserID;
            this.DateFormat = DateFormat;//.Replace("mm", "MM");
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        public void AppendDurationFiltersToQuery(string selectedDuration, StringBuilder stringBuilder1, SqlCommand sqlCommandParam)
        {
            if (!string.IsNullOrEmpty(selectedDuration))
            {
                DateTime now1 = DateTime.Now;
                string str3 = objCommon.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                char[] chrArray = new char[] { ' ' };
                this.day = str3.Split(chrArray);
                DateTime now = DateTime.Now;
                string standardFormat = this.DateFormat.Replace("mm", "MM");
                string[] str;
                if (selectedDuration == "daily")
                {
                    string str12 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    stringBuilder1.Append(string.Concat(" and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) = ", "@CreatedDate", " "));
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDate", str12);
                }
                else if (selectedDuration == "yesterday")
                {
                    DateTime dateTime = objCommon.Eprint_return_ActualDate_Before_View(DateTime.Now.ToString(), this.CompanyID, this.UserID, true);
                    string str4 = dateTime.AddDays(-1).ToString();
                    char[] chrArray1 = new char[] { ' ' };
                    string str5 = objCommon.Eprint_return_Date_Before_View(str4.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);

                    this.yestday = str5.Split(chrArray1);
                    string str13 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    stringBuilder1.Append(string.Concat(" and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) = ", "@CreatedDate", " "));
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDate", str13);
                }
                else if (selectedDuration == "thismonth")
                {
                    DateTime dateTime = objCommon.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
                    DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, 1);
                    DateTime dateTime3 = dateTime2.AddMonths(1).AddDays(-1);
                    string str6 = this.objCommon.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);

                    this.stdate = str6.Split(chrArray);
                    string str7 = this.objCommon.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray4 = new char[] { ' ' };
                    this.endate = str7.Split(chrArray4);

                    string str14 = DateTimeUtility.ConvertDateToRequiredFormat(this.DateFormat, this.stdate[0].ToString());
                    string str15 = DateTimeUtility.ConvertDateToRequiredFormat(this.DateFormat, this.endate[0].ToString());
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str14);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str15);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "thisquarter")
                {
                    string[] strArrays2 = CurrentQuater().Split(new char[] { ',' });
                    string str8 = this.objCommon.Eprint_return_Date_Before_View(strArrays2[0].ToString(), this.CompanyID, this.UserID, false);
                    this.stquardate = str8.Split(chrArray);
                    string str9 = this.objCommon.Eprint_return_Date_Before_View(strArrays2[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enquardate = str9.Split(chrArray);

                    string str16 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str17 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str16);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str17);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == ePrintConstants.ThisAnnualYear)
                {
                    string str16 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat).ToString());
                    string str17 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(standardFormat));
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str16);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str17);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "lastquater")
                {
                    string[] strArrays5 = this.LastQuarter().Split(new char[] { ',' });
                    string str10 = this.objCommon.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
                    this.stlastquardate = str10.Split(chrArray);
                    string str11 = this.objCommon.Eprint_return_Date_Before_View(strArrays5[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enlastquardate = str11.Split(chrArray);

                    string str18 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str19 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    str = new string[] { " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str18);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str19);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "thisyear") // This Fiscal year
                {
                    string[] strArrays8 = this.CurrentFiscalYear().Split(new char[] { ',' });
                    string str12 = this.objCommon.Eprint_return_Date_Before_View(strArrays8[0].ToString(), this.CompanyID, this.UserID, false);
                    this.startyear = str12.Split(chrArray);
                    string str13 = this.objCommon.Eprint_return_Date_Before_View(strArrays8[1].ToString(), this.CompanyID, this.UserID, false);
                    this.endyear = str13.Split(chrArray);
                    string str20 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.startyear[0].ToString());
                    string str21 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endyear[0].ToString());
                    str = new string[] { " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str20);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str21);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "lastfiscalyear") // Last Fiscal year
                {
                    string[] strArrays8 = this.LastFiscalYear().Split(new char[] { ',' });

                    // Convert to DateTime
                    DateTime lastStartDate = DateTime.Parse(strArrays8[0]);
                    DateTime lastEndDate = DateTime.Parse(strArrays8[1]);

                    // Convert back to string using existing methods
                    //string str12 = this.objCommon.Eprint_return_Date_Before_View(lastStartDate.ToString(standardFormat), this.CompanyID, this.UserID, false);
                    //this.startyear = str12.Split(chrArray);

                    //string str13 = this.objCommon.Eprint_return_Date_Before_View(lastEndDate.ToString(standardFormat), this.CompanyID, this.UserID, false);
                    //this.endyear = str13.Split(chrArray);

                    // Format dates according to system
                    string str20 = lastStartDate.ToString();//  this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, lastStartDate.ToString());
                    string str21 = lastEndDate.ToString();// this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, lastEndDate.ToString());

                    str = new string[] { " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str20);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str21);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "thisfiscalyear") // Last Fiscal year
                {
                    string[] strArrays8 = this.CurrentFiscalYear().Split(new char[] { ',' });

                    // Convert to DateTime
                    DateTime lastStartDate = DateTime.Parse(strArrays8[0]);
                    DateTime lastEndDate = DateTime.Parse(strArrays8[1]);

                    // Convert back to string using existing methods
                    //string str12 = this.objCommon.Eprint_return_Date_Before_View(lastStartDate.ToString(standardFormat), this.CompanyID, this.UserID, false);
                    //this.startyear = str12.Split(chrArray);

                    //string str13 = this.objCommon.Eprint_return_Date_Before_View(lastEndDate.ToString(standardFormat), this.CompanyID, this.UserID, false);
                    //this.endyear = str13.Split(chrArray);

                    // Format dates according to system
                    string str20 = lastStartDate.ToString();//this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, lastStartDate.ToString());
                    string str21 = lastEndDate.ToString(); this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, lastEndDate.ToString());

                    str = new string[] { " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str20);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str21);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "halfyear")
                {
                    string[] strArrays11 = this.HalfFiscalYear().Split(new char[] { ',' });
                    string str14 = this.objCommon.Eprint_return_Date_Before_View(strArrays11[0].ToString(), this.CompanyID, this.UserID, false);
                    this.from_halffiscalyear = str14.Split(chrArray);

                    string str15 = this.objCommon.Eprint_return_Date_Before_View(strArrays11[1].ToString(), this.CompanyID, this.UserID, false);
                    this.to_halffiscalyear = str15.Split(chrArray);

                    string str22 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str23 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) between ", "@CreatedDateStart", " and ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str22);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str23);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "tilldate")
                {
                    commonClass _commonClass = this.objCommon;

                    string str24 = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    string[] strArrays = str24.Split(chrArray);
                    stringBuilder1.Append(string.Concat(" and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) <= ", "@CreatedDate", " "));
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDate", this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays[0].ToString()));
                }
                else if (selectedDuration == "daterange")
                {
                    string str25 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.fromDate));
                    string str26 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.toDate));
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) BETWEEN ", "@CreatedDateStart", " AND ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str25);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str26);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "thisweek")
                {
                    // Get this week range (assuming week starts on Monday)
                    string[] strArrays3 = this.ThisWeek().Split(new char[] { ',' });

                    // Start Date
                    string str71 = this.objCommon.Eprint_return_Date_Before_View(
                        strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                    this.stthisweek = str71.Split(chrArray);

                    // End Date
                    string str8 = this.objCommon.Eprint_return_Date_Before_View(
                        strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enthisweek = str8.Split(chrArray);

                    // Format for SQL
                    string str25 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(
                        this.DateFormat, ReplaceSingleQuote(this.stthisweek[0]));
                    string str26 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(
                        this.DateFormat, ReplaceSingleQuote(this.enthisweek[0]));

                    // Add SQL condition
                    str = new string[]
                    {
    " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) BETWEEN ",
    "@CreatedDateStart", " AND ", "@CreatedDateEnd", " "
                    };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str25);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str26);

                    stringBuilder1.Append(string.Concat(str));

                }
                else if (selectedDuration == "lastweek")
                {
                    string[] strArrays3 = this.Lastweek().Split(new char[] { ',' });
                    string str71 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                    this.stlastweek = str71.Split(chrArray);
                    string str8 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enlastweek = str8.Split(chrArray);

                    string str25 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.stlastweek[0]));
                    string str26 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.enlastweek[0]));
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) BETWEEN ", "@CreatedDateStart", " AND ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str25);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str26);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "lastmonth")
                {
                    string[] strArrays3 = Lastmonth().Split(new char[] { ',' });
                    string str71 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                    this.stlastmonth = str71.Split(chrArray);
                    string str8 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enlastmonth = str8.Split(chrArray);
                    //string str25 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.stlastmonth[0]));
                    //string str26 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.enlastmonth[0]));
                    string str25 = DateTimeUtility.ConvertDateToRequiredFormat(this.DateFormat, ReplaceSingleQuote(this.stlastmonth[0]));
                    string str26 = DateTimeUtility.ConvertDateToRequiredFormat(this.DateFormat, ReplaceSingleQuote(this.enlastmonth[0]));
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) BETWEEN ", "@CreatedDateStart", " AND ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str25);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str26);
                    stringBuilder1.Append(string.Concat(str));
                }
                else if (selectedDuration == "lastyear")
                {
                    string[] strArrays3 = this.Lastyear().Split(new char[] { ',' });
                    string str71 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray7 = new char[] { ' ' };
                    this.stlastyear = str71.Split(chrArray7);
                    string str8 = this.objCommon.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                    this.enlastyear = str8.Split(chrArray);
                    string str25 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.stlastyear[0]));
                    string str26 = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ReplaceSingleQuote(this.enlastyear[0]));
                    str = new string[] { " and DateAdd(d,0,Datediff(d,0,a.CreatedDate)) BETWEEN ", "@CreatedDateStart", " AND ", "@CreatedDateEnd", " " };
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateStart", str25);
                    sqlCommandParam.Parameters.AddWithValue("@CreatedDateEnd", str26);
                    stringBuilder1.Append(string.Concat(str));
                }
            }
        }


        #region duration date related fields

        public string[] day;

        public string[] yestday;
        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] from_halffiscalyear;

        public string[] to_halffiscalyear;

        public string[] startyear;

        public string[] endyear;

        public string[] stlastweek;

        public string[] enlastweek;

        public string[] stthisweek;

        public string[] enthisweek;

        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string year = string.Empty;

        #endregion

        #region Duration Filters
        private string ThisWeek()
        {
            DateTime today = DateTime.Today;

            // Start of this week (Monday)
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime startOfWeek = today.AddDays(-1 * diff).Date;

            // End of this week (Sunday)
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Return as string with comma separator (same style as Lastweek)
            return $"{startOfWeek:MM/dd/yyyy},{endOfWeek:MM/dd/yyyy}";
        }

        public string Lastweek()
        {
            DateTime today = DateTime.Today;
            DayOfWeek currentDayOfWeek = today.DayOfWeek;

            // Calculate the start date of last week
            DateTime lastWeekStartDate = today.AddDays(-(int)currentDayOfWeek - 6);

            // Calculate the end date of last week
            DateTime lastWeekEndDate = lastWeekStartDate.AddDays(6);

            return lastWeekStartDate.ToString() + "," + lastWeekEndDate.ToString();
        }
        public string Lastmonth()
        {
            DateTime today = DateTime.Today;

            // Get the first day of the current month
            DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);

            // Get the last day of the previous month
            DateTime lastDayOfLastMonth = firstDayOfThisMonth.AddDays(-1);

            // Get the first day of the previous month
            DateTime firstDayOfLastMonth = new DateTime(lastDayOfLastMonth.Year, lastDayOfLastMonth.Month, 1);



            return firstDayOfLastMonth.ToString() + "," + lastDayOfLastMonth.ToString();
        }
        public string Lastyear()
        {
            DateTime currentDate = DateTime.Today;

            // Get start date of last year
            DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);

            // Get end date of last year
            DateTime lastYearEndDate = new DateTime(currentDate.Year - 1, 12, 31);


            return lastYearStartDate.ToString() + "," + lastYearEndDate.ToString();
        }

        public string HalfFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            int month = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToString());
            int num = dateTime.Month;
            DateTime dateTime3 = dateTime.AddMonths(5);
            int month1 = dateTime3.Month;
            int year = 0;
            int num1 = 0;
            int month2 = dateTime.Month;
            int num2 = dateTime2.Month;
            int month3 = dateTime3.Month;
            if (num <= 7)
            {
                num1 = DateTime.DaysInMonth(dateTime.Year, month1);
            }
            else
            {
                year = dateTime.AddYears(1).Year;
                num1 = DateTime.DaysInMonth(year, month1);
            }
            if (num2 <= month1 || dateTime2.Year != dateTime3.Year)
            {
                dateTimeArray[0] = new DateTime(dateTime.Year, num, 1);
                dateTimeArray[1] = new DateTime(dateTime3.Year, month1, num1);
            }
            else
            {
                dateTimeArray[0] = new DateTime(dateTime3.Year, month1 + 1, 1);
                dateTimeArray[1] = dateTime1;
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string LastQuarter()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime.Month;
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int num = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (num == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int month1 = dateTime.Month;
                    if (month1 == 1)
                    {
                        int num1 = month1 + 11;
                        month1 = month1 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num1, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 2)
                    {
                        int num2 = month1 + 10;
                        month1 = month1 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num2, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 3)
                    {
                        int num3 = month1 + 9;
                        month1 = month1 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num3, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime.Month;
                    if (month2 == 4)
                    {
                        month2 = month2 - 3;
                        int num4 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num4, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 5)
                    {
                        month2 = month2 - 4;
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num5, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 5;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num6, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime.Month;
                    if (month3 == 7)
                    {
                        month3 = month3 - 3;
                        int num7 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num7, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 8)
                    {
                        month3 = month3 - 4;
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num8, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 5;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num9, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime.Month;
                    if (month4 == 10)
                    {
                        month4 = month4 - 3;
                        int num10 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num10, DateTime.DaysInMonth(dateTime.Year, num10));
                    }
                    if (month4 == 11)
                    {
                        month4 = month4 - 4;
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num11, DateTime.DaysInMonth(dateTime.Year, num11));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 5;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num12, DateTime.DaysInMonth(dateTime.Year, num12));
                    }
                }
            }
            if (num == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime.Month;
                    if (month5 == 2)
                    {
                        int num13 = month5 - 1;
                        month5 = month5 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num13, DateTime.DaysInMonth(dateTime.Year, num13));
                    }
                    else if (month5 == 3)
                    {
                        int num14 = month5 - 2;
                        month5 = month5 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num14, DateTime.DaysInMonth(dateTime.Year, num14));
                    }
                    else if (month5 == 4)
                    {
                        int num15 = month5 - 3;
                        month5 = month5 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num15, DateTime.DaysInMonth(dateTime.Year, num15));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime.Month;
                    if (month6 == 5)
                    {
                        int num16 = month6 - 1;
                        month6 = month6 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num16, DateTime.DaysInMonth(dateTime.Year, num16));
                    }
                    else if (month6 == 6)
                    {
                        int num17 = month6 - 2;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num17, DateTime.DaysInMonth(dateTime.Year, num17));
                    }
                    else if (month6 == 7)
                    {
                        int num18 = month6 - 3;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num18, DateTime.DaysInMonth(dateTime.Year, num18));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime.Month;
                    if (month7 == 8)
                    {
                        int num19 = month7 - 1;
                        month7 = month7 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num19, DateTime.DaysInMonth(dateTime.Year, num19));
                    }
                    else if (month7 == 9)
                    {
                        int num20 = month7 - 2;
                        month7 = month7 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num20, DateTime.DaysInMonth(dateTime.Year, num20));
                    }
                    else if (month7 == 10)
                    {
                        int num21 = month7 - 3;
                        month7 = month7 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num21, DateTime.DaysInMonth(dateTime.Year, num21));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime.Month;
                    if (month8 == 11)
                    {
                        int num22 = month8 - 1;
                        month8 = month8 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num22, DateTime.DaysInMonth(dateTime.Year, num22));
                    }
                    if (month8 == 12)
                    {
                        int num23 = month8 - 2;
                        month8 = month8 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num23, DateTime.DaysInMonth(dateTime.Year, num23));
                    }
                    else if (month8 == 1)
                    {
                        int num24 = month8 + 9;
                        month8 = month8 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num24, DateTime.DaysInMonth(dateTime.Year, num24));
                    }
                }
            }
            if (num == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime.Month;
                    if (month9 == 3)
                    {
                        int num25 = month9 - 1;
                        month9 = month9 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num25, DateTime.DaysInMonth(dateTime.Year, num25));
                    }
                    else if (month9 == 4)
                    {
                        int num26 = month9 - 2;
                        month9 = month9 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num26, DateTime.DaysInMonth(dateTime.Year, num26));
                    }
                    else if (month9 == 5)
                    {
                        int num27 = month9 - 3;
                        month9 = month9 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num27, DateTime.DaysInMonth(dateTime.Year, num27));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime.Month;
                    if (month10 == 6)
                    {
                        int num28 = month10 - 1;
                        month10 = month10 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num28, DateTime.DaysInMonth(dateTime.Year, num28));
                    }
                    else if (month10 == 7)
                    {
                        int num29 = month10 - 2;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num29, DateTime.DaysInMonth(dateTime.Year, num29));
                    }
                    else if (month10 == 8)
                    {
                        int num30 = month10 - 3;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num30, DateTime.DaysInMonth(dateTime.Year, num30));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime.Month;
                    if (month11 == 9)
                    {
                        int num31 = month11 - 1;
                        month11 = month11 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num31, DateTime.DaysInMonth(dateTime.Year, num31));
                    }
                    else if (month11 == 10)
                    {
                        int num32 = month11 - 2;
                        month11 = month11 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num32, DateTime.DaysInMonth(dateTime.Year, num32));
                    }
                    else if (month11 == 11)
                    {
                        int num33 = month11 - 3;
                        month11 = month11 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num33, DateTime.DaysInMonth(dateTime.Year, num33));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime.Month;
                    if (month12 == 12)
                    {
                        int num34 = month12 - 1;
                        month12 = month12 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num34, DateTime.DaysInMonth(dateTime.Year, num34));
                    }
                    if (month12 == 1)
                    {
                        int num35 = month12 + 10;
                        month12 = month12 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num35, DateTime.DaysInMonth(dateTime.Year, num35));
                    }
                    else if (month12 == 2)
                    {
                        int num36 = month12 + 9;
                        month12 = month12 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num36, DateTime.DaysInMonth(dateTime.Year, num36));
                    }
                }
            }
            if (num == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime.Month;
                    if (month13 == 4)
                    {
                        int num37 = month13 - 1;
                        month13 = month13 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num37, DateTime.DaysInMonth(dateTime.Year, num37));
                    }
                    else if (month13 == 5)
                    {
                        int num38 = month13 - 2;
                        month13 = month13 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num38, DateTime.DaysInMonth(dateTime.Year, num38));
                    }
                    else if (month13 == 6)
                    {
                        int num39 = month13 - 3;
                        month13 = month13 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num39, DateTime.DaysInMonth(dateTime.Year, num39));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime.Month;
                    if (month14 == 7)
                    {
                        int num40 = month14 - 1;
                        month14 = month14 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num40, DateTime.DaysInMonth(dateTime.Year, num40));
                    }
                    else if (month14 == 8)
                    {
                        int num41 = month14 - 2;
                        month14 = month14 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num41, DateTime.DaysInMonth(dateTime.Year, num41));
                    }
                    else if (month14 == 9)
                    {
                        int num42 = month14 - 3;
                        month14 = month14 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num42, DateTime.DaysInMonth(dateTime.Year, num42));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime.Month;
                    if (month15 == 10)
                    {
                        int num43 = month15 - 1;
                        month15 = month15 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num43, DateTime.DaysInMonth(dateTime.Year, num43));
                    }
                    else if (month15 == 11)
                    {
                        int num44 = month15 - 2;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num44, DateTime.DaysInMonth(dateTime.Year, num44));
                    }
                    else if (month15 == 12)
                    {
                        int num45 = month15 - 3;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num45, DateTime.DaysInMonth(dateTime.Year, num45));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime.Month;
                    if (month16 == 1)
                    {
                        int num46 = month16 + 11;
                        month16 = month16 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num46, DateTime.DaysInMonth(dateTime.Year, num46));
                    }
                    if (month16 == 2)
                    {
                        int num47 = month16 + 10;
                        month16 = month16 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num47, DateTime.DaysInMonth(dateTime.Year, num47));
                    }
                    else if (month16 == 3)
                    {
                        int num48 = month16 + 9;
                        month16 = month16 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num48, DateTime.DaysInMonth(dateTime.Year, num48));
                    }
                }
            }
            if (num == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime.Month;
                    if (month17 == 5)
                    {
                        int num49 = month17 - 1;
                        month17 = month17 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num49, DateTime.DaysInMonth(dateTime.Year, num49));
                    }
                    else if (month17 == 6)
                    {
                        int num50 = month17 - 2;
                        month17 = month17 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num50, DateTime.DaysInMonth(dateTime.Year, num50));
                    }
                    else if (month17 == 7)
                    {
                        int num51 = month17 - 3;
                        month17 = month17 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num51, DateTime.DaysInMonth(dateTime.Year, num51));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime.Month;
                    if (month18 == 8)
                    {
                        int num52 = month18 - 1;
                        month18 = month18 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num52, DateTime.DaysInMonth(dateTime.Year, num52));
                    }
                    else if (month18 == 9)
                    {
                        int num53 = month18 - 2;
                        month18 = month18 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num53, DateTime.DaysInMonth(dateTime.Year, num53));
                    }
                    else if (month18 == 10)
                    {
                        int num54 = month18 - 3;
                        month18 = month18 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num54, DateTime.DaysInMonth(dateTime.Year, num54));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime.Month;
                    if (month19 == 11)
                    {
                        int num55 = month19 - 1;
                        month19 = month19 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num55, DateTime.DaysInMonth(dateTime.Year, num55));
                    }
                    else if (month19 == 12)
                    {
                        int num56 = month19 - 2;
                        month19 = month19 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num56, DateTime.DaysInMonth(dateTime.Year, num56));
                    }
                    else if (month19 == 1)
                    {
                        int num57 = month19 + 7;
                        month19 = month19 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num57, DateTime.DaysInMonth(dateTime.Year, num57));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime.Month;
                    if (month20 == 2)
                    {
                        int num58 = month20 - 1;
                        month20 = month20 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num58, DateTime.DaysInMonth(dateTime.Year, num58));
                    }
                    if (month20 == 3)
                    {
                        int num59 = month20 - 2;
                        month20 = month20 - 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num59, DateTime.DaysInMonth(dateTime.Year, num59));
                    }
                    else if (month20 == 4)
                    {
                        int num60 = month20 - 3;
                        month20 = month20 - 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num60, DateTime.DaysInMonth(dateTime.Year, num60));
                    }
                }
            }
            if (num == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime.Month;
                    if (month21 == 6)
                    {
                        int num61 = month21 - 1;
                        month21 = month21 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num61, DateTime.DaysInMonth(dateTime.Year, num61));
                    }
                    else if (month21 == 7)
                    {
                        int num62 = month21 - 2;
                        month21 = month21 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num62, DateTime.DaysInMonth(dateTime.Year, num62));
                    }
                    else if (month21 == 8)
                    {
                        int num63 = month21 - 3;
                        month21 = month21 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num63, DateTime.DaysInMonth(dateTime.Year, num63));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime.Month;
                    if (month22 == 9)
                    {
                        int num64 = month22 - 1;
                        month22 = month22 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num64, DateTime.DaysInMonth(dateTime.Year, num64));
                    }
                    else if (month22 == 10)
                    {
                        int num65 = month22 - 2;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num65, DateTime.DaysInMonth(dateTime.Year, num65));
                    }
                    else if (month22 == 11)
                    {
                        int num66 = month22 - 3;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num66, DateTime.DaysInMonth(dateTime.Year, num66));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime.Month;
                    if (month23 == 12)
                    {
                        int num67 = month23 - 1;
                        month23 = month23 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num67, DateTime.DaysInMonth(dateTime.Year, num67));
                    }
                    else if (month23 == 1)
                    {
                        int num68 = month23 + 10;
                        month23 = month23 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num68, DateTime.DaysInMonth(dateTime.Year, num68));
                    }
                    else if (month23 == 2)
                    {
                        int num69 = month23 + 9;
                        month23 = month23 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num69, DateTime.DaysInMonth(dateTime.Year, num69));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime.Month;
                    if (month24 == 3)
                    {
                        int num70 = month24 - 1;
                        month24 = month24 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num70, DateTime.DaysInMonth(dateTime.Year, num70));
                    }
                    if (month24 == 4)
                    {
                        int num71 = month24 - 2;
                        month24 = month24 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num71, DateTime.DaysInMonth(dateTime.Year, num71));
                    }
                    else if (month24 == 5)
                    {
                        int num72 = month24 - 3;
                        month24 = month24 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num72, DateTime.DaysInMonth(dateTime.Year, num72));
                    }
                }
            }
            if (num == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime.Month;
                    if (month25 == 7)
                    {
                        int num73 = month25 - 1;
                        month25 = month25 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num73, DateTime.DaysInMonth(dateTime.Year, num73));
                    }
                    else if (month25 == 8)
                    {
                        int num74 = month25 - 2;
                        month25 = month25 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num74, DateTime.DaysInMonth(dateTime.Year, num74));
                    }
                    else if (month25 == 9)
                    {
                        int num75 = month25 - 3;
                        month25 = month25 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num75, DateTime.DaysInMonth(dateTime.Year, num75));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime.Month;
                    if (month26 == 10)
                    {
                        int num76 = month26 - 1;
                        month26 = month26 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num76, DateTime.DaysInMonth(dateTime.Year, num76));
                    }
                    else if (month26 == 11)
                    {
                        int num77 = month26 - 2;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num77, DateTime.DaysInMonth(dateTime.Year, num77));
                    }
                    else if (month26 == 12)
                    {
                        int num78 = month26 - 3;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num78, DateTime.DaysInMonth(dateTime.Year, num78));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime.Month;
                    if (month27 == 1)
                    {
                        int num79 = month27 + 11;
                        month27 = month27 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num79, DateTime.DaysInMonth(dateTime.Year, num79));
                    }
                    else if (month27 == 2)
                    {
                        int num80 = month27 + 10;
                        month27 = month27 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num80, DateTime.DaysInMonth(dateTime.Year, num80));
                    }
                    else if (month27 == 3)
                    {
                        int num81 = month27 + 9;
                        month27 = month27 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num81, DateTime.DaysInMonth(dateTime.Year, num81));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime.Month;
                    if (month28 == 4)
                    {
                        int num82 = month28 - 1;
                        month28 = month28 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num82, DateTime.DaysInMonth(dateTime.Year, num82));
                    }
                    if (month28 == 5)
                    {
                        int num83 = month28 - 2;
                        month28 = month28 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num83, DateTime.DaysInMonth(dateTime.Year, num83));
                    }
                    else if (month28 == 6)
                    {
                        int num84 = month28 - 3;
                        month28 = month28 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num84, DateTime.DaysInMonth(dateTime.Year, num84));
                    }
                }
            }
            if (num == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime.Month;
                    if (month29 == 8)
                    {
                        int num85 = month29 - 1;
                        month29 = month29 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num85, DateTime.DaysInMonth(dateTime.Year, num85));
                    }
                    else if (month29 == 9)
                    {
                        int num86 = month29 - 2;
                        month29 = month29 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num86, DateTime.DaysInMonth(dateTime.Year, num86));
                    }
                    else if (month29 == 10)
                    {
                        int num87 = month29 - 3;
                        month29 = month29 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num87, DateTime.DaysInMonth(dateTime.Year, num87));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime.Month;
                    if (month30 == 11)
                    {
                        int num88 = month30 - 1;
                        month30 = month30 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num88, DateTime.DaysInMonth(dateTime.Year, num88));
                    }
                    else if (month30 == 12)
                    {
                        int num89 = month30 - 2;
                        month30 = month30 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num89, DateTime.DaysInMonth(dateTime.Year, num89));
                    }
                    else if (month30 == 1)
                    {
                        int num90 = month30 + 9;
                        month30 = month30 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num90, DateTime.DaysInMonth(dateTime.Year, num90));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime.Month;
                    if (month31 == 2)
                    {
                        int num91 = month31 - 1;
                        month31 = month31 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num91, DateTime.DaysInMonth(dateTime.Year, num91));
                    }
                    else if (month31 == 3)
                    {
                        int num92 = month31 - 2;
                        month31 = month31 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num92, DateTime.DaysInMonth(dateTime.Year, num92));
                    }
                    else if (month31 == 4)
                    {
                        int num93 = month31 - 3;
                        month31 = month31 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num93, DateTime.DaysInMonth(dateTime.Year, num93));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime.Month;
                    if (month32 == 5)
                    {
                        int num94 = month32 - 1;
                        month32 = month32 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num94, DateTime.DaysInMonth(dateTime.Year, num94));
                    }
                    if (month32 == 6)
                    {
                        int num95 = month32 - 2;
                        month32 = month32 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num95, DateTime.DaysInMonth(dateTime.Year, num95));
                    }
                    else if (month32 == 7)
                    {
                        int num96 = month32 - 3;
                        month32 = month32 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num96, DateTime.DaysInMonth(dateTime.Year, num96));
                    }
                }
            }
            if (num == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime.Month;
                    if (month33 == 9)
                    {
                        int num97 = month33 - 1;
                        month33 = month33 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num97, DateTime.DaysInMonth(dateTime.Year, num97));
                    }
                    else if (month33 == 10)
                    {
                        int num98 = month33 - 2;
                        month33 = month33 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num98, DateTime.DaysInMonth(dateTime.Year, num98));
                    }
                    else if (month33 == 11)
                    {
                        int num99 = month33 - 3;
                        month33 = month33 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num99, DateTime.DaysInMonth(dateTime.Year, num99));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime.Month;
                    if (month34 == 12)
                    {
                        int num100 = month34 - 1;
                        month34 = month34 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num100, DateTime.DaysInMonth(dateTime.Year, num100));
                    }
                    else if (month34 == 1)
                    {
                        int num101 = month34 + 10;
                        month34 = month34 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num101, DateTime.DaysInMonth(dateTime.Year, num101));
                    }
                    else if (month34 == 2)
                    {
                        int num102 = month34 + 9;
                        month34 = month34 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num102, DateTime.DaysInMonth(dateTime.Year, num102));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime.Month;
                    if (month35 == 3)
                    {
                        int num103 = month35 - 1;
                        month35 = month35 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num103, DateTime.DaysInMonth(dateTime.Year, num103));
                    }
                    else if (month35 == 4)
                    {
                        int num104 = month35 - 2;
                        month35 = month35 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num104, DateTime.DaysInMonth(dateTime.Year, num104));
                    }
                    else if (month35 == 5)
                    {
                        int num105 = month35 - 3;
                        month35 = month35 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num105, DateTime.DaysInMonth(dateTime.Year, num105));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime.Month;
                    if (month36 == 6)
                    {
                        int num106 = month36 - 1;
                        month36 = month36 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num106, DateTime.DaysInMonth(dateTime.Year, num106));
                    }
                    if (month36 == 7)
                    {
                        int num107 = month36 - 2;
                        month36 = month36 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num107, DateTime.DaysInMonth(dateTime.Year, num107));
                    }
                    else if (month36 == 8)
                    {
                        int num108 = month36 - 3;
                        month36 = month36 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num108, DateTime.DaysInMonth(dateTime.Year, num108));
                    }
                }
            }
            if (num == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime.Month;
                    if (month37 == 10)
                    {
                        int num109 = month37 - 1;
                        month37 = month37 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num109, DateTime.DaysInMonth(dateTime.Year, num109));
                    }
                    else if (month37 == 11)
                    {
                        int num110 = month37 - 2;
                        month37 = month37 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num110, DateTime.DaysInMonth(dateTime.Year, num110));
                    }
                    else if (month37 == 12)
                    {
                        int num111 = month37 - 3;
                        month37 = month37 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num111, DateTime.DaysInMonth(dateTime.Year, num111));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime.Month;
                    if (month38 == 1)
                    {
                        int num112 = month38 + 11;
                        month38 = month38 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num112, DateTime.DaysInMonth(dateTime.Year, num112));
                    }
                    else if (month38 == 2)
                    {
                        int num113 = month38 + 10;
                        month38 = month38 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num113, DateTime.DaysInMonth(dateTime.Year, num113));
                    }
                    else if (month38 == 3)
                    {
                        int num114 = month38 + 9;
                        month38 = month38 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num114, DateTime.DaysInMonth(dateTime.Year, num114));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime.Month;
                    if (month39 == 4)
                    {
                        int num115 = month39 - 1;
                        month39 = month39 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num115, DateTime.DaysInMonth(dateTime.Year, num115));
                    }
                    else if (month39 == 5)
                    {
                        int num116 = month39 - 2;
                        month39 = month39 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num116, DateTime.DaysInMonth(dateTime.Year, num116));
                    }
                    else if (month39 == 6)
                    {
                        int num117 = month39 - 3;
                        month39 = month39 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num117, DateTime.DaysInMonth(dateTime.Year, num117));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime.Month;
                    if (month40 == 7)
                    {
                        int num118 = month40 - 1;
                        month40 = month40 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num118, DateTime.DaysInMonth(dateTime.Year, num118));
                    }
                    if (month40 == 8)
                    {
                        int num119 = month40 - 2;
                        month40 = month40 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num119, DateTime.DaysInMonth(dateTime.Year, num119));
                    }
                    else if (month40 == 9)
                    {
                        int num120 = month40 - 3;
                        month40 = month40 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num120, DateTime.DaysInMonth(dateTime.Year, num120));
                    }
                }
            }
            if (num == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime.Month;
                    if (month41 == 11)
                    {
                        int num121 = month41 - 1;
                        month41 = month41 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num121, DateTime.DaysInMonth(dateTime.Year, num121));
                    }
                    else if (month41 == 12)
                    {
                        int num122 = month41 - 2;
                        month41 = month41 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num122, DateTime.DaysInMonth(dateTime.Year, num122));
                    }
                    else if (month41 == 1)
                    {
                        int num123 = month41 + 9;
                        month41 = month41 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num123, DateTime.DaysInMonth(dateTime.Year, num123));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime.Month;
                    if (month42 == 2)
                    {
                        int num124 = month42 - 1;
                        month42 = month42 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num124, DateTime.DaysInMonth(dateTime.Year, num124));
                    }
                    else if (month42 == 3)
                    {
                        int num125 = month42 - 2;
                        month42 = month42 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num125, DateTime.DaysInMonth(dateTime.Year, num125));
                    }
                    else if (month42 == 4)
                    {
                        int num126 = month42 - 3;
                        month42 = month42 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num126, DateTime.DaysInMonth(dateTime.Year, num126));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime.Month;
                    if (month43 == 5)
                    {
                        int num127 = month43 - 1;
                        month43 = month43 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num127, DateTime.DaysInMonth(dateTime.Year, num127));
                    }
                    else if (month43 == 6)
                    {
                        int num128 = month43 - 2;
                        month43 = month43 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num128, DateTime.DaysInMonth(dateTime.Year, num128));
                    }
                    else if (month43 == 7)
                    {
                        int num129 = month43 - 3;
                        month43 = month43 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num129, DateTime.DaysInMonth(dateTime.Year, num129));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime.Month;
                    if (month44 == 8)
                    {
                        int num130 = month44 - 1;
                        month44 = month44 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num130, DateTime.DaysInMonth(dateTime.Year, num130));
                    }
                    if (month44 == 9)
                    {
                        int num131 = month44 - 2;
                        month44 = month44 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num131, DateTime.DaysInMonth(dateTime.Year, num131));
                    }
                    else if (month44 == 10)
                    {
                        int num132 = month44 - 3;
                        month44 = month44 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num132, DateTime.DaysInMonth(dateTime.Year, num132));
                    }
                }
            }
            if (num == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime.Month;
                    if (month45 == 12)
                    {
                        int num133 = month45 - 1;
                        month45 = month45 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num133, DateTime.DaysInMonth(dateTime.Year, num133));
                    }
                    else if (month45 == 1)
                    {
                        int num134 = month45 + 10;
                        month45 = month45 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num134, DateTime.DaysInMonth(dateTime.Year, num134));
                    }
                    else if (month45 == 2)
                    {
                        int num135 = month45 + 9;
                        month45 = month45 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num135, DateTime.DaysInMonth(dateTime.Year, num135));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime.Month;
                    if (month46 == 3)
                    {
                        int num136 = month46 - 1;
                        month46 = month46 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num136, DateTime.DaysInMonth(dateTime.Year, num136));
                    }
                    else if (month46 == 4)
                    {
                        int num137 = month46 - 2;
                        month46 = month46 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num137, DateTime.DaysInMonth(dateTime.Year, num137));
                    }
                    else if (month46 == 5)
                    {
                        int num138 = month46 - 3;
                        month46 = month46 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num138, DateTime.DaysInMonth(dateTime.Year, num138));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime.Month;
                    if (month47 == 6)
                    {
                        int num139 = month47 - 1;
                        month47 = month47 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num139, DateTime.DaysInMonth(dateTime.Year, num139));
                    }
                    else if (month47 == 7)
                    {
                        int num140 = month47 - 2;
                        month47 = month47 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num140, DateTime.DaysInMonth(dateTime.Year, num140));
                    }
                    else if (month47 == 8)
                    {
                        int num141 = month47 - 3;
                        month47 = month47 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num141, DateTime.DaysInMonth(dateTime.Year, num141));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime.Month;
                    if (month48 == 9)
                    {
                        int num142 = month48 - 1;
                        month48 = month48 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num142, DateTime.DaysInMonth(dateTime.Year, num142));
                    }
                    if (month48 == 10)
                    {
                        int num143 = month48 - 2;
                        month48 = month48 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num143, DateTime.DaysInMonth(dateTime.Year, num143));
                    }
                    else if (month48 == 11)
                    {
                        int num144 = month48 - 3;
                        month48 = month48 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num144, DateTime.DaysInMonth(dateTime.Year, num144));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }
        public string CurrentFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            string str = string.Concat(dateTime.ToString(), ",", dateTime1.ToString());
            return str;
        }
        public string LastFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);

            DateTime fiscalFrom = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime fiscalTo = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);

            // Last fiscal year = subtract 1 year from both
            DateTime lastFiscalFrom = fiscalFrom.AddYears(-1);
            DateTime lastFiscalTo = fiscalTo.AddYears(-1);

            return $"{lastFiscalFrom},{lastFiscalTo}";
        }

        public string CurrentMonth()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime[] dateTimeArray = new DateTime[] { new DateTime(dateTime.Year, dateTime.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTimeArray[1] = dateTime2.AddDays(-1);
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }
        public string CurrentQuater()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            DateTime dateTime1 = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime1.Month;
            int num = dateTime.Month;
            DateTime dateTime2 = new DateTime();
            dateTime2 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int month1 = dateTime2.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (month1 == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int num1 = dateTime1.Month;
                    if (num1 == 1)
                    {
                        int num2 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num2, DateTime.DaysInMonth(dateTime1.Year, num2));
                    }
                    else if (num1 == 2)
                    {
                        num1--;
                        int num3 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num3, DateTime.DaysInMonth(dateTime1.Year, num3));
                    }
                    else if (num1 == 3)
                    {
                        num1 = num1 - 2;
                        int num4 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num4, DateTime.DaysInMonth(dateTime1.Year, num4));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime1.Month;
                    if (month2 == 4)
                    {
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num5, DateTime.DaysInMonth(dateTime1.Year, num5));
                    }
                    else if (month2 == 5)
                    {
                        month2--;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num6, DateTime.DaysInMonth(dateTime1.Year, num6));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 2;
                        int num7 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num7, DateTime.DaysInMonth(dateTime1.Year, num7));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime1.Month;
                    if (month3 == 7)
                    {
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num8, DateTime.DaysInMonth(dateTime1.Year, num8));
                    }
                    else if (month3 == 8)
                    {
                        month3--;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num9, DateTime.DaysInMonth(dateTime1.Year, num9));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 2;
                        int num10 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num10, DateTime.DaysInMonth(dateTime1.Year, num10));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime1.Month;
                    if (month4 == 10)
                    {
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num11, DateTime.DaysInMonth(dateTime1.Year, num11));
                    }
                    if (month4 == 11)
                    {
                        month4--;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num12, DateTime.DaysInMonth(dateTime1.Year, num12));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 2;
                        int num13 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num13, DateTime.DaysInMonth(dateTime1.Year, num13));
                    }
                }
            }
            if (month1 == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime1.Month;
                    if (month5 == 2)
                    {
                        int num14 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num14, DateTime.DaysInMonth(dateTime1.Year, num14));
                    }
                    else if (month5 == 3)
                    {
                        month5--;
                        int num15 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num15, DateTime.DaysInMonth(dateTime1.Year, num15));
                    }
                    else if (month5 == 4)
                    {
                        month5 = month5 - 2;
                        int num16 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num16, DateTime.DaysInMonth(dateTime1.Year, num16));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime1.Month;
                    if (month6 == 5)
                    {
                        int num17 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num17, DateTime.DaysInMonth(dateTime1.Year, num17));
                    }
                    else if (month6 == 6)
                    {
                        month6--;
                        int num18 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num18, DateTime.DaysInMonth(dateTime1.Year, num18));
                    }
                    else if (month6 == 7)
                    {
                        month6 = month6 - 2;
                        int num19 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num19, DateTime.DaysInMonth(dateTime1.Year, num19));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime1.Month;
                    if (month7 == 8)
                    {
                        int num20 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num20, DateTime.DaysInMonth(dateTime1.Year, num20));
                    }
                    else if (month7 == 9)
                    {
                        month7--;
                        int num21 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num21, DateTime.DaysInMonth(dateTime1.Year, num21));
                    }
                    else if (month7 == 10)
                    {
                        month7 = month7 - 2;
                        int num22 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num22, DateTime.DaysInMonth(dateTime1.Year, num22));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime1.Month;
                    if (month8 == 11)
                    {
                        int num23 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num23, DateTime.DaysInMonth(dateTime1.Year, num23));
                    }
                    if (month8 == 12)
                    {
                        month8--;
                        int num24 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num24, DateTime.DaysInMonth(dateTime1.Year, num24));
                    }
                    else if (month8 == 1)
                    {
                        month8 = month8 + 10;
                        int num25 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num25, DateTime.DaysInMonth(dateTime1.Year, num25));
                    }
                }
            }
            if (month1 == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime1.Month;
                    if (month9 == 3)
                    {
                        int num26 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num26, DateTime.DaysInMonth(dateTime1.Year, num26));
                    }
                    else if (month9 == 4)
                    {
                        month9--;
                        int num27 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num27, DateTime.DaysInMonth(dateTime1.Year, num27));
                    }
                    else if (month9 == 5)
                    {
                        month9 = month9 - 2;
                        int num28 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num28, DateTime.DaysInMonth(dateTime1.Year, num28));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime1.Month;
                    if (month10 == 6)
                    {
                        int num29 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num29, DateTime.DaysInMonth(dateTime1.Year, num29));
                    }
                    else if (month10 == 7)
                    {
                        month10--;
                        int num30 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num30, DateTime.DaysInMonth(dateTime1.Year, num30));
                    }
                    else if (month10 == 8)
                    {
                        month10 = month10 - 2;
                        int num31 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num31, DateTime.DaysInMonth(dateTime1.Year, num31));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime1.Month;
                    if (month11 == 9)
                    {
                        int num32 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num32, DateTime.DaysInMonth(dateTime1.Year, num32));
                    }
                    else if (month11 == 10)
                    {
                        month11--;
                        int num33 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num33, DateTime.DaysInMonth(dateTime1.Year, num33));
                    }
                    else if (month11 == 11)
                    {
                        month11 = month11 - 2;
                        int num34 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num34, DateTime.DaysInMonth(dateTime1.Year, num34));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime1.Month;
                    if (month12 == 12)
                    {
                        int num35 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num35, DateTime.DaysInMonth(dateTime1.Year, num35));
                    }
                    if (month12 == 1)
                    {
                        month12 = month12 + 11;
                        int num36 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num36, DateTime.DaysInMonth(dateTime1.Year, num36));
                    }
                    else if (month12 == 2)
                    {
                        month12 = month12 + 10;
                        int num37 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num37, DateTime.DaysInMonth(dateTime1.Year, num37));
                    }
                }
            }
            if (month1 == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime1.Month;
                    if (month13 == 4)
                    {
                        int num38 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num38, DateTime.DaysInMonth(dateTime1.Year, num38));
                    }
                    else if (month13 == 5)
                    {
                        month13--;
                        int num39 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num39, DateTime.DaysInMonth(dateTime1.Year, num39));
                    }
                    else if (month13 == 6)
                    {
                        month13 = month13 - 2;
                        int num40 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num40, DateTime.DaysInMonth(dateTime1.Year, num40));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime1.Month;
                    if (month14 == 7)
                    {
                        int num41 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num41, DateTime.DaysInMonth(dateTime1.Year, num41));
                    }
                    else if (month14 == 8)
                    {
                        month14--;
                        int num42 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num42, DateTime.DaysInMonth(dateTime1.Year, num42));
                    }
                    else if (month14 == 9)
                    {
                        month14 = month14 - 2;
                        int num43 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num43, DateTime.DaysInMonth(dateTime1.Year, num43));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime1.Month;
                    if (month15 == 10)
                    {
                        int num44 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num44, DateTime.DaysInMonth(dateTime1.Year, num44));
                    }
                    else if (month15 == 11)
                    {
                        month15--;
                        int num45 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num45, DateTime.DaysInMonth(dateTime1.Year, num45));
                    }
                    else if (month15 == 12)
                    {
                        month15 = month15 - 2;
                        int num46 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num46, DateTime.DaysInMonth(dateTime1.Year, num46));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime1.Month;
                    if (month16 == 1)
                    {
                        int num47 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num47, DateTime.DaysInMonth(dateTime1.Year, num47));
                    }
                    if (month16 == 2)
                    {
                        month16--;
                        int num48 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num48, DateTime.DaysInMonth(dateTime1.Year, num48));
                    }
                    else if (month16 == 3)
                    {
                        month16 = month16 - 2;
                        int num49 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num49, DateTime.DaysInMonth(dateTime1.Year, num49));
                    }
                }
            }
            if (month1 == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime1.Month;
                    if (month17 == 5)
                    {
                        int num50 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num50, DateTime.DaysInMonth(dateTime1.Year, num50));
                    }
                    else if (month17 == 6)
                    {
                        month17--;
                        int num51 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num51, DateTime.DaysInMonth(dateTime1.Year, num51));
                    }
                    else if (month17 == 7)
                    {
                        month17 = month17 - 2;
                        int num52 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num52, DateTime.DaysInMonth(dateTime1.Year, num52));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime1.Month;
                    if (month18 == 8)
                    {
                        int num53 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num53, DateTime.DaysInMonth(dateTime1.Year, num53));
                    }
                    else if (month18 == 9)
                    {
                        month18--;
                        int num54 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num54, DateTime.DaysInMonth(dateTime1.Year, num54));
                    }
                    else if (month18 == 10)
                    {
                        month18 = month18 - 2;
                        int num55 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num55, DateTime.DaysInMonth(dateTime1.Year, num55));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime1.Month;
                    if (month19 == 11)
                    {
                        int num56 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num56, DateTime.DaysInMonth(dateTime1.Year, num56));
                    }
                    else if (month19 == 12)
                    {
                        month19--;
                        int num57 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num57, DateTime.DaysInMonth(dateTime1.Year, num57));
                    }
                    else if (month19 == 1)
                    {
                        month19 = month19 + 10;
                        int num58 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num58, DateTime.DaysInMonth(dateTime1.Year, num58));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime1.Month;
                    if (month20 == 2)
                    {
                        int num59 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num59, DateTime.DaysInMonth(dateTime1.Year, num59));
                    }
                    if (month20 == 3)
                    {
                        month20--;
                        int num60 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num60, DateTime.DaysInMonth(dateTime1.Year, num60));
                    }
                    else if (month20 == 4)
                    {
                        month20 = month20 - 2;
                        int num61 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num61, DateTime.DaysInMonth(dateTime1.Year, num61));
                    }
                }
            }
            if (month1 == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime1.Month;
                    if (month21 == 6)
                    {
                        int num62 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num62, DateTime.DaysInMonth(dateTime1.Year, num62));
                    }
                    else if (month21 == 7)
                    {
                        month21--;
                        int num63 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num63, DateTime.DaysInMonth(dateTime1.Year, num63));
                    }
                    else if (month21 == 8)
                    {
                        month21 = month21 - 2;
                        int num64 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num64, DateTime.DaysInMonth(dateTime1.Year, num64));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime1.Month;
                    if (month22 == 9)
                    {
                        int num65 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num65, DateTime.DaysInMonth(dateTime1.Year, num65));
                    }
                    else if (month22 == 10)
                    {
                        month22--;
                        int num66 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num66, DateTime.DaysInMonth(dateTime1.Year, num66));
                    }
                    else if (month22 == 11)
                    {
                        month22 = month22 - 2;
                        int num67 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num67, DateTime.DaysInMonth(dateTime1.Year, num67));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime1.Month;
                    if (month23 == 12)
                    {
                        int num68 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num68, DateTime.DaysInMonth(dateTime1.Year, num68));
                    }
                    else if (month23 == 1)
                    {
                        month23 = month23 + 11;
                        int num69 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num69, DateTime.DaysInMonth(dateTime1.Year, num69));
                    }
                    else if (month23 == 2)
                    {
                        month23 = month23 + 10;
                        int num70 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num70, DateTime.DaysInMonth(dateTime1.Year, num70));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime1.Month;
                    if (month24 == 3)
                    {
                        int num71 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num71, DateTime.DaysInMonth(dateTime1.Year, num71));
                    }
                    if (month24 == 4)
                    {
                        month24--;
                        int num72 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num72, DateTime.DaysInMonth(dateTime1.Year, num72));
                    }
                    else if (month24 == 5)
                    {
                        month24 = month24 - 2;
                        int num73 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num73, DateTime.DaysInMonth(dateTime1.Year, num73));
                    }
                }
            }
            if (month1 == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime1.Month;
                    if (month25 == 7)
                    {
                        int num74 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num74, DateTime.DaysInMonth(dateTime1.Year, num74));
                    }
                    else if (month25 == 8)
                    {
                        month25--;
                        int num75 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num75, DateTime.DaysInMonth(dateTime1.Year, num75));
                    }
                    else if (month25 == 9)
                    {
                        month25 = month25 - 2;
                        int num76 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num76, DateTime.DaysInMonth(dateTime1.Year, num76));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime1.Month;
                    if (month26 == 10)
                    {
                        int num77 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num77, DateTime.DaysInMonth(dateTime1.Year, num77));
                    }
                    else if (month26 == 11)
                    {
                        month26--;
                        int num78 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num78, DateTime.DaysInMonth(dateTime1.Year, num78));
                    }
                    else if (month26 == 12)
                    {
                        month26 = month26 - 2;
                        int num79 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num79, DateTime.DaysInMonth(dateTime1.Year, num79));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime1.Month;
                    if (month27 == 1)
                    {
                        int num80 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num80, DateTime.DaysInMonth(dateTime1.Year, num80));
                    }
                    else if (month27 == 2)
                    {
                        month27--;
                        int num81 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num81, DateTime.DaysInMonth(dateTime1.Year, num81));
                    }
                    else if (month27 == 3)
                    {
                        month27 = month27 - 2;
                        int num82 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num82, DateTime.DaysInMonth(dateTime1.Year, num82));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime1.Month;
                    if (month28 == 4)
                    {
                        int num83 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num83, DateTime.DaysInMonth(dateTime1.Year, num83));
                    }
                    if (month28 == 5)
                    {
                        month28--;
                        int num84 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num84, DateTime.DaysInMonth(dateTime1.Year, num84));
                    }
                    else if (month28 == 6)
                    {
                        month28 = month28 - 2;
                        int num85 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num85, DateTime.DaysInMonth(dateTime1.Year, num85));
                    }
                }
            }
            if (month1 == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime1.Month;
                    if (month29 == 8)
                    {
                        int num86 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num86, DateTime.DaysInMonth(dateTime1.Year, num86));
                    }
                    else if (month29 == 9)
                    {
                        month29--;
                        int num87 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num87, DateTime.DaysInMonth(dateTime1.Year, num87));
                    }
                    else if (month29 == 10)
                    {
                        month29 = month29 - 2;
                        int num88 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num88, DateTime.DaysInMonth(dateTime1.Year, num88));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime1.Month;
                    if (month30 == 11)
                    {
                        int num89 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num89, DateTime.DaysInMonth(dateTime1.Year, num89));
                    }
                    else if (month30 == 12)
                    {
                        month30--;
                        int num90 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num90, DateTime.DaysInMonth(dateTime1.Year, num90));
                    }
                    else if (month30 == 1)
                    {
                        month30 = month30 + 10;
                        int num91 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num91, DateTime.DaysInMonth(dateTime1.Year, num91));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime1.Month;
                    if (month31 == 2)
                    {
                        int num92 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num92, DateTime.DaysInMonth(dateTime1.Year, num92));
                    }
                    else if (month31 == 3)
                    {
                        month31--;
                        int num93 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num93, DateTime.DaysInMonth(dateTime1.Year, num93));
                    }
                    else if (month31 == 4)
                    {
                        month31 = month31 - 2;
                        int num94 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num94, DateTime.DaysInMonth(dateTime1.Year, num94));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime1.Month;
                    if (month32 == 5)
                    {
                        int num95 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num95, DateTime.DaysInMonth(dateTime1.Year, num95));
                    }
                    if (month32 == 6)
                    {
                        month32--;
                        int num96 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num96, DateTime.DaysInMonth(dateTime1.Year, num96));
                    }
                    else if (month32 == 7)
                    {
                        month32 = month32 - 2;
                        int num97 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num97, DateTime.DaysInMonth(dateTime1.Year, num97));
                    }
                }
            }
            if (month1 == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime1.Month;
                    if (month33 == 9)
                    {
                        int num98 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num98, DateTime.DaysInMonth(dateTime1.Year, num98));
                    }
                    else if (month33 == 10)
                    {
                        month33--;
                        int num99 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num99, DateTime.DaysInMonth(dateTime1.Year, num99));
                    }
                    else if (month33 == 11)
                    {
                        month33 = month33 - 2;
                        int num100 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num100, DateTime.DaysInMonth(dateTime1.Year, num100));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime1.Month;
                    if (month34 == 12)
                    {
                        int num101 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num101, DateTime.DaysInMonth(dateTime1.Year, num101));
                    }
                    else if (month34 == 1)
                    {
                        month34 = month34 + 11;
                        int num102 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num102, DateTime.DaysInMonth(dateTime1.Year, num102));
                    }
                    else if (month34 == 2)
                    {
                        month34 = month34 + 10;
                        int num103 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num103, DateTime.DaysInMonth(dateTime1.Year, num103));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime1.Month;
                    if (month35 == 3)
                    {
                        int num104 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num104, DateTime.DaysInMonth(dateTime1.Year, num104));
                    }
                    else if (month35 == 4)
                    {
                        month35--;
                        int num105 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num105, DateTime.DaysInMonth(dateTime1.Year, num105));
                    }
                    else if (month35 == 5)
                    {
                        month35 = month35 - 2;
                        int num106 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num106, DateTime.DaysInMonth(dateTime1.Year, num106));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime1.Month;
                    if (month36 == 6)
                    {
                        int num107 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num107, DateTime.DaysInMonth(dateTime1.Year, num107));
                    }
                    if (month36 == 7)
                    {
                        month36--;
                        int num108 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num108, DateTime.DaysInMonth(dateTime1.Year, num108));
                    }
                    else if (month36 == 8)
                    {
                        month36 = month36 - 2;
                        int num109 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num109, DateTime.DaysInMonth(dateTime1.Year, num109));
                    }
                }
            }
            if (month1 == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime1.Month;
                    if (month37 == 10)
                    {
                        int num110 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num110, DateTime.DaysInMonth(dateTime1.Year, num110));
                    }
                    else if (month37 == 11)
                    {
                        month37--;
                        int num111 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num111, DateTime.DaysInMonth(dateTime1.Year, num111));
                    }
                    else if (month37 == 12)
                    {
                        month37 = month37 - 2;
                        int num112 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num112, DateTime.DaysInMonth(dateTime1.Year, num112));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime1.Month;
                    if (month38 == 1)
                    {
                        int num113 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num113, DateTime.DaysInMonth(dateTime1.Year, num113));
                    }
                    else if (month38 == 2)
                    {
                        month38--;
                        int num114 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num114, DateTime.DaysInMonth(dateTime1.Year, num114));
                    }
                    else if (month38 == 3)
                    {
                        month38 = month38 - 2;
                        int num115 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num115, DateTime.DaysInMonth(dateTime1.Year, num115));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime1.Month;
                    if (month39 == 4)
                    {
                        int num116 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num116, DateTime.DaysInMonth(dateTime1.Year, num116));
                    }
                    else if (month39 == 5)
                    {
                        month39--;
                        int num117 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num117, DateTime.DaysInMonth(dateTime1.Year, num117));
                    }
                    else if (month39 == 6)
                    {
                        month39 = month39 - 2;
                        int num118 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num118, DateTime.DaysInMonth(dateTime1.Year, num118));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime1.Month;
                    if (month40 == 7)
                    {
                        int num119 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num119, DateTime.DaysInMonth(dateTime1.Year, num119));
                    }
                    if (month40 == 8)
                    {
                        month40--;
                        int num120 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num120, DateTime.DaysInMonth(dateTime1.Year, num120));
                    }
                    else if (month40 == 9)
                    {
                        month40 = month40 - 2;
                        int num121 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num121, DateTime.DaysInMonth(dateTime1.Year, num121));
                    }
                }
            }
            if (month1 == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime1.Month;
                    if (month41 == 11)
                    {
                        int num122 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num122, DateTime.DaysInMonth(dateTime1.Year, num122));
                    }
                    else if (month41 == 12)
                    {
                        month41--;
                        int num123 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num123, DateTime.DaysInMonth(dateTime1.Year, num123));
                    }
                    else if (month41 == 1)
                    {
                        month41 = month41 + 10;
                        int num124 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num124, DateTime.DaysInMonth(dateTime1.Year, num124));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime1.Month;
                    if (month42 == 2)
                    {
                        int num125 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num125, DateTime.DaysInMonth(dateTime1.Year, num125));
                    }
                    else if (month42 == 3)
                    {
                        month42--;
                        int num126 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num126, DateTime.DaysInMonth(dateTime1.Year, num126));
                    }
                    else if (month42 == 4)
                    {
                        month42 = month42 - 2;
                        int num127 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num127, DateTime.DaysInMonth(dateTime1.Year, num127));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime1.Month;
                    if (month43 == 5)
                    {
                        int num128 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num128, DateTime.DaysInMonth(dateTime1.Year, num128));
                    }
                    else if (month43 == 6)
                    {
                        month43--;
                        int num129 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num129, DateTime.DaysInMonth(dateTime1.Year, num129));
                    }
                    else if (month43 == 7)
                    {
                        month43 = month43 - 2;
                        int num130 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num130, DateTime.DaysInMonth(dateTime1.Year, num130));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime1.Month;
                    if (month44 == 8)
                    {
                        int num131 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num131, DateTime.DaysInMonth(dateTime1.Year, num131));
                    }
                    if (month44 == 9)
                    {
                        month44--;
                        int num132 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num132, DateTime.DaysInMonth(dateTime1.Year, num132));
                    }
                    else if (month44 == 10)
                    {
                        month44 = month44 - 2;
                        int num133 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num133, DateTime.DaysInMonth(dateTime1.Year, num133));
                    }
                }
            }
            if (month1 == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime1.Month;
                    if (month45 == 12)
                    {
                        int num134 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num134, DateTime.DaysInMonth(dateTime1.Year, num134));
                    }
                    else if (month45 == 1)
                    {
                        month45 = month45 + 11;
                        int num135 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num135, DateTime.DaysInMonth(dateTime1.Year, num135));
                    }
                    else if (month45 == 2)
                    {
                        month45 = month45 + 10;
                        int num136 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num136, DateTime.DaysInMonth(dateTime1.Year, num136));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime1.Month;
                    if (month46 == 3)
                    {
                        int num137 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num137, DateTime.DaysInMonth(dateTime1.Year, num137));
                    }
                    else if (month46 == 4)
                    {
                        month46--;
                        int num138 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num138, DateTime.DaysInMonth(dateTime1.Year, num138));
                    }
                    else if (month46 == 5)
                    {
                        month46 = month46 - 2;
                        int num139 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num139, DateTime.DaysInMonth(dateTime1.Year, num139));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime1.Month;
                    if (month47 == 6)
                    {
                        int num140 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num140, DateTime.DaysInMonth(dateTime1.Year, num140));
                    }
                    else if (month47 == 7)
                    {
                        month47--;
                        int num141 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num141, DateTime.DaysInMonth(dateTime1.Year, num141));
                    }
                    else if (month47 == 8)
                    {
                        month47 = month47 - 2;
                        int num142 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num142, DateTime.DaysInMonth(dateTime1.Year, num142));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime1.Month;
                    if (month48 == 9)
                    {
                        int num143 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num143, DateTime.DaysInMonth(dateTime1.Year, num143));
                    }
                    if (month48 == 10)
                    {
                        month48--;
                        int num144 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num144, DateTime.DaysInMonth(dateTime1.Year, num144));
                    }
                    else if (month48 == 11)
                    {
                        month48 = month48 - 2;
                        int num145 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num145, DateTime.DaysInMonth(dateTime1.Year, num145));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string ReplaceSingleQuote(string OriginalString)
        {
            return OriginalString.Replace("'", "`");
        }
        #endregion 
    }
}