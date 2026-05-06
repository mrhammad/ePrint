using System;
using System.Collections.Generic;
using System.Linq;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using Printcenter.UI.CMS;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class cms : BaseClass, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_cms;

        //protected PlaceHolder plhLeftBanner;

        //protected Label lbl_csm_heading;

        //protected PlaceHolder ph_csm_content;

        //protected PlaceHolder plhRightBanner;

        public int companyID;

        public int accountID;

        public int pageID;

        public int cnt_left;

        public int cnt_right;

        public char KeySeparator;

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string strSitePath = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        private commonclass comm = new commonclass();

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

        public cms()
        {
        }

        public void emailWrongCMSURL(string Body)
        {
            EmailClass.SendMailMessage("", "gajendra.singh@infomazeapps.com", "", "", "Wrong CMS page url", Body, "", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitePath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.accountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["ID"] != null)
                {
                    this.pageID = Convert.ToInt32(base.Request.Params["ID"]);
                }
            }
            else if (RewriteContext.Current.Params["ID"] != null)
            {
                string str = RewriteContext.Current.Params["ID"].ToString();
                char[] keySeparator = new char[] { this.KeySeparator };
                if ((int)str.Split(keySeparator).Length <= 1)
                {
                    base.Response.Redirect(this.strSitePath);
                }
                else
                {
                    try
                    {
                        string str1 = RewriteContext.Current.Params["ID"].ToString();
                        char[] chrArray = new char[] { this.KeySeparator };
                        this.pageID = Convert.ToInt32(str1.Split(chrArray)[1]);
                    }
                    catch
                    {
                        try
                        {
                            string str2 = string.Concat("RURL: ", base.Request.UrlReferrer.PathAndQuery.ToString(), " <br/><br/>URL: ", base.Request.Url.ToString());
                            this.emailWrongCMSURL(str2);
                            base.Response.Redirect(this.strSitePath);
                        }
                        catch
                        {
                            string str3 = string.Concat("Referal Url not found, URL: ", base.Request.Url.ToString());
                            this.emailWrongCMSURL(str3);
                            base.Response.Redirect(this.strSitePath);
                        }
                    }
                }
            }
            this.lbl_cms.Text = ConnectionClass.PageName(this.companyID, Convert.ToInt32(this.accountID), this.pageID);
            this.lbl_cms.Text = base.SpecialDecode(this.lbl_cms.Text);
            base.Title = commonclass.pageTitle(this.lbl_cms.Text, Convert.ToInt32(this.companyID), Convert.ToInt32(this.accountID));
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.IsHomePageVisible != "1")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.companyID), Convert.ToInt32(this.accountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            this.AccountType = this.comm.return_AccountType((long)this.companyID, (long)this.accountID);
            if (this.Session["StoreUserID"] == null && this.AccountType == "p")
            {
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitePath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitePath, "login", ConnectionClass.FileExtension));
                }
            }
            HtmlMeta htmlMetum = new HtmlMeta();
            HtmlMeta htmlMetum1 = new HtmlMeta();
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable = CMSBasePage.CMSPages_get(this.companyID, this.accountID, this.pageID);
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)base.Master.FindControl("head");
            foreach (DataRow row in dataTable.Rows)
            {
                this.lbl_csm_heading.Text = base.SpecialDecode(row["pageName"].ToString().Trim());
                htmlMetum.Name = "Keywords";
                htmlMetum.Content = row["metaKeywords"].ToString().Trim();
                contentPlaceHolder.Controls.Add(htmlMetum);
                htmlMetum1.Name = "Description";
                htmlMetum1.Content = row["metaDescription"].ToString().Trim();
                contentPlaceHolder.Controls.Add(htmlMetum1);
                Label label = new Label()
                {
                    Text = row["pageBody"].ToString().Trim()
                };
                this.ph_csm_content.Controls.Add(new LiteralControl("<div id='csm_content' class='csm_content'>"));
                this.ph_csm_content.Controls.Add(label);
                this.ph_csm_content.Controls.Add(new LiteralControl("</div>"));
            }
            int num = 0;
            DataTable dataTable1 = CMSBasePage.Select_BannerImages((long)this.accountID, this.pageID, "L", "");
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (num == 0)
                {
                    this.plhLeftBanner.Controls.Add(new LiteralControl("<div class='cms_Panel'>"));
                }
                object[] item = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", dataRow["bannerImage"], "&amp;type=b&amp;aid=", this.accountID, "&amp;cid=", this.companyID };
                string str4 = string.Concat(item);
                if (dataRow["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhLeftBanner.Controls;
                    object[] objArray = new object[] { "<div><img src='", str4, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhLeftBanner.Controls;
                    object[] item1 = new object[] { "<div><a href='", dataRow["URL"], "'><img src='", str4, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item1)));
                }
                num++;
                cms cntLeft = this;
                cntLeft.cnt_left = cntLeft.cnt_left + 1;
            }
            if (num != 0)
            {
                this.plhLeftBanner.Controls.Add(new LiteralControl("</div>"));
            }
            int num1 = 0;
            DataTable dataTable2 = CMSBasePage.Select_BannerImages((long)this.accountID, this.pageID, "R", "");
            foreach (DataRow row1 in dataTable2.Rows)
            {
                if (num1 == 0)
                {
                    this.plhRightBanner.Controls.Add(new LiteralControl("<div class='cms_Panel'>"));
                }
                object[] objArray1 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", row1["bannerImage"], "&amp;type=b&amp;aid=", this.accountID, "&amp;cid=", this.companyID };
                string str5 = string.Concat(objArray1);
                if (row1["URL"].ToString() == "")
                {
                    ControlCollection controls1 = this.plhRightBanner.Controls;
                    object[] item2 = new object[] { "<div><img src='", str5, "' class='imgWidth' alt='", row1["bannerTitle"], "' /></div>" };
                    controls1.Add(new LiteralControl(string.Concat(item2)));
                }
                else
                {
                    ControlCollection controlCollections1 = this.plhRightBanner.Controls;
                    object[] objArray2 = new object[] { "<div><a href='", row1["URL"], "'><img src='", str5, "' class='imgWidth' alt='", row1["bannerTitle"], "' /></a></div>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray2)));
                }
                num1++;
                cms cntRight = this;
                cntRight.cnt_right = cntRight.cnt_right + 1;
            }
            if (num1 != 0)
            {
                this.plhRightBanner.Controls.Add(new LiteralControl("</div>"));
            }
        }
    }
}