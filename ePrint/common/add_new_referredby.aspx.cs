using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class add_new_referredby : System.Web.UI.Page, IRequiresSessionState
    {
        public string url;

        public languageClass objLanguage = new languageClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private commonClass objCommon = new commonClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BasePage objpage = new BasePage();

        public string tabcolor = string.Empty;

        private Global gloobj = new Global();

        private BaseClass ObjBaseClass = new BaseClass();

        public int CompanyID;

        public int ReferredByID;

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

        public add_new_referredby()
        {
        }

        protected void btnSaveReffered_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Setting_ReferencedBy_InsertUpdate(0, Convert.ToInt32(this.CompanyID.ToString()), this.ObjBaseClass.SpecialEncode(this.txtRefferedBy.Text), this.ObjBaseClass.SpecialEncode(this.txtCommision.Text), Convert.ToBoolean(0), this.chkDefault.Checked);
            string str = string.Concat("SELECT ReferencedID FROM tb_clientReferencedBy WHERE IsDeleted = 0 AND Name = '", this.ObjBaseClass.SpecialEncode(this.txtRefferedBy.Text), "'");
            SqlCommand sqlCommand = new SqlCommand(str, this.objCommon.openConnection())
            {
                CommandType = CommandType.Text
            };
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    this.Session["Flag"] = true;
                    this.ReferredByID = int.Parse(sqlDataReader["ReferencedID"].ToString());
                }
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "ddl();", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Title = this.objLanguage.GetLanguageConversion("Add_New_Referred_By");
            this.btnSaveReffered.Text = this.objLanguage.GetLanguageConversion("Save");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.CompanyID = int.Parse(this.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                this.txtRefferedBy.Focus();
            }
        }
    }
}