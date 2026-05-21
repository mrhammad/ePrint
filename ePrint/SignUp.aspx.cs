using System;
using System.Web.UI;

namespace ePrint
{
    public partial class SignUpRedirect : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = Request.Url.Query;
            Response.Redirect("~/Login/SignUp.aspx" + query, true);
        }
    }
}
