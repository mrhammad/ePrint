using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.Printcenter.Views
{
    public partial class SignUp : Page
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strCompany = global.companyName();

        public languageClass objLanguage = new languageClass();

        private readonly BasePage objpage = new BasePage();

        private readonly BaseClass objclass = new BaseClass();

        private readonly commonClass cmn = new commonClass();

        private const int DefaultTimeZoneId = 115;

        private const int TrialExpireDays = 14;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyBranding();
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            HideMessages();

            if (!Page.IsValid)
            {
                ShowError("Please correct the errors below.");
                return;
            }

            string email = objclass.SpecialEncode(txtEmail.Text.Trim());
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ShowError("Passwords do not match.");
                return;
            }

            if (new checkEmail().Email(email))
            {
                ShowError("An account with this email already exists. Please sign in or use a different email.");
                return;
            }

            const string dateFormat = "dd/mm/yyyy";
            registrationClass registration = new registrationClass();
            int companyId = 0;

            try
            {
                companyId = CreateCompanyAndAdminUser(email, password, registration);
                if (companyId <= 0)
                {
                    ShowError("Registration could not be completed. This email may already be registered.");
                    return;
                }

                registration.CompleteNewCompanySetup(companyId, DefaultTimeZoneId, dateFormat);
                Response.Redirect("~/Login/Login.aspx?registered=1", false);
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("SignUp error: " + ex);

                if (companyId > 0)
                {
                    try
                    {
                        registration.RepairNewCompanySetup(companyId, DefaultTimeZoneId, dateFormat);
                        Response.Redirect("~/Login/Login.aspx?registered=1", false);
                        return;
                    }
                    catch (Exception repairEx)
                    {
                        System.Diagnostics.Trace.WriteLine("SignUp repair error: " + repairEx);
                    }
                }

                ShowError("Registration failed. If you already have an account, try signing in. Otherwise contact support.");
            }
        }

        private int CreateCompanyAndAdminUser(string email, string plainPassword, registrationClass registration)
        {
            DateTime now = DateTime.Now;
            string companyName = objclass.SpecialEncode(txtCompanyName.Text.Trim());
            string firstName = objclass.SpecialEncode(txtFirstName.Text.Trim());
            string lastName = objclass.SpecialEncode(txtLastName.Text.Trim());
            string uniqueValue = Guid.NewGuid().ToString("N");
            if (uniqueValue.Length > 50)
            {
                uniqueValue = uniqueValue.Substring(0, 50);
            }

            string country = "Australia";
            string currency = "AUD";
            string languageName = "English";
            string dateFormat = "dd/mm/yyyy";

            int newCompanyId = registration.RegisterNew(
                country,
                string.Empty,
                companyName,
                string.Empty,
                string.Empty,
                string.Empty,
                1,
                5,
                "Sign Up",
                string.Empty,
                1,
                now,
                now,
                0,
                1,
                now.AddDays(TrialExpireDays),
                languageName,
                currency,
                0,
                DefaultTimeZoneId,
                dateFormat,
                email,
                0,
                TrialExpireDays,
                uniqueValue);

            if (newCompanyId <= 0)
            {
                return 0;
            }

            string encryptedPassword = commonClass.Encrypt(objclass.SpecialEncode(plainPassword));
            registration.RegisterAdminUser(newCompanyId, email, encryptedPassword, firstName, lastName, string.Empty, DefaultTimeZoneId);

            return newCompanyId;
        }

        private void ApplyBranding()
        {
            int companyId = 0;
            try
            {
                companyId = Convert.ToInt32(System.Configuration.EprintConfigurationManager.AppSettings["CompanyID"].ToString());
            }
            catch
            {
            }

            if (companyId > 0)
            {
                BasePage.LoadAuthPageLanguageFile(companyId, Session, cmn);
                BasePage.ApplyAuthPageLoginButtonColor(companyId, Session, btnSignUp, cmn);
                objpage.ApplyAuthPageLogo(plhLoginImg, companyId);
            }
        }

        private void HideMessages()
        {
            div_InvalidMsg.Style["display"] = "none";
            lblerror.Visible = false;
            div_SuccessMsg.Visible = false;
        }

        private void ShowError(string message)
        {
            div_InvalidMsg.Style["display"] = "block";
            lblerror.Visible = true;
            lblerror.Text = message;
        }

    }
}
