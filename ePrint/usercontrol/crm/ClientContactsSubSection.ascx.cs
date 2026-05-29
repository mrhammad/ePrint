using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class ClientContactsSubSection : System.Web.UI.UserControl
    {
        public static string WhereConditionContact;

        private CompanyBasePage objcomm = new CompanyBasePage();
        public BaseClass basecls = new BaseClass();
        public languageClass objLangClass = new languageClass();

        public int CompanyID;
        public int UserID;
        public int ClientID;
        public int AccountID;
        public int cntDelete;
        public int cntDefault;
        public int cntActivate;
        public int cntDeactivate;
        public int SetDefaultContactID;
        public int Index;
        public int DefContactid;
        public string CompanyType = string.Empty;
        public string isView = string.Empty;
        public string ImgPath = global.imagePath();
        public string FileExtension = string.Empty;
        public string WebStorePathB2B = string.Empty;
        public string WebStorePathB2C = string.Empty;
        public bool IsSpendLimitEnable;
        public bool IsPeruser;
        public DataTable dt_Contact;
        public DataSet ds_Contact;

        public ClientSubSection ParentCrmSection { get; set; }
        public RadGrid ParentAddressGrid { get; set; }
        public Panel MoreThanOneSelectedPanel { get; set; }

        static ClientContactsSubSection()
        {
            ClientContactsSubSection.WhereConditionContact = string.Empty;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ConfigureContactFilterMenu();
        }

        public void ConfigureContactFilterMenu()
        {
            GridFilterMenu filterMenu = this.RadGrid_Contact.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                string lower = filterMenu.Items[i].Text.ToLower();
                if (lower == null) continue;
                switch (lower)
                {
                    case "custom": filterMenu.Items[i].Text = "Custom-Text (ThisWeek)"; break;
                    case "isempty":
                    case "notisempty":
                    case "isnull":
                    case "notisnull":
                    case "between":
                    case "notbetween":
                    case "notequalto":
                    case "greaterthan":
                    case "lessthan":
                    case "greaterthanorequalto":
                    case "lessthanorequalto":
                        filterMenu.Items[i].Visible = false; break;
                }
            }
        }

        public void ClearFilters()
        {
            this.clrFilters_Click(this, EventArgs.Empty);
        }

        public void RefreshGrid(int companyId, int clientId)
        {
            this.GridContact(companyId, clientId, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            this.RadGrid_Contact.Rebind();
        }

        public void BindContactTab()
        {
            this.SyncFromParent();
            ClientContactsSubSection.WhereConditionContact = string.Empty;
            this.RadGrid_Contact.CurrentPageIndex = 0;
            this.GridContact(this.CompanyID, this.ClientID, 1, this.RadGrid_Contact.PageSize);
        }

        private void SyncFromParent()
        {
            if (this.ParentCrmSection == null)
            {
                return;
            }
            this.CompanyID = this.ParentCrmSection.CompanyID;
            this.ClientID = this.ParentCrmSection.ClientID;
            this.UserID = this.ParentCrmSection.UserID;
            this.AccountID = this.ParentCrmSection.AccountID;
            this.CompanyType = this.ParentCrmSection.CompanyType;
            this.isView = this.ParentCrmSection.isView;
            this.ImgPath = this.ParentCrmSection.ImgPath;
            this.FileExtension = this.ParentCrmSection.FileExtension;
            this.WebStorePathB2B = this.ParentCrmSection.WebStorePathB2B;
            this.WebStorePathB2C = this.ParentCrmSection.WebStorePathB2C;
            this.IsSpendLimitEnable = this.ParentCrmSection.IsSpendLimitEnable;
            this.IsPeruser = this.ParentCrmSection.IsPeruser;
            this.DefContactid = this.ParentCrmSection.DefContactid;
            this.basecls = this.ParentCrmSection.basecls;
        }

        public void ApplyListBoxLabels()
        {
            if (this.RadListBox_Contact.Items.Count < 5) return;
            this.RadListBox_Contact.Items[0].Text = this.objLangClass.GetLanguageConversion("Activate_Spend_Limit");
            this.RadListBox_Contact.Items[1].Text = this.objLangClass.GetLanguageConversion("Deactivate_Spend_Limit");
            this.RadListBox_Contact.Items[2].Text = this.objLangClass.GetLanguageConversion("Delete");
            this.RadListBox_Contact.Items[3].Text = this.objLangClass.GetLanguageConversion("Activate_eStore");
            this.RadListBox_Contact.Items[4].Text = this.objLangClass.GetLanguageConversion("Deactivate_eStore");
        }

        // --- FilterFunction ---
        public string FilterFunction(DataTable dtsearchfilter)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dtsearchfilter.Rows)
            {
                if (row["filter"].ToString().ToLower() != "nofilter" && empty1 != "")
                {
                    empty1 = string.Concat(empty1, " and ");
                }
                string lower = row["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                if (str1 == "startswith")
                {
                    string str2 = empty1;
                    string[] strArrays = new string[] { str2, " ", row["ColumnName"].ToString(), " like '", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "%'" };
                    empty1 = string.Concat(strArrays);
                }
                else if (str1 == "endswith")
                {
                    string str3 = empty1;
                    string[] strArrays1 = new string[] { str3, " ", row["ColumnName"].ToString(), " like '%", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "'" };
                    empty1 = string.Concat(strArrays1);
                }
                else if (str1 == "equalto")
                {
                    string str4 = empty1;
                    string[] strArrays2 = new string[] { str4, " ", row["ColumnName"].ToString(), " = '", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "'" };
                    empty1 = string.Concat(strArrays2);
                }
                else if (str1 == "contains")
                {
                    string str5 = empty1;
                    string[] strArrays3 = new string[] { str5, " ", row["ColumnName"].ToString(), " like '%", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "%'" };
                    empty1 = string.Concat(strArrays3);
                }
                else if (str1 == "doesnotcontain")
                {
                    string str6 = empty1;
                    string[] strArrays4 = new string[] { str6, " ", row["ColumnName"].ToString(), " not like '%", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "%'" };
                    empty1 = string.Concat(strArrays4);
                }
                else if (str1 == "nofilter")
                {
                    string str7 = empty1;
                    string[] strArrays5 = new string[] { str7, " ", row["ColumnName"].ToString(), " > '%", this.basecls.SpecialEncode(row["FilterText"].ToString().Trim()), "%'" };
                    empty1 = string.Concat(strArrays5);
                }
            }
            return empty1;
        }

        // --- clrFilters ---
        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid_Contact.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchContact", this.ClientID)] = null;
            ClientContactsSubSection.WhereConditionContact = "";
            this.RadGrid_Contact.MasterTableView.FilterExpression = string.Empty;
            this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
        }

        // --- DeleteImgContact ---
        protected void DeleteImgContact_OnClick(object sender, CommandEventArgs e)
        {
            if (this.ParentCrmSection != null)
            {
                this.ParentCrmSection.SetUpProgressVisible(false);
            }
            this.objcomm.contact_delete(this.CompanyID, e.CommandArgument.ToString(), this.UserID);
            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_Deleted_Successfully"), "msg-success", this.plhContact);
            this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            this.RadGrid_Contact.Rebind();
            if (this.ParentCrmSection != null)
            {
                this.ParentCrmSection.SetUpProgressVisible(false);
            }
        }

        // --- GridContact ---
        public void GridContact(int CompanyID, int ClientID, int pageno, int pagesize)
        {
            if (CompanyID <= 0 || ClientID <= 0)
            {
                this.SyncFromParent();
                CompanyID = this.CompanyID;
                ClientID = this.ClientID;
            }
            if (CompanyID <= 0 || ClientID <= 0)
            {
                return;
            }

            this.RadGrid_Contact.AllowCustomPaging = true;
            this.ds_Contact = CompanyBasePage.client_contacts_select_for_filter(CompanyID, ClientID, pageno, pagesize, ClientContactsSubSection.WhereConditionContact);
            if (this.ds_Contact == null || this.ds_Contact.Tables.Count < 2)
            {
                this.RadGrid_Contact.DataSource = new DataTable();
                this.RadGrid_Contact.VirtualItemCount = 0;
                this.RadGrid_Contact.AllowCustomPaging = false;
                this.RadGrid_Contact.DataBind();
                return;
            }

            this.RadGrid_Contact.DataSource = this.ds_Contact.Tables[0];
            this.RadGrid_Contact.VirtualItemCount = Convert.ToInt32(this.ds_Contact.Tables[1].Rows[0][0].ToString());
            if (this.ds_Contact.Tables[0].Rows.Count == 0)
            {
                this.RadGrid_Contact.VirtualItemCount = 0;
                this.RadGrid_Contact.AllowCustomPaging = false;
            }
            this.RadGrid_Contact.DataBind();
        }

        // --- RadGrid_Contact_PreRender ---
        protected void RadGrid_Contact_PreRender(object sender, EventArgs e)
        {
            if (this.ds_Contact == null && this.CompanyID > 0 && this.ClientID > 0)
            {
                this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            }
        }

        // --- RadGrid_Contact_ItemCommand ---
        protected void RadGrid_Contact_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                ClientContactsSubSection.WhereConditionContact = "";
                if (base.Session[string.Concat("searchContact", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchContact", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchContact", this.ClientID)];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                base.Session[string.Concat("searchContact", this.ClientID)] = dataTable;
                ClientContactsSubSection.WhereConditionContact = this.FilterFunction(dataTable);
                this.GridContact(this.CompanyID, this.ClientID, 1, this.RadGrid_Contact.PageSize);
                this.RadGrid_Contact.Rebind();
            }
        }

        // --- RadGrid_Contact_OnNeedDataSource ---
        protected void RadGrid_Contact_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.SyncFromParent();
            if (this.CompanyID <= 0 || this.ClientID <= 0)
            {
                this.RadGrid_Contact.DataSource = new DataTable();
                this.RadGrid_Contact.VirtualItemCount = 0;
                return;
            }

            this.RadGrid_Contact.AllowCustomPaging = true;
            this.ds_Contact = CompanyBasePage.client_contacts_select_for_filter(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize, ClientContactsSubSection.WhereConditionContact);
            if (this.ds_Contact == null || this.ds_Contact.Tables.Count < 2)
            {
                this.RadGrid_Contact.DataSource = new DataTable();
                this.RadGrid_Contact.VirtualItemCount = 0;
                this.RadGrid_Contact.AllowCustomPaging = false;
                return;
            }

            this.RadGrid_Contact.DataSource = this.ds_Contact.Tables[0];
            this.RadGrid_Contact.VirtualItemCount = Convert.ToInt32(this.ds_Contact.Tables[1].Rows[0][0].ToString());
            if (this.ds_Contact.Tables[0].Rows.Count == 0)
            {
                this.RadGrid_Contact.VirtualItemCount = 0;
                this.RadGrid_Contact.AllowCustomPaging = false;
            }
        }

        // --- RadGrid_Contact_PageIndexChanged ---
        protected void RadGrid_Contact_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid_Contact.AllowCustomPaging = true;
            RadGrid_Contact.CurrentPageIndex = e.NewPageIndex;
            //this.dt_Contact = CompanyBasePage.client_contacts_select_for_filter(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize, this.WhereConditionContact);
            this.ds_Contact = CompanyBasePage.client_contacts_select_for_filter(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize, ClientContactsSubSection.WhereConditionContact);
            this.RadGrid_Contact.DataSource = this.ds_Contact.Tables[0];
            this.RadGrid_Contact.VirtualItemCount = Convert.ToInt32(this.ds_Contact.Tables[1].Rows[0][0].ToString());
            if (this.ds_Contact.Tables[0].Rows.Count == 0)
            {
                this.RadGrid_Contact.VirtualItemCount = 0;
                this.RadGrid_Contact.AllowCustomPaging = false;
            }

            this.RadGrid_Contact.DataBind();
        }

        // --- GetEstoreB2B ---
        private string GetEstoreB2BLoginUrl()
        {
            string ext = string.IsNullOrEmpty(this.FileExtension) ? ".aspx" : this.FileExtension;
            string reqHost = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Request.Url != null)
            {
                reqHost = HttpContext.Current.Request.Url.Host.Trim().ToLower();
            }
            if (IsLocalCrmRequest())
            {
                string local = ConfigurationManager.AppSettings["LocalB2BURL"];
                string baseUrl = !string.IsNullOrWhiteSpace(local) ? local.Trim() : "http://localhost:2222/";
                return string.Concat(baseUrl, "login", ext);
            }
            if (!string.IsNullOrEmpty(this.WebStorePathB2B))
            {
                return this.WebStorePathB2B;
            }
            if (ConnectionClass.B2BURL != null)
            {
                return string.Concat(ConnectionClass.B2BURL, "login", ext);
            }
            return string.Empty;
        }

        // --- IsLocalCrm ---
        private static bool IsLocalCrmRequest()
        {
            if (HttpContext.Current == null || HttpContext.Current.Request == null || HttpContext.Current.Request.Url == null)
            {
                return false;
            }
            string reqHost = HttpContext.Current.Request.Url.Host.Trim().ToLower();
            int reqPort = HttpContext.Current.Request.Url.Port;
            return reqPort == 1111 || reqHost == "localhost" || reqHost == "127.0.0.1" || reqHost == "192.168.1.6";
        }

        // --- GetEstoreB2C ---
        private string GetEstoreB2CLoginUrl()
        {
            string ext = string.IsNullOrEmpty(this.FileExtension) ? ".aspx" : this.FileExtension;
            if (IsLocalCrmRequest())
            {
                string local = ConfigurationManager.AppSettings["LocalB2CURL"];
                string baseUrl = !string.IsNullOrWhiteSpace(local) ? local.Trim() : "http://localhost:2222/";
                return string.Concat(baseUrl, "login", ext);
            }
            if (!string.IsNullOrEmpty(this.WebStorePathB2C))
            {
                return this.WebStorePathB2C;
            }
            if (ConnectionClass.B2CURL != null)
            {
                return string.Concat(ConnectionClass.B2CURL, "login", ext);
            }
            return string.Empty;
        }

        // --- RadGridContact_OnRowDataBound ---
        protected void RadGridContact_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.CommandItem)
                {
                    string empty = string.Empty;
                    empty = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                    HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivAddNewContact");
                    if (empty.Trim().ToLower() != "false")
                    {
                        if(htmlControl !=null)
                        {
                            htmlControl.Visible = true;
                        }
                    }
                    else
                    {
                        if (htmlControl != null)
                        {
                            htmlControl.Visible = false;
                        }
                    }
                    GridTableView masterTableView = this.RadGrid_Contact.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                    GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    //((LinkButton)items.FindControl("btnclrFilters_Contacts")).Visible = true;
                }
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    GridDataItem contactRow = (GridDataItem)e.Item;
                    for (int cellIndex = 0; cellIndex < contactRow.Cells.Count && cellIndex < this.RadGrid_Contact.Columns.Count; cellIndex++)
                    {
                        string headerText = this.RadGrid_Contact.Columns[cellIndex].HeaderText;
                        if (!string.IsNullOrEmpty(headerText))
                        {
                            contactRow.Cells[cellIndex].Attributes["data-label"] = headerText;
                        }
                    }
                    string str = string.Empty;
                    str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
                    HtmlControl htmlControl1 = (HtmlControl)e.Item.FindControl("DivContact");
                    HtmlControl htmlControl2 = (HtmlControl)e.Item.FindControl("DivLoginKey");
                    if (str.Trim().ToLower() != "false")
                    {
                        if (this.ParentAddressGrid != null)
                        {
                            this.ParentAddressGrid.MasterTableView.GetColumn("checkBox_Address").Visible = true;
                        }
                        htmlControl1.Visible = true;
                    }
                    else
                    {
                        if (this.ParentAddressGrid != null)
                        {
                            this.ParentAddressGrid.MasterTableView.GetColumn("checkBox_Address").Visible = false;
                        }
                        htmlControl1.Visible = false;
                        htmlControl2.Style.Add("float", "right");
                        htmlControl2.Style.Add("padding-right", "22px");
                    }
                    Label text = (Label)e.Item.FindControl("lbl_ContactName");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_ContactFirstName");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_ContactLastName");
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_DefaultContact");
                    HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_DefaultContactID");
                    Image image = (Image)e.Item.FindControl("img_DefaultContact");
                    Image image1 = (Image)e.Item.FindControl("ImgButtonDeleteContacts");
                    HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_LoginEmail");
                    HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_LoginPwd");
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonLoginContacts");
                    HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("anchor");
                    if (this.CompanyType.ToString().ToLower() == "supplier" || this.CompanyType.ToString().ToLower() == "prospect")
                    {
                        imageButton.Visible = false;
                    }
                    AttributeCollection attributes = htmlAnchor.Attributes;
                    object[] objArray = new object[] { "javascript:postwith('", this.basecls.SpecialEncode(((DataRowView)e.Item.DataItem)[31].ToString()), "',{b2bemail:'", this.basecls.SpecialEncode(((DataRowView)e.Item.DataItem)[11].ToString()), "',b2bpwd:'", ((DataRowView)e.Item.DataItem)[29], "',id:'", ((DataRowView)e.Item.DataItem)[32], "',from:'MIS'},'", this.GetEstoreB2BLoginUrl(), "','", this.GetEstoreB2CLoginUrl(), "');return false;" };
                    attributes.Add("onclick", string.Concat(objArray));
                    HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkBox_Contact");
                    Label label = (Label)e.Item.FindControl("lbl_Activate");
                    HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_Activate");
                    text.Text = string.Concat(hiddenField.Value, " ", hiddenField1.Value);
                    text.ToolTip = text.Text;
                    if (hiddenField2.Value != "True")
                    {
                        image.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                    }
                    else
                    {
                        this.DefContactid = Convert.ToInt32(hiddenField3.Value);
                        image.ImageUrl = string.Concat(this.ImgPath, "ICON_checkboxNew.gif");
                        if (!this.IsSpendLimitEnable)
                        {
                            htmlInputCheckBox.Disabled = true;
                        }
                        else if (!this.IsPeruser)
                        {
                            htmlInputCheckBox.Disabled = true;
                        }
                        else
                        {
                            htmlInputCheckBox.Disabled = false;
                        }
                        image1.Visible = false;
                        image1.Style.Add("margin-left", "30px");
                    }
                    if (!(hiddenField4.Value != "") || !(hiddenField5.Value != ""))
                    {
                        imageButton.ImageUrl = string.Concat(this.ImgPath, "1t.gif");
                        label.Text = "";
                    }
                    else
                    {
                        imageButton.ImageUrl = string.Concat(this.ImgPath, "key.gif");
                        imageButton.CommandArgument = string.Concat(hiddenField4.Value, ",", hiddenField5.Value);
                        if (hiddenField6.Value != "True")
                        {
                            imageButton.ImageUrl = string.Concat(this.ImgPath, "1t.gif");
                            label.Text = "Deactivate";
                        }
                        else
                        {
                            label.Text = "Active";
                        }
                    }
                }
            }
            catch
            {
            }
        }

        // --- RadListBox_Contact ---
        protected void RadListBox_Contact_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            this.dt_Contact = CompanyBasePage.client_contacts_select(this.CompanyID, this.ClientID);
            int num2 = 0;
            while (num2 < this.RadGrid_Contact.Items.Count)
            {
                string empty = string.Empty;
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Contact.Items[num2].Cells[0].FindControl("checkBox_Contact");
                if (base.Request.Cookies["RadListBoxContactsValue"] != null)
                {
                    empty = base.Request.Cookies["RadListBoxContactsValue"].Value;
                }
                if (empty.ToLower() == "delete" && this.hdn_ContactIDs.Value.Length > 0)
                {
                    string[] strArrays = this.hdn_ContactIDs.Value.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (Convert.ToInt32(strArrays[i]) == this.DefContactid)
                        {
                            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Default_contact_can_not_be_delete"), "msg-fail", this.plhContact);
                        }
                        else
                        {
                            num = Convert.ToInt32(strArrays[i]);
                            this.objcomm.contact_delete(this.CompanyID, num.ToString(), this.UserID);
                            htmlInputCheckBox.Checked = false;
                            this.cntDelete = this.cntDelete + 1;
                        }
                    }
                }
                if (empty.ToLower() == "set default" && htmlInputCheckBox.Checked)
                {
                    this.SetDefaultContactID = Convert.ToInt32(htmlInputCheckBox.Value);
                    this.cntDefault = this.cntDefault + 1;
                    htmlInputCheckBox.Checked = false;
                }
                if (empty.ToLower() == "activate" && this.hdn_ContactIDs.Value.Length > 0)
                {
                    string[] strArrays1 = this.hdn_ContactIDs.Value.Split(new char[] { ',' });
                    for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                    {
                        num = Convert.ToInt32(strArrays1[j]);
                        foreach (DataRow row in this.dt_Contact.Rows)
                        {
                            if (num != Convert.ToInt32(row["ContactID"].ToString()))
                            {
                                continue;
                            }
                            num1 = (row["Password"].ToString() != "" ? 0 : num1 + 1);
                        }
                        if (num1 == 0)
                        {
                            this.objcomm.StoreUser_AccountIsActivate(this.CompanyID, num, 1);
                            this.cntActivate = this.cntActivate + 1;
                            htmlInputCheckBox.Checked = false;
                        }
                    }
                }

                if (empty.ToLower() == "deactivate" && this.hdn_ContactIDs.Value.Length > 0)
                {
                    string[] strArrays2 = this.hdn_ContactIDs.Value.Split(new char[] { ',' });
                    for (int k = 0; k < (int)strArrays2.Length - 1; k++)
                    {
                        num = Convert.ToInt32(strArrays2[k]);
                        foreach (DataRow dataRow in this.dt_Contact.Rows)
                        {
                            if (num != Convert.ToInt32(dataRow["ContactID"].ToString()))
                            {
                                continue;
                            }
                            num1 = (dataRow["Password"].ToString() != "" ? 0 : num1 + 1);
                        }
                        if (num1 == 0)
                        {
                            this.objcomm.StoreUser_AccountIsActivate(this.CompanyID, num, 0);
                            this.cntDeactivate = this.cntDeactivate + 1;
                            htmlInputCheckBox.Checked = false;
                        }
                    }
                }
                if (!(empty.ToLower() == "spendlimitdeactivate") || this.hdn_ContactIDs.Value.Length <= 0)
                {
                    num2++;
                }
                else
                {
                    string str = string.Empty;
                    this.objcomm.Deactivate_SpendLimitUser(this.CompanyID, this.hdn_ContactIDs.Value, "contact");
                    break;
                }
                if (!(empty.ToLower() == "deactivatestorecredit") || this.hdn_ContactIDs.Value.Length <= 0)
                {
                    num2++;
                }
                else
                {
                    string str = string.Empty;
                    this.objcomm.Deactivate_StoreCredit(this.CompanyID, this.hdn_ContactIDs.Value);
                    break;
                }
            }
            if (this.cntDelete != 0)
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_Deleted_Successfully"), "msg-success", this.plhContact);
            }
            else if (this.cntDefault != 1)
            {
                if (this.MoreThanOneSelectedPanel != null)
                {
                    this.MoreThanOneSelectedPanel.Visible = true;
                }
            }
            else
            {
                (new CompanyBasePage()).client_defaultcontact(this.CompanyID, this.ClientID, this.SetDefaultContactID);
                this.basecls.Message_Display("Default contact set successfully", "msg-success", this.plhContact);
                this.cntDefault = 0;
            }
            if (this.cntActivate != 0)
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_Activated_Successfully"), "msg-success", this.plhContact);
            }
            else if (this.cntDeactivate != 0)
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_de_activated_successfully"), "msg-success", this.plhContact);
            }
            else if (num1 != 0)
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Selected_Contact_cannot_be_activate_deactivate"), "msg-fail", this.plhContact);
            }
            if (this.ParentCrmSection != null) { this.ParentCrmSection.BindDefaultGrids(this.CompanyID, this.ClientID); }
            this.RadGrid_Contact.Rebind();
            this.RadListBox_Contact.SelectedIndex = this.Index - 1;
            base.Request.Cookies["RadListBoxContactsValue"].Value = null;
        }

        // --- setDefaultContact ---
        protected void setDefaultContact_OnClick(object sender, CommandEventArgs e)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            companyBasePage.client_defaultcontact(this.CompanyID, this.ClientID, Convert.ToInt32(e.CommandArgument));
            this.basecls.Message_Display("Default contact set successfully", "msg-success", this.plhContact);
            this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            this.RadGrid_Contact.Rebind();
        }


    }
}
