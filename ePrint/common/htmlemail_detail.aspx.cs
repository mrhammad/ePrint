using nmsCommon;
using nmsLanguage;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class htmlemail_detail : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string pg = "";

        public languageClass objLanguage = new languageClass();

        public int Id;

        public int companyId;

        public string tabcolor = "";

        public BasePage objpage = new BasePage();

        public BaseClass objBase = new BaseClass();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public htmlemail_detail()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.strImagepath = global.imagePath();
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.companyId = int.Parse(this.Session["companyId"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("HTML Email Detail", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.pg = "lead";
            this.tabcolor = this.objpage.colorCode(this.companyId, global.pageName);
            try
            {
                this.Id = int.Parse(base.Request.Params["sl"]);
            }
            catch
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (!base.IsPostBack)
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_select_email_detail", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@sl", this.Id);
                sqlCommand.Parameters.AddWithValue("@companyID", this.companyId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    this.lbl_senddate_value.Text = _commonClass.Eprint_return_Date_Before_View(sqlDataReader["datesent"].ToString(), this.companyId, int.Parse(this.Session["userid"].ToString()), true);
                    this.lblmessage_value.Text = this.objBase.SpecialDecode(sqlDataReader["message"].ToString());
                    this.lblsubject_value.Text = this.objBase.SpecialDecode(base.dispstr(sqlDataReader["subject"].ToString(), 95));
                    this.lbltowho_value.Text = this.objBase.SpecialDecode(sqlDataReader["TO"].ToString());
                }
            }
        }
    }
}