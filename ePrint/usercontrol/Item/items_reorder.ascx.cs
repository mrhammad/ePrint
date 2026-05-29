using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Prefligt;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class items_reorder : System.Web.UI.UserControl
    {


        public long EstimateID;
        public int CompanyID;
        public long JobID;
        public long InvoiceID;
        public string Pgtype = string.Empty;
        public string MainItemNumber = string.Empty;



        protected void Page_Load(object sender, EventArgs e)
        {

            this.page_type.Value = base.Request.QueryString["page"].ToString();

            if (base.Request.QueryString["estimateid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estimateid"].ToString());
            }
            if (base.Request.QueryString["companyid"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Request.QueryString["companyid"].ToString());
            }
            if (base.Request.QueryString["jobid"] != null)
            {
                this.JobID = Convert.ToInt64(base.Request.QueryString["jobid"].ToString());
            }
            if (base.Request.QueryString["invoiceid"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.QueryString["invoiceid"].ToString());
            }
            if (base.Request.QueryString["page"] != null)
            {
                this.Pgtype = base.Request.QueryString["page"].ToString().ToLower();
            }




            DataTable dataTable2 = new DataTable();

            string itemNumber = "";




            if (Pgtype == "estimate")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);                
            }
            else if (Pgtype == "job")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng_ByJob(this.CompanyID, this.JobID, this.Pgtype);
            }
            else if (Pgtype == "invoice")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng_ByInvoice(this.CompanyID, this.InvoiceID, this.Pgtype);
            }
            else if (Pgtype == "order")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);
            }





            this.plhItems.Controls.Clear();
            foreach (DataRow row4 in dataTable2.Rows)
            {
                if (Pgtype == "estimate")
                {
                    itemNumber = row4["EstimateItemNumber"].ToString();
                }
                else if (Pgtype == "job")
                {
                    itemNumber = row4["JobItemNumber"].ToString();
                }
                else if (Pgtype == "invoice")
                {
                    itemNumber = row4["JobItemNumber"].ToString();
                }
                else if(Pgtype == "order")
                {
                    itemNumber = row4["OrderItemNumber"].ToString();
                }

                
                string[] languageConversion;
                MasterPage master = this.Parent.Page.Master;
                HtmlControl htmlControl = master.FindControl("DivLeftpanel") as HtmlControl;
                HtmlGenericControl contextPanel = master.FindControl("contextPanel") as HtmlGenericControl;
                if (htmlControl != null)
                {
                    htmlControl.Visible = false;
                }
                if (contextPanel != null)
                {
                    contextPanel.Visible = false;
                }

                this.plhItems.Controls.Add(new LiteralControl("<div class='sortingdivs' id='" + row4["EstimateItemID"] + "' style='width:100%;margin-top:5px' data-number='" + Convert.ToInt32(row4["Estimate_Item_Number"]) + "' id='' data-value='sortable'>"));
                ControlCollection controls1 = this.plhItems.Controls;
                languageConversion = new string[] { "<h3 class='sortingdivs' id='" + row4["EstimateItemID"] + "' data-number='" + Convert.ToInt32(row4["Estimate_Item_Number"]) + "' data-value='sortable' ", ">" };
                controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0'  border='0' width='100%' >"));
                this.plhItems.Controls.Add(new LiteralControl("<tr bgcolor='#ddd' class='sortingdivs' data-value='sortable' id='" + row4["EstimateItemID"] + "'>"));
                this.plhItems.Controls.Add(new LiteralControl("<td style='width: 185px; border: 1px solid #ddd; padding: 8px;'> " + itemNumber + "              --              " + System.Net.WebUtility.UrlDecode(row4["ItemTitle"].ToString()) + "  "));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</h3>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
            }
        }
    }
}