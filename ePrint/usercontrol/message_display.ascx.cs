using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol
{
    public partial class message_display : UsercontrolBasePage
    {

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        public Label LabelMessage
        {
            get
            {
                return this.lblMessage;
            }
            set
            {
                this.lblMessage = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public message_display()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TimerMessage_OnTick(object sender, EventArgs e)
        {
            this.pnlMessage.Visible = false;
            this.TimerMessage.Enabled = false;
        }
    }
}