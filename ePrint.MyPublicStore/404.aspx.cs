using System;
using System.Collections.Generic;
using nmsConnection;
using Printcenter.UI.Products;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class _404 : System.Web.UI.Page, IRequiresSessionState
    {
        //protected PlaceHolder plh_404;

        //protected HtmlGenericControl div_Customize;

        //protected HtmlForm form1;

        public static int CompanyID;

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

        static _404()
        {
        }

        public _404()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                _404.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                _404.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            this.plh_404.Controls.Clear();
            DataTable dataTable = ProductBasePage.Get404Content(_404.CompanyID, _404.AccountID);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div>");
            if (dataTable.Rows.Count > 0)
            {
                stringBuilder.Append(dataTable.Rows[0]["pagebody"].ToString());
            }
            stringBuilder.Append("</div>");
            this.plh_404.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }
    }
}