using nmsCommon;
using nmsLanguage;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace nmsView
{
	public class createViewClass : BaseView
	{
        private languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        public createViewClass()
        {
        }

        public void BindCustomColumns(string pg, RadListBox lstBox)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[crm_common_CustomView_Columns]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["ColumnAlias"] = this.objBase.SpecialDecode(dataTable.Rows[i]["ColumnAlias"].ToString());
                }
            }
            lstBox.DataTextField = "ColumnAlias";
            lstBox.DataValueField = "ColumnName";
            lstBox.DataSource = dataTable;
            lstBox.DataBind();
            _commonClass.closeConnection();
        }

        public void BindCustomColumns_sortby(string pg, DropDownList ddlsortby, DropDownList ddldirection)
        {
            string empty = string.Empty;
            if (this.Session["pgtype"] != null)
            {
                empty = this.Session["pgtype"].ToString().ToLower().Trim();
            }
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            int num = 0;
            SqlCommand sqlCommand = new SqlCommand("[crm_common_CustomView_Columns]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int languageConversion = 0;
            while (sqlDataReader.Read())
            {
                if ((empty == "supplier" || empty == "prospect") && (sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() == "store name" || sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() == "refered by"))
                {
                    num++;
                }
                else if (sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() != "business fax")
                {
                    ddlsortby.Items.Insert(languageConversion, this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().Trim()));
                    ddlsortby.Items[languageConversion].Text = (this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "company" ? "Department" : sqlDataReader["ColumnAlias"].ToString().Trim());
                    if (pg == "job" || pg == "estimate" || pg == "invoice" || pg == "webstoreorder")
                    {
                        string str = string.Empty;
                        string empty1 = string.Empty;
                        str = "statusid";
                        empty1 = "itemtitle";
                        if (this.objBase.SpecialDecode(sqlDataReader["ColumnName"].ToString().ToLower().Trim()) == str)
                        {
                            ddlsortby.Items[languageConversion].Text = (this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "status" ? this.objLanguage.GetLanguageConversion("Item_Status") : sqlDataReader["ColumnAlias"].ToString().Trim());
                        }
                        if (this.objBase.SpecialDecode(sqlDataReader["ColumnName"].ToString().ToLower().Trim()) == empty1)
                        {
                            ddlsortby.Items[languageConversion].Text = (this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "title" ? this.objLanguage.GetLanguageConversion("Item_Title") : sqlDataReader["ColumnAlias"].ToString().Trim());
                        }
                    }
                    if (empty.ToLower() == "customer" && this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "business telephone")
                    {
                        ddlsortby.Items[languageConversion].Text = this.objLangClass.GetLanguageConversion("Dept_Phone");
                    }
                    ddlsortby.Items[languageConversion].Value = sqlDataReader["ColumnName"].ToString().Trim();
                    languageConversion++;
                }
                else
                {
                    num++;
                }
            }
            ddlsortby.Items.Insert(0, this.objLanguage.convert("None"));
            ddlsortby.Items[0].Text = this.objLanguage.convert("None");
            ddlsortby.Items[0].Value = "";
            string[] strArrays = new string[] { "asc", "desc" };
            string[] strArrays1 = new string[] { this.objLanguage.convert("Ascending"), this.objLanguage.convert("Descending") };
            string[] strArrays2 = strArrays1;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                ddldirection.Items.Insert(i, strArrays2[i].ToString());
                ddldirection.Items[i].Text = strArrays2[i].ToString();
                ddldirection.Items[i].Value = strArrays[i].ToString();
            }
            _commonClass.closeConnection();
        }

        public void BindCustomView(string pg, int CompanyID, DropDownList ddlview)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[Estimate_select_viewname_default]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int num = 1;
            string empty = string.Empty;
            DataTable dataTable1 = new DataTable();
            commonClass _commonClass1 = new commonClass();
            SqlCommand sqlCommand1 = new SqlCommand("[PC_view_zero_select]", _commonClass1.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@pagename", pg);
            sqlCommand1.Parameters.AddWithValue("@Companyid", CompanyID);
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            while (sqlDataReader1.Read())
            {
                ddlview.Items.Insert(0, sqlDataReader1["ViewName"].ToString().Trim());
                ddlview.Items[0].Text = sqlDataReader1["ViewName"].ToString().Trim();
                ddlview.Items[0].Value = sqlDataReader1["ViewID"].ToString().Trim();
            }
            _commonClass1.closeConnection();
            while (sqlDataReader.Read())
            {
                ddlview.Items.Insert(num, sqlDataReader["ViewName"].ToString().Trim());
                ddlview.Items[num].Text = sqlDataReader["ViewName"].ToString().Trim();
                ddlview.Items[num].Value = sqlDataReader["ViewID"].ToString().Trim();
                num++;
                if (sqlDataReader["isdefault"].ToString().ToLower().Trim() != "true")
                {
                    continue;
                }
                empty = this.objLanguage.convert(sqlDataReader["ViewName"].ToString().Trim());
                Convert.ToInt32(sqlDataReader["ViewID"].ToString().Trim());
                for (int i = 0; i < ddlview.Items.Count; i++)
                {
                    if (ddlview.Items[i].Text == empty)
                    {
                        ddlview.SelectedIndex = i;
                    }
                }
            }
            _commonClass.closeConnection();
        }

        public void BindCustomView(string pg, int CompanyID, DropDownList ddlview, int ViewID)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            SqlCommand sqlCommand = new SqlCommand("[Estimate_select_viewname_default_New]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int num = 0;
            string empty = string.Empty;
            while (sqlDataReader.Read())
            {
                ddlview.Items.Insert(num, sqlDataReader["ViewName"].ToString().Trim());
                ddlview.Items[num].Text = baseClass.SpecialDecode(sqlDataReader["ViewName"].ToString().Trim());
                ddlview.Items[num].Value = sqlDataReader["ViewID"].ToString().Trim();
                num++;
            }
            _commonClass.closeConnection();
        }

        public DataTable Check_Iszeroth_View(int CompanyID, long ViewID, string pg)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("[Check_Iszeroth_View]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            dataTable.Load(sqlCommand.ExecuteReader());
            return dataTable;
        }

        public void CustomColumns_delete(string pg, int CompanyID, long ViewID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[Estimate_viewname_delete]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.ExecuteReader();
            _commonClass.closeConnection();
        }

        public int CustomColumns_insert1(int CompanyID, long ViewID, string ViewName, string ColumnNames, string condition1, string condition2, string condition3, string condition4, string condition5, string operator1, string operator2, string operator3, string operator4, string operator5, string value1, string value2, string value3, string value4, string value5, int isdeleted, int CreatedBy, int UpdatedBy, string CreatedOn, string UpdatedOn, int isdefault, string SortedBy, string SortDirection, string PageName, int isshowallrecords, int iszerothvalue, string ConditionalOperator1, string ConditionalOperator2, string ConditionalOperator3, string ConditionalOperator4, string CustomerType, string RecordsToDisplay,bool isgrouping=false,string groupby="",string FilterDateType="", string FilterDateRange= "All")
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "PC_Estimateview_Customize_Insert"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@ViewName", ViewName);
            sqlCommand.Parameters.AddWithValue("@ColumnNames", ColumnNames);
            sqlCommand.Parameters.AddWithValue("@condition1", condition1);
            sqlCommand.Parameters.AddWithValue("@condition2", condition2);
            sqlCommand.Parameters.AddWithValue("@condition3", condition3);
            sqlCommand.Parameters.AddWithValue("@condition4", condition4);
            sqlCommand.Parameters.AddWithValue("@condition5", condition5);
            sqlCommand.Parameters.AddWithValue("@operator1", operator1);
            sqlCommand.Parameters.AddWithValue("@operator2", operator2);
            sqlCommand.Parameters.AddWithValue("@operator3", operator3);
            sqlCommand.Parameters.AddWithValue("@operator4", operator4);
            sqlCommand.Parameters.AddWithValue("@operator5", operator5);
            sqlCommand.Parameters.AddWithValue("@value1", value1);
            sqlCommand.Parameters.AddWithValue("@value2", value2);
            sqlCommand.Parameters.AddWithValue("@value3", value3);
            sqlCommand.Parameters.AddWithValue("@value4", value4);
            sqlCommand.Parameters.AddWithValue("@value5", value5);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr1", ConditionalOperator1);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr2", ConditionalOperator2);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr3", ConditionalOperator3);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr4", ConditionalOperator4);
            sqlCommand.Parameters.AddWithValue("@isdeleted", isdeleted);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            sqlCommand.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
            sqlCommand.Parameters.AddWithValue("@isdefault", isdefault);
            sqlCommand.Parameters.AddWithValue("@SortedBy", SortedBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@PageName", PageName);
            sqlCommand.Parameters.AddWithValue("@IsShowAll", isshowallrecords);
            sqlCommand.Parameters.AddWithValue("@IsZerothView", iszerothvalue);
            sqlCommand.Parameters.AddWithValue("@CustomerType", CustomerType);
            sqlCommand.Parameters.AddWithValue("@RecordsToDisplay", RecordsToDisplay);
            sqlCommand.Parameters.AddWithValue("@isGrouping", isgrouping);
            sqlCommand.Parameters.AddWithValue("@GroupByColumn", groupby);
            sqlCommand.Parameters.AddWithValue("@FilterDateType", FilterDateType);
            sqlCommand.Parameters.AddWithValue("@FilterDateRange", FilterDateRange);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            return Convert.ToInt32(sqlCommand.Parameters["ReturnValue"].Value);
        }

        public int CustomColumns_insert(
    int CompanyID,
    long ViewID,
    string ViewName,
    string ColumnNames,
    string condition1,
    string condition2,
    string condition3,
    string condition4,
    string condition5,
    string operator1,
    string operator2,
    string operator3,
    string operator4,
    string operator5,
    string value1,
    string value2,
    string value3,
    string value4,
    string value5,
    int isdeleted,
    int CreatedBy,
    int UpdatedBy,
    string CreatedOn,
    string UpdatedOn,
    int isdefault,
    string SortedBy,
    string SortDirection,
    string PageName,
    int isshowallrecords,
    int iszerothvalue,
    string ConditionalOperator1,
    string ConditionalOperator2,
    string ConditionalOperator3,
    string ConditionalOperator4,
    string CustomerType,
    string RecordsToDisplay,
    //bool isgrouping = false,
    //string groupby = "",
    string FilterDateType = "",
    string FilterDateRange = "All",
    // New parameters with default values
    string condition6 = "",
    string condition7 = "",
    string condition8 = "",
    string condition9 = "",
    string condition10 = "",
    string operator6 = "",
    string operator7 = "",
    string operator8 = "",
    string operator9 = "",
    string operator10 = "",
    string value6 = "",
    string value7 = "",
    string value8 = "",
    string value9 = "",
    string value10 = "",
    string ConditionalOperator5 = "",
    string ConditionalOperator6 = "",
    string ConditionalOperator7 = "",
    string ConditionalOperator8 = "",
    string ConditionalOperator9 = "",
    string SortedBy2 = "",
    string SortDirection2 = "",
    string SortedBy3 = "",
    string SortDirection3 = "",
    string SortedBy4 = "",
    string SortDirection4 = "")
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "PC_Estimateview_Customize_Insert"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@ViewName", ViewName);
            sqlCommand.Parameters.AddWithValue("@ColumnNames", ColumnNames);
            sqlCommand.Parameters.AddWithValue("@condition1", condition1);
            sqlCommand.Parameters.AddWithValue("@condition2", condition2);
            sqlCommand.Parameters.AddWithValue("@condition3", condition3);
            sqlCommand.Parameters.AddWithValue("@condition4", condition4);
            sqlCommand.Parameters.AddWithValue("@condition5", condition5);
            sqlCommand.Parameters.AddWithValue("@operator1", operator1);
            sqlCommand.Parameters.AddWithValue("@operator2", operator2);
            sqlCommand.Parameters.AddWithValue("@operator3", operator3);
            sqlCommand.Parameters.AddWithValue("@operator4", operator4);
            sqlCommand.Parameters.AddWithValue("@operator5", operator5);
            sqlCommand.Parameters.AddWithValue("@value1", value1);
            sqlCommand.Parameters.AddWithValue("@value2", value2);
            sqlCommand.Parameters.AddWithValue("@value3", value3);
            sqlCommand.Parameters.AddWithValue("@value4", value4);
            sqlCommand.Parameters.AddWithValue("@value5", value5);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr1", ConditionalOperator1);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr2", ConditionalOperator2);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr3", ConditionalOperator3);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr4", ConditionalOperator4);
            sqlCommand.Parameters.AddWithValue("@isdeleted", isdeleted);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            sqlCommand.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
            sqlCommand.Parameters.AddWithValue("@isdefault", isdefault);
            sqlCommand.Parameters.AddWithValue("@SortedBy", SortedBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@PageName", PageName);
            sqlCommand.Parameters.AddWithValue("@IsShowAll", isshowallrecords);
            sqlCommand.Parameters.AddWithValue("@IsZerothView", iszerothvalue);
            sqlCommand.Parameters.AddWithValue("@CustomerType", CustomerType);
            sqlCommand.Parameters.AddWithValue("@RecordsToDisplay", RecordsToDisplay);
            //sqlCommand.Parameters.AddWithValue("@isGrouping", isgrouping);
            //sqlCommand.Parameters.AddWithValue("@GroupByColumn", groupby);
            sqlCommand.Parameters.AddWithValue("@FilterDateType", FilterDateType);
            sqlCommand.Parameters.AddWithValue("@FilterDateRange", FilterDateRange);

            sqlCommand.Parameters.AddWithValue("@condition6", condition6);
            sqlCommand.Parameters.AddWithValue("@condition7", condition7);
            sqlCommand.Parameters.AddWithValue("@condition8", condition8);
            sqlCommand.Parameters.AddWithValue("@condition9", condition9);
            sqlCommand.Parameters.AddWithValue("@condition10", condition10);
            sqlCommand.Parameters.AddWithValue("@operator6", operator6);
            sqlCommand.Parameters.AddWithValue("@operator7", operator7);
            sqlCommand.Parameters.AddWithValue("@operator8", operator8);
            sqlCommand.Parameters.AddWithValue("@operator9", operator9);
            sqlCommand.Parameters.AddWithValue("@operator10", operator10);
            sqlCommand.Parameters.AddWithValue("@value6", value6);
            sqlCommand.Parameters.AddWithValue("@value7", value7);
            sqlCommand.Parameters.AddWithValue("@value8", value8);
            sqlCommand.Parameters.AddWithValue("@value9", value9);
            sqlCommand.Parameters.AddWithValue("@value10", value10);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr5", ConditionalOperator5);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr6", ConditionalOperator6);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr7", ConditionalOperator7);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr8", ConditionalOperator8);
            sqlCommand.Parameters.AddWithValue("@CondnalOpertr9", ConditionalOperator9);
            sqlCommand.Parameters.AddWithValue("@SortedBy2", SortedBy2);
            sqlCommand.Parameters.AddWithValue("@SortDirection2", SortDirection2);
            sqlCommand.Parameters.AddWithValue("@SortedBy3", SortedBy3);
            sqlCommand.Parameters.AddWithValue("@SortDirection3", SortDirection3);
            sqlCommand.Parameters.AddWithValue("@SortedBy4", SortedBy4);
            sqlCommand.Parameters.AddWithValue("@SortDirection4", SortDirection4);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            return Convert.ToInt32(sqlCommand.Parameters["ReturnValue"].Value);
          

        }



        public DataTable CustomizeView_Select(int ViewID, int CompanyID, string pg)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("[PC_CustomizeView_Select]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ViewID", ViewID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageName", pg.Trim().ToLower());
            dataTable.Load(sqlCommand.ExecuteReader());
            return dataTable;
        }

        public DataTable Estimate_Outwork_ArtworkFile_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Estimate_Outwork_ArtworkFile_Select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = int.MaxValue;
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dataTable.Load(sqlCommand.ExecuteReader());
            return dataTable;
        }

        public int EstimateView_Set_Default(string pg, int CompanyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[EstimateView_Set_Default]", _commonClass.openConnection());
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pagename", pg);
            sqlCommand.ExecuteReader();
            _commonClass.closeConnection();
            return Convert.ToInt32(sqlCommand.Parameters["ReturnValue"].Value);
        }

        public DataTable GetdefaultviewID(int CompanyID, string pg)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("[Estimate_GetviewID_default]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            dataTable.Load(sqlCommand.ExecuteReader());
            return dataTable;
        }

        public void initialize_DropDown(int companyId, string pg, DropDownList[] ddlselectcolumn, DropDownList[] ddlsearchfield, DropDownList[] ddlsearchcondition)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyID", companyId);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                if (!((sqlDataReader["inputtype"].ToString().ToLower().Trim() != "heading") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "description") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") & (sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample")))
                {
                    continue;
                }
                for (int i = 0; i < (int)ddlselectcolumn.Length; i++)
                {
                    ddlselectcolumn[i].Items.Insert(num, sqlDataReader["labelName"].ToString().Trim());
                    ddlselectcolumn[i].Items[num].Text = sqlDataReader["labelName"].ToString().Trim();
                    ddlselectcolumn[i].Items[num].Value = sqlDataReader["databaseFieldName"].ToString().Trim();
                }
                for (int j = 0; j < (int)ddlsearchfield.Length; j++)
                {
                    ddlsearchfield[j].Items.Insert(num, sqlDataReader["labelName"].ToString().Trim());
                    ddlsearchfield[j].Items[num].Text = sqlDataReader["labelName"].ToString().Trim();
                    ddlsearchfield[j].Items[num].Value = sqlDataReader["databaseFieldName"].ToString().Trim();
                }
                num++;
            }
            string[] strArrays = new string[] { "None", "=", "!=", "startswith", "contains", "notlike", " < ", " > ", " <= ", " >= " };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { this.objLanguage.convert("None"), this.objLanguage.convert("Equal to"), this.objLanguage.convert("Not equal to"), this.objLanguage.convert("Starts with"), this.objLanguage.convert("Contains"), this.objLanguage.convert("Not like"), this.objLanguage.convert("Less than"), this.objLanguage.convert("Greater than"), this.objLanguage.convert("Less than or equal to"), this.objLanguage.convert("Greater than or equal to") };
            string[] strArrays3 = strArrays2;
            for (int k = 0; k < (int)ddlsearchcondition.Length; k++)
            {
                for (int l = 0; l < (int)strArrays1.Length; l++)
                {
                    ddlsearchcondition[k].Items.Insert(l, strArrays3[l].ToString());
                    ddlsearchcondition[k].Items[l].Text = strArrays3[l].ToString();
                    ddlsearchcondition[k].Items[l].Value = strArrays1[l].ToString();
                }
            }
            for (int m = 0; m < (int)ddlselectcolumn.Length; m++)
            {
                ddlselectcolumn[m].Items.Insert(0, this.objLanguage.convert("None"));
                ddlselectcolumn[m].Items[0].Text = this.objLanguage.convert("None");
                ddlselectcolumn[m].Items[0].Value = "";
            }
            for (int n = 0; n < (int)ddlsearchfield.Length; n++)
            {
                ddlsearchfield[n].Items.Insert(0, this.objLanguage.convert("None"));
                ddlsearchfield[n].Items[0].Text = this.objLanguage.convert("None");
                ddlsearchfield[n].Items[0].Value = "";
            }
            try
            {
                for (int o = 0; o < 5; o++)
                {
                    ddlselectcolumn[o].SelectedIndex = o + 1;
                }
            }
            catch
            {
            }
        }

        public void initialize_DropDown_ForCustomView(int companyId, string pg, DropDownList[] ddlsearchfield, DropDownList[] ddlsearchcondition)
        {
            string empty = string.Empty;
            if (this.Session["pgtype"] != null)
            {
                empty = this.Session["pgtype"].ToString().ToLower().Trim();
            }
            SqlCommand sqlCommand = new SqlCommand("crm_common_CustomView_Columns", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int languageConversion = 0;
            int num = 0;
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < (int)ddlsearchfield.Length; i++)
                {
                    if ((empty == "supplier" || empty == "prospect") && (sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() == "store name" || sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() == "refered by"))
                    {
                        num++;
                    }
                    else if (sqlDataReader["ColumnAlias"].ToString().ToLower().Trim() != "business fax")
                    {
                        ddlsearchfield[i].Items.Insert(languageConversion, sqlDataReader["ColumnAlias"].ToString().Trim());
                        ddlsearchfield[i].Items[languageConversion].Text = sqlDataReader["ColumnAlias"].ToString().Trim();
                        ddlsearchfield[i].Items[languageConversion].Value = sqlDataReader["ColumnName"].ToString().Trim();
                        if (ddlsearchfield[i].Items[languageConversion].Text.ToLower() == "business telephone" && empty.ToLower() == "customer")
                        {
                            ddlsearchfield[i].Items[languageConversion].Text = this.objLangClass.GetLanguageConversion("Dept_Phone");
                        }
                        if (pg.ToLower().Trim() == "job" || pg.ToLower().Trim() == "estimate" || pg.ToLower().Trim() == "invoice" || pg.ToLower().Trim() == "webstoreorder")
                        {
                            string str = string.Empty;
                            string empty1 = string.Empty;
                            str = "statusid";
                            empty1 = "itemtitle";
                            if (this.objBase.SpecialDecode(sqlDataReader["ColumnName"].ToString().ToLower().Trim()) == str)
                            {
                                ddlsearchfield[i].Items[languageConversion].Text = (this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "status" ? this.objLanguage.GetLanguageConversion("Item_Status") : sqlDataReader["ColumnAlias"].ToString().Trim());
                            }
                            if (this.objBase.SpecialDecode(sqlDataReader["ColumnName"].ToString().ToLower().Trim()) == empty1)
                            {
                                ddlsearchfield[i].Items[languageConversion].Text = (this.objBase.SpecialDecode(sqlDataReader["ColumnAlias"].ToString().ToLower().Trim()) == "title" ? this.objLanguage.GetLanguageConversion("Item_Title") : sqlDataReader["ColumnAlias"].ToString().Trim());
                            }
                        }
                    }
                    else
                    {
                        num++;
                    }
                }
                if (num != 0)
                {
                    continue;
                }
                num = 0;
                languageConversion++;
            }
            string[] strArrays = new string[] { "None", "=", "!=", "startswith", "contains", "endswith", " < ", " > ", " <= ", " >= " };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { this.objLanguage.convert("None"), this.objLanguage.convert("Equal to"), this.objLanguage.convert("Not equal to"), this.objLanguage.convert("Starts with"), this.objLanguage.convert("Contains"), this.objLanguage.convert("Ends with"), this.objLanguage.convert("Less than"), this.objLanguage.convert("Greater than"), this.objLanguage.convert("Less than or equal to"), this.objLanguage.convert("Greater than or equal to") };
            string[] strArrays3 = strArrays2;
            for (int j = 0; j < (int)ddlsearchcondition.Length; j++)
            {
                for (int k = 0; k < (int)strArrays1.Length; k++)
                {
                    ddlsearchcondition[j].Items.Insert(k, strArrays3[k].ToString());
                    ddlsearchcondition[j].Items[k].Text = strArrays3[k].ToString();
                    ddlsearchcondition[j].Items[k].Value = strArrays1[k].ToString();
                }
            }
            for (int l = 0; l < (int)ddlsearchfield.Length; l++)
            {
                ddlsearchfield[l].Items.Insert(0, this.objLanguage.convert("None"));
                ddlsearchfield[l].Items[0].Text = this.objLanguage.convert("None");
                ddlsearchfield[l].Items[0].Value = this.objLanguage.convert("None");
            }
        }

        public DataTable Settings_JobViewColor_Select(int companyid, string DateType)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("pc_settings_jobViewColor_select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", companyid);
            sqlCommand.Parameters.AddWithValue("@DateType", DateType);
            dataTable.Load(sqlCommand.ExecuteReader());
            return dataTable;
        }

        public void View_Set_Default_All_zero_exist(string pg, int CompanyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[View_Set_Default_All_zero_exist]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@pagename", pg);
            sqlCommand.ExecuteReader();
            _commonClass.closeConnection();
        }
        public int PageCustomizeCount(int companyID, string pageName)
        {
            SqlCommand sqlCommand = new SqlCommand("[PC_CustomizeView_Count]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
            sqlCommand.Parameters.AddWithValue("@pg", pageName);
            int count = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
            return count;
        }
      
    }
}