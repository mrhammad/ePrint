using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
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
    public partial class SinceSettings : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private commonClass objJava = new commonClass();

        public BasePage objPage = new BasePage();

        public int CompanyID;

        public languageClass objlang = new languageClass();

        private Global gloobj = new Global();
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.InsertUpdate_DaysSince_Settings(this.CompanyID, this.txtEstimateStatus.Text, this.txtOrderStatus.Text, this.txtProofStatus.Text, this.txtProofFileStatus.Text, this.txtJobStatus.Text, this.txtPOStatus.Text, this.txtInvoiceStatus.Text, this.txtDNStatus.Text, this.txtEstimateEmail.Text, this.txtOrderEmail.Text, this.txtProofEmail.Text, this.txtProofFileEmail.Text, this.txtJobEmail.Text, this.txtPOEmail.Text, this.txtInvoiceEmail.Text, this.txtDNEmail.Text ,this.chkEstimateStatus.Checked ? 1 : 0,  // Adding new BIT parameters
                                                    this.chkOrderStatus.Checked ? 1 : 0,
                                                    this.chkProofStatus.Checked ? 1 : 0,
                                                    this.chkProoffileStatus.Checked ? 1 : 0,
                                                    this.chkJobStatus.Checked ? 1 : 0,
                                                    this.chkPOStatus.Checked ? 1 : 0,
                                                    this.chkInvStatus.Checked ? 1 : 0,
                                                    this.chkDNStatus.Checked ? 1 : 0,
                                                    this.chkEstEmail.Checked ? 1 : 0,
                                                    this.chkOrdEmail.Checked ? 1 : 0,
                                                    this.chkProofEmail.Checked ? 1 : 0,
                                                    this.chkProofFileEmail.Checked ? 1 : 0,
                                                    this.chkJobEmail.Checked ? 1 : 0,
                                                    this.chkPOEmail.Checked ? 1 : 0,
                                                    this.chkInvoiceEmail.Checked ? 1 : 0,
                                                    this.chkDNEmail.Checked ? 1 : 0);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = "Days Since Setting";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_Settings")));
            base.Title = "Days Since Settings";//this.objLanguage.convert(global.pageTitle("Days Since Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Select_DaysSince_Settings(this.CompanyID).Rows)
                {
                    txtEstimateStatus.Text = row["eststatus"].ToString();
                    txtOrderStatus.Text = row["ordstatus"].ToString();
                    txtProofStatus.Text = row["proofstatus"].ToString();
                    txtProofFileStatus.Text = row["prooffilestatus"].ToString();
                    txtJobStatus.Text = row["jobstatus"].ToString();
                    txtPOStatus.Text = row["postatus"].ToString();
                    txtInvoiceStatus.Text = row["invstatus"].ToString();
                    txtDNStatus.Text = row["dnstatus"].ToString();
                    txtEstimateEmail.Text = row["estemail"].ToString();
                    txtOrderEmail.Text = row["ordemail"].ToString();
                    txtProofEmail.Text = row["proofemail"].ToString();
                    txtProofFileEmail.Text = row["prooffileemail"].ToString();
                    txtJobEmail.Text = row["jobemail"].ToString();
                    txtPOEmail.Text = row["poemail"].ToString();
                    txtInvoiceEmail.Text = row["invemail"].ToString();
                    txtDNEmail.Text = row["dnemail"].ToString();

                    chkEstimateStatus.Checked = Convert.ToBoolean(row["iseststatus"]);
                    chkOrderStatus.Checked = Convert.ToBoolean(row["isordstatus"]);
                    chkProofStatus.Checked = Convert.ToBoolean(row["isproofstatus"]);
                    chkProoffileStatus.Checked = Convert.ToBoolean(row["isprooffilestatus"]);
                    chkJobStatus.Checked = Convert.ToBoolean(row["isjobstatus"]);
                    chkPOStatus.Checked = Convert.ToBoolean(row["ispostatus"]);
                    chkInvStatus.Checked = Convert.ToBoolean(row["isinvstatus"]);
                    chkDNStatus.Checked = Convert.ToBoolean(row["isdnstatus"]);
                    chkEstEmail.Checked = Convert.ToBoolean(row["isestemail"]);
                    chkOrdEmail.Checked = Convert.ToBoolean(row["isordemail"]);
                    chkProofEmail.Checked = Convert.ToBoolean(row["isproofemail"]);
                    chkProofFileEmail.Checked = Convert.ToBoolean(row["isprooffileemail"]);
                    chkJobEmail.Checked = Convert.ToBoolean(row["isjobemail"]);
                    chkPOEmail.Checked = Convert.ToBoolean(row["ispoemail"]);
                    chkInvoiceEmail.Checked = Convert.ToBoolean(row["isinvemail"]);
                    chkDNEmail.Checked = Convert.ToBoolean(row["isdnemail"]);

                }

            }
        }
    }
}