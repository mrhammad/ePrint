using nmsCommon;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.Estimates
{
    public partial class estimate_summary_reeng : BaseClass, IRequiresSessionState
    {
    
    //protected usercontrol_item_item_summary_main_ascx UCItemSummaryMain;

	private Global gloobj = new Global();

	private BaseClass objBC = new BaseClass();

	public string strSitepath = global.sitePath();

	public string strImagepath = global.imagePath();

	public int CompanyID;

	public int UserID;

	public string pg = string.Empty;

	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}

    public estimate_summary_reeng()
	{
	}

	protected void Page_Load(object sender, EventArgs e)
	{
        this.objBC.ReturnRoles_Privileges_Tabs("estimates", "isview", "");
        global.pageName = "estimate";
        this.pg = "estimate";
        this.gloobj.setpagename("estimate");
        this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
        this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
        languageClass _languageClass = new languageClass();
        string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Estimate_View"), "</a>" };
        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Estimate_Summary")));
        base.Title = _languageClass.convert(global.pageTitle("Estimate Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
	}
    }
}