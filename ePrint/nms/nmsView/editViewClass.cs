using nmsCommon;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsView
{
	public class editViewClass
	{
		public editViewClass()
		{
		}

		public void selectView_Value(int companyId, int paraViewValueId, string pg, DropDownList[] ddlselectcolumn, DropDownList[] ddlsearchfield, DropDownList[] ddlsearchcondition, TextBox[] txtsearchcriteria, TextBox txtviewname, CheckBox chkhide)
		{
			BaseClass baseClass = new BaseClass();
			string str = "";
			string str1 = "";
			string lower = pg.Trim().ToLower();
			string str2 = lower;
			if (lower != null)
			{
				switch (str2)
				{
					case "lead":
					{
						str = "tb_leadviewvalue";
						str1 = "leadviewvalueid";
						break;
					}
					case "client":
					{
						str = "tb_clientviewvalue";
						str1 = "clientviewvalueid";
						break;
					}
					case "contact":
					{
						str = "tb_contactviewvalue";
						str1 = "contactviewvalueid";
						break;
					}
					case "campaign":
					{
						str = "tb_campaignviewvalue";
						str1 = "campaignviewvalueid";
						break;
					}
					case "solution":
					{
						str = "tb_solutionviewvalue";
						str1 = "solutionviewvalueid";
						break;
					}
					case "opportunity":
					{
						str = "tb_opportunityviewvalue";
						str1 = "opportunityviewvalueid";
						break;
					}
					case "ticket":
					{
						str = "tb_ticketviewvalue";
						str1 = "ticketviewvalueid";
						break;
					}
					case "forecast":
					{
						str = "tb_forecastviewvalue";
						str1 = "forecastviewvalueid";
						break;
					}
					case "contract":
					{
						str = "tb_contractviewvalue";
						str1 = "contractviewvalueid";
						break;
					}
					case "product":
					{
						str = "tb_productviewvalue";
						str1 = "productviewvalueid";
						break;
					}
					case "asset":
					{
						str = "tb_assetviewvalue";
						str1 = "assetviewvalueid";
						break;
					}
					case "price":
					{
						str = "tb_priceviewvalue";
						str1 = "priceviewvalueid";
						break;
					}
				}
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "select * from ", str, " where ", str1, " = ", paraViewValueId };
			SqlCommand sqlCommand = new SqlCommand(string.Concat(objArray), _commonClass.openConnection());
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				txtviewname.Text = baseClass.SpecialDecode(sqlDataReader["viewname"].ToString());
				if ((bool)sqlDataReader["ishide"])
				{
					chkhide.Checked = true;
				}
				if ((bool)sqlDataReader["CompanyDefault"])
				{
					chkhide.Visible = false;
				}
				for (int i = 0; i < (int)txtsearchcriteria.Length; i++)
				{
					int num = i + 1;
					txtsearchcriteria[i].Text = baseClass.SpecialDecode(sqlDataReader[string.Concat("value", num)].ToString().Trim());
				}
				for (int j = 0; j < (int)ddlsearchfield.Length; j++)
				{
					for (int k = 0; k < ddlsearchfield[j].Items.Count; k++)
					{
						if (ddlsearchfield[j].Items[k].Value.ToString().ToLower().Trim() == sqlDataReader[string.Concat("condition", j + 1)].ToString().ToLower().Trim())
						{
							ddlsearchfield[j].SelectedIndex = k;
						}
					}
				}
				for (int l = 0; l < (int)ddlsearchcondition.Length; l++)
				{
					for (int m = 0; m < ddlsearchcondition[l].Items.Count; m++)
					{
						if (ddlsearchcondition[l].Items[m].Value.ToString().ToLower().Trim() == sqlDataReader[string.Concat("operator", l + 1)].ToString().ToLower().Trim())
						{
							ddlsearchcondition[l].SelectedIndex = m;
						}
					}
				}
				for (int n = 0; n < (int)ddlselectcolumn.Length; n++)
				{
					for (int o = 0; o < ddlselectcolumn[n].Items.Count; o++)
					{
						int num1 = n + 1;
						try
						{
							if (ddlselectcolumn[n].Items[o].Value.ToString().ToLower().Trim() == sqlDataReader[string.Concat("field", num1)].ToString().ToLower().Trim())
							{
								ddlselectcolumn[n].SelectedIndex = o;
							}
						}
						catch
						{
						}
					}
				}
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
		}
	}
}