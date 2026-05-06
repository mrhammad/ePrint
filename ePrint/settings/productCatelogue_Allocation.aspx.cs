using nmsCommon;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.settings
{
    public partial class productCatelogue_Allocation : BaseClass, IRequiresSessionState
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

        public productCatelogue_Allocation()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.Params["from"] != null)
                {
                    this.From = base.Request.Params["from"].ToString();
                }
                if (base.Request.Params["action"] != null)
                {
                    this.Action = base.Request.Params["action"].ToString();
                }
                if (this.From.ToLower() == "product")
                {
                    if (base.Request.Params["id"] != null)
                    {
                        this.Name = base.SpecialDecode(SettingsBasePage.Product_ItemTitle_Select(Convert.ToInt64(base.Request.Params["id"])));
                    }
                    base.Title = string.Concat("Product: ", this.Name);
                    return;
                }
                if (this.From.ToLower() == "category")
                {
                    if (base.Request.Params["Name"] != null)
                    {
                        this.Name = base.Request.Params["Name"].ToString();
                    }
                    this.Name = this.Name.Replace("%26", "&");
                    if (this.Action == "AllocateMultiple")
                    {
                        base.Title = "Categories";
                        return;
                    }
                    base.Title = string.Concat("Category: ", this.Name);
                    return;
                }
                if (this.From.ToLower() == "reports")
                {
                    base.Title = "Estore Reports Customer Allocation";
                }
            }
        }
    }
}