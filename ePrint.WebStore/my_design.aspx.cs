using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.DataAccessLayer.Cart;
using Printcenter.UI.CatrsNew;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class my_design : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label LblMessage;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected HtmlGenericControl productAdded;

        //protected RadGrid RadGridMyDesign;

        //protected HtmlGenericControl Shoppingcard_div;

        private commonclass comm = new commonclass();

        public string CookieID = "";

        public string type = "";

        public long StoreUserID;

        public int CompanyID;

        public string NewSessionID = string.Empty;

        public long CartID;

        public string strSitepath = string.Empty;

        public string StyleSheetPath = string.Empty;

        public static long AccountID;

        public string AccountType = string.Empty;

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

        static my_design()
        {
        }

        public my_design()
        {
        }

        public void BindMyDesignCartItems()
        {
            this.RadGridMyDesign.MasterTableView.GetColumn("UnitPrice").HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridMyDesign.MasterTableView.GetColumn("CartTotalPrice").HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Total"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            DBCart dBCart = new DBCart();
            DataTable dataTable = dBCart.Select_MyDesignCartItems(this.CookieID, this.type, this.StoreUserID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["CatalogueName"] = base.SpecialDecode(row["CatalogueName"].ToString());
                row["ItemTitle"] = base.SpecialDecode(row["ItemTitle"].ToString());
            }
            this.RadGridMyDesign.DataSource = dataTable;
            if (dataTable.Rows.Count <= 0)
            {
                this.RadGridMyDesign.AllowPaging = false;
            }
            else
            {
                this.RadGridMyDesign.AllowPaging = true;
            }
            this.RadGridMyDesign.DataBind();
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            long num = Convert.ToInt64(linkButton.CommandArgument.ToString());
            this.CartID = Convert.ToInt64(linkButton.CommandName.ToString());
            CartBasePage.Delete_CartItem_B2B(num, this.CartID);
            this.LblMessage.Visible = true;
            this.BindMyDesignCartItems();
        }

        protected void btnEdit_Click(object sender, CommandEventArgs e)
        {
            string empty = string.Empty;
            DBCart dBCart = new DBCart();
            DataTable dataTable = dBCart.Select_MyDesignCartItems(this.CookieID, this.type, this.StoreUserID);
            foreach (DataRow row in dataTable.Rows)
            {
                if (e.CommandArgument.ToString() != row["CartItemID"].ToString())
                {
                    continue;
                }
                empty = row["ProductID"].ToString();
            }
            HttpResponse response = base.Response;
            object[] fileExtension = new object[] { this.strSitepath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", e.CommandArgument, "&ID=", empty, "#EditTemplate" };
            response.Redirect(string.Concat(fileExtension));
        }

        protected void LnkPdf_Click(object sender, CommandEventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "my_design.aspx' >", this.objLanguage.GetLanguageConversion("Saved_Drafts"), "</a>" };
            label.Text = string.Concat(sitePath);
            this.RadGridMyDesign.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGridMyDesign.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Product_Name");
            this.RadGridMyDesign.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Saved_Drafts");
            this.RadGridMyDesign.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Unit_Price");
            this.RadGridMyDesign.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
            this.RadGridMyDesign.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Total");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                this.StyleSheetPath = ConnectionClass.StyleSheetPath;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                my_design.AccountID = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            this.AccountType = this.comm.return_AccountType((long)this.CompanyID, my_design.AccountID);
            if (this.Session["StoreUserID"] == null && this.AccountType.ToLower() == "p" || this.CompanyID == 0 && my_design.AccountID == (long)0)
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
            base.Title = commonclass.pageTitle("Saved Design", Convert.ToInt32(this.CompanyID), Convert.ToInt32(my_design.AccountID));
            this.BindMyDesignCartItems();
            this.NewSessionID = this.comm.UniqueID;
        }

        protected void RadGridMyDesign_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DBCart dBCart = new DBCart();
            DataTable dataTable = dBCart.Select_MyDesignCartItems(this.CookieID, this.type, this.StoreUserID);
            this.RadGridMyDesign.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridMyDesign.AllowPaging = true;
                return;
            }
            this.RadGridMyDesign.AllowPaging = false;
        }
    }
}
