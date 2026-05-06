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
    public partial class CustomDate_Update : System.Web.UI.UserControl
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

        protected void btnSaveCustomDate_Click(object sender, EventArgs e)
        {
            this.divLoadingImage.Style.Add("display", "block");
            //Validation on client side to be applied
            string CustomDate = txtCustomDate.Text;
            string jobId = hdnJobId.Value;
            string estimateItemID = hdnEstimateItemID.Value;
            string dateNo = hdnDateNo.Value;
            DateTime parsedCustomDateDate = new DateTime();
            if (hdnDateFormat.Value == "dd/mm/yyyy")
            {
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
                // fetch the en-GB culture
                CultureInfo ukCulture = new CultureInfo("en-GB");
                parsedCustomDateDate = DateTime.Parse(CustomDate, ukCulture.DateTimeFormat);

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
            }
            else
            {
                parsedCustomDateDate = DateTime.Parse(CustomDate);
            }

            if (!string.IsNullOrEmpty(jobId) && !string.IsNullOrEmpty(estimateItemID))
            {
                if (dateNo == "1")
                {
                    string type = "CustomDate1";
                    Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedCustomDateDate, type);
                }
                else if (dateNo == "2")
                {
                    string type = "CustomDate2";
                    Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedCustomDateDate, type);
                }
                else if (dateNo == "3")
                {
                    string type = "CustomDate3";
                    Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedCustomDateDate, type);
                }
                else if (dateNo == "4")
                {
                    string type = "CustomDate4";
                    Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedCustomDateDate, type);
                }
                else if (dateNo == "5")
                {
                    string type = "CustomDate5";
                    Settings.UpdateJobDates(this.CompanyID, long.Parse(jobId), long.Parse(estimateItemID), parsedCustomDateDate, type);
                }

                var script = "saveCallback();";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", script, true);

            }


        }
    }
}