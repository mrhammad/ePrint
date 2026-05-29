using nmsCommon;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsView
{
    public class viewClass : BaseView
    {
        public static string SortDirection;

        public static string SortFieldd;

        public static int SortCount;

        public string sortBydatabase = string.Empty;

        private ArrayList arrInUserField = new ArrayList();

        private string CompanyType = string.Empty;

        private string[] DisplayColumns;

        public string DateFormat = string.Empty;

        public string viewname = string.Empty;

        private BasePage objpage = new BasePage();

        private SettingsBasePage objset = new SettingsBasePage();

        private string ColumnName = string.Empty;

        private bool flag1;

        private bool dateflag;

        static viewClass()
        {
            viewClass.SortDirection = string.Empty;
            viewClass.SortFieldd = string.Empty;
            viewClass.SortCount = 0;
        }

        public viewClass()
        {
        }

        private string[] ParseDefaultViewColumns(string rawColumns, string sectionName)
        {
            if (string.IsNullOrWhiteSpace(rawColumns))
            {
                if (string.Equals(sectionName, "estimate", StringComparison.OrdinalIgnoreCase))
                {
                    return new[] { "EstimateNumber", "EstimateTitle", "CustomerID", "EstimateDate", "EstimateStatus", "EstimateType" };
                }

                return new string[0];
            }

            string trimmed = rawColumns.Trim();
            if (trimmed.EndsWith(","))
            {
                trimmed = trimmed.Substring(0, trimmed.Length - 1);
            }

            if (trimmed.Length == 0)
            {
                return new string[0];
            }

            return trimmed.Split(new char[] { ',' });
        }

        public void AssignRecords(string sectionName, int sectionID, int Id, int userorgroup, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_assign", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", sectionName);
            sqlCommand.Parameters.AddWithValue("@sectionid", sectionID);
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlCommand.Parameters.AddWithValue("@userorgroup", userorgroup);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void ChangeOwnership(int companyid, int transferUserID, int RecordID, string page)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_change_ownership", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@transferUserID", transferUserID);
            sqlCommand.Parameters.AddWithValue("@RecordID", RecordID);
            sqlCommand.Parameters.AddWithValue("@page", page);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public bool Datevalidate(string datevalue)
        {
            if (datevalue == "")
            {
                this.dateflag = false;
            }
            else
            {
                string[] strArrays = new string[] { "/" };
                string[] strArrays1 = datevalue.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    if (this.validatenum(strArrays1[i].ToString()))
                    {
                        this.dateflag = true;
                    }
                }
            }
            if (!this.dateflag)
            {
                return false;
            }
            return true;
        }

        private string EstimateSearchCondition(string[] ConditionalOperator, string[] conditions, string[] operators, string[] values, bool isSearchCondition)
        {
            int i;
            string str = this.Session["Dateformat"].ToString();
            commonClass _commonClass = new commonClass();
            bool flag = false;
            StringBuilder stringBuilder = new StringBuilder();
            if (isSearchCondition)
            {
                bool flag1 = false;
                int num = 0;
                for (i = 0; i < (int)conditions.Length; i++)
                {
                    if (conditions[i].Trim().ToLower() != "none" && operators[i].Trim().ToLower() != "none" && values[i].Trim().ToLower() != "")
                    {
                        num = i;
                        if (!flag1)
                        {
                            stringBuilder.Append(" and ");
                        }
                        flag1 = true;
                        if (ConditionalOperator[i].ToString().Trim().ToLower() == "or" && !flag)
                        {
                            stringBuilder.Append(" ( ");
                            flag = true;
                        }
                        string lower = operators[i].Trim().ToLower();
                        string str1 = lower;
                        if (lower != null)
                        {
                            switch (str1)
                            {
                                case "startswith":
                                    {
                                        string[] strArrays = new string[] { "  ", conditions[i].ToString(), " like '", values[i].ToString(), "%'     ", ConditionalOperator[i].ToString(), " " };
                                        stringBuilder.Append(string.Concat(strArrays));
                                        break;
                                    }
                                case "contains":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays1 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) = '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays1));
                                            break;
                                        }
                                        else
                                        {
                                            string[] str2 = new string[] { "  ", conditions[i].ToString(), " like '%", values[i].ToString(), "%'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str2));
                                            break;
                                        }
                                    }
                                case "endswith":
                                    {
                                        string[] strArrays2 = new string[] { "  ", conditions[i].ToString(), " like '%", values[i].ToString(), "'     ", ConditionalOperator[i].ToString(), " " };
                                        stringBuilder.Append(string.Concat(strArrays2));
                                        break;
                                    }
                                case ">":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str3 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) > '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str3));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() == "estimatevalue" || conditions[i].Trim().ToLower() == "estimatevalue_excgst")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays3 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays3));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() != "availablequantity")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str4 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str4));
                                            break;
                                        }
                                        else
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays4 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), values[i].ToString(), "     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays4));
                                            break;
                                        }
                                    }
                                case "<":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            bool flag2 = this.Datevalidate(values[i].ToString());
                                            string empty = string.Empty;
                                            if (!flag2)
                                            {
                                                break;
                                            }
                                            this.getDateFormat(values[i].ToString());
                                            string[] str5 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) < '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str5));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() == "estimatevalue" || conditions[i].Trim().ToLower() == "estimatevalue_excgst")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays5 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays5));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() != "availablequantity")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str6 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str6));
                                            break;
                                        }
                                        else
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays6 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), values[i].ToString(), "     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays6));
                                            break;
                                        }
                                    }
                                case "<=":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str7 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) <= '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str7));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() == "estimatevalue" || conditions[i].Trim().ToLower() == "estimatevalue_excgst")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays7 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays7));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() != "availablequantity")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str8 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str8));
                                            break;
                                        }
                                        else
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays8 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), values[i].ToString(), "     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays8));
                                            break;
                                        }
                                    }
                                case ">=":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str9 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) >= '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str9));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() == "estimatevalue" || conditions[i].Trim().ToLower() == "estimatevalue_excgst")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays9 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays9));
                                            break;
                                        }
                                        else if (conditions[i].Trim().ToLower() != "availablequantity")
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] str10 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "cast('", values[i].ToString(), "'as decimal(18,2))     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str10));
                                            break;
                                        }
                                        else
                                        {
                                            if (!this.validatenum(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays10 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), values[i].ToString(), "     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays10));
                                            break;
                                        }
                                    }
                                case "=":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays1 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) = '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays1));
                                            break;
                                        }
                                        else
                                        {
                                            string[] str2 = new string[] { "  ", conditions[i].ToString(), " = '", values[i].ToString(), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str2));
                                            break;
                                        }
                                    }
                                case "!=":
                                    {
                                        if (conditions[i].Trim().ToLower() == "estimatedate" || conditions[i].Trim().ToLower() == "createddate" || conditions[i].Trim().ToLower() == "converteddate" || conditions[i].Trim().ToLower() == "completiondate" || conditions[i].Trim().ToLower() == "deliverydate" || conditions[i].Trim().ToLower() == "podate" || conditions[i].Trim().ToLower() == "ordereddate" || conditions[i].Trim().ToLower() == "createdate" || conditions[i].Trim().ToLower() == "lastviewdate" || conditions[i].Trim().ToLower() == "modifieddate" || conditions[i].Trim().ToLower() == "startdate" || conditions[i].Trim().ToLower() == "invoiceduedate" || conditions[i].Trim().ToLower() == "proofdate" || conditions[i].Trim().ToLower() == "artworkdate" || conditions[i].Trim().ToLower() == "approvaldate" || conditions[i].Trim().ToLower() == "productiondate" || conditions[i].Trim().ToLower() == "jobdate" || conditions[i].Trim().ToLower() == "enddate")
                                        {
                                            if (!this.Datevalidate(values[i].ToString()))
                                            {
                                                break;
                                            }
                                            string[] strArrays1 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) = '", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(strArrays1));
                                            break;
                                        }
                                        else
                                        {
                                            string[] str2 = new string[] { "  ", conditions[i].ToString(), " != '", values[i].ToString(), "'     ", ConditionalOperator[i].ToString(), " " };
                                            stringBuilder.Append(string.Concat(str2));
                                            break;
                                        }
                                    }
                                default:
                                    {
                                        goto Label44;
                                    }
                            }
                        }
                        else
                        {
                            goto Label55;
                        }
                        Label55:
                        string s = "";
                        Label1:
                        if ((ConditionalOperator[i].ToString().Trim().ToLower() == "and" || ConditionalOperator[i].ToString().Trim().ToLower() == "") && flag)
                        {
                            if (ConditionalOperator[i].ToString().Trim().ToLower() == "and")
                            {
                                string str11 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 4);
                                stringBuilder = new StringBuilder();
                                stringBuilder.Append(str11);
                            }
                            stringBuilder.Append(" ) and ");
                            flag = false;
                        }
                    }
                }
                if (flag)
                {
                    if (ConditionalOperator[num].ToString().Trim().ToLower() == "and" || ConditionalOperator[num].ToString().Trim().ToLower() == "")
                    {
                        string str12 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 4);
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(str12);
                    }
                    else
                    {
                        string str13 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 3);
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(str13);
                    }
                    stringBuilder.Append(" )  ");
                    flag = false;
                }
                else if (stringBuilder.ToString().Trim().Length > 0)
                {
                    if (ConditionalOperator[num].ToString().Trim().ToLower() == "and" || ConditionalOperator[num].ToString().Trim().ToLower() == "")
                    {
                        string str14 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 4);
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(str14);
                    }
                    else
                    {
                        string str15 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 3);
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(str15);
                    }
                }
            }
            return stringBuilder.ToString();
            if (conditions[i].Trim().ToLower() != "estimatedate" && conditions[i].Trim().ToLower() != "createddate" && conditions[i].Trim().ToLower() != "converteddate" && conditions[i].Trim().ToLower() != "completiondate" && conditions[i].Trim().ToLower() != "deliverydate" && conditions[i].Trim().ToLower() != "podate" && conditions[i].Trim().ToLower() != "ordereddate" && conditions[i].Trim().ToLower() != "createdate" && conditions[i].Trim().ToLower() != "lastviewdate" && conditions[i].Trim().ToLower() != "modifieddate" && conditions[i].Trim().ToLower() != "startdate" && conditions[i].Trim().ToLower() != "invoiceduedate" && conditions[i].Trim().ToLower() != "proofdate" && conditions[i].Trim().ToLower() != "artworkdate" && conditions[i].Trim().ToLower() != "approvaldate" && conditions[i].Trim().ToLower() != "productiondate" && conditions[i].Trim().ToLower() != "jobdate" && conditions[i].Trim().ToLower() != "enddate")
            {
                string[] strArrays11 = new string[] { "  ", conditions[i].ToString(), operators[i].Trim().ToLower(), "'", values[i].ToString(), "'     ", ConditionalOperator[i].ToString(), " " };
                stringBuilder.Append(string.Concat(strArrays11));
                goto Label44;
            }
            else if (this.Datevalidate(values[i].ToString()))
            {
                string[] strArrays12 = new string[] { "  DateAdd(d,0,DateDiff(d,0,", conditions[i].ToString(), ")) ", operators[i].Trim().ToLower(), "'", _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, values[i].ToString()), "'     ", ConditionalOperator[i].ToString(), " " };
                stringBuilder.Append(string.Concat(strArrays12));
                goto Label44;

            }
            else
            {
                goto Label44;
            }
            Label44:
            string ss = "";

            return string.Empty;

        }

        public string getDateFormat(string datevalue)
        {
            return datevalue;
        }

        public void initialize_noOfRecordsPerPage(DropDownList ddl)
        {
            ddl.Items.Add("5");
            ddl.Items.Add("10");
            ddl.Items.Add("15");
            ddl.Items.Add("20");
            ddl.Items.Add("25");
            ddl.Items.Add("30");
            ddl.Items.Add("40");
            ddl.Items.Add("50");
            ddl.Items.Add("75");
            ddl.Items.Add("100");
            ddl.SelectedIndex = 3;
        }

        public string[] RemoveDuplicates(string[] myList)
        {
            ArrayList arrayLists = new ArrayList();
            string[] strArrays = myList;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (!arrayLists.Contains(str))
                {
                    arrayLists.Add(str);
                }
            }
            return (string[])arrayLists.ToArray(typeof(string));
        }

        public string Return_ShowRecords_BaseOn_RolesAndPrivileges()
        {
            string empty = string.Empty;
            BaseClass baseClass = new BaseClass();
            string str = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (str.ToLower() == "allocation")
            {
                if (this.Session["userID"] != null && this.Session["userID"] != null && viewname == "purchase")
                {
                    empty = string.Concat("L.RaisedByID='", this.Session["userID"].ToString(), "' and ");
                }
                else if (this.Session["userID"] != null && this.Session["userID"] != null)
                {
                    empty = string.Concat("L.SalesPersonID='", this.Session["userID"].ToString(), "' and ");
                }
            }
            else if (str.ToLower() != "type")
            {
                empty = "";
            }
            else
            {
                string str1 = baseClass.ReturnRoles_Privileges_Others("companytype");
                if (str1 == null || !(str1 != ""))
                {
                    empty = "";
                }
                else
                {
                    str1 = str1.Substring(0, str1.Length - 1);
                    empty = string.Concat("L.TypeID in (", str1, ") and ");
                }
            }
            return empty;
        }

        public string Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized()
        {
            string empty = string.Empty;
            BaseClass baseClass = new BaseClass();
            string str = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (str.ToLower() == "allocation")
            {

                if (this.Session["userID"] != null && this.Session["userID"] != null && viewname == "purchase")
                {
                    empty = string.Concat("L.RaisedByID='", this.Session["userID"].ToString(), "' and ");
                }
                else if (this.Session["userID"] != null && this.Session["userID"] != null)
                {
                    empty = string.Concat("L.SalesPersonID='", this.Session["userID"].ToString(), "' and ");
                }

            }
            else if (str.ToLower() != "type")
            {
                empty = "";
            }
            else
            {
                string str1 = baseClass.ReturnRoles_Privileges_Others("companytype");
                if (str1 == null || !(str1 != ""))
                {
                    empty = "";
                }
                else
                {
                    str1 = str1.Substring(0, str1.Length - 1);
                    empty = string.Concat("L.TypeID like '%", str1, "%' and ");
                }
            }
            return empty;
        }
        //filter report record
        public string showRecords_BaseOn_RolesAndPrivileges(string page)
        {
            string empty = string.Empty;
            BaseClass baseClass = new BaseClass();
            string str = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (str.ToLower() == "allocation")
            {
                if (this.Session["userID"] != null && this.Session["userID"] != null)
                {
                    switch (page)
                    {
                        case "estimate":
                        case  "client":
                         empty = string.Concat("a.SalesPerson=", this.Session["userID"].ToString(), " and ");
                        break;
                        case "webstoreorder":
                        case "job":
                        case "invoice":
                         empty = string.Concat("b.SalesPerson=", this.Session["userID"].ToString(), " and ");
                        break;
                        default:
                         empty = string.Concat("a.SalesPerson=", this.Session["userID"].ToString(), " and ");
                        break;

                    }
                    
                }
            }
            else if (str.ToLower() != "type")
            {
                empty = "";
            }
            else
            {
                string str1 = baseClass.ReturnRoles_Privileges_Others("companytype");
                if (str1 == null || !(str1 != ""))
                {
                    empty = "";
                }
                else
                {
                    str1 = str1.Substring(0, str1.Length - 1);
                    //empty =  string.Concat("TypeID like '%", str1, "%' and ");
                }
            }
            return empty;
        }
        public string returnFinalQuery(int companyId, int userId, string sortField, string letter1, int intStartIndex, int PageSize, string pg, int viewValueId, int adminrights, ref string IsMsg)
        {
            string[] strArrays;
            string[] screenName;
            object[] item;
            char[] chrArray;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string lower = pg.Trim().ToLower();
            string str6 = lower;
            if (lower != null)
            {
                switch (str6)
                {
                    case "lead":
                        {
                            empty = "tb_lead";
                            str = "leadid";
                            empty1 = "tb_leadcustomizevalue";
                            str1 = "leadcustomizeid";
                            empty2 = "tb_leadviewvalue";
                            str2 = "leadviewvalueid";
                            empty3 = "lastName";
                            screenName = new string[] { " companyname as '", global.GetScreenName(companyId, "Company name", pg.Trim()), "', Isnull(firstnameÇ'') as '", global.GetScreenName(companyId, "First Name", pg.Trim()), "',Isnull(lastnameÇ'') as '", global.GetScreenName(companyId, "Last Name", pg.Trim()), "', phone as '", global.GetScreenName(companyId, "Phone", pg.Trim()), "', IsNull(annualrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Annual Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "'" };
                            str3 = string.Concat(screenName);
                            empty4 = " companyname nvarchar(max), firstname nvarchar(max), lastname nvarchar(max), phone nvarchar(max), annualrevenue money, btassigned bit ";
                            str4 = " companyname, firstname, lastname, phone, annualrevenue, btassigned ";
                            break;
                        }
                    case "client":
                        {
                            empty = "tb_client";
                            str = "clientid";
                            empty1 = "tb_clientcustomizevalue";
                            str1 = "clientcustomizeid";
                            empty2 = "tb_clientviewvalue";
                            str2 = "clientviewvalueid";
                            empty3 = "clientName";
                            screenName = new string[] { " clientname as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', clientsite as  '", global.GetScreenName(companyId, "Client Site", pg.Trim()), "', phone as '", global.GetScreenName(companyId, "Phone", pg.Trim()), "',IsNull(annualrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Annual Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as  '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " clientname nvarchar(max), clientsite nvarchar(max),phone nvarchar(max),annualrevenue money, btassigned bit ";
                            str4 = " clientname, clientsite, phone, annualrevenue, btassigned ";
                            break;
                        }
                    case "contact":
                        {
                            empty = "tb_contact";
                            str = "contactid";
                            empty1 = "tb_contactcustomizevalue";
                            str1 = "contactcustomizeid";
                            empty2 = "tb_contactviewvalue";
                            str2 = "contactviewvalueid";
                            empty3 = "lastname";
                            screenName = new string[] { "  clientID,Isnull(firstnameÇ'') as '", global.GetScreenName(companyId, "First Name", pg.Trim()), "',Isnull(lastnameÇ'') as '", global.GetScreenName(companyId, "Last Name", pg.Trim()), "',", base.fieldElement_US("clientid", companyId, userId, "clientid", "text", ""), " as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', phone1 as '", global.GetScreenName(companyId, "Phone1", pg.Trim()), "', email as '", global.GetScreenName(companyId, "Email", pg.Trim()), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " clientID int, firstname nvarchar(max), lastname nvarchar(max),phone1 nvarchar(max),email nvarchar(max), btassigned bit ";
                            str4 = " clientID, firstname, lastname, phone1, email, btassigned ";
                            break;
                        }
                    case "campaign":
                        {
                            empty = "tb_campaign";
                            str = "campaignid";
                            empty1 = "tb_campaigncustomizevalue";
                            str1 = "campaigncustomizeid";
                            empty2 = "tb_campaignviewvalue";
                            str2 = "campaignviewvalueid";
                            empty3 = "campaignname";
                            item = new object[] { " campaignname as '", global.GetScreenName(companyId, "Campaign Name", pg.Trim()), "', campaignstatus as '", global.GetScreenName(companyId, "Status", pg.Trim()), "', ", global.databaseUserName(), ".return_DateTime_Before_View(startdateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "Start Date", pg.Trim()), "',", global.databaseUserName(), ".return_DateTime_Before_View(enddateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "End Date", pg.Trim()), "',IsNull(expectedrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Expected Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(item);
                            empty4 = " campaignname nvarchar(max), campaignstatus nvarchar(max), startdate datetime, enddate datetime, expectedrevenue decimal, btassigned bit ";
                            str4 = " campaignname, campaignstatus, startdate, enddate, expectedrevenue, btassigned ";
                            break;
                        }
                    case "solution":
                        {
                            empty = "tb_solution";
                            str = "solutionid";
                            empty1 = "tb_solutioncustomizevalue";
                            str1 = "solutioncustomizeid";
                            empty2 = "tb_solutionviewvalue";
                            str2 = "solutionviewvalueid";
                            empty3 = "solutionnumber";
                            screenName = new string[] { " solutionnumber as '", global.GetScreenName(companyId, "Solution Number", pg.Trim()), "', solutiontitle as '", global.GetScreenName(companyId, "Title", pg.Trim()), "', solutionstatus as '", global.GetScreenName(companyId, "Status", pg.Trim()), "', replace(replace(ispublishedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Published", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " solutionnumber nvarchar(max), solutiontitle nvarchar(max), solutionstatus nvarchar(max), ispublished bit ";
                            str4 = " solutionnumber, solutiontitle, solutionstatus, ispublished ";
                            break;
                        }
                    case "opportunity":
                        {
                            empty = "tb_opportunity";
                            str = "opportunityid";
                            empty1 = "tb_opportunitycustomizevalue";
                            str1 = "opportunitycustomizeid";
                            empty2 = "tb_opportunityviewvalue";
                            str2 = "opportunityviewvalueid";
                            empty3 = "opportunityname";
                            item = new object[] { " opportunityname as '", global.GetScreenName(companyId, "Opportunity Name", pg.Trim()), "', opportunitytype as '", global.GetScreenName(companyId, "Opportunity Type", pg.Trim()), "', opportunitystagename as '", global.GetScreenName(companyId, "Opportunity Stage", pg.Trim()), "',IsNull(expectedamountÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Expected Amount(USD)", pg.Trim())), "',", global.databaseUserName(), ".return_DateTime_Before_View(closedateÇ", companyId, "Ç", userId, ") as 'Close On' " };
                            str3 = string.Concat(item);
                            empty4 = " opportunityname nvarchar(max), opportunitytype nvarchar(max), opportunitystagename nvarchar(max), expectedamount money, closedate datetime ";
                            str4 = " opportunityname, opportunitytype, opportunitystagename, expectedamount, closedate ";
                            break;
                        }
                    case "ticket":
                        {
                            empty = "tb_ticket";
                            str = "ticketid";
                            empty1 = "tb_ticketcustomizevalue";
                            str1 = "ticketcustomizeid";
                            empty2 = "tb_ticketviewvalue";
                            str2 = "ticketviewvalueid";
                            empty3 = "ticketnumber";
                            screenName = new string[] { " ticketnumber as '", global.GetScreenName(companyId, "Ticket Number", pg.Trim()), "', subject as '", global.GetScreenName(companyId, "Subject", pg.Trim()), "', tickettype as '", global.GetScreenName(companyId, "Ticket Type", pg.Trim()), "',ticketreason as '", global.GetScreenName(companyId, "Ticket Reason", pg.Trim()), "', ticketstatus as '", global.GetScreenName(companyId, "Ticket Status", pg.Trim()), "', ticketpriority as '", global.GetScreenName(companyId, "Ticket Priority", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " ticketnumber nvarchar(max), subject nvarchar(max), tickettype nvarchar(max), ticketreason nvarchar(max),ticketstatus nvarchar(max),ticketpriority nvarchar(max) ";
                            str4 = " ticketnumber, subject, tickettype, ticketreason, ticketstatus, ticketpriority ";
                            break;
                        }
                    case "forecast":
                        {
                            empty = "tb_forecast";
                            str = "forecastid";
                            str1 = "forecastcustomizeid";
                            empty2 = "tb_forecastviewvalue";
                            str2 = "forecastviewvalueid";
                            empty3 = "forecastname";
                            item = new object[] { " forecastname as '", global.GetScreenName(companyId, "Forecast Name", pg.Trim()), "',IsNull(Quoteamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Quote Amount", pg.Trim())), "',IsNull(commitamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Commit Amount", pg.Trim())), "',IsNull(bestticketamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Best Case Amount", pg.Trim())), "',", global.databaseUserName(), ".return_DateTime_Before_View(modifieddateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "Modified Date", pg.Trim()), "' " };
                            str3 = string.Concat(item);
                            empty4 = " forecastname nvarchar(max), Quoteamount1 money, commitamount1 money, bestticketamount1 money, modifieddate datetime ";
                            str4 = " forecastname, Quoteamount1, commitamount1, bestticketamount1, modifieddate ";
                            break;
                        }
                    case "contract":
                        {
                            empty = "tb_contract";
                            str = "contractid";
                            empty1 = "tb_contractcustomizevalue";
                            str1 = "contractcustomizeid";
                            empty2 = "tb_contractviewvalue";
                            str2 = "contractviewvalueid";
                            empty3 = "contractalias";
                            screenName = new string[] { "contractalias as '", global.GetScreenName(companyId, "Contract Alias", pg.Trim()), "',", base.fieldElement_US("clientid", companyId, userId, "clientid", "text", ""), " as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', status as '", global.GetScreenName(companyId, "Status", pg.Trim()), "',replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = "contractalias nvarchar(max),clientid int, status nvarchar(max), btassigned bit ";
                            str4 = "contractalias, clientid, status, btassigned ";
                            break;
                        }
                    case "product":
                        {
                            empty = "tb_product";
                            str = "productid";
                            empty1 = "tb_productcustomizevalue";
                            str1 = "productcustomizeid";
                            empty2 = "tb_productviewvalue";
                            str2 = "productviewvalueid";
                            empty3 = "productname";
                            screenName = new string[] { " productName as '", global.GetScreenName(companyId, "Product Name", pg.Trim()), "', productCode as '", global.GetScreenName(companyId, "Product Code", pg.Trim()), "', productalias as '", global.GetScreenName(companyId, "Product Alias", pg.Trim()), "',productcategory as '", global.GetScreenName(companyId, "Product Family", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " productName nvarchar(max), productCode nvarchar(max), productalias nvarchar(max), productcategory nvarchar(max) ";
                            str4 = " productName, productCode, productalias, productcategory ";
                            break;
                        }
                    case "asset":
                        {
                            empty = "tb_asset";
                            str = "assetid";
                            empty1 = "tb_assetcustomizevalue";
                            str1 = "assetcustomizeid";
                            empty2 = "tb_assetviewvalue";
                            str2 = "assetviewvalueid";
                            empty3 = "assetname";
                            item = new object[] { global.databaseUserName(), ".return_DateTime_Before_View(purchasedateÇ", companyId, "Ç", userId, ")as '", global.GetScreenName(companyId, "Purchase Date", pg.Trim()), "' " };
                            string str7 = string.Concat(item);
                            screenName = new string[] { " assetName as '", global.GetScreenName(companyId, "Asset Name", pg.Trim()), "', assetstatus as '", global.GetScreenName(companyId, "Asset Status", pg.Trim()), "',IsNull(priceÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Price", pg.Trim())), "', ", str7 };
                            str3 = string.Concat(screenName);
                            empty4 = " assetName nvarchar(max), assetstatus nvarchar(max), price  money, purchasedate datetime ";
                            str4 = " assetName, assetstatus, price, purchasedate ";
                            break;
                        }
                    case "price":
                        {
                            empty = "tb_price";
                            str = "priceid";
                            empty1 = "tb_pricecustomizevalue";
                            str1 = "pricecustomizeid";
                            empty2 = "tb_priceviewvalue";
                            str2 = "priceviewvalueid";
                            empty3 = "pricebookname";
                            screenName = new string[] { " pricebookname as '", global.GetScreenName(companyId, "Price Book Name", pg.Trim()), "', pricebookalias as '", global.GetScreenName(companyId, "Price Book Alias", pg.Trim()), "',replace(replace(isactiveÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Active", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " pricebookname nvarchar(max), pricebookalias nvarchar(max), isactive bit ";
                            str4 = " pricebookname, pricebookalias, isactive ";
                            break;
                        }
                }
            }
            if (empty3.ToLower() != sortField.ToLower())
            {
                empty5 = empty3;
            }
            else
            {
                empty5 = sortField;
                sortField = "''";
            }
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyID", companyId);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                string str8 = sqlDataReader["labelname"].ToString().Trim().Replace("'", "''");
                if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "d" && sortField.Trim().ToLower() == str8.Trim().ToLower())
                {
                    sortField = sqlDataReader["databasefieldname"].ToString().ToLower().Trim();
                }
                if (Convert.ToInt32(sqlDataReader["isDisplayed"]) != 1)
                {
                    continue;
                }
                if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "e")
                {
                    this.arrInUserField.Add(sqlDataReader["databasefieldname"].ToString().ToLower().Trim());
                }
                else
                {
                    this.arrInUserField.Add(string.Concat("[", sqlDataReader["databasefieldname"].ToString().ToLower().Trim(), "]"));
                }
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
            sqlDataReader.Dispose();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            StringBuilder stringBuilder1 = new StringBuilder();
            string str9 = string.Empty;
            StringBuilder stringBuilder2 = new StringBuilder();
            string empty10 = string.Empty;
            StringBuilder stringBuilder3 = new StringBuilder();
            empty3 = string.Concat("L.", empty3);
            if (letter1 == "number")
            {
                screenName = new string[] { " and (", empty3, " like '0%' or ", empty3, " like '1%' or ", empty3, " like '2%' or ", empty3, " like '3%' or ", empty3, " like '4%' or ", empty3, " like '5%' or ", empty3, " like '6%' or ", empty3, " like '7%' or ", empty3, " like '8%' or ", empty3, " like '9%') " };
                letter1 = string.Concat(screenName);
            }
            else if (letter1 != null && letter1 != "")
            {
                if (pg.ToLower() != "campaign")
                {
                    screenName = new string[] { " and ", empty3, " like '", letter1, "%'" };
                    letter1 = string.Concat(screenName);
                }
                else
                {
                    letter1 = string.Concat(" and ", letter1);
                }
            }
            if (viewValueId == 0)
            {
                empty7 = str3;
                empty9 = empty4;
                str9 = str4;
                empty10 = str9;
            }
            else
            {
                commonClass _commonClass1 = new commonClass();
                item = new object[] { " select * from ", empty2, " where ", str2, "=", viewValueId };
                string str10 = string.Concat(item);
                SqlDataReader sqlDataReader1 = (new SqlCommand(str10, _commonClass1.openConnection())).ExecuteReader();
                string str11 = "";
                string str12 = "";
                string str13 = "";
                string str14 = "";
                string str15 = "";
                string str16 = "";
                string str17 = "";
                string str18 = "";
                string str19 = "";
                string str20 = "";
                string str21 = "";
                string str22 = "";
                string str23 = "";
                string str24 = "";
                string str25 = "";
                string str26 = "";
                string str27 = "";
                string str28 = "";
                string str29 = "";
                string str30 = "";
                string str31 = "";
                string str32 = "";
                string str33 = "";
                string str34 = "";
                string str35 = "";
                string str36 = "";
                string searchCondition = "";
                string searchCondition1 = "";
                string searchCondition2 = "";
                string searchCondition3 = "";
                string searchCondition4 = "";
                string[] strArrays1 = new string[11];
                bool[] flagArray = new bool[11];
                while (sqlDataReader1.Read())
                {
                    str11 = sqlDataReader1["field1"].ToString().Replace(",", "Ç");
                    str12 = sqlDataReader1["field2"].ToString().Replace(",", "Ç");
                    str13 = sqlDataReader1["field3"].ToString().Replace(",", "Ç");
                    str14 = sqlDataReader1["field4"].ToString().Replace(",", "Ç");
                    str15 = sqlDataReader1["field5"].ToString().Replace(",", "Ç");
                    str16 = sqlDataReader1["field6"].ToString().Replace(",", "Ç");
                    str17 = sqlDataReader1["field7"].ToString().Replace(",", "Ç");
                    str18 = sqlDataReader1["field8"].ToString().Replace(",", "Ç");
                    str19 = sqlDataReader1["field9"].ToString().Replace(",", "Ç");
                    str20 = sqlDataReader1["field10"].ToString().Replace(",", "Ç");
                    str21 = sqlDataReader1["field11"].ToString().Replace(",", "Ç");
                    for (int i = 1; i <= 11; i++)
                    {
                        strArrays1[i - 1] = sqlDataReader1[string.Concat("field", i.ToString())].ToString();
                    }
                    str22 = sqlDataReader1["condition1"].ToString();
                    str23 = sqlDataReader1["condition2"].ToString();
                    str24 = sqlDataReader1["condition3"].ToString();
                    str25 = sqlDataReader1["condition4"].ToString();
                    str26 = sqlDataReader1["condition5"].ToString();
                    str27 = sqlDataReader1["operator1"].ToString();
                    str28 = sqlDataReader1["operator2"].ToString();
                    str29 = sqlDataReader1["operator3"].ToString();
                    str30 = sqlDataReader1["operator4"].ToString();
                    str31 = sqlDataReader1["operator5"].ToString();
                    str32 = sqlDataReader1["value1"].ToString().Replace("'", "''");
                    str33 = sqlDataReader1["value2"].ToString().Replace("'", "''");
                    str34 = sqlDataReader1["value3"].ToString().Replace("'", "''");
                    str35 = sqlDataReader1["value4"].ToString().Replace("'", "''");
                    str36 = sqlDataReader1["value5"].ToString().Replace("'", "''");
                    bool flag = false;
                    if (sqlDataReader1["SortedBy"].ToString().Trim().Length > 0 && sqlDataReader1["SortedBy"].ToString().Trim().ToLower() != "please select")
                    {
                        empty5 = sqlDataReader1["SortedBy"].ToString();
                        flag = true;
                    }
                    if (sqlDataReader1["SortedBy"].ToString().Trim().Length <= 0 || !flag)
                    {
                        continue;
                    }
                    str5 = sqlDataReader1["SortDirection"].ToString();
                }
                _commonClass1.closeConnection();
                SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_customizefield", _commonClass1.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand1.Parameters.AddWithValue("@pg", pg);
                sqlCommand1.Parameters.AddWithValue("@companyID", companyId);
                sqlDataReader1 = sqlCommand1.ExecuteReader();
                empty7 = "";
                empty9 = "";
                str9 = "";
                empty10 = string.Empty;
                int j = 0;
                for (j = 0; j < 11; j++)
                {
                    int num = 1;
                    for (int k = j + 1; k < 11; k++)
                    {
                        if (strArrays1[j] == strArrays1[k])
                        {
                            flagArray[k] = true;
                            strArrays1[k] = string.Concat(strArrays1[j], "_", num);
                            num++;
                        }
                    }
                }
                while (sqlDataReader1.Read())
                {
                    string empty11 = string.Empty;
                    string str37 = sqlDataReader1["fieldtype"].ToString().ToLower().Trim();
                    string str38 = sqlDataReader1["labelname"].ToString().Trim().Replace("'", "''");
                    if (sortField.Trim().ToLower() != str38.Trim().ToLower())
                    {
                        chrArray = new char[] { '\u005F' };
                        string[] strArrays2 = sortField.Split(chrArray);
                        if ((int)strArrays2.Length == 2 && strArrays2[0].Trim().ToLower() == str38.Trim().ToLower())
                        {
                            if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "d")
                            {
                                sortField = string.Concat(sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "_", strArrays2[1]);
                            }
                            else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "e")
                            {
                                screenName = new string[] { "[", sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "_", strArrays2[1], "]" };
                                sortField = string.Concat(screenName);
                            }
                        }
                    }
                    else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "d")
                    {
                        sortField = sqlDataReader1["databasefieldname"].ToString().ToLower().Trim();
                    }
                    else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "e")
                    {
                        sortField = string.Concat("[", sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "]");
                    }
                    string str39 = sqlDataReader1["inputtype"].ToString().Trim();
                    int num1 = int.Parse(sqlDataReader1["customizeid"].ToString().Trim());
                    int num2 = 0;
                    if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() != "e")
                    {
                        if (str11.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 0;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str11, " ,"));
                                stringBuilder3.Append(string.Concat(str11, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, str11, str39, str38), " as '", base.returnMyCurrency(str11, companyId, userId, str11, str39, str38), "',"));
                            }
                            else
                            {
                                string str40 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str40.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str11, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str11, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str12.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 1;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str12, " ,"));
                                stringBuilder3.Append(string.Concat(str12, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, str12, str39, str38), " as '", base.returnMyCurrency(str12, companyId, userId, str12, str39, str38), "',"));
                            }
                            else
                            {
                                string str41 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str41.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str12, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str12, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str13.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 2;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str13, " ,"));
                                stringBuilder3.Append(string.Concat(str13, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, str13, str39, str38), " as '", base.returnMyCurrency(str13, companyId, userId, str13, str39, str38), "',"));
                            }
                            else
                            {
                                string str42 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str42.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str13, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str13, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str14.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 3;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str14, " ,"));
                                stringBuilder3.Append(string.Concat(str14, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, str14, str39, str38), " as '", base.returnMyCurrency(str14, companyId, userId, str14, str39, str38), "',"));
                            }
                            else
                            {
                                string str43 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str43.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str14, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str14, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str15.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 4;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str15, " ,"));
                                stringBuilder3.Append(string.Concat(str15, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, str15, str39, str38), " as '", base.returnMyCurrency(str15, companyId, userId, str15, str39, str38), "',"));
                            }
                            else
                            {
                                string str44 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str44.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str15, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str15, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str16.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 5;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str16, " ,"));
                                stringBuilder3.Append(string.Concat(str16, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, str16, str39, str38), " as '", base.returnMyCurrency(str16, companyId, userId, str16, str39, str38), "',"));
                            }
                            else
                            {
                                string str45 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str45.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str16, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str16, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str17.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 6;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str17, " ,"));
                                stringBuilder3.Append(string.Concat(str17, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, str17, str39, str38), " as '", base.returnMyCurrency(str17, companyId, userId, str17, str39, str38), "',"));
                            }
                            else
                            {
                                string str46 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str46.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str17, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str17, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str18.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 7;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str18, " ,"));
                                stringBuilder3.Append(string.Concat(str18, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, str18, str39, str38), " as '", base.returnMyCurrency(str18, companyId, userId, str18, str39, str38), "',"));
                            }
                            else
                            {
                                string str47 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str47.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str18, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str18, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str19.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 8;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str19, " ,"));
                                stringBuilder3.Append(string.Concat(str19, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, str19, str39, str38), " as '", base.returnMyCurrency(str19, companyId, userId, str19, str39, str38), "',"));
                            }
                            else
                            {
                                string str48 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str48.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str19, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str19, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str20.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 9;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str20, " ,"));
                                stringBuilder3.Append(string.Concat(str20, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, str20, str39, str38), " as '", base.returnMyCurrency(str20, companyId, userId, str20, str39, str38), "',"));
                            }
                            else
                            {
                                string str49 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str49.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str20, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str20, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                        if (str21.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 10;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str21, " ,"));
                                stringBuilder3.Append(string.Concat(str21, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, str21, str39, str38), " as '", base.returnMyCurrency(str21, companyId, userId, str21, str39, str38), "',"));
                            }
                            else
                            {
                                string str50 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str50.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(str21, " ,"));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, strArrays1[num2], str39, str38), " as '", base.returnMyCurrency(str21, companyId, userId, strArrays1[num2], str39, empty11), "',"));
                            }
                        }
                    }
                    else
                    {
                        if (str11.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 0;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str11, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, string.Concat("[", str11, "]"), str39), " as '", base.returnMyCurrency(str11, companyId, userId, string.Concat("[", str11, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str51 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str51.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str11, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str12.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 1;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str12, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, string.Concat("[", str12, "]"), str39), " as '", base.returnMyCurrency(str12, companyId, userId, string.Concat("[", str12, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str52 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str52.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str12, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str13.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 2;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str13, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, string.Concat("[", str13, "]"), str39), " as '", base.returnMyCurrency(str13, companyId, userId, string.Concat("[", str13, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str53 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str53.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str13, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str14.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 3;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str14, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, string.Concat("[", str14, "]"), str39), " as '", base.returnMyCurrency(str14, companyId, userId, string.Concat("[", str14, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str54 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str54.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str14, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str15.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 4;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str15, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, string.Concat("[", str15, "]"), str39), " as '", base.returnMyCurrency(str15, companyId, userId, string.Concat("[", str15, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str55 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str55.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str15, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str16.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 5;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str16, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, string.Concat("[", str16, "]"), str39), " as '", base.returnMyCurrency(str16, companyId, userId, string.Concat("[", str16, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str56 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str56.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str16, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str17.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 6;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str17, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, string.Concat("[", str17, "]"), str39), " as '", base.returnMyCurrency(str17, companyId, userId, string.Concat("[", str17, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str57 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str57.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str17, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str18.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 7;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str18, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, string.Concat("[", str18, "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", str18, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str58 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str58.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str19.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 8;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str19, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, string.Concat("[", str19, "]"), str39), " as '", base.returnMyCurrency(str19, companyId, userId, string.Concat("[", str19, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str59 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str59.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", str18, "]"), str39, empty11), "',"));
                            }
                        }
                        if (str20.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 9;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str20, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, string.Concat("[", str20, "]"), str39), " as '", base.returnMyCurrency(str20, companyId, userId, string.Concat("[", str20, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str60 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str60.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str20, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str21.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 10;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str21, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, string.Concat("[", str21, "]"), str39), " as '", base.returnMyCurrency(str21, companyId, userId, string.Concat("[", str21, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str61 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str61.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str21, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                    }
                    if (str22.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition = base.getSearchCondition(companyId, userId, str22, str27, str32, str37, str39, num1, pg);
                    }
                    if (str23.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition1 = base.getSearchCondition(companyId, userId, str23, str28, str33, str37, str39, num1, pg);
                    }
                    if (str24.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition2 = base.getSearchCondition(companyId, userId, str24, str29, str34, str37, str39, num1, pg);
                    }
                    if (str25.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition3 = base.getSearchCondition(companyId, userId, str25, str30, str35, str37, str39, num1, pg);
                    }
                    if (str26.ToString().ToLower().Trim() != sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        continue;
                    }
                    searchCondition4 = base.getSearchCondition(companyId, userId, str26, str31, str36, str37, str39, num1, pg);
                }
                _commonClass1.closeConnection();
                empty8 = "";
                screenName = new string[] { searchCondition, searchCondition1, searchCondition2, searchCondition3, searchCondition4 };
                empty8 = string.Concat(screenName);
                empty7 = (stringBuilder.ToString().Length == 0 ? stringBuilder.ToString() : stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1));
                empty9 = (stringBuilder1.ToString().Length == 0 ? stringBuilder1.ToString() : stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1));
                str9 = (stringBuilder2.ToString().Length == 0 ? stringBuilder2.ToString() : stringBuilder2.ToString().Substring(0, stringBuilder2.ToString().Length - 1));
                empty10 = (stringBuilder3.ToString().Length == 0 ? stringBuilder3.ToString() : stringBuilder3.ToString().Substring(0, stringBuilder3.ToString().Length - 1));
            }
            string str62 = "";
            if (empty.ToLower().Trim() == "tb_lead")
            {
                str62 = " and L.isconverted = 0 ";
            }
            string str63 = base.CheckViewRight(pg, adminrights, companyId, userId);
            int num3 = 0;
            int pageSize = 0;
            num3 = intStartIndex;
            pageSize = PageSize;
            string empty12 = string.Empty;
            string empty13 = string.Empty;
            StringBuilder stringBuilder4 = new StringBuilder();
            chrArray = new char[] { ',' };
            string[] strArrays3 = empty9.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays4 = str9.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays5 = empty10.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays6 = empty7.Split(chrArray);
            empty9 = string.Empty;
            str9 = string.Empty;
            empty10 = string.Empty;
            empty7 = string.Empty;
            int num4 = 0;
            for (int l = 0; l < this.arrInUserField.Count; l++)
            {
                for (int m = 0; m < (int)strArrays3.Length; m++)
                {
                    if (this.arrInUserField[l].ToString().ToLower().Trim() == strArrays4[m].ToString().Trim().ToLower())
                    {
                        empty9 = string.Concat(empty9, strArrays3[m].ToString(), ",");
                        str9 = string.Concat(str9, strArrays4[m].ToString(), ",");
                        empty10 = string.Concat(empty10, strArrays5[m].ToString(), ",");
                        empty7 = string.Concat(empty7, strArrays6[m].ToString().Replace('Ç', ','), ",");
                        num4++;
                    }
                }
            }
            if ((int)strArrays4.Length > num4 + 1)
            {
                IsMsg = "Yes";
            }
            if (empty9.Length > 0)
            {
                empty9 = empty9.Substring(0, empty9.Length - 1);
                str9 = str9.Substring(0, str9.Length - 1);
                empty10 = empty10.Substring(0, empty10.Length - 1);
                empty7 = empty7.Substring(0, empty7.Length - 1);
            }
            if (empty9.Length <= 0)
            {
                screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT) Insert Into #PageIndex  (", str, ")" };
                stringBuilder4.Append(string.Concat(screenName));
                if (pg.ToLower() != "client")
                {
                    item = new object[] { " Select ", str, " FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else
                {
                    item = new object[] { " Select ", str, " FROM ", empty, "  L where L.isdelete=0 and L.companytype='", this.CompanyType, "' and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                empty7 = string.Concat("select  ", str, " as ID from #PageIndex ");
            }
            else
            {
                if (pg.ToLower() == "client" || pg.ToLower() == "campaign")
                {
                    screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT,  ", empty9, ",  name1 nvarchar(max) ) Insert Into #PageIndex  (", str, ",", str9, ",name1)" };
                    stringBuilder4.Append(string.Concat(screenName));
                }
                else
                {
                    screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT,  ", empty9, " ) Insert Into #PageIndex  (", str, ",", str9, ")" };
                    stringBuilder4.Append(string.Concat(screenName));
                }
                if (pg.ToLower() == "client")
                {
                    item = new object[] { " Select ", str, ",", empty10, ",clientname FROM ", empty, "  L where L.isdelete=0 and L.companytype='", this.CompanyType, "' and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else if (pg.ToLower() != "campaign")
                {
                    item = new object[] { " Select ", str, ",", empty10, " FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else
                {
                    item = new object[] { " Select ", str, ",", empty10, ",campaignname FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                if (pg.ToLower() == "client" || pg.ToLower() == "campaign")
                {
                    screenName = new string[] { "select  ", empty7, " ,name1 as [Client Name],", str, " as ID from #PageIndex " };
                    empty7 = string.Concat(screenName);
                }
                else
                {
                    screenName = new string[] { "select  ", empty7, " ,", str, " as ID from #PageIndex " };
                    empty7 = string.Concat(screenName);
                }
            }
            if (sortField.Trim().Length <= 2 || sortField.Trim().Contains(Convert.ToString(this.Session["currency"])))
            {
                item = new object[] { empty12, empty7, " Where IndexID > ", num3, " and IndexID < ", num3 + pageSize + 1 };
                empty6 = string.Concat(item);
            }
            else
            {
                item = new object[] { empty12, empty7, " Where IndexID > ", num3, " and IndexID < ", num3 + pageSize + 1, " order by ", sortField.Trim(), " " };
                empty6 = string.Concat(item);
            }
            empty13 = " select count(*) as totalrecord from #PageIndex ";
            if (sortField.Length > 2 && !sortField.Trim().Contains(Convert.ToString(this.Session["currency"])))
            {
                viewClass.SortFieldd = sortField;
                if (viewClass.SortFieldd == sortField)
                {
                    viewClass.SortCount = viewClass.SortCount + 1;
                    if (viewClass.SortCount % 2 != 0)
                    {
                        viewClass.SortDirection = "desc";
                    }
                    else
                    {
                        viewClass.SortDirection = "asc";
                    }
                }
                else
                {
                    viewClass.SortDirection = "desc";
                    viewClass.SortCount = 0;
                }
                empty6 = string.Concat(empty6, viewClass.SortDirection);
            }
            empty6 = string.Concat(empty6, ";", empty13);
            return empty6;
        }

        public string returnFinalQuery_campaign(int companyId, int userId, string sortField, string sortdirection, string letter1, int intStartIndex, int PageSize, string pg, int viewValueId, int adminrights, ref string IsMsg, string companytype)
        {
            string[] strArrays;
            string[] screenName;
            object[] item;
            char[] chrArray;
            this.CompanyType = companytype;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string lower = pg.Trim().ToLower();
            string str6 = lower;
            if (lower != null)
            {
                switch (str6)
                {
                    case "lead":
                        {
                            empty = "tb_lead";
                            str = "leadid";
                            empty1 = "tb_leadcustomizevalue";
                            str1 = "leadcustomizeid";
                            empty2 = "tb_leadviewvalue";
                            str2 = "leadviewvalueid";
                            empty3 = "lastName";
                            screenName = new string[] { " companyname as '", global.GetScreenName(companyId, "Company name", pg.Trim()), "', Isnull(firstnameÇ'') as '", global.GetScreenName(companyId, "First Name", pg.Trim()), "',Isnull(lastnameÇ'') as '", global.GetScreenName(companyId, "Last Name", pg.Trim()), "', phone as '", global.GetScreenName(companyId, "Phone", pg.Trim()), "', IsNull(annualrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Annual Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "'" };
                            str3 = string.Concat(screenName);
                            empty4 = " companyname nvarchar(max), firstname nvarchar(max), lastname nvarchar(max), phone nvarchar(max), annualrevenue money, btassigned bit ";
                            str4 = " companyname, firstname, lastname, phone, annualrevenue, btassigned ";
                            break;
                        }
                    case "client":
                        {
                            empty = "tb_client";
                            str = "clientid";
                            empty1 = "tb_clientcustomizevalue";
                            str1 = "clientcustomizeid";
                            empty2 = "tb_clientviewvalue";
                            str2 = "clientviewvalueid";
                            empty3 = "clientName";
                            screenName = new string[] { " clientname as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', clientsite as  '", global.GetScreenName(companyId, "Client Site", pg.Trim()), "', phone as '", global.GetScreenName(companyId, "Phone", pg.Trim()), "',IsNull(annualrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Annual Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as  '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " clientname nvarchar(max), clientsite nvarchar(max),phone nvarchar(max),annualrevenue money, btassigned bit ";
                            str4 = " clientname, clientsite, phone, annualrevenue, btassigned ";
                            break;
                        }
                    case "contact":
                        {
                            empty = "tb_contact";
                            str = "contactid";
                            empty1 = "tb_contactcustomizevalue";
                            str1 = "contactcustomizeid";
                            empty2 = "tb_contactviewvalue";
                            str2 = "contactviewvalueid";
                            empty3 = "lastname";
                            screenName = new string[] { "  clientID,Isnull(firstnameÇ'') as '", global.GetScreenName(companyId, "First Name", pg.Trim()), "',Isnull(lastnameÇ'') as '", global.GetScreenName(companyId, "Last Name", pg.Trim()), "',", base.fieldElement_US("clientid", companyId, userId, "clientid", "text", ""), " as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', phone1 as '", global.GetScreenName(companyId, "Phone1", pg.Trim()), "', email as '", global.GetScreenName(companyId, "Email", pg.Trim()), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " clientID int, firstname nvarchar(max), lastname nvarchar(max),phone1 nvarchar(max),email nvarchar(max), btassigned bit ";
                            str4 = " clientID, firstname, lastname, phone1, email, btassigned ";
                            break;
                        }
                    case "campaign":
                        {
                            empty = "tb_campaign";
                            str = "campaignid";
                            empty1 = "tb_campaigncustomizevalue";
                            str1 = "campaigncustomizeid";
                            empty2 = "tb_campaignviewvalue";
                            str2 = "campaignviewvalueid";
                            empty3 = "campaignname";
                            item = new object[] { " campaignname as '", global.GetScreenName(companyId, "Campaign Name", pg.Trim()), "', campaignstatus as '", global.GetScreenName(companyId, "Status", pg.Trim()), "', ", global.databaseUserName(), ".return_DateTime_Before_View(startdateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "Start Date", pg.Trim()), "',", global.databaseUserName(), ".return_DateTime_Before_View(enddateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "End Date", pg.Trim()), "',IsNull(expectedrevenueÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Expected Revenue", pg.Trim())), "', replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(item);
                            empty4 = " campaignname nvarchar(max), campaignstatus nvarchar(max), startdate datetime, enddate datetime, expectedrevenue decimal, btassigned bit ";
                            str4 = " campaignname, campaignstatus, startdate, enddate, expectedrevenue, btassigned ";
                            break;
                        }
                    case "solution":
                        {
                            empty = "tb_solution";
                            str = "solutionid";
                            empty1 = "tb_solutioncustomizevalue";
                            str1 = "solutioncustomizeid";
                            empty2 = "tb_solutionviewvalue";
                            str2 = "solutionviewvalueid";
                            empty3 = "solutionnumber";
                            screenName = new string[] { " solutionnumber as '", global.GetScreenName(companyId, "Solution Number", pg.Trim()), "', solutiontitle as '", global.GetScreenName(companyId, "Title", pg.Trim()), "', solutionstatus as '", global.GetScreenName(companyId, "Status", pg.Trim()), "', replace(replace(ispublishedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Published", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " solutionnumber nvarchar(max), solutiontitle nvarchar(max), solutionstatus nvarchar(max), ispublished bit ";
                            str4 = " solutionnumber, solutiontitle, solutionstatus, ispublished ";
                            break;
                        }
                    case "opportunity":
                        {
                            empty = "tb_opportunity";
                            str = "opportunityid";
                            empty1 = "tb_opportunitycustomizevalue";
                            str1 = "opportunitycustomizeid";
                            empty2 = "tb_opportunityviewvalue";
                            str2 = "opportunityviewvalueid";
                            empty3 = "opportunityname";
                            item = new object[] { " opportunityname as '", global.GetScreenName(companyId, "Opportunity Name", pg.Trim()), "', opportunitytype as '", global.GetScreenName(companyId, "Opportunity Type", pg.Trim()), "', opportunitystagename as '", global.GetScreenName(companyId, "Opportunity Stage", pg.Trim()), "',IsNull(expectedamountÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Expected Amount(USD)", pg.Trim())), "',", global.databaseUserName(), ".return_DateTime_Before_View(closedateÇ", companyId, "Ç", userId, ") as 'Close On' " };
                            str3 = string.Concat(item);
                            empty4 = " opportunityname nvarchar(max), opportunitytype nvarchar(max), opportunitystagename nvarchar(max), expectedamount money, closedate datetime ";
                            str4 = " opportunityname, opportunitytype, opportunitystagename, expectedamount, closedate ";
                            break;
                        }
                    case "ticket":
                        {
                            empty = "tb_ticket";
                            str = "ticketid";
                            empty1 = "tb_ticketcustomizevalue";
                            str1 = "ticketcustomizeid";
                            empty2 = "tb_ticketviewvalue";
                            str2 = "ticketviewvalueid";
                            empty3 = "ticketnumber";
                            screenName = new string[] { " ticketnumber as '", global.GetScreenName(companyId, "Ticket Number", pg.Trim()), "', subject as '", global.GetScreenName(companyId, "Subject", pg.Trim()), "', tickettype as '", global.GetScreenName(companyId, "Ticket Type", pg.Trim()), "',ticketreason as '", global.GetScreenName(companyId, "Ticket Reason", pg.Trim()), "', ticketstatus as '", global.GetScreenName(companyId, "Ticket Status", pg.Trim()), "', ticketpriority as '", global.GetScreenName(companyId, "Ticket Priority", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " ticketnumber nvarchar(max), subject nvarchar(max), tickettype nvarchar(max), ticketreason nvarchar(max),ticketstatus nvarchar(max),ticketpriority nvarchar(max) ";
                            str4 = " ticketnumber, subject, tickettype, ticketreason, ticketstatus, ticketpriority ";
                            break;
                        }
                    case "forecast":
                        {
                            empty = "tb_forecast";
                            str = "forecastid";
                            str1 = "forecastcustomizeid";
                            empty2 = "tb_forecastviewvalue";
                            str2 = "forecastviewvalueid";
                            empty3 = "forecastname";
                            item = new object[] { " forecastname as '", global.GetScreenName(companyId, "Forecast Name", pg.Trim()), "',IsNull(Quoteamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Quote Amount", pg.Trim())), "',IsNull(commitamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Commit Amount", pg.Trim())), "',IsNull(bestticketamount1Ç0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Best Case Amount", pg.Trim())), "',", global.databaseUserName(), ".return_DateTime_Before_View(modifieddateÇ", companyId, "Ç", userId, ") as '", global.GetScreenName(companyId, "Modified Date", pg.Trim()), "' " };
                            str3 = string.Concat(item);
                            empty4 = " forecastname nvarchar(max), Quoteamount1 money, commitamount1 money, bestticketamount1 money, modifieddate datetime ";
                            str4 = " forecastname, Quoteamount1, commitamount1, bestticketamount1, modifieddate ";
                            break;
                        }
                    case "contract":
                        {
                            empty = "tb_contract";
                            str = "contractid";
                            empty1 = "tb_contractcustomizevalue";
                            str1 = "contractcustomizeid";
                            empty2 = "tb_contractviewvalue";
                            str2 = "contractviewvalueid";
                            empty3 = "contractalias";
                            screenName = new string[] { "contractalias as '", global.GetScreenName(companyId, "Contract Alias", pg.Trim()), "',", base.fieldElement_US("clientid", companyId, userId, "clientid", "text", ""), " as '", global.GetScreenName(companyId, "Client Name", pg.Trim()), "', status as '", global.GetScreenName(companyId, "Status", pg.Trim()), "',replace(replace(btassignedÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Assigned", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = "contractalias nvarchar(max),clientid int, status nvarchar(max), btassigned bit ";
                            str4 = "contractalias, clientid, status, btassigned ";
                            break;
                        }
                    case "product":
                        {
                            empty = "tb_product";
                            str = "productid";
                            empty1 = "tb_productcustomizevalue";
                            str1 = "productcustomizeid";
                            empty2 = "tb_productviewvalue";
                            str2 = "productviewvalueid";
                            empty3 = "productname";
                            screenName = new string[] { " productName as '", global.GetScreenName(companyId, "Product Name", pg.Trim()), "', productCode as '", global.GetScreenName(companyId, "Product Code", pg.Trim()), "', productalias as '", global.GetScreenName(companyId, "Product Alias", pg.Trim()), "',productcategory as '", global.GetScreenName(companyId, "Product Family", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " productName nvarchar(max), productCode nvarchar(max), productalias nvarchar(max), productcategory nvarchar(max) ";
                            str4 = " productName, productCode, productalias, productcategory ";
                            break;
                        }
                    case "asset":
                        {
                            empty = "tb_asset";
                            str = "assetid";
                            empty1 = "tb_assetcustomizevalue";
                            str1 = "assetcustomizeid";
                            empty2 = "tb_assetviewvalue";
                            str2 = "assetviewvalueid";
                            empty3 = "assetname";
                            item = new object[] { global.databaseUserName(), ".return_DateTime_Before_View(purchasedateÇ", companyId, "Ç", userId, ")as '", global.GetScreenName(companyId, "Purchase Date", pg.Trim()), "' " };
                            string str7 = string.Concat(item);
                            screenName = new string[] { " assetName as '", global.GetScreenName(companyId, "Asset Name", pg.Trim()), "', assetstatus as '", global.GetScreenName(companyId, "Asset Status", pg.Trim()), "',IsNull(priceÇ0.00) as '", base.returnMyCurrency("", companyId, userId, "", "currency", global.GetScreenName(companyId, "Price", pg.Trim())), "', ", str7 };
                            str3 = string.Concat(screenName);
                            empty4 = " assetName nvarchar(max), assetstatus nvarchar(max), price  money, purchasedate datetime ";
                            str4 = " assetName, assetstatus, price, purchasedate ";
                            break;
                        }
                    case "price":
                        {
                            empty = "tb_price";
                            str = "priceid";
                            empty1 = "tb_pricecustomizevalue";
                            str1 = "pricecustomizeid";
                            empty2 = "tb_priceviewvalue";
                            str2 = "priceviewvalueid";
                            empty3 = "pricebookname";
                            screenName = new string[] { " pricebookname as '", global.GetScreenName(companyId, "Price Book Name", pg.Trim()), "', pricebookalias as '", global.GetScreenName(companyId, "Price Book Alias", pg.Trim()), "',replace(replace(isactiveÇ1Ç'Yes')Ç0Ç'No') as '", global.GetScreenName(companyId, "Active", pg.Trim()), "' " };
                            str3 = string.Concat(screenName);
                            empty4 = " pricebookname nvarchar(max), pricebookalias nvarchar(max), isactive bit ";
                            str4 = " pricebookname, pricebookalias, isactive ";
                            break;
                        }
                }
            }
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyID", companyId);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                string str8 = sqlDataReader["labelname"].ToString().Trim().Replace("'", "''");
                if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "d" && sortField.Trim().ToLower() == str8.Trim().ToLower())
                {
                    sortField = sqlDataReader["databasefieldname"].ToString().ToLower().Trim();
                }
                if (Convert.ToInt32(sqlDataReader["isDisplayed"]) != 1)
                {
                    continue;
                }
                if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "e")
                {
                    this.arrInUserField.Add(sqlDataReader["databasefieldname"].ToString().ToLower().Trim());
                }
                else
                {
                    this.arrInUserField.Add(string.Concat("[", sqlDataReader["databasefieldname"].ToString().ToLower().Trim(), "]"));
                }
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
            sqlDataReader.Dispose();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            StringBuilder stringBuilder1 = new StringBuilder();
            string str9 = string.Empty;
            StringBuilder stringBuilder2 = new StringBuilder();
            string empty10 = string.Empty;
            StringBuilder stringBuilder3 = new StringBuilder();
            empty3 = string.Concat("L.", empty3);
            if (letter1 == "number")
            {
                screenName = new string[] { " and (", empty3, " like '0%' or ", empty3, " like '1%' or ", empty3, " like '2%' or ", empty3, " like '3%' or ", empty3, " like '4%' or ", empty3, " like '5%' or ", empty3, " like '6%' or ", empty3, " like '7%' or ", empty3, " like '8%' or ", empty3, " like '9%') " };
                letter1 = string.Concat(screenName);
            }
            else if (letter1 != null && letter1 != "")
            {
                letter1 = string.Concat(" and ", letter1);
            }
            if (viewValueId == 0)
            {
                empty7 = str3;
                empty9 = empty4;
                str9 = str4;
                empty10 = str9;
            }
            else
            {
                commonClass _commonClass1 = new commonClass();
                item = new object[] { " select * from ", empty2, " where ", str2, "=", viewValueId };
                string str10 = string.Concat(item);
                SqlDataReader sqlDataReader1 = (new SqlCommand(str10, _commonClass1.openConnection())).ExecuteReader();
                string str11 = "";
                string str12 = "";
                string str13 = "";
                string str14 = "";
                string str15 = "";
                string str16 = "";
                string str17 = "";
                string str18 = "";
                string str19 = "";
                string str20 = "";
                string str21 = "";
                string str22 = "";
                string str23 = "";
                string str24 = "";
                string str25 = "";
                string str26 = "";
                string str27 = "";
                string str28 = "";
                string str29 = "";
                string str30 = "";
                string str31 = "";
                string str32 = "";
                string str33 = "";
                string str34 = "";
                string str35 = "";
                string str36 = "";
                string searchCondition = "";
                string searchCondition1 = "";
                string searchCondition2 = "";
                string searchCondition3 = "";
                string searchCondition4 = "";
                string[] strArrays1 = new string[11];
                bool[] flagArray = new bool[11];
                while (sqlDataReader1.Read())
                {
                    str11 = sqlDataReader1["field1"].ToString().Replace(",", "Ç");
                    str12 = sqlDataReader1["field2"].ToString().Replace(",", "Ç");
                    str13 = sqlDataReader1["field3"].ToString().Replace(",", "Ç");
                    str14 = sqlDataReader1["field4"].ToString().Replace(",", "Ç");
                    str15 = sqlDataReader1["field5"].ToString().Replace(",", "Ç");
                    str16 = sqlDataReader1["field6"].ToString().Replace(",", "Ç");
                    str17 = sqlDataReader1["field7"].ToString().Replace(",", "Ç");
                    str18 = sqlDataReader1["field8"].ToString().Replace(",", "Ç");
                    str19 = sqlDataReader1["field9"].ToString().Replace(",", "Ç");
                    str20 = sqlDataReader1["field10"].ToString().Replace(",", "Ç");
                    str21 = sqlDataReader1["field11"].ToString().Replace(",", "Ç");
                    for (int i = 1; i <= 11; i++)
                    {
                        strArrays1[i - 1] = sqlDataReader1[string.Concat("field", i.ToString())].ToString();
                    }
                    str22 = sqlDataReader1["condition1"].ToString();
                    str23 = sqlDataReader1["condition2"].ToString();
                    str24 = sqlDataReader1["condition3"].ToString();
                    str25 = sqlDataReader1["condition4"].ToString();
                    str26 = sqlDataReader1["condition5"].ToString();
                    str27 = sqlDataReader1["operator1"].ToString();
                    str28 = sqlDataReader1["operator2"].ToString();
                    str29 = sqlDataReader1["operator3"].ToString();
                    str30 = sqlDataReader1["operator4"].ToString();
                    str31 = sqlDataReader1["operator5"].ToString();
                    str32 = sqlDataReader1["value1"].ToString().Replace("'", "''");
                    str33 = sqlDataReader1["value2"].ToString().Replace("'", "''");
                    str34 = sqlDataReader1["value3"].ToString().Replace("'", "''");
                    str35 = sqlDataReader1["value4"].ToString().Replace("'", "''");
                    str36 = sqlDataReader1["value5"].ToString().Replace("'", "''");
                    bool flag = false;
                    if (sqlDataReader1["SortedBy"].ToString().Trim().Length > 0 && sqlDataReader1["SortedBy"].ToString().Trim().ToLower() != "please select")
                    {
                        empty5 = sqlDataReader1["SortedBy"].ToString();
                        flag = true;
                    }
                    if (sqlDataReader1["SortedBy"].ToString().Trim().Length <= 0 || !flag)
                    {
                        continue;
                    }
                    str5 = sqlDataReader1["SortDirection"].ToString();
                }
                _commonClass1.closeConnection();
                if (sortField != "")
                {
                    if (empty3.ToLower() != sortField.ToLower())
                    {
                        empty5 = sortField;
                        str5 = sortdirection;
                    }
                    else
                    {
                        empty5 = sortField;
                        str5 = sortdirection;
                    }
                }
                SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_customizefield", _commonClass1.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand1.Parameters.AddWithValue("@pg", pg);
                sqlCommand1.Parameters.AddWithValue("@companyID", companyId);
                sqlDataReader1 = sqlCommand1.ExecuteReader();
                empty7 = "";
                empty9 = "";
                str9 = "";
                empty10 = string.Empty;
                int j = 0;
                for (j = 0; j < 11; j++)
                {
                    int num = 1;
                    for (int k = j + 1; k < 11; k++)
                    {
                        if (strArrays1[j] == strArrays1[k])
                        {
                            flagArray[k] = true;
                            strArrays1[k] = string.Concat(strArrays1[j], "_", num);
                            num++;
                        }
                    }
                }
                while (sqlDataReader1.Read())
                {
                    string empty11 = string.Empty;
                    string str37 = sqlDataReader1["fieldtype"].ToString().ToLower().Trim();
                    string str38 = sqlDataReader1["labelname"].ToString().Trim().Replace("'", "''").Replace(" ", "");
                    if (sortField.Trim().ToLower() != str38.Trim().ToLower())
                    {
                        chrArray = new char[] { '\u005F' };
                        string[] strArrays2 = sortField.Split(chrArray);
                        if ((int)strArrays2.Length == 2 && strArrays2[0].Trim().ToLower() == str38.Trim().ToLower())
                        {
                            if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "d")
                            {
                                sortField = string.Concat(sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "_", strArrays2[1]);
                            }
                            else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "e")
                            {
                                screenName = new string[] { "[", sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "_", strArrays2[1], "]" };
                                sortField = string.Concat(screenName);
                            }
                        }
                    }
                    else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "d")
                    {
                        sortField = sqlDataReader1["databasefieldname"].ToString().ToLower().Trim();
                    }
                    else if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() == "e")
                    {
                        sortField = string.Concat("[", sqlDataReader1["databasefieldname"].ToString().ToLower().Trim(), "]");
                    }
                    string str39 = sqlDataReader1["inputtype"].ToString().Trim();
                    int num1 = int.Parse(sqlDataReader1["customizeid"].ToString().Trim());
                    int num2 = 0;
                    if (sqlDataReader1["fieldtype"].ToString().ToLower().Trim() != "e")
                    {
                        if (str11.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 0;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str11, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str11, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str11, " as '", str38, "',"));
                            }
                            else
                            {
                                string str40 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str40.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str11, companyId, userId, strArrays1[num2], str39, str38), " as ", str11, ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str11, " as '", empty11, "',"));
                            }
                        }
                        if (str12.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 1;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str12, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str12, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str12, " as '", str38, "',"));
                            }
                            else
                            {
                                string str41 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str41.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str12, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str12, " as '", empty11, "',"));
                            }
                        }
                        if (str13.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 2;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str13, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str13, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str13, " as '", str38, "',"));
                            }
                            else
                            {
                                string str42 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str42.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str13, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str13, " as '", empty11, "',"));
                            }
                        }
                        if (str14.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 3;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str14, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str14, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str14, " as '", str38, "',"));
                            }
                            else
                            {
                                string str43 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str43.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str14, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str14, " as '", empty11, "',"));
                            }
                        }
                        if (str15.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 4;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str15, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str15, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str15, " as '", str38, "',"));
                            }
                            else
                            {
                                string str44 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str44.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str15, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str15, " as '", empty11, "',"));
                            }
                        }
                        if (str16.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 5;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str16, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str16, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str16, " as '", str38, "',"));
                            }
                            else
                            {
                                string str45 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str45.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str16, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str16, " as '", empty11, "',"));
                            }
                        }
                        if (str17.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 6;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str17, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str17, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str17, " as '", str38, "',"));
                            }
                            else
                            {
                                string str46 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str46.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str17, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str17, " as '", empty11, "',"));
                            }
                        }
                        if (str18.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 7;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str18, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str18, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str18, " as '", str38, "',"));
                            }
                            else
                            {
                                string str47 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str47.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str18, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str18, " as '", empty11, "',"));
                            }
                        }
                        if (str19.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 8;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str19, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str19, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str19, " as '", str38, "',"));
                            }
                            else
                            {
                                string str48 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str48.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str19, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str19, " as '", empty11, "',"));
                            }
                        }
                        if (str20.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 9;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str20, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str20, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str20, " as '", str38, "',"));
                            }
                            else
                            {
                                string str49 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str49.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str20, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str20, " as '", empty11, "',"));
                            }
                        }
                        if (str21.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 10;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat(str21, " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str21, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(sqlDataReader1["databasefieldname"].ToString(), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str21, " as '", str38, "',"));
                            }
                            else
                            {
                                string str50 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str50.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat(strArrays1[num2], " ,"));
                                stringBuilder3.Append(string.Concat(base.fieldElement_US_Campaign(str21, companyId, userId, strArrays1[num2], str39, str38), ","));
                                stringBuilder1.Append(this.tempTableCreateField(strArrays1[num2], sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(str21, " as '", empty11, "',"));
                            }
                        }
                    }
                    else
                    {
                        if (str11.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 0;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str11, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, string.Concat("[", str11, "]"), str39), " as '", base.returnMyCurrency(str11, companyId, userId, string.Concat("[", str11, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str51 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str51.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str11, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str11, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str12.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 1;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str12, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, string.Concat("[", str12, "]"), str39), " as '", base.returnMyCurrency(str12, companyId, userId, string.Concat("[", str12, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str52 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str52.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str12, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str12, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str13.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 2;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str13, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, string.Concat("[", str13, "]"), str39), " as '", base.returnMyCurrency(str13, companyId, userId, string.Concat("[", str13, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str53 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str53.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str13, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str13, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str14.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 3;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str14, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, string.Concat("[", str14, "]"), str39), " as '", base.returnMyCurrency(str14, companyId, userId, string.Concat("[", str14, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str54 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str54.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str14, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str14, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str15.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 4;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str15, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, string.Concat("[", str15, "]"), str39), " as '", base.returnMyCurrency(str15, companyId, userId, string.Concat("[", str15, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str55 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str55.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str15, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str15, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str16.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 5;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str16, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, string.Concat("[", str16, "]"), str39), " as '", base.returnMyCurrency(str16, companyId, userId, string.Concat("[", str16, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str56 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str56.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str16, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str16, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str17.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 6;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str17, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, string.Concat("[", str17, "]"), str39), " as '", base.returnMyCurrency(str17, companyId, userId, string.Concat("[", str17, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str57 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str57.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str17, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str17, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str18.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 7;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str18, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, string.Concat("[", str18, "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", str18, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str58 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str58.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str18, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str19.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 8;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str19, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, string.Concat("[", str19, "]"), str39), " as '", base.returnMyCurrency(str19, companyId, userId, string.Concat("[", str19, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str59 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str59.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str19, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str18, companyId, userId, string.Concat("[", str18, "]"), str39, empty11), "',"));
                            }
                        }
                        if (str20.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 9;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str20, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, string.Concat("[", str20, "]"), str39), " as '", base.returnMyCurrency(str20, companyId, userId, string.Concat("[", str20, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str60 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str60.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str20, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str20, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                        if (str21.ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                        {
                            num2 = 10;
                            if (!flagArray[num2])
                            {
                                stringBuilder2.Append(string.Concat("[", str21, "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", sqlDataReader1["databasefieldname"].ToString(), "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, string.Concat("[", str21, "]"), str39), " as '", base.returnMyCurrency(str21, companyId, userId, string.Concat("[", str21, "]"), str39, str38), "',"));
                            }
                            else
                            {
                                string str61 = strArrays1[num2];
                                chrArray = new char[] { '\u005F' };
                                strArrays = str61.Split(chrArray);
                                empty11 = string.Concat(str38, "_", strArrays[1]);
                                stringBuilder2.Append(string.Concat("[", strArrays1[num2], "] ,"));
                                item = new object[] { "( select cast(customizedvalue as nvarchar(4000)) from ", empty1, " where ", str1, "=", sqlDataReader1["CustomizeID"], " and ", str, "=L.", str, ") ," };
                                stringBuilder3.Append(string.Concat(item));
                                stringBuilder1.Append(this.tempTableCreateField(string.Concat("[", strArrays1[num2], "]"), sqlDataReader1["datatype"].ToString()));
                                stringBuilder.Append(string.Concat(base.fieldElement_US(str21, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39), " as '", base.returnMyCurrency(str21, companyId, userId, string.Concat("[", strArrays1[num2], "]"), str39, empty11), "',"));
                            }
                        }
                    }
                    if (str22.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition = base.getSearchCondition(companyId, userId, str22, str27, str32, str37, str39, num1, pg);
                    }
                    if (str23.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition1 = base.getSearchCondition(companyId, userId, str23, str28, str33, str37, str39, num1, pg);
                    }
                    if (str24.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition2 = base.getSearchCondition(companyId, userId, str24, str29, str34, str37, str39, num1, pg);
                    }
                    if (str25.ToString().ToLower().Trim() == sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        searchCondition3 = base.getSearchCondition(companyId, userId, str25, str30, str35, str37, str39, num1, pg);
                    }
                    if (str26.ToString().ToLower().Trim() != sqlDataReader1["databasefieldname"].ToString().ToLower().Trim())
                    {
                        continue;
                    }
                    searchCondition4 = base.getSearchCondition(companyId, userId, str26, str31, str36, str37, str39, num1, pg);
                }
                _commonClass1.closeConnection();
                empty8 = "";
                screenName = new string[] { searchCondition, searchCondition1, searchCondition2, searchCondition3, searchCondition4 };
                empty8 = string.Concat(screenName);
                empty7 = (stringBuilder.ToString().Length == 0 ? stringBuilder.ToString() : stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1));
                empty9 = (stringBuilder1.ToString().Length == 0 ? stringBuilder1.ToString() : stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1));
                str9 = (stringBuilder2.ToString().Length == 0 ? stringBuilder2.ToString() : stringBuilder2.ToString().Substring(0, stringBuilder2.ToString().Length - 1));
                empty10 = (stringBuilder3.ToString().Length == 0 ? stringBuilder3.ToString() : stringBuilder3.ToString().Substring(0, stringBuilder3.ToString().Length - 1));
            }
            string str62 = "";
            if (empty.ToLower().Trim() == "tb_lead")
            {
                str62 = " and L.isconverted = 0 ";
            }
            string str63 = base.CheckViewRight(pg, adminrights, companyId, userId);
            int num3 = 0;
            int pageSize = 0;
            string empty12 = string.Empty;
            string empty13 = string.Empty;
            StringBuilder stringBuilder4 = new StringBuilder();
            if (pg.ToLower() != "campaign")
            {
                num3 = intStartIndex;
                pageSize = PageSize;
            }
            else if (intStartIndex != 1)
            {
                num3 = intStartIndex * PageSize - PageSize + 1;
                pageSize = num3 + PageSize - 1;
            }
            else
            {
                num3 = 1;
                pageSize = PageSize;
            }
            chrArray = new char[] { ',' };
            string[] strArrays3 = empty9.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays4 = str9.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays5 = empty10.Split(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays6 = empty7.Split(chrArray);
            empty9 = string.Empty;
            str9 = string.Empty;
            empty10 = string.Empty;
            empty7 = string.Empty;
            int num4 = 0;
            for (int l = 0; l < this.arrInUserField.Count; l++)
            {
                for (int m = 0; m < (int)strArrays3.Length; m++)
                {
                    if (this.arrInUserField[l].ToString().ToLower().Trim() == strArrays4[m].ToString().Trim().ToLower())
                    {
                        empty9 = string.Concat(empty9, strArrays3[m].ToString().Replace('ç', ','), ",");
                        str9 = string.Concat(str9, strArrays4[m].ToString(), ",");
                        empty10 = string.Concat(empty10, strArrays5[m].ToString(), ",");
                        empty7 = string.Concat(empty7, strArrays6[m].ToString().Replace('Ç', ','), ",");
                        num4++;
                    }
                }
            }
            if ((int)strArrays4.Length > num4 + 1)
            {
                IsMsg = "Yes";
            }
            if (empty9.Length > 0)
            {
                empty9 = empty9.Substring(0, empty9.Length - 1);
                str9 = str9.Substring(0, str9.Length - 1);
                empty10 = empty10.Substring(0, empty10.Length - 1);
                empty7 = empty7.Substring(0, empty7.Length - 1);
            }
            if (empty9.Length <= 0)
            {
                screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT) Insert Into #PageIndex  (", str, ")" };
                stringBuilder4.Append(string.Concat(screenName));
                if (pg.ToLower() != "client")
                {
                    item = new object[] { " Select ", str, " FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else
                {
                    item = new object[] { " Select ", str, " FROM ", empty, "  L where L.isdelete=0 and L.companytype='", this.CompanyType, "' and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                empty7 = string.Concat("select  ", str, " as ID from #PageIndex ");
            }
            else
            {
                if (pg.ToLower() == "client")
                {
                    screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT,  ", empty9, ",  name1 nvarchar(max) ) Insert Into #PageIndex  (", str, ",", str9, ",name1)" };
                    stringBuilder4.Append(string.Concat(screenName));
                }
                else if (pg.ToLower() != "campaign")
                {
                    screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT,  ", empty9, " ) Insert Into #PageIndex  (", str, ",", str9, ")" };
                    stringBuilder4.Append(string.Concat(screenName));
                }
                else
                {
                    screenName = new string[] { "CREATE TABLE #PageIndex( IndexId INT IDENTITY (1, 1) NOT NULL, ", str, " INT,  ", empty9, " ) Insert Into #PageIndex  (", str, ",", str9, ")" };
                    stringBuilder4.Append(string.Concat(screenName));
                }
                if (pg.ToLower() == "client")
                {
                    item = new object[] { " Select ", str, ",", empty10, ",clientname FROM ", empty, "  L where L.isdelete=0 and L.companytype='", this.CompanyType, "' and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else if (pg.ToLower() != "campaign")
                {
                    item = new object[] { " Select ", str, ",", empty10, " FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                else
                {
                    item = new object[] { " Select ", str, ",", empty10, " FROM ", empty, "  L where L.isdelete=0 and L.companyid=", companyId, str62, str63, "  ", letter1, " ", empty8, " order by L.", empty5, "  ", str5, " " };
                    empty12 = stringBuilder4.Append(string.Concat(item)).ToString();
                }
                if (pg.ToLower() == "client")
                {
                    screenName = new string[] { "select  ", empty7, " ,name1 as [Client Name],", str, " as ID from #PageIndex " };
                    empty7 = string.Concat(screenName);
                }
                else if (pg.ToLower() != "campaign")
                {
                    screenName = new string[] { "select  ", empty7, " ,", str, " as ID from #PageIndex " };
                    empty7 = string.Concat(screenName);
                }
                else
                {
                    screenName = new string[] { "select  ", empty7, " ,", str, " as ID from #PageIndex " };
                    empty7 = string.Concat(screenName);
                }
            }
            if (pg.ToLower() == "campaign")
            {
                item = new object[] { empty12, empty7, " Where IndexID >= ", num3, " and IndexID <= ", pageSize };
                empty6 = string.Concat(item);
            }
            else if (sortField.Trim().Length <= 2 || sortField.Trim().Contains(Convert.ToString(this.Session["currency"])))
            {
                item = new object[] { empty12, empty7, " Where IndexID > ", num3, " and IndexID < ", num3 + pageSize + 1 };
                empty6 = string.Concat(item);
            }
            else
            {
                item = new object[] { empty12, empty7, " Where IndexID > ", num3, " and IndexID < ", num3 + pageSize + 1, " order by ", sortField.Trim(), " " };
                empty6 = string.Concat(item);
            }
            empty6 = string.Concat(empty6, ";", " select count(*) as totalrecord from #PageIndex ");
            return empty6;
        }

        public string returnFinalQuery_client(int companyId, int userId, string sortField, string letter1, int intStartIndex, int PageSize, string pg, int viewValueId, int adminrights, ref string IsMsg, string companytype)
        {
            this.CompanyType = companytype;
            return this.returnFinalQuery(companyId, userId, sortField, letter1, intStartIndex, PageSize, pg, viewValueId, adminrights, ref IsMsg);
        }


        public string BuildWhereClause(string olderThanPeriod, string field, string page)
        {
            //Dictionary<string, string> fieldMap=new Dictionary<string, string>();
            //if (page == "estimate")
            //{
            //    // Map frontend field names to database column names
            //     fieldMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            //        {
            //            //{"ArtworkDate", "EstimatedArtwork"},
            //            //{"ProofDate", "EstProofDate"},
            //            //{"ApprovalDate", "EstApprovalDate"},
            //            //{"ProductionDate", "EstProductionDate"},
            //            //{"CompletionDate", "EstCompletionDate"},
            //            //{"DeliveryDate", "EstimatedDelivery"},
            //            //{"EstimateDate", "EstimateDate"}

            //        };
            //}
            //if (!fieldMap.ContainsKey(field))
            //    return "";

            if (field.ToLower().Contains("none") || String.IsNullOrEmpty(field))
                return "";

            // Get the correct database column name
            string dbField = field;// fieldMap.ContainsKey(field) ? fieldMap[field] : "EstApprovalDate"; // Default field

            string dateCondition = "";

            switch (olderThanPeriod.ToUpper())
            {
             

                // Month cases
                case "1M":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(month, -1, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;
                case "3M":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(month, -3, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;
                case "6M":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(month, -6, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;

                // Year cases
                case "1Y":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(year, -1, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;
                case "2Y":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(year, -2, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;
                case "3Y":
                    dateCondition = $" and CONVERT(date, {dbField}) >= CONVERT(date, DATEADD(year, -3, GETDATE())) " +
                                   $"AND CONVERT(date, {dbField}) <= CONVERT(date, GETDATE())";
                    break;

                default:
                    dateCondition = ""; // Default to no date filtering
                    break;
            }

            return dateCondition;
        }

        public string ReturnFinalQueryForNewCustomView(int CompanyID, int UserID, int PageSize, int PageNumber, string SectionName, int ViewID, string SortedBy, string SortedDirection, string para)
        {
            char[] chrArray;
            string[] strArrays;
            object[] companyID;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            bool flag = EstimatesBasePage.Views_IsItemDetailsSelected((long)ViewID);
            string str5 = "EstimateItemID";
            string str6 = "Cust_ID";
            string str7 = "InvAddress_ID";
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            bool isSortingOrder = false;
            if (SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "estimate")
            {
                str5 = "L.EstimateItemID";
            }
            foreach (DataRow row in SettingsBasePage.settings_regionalsettings_select(CompanyID).Rows)
            {
                empty7 = row["DateFormat"].ToString();
            }
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows)
            {
                isSortingOrder = Convert.ToBoolean(row["AllowSorting"]);
            }
            if (SectionName.Trim().ToLower() == "estimate")
            {
                str1 = "EstimateID";
                str2 = "";
                empty2 = "VW_Estimate_View";
                if (flag)
                {
                    str1 = "EstimateItemID";
                    str2 = "EstimateID";
                    empty6 = "JOBID";
                    empty2 = "VW_Estimate_View_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            if (SectionName.Trim().ToLower() == "proof")
            {
                str1 = "EstimateID";
                str2 = "";
                empty2 = "VW_Proof_View";
                //if (flag)
                //{
                //    str1 = "EstimateItemID";
                //    str2 = "EstimateID";
                //    empty6 = "JOBID";
                //    empty2 = "VW_Estimate_View_SplitItem";
                //}
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }

            else if (SectionName.Trim().ToLower() == "job")
            {
                str1 = "JobID";
                str2 = "L.EstimateID";
                empty2 = "VW_Job_View";
                if (flag)
                {
                    empty2 = "VW_Job_View_splititem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "invoice")
            {
                str1 = "InvoiceID";
                str2 = "EstimateID";
                empty2 = "VW_Invoice_View";
                if (flag)
                {
                    empty2 = "VW_Invoice_View_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "purchase")
            {
                viewname = SectionName.Trim().ToLower();
                str1 = "PurchaseID";
                empty2 = "VW_Purchase_View";
                if (flag)
                {
                    empty2 = "vw_purchase_view_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else  if (SectionName.Trim().ToLower() == "deliverynote")
            {
                str1 = "DeliveryID";
                empty2 = "VW_delivery_View";
                BaseClass baseClass = new BaseClass();
                if (baseClass.ReturnRoles_Privileges_Others("showrecords").ToLower() != "type")
                {
                    str4 = "";
                }
                else
                {
                    string str8 = baseClass.ReturnRoles_Privileges_Others("companytype");
                    if (str8 == null || !(str8 != ""))
                    {
                        str4 = "";
                    }
                    else
                    {
                        str8 = str8.Substring(0, str8.Length - 1);
                        str4 = string.Concat("L.TypeID like '%", str8, "%' and ");
                    }
                }
            }
            else if (SectionName.Trim().ToLower() == "store")
            {
                str1 = "FinishedGoodsID";
                empty2 = "VW_store_View";
            }
            else if (SectionName.Trim().ToLower() == "item")
            {
                str1 = "FinishedGoodsID";
                empty2 = "VW_item_View";
            }
            else if (SectionName.Trim().ToLower() == "inventory")
            {
                str1 = "InventoryID";
                empty2 = "VW_inventory_View";
            }
            else if (SectionName.Trim().ToLower() == "customer")
            {
                str1 = "ClientID";
                empty2 = "VW_client_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "supplier")
            {
                str1 = "ClientID";
                empty2 = "VW_supplier_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "prospect")
            {
                str1 = "ClientID";
                empty2 = "VW_prospect_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "webstoreorder")
            {
                str1 = "OrderID";
                empty2 = "VW_Order_View";
                empty6 = "JOBID";
                if (flag)
                {
                    empty2 = "VW_Order_View_splititem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
                if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows[0]["AllowUnApprovedOrder"]))
                {
                    empty1 = "and APPROVED !='Awaiting Approval' AND  APPROVED !='REJECTED' ";
                }
            }
            else if (SectionName.Trim().ToLower() == "productcatalogue")
            {
                str1 = "PriceCatalogueID";
                //empty2 = "VW_productcatalogue_View";
                empty2 = "VW_Productcatalogue_View_multiple_categories";
            }
            string[] strArrays1 = new string[10];
            string[] strArrays2 = new string[10];
            string[] strArrays3 = new string[10];
            string[] strArrays4 = new string[10];
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string olderThanField = string.Empty;
            string olderThanPeriod = string.Empty;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageName", SectionName.Trim().ToLower());
            string sortedBy = string.Empty;
            string sortedDirection = string.Empty;
            string sortedBy2 = string.Empty;
            string sortedDirection2 = string.Empty;
            string sortedBy3 = string.Empty;
            string sortedDirection3 = string.Empty;
            string sortedBy4 = string.Empty;
            string sortedDirection4 = string.Empty;
            string fsortedBy2 = string.Empty;
            string fsortedBy3 = string.Empty;
            string fsortedBy4 = string.Empty;
            bool flag1 = false;
            string empty11 = string.Empty;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["ColumnNames"].ToString().Length <= 0)
                {
                    continue;
                }
                if (SectionName.Trim().ToLower() == "customer")
                {
                    if (sqlDataReader["CustomerType"].ToString().ToLower() == "estore customer")
                    {
                        empty11 = string.Concat(empty11, " and (IsFromWebStore = 'store' or AccountID > 0)");
                    }
                    else if (sqlDataReader["CustomerType"].ToString().ToLower() == "non estore customer")
                    {
                        empty11 = string.Concat(empty11, " and (IsFromWebStore != 'store' and AccountID = 0)");
                    }
                }
                string str11 = sqlDataReader["ColumnNames"].ToString().Substring(0, sqlDataReader["ColumnNames"].ToString().Length - 1);
                chrArray = new char[] { ',' };
                this.DisplayColumns = str11.Split(chrArray);
                this.DisplayColumns = this.RemoveDuplicates(this.DisplayColumns);
                if (SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "estimate")
                {
                    strArrays1[0] = (sqlDataReader["condition1"] == DBNull.Value ? "" : sqlDataReader["condition1"].ToString())
                    .Replace("InventoryCode", "inventorycode")
                    .Replace("StatusID", "L.StatusID")
                    .Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[1] = sqlDataReader["condition2"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[2] = sqlDataReader["condition3"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[3] = sqlDataReader["condition4"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[4] = sqlDataReader["condition5"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[5] = sqlDataReader["condition6"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[6] = sqlDataReader["condition7"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[7] = sqlDataReader["condition8"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[8] = sqlDataReader["condition9"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                    strArrays1[9] = sqlDataReader["condition10"].ToString().Replace("StatusID", "L.StatusID").Replace("ProofStatus", "pd.ProofItemStatus");
                }
                else
                {
                    strArrays1[0] = sqlDataReader["condition1"].ToString().Replace("InventoryCode", "inventorycode");
                    strArrays1[1] = sqlDataReader["condition2"].ToString();
                    strArrays1[2] = sqlDataReader["condition3"].ToString();
                    strArrays1[3] = sqlDataReader["condition4"].ToString();
                    strArrays1[4] = sqlDataReader["condition5"].ToString();
                    strArrays1[5] = sqlDataReader["condition6"].ToString();
                    strArrays1[6] = sqlDataReader["condition7"].ToString();
                    strArrays1[7] = sqlDataReader["condition8"].ToString();
                    strArrays1[8] = sqlDataReader["condition9"].ToString();
                    strArrays1[9] = sqlDataReader["condition10"].ToString();
                }
                strArrays2[0] = sqlDataReader["operator1"].ToString();
                strArrays2[1] = sqlDataReader["operator2"].ToString();
                strArrays2[2] = sqlDataReader["operator3"].ToString();
                strArrays2[3] = sqlDataReader["operator4"].ToString();
                strArrays2[4] = sqlDataReader["operator5"].ToString();
                strArrays2[5] = sqlDataReader["operator6"].ToString();
                strArrays2[6] = sqlDataReader["operator7"].ToString();
                strArrays2[7] = sqlDataReader["operator8"].ToString();
                strArrays2[8] = sqlDataReader["operator9"].ToString();
                strArrays2[9] = sqlDataReader["operator10"].ToString();
                strArrays3[0] = sqlDataReader["value1"].ToString();
                strArrays3[1] = sqlDataReader["value2"].ToString();
                strArrays3[2] = sqlDataReader["value3"].ToString();
                strArrays3[3] = sqlDataReader["value4"].ToString();
                strArrays3[4] = sqlDataReader["value5"].ToString();
                strArrays3[5] = sqlDataReader["value6"].ToString();
                strArrays3[6] = sqlDataReader["value7"].ToString();
                strArrays3[7] = sqlDataReader["value8"].ToString();
                strArrays3[8] = sqlDataReader["value9"].ToString();
                strArrays3[9] = sqlDataReader["value10"].ToString();
                strArrays4[0] = sqlDataReader["CondnalOpertr1"].ToString();
                strArrays4[1] = sqlDataReader["CondnalOpertr2"].ToString();
                strArrays4[2] = sqlDataReader["CondnalOpertr3"].ToString();
                strArrays4[3] = sqlDataReader["CondnalOpertr4"].ToString();
                strArrays4[4] = sqlDataReader["CondnalOpertr5"].ToString();
                strArrays4[5] = sqlDataReader["CondnalOpertr6"].ToString();
                strArrays4[6] = sqlDataReader["CondnalOpertr7"].ToString();
                strArrays4[7] = sqlDataReader["CondnalOpertr8"].ToString();
                strArrays4[8] = sqlDataReader["CondnalOpertr9"].ToString();
                strArrays4[9] = "";
                flag1 = Convert.ToBoolean(sqlDataReader["isShowAllRecords"]);
                empty5 = sqlDataReader["RecordsToDisplay"].ToString();
                if (sqlDataReader["SortedBy"].ToString().Trim().ToLower() == "none")
                {
                    sortedBy = str1;
                    sortedDirection = "desc";
                }
                else
                {
                    sortedBy = SortedBy.ToString();
                    sortedDirection = SortedDirection.ToString();
                }

                sortedBy2 = sqlDataReader["sortedBy2"].ToString();
                sortedBy3 = sqlDataReader["sortedBy3"].ToString();
                sortedDirection2 = sqlDataReader["SortDirection2"].ToString();
                sortedDirection3 = sqlDataReader["SortDirection3"].ToString();
                sortedBy4 = sqlDataReader["sortedBy4"].ToString();
                sortedDirection4 = sqlDataReader["SortDirection4"].ToString();
              

                if (!string.IsNullOrEmpty(sortedBy2) && !sortedBy2.ToLower().Contains("none"))
                {
                    fsortedBy2 = String.Concat(",L.", sortedBy2," ", sortedDirection2);
                }
                if (!string.IsNullOrEmpty(sortedBy3) && !sortedBy3.ToLower().Contains("none"))
                {
                    fsortedBy3 = String.Concat(",L.", sortedBy3," ", sortedDirection3);
                }
                if (!string.IsNullOrEmpty(sortedBy4) && !sortedBy4.ToLower().Contains("none"))
                {
                    fsortedBy4 = String.Concat(",L.", sortedBy4, " ", sortedDirection4);
                }

                olderThanField = sqlDataReader["FilterDateType"].ToString();
                olderThanPeriod = sqlDataReader["FilterDateRange"].ToString();
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
            string empty12 = string.Empty;
            if (SectionName.Trim().ToLower() == "estimate" || SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "invoice" || SectionName.Trim().ToLower() == "webstoreorder" || SectionName.Trim().ToLower() == "purchase" || SectionName.Trim().ToLower() == "deliverynote" || SectionName.Trim().ToLower() == "inventory" || SectionName.Trim().ToLower() == "proof")
            {
                if(SectionName.Trim().ToLower() == "proof")
                {
                    if (empty5 == "Live")
                    {
                        empty12 = " and IsArchived=0 ";
                    }
                    else if (empty5 == "Archive")
                    {
                        empty12 = " and IsArchived=1 ";
                    }
                }
                else
                {
                    if (empty5 == "Live")
                    {
                        empty12 = " and IsArchive=0 ";
                    }
                    else if (empty5 == "Archive")
                    {
                        empty12 = " and IsArchive=1 ";
                    }
                }
                
            }
            string str12 = string.Empty;
            string empty13 = string.Empty;
            string finalolderthan = string.Empty;
            str12 = this.EstimateSearchCondition(strArrays4, strArrays1, strArrays2, strArrays3, flag1);
            finalolderthan = BuildWhereClause(olderThanPeriod, olderThanField, SectionName.Trim().ToLower());
            str12 = string.Concat(str12, empty11, finalolderthan);
            if (para.Trim().ToLower() != "")
            {
                if (para.Trim().ToLower() == "number")
                {
                    empty13 = string.Concat(" and ", SortedBy.ToString(), " like '[0-9]%'");
                    str12 = string.Concat(str12, empty13);
                }
                else if (para.Trim().ToLower() != "false")
                {
                    empty13 = string.Concat(" and ", para);
                    str12 = string.Concat(str12, empty13);
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            if (SectionName.Trim().ToLower() == "estimate")
            {
                if (this.DisplayColumns == null)
                {
                    string str13 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str13, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int i = 0; i < (int)this.DisplayColumns.Length; i++)
                    {
                        string str15 = this.DisplayColumns[i].ToString();
                        if (str15.Trim().ToLower() == "estimatenumber")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else if (str15.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(L.", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "validfor")
                        {
                            strArrays = new string[] { "cast(", str15, " as int) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "isforinvoice")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else if (str15.Trim().ToLower() == "estimatevalue")
                        {
                            strArrays = new string[] { "cast(", str15, " as decimal(28,10)) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str15, " as decimal(28,10)) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "company")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "priority")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "header")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "footer")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "paymentterms")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "costcentre")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "companyemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "contactemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofstatus")
                        
                        {
                            strArrays = new string[] { "Replace(Replace(pd.ProofItemStatus,'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(L.", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatedate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "artworkdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] {"CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "approvaldate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "productiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str15.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        else if (str15.Trim().ToLower() != "completiondate")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("EmailCount,");
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                    stringBuilder.Append("L.StatusColorCode,");
                    stringBuilder.Append("itemStatusColorCode,");
                    stringBuilder.Append("custid,");

                }
            }
            if (SectionName.Trim().ToLower() == "proof")
            {
                if (this.DisplayColumns == null)
                {
                    string str13 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str13, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int i = 0; i < (int)this.DisplayColumns.Length; i++)
                    {
                        string str15 = this.DisplayColumns[i].ToString();
                        if (str15.Trim().ToLower() == "estimatenumber")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else if (str15.Trim().ToLower() == "proofnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "itemtitlevalue")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "filestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "creationdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "file")
                        {
                            strArrays = new string[] { "Replace(Replace([", str15, "],'%27',''''),'%22','\"') as '", str15, "'," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "jobnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "contactname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "approvalstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "actualproofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "actualproofapprovaldate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofcomments")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofitemstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "artworkdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str15.Trim().ToLower() == "jobid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "salespersonid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "cust_id")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "archive")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str15.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str15.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        else if (str15.Trim().ToLower() == "productiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty7, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str15.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "CASE WHEN ", str15, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str15, ",'", empty7, "') END as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                    }
                    stringBuilder.Append("StatusColorCode,");
                    //stringBuilder.Append("EmailCount,");
                    //stringBuilder.Append("ErrorCount,");
                    //stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    //stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    //stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                }
            }

            if (SectionName.Trim().ToLower() == "job")
            {
                if (this.DisplayColumns == null)
                {
                    string str16 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str16, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int j = 0; j < (int)this.DisplayColumns.Length; j++)
                    {
                        string str18 = this.DisplayColumns[j].ToString();
                        if (str18.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str18, ","));
                        }
                        else if (str18.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "company")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "header")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "footer")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            strArrays = new string[] { "Replace(Replace(", "SalesPersonID", ",'%27',''''),'%22','\"') as ", "SalesPersonID", "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "jobstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(L.", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatevalue")
                        {
                            strArrays = new string[] { "cast(", str18, " as decimal(28,10)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str18, " as decimal(28,10)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "isproformainvoice")
                        {
                            strArrays = new string[] { "cast(", str18, " as nvarchar(1)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "priority")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customerordernumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "paymentterms")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "costcentre")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemmaterial")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "orderedheight")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "orderedwidth")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemdescription")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemcolour")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemsize")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemartwork")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemdelivery")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "deliveryaddresslabel")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemproofs")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itempacking")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemnotes")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemterms_instructions")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "companyemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "contactemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "mainItemsupplier")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "converteddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimateddeliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "actualdeliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "productiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "completiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "approvaldate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str18.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str18.Trim().ToLower() == "jobdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "artworkdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty7, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str18.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str18.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        //Add custom description fields 1-5 to jobs
                        else if (str18.Contains("CustomDescription1"))
                        {
                            string cusdeshead1 = string.Empty;
                            cusdeshead1 = str18.Replace("CustomDescription1 AS", string.Empty);
                            cusdeshead1 = cusdeshead1.Replace("[", string.Empty).Replace("]", string.Empty);
                            Session["CustomDescription1"] = null;
                            Session["CustomDescription1"] = cusdeshead1;
                            stringBuilder.Append(string.Concat("CustomDescription1 as CustomDescription1", ","));
                        }
                        else if (str18.Contains("CustomDescription2"))
                        {
                            string cusdeshead2 = string.Empty;
                            cusdeshead2 = str18.Replace("CustomDescription2 AS", string.Empty);
                            cusdeshead2 = cusdeshead2.Replace("[", string.Empty).Replace("]", string.Empty);
                            Session["CustomDescription2"] = null;
                            Session["CustomDescription2"] = cusdeshead2;
                            stringBuilder.Append(string.Concat("CustomDescription2 as CustomDescription2", ","));
                        }
                        else if (str18.Contains("CustomDescription3"))
                        {
                            string cusdeshead3 = string.Empty;
                            cusdeshead3 = str18.Replace("CustomDescription3 AS", string.Empty);
                            cusdeshead3 = cusdeshead3.Replace("[", string.Empty).Replace("]", string.Empty);
                            Session["CustomDescription3"] = null;
                            Session["CustomDescription3"] = cusdeshead3;
                            stringBuilder.Append(string.Concat("CustomDescription3 as CustomDescription3", ","));
                        }
                        else if (str18.Contains("CustomDescription4"))
                        {
                            string cusdeshead4 = string.Empty;
                            cusdeshead4 = str18.Replace("CustomDescription4 AS", string.Empty);
                            cusdeshead4 = cusdeshead4.Replace("[", string.Empty).Replace("]", string.Empty);
                            Session["CustomDescription4"] = null;
                            Session["CustomDescription4"] = cusdeshead4;
                            stringBuilder.Append(string.Concat("CustomDescription4 as CustomDescription4", ","));
                        }
                        else if (str18.Contains("CustomDescription5"))
                        {
                            string cusdeshead5 = string.Empty;
                            cusdeshead5 = str18.Replace("CustomDescription5 AS", string.Empty);
                            cusdeshead5 = cusdeshead5.Replace("[", string.Empty).Replace("]", string.Empty);
                            Session["CustomDescription5"] = null;
                            Session["CustomDescription5"] = cusdeshead5;
                            stringBuilder.Append(string.Concat("CustomDescription5 as CustomDescription5", ","));
                        }
                        else if (str18.Trim().ToLower() != "pressname")
                        {
                            stringBuilder.Append(string.Concat(str18, ","));
                        }
                        else if (str18.Trim().ToLower() == "proofstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));

                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    stringBuilder.Append("cast(HasReplenishItem as int) as HasReplenishItem,");
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                    stringBuilder.Append("PaymentType,");
                    stringBuilder.Append("L.StatusColorCode,");
                    stringBuilder.Append("itemStatusColorCode,");
                    stringBuilder.Append("custid,");
                }
            }
            if (SectionName.Trim().ToLower() == "invoice")
            {
                if (this.DisplayColumns == null)
                {
                    string str19 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str19, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int k = 0; k < (int)this.DisplayColumns.Length; k++)
                    {
                        string str21 = this.DisplayColumns[k].ToString();
                        if (str21.Trim().ToLower() == "invoicenumber")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoicestatus")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "completiondate")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "priority")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoicevalue")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceoutstanding")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceamountpaid")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty7, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "paymentdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty7, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceduedate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty7, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "completiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty7, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty7, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str21.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str21, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str21, ",'", empty7, "') END as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str21, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str21, ",'", empty7, "') END as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str21, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str21, ",'", empty7, "') END as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str21, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str21, ",'", empty7, "') END as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "CASE WHEN ", str21, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str21, ",'", empty7, "') END as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str21.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "department")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemdescription")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemcolour")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemsize")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemartwork")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemdelivery")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "deliveryaddresslabel")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemproofs")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itempacking")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemnotes")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemterms_instructions")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str21.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str21.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        else if (str21.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() != "address5")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                    stringBuilder.Append("PaymentType,");
                    stringBuilder.Append("StatusColorCode,");
                    stringBuilder.Append("jobStatusColCode,");

                    stringBuilder.Append("custid,");
                }
            }
            if (SectionName.Trim().ToLower() == "purchase")
            {
                if (this.DisplayColumns == null)
                {
                    string str22 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str22, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int l = 0; l < (int)this.DisplayColumns.Length; l++)
                    {
                        string str24 = this.DisplayColumns[l].ToString();
                        if (str24.Trim().ToLower() == "PONO")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "SupplierName")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "PODate")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "GoodsReceived")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "status")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str24, " as decimal(28,10)) as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "poprice")
                        {
                            strArrays = new string[] { "cast(", str24, " as decimal(28,10)) as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "comments")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "description")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str24, ",'", empty7, "') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str24.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str24, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str24, ",'", empty7, "') END as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str24, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str24, ",'", empty7, "') END as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str24, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str24, ",'", empty7, "') END as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str24, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str24, ",'", empty7, "') END as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "CASE WHEN ", str24, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str24, ",'", empty7, "') END as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str24.Trim().ToLower() == "supplierquotenumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "jobstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str24.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str24.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        else if (str24.Trim().ToLower() != "podate")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str24, ",'", empty7, "') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("StatusColorCode,");
                    stringBuilder.Append("custid,");
                }
            }
            if (SectionName.Trim().ToLower() == "deliverynote")
            {
                if (this.DisplayColumns == null)
                {
                    string str25 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str25, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int m = 0; m < (int)this.DisplayColumns.Length; m++)
                    {
                        string str27 = this.DisplayColumns[m].ToString();
                        if (str27.Trim().ToLower() == "deliverynumber")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else if (str27.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else if (str27.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str27, ",'", empty7, "') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str27, ",'", empty7, "') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }


                        else if (str27.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str27, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str27, ",'", empty7, "') END as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str27, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str27, ",'", empty7, "') END as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str27, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str27, ",'", empty7, "') END as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str27, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str27, ",'", empty7, "') END as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "CASE WHEN ", str27, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str27, ",'", empty7, "') END as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str27.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "status")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str27.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str27.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }

                        else if (str27.Trim().ToLower() != "orderno")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                    }
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("StatusColorCode,");
                    stringBuilder.Append("custid,");
                }
            }
            if (SectionName.Trim().ToLower() == "store")
            {
                if (this.DisplayColumns == null)
                {
                    string str28 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str28, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int n = 0; n < (int)this.DisplayColumns.Length; n++)
                    {
                        string str30 = this.DisplayColumns[n].ToString();
                        if (str30.Trim().ToLower() == "productcode")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else if (str30.Trim().ToLower() == "productname")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else if (str30.Trim().ToLower() == "instockquantity")
                        {
                            strArrays = new string[] { "cast(", str30, " as int) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str30.Trim().ToLower() == "packquantity")
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(28,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str30.Trim().ToLower() == "packcostprice")
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(28,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str30.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(28,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    //stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "item")
            {
                if (this.DisplayColumns == null)
                {
                    string str31 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str31, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int o = 0; o < (int)this.DisplayColumns.Length; o++)
                    {
                        string str33 = this.DisplayColumns[o].ToString();
                        if (str33.Trim().ToLower() == "productcode")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else if (str33.Trim().ToLower() == "productname")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else if (str33.Trim().ToLower() == "instockquantity")
                        {
                            strArrays = new string[] { "cast(", str33, " as int) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str33.Trim().ToLower() == "packquantity")
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(28,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str33.Trim().ToLower() == "packcostprice")
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(28,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str33.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(28,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                }
            }
            if (SectionName.Trim().ToLower() == "customer" || SectionName.Trim().ToLower() == "supplier" || SectionName.Trim().ToLower() == "prospect")
            {
                if (this.DisplayColumns == null)
                {
                    string str34 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str34, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int p = 0; p < (int)this.DisplayColumns.Length; p++)
                    {
                        string str36 = this.DisplayColumns[p].ToString();
                        if (str36.Trim().ToLower() == "name")
                        {
                            str36 = "[name]";
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "type")
                        {
                            str36 = "[type]";
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "businesstelephone")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "businessemail")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "businessfax")
                        {
                            str36 = "fax";
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "deparmentname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultdepartmentname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultcontactname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultcontactjobtitle1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() != "defaultcontactjobtitle2")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("AccountID,");
                    if (SectionName.Trim().ToLower() == "customer")
                    {
                        stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    }
                }
            }
            empty3 = "false";
            if (SectionName.Trim().ToLower() == "inventory")
            {
                if (this.DisplayColumns != null)
                {
                    empty3 = "true";
                }
                else
                {
                    string str37 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    str37 = string.Concat(str37, "height,stocktype,width,length,widthtype,lengthtype,papertype,packedin,packedintype,basisweight,papername,ChargableSheets,InkType,");
                    this.DisplayColumns = this.ParseDefaultViewColumns(str37, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int q = 0; q < (int)this.DisplayColumns.Length; q++)
                    {
                        string str39 = this.DisplayColumns[q].ToString();
                        if (str39.Trim().ToLower() == "inventorycode")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() == "inventoryname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "suppliername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "cost")
                        {
                            strArrays = new string[] { "cast(", str39, " as decimal(28,10)) as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "stocktype")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() == "location")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "friendlyname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "description")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str39, ",'", empty7, "') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "Archived")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str39, " as decimal(28,10)) as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                }
            }
            if (SectionName.Trim().ToLower() == "webstoreorder")
            {
                if (this.DisplayColumns == null)
                {
                    string str40 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str40, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int r = 0; r < (int)this.DisplayColumns.Length; r++)
                    {
                        string str42 = this.DisplayColumns[r].ToString();
                        if (str42.Trim().ToLower() == "ordernumber")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "clientid")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "storeuserid")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "address")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "isforinvoice")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "ordervalue")
                        {
                            strArrays = new string[] { "cast(", str42, " as decimal(28,10)) as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        //else if (str42.Trim().ToLower() == "priority")
                        //{
                        //    strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                        //    stringBuilder.Append(string.Concat(strArrays));
                        //}
                        else if (str42.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str42, " as decimal(28,10)) as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty7, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "ordereddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty7, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty7, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }


                        else if (str42.Trim().ToLower() == "customdate1")
                        {
                            strArrays = new string[] { "CASE WHEN ", str42, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str42, ",'", empty7, "') END as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customdate2")
                        {
                            strArrays = new string[] { "CASE WHEN ", str42, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str42, ",'", empty7, "') END as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customdate3")
                        {
                            strArrays = new string[] { "CASE WHEN ", str42, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str42, ",'", empty7, "') END as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customdate4")
                        {
                            strArrays = new string[] { "CASE WHEN ", str42, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str42, ",'", empty7, "') END as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customdate5")
                        {
                            strArrays = new string[] { "CASE WHEN ", str42, " IS NULL THEN '---' ELSE dbo.FormatDateTime(", str42, ",'", empty7, "') END as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str42.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                        else if (str42.Trim().ToLower() == "sincestatusupdate")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceStatusCount,");


                        }
                        else if (str42.Trim().ToLower() == "sinceemailed")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                            stringBuilder.Append("SinceEmailCount,");
                            stringBuilder.Append("isAnyEmailed,");
                        }
                        else if (str42.Trim().ToLower() != "ordertitle")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("ErrorCount,");
                    stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    stringBuilder.Append("cast(HasReplenishItem as int) as HasReplenishItem,");
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                    stringBuilder.Append("StatusColorCode,");
                    stringBuilder.Append("custid,");
                }
            }
            if (SectionName.Trim().ToLower() == "productcatalogue")
            {
                if (this.DisplayColumns == null)
                {
                    string str43 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str43, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int s = 0; s < (int)this.DisplayColumns.Length; s++)
                    {
                        string str45 = this.DisplayColumns[s].ToString();
                        if (str45.Trim().ToLower() == "categoryname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str45, ",'%27',''''),'%22','\"') as ", str45, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str45.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str45, ",'%27',''''),'%22','\"') as ", str45, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str45.Trim().ToLower() == "description")
                        {
                            strArrays = new string[] { "Replace(Replace(", str45, ",'%27',''''),'%22','\"') as ", str45, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str45.Trim().ToLower() == "salestax")
                        {
                            strArrays = new string[] { "Replace(Replace(", str45, ",'%27',''''),'%22','\"') as ", str45, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str45.Trim().ToLower() == "allocatedcustomer")
                        {
                            stringBuilder.Append(string.Concat(str45, ","));
                        }
                        else if (str45.Trim().ToLower() == "publicaccounts")
                        {
                            stringBuilder.Append(string.Concat(str45, ","));
                        }
                        else if (str45.Trim().ToLower() != "producttype")
                        {
                            stringBuilder.Append(string.Concat(str45, ","));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat(str45, ","));
                        }
                    }
                }
            }

            var dateFields = new HashSet<string>
                {
                    "sysestimatedate",  "sysdeliverydate",
                     "syscompletiondate", "sysconverteddate",
                     "syscreateddate",  "sysartworkdate",
                     "sysapprovaldate",  "sysproofdate",
                     "sysordereddate","syspodate"

                };

            string str46 = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
            string empty14 = string.Empty;
            if (SortedBy != "")
            {
                sortedBy = SortedBy;
                sortedDirection = SortedDirection;
            }
            else if (sortedBy.Trim().Length == 0)
            {
                sortedBy = str1;
                sortedDirection = "desc";
            }
            string proofStatus = string.Empty;
            if (str46.ToLower().Contains("proofstatus") && empty2 == "VW_Job_View_splititem")
            {
                str46 = str46.Replace("ProofStatus", "IsNull(pd.ProofItemStatus,'') as 'ProofStatus' ");
                proofStatus = "  left join tb_ProofItemDetails pd on pd.EstimateItemID=L.EstimateItemID  left join tb_EstimateStatus s on s.StatusID = pd.ItemStatus";
            }
            if (str46.ToLower().Contains("proofstatus") && empty2 == "VW_Estimate_View_SplitItem")
            {
                //str46 = str46.Replace("ProofStatus", "IsNull(pd.ProofItemStatus,'') as 'ProofStatus' ");
                proofStatus = "  left join tb_ProofItemDetails pd on pd.EstimateItemID=L.EstimateItemID";
            }
            if (SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "invoice")
            {
                if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "completiondate")
                {
                    sortedBy = "syscompletiondate";
                }
                else if (sortedBy.ToLower().Trim() == "converteddate")
                {
                    sortedBy = "sysconverteddate";
                }
                else if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                if (sortedBy.ToLower().Trim() == "status")
                {
                    sortedBy = "StatusID";
                }
                else if (sortedBy.ToLower().Trim() == "artworkdate")
                {
                    sortedBy = "SysArtworkDate";
                }
                else if (sortedBy.ToLower().Trim() == "approvaldate")
                {
                    sortedBy = "SysApprovalDate";
                }
                else if (sortedBy.ToLower().Trim() == "proofdate")
                {
                    sortedBy = "SysProofDate";
                }

                if (!String.IsNullOrEmpty(fsortedBy2)) {
                    if (fsortedBy2.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy2.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("completiondate"))
                    {
                        fsortedBy2.Replace("completiondate", "syscompletiondate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("converteddate"))
                    {
                        fsortedBy2.Replace("converteddate","sysconverteddate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy2.Replace("createddate", "syscreateddate");
                    }
                    if (fsortedBy2.ToLower().Trim().Contains("status"))
                    {
                        fsortedBy2.Replace("status", "StatusID");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("artworkdate"))
                    {
                        fsortedBy2.Replace("artworkdate", "SysArtworkDate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("approvaldate"))
                    {
                        fsortedBy2.Replace("approvaldate", "SysApprovalDate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("proofdate"))
                    {
                        fsortedBy2.Replace("proofdate", "SysProofDate");
                    }
                }


                if (!String.IsNullOrEmpty(fsortedBy3))
                {
                    if (fsortedBy3.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy3.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("completiondate"))
                    {
                        fsortedBy3.Replace("completiondate", "syscompletiondate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("converteddate"))
                    {
                        fsortedBy3.Replace("converteddate", "sysconverteddate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy3.Replace("createddate", "syscreateddate");
                    }
                    if (fsortedBy3.ToLower().Trim().Contains("status"))
                    {
                        fsortedBy3.Replace("status", "StatusID");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("artworkdate"))
                    {
                        fsortedBy3.Replace("artworkdate", "SysArtworkDate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("approvaldate"))
                    {
                        fsortedBy3.Replace("approvaldate", "SysApprovalDate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("proofdate"))
                    {
                        fsortedBy3.Replace("proofdate", "SysProofDate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy4))
                {
                    if (fsortedBy4.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy4.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("completiondate"))
                    {
                        fsortedBy4.Replace("completiondate", "syscompletiondate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("converteddate"))
                    {
                        fsortedBy4.Replace("converteddate", "sysconverteddate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy4.Replace("createddate", "syscreateddate");
                    }
                    if (fsortedBy4.ToLower().Trim().Contains("status"))
                    {
                        fsortedBy4.Replace("status", "StatusID");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("artworkdate"))
                    {
                        fsortedBy4.Replace("artworkdate", "SysArtworkDate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("approvaldate"))
                    {
                        fsortedBy4.Replace("approvaldate", "SysApprovalDate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("proofdate"))
                    {
                        fsortedBy4.Replace("proofdate", "SysProofDate");
                    }
                }

                string orderByField = dateFields.Contains(sortedBy)
                                   ? $"CAST(L.{sortedBy} AS DATE)"
                                   : $"L.{sortedBy}";
        
                string empty15 = string.Empty;
                string empty16 = string.Empty; //Warehouse stage 1
                string empty17 = string.Empty;
                string empty18 = string.Empty;
                if (flag && SectionName.Trim().ToLower() == "job")
                {
                    empty15 = " InvoiceID, ";
                    empty16 = "PurchaseID,"; //warehouse stage 1
                    empty17 = "DeliveryID,";
                    empty18 = "PriceCatalogueID,";
                }

                if (isSortingOrder && flag)
                {
                    if (SectionName.Trim().ToLower() == "job")
                    {
                        //sortedBy = "JobNumber";
                        //sortedDirection = "DESC";
                        if (sortedBy.ToLower().Trim() == "jobnumber")
                        {
                            if (str46.ToLower().Contains("proofstatus"))
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46, " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.JobSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            }
                            else
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.JobSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            }
                            empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                            strArrays = new string[] { "order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.JobSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            string.Concat(strArrays);
                        }
                        else if (sortedBy == "sysdeliverydate")
                        {
                            if (str46.ToLower().Contains("proofstatus"))
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46 , " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 ,",JobID ", sortedDirection, ", L.JobSortingOrder ASC" };
                            }
                            else
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ",JobID ", sortedDirection, ", L.JobSortingOrder ASC"};
                            }
                            empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                            strArrays = new string[] { "order by ", orderByField, " ", sortedDirection, ", L.JobSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            string.Concat(strArrays);
                        }
                        else
                        {
                            if (str46.ToLower().Contains("proofstatus"))
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46 , " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.JobSortingOrder ASC"};
                            }
                            else
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.JobSortingOrder ASC" };
                            }
                            empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                            strArrays = new string[] { "order by ", orderByField, " ", sortedDirection, ", L.JobSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            string.Concat(strArrays);
                        }


                    }
                    else
                    {
                        //sortedBy = "InvoiceNumber";
                        //sortedDirection = "DESC";
                        if (sortedBy.ToLower().Trim() == "invoicenumber")
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.InvoiceSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                            strArrays = new string[] { "order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.InvoiceSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            string.Concat(strArrays);
                        }
                        else
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.InvoiceSortingOrder ASC" };
                            empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                            strArrays = new string[] { "order by ", orderByField, " ", sortedDirection, ", L.InvoiceSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                            string.Concat(strArrays);
                        }
                    }


                }

                else if ((!flag || !(SectionName.Trim().ToLower().Trim() == "job") || !(sortedBy.ToLower().Trim() == "jobnumber")) && (!flag || !(SectionName.Trim().ToLower().Trim() == "invoice") || !(sortedBy.ToLower().Trim() == "invoicenumber")))
                {
                    //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, "PurchaseID", ",DeliveryID,", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by L.", sortedBy, " ", sortedDirection };
                    if(SectionName.Trim().ToLower().Trim() == "job")
                    {
                        if (sortedBy == "sysdeliverydate")
                        {
                            if (str46.ToLower().Contains("proofstatus"))
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46 , " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ",JobID ", sortedDirection };
                            }
                            else
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ",JobID ", sortedDirection};
                            }
                            //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by L.", sortedBy, " ", sortedDirection, ",JobID ", sortedDirection };
                        }
                        else
                        {
                            if (str46.ToLower().Contains("proofstatus"))
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46 , " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                            }
                            else
                            {
                                companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                            }
                            //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by L.", sortedBy, " ", sortedDirection };
                        }
                    }
                    else
                    {
                        if (sortedBy == "sysdeliverydate")
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ",JobID " };
                            //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by L.", sortedBy, " ", sortedDirection, ",JobID ", sortedDirection };
                        }
                        else
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                            //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by L.", sortedBy, " ", sortedDirection };
                        }
                    }
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    string.Concat("order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4);
                }
                else
                {
                    if(SectionName.Trim().ToLower().Trim() != "invoice")
                    {
                        if(str46.ToLower().Contains("proofstatus"))
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, "ProofID,", str46 , " FROM ", empty2, "  L ", proofStatus ," where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 }; ///Modification PurchaseID and DeliveryID Added by Bilal warehouse stage 1
                        }
                        else
                        {
                            companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 }; ///Modification PurchaseID and DeliveryID Added by Bilal warehouse stage 1
                        }
                    }
                    else
                    {
                        companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, empty16, empty17, empty18, str46 , " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 }; ///Modification PurchaseID and DeliveryID Added by Bilal warehouse stage 1
                    }
                    //companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str6, ",", str7, ",", empty15, str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection };
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    strArrays = new string[] { "order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    string.Concat(strArrays);
                }
            }
            else if (SectionName.Trim().ToLower() == "inventory" && empty3.ToLower().Trim() == "true")
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                strArrays = new string[] { "," };
                string[] strArrays5 = str46.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                string empty16 = string.Empty;
                for (int t = 0; t < (int)strArrays5.Length; t++)
                {
                    if (strArrays5[t].ToString().ToLower() == "inventorycode")
                    {
                        strArrays5[t] = "a.inventorycode";
                    }
                    if (strArrays5[t].ToString().ToLower() == "inventoryname")
                    {
                        strArrays5[t] = "a.inventoryname";
                    }
                    if (strArrays5[t].ToString().ToLower() == "cost")
                    {
                        strArrays5[t] = "b.cost";
                    }
                    if (strArrays5[t].ToString().ToLower() == "customstocktype")
                    {
                        strArrays5[t] = "CustomStockType = (select CategoryName from tb_StockCategory d where d.CategoryID = a.InventoryCategoryID)";
                    }
                    if (strArrays5[t].ToString().ToLower() == "suppliername")
                    {
                        strArrays5[t] = "SupplierName = (select clientname from tb_client e where e.clientid=a.SupplierID And companyID= a.companyid and companytype='supplier' and isdelete=0)";
                    }
                    if (strArrays5[t].ToString().ToLower() == "unitprice")
                    {
                        strArrays5[t] = "case when b.PerQuantity=0 then 0 else cast ((b.cost/b.PerQuantity) as decimal(18,10)) end as UnitPrice";
                    }
                    if (strArrays5[t].ToString().ToLower() == "description")
                    {
                        strArrays5[t] = "a.description";
                    }
                    if (strArrays5[t].ToString().ToLower() == "createddate")
                    {
                        strArrays5[t] = "CreatedDate = (select dbo.FormatDateTime(a.CreatedDate,DateFormat) from tb_RegionalSettings where CompanyID=a.companyid AND IsDeleted=0)";
                    }
                    if (strArrays5[t].ToString().ToLower() == "customheight")
                    {
                        strArrays5[t] = "b.Height as customheight";
                    }
                    if (strArrays5[t].ToString() != " ")
                    {
                        empty16 = string.Concat(empty16, strArrays5[t].ToString(), ",");
                    }
                }
                if (sortedBy.ToLower().Trim() == "inventoryid")
                {
                    sortedBy = "inventoryid";
                }
                string str47 = "height,stocktype,basisweight,papername,width,length,widthtype,lengthtype,papertype,packedin,packedintype,ChargableSheets,InkType,";
                companyID = new object[] { " Select ", str1, ",", str47, str46, " FROM ", empty2, "  L where  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, " order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                string.Concat("order by L.", sortedBy, " ", sortedDirection);
            }
            else if (SectionName.Trim().ToLower() == "customer" || SectionName.Trim().ToLower() == "supplier" || SectionName.Trim().ToLower() == "prospect")
            {
                companyID = new object[] { " Select ", str1, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, "  order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                string.Concat("order by L.", sortedBy, " ", sortedDirection);
            }
            else if (SectionName.Trim().ToLower() == "estimate" && flag)
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "podate")
                {
                    sortedBy = "syspodate";
                }
                else if (sortedBy.ToLower().Trim() == "estimatedate")
                {
                    sortedBy = "sysestimatedate";
                }
                else if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "ordereddate")
                {
                    sortedBy = "sysordereddate";
                }


                if (!String.IsNullOrEmpty(fsortedBy2))
                {
                    if (fsortedBy2.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy2.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy2.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy2.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy2.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy2.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy3))
                {
                    if (fsortedBy3.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy3.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy3.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy3.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy3.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy3.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy4))
                {
                    if (fsortedBy4.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy4.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy4.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy4.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy4.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy4.Replace("createddate", "syscreateddate");
                    }
                }

                string orderByField = dateFields.Contains(sortedBy)
                   ? $"CAST(L.{sortedBy} AS DATE)"
                   : $"L.{sortedBy}";


                if (isSortingOrder && flag)
                {
                    //sortedBy = "EstimateNumber";
                    //sortedDirection = "DESC";
                    if ((sortedBy.ToLower().Trim() == "estimatenumber"))
                    {
                        if (str46.ToLower().Contains("proofstatus"))
                        {
                            companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",ProofID,", str46, " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.EstimateSortingOrder ASC",fsortedBy2,fsortedBy3,fsortedBy4 };
                        }
                        else
                        {
                            companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.EstimateSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                        }
                        empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                        strArrays = new string[] { "order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.EstimateSortingOrder", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                        string.Concat(strArrays);
                    }
                    else
                    {
                        if (str46.ToLower().Contains("proofstatus"))
                        {
                            companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",ProofID,", str46, " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.EstimateSortingOrder ASC"};
                        }
                        else
                        {
                            companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.EstimateSortingOrder ASC"};
                        }
                        empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                        strArrays = new string[] { "order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                        string.Concat(strArrays);
                    }
                }
                else if (!flag || !(SectionName.Trim().ToLower().Trim() == "estimate") || !(sortedBy.ToLower().Trim() == "estimatenumber"))
                {
                    if (str46.ToLower().Contains("proofstatus"))
                    {
                        companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",ProofID,", str46, " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    }
                    else
                    {
                        companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    }
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    string.Concat("order by ", orderByField, " ", sortedDirection);
                }
                else
                {
                    if (str46.ToLower().Contains("proofstatus"))
                    {
                        companyID = new object[] { " Select ", str5, ",", str2, ",", empty6, ",ProofID,", str46, " FROM ", empty2, "  L ", proofStatus, " where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    }
                    else
                    {
                        companyID = new object[] { " Select ", str5, ",", str2, ",", empty6,",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, str12, empty12, " order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    }
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    strArrays = new string[] { "order by substring(L.", sortedBy, " , 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    string.Concat(strArrays);
                }
            }
            else if (SectionName.Trim().ToLower() == "proof")
            {
                //if (sortedBy.ToLower().Trim() == "proofdate")
                //{
                //    sortedBy = "sysproofdate";
                //}
                //else if (sortedBy.ToLower().Trim() == "jobtitle")
                //{
                //    sortedBy = "sysjobtitle";
                //}
                //if (sortedBy.ToLower().Trim() == "proofnumber")
                //{
                //    sortedBy = "sysproofnumber";
                //}
                //else if (sortedBy.ToLower().Trim() == "itemtitlevalue")
                //{
                //    sortedBy = "sysitemtitlevalue";
                //}
                string orderByField = dateFields.Contains(sortedBy)
                   ? $"CAST(L.{sortedBy} AS DATE)"
                   : $"L.{sortedBy}";

                string proofInfo = "ProofID,EstimateItemID,JobID,Cust_ID,SalesPersonId";
                companyID = new object[] { " Select ProofItemID,", str1, ",", str46, ",", proofInfo, " FROM ", empty2, "  L where ", str4, " L.IsDeleted=0  and  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, "  order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                string.Concat("order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4);
            }

            else if (SectionName.Trim().ToLower() != "webstoreorder")
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "podate")
                {
                    sortedBy = "syspodate";
                }
                if (sortedBy.ToLower().Trim() == "estimatedate")
                {
                    sortedBy = "sysestimatedate";
                }
                else if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "ordereddate")
                {
                    sortedBy = "sysordereddate";
                }

  

                if (!String.IsNullOrEmpty(fsortedBy2))
                {
                    if (fsortedBy2.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy2.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy2.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy2.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy2.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy2.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy3))
                {
                    if (fsortedBy3.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy3.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy3.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy3.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy3.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy3.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy4))
                {
                    if (fsortedBy4.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy4.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy4.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy4.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy4.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy4.Replace("createddate", "syscreateddate");
                    }
                }
                string orderByField = dateFields.Contains(sortedBy)
                   ? $"CAST(L.{sortedBy} AS DATE)"
                   : $"L.{sortedBy}";

                companyID = new object[] { " Select ", str1, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, "  order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                string.Concat("order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4);
            }
            else
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "podate")
                {
                    sortedBy = "syspodate";
                }
                else if (sortedBy.ToLower().Trim() == "estimatedate")
                {
                    sortedBy = "sysestimatedate";
                }
                else if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "ordereddate")
                {
                    sortedBy = "sysordereddate";
                }

                if (!String.IsNullOrEmpty(fsortedBy2))
                {
                    if (fsortedBy2.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy2.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy2.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy2.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy2.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy2.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy2.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy3))
                {
                    if (fsortedBy3.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy3.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy3.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy3.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy3.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy3.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy3.Replace("createddate", "syscreateddate");
                    }
                }

                if (!String.IsNullOrEmpty(fsortedBy4))
                {
                    if (fsortedBy4.ToLower().Trim().Contains("deliverydate"))
                    {
                        fsortedBy4.Replace("deliverydate", "sysdeliverydate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("podate"))
                    {
                        fsortedBy4.Replace("podate", "syspodate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("estimatedate"))
                    {
                        fsortedBy4.Replace("estimatedate", "sysestimatedate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("ordereddate"))
                    {
                        fsortedBy4.Replace("ordereddate", "sysordereddate");
                    }
                    else if (fsortedBy4.ToLower().Trim().Contains("createddate"))
                    {
                        fsortedBy4.Replace("createddate", "syscreateddate");
                    }
                }

                string orderByField = dateFields.Contains(sortedBy)
                   ? $"CAST(L.{sortedBy} AS DATE)"
                   : $"L.{sortedBy}";

                if (isSortingOrder && flag && (SectionName.Trim().ToLower().Trim() == "webstoreorder"))
                {
                    //sortedBy = "OrderNumber";
                    //sortedDirection = "DESC";
                    if (sortedBy.ToLower().Trim() == "ordernumber")
                    {
                        companyID = new object[] { " Select ", str1, ",", str5, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, " ", empty1, "  order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", L.OrderSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                        empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                        strArrays = new string[] { "order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", , L.OrderSortingOrder ASC", fsortedBy2, fsortedBy3, fsortedBy4 };
                        string.Concat(strArrays);
                    }
                    else
                    {
                        companyID = new object[] { " Select ", str1, ",", str5, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, " ", empty1, "  order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.OrderSortingOrder ASC"};
                         empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                        strArrays = new string[] { "order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4, ", L.OrderSortingOrder ASC"};
                        string.Concat(strArrays);
                    }

                }
                else if (!flag || !(SectionName.Trim().ToLower().Trim() == "webstoreorder") || !(sortedBy.ToLower().Trim() == "ordernumber"))
                {
                    companyID = new object[] { " Select ", str1, ",", str5, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, " ", empty1, "  order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    string.Concat("order by ", orderByField, " ", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4);
                }
                else
                {
                    companyID = new object[] { " Select ", str1, ",", str5, ",", empty6, ",", str46, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", str12, " ", empty12, " ", empty1, "  order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                    strArrays = new string[] { "order by substring(L.", sortedBy, ", 1 , CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4))", sortedDirection, ", cast(substring( L.", sortedBy, " ,CHARINDEX('-', L.", sortedBy, " ,len(L.", sortedBy, ")-4)+1,len(L.", sortedBy, ")) as INT )", sortedDirection, fsortedBy2, fsortedBy3, fsortedBy4 };
                    string.Concat(strArrays);
                }
            }
            int num = 0;
            int pageSize = PageSize;
            num = (PageNumber != 1 ? PageNumber * PageSize - PageSize : 0);
            object obj = empty;
            companyID = new object[] { obj, " OFFSET ", num, " ROWS FETCH NEXT ", pageSize, " ROWS ONLY" };
            empty = string.Concat(companyID);
            if (SectionName.Trim().ToLower() == "proof")
            {
                companyID = new object[] { "select count(L.", str1, ") from ", empty2, " L where ", str4, " L.IsDeleted=0  and  L.CompanyID=", CompanyID, "  ", str12, " ", empty12 };
            }
            else if(SectionName.Trim().ToLower() == "estimate" || SectionName.Trim().ToLower() == "job")
            {
                companyID = new object[] { "select count(L.", str1, ") from ", empty2, " L ", proofStatus, " Where ", str4, " L.CompanyID=", CompanyID, "  ", str12, " ", empty12 };
            }
            else
            {
                companyID = new object[] { "select count(L.", str1, ") from ", empty2, " L Where ", str4, " L.CompanyID=", CompanyID, "  ", str12, " ", empty12 };
            }
            str = string.Concat(companyID);
            empty = string.Concat(empty, ";", str);
            //delivery date issue
                if(SectionName.Trim().ToLower() == "purchase")
                {
                    if (sortedBy.ToLower().Trim() == "reqdate")
                    {
                       empty = empty.Replace("L.ReqDate", "convert(datetime, L.ReqDate, 103)");
                    }
                    
                }
            if (SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "estimate")
            {
                if(sortedBy.ToLower() == "proofstatus")
                {
                    empty = empty.ToString().Replace("L.ProofStatus", "pd.ProofItemStatus");
                }
            }
            if (SectionName.Trim().ToLower() == "invoice")
            {
                if (sortedBy.ToLower() == "job number")
                {
                    empty = empty.ToString().Replace("L.Job Number", "L.[Job Number]");
                }
            }
            return empty;
        }

        public string ReturnFinalQueryForNewCustomView_ForSearch(int CompanyID, int UserID, int PageSize, int PageNumber, string SectionName, int ViewID, string SortedBy, string SortedDirection, string para, string new_Para)
        {
            char[] chrArray;
            string[] strArrays;
            object[] companyID;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            bool flag = EstimatesBasePage.Views_IsItemDetailsSelected((long)ViewID);
            string str5 = "JOBID";
            string str6 = "InvoiceID";
            string str7 = "EstimateItemID";
            if(SectionName.Trim().ToLower() == "estimate" || SectionName.Trim().ToLower() == "job")
            {
                str7 = "L.EstimateItemID";
            }
            string empty5 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_regionalsettings_select(CompanyID).Rows)
            {
                empty5 = row["DateFormat"].ToString();
            }
            if (SectionName.Trim().ToLower() == "estimate")
            {
                str1 = "EstimateID";
                empty2 = "VW_Estimate_View_ForSearch";
                if (flag)
                {
                    str1 = "EstimateItemID";
                    str2 = "EstimateID";
                    empty2 = "VW_Estimate_View_ForSearch_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "job")
            {
                str1 = "JobID";
                str2 = "EstimateID";
                empty2 = "VW_Job_View_Forsearch";
                if (flag)
                {
                    empty2 = "VW_Job_View_Forsearch_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "invoice")
            {
                str1 = "InvoiceID";
                str2 = "EstimateID";
                empty2 = "VW_Invoice_View_ForSearch";
                if (flag)
                {
                    empty2 = "VW_Invoice_View_ForSearch_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "purchase")
            {
                str1 = "PurchaseID";
                empty2 = "VW_Purchase_View_ForSearch";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "deliverynote")
            {
                str1 = "DeliveryID";
                empty2 = "VW_delivery_View_ForSearch";
                BaseClass baseClass = new BaseClass();
                if (baseClass.ReturnRoles_Privileges_Others("showrecords").ToLower() != "type")
                {
                    str4 = "";
                }
                else
                {
                    string str8 = baseClass.ReturnRoles_Privileges_Others("companytype");
                    if (str8 == null || !(str8 != ""))
                    {
                        str4 = "";
                    }
                    else
                    {
                        str8 = str8.Substring(0, str8.Length - 1);
                        str4 = string.Concat("L.TypeID like '%", str8, "%' and ");
                    }
                }
            }
            else if (SectionName.Trim().ToLower() == "store")
            {
                str1 = "FinishedGoodsID";
                empty2 = "VW_store_View";
            }
            else if (SectionName.Trim().ToLower() == "item")
            {
                str1 = "FinishedGoodsID";
                empty2 = "VW_item_View";
            }
            else if (SectionName.Trim().ToLower() == "inventory")
            {
                str1 = "InventoryID";
                empty2 = "VW_inventory_View";
            }
            else if (SectionName.Trim().ToLower() == "customer")
            {
                str1 = "ClientID";
                empty2 = "VW_client_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "supplier")
            {
                str1 = "ClientID";
                empty2 = "VW_supplier_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "prospect")
            {
                str1 = "ClientID";
                empty2 = "VW_prospect_View";
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
            }
            else if (SectionName.Trim().ToLower() == "webstoreorder")
            {
                str1 = "OrderID";
                empty2 = "VW_Order_View_ForSearch";
                if (flag)
                {
                    empty2 = "VW_Order_View_SplitItem";
                }
                str4 = this.Return_ShowRecords_BaseOn_RolesAndPrivilegesCustomized();
                if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows[0]["AllowUnApprovedOrder"]))
                {
                    empty1 = "and APPROVED !='Awaiting Approval' AND  APPROVED !='REJECTED' ";
                }
            }
            else if (SectionName.Trim().ToLower() == "proof")
            {
                str1 = "EstimateID";
                str2 = "";
                empty2 = "VW_Proof_View";
            }
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageName", SectionName.Trim().ToLower());
            string sortedBy = string.Empty;
            string sortedDirection = string.Empty;
            string str10 = string.Empty;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["ColumnNames"].ToString().Length <= 0)
                {
                    continue;
                }
                if (SectionName.Trim().ToLower() == "customer")
                {
                    if (sqlDataReader["CustomerType"].ToString().ToLower() == "estore customer")
                    {
                        str10 = string.Concat(str10, " and (IsFromWebStore = 'store' or AccountID > 0)");
                    }
                    else if (sqlDataReader["CustomerType"].ToString().ToLower() == "non estore customer")
                    {
                        str10 = string.Concat(str10, " and (IsFromWebStore != 'store' and AccountID = 0)");
                    }
                }
                string str11 = sqlDataReader["ColumnNames"].ToString().Substring(0, sqlDataReader["ColumnNames"].ToString().Length - 1);
                chrArray = new char[] { ',' };
                this.DisplayColumns = str11.Split(chrArray);
                empty10 = sqlDataReader["RecordsToDisplay"].ToString();
                if (sqlDataReader["SortedBy"].ToString().Trim().ToLower() == "none")
                {
                    sortedBy = str1;
                    sortedDirection = "desc";
                }
                else
                {
                    sortedBy = SortedBy.ToString();
                    sortedDirection = SortedDirection.ToString();
                }
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
            string empty11 = string.Empty;
            //if (SectionName.Trim().ToLower() == "estimate" || SectionName.Trim().ToLower() == "job" || SectionName.Trim().ToLower() == "invoice" || SectionName.Trim().ToLower() == "webstoreorder" || SectionName.Trim().ToLower() == "purchase" || SectionName.Trim().ToLower() == "deliverynote" || SectionName.Trim().ToLower() == "inventory")
            //{
            //if (empty10 == "Live")
            //{
            //  empty11 = " and IsArchive=0 ";
            //}
            //else if (empty10 == "Archive")
            //{
            //  empty11 = " and IsArchive=1 ";
            //}
            //}
            string empty12 = string.Empty;
            string str12 = string.Empty;
            if (para.Trim().ToLower() != "")
            {
                if (para.Trim().ToLower() == "number")
                {
                    str12 = string.Concat(" and ", SortedBy.ToString(), " like '[0-9]%'");
                    empty12 = string.Concat(empty12, str12);
                }
                else if (para.Trim().ToLower() != "false")
                {
                    str12 = string.Concat(" and ", para);
                    empty12 = string.Concat(empty12, str12);
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            if (SectionName.Trim().ToLower() == "estimate")
            {
                if (this.DisplayColumns == null)
                {
                    string str13 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str13, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int i = 0; i < (int)this.DisplayColumns.Length; i++)
                    {
                        string str15 = this.DisplayColumns[i].ToString();
                        if (str15.Trim().ToLower() == "estimatenumber")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else if (str15.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(L.", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "validfor")
                        {
                            strArrays = new string[] { "cast(", str15, " as int) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "isforinvoice")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else if (str15.Trim().ToLower() == "estimatevalue")
                        {
                            strArrays = new string[] { "cast(", str15, " as decimal(28,10)) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str15, " as decimal(28,10)) as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "company")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "header")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "footer")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "paymentterms")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "costcentre")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "companyemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "contactemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str15, ",'%27',''''),'%22','\"') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "estimatedate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "artworkdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "approvaldate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() == "productiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str15.Trim().ToLower() != "completiondate")
                        {
                            stringBuilder.Append(string.Concat(str15, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str15, ",'", empty5, "') as ", str15, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("EmailCount,");
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "job")
            {
                if (this.DisplayColumns == null)
                {
                    string str16 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str16, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int j = 0; j < (int)this.DisplayColumns.Length; j++)
                    {
                        string str18 = this.DisplayColumns[j].ToString();
                        if (str18.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str18, ","));
                        }
                        else if (str18.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "company")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "header")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "footer")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "jobstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(L.", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatevalue")
                        {
                            strArrays = new string[] { "cast(", str18, " as decimal(28,10)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str18, " as decimal(28,10)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "isproformainvoice")
                        {
                            strArrays = new string[] { "cast(", str18, " as nvarchar(1)) as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimatestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "customerordernumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "paymentterms")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "costcentre")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemmaterial")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "orderedheight")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "orderedwidth")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemdescription")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemcolour")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemsize")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemartwork")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemdelivery")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemproofs")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itempacking")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemnotes")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemterms_instructions")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "companyemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "contactemail")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "mainItemsupplier")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "converteddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "productiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "completiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "approvaldate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "jobdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "artworkdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str18, ",'", empty5, "') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str18.Trim().ToLower() != "pressname")
                        {
                            stringBuilder.Append(string.Concat(str18, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str18, ",'%27',''''),'%22','\"') as ", str18, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "invoice")
            {
                if (this.DisplayColumns == null)
                {
                    string str19 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str19, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int k = 0; k < (int)this.DisplayColumns.Length; k++)
                    {
                        string str21 = this.DisplayColumns[k].ToString();
                        if (str21.Trim().ToLower() == "invoicenumber")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "estimatetitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoicestatus")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "statusid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "completiondate")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else if (str21.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoicevalue")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceoutstanding")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceamountpaid")
                        {
                            strArrays = new string[] { "cast(", str21, " as decimal(28,10)) as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty5, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "paymentdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty5, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "invoiceduedate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty5, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "completiondate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty5, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str21, ",'", empty5, "') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "department")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "estimator")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "greeting")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "customeraccountnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemdescription")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemcolour")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemsize")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemartwork")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemdelivery")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemproofs")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itempacking")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemnotes")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "itemterms_instructions")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str21.Trim().ToLower() != "status")
                        {
                            stringBuilder.Append(string.Concat(str21, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str21, ",'%27',''''),'%22','\"') as ", str21, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "purchase")
            {
                if (this.DisplayColumns == null)
                {
                    string str22 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str22, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int l = 0; l < (int)this.DisplayColumns.Length; l++)
                    {
                        string str24 = this.DisplayColumns[l].ToString();
                        if (str24.Trim().ToLower() == "PONO")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "SupplierName")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "PODate")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "GoodsReceived")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "status")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str24, " as decimal(28,10)) as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else if (str24.Trim().ToLower() == "poprice")
                        {
                            strArrays = new string[] { "cast(", str24, " as decimal(28,10)) as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "comments")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "description")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "customername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str24, ",'%27',''''),'%22','\"') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str24, ",'", empty5, "') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str24.Trim().ToLower() != "podate")
                        {
                            stringBuilder.Append(string.Concat(str24, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str24, ",'", empty5, "') as ", str24, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "deliverynote")
            {
                if (this.DisplayColumns == null)
                {
                    string str25 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str25, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int m = 0; m < (int)this.DisplayColumns.Length; m++)
                    {
                        string str27 = this.DisplayColumns[m].ToString();
                        if (str27.Trim().ToLower() == "deliverynumber")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else if (str27.Trim().ToLower() == "jobnumber")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else if (str27.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str27, ",'", empty5, "') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str27, ",'", empty5, "') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "status")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() != "orderno")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                    }
                    stringBuilder.Append("StatusColorCode,");
                }
            }
            if (SectionName.Trim().ToLower() == "store")
            {
                if (this.DisplayColumns == null)
                {
                    string str28 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str28, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int n = 0; n < (int)this.DisplayColumns.Length; n++)
                    {
                        string str30 = this.DisplayColumns[n].ToString();
                        if (str30.Trim().ToLower() == "productcode")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else if (str30.Trim().ToLower() == "productname")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else if (str30.Trim().ToLower() == "instockquantity")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else if (str30.Trim().ToLower() == "packquantity")
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(18,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str30.Trim().ToLower() == "packcostprice")
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(18,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str30.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str30, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str30, " as decimal(18,10)) as ", str30, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                }
            }
            if (SectionName.Trim().ToLower() == "item")
            {
                if (this.DisplayColumns == null)
                {
                    string str31 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str31, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int o = 0; o < (int)this.DisplayColumns.Length; o++)
                    {
                        string str33 = this.DisplayColumns[o].ToString();
                        if (str33.Trim().ToLower() == "productcode")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else if (str33.Trim().ToLower() == "productname")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else if (str33.Trim().ToLower() == "instockquantity")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else if (str33.Trim().ToLower() == "packquantity")
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(18,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str33.Trim().ToLower() == "packcostprice")
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(18,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str33.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str33, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str33, " as decimal(18,10)) as ", str33, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                }
            }
            if (SectionName.Trim().ToLower() == "customer" || SectionName.Trim().ToLower() == "supplier" || SectionName.Trim().ToLower() == "prospect")
            {
                if (this.DisplayColumns == null)
                {
                    string str34 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str34, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int p = 0; p < (int)this.DisplayColumns.Length; p++)
                    {
                        string str36 = this.DisplayColumns[p].ToString();
                        if (str36.Trim().ToLower() == "name")
                        {
                            str36 = "[name]";
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "type")
                        {
                            str36 = "[type]";
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "businesstelephone")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "businessemail")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "businessfax")
                        {
                            str36 = "fax";
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else if (str36.Trim().ToLower() == "deparmentname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "referredby")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultdepartmentname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultcontactname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address2")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address3")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address4")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "address5")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() == "defaultcontactjobtitle1")
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str36.Trim().ToLower() != "defaultcontactjobtitle2")
                        {
                            stringBuilder.Append(string.Concat(str36, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str36, ",'%27',''''),'%22','\"') as ", str36, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    if (SectionName.Trim().ToLower() == "customer")
                    {
                        stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    }
                }
            }
            empty3 = "false";
            if (SectionName.Trim().ToLower() == "inventory")
            {
                if (this.DisplayColumns != null)
                {
                    empty3 = "true";
                }
                else
                {
                    string str37 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    str37 = string.Concat(str37, "height,stocktype,width,length,widthtype,lengthtype,papertype,packedin,packedintype,basisweight,papername,ChargableSheets,InkType,");
                    this.DisplayColumns = this.ParseDefaultViewColumns(str37, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int q = 0; q < (int)this.DisplayColumns.Length; q++)
                    {
                        string str39 = this.DisplayColumns[q].ToString();
                        if (str39.Trim().ToLower() == "inventorycode")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() == "inventoryname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "suppliername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "cost")
                        {
                            strArrays = new string[] { "cast(", str39, " as decimal(28,10)) as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "stocktype")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() == "location")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "friendlyname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "description")
                        {
                            strArrays = new string[] { "Replace(Replace(", str39, ",'%27',''''),'%22','\"') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str39, ",'", empty5, "') as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str39.Trim().ToLower() == "archived")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else if (str39.Trim().ToLower() != "unitprice")
                        {
                            stringBuilder.Append(string.Concat(str39, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "cast(", str39, " as decimal(28,10)) as ", str39, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                }
            }
            if (SectionName.Trim().ToLower() == "webstoreorder")
            {
                if (this.DisplayColumns == null)
                {
                    string str40 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str40, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int r = 0; r < (int)this.DisplayColumns.Length; r++)
                    {
                        string str42 = this.DisplayColumns[r].ToString();
                        if (str42.Trim().ToLower() == "ordernumber")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "clientid")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "storeuserid")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "address")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "salesperson")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "isforinvoice")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else if (str42.Trim().ToLower() == "ordervalue")
                        {
                            strArrays = new string[] { "cast(", str42, " as decimal(28,10)) as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "estimatevalue_excgst")
                        {
                            strArrays = new string[] { "cast(", str42, " as decimal(28,10)) as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "customerid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "attentionid")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "accountstatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "itemfinishing")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "createddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty5, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "ordereddate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty5, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "deliverydate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str42, ",'", empty5, "') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() == "itemtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str42.Trim().ToLower() != "ordertitle")
                        {
                            stringBuilder.Append(string.Concat(str42, ","));
                        }
                        else
                        {
                            strArrays = new string[] { "Replace(Replace(", str42, ",'%27',''''),'%22','\"') as ", str42, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    stringBuilder.Append("StatusColorCode,");
                }
            }

            if (SectionName.Trim().ToLower() == "proof")
            {
                if (this.DisplayColumns == null)
                {
                    string str25 = SettingsBasePage.view_Default_select(SectionName.Trim().ToLower(), Convert.ToInt32(CompanyID));
                    this.DisplayColumns = this.ParseDefaultViewColumns(str25, SectionName);
                }
                if ((int)this.DisplayColumns.Length > 0)
                {
                    for (int i = 0; i < (int)this.DisplayColumns.Length; i++)
                    {
                        string str27 = this.DisplayColumns[i].ToString();
                        if (str27.Trim().ToLower() == "estimatenumber")
                        {
                            stringBuilder.Append(string.Concat(str27, ","));
                        }
                        else if (str27.Trim().ToLower() == "proofnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "itemtitlevalue")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "jobtitle")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "filestatus")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "proofdate")
                        {
                            strArrays = new string[] { "dbo.FormatDateTime(", str27, ",'", empty7, "') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "file")
                        {
                            strArrays = new string[] { "Replace(Replace([", str27, "],'%27',''''),'%22','\"') as '", str27, "'," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "jobnumber")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "customername")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (str27.Trim().ToLower() == "contactname")
                        {
                            strArrays = new string[] { "Replace(Replace(", str27, ",'%27',''''),'%22','\"') as ", str27, "," };
                            stringBuilder.Append(string.Concat(strArrays));
                        }

                    }
                    stringBuilder.Append("StatusColorCode,");
                    //stringBuilder.Append("EmailCount,");
                    //stringBuilder.Append("ErrorCount,");
                    //stringBuilder.Append("cast(BackOrder as int) as BackOrder,");
                    //stringBuilder.Append("cast(IsAccountOnHold as int) as IsAccountOnHold,");
                    //stringBuilder.Append("cast(IsStockProduct as int) as IsStockProduct,");
                }
            }
            string str43 = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
            if (SortedBy != "")
            {
                sortedBy = SortedBy;
                sortedDirection = SortedDirection;
            }
            else if (sortedBy.Trim().Length == 0)
            {
                sortedBy = str1;
                sortedDirection = "desc";
            }
            if (SectionName.Trim().ToLower() == "job")
            {
                if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "completiondate")
                {
                    sortedBy = "syscompletiondate";
                }
                else if (sortedBy.ToLower().Trim() == "converteddate")
                {
                    sortedBy = "sysconverteddate";
                }
                else if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "proofdate")
                {
                    sortedBy = "SysProofDate";
                }
                companyID = new object[] { " Select ", str1, ",", str2, ",", str7, ",", str6, ",", str43, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, empty12, " ", empty11, " ", new_Para, " order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            else if (SectionName.Trim().ToLower() == "invoice")
            {
                if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                else if (sortedBy.ToLower().Trim() == "completiondate")
                {
                    sortedBy = "syscompletiondate";
                }
                else if (sortedBy.ToLower().Trim() == "converteddate")
                {
                    sortedBy = "sysconverteddate";
                }
                else if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                companyID = new object[] { " Select ", str1, ",", str2, ",", str7, ",", str43, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, empty12, " ", empty11, " ", new_Para, " order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            else if (SectionName.Trim().ToLower() == "inventory" && empty3.ToLower().Trim() == "true")
            {
                strArrays = new string[] { "," };
                string[] strArrays1 = str43.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                string empty13 = string.Empty;
                for (int s = 0; s < (int)strArrays1.Length; s++)
                {
                    if (strArrays1[s].ToString().ToLower() == "inventorycode")
                    {
                        strArrays1[s] = "a.inventorycode";
                    }
                    if (strArrays1[s].ToString().ToLower() == "inventoryname")
                    {
                        strArrays1[s] = "a.inventoryname";
                    }
                    if (strArrays1[s].ToString().ToLower() == "cost")
                    {
                        strArrays1[s] = "b.cost";
                    }
                    if (strArrays1[s].ToString().ToLower() == "customstocktype")
                    {
                        strArrays1[s] = "CustomStockType = (select CategoryName from tb_StockCategory d where d.CategoryID = a.InventoryCategoryID)";
                    }
                    if (strArrays1[s].ToString().ToLower() == "suppliername")
                    {
                        strArrays1[s] = "SupplierName = (select clientname from tb_client e where e.clientid=a.SupplierID And companyID= a.companyid and companytype='supplier' and isdelete=0)";
                    }
                    if (strArrays1[s].ToString().ToLower() == "unitprice")
                    {
                        strArrays1[s] = "case when b.PerQuantity=0 then 0 else cast ((b.cost/b.PerQuantity) as decimal(18,10)) end as UnitPrice";
                    }
                    if (strArrays1[s].ToString().ToLower() == "description")
                    {
                        strArrays1[s] = "a.description";
                    }
                    if (strArrays1[s].ToString().ToLower() == "createddate")
                    {
                        strArrays1[s] = "CreatedDate = (select dbo.FormatDateTime(a.CreatedDate,DateFormat) from tb_RegionalSettings where CompanyID=a.companyid AND IsDeleted=0)";
                    }
                    if (strArrays1[s].ToString().ToLower() == "customheight")
                    {
                        strArrays1[s] = "b.Height as customheight";
                    }
                    if (strArrays1[s].ToString() != " ")
                    {
                        empty13 = string.Concat(empty13, strArrays1[s].ToString(), ",");
                    }
                }
                if (sortedBy.ToLower().Trim() == "inventoryid")
                {
                    sortedBy = "inventoryid";
                }
                string str44 = "height,stocktype,basisweight,papername,width,length,widthtype,lengthtype,papertype,packedin,packedintype,ChargableSheets,InkType,";
                companyID = new object[] { " Select ", str1, ",", str44, str43, " FROM ", empty2, "  L where  L.CompanyID=", CompanyID, "  ", empty12, " ", empty11, " ", new_Para, "  order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            else if (SectionName.Trim().ToLower() == "customer" || SectionName.Trim().ToLower() == "supplier" || SectionName.Trim().ToLower() == "prospect")
            {
                companyID = new object[] { " Select ", str1, ",", str43, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, "  ", empty12, " ", new_Para, "  order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            else if (SectionName.Trim().ToLower() == "estimate")
            {
                if (!flag)
                {
                    if (sortedBy.ToLower().Trim() == "createddate")
                    {
                        sortedBy = "syscreateddate";
                    }
                    else if (sortedBy.ToLower().Trim() == "podate")
                    {
                        sortedBy = "syspodate";
                    }
                    else if (sortedBy.ToLower().Trim() == "estimatedate")
                    {
                        sortedBy = "sysestimatedate";
                    }
                    else if (sortedBy.ToLower().Trim() == "deliverydate")
                    {
                        sortedBy = "sysdeliverydate";
                    }
                    companyID = new object[] { " Select ", str1, ",", str5, ",", str43, " FROM ", empty2, "  L where  ", str4, "  L.CompanyID=", CompanyID, "  ", empty12, " ", empty11, " ", new_Para, "  order by L.", sortedBy, " ", sortedDirection };
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                }
                else
                {
                    if (sortedBy.ToLower().Trim() == "createddate")
                    {
                        sortedBy = "syscreateddate";
                    }
                    else if (sortedBy.ToLower().Trim() == "podate")
                    {
                        sortedBy = "syspodate";
                    }
                    else if (sortedBy.ToLower().Trim() == "estimatedate")
                    {
                        sortedBy = "sysestimatedate";
                    }
                    else if (sortedBy.ToLower().Trim() == "deliverydate")
                    {
                        sortedBy = "sysdeliverydate";
                    }
                    else if (sortedBy.ToLower().Trim() == "ordereddate")
                    {
                        sortedBy = "sysordereddate";
                    }
                    companyID = new object[] { " Select ", str1, ",", str2, ",", str5, ",", str43, " FROM ", empty2, "  L where ", str4, "  L.CompanyID=", CompanyID, empty12, " ", empty11, " ", new_Para, "  order by L.", sortedBy, " ", sortedDirection };
                    empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
                }
            }
            else if (SectionName.Trim().ToLower() != "webstoreorder")
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "podate")
                {
                    sortedBy = "syspodate";
                }
                else if (sortedBy.ToLower().Trim() == "estimatedate")
                {
                    sortedBy = "sysestimatedate";
                }
                else if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                companyID = new object[] { " Select ", str1, ",", str43, " FROM ", empty2, "  L where  ", str4, "  L.CompanyID=", CompanyID, "  ", empty12, " ", empty11, " ", new_Para, "  order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            else
            {
                if (sortedBy.ToLower().Trim() == "createddate")
                {
                    sortedBy = "syscreateddate";
                }
                else if (sortedBy.ToLower().Trim() == "podate")
                {
                    sortedBy = "syspodate";
                }
                else if (sortedBy.ToLower().Trim() == "estimatedate")
                {
                    sortedBy = "sysestimatedate";
                }
                else if (sortedBy.ToLower().Trim() == "deliverydate")
                {
                    sortedBy = "sysdeliverydate";
                }
                companyID = new object[] { " Select ", str1, ",", str7, ",", str5, ",", str43, " FROM ", empty2, "  L where  ", str4, "  L.CompanyID=", CompanyID, "  ", empty12, " ", empty11, " ", new_Para, " ", empty1, "  order by L.", sortedBy, " ", sortedDirection };
                empty = Convert.ToString(stringBuilder2.Append(string.Concat(companyID)));
            }
            int num = 0;
            int pageSize = PageSize;
            num = (PageNumber != 1 ? PageNumber * PageSize - PageSize : 0);
            object obj = empty;
            companyID = new object[] { obj, " OFFSET ", num, " ROWS FETCH NEXT ", pageSize, " ROWS ONLY" };
            empty = string.Concat(companyID);
            companyID = new object[] { "select count(L.", str1, ") FROM ", empty2, "  L where  ", str4, "  L.CompanyID=", CompanyID, "  ", empty12, " ", empty11, " ", new_Para };
            str = string.Concat(companyID);
            empty = string.Concat(empty, ";", str);
            return empty;
        }

        public string tempTableCreateField(string fieldName, string dataType)
        {
            string empty = string.Empty;
            string lower = dataType.ToString().Trim().ToLower();
            string str = lower;
            if (lower != null)
            {
                switch (str)
                {
                    case "text":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    case "select":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(4000),");
                            break;
                        }
                    case "email":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    case "url":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    case "textarea":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(4000),");
                            break;
                        }
                    case "date":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " datetime,");
                            break;
                        }
                    case "number":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " decimal,");
                            break;
                        }
                    case "radio button":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    case "checkbox":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " bit,");
                            break;
                        }
                    case "heading":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    case "currency":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " money,");
                            break;
                        }
                    case "nvarchar":
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " nvarchar(max),");
                            break;
                        }
                    default:
                        {
                            empty = string.Concat(fieldName.ToString().ToLower().Trim(), " ", dataType.ToString().Trim().ToLower(), ",");
                            return empty;
                        }
                }
            }
            else
            {
                empty = string.Concat(fieldName.ToString().ToLower().Trim(), " ", dataType.ToString().Trim().ToLower(), ",");
                return empty;
            }
            return empty;
        }

        public void UnassignRecords(string sectionName, int sectionID, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_Common_Unassign", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", sectionName);
            sqlCommand.Parameters.AddWithValue("@sectionid", sectionID);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public bool validatenum(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsNumber(number[i]))
                {
                    this.flag1 = false;
                }
                if (char.IsDigit(number[i]))
                {
                    this.flag1 = true;
                }
                else
                {
                    this.flag1 = false;
                }
            }
            if (!this.flag1)
            {
                return false;
            }
            return true;
        }
    }
}