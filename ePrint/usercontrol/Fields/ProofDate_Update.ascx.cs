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
    public partial class ProofDate_Update : System.Web.UI.UserControl
    {
        public string DateFormat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateFormat = hdnDateFormat.Value;
            }
        }

        protected void btnSaveProofDate_Click(object sender, EventArgs e)
        {
            this.divLoadingImage.Style.Add("display", "block");
            //Validation on client side to be applied
            string proofDate = txtProofDate.Text;
            string jobId = hdnJobId.Value;
            DateTime parsedProofDate = new DateTime();
            if (hdnDateFormat.Value == "dd/mm/yyyy")
            {
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
                // fetch the en-GB culture
                CultureInfo ukCulture = new CultureInfo("en-GB");
                parsedProofDate = DateTime.Parse(proofDate, ukCulture.DateTimeFormat);

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
            }
            else
            {
                parsedProofDate = DateTime.Parse(proofDate);
            }

            if (!string.IsNullOrEmpty(jobId))
            {
                //update the proof date
                Settings.UpdateJobProofDate(long.Parse(jobId), parsedProofDate);

                var script = "saveCallback();";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", script, true);

            }


        }
    }
}