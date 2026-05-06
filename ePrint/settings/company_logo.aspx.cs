using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class company_logo : BaseClass, IRequiresSessionState
    {
        private createImageThumnail objImg = new createImageThumnail();

        private Global gloobj = new Global();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        public commonClass objcommon = new commonClass();

        public static string oldFileName;

        public string section = "Admin :: Company Profile";

        public string subsection = "Edit Header";

        public int type;

        public int error;

        public string image = "";

        public string logotype = string.Empty;

        private double Resolution;

        public int companyId;

        public string ServerName = string.Empty;

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

        static company_logo()
        {
            company_logo.oldFileName = "";
        }

        public company_logo()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/default.aspx"));
        }

        protected void btnContinue_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            string str = base.ReplaceSingleQuote(this.txttext.Text);
            string str1 = company_logo.oldFileName;
            string str2 = base.ReplaceSingleQuote(this.txttemplate.Text);
            if (this.chkdefault.Checked)
            {
                num = 1;
                this.logotype = "text";
            }
            if (this.rdtext.Checked)
            {
                this.logotype = "text";
            }
            else if (this.rdimage.Checked)
            {
                this.logotype = "image";
            }
            else if (this.rdtemplate.Checked)
            {
                this.logotype = "template";
            }
            string empty = string.Empty;
            if (this.type == 1)
            {
                empty = "header";
            }
            else if (this.type == 2)
            {
                empty = "footer";
            }
            this.SaveLogo(this.companyId, num, str, this.hid_FileName.Value, str2, this.logotype, empty);
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            int num = 0;
            string str = "";
            string str1 = "";
            string str2 = "";
            string empty = string.Empty;
            str = base.SpecialEncode(this.txttext.Text);
            str1 = company_logo.oldFileName;
            str2 = base.SpecialEncode(this.txttemplate.Text);
            if (this.chkdefault.Checked)
            {
                num = 1;
                this.logotype = "text";
            }
            if (num != 1)
            {
                if (this.rdtext.Checked)
                {
                    this.logotype = "text";
                }
                else if (this.rdimage.Checked)
                {
                    if (!this.FileUpload1.HasFile)
                    {
                        this.error = 1;
                        this.lblError.Visible = true;
                    }
                    else
                    {
                        string[] strArrays = this.FileUpload1.FileName.ToString().Trim().Split(new char[] { '.' });
                        string str3 = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
                        if (str3.ToLower() == "jpg" || str3.ToLower() == "tif" || str3.ToLower() == "bmp" || str3.ToLower() == "jpeg" || str3.ToLower() == "jpf" || str3.ToLower() == "gif" || str3.ToLower() == "msp" || str3.ToLower() == "mng" || str3.ToLower() == "pct" || str3.ToLower() == "png")
                        {
                            string str4 = this.objcommon.ReplaceSplSymbol(this.FileUpload1.FileName);
                            string str5 = Guid.NewGuid().ToString();
                            str5 = str5.Replace("-", string.Empty);
                            str5 = str5.Substring(0, 5);
                            str4 = string.Concat(str5, "_", str4.Replace(" ", "_"));
                            if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//")))
                            {
                                Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//"));
                            }
                            if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//", this.Session["companyid"].ToString())))
                            {
                                Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//", this.Session["companyid"].ToString()));
                            }
                            FileUpload fileUpload1 = this.FileUpload1;
                            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.Session["companyid"].ToString(), "//", str4 };
                            fileUpload1.SaveAs(string.Concat(secureDocPath));
                            str1 = str4;
                            this.hid_FileName.Value = str1;
                            System.Drawing.Image image = null;
                            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "//", this.Session["companyid"].ToString(), "//", str4 };
                            string str6 = string.Concat(secureDocPath1);
                            str4 = string.Concat("t_", str4);
                            str1 = str4;
                            this.hid_FileName.Value = str1;
                            string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "//", this.Session["companyid"].ToString(), "//", str4 };
                            string str7 = string.Concat(strArrays1);
                            int num1 = 300;
                            int num2 = 300;
                            try
                            {
                                System.Drawing.Image image1 = System.Drawing.Image.FromFile(str6);
                                image = createImageThumnail.FixedSize(str6, image1, num1, num2, true, str7);
                                image1.Dispose();
                                image.Dispose();
                                GC.Collect();
                            }
                            catch (Exception exception)
                            {
                                this.lblError.Visible = true;
                            }
                            if (Convert.ToInt32(this.Resolution) > 0 && Convert.ToInt32(this.Resolution) < 200)
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm11111", ";CheckResolution();", true);
                                this.error = Convert.ToInt16(this.hid_UpType.Value);
                            }
                        }
                        else
                        {
                            this.lblError.Visible = true;
                            this.error = 1;
                        }
                    }
                    this.logotype = "image";
                }
                else if (this.rdtemplate.Checked)
                {
                    this.logotype = "template";
                }
            }
            string empty1 = string.Empty;
            if (this.type == 1)
            {
                empty1 = "header";
            }
            else if (this.type == 2)
            {
                empty1 = "footer";
            }
            if (this.error == 0)
            {
                this.SaveLogo(this.companyId, num, str, str1, str2, this.logotype, empty1);
            }
        }

        protected void chkdefault_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkdefault.Checked)
            {
                this.rdtext.Checked = true;
            }
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.Session["companyid"].ToString());
            string empty = string.Empty;
            string str = string.Empty;
            if (this.type == 1)
            {
                str = "header";
                empty = "header-32.gif";
            }
            else if (this.type == 2)
            {
                str = "footer";
                empty = "images2.gif";
            }
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_company_logo_update_image", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", num);
            sqlCommand.Parameters.AddWithValue("@logoimage", empty);
            sqlCommand.Parameters.AddWithValue("@type", str);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            HttpResponse response = base.Response;
            object[] objArray = new object[] { global.sitePath(), "Settings/company_logo.aspx?type=", this.type, "&image=image" };
            response.Redirect(string.Concat(objArray));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnsave.Attributes.Add("onclick", "javascript:loadingimg('div_btnsave','div_btnsaveprocess');");
            this.rdtext.Text = this.objlang.GetValueOnLang("Text");
            this.lblError.Text = this.objlang.GetValueOnLang("Please upload only image file");
            this.LinkButton1.Text = this.objLanguage.GetLanguageConversion("Remove");
            this.rdtemplate.Text = this.objlang.GetValueOnLang("Custom HTML");
            this.btnsave.Text = this.objlang.GetValueOnLang("Save");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            global.pageName = "setting";
            global.pgName = "setting";
            this.gloobj.setpagename("setting");
            this.companyId = Convert.ToInt32(this.Session["companyid"].ToString());
            this.txttext.Focus();
            global.pgDetail = "Admin Section >> Company Detail >> Header Setting";
            this.rdtext.Attributes.Add("onclick", "javascript:chkUnCheck();hide_textbox();");
            this.rdimage.Attributes.Add("onclick", "javascript:chkUnCheck();hide_textbox();");
            this.rdtemplate.Attributes.Add("onclick", "javascript:chkUnCheck();hide_textbox();");
            this.chkdefault.Attributes.Add("onclick", "javascript:rdUnCheck();");
            try
            {
                this.image = base.Request.Params["image"]?.ToString();
            }
            catch
            {
            }
            this.type = Convert.ToInt32(base.Request.QueryString[0].ToString());
            string empty = string.Empty;
            if (this.type == 1)
            {
                empty = "header";
                base.Title = this.objLanguage.convert(global.pageTitle("Header Setting", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx style=text-decoration:underline class=subnavigator>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/Settings.aspx style=text-decoration:underline class=subnavigator>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Appearance_Customize_Header")));
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Appearance_Customize_Header");
            }
            else if (this.type == 2)
            {
                empty = "footer";
                base.Title = this.objLanguage.convert(global.pageTitle("Footer Setting", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] strArrays = new string[] { "<a href=../welcome.aspx style=text-decoration:underline class=subnavigator>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/Settings.aspx style=text-decoration:underline class=subnavigator>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Appearance_Customize_Footer")));
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Appearance_Customize_Footer");
            }
            if (!base.IsPostBack)
            {
                this.chkdefault.Text = this.objLanguage.convert("Restore_Default");
                this.rdtext.Text = this.objLanguage.GetLanguageConversion("Text");
                this.rdimage.Text = this.objLanguage.GetLanguageConversion("Image");
                this.rdtemplate.Text = this.objLanguage.GetLanguageConversion("Custom_HTML");
                this.btnsave.Text = this.objLanguage.GetLanguageConversion("Save");
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_company_logo_select", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                sqlCommand.Parameters.AddWithValue("@companyid", this.companyId);
                sqlCommand.Parameters.AddWithValue("@type", empty);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    this.txttext.Text = sqlDataReader["logotext"].ToString();
                    company_logo.oldFileName = sqlDataReader["logoimage"].ToString();
                    this.lblfilename.Visible = false;
                    this.lblOld.Text = string.Concat(this.objLanguage.convert("Current image"), ": ");
                    this.lblOld.Visible = false;
                    QueryString queryString = new QueryString()
				{
					{ "doctype", "logo" },
					{ "filename", sqlDataReader["logoimage"].ToString() }
				};
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    Label label = this.lblfilename;
                    string[] strArrays1 = new string[] { "<a href='", this.strSitepath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", sqlDataReader["logoimage"].ToString(), "</a>" };
                    label.Text = string.Concat(strArrays1);
                    this.logotype = sqlDataReader["logotype"].ToString();
                    string lower = this.logotype.Trim().ToLower();
                    string str = lower;
                    if (lower != null)
                    {
                        if (str == "text")
                        {
                            this.rdtext.Checked = true;
                            this.rdimage.Checked = false;
                            this.rdtemplate.Checked = false;
                            goto Label0;
                        }
                        else if (str == "image")
                        {
                            this.rdtext.Checked = false;
                            this.rdimage.Checked = true;
                            this.rdtemplate.Checked = false;
                            this.pnlimage.Visible = true;
                            this.lblOld.Visible = true;
                            this.lblfilename.Visible = true;
                            this.LinkButton1.Visible = true;
                            goto Label0;
                        }
                        else
                        {
                            if (str != "template")
                            {
                                goto Label2;
                            }
                            this.rdtext.Checked = false;
                            this.rdimage.Checked = false;
                            this.rdtemplate.Checked = true;
                            this.txttemplate.Text = sqlDataReader["logotemplate"].ToString();
                            goto Label0;
                        }
                    }
                Label2:
                    this.rdtext.Checked = true;
                    this.lblfilename.Visible = true;
                Label0:
                    if (sqlDataReader["Isdefault"].ToString().ToLower() != "true")
                    {
                        this.chkdefault.Checked = false;
                    }
                    else
                    {
                        if (this.type != 1)
                        {
                            this.rdtext.Checked = true;
                            this.rdimage.Checked = false;
                            this.rdtemplate.Checked = false;
                        }
                        else
                        {
                            this.rdimage.Checked = false;
                            this.rdtext.Checked = true;
                            this.rdtemplate.Checked = false;
                        }
                        this.chkdefault.Checked = false;
                    }
                }
                sqlDataReader.Close();
                sqlDataReader.Dispose();
                _commonClass.closeConnection();
                _commonClass.Dispose();
                sqlCommand.Dispose();
                if (this.image == "image")
                {
                    this.lblOld.Visible = false;
                    this.lblfilename.Visible = false;
                    this.LinkButton1.Visible = false;
                }
                if (this.txttemplate.Text == "")
                {
                    if (string.IsNullOrEmpty(company_logo.oldFileName))
                    {
                        company_logo.oldFileName = "Image File Name";
                    }
                    this.txttemplate.Text = "";
                }
            }
            this.LinkButton1.Attributes.Add("onclick", string.Concat("javascript:return window.confirm('", this.objLanguage.GetLanguageConversion("Image_Delete_Confirmation"), "');"));
            this.objLanguage.Dispose();
            try
            {
                if (base.Request.QueryString["error"] == "1")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
            this.img_Help_ShortDescritpion_Link_Image.Title = this.objLanguage.GetLanguageConversion("File_exstensions_allowed_gif_png_jpg_jpeg_tiff_tif_bmp");
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:hide_textbox();", true);
        }

        public void SaveLogo(int companyId, int isdefault, string logotext, string logoimage, string logotemplat, string logotype, string headerFooter)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_company_logo_edit", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
            sqlCommand.Parameters.AddWithValue("@isdefault", isdefault);
            sqlCommand.Parameters.AddWithValue("@logotext", logotext);
            sqlCommand.Parameters.AddWithValue("@logoimage", logoimage);
            sqlCommand.Parameters.AddWithValue("@logotemplate", logotemplat);
            sqlCommand.Parameters.AddWithValue("@logotype", logotype);
            sqlCommand.Parameters.AddWithValue("@type", headerFooter);
            sqlCommand.ExecuteReader();
            _commonClass.closeConnection();
            _commonClass.Dispose();
            sqlCommand.Dispose();
            HttpResponse response = base.Response;
            object[] objArray = new object[] { global.sitePath(), "Settings/company_logo.aspx?type=", this.type, "&error=1" };
            response.Redirect(string.Concat(objArray));
        }
    }
}