using nmsCommon;
using nmsConnection;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class sitemap : System.Web.UI.Page, IRequiresSessionState
    {
        //protected PlaceHolder phSiteMap;

        public long AccountID;

        public int CompanyID;

        public string strSitePath = string.Empty;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string AccountType = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public char KeySeparator;

        private BaseClass objbAse = new BaseClass();

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public sitemap()
        {
        }

        public void BindAll(long ID, int CompanyID, long AccountID)
        {
            DataSet siteMapData = LoginBasePage.GetSiteMapData(ID, CompanyID, AccountID);
            this.phSiteMap.Controls.Add(new LiteralControl("<ul class='paddingLeft20'>"));
            foreach (DataRow row in siteMapData.Tables[0].Rows)
            {
                this.phSiteMap.Controls.Add(new LiteralControl("<li class='paddingLeft10'>"));
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (row["PorC"].ToString().Trim().ToLower() != "p")
                    {
                        ControlCollection controls = this.phSiteMap.Controls;
                        string[] strArrays = new string[] { "<a class='cursorPointer' href='", null, null, null, null };
                        string[] keySeparator = new string[] { this.strSitePath, "products", ConnectionClass.KeySeparator, row["ID"].ToString(), ConnectionClass.FileExtension };
                        strArrays[1] = base.ResolveUrl(string.Concat(keySeparator));
                        strArrays[2] = "'>";
                        strArrays[3] = this.objbAse.SpecialDecode(row["Name"].ToString());
                        strArrays[4] = "</a>";
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.phSiteMap.Controls;
                        string[] strArrays1 = new string[] { "<a class='cursorPointer' onclick='Onclick_Product(", row["ID"].ToString().Trim(), ", \"", row["Name"].ToString(), "\")'>", this.objbAse.SpecialDecode(row["Name"].ToString()), "</a>" };
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                }
                else if (row["PorC"].ToString().Trim().ToLower() != "p")
                {
                    ControlCollection controls1 = this.phSiteMap.Controls;
                    string[] str = new string[] { "<a class='cursorPointer' href='", this.strSitePath, "products/product.aspx?ID=", row["ID"].ToString(), "'> ", row["Name"].ToString(), "</a>" };
                    controls1.Add(new LiteralControl(string.Concat(str)));
                }
                else
                {
                    ControlCollection controlCollections1 = this.phSiteMap.Controls;
                    string[] strArrays2 = new string[] { "<a class='cursorPointer' onclick='Onclick_Product(", row["ID"].ToString().Trim(), ",\"", row["Name"].ToString(), "\")'>", row["Name"].ToString(), "</a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                if (row["PorC"].ToString().Trim().ToLower() == "c")
                {
                    this.BindAll(Convert.ToInt64(row["CategoryID"]), CompanyID, AccountID);
                }
                this.phSiteMap.Controls.Add(new LiteralControl("</li>"));
            }
            this.phSiteMap.Controls.Add(new LiteralControl("</ul>"));
        }

        public void BindNavigationPage(long ID, int CompanyID, long AccountID)
        {
            DataSet siteMapData = LoginBasePage.GetSiteMapData(ID, CompanyID, AccountID);
            foreach (DataRow row in siteMapData.Tables[0].Rows)
            {
                this.phSiteMap.Controls.Add(new LiteralControl("<ul>"));
                this.phSiteMap.Controls.Add(new LiteralControl("<li>"));
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (row["systemName"].ToString().Trim().ToLower() == "products")
                    {
                        this.phSiteMap.Controls.Add(new LiteralControl(string.Concat("<a href='#' class='cursorPointer' onclick='Onclick_Productnew();'> ", this.objbAse.SpecialDecode(row["Name"].ToString()), "</a>")));
                        this.BindAll((long)0, CompanyID, AccountID);
                    }
                    else if (row["systemName"].ToString().Trim().ToLower() == "home")
                    {
                        ControlCollection controls = this.phSiteMap.Controls;
                        string[] strArrays = new string[] { "<a class='cursorPointer' href='", base.ResolveUrl(this.strSitePath), "'> ", this.objbAse.SpecialDecode(row["Name"].ToString()), "</a>" };
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    else if (row["systemName"].ToString().Trim().ToLower() != "sitemap" && this.AccountType == "x")
                    {
                        ControlCollection controlCollections = this.phSiteMap.Controls;
                        string[] strArrays1 = new string[] { "<a href='", null, null, null, null };
                        object[] objArray = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), "/", ConnectionClass.RemoveIllegalChars(row["name"].ToString()), ConnectionClass.KeySeparator, Convert.ToInt32(row["PageID"].ToString()), ConnectionClass.FileExtension };
                        strArrays1[1] = base.ResolveUrl(string.Concat(objArray));
                        strArrays1[2] = "'> ";
                        strArrays1[3] = row["Name"].ToString().Trim();
                        strArrays1[4] = " </a>";
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                }
                else if (row["systemName"].ToString().Trim().ToLower() == "products")
                {
                    this.phSiteMap.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", this.objbAse.SpecialDecode(row["Name"].ToString().Trim()), " </a>")));
                    this.BindAll((long)0, CompanyID, AccountID);
                }
                else if (row["systemName"].ToString().Trim().ToLower() == "home")
                {
                    ControlCollection controls1 = this.phSiteMap.Controls;
                    string[] strArrays2 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "'> ", this.objbAse.SpecialDecode(row["Name"].ToString()), "</a>" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                else if (row["systemName"].ToString().Trim().ToLower() != "sitemap" && this.AccountType == "x")
                {
                    ControlCollection controlCollections1 = this.phSiteMap.Controls;
                    object[] num = new object[] { "<a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row["PageID"].ToString()), "'> ", this.objbAse.SpecialDecode(row["Name"].ToString().Trim().Trim()), "</a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(num)));
                }
                this.phSiteMap.Controls.Add(new LiteralControl("</li>"));
                this.phSiteMap.Controls.Add(new LiteralControl("</ul>"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EprintConfigurationManager.AppSettings["AccountType"].ToString().ToLower() != "private")
            {
                this.AccountType = "x";
            }
            else
            {
                this.AccountType = "p";
            }
            if (ConnectionClass.SitePath == null)
            {
                this.strSitePath = "";
            }
            else
            {
                this.strSitePath = ConnectionClass.SitePath.ToString();
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator.ToString());
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Sitemap", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            if (this.Rewritemodule.ToLower() == "on" && this.AccountType != "x")
            {
                base.Response.Redirect(this.strSitePath);
            }
            this.BindNavigationPage((long)-3, this.CompanyID, this.AccountID);
        }
    }
}