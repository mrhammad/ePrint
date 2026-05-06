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
    public partial class Dates : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private commonClass objJava = new commonClass();

        public BasePage objPage = new BasePage();

        public int CompanyID;

        public languageClass objlang = new languageClass();

        private Global gloobj = new Global();
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.PC_settings_default_Dates_insert(this.CompanyID, Convert.ToInt32(this.txtValidFor.Text.ToString()), this.txtDefaultEstimated.Text, this.txtEstimateProof.Text, this.TxtEstimateApproval.Text, this.txtEstimateProduction.Text, this.txtEstimatedCompletion.Text, this.txtEstimateDelivery.Text, this.chkEstimateArtwork.Checked, this.chkEstimateProof.Checked, this.chkEstimateApproval.Checked, this.chkEstimateProduction.Checked, this.chkEstimateCompletion.Checked, this.chkEstimateDelivery.Checked, this.chkCustomDate1.Checked, this.chkCustomDate2.Checked, this.chkCustomDate3.Checked, this.chkCustomDate4.Checked, this.chkCustomDate5.Checked, this.txtCustomDate1.Text, this.txtCustomDate2.Text, this.txtCustomDate3.Text, this.txtCustomDate4.Text, this.txtCustomDate5.Text, this.txtCustomDateTitle1.Text, this.txtCustomDateTitle2.Text, this.txtCustomDateTitle3.Text, this.txtCustomDateTitle4.Text, this.txtCustomDateTitle5.Text );
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = "Dates Settings";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", "Dates Settings"));
            base.Title = "Dates Settings";//this.objLanguage.convert(global.pageTitle("Days Since Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.chkEstimateArtwork.ToolTip = this.objlang.GetLanguageConversion("tooltip_artwork_date");
            this.chkEstimateProof.ToolTip = this.objlang.GetLanguageConversion("tooltip_proof_date");
            this.chkEstimateApproval.ToolTip = this.objlang.GetLanguageConversion("tooltip_approval_date");
            this.chkEstimateProduction.ToolTip = this.objlang.GetLanguageConversion("tooltip_production_date");
            this.chkEstimateCompletion.ToolTip = this.objlang.GetLanguageConversion("tooltip_completion_date");
            this.chkEstimateDelivery.ToolTip = this.objlang.GetLanguageConversion("tooltip_delivery_date");

            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.txtValidFor.Text = row["ValidFor"].ToString();
                    this.txtDefaultEstimated.Text = row["DefaultEstimatedArtwork"].ToString();
                    this.txtEstimateProof.Text = row["DefaultEstimatedProof"].ToString();
                    this.TxtEstimateApproval.Text = row["DefaultEstimatedApproval"].ToString();
                    this.txtEstimateProduction.Text = row["DefaultEstimatedProduction"].ToString();
                    this.txtEstimatedCompletion.Text = row["DefaultEstimatedCompletion"].ToString();
                    this.txtEstimateDelivery.Text = row["DefaultEstimatedDelivery"].ToString();
                    this.txtCustomDate1.Text = row["DefaultCustomDate1"].ToString();
                    this.txtCustomDate2.Text = row["DefaultCustomDate2"].ToString();
                    this.txtCustomDate3.Text = row["DefaultCustomDate3"].ToString();
                    this.txtCustomDate4.Text = row["DefaultCustomDate4"].ToString();
                    this.txtCustomDate5.Text = row["DefaultCustomDate5"].ToString();
                    this.txtCustomDateTitle1.Text = row["DefaultCustomDateTitle1"].ToString();
                    this.txtCustomDateTitle2.Text = row["DefaultCustomDateTitle2"].ToString();
                    this.txtCustomDateTitle3.Text = row["DefaultCustomDateTitle3"].ToString();
                    this.txtCustomDateTitle4.Text = row["DefaultCustomDateTitle4"].ToString();
                    this.txtCustomDateTitle5.Text = row["DefaultCustomDateTitle5"].ToString();


                    if (!Convert.ToBoolean(row["IsDefaultArtwork"]))
                    {
                        this.chkEstimateArtwork.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateArtwork.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultProof"]))
                    {
                        this.chkEstimateProof.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateProof.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultApproval"]))
                    {
                        this.chkEstimateApproval.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateApproval.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultProduction"]))
                    {
                        this.chkEstimateProduction.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateProduction.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultCompletion"]))
                    {
                        this.chkEstimateCompletion.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateCompletion.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultDelivery"]))
                    {
                        this.chkEstimateDelivery.Checked = false;
                    }
                    else
                    {
                        this.chkEstimateDelivery.Checked = true;
                    }

                    if (!Convert.ToBoolean(row["IsDefaultCustomDate1"]))
                    {
                        this.chkCustomDate1.Checked = false;
                    }
                    else
                    {
                        this.chkCustomDate1.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultCustomDate2"]))
                    {
                        this.chkCustomDate2.Checked = false;
                    }
                    else
                    {
                        this.chkCustomDate2.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultCustomDate3"]))
                    {
                        this.chkCustomDate3.Checked = false;
                    }
                    else
                    {
                        this.chkCustomDate3.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultCustomDate4"]))
                    {
                        this.chkCustomDate4.Checked = false;
                    }
                    else
                    {
                        this.chkCustomDate4.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultCustomDate5"]))
                    {
                        this.chkCustomDate5.Checked = false;
                    }
                    else
                    {
                        this.chkCustomDate5.Checked = true;
                    }





                }
                bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
                if (!ConnectionClass.Is_Non_Printing_System)
                {
                  
                    this.div_Default_Arkwork.Attributes.Add("style", " display:block");
                    this.div_DefaultProof.Attributes.Add("style", " display:block");
                }
                else
                {
                 
                    this.div_Default_Arkwork.Attributes.Add("style", " display:none");
                    this.div_DefaultProof.Attributes.Add("style", " display:none");
                }

            }
        }
    }
}