using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsLanguage;

namespace ePrint.usercontrol.settings
{
    public partial class FTPEmailMenu : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}