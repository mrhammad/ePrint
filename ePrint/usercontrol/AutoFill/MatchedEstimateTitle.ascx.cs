using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedEstimateTitle : System.Web.UI.UserControl
    {

        public DataSet data;

        public BaseClass obj = new BaseClass();

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

        public MatchedEstimateTitle()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.data.Tables[0].Rows.Count <= 0)
            {
                this.pnlEstimateTitle.Style.Add("display", "none");
                return;
            }
            this.pnlEstimateTitle.Style.Add("display", "block");
            this.uc.DataSource = this.data;
            this.uc.DataBind();
        }
    }
}