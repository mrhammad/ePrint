using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

public class DemoClass : System.Web.UI.Page
{
	public DemoClass()
	{
	}

	protected override void OnPreInit(EventArgs e)
	{
		if (this.Session["CompanyID"] == null)
		{
			this.Session["CompanyID"] = base.Request.Cookies["DemoCompanyID"].Value;
		}
		if (this.Session["secondadminid"] == null)
		{
			int num = Convert.ToInt32(base.Request.Cookies["sadmin"].Value);
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_select_secondAdminid_by_id", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ID", num);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				this.Session["secondadminname"] = string.Concat(sqlDataReader["firstname"].ToString(), " ", sqlDataReader["lastname"].ToString());
				this.Session["secondadminid"] = sqlDataReader["id"].ToString();
				this.Session["companyName"] = sqlDataReader["companyname"].ToString();
				this.Session["CompanyID"] = base.Request.Cookies["DemoCompanyID"].Value;
				base.Response.Cookies["sadmin"].Value = sqlDataReader["id"].ToString();
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
		}
	}
}