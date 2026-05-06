using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using nmsLanguage;
using nmsLogin;
using Printcenter.UI.Setting;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class _Default : System.Web.UI.Page, IRequiresSessionState
    {
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

        public BasePage objpage = new BasePage();

        public BaseClass objclass = new BaseClass();

        private commonClass cmn = new commonClass();

        private DateTime ChangePasswordOn;

        private storeEmail Objemail = new storeEmail();

        public string ServerName = string.Empty;

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

        static _Default()
        {
            _Default.displayVerificationImage = 1;
            _Default.isSecurity = false;
            
        }

        public _Default()
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
            HttpCookie httpCookie = new HttpCookie("notifiocation", "no");
            base.Response.Cookies.Add(httpCookie);
            if (_Default.displayVerificationImage >= 3)
            {
                _Default.isSecurity = true;
            }
            if (!_Default.isSecurity)
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
                empty = _Default.LocalIPAddress();
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
                pAddress.InsertLoginInfo(this.objclass.SpecialEncode(this.email.Value), commonClass.Encrypt(this.password.Text.ToString().Trim()));
            }
            else
            {
                pAddress.InsertLoginInfo(this.objclass.SpecialEncode(this.email.Value), commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim()));
                sqlCommand.Parameters.AddWithValue("password", commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim()));
                str = commonClass.Encrypt(this.hdnpassword.Value.ToString().Trim());
            }
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
            _commonClass.closeConnection();
            if (flag)
            {
                this.lblerror.Text = this.objLanguage.GetLanguageConversion("Your_account_has_been_disabled");
                flag1 = false;
            }
            if (!flag1)
            {
                _Default.displayVerificationImage = _Default.displayVerificationImage + 1;
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
                if (this.hdnpassword.Value == "")
                {
                    this.hdnpassword.Value = this.password.Text.ToString().Trim();
                }
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
                SqlCommand sqlCommand2 = new SqlCommand("crm_update_InvalidAttempts", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand2.Parameters.AddWithValue("@email", this.email.Value.Trim());
                sqlCommand2.Parameters.AddWithValue("@password", str);
                sqlCommand2.ExecuteNonQuery();
                _commonClass.closeConnection();
                SqlCommand sqlCommand3 = new SqlCommand("crm_update_loginDay", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand3.Parameters.AddWithValue("@companyId", this.COMPANYID);
                sqlCommand3.ExecuteNonQuery();
                _commonClass.closeConnection();
                if (Convert.ToDateTime(this.ChangePasswordOn.ToShortDateString()) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "changepassword.aspx"), true);
                }
                if (HttpContext.Current.Cache[""] == null || isPageLoad)
                {
                    loginClass _loginClass = new loginClass();
                    _loginClass.LogInFromDefault(this.objclass.SpecialEncode(this.email.Value.ToString()), str);
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
                    }
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
                            base.Response.Redirect(string.Concat(global.sitePath(), "firstlogin.aspx"));
                            return;
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
            int num = Convert.ToInt32(EprintConfigurationManager.AppSettings["CompanyID"].ToString());
            SqlCommand sqlCommand = new SqlCommand("PC_Select_LanguageFile", this.cmn.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", num);
            string str = (string)sqlCommand.ExecuteScalar();
            this.cmn.closeConnection();
            if (str != "")
            {
                this.Session["LanguageConversion"] = str;
            }
            this.btnlogin.Text = this.objLanguage.GetLanguageConversion("Login");
            this.lblEmail.Text = this.objLanguage.GetLanguageConversion("Email");
            this.lblPassword.Text = this.objLanguage.GetLanguageConversion("Password");
            this.lblRememberMe.Text = "Stay logged in";
            this.lblRemembermeNote.Text = this.objLanguage.GetLanguageConversion("Remember_Me_Note");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Invalid_Email");
            this.RequiredFieldValidator1.ErrorMessage = "Please enter Email";
            this.RequiredFieldValidator2.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Password");
            int num1 = Convert.ToInt32(EprintConfigurationManager.AppSettings["CompanyID"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand("crm_select_upperNavigationTab", this.cmn.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@companyID", num1);
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["headername"].ToString().ToLower() != "home")
                {
                    continue;
                }
                this.btnlogin.BackColor = Color.FromName(sqlDataReader["colorCode"].ToString());
                break;
            }
            this.tabcolor = this.objpage.colorCode(num1, global.pageName);
            this.forecolor = this.objpage.Forecolor(num1, global.pageName);
            (new BasePage()).logoSetting(this.plhLoginImg, this.plhFooter, num1, "both");
            this.Session["LoginCompanyID"] = num1;
            //Ticket 214: Undoing the changes as they are not part of the roll out. 
            //As of now ticket 214 is working fine as per requirements
            //RenderLoginPageUpdates();
            if (!base.IsPostBack)
            {
                string empty = string.Empty;
                empty = this.GetSubDomainName(base.Request.Url.ToString());
                if (empty.Length <= 0 || !(empty.ToLower() != "www") || !(empty.ToLower() != "192"))
                {
                    this.Session["ConnectionString"] = "CRMConnectionString";
                    base.Response.Cookies.Add(new HttpCookie("connectionstring", "CRMConnectionString"));
                    base.Response.Cookies.Add(new HttpCookie("sitepath", "SitePath"));
                    base.Response.Cookies.Add(new HttpCookie("filepath", "FilePath"));
                }
                else
                {
                    this.Session["ConnectionString"] = empty.ToLower();
                    base.Response.Cookies.Add(new HttpCookie("connectionstring", empty.ToLower()));
                    base.Response.Cookies.Add(new HttpCookie("sitepath", string.Concat("SitePath_", empty.ToLower())));
                    base.Response.Cookies.Add(new HttpCookie("filepath", string.Concat("FilePath_", empty.ToLower())));
                }
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
            if (!base.IsPostBack)
            {
                _Default.displayVerificationImage = 1;
                _Default.isSecurity = false;
            }
            this.strpath = global.imagePath();
            this.Session["language"] = "english";
            this.div_InvalidMsg.Style.Add("display", "none");
            this.lblerror.Visible = false;
            this.email.Focus();
            this.chkremember.Value = this.objLanguage.convert("Remember me");
            this.nooflogin = 0;
            this.COMPANYID = 0;
            if (!base.IsPostBack)
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
                this.hdn_login.Value = this.email.Value.ToString();
                if (this.hdn_login.Value.Trim().Length > 0 && this.hdn_pass.Value.Trim().Length > 0)
                {
                    this.login(true);
                }
            }
        }
    }
}