using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.AutoFill
{
    public partial class MachedCustomer_FromHeader : UserControl
    {
        //protected Repeater Repeater_FromHeader;

        //protected Panel pnlLocationBindCustomers_FromHeader;

        public DataSet data;

        private BaseClass objBase = new BaseClass();

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

        public MachedCustomer_FromHeader()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pnlLocationBindCustomers_FromHeader.Style.Add("display", "block");
            this.Repeater_FromHeader.DataSource = this.data;
            this.Repeater_FromHeader.DataBind();
        }

        protected void Repeater_FromHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("Repeater_ClientName_FromHeader");
                Label label = (Label)e.Item.FindControl("Repeater_hdnClientID_FromHeader");
                Label label1 = (Label)e.Item.FindControl("Repeater_hdnClientNam_FromHeadere");
                Label label2 = (Label)e.Item.FindControl("Repeater_hdnContacts_FromHeader");
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] strArrays = new string[] { "javascript:BindResultCustomer_FromHeader('", this.objBase.SpecialEncode(label.Text), "','", this.objBase.SpecialEncode(label1.Text), "','", this.objBase.SpecialEncode(label2.Text), "');" };
                attributes.Add("onclick", string.Concat(strArrays));
            }
        }
    }
}