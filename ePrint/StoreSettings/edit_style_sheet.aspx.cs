using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.StoreSettings
{
    public partial class edit_style_sheet : BaseClass, IRequiresSessionState
    {
        private BasePage ObjPage = new BasePage();

        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        public languageClass objlang = new languageClass();

        public static string strSitepath;

        public string strImagepath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Store_ThemePath = string.Empty;

        public string RegionalSettings_ColorText = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public string AccountType = string.Empty;

        private string CartImage = string.Empty;

        private string OriginalCartImageName = string.Empty;

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

        static edit_style_sheet()
        {
            edit_style_sheet.strSitepath = global.sitePath();
        }

        public edit_style_sheet()
        {
        }

        public string B2B_Classes()
        {
            string empty = string.Empty;
            string str = string.Empty;
            str = "body { ";
            if (this.txtBody_color.Text != "")
            {
                str = string.Concat(str, "color:", this.txtBody_color.Text, "; ");
            }
            if (this.ddlBody_fontfamily.SelectedValue != "0")
            {
                str = string.Concat(str, "font-family:", this.ddlBody_fontfamily.SelectedValue, "; ");
            }
            if (this.txtBody_fontsize.Text != "")
            {
                str = string.Concat(str, "font-size:", this.txtBody_fontsize.Text, "px; ");
            }
            if (this.txtBody_bckgrdcolor.Text != "")
            {
                str = string.Concat(str, "background-color:", this.txtBody_bckgrdcolor.Text, "; ");
            }
            str = string.Concat(str, "} ");
            string empty1 = string.Empty;
            empty1 = ".logoText { ";
            if (this.txtHeader_color.Text != "")
            {
                empty1 = string.Concat(empty1, "color:", this.txtHeader_color.Text, "; ");
            }
            if (this.txtHeader_fontsize.Text != "")
            {
                empty1 = string.Concat(empty1, "font-size:", this.txtHeader_fontsize.Text, "px; ");
            }
            empty1 = string.Concat(empty1, "} ");
            string str1 = string.Empty;
            str1 = "ul#topnav { ";
            if (this.ddlMenu_fontweight.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-weight:", this.ddlMenu_fontweight.SelectedValue, "; ");
            }
            if (this.txtMenu_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background: ", this.txtMenu_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "ul#topnav li a { ");
            if (this.txtMenuItem_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItem_color.Text, "; ");
            }
            if (this.ddlMenuItem_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItem_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItem_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItem_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItem_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItem_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItem_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItem_txtTrnsfm.SelectedValue, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, ".SelectedTab { ");
            if (this.txtMenuItmSlctd_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background-color:", this.txtMenuItmSlctd_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "ul#topnav li:hover a { ");
            if (this.txtMenuItmHvr_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItmHvr_color.Text, "; ");
            }
            if (this.ddlMenuItmHvr_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItmHvr_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItmHvr_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItmHvr_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItmHvr_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItmHvr_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItmHvr_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItmHvr_txtTrnsfm.SelectedValue, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "ul#topnav li:hover { ");
            if (this.txtMenuItmHvr_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background-color:", this.txtMenuItmHvr_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "ul#ul_reportsmenu { ");
            if (this.ddlMenu_fontweight.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-weight:", this.ddlMenu_fontweight.SelectedValue, "; ");
            }
            if (this.txtMenu_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background: ", this.txtMenu_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "#ul_reportsmenu li a { ");
            if (this.txtMenuItem_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItem_color.Text, "; ");
            }
            if (this.ddlMenuItem_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItem_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItem_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItem_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItem_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItem_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItem_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItem_txtTrnsfm.SelectedValue, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "#ul_reportsmenu li:hover a { ");
            if (this.txtMenuItmHvr_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItmHvr_color.Text, "; ");
            }
            if (this.ddlMenuItmHvr_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItmHvr_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItmHvr_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItmHvr_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItmHvr_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItmHvr_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItmHvr_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItmHvr_txtTrnsfm.SelectedValue, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "#ul_reportsmenu li:hover { ");
            if (this.txtMenuItmHvr_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background-color:", this.txtMenuItmHvr_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            string empty2 = string.Empty;
            empty2 = ".divNavigation { ";
            if (this.txtNavBar_fontsize.Text != "")
            {
                empty2 = string.Concat(empty2, "font-size:", this.txtNavBar_fontsize.Text, "px; ");
            }
            if (this.txtNavBar_bckgrdcolor.Text != "")
            {
                empty2 = string.Concat(empty2, "background-color:", this.txtNavBar_bckgrdcolor.Text, "; ");
            }
            empty2 = string.Concat(empty2, "} ");
            empty2 = string.Concat(empty2, ".WelcomeLoginName { ");
            if (this.txtNavBar_fontsize.Text != "")
            {
                empty2 = string.Concat(empty2, "font-size:", this.txtNavBar_fontsize.Text, "px; ");
            }
            empty2 = string.Concat(empty2, "} ");
            string str2 = string.Empty;
            str2 = ".Header_Background { ";
            if (this.txtHeading_color.Text != "")
            {
                str2 = string.Concat(str2, "color:", this.txtHeading_color.Text, "; ");
            }
            if (this.ddlHeading_fontfamily.SelectedValue != "0")
            {
                str2 = string.Concat(str2, "font-family:", this.ddlHeading_fontfamily.SelectedValue, "; ");
            }
            if (this.txtHeading_fontsize.Text != "")
            {
                str2 = string.Concat(str2, "font-size:", this.txtHeading_fontsize.Text, "px; ");
            }
            str2 = string.Concat(str2, "} ");
            str2 = string.Concat(str2, ".Hederfont { ");
            if (this.txtHeading_color.Text != "")
            {
                str2 = string.Concat(str2, "color:", this.txtHeading_color.Text, "; ");
            }
            if (this.ddlHeading_fontfamily.SelectedValue != "0")
            {
                str2 = string.Concat(str2, "font-family:", this.ddlHeading_fontfamily.SelectedValue, "; ");
            }
            if (this.txtHeading_fontsize.Text != "")
            {
                str2 = string.Concat(str2, "font-size:", this.txtHeading_fontsize.Text, "px; ");
            }
            str2 = string.Concat(str2, "} ");
            string empty3 = string.Empty;
            empty3 = "#footer_content { ";
            if (this.txtFooter_color.Text != "")
            {
                empty3 = string.Concat(empty3, "color:", this.txtFooter_color.Text, "; ");
            }
            if (this.ddlFooter_fontfamily.SelectedValue != "0")
            {
                empty3 = string.Concat(empty3, "font-family:", this.ddlFooter_fontfamily.SelectedValue, "; ");
            }
            if (this.txtFooter_fontsize.Text != "")
            {
                empty3 = string.Concat(empty3, "font-size:", this.txtFooter_fontsize.Text, "px; ");
            }
            empty3 = string.Concat(empty3, "} ");
            empty3 = string.Concat(empty3, "#footer_content .footer_div a { ");
            if (this.txtFooter_color.Text != "")
            {
                empty3 = string.Concat(empty3, "color:", this.txtFooter_color.Text, "; ");
            }
            if (this.ddlFooter_fontfamily.SelectedValue != "0")
            {
                empty3 = string.Concat(empty3, "font-family:", this.ddlFooter_fontfamily.SelectedValue, "; ");
            }
            if (this.txtFooter_fontsize.Text != "")
            {
                empty3 = string.Concat(empty3, "font-size:", this.txtFooter_fontsize.Text, "px; ");
            }
            empty3 = string.Concat(empty3, "} ");
            string[] strArrays = new string[] { str, empty1, str1, empty2, str2, empty3 };
            return string.Concat(strArrays);
        }

        public string B2C_Classes()
        {
            string empty = string.Empty;
            string str = string.Empty;
            str = "body { ";
            if (this.txtBody_color.Text != "")
            {
                str = string.Concat(str, "color:", this.txtBody_color.Text, "; ");
            }
            if (this.ddlBody_fontfamily.SelectedValue != "0")
            {
                str = string.Concat(str, "font-family:", this.ddlBody_fontfamily.SelectedValue, "; ");
            }
            if (this.txtBody_fontsize.Text != "")
            {
                str = string.Concat(str, "font-size:", this.txtBody_fontsize.Text, "px; ");
            }
            if (this.txtBody_bckgrdcolor.Text != "")
            {
                str = string.Concat(str, "background-color:", this.txtBody_bckgrdcolor.Text, "; ");
            }
            str = string.Concat(str, "} ");
            string empty1 = string.Empty;
            empty1 = ".logoText { ";
            if (this.txtHeader_color.Text != "")
            {
                empty1 = string.Concat(empty1, "color:", this.txtHeader_color.Text, "; ");
            }
            if (this.txtHeader_fontsize.Text != "")
            {
                empty1 = string.Concat(empty1, "font-size:", this.txtHeader_fontsize.Text, "px; ");
            }
            empty1 = string.Concat(empty1, "} ");
            string str1 = string.Empty;
            str1 = "#header-nav { ";
            if (this.ddlMenu_fontweight.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-weight:", this.ddlMenu_fontweight.SelectedValue, "; ");
            }
            if (this.txtMenu_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background-color: ", this.txtMenu_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "#header-nav a { ");
            if (this.txtMenuItem_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItem_color.Text, "; ");
            }
            if (this.ddlMenuItem_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItem_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItem_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItem_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItem_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItem_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItem_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItem_txtTrnsfm.SelectedValue, "; ");
            }
            str1 = string.Concat(str1, "} ");
            str1 = string.Concat(str1, "#header-nav a:hover { ");
            if (this.txtMenuItmHvr_color.Text != "")
            {
                str1 = string.Concat(str1, "color:", this.txtMenuItmHvr_color.Text, "; ");
            }
            if (this.ddlMenuItmHvr_fontfamily.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "font-family:", this.ddlMenuItmHvr_fontfamily.SelectedValue, "; ");
            }
            if (this.txtMenuItmHvr_fontsize.Text != "")
            {
                str1 = string.Concat(str1, "font-size:", this.txtMenuItmHvr_fontsize.Text, "px; ");
            }
            if (this.ddlMenuItmHvr_txtDcrtn.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-decoration:", this.ddlMenuItmHvr_txtDcrtn.SelectedValue, "; ");
            }
            if (this.ddlMenuItmHvr_txtTrnsfm.SelectedValue != "0")
            {
                str1 = string.Concat(str1, "text-transform:", this.ddlMenuItmHvr_txtTrnsfm.SelectedValue, "; ");
            }
            if (this.txtMenuItmHvr_bckgrdcolor.Text != "")
            {
                str1 = string.Concat(str1, "background:", this.txtMenuItmHvr_bckgrdcolor.Text, "; ");
            }
            str1 = string.Concat(str1, "} ");
            string empty2 = string.Empty;
            empty2 = ".navigation_div { ";
            if (this.txtNavBar_fontsize.Text != "")
            {
                empty2 = string.Concat(empty2, "font-size:", this.txtNavBar_fontsize.Text, "px; ");
            }
            if (this.txtNavBar_bckgrdcolor.Text != "")
            {
                empty2 = string.Concat(empty2, "background-color:", this.txtNavBar_bckgrdcolor.Text, "; ");
            }
            empty2 = string.Concat(empty2, "} ");
            empty2 = string.Concat(empty2, ".navigation_div a { ");
            if (this.txtNavBar_fontsize.Text != "")
            {
                empty2 = string.Concat(empty2, "font-size:", this.txtNavBar_fontsize.Text, "px; ");
            }
            empty2 = string.Concat(empty2, "} ");
            string str2 = string.Empty;
            str2 = ".Header_Background { ";
            if (this.txtHeading_color.Text != "")
            {
                str2 = string.Concat(str2, "color:", this.txtHeading_color.Text, "; ");
            }
            if (this.ddlHeading_fontfamily.SelectedValue != "0")
            {
                str2 = string.Concat(str2, "font-family:", this.ddlHeading_fontfamily.SelectedValue, "; ");
            }
            if (this.txtHeading_fontsize.Text != "")
            {
                str2 = string.Concat(str2, "font-size:", this.txtHeading_fontsize.Text, "px; ");
            }
            str2 = string.Concat(str2, "} ");
            str2 = string.Concat(str2, ".Header_Background strong { ");
            if (this.txtHeading_fontsize.Text != "")
            {
                str2 = string.Concat(str2, "font-size:", this.txtHeading_fontsize.Text, "px; ");
            }
            str2 = string.Concat(str2, "} ");
            string empty3 = string.Empty;
            empty3 = "#footer_content { ";
            if (this.txtFooter_color.Text != "")
            {
                empty3 = string.Concat(empty3, "color:", this.txtFooter_color.Text, "; ");
            }
            if (this.ddlFooter_fontfamily.SelectedValue != "0")
            {
                empty3 = string.Concat(empty3, "font-family:", this.ddlFooter_fontfamily.SelectedValue, "; ");
            }
            if (this.txtFooter_fontsize.Text != "")
            {
                empty3 = string.Concat(empty3, "font-size:", this.txtFooter_fontsize.Text, "px; ");
            }
            empty3 = string.Concat(empty3, "} ");
            empty3 = string.Concat(empty3, "#footer_content .footer_div a { ");
            if (this.txtFooter_color.Text != "")
            {
                empty3 = string.Concat(empty3, "color:", this.txtFooter_color.Text, "; ");
            }
            if (this.ddlFooter_fontfamily.SelectedValue != "0")
            {
                empty3 = string.Concat(empty3, "font-family:", this.ddlFooter_fontfamily.SelectedValue, "; ");
            }
            if (this.txtFooter_fontsize.Text != "")
            {
                empty3 = string.Concat(empty3, "font-size:", this.txtFooter_fontsize.Text, "px; ");
            }
            empty3 = string.Concat(empty3, "} ");
            string[] strArrays = new string[] { str, empty1, str1, empty2, str2, empty3 };
            return string.Concat(strArrays);
        }

        public void BindStyles(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["ClassName"].ToString() == "Body")
                {
                    this.txtBody_color.Text = row["Color"].ToString();
                    if (row["Color"].ToString() == "")
                    {
                        this.txtBody_color_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtBody_color_div.Style.Add("background-color", row["Color"].ToString());
                    }
                    this.txtBody_fontsize.Text = row["FontSize"].ToString();
                    this.txtBody_bckgrdcolor.Text = row["BackgroundColor"].ToString();
                    if (row["BackgroundColor"].ToString() == "")
                    {
                        this.txtBody_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtBody_bckgrdcolor_div.Style.Add("background-color", row["BackgroundColor"].ToString());
                    }
                    if (row["FontFamily"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlBody_fontfamily, row["FontFamily"].ToString());
                    }
                }
                if (row["ClassName"].ToString() == "Header")
                {
                    this.txtHeader_color.Text = row["Color"].ToString();
                    if (row["Color"].ToString() == "")
                    {
                        this.txtHeader_color_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtHeader_color_div.Style.Add("background-color", row["Color"].ToString());
                    }
                    this.txtHeader_fontsize.Text = row["FontSize"].ToString();
                }
                if (row["ClassName"].ToString() == "Menu")
                {
                    if (row["FontWeight"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenu_fontweight, row["FontWeight"].ToString());
                    }
                    this.txtMenu_bckgrdcolor.Text = row["BackgroundColor"].ToString();
                    if (row["BackgroundColor"].ToString() == "")
                    {
                        this.txtMenu_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtMenu_bckgrdcolor_div.Style.Add("background-color", row["BackgroundColor"].ToString());
                    }
                }
                if (row["ClassName"].ToString() == "Menu Item")
                {
                    this.txtMenuItem_color.Text = row["Color"].ToString();
                    if (row["Color"].ToString() == "")
                    {
                        this.txtMenuItem_color_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtMenuItem_color_div.Style.Add("background-color", row["Color"].ToString());
                    }
                    this.txtMenuItem_fontsize.Text = row["FontSize"].ToString();
                    if (row["FontFamily"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItem_fontfamily, row["FontFamily"].ToString());
                    }
                    if (row["TextDecoration"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItem_txtDcrtn, row["TextDecoration"].ToString());
                    }
                    if (row["TextTranform"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItem_txtTrnsfm, row["TextTranform"].ToString());
                    }
                }
                if (row["ClassName"].ToString() == "Menu Item Selected")
                {
                    this.txtMenuItmSlctd_bckgrdcolor.Text = row["BackgroundColor"].ToString();
                    if (row["BackgroundColor"].ToString() == "")
                    {
                        this.txtMenuItmSlctd_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtMenuItmSlctd_bckgrdcolor_div.Style.Add("background-color", row["BackgroundColor"].ToString());
                    }
                }
                if (row["ClassName"].ToString() == "Menu Item Hover")
                {
                    this.txtMenuItmHvr_bckgrdcolor.Text = row["BackgroundColor"].ToString();
                    if (row["BackgroundColor"].ToString() == "")
                    {
                        this.txtMenuItmHvr_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtMenuItmHvr_bckgrdcolor_div.Style.Add("background-color", row["BackgroundColor"].ToString());
                    }
                    this.txtMenuItmHvr_color.Text = row["Color"].ToString();
                    if (row["Color"].ToString() == "")
                    {
                        this.txtMenuItmHvr_color_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtMenuItmHvr_color_div.Style.Add("background-color", row["Color"].ToString());
                    }
                    this.txtMenuItmHvr_fontsize.Text = row["FontSize"].ToString();
                    if (row["TextTranform"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItmHvr_fontfamily, row["FontFamily"].ToString());
                    }
                    if (row["TextTranform"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItmHvr_txtDcrtn, row["TextDecoration"].ToString());
                    }
                    if (row["TextTranform"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlMenuItmHvr_txtTrnsfm, row["TextTranform"].ToString());
                    }
                }
                if (row["ClassName"].ToString() == "Navigation")
                {
                    this.txtNavBar_bckgrdcolor.Text = row["BackgroundColor"].ToString();
                    if (row["BackgroundColor"].ToString() == "")
                    {
                        this.txtNavBar_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtNavBar_bckgrdcolor_div.Style.Add("background-color", row["BackgroundColor"].ToString());
                    }
                    this.txtNavBar_fontsize.Text = row["FontSize"].ToString();
                }
                if (row["ClassName"].ToString() == "Heading")
                {
                    this.txtHeading_color.Text = row["Color"].ToString();
                    if (row["Color"].ToString() == "")
                    {
                        this.txtHeading_color_div.Style.Add("background-color", "#FFFFFF");
                    }
                    else
                    {
                        this.txtHeading_color_div.Style.Add("background-color", row["Color"].ToString());
                    }
                    if (row["FontFamily"].ToString() != "0")
                    {
                        base.SetDDLValue(this.ddlHeading_fontfamily, row["FontFamily"].ToString());
                    }
                    this.txtHeading_fontsize.Text = row["FontSize"].ToString();
                }
                if (row["ClassName"].ToString() != "Footer")
                {
                    continue;
                }
                this.txtFooter_color.Text = row["Color"].ToString();
                if (row["Color"].ToString() == "")
                {
                    this.txtFooter_color_div.Style.Add("background-color", "#FFFFFF");
                }
                else
                {
                    this.txtFooter_color_div.Style.Add("background-color", row["Color"].ToString());
                }
                if (row["FontFamily"].ToString() != "0")
                {
                    base.SetDDLValue(this.ddlFooter_fontfamily, row["FontFamily"].ToString());
                }
                this.txtFooter_fontsize.Text = row["FontSize"].ToString();
            }
        }

        protected void btn_cancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(edit_style_sheet.strSitepath, "StoreSettings/StoreSettings.aspx"));
        }

        protected void btn_default_Click(object sender, EventArgs e)
        {
            this.getStyleSheet("master", "");
            this.getStyleSheet("save", this.txt_editStyleSheet.Text);
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Default_Restored_Successfully"), "msg-success", this.plhMessageNew);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            this.getStyleSheet("save", this.txt_editStyleSheet.Text);
        }

        protected void btnSave_Design_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, "store\\"));
            }
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, "store\\", this.AccountID)))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, "store\\", this.AccountID));
            }
            object[] storeThemePath = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\" };
            if (!Directory.Exists(string.Concat(storeThemePath)))
            {
                object[] objArray = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\" };
                Directory.CreateDirectory(string.Concat(objArray));
            }
            string empty = string.Empty;
            object[] storeThemePath1 = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\CustomStyleSheet.css" };
            empty = string.Concat(storeThemePath1);
            if (!File.Exists(empty))
            {
                File.Create(empty).Close();
            }
            string str = string.Empty;
            if (this.AccountType.ToLower() == "p")
            {
                str = this.B2B_Classes();
            }
            else if (this.AccountType.ToLower() == "x")
            {
                str = this.B2C_Classes();
            }
            try
            {
                File.WriteAllText(empty, str);
            }
            catch
            {
                this.phAccessDenite.Visible = true;
            }
            if (this.hdnCartImage.Value == "0")
            {
                if (!this.upCartImage.HasFile)
                {
                    SettingsBasePage.CartImage_Insert_Update((long)this.AccountID, "", "");
                }
                else
                {
                    object[] objArray1 = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\CartIcon\\" };
                    if (!Directory.Exists(string.Concat(objArray1)))
                    {
                        object[] storeThemePath2 = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\CartIcon\\" };
                        Directory.CreateDirectory(string.Concat(storeThemePath2));
                    }
                    object[] accountID = new object[] { this.AccountID, "_", null, null, null };
                    Guid guid = Guid.NewGuid();
                    accountID[2] = guid.ToString().Substring(0, 5);
                    accountID[3] = "_";
                    accountID[4] = this.upCartImage.FileName.ToString();
                    string str1 = string.Concat(accountID);
                    FileUpload fileUpload = this.upCartImage;
                    object[] objArray2 = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\CartIcon\\", str1 };
                    fileUpload.SaveAs(string.Concat(objArray2));
                    SettingsBasePage.CartImage_Insert_Update((long)this.AccountID, this.upCartImage.FileName.ToString(), str1);
                }
                foreach (DataRow row in AccountsBaseClass.accounts_getDetails(0, 0, this.AccountID).Rows)
                {
                    this.CartImage = row["CartImage"].ToString();
                    this.OriginalCartImageName = row["OriginalCartImageName"].ToString();
                }
                if (string.IsNullOrEmpty(this.OriginalCartImageName))
                {
                    QueryString queryString = new QueryString()
				{
					{ "doctype", "defaultcartimage" }
				};
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    Label label = this.lblCartImageName;
                    string[] strArrays = new string[] { "<a href='", edit_style_sheet.strSitepath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", this.objlang.GetLanguageConversion("Default_Cart_Image"), "</a>&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' style='cursor: pointer;' onclick=RemoveCartImage(); title='", this.objLanguage.GetLanguageConversion("Remove"), "'>" };
                    label.Text = string.Concat(strArrays);
                    this.upCartImage.Attributes.Add("style", "display:none");
                }
                else
                {
                    QueryString queryString2 = new QueryString()
				{
					{ "doctype", "cartimage" },
					{ "aid", Convert.ToString(this.AccountID) },
					{ "CartImg", this.OriginalCartImageName }
				};
                    QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                    Label label1 = this.lblCartImageName;
                    string[] strArrays1 = new string[] { "<a href='", edit_style_sheet.strSitepath, "DocManager.ashx", queryString3.ToString().Trim(), "' target='_blank'>", this.CartImage, "</a>&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' style='cursor: pointer;' onclick=RemoveCartImage(); title='", this.objLanguage.GetLanguageConversion("Remove"), "'>" };
                    label1.Text = string.Concat(strArrays1);
                    this.upCartImage.Attributes.Add("style", "display:none");
                }
                this.hdnCartImage.Value = "1";
            }
            SettingsBasePage.CustomStyles_Insert_Update("Body", (long)this.AccountID, this.txtBody_color.Text, this.ddlBody_fontfamily.SelectedValue, this.txtBody_fontsize.Text, this.txtBody_bckgrdcolor.Text, "", "", "", "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Header", (long)this.AccountID, this.txtHeader_color.Text, "", this.txtHeader_fontsize.Text, "", "", "", "", "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Menu", (long)this.AccountID, "", "", "", this.txtMenu_bckgrdcolor.Text, "", "", this.ddlMenu_fontweight.SelectedValue, "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Menu Item", (long)this.AccountID, this.txtMenuItem_color.Text, this.ddlMenuItem_fontfamily.SelectedValue, this.txtMenuItem_fontsize.Text, "", "", "", "", "", this.ddlMenuItem_txtDcrtn.SelectedValue, this.ddlMenuItem_txtTrnsfm.SelectedValue);
            SettingsBasePage.CustomStyles_Insert_Update("Menu Item Selected", (long)this.AccountID, "", "", "", this.txtMenuItmSlctd_bckgrdcolor.Text, "", "", "", "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Menu Item Hover", (long)this.AccountID, this.txtMenuItmHvr_color.Text, this.ddlMenuItmHvr_fontfamily.SelectedValue, this.txtMenuItmHvr_fontsize.Text, this.txtMenuItmHvr_bckgrdcolor.Text, "", "", "", "", this.ddlMenuItmHvr_txtDcrtn.SelectedValue, this.ddlMenuItmHvr_txtTrnsfm.SelectedValue);
            SettingsBasePage.CustomStyles_Insert_Update("Navigation", (long)this.AccountID, "", "", this.txtNavBar_fontsize.Text, this.txtNavBar_bckgrdcolor.Text, "", "", "", "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Heading", (long)this.AccountID, this.txtHeading_color.Text, this.ddlHeading_fontfamily.SelectedValue, this.txtHeading_fontsize.Text, "", "", "", "", "", "", "");
            SettingsBasePage.CustomStyles_Insert_Update("Footer", (long)this.AccountID, this.txtFooter_color.Text, this.ddlFooter_fontfamily.SelectedValue, this.txtFooter_fontsize.Text, "", "", "", "", "", "", "");
            DataTable dataTable = SettingsBasePage.CustomStyles_Details((long)this.AccountID);
            if (dataTable.Rows.Count > 0)
            {
                this.BindStyles(dataTable);
            }
        }

        public void FontFamily_DropDownBind(DropDownList ddl)
        {
            FontFamily[] families = FontFamily.Families;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Name";
            ddl.DataSource = families;
            ddl.DataBind();
            ddl.Items.Insert(0, "Select");
            ddl.Items[0].Text = "------Select------";
            ddl.Items[0].Value = "0";
            ddl.Items.Insert(1, "Helvetica, sans-serif");
            ddl.Items[1].Text = "Helvetica, sans-serif";
            ddl.Items[1].Value = "Helvetica, sans-serif";
        }

        public void getStyleSheet(string name, string value)
        {
            string empty = string.Empty;
            if (this.Session["AccountType"] != null)
            {
                if (this.Session["AccountType"].ToString().ToLower() != "p")
                {
                    object[] publicDocPath = new object[] { this.PublicDocPath, ConnectionClass.ServerName, "/store/", this.AccountID, "/Themes/StyleSheet.css" };
                    empty = string.Concat(publicDocPath);
                }
                else
                {
                    object[] objArray = new object[] { this.PublicDocPath, ConnectionClass.ServerName, "/store/", this.AccountID, "/Themes/StyleSheet_B2B.css" };
                    empty = string.Concat(objArray);
                }
            }
            if (name == "default" && File.Exists(empty))
            {
                try
                {
                    this.txt_editStyleSheet.Text = File.ReadAllText(empty);
                }
                catch
                {
                }
            }
            if (name == "save")
            {
                string str = value;
                if (File.Exists(empty))
                {
                    try
                    {
                        if (File.Exists(empty))
                        {
                            File.Delete(empty);
                        }
                        using (FileStream fileStream = File.Create(empty))
                        {
                        }
                        StreamWriter streamWriter = (new FileInfo(empty)).AppendText();
                        streamWriter.WriteLine(str);
                        streamWriter.Write(streamWriter.NewLine);
                        streamWriter.Close();
                        this.objBase.Message_Display(this.objlang.GetLanguageConversion("Style_sheet_saved_successfully"), "msg-success", this.plhMessageNew);
                    }
                    catch
                    {
                        this.phAccessDenite.Visible = true;
                    }
                }
            }
            if (name == "master" && File.Exists(empty))
            {
                this.txt_editStyleSheet.Text = "";
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Default_Restored_Successfully"), "msg-success", this.plhMessageNew);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_cancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            this.btn_save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_default.Text = this.objLanguage.GetLanguageConversion("Restore_Default");
            this.btn_masterStyleSheet.Text = this.objLanguage.GetLanguageConversion("View_Master_Style_Sheet");
            this.img_thumbNail.Title = this.objlang.GetLanguageConversion("Upload_Cart_Image_Help_Text");
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            this.RegionalSettings_ColorText = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
            this.Store_ThemePath = string.Concat(this.PublicDocPath, ConnectionClass.ServerName, "/");
            this.btnSave_Design.Text = this.objLanguage.GetLanguageConversion("Save");
            this.Radwinmanagercatalogue.Title = string.Concat(this.objLanguage.GetLanguageConversion("Select"), " ", this.RegionalSettings_ColorText);
            this.btn_ColorApply.Text = this.objLanguage.GetLanguageConversion("Apply");
            foreach (DataRow row in AccountsBaseClass.accounts_getDetails(0, 0, this.AccountID).Rows)
            {
                this.Session["AccountType"] = row["accountType"].ToString();
                this.AccountType = row["accountType"].ToString();
                this.CartImage = row["CartImage"].ToString();
                this.OriginalCartImageName = row["OriginalCartImageName"].ToString();
            }
            if (this.AccountType.ToLower() == "x")
            {
                this.Menu_Item_Selected_hdng_tr.Style.Add("display", "none");
                this.Menu_Item_Selected_options_tr2.Style.Add("display", "none");
                this.tr_Upload_Cart_Image.Style.Add("display", "none");
            }
            if (!base.IsPostBack)
            {
                if (string.IsNullOrEmpty(this.OriginalCartImageName))
                {
                    QueryString queryString = new QueryString()
				{
					{ "doctype", "defaultcartimage" }
				};
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    Label label = this.lblCartImageName;
                    string[] strArrays1 = new string[] { "<a href='", edit_style_sheet.strSitepath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", this.objlang.GetLanguageConversion("Default_Cart_Image"), "</a>&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' style='cursor: pointer;' onclick=RemoveCartImage(); title='", this.objLanguage.GetLanguageConversion("Remove"), "'>" };
                    label.Text = string.Concat(strArrays1);
                    this.upCartImage.Attributes.Add("style", "display:none");
                }
                else
                {
                    QueryString queryString2 = new QueryString()
				{
					{ "doctype", "cartimage" },
					{ "aid", Convert.ToString(this.AccountID) },
					{ "CartImg", this.OriginalCartImageName }
				};
                    QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                    Label label1 = this.lblCartImageName;
                    string[] strArrays2 = new string[] { "<a href='", edit_style_sheet.strSitepath, "DocManager.ashx", queryString3.ToString().Trim(), "' target='_blank'>", this.CartImage, "</a>&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' style='cursor: pointer;' onclick=RemoveCartImage(); title='", this.objLanguage.GetLanguageConversion("Remove"), "'>" };
                    label1.Text = string.Concat(strArrays2);
                    this.upCartImage.Attributes.Add("style", "display:none");
                }
                this.hdnCartImage.Value = "1";
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Edit_Style_Sheet")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Edit_Style_Sheet");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (this.Session["companyid"] != null && this.Session["companyName"] != null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Edit Style Sheet", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, "store\\"));
            }
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, "store\\", this.AccountID)))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, "store\\", this.AccountID));
            }
            object[] storeThemePath = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\" };
            if (!Directory.Exists(string.Concat(storeThemePath)))
            {
                object[] objArray = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\" };
                Directory.CreateDirectory(string.Concat(objArray));
                string empty = string.Empty;
                if (this.Session["AccountType"] == null)
                {
                    empty = (this.hdnAccountType.Value.ToLower() != "p" ? "StyleSheet.css" : "StyleSheet_B2B.css");
                    this.Session["AccountType"] = this.hdnAccountType.Value;
                }
                else
                {
                    empty = (this.Session["AccountType"].ToString().ToLower() != "p" ? "StyleSheet.css" : "StyleSheet_B2B.css");
                }
                object[] storeThemePath1 = new object[] { this.Store_ThemePath, "store\\", this.AccountID, "\\Themes\\", empty };
                string str1 = string.Concat(storeThemePath1);
                if (!File.Exists(str1))
                {
                    File.Create(str1);
                }
            }
            if (!base.IsPostBack)
            {
                this.getStyleSheet("default", "");
            }
            if (!base.IsPostBack)
            {
                this.FontFamily_DropDownBind(this.ddlBody_fontfamily);
                this.FontFamily_DropDownBind(this.ddlMenuItem_fontfamily);
                this.FontFamily_DropDownBind(this.ddlMenuItmHvr_fontfamily);
                this.FontFamily_DropDownBind(this.ddlHeading_fontfamily);
                this.FontFamily_DropDownBind(this.ddlFooter_fontfamily);
                DataTable dataTable = SettingsBasePage.CustomStyles_Details((long)this.AccountID);
                if (dataTable.Rows.Count > 0)
                {
                    this.BindStyles(dataTable);
                    return;
                }
                if (this.AccountType.ToLower() == "p")
                {
                    this.PreFill_default_B2B();
                    return;
                }
                if (this.AccountType.ToLower() == "x")
                {
                    this.PreFill_default_Public();
                }
            }
        }

        public void PreFill_default_B2B()
        {
            this.txtBody_color.Text = "#444444";
            this.txtBody_color_div.Style.Add("background-color", "#444444");
            base.SetDDLValue(this.ddlBody_fontfamily, "Helvetica, sans-serif");
            this.txtBody_fontsize.Text = "13";
            this.txtBody_bckgrdcolor.Text = "#D6D6D6";
            this.txtBody_bckgrdcolor_div.Style.Add("background-color", "#D6D6D6");
            this.txtHeader_color.Text = "silver";
            this.txtHeader_color_div.Style.Add("background-color", "silver");
            this.txtHeader_fontsize.Text = "24";
            base.SetDDLValue(this.ddlMenu_fontweight, "normal");
            this.txtMenu_bckgrdcolor.Text = "#000000";
            this.txtMenu_bckgrdcolor_div.Style.Add("background-color", "#000000");
            this.txtMenuItem_color.Text = "#F0F0F0";
            this.txtMenuItem_color_div.Style.Add("background-color", "#F0F0F0");
            this.txtMenuItem_fontsize.Text = "13";
            base.SetDDLValue(this.ddlMenuItem_fontfamily, "Helvetica, sans-serif");
            base.SetDDLValue(this.ddlMenuItem_txtDcrtn, "0");
            base.SetDDLValue(this.ddlMenuItem_txtTrnsfm, "uppercase");
            this.txtMenuItmSlctd_bckgrdcolor.Text = "#F68D1A";
            this.txtMenuItmSlctd_bckgrdcolor_div.Style.Add("background-color", "#F68D1A");
            this.txtMenuItmHvr_color.Text = "#000000";
            this.txtMenuItmHvr_color_div.Style.Add("background-color", "#000000");
            this.txtMenuItmHvr_fontsize.Text = "13";
            this.txtMenuItmHvr_bckgrdcolor.Text = "#F68D1A";
            this.txtMenuItmHvr_bckgrdcolor_div.Style.Add("background-color", "#F68D1A");
            base.SetDDLValue(this.ddlMenuItmHvr_fontfamily, "Helvetica, sans-serif");
            base.SetDDLValue(this.ddlMenuItmHvr_txtDcrtn, "0");
            base.SetDDLValue(this.ddlMenuItmHvr_txtTrnsfm, "uppercase");
            this.txtNavBar_fontsize.Text = "13";
            this.txtNavBar_bckgrdcolor.Text = "#FFFFFF";
            this.txtNavBar_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
            this.txtHeading_color.Text = "#007ED3";
            this.txtHeading_color_div.Style.Add("background-color", "#007ED3");
            this.txtHeading_fontsize.Text = "15";
            base.SetDDLValue(this.ddlHeading_fontfamily, "Helvetica, sans-serif");
            this.txtFooter_color.Text = "#4E4E51";
            this.txtFooter_color_div.Style.Add("background-color", "#4E4E51");
            this.txtFooter_fontsize.Text = "13";
            base.SetDDLValue(this.ddlFooter_fontfamily, "Helvetica, sans-serif");
        }

        public void PreFill_default_Public()
        {
            this.txtBody_color.Text = "#000000";
            this.txtBody_color_div.Style.Add("background-color", "#000000");
            base.SetDDLValue(this.ddlBody_fontfamily, "Helvetica, sans-serif");
            this.txtBody_fontsize.Text = "13";
            this.txtBody_bckgrdcolor.Text = "#FFFFFF";
            this.txtBody_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
            this.txtHeader_color.Text = "silver";
            this.txtHeader_color_div.Style.Add("background-color", "silver");
            this.txtHeader_fontsize.Text = "24";
            base.SetDDLValue(this.ddlMenu_fontweight, "bold");
            this.txtMenu_bckgrdcolor.Text = "#000000";
            this.txtMenu_bckgrdcolor_div.Style.Add("background-color", "#000000");
            this.txtMenuItem_color.Text = "silver";
            this.txtMenuItem_color_div.Style.Add("background-color", "silver");
            this.txtMenuItem_fontsize.Text = "13";
            base.SetDDLValue(this.ddlMenuItem_fontfamily, "Helvetica, sans-serif");
            base.SetDDLValue(this.ddlMenuItem_txtDcrtn, "0");
            base.SetDDLValue(this.ddlMenuItem_txtTrnsfm, "none");
            this.txtMenuItmHvr_color.Text = "#000000";
            this.txtMenuItmHvr_color_div.Style.Add("background-color", "#000000");
            this.txtMenuItmHvr_fontsize.Text = "13";
            this.txtMenuItmHvr_bckgrdcolor.Text = "#FFFFFF";
            this.txtMenuItmHvr_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
            base.SetDDLValue(this.ddlMenuItmHvr_fontfamily, "Helvetica, sans-serif");
            base.SetDDLValue(this.ddlMenuItmHvr_txtDcrtn, "0");
            base.SetDDLValue(this.ddlMenuItmHvr_txtTrnsfm, "none");
            this.txtNavBar_fontsize.Text = "12";
            this.txtNavBar_bckgrdcolor.Text = "#FFFFFF";
            this.txtNavBar_bckgrdcolor_div.Style.Add("background-color", "#FFFFFF");
            this.txtHeading_color.Text = "#007ED3";
            this.txtHeading_color_div.Style.Add("background-color", "#007ED3");
            this.txtHeading_fontsize.Text = "16";
            base.SetDDLValue(this.ddlHeading_fontfamily, "Helvetica, sans-serif");
            this.txtFooter_color.Text = "#4E4E51";
            this.txtFooter_color_div.Style.Add("background-color", "#4E4E51");
            this.txtFooter_fontsize.Text = "13";
            base.SetDDLValue(this.ddlFooter_fontfamily, "Helvetica, sans-serif");
        }
    }
}