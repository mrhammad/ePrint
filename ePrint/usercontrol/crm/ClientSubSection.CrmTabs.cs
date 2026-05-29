using System;

using System.Web;

using System.Web.UI;

using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls;



namespace ePrint.usercontrol.crm

{

    public partial class ClientSubSection

    {

        private bool _crmTabClickHandled;

        private string _activeCrmTabKey = "client";



        private static void SetDisplay(Control control, bool visible)

        {

            if (control == null)

            {

                return;

            }

            if (control is WebControl webControl)

            {

                webControl.Style["display"] = visible ? "block" : "none";

                return;

            }

            if (control is HtmlControl htmlControl)

            {

                htmlControl.Style["display"] = visible ? "block" : "none";

            }

        }



        private void HideAllCrmSectionPanels()

        {

            SetDisplay(this.div_ClientMain, false);

            SetDisplay(this.div_ContactMain, false);

            SetDisplay(this.div_DepartmentMain, false);

            SetDisplay(this.div_AddressMain, false);

            SetDisplay(this.div_b2bMain, false);

            SetDisplay(this.div_ProductsMain, false);

            SetDisplay(this.div_NotesMain, false);

            SetDisplay(this.div_EmailMain, false);

            SetDisplay(this.div_ActivitiesMain, false);

            SetDisplay(this.div_CostcentreMain, false);

            SetDisplay(this.DivAnotherDesign, false);

        }



        private void HideAllCrmToolbarPanels()

        {

            SetDisplay(this.div_DeptControls, false);

            SetDisplay(this.div_ContactControls, false);

            SetDisplay(this.div_AddressControls, false);

            SetDisplay(this.div_CostcenterControls, false);

            SetDisplay(this.div_ProductsControls, false);

            SetDisplay(this.div_EmailControls, false);

            SetDisplay(this.div_EstimateControls, false);

            SetDisplay(this.div_JobControls, false);

            SetDisplay(this.div_InvoiceControls, false);

            SetDisplay(this.div_eStoreControls, false);

        }



        private void ApplyCrmTabLayout(string tabKey)

        {

            string tab = (tabKey ?? "client").ToLower();

            this._activeCrmTabKey = tab;

            if (this.hdnActiveCrmTab != null)

            {

                this.hdnActiveCrmTab.Value = tab;

            }



            this.HideAllCrmSectionPanels();

            this.HideAllCrmToolbarPanels();

            SetDisplay(this.divbtnedit, false);

            SetDisplay(this.divbtndelete, false);

            SetDisplay(this.DivsearchButton, false);



            if (this.tablemainpanel != null)

            {

                this.tablemainpanel.Attributes["data-crm-active-tab"] = tab;

            }



            switch (tab)

            {

                case "client":

                    SetDisplay(this.div_ClientMain, true);

                    SetDisplay(this.divbtnedit, true);

                    SetDisplay(this.divbtndelete, true);

                    SetDisplay(this.DivsearchButton, true);

                    break;

                case "dept":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_DepartmentMain, true);

                    SetDisplay(this.div_DeptControls, true);

                    break;

                case "contacts":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_ContactMain, true);

                    SetDisplay(this.div_ContactControls, true);

                    break;

                case "address":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_AddressMain, true);

                    SetDisplay(this.div_AddressControls, true);

                    break;

                case "costcentre":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_CostcentreMain, true);

                    SetDisplay(this.div_CostcenterControls, true);

                    break;

                case "b2b":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_b2bMain, true);

                    break;

                case "products":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_ProductsMain, true);

                    SetDisplay(this.div_ProductsControls, true);

                    break;

                case "emails":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_EmailMain, true);

                    SetDisplay(this.div_EmailControls, true);

                    break;

                case "activities":

                case "jobs":

                case "invoices":

                case "estore":

                    SetDisplay(this.DivAnotherDesign, true);

                    SetDisplay(this.div_ActivitiesMain, true);

                    break;

                case "notes":

                    SetDisplay(this.div_NotesMain, true);

                    break;

            }



            if (tab == "activities" || tab == "jobs" || tab == "invoices" || tab == "estore")

            {

                this.ApplyRecordsToolbar(tab);

            }



            this.SetCrmPanelTitle(tab);

            this.RegisterCrmTabClientSync(tab);

        }



        private void SetCrmPanelTitle(string tabKey)

        {

            if (this.PanelName == null)

            {

                return;

            }

            switch ((tabKey ?? string.Empty).ToLower())

            {

                case "contacts":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Contacts");

                    break;

                case "dept":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Departments");

                    break;

                case "address":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Address_Book");

                    break;

                case "costcentre":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Cost_Centres");

                    break;

                case "b2b":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("eStore");

                    break;

                case "products":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Products");

                    break;

                case "emails":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Emails");

                    break;

                case "activities":

                case "jobs":

                case "invoices":

                case "estore":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Records");

                    break;

                case "notes":

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Notes");

                    break;

                default:

                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Summary_Information");

                    break;

            }

        }



        private void ApplyRecordsToolbar(string subTab)

        {

            SetDisplay(this.div_EstimateControls, false);

            SetDisplay(this.div_JobControls, false);

            SetDisplay(this.div_InvoiceControls, false);

            SetDisplay(this.div_eStoreControls, false);

            switch ((subTab ?? string.Empty).ToLower())

            {

                case "activities":

                    SetDisplay(this.div_EstimateControls, true);

                    break;

                case "jobs":

                    SetDisplay(this.div_JobControls, true);

                    break;

                case "invoices":

                    SetDisplay(this.div_InvoiceControls, true);

                    break;

                case "estore":

                    SetDisplay(this.div_eStoreControls, true);

                    break;

            }

        }



        private bool IsCrmCustomerType()

        {

            return string.Equals(this.CompanyType, "customer", StringComparison.OrdinalIgnoreCase);

        }



        private void HideProductsEmailsRecordsNav()

        {

            SetDisplay(this.DivlnlCostCentre, false);

            SetDisplay(this.DivlnlProducts, false);

            SetDisplay(this.DivlnkEmail, false);

            SetDisplay(this.DivlnkRecords, false);

        }



        private bool IsRestrictedCustomerTab(string tabKey)

        {

            if (!this.IsCrmCustomerType())

            {

                return false;

            }

            switch ((tabKey ?? string.Empty).ToLower())

            {

                case "costcentre":

                case "products":

                case "emails":

                case "activities":

                case "jobs":

                case "invoices":

                    return true;

                default:

                    return false;

            }

        }



        private void NormalizeCustomerTabCookie()

        {

            if (!this.IsCrmCustomerType())

            {

                return;

            }

            string cookieName = string.Concat("CRMTabName", this.ClientID);

            HttpCookie cookie = base.Request.Cookies[cookieName];

            if (cookie == null || !this.IsRestrictedCustomerTab(cookie.Value))

            {

                return;

            }

            this.SetCrmTabCookie("client");

        }



        private string GetCrmTabFromCookie()

        {

            if (this.ClientID <= 0)

            {

                return "client";

            }

            string cookieName = string.Concat("CRMTabName", this.ClientID);

            HttpCookie cookie = base.Request.Cookies[cookieName];

            if (cookie == null || string.IsNullOrEmpty(cookie.Value))

            {

                return "client";

            }

            string tab = cookie.Value.ToLower();

            if (this.IsRestrictedCustomerTab(tab))

            {

                return "client";

            }

            return tab;

        }



        private void MarkCrmTabClickHandled()

        {

            this._crmTabClickHandled = true;

        }



        private void HandleCrmTabPostBack()

        {

            if (!base.IsPostBack)

            {

                return;

            }



            string postedButton = this.GetPostedCrmTabButtonName();

            if (!string.IsNullOrEmpty(postedButton))

            {

                this.NavigateCrmTabByButton(postedButton);

                return;

            }



            string postedTab = this.GetPostedActiveCrmTabKey();

            if (!string.IsNullOrEmpty(postedTab)

                && !string.Equals(postedTab, "client", StringComparison.OrdinalIgnoreCase))

            {

                this.NavigateCrmTabByKey(postedTab);

            }

        }



        private string GetPostedActiveCrmTabKey()

        {

            if (this.hdnActiveCrmTab != null && !string.IsNullOrEmpty(this.hdnActiveCrmTab.Value))

            {

                return this.hdnActiveCrmTab.Value.Trim().ToLower();

            }



            if (base.Request.Form == null)

            {

                return null;

            }



            foreach (string key in base.Request.Form.AllKeys)

            {

                if (string.IsNullOrEmpty(key))

                {

                    continue;

                }



                if (key.EndsWith("$hdnActiveCrmTab", StringComparison.OrdinalIgnoreCase)

                    || string.Equals(key, "hdnActiveCrmTab", StringComparison.OrdinalIgnoreCase))

                {

                    string value = base.Request.Form[key];

                    if (!string.IsNullOrEmpty(value))

                    {

                        return value.Trim().ToLower();

                    }

                }

            }



            return null;

        }



        private void NavigateCrmTabByButton(string postedButton)

        {

            switch (postedButton)

            {

                case "LnkSummary":

                case "lnk_ClientTab":

                    this.get_ClientTab();

                    break;

                case "lnkDepartment":

                case "lnk_DeptTab":

                    this.get_DeptTab();

                    break;

                case "lnkContact":

                case "lnk_ContactTab":

                    this.get_ContactTab();

                    break;

                case "lnkAddressBook":

                case "lnk_AddressTab":

                    this.get_AddressTab();

                    break;

                case "lnkEstore":

                case "lnk_b2bTab":

                    this.get_b2bTab();

                    break;

                case "lnlCostCentre":

                case "lnk_CostCenterTab":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_CostcentreTabs();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "lnlProducts":

                case "lnk_ProductsTab":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_ProductTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "lnkEmail":

                case "lnk_EmailsTab":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_EmailsTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "lnkRecords":

                case "lnk_ActivitiesTab":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_ActivitiesTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "lnk_NotesTab":

                    this.get_ClientTab();

                    break;

            }

        }



        private void NavigateCrmTabByKey(string tabKey)

        {

            switch ((tabKey ?? string.Empty).ToLower())

            {

                case "client":

                    this.get_ClientTab();

                    break;

                case "dept":

                    this.get_DeptTab();

                    break;

                case "contacts":

                    this.get_ContactTab();

                    break;

                case "address":

                    this.get_AddressTab();

                    break;

                case "b2b":

                    this.get_b2bTab();

                    break;

                case "costcentre":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_CostcentreTabs();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "products":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_ProductTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "emails":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_EmailsTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "activities":

                case "jobs":

                case "invoices":

                case "estore":

                    if (!this.IsCrmCustomerType())

                    {

                        this.get_ActivitiesTab();

                    }

                    else

                    {

                        this.get_ClientTab();

                    }

                    break;

                case "notes":

                    this.get_ClientTab();

                    break;

            }

        }



        private string GetPostedCrmTabButtonName()

        {

            if (base.Request.Form == null)

            {

                return null;

            }



            string[] tabButtons =

            {

                "LnkSummary", "lnk_ClientTab",

                "lnkDepartment", "lnk_DeptTab",

                "lnkContact", "lnk_ContactTab",

                "lnkAddressBook", "lnk_AddressTab",

                "lnkEstore", "lnk_b2bTab",

                "lnlCostCentre", "lnk_CostCenterTab",

                "lnlProducts", "lnk_ProductsTab",

                "lnkEmail", "lnk_EmailsTab",

                "lnkRecords", "lnk_ActivitiesTab",

                "lnk_NotesTab"

            };



            foreach (string key in base.Request.Form.AllKeys)

            {

                if (string.IsNullOrEmpty(key))

                {

                    continue;

                }



                int separator = key.LastIndexOf('$');

                string name = separator >= 0 ? key.Substring(separator + 1) : key;

                foreach (string tabButton in tabButtons)

                {

                    if (string.Equals(name, tabButton, StringComparison.OrdinalIgnoreCase))

                    {

                        return tabButton;

                    }

                }

            }



            return null;

        }



        protected override void OnPreRender(EventArgs e)

        {

            base.OnPreRender(e);

            if (this._crmTabClickHandled)

            {

                this.HideCrmLoadingOverlay();

                return;

            }



            string tab = null;

            if (this.hdnActiveCrmTab != null && !string.IsNullOrEmpty(this.hdnActiveCrmTab.Value))

            {

                tab = this.hdnActiveCrmTab.Value.Trim().ToLower();

            }



            if (string.IsNullOrEmpty(tab))

            {

                tab = this._activeCrmTabKey;

            }



            if (string.IsNullOrEmpty(tab))

            {

                tab = this.GetCrmTabFromCookie();

            }



            if (string.IsNullOrEmpty(tab))

            {

                tab = "client";

            }



            this.ApplyCrmTabLayout(tab);

            this.HideCrmLoadingOverlay();

        }



        private void RegisterCrmTabClientSync(string tabKey)

        {

            string safeKey = (tabKey ?? string.Empty).Replace("'", string.Empty);

            string script = string.Format(

                "if(window.eprintCrmTabs){{window.eprintCrmTabs.applyPreview('{0}');}}if(window.eprintCrmUi){{window.eprintCrmUi.updateActiveNav();}}",

                safeKey);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "crmTabSync_" + safeKey, script, true);

        }



        /// <summary>

        /// Tab link buttons live inside legacy UpdatePanels; without full postback only those panels refresh.

        /// </summary>

        private void RegisterCrmTabPostBackControls()

        {

            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

            if (scriptManager == null)

            {

                return;

            }

            scriptManager.RegisterPostBackControl(this.lnk_ClientTab);

            scriptManager.RegisterPostBackControl(this.lnk_DeptTab);

            scriptManager.RegisterPostBackControl(this.lnk_ContactTab);

            scriptManager.RegisterPostBackControl(this.lnk_AddressTab);

            scriptManager.RegisterPostBackControl(this.lnk_b2bTab);

            scriptManager.RegisterPostBackControl(this.lnk_ProductsTab);

            scriptManager.RegisterPostBackControl(this.lnk_NotesTab);

            scriptManager.RegisterPostBackControl(this.lnk_EmailsTab);

            scriptManager.RegisterPostBackControl(this.lnk_CostCenterTab);

            scriptManager.RegisterPostBackControl(this.lnk_ActivitiesTab);

            scriptManager.RegisterPostBackControl(this.LnkSummary);

            scriptManager.RegisterPostBackControl(this.lnkDepartment);

            scriptManager.RegisterPostBackControl(this.lnkContact);

            scriptManager.RegisterPostBackControl(this.lnkAddressBook);

            scriptManager.RegisterPostBackControl(this.lnkEstore);

            scriptManager.RegisterPostBackControl(this.lnlCostCentre);

            scriptManager.RegisterPostBackControl(this.lnlProducts);

            scriptManager.RegisterPostBackControl(this.lnkEmail);

            scriptManager.RegisterPostBackControl(this.lnkRecords);

        }



        private void HideCrmLoadingOverlay()

        {

            SetDisplay(this.divLoadingImageCus, false);

            ScriptManager.RegisterStartupScript(

                this,

                this.GetType(),

                "crmHideLoad",

                "if(typeof hideCrmLoadingOverlay==='function'){hideCrmLoadingOverlay();}",

                true);

        }

    }

}


