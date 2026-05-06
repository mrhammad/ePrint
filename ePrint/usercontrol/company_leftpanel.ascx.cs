using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol
{
    public partial class company_leftpanel : UserControl
    {
        //protected HtmlGenericControl div_copmpany_open;

        //protected HtmlGenericControl div_copmpany_close;

        //protected HtmlGenericControl Accouts_View;

        //protected HtmlGenericControl createAccount;

        //protected HtmlGenericControl addNewView;

        //protected HtmlGenericControl editView;

        //protected LinkButton lnKAddCustomer;

        //protected LinkButton lnKViewCustomer;

        //protected HtmlGenericControl li_Customers;

        //protected LinkButton lnKAddSupplier;

        //protected LinkButton lnKViewSupplier;

        //protected HtmlGenericControl li_Suppliers;

        //protected LinkButton lnKAddProspect;

        //protected LinkButton lnKViewProspect;

        //protected HtmlGenericControl li_Prospects;

        //protected LinkButton LnkViewContacts;

        //protected HtmlGenericControl licontactview;

        //protected HtmlGenericControl liaddview;

        //protected HtmlGenericControl lieditview;

        //protected LinkButton lnkCRMReports;

        //protected HtmlGenericControl report;

        //protected HtmlGenericControl div_copmpany_contents1;

        //protected Panel pnlcompany;

        //protected HtmlGenericControl div_home_open;

        //protected HtmlGenericControl div_home_close;

        //protected HtmlGenericControl lihome;

        //protected HtmlGenericControl litask;

        //protected HtmlGenericControl lievent;

        //protected HtmlGenericControl div_home_contents1;

        //protected Panel pnlhome;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int height = 85;

        public string Path = string.Empty;

        public string editPath = string.Empty;

        public int companyid;

        public string web_key = string.Empty;

        public languageClass objLanguage = new languageClass();

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

        public company_leftpanel()
        {
        }

        protected void lnkAddCustomer_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_add.aspx?type=Customer"));
        }

        protected void lnKAddProspect_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_add.aspx?type=Prospect"));
        }

        protected void lnKAddSupplier_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_add.aspx?type=Supplier"));
        }

        protected void lnkCRMReports_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Reports("crm", "showreport", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_report.aspx"));
        }

        protected void LnkViewContacts_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "contact/contact_view.aspx"));
        }

        protected void lnKViewCustomer_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_view.aspx?type=Customer"));
        }

        protected void lnKViewProspect_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_view.aspx?type=Prospect"));
        }

        protected void lnKViewSupplier_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "client/client_view.aspx?type=Supplier"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (ConnectionClass.WebStore != null)
            {
                this.web_key = ConnectionClass.WebStore;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Url.ToString().ToLower().Contains("/client") || base.Request.Url.ToString().ToLower().Contains("common/email_send.aspx") || base.Request.Url.ToString().ToLower().Contains("common/email_viewall.aspx") || base.Request.Url.ToString().ToLower().Contains("/accounts"))
                {
                    this.pnlcompany.Visible = true;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("common/attachment_viewall.aspx"))
                {
                    if (base.Request.Url.ToString().ToLower().Contains("common/attachment_viewall.aspx?sectionname=client"))
                    {
                        this.pnlcompany.Visible = true;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_view.aspx"))
                {
                    this.pnlcompany.Visible = true;
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_add_main.aspx"))
                {
                    this.pnlcompany.Visible = true;
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_viewdetail.aspx"))
                {
                    this.pnlcompany.Visible = true;
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                }
                else if (base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx") && !base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx?type="))
                {
                    this.liaddview.Visible = true;
                    if (EstimateBasePage.estimates_customview_count(Convert.ToInt32(base.Session["CompanyID"].ToString()), "customer") > 0)
                    {
                        this.lieditview.Visible = true;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("/welcome") || base.Request.Url.ToString().ToLower().Contains("/common/event") || base.Request.Url.ToString().ToLower().Contains("/common/task"))
                {
                    this.pnlhome.Visible = true;
                }
                else
                {
                    this.pnlcompany.Visible = false;
                    this.pnlhome.Visible = false;
                }
                if (base.Request.Url.ToString().ToLower().Contains("contact/contact_add_main.aspx"))
                {
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                }
                if (base.Request.Url.ToString().ToLower().Trim().Contains("accounts/accounts_view.aspx?type=customer") || base.Request.Url.ToString().ToLower().Trim().Contains("accounts/accounts_view.aspx"))
                {
                    this.pnlcompany.Visible = true;
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                    this.createAccount.Visible = true;
                    this.editView.Visible = true;
                    this.addNewView.Visible = true;
                }
                if (base.Request.Url.ToString().ToLower().Trim().Contains("accounts/accounts_new_create.aspx?type=customer") || base.Request.Url.ToString().ToLower().Trim().Contains("accounts/accounts_details.aspx?type=customer") || base.Request.Url.ToString().ToLower().Trim().Contains("accounts/accounts_edit_view.aspx"))
                {
                    this.pnlcompany.Visible = true;
                    this.liaddview.Visible = false;
                    this.lieditview.Visible = false;
                    this.createAccount.Visible = false;
                    this.editView.Visible = false;
                    this.addNewView.Visible = false;
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx?type=customer"))
                {
                    this.Path = "?pgtype=customer";
                    this.liaddview.Visible = true;
                    if (EstimateBasePage.estimates_customview_count(Convert.ToInt32(base.Session["CompanyID"].ToString()), "customer") > 0)
                    {
                        this.lieditview.Visible = true;
                        return;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx") && !base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx?type="))
                {
                    this.liaddview.Visible = true;
                    if (EstimateBasePage.estimates_customview_count(Convert.ToInt32(base.Session["CompanyID"].ToString()), "customer") > 0)
                    {
                        this.lieditview.Visible = true;
                        return;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx?type=supplier"))
                {
                    this.Path = "?pgtype=supplier";
                    this.liaddview.Visible = true;
                    if (EstimateBasePage.estimates_customview_count(Convert.ToInt32(base.Session["CompanyID"].ToString()), "supplier") > 0)
                    {
                        this.lieditview.Visible = true;
                        return;
                    }
                }
                else if (!base.Request.Url.ToString().ToLower().Trim().Contains("client/client_view.aspx?type=prospect"))
                {
                    if (base.Request.Url.ToString().ToLower().Trim().Contains("client/customviewcrm.aspx"))
                    {
                        this.liaddview.Visible = false;
                        this.lieditview.Visible = false;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("client/client_add.aspx"))
                    {
                        this.liaddview.Visible = false;
                        this.lieditview.Visible = false;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("client/client_detail_new.aspx"))
                    {
                        this.liaddview.Visible = false;
                        this.lieditview.Visible = false;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("client/client_edit.aspx"))
                    {
                        this.height = 110;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("common/task"))
                    {
                        this.litask.Visible = false;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("common/event"))
                    {
                        this.lievent.Visible = false;
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("welcome"))
                    {
                        this.lihome.Visible = false;
                    }
                }
                else
                {
                    this.Path = "?pgtype=prospect";
                    this.liaddview.Visible = true;
                    if (EstimateBasePage.estimates_customview_count(Convert.ToInt32(base.Session["CompanyID"].ToString()), "prospect") > 0)
                    {
                        this.lieditview.Visible = true;
                        return;
                    }
                }
            }
        }
    }
}