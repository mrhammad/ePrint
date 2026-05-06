using nmsCommon;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_stockonly_po : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string pg = string.Empty;

        public string stockUrl = string.Empty;

        private string _Section = string.Empty;

        public commonClass commclass = new commonClass();

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

        public string Section
        {
            get
            {
                return this._Section;
            }
            set
            {
                this._Section = value;
            }
        }

        public item_stockonly_po()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.stockUrl = base.Request.Url.ToString().ToLower();
            if (!this.stockUrl.Contains("purchase/purchase_add.aspx") && !this.stockUrl.Contains("common/common_popup.aspx"))
            {
                this.stockUrl = "div_stock_only";
                return;
            }
            this.stockUrl = "dstock_only";
        }
    }
}