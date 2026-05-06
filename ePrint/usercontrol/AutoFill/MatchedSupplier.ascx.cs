using nmsLanguage;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedSupplier : System.Web.UI.UserControl
    {

        public DataSet data;

        private BaseClass objBase = new BaseClass();

        public static languageClass objLanguage;

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

        static MatchedSupplier()
        {
            MatchedSupplier.objLanguage = new languageClass();
        }

        public MatchedSupplier()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.data.Tables[0].Rows.Count <= 0)
            {
                this.pnlLocation.Style.Add("display", "none");
                return;
            }
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
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] text = new string[] { "javascript:BindResultSupplier('", label.Text, "','", this.objBase.SpecialEncode(label1.Text), "','", this.objBase.SpecialEncode(label2.Text), "','", label3.Text, "','", this.objBase.SpecialEncode(label4.Text), "');" };
                attributes.Add("onclick", string.Concat(text));
            }
        }
    }
}