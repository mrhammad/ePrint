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
    public partial class Completion_Update : System.Web.UI.UserControl
    {
        public string DateFormat { get; set; }
        public long CompanyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt64(base.Session["CompanyID"]);
            if (!Page.IsPostBack)
            {
                DateFormat = hdnDateFormat.Value;
            }
        }

        protected void btnSaveCompletionDate_Click(object sender, EventArgs e)
        {
            this.divLoadingImage.Style.Add("display", "block");
            //Validation on client side to be applied
            string artworkDate = txtCompletionDate.Text;
            string jobId = hdnJobId.Value;
            string estimateItemID = hdnEstimateItemID.Value;
            DateTime parsedArtworkDate = new DateTime();
            if (hdnDateFormat.Value == "dd/mm/yyyy")
            {
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
                // fetch the en-GB culture
                CultureInfo ukCulture = new CultureInfo("en-GB");
                parsedArtworkDate = DateTime.Parse(artworkDate, ukCulture.DateTimeFormat);

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
            }
            else
            {
                parsedArtworkDate = DateTime.Parse(artworkDate);
            }

            if (!string.IsNullOrEmpty(jobId) && !string.IsNullOrEmpty(estimateItemID))
            {
                //update the delivery date
                string type = "CompletionDate";
                Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedArtworkDate, type);

                var script = "saveCallback();";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", script, true);

            }


        }

    }
}