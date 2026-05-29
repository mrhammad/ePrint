using nmsCommon;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

public class HelpClass : System.Web.UI.Page
{
	public string strHelpPath = string.Empty;

	public string strHelpImgPath = string.Empty;

	public HelpClass()
	{
		this.strHelpPath = global.sitePath();
		this.strHelpImgPath = string.Concat(this.strHelpPath, "Images5/");
	}

	protected override void OnPreInit(EventArgs e)
	{
		string enableRuntimeTheme = ConfigurationManager.AppSettings["EnableRuntimePageTheme"];
		if (string.Equals(enableRuntimeTheme, "true", StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				this.Page.Theme = "Theme5";
			}
			catch (HttpException)
			{
				// Some pages include inline <% %> code blocks; skip runtime theme assignment.
			}
		}
		base.OnPreInit(e);
	}
}