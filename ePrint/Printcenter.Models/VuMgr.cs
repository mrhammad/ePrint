using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;

public class VuMgr
{
	public VuMgr()
	{
	}

	public static string RenderView(string path, object data)
	{
		Page page = new Page();
		UserControl userControl = (UserControl)page.LoadControl(path);
		userControl.GetType().GetField("data").SetValue(userControl, data);
		page.Controls.Add(userControl);
		StringWriter stringWriter = new StringWriter();
		HttpContext.Current.Server.Execute(page, stringWriter, false);
	return stringWriter.ToString();
	}
}