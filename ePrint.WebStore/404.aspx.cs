using nmsCommon;
using nmsConnection;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class _404 : System.Web.UI.Page, IRequiresSessionState
    {
    //    protected PlaceHolder plh_404;

    //    protected HtmlGenericControl div_Customize;

    //    protected HtmlForm form1;

        public static int CompanyID;

        public static long AccountID;

        public string strSitepath = string.Empty;

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

        static _404()
        {
        }

        public _404()
        {
        }

        public void LoginWithAccountName(string URL)
        {
            string[] strArrays = URL.Split(new char[] { ';' });
            if ((int)strArrays.Length <= 1)
            {
                foreach (DataRow row in ProductBasePage.Get404Content(_404.CompanyID, _404.AccountID).Rows)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<div>");
                    stringBuilder.Append(row["pageBody"].ToString());
                    stringBuilder.Append("</div>");
                    this.plh_404.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                }
            }
            else
            {
                string str = strArrays[1];
                int num = str.LastIndexOf('/') + 1;
                int length = str.Length - num;
                str = str.Substring(num, length);
                str = str.Replace("%20", " ");
                DataTable dataTable = LoginBasePage.Select_AccountInformation(str);
                if (dataTable.Rows.Count <= 0)
                {
                    foreach (DataRow dataRow in ProductBasePage.Get404Content(_404.CompanyID, _404.AccountID).Rows)
                    {
                        StringBuilder stringBuilder1 = new StringBuilder();
                        stringBuilder1.Append("<div>");
                        stringBuilder1.Append(dataRow["pageBody"].ToString());
                        stringBuilder1.Append("</div>");
                        this.plh_404.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                    }
                }
                else
                {
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (this.Session["AccountID"] != row1["AccountID"].ToString())
                        {
                            this.Logout();
                        }
                        base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", row1["AccountID"].ToString()));
                    }
                }
            }
        }

        public void LoginWithAccountNameLocal(string AccountName)
        {
            DataTable dataTable = LoginBasePage.Select_AccountInformation(AccountName);
            if (dataTable.Rows.Count <= 0)
            {
                foreach (DataRow row in ProductBasePage.Get404Content(_404.CompanyID, _404.AccountID).Rows)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<div>");
                    stringBuilder.Append(row["pageBody"].ToString());
                    stringBuilder.Append("</div>");
                    this.plh_404.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                }
            }
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (this.Session["AccountID"] != dataRow["AccountID"].ToString())
                    {
                        this.Logout();
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", dataRow["AccountID"].ToString()));
                }
            }
        }

        public void Logout()
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                _404.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                _404.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            this.plh_404.Controls.Clear();
            if (base.Request.QueryString["AccountName"] == null)
            {
                this.LoginWithAccountName(base.Request.Url.Query.ToString());
                return;
            }
            this.LoginWithAccountNameLocal(base.Request.QueryString["AccountName"].ToString());
        }
    }
}