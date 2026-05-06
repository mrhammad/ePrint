using nmsCommon;
using nmsConnection;
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

namespace ePrint.WebStore
{
    public partial class edit_template : BaseClass, IRequiresSessionState
    {
        //protected HtmlIframe Iframe1;

        private commonclass comm = new commonclass(); 

        public int CartItemID;

        public int StoreUserID;

        public int PriceCatalogueID;

        public int CompanyID;

        public char KeySeparator;

        public string AccountType = string.Empty;

        public static long AccountID;

        public string strSitepath = string.Empty;

        public string ProdCategoryID = string.Empty;

        public string ProductSitePath = string.Empty;

        public int strMainCount;

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

        public void GenerateBreadcrums(int CategoryID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            this.ProdCategoryID = CategoryID.ToString();
            DataTable dataTable = ProductBasePage.ProductCategoryNameSelect_Navigation(this.CompanyID, Convert.ToInt32(this.ProdCategoryID));
            foreach (DataRow row in dataTable.Rows)
            {
                empty1 = row["PriceCatalogueCategoryName"].ToString().Trim();
                empty = row["PriceCatalogueCategoryName"].ToString().Trim();
                if (this.strMainCount > empty.Length + 4)
                {
                    this.strMainCount = this.strMainCount - (empty.Length + 4);
                    object[] objArray = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                else if (this.strMainCount <= 4)
                {
                    empty = "..";
                    this.strMainCount = this.strMainCount - empty.Length;
                    object[] objArray1 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray1);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                else
                {
                    this.strMainCount = this.strMainCount - 4;
                    if (this.strMainCount <= 2)
                    {
                        empty = "..";
                    }
                    else
                    {
                        empty = empty.Substring(0, this.strMainCount - 2);
                        empty = string.Concat(empty, "..");
                    }
                    this.strMainCount = this.strMainCount - empty.Length;
                    object[] objArray2 = new object[] { "<span Class='floatLeft'>&nbsp;>>&nbsp;</span><a title='", base.SpecialDecode(empty1), "' Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", CategoryID, "'>", base.SpecialDecode(empty), " </a>" };
                    str = string.Concat(objArray2);
                    if (str != "")
                    {
                        this.ProductSitePath = string.Concat(str, this.ProductSitePath);
                    }
                }
                if (this.strMainCount <= 0 || Convert.ToInt32(row["ParentCategoryID"]) <= 0)
                {
                    continue;
                }
                this.GenerateBreadcrums(Convert.ToInt32(row["ParentCategoryID"]));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string item = "";
            string str = "";
            this.StoreUserID = Convert.ToInt32(this.Session["StoreUserID"]);
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
            if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
            {
                item = base.Request.QueryString["ID"];
                DataTable dataTable = ProductBasePage.WS_CategoryName_SubCategory_Select_for_Navigation(Convert.ToInt32(item), this.CompanyID, this.PriceCatalogueID);
                foreach (DataRow row in dataTable.Rows)
                {
                    base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
                    str = base.SpecialDecode(row["CatalogueName"].ToString());
                    this.strMainCount = 75;
                    if (this.Session["Notification"] != null)
                    {
                        if (this.Session["Notification"] != null)
                        {
                            this.strMainCount = 90;
                        }
                        else
                        {
                            this.strMainCount = 75;
                        }
                    }
                    this.strMainCount = this.strMainCount - 12;
                    if (this.strMainCount > str.Length + 4)
                    {
                        this.strMainCount = this.strMainCount - str.Length + 4;
                        if (this.ProductSitePath == "")
                        {
                            string[] sitePath = new string[] { "<span style='float:left;'>&nbsp;>>&nbsp;</span><div class='div_prodname_navigation'>", str, "</div><a style='float:left; text-decoration:underline;' href ='", BaseClass.SitePath, "products/productdetails.aspx' Class='pathlink'></a>" };
                            this.ProductSitePath = string.Concat(sitePath);
                        }
                    }
                    if (this.strMainCount > 0 && Convert.ToInt32(row["PriceCatalogueCategoryID"]) > 0)
                    {
                        this.GenerateBreadcrums(Convert.ToInt32(row["PriceCatalogueCategoryID"]));
                    }
                    Label label = (Label)base.Master.FindControl("lblPathLink");
                    string[] strArrays = new string[] { "<a style='float:left; text-decoration:underline;'  href ='", BaseClass.SitePath, "Default.aspx' Class='pathlink'></a><span style='float:left;'></span><a style='float:left; text-decoration:underline;' href ='", BaseClass.SitePath, "products/product.aspx' Class='pathlink'>Product List</a>", this.ProductSitePath };
                    label.Text = string.Concat(strArrays);
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
                        string str1 = RewriteContext.Current.Params["CartItemID"].ToString();
                        char[] keySeparator = new char[] { this.KeySeparator };
                        this.CartItemID = Convert.ToInt32(str1.Split(keySeparator)[1]);
                    }
                    if (RewriteContext.Current.Params["ID"] != null)
                    {
                        this.PriceCatalogueID = Convert.ToInt32(RewriteContext.Current.Params["ID"].ToString());
                    }
                }
            }
            string empty = string.Empty;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
                sqlConnection.Open();
                DataTable dataTable1 = new DataTable();
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
            catch
            {
            }
            DataSet dataSet = ProductBasePage.Select_TemplateID((long)this.PriceCatalogueID);
            DataTable dataTable2 = ProductBasePage.Select_UserID_BasedOnBehalf((long)this.CartItemID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                long num = (long)0;
                if (dataTable2.Rows.Count > 0)
                {
                    num = Convert.ToInt64(dataTable2.Rows[0]["StoreUserID"].ToString());
                }
                long num1 = Convert.ToInt64(dataSet.Tables[0].Rows[0]["TemplateID"].ToString());
                object[] sessionID = new object[] { "tid=", num1, "&SessionID=", this.Session.SessionID, "&companyid=", this.CompanyID, "&CartItemID=", this.CartItemID, "&ID=", this.PriceCatalogueID, "&StoreUserID=", num, "&dbkey=", empty, "&ctype=b2b&AccountID=", edit_template.AccountID };
                string str2 = Encryption.Encrypt(string.Concat(sessionID));
                this.Iframe1.Attributes["src"] = string.Concat(BaseClass.FrontEndTemplate, "editabletemplate.aspx?", str2);
            }
        }
    }
}