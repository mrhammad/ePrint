using nmsCommon;
using nmsConnection;
using Printcenter.UI.CatrsNew;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore.common
{
    public partial class artwork_common : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected RadGrid grdFilesUploaded;

        //protected HtmlForm form1;

        private commonclass comm = new commonclass();

        public long StoreUserID;

        public string NewSessionID = string.Empty;

        public long CartItemID;

        public long CartID;

        public string StyleSheetPathMaster = string.Empty;

        public string StyleSheetPath = string.Empty;

        public int AccountID;

        public int CompanyID;

        public long OrderItemId;

        public long OrderID;

        public string strSitepath = string.Empty;

        public string ArtUploadfile = string.Empty;

        public string ArtUploadfile1 = string.Empty;

        public string ArtUploadfile2 = string.Empty;

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

        public artwork_common()
        {
        }

        protected void grdFilesUploaded_ItemDataBound(object sender, GridItemEventArgs e)
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label label = (Label)e.Item.FindControl("lbl_UpldOn");
                label.Text = this.comm.Eprint_return_Date_Before_View(dataItem["CreatedON"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                this.StyleSheetPath = string.Concat(ConnectionClass.StyleSheetPath, this.AccountID);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.StyleSheetPath, "0");
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            this.Page.Header.DataBind();
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (base.Request.QueryString["CartItemID"] != null)
            {
                this.CartItemID = Convert.ToInt64(base.Request.QueryString["CartItemID"].ToString());
            }
            if (base.Request.QueryString["CartID"] != null)
            {
                this.CartID = Convert.ToInt64(base.Request.QueryString["CartID"].ToString());
            }
            if (base.Request.QueryString["OrderItemID"] != null)
            {
                this.OrderItemId = Convert.ToInt64(base.Request.QueryString["OrderItemID"].ToString());
            }
            this.NewSessionID = this.comm.UniqueID;
            if (base.Request.QueryString["from"] != null)
            {
                if (base.Request.QueryString["from"].ToString().ToLower() == "shoppingcart")
                {
                    DataTable dataTable = CartBasePage.Select_ArtworkFile(this.CartItemID, this.CartID, "cart");
                    this.grdFilesUploaded.DataSource = dataTable;
                    this.grdFilesUploaded.DataBind();
                    return;
                }
                if (base.Request.QueryString["from"].ToString().ToLower() == "order")
                {
                    DataTable dataTable1 = CartBasePage.Select_ArtworkFile(this.CartItemID, this.OrderItemId, "order");
                    this.grdFilesUploaded.DataSource = dataTable1;
                    this.grdFilesUploaded.DataBind();
                }
            }
        }
    }
}