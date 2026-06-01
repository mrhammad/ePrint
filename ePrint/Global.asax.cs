using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ePrint;
using System.Web.Profile;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Web.Compilation;
using System.Web.SessionState;
using nmsCommon;

namespace ePrint
{
    public class Global : HttpApplication
    {
        private static bool __initialized;
        private static bool _startupWarmComplete;

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;

            HttpRequest request = HttpContext.Current.Request;
            if (IsLegacyDefaultLoginRequest(request))
            {
                string qs = request.QueryString.ToString();
                string target = VirtualPathUtility.ToAbsolute("~/Login/Login.aspx");
                if (!string.IsNullOrEmpty(qs))
                {
                    target = string.Concat(target, "?", qs);
                }

                if (string.Equals(request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    HttpContext.Current.Response.Redirect(target, true);
                    return;
                }

                HttpContext.Current.RewritePath(target, false);
            }
        }

        private static bool IsLegacyDefaultLoginRequest(HttpRequest request)
        {
            if (request == null)
            {
                return false;
            }

            string path = request.FilePath ?? string.Empty;
            if (path.EndsWith("/default.aspx", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            string absolutePath = request.Url == null ? string.Empty : request.Url.AbsolutePath ?? string.Empty;
            string appPath = (request.ApplicationPath ?? "/").TrimEnd('/');
            if (appPath.Length == 0)
            {
                appPath = "/";
            }

            return absolutePath.Equals(appPath, StringComparison.OrdinalIgnoreCase)
                || absolutePath.Equals(string.Concat(appPath, "/"), StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsLoginPageRequest(HttpRequest request)
        {
            if (request == null)
            {
                return false;
            }

            if (request.FilePath.EndsWith("/Login/Login.aspx", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return IsLegacyDefaultLoginRequest(request);
        }

        protected void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            if (!BasePage.IsLightweightAuthPageEnabled())
            {
                return;
            }

            HttpRequest request = HttpContext.Current.Request;
            if (!string.Equals(request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (IsLoginPageRequest(request))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            try
            {
                string profileRoot = AppDomain.CurrentDomain.BaseDirectory;
                System.Runtime.ProfileOptimization.SetProfileRoot(profileRoot);
                System.Runtime.ProfileOptimization.StartProfile("eprint-startup.profile");
            }
            catch
            {
            }

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            WarmApplicationAfterCompile();
        }

        /// <summary>
        /// After rebuild/restart the first browser hit pays JIT + ASPX compile + master DB config.
        /// Run that work here so the login screen opens faster on first request.
        /// </summary>
        private static void WarmApplicationAfterCompile()
        {
            if (_startupWarmComplete)
            {
                return;
            }

            HttpContext previous = HttpContext.Current;
            try
            {
                string host = ConfigurationManager.AppSettings["HostName"];
                if (string.IsNullOrWhiteSpace(host))
                {
                    host = "localhost";
                }

                var request = new HttpRequest("", string.Concat("http://", host, "/Login/Login.aspx"), "");
                var response = new HttpResponse(new StringWriter());
                HttpContext.Current = new HttpContext(request, response);

                object companyId = System.Configuration.EprintConfigurationManager.AppSettings["CompanyID"];

                const string loginPath = "~/Login/Login.aspx";
                BuildManager.GetCompiledType(loginPath);
                BuildManager.CreateInstanceFromVirtualPath(loginPath, typeof(System.Web.UI.Page));

                _startupWarmComplete = true;
            }
            catch
            {
            }
            finally
            {
                HttpContext.Current = previous;
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }		

		protected DefaultProfile Profile
		{
			get
			{
				return (DefaultProfile)base.Context.Profile;
			}
		}

        public void setpagename(string page)
        {
            HttpContext.Current.Session["pagename"] = page;
        }

        //public void setpagename(string pagename)
        //{
        //    this.Session["pagename"] = pagename;

        //}

		[DebuggerNonUserCode]
        public Global()
		{
			if (!Global.__initialized)
			{
                Global.__initialized = true;
			}
		}
    }
}
