using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Templates
{
    public partial class Supplier : System.Web.UI.MasterPage
    {
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

	public Supplier()
	{
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
	}
    }
}