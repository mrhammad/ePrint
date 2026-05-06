using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class Default5 : System.Web.UI.Page, IRequiresSessionState
    {
        //protected PlaceHolder plhSiteMAP;

        //protected HtmlForm form1;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public Default5()
        {
        }

        public void BindAll(long ID)
        {
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "WS_GenerateSiteMAP";
            sqlCommand.Parameters.Add("@ParentCategoryID", ID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            sqlDataAdapter.Dispose();
            sqlCommand.Dispose();
            sqlConnection.Close();
            this.plhSiteMAP.Controls.Add(new LiteralControl("<ul>"));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.plhSiteMAP.Controls.Add(new LiteralControl("<li>"));
                this.plhSiteMAP.Controls.Add(new LiteralControl(row["Name"].ToString()));
                if (row["PorC"].ToString().Trim().ToLower() == "c")
                {
                    this.BindAll(Convert.ToInt64(row["CategoryID"]));
                }
                this.plhSiteMAP.Controls.Add(new LiteralControl("</li>"));
            }
            this.plhSiteMAP.Controls.Add(new LiteralControl("</ul>"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindAll((long)0);
        }
    }
}