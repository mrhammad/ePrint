using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.settings
{
    public partial class PurchaseOrderDeliveryaddress : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private int CompanyID;

        public languageClass objlang = new languageClass();

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

        public PurchaseOrderDeliveryaddress()
        {
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                Digital = this.ddlDigital_PODeliveryAddres.SelectedValue,
                Offset = this.ddlOffset_PODeliveryAddres.SelectedValue,
                Largeformat = this.ddlLargeformat_PODeliveryAddres.SelectedValue,
                Outwork = this.ddlOutwork_PODeliveryAddres.SelectedValue,
                ProdCatalogue = this.ddlProdCatlogue_PODeliveryAddres.SelectedValue,
                OtherCost = this.ddlOtherCost_PODeliveryAddres.SelectedValue,
                QuickQuote = this.ddlQuickQuote_PODeliveryAddres.SelectedValue,
                Warehouse = this.ddlWarehouse_PODeliveryAddres.SelectedValue,
                Order = this.ddlWebstoreorder_PODeliveryAddres.SelectedValue,
                DirectPO = this.ddlDirectPO_PODeliveryAddres.SelectedValue,
                DescriptionInclude = this.ddlInventoryPO_include_description.SelectedValue,
                CompanyID = this.CompanyID
            };
            SettingsBasePage.settings_PO_DeliveryAdrress_insertupdate(settingsItem);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (ConnectionClass.SheetFedDigital == null)
                {
                    this.divDigital_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.SheetFedOffset == null)
                {
                    this.divOffset_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.LargeFormat == null)
                {
                    this.divLargeFormat_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.PrintBroker == null)
                {
                    this.divOutwork_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.PriceCatalogue == null)
                {
                    this.divProdCatlogue_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.OtherCosts == null)
                {
                    this.divOthercost_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.QuickQuote == null)
                {
                    this.divQuickquote_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.Warehouse == null)
                {
                    this.divWarehouse_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
                if (ConnectionClass.WebStore == null)
                {
                    this.divWebstoreorder_PODeliveryAddres.Attributes.Add("style", "display:none");
                }
            }
            this.btnSave_PODeliveryAddres.Attributes.Add("onclick", "javascript:loadingimg('div_btnSave','div_btnsaveprocess');");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Purchase_Order")));
            base.Title = this.objlang.convert(global.pageTitle("Delivery Address Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Delivery_Address_Settings");
            if (!base.IsPostBack)
            {
                this.lblDigital_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Digital");
                this.lblOffset_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Offset");
                this.lblLargeformat_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Large_Format");
                this.lblOutwork_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Outwork");
                this.lblProdCatlogue_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Product_Catalogue");
                this.lblOtherCost_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("OtherCost");
                this.lblQuickQuote_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("QuickQuote");
                this.lblWarehouse_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Warehouse");
                this.lblDirectPO_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Direct_PO");
                this.lblWebstoreorder_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Order");
                this.btnSave_PODeliveryAddres.Text = this.objlang.GetLanguageConversion("Save");
                this.lblDeliveryTo_POselecttext.Text = this.objlang.GetLanguageConversion("Select_the_default_delivery_address_settings_for_the_various_types_of_purchase_orders");
                foreach (DataRow row in SettingsBasePage.settings_PODeliveryAddress_select(this.CompanyID).Rows)
                {
                    if (row["Digital"].ToString() != "a")
                    {
                        this.ddlDigital_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlDigital_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["LargeFormat"].ToString() != "a")
                    {
                        this.ddlLargeformat_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlLargeformat_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["Offset"].ToString() != "a")
                    {
                        this.ddlOffset_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlOffset_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["OtherCost"].ToString() != "a")
                    {
                        this.ddlOtherCost_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlOtherCost_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["Outwork"].ToString() != "a")
                    {
                        this.ddlOutwork_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlOutwork_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["PriceCatalogue"].ToString() != "a")
                    {
                        this.ddlProdCatlogue_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlProdCatlogue_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["QuickQuote"].ToString() != "a")
                    {
                        this.ddlQuickQuote_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlQuickQuote_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["Order"].ToString() != "a")
                    {
                        this.ddlWebstoreorder_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlWebstoreorder_PODeliveryAddres.SelectedIndex = 0;
                    }
                    if (row["DescriptionInclude"].ToString() != "a")
                    {
                        this.ddlInventoryPO_include_description.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlInventoryPO_include_description.SelectedIndex = 0;
                    }
                    if (row["Warehouse"].ToString() != "a")
                    {
                        this.ddlWarehouse_PODeliveryAddres.SelectedIndex = 1;
                    }
                    else
                    {
                        this.ddlWarehouse_PODeliveryAddres.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}