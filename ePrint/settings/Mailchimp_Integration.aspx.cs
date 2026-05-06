using MailChimp.Net;
using MailChimp.Net.Core;
using nmsCommon;
using nmsLanguage;

using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class Mailchimp_Integration : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private Global gloobj = new Global();

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

        public Mailchimp_Integration()
        {
        }

        public void BINDList()
        {

            try
            {
                string text = this.txtAPIKey.Text;
                MailChimpManager Manager = new MailChimpManager(text);
                //listsOutput _listsOutput = (new lists(new listsInput(text))).Execute();
                var options = new ListRequest
                {
                    Limit = 10
                };


                var model = Manager.Lists.GetAllAsync(options).Result;



                if (model == null)
                {
                    this.listid.Visible = false;
                    this.tdbtn.Visible = false;
                    return;
                }
                this.listid.Visible = true;
                this.tdbtn.Visible = true;
                this.ddlListID.DataValueField = "id";
                this.ddlListID.DataTextField = "name";
                this.ddlListID.DataSource = model;
                this.ddlListID.DataBind();
                this.ddlListID.Items.Insert(0, "Select");
                this.ddlListID.Items[0].Text = "------Select------";
                this.ddlListID.Items[0].Value = "0";

            }
            catch (MailChimpException mce)
            {

                base.Message_Display(mce.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
            catch (Exception ex)
            {

                base.Message_Display(ex.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
        }

        public void btnGetList_OnClick(object sender, EventArgs e)
        {
            try
            {
                string text = this.txtAPIKey.Text;
                MailChimpManager Manager = new MailChimpManager(text);
                var options = new ListRequest
                {
                    Limit = 10
                };
                var model = Manager.Lists.GetAllAsync(options).Result;
                if (model == null)
                {
                    this.listid.Visible = false;
                    this.tdbtn.Visible = false;
                    base.Message_Display(this.objlang.GetLanguageConversion("Entered_key_does_not_validate"), "msg-fail", this.plhMessage);
                }
                else
                {
                    this.listid.Visible = true;
                    this.tdbtn.Visible = true;
                    this.BINDList();
                }
                DataTable dataTable = this.objcomm.selectall_MailchimpIntegration(this.CompanyID);
                base.SetDDLValue(this.ddlListID, dataTable.Rows[0]["MailChimpListId"].ToString());
            }
            catch (MailChimpException mce)
            {

                base.Message_Display(mce.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
            catch (Exception ex)
            {

                base.Message_Display(ex.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = this.ddlListID.SelectedValue;
                string text = this.txtAPIKey.Text;
                MailChimpManager Manager = new MailChimpManager(text);
                var options = new ListRequest
                {
                    Limit = 10
                };
                var model = Manager.Lists.GetAllAsync(options);
                if (model == null)
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Entered_key_does_not_validate"), "msg-fail", this.plhMessage);
                    return;
                }
                CompanyBasePage.MailChimp_Insert(this.CompanyID, text, selectedValue);
                base.Message_Display(this.objlang.GetLanguageConversion("Mailchimp_Integration_Update_successfully"), "msg-success", this.plhMessage);
            }
            catch (MailChimpException mce)
            {

                base.Message_Display(mce.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
            catch (Exception ex)
            {

                base.Message_Display(ex.InnerException.Message.ToString(), "msg-fail", this.plhMessage);
            }
        }

        public void imgEdit_OnClick(object sender, EventArgs e)
        {
            this.lblInRecord.Visible = false;
            this.txtAPIKey.Visible = true;
            this.imgEdit.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Mailchimp_Integration");
            base.Title = this.objlang.convert(global.pageTitle("Mailchimp Integration", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Appearance_Mailchimp_Integration")));
            this.btnSave.Text = this.objlang.GetLanguageConversion("Update");
            this.btnGetList.Text = this.objlang.GetLanguageConversion("Click_here_to_validate_the_key");
            DataTable dataTable = this.objcomm.selectall_MailchimpIntegration(this.CompanyID);
            if (!base.IsPostBack)
            {
                
                this.txtAPIKey.Text = dataTable.Rows[0]["MailChimpAPIKey"].ToString();
                this.BINDList();
                base.SetDDLValue(this.ddlListID, dataTable.Rows[0]["MailChimpListId"].ToString());
            }
            if (!base.IsPostBack)
            {
                string text = this.txtAPIKey.Text;
                MailChimpManager Manager = new MailChimpManager(text);
                var options = new ListRequest
                {
                    Limit = 10
                };
                var model = Manager.Lists.GetAllAsync(options);

                if (model == null)
                {
                    this.lblInRecord.Visible = false;
                    this.txtAPIKey.Visible = true;
                }
                else
                {
                    this.lblInRecord.Visible = true;
                    this.txtAPIKey.Visible = false;
                }
                if (this.txtAPIKey.Visible)
                {
                    this.imgEdit.Visible = false;
                    this.txtAPIKey.Focus();
                }
            }
        }
    }
}