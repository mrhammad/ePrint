using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class warehouse_customsettings : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private string strImagepath = global.imagePath();

        private string strSitepath = global.sitePath();

        public int CompanyID;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

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

        public warehouse_customsettings()
        {
        }

        protected void btnstocksave_Onclick(object sender, EventArgs e)
        {
            int num;
            foreach (GridDataItem item in this.grdstocksettings.MasterTableView.Items)
            {
                TextBox textBox = (TextBox)item.FindControl("txtScreenName");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnFieldName");
                num = (!((CheckBox)item.FindControl("isChecked")).Checked || !this.chkstkdetail.Checked ? 0 : 1);
                string empty = string.Empty;
                SettingsBasePage.productcatalogue_warehousestock_update(this.CompanyID, hiddenField.Value, textBox.Text, num);
            }
            this.grdstocksettings.Rebind();
            DataTable dataTable = SettingsBasePage.productcatalogue_warehousestock_select(this.CompanyID);
            int num1 = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i]["isdisplay"]))
                {
                    num1++;
                }
            }
            if (num1 == 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:EnableDisable();", true);
            }
            base.Message_Display("Custom Fields updated successfully", "msg-success", this.plhMessage);
        }

        protected void grdstocksettings_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label languageConversion = (Label)e.Item.FindControl("lblFieldName");
                if (languageConversion.Text.ToLower() == "customfield1")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield1");
                    return;
                }
                if (languageConversion.Text.ToLower() == "customfield2")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield2");
                    return;
                }
                if (languageConversion.Text.ToLower() == "customfield3")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield3");
                    return;
                }
                if (languageConversion.Text.ToLower() == "customfield4")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield4");
                    return;
                }
                if (languageConversion.Text.ToLower() == "customfield5")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield5");
                    return;
                }
                if (languageConversion.Text.ToLower() == "customfield6")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("customfield6");
                }
            }
        }

        public void GridStockBind(int CompanyID)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            DataTable dataTable = SettingsBasePage.productcatalogue_warehousestock_select(CompanyID);
            int num = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i]["isdisplay"]))
                {
                    num++;
                }
            }
            if (num <= 0)
            {
                this.chkstkdetail.Checked = false;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:EnableDisable();", true);
            }
            else
            {
                this.chkstkdetail.Checked = true;
            }
            this.grdstocksettings.DataSource = dataTable;
            this.grdstocksettings.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grdstocksettings.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Field_Name");
            this.grdstocksettings.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Display");
            this.grdstocksettings.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Screen_Name");
            this.btnstocksave.Text = this.objLanguage.GetLanguageConversion("Save");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Stock_Custom_Fields"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), "&nbsp;&nbsp;");
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = global.pageTitle(this.objLanguage.GetLanguageConversion("Warehouse_Custom_Settings"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Stock_Custom_Fields");
            if (!base.IsPostBack)
            {
                this.GridStockBind(this.CompanyID);
            }
        }
    }
}