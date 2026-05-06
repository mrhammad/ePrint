using nmsCommon;
using System;
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
		this.Page.Theme = "Theme5";
	}
}