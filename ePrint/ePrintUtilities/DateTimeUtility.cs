using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ePrint.ePrintUtilities
{
    public class DateTimeUtility
    {
        public static string ConvertDateToRequiredFormat(string dateFormat, string inputDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputDate))
                    return "1/1/1900";

                dateFormat = dateFormat.Trim().Replace("-", "/").ToLower();
                string formatToUse = "MM/dd/yyyy"; // default
                CultureInfo culture = CultureInfo.InvariantCulture;

                switch (dateFormat)
                {
                    case "dd/mm/yyyy":
                        formatToUse = "dd/MM/yyyy";
                        //culture = new CultureInfo("en-GB"); // matches dd/MM/yyyy
                        break;
                    case "mm/dd/yyyy":
                        formatToUse = "MM/dd/yyyy";
                        //culture = new CultureInfo("en-US"); // matches mm/dd/yyyy
                        break;
                }

                if (DateTime.TryParseExact(inputDate, formatToUse, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    return parsedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                // Fallback generic parse
                if (DateTime.TryParse(inputDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                    return parsedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return "1/1/1900";
            }

            return "1/1/1900";
        }



    }
}