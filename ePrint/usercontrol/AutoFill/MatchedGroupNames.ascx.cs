using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedGroupNames : UserControl
    {
        //protected Repeater uc;

        //protected Panel pnlLocation;

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

        public MatchedGroupNames()
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
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("GroupName");
                Label label = (Label)e.Item.FindControl("hdnGroupID");
                Label label1 = (Label)e.Item.FindControl("hdnGroupName");
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] text = new string[] { "javascript:BindResultGroup('", label.Text, "','", label1.Text.Replace("'", "\\'"), "');" };
                attributes.Add("onclick", string.Concat(text));
            }
        }
    }
}