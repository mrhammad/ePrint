using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateEditor;

namespace HTML5TemplateEditor
{
    public partial class start : System.Web.UI.Page, IRequiresSessionState
    {


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

        public start()
        {
        }

        public void GeneratePlhContent(string host)
        {
            string str = "eprint_TE";
            string str1 = "";
            string str2 = str;
            string str3 = str2;
            if (str2 != null)
            {
                if (str3 == "smp")
                {
                    str1 = "Data Source= DBSERVER\\DBSERVER;Initial Catalog=eprint_smp;Persist Security Info=true;User ID=sa;Password=Vikash@123";
                }
                else if (str3 == "bendigo")
                {
                    str1 = "Data Source= DBSERVER\\DBSERVER;Initial Catalog=eprint_bendigo;Persist Security Info=true;User ID=sa;Password=Vikash@123";
                }
                else if (str3 == "eprint_TE")
                {
                    str1 = "Data Source= DBSERVER\\DBSERVER;Initial Catalog=eprint_3.9_TE;Persist Security Info=true;User ID=eprint;Password=vikash@123";
                }
                else if (str3 == "eprint3.9_copy")
                {
                    str1 = "Data Source= DBSERVER\\DBSERVER;Initial Catalog=eprint_prod_3.9_copy;Persist Security Info=true;User ID=eprint;Password=vikash@123";
                }
            }
            if (host != "localhost")
            {
                str1 = "Data Source= DBSERVER\\DBSERVER;Initial Catalog=eprint_3.9_TE;Persist Security Info=true;User ID=eprint;Password=vikash@123";
            }
            SqlConnection sqlConnection = new SqlConnection(str1);
            string str4 = "";
            str4 = (str == "bendigo" || str == "smp" ? "SELECT TemplateName,TemplateID,CompanyID,PriceCatalogueID,CreatedBy FROM et_Templates where companyid=2144 and IsDeleted=0 ORDER BY TemplateID " : "SELECT TemplateName,TemplateID,CompanyID,PriceCatalogueID,CreatedBy FROM et_Templates where IsDeleted=0 ORDER BY TemplateID");
            if (host != "localhost")
            {
                str4 = "SELECT TemplateName,TemplateID,CompanyID,PriceCatalogueID,CreatedBy FROM et_Templates where IsDeleted=0 ORDER BY TemplateID";
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str4, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "et_Templates");
            this.plhTemplates.Controls.Add(new LiteralControl("<div style='width:100%;margin:0px auto 0px auto;'>"));
            int num = 0;
            string str5 = "";
            string str6 = str;
            string str7 = str6;
            if (str6 != null)
            {
                if (str7 == "smp")
                {
                    str5 = "CEF1C844-849B-47F9-B1D6-39264CEDCE91";
                }
                else if (str7 == "bendigo")
                {
                    str5 = "36E547AC-C83C-4716-8912-CE8AC7E03643";
                }
                else if (str7 == "eprint_TE")
                {
                    str5 = "1E7EBA34-619C-4F1A-8D42-E66D981ACB2A";
                }
                else if (str7 == "eprint3.9_copy")
                {
                    str5 = "4D255A9C-A543-4538-ACBD-675B7BB9EAF4";
                }
            }
            if (host != "localhost")
            {
                str5 = "5E01FF7E-DC44-43EB-A208-DCF66350B1A9";
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string str8 = row["TemplateName"].ToString();
                if (str8 == "")
                {
                    num++;
                    str8 = string.Concat("With Out Name-", num);
                }
                if (row["TemplateName"].ToString().Length > 22)
                {
                    str8 = row["TemplateName"].ToString().Substring(0, 22);
                }
                string[] strArrays = new string[] { "templateid=", row["TemplateID"].ToString(), "&pricecatalogid=", row["PriceCatalogueID"].ToString(), "&companyid=", row["CompanyID"].ToString(), "&userid=", row["CreatedBy"].ToString(), "&dbkey=", str5 };
                string str9 = Encrypt.Encryption(string.Concat(strArrays));
                this.plhTemplates.Controls.Add(new LiteralControl(string.Concat("<a id='Name' href='editableproduct.aspx?", str9, "' class='TemplateDiv' style='text-decoration:none;' >")));
                this.plhTemplates.Controls.Add(new LiteralControl(string.Concat("<span class='linkfonts' style='vertical-align:middle;align:center;overflow:hidden;height:25px;width:190px;'>", str8, "</span>")));
                this.plhTemplates.Controls.Add(new LiteralControl("</a>"));
            }
            this.plhTemplates.Controls.Add(new LiteralControl("</div>"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GeneratePlhContent(HttpContext.Current.Request.Url.Host);
        }
    }
}