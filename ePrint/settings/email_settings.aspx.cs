using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class email_settings : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected Label lbl_fromemail;

        //protected TextBox txt_fromemail;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator rfv_fromemail;

        //protected RadioButton rdbFromEprint;

        //protected CheckBox Chk_cc;

        //protected TextBox txt_cc;

        //protected HtmlImage img_help_productthumbnail;

        //protected HiddenField hdn_cc;

        //protected CheckBox Chk_bcc;

        //protected TextBox txt_bcc;

        //protected HtmlImage img1;

        //protected HiddenField hdn_bcc;

        //protected Label lbl_SupplierText;

        //protected HiddenField hdn_ChkSuplier;

        //protected CheckBox Chk_SupplierRFQ;

        //protected CheckBox Chk_SuplrAttachLink;

        //protected Label Label1;

        //protected HiddenField hdn_PUrchase;

        //protected CheckBox Chk_Purchase;

        //protected CheckBox Chk_POAttachLink;

        //protected CheckBox Chk_AttachDeliveryNote;

        //protected CheckBox Chk_estoreAttach;

        //protected RadioButton rdbFromOthers;

        //protected HtmlImage img4;

        //protected CheckBox Chk_cc_Other;

        //protected TextBox txt_cc_Other;

        //protected HtmlImage img3;

        //protected HiddenField hdn_cc_Other;

        //protected CheckBox Chk_bcc_Other;

        //protected TextBox txt_bcc_Other;

        //protected HtmlImage img2;

        //protected HiddenField hdn_bcc_Other;

        //protected RadButton btnCancel;

        //protected Button btnSave;

        //protected HtmlGenericControl div_btnsave;

        //protected HtmlGenericControl div_btnsaveprocess;

        //protected HiddenField hid_EmailSettingId;

        //protected LinkButton lnk_Validate;

        //protected LinkButton lnk_OtherEmailSettings;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private languageClass objLanguage = new languageClass();

        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public int EmailSettingID;

        private string EmailSettingType = string.Empty;

        public languageClass objlang = new languageClass();

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

        public email_settings()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            bool flag = true;
            bool flag1 = true;
            bool flag2 = true;
            bool flag3 = true;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            if (this.rdbFromEprint.Checked)
            {
                this.EmailSettingType = "e";
                flag = (!this.Chk_SupplierRFQ.Checked ? false : true);
                flag1 = (!this.Chk_Purchase.Checked ? false : true);
                if (!this.Chk_cc.Checked)
                {
                    flag2 = false;
                    this.hdn_cc.Value = this.txt_cc.Text;
                }
                else
                {
                    flag2 = true;
                    this.hdn_cc.Value = this.txt_cc.Text;
                }
                if (!this.Chk_bcc.Checked)
                {
                    flag3 = false;
                    this.hdn_bcc.Value = this.txt_bcc.Text;
                }
                else
                {
                    flag3 = true;
                    this.hdn_bcc.Value = this.txt_bcc.Text;
                }
                if (this.Chk_SuplrAttachLink.Checked)
                {
                    flag4 = true;
                }
                if (this.Chk_POAttachLink.Checked)
                {
                    flag5 = true;
                }
                if (this.Chk_AttachDeliveryNote.Checked)
                {
                    flag6 = true;
                }
                if (this.Chk_estoreAttach.Checked)
                {
                    flag7 = true;
                }
                SettingsBasePage.settings_EmailSetting_Email_Eprint(this.CompanyID, Convert.ToInt32(this.hid_EmailSettingId.Value), this.EmailSettingType, base.SpecialEncode(this.hdn_bcc.Value), base.SpecialEncode(this.hdn_cc.Value), this.UserID, flag, flag1, flag2, flag3, flag4, flag5, flag6, flag7);
            }
            else if (this.rdbFromOthers.Checked)
            {
                bool flag8 = true;
                bool flag9 = true;
                this.EmailSettingType = "o";
                if (!this.Chk_cc_Other.Checked)
                {
                    flag8 = false;
                    this.hdn_cc_Other.Value = this.txt_cc_Other.Text;
                }
                else
                {
                    flag8 = true;
                    this.hdn_cc_Other.Value = this.txt_cc_Other.Text;
                }
                if (!this.Chk_bcc_Other.Checked)
                {
                    flag9 = false;
                    this.hdn_bcc_Other.Value = this.txt_bcc_Other.Text;
                }
                else
                {
                    flag9 = true;
                    this.hdn_bcc_Other.Value = this.txt_bcc_Other.Text;
                }
                SettingsBasePage.settings_emailsetting_insert(this.CompanyID, Convert.ToInt32(this.hid_EmailSettingId.Value), this.EmailSettingType, base.SpecialEncode(this.hdn_bcc_Other.Value), base.SpecialEncode(this.hdn_cc_Other.Value), this.UserID, flag8, flag9);
            }
            if (this.txt_fromemail.Text != "")
            {
                SettingsBasePage.Settings_fromemail_save(Convert.ToInt32(this.Session["CompanyID"].ToString()), this.txt_fromemail.Text);
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/email_settings.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "javascript:var a=Validating();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a;");
            this.btnCancel.Attributes.Add("onclick", "javascript: loadingimg('div_btnCancel','div_btnCancelprocess');");
            this.rdbFromEprint.Text = this.objlang.GetLanguageConversion("Send_All_Email_From_Eprint");
            this.rdbFromOthers.Text = this.objlang.GetLanguageConversion("Send_all_emails_via_your_preferred_local_email_client");
            this.lbl_fromemail.Text = this.objlang.GetLanguageConversion("From_Email_Name");
            this.lbl_SupplierText.Text = this.objlang.GetLanguageConversion("While_sending_Supplier_RFQ_attach_all_item_specific_files_to_the_email");
            this.Chk_SupplierRFQ.Text = this.objlang.GetLanguageConversion("Attach_As_Attachment");
            this.Chk_SuplrAttachLink.Text = this.objlang.GetLanguageConversion("Attach_As_Link");
            this.Label1.Text = this.objlang.GetLanguageConversion("While_sending_a_Purchase_Order_to_an_Outwork_Supplier_attach_all_item_specific_files_to_the_email");
            this.Chk_Purchase.Text = this.objlang.GetLanguageConversion("Attach_As_Attachment");
            this.Chk_POAttachLink.Text = this.objlang.GetLanguageConversion("Attach_As_Link");
            this.Chk_AttachDeliveryNote.Text = this.objlang.GetLanguageConversion("Attach_Delivery_Note");
            this.Chk_estoreAttach.Text = this.objlang.GetLanguageConversion("Attach_eStore_atrtwork_file");
            this.Chk_bcc.Text = this.objlang.GetLanguageConversion("BCC");
            this.Chk_cc.Text = this.objlang.GetLanguageConversion("CC");
            this.Chk_cc_Other.Text = this.objlang.GetLanguageConversion("CC");
            this.Chk_bcc_Other.Text = this.objlang.GetLanguageConversion("BCC");
            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Email Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Email_Settings")));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Email_Settings");
            if (!base.IsPostBack)
            {
                string str = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(this.Session["CompanyID"].ToString()));
                if (str != " ")
                {
                    this.txt_fromemail.Text = str;
                }
                else
                {
                    this.txt_fromemail.Text = "EPRINT SUPPORT";
                }
                foreach (DataRow row in SettingsBasePage.settings_emailsetting_select(this.CompanyID, this.UserID).Rows)
                {
                    this.EmailSettingID = Convert.ToInt32(row["EmailSettingID"].ToString());
                    this.EmailSettingType = row["EmailSettingType"].ToString();
                    this.hid_EmailSettingId.Value = row["EmailSettingID"].ToString();
                    string str1 = base.SpecialDecode(row["CC"].ToString());
                    string str2 = base.SpecialDecode(row["BCC"].ToString());
                    if (this.EmailSettingType != "e")
                    {
                        this.rdbFromOthers.Checked = true;
                        this.txt_cc_Other.Text = str1;
                        this.txt_bcc_Other.Text = str2;
                        if (Convert.ToBoolean(row["IsCheckedCC"]))
                        {
                            this.Chk_cc_Other.Checked = true;
                        }
                        if (!Convert.ToBoolean(row["IsCheckedBCC"]))
                        {
                            continue;
                        }
                        this.Chk_bcc_Other.Checked = true;
                    }
                    else
                    {
                        this.txt_bcc.Text = str2;
                        this.txt_cc.Text = str1;
                        this.rdbFromEprint.Checked = true;
                        if (Convert.ToBoolean(row["IsSuplierRFQ_AttachAll"]))
                        {
                            this.Chk_SupplierRFQ.Checked = true;
                        }
                        if (Convert.ToBoolean(row["IsPurchase_AttachAll"]))
                        {
                            this.Chk_Purchase.Checked = true;
                        }
                        if (Convert.ToBoolean(row["IsCheckedCC"]))
                        {
                            this.Chk_cc.Checked = true;
                        }
                        if (Convert.ToBoolean(row["IsCheckedBCC"]))
                        {
                            this.Chk_bcc.Checked = true;
                        }
                        if (Convert.ToBoolean(row["Supplier_AttachLink"]))
                        {
                            this.Chk_SuplrAttachLink.Checked = true;
                        }
                        if (Convert.ToBoolean(row["Purchase_AttachLink"]))
                        {
                            this.Chk_POAttachLink.Checked = true;
                        }
                        if (Convert.ToBoolean(row["DeliveryNote_AttachLink"]))
                        {
                            this.Chk_AttachDeliveryNote.Checked = true;
                        }
                        if (!Convert.ToBoolean(row["Is_eStoreAttachment"]))
                        {
                            continue;
                        }
                        this.Chk_estoreAttach.Checked = true;
                    }
                }
            }
        }
    }
}