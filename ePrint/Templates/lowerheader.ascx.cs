using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.Templates
{
    public partial class lowerheader : System.Web.UI.UserControl
    {
     
    //protected Label lblsitepath;

    //protected LinkButton lnkHome;

    //protected Label lblHome;

    //protected LinkButton lnkSection;

    //protected Label lblSection;

    //protected LinkButton lnkSubsection;

    //protected Label lnkTask;

    //protected Label lblsubscription;

    //protected Label lblgoto;

    //protected Label lblUserName;

	public string strSitepath = global.sitePath();

	public languageClass objLanguage = new languageClass();

	public BaseClass objBase = new BaseClass();

	public string tabcolor = "";

	public string forecolor = "";

	public int companyid;

	public BasePage objpage = new BasePage();

	public languageClass objLangClass = new languageClass();

	public string VersionNumber = ConnectionClass.VersionNumber;

	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}

	public lowerheader()
	{
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		string empty;
		ListItem listItem = new ListItem();
		this.companyid = int.Parse(base.Session["companyID"].ToString());
		if (base.Session["email"] == null)
		{
			base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
		}
		Label label = this.lblgoto;
		string[] languageConversion = new string[] { "<span style='color:White;'>&nbsp;", this.objLangClass.GetLanguageConversion("Logged_In_As"), "&nbsp;<b>", this.objBase.SpecialDecode(base.Session["firstName"].ToString()), "</b>&nbsp;", this.objBase.SpecialDecode(base.Session["lastName"].ToString()), " (<i>", this.objBase.SpecialDecode(base.Session["companyname"].ToString().Trim()), "</i>)&nbsp;v", this.VersionNumber, " </span>" };
		label.Text = string.Concat(languageConversion);
		try
		{
			if ((int)base.Session["iscorporateright"] == 1 || (int)base.Session["admin"] == 1)
			{
				//this.lblsubscription.Visible = true;
				//Label label1 = this.lblsubscription;
				//object[] str = new object[] { base.Session["noofdaysremaining"].ToString(), this.objLanguage.convert("Days"), this.objLanguage.convert("trial left, subscribe now"), global.sitePath(), global.imagePath() };
				//label1.Text = string.Format("<font color=red>{0} {1}</font> {2} <a class=headertext href={3}admin/subscribe.aspx><img alt=Subscription src={4}subscribe.gif border=0 style=vertical-align:middle /></a>&nbsp;|", str);
			}
		}
		catch
		{
		}
		this.tabcolor = this.objpage.colorCode(this.companyid, global.pageName);
		this.forecolor = this.objpage.Forecolor(this.companyid, global.pageName);
		if (!base.IsPostBack)
		{
			empty = string.Empty;
			try
			{
				
                string lower = string.IsNullOrEmpty(global.pageName)?"": global.pageName.ToLower();
				string str1 = lower;
				if (lower != null)
				{
					switch (str1)
					{
						case "welcome":
						{
							empty = "HOME";
							break;
						}
						case "lead":
						{
							empty = "LEADS";
							break;
						}
						case "client":
						{
							empty = "CLIENTS";
							break;
						}
						case "contact":
						{
							empty = "CONTACTS";
							break;
						}
						case "contract":
						{
							empty = "CONTRACTS";
							break;
						}
						case "product":
						{
							empty = "PRODUCTS";
							break;
						}
						case "asset":
						{
							empty = "ASSETS";
							break;
						}
						case "opportunity":
						{
							empty = "OPPORTUNITIES";
							break;
						}
						case "ticket":
						{
							empty = "TICKETS";
							break;
						}
						case "solution":
						{
							empty = "SOLUTIONS";
							break;
						}
						case "campaign":
						{
							empty = "CAMPAIGN";
							break;
						}
						case "document":
						{
							empty = "DOCUMENTS";
							break;
						}
						case "forecast":
						{
							empty = "FORECAST";
							break;
						}
						case "report":
						{
							empty = "REPORTS";
							break;
						}
						case "dashboard":
						{
							empty = "DASHBOARD";
							break;
						}
						case "estimate":
						{
							empty = "ESTIMATES";
							break;
						}
						case "jobs":
						{
							empty = "JOBS";
							break;
						}
						case "purchase":
						{
							empty = "PURCHASES";
							break;
						}
						case "deliverynote":
						{
							empty = "DELIVERYNOTE";
							break;
						}
						case "invoice":
						{
							empty = "INVOICES";
							break;
						}
						case "setting":
						{
							empty = "SETTINGS";
							break;
						}
						default:
						{
							goto Label0;
						}
					}
				}
				else
				{
					goto Label0;
				}
			}
			catch
			{
			}
		Label2:
			DataTable dataTable = new DataTable();
			string empty1 = string.Empty;
			BasePage basePage = new BasePage();
			DataSet header = basePage.GetHeader(Convert.ToInt32(base.Session["companyID"]), Convert.ToInt32(base.Session["userID"]), empty, ref dataTable, ref empty1, (int)base.Session["admin"]);
			(new ListItem("Quick view", "QUICK VIEW")).Attributes.Add("style", "background-color:#CCCCCC");
			int num = 1;
			foreach (DataRow row in header.Tables[0].Rows)
			{
				BaseClass baseClass = new BaseClass();
				object[] itemArray = row.ItemArray;
				listItem = new ListItem(string.Concat(baseClass.Padding, baseClass.ReturnScreenName(itemArray[1].ToString(), 2, "p")), itemArray[1].ToString());
				string lower1 = itemArray[1].ToString().ToLower();
				string str2 = lower1;
				if (lower1 != null)
				{
					switch (str2)
					{
						case "home":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "home");
							this.forecolor = this.objpage.Forecolor(this.companyid, "home");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "leads":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "lead");
							this.forecolor = this.objpage.Forecolor(this.companyid, "lead");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "clients":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "client");
							this.forecolor = this.objpage.Forecolor(this.companyid, "client");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "contacts":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "contact");
							this.forecolor = this.objpage.Forecolor(this.companyid, "contact");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "contracts":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "contract");
							this.forecolor = this.objpage.Forecolor(this.companyid, "contract");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "product":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "product");
							this.forecolor = this.objpage.Forecolor(this.companyid, "product");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							break;
						}
						case "asset":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "asset");
							this.forecolor = this.objpage.Forecolor(this.companyid, "asset");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "opportunities":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "opportunity");
							this.forecolor = this.objpage.Forecolor(this.companyid, "opportunity");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "tickets":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "ticket");
							this.forecolor = this.objpage.Forecolor(this.companyid, "ticket");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "solutions":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "solution");
							this.forecolor = this.objpage.Forecolor(this.companyid, "solution");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "campaign":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "campaign");
							this.forecolor = this.objpage.Forecolor(this.companyid, "campaign");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "documents":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "document");
							this.forecolor = this.objpage.Forecolor(this.companyid, "document");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "forecast":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "forecast");
							this.forecolor = this.objpage.Forecolor(this.companyid, "forecast");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "reports":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "report");
							this.forecolor = this.objpage.Forecolor(this.companyid, "report");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "dashboard":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "dashboard");
							this.forecolor = this.objpage.Forecolor(this.companyid, "dashboard");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "estimates":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "estimate");
							this.forecolor = this.objpage.Forecolor(this.companyid, "estimate");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "jobs":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "job");
							this.forecolor = this.objpage.Forecolor(this.companyid, "job");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "purchases":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "purchase");
							this.forecolor = this.objpage.Forecolor(this.companyid, "purchase");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "deliverynote":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "deliverynote");
							this.forecolor = this.objpage.Forecolor(this.companyid, "deliverynote");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "invoices":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "invoice");
							this.forecolor = this.objpage.Forecolor(this.companyid, "invoice");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						case "settings":
						{
							this.tabcolor = this.objpage.colorCode(this.companyid, "setting");
							this.forecolor = this.objpage.Forecolor(this.companyid, "setting");
							listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
							listItem.Attributes.CssStyle.Add("color", this.forecolor);
							break;
						}
						default:
						{
							goto Label1;
						}
					}
				}
				else
				{
					goto Label1;
				}
			Label3:
				num++;
			}
		}
		Label label2 = this.lblUserName;
		string[] strArrays = new string[] { "<a style='color:White' href='", global.sitePath(), "logout.aspx'><b>", this.objLangClass.GetLanguageConversion("Logout"), "&nbsp;</b></a>" };
		label2.Text = string.Concat(strArrays);
		return;
	Label0:
		empty = "SELECT MODULE";
		goto Label11;
    Label11:
        var s = "";
	Label1:
		this.tabcolor = this.objpage.colorCode(this.companyid, "home");
		this.forecolor = this.objpage.Forecolor(this.companyid, "home");
		listItem.Attributes.CssStyle.Add("background-color", this.tabcolor);
		listItem.Attributes.CssStyle.Add("color", this.forecolor);
		goto Label33;
    Label33:
        var ss = "";
	}
    
    }
}