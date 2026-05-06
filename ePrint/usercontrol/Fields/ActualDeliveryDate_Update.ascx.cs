using Printcenter.BusinessAccessLayer.Setting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Fields
{
    public partial class ActualDeliveryDate_Update : System.Web.UI.UserControl
    {
        public string DateFormat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateFormat = hdnDateFormat.Value;
            }
        }
        protected void btnSaveDeliveryDate_Click(object sender, EventArgs e)
        {
            this.divLoadingImage.Style.Add("display", "block");
            //Validation on client side to be applied
            string actualDeliveryDate = txtActualDeliveryDate.Text;
            string jobId = hdnJobId.Value;
            string estimateItemID = hdnEstimateItemID.Value;
            DateTime parsedDeliveryDate = new DateTime();
            if (hdnDateFormat.Value == "dd/mm/yyyy")
            {
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
                // fetch the en-GB culture
                CultureInfo ukCulture = new CultureInfo("en-GB");
                parsedDeliveryDate = DateTime.Parse(actualDeliveryDate, ukCulture.DateTimeFormat);

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
            }
            else
            {
                parsedDeliveryDate = DateTime.Parse(actualDeliveryDate);
            }

            if (!string.IsNullOrEmpty(jobId) && !string.IsNullOrEmpty(estimateItemID))
            {
                //update the delivery date
                string type = "actual";
                Settings.UpdateJobEstimatedDeliveryDate(long.Parse(jobId), long.Parse(estimateItemID), parsedDeliveryDate, type);

                var script = "saveCallback();";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", script, true);

            }


        }

    }
}