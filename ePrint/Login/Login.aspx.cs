using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using nmsLanguage;
using nmsLogin;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.Printcenter.Views
{
    public partial class Login : System.Web.UI.Page
    {

        protected HtmlHead Head1 = new HtmlHead();

        protected HiddenField hdnScreenWidth = new HiddenField();

        protected PlaceHolder plhLoginImg = new PlaceHolder();

        protected System.Web.UI.WebControls.Image ImgError = new System.Web.UI.WebControls.Image();

        protected Label lblerror = new Label();

        protected HtmlGenericControl div_InvalidMsg = new HtmlGenericControl();

        //protected Label lblEmail;

        //protected HtmlInputText email;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator1;

        //protected Sample.Web.UI.Compatibility.RegularExpressionValidator RegularExpressionValidator1;

        //protected Label lblPassword;

        //protected HiddenField hdnpassword;

        //protected TextBox password;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator2;

        //protected Button btnlogin;

        //protected HiddenField hdn_login;

        //protected HiddenField hdn_pass;

        //protected HtmlInputCheckBox chkremember;

        //protected Label lblRememberMe;

        //protected Label lblRemembermeNote;

        protected PlaceHolder plhFooter = new PlaceHolder();

        //protected HtmlForm form1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = string.Concat(global.sitePath(), "images/");

        public static string LoginPageUpdates = string.Empty;

        public string strpath;

        public languageClass objLanguage = new languageClass();

        public string strCompany = global.companyName();

        public int subscriptionid;

        public int loginDay;

        private int nooflogin;

        private int userid;

        private int COMPANYID;

        private DateTime isCompanyExpire = DateTime.Parse("1/1/1900");

        private DateTime IsUserExpire = DateTime.Parse("1/1/1900");

        private static int displayVerificationImage;

        public string displaytextbox = "none";

        private static bool isSecurity;

        public string RegionalSettings = string.Empty;

        public string PasswordValue = string.Empty;

        public string stext = string.Empty;

        private string roundoff = "2";

        public string tabcolor = "";

        public string defaultlanding = string.Empty;

        public string forecolor = "";
        private static readonly object LoginPerfLogLock = new object();
        private static int? _cachedLoginCompanyId;

        public BasePage objpage = new BasePage();

        public BaseClass objclass = new BaseClass();

        private commonClass cmn = new commonClass();

        private DateTime ChangePasswordOn;

        private storeEmail Objemail = new storeEmail();

        public string ServerName = string.Empty;
        public Login()
        {
            try
            {
                strImagepath = string.Concat(global.sitePath(), "images/");

            }
            catch (Exception)
            {
            }
        }

        public void RenderLoginPageUpdates()
        {
            try
            {
                LoginPageUpdates = string.Concat(ConfigurationManager.AppSettings["LoginPageUpdatesFilePath"]?.ToString());
                if (!string.IsNullOrEmpty(LoginPageUpdates))
                {
                    string filePath = LoginPageUpdates;

                    // Check if the file exists
                    if (File.Exists(filePath))
                    {
                        // Read the file contents
                        string htmlContent = File.ReadAllText(filePath);

                        if (!string.IsNullOrEmpty(htmlContent))
                        {
                            // Assign the contents to the Literal control
                            ltrLoginPageUpdates.Text = $"<div class='custom-container'>{htmlContent}</div>";
                            ClientScript.RegisterStartupScript(this.GetType(), "InjectShadowDOM", $@"
                                document.addEventListener('DOMContentLoaded', function() {{
                                    const shadowHost = document.getElementById('custom-container');
                                    const shadowRoot = shadowHost.attachShadow({{ mode: 'open' }});
                                    shadowRoot.innerHTML = `{htmlContent}`;
                                    
                                }});
                                document.getElementById('divLtrLoginPageUpdates').style.display = 'block';
                            ", true); 
                        }
                    }
                    else
                    {
                        // Map server path and try to retrieve the file
                        filePath = Server.MapPath(filePath);
                        if (File.Exists(filePath))
                        {
                            //filePath = Server.MapPath(LoginPageUpdates);
                            // Read the file contents
                            string htmlContent = File.ReadAllText(filePath);

                            if (!string.IsNullOrEmpty(htmlContent))
                            {
                                // Assign the contents to the Literal control
                                ltrLoginPageUpdates.Text = $"<div class='custom-container'>{htmlContent}</div>";

                                ClientScript.RegisterStartupScript(this.GetType(), "InjectShadowDOM", $@"
                                document.addEventListener('DOMContentLoaded', function() {{
                                    const shadowHost = document.getElementById('custom-container');
                                    const shadowRoot = shadowHost.attachShadow({{ mode: 'open' }});
                                    shadowRoot.innerHTML = `{htmlContent}`;

                                }});
                                document.getElementById('divLtrLoginPageUpdates').style.display = 'block';
                            ", true); 
                            }
                        }
                    }
                   
                }
            }
            catch (Exception e)
            {
            }
        }
        protected void btnContinue_OnClick(object sender, EventArgs e)
        {
            TimeSpan timeOfDay;
            int milliseconds;
            loginClass _loginClass = new loginClass();

            if (this.hdn_login.Value != "" && this.hdn_pass.Value != "")
            {
                _loginClass.LogInFromDefault(this.objclass.SpecialEncode(this.hdn_login.Value.ToString()), this.hdn_pass.Value.ToString());
                this.cmn.ht_UserSettings.Clear();
                this.cmn.UserSetting_Insert(this.COMPANYID, this.userid);
                if (this.lblerror.Text != this.objLanguage.GetLanguageConversion("UnAuthorise_Note"))
                {
                    IPAddress pAddress = new IPAddress();
                    SqlCommand sqlCommand = new SqlCommand("crm_common_login_new", (new commonClass()).openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("email", this.objclass.SpecialEncode(this.hdn_login.Value.ToString()).Trim());
                    sqlCommand.Parameters.AddWithValue("password", this.hdn_pass.Value.ToString().Trim());
                    pAddress.InsertLoginInfo(this.objclass.SpecialEncode(this.hdn_login.Value), this.hdn_pass.Value.ToString().Trim());
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        this.userid = int.Parse(sqlDataReader["userid"].ToString());
                        this.nooflogin = int.Parse(sqlDataReader["noOfLogin"].ToString());
                        this.COMPANYID = int.Parse(sqlDataReader["companyid"].ToString());
                        this.defaultlanding = sqlDataReader["DefaultLanding"].ToString();
                    }
                    if (this.Session["DirectLogin"] != null)
                    {
                        string str = this.Session["DirectLogin"].ToString();
                        this.Session["DirectLogin"] = null;
                        base.Response.Redirect(str);
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "Home" || this.defaultlanding.Trim().ToUpper() == "HOME")
                    {
                        HttpResponse response = base.Response;
                        string str1 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response.Redirect(string.Concat(str1, "welcome.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "CLIENTS")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse = base.Response;
                            string str2 = global.sitePath();
                            int num = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse.Redirect(string.Concat(str2, "welcome.aspx?sec=", num.ToString()), false);
                            return;
                        }
                        HttpResponse response1 = base.Response;
                        string str3 = global.sitePath();
                        int milliseconds1 = DateTime.Now.TimeOfDay.Milliseconds;
                        response1.Redirect(string.Concat(str3, "client/client_view.aspx?sec=", milliseconds1.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "ESTIMATES")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse1 = base.Response;
                            string str4 = global.sitePath();
                            int num1 = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse1.Redirect(string.Concat(str4, "welcome.aspx?sec=", num1.ToString()), false);
                            return;
                        }
                        HttpResponse response2 = base.Response;
                        string str5 = global.sitePath();
                        int milliseconds2 = DateTime.Now.TimeOfDay.Milliseconds;
                        response2.Redirect(string.Concat(str5, "estimates/estimate_view.aspx?sec=", milliseconds2.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "WEBSTOREORDER")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse2 = base.Response;
                            string str6 = global.sitePath();
                            int num2 = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse2.Redirect(string.Concat(str6, "welcome.aspx?sec=", num2.ToString()), false);
                            return;
                        }
                        HttpResponse response3 = base.Response;
                        string str7 = global.sitePath();
                        int milliseconds3 = DateTime.Now.TimeOfDay.Milliseconds;
                        response3.Redirect(string.Concat(str7, "orders/order_view.aspx?sec=", milliseconds3.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "JOBS")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            string str8 = global.sitePath();
                            int num3 = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse3.Redirect(string.Concat(str8, "welcome.aspx?sec=", num3.ToString()), false);
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        string str9 = global.sitePath();
                        int milliseconds4 = DateTime.Now.TimeOfDay.Milliseconds;
                        response4.Redirect(string.Concat(str9, "Jobs/jobs_view.aspx?sec=", milliseconds4.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "PURCHASES")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            string str10 = global.sitePath();
                            int num4 = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse4.Redirect(string.Concat(str10, "welcome.aspx?sec=", num4.ToString()), false);
                            return;
                        }
                        HttpResponse response5 = base.Response;
                        string str11 = global.sitePath();
                        int milliseconds5 = DateTime.Now.TimeOfDay.Milliseconds;
                        response5.Redirect(string.Concat(str11, "Purchase/purchase_view.aspx?sec=", milliseconds5.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "DELIVERYNOTE")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("delieverynote", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse5 = base.Response;
                            string str12 = global.sitePath();
                            int num5 = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse5.Redirect(string.Concat(str12, "welcome.aspx?sec=", num5.ToString()), false);
                            return;
                        }
                        HttpResponse response6 = base.Response;
                        string str13 = global.sitePath();
                        int milliseconds6 = DateTime.Now.TimeOfDay.Milliseconds;
                        response6.Redirect(string.Concat(str13, "Delivery/delivery_view.aspx?sec=", milliseconds6.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "SETTINGS")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("settings", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse6 = base.Response;
                            string str14 = global.sitePath();
                            milliseconds = DateTime.Now.TimeOfDay.Milliseconds;
                            httpResponse6.Redirect(string.Concat(str14, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response7 = base.Response;
                        string str15 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response7.Redirect(string.Concat(str15, "settings/settings.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "WAREHOUSE")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse7 = base.Response;
                            string str16 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse7.Redirect(string.Concat(str16, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response8 = base.Response;
                        string str17 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response8.Redirect(string.Concat(str17, "warehouse/warehouse.aspx?type=inventory&&sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "CAMPAIGN")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse8 = base.Response;
                            string str18 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse8.Redirect(string.Concat(str18, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response9 = base.Response;
                        string str19 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response9.Redirect(string.Concat(str19, "campaign/campaign_view.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "INVOICES")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse9 = base.Response;
                            string str20 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse9.Redirect(string.Concat(str20, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response10 = base.Response;
                        string str21 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response10.Redirect(string.Concat(str21, "Invoice/invoice_view.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "REPORTS")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("reports", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse10 = base.Response;
                            string str22 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse10.Redirect(string.Concat(str22, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response11 = base.Response;
                        string str23 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response11.Redirect(string.Concat(str23, "common/report.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "DOCUMENTS")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("documents", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            HttpResponse httpResponse11 = base.Response;
                            string str24 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse11.Redirect(string.Concat(str24, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        HttpResponse response12 = base.Response;
                        string str25 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response12.Redirect(string.Concat(str25, "documents/document.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "PRODUCTCATALOGUE")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                        {
                            base.Response.Redirect(string.Concat(global.sitePath(), "ProductCatalogue/PriceCatalogue.aspx"));
                            return;
                        }
                        HttpResponse httpResponse12 = base.Response;
                        string str26 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        httpResponse12.Redirect(string.Concat(str26, "welcome.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                    if (this.defaultlanding.Trim().ToUpper() == "FORECAST")
                    {
                        if (this.objclass.ReturnRoles_Privileges_ForGrid("forecast", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                        {
                            base.Response.Redirect(string.Concat(global.sitePath(), "forecast/forecast.aspx"));
                            return;
                        }
                        HttpResponse response13 = base.Response;
                        string str27 = global.sitePath();
                        timeOfDay = DateTime.Now.TimeOfDay;
                        milliseconds = timeOfDay.Milliseconds;
                        response13.Redirect(string.Concat(str27, "welcome.aspx?sec=", milliseconds.ToString()), false);
                        return;
                    }
                }
                else if (this.lblerror.Text == this.objLanguage.GetLanguageConversion("UnAuthorise_Note"))
                {
                    this.div_InvalidMsg.Style.Add("display", "block");
                    this.lblerror.Visible = true;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "Close", "javascript:CloseRes();", true);
                }
            }
        }

        protected void btnLogIN_Click(object sender, EventArgs e)
        {
            this.EnsureLoginSessionPrimed(this.GetLoginCompanyId());
            HttpCookie httpCookie = new HttpCookie("notifiocation397", "no");
            base.Response.Cookies.Add(httpCookie);
            if (Login.displayVerificationImage >= 3)
            {
                Login.isSecurity = true;
            }
            if (!Login.isSecurity)
            {
                this.login(false);
                return;
            }
            this.displaytextbox = "none";
            this.div_InvalidMsg.Style.Add("display", "block");
            this.lblerror.Visible = true;
        }

        protected void btnNo_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "default.aspx"));
        }

        public void CheckIPAddress(long CompanyID, string Username)
        {
            this.lblerror.Text = "";
            string empty = string.Empty;
            if (ConnectionClass.IsLocal.ToString().ToLower() != "true")
            {
                empty = base.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (empty == "" || empty == null)
                {
                    empty = base.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            else
            {
                Dns.GetHostEntry(Dns.GetHostName());
                empty = Login.LocalIPAddress();
            }
            if (empty.Trim().ToLower().IndexOf("local") == -1)
            {
                DataTable dataTable = SettingsBasePage.select_SystemIp_Address(Convert.ToInt64(this.Session["UserTypeID"]));
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["IPAddresstype"].ToString().ToUpper() == "S" && row["IPAddresstype"].ToString() != "")
                    {
                        if (row["IPAddressList"].ToString() == empty)
                        {
                            continue;
                        }
                        this.lblerror.Text = this.objLanguage.GetLanguageConversion("Unauthorise_Note");
                        this.iprestricted();
                        if (row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() == null || !(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() != ""))
                        {
                            continue;
                        }
                        this.Objemail.emailInvalidLoginDetail(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString(), empty, Username, CompanyID, base.Request.Url.ToString());
                    }
                    else if (!(row["IPAddresstype"].ToString().ToUpper() == "M") || !(row["IPAddresstype"].ToString() != ""))
                    {
                        if (!(row["IPAddresstype"].ToString().ToUpper() == "R") || !(row["IPAddresstype"].ToString() != ""))
                        {
                            continue;
                        }
                        string str = string.Empty;
                        string empty1 = string.Empty;
                        string str1 = row["IPAddressList"].ToString();
                        char[] chrArray = new char[] { ',' };
                        if ((int)str1.Split(chrArray).Length > 0)
                        {
                            string str2 = row["IPAddressList"].ToString();
                            char[] chrArray1 = new char[] { ',' };
                            str = str2.Split(chrArray1)[0].ToString();
                        }
                        string str3 = row["IPAddressList"].ToString();
                        char[] chrArray2 = new char[] { ',' };
                        if ((int)str3.Split(chrArray2).Length > 1)
                        {
                            string str4 = row["IPAddressList"].ToString();
                            char[] chrArray3 = new char[] { ',' };
                            empty1 = str4.Split(chrArray3)[1].ToString();
                        }
                        if (str.IndexOf(".") < 3 || empty1.IndexOf(".") < 3 || empty.IndexOf(".") < 3)
                        {
                            this.lblerror.Text = this.objLanguage.GetLanguageConversion("Unauthorise_Note");
                            this.iprestricted();
                            if (row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() == null || !(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() != ""))
                            {
                                continue;
                            }
                            this.Objemail.emailInvalidLoginDetail(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString(), empty, Username, CompanyID, base.Request.Url.ToString());
                        }
                        else
                        {
                            string[] strArrays = str.Trim().Split(new char[] { '.' });
                            double num = Convert.ToDouble(16777216 * Convert.ToDouble(strArrays[0]) + 65536 * Convert.ToDouble(strArrays[1]) + 256 * Convert.ToDouble(strArrays[2]) + Convert.ToDouble(strArrays[3]));
                            string[] strArrays1 = empty1.ToString().Trim().Split(new char[] { '.' });
                            double num1 = Convert.ToDouble(16777216 * Convert.ToDouble(strArrays1[0]) + 65536 * Convert.ToDouble(strArrays1[1]) + 256 * Convert.ToDouble(strArrays1[2]) + Convert.ToDouble(strArrays1[3]));
                            string[] strArrays2 = empty.Trim().Split(new char[] { '.' });
                            double num2 = Convert.ToDouble(16777216 * Convert.ToDouble(strArrays2[0]) + 65536 * Convert.ToDouble(strArrays2[1]) + 256 * Convert.ToDouble(strArrays2[2]) + Convert.ToDouble(strArrays2[3]));
                            if (num2 >= num && num2 <= num1)
                            {
                                continue;
                            }
                            this.lblerror.Text = this.objLanguage.GetLanguageConversion("Unauthorise_Note");
                            this.iprestricted();
                            if (row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() == null || !(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() != ""))
                            {
                                continue;
                            }
                            this.Objemail.emailInvalidLoginDetail(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString(), empty, Username, CompanyID, base.Request.Url.ToString());
                        }
                    }
                    else
                    {
                        int num3 = 0;
                        string[] strArrays3 = row["IPAddressList"].ToString().Split(new char[] { '\r' });
                        for (int i = 0; i < (int)strArrays3.Length; i++)
                        {
                            if (strArrays3[i].ToString().Replace('\n', ' ').TrimStart(new char[0]) == empty)
                            {
                                num3++;
                            }
                        }
                        if (num3 != 0)
                        {
                            continue;
                        }
                        this.lblerror.Text = this.objLanguage.GetLanguageConversion("Unauthorise_Note");
                        this.iprestricted();
                        if (row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() == null || !(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() != ""))
                        {
                            continue;
                        }
                        this.Objemail.emailInvalidLoginDetail(row["restrictSystemIPforUnauthorizedEmailAccess"].ToString(), empty, Username, CompanyID, base.Request.Url.ToString());
                    }
                }
            }
        }

        public string GetSubDomainName(string Url)
        {
            if (Url.Contains("://"))
            {
                Url = Url.ToLower().Replace("http://", "").Replace("http://", "");
            }
            if (Url.IndexOf(".") <= 1)
            {
                Url = string.Empty;
            }
            else
            {
                char[] chrArray = new char[] { '.' };
                Url = Url.Split(chrArray)[0].ToString();
            }
            return Url;
        }

        public void InsertSessionValue(string email, string password, long ScreenResolutionWidth)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_resumeSession_insert", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@email", email);
            sqlCommand.Parameters.Add("@password", password);
            sqlCommand.Parameters.Add("@ScreenResolutionWidth", ScreenResolutionWidth);
            sqlCommand.Parameters.Add("@returnvalue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            string str = Convert.ToString(sqlCommand.ExecuteScalar());
            base.Response.Cookies.Add(new HttpCookie("hdnSessionId", str.ToString()));
            _commonClass.closeConnection();
            loginClass.hdnvalue = str.ToString();
        }

        public void iprestricted()
        {
            loginClass._LogIN = false;
            this.Session["email"] = null;
            this.Session["password"] = null;
            this.Session["accessdenied"] = "iprestricted";
            this.lblerror.Visible = true;
            this.div_InvalidMsg.Style.Add("display", "block");
        }

        public static string LocalIPAddress()
        {
            string str = "";
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < (int)addressList.Length; i++)
            {
                System.Net.IPAddress pAddress = addressList[i];
                if (pAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    str = pAddress.ToString();
                }
            }
            return str;
        }

        public void login(bool isPageLoad)
        {
            TimeSpan timeOfDay;
            int milliseconds;
            Stopwatch loginTimer = Stopwatch.StartNew();
            Stopwatch stageTimer = Stopwatch.StartNew();
            long num = (long)1366;
            if (this.hdnScreenWidth.Value != "")
            {
                num = Convert.ToInt64(this.hdnScreenWidth.Value);
            }
            this.Session["ScreenResolutionWidth"] = num;
            IPAddress pAddress = new IPAddress();
            string empty = string.Empty;
            bool flag = false;
            bool flag1 = false;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_login_new", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            string str = string.Empty;
            sqlCommand.Parameters.AddWithValue("email", this.objclass.SpecialEncode(this.email.Value).ToString().Trim());
            if (!isPageLoad)
            {
                sqlCommand.Parameters.AddWithValue("password", commonClass.Encrypt(this.password.Text.ToString().Trim()));
                str = commonClass.Encrypt(this.password.Text.ToString().Trim());
                if (!BasePage.IsLightweightAuthPageEnabled())
                {
                    pAddress.InsertLoginInfo(this.objclass.SpecialEncode(this.email.Value), commonClass.Encrypt(this.password.Text.ToString().Trim()));
                }
            }
            else
            {
                if (!BasePage.IsLightweightAuthPageEnabled())
                {
                    pAddress.InsertLoginInfo(this.objclass.SpecialEncode(this.email.Value), commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim()));
                }
                sqlCommand.Parameters.AddWithValue("password", commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim()));
                str = commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim());
            }
            this.LogLoginPerfStage("InsertLoginInfo", stageTimer, loginTimer);
            this.nooflogin = 0;
            this.COMPANYID = 0;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.userid = int.Parse(sqlDataReader["userid"].ToString());
                this.nooflogin = int.Parse(sqlDataReader["noOfLogin"].ToString());
                this.COMPANYID = int.Parse(sqlDataReader["companyid"].ToString());
                empty = string.Concat(this.objclass.SpecialDecode(sqlDataReader["firstname"].ToString()), " ", this.objclass.SpecialDecode(sqlDataReader["lastname"].ToString()));
                this.defaultlanding = sqlDataReader["DefaultLanding"].ToString();
                this.ChangePasswordOn = Convert.ToDateTime(sqlDataReader["ChangePasswordOn"]);
                this.Session[string.Concat("TabColours", this.COMPANYID)] = null;
                flag = Convert.ToBoolean(sqlDataReader["DisableAccount"].ToString());
                flag1 = true;
                loginClass._LogIN = true;
                loginClass._email = this.email.Value.ToString();
                if (!this.chkremember.Checked)
                {
                    base.Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                    base.Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                }
                else
                {
                    base.Response.Cookies["email"].Value = this.email.Value;
                    if (this.password.Text.Length > 0)
                    {
                        base.Response.Cookies["password"].Value = this.password.Text.ToString().Trim();
                        base.Response.Cookies["password"].Expires = DateTime.Now.AddDays(100);
                    }
                    base.Response.Cookies["email"].Expires = DateTime.Now.AddDays(100);
                }
                HttpCookie httpCookie = new HttpCookie("ckeLoginEmailDetails");
                httpCookie["ckeLoginEmailValue"] = this.email.Value.Trim();
                base.Response.Cookies.Add(httpCookie);
            }
            sqlDataReader.Close();
            this.LogLoginPerfStage("crm_common_login_new", stageTimer, loginTimer);
            _commonClass.closeConnection();
            if (flag)
            {
                this.lblerror.Text = this.objLanguage.GetLanguageConversion("Your_account_has_been_disabled");
                flag1 = false;
            }
            if (!flag1)
            {
                Login.displayVerificationImage = Login.displayVerificationImage + 1;
                DataTable dataTable = new DataTable();
                dataTable = SettingsBasePage.User_IsValid_Select(this.objclass.SpecialEncode(this.email.Value), commonClass.Encrypt(this.password.Text.ToString().Trim()));
                int num1 = Convert.ToInt16(dataTable.Rows[0]["islockedemail"]);
                int num2 = Convert.ToInt16(dataTable.Rows[0]["invalidlogin"]);
                commonClass _commonClass1 = new commonClass();
                SqlCommand sqlCommand1 = new SqlCommand("crm_insert_invalidlogindetails", _commonClass1.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand1.Parameters.Add("@email", this.email.Value.Trim());
                sqlCommand1.Parameters.Add("@ipaddress", HttpContext.Current.Request.UserHostAddress);
                sqlCommand1.Parameters.Add("@password", this.hdnpassword.Value.Trim());
                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                int num3 = 0;
                int num4 = 0;
                while (sqlDataReader1.Read())
                {
                    num3 = Convert.ToInt32(sqlDataReader1["finalretval"]);
                    num4 = Convert.ToInt32(sqlDataReader1["finalNoofInvalidAttempt"]);
                }
                sqlDataReader1.Close();
                this.LogLoginPerfStage("InvalidLoginHandling", stageTimer, loginTimer);
                _commonClass1.closeConnection();
                if (num3 == -1)
                {
                    this.lblerror.Text = this.objLanguage.GetLanguageConversion("Invalid_login_details");
                }
                else if (num4 == 0)
                {
                    if (num1 != -1)
                    {
                        this.lblerror.Text = this.objLanguage.GetLanguageConversion("Invalid_Password");
                    }
                    else if (num2 != -1)
                    {
                        this.lblerror.Text = this.objLanguage.GetLanguageConversion("Invalid_Password");
                    }
                    else
                    {
                        this.lblerror.Text = this.objLanguage.GetLanguageConversion("Sorry_your_login_details_has_been_locked");
                    }
                }
                else if (num3 == 999)
                {
                    this.lblerror.Text = this.objLanguage.GetLanguageConversion("your_account_has_been_deactivate_please_contact_administrator");
                }
                else if (num1 != -1)
                {
                    Label label = this.lblerror;
                    object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("Invalid_login_credentials_you_have"), " ", num4 - num3, " ", this.objLanguage.GetLanguageConversion("more_attempts") };
                    label.Text = string.Concat(languageConversion);
                }
                else if (num2 != -1)
                {
                    this.lblerror.Text = this.objLanguage.GetLanguageConversion("Invalid_Password");
                }
                else
                {
                    this.lblerror.Text = this.objLanguage.GetLanguageConversion("Sorry_your_login_details_has_been_locked");
                }
            }
            if (!flag1)
            {
                this.div_InvalidMsg.Style.Add("display", "block");
                this.lblerror.Visible = true;
            }
            else
            {
                this.Session["LoginCompanyID"] = null;
                this.Session["accessdenied"] = null;
                num = (long)1366;
                if (this.hdnScreenWidth.Value != "")
                {
                    num = Convert.ToInt64(this.hdnScreenWidth.Value);
                }
                this.InsertSessionValue(this.objclass.SpecialEncode(this.email.Value), str, num);
                SqlConnection loginConn = _commonClass.openConnection();
                try
                {
                    SqlCommand sqlCommand2 = new SqlCommand("crm_update_InvalidAttempts", loginConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand2.Parameters.AddWithValue("@email", this.email.Value.Trim());
                    sqlCommand2.Parameters.AddWithValue("@password", str);
                    sqlCommand2.ExecuteNonQuery();
                    SqlCommand sqlCommand3 = new SqlCommand("crm_update_loginDay", loginConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand3.Parameters.AddWithValue("@companyId", this.COMPANYID);
                    sqlCommand3.ExecuteNonQuery();
                }
                finally
                {
                    _commonClass.closeConnection();
                }
                this.LogLoginPerfStage("crm_update_InvalidAttempts+loginDay", stageTimer, loginTimer);
                if (Convert.ToDateTime(this.ChangePasswordOn.ToShortDateString()) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "changepassword.aspx"), true);
                }
                if (HttpContext.Current.Cache[""] == null || isPageLoad)
                {
                    bool deferNavigationBootstrap = BasePage.IsLightweightAuthPageEnabled()
                        && BasePage.IsHomeDefaultLanding(this.defaultlanding);
                    if (deferNavigationBootstrap)
                    {
                        this.Session["DeferNavigationBootstrap"] = "1";
                    }
                    loginClass _loginClass = new loginClass();
                    _loginClass.LogInFromDefault(this.objclass.SpecialEncode(this.email.Value.ToString()), str, deferNavigationBootstrap);
                    this.LogLoginPerfStage("LogInFromDefault", stageTimer, loginTimer);
                    DataTable dataTable1 = SettingsBasePage.select_SystemIp_Address(Convert.ToInt64(this.Session["UserTypeID"]));
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        if (row["IPAddresstype"].ToString() == "")
                        {
                            continue;
                        }
                        this.CheckIPAddress((long)this.COMPANYID, empty);
                    }
                    if (this.lblerror.Text != this.objLanguage.GetLanguageConversion("UnAuthorise_Note"))
                    {
                        if (this.nooflogin == 0)
                        {
                            string str1 = string.Concat("update tb_company set nooflogin=nooflogin+1 where companyid=", this.COMPANYID);
                            (new SqlCommand(str1, _commonClass.openConnection())).ExecuteNonQuery();
                            _commonClass.closeConnection();
                        }
                        if (this.TryFastHomeLoginRedirect())
                        {
                            this.LogLoginPerfFinal("fast home redirect", loginTimer);
                            return;
                        }
                        if (this.Session["userTypeID"] != null)
                        {
                            SqlCommand sqlCommand4 = new SqlCommand("PC_RolesAndPrivileges_select", (new commonClass()).openConnection())
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            sqlCommand4.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                            sqlCommand4.Parameters.AddWithValue("@UserTypeID", Convert.ToInt32(this.Session["userTypeID"]));
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand4);
                            DataSet dataSet = new DataSet();
                            sqlDataAdapter.Fill(dataSet);
                            this.Session["Roles_Privileges_Others"] = dataSet.Tables[0];
                            this.Session["Roles_Privileges_Tabs"] = dataSet.Tables[1];
                            this.Session["Roles_Privileges_Reports"] = dataSet.Tables[2];
                            this.LogLoginPerfStage("PC_RolesAndPrivileges_select", stageTimer, loginTimer);
                        }
                        try
                        {
                            foreach (DataRow dataRow in SettingsBasePage.settings_regionalsettings_select(this.COMPANYID).Rows)
                            {
                                this.roundoff = dataRow["Roundoff"].ToString();
                            }
                            this.Session["Roundoff"] = this.roundoff;
                        }
                        catch
                        {
                        }
                        _commonClass.ht_UserSettings.Clear();
                        _commonClass.UserSetting_Insert(this.COMPANYID, this.userid);
                        this.LogLoginPerfStage("UserSetting_Insert", stageTimer, loginTimer);
                        if (this.Session["DirectLogin"] != null)
                        {
                            string str2 = this.Session["DirectLogin"].ToString();
                            this.Session["DirectLogin"] = null;
                            base.Response.Redirect(str2);
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "Home" || this.defaultlanding.Trim().ToUpper() == "HOME")
                        {
                            HttpResponse response = base.Response;
                            string str3 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response.Redirect(string.Concat(str3, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "CLIENTS")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse = base.Response;
                                string str4 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse.Redirect(string.Concat(str4, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response1 = base.Response;
                            string str5 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response1.Redirect(string.Concat(str5, "client/client_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "ESTIMATES")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse1 = base.Response;
                                string str6 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse1.Redirect(string.Concat(str6, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response2 = base.Response;
                            string str7 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response2.Redirect(string.Concat(str7, "estimates/estimate_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "WEBSTOREORDER")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse2 = base.Response;
                                string str8 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse2.Redirect(string.Concat(str8, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response3 = base.Response;
                            string str9 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response3.Redirect(string.Concat(str9, "orders/order_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "JOBS")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse3 = base.Response;
                                string str10 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse3.Redirect(string.Concat(str10, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response4 = base.Response;
                            string str11 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response4.Redirect(string.Concat(str11, "Jobs/jobs_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "PURCHASES")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse4 = base.Response;
                                string str12 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse4.Redirect(string.Concat(str12, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response5 = base.Response;
                            string str13 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response5.Redirect(string.Concat(str13, "Purchase/purchase_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "DELIVERYNOTE")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("delieverynote", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse5 = base.Response;
                                string str14 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse5.Redirect(string.Concat(str14, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response6 = base.Response;
                            string str15 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response6.Redirect(string.Concat(str15, "Delivery/delivery_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "SETTINGS")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("settings", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse6 = base.Response;
                                string str16 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse6.Redirect(string.Concat(str16, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response7 = base.Response;
                            string str17 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response7.Redirect(string.Concat(str17, "settings/settings.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "WAREHOUSE")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse7 = base.Response;
                                string str18 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse7.Redirect(string.Concat(str18, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response8 = base.Response;
                            string str19 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response8.Redirect(string.Concat(str19, "warehouse/warehouse.aspx?type=inventory&&sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "CAMPAIGN")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse8 = base.Response;
                                string str20 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse8.Redirect(string.Concat(str20, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response9 = base.Response;
                            string str21 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response9.Redirect(string.Concat(str21, "campaign/campaign_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "INVOICES")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse9 = base.Response;
                                string str22 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse9.Redirect(string.Concat(str22, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response10 = base.Response;
                            string str23 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response10.Redirect(string.Concat(str23, "Invoice/invoice_view.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "REPORTS")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("reports", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse10 = base.Response;
                                string str24 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse10.Redirect(string.Concat(str24, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response11 = base.Response;
                            string str25 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response11.Redirect(string.Concat(str25, "common/report.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "DOCUMENTS")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("documents", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                            {
                                HttpResponse httpResponse11 = base.Response;
                                string str26 = global.sitePath();
                                timeOfDay = DateTime.Now.TimeOfDay;
                                milliseconds = timeOfDay.Milliseconds;
                                httpResponse11.Redirect(string.Concat(str26, "welcome.aspx?sec=", milliseconds.ToString()), false);
                                return;
                            }
                            HttpResponse response12 = base.Response;
                            string str27 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response12.Redirect(string.Concat(str27, "documents/document.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "PRODUCTCATALOGUE")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                            {
                                base.Response.Redirect(string.Concat(global.sitePath(), "ProductCatalogue/PriceCatalogue.aspx"));
                                return;
                            }
                            HttpResponse httpResponse12 = base.Response;
                            string str28 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            httpResponse12.Redirect(string.Concat(str28, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                        if (this.defaultlanding.Trim().ToUpper() == "FORECAST")
                        {
                            if (this.objclass.ReturnRoles_Privileges_ForGrid("forecast", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                            {
                                base.Response.Redirect(string.Concat(global.sitePath(), "forecast/forecast.aspx"));
                                return;
                            }
                            HttpResponse response13 = base.Response;
                            string str29 = global.sitePath();
                            timeOfDay = DateTime.Now.TimeOfDay;
                            milliseconds = timeOfDay.Milliseconds;
                            response13.Redirect(string.Concat(str29, "welcome.aspx?sec=", milliseconds.ToString()), false);
                            return;
                        }
                    }
                    else if (this.lblerror.Text == this.objLanguage.GetLanguageConversion("UnAuthorise_Note"))
                    {
                        this.div_InvalidMsg.Style.Add("display", "block");
                        this.lblerror.Visible = true;
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "Close", "javascript:CloseRes();", true);
                        return;
                    }
                }
                else
                {
                    this.hdn_login.Value = this.email.Value.ToString();
                    this.hdn_pass.Value = str;
                    loginClass _loginClass1 = new loginClass();
                    _loginClass1.LogInFromDefault(this.objclass.SpecialEncode(this.email.Value.ToString()), str);
                    this.LogLoginPerfStage("LogInFromDefault_CacheBranch", stageTimer, loginTimer);
                    DataTable dataTable2 = SettingsBasePage.select_SystemIp_Address(Convert.ToInt64(this.Session["UserTypeID"]));
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        if (row1["IPAddresstype"].ToString() == "")
                        {
                            continue;
                        }
                        this.CheckIPAddress((long)this.COMPANYID, empty);
                    }
                }
            }
            this.LogLoginPerfFinal("login() method end", loginTimer);
        }

        private void LogLoginPerfStage(string stageName, Stopwatch stageTimer, Stopwatch loginTimer)
        {
            if (stageTimer == null || !this.IsLoginPerfLogEnabled())
            {
                return;
            }

            string line = string.Concat(
                "[LOGIN-PERF] ",
                stageName,
                " stageMs=",
                stageTimer.ElapsedMilliseconds.ToString(),
                " totalMs=",
                (loginTimer == null ? 0L : loginTimer.ElapsedMilliseconds).ToString(),
                " user=",
                this.email == null ? string.Empty : this.email.Value);
            this.WriteLoginPerfLine(line);

            stageTimer.Restart();
        }

        private void LogLoginPerfFinal(string reason, Stopwatch loginTimer)
        {
            if (!this.IsLoginPerfLogEnabled())
            {
                return;
            }

            string line = string.Concat(
                "[LOGIN-PERF] END ",
                reason,
                " totalMs=",
                (loginTimer == null ? 0L : loginTimer.ElapsedMilliseconds).ToString(),
                " user=",
                this.email == null ? string.Empty : this.email.Value);
            this.WriteLoginPerfLine(line);
        }

        private bool IsLoginPerfLogEnabled()
        {
            string setting = ConfigurationManager.AppSettings["EnableLoginPerfLog"];
            return string.Equals(setting, "true", StringComparison.OrdinalIgnoreCase);
        }

        private void WriteLoginPerfLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            string datedLine = string.Concat(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), " ", line);
            System.Diagnostics.Debug.WriteLine(datedLine);

            try
            {
                string filePath = this.GetLoginPerfLogFilePath();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return;
                }

                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                lock (LoginPerfLogLock)
                {
                    // Append-only; keep file trimmed so AV/lock contention stays low on dev machines.
                    const int maxLogBytes = 512000;
                    try
                    {
                        if (File.Exists(filePath))
                        {
                            var info = new FileInfo(filePath);
                            if (info.Length > maxLogBytes)
                            {
                                string[] lines = File.ReadAllLines(filePath);
                                int keep = Math.Min(lines.Length, 400);
                                if (keep < lines.Length)
                                {
                                    File.WriteAllLines(filePath, lines.Skip(lines.Length - keep).ToArray());
                                }
                            }
                        }
                    }
                    catch
                    {
                        // ignore trim failures
                    }
                    File.AppendAllText(filePath, datedLine + Environment.NewLine);
                }
            }
            catch
            {
                // Ignore logging failures; login flow must never fail because of diagnostics logging.
            }
        }

        private string GetLoginPerfLogFilePath()
        {
            try
            {
                if (HttpContext.Current != null && HttpContext.Current.Server != null)
                {
                    return HttpContext.Current.Server.MapPath("~/App_Data/login-perf.log");
                }
            }
            catch
            {
            }

            try
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "login-perf.log");
            }
            catch
            {
                return string.Empty;
            }
        }

        private Stopwatch _pagePerfTotal;
        private Stopwatch _pagePerfStage;

        protected override void OnPreInit(EventArgs e)
        {
            this._pagePerfTotal = Stopwatch.StartNew();
            this._pagePerfStage = Stopwatch.StartNew();
            this.LogPagePerfStage("OnPreInit", this._pagePerfStage);
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (this.form1 != null)
            {
                this.form1.Action = base.ResolveUrl("~/Login/Login.aspx");
            }
            this.LogPagePerfStage("OnInit (after base)", this._pagePerfStage);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            this.LogPagePerfStage("OnPreLoad (after base)", this._pagePerfStage);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.LogPagePerfStage("OnLoadComplete (after base)", this._pagePerfStage);
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.LogPagePerfStage("OnPreRender (before base)", this._pagePerfStage);
            base.OnPreRender(e);
            this.LogPagePerfStage("OnPreRender (after base)", this._pagePerfStage);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            this.LogPagePerfStage("OnPreRenderComplete (after base)", this._pagePerfStage);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            this.LogPagePerfStage("Render (after base)", this._pagePerfStage);
            if (this._pagePerfTotal != null && this.IsLoginPerfLogEnabled())
            {
                this.WriteLoginPerfLine(string.Concat(
                    "[LOGIN-PAGE-PERF] END isPostBack=",
                    this.IsPostBack.ToString(),
                    " totalMs=",
                    this._pagePerfTotal.ElapsedMilliseconds.ToString(),
                    " url=",
                    base.Request != null && base.Request.RawUrl != null ? base.Request.RawUrl : string.Empty));
            }
        }

        private void LogPagePerfStage(string stageName, Stopwatch stageTimer)
        {
            if (stageTimer == null || !this.IsLoginPerfLogEnabled())
            {
                return;
            }

            long total = this._pagePerfTotal == null ? 0L : this._pagePerfTotal.ElapsedMilliseconds;
            string line = string.Concat(
                "[LOGIN-PAGE-PERF] ",
                stageName,
                " stageMs=",
                stageTimer.ElapsedMilliseconds.ToString(),
                " totalMs=",
                total.ToString(),
                " isPostBack=",
                this.IsPostBack.ToString());
            this.WriteLoginPerfLine(line);
            stageTimer.Restart();
        }

        private int GetLoginCompanyId()
        {
            if (!_cachedLoginCompanyId.HasValue)
            {
                _cachedLoginCompanyId = Convert.ToInt32(EprintConfigurationManager.AppSettings["CompanyID"].ToString());
            }
            return _cachedLoginCompanyId.Value;
        }

        private bool TryFastHomeLoginRedirect()
        {
            if (!BasePage.IsLightweightAuthPageEnabled() || !BasePage.IsHomeDefaultLanding(this.defaultlanding))
            {
                return false;
            }
            if (this.Session["DirectLogin"] != null)
            {
                string direct = this.Session["DirectLogin"].ToString();
                this.Session["DirectLogin"] = null;
                this.Session["PostLoginBootstrapPending"] = "1";
                this.EndLoginResponse(direct);
                return true;
            }
            this.Session["PostLoginBootstrapPending"] = "1";
            int milliseconds = DateTime.Now.TimeOfDay.Milliseconds;
            string welcomeUrl = string.Concat(global.sitePath(), "welcome.aspx?sec=", milliseconds.ToString());
            this.EndLoginResponse(welcomeUrl);
            return true;
        }

        private void EndLoginResponse(string url)
        {
            base.Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void EnsureLoginSessionPrimed(int companyId)
        {
            this.Session["LoginCompanyID"] = companyId;
            this.Session["language"] = "english";
            if (this.Session["ConnectionString"] == null)
            {
                HttpCookie connectionCookie = base.Request.Cookies["connectionstring"];
                this.Session["ConnectionString"] = connectionCookie != null && !string.IsNullOrEmpty(connectionCookie.Value)
                    ? connectionCookie.Value
                    : "CRMConnectionString";
            }
        }

        private void SetupAuthPageChrome(int companyId, Stopwatch pageLoadStage)
        {
            BasePage.LoadAuthPageLanguageFile(companyId, this.Session, this.cmn);
            this.LogPagePerfStage("Page_Load.LoadAuthPageLanguageFile", pageLoadStage);
            if (BasePage.IsLightweightAuthPageEnabled())
            {
                this.objpage.ApplyAuthPageLogoLightweight(this.plhLoginImg, companyId);
                this.LogPagePerfStage("Page_Load.ApplyAuthPageLogoLightweight", pageLoadStage);
            }
            else
            {
                this.objpage.ApplyAuthPageLogo(this.plhLoginImg, companyId);
                this.LogPagePerfStage("Page_Load.ApplyAuthPageLogo", pageLoadStage);
            }
        }

        private void ApplyLoginFormLabels()
        {
            this.lblLoginTitle.Text = this.objLanguage.GetLanguageConversion("Login");
            this.btnlogin.Text = "Sign in";
            this.lblEmail.Text = this.objLanguage.GetLanguageConversion("Email");
            this.lblPassword.Text = this.objLanguage.GetLanguageConversion("Password");
            this.lblRememberMe.Text = "Stay logged in";
            this.lblRemembermeNote.Text = this.objLanguage.GetLanguageConversion("Remember_Me_Note");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Invalid_Email");
            this.RequiredFieldValidator1.ErrorMessage = "Please enter Email";
            this.RequiredFieldValidator2.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Password");
        }

        /// <summary>Pre-fill remember-me fields only; user must click Login (no auto-login on page load).</summary>
        private void PrefillRememberMeCookiesOnly()
        {
            if (base.Request.Cookies["email"] == null || base.Request.Cookies["password"] == null)
            {
                this.chkremember.Checked = false;
                return;
            }
            this.email.Value = base.Request.Cookies["email"].Value;
            this.chkremember.Checked = true;
            this.PasswordValue = base.Request.Cookies["password"].Value;
            this.password.Attributes.Add("value", this.PasswordValue);
            this.hdnpassword.Value = base.Request.Cookies["password"].Value;
            this.hdn_pass.Value = this.hdnpassword.Value;
            this.hdn_login.Value = this.email.Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().IndexOf("dmcsportonline") != -1)
            {
                bool flag = false;
                string lower = base.Request.Url.ToString().ToLower();
                if (lower.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower = lower.Replace("http", "https");
                    flag = true;
                }
                if (lower.ToString().ToLower().IndexOf("https://dmcsportonline.com.au") != -1)
                {
                    lower = lower.Replace("https://dmcsportonline.com.au", "https://www.dmcsportonline.com.au");
                    flag = true;
                }
                if (flag)
                {
                    base.Response.Redirect(lower);
                }
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            int num1 = this.GetLoginCompanyId();
            if (base.IsPostBack || !BasePage.IsLightweightAuthPageEnabled())
            {
                this.EnsureLoginSessionPrimed(num1);
            }
            Stopwatch pageLoadStage = Stopwatch.StartNew();
            if (!base.IsPostBack)
            {
                this.SetupAuthPageChrome(num1, pageLoadStage);
            }
            this.ApplyLoginFormLabels();
            this.LogPagePerfStage("Page_Load.ApplyLoginFormLabels", pageLoadStage);

            //Ticket 214: Undoing the changes as they are not part of the roll out. 
            //As of now ticket 214 is working fine as per requirements
            //RenderLoginPageUpdates();
            if (!base.IsPostBack)
            {
                string empty = string.Empty;
                empty = this.GetSubDomainName(base.Request.Url.ToString());
                if (empty.Length <= 0 || !(empty.ToLower() != "www") || !(empty.ToLower() != "192"))
                {
                    if (!BasePage.IsLightweightAuthPageEnabled())
                    {
                        this.Session["ConnectionString"] = "CRMConnectionString";
                    }
                    base.Response.Cookies.Add(new HttpCookie("connectionstring", "CRMConnectionString"));
                    base.Response.Cookies.Add(new HttpCookie("sitepath", "SitePath"));
                    base.Response.Cookies.Add(new HttpCookie("filepath", "FilePath"));
                }
                else
                {
                    if (!BasePage.IsLightweightAuthPageEnabled())
                    {
                        this.Session["ConnectionString"] = empty.ToLower();
                    }
                    base.Response.Cookies.Add(new HttpCookie("connectionstring", empty.ToLower()));
                    base.Response.Cookies.Add(new HttpCookie("sitepath", string.Concat("SitePath_", empty.ToLower())));
                    base.Response.Cookies.Add(new HttpCookie("filepath", string.Concat("FilePath_", empty.ToLower())));
                }
                if (!BasePage.IsLightweightAuthPageEnabled())
                {
                    HttpCookie item = base.Request.Cookies["hdnSessionId"];
                    if (item != null)
                    {
                        commonClass _commonClass = new commonClass();
                        SqlCommand sqlCommand2 = new SqlCommand("crm_resumeSession_delete", _commonClass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand2.Parameters.Add("@hdnSessionID", item.Value.ToString());
                        sqlCommand2.ExecuteNonQuery();
                        _commonClass.closeConnection();
                        base.Request.Cookies.Set(new HttpCookie("hdnSessionId", ""));
                        base.Response.Cookies.Set(new HttpCookie("hdnSessionId", ""));
                    }
                }
            }
            if (!base.IsPostBack && string.Equals(Request.QueryString["registered"], "1", StringComparison.Ordinal))
            {
                div_RegisteredMsg.Visible = true;
                lblRegistered.Text = "Your account was created. Please sign in with your email and password.";
            }
            if (!base.IsPostBack)
            {
                Login.displayVerificationImage = 1;
                Login.isSecurity = false;
            }
            if (base.IsPostBack || !BasePage.IsLightweightAuthPageEnabled())
            {
                this.EnsureLoginSessionPrimed(num1);
            }
            this.div_InvalidMsg.Style.Add("display", "none");
            this.lblerror.Visible = false;
            this.email.Focus();
            this.nooflogin = 0;
            this.COMPANYID = 0;
            if (!base.IsPostBack)
            {
                this.PrefillRememberMeCookiesOnly();
            }
            this.LogPagePerfStage("Page_Load.End", pageLoadStage);
        }

    }
}