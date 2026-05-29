using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class ClientSubSection
    {
        private ClientContactsSubSection _contactsSection;

        public ClientContactsSubSection ContactsSection
        {
            get { return this.EnsureContactsSection(); }
        }

        private ClientContactsSubSection EnsureContactsSection()
        {
            if (this._contactsSection != null)
            {
                return this._contactsSection;
            }
            if (this.plh_ContactDetails != null)
            {
                foreach (Control control in this.plh_ContactDetails.Controls)
                {
                    ClientContactsSubSection existing = control as ClientContactsSubSection;
                    if (existing != null)
                    {
                        this._contactsSection = existing;
                        this.SyncContactsContext(this._contactsSection);
                        this.RegisterContactGridAjaxSettings();
                        return this._contactsSection;
                    }
                }
            }
            ClientContactsSubSection loaded = (ClientContactsSubSection)this.LoadControl("~/usercontrol/crm/ClientContactsSubSection.ascx");
            loaded.ID = "ContactsSubSection";
            this.SyncContactsContext(loaded);
            this.plh_ContactDetails.Controls.Add(loaded);
            this._contactsSection = loaded;
            this.RegisterContactGridAjaxSettings();
            return this._contactsSection;
        }

        private void RegisterContactGridAjaxSettings()
        {
            if (this.RadAjaxManager1 == null || this._contactsSection == null)
            {
                return;
            }

            RadGrid grid = this._contactsSection.RadGrid_Contact;
            if (grid == null)
            {
                return;
            }

            string gridId = grid.ID;
            foreach (AjaxSetting existing in this.RadAjaxManager1.AjaxSettings)
            {
                if (existing.AjaxControlID == gridId || existing.AjaxControlID == "RadGrid_Contact")
                {
                    return;
                }
            }

            AjaxSetting gridSetting = new AjaxSetting(gridId);
            gridSetting.UpdatedControls.Add(new AjaxUpdatedControl(gridId, this.RadAjaxLoadingPanel1.ID));
            this.RadAjaxManager1.AjaxSettings.Add(gridSetting);

            if (this.btn_ClearFilter_Contact != null)
            {
                AjaxSetting clearSetting = new AjaxSetting(this.btn_ClearFilter_Contact.ID);
                clearSetting.UpdatedControls.Add(new AjaxUpdatedControl(gridId, this.RadAjaxLoadingPanel1.ID));
                this.RadAjaxManager1.AjaxSettings.Add(clearSetting);
            }
        }

        public void RefreshContactsContext()
        {
            if (this._contactsSection != null)
            {
                this.SyncContactsContext(this._contactsSection);
            }
        }

        private void SyncContactsContext(ClientContactsSubSection contacts)
        {
            contacts.ParentCrmSection = this;
            contacts.CompanyID = this.CompanyID;
            contacts.ClientID = this.ClientID;
            contacts.UserID = this.UserID;
            contacts.AccountID = this.AccountID;
            contacts.CompanyType = this.CompanyType;
            contacts.isView = this.isView;
            contacts.ImgPath = this.ImgPath;
            contacts.FileExtension = this.FileExtension;
            contacts.WebStorePathB2B = this.WebStorePathB2B;
            contacts.WebStorePathB2C = this.WebStorePathB2C;
            contacts.IsSpendLimitEnable = this.IsSpendLimitEnable;
            contacts.IsPeruser = this.IsPeruser;
            contacts.DefContactid = this.DefContactid;
            contacts.basecls = this.basecls;
            contacts.ParentAddressGrid = this.RadGrid_Address;
            contacts.MoreThanOneSelectedPanel = this.pnl_MoreThan1Selected;
        }

        private RadGrid RadGrid_Contact
        {
            get { return this.ContactsSection.RadGrid_Contact; }
        }

        public void GridContact(int companyId, int clientId, int pageNo, int pageSize)
        {
            this.ContactsSection.GridContact(companyId, clientId, pageNo, pageSize);
        }

        public void SetUpProgressVisible(bool visible)
        {
            this.upProgress.Visible = visible;
        }
    }
}
