using nmsCommon;
using nmsLanguage;
using nmsView;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsMassdelete
{
	public class massdeleteClass : BaseView
	{
		public massdeleteClass()
		{
		}

		public void createDataGrid(string strSql, GridView dataGrid, LinkButton btncheckall, LinkButton btnuncheck, Button btndelete, Label lblNoData, string searchcriteria1, string searchcriteria2, string searchcriteria3)
		{
			languageClass _languageClass = new languageClass();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("crm_common_select_view ", (new commonClass()).openConnection());
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@strSQL", strSql);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataGrid.DataSource = dataSet;
			dataGrid.DataBind();
			if (dataGrid.Rows.Count != 0)
			{
				dataGrid.Visible = true;
				btncheckall.Visible = true;
				btnuncheck.Visible = true;
				btndelete.Visible = true;
				lblNoData.Visible = false;
				return;
			}
			dataGrid.Visible = false;
			btncheckall.Visible = false;
			btnuncheck.Visible = false;
			btndelete.Visible = false;
			lblNoData.Visible = true;
			if (!(searchcriteria1 != "") && !(searchcriteria2 != "") && !(searchcriteria3 != ""))
			{
				lblNoData.Text = _languageClass.convert("No Record Found");
				return;
			}
			lblNoData.Text = string.Concat(_languageClass.convert("No record found with this search parameter."), "&nbsp;", _languageClass.convert("Please try again."));
		}

		public SqlDataReader dtrUsername(int companyID)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_Username", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@companyID", companyID);
			return sqlCommand.ExecuteReader();
		}

		public void initialize_DropDown(int companyId, string pg, DropDownList[] ddlsearchfield, DropDownList[] ddlsearchcondition)
		{
			string str = "";
			bool flag = true;
			string lower = pg.ToLower();
			string str1 = lower;
			if (lower != null)
			{
				if (str1 == "client assignment")
				{
					pg = "client";
					str = "Client";
					flag = false;
				}
				else if (str1 == "contact assignment")
				{
					pg = "contact";
					str = "Contact";
					flag = false;
				}
				else if (str1 == "ticket assignment")
				{
					pg = "ticket";
					str = "Ticket";
				}
			}
			languageClass _languageClass = new languageClass();
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
				if (!(sqlDataReader["inputtype"].ToString().ToLower().Trim() != "heading") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "description") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample"))
				{
					continue;
				}
				if (str != "")
				{
					for (int i = 0; i < (int)ddlsearchfield.Length; i++)
					{
						ddlsearchfield[i].Items.Insert(num, string.Concat(str, ": ", sqlDataReader["labelName"].ToString().Trim()));
						ddlsearchfield[i].Items[num].Text = string.Concat(_languageClass.convert(str), ": ", _languageClass.convert(sqlDataReader["labelName"].ToString().Trim()));
						ddlsearchfield[i].Items[num].Value = string.Concat(str, ": ", sqlDataReader["databaseFieldName"].ToString().Trim());
					}
					num++;
				}
				else
				{
					for (int j = 0; j < (int)ddlsearchfield.Length; j++)
					{
						ddlsearchfield[j].Items.Insert(num, sqlDataReader["labelName"].ToString().Trim());
						ddlsearchfield[j].Items[num].Text = _languageClass.convert(sqlDataReader["labelName"].ToString().Trim());
						ddlsearchfield[j].Items[num].Value = sqlDataReader["databaseFieldName"].ToString().Trim();
					}
					num++;
				}
			}
			string[] strArrays = new string[] { "None", "=", "!=", "startswith", "contains", "notlike", " < ", " > ", " <= ", " >= " };
			string[] strArrays1 = strArrays;
			string[] strArrays2 = new string[] { _languageClass.convert("None"), _languageClass.convert("Equal to"), _languageClass.convert("Not equal to"), _languageClass.convert("Starts with"), _languageClass.convert("Contains"), _languageClass.convert("Not like"), _languageClass.convert("Less than"), _languageClass.convert("Greater than"), _languageClass.convert("Less than or equal to"), _languageClass.convert("Greater than or equal to") };
			string[] strArrays3 = strArrays2;
			if (flag)
			{
				for (int k = 0; k < (int)ddlsearchcondition.Length; k++)
				{
					for (int l = 0; l < (int)strArrays1.Length; l++)
					{
						ddlsearchcondition[k].Items.Insert(l, strArrays3[l].ToString());
						ddlsearchcondition[k].Items[l].Text = strArrays3[l].ToString();
						ddlsearchcondition[k].Items[l].Value = strArrays1[l].ToString();
					}
				}
				for (int m = 0; m < (int)ddlsearchfield.Length; m++)
				{
					ddlsearchfield[m].Items.Insert(0, "None");
					ddlsearchfield[m].Items[0].Text = _languageClass.convert("None");
					ddlsearchfield[m].Items[0].Value = "";
				}
			}
		}

		public override void initializeArray(int companyId, string pg, ArrayList ArrayInputType, ArrayList ArrayDataType, ArrayList ArrayFieldType, ArrayList ArrayCustomizeId)
		{
			string str = "";
			bool flag = true;
			string lower = pg.ToLower();
			string str1 = lower;
			if (lower != null)
			{
				if (str1 == "client assignment")
				{
					pg = "client";
					str = "Client";
					flag = false;
				}
				else if (str1 == "contact assignment")
				{
					pg = "contact";
					str = "Contact";
					flag = false;
				}
				else if (str1 == "ticket assignment")
				{
					pg = "ticket";
					str = "Ticket";
				}
			}
			if (flag)
			{
				ArrayInputType.Add("none");
				ArrayDataType.Add("none");
				ArrayFieldType.Add("d");
				ArrayCustomizeId.Add("0");
			}
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (!(sqlDataReader["inputtype"].ToString().ToLower().Trim() != "heading") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "description") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isread") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "isdelete") || !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "issample"))
				{
					continue;
				}
				if (str != "")
				{
					ArrayInputType.Add(string.Concat(str, ": ", sqlDataReader["inputtype"].ToString().ToLower().Trim()));
					ArrayDataType.Add(string.Concat(str, ": ", sqlDataReader["datatype"].ToString().ToLower().Trim()));
					ArrayFieldType.Add(string.Concat(str, ": ", sqlDataReader["fieldtype"].ToString().ToLower().Trim()));
					ArrayCustomizeId.Add(string.Concat(str, ": ", sqlDataReader["customizeid"].ToString().ToLower().Trim()));
				}
				else
				{
					ArrayInputType.Add(sqlDataReader["inputtype"].ToString().ToLower().Trim());
					ArrayDataType.Add(sqlDataReader["datatype"].ToString().ToLower().Trim());
					ArrayFieldType.Add(sqlDataReader["fieldtype"].ToString().ToLower().Trim());
					ArrayCustomizeId.Add(sqlDataReader["customizeid"].ToString().ToLower().Trim());
				}
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
		}
	}
}