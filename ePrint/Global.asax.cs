using System;
using System.Collections.Generic;
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

namespace ePrint
{
    public class Global : HttpApplication
    {
        private static bool __initialized;

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
