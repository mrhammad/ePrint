using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedWarehouseLocation : System.Web.UI.UserControl
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

        public MatchedWarehouseLocation()
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
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("LocationName");
                Label label = (Label)e.Item.FindControl("hdnLocationID");
                Label label1 = (Label)e.Item.FindControl("hdnLocationName");
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] text = new string[] { "javascript:BindResultWarehouseLocation('", label.Text, "','", this.objBase.SpecialEncode(label1.Text), "');" };
                attributes.Add("onclick", string.Concat(text));
            }
        }
    }
}