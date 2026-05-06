using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.products
{
    public partial class edit_template : BaseClass, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_nav_catagoty;

        //protected Label lbl_nav_product;

        //protected Label lbl_nav_productName;

        //protected HtmlGenericControl navigation_div;

        //protected Button btnExpand;

        //protected HtmlGenericControl div_expandBtn;

        //protected HtmlIframe Iframe1;

        //protected HtmlGenericControl editableProduct_div1;

        private commonclass comm = new commonclass();

        public int CartItemID;

        public int StoreUserID;

        public int PriceCatalogueID;

        public int PriceCatalogueCategoryID;

        public int CompanyID;

        public char KeySeparator;

        public string AccountType = string.Empty;

        public static long AccountID;

        public string strSitepath = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

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

        static edit_template()
        {
        }

        public edit_template()
        {
        }

        protected void Expand_OnClick(object sender, EventArgs e)
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!base.Request.QueryString.ToString().Contains("type"))
            {
                base.Response.Redirect(string.Concat(absoluteUri, "?type=exp"));
                return;
            }
            absoluteUri = absoluteUri.Remove(absoluteUri.Length - 3);
            if (base.Request.QueryString["type"].ToString() == "exp")
            {
                base.Response.Redirect(string.Concat(absoluteUri, "col"));
                return;
            }
            base.Response.Redirect(string.Concat(absoluteUri, "exp"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.StoreUserID = Convert.ToInt16(this.Session["StoreUserID"]);
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                edit_template.AccountID = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            base.Title = commonclass.pageTitle("Edit Product", Convert.ToInt32(this.CompanyID), Convert.ToInt32(edit_template.AccountID));
            this.AccountType = this.comm.return_AccountType((long)this.CompanyID, edit_template.AccountID);
            if (this.Session["StoreUserID"] != null)
            {
                if (this.comm.GetDisplayValue("IsHome", edit_template.AccountID) != "true")
                {
                    this.lbl_home.Visible = false;
                    this.lbl_spliter.Visible = false;
                }
                else
                {
                    this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(edit_template.AccountID), 0);
                    this.lbl_home.Visible = true;
                    this.lbl_spliter.Visible = true;
                }
            }
            else if (this.AccountType != "x")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else if (this.comm.GetDisplayValue("IsHome", edit_template.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(edit_template.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.Session["StoreUserID"] == null && this.AccountType.ToLower() == "p" || this.CompanyID == 0 && edit_template.AccountID == (long)0)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                }
            }
            if (!base.IsPostBack)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    if (base.Request.Params["CartItemID"] != null)
                    {
                        this.CartItemID = Convert.ToInt32(base.Request.Params["CartItemID"]);
                    }
                    if (base.Request.Params["ID"] != null)
                    {
                        this.PriceCatalogueID = Convert.ToInt32(base.Request.Params["ID"]);
                    }
                }
                else
                {
                    if (RewriteContext.Current.Params["CartItemID"] != null)
                    {
                        string str = RewriteContext.Current.Params["CartItemID"].ToString();
                        char[] keySeparator = new char[] { this.KeySeparator };
                        this.CartItemID = Convert.ToInt32(str.Split(keySeparator)[1]);
                    }
                    if (RewriteContext.Current.Params["ID"] != null)
                    {
                        this.PriceCatalogueID = Convert.ToInt32(RewriteContext.Current.Params["ID"].ToString());
                    }
                }
            }
            foreach (DataRow row in ProductBasePage.productsDetails_Select(this.PriceCatalogueID).Rows)
            {
                this.lbl_nav_productName.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                this.PriceCatalogueCategoryID = Convert.ToInt32(row["PriceCatalogueCategoryID"].ToString());
                this.lbl_nav_product.Text = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
            }
            string empty = string.Empty;
            if (!base.IsPostBack)
            {
                try
                {
                    string str1 = ProductBasePage.DBKeyForTemplate_Select(edit_template.AccountID);
                    if (str1.Length <= 0)
                    {
                        SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
                        sqlConnection.Open();
                        DataTable dataTable = new DataTable();
                        SqlCommand sqlCommand = new SqlCommand("PC_Xero_ConnectKey_Select")
                        {
                            Connection = sqlConnection,
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
                        sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
                        empty = (string)sqlCommand.ExecuteScalar();
                        sqlConnection.Close();
                    }
                    else
                    {
                        empty = str1;
                    }
                }
                catch
                {
                }
            }
            DataSet dataSet = CartBasePage.Select_TemplateID((long)this.PriceCatalogueID);
            if (dataSet.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(ConnectionClass.FrontEndTemplate))
            {
                long num = Convert.ToInt64(dataSet.Tables[0].Rows[0]["TemplateID"].ToString());
                if (base.Request.QueryString["type"] == null)
                {
                    object[] sessionID = new object[] { "tid=", num, "&SessionID=", this.Session.SessionID, "&companyid=", this.CompanyID, "&CartItemID=", this.CartItemID, "&ID=", this.PriceCatalogueID, "&StoreUserID=", this.StoreUserID, "&dbkey=", empty, "&ctype=public&AccountID=", edit_template.AccountID };
                    string str2 = Encryption.Encrypt(string.Concat(sessionID));
                    this.Iframe1.Attributes["src"] = string.Concat(ConnectionClass.FrontEndTemplate, "editabletemplate.aspx?", str2);
                    return;
                }
                if (base.Request.QueryString["type"].ToString() == "exp")
                {
                    object[] objArray = new object[] { "tid=", num, "&SessionID=", this.Session.SessionID, "&companyid=", this.CompanyID, "&CartItemID=", this.CartItemID, "&ID=", this.PriceCatalogueID, "&StoreUserID=", this.StoreUserID, "&dbkey=", empty, "&ctype=public_exp&AccountID=", edit_template.AccountID };
                    string str3 = Encryption.Encrypt(string.Concat(objArray));
                    this.editableProduct_div1.Attributes.Add("Style", "width:98%; padding: 20px 0px 0px 0px;");
                    this.Iframe1.Attributes.Add("Style", "width:98%;");
                    this.btnExpand.Attributes.Add("Style", "background-image: url(../images/StoreImages/image_07_lft.png); width: 20px;height: 25px; display:block;box-shadow: 0px 1px 4px rgba(0, 0, 0, 0.2);");
                    this.btnExpand.ToolTip = "Collapse";
                    this.Iframe1.Attributes["src"] = string.Concat(ConnectionClass.FrontEndTemplate, "editabletemplate.aspx?", str3);
                    return;
                }
                object[] sessionID1 = new object[] { "tid=", num, "&SessionID=", this.Session.SessionID, "&companyid=", this.CompanyID, "&CartItemID=", this.CartItemID, "&ID=", this.PriceCatalogueID, "&StoreUserID=", this.StoreUserID, "&dbkey=", empty, "&ctype=public&AccountID=", edit_template.AccountID };
                string str4 = Encryption.Encrypt(string.Concat(sessionID1));
                this.editableProduct_div1.Attributes.Add("Style", "width:982px;padding: 20px 16px 0px 0px;");
                this.Iframe1.Attributes.Add("Style", "width:978px;");
                this.btnExpand.Attributes.Add("Style", "background-image: url(../images/StoreImages/image_07_rgt.png); width: 20px;height: 25px; display:block;box-shadow: 0px 1px 4px rgba(0, 0, 0, 0.2);");
                this.btnExpand.ToolTip = "Expand";
                this.Iframe1.Attributes["src"] = string.Concat(ConnectionClass.FrontEndTemplate, "editabletemplate.aspx?", str4);
            }
        }
    }
}
