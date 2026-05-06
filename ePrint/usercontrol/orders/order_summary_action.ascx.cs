using nmsLanguage;
using Printcenter.UI.Order;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.orders
{
    public partial class order_summary_action : UserControl
    {
        public string Module = string.Empty;

        public string ActHistry = string.Empty;

        public languageClass objLanguage = new languageClass();

        public static string IsEditOnlyHisRecords;

        public string SalesPersonID = string.Empty;

        public int CompanyID;

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

        static order_summary_action()
        {
            order_summary_action.IsEditOnlyHisRecords = string.Empty;
        }

        public order_summary_action()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            if (base.Request.Params["ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
            }
            foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
            {
                this.SalesPersonID = row["Salesperson"].ToString();
            }
            order_summary_action.IsEditOnlyHisRecords = (new BaseClass()).ReturnRoles_Privileges_Others("editrecords");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            string str = string.Empty;
            if (!base.IsPostBack)
            {
                this.rbtn_Action.Text = this.objLanguage.GetLanguageConversion("Action");
                this.rcm_ItemOrder.Items[0].Text = this.objLanguage.GetLanguageConversion("ReRun_Item");
                this.rcm_ItemOrder.Items[1].Text = this.objLanguage.GetLanguageConversion("Delete_Item");
                this.rcm_ItemOrder.Items[2].Text = this.objLanguage.GetLanguageConversion("Edit_Job_Card");
            }
            if (base.Request.Params["acthist"] != null)
            {
                this.ActHistry = base.Request.Params["acthist"].ToLower();
            }
            if (this.ActHistry == "yes")
            {
                this.rbtn_Action.Visible = false;
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                if (empty.Trim().ToLower() == "false")
                {
                    this.rcm_ItemOrder.Items[2].Attributes.Add("style", "display:none");
                }
                str = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
                this.rcm_ItemOrder.Items[2].Attributes.Add("style", "display:none");
                empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                str = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
            }
            else
            {
                this.Module = "webstoreorder";
                this.rcm_ItemOrder.Items[2].Attributes.Add("style", "display:none");
                empty = baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                str = baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
            }
            if (empty.Trim().ToLower() == "false")
            {
                this.rcm_ItemOrder.Items[0].Attributes.Add("style", "display:none");
            }
            else if (order_summary_action.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != this.SalesPersonID)
            {
                this.rcm_ItemOrder.Items[0].Attributes.Add("style", "display:none");
            }
            if (str.Trim().ToLower() == "false")
            {
                this.rcm_ItemOrder.Items[1].Attributes.Add("style", "display:none");
            }
            if (empty.Trim().ToLower() == "false" && str.Trim().ToLower() == "false")
            {
                this.rcm_ItemOrder.Visible = false;
            }
        }
    }
}
