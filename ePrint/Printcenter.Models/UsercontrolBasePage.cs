using System;
using System.Web.UI;

public class UsercontrolBasePage : UserControl
{
	private static int _showing;

	private static int _showingTommorow;

	public BaseClass objBase = new BaseClass();

	private string _BaseSection = string.Empty;

	public string BaseSection
	{
		get
		{
			return this._BaseSection;
		}
		set
		{
			this._BaseSection = value;
		}
	}

	public static int showing
	{
		get
		{
			return UsercontrolBasePage._showing;
		}
		set
		{
			UsercontrolBasePage._showing = value;
		}
	}

	public static int showingTommorow
	{
		get
		{
			return UsercontrolBasePage._showingTommorow;
		}
		set
		{
			UsercontrolBasePage._showingTommorow = value;
		}
	}

	static UsercontrolBasePage()
	{
	}

	public UsercontrolBasePage()
	{
		this.objBase.Session_Check();
	}
}