using nmsCommon;
using nmsLanguage;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class logout : System.Web.UI.Page, IRequiresSessionState
    {
        private commonClass cmn = new commonClass();

        public languageClass objLanguage = new languageClass();

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

        public logout()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbl_ThankyouNote.Text = this.objLanguage.GetLanguageConversion("Thankyou_Logout_Note");
            this.lbl_ClickHere.Text = this.objLanguage.GetLanguageConversion("Please_click_here_to_Login");
            string empty = string.Empty;
            int num = 0;
            try
            {
                empty = this.Session["CompanyName"].ToString();
                num = Convert.ToInt32(this.Session["CompanyID"].ToString());
                string str = this.Session["email"].ToString();
                HttpContext.Current.Cache.Remove(str);
            }
            catch
            {
                empty = "Print Center";
            }
            base.Title = global.pageTitle("Logged out", num, empty);
            base.Response.Cookies["eclientes_userid"].Expires = DateTime.Now.AddDays(-1);
            base.Response.Cookies["eclientes_password"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie item = base.Request.Cookies["hdnSessionId"];
            if (item != null)
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_resumeSession_delete", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@hdnSessionID", item.Value.ToString());
                sqlCommand.ExecuteNonQuery();
                _commonClass.closeConnection();
                base.Request.Cookies.Set(new HttpCookie("hdnSessionId", ""));
                base.Response.Cookies.Set(new HttpCookie("hdnSessionId", ""));
            }
            base.Request.Cookies.Set(new HttpCookie("password", ""));
            base.Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            base.Response.Cookies["hdnSessionId"].Expires = DateTime.Now.AddDays(-1);
            this.Session[string.Concat("TabColours", num)] = null;
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            this.cmn.ht_UserSettings.Clear();
            base.Response.Redirect("~/Login/Login.aspx");
        }
    }
}