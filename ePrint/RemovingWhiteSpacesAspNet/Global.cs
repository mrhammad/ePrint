using System;
using System.Web;
using System.Web.SessionState;

namespace RemovingWhiteSpacesAspNet
{
	public class Global : HttpApplication
	{
		public Global()
		{
			this.InitializeComponent();
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
		{
		}

		protected void Application_Start(object sender, EventArgs e)
		{
		}

		private void Global_PostRequestHandlerExecute(object sender, EventArgs e)
		{
		}

		private void InitializeComponent()
		{
			base.PostRequestHandlerExecute += new EventHandler(this.Global_PostRequestHandlerExecute);
		}

		protected void Session_End(object sender, EventArgs e)
		{
		}

		protected void Session_Start(object sender, EventArgs e)
		{
		}

		public void setpagename(string pagename)
		{
			HttpContext.Current.Session["pagename"] = pagename;
			HttpContext current = HttpContext.Current;
			HttpCookie item = current.Request.Cookies["SessionStarted"];
			if (item != null)
			{
				item.Value = pagename;
				return;
			}
			HttpCookie httpCookie = new HttpCookie("SessionStarted", pagename);
			current.Response.Cookies.Add(httpCookie);
		}
	}
}