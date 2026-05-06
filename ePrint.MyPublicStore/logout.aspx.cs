using nmsCommon;
using nmsConnection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class logout : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label Label1;

        //protected Label lbl_cntDown;

        //protected Label Label2;

        public static int companyID;

        public static long AccountID;

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

        static logout()
        {
        }

        public logout()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                logout.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                logout.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Logout", Convert.ToInt32(logout.companyID), Convert.ToInt32(logout.AccountID));
            if (!base.IsPostBack)
            {
                HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
                if (item != null)
                {
                    commonclass _commonclass = new commonclass();
                    SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                    sqlCommand.ExecuteNonQuery();
                    _commonclass.closeConnection();
                    base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                    base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                }
                base.Response.Cookies["ResumeSessionID"].Expires = DateTime.Now.AddDays(-1);
                this.Session["StoreUserID"] = "";
                this.Session.Clear();
                this.Session.Abandon();
                GC.Collect();
            }
        }
    }
}