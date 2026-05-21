using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.settings
{
    public partial class guillotine_add : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel_ascx header_mis;

        //protected usercontrol_settings_guillotine_add_ascx guillotine;

        private Global gloobj = new Global();

        public string ParaForLarge = string.Empty;

        public string IsLarge = string.Empty;

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

        public guillotine_add()
        {
        }

        [WebMethod]
        public static int GetGuillotinePress(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.ReplaceSingleQuote(strArrays[1]);
            string str2 = baseClass.ReplaceSingleQuote(strArrays[2]);
            long num = Convert.ToInt64(strArrays[3]);
            int num1 = SettingsBasePage.settings_plantpressduplicacy_check(Convert.ToInt32(str), str2, str1, num);
            return num1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["islarge"] != null)
            {
                this.IsLarge = "yes";
                this.ParaForLarge = "&islarge=yes";
            }
            this.gloobj.setpagename("setting");
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"] != "edit")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/guillotine_view.aspx?", this.ParaForLarge, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Guillotine"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Guillotine_Add")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Guillotine Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Guillotine_Add");
                }
                else
                {
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/guillotine_view.aspx?", this.ParaForLarge, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Guillotine"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Guillotine_Edit")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Guillotine Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Guillotine_Edit");
                }
            }
            try
            {
                if (this.IsLarge == "yes")
                {
                    if (base.Request.Params["type"] != "edit")
                    {
                        string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/guillotine_view.aspx?", this.ParaForLarge, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Cutting_Table"), "</a>" };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Cutting_Table_Add")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Cutting Table Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Cutting_Table_Add");
                    }
                    else
                    {
                        string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/guillotine_view.aspx?", this.ParaForLarge, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Cutting_Table"), "</a>" };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Cutting_Table_Edit")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Cutting Table Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Cutting_Table_Edit");
                    }
                }
            }
            catch
            {
            }
        }
    }
}