using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class AddressLabels : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadGrid GridAddressLabel;

        //protected Button btnUpdate;

        //protected Label LblNote;

        private Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        private commonClass objJava = new commonClass();

        private BasePage objLog = new BasePage();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        private CompanyBasePage objcomm = new CompanyBasePage();

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

        public AddressLabels()
        {
        }

        public void btnUpdate_OnClick(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.GridAddressLabel.MasterTableView.Items)
            {
                TextBox textBox = (TextBox)item.FindControl("txtAddressValue");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnLabelID");
                CheckBox checkBox = (CheckBox)item.FindControl("chkRequired");
                SqlCommand sqlCommand = new SqlCommand("pc_update_addresslabels", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.Add("@labelID", Convert.ToInt32(hiddenField.Value.ToString()));
                sqlCommand.Parameters.Add("@addressValue", textBox.Text);
                sqlCommand.Parameters.Add("@isRequired", checkBox.Checked);
                sqlCommand.ExecuteNonQuery();
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Address_Value_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        public void GridBind()
        {
            DataTable dataTable = this.objcomm.Clientaddresslabels(this.CompanyID);
            this.GridAddressLabel.DataSource = dataTable;
            this.GridAddressLabel.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnUpdate.Text = this.objLanguage.GetLanguageConversion("Update");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.lblheader.Text = this.objLanguage.GetLanguageConversion("Address_Labels");
            if (!base.IsPostBack)
            {
                this.GridBind();
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Address Labels", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Appearance_Address_Labels")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Address_Labels");
        }
    }
}