using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.Services;
using ePrint.usercontrol.Item;
using Newtonsoft.Json;

namespace ePrint.orders
{
    public partial class order_summary : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_item_item_summary_main_ascx UCItemSummaryMain;

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public long OrderID;

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

        public order_summary()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ticket # 113606 (Timeout added for large number of progress to Job) 
            ScriptManager _scriptMan = ScriptManager.GetCurrent(this);
            _scriptMan.AsyncPostBackTimeout = 36000;
            
            (new BaseClass()).ReturnRoles_Privileges_Tabs("webstoreorder", "isview", "");
            this.gloobj.setpagename("webstoreorder");
            this.OrderID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_view"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_Summary")));
            base.Title = this.objLanguage.convert(global.pageTitle("Order Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            Session["OrderSummery"] = this;
        }
    }
}
