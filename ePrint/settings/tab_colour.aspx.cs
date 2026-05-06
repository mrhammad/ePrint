using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class tab_colour : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected Sample.Web.UI.Compatibility.ValidationSummary Validationsummary1;

        //protected PlaceHolder PlaceError;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhgroupdetail;

        //protected Button Button3;

        //protected RadButton Button1;

        protected string pg;

        protected string strImagepath = global.imagePath();

        protected string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        public string section = "Admin :: Navigator";

        public string subsection = "Change Color";

        private int error;

        private Global gloobj = new Global();

        public string flag = "false";

        public languageClass objlang = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage ObjPage = new BasePage();

        private int Company_ID;

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

        public tab_colour()
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_select_upperNavigationTab", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                //if (sqlDataReader["headerName"].ToString() == "PROOFS")
                //    continue;

                TextBox textBox = (TextBox)this.plhgroupdetail.FindControl(sqlDataReader["headerName"].ToString());
                TextBox textBox1 = (TextBox)this.plhgroupdetail.FindControl(sqlDataReader["headerID"].ToString());
                if(textBox == null || textBox1 == null)
                {
                    continue;
                }
                else if (textBox.Text == "" || textBox1.Text == "")
                {
                    Label label = new Label()
                    {
                        CssClass = "errorMsg",
                        ForeColor = Color.Black,
                        Visible = true
                    };
                    this.PlaceError.Controls.Add(label);
                    base.Response.Redirect(string.Concat(global.sitePath(), "Settings/tab_colour.aspx?error=0"));
                    break;
                }
                else
                {
                    commonClass _commonClass1 = new commonClass();
                    SqlCommand sqlCommand1 = new SqlCommand("crm_update_tabcolor", _commonClass1.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand1.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
                    sqlCommand1.Parameters.AddWithValue("@colorcode", textBox.Text);
                    sqlCommand1.Parameters.AddWithValue("@headerName", sqlDataReader["headerName"].ToString());
                    sqlCommand1.Parameters.AddWithValue("@forecolor", textBox1.Text);
                    sqlCommand1.ExecuteNonQuery();
                    _commonClass1.closeConnection();
                    _commonClass1.Dispose();
                    sqlCommand1.Dispose();
                }
            }
            _commonClass.closeConnection();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            this.objLanguage.Dispose();
            int num = Convert.ToInt32(this.Session["companyID"]);
            this.Session[string.Concat("TabColours", num)] = null;
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/tab_colour.aspx?error=1"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/settings.aspx"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_select_defaultcolor", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            int num = Convert.ToInt32(this.Session["companyID"]);
            this.Session[string.Concat("TabColours", num)] = null;
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/tab_colour.aspx?error=1"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Company_ID = Convert.ToInt32(this.Session["companyID"]);
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Update");
            this.Button3.Text = this.objLanguage.GetLanguageConversion("Restore_Default");
            this.Button3.Attributes.Add("onclick", "javascript:loadingimg('div_restore','div_restoreprocess');");
            this.Button1.Attributes.Add("onclick", "javascript:var a=ValidateColor();if(a)loadingimg('div_btnupdate','div_updateprocess');return a;");
            global.pgName = "admin";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Tab Color", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx style=text-decoration:underline class='subnavigator'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx style=text-decoration:underline class='subnavigator'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Appearance_Customize_Tab"), "&nbsp;", this.ObjPage.GetRegionalSettings(this.Company_ID, "Colour")));
            global.pgDetail = string.Concat(this.objLanguage.convert("Admin Section"), ">>", this.objLanguage.convert("Edit Tab Color"));
            this.Button1.Text = this.objLanguage.convert(this.Button1.Text);
            this.Button3.Text = this.objLanguage.convert(this.Button3.Text);
            commonClass _commonClass = new commonClass();
            this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Appearance_Customize_Tab"), " ", this.ObjPage.GetRegionalSettings(this.Company_ID, "Colour"));
            SqlCommand sqlCommand = new SqlCommand("crm_select_upperNavigationTab", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            this.plhgroupdetail.Controls.Add(new LiteralControl("<table width=45% id='tbl_Color'  border=0 cellpadding=2 cellspacing=3 class='div_spacing4'>"));
            ControlCollection controls = this.plhgroupdetail.Controls;
            string[] strArrays = new string[] { "<tr><td style='padding-left: 5px' align=right colspan=6 nowrap><b>&nbsp;", this.objLanguage.GetLanguageConversion("Customize_Tab"), " ", this.ObjPage.GetRegionalSettings(this.Company_ID, "Colour"), "</b></td><td style='padding-left: 82px;' colspan=10 align=center nowrap><b>", this.objLanguage.GetLanguageConversion("Customize_Text"), " ", this.ObjPage.GetRegionalSettings(this.Company_ID, "Colour"), "</b></td></tr>" };
            controls.Add(new LiteralControl(string.Concat(strArrays)));
            this.plhgroupdetail.Controls.Add(new LiteralControl("<tr><td></td></tr>"));
            while (sqlDataReader.Read())
            {
                if (!commonClass.CheckProofPermission())
                {
                    if (sqlDataReader["headername"].ToString().ToLower() != "proofs")
                    {
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<tr valign=top>"));
                        if (sqlDataReader["headername"].ToString().ToLower() == "home")
                        {
                            this.plhgroupdetail.Controls.Add(new LiteralControl(string.Concat("<td style='width:3px'></td><td nowrap class=label width=20% nowrap>&nbsp;", base.ReturnScreenName(string.Concat(sqlDataReader["headername"].ToString().Substring(0, 1).ToUpper(), sqlDataReader["headername"].ToString().Substring(1, sqlDataReader["headername"].ToString().Length - 1).ToLower()), 2, "p"), "</td>")));
                        }
                        else if (sqlDataReader["headername"].ToString().ToLower() != "inventory")
                        {
                            this.plhgroupdetail.Controls.Add(new LiteralControl(string.Concat("<td style='width:3px'></td><td nowrap class=label width=20% nowrap>&nbsp;", base.SpecialDecode(base.ReturnScreenName(string.Concat(sqlDataReader["headername"].ToString().Substring(0, 1).ToUpper(), sqlDataReader["headername"].ToString().Substring(1, sqlDataReader["headername"].ToString().Length - 1).ToLower()), 1, "p").Replace("Crms", "CRM")), "</td>")));
                        }
                        else
                        {
                            this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:3px'></td><td nowrap class=label width=20%>&nbsp;Inventory</td>"));
                        }
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:5%;'>"));
                        TextBox textBox = new TextBox()
                        {
                            ID = sqlDataReader["headerName"].ToString(),
                            CssClass = "txtBox",
                            Width = 80,
                            MaxLength = 7,
                            Text = sqlDataReader["colorcode"].ToString()
                        };
                        this.plhgroupdetail.Controls.Add(textBox);
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                        ControlCollection controlCollections = this.plhgroupdetail.Controls;
                        string[] str = new string[] { "<td nowrap style=width:30px; align=left><div id='divCLR_", sqlDataReader["headerName"].ToString(), "' style='height: 30px; width:30px;  margin-top: -4px;  background-color:", base.ReplaceSingleQuote(textBox.Text), "'></div></td>" };
                        controlCollections.Add(new LiteralControl(string.Concat(str)));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:5%;'>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td>"));
                        ImageButton imageButton = new ImageButton()
                        {
                            Width = 20,
                            ImageUrl = string.Concat(this.strImagepath, "colorcube.gif"),
                            Height = 20
                        };
                        imageButton.Attributes.Add("onclick", string.Concat("javascript:paletteOpen('", textBox.ID, "');return false;"));
                        imageButton.ImageAlign = ImageAlign.AbsMiddle;
                        imageButton.CausesValidation = false;
                        this.plhgroupdetail.Controls.Add(imageButton);
                        System.Web.UI.WebControls.RequiredFieldValidator requiredFieldValidator = new System.Web.UI.WebControls.RequiredFieldValidator()
                        {
                            ControlToValidate = textBox.ID,
                            CssClass = "errorMsg",
                            Display = ValidatorDisplay.Dynamic,
                            ErrorMessage = string.Concat("Please select a color code for ", textBox.ID, " Tab"),
                            Visible = false
                        };
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<BR>"));
                        this.plhgroupdetail.Controls.Add(requiredFieldValidator);
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap align=left style='width:5%; padding-left: 50px;'>"));
                        TextBox textBox1 = new TextBox()
                        {
                            ID = sqlDataReader["headerID"].ToString(),
                            CssClass = "txtBox",
                            Width = 80,
                            MaxLength = 7,
                            Text = sqlDataReader["forecolor"].ToString()
                        };
                        this.plhgroupdetail.Controls.Add(textBox1);
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                        ControlCollection controls1 = this.plhgroupdetail.Controls;
                        string[] str1 = new string[] { "<td nowrap style=width:30px; align=left><div id='divCLR_", sqlDataReader["headerID"].ToString(), "' style='height: 30px; width:30px; margin-top: -4px; background-color:", base.ReplaceSingleQuote(textBox1.Text), "'></div></td>" };
                        controls1.Add(new LiteralControl(string.Concat(str1)));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap>"));
                        ImageButton imageButton1 = new ImageButton()
                        {
                            Width = 20,
                            ImageUrl = string.Concat(this.strImagepath, "colorcube.gif"),
                            Height = 20
                        };
                        imageButton1.Attributes.Add("onclick", string.Concat("javascript:paletteOpen('", textBox1.ID, "');return false;"));
                        imageButton1.ImageAlign = ImageAlign.AbsMiddle;
                        imageButton1.CausesValidation = false;
                        this.plhgroupdetail.Controls.Add(imageButton1);
                        if (textBox1.Text == "" || textBox.Text == "")
                        {
                            System.Web.UI.WebControls.RequiredFieldValidator requiredFieldValidator1 = new System.Web.UI.WebControls.RequiredFieldValidator()
                            {
                                ControlToValidate = textBox.ID,
                                CssClass = "errorMsg",
                                ForeColor = Color.Black,
                                Display = ValidatorDisplay.Dynamic,
                                ErrorMessage = string.Concat("Please select a color code for ", textBox.ID, " Tab"),
                                Visible = false
                            };
                            this.plhgroupdetail.Controls.Add(requiredFieldValidator1);
                        }
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                        this.plhgroupdetail.Controls.Add(new LiteralControl("</tr>"));
                    }
                    else
                    {

                    }
                }
                else
                {
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<tr valign=top>"));
                    if (sqlDataReader["headername"].ToString().ToLower() == "home")
                    {
                        this.plhgroupdetail.Controls.Add(new LiteralControl(string.Concat("<td style='width:3px'></td><td nowrap class=label width=20% nowrap>&nbsp;", base.ReturnScreenName(string.Concat(sqlDataReader["headername"].ToString().Substring(0, 1).ToUpper(), sqlDataReader["headername"].ToString().Substring(1, sqlDataReader["headername"].ToString().Length - 1).ToLower()), 2, "p"), "</td>")));
                    }
                    else if (sqlDataReader["headername"].ToString().ToLower() != "inventory")
                    {
                        this.plhgroupdetail.Controls.Add(new LiteralControl(string.Concat("<td style='width:3px'></td><td nowrap class=label width=20% nowrap>&nbsp;", base.SpecialDecode(base.ReturnScreenName(string.Concat(sqlDataReader["headername"].ToString().Substring(0, 1).ToUpper(), sqlDataReader["headername"].ToString().Substring(1, sqlDataReader["headername"].ToString().Length - 1).ToLower()), 1, "p").Replace("Crms", "CRM")), "</td>")));
                    }
                    else
                    {
                        this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:3px'></td><td nowrap class=label width=20%>&nbsp;Inventory</td>"));
                    }
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:5%;'>"));
                    TextBox textBox = new TextBox()
                    {
                        ID = sqlDataReader["headerName"].ToString(),
                        CssClass = "txtBox",
                        Width = 80,
                        MaxLength = 7,
                        Text = sqlDataReader["colorcode"].ToString()
                    };
                    this.plhgroupdetail.Controls.Add(textBox);
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                    ControlCollection controlCollections = this.plhgroupdetail.Controls;
                    string[] str = new string[] { "<td nowrap style=width:30px; align=left><div id='divCLR_", sqlDataReader["headerName"].ToString(), "' style='height: 30px; width:30px;  margin-top: -4px;  background-color:", base.ReplaceSingleQuote(textBox.Text), "'></div></td>" };
                    controlCollections.Add(new LiteralControl(string.Concat(str)));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td style='width:5%;'>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td>"));
                    ImageButton imageButton = new ImageButton()
                    {
                        Width = 20,
                        ImageUrl = string.Concat(this.strImagepath, "colorcube.gif"),
                        Height = 20
                    };
                    imageButton.Attributes.Add("onclick", string.Concat("javascript:paletteOpen('", textBox.ID, "');return false;"));
                    imageButton.ImageAlign = ImageAlign.AbsMiddle;
                    imageButton.CausesValidation = false;
                    this.plhgroupdetail.Controls.Add(imageButton);
                    System.Web.UI.WebControls.RequiredFieldValidator requiredFieldValidator = new System.Web.UI.WebControls.RequiredFieldValidator()
                    {
                        ControlToValidate = textBox.ID,
                        CssClass = "errorMsg",
                        Display = ValidatorDisplay.Dynamic,
                        ErrorMessage = string.Concat("Please select a color code for ", textBox.ID, " Tab"),
                        Visible = false
                    };
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<BR>"));
                    this.plhgroupdetail.Controls.Add(requiredFieldValidator);
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap align=left style='width:5%; padding-left: 50px;'>"));
                    TextBox textBox1 = new TextBox()
                    {
                        ID = sqlDataReader["headerID"].ToString(),
                        CssClass = "txtBox",
                        Width = 80,
                        MaxLength = 7,
                        Text = sqlDataReader["forecolor"].ToString()
                    };
                    this.plhgroupdetail.Controls.Add(textBox1);
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                    ControlCollection controls1 = this.plhgroupdetail.Controls;
                    string[] str1 = new string[] { "<td nowrap style=width:30px; align=left><div id='divCLR_", sqlDataReader["headerID"].ToString(), "' style='height: 30px; width:30px; margin-top: -4px; background-color:", base.ReplaceSingleQuote(textBox1.Text), "'></div></td>" };
                    controls1.Add(new LiteralControl(string.Concat(str1)));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap style='width:3px'></td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("<td nowrap>"));
                    ImageButton imageButton1 = new ImageButton()
                    {
                        Width = 20,
                        ImageUrl = string.Concat(this.strImagepath, "colorcube.gif"),
                        Height = 20
                    };
                    imageButton1.Attributes.Add("onclick", string.Concat("javascript:paletteOpen('", textBox1.ID, "');return false;"));
                    imageButton1.ImageAlign = ImageAlign.AbsMiddle;
                    imageButton1.CausesValidation = false;
                    this.plhgroupdetail.Controls.Add(imageButton1);
                    if (textBox1.Text == "" || textBox.Text == "")
                    {
                        System.Web.UI.WebControls.RequiredFieldValidator requiredFieldValidator1 = new System.Web.UI.WebControls.RequiredFieldValidator()
                        {
                            ControlToValidate = textBox.ID,
                            CssClass = "errorMsg",
                            ForeColor = Color.Black,
                            Display = ValidatorDisplay.Dynamic,
                            ErrorMessage = string.Concat("Please select a color code for ", textBox.ID, " Tab"),
                            Visible = false
                        };
                        this.plhgroupdetail.Controls.Add(requiredFieldValidator1);
                    }
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</td>"));
                    this.plhgroupdetail.Controls.Add(new LiteralControl("</tr>"));
                }

            }
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            _commonClass.closeConnection();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            this.plhgroupdetail.Controls.Add(new LiteralControl("</table>"));
            this.objLanguage.Dispose();
            try
            {
                if (base.Request.QueryString["error"] == "1")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Appearance_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.QueryString["error"] == "0")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Please_select_color_code_for_all_the_Tabs"), "msg-success", this.PlaceError);
                }
            }
            catch
            {
            }
        }
    }
}