using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class coupon_code_view : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public long ID;

        private commonClass objJava = new commonClass();

        public int PageSize = 10000;

        public long AccountID;

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long UserId;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

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

        public coupon_code_view()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        WebstoreBasePage.CouponCode_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(strArrays[i]), this.AccountID);
                    }
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/coupon_code_view.aspx?su=de"));
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridCouponCode.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridCouponCode.MasterTableView.FilterExpression = string.Empty;
            this.GridCouponCode.MasterTableView.Rebind();
        }

        public void GridBind()
        {
            DataSet dataSet = WebstoreBasePage.CouponCode_Select(Convert.ToInt64(this.CompanyID), this.ID, this.AccountID, "");
            RadGrid gridCouponCode = this.GridCouponCode;
            int count = dataSet.Tables[0].Rows.Count;
            gridCouponCode.VirtualItemCount = Convert.ToInt32(count.ToString());
            this.GridCouponCode.PagerStyle.AlwaysVisible = true;
            this.GridCouponCode.DataSource = dataSet;
            this.GridCouponCode.DataBind();
        }

        protected void GridCouponCode_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Image image = (Image)e.Item.FindControl("imgcanbeusemultipletime");
                Image image1 = (Image)e.Item.FindControl("imgalreadyused");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdncanitbeusemultipletime");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnalreaduused");
                if (!Convert.ToBoolean(hiddenField.Value))
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
                if (Convert.ToBoolean(hiddenField.Value) || !(hiddenField1.Value == "1"))
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridCouponCode.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridCouponCode.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridCouponCode_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridCouponCode.CurrentPageIndex = e.NewPageIndex;
            this.GridCouponCode.Rebind();
        }

        protected void GridCouponCode_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridCouponCode.Rebind();
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.CouponCode_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(e.CommandArgument), this.AccountID);
            base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/coupon_code_view.aspx?su=de"));
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridCouponCode.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridCouponCode.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetValueOnLang("Action");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Coupon_Code_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Coupon Code View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.UserId = Convert.ToInt64(this.Session["UserID"].ToString());
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Coupon_Code");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            string str = SettingsBasePage.Fetch_SelectedAccountID(this.UserId);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt64(strArrays[0]);
                this.hdnAccountID.Value = this.AccountID.ToString();
            }
            if (!base.IsPostBack && base.Request.Params["su"] != null)
            {
                if (base.Request.Params["su"] == "in")
                {
                    base.Message_Display("Coupon Code Saved Successfully", "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "up")
                {
                    base.Message_Display("Coupon Code Updated Successfully", "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "de")
                {
                    base.Message_Display("Coupon Code Deleted Successfully", "msg-success", this.plhMessage);
                }
            }
            this.GridBind();
        }
    }
}