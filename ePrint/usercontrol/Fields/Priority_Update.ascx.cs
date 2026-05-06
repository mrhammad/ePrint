using Printcenter.BusinessAccessLayer.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Fields
{
    public partial class Priority_Update : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i <= 9; i++)
                {
                    ddlPriority.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                // Optionally set a default selected value
                ddlPriority.SelectedValue = string.IsNullOrEmpty(this.hdnpriority.Value)? "1": this.hdnpriority.Value;

            }
        }

        protected void btnSavePriority_Click(object sender, EventArgs e)
        {
            string type = string.Empty;
            this.divLoadingImage.Style.Add("display", "block");
            string selectedpriority = ddlPriority.SelectedItem.Value;
            string id = hdnId.Value;
            string page = hdnpage.Value;

            if (!string.IsNullOrEmpty(id))
            {
                //update the delivery date
                Settings.UpdatePriority(long.Parse(id), selectedpriority,page);
                var script = @"
            if (window.parent.closeDialog) {
                window.parent.closeDialog();
            }
            if (window.parent.location) {
                window.parent.location.reload(true);
            } else {
                window.location.reload(true);
            }";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseAndReload", script, true);
            }


        }
    }
}