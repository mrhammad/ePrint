using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class LockOption : BaseClass, IRequiresSessionState
    {
        public int CompanyID;
        private Global gloobj = new Global();
        public int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.header_mis.SettingName = "Lock Options";

            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());

            if (!IsPostBack)
            {


              
                string status = SettingsBasePage.PC_select_ProductEditingOption_Status(CompanyID);

                if (status == "LockEditingDescStatus")
                {
                    this.ddlLockTypes.SelectedIndex = 2;
                }
                else if (status == "LockEditingDesc")
                {
                    this.ddlLockTypes.SelectedIndex = 1;
                }
                else
                {
                    this.ddlLockTypes.SelectedIndex = 0;
                }

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            SettingsBasePage.PC_Update_ProductEditingOption_Status(CompanyID, ddlLockTypes.SelectedItem.Value.ToString());
        }
    }
}