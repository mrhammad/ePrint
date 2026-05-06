using nmsCommon;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ePrint.ProductCatalogue
{
    public partial class ProductCatalogueSubAdditionOption_Allocation : BaseClass, IRequiresSessionState
    {


        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public string Name = string.Empty;

        public string From = string.Empty;

        public string Action = string.Empty;

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

        public ProductCatalogueSubAdditionOption_Allocation()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.Params["action"] != null)
                {
                    this.Action = base.Request.Params["action"].ToString();
                }
                if (base.Request.Params["Name"] != null)
                {
                    this.Name = base.Request.Params["Name"].ToString();
                }
                this.Name = this.Name.Replace("%26", "&");
                if (this.Action == "add")
                {
                    base.Title = "Sub Options";
                    return;
                }
                base.Title = string.Concat("Group: ", this.Name);
            }
        }
    }
}