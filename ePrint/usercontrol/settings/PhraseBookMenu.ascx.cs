using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.usercontrol.settings
{
    public partial class PhraseBookMenu : System.Web.UI.UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public static int ManageStockPermission;

        public BaseClass objclass = new BaseClass();

        public BasePage ObjPage = new BasePage();

        public int CompanyID;

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

        static PhraseBookMenu()
        {
        }

        public PhraseBookMenu()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (commonClass.CheckProofPermission())
            {
                this.prooftr1.Visible = true;
                this.prooftr2.Visible = true;
            }
            else
            {
                this.prooftr1.Visible = false;
                this.prooftr2.Visible = false;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(Convert.ToInt16(base.Session["Companyid"]));
            PhraseBookMenu.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            if (base.Request.QueryString["Mtype"] != "PB")
            {
                this.tblPhresebook.Visible = false;
                this.tblEmail.Visible = true;
            }
            else
            {
                this.tblPhresebook.Visible = true;
                this.tblEmail.Visible = false;
            }
            if (!SettingsBasePage.Fetch_SupplierQuote(Convert.ToInt16(base.Session["Companyid"])))
            {
                this.tr30.Visible = false;
            }
            else
            {
                this.tr30.Visible = true;
            }
            if (this.InventoryManagement.ToLower() != "im")
            {
                this.Tr3.Visible = false;
            }
            if (PhraseBookMenu.ManageStockPermission != 1)
            {
                this.Tr2.Visible = false;
            }
            this.Tr5.Visible = false;
            if (base.Session["CustomAccessRight"] != null && base.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true")
            {
                this.Tr5.Visible = true;
            }
            this.objclass.Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID));
            this.DivAlertNotificationSetting.Style.Add("display", "block");
            this.DivAlertNotificationSetting1.Style.Add("display", "block");
        }
    }
}