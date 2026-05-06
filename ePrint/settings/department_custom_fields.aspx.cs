using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class department_custom_fields : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

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

        public department_custom_fields()
        {
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.grdcustomfields.MasterTableView.Items)
            {
                TextBox textBox = (TextBox)item.FindControl("txtScreenName");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnLabelID");
                if (base.Request.QueryString["type"] != "Dept")
                {
                    this.objcomm.Updatecontactcustomfields(this.CompanyID, Convert.ToInt32(hiddenField.Value), base.SpecialEncode(textBox.Text));
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Contact_Custom_Fields_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else
                {
                    this.objcomm.UpdateDepartmentcustomfields(this.CompanyID, Convert.ToInt32(hiddenField.Value), base.SpecialEncode(textBox.Text));
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Department_Custom_Fields_Updated_Successfully"), "msg-success", this.plhMessage);
                }
            }
        }

        public void GridBind()
        {
            DataTable dataTable = this.objcomm.departmentcustomfields(this.CompanyID);
            this.grdcustomfields.DataSource = dataTable;
            this.grdcustomfields.DataBind();
        }

        public void GridBindContact()
        {
            DataTable dataTable = this.objcomm.contactcustomfields(this.CompanyID);
            this.grdcustomfields.DataSource = dataTable;
            this.grdcustomfields.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            if (base.Request.QueryString["type"] != "Dept")
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Contact Custom Fields", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Contact_Custom_Fields")));
                this.header_mis.SettingName = this.objlang.GetLanguageConversion("Contact_Custom_Fields");
            }
            else
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Department Custom Fields", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Department_Custom_Fields")));
                this.header_mis.SettingName = this.objlang.GetLanguageConversion("Department_Custom_Fields");
            }
            this.btnUpdate.Text = this.objLanguage.GetLanguageConversion("Update");
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["type"] == "Dept")
                {
                    this.GridBind();
                    return;
                }
                this.GridBindContact();
            }
        }
    }
}