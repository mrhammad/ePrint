using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public class FtpRouteSetting
    {
        public string SectionName { get; set; }
        public string ActionName { get; set; }
        public int StatusValue { get; set; }
        public bool IsSelected { get; set; }
    }
    public partial class FTPRoute : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        public int CompanyID;

        public int UserID;

        private SettingsBasePage obj = new SettingsBasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("FTP_Route_Settings");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("FTP_Route_Settings");
            base.Session["pagename"] = "setting";
            if (!base.IsPostBack)
            {
                this.obj.Bind_Status_new(this.ddlJobStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                this.obj.Bind_Status_new(this.ddlInvoiceStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "invoice");
                this.obj.Bind_Status_new(this.ddlProductEstimateStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "estimate");
                this.obj.Bind_Status_new(this.ddlProductJobStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                this.obj.Bind_Status_new(this.ddlProductInvoiceStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "invoice");
                this.obj.Bind_Status_new(this.ddlOrderStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "webstoreorder");

                LoadFtpSettings();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string orderAction = string.Empty;
            string productAction = string.Empty;
            int orderStatusValue = 0;
            int productStatusValue = 0;

            // Determine OnlineOrder action
            if (rdoOrderCreation.Checked)
            {
                orderAction = "OrderCreation";
            }
            else if (rdoJobCreation.Checked)
            {
                orderAction = "JobCreation";
            }
            else if (rdoInvoiceCreation.Checked)
            {
                orderAction = "InvoiceCreation";
            }
            else if (rdoOrderStatus.Checked)
            {
                orderAction = "OrderStatus";
                orderStatusValue =Convert.ToInt32(this.ddlOrderStatus.SelectedValue);
            }
            else if (rdoJobStatus.Checked)
            {
                orderAction = "JobStatus";
                orderStatusValue = Convert.ToInt32(this.ddlJobStatus.SelectedValue);
            }
            else if (rdoInvoiceStatus.Checked)
            {
                orderAction = "InvoiceStatus";
                orderStatusValue = Convert.ToInt32(this.ddlInvoiceStatus.SelectedValue);
            }
            else
            {
                orderAction = "";
            }

            // Determine ProductEstimate action
            if (rdoProductEstimateCreation.Checked)
            {
                productAction = "EstimateCreation";
            }
            else if (rdoProductJobCreation.Checked)
            {
                productAction = "JobCreation";
            }
            else if (rdoProductInvoiceCreation.Checked)
            {
                productAction = "InvoiceCreation";
            }
            else if (rdoProductEstimateStatus.Checked)
            {
                productAction = "EstimateStatus";
                productStatusValue = Convert.ToInt32(this.ddlProductEstimateStatus.SelectedValue);
            }
            else if (rdoProductJobStatus.Checked)
            {
                productAction = "JobStatus";
                productStatusValue = Convert.ToInt32(this.ddlProductJobStatus.SelectedValue);
            }
            else if (rdoProductInvoiceStatus.Checked)
            {
                productAction = "InvoiceStatus";
                productStatusValue = Convert.ToInt32(this.ddlProductInvoiceStatus.SelectedValue);
            }
            else
            {
                productAction = "";
            }

            // Save settings
            SettingsBasePage.SaveFtpRouteSetting(this.CompanyID, "OnlineOrder", orderAction, orderStatusValue, true);
            SettingsBasePage.SaveFtpRouteSetting(this.CompanyID, "ProductEstimate", productAction, productStatusValue, true);
            //SaveFtpSetting("OnlineOrder", onlineOrderValue);
            //SaveFtpSetting("ProductEstimate", productEstimateValue);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
            LoadFtpSettings();
            //lblMessage.Text = "✅ Settings updated successfully.";
            //lblMessage.Visible = true;
        }

        private void LoadFtpSettings()
        {
            var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);

            var online = settings.FirstOrDefault(s => s.SectionName == "OnlineOrder");
            if (online != null)
            {
                switch (online.ActionName)
                {
                    case "OrderCreation": rdoOrderCreation.Checked = true; break;
                    case "JobCreation": rdoJobCreation.Checked = true; break;
                    case "InvoiceCreation": rdoInvoiceCreation.Checked = true; break;
                    case "OrderStatus": rdoOrderStatus.Checked = true; ddlOrderStatus.SelectedValue = online.StatusValue.ToString(); break;
                    case "JobStatus": rdoJobStatus.Checked = true; ddlJobStatus.SelectedValue = online.StatusValue.ToString(); break;
                    case "InvoiceStatus": rdoInvoiceStatus.Checked = true; ddlInvoiceStatus.SelectedValue = online.StatusValue.ToString(); break;
                    case "": rdoOrderNone.Checked = true; break;
                }
            }

            var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
            if (product != null)
            {
                switch (product.ActionName)
                {
                    case "EstimateCreation": rdoProductEstimateCreation.Checked = true; break;
                    case "JobCreation": rdoProductJobCreation.Checked = true; break;
                    case "InvoiceCreation": rdoProductInvoiceCreation.Checked = true; break;
                    case "EstimateStatus": rdoProductEstimateStatus.Checked = true; ddlProductEstimateStatus.SelectedValue = product.StatusValue.ToString(); break;
                    case "JobStatus": rdoProductJobStatus.Checked = true; ddlProductJobStatus.SelectedValue = product.StatusValue.ToString(); break;
                    case "InvoiceStatus": rdoProductInvoiceStatus.Checked = true; ddlProductInvoiceStatus.SelectedValue = product.StatusValue.ToString(); break;
                    case "": rdoProductNone.Checked = true; break;
                }
            }
        }
    }
}