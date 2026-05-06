using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedClientAll_Report : System.Web.UI.UserControl
    {

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

        public MatchedClientAll_Report()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pnlLocation.Style.Add("display", "block");
            this.uc.DataSource = this.data;
            this.uc.DataBind();
        }

        protected void Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("ClientName");
                Label label = (Label)e.Item.FindControl("hdnClientID");
                Label label1 = (Label)e.Item.FindControl("hdnClientName");
                Label label2 = (Label)e.Item.FindControl("hdnContacts");
                Label label3 = (Label)e.Item.FindControl("hdnAccountNo");
                Label label4 = (Label)e.Item.FindControl("hdnContactDelAddress");
                Label label5 = (Label)e.Item.FindControl("hdnDepartmentName");
                Label label6 = (Label)e.Item.FindControl("hdnDepartmentID");
                Label label7 = (Label)e.Item.FindControl("hdnInvoiceAddressID");
                Label label8 = (Label)e.Item.FindControl("hdnInvoiceAddress");
                Label label9 = (Label)e.Item.FindControl("hdnContactAddress");
                Label label10 = (Label)e.Item.FindControl("hdnContactAddressID");
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] text = new string[] { "javascript:BindResultCustomer('", label.Text, "','", this.objBase.SpecialEncode(label1.Text), "','", this.objBase.SpecialEncode(label2.Text), "','", this.objBase.SpecialEncode(label3.Text), "','", this.objBase.SpecialEncode(label4.Text), "','", this.objBase.SpecialEncode(label5.Text), "','", label6.Text, "','", label7.Text, "','", this.objBase.SpecialEncode(label8.Text), "','", this.objBase.SpecialEncode(label9.Text), "','", label10.Text, "');" };
                attributes.Add("onclick", string.Concat(text));
            }
        }
    }
}