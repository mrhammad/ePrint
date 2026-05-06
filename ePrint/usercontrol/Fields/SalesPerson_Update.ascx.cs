using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Fields
{
    public partial class SalesPerson_Update : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Bind Drop down
                DataTable dataTable = SettingsBasePage.settings_user_select_forddl(Convert.ToInt32(Session["CompanyID"]));
                this.ddlSalesPerson.DataSource = dataTable;
                this.ddlSalesPerson.DataTextField = "LimitName";
                this.ddlSalesPerson.DataValueField = "UserID";
                this.ddlSalesPerson.DataBind();
                if (!string.IsNullOrEmpty(hdnSalesPersonId.Value))
                {
                    var selectedItem = this.ddlSalesPerson.Items.FindByValue(hdnSalesPersonId.Value);
                    if (selectedItem != null)
                    {
                        selectedItem.Selected = true;
                    }
                   // this.ddlSalesPerson.SelectedItem.Value = hdnSalesPersonId.Value;
                }
                if (!string.IsNullOrEmpty(hdnType.Value))
                {
                    this.salesPersonLablel.Text = "Estimator";
                }
                


            }
        }

        protected void btnSaveSalesPerson_Click(object sender, EventArgs e)
        {
            string type = string.Empty;
            this.divLoadingImage.Style.Add("display", "block");
            string selectedSalesPersonId = ddlSalesPerson.SelectedItem.Value;
            string jobId = hdnJobId.Value;
            if(hdnType.Value != null)
            {
                type = hdnType.Value;
            }
            if (!string.IsNullOrEmpty(jobId))
            {
                //update the delivery date
                Settings.UpdateSalesPerson(long.Parse(jobId), long.Parse(selectedSalesPersonId),type);
                var script = "saveCallback();";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", script, true);
            }
            

        }
    }
}