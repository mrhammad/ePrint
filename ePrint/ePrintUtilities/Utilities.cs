using Microsoft.Ajax.Utilities;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Telerik.Web.UI;

namespace ePrint.ePrintUtilities
{
    public static class Utilities
    {
        public static List<KeyValues> GetReportDurtionsList(string condition = "")
        {
            List<KeyValues> keyValues = new List<KeyValues>();
            if (string.IsNullOrEmpty(condition))
            {
                keyValues.Add(new KeyValues { text = "Select Date", value = "daterange" });

                keyValues.Add(new KeyValues { text = "Yesterday", value = "yesterday" });
                keyValues.Add(new KeyValues { text = "Today", value = "daily" });
                keyValues.Add(new KeyValues { text = "Last Week", value = "lastweek" });
                keyValues.Add(new KeyValues { text = "This Week", value = "thisweek" });// Implementation required
                keyValues.Add(new KeyValues { text = "Last Month", value = "lastmonth", isSelected = true });
                keyValues.Add(new KeyValues { text = "This Month", value = "thismonth" });
                keyValues.Add(new KeyValues { text = "Last Year", value = "lastyear" });
                keyValues.Add(new KeyValues { text = "This Year", value = ePrintConstants.ThisAnnualYear });
                //Fiscal Year
                keyValues.Add(new KeyValues { text = "Last Financial Year", value = "lastfiscalyear" });
                keyValues.Add(new KeyValues { text = "This Financial Year", value = "thisfiscalyear" });

                keyValues.Add(new KeyValues { text = "All Dates", value = "tilldate" });

                //keyValues.Add(new KeyValues { text = "Current Quarter", value = "thisquarter" });
                //keyValues.Add(new KeyValues { text = "Last Quarter", value = "lastquater" });
                //keyValues.Add(new KeyValues { text = "Half Fiscal year", value = "halfyear" });

            }

            return keyValues;

        }
        public static string ApplyCharacterLimit(string inputString, string configKey = "charDisplayLimitKey", int charLimit = 50)
        {
            if (!string.IsNullOrEmpty(configKey))
            {
                string charLimitString = string.Empty;
                try
                {
                    charLimitString = Convert.ToString(ConfigurationManager.AppSettings[configKey]);
                }
                catch (Exception e)
                {
                }
                charLimit = !string.IsNullOrEmpty(charLimitString) ? Convert.ToInt32(charLimitString) : charLimit;
            }

            if (inputString.Length > charLimit && !inputString.EndsWith("..."))
            {
                inputString = inputString.Substring(0, charLimit) + "...";
            }

            return inputString;
        }

        public static string EncodeForHtml(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Equals("..."))
            {
                return input;
            }

            input = input.Replace("'", "\\'")  // Escape single quotes
                .Replace("\r\n", "\\n")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");

            // Use WebUtility.HtmlEncode to escape HTML special characters
            return WebUtility.HtmlEncode(input);
        }

        public static void SetGridViewItemProperties(GridDataItem item, string cellKey, string itemIdKey)
        {
            string escapedCommentText = EncodeForHtml(item[cellKey].Text);
            item[cellKey].Attributes.Add("align", "left");
            item[cellKey].Attributes.Add("class", "hyperlinkNoUnderline");
            item[cellKey].Attributes.Add("onclick", string.Concat("javascript:openCommentPopup(", item[itemIdKey].Text + ",'" + escapedCommentText + "' );"));
            item[cellKey].Style.Add("cursor", "pointer");
            item[cellKey].Attributes["title"] = item[cellKey].Text;
            item[cellKey].Text = EncodeForHtml(ApplyCharacterLimit(item[cellKey].Text.ToString()));

        }
        public static string ConvertUrlToHyperlink(string url, string caption)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            caption = string.IsNullOrEmpty(caption) ? "Tracking Link" : caption;

            // Ensure the URL starts with http:// or https://
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;

            return $"<a href=\"{System.Net.WebUtility.HtmlEncode(url)}\" target=\"_blank\">{System.Net.WebUtility.HtmlEncode(caption)}</a>";
        }

        public static string GetFirstDateOfTheCuurentYear(string dateTimeFormat = "")
        {
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            if (!string.IsNullOrEmpty(dateTimeFormat))
            {
                return dt.Date.ToString(dateTimeFormat.Replace("mm", "MM"));
            }

            return dt.ToString(dateTimeFormat.Replace("mm", "MM"));

        }
        public static string GetCurrentDateString(string dateTimeFormat = "")
        {
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(dateTimeFormat))
            {
                return dt.Date.ToString(dateTimeFormat.Replace("mm", "MM"));
            }
            return dt.ToString(dateTimeFormat.Replace("mm", "MM"));
        }

        public static string ReplaceConsigneeUrlTags(DataRow item, string content)
        {
            if (!string.IsNullOrEmpty(item["ConsigneeUrl"].ToString()))
            {
                content = content.Replace("[$ConsigneeURL$]",
                    Utilities.ConvertUrlToHyperlink(
                        item["ConsigneeUrl"].ToString(), item["ConsignmentNumber"].ToString())
                    );
            }

            if (!string.IsNullOrEmpty(item["ConsigneeUrl"].ToString()))
            {
                content = content.Replace("[$ConsigneeURLWithConsignmentNoteNumber$]",
                    Utilities.ConvertUrlToHyperlink(
                        string.Concat(item["ConsigneeUrl"].ToString(), '/', item["ConsignmentNumber"].ToString()),
                        item["ConsignmentNumber"].ToString())
                    );
            }

            return content;
        }


    }
}