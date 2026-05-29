using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class ClientSubSection : System.Web.UI.UserControl
    {

        private CompanyBasePage objcomm = new CompanyBasePage();

        private DepartmentBaseClass objDept = new DepartmentBaseClass();

        private commonClass objcom = new commonClass();

        public BaseClass basecls = new BaseClass();

        private commonClass objCommonClass = new commonClass();

        public languageClass objLanguage = new languageClass();

        private SettingsBasePage objSetBase = new SettingsBasePage();

        private commonClass commclass = new commonClass();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int AccountID;

        public int isnew = 2;

        public int DeliveryAddressID;

        public int InvoiceAddressID;

        public int cntPostbox;

        public int cntDelete;

        public int cntDefault;

        public int cntActivate;

        public int cntDeactivate;

        public int SetDefaultContactID;

        public int SetDefaultDeptID;

        public int Index;

        public static int ChangeOrder;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public static int Contactflag;

        public static int Filtering;

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string strimgpath = global.strimagepath;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string web_key = string.Empty;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string QSsuc = string.Empty;

        public string strSuc = string.Empty;

        public string DateFormat = string.Empty;

        public string companyName = string.Empty;

        public string From = string.Empty;

        public string Tax2 = string.Empty;

        public string uploadedfile;

        public string subject;

        public string fileName;

        public string url;

        public string sectionName;

        public string WebStorePathB2B = string.Empty;

        public string WebStorePathB2C = string.Empty;

        public string isView = string.Empty;

        public DataTable dt_Contact;

        public DataSet ds_Contact;

        public DataTable dt_Department;
        public DataSet ds_Department;

        public DataTable dt_Address;

        public DataTable dt_Notes;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string AccountName = string.Empty;

        public languageClass objLangClass = new languageClass();

        public string SectionName;

        public int SectionID;

        public int UserIDN;

        public int attachID;

        public string CreateddateN = DateTime.Now.ToString();

        public string tasktype = "";

        public int tasktypeid;

        public int ClientIDTask;

        public string SecureDocFilepath = global.SecureDocFilepath();

        public string ServerName = string.Empty;

        public string TodayDate = string.Empty;

        private bool IsApprovalSystemEnable;

        public string TodDate = string.Empty;

        public int UserTypeID;

        public string CompanyTypeNew = "";

        public string ShowRecords = "All";

        public string CompanyCusName = "";

        public string UniqueID = "";

        public string Types = "";

        public bool PopupOpen;

        private DataTable dtsource = new DataTable();

        //public string WhereConditionContact = string.Empty;

        //public string WhereConditionDepartment = string.Empty;

                public static string WhereConditionDepartment;

        public string WhereConditionCostcenter = string.Empty;

        public string WhereConditionAddress = string.Empty;

        public int TaskId;

        public string ActivityType = string.Empty;

        public bool IsSpendLimitEnable;

        public bool IsPeruser;

        public bool IsPerDept;

        public int DefContactid;

        public int DefDeptId;

        public string WebStorePathB2B_Display = string.Empty;

        public string IsFromWebStore = string.Empty;

        public string WSPathB2B = string.Empty;

        public string WSPathB2C = string.Empty;

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

        static ClientSubSection()
        {
            ClientSubSection.ChangeOrder = 0;
            ClientSubSection.SalesPersonID = string.Empty;
            ClientSubSection.IsEditOnlyHisRecords = string.Empty;
            ClientSubSection.Contactflag = 0;
            ClientSubSection.Filtering = 0;

            ClientContactsSubSection.WhereConditionContact = string.Empty;
            ClientSubSection.WhereConditionDepartment = string.Empty;
        }

        public ClientSubSection()
        {
        }

        public void BindDefaultGrids(int CompanyID, int ClientID)
        {
            this.GridDepartment(CompanyID, ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
            //this.GridContact(CompanyID, ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            this.GridAddress(CompanyID, ClientID);
        }

        public void BindEdirTaskPyorty()
        {
            this.ddlEditPriority.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
            this.ddlEditPriority.Items.Insert(1, this.objLanguage.convert("High"));
            this.ddlEditPriority.Items.Insert(2, this.objLanguage.convert("Low"));
            this.ddlEditPriority.Items.Insert(3, this.objLanguage.convert("Normal"));
            this.ddlEditPriority.Items[0].Value = "";
            this.ddlEditPriority.SelectedIndex = 3;
        }

        public void BindEditStatusDrop()
        {
            taskClass _taskClass = new taskClass();
            this.ddlEditStataus.DataSource = _taskClass.dtrTaskStatus(int.Parse(base.Session["companyID"].ToString()));
            this.ddlEditStataus.DataTextField = "taskStatus";
            this.ddlEditStataus.DataValueField = "taskStatusId";
            this.ddlEditStataus.DataBind();
            this.ddlEditStataus.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
            this.ddlEditStataus.Items[0].Value = "";
            this.ddlEditStataus.SelectedIndex = 4;
        }

        public void BindEditSubJectDropdown()
        {
            try
            {
                this.objSetBase.Bind_Subject(this.ddlEditsubject, this.CompanyID, "---Select---");
            }
            catch
            {
            }
        }

        protected void bindEstoreDetails()
        {
            if (this.web_key != "")
            {
                if (this.web_key.ToLower() != "yes")
                {
                    this.div_b2bMain.Style.Add("display", "none");
                    this.div_B2BMsg.Style.Add("display", "block");
                    this.div_B2B_Button.Visible = false;
                }
                else
                {
                    this.div_b2bMain.Visible = true;
                    string str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "others", this.Page.Request.Url.ToString());
                    if (str == "0" || str == "2")
                    {
                        this.div_b2bMain.Style.Add("display", "none");
                    }
                    if (ConnectionClass.B2BURL == null)
                    {
                        this.div_B2B_Button.Visible = false;
                    }
                    else
                    {
                        foreach (DataRow row in CompanyBasePage.Get_AccountName(this.ClientID).Rows)
                        {
                            this.AccountName = row["accountName"].ToString();
                            this.div_B2B_Button.Visible = false;
                        }
                        this.WSPathB2B = ConnectionClass.B2BURL;
                        this.WebStorePathB2B_Display = string.Concat(this.WSPathB2B, this.AccountName);
                        this.WSPathB2B = string.Concat(this.WSPathB2B, "404.aspx?AccountName=", this.AccountName);
                    }
                    DataTable dataTable = CompanyBasePage.company_client_For_subsection(this.CompanyID, this.ClientID, this.CompanyType);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.AccountID = Convert.ToInt32(dataRow["AccountID"].ToString());
                        this.IsFromWebStore = dataRow["IsFromWebStore"].ToString();
                    }
                }
            }
            if (this.CompanyType.ToLower() == "customer")
            {
                if (this.AccountID != 0)
                {
                    if (this.IsFromWebStore.ToLower() == "store")
                    {
                        this.div_B2C_Link.Style.Add("display", "block");
                        this.lbl_b2ceStoreLink.Text = this.basecls.SpecialDecode(this.WebStorePathB2C);
                        return;
                    }
                    this.div_B2B_Link.Style.Add("display", "block");
                    this.lbl_b2beStoreLink.Text = this.basecls.SpecialDecode(this.WebStorePathB2B_Display);
                    return;
                }
                this.div_B2B_Button.Style.Add("display", "block");
                HtmlControl htmlControl = (HtmlControl)this.FindControl("ifrm_accounts");
                htmlControl.Attributes["src"] = string.Concat(this.strSitepath, "Accounts/account_new_create_withoutTemplate.aspx?from=client&type=Customer&mode=add&clientID=", this.ClientID);
            }
        }

        public void BindPyortyDrop()
        {
            this.ddlpriority.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
            this.ddlpriority.Items.Insert(1, this.objLanguage.convert("High"));
            this.ddlpriority.Items.Insert(2, this.objLanguage.convert("Low"));
            this.ddlpriority.Items.Insert(3, this.objLanguage.convert("Normal"));
            this.ddlpriority.Items[0].Value = "";
            this.ddlpriority.SelectedIndex = 3;
        }

        public void BindStatusDrop()
        {
            taskClass _taskClass = new taskClass();
            this.ddlstatus.DataSource = _taskClass.dtrTaskStatus(int.Parse(base.Session["companyID"].ToString()));
            this.ddlstatus.DataTextField = "taskStatus";
            this.ddlstatus.DataValueField = "taskStatusId";
            this.ddlstatus.DataBind();
            this.ddlstatus.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
            this.ddlstatus.Items[0].Value = "";
            this.ddlstatus.SelectedIndex = 4;
        }

        public void BindSubJectDropdown()
        {
            DataTable dataTable = Settings.settings_subject_select(Convert.ToInt32(this.CompanyID));
            if (dataTable.Rows.Count > 0)
            {
                this.ddlsubject.DataSource = dataTable;
                this.ddlsubject.DataTextField = "sampleSubject";
                this.ddlsubject.DataValueField = "sampleSubjectId";
                this.ddlsubject.DataBind();
                this.ddlsubject.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlsubject.Items[0].Value = "";
                this.ddlsubject.SelectedIndex = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["IsDefault"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                    this.basecls.SetDDLValue(this.ddlsubject, row["sampleSubjectId"].ToString());
                    this.hdnDefaultTaskSubject.Value = row["sampleSubjectId"].ToString();
                }
            }
        }

        public void BintCallContact()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_Contact_select(this.CompanyID, this.ClientID);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                this.ddlCallAssignTo.DataSource = dataSet;
                this.ddlCallAssignTo.DataTextField = "ContactName";
                this.ddlCallAssignTo.DataValueField = "ContactID";
                this.ddlCallAssignTo.DataBind();
                this.ddlEditCallContact.DataSource = dataSet;
                this.ddlEditCallContact.DataTextField = "ContactName";
                this.ddlEditCallContact.DataValueField = "ContactID";
                this.ddlEditCallContact.DataBind();
                this.ddlEditContact.DataSource = dataSet;
                this.ddlEditContact.DataTextField = "ContactName";
                this.ddlEditContact.DataValueField = "ContactID";
                this.ddlEditContact.DataBind();
                this.ddlTaskContacts.DataSource = dataSet;
                this.ddlTaskContacts.DataTextField = "ContactName";
                this.ddlTaskContacts.DataValueField = "ContactID";
                this.ddlTaskContacts.DataBind();
                this.ddlspecificTo.DataSource = dataSet;
                this.ddlspecificTo.DataTextField = "ContactName";
                this.ddlspecificTo.DataValueField = "ContactID";
                this.ddlspecificTo.DataBind();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["DefaultContact"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                    this.basecls.SetDDLValue(this.ddlCallAssignTo, row["ContactID"].ToString());
                    this.basecls.SetDDLValue(this.ddlTaskContacts, row["ContactID"].ToString());
                    this.basecls.SetDDLValue(this.ddlspecificTo, row["ContactID"].ToString());
                }
            }
        }

        public void BonDCallOwner()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_user_select(this.CompanyID, this.UserID, this.SectionID);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                this.ddlassigneto.DataSource = dataSet;
                this.ddlassigneto.DataTextField = "Name";
                this.ddlassigneto.DataValueField = "UserID";
                this.ddlassigneto.DataBind();
                this.ddlowner.DataSource = dataSet;
                this.ddlowner.DataTextField = "Name";
                this.ddlowner.DataValueField = "UserID";
                this.ddlowner.DataBind();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["UserID"].ToString().ToLower() != Convert.ToInt32(this.UserIDN).ToString())
                    {
                        continue;
                    }
                    this.basecls.SetDDLValue(this.ddlassigneto, row["UserID"].ToString());
                    this.basecls.SetDDLValue(this.ddlowner, row["UserID"].ToString());
                }
                this.ddlEditassignto.DataSource = dataSet;
                this.ddlEditassignto.DataTextField = "Name";
                this.ddlEditassignto.DataValueField = "UserID";
                this.ddlEditassignto.DataBind();
                this.ddlEditowner.DataSource = dataSet;
                this.ddlEditowner.DataTextField = "Name";
                this.ddlEditowner.DataValueField = "UserID";
                this.ddlEditowner.DataBind();
            }
        }

        protected void btn_saveDept_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            if (Convert.ToInt32(this.hdn_assignedDeptID.Value) != 0)
            {
                num1 = Convert.ToInt32(this.hdn_assignedDeptID.Value);
            }
            if (base.Request.Cookies["DeleteImage"] != null)
            {
                if (base.Request.Cookies["DeleteImage"].Value != "yes")
                {
                    for (int i = 0; i < this.RadGrid_Department.Items.Count; i++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                        htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Department.Items[i].Cells[0].FindControl("checkBox_Department");
                        if (this.hdn_deptIDs.Value.Length > 0)
                        {
                            string[] strArrays = this.hdn_deptIDs.Value.Split(new char[] { ',' });
                            for (int j = 0; j < (int)strArrays.Length - 1; j++)
                            {
                                num = Convert.ToInt32(strArrays[j]);
                                this.objDept.departmentDelete(this.CompanyID, this.UserID, num, num1);
                                ClientSubSection usercontrolCrmClientSubSection = this;
                                usercontrolCrmClientSubSection.cntDelete = usercontrolCrmClientSubSection.cntDelete + 1;
                            }
                        }
                        htmlInputCheckBox.Checked = false;
                    }
                }
                else if (base.Request.Cookies["DeleteDeptID"] != null)
                {
                    num = Convert.ToInt32(base.Request.Cookies["DeleteDeptID"].Value);
                    this.objDept.departmentDelete(this.CompanyID, this.UserID, num, num1);
                }
                this.get_DeptTab();
                this.RadGrid_Department.Rebind();
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Department_deleted_successfully"), "msg-success", this.plhDepartment);
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (this.redirectFrom.ToLower() == "accounts")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accounts/accounts_view.aspx?type=", this.CompanyType));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx?type=", this.CompanyType));
        }

        protected void btnConvertToCstmr_Click(object sender, EventArgs e)
        {
            this.converttocust.Style.Add("display", "none");
            CompanyBasePage.company_convert_to_customer(Convert.ToInt32(this.hid_ClientID.Value));
            string str = "Customer";
            QueryString queryString = new QueryString()
        {
            { "clientid", this.hid_ClientID.Value },
            { "isnew", "2" },
            { "bypass", "1" },
            { "type", str },
            { "suc", "Cn" }
        };
            string str1 = "client/client_detail.aspx";
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            str1 = string.Concat(str1, queryString1.ToString());
            base.Response.Redirect(string.Concat(this.strSitepath, str1));
        }

        protected void btnCreateAcc_Or_view_Click(object sender, EventArgs e)
        {
            if (this.AccountID == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_new_create.aspx?from=client&type=Customer&mode=add&clientID=", this.ClientID));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_details.aspx?from=client&type=Customer&mode=view&clientID=", this.ClientID));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            CompanyBasePage.company_client_delete(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value));
            base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx?type=", this.CompanyType));
        }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            QueryString queryString = new QueryString()
        {
            { "clientid", this.hid_ClientID.Value },
            { "isnew", "2" },
            { "bypass", "1" },
            { "type", this.CompanyType },
            { "action", "edit" }
        };
            string str = "client/client_add.aspx";
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            str = string.Concat(str, queryString1.ToString());
            base.Response.Redirect(string.Concat(this.strSitepath, str));
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            this.ContactsSection.ClearFilters();
        }

        protected void clrFiltersAddress_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid_Address.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchAddress", this.ClientID)] = null;
            this.WhereConditionAddress = "";
            this.RadGrid_Address.MasterTableView.FilterExpression = string.Empty;
            this.GridAddress(this.CompanyID, this.ClientID);
        }

        protected void clrFiltersDept_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid_Department.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchDepartment", this.ClientID)] = null;
            ClientSubSection.WhereConditionDepartment = "";
            this.RadGrid_Department.MasterTableView.FilterExpression = string.Empty;
            this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
        }

        protected void Deletecostcenter_OnClick(object sender, CommandEventArgs e)
        {
            DepartmentBaseClass.costcenter_details_delete(Convert.ToInt32(e.CommandArgument));
            this.basecls.Message_Display("Cost centre deleted successfully", "msg-success", this.plhCoceCEn);
            this.grdcostcentre.Rebind();
        }

        protected void DeleteImgAddress_OnClick(object sender, CommandEventArgs e)
        {
            this.objcomm.address_delete(this.CompanyID, Convert.ToInt32(e.CommandArgument), this.UserID);
            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Address_deleted_successfully"), "msg-success", this.plhAddress);
            this.GridAddress(this.CompanyID, this.ClientID);
            this.RadGrid_Address.Rebind();
            this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
            this.RadGrid_Department.Rebind();
        }

                protected void DeleteImgDept_OnClick(object sender, CommandEventArgs e)
        {
            if (this.hdn_deptIDs.Value.Length > 0)
            {
                string[] strArrays = this.hdn_deptIDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    int num = Convert.ToInt32(strArrays[i]);
                    this.objDept.departmentDelete(this.CompanyID, this.UserID, num, 0);
                }
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Department_deleted_successfully"), "msg-success", this.plhDepartment);
                this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
                this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            }
        }

        protected void DeleteImgNotesNew_OnClick(object sender, EventArgs e)
        {
            this.objcomm.crm_common_attachment_delete(Convert.ToInt32(this.hdnAttachmentID.Value), this.CompanyID);
            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Note_Deleted_Successfully"), "msg-success", this.plhNotes);
        }

        protected void dlist_Notes_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string empty = string.Empty;
                empty = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("div_Edit");
                if (empty.Trim().ToLower() == "false")
                {
                    htmlControl.Style.Add("display", "none");
                }
                else if (ClientSubSection.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != ClientSubSection.SalesPersonID)
                {
                    htmlControl.Style.Add("display", "none");
                }
                string str = string.Empty;
                str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
                HtmlControl htmlControl1 = (HtmlControl)e.Item.FindControl("div_Delete");
                if (str.Trim().ToLower() != "false")
                {
                    htmlControl1.Style.Add("display", "block");
                }
                else
                {
                    htmlControl1.Style.Add("display", "none");
                }
                int num = 495;
                Label label = (Label)e.Item.FindControl("lbl_Title");
                Label label1 = (Label)e.Item.FindControl("lbl_Subject");
                label1.Text = label1.Text.Replace(Environment.NewLine, "<BR/>");
                label1.Text = label1.Text.Replace(" ", "&nbsp;");
                Label label2 = (Label)e.Item.FindControl("lbl_FileName");
                Label label3 = (Label)e.Item.FindControl("lbl_CreatedOn");
                Image image = (Image)e.Item.FindControl("img_FileName");
                HtmlGenericControl htmlGenericControl = (HtmlGenericControl)e.Item.FindControl("div_More");
                HtmlGenericControl htmlGenericControl1 = (HtmlGenericControl)e.Item.FindControl("div_Notes_WithFileName");
                HtmlGenericControl htmlGenericControl2 = (HtmlGenericControl)e.Item.FindControl("div_Notes_NoFileName");
                Label label4 = (Label)e.Item.FindControl("lbl_NoFileName");
                if (label1.Text.Length < num)
                {
                    htmlGenericControl.Style.Add("display", "none");
                }
                else
                {
                    htmlGenericControl.Style.Add("display", "block");
                }
                if (label.Text == "")
                {
                    label.Visible = false;
                }
                if (label2.Text == "")
                {
                    label4.Text = "";
                    image.Visible = false;
                    htmlGenericControl1.Style.Add("display", "none");
                    htmlGenericControl2.Style.Add("display", "block");
                }
                label3.Text = this.objcom.Eprint_return_Date_Before_View(label3.Text, this.CompanyID, this.UserID, false);
            }
        }

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

        public void FilterStatus()
        {
            this.GridAddress(this.CompanyID, this.ClientID);
        }

        public void get_ActivitiesTab()
        {
            string subTab = "activities";
            HttpCookie tabCookie = base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)];
            if (tabCookie != null && !string.IsNullOrEmpty(tabCookie.Value))
            {
                subTab = tabCookie.Value.ToLower();
            }
            this.SetCrmTabCookie(subTab);
            this.plh_ActivitiesDetails.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/crm/ActivitiesSubSection.ascx");
            userControl.ID = "ActivitiesSubSection";
            this.plh_ActivitiesDetails.Controls.Add(userControl);
            this.ApplyCrmTabLayout(subTab);
            SetDisplay(this.divLoadingImageCus, false);
            this.RefreshCrmSectionUi("records");
        }

        public void get_AddressTab()
        {
            this.MarkCrmTabClickHandled();
            this.SetCrmTabCookie("address");
            this.ApplyCrmTabLayout("address");
            this.EnsureCrmClientContext();
            this.BindAddressTab();
            this.HideCrmLoadingOverlay();
            this.RefreshCrmSectionUi("address");
        }

        public void BindAddressTab()
        {
            this.EnsureCrmClientContext();
            if (this.CompanyID <= 0 || this.ClientID <= 0)
            {
                return;
            }
            this.RadGrid_Address.MasterTableView.FilterExpression = string.Empty;
            this.GridAddress(this.CompanyID, this.ClientID);
            this.RadGrid_Address.Rebind();
        }

        private void EnsureCrmClientContext()
        {
            if (this.CompanyID <= 0 && base.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            }
            if (this.ClientID <= 0 && !string.IsNullOrEmpty(this.hid_ClientID.Value))
            {
                int parsedClientId;
                if (int.TryParse(this.hid_ClientID.Value, out parsedClientId))
                {
                    this.ClientID = parsedClientId;
                }
            }
            if (this.ClientID <= 0)
            {
                try
                {
                    string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                    ArrayList arrayLists = Encryption.querystrvalue(str);
                    this.ClientID = int.Parse(arrayLists[1].ToString());
                    this.hid_ClientID.Value = this.ClientID.ToString();
                }
                catch
                {
                }
            }
        }

        public void get_b2bTab()
        {
            this.MarkCrmTabClickHandled();
            this.SetCrmTabCookie("b2b");
            this.ApplyCrmTabLayout("b2b");
            this.HideCrmLoadingOverlay();
            this.RefreshCrmSectionUi("estore");
        }

        private void SetCrmTabCookie(string tabName)
        {
            if (this.ClientID <= 0)
            {
                return;
            }

            string cookieName = string.Concat("CRMTabName", this.ClientID);
            HttpCookie cookie = base.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName, tabName);
            }
            else
            {
                cookie.Value = tabName;
            }
            base.Response.Cookies.Set(cookie);
            base.Request.Cookies.Set(new HttpCookie(cookieName, tabName));
        }

        private void RefreshCrmSectionUi(string sectionKey)
        {
            string safeKey = (sectionKey ?? string.Empty).Replace("'", string.Empty);
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "crmSec_" + safeKey,
                string.Format("if(window.eprintCrmSections){{window.eprintCrmSections.refresh('{0}');}}", safeKey),
                true);
        }

        public void get_ClientTab()
        {
            this.MarkCrmTabClickHandled();
            this.SetCrmTabCookie("client");
            this.ApplyCrmTabLayout("client");
            this.getAccountID(this.CompanyID, this.ClientID, this.CompanyType);
            this.getClientDetails(this.UserID, this.CompanyID, this.CompanyType, this.ClientID, this.AccountID);
            this.HideCrmLoadingOverlay();
            this.RefreshCrmSectionUi("client");
        }

        public void get_ContactTab()
        {
            this.MarkCrmTabClickHandled();
            this.SetCrmTabCookie("contacts");
            this.ApplyCrmTabLayout("contacts");
            this.EnsureCrmClientContext();
            this.EnsureContactsSection();
            this.ContactsSection.BindContactTab();
            this.HideCrmLoadingOverlay();
            this.RefreshCrmSectionUi("contacts");
        }

        public void get_CostcentreTabs()
        {
            this.SetCrmTabCookie("costcentre");
            this.ApplyCrmTabLayout("costcentre");
            this.loadgrdcostcenter();
            this.RefreshCrmSectionUi("costcentre");
        }

        public void get_DeptTab()
        {
            this.MarkCrmTabClickHandled();
            this.SetCrmTabCookie("dept");
            this.ApplyCrmTabLayout("dept");
            this.EnsureCrmClientContext();
            if (this.CompanyType != "supplier" && this.CompanyType != "prospect")
            {
                SetDisplay(this.div_b2bMain, false);
            }
            this.BindDefaultGrids(this.CompanyID, this.ClientID);
            this.HideCrmLoadingOverlay();
            this.RefreshCrmSectionUi("dept");
        }

        public void get_EmailsTab()
        {
            try
            {
                this.SetCrmTabCookie("emails");
                this.plh_EmailsDetails.Controls.Clear();
                EmailsSubSection emailsSection = (EmailsSubSection)base.LoadControl("~/usercontrol/crm/EmailsSubSection.ascx");
                emailsSection.ID = "EmailsSubSection";
                emailsSection.CompanyID = this.CompanyID;
                emailsSection.ClientID = this.ClientID;
                emailsSection.UserID = this.UserID;
                emailsSection.CompanyType = this.CompanyType;
                emailsSection.CompanyName = this.CompanyCusName;
                this.plh_EmailsDetails.Controls.Add(emailsSection);
                this.ApplyCrmTabLayout("emails");
                emailsSection.BindEmailTab();
                SetDisplay(this.divLoadingImageCus, false);
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "crmHideLoad_emails",
                    "if(typeof hideCrmLoadingOverlay==='function'){hideCrmLoadingOverlay();}",
                    true);
                if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.btn_AddNewEmail.Visible = true;
                }
                else
                {
                    this.btn_AddNewEmail.Visible = false;
                }
                this.RefreshCrmSectionUi("emails");
            }
            catch
            {
                SetDisplay(this.divLoadingImageCus, false);
            }
        }

        public void get_ProductTab()
        {
            try
            {
                this.SetCrmTabCookie("products");
                this.plh_ProductDetails.Controls.Clear();
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/crm/ProductSubSection.ascx");
                userControl.ID = "ProductSubSection";
                this.plh_ProductDetails.Controls.Add(userControl);
                this.ApplyCrmTabLayout("products");
                if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.div_ProductsControls.Visible = true;
                }
                else
                {
                    this.div_ProductsControls.Visible = false;
                }
                this.RefreshCrmSectionUi("products");
            }
            catch
            {
            }
        }

        public void getAccountID(int CompanyID, int ClientID, string CompanyType)
        {
            DataTable dataTable = CompanyBasePage.company_client_For_subsection(CompanyID, ClientID, CompanyType);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.AccountID = Convert.ToInt32(row["AccountID"].ToString());
                }
            }
        }

        public void getClientDetails(int UserID, int CompanyID, string CompanyType, int ClientID, int AccountID)
        {
            if (ConnectionClass.WebStore != null)
            {
                this.web_key = ConnectionClass.WebStore;
            }
            if (ConnectionClass.Tax2 != null)
            {
                this.Tax2 = ConnectionClass.Tax2;
                if (this.Tax2.ToLower() == "yes")
                {
                    this.div_Tax2.Style.Add("display", "block");
                }
            }
            if (!base.IsPostBack && this.web_key != "")
            {
                if (this.web_key.ToLower() != "yes")
                {
                    this.btnCreateAcc_Or_view.Visible = false;
                }
                else
                {
                    this.btnCreateAcc_Or_view.Visible = true;
                }
            }
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                ClientID = int.Parse(arrayLists[1].ToString());
                this.ClientIDTask = ClientID;
                this.companyName = arrayLists[3].ToString();
                CompanyType = arrayLists[7].ToString().ToLower().Trim();
                this.QSsuc = arrayLists[8].ToString();
                this.strSuc = arrayLists[9].ToString();
                try
                {
                    this.isnew = int.Parse(Convert.ToString(arrayLists[3]));
                }
                catch
                {
                }
            }
            catch
            {
            }
            this.converttocust.Style.Add("display", "none");
            if (CompanyType != "")
            {
                this.hid_ClientID.Value = ClientID.ToString();
                if (CompanyType != "supplier")
                {
                    this.div_Supplier.Style.Add("display", "none");
                    this.Div_Carrier.Style.Add("display", "none");
                }
                else
                {
                    this.div_Supplier.Style.Add("display", "block");
                    this.Div_Carrier.Style.Add("display", "block");
                }
                DataTable dataTable = CompanyBasePage.company_client_select(CompanyID, ClientID, CompanyType);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        CompanyType = row["CompanyType"].ToString().ToLower().Trim();
                        if (CompanyType == "prospect")
                        {
                            this.converttocust.Style.Add("display", "block");
                        }
                        CompanyType = row[2].ToString().ToLower().Trim();
                        this.lblCompanyName.Text = this.basecls.SpecialDecode(row["ClientName"].ToString());
                        this.lbltitlecompanyname.Text = this.basecls.SpecialDecode(row["ClientName"].ToString());
                        this.lblCompanyAlias.Text = this.basecls.SpecialDecode(row["ClientAlias"].ToString());
                        this.lblContactname.Text = this.basecls.SpecialDecode(row["DefaultContactName"].ToString());
                        this.lblType.Text = this.basecls.SpecialDecode(row["ctype"].ToString());
                        this.lblAccountStatus.Text = this.basecls.SpecialDecode(row["AccountStatusName"].ToString());
                        if (row["AccountStatusName"].ToString().ToLower() == "account on hold")
                        {
                            this.lblAccountStatus.Style.Add("color", "red");
                        }
                        this.lblAccountNumber.Text = this.basecls.SpecialDecode(row["AccountNumber"].ToString());
                        this.lblCreditLimit.Text = this.basecls.SpecialDecode(row["CreditLimit"].ToString());
                        this.lblCreditRef.Text = this.basecls.SpecialDecode(row["CreditRef"].ToString());
                        this.lblTax1.Text = this.basecls.SpecialDecode(row["TaxName1"].ToString());
                        this.lblTax2.Text = this.basecls.SpecialDecode(row["TaxName2"].ToString());
                        this.lblTaxRegNo.Text = this.basecls.SpecialDecode(row["TaxRegNo"].ToString());
                        this.lblPhoneNumber.Text = this.basecls.SpecialDecode(row["Mobile"].ToString());
                        this.lblPaymentTerms.Text = this.basecls.SpecialDecode(row["PaymentTermName"].ToString());
                        if (row["ProfitMargin"].ToString() != "")
                        {
                            this.lblProfitMargin.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["ProfitMargin"].ToString()), 0, "", false, false, true);
                        }
                        this.lblAcOpened.Text = (row["AcOpeneddate"].ToString() == "01/01/1900" ? "" : this.objcom.Eprint_return_Date_Before_View(row["AcOpeneddate"].ToString(), CompanyID, UserID, false));
                        this.lblBankCode.Text = this.basecls.SpecialDecode(row["BankCode"].ToString());
                        this.lblBankAccountNumber.Text = this.basecls.SpecialDecode(row["BankAccountNumber"].ToString());
                        this.lblAccountName.Text = this.basecls.SpecialDecode(row["AccountName"].ToString());
                        this.lblSalesPerson.Text = this.basecls.SpecialDecode(row["SalesPersonName"].ToString());
                        this.lblTaxNumber.Text = this.basecls.SpecialDecode(row["TaxNumber"].ToString());
                        this.lblBalance.Text = this.basecls.SpecialDecode(row["Balance"].ToString());
                        this.lblDescription.Text = this.basecls.SpecialDecode(row["Description"].ToString());
                        this.lblBusinessEmail.Text = this.basecls.SpecialDecode(row["ContactEmail"].ToString());
                        this.lblURL.Text = this.basecls.SpecialDecode(row["WebSite"].ToString());
                        this.lblActualBusinessEmail.Text = this.basecls.SpecialDecode(row["BusinessEmail"].ToString());
                        this.DeliveryAddressID = Convert.ToInt32(row["DeliveryAddressID"].ToString());
                        this.InvoiceAddressID = Convert.ToInt32(row["InvoiceAddressID"].ToString());
                        this.lblDescription.Text = this.basecls.SpecialDecode(BaseClass.WrapString(this.lblDescription.Text, 250));
                        AccountID = Convert.ToInt32(row["AccountID"].ToString());
                        this.lbl_Referencedby.Text = this.basecls.SpecialDecode(row["ReferencedName"].ToString());
                        if (Convert.ToInt32(row["IsCarrier"]) != 1)
                        {
                            this.lbliscarrier.Text = "No";
                        }
                        else
                        {
                            this.lbliscarrier.Text = "Yes";
                        }
                        if (row["RoyalityFree"].ToString().ToLower() != "true")
                        {
                            this.lblRoyalityFree.Text = "No";
                        }
                        else
                        {
                            this.lblRoyalityFree.Text = "True";
                        }
                    }
                }
            }
            if (CompanyType != "customer")
            {
                this.btnCreateAcc_Or_view.Visible = false;
            }
            else if (AccountID != 0)
            {
                this.btnCreateAcc_Or_view.Text = this.objLangClass.GetLanguageConversion("View_Store_Account");
                return;
            }
        }

        public string GetNextPreviousURL(string ActionType)
        {
            int num = 0;
            if (base.Session["crmdefaultviewid"] != null && base.Session["crmsortby"] != null && base.Session["crmsortdirection"] != null && base.Session["crmpara"] != null)
            {
                string empty = string.Empty;
                viewClass _viewClass = new viewClass();
                empty = _viewClass.ReturnFinalQueryForNewCustomView(this.CompanyID, this.UserID, 10000, 1, this.CompanyType, Convert.ToInt32(base.Session["crmdefaultviewid"]), base.Session["crmsortby"].ToString(), base.Session["crmsortdirection"].ToString(), base.Session["crmpara"].ToString());
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                sqlCommand.Parameters.AddWithValue("@strSQL", empty);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                _commonClass.closeConnection();
                DataTable item = dataSet.Tables[0];
                if (item.Rows.Count > 0)
                {
                    DataRow[] dataRowArray = item.Select(string.Concat("ClientID=", this.ClientID));
                    int num1 = item.Rows.IndexOf(dataRowArray[0]);
                    if (ActionType == "next")
                    {
                        if (num1 < item.Rows.Count - 1 && item.Rows[num1 + 1] != null)
                        {
                            DataRow dataRow = item.Rows[num1 + 1];
                            num = Convert.ToInt32(dataRow["ClientID"]);
                            if (num1 == item.Rows.Count - 2)
                            {
                                base.Session["IsLastNextRecord"] = "true";
                            }
                        }
                    }
                    else if (num1 > 0 && item.Rows[num1 - 1] != null)
                    {
                        DataRow item1 = item.Rows[num1 - 1];
                        num = Convert.ToInt32(item1["ClientID"]);
                        if (num1 == 1)
                        {
                            base.Session["IsLastPreviousRecord"] = "true";
                        }
                    }
                }
            }
            string str = string.Empty;
            if (num.ToString() != "0")
            {
                QueryString queryString = new QueryString()
            {
                { "clientid", num.ToString() },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", this.CompanyType }
            };
                str = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str = string.Concat(str, queryString1.ToString());
            }
            else
            {
                base.Session["NoMoreDateLoad"] = "Yes";
            }
            return str;
        }

        protected void grdcostcenter_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                this.WhereConditionCostcenter = "";
                if (base.Session[string.Concat("searchCostcenter", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchCostcenter", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchCostcenter", this.ClientID)];
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
                base.Session[string.Concat("searchCostcenter", this.ClientID)] = dataTable;
                this.WhereConditionCostcenter = this.FilterFunction(dataTable);
                this.loadgrdcostcenter();
                this.grdcostcentre.Rebind();
            }
        }

        protected void grdcostcenter_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridEditableItem item = (GridEditableItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                item.FindControl("chk_CostDefault");
                item.FindControl("hdn_Defaultcostcenter");
            }
            try
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Default");
                Image image = (Image)e.Item.FindControl("img_Default");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgbtnDelete");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkBox_costcenter");
                if(hiddenField != null)
                {
                    if (hiddenField.Value != "True")
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                        htmlInputCheckBox.Disabled = true;
                    }
                }

            }
            catch (Exception exception)
            {
            }
        }

        public void grdcostcentre_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = DepartmentBaseClass.costcenter_getdetails(this.CompanyID, this.ClientID);
            this.grdcostcentre.DataSource = dataTable;
        }

        public void GridAddress(int CompanyID, int ClientID)
        {
            if (CompanyID <= 0 || ClientID <= 0)
            {
                return;
            }
            this.dt_Address = DepartmentBaseClass.address_select_for_filter(ClientID, CompanyID, "Yes", this.WhereConditionAddress ?? string.Empty);
            this.RadGrid_Address.DataSource = this.dt_Address ?? new DataTable();
        }

                protected void RadGrid_Department_PreRender(object sender, EventArgs e)
        {
            if (this.ds_Department != null)
            {
                this.RadGrid_Department.DataSource = this.ds_Department.Tables[0];
                this.RadGrid_Department.VirtualItemCount = Convert.ToInt32(this.ds_Department.Tables[1].Rows[0][0]);
                if (this.ds_Department.Tables[0].Rows.Count == 0)
                {
                    this.RadGrid_Department.VirtualItemCount = 0;
                    this.RadGrid_Department.AllowCustomPaging = false;
                }
                this.RadGrid_Department.Rebind();
            }
            else
            {
                this.RadGrid_Department.VirtualItemCount = Convert.ToInt32(this.RadGrid_Department.MasterTableView.Items.Count.ToString());
                this.RadGrid_Department.MasterTableView.AllowPaging = true;
                this.RadGrid_Department.Rebind();
            }
        }

                public void GridDepartment(int CompanyID, int ClientID, int pageno, int pagesize)
        {
            this.RadGrid_Department.AllowCustomPaging = true;
            //this.ds_Department = DepartmentBaseClass.department_getAllDetails_for_filter(CompanyID, this.UserID, ClientID, (long)0, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize, this.WhereConditionDepartment);
            this.ds_Department = DepartmentBaseClass.department_getAllDetails_for_filter(CompanyID, this.UserID, ClientID, (long)0, pageno, pagesize, ClientSubSection.WhereConditionDepartment);
            this.RadGrid_Department.DataSource = this.ds_Department.Tables[0];
            this.RadGrid_Department.VirtualItemCount = Convert.ToInt32(this.ds_Department.Tables[1].Rows[0][0]);
            if (this.ds_Department.Tables[0].Rows.Count == 0)
            {
                this.RadGrid_Department.VirtualItemCount = 0;
                this.RadGrid_Department.AllowCustomPaging = false;
            }
            this.RadGrid_Department.Rebind();
        }

        protected void GridView2_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnFirstLastName");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnLastName");
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnContactID");
                    AttributeCollection attributes = ((HtmlAnchor)e.Item.FindControl("Contacts")).Attributes;
                    string[] strArrays = new string[] { "javascript:SelectContact('", this.basecls.SpecialEncode(hiddenField.Value), " ", this.basecls.SpecialEncode(hiddenField1.Value), "','", hiddenField2.Value, "');" };
                    attributes.Add("onclick", string.Concat(strArrays));
                }
            }
            catch
            {
            }
        }

        public void GroupCallPurpose()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_Select_CallPurpose(this.CompanyID);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                this.ddlCallSubject.DataSource = dataSet;
                this.ddlCallSubject.DataTextField = "StatusTitle";
                this.ddlCallSubject.DataValueField = "Id";
                this.ddlCallSubject.DataBind();
                this.ddlCallSubject.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlCallSubject.Items[0].Value = "";
                this.ddlCallSubject.SelectedIndex = 0;
                this.ddlCallSubjectEdit.DataSource = dataSet;
                this.ddlCallSubjectEdit.DataTextField = "StatusTitle";
                this.ddlCallSubjectEdit.DataValueField = "Id";
                this.ddlCallSubjectEdit.DataBind();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["Isdefault"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                    this.basecls.SetDDLValue(this.ddlCallSubject, row["id"].ToString());
                    this.hdnDefaultCallSubject.Value = row["id"].ToString();
                }
                this.ddleditCallPurpose.DataSource = dataSet;
                this.ddleditCallPurpose.DataTextField = "StatusTitle";
                this.ddleditCallPurpose.DataValueField = "Id";
                this.ddleditCallPurpose.DataBind();
            }
        }

        private static string InsertAtIntervals(string s, int interval, string value)
        {
            if (s == null || s.Length <= interval)
            {
                return s;
            }
            StringBuilder stringBuilder = new StringBuilder(s);
            for (int i = interval * ((s.Length - 1) / interval); i > 0; i = i - interval)
            {
                stringBuilder.Insert(i, value);
            }
            return stringBuilder.ToString();
        }

        protected void lnk_ActivitiesTab_Click(object sender, EventArgs e)
        {
            if (this.IsCrmCustomerType())
            {
                this.get_ClientTab();
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:OpeneRecordsDiv();", true);
            this.get_ActivitiesTab();
        }

        protected void lnk_AddressTab_Click(object sender, EventArgs e)
        {
            this.get_AddressTab();
        }

        protected void lnk_b2bTab_Click(object sender, EventArgs e)
        {
            this.MarkCrmTabClickHandled();
            this.get_b2bTab();
        }

        protected void lnk_ClientTab_Click(object sender, EventArgs e)
        {
            this.get_ClientTab();
        }

        protected void LnkSummary_Click(object sender, EventArgs e)
        {
            this.get_ClientTab();
        }

        protected void lnkAddressBook_Click(object sender, EventArgs e)
        {
            this.get_AddressTab();
        }

        protected void lnk_ContactTab_Click(object sender, EventArgs e)
        {
            this.get_ContactTab();
            //          //modifications by bilal
            //          CompanyBasePage.company_convert_to_customer(Convert.ToInt32(this.hid_ClientID.Value));
            //          string str = "Customer";
            //          QueryString queryString = new QueryString()
            //{
            //	{ "clientid", this.hid_ClientID.Value },
            //	{ "isnew", "2" },
            //	{ "bypass", "1" },
            //	{ "type", str },
            //	{ "suc", "Cn" }
            //};
            //          string str1 = "client/client_detail.aspx";
            //          QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            //          str1 = string.Concat(str1, queryString1.ToString());
            //          base.Response.Redirect(string.Concat(this.strSitepath, str1));
        }

        protected void lnk_CostCenterTab_Click(object sender, EventArgs e)
        {
            if (this.IsCrmCustomerType())
            {
                this.get_ClientTab();
                return;
            }
            this.get_CostcentreTabs();
            this.loadgrdcostcenter();
        }

        protected void lnk_DeptTab_Click(object sender, EventArgs e)
        {
            this.get_DeptTab();
        }

        protected void lnk_EmailsTab_Click(object sender, EventArgs e)
        {
            if (this.IsCrmCustomerType())
            {
                this.get_ClientTab();
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:OpeneEmailDiv();", true);
            this.get_EmailsTab();
        }

        protected void lnk_NotesTab_Click(object sender, EventArgs e)
        {
        }

        protected void lnk_ProductsTab_Click(object sender, EventArgs e)
        {
            if (this.IsCrmCustomerType())
            {
                this.get_ClientTab();
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:OpeneProductsDiv();", true);
            this.get_ProductTab();
        }

        protected void lnk_SortDirection_OnClick(object sender, EventArgs e)
        {
            if (ClientSubSection.ChangeOrder == 0)
            {
                ClientSubSection.ChangeOrder = 1;
                return;
            }
            ClientSubSection.ChangeOrder = 0;
        }

        protected void lnkdeletecostcentre_Onclick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdncostcenterids.Value.ToString().Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    DepartmentBaseClass.costcenter_details_delete(Convert.ToInt32(strArrays[i]));
                    this.basecls.Message_Display("Cost centre deleted successfully", "msg-success", this.plhCoceCEn);
                }
            }
            this.grdcostcentre.Rebind();
        }

        protected void lnkNextClientRecord_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(this.GetNextPreviousURL("next"));
        }

        protected void lnkPreviousClientRecord_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(this.GetNextPreviousURL("previous"));
        }

        protected void lnlClerCostFilter_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.grdcostcentre.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchCostcenter", this.ClientID)] = null;
            this.WhereConditionCostcenter = "";
            this.grdcostcentre.MasterTableView.FilterExpression = string.Empty;
            this.loadgrdcostcenter();
        }

        public void loadgrdcostcenter()
        {
            base.Session["dt"] = null;
            DataTable dataTable = DepartmentBaseClass.costcenter_getdetails_for_filter(this.CompanyID, this.ClientID, this.WhereConditionCostcenter);
            base.Session["dt"] = dataTable;
            this.grdcostcentre.DataSource = dataTable;
            this.grdcostcentre.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.EnsureContactsSection();
            GridFilterMenu gridFilterMenu = this.RadGrid_Department.FilterMenu;
            for (int j = gridFilterMenu.Items.Count - 1; j >= 0; j--)
            {
                string lower1 = gridFilterMenu.Items[j].Text.ToLower();
                string str1 = lower1;
                if (lower1 != null)
                {
                    switch (str1)
                    {
                        case "custom":
                            {
                                gridFilterMenu.Items[j].Text = "Custom-Text (ThisWeek)";
                                break;
                            }
                        case "isempty":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "notisempty":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "isnull":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "notisnull":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "between":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "notbetween":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "notequalto":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "greaterthan":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "lessthan":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "greaterthanorequalto":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                        case "lessthanorequalto":
                            {
                                gridFilterMenu.Items[j].Visible = false;
                                break;
                            }
                    }
                }
            }
            GridFilterMenu filterMenu1 = this.RadGrid_Address.FilterMenu;
            for (int k = filterMenu1.Items.Count - 1; k >= 0; k--)
            {
                string lower2 = filterMenu1.Items[k].Text.ToLower();
                string str2 = lower2;
                if (lower2 != null)
                {
                    switch (str2)
                    {
                        case "custom":
                            {
                                filterMenu1.Items[k].Text = "Custom-Text (ThisWeek)";
                                break;
                            }
                        case "isempty":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "notisempty":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "isnull":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "notisnull":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "between":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "notbetween":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "notequalto":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "greaterthan":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "lessthan":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "greaterthanorequalto":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                        case "lessthanorequalto":
                            {
                                filterMenu1.Items[k].Visible = false;
                                break;
                            }
                    }
                }
            }
            GridFilterMenu gridFilterMenu1 = this.grdcostcentre.FilterMenu;
            for (int l = gridFilterMenu1.Items.Count - 1; l >= 0; l--)
            {
                string lower3 = gridFilterMenu1.Items[l].Text.ToLower();
                string str3 = lower3;
                if (lower3 != null)
                {
                    switch (str3)
                    {
                        case "custom":
                            {
                                gridFilterMenu1.Items[l].Text = "Custom-Text (ThisWeek)";
                                break;
                            }
                        case "isempty":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "notisempty":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "isnull":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "notisnull":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "between":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "notbetween":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "notequalto":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "greaterthan":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "lessthan":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "greaterthanorequalto":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                        case "lessthanorequalto":
                            {
                                gridFilterMenu1.Items[l].Visible = false;
                                break;
                            }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] strArrays;
            object[] languageConversion;
            this.SectionName = "client";
            this.EnsureContactsSection();
            this.UserIDN = Convert.ToInt32(base.Session["UserID"]);
            if (ConnectionClass.ServerName.ToString().ToLower() == "coralcoast")
            {
                this.DivChkRoyalityFree.Style.Add("display", "block");
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            this.RadGrid_Address.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Address_Label").ToString();
            this.RadGrid_Address.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Address").ToString();
            this.RadGrid_Address.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Telephone").ToString();
            this.RadGrid_Address.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("PO_Box").ToString();
            this.RadGrid_Address.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
            this.grdcostcentre.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Code");
            this.grdcostcentre.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Name");
            this.grdcostcentre.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Default");
            this.grdcostcentre.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Action");
            this.grdcostcentre.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_records_To_Display");
            this.RadListBox_Department.Items[0].Text = this.objLangClass.GetLanguageConversion("Activate_Spend_Limit");
            this.RadListBox_Department.Items[1].Text = this.objLangClass.GetLanguageConversion("Deactivate_Spend_Limit");
            this.RadListBox_Department.Items[2].Text = this.objLangClass.GetLanguageConversion("Delete");
                        this.ContactsSection.ApplyListBoxLabels();
            this.RadListBox_Address.Items[0].Text = this.objLangClass.GetLanguageConversion("Delete");
            this.ImageButton9.ToolTip = this.objLangClass.GetLanguageConversion("Add_new_subject");
            this.LinkButton26.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.LinkButton29.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.LinkButton28.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.LinkButton22.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.btnDelEdit.Text = this.objLangClass.GetLanguageConversion("Edit");
            this.btnDelDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.btndetComplete.Text = this.objLangClass.GetLanguageConversion("Complete");
            this.LinkButton27.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.btnDetailsEdit.Text = this.objLangClass.GetLanguageConversion("Edit");
            this.btndeleteDetNotes.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.btnviewdetattachedfile.Text = this.objLangClass.GetLanguageConversion("View_Attached_File");
            this.LnkCloseTaskPopup.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.ImageButton9.ToolTip = this.objLangClass.GetLanguageConversion("Add_new_subject");
            this.lnlcloseAddnotepopup.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Back");
            this.btnEdit.Text = this.objLangClass.GetLanguageConversion("Edit");
            this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.btnConvertToCstmr.Text = this.objLangClass.GetLanguageConversion("Progress_to_Customer");
            this.btnSearch.Text = this.objLangClass.GetLanguageConversion("Search");
            this.btnsavetasks.Text = this.objLangClass.GetLanguageConversion("Save");
            this.lnkSaveSubject.Text = this.objLangClass.GetLanguageConversion("Save");
            this.Button1.Text = this.objLangClass.GetLanguageConversion("Print_Options");
            this.LnkSummary.Text = this.objLangClass.GetLanguageConversion("Summary_Information");
            this.lnkDepartment.Text = this.objLangClass.GetLanguageConversion("Departments");
            this.lnlCostCentre.Text = this.objLangClass.GetLanguageConversion("Cost_Centres");
            this.lnkContact.Text = this.objLangClass.GetLanguageConversion("Contacts");
            this.lnkAddressBook.Text = this.objLangClass.GetLanguageConversion("Address_Book");
            this.lnkEstore.Text = this.objLangClass.GetLanguageConversion("eStore");
            this.lnlProducts.Text = this.objLangClass.GetLanguageConversion("Products");
            this.lnkEmail.Text = this.objLangClass.GetLanguageConversion("Emails");
            this.lnkRecords.Text = this.objLangClass.GetLanguageConversion("Records");
            this.ddlCallType.Items[0].Text = this.objLangClass.GetLanguageConversion("Inbound");
            this.ddlCallType.Items[1].Text = this.objLangClass.GetLanguageConversion("Outbound");
            this.ddlCallDetailsType.Items[0].Text = this.objLangClass.GetLanguageConversion("Completed_Call");
            this.ddlCallDetailsType.Items[1].Text = this.objLangClass.GetLanguageConversion("Scheduled_Call");
            this.btnFinalSearch.Text = this.objLangClass.GetLanguageConversion("Search");
            this.btnClear.Text = this.objLangClass.GetLanguageConversion("Clear");
            this.LinkButton25.ToolTip = this.objLangClass.GetLanguageConversion("Close");
            this.btnCloseCallPopup.Text = this.objLangClass.GetLanguageConversion("Close");
            this.btnSaveCall.Text = this.objLangClass.GetLanguageConversion("Save");
            this.ChkBillable.Text = this.objLangClass.GetLanguageConversion("Billable");
            this.bynBackCallPopup.Text = this.objLangClass.GetLanguageConversion("Back");
            this.btnSaveCall1.Text = this.objLangClass.GetLanguageConversion("Save");
            this.imgeditaddcontact.ToolTip = this.objLangClass.GetLanguageConversion("Add_new_subject");
            this.LinkButton13.ToolTip = this.objLangClass.GetLanguageConversion("Slide_Right");
            this.btnEditCloseTask.Text = this.objLangClass.GetLanguageConversion("Close");
            this.btnEditUpdateTask.Text = this.objLangClass.GetLanguageConversion("Save");
            this.Button8.Text = this.objLangClass.GetLanguageConversion("Back");
            this.btnEditUpdateTask1.Text = this.objLangClass.GetLanguageConversion("Save");
            this.lnlAddSub.Text = this.objLangClass.GetLanguageConversion("Save");
            this.ddlEditCallType.Items[0].Text = this.objLangClass.GetLanguageConversion("Inbound");
            this.ddlEditCallType.Items[1].Text = this.objLangClass.GetLanguageConversion("Outbound");
            this.ddlEditCallDetails.Items[0].Text = this.objLangClass.GetLanguageConversion("Completed_Call");
            this.ddlEditCallDetails.Items[1].Text = this.objLangClass.GetLanguageConversion("Scheduled_Call");
            this.LinkButton20.ToolTip = this.objLangClass.GetLanguageConversion("Slide_Right");
            this.Button18.Text = this.objLangClass.GetLanguageConversion("Close");
            this.btnUpdateEditcall.Text = this.objLangClass.GetLanguageConversion("Save");
            this.ChkEditBillable.Text = this.objLangClass.GetLanguageConversion("Billable");
            this.bynBacksCallPopup.Text = this.objLangClass.GetLanguageConversion("Back");
            this.btnUpdateEditcall1.Text = this.objLangClass.GetLanguageConversion("Save");
            this.BtnNotesSave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnUpdateAllNotes.Text = this.objLangClass.GetLanguageConversion("Update");
            this.btnUpdateNotes.Text = this.objLangClass.GetLanguageConversion("Update");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.btn_b2bCreate.Text = this.objLangClass.GetLanguageConversion("Create_B2B_Estore");
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            if (dataTable.Rows.Count > 0 && Convert.ToBoolean(dataTable.Rows[0]["IsDisplayCostCentre"]) && !this.IsCrmCustomerType())
            {
                this.DivlnlCostCentre.Style.Add("display", "block");
            }
            if (!base.IsPostBack)
            {
                if (this.web_key != "")
                {
                    if (this.web_key.ToLower() != "yes")
                    {
                        this.btnCreateAcc_Or_view.Visible = false;
                    }
                    else
                    {
                        this.btnCreateAcc_Or_view.Visible = true;
                    }
                }
                if (ConnectionClass.Tax2 != null)
                {
                    this.Tax2 = ConnectionClass.Tax2;
                    if (this.Tax2.ToLower() != "yes")
                    {
                        this.Label20.Text = this.objLangClass.GetLanguageConversion("Tax");
                    }
                    else
                    {
                        this.div_Tax2.Style.Add("display", "block");
                    }
                }
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.WebStore != null)
            {
                this.web_key = ConnectionClass.WebStore;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.B2CURL != null)
            {
                this.WebStorePathB2C = ConnectionClass.B2CURL.ToString();
                this.WebStorePathB2C = string.Concat(this.WebStorePathB2C, "login", this.FileExtension);
            }
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                this.ClientID = int.Parse(arrayLists[1].ToString());
                this.SectionID = this.ClientID;
                base.Session["ClientID"] = arrayLists[1].ToString();
                this.CompanyType = arrayLists[7].ToString().ToLower().Trim();
                this.CompanyName = arrayLists[3].ToString();
                this.redirectFrom = arrayLists[9].ToString();
                this.UniqueID = arrayLists[9].ToString();
                this.Types = arrayLists[11].ToString();
                this.TaskId = Convert.ToInt16(arrayLists[9]);
                this.ActivityType = arrayLists[11].ToString();
            }
            catch
            {
            }
            this.RefreshContactsContext();
            if (this.UniqueID == "" && this.Types == "")
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:SetContentWidth();", true);
            }
            else if (base.Session["Popup"] == null)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:SetContentWidth();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:$(document).ready(function(){SetContentWidthPopup();});", true);
                base.Session["Popup"] = null;
            }
            if (ConnectionClass.B2BURL != null)
            {
                this.WebStorePathB2B = ConnectionClass.B2BURL.ToString();
                this.WebStorePathB2B = string.Concat(this.WebStorePathB2B, "login", this.FileExtension);
            }
            if (this.CompanyType == "prospect")
            {
                this.divlnkEstore.Style.Add("display", "none");
                this.DivlnlProducts.Style.Add("display", "none");
                this.div_ActivitiesMain.Attributes.Add("style", "display:block");
                this.tablemainpanel.Style.Add("width", "101%");
                this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete_Prospect");
            }
            else if (this.CompanyType != "supplier")
            {
                this.div_ActivitiesMain.Attributes.Add("style", "display:none");
                this.tablemainpanel.Style.Add("width", "101%");
                if (this.IsCrmCustomerType())
                {
                    this.HideProductsEmailsRecordsNav();
                    if (string.Equals(this.strSuc, "products", StringComparison.OrdinalIgnoreCase))
                    {
                        this.strSuc = string.Empty;
                    }
                }
            }
            else
            {
                this.divlnkEstore.Style.Add("display", "none");
                this.DivlnlProducts.Style.Add("display", "none");
                this.DivlnkRecords.Style.Add("display", "none");
                this.DivlnlCostCentre.Style.Add("display", "none");
                this.div_ActivitiesMain.Attributes.Add("style", "display:none");
                this.tablemainpanel.Style.Add("width", "101%");
                this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete_Supplier");
            }
            DataTable dataTable1 = DepartmentBaseClass.department_getDeptNameID(this.CompanyID, this.UserID, this.ClientID, (long)0);
            if (dataTable1.Rows.Count > 0)
            {
                this.ddl_deptList.DataSource = dataTable1;
                this.ddl_deptList.DataTextField = "deptName";
                this.ddl_deptList.DataValueField = "deptID";
                this.ddl_deptList.DataBind();
            }
            DataTable dataTable2 = CompanyBasePage.company_client_For_subsection(this.CompanyID, this.ClientID, this.CompanyType);
            if (dataTable2.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable2.Rows)
                {
                    this.AccountID = Convert.ToInt32(row["AccountID"].ToString());
                    ClientSubSection.SalesPersonID = row["SalesPerson"].ToString();
                    this.CompanyCusName = row["clientName"].ToString();
                }
            }
            this.ContactsSection.RadListboxActiverStoreUser.Style.Add("display", "none");
            this.ContactsSection.RadListboxDeActiverStoreUser.Style.Add("display", "none");
            DataTable dataTableStoreCredit = SettingsBasePage.Setting_StoreCredit_Select(AccountID, CompanyID);
            foreach (DataRow row in dataTableStoreCredit.Rows)
            {
                if (Convert.ToBoolean(row["IsStoreCreditsEnabled"]))
                {
                    this.ContactsSection.RadListboxActiverStoreUser.Style.Add("display", "block");
                    this.ContactsSection.RadListboxDeActiverStoreUser.Style.Add("display", "block");
                }


            }
            DataTable dataTable3 = SettingsBasePage.Setting_SpendLimit_Select((long)this.AccountID, (long)this.CompanyID);
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                this.IsSpendLimitEnable = Convert.ToBoolean(dataRow["IsSpendlimitEnabled"]);
                this.IsPeruser = Convert.ToBoolean(dataRow["IsForUser"]);
                this.IsPerDept = Convert.ToBoolean(dataRow["IsForDepartment"]);
            }
            if (!this.IsSpendLimitEnable)
            {
                this.RadGrid_Department.MasterTableView.GetColumn("SpendLimit").Display = false;
                this.RadGrid_Contact.MasterTableView.GetColumn("SpendLimit").Display = false;
                this.RadGrid_Department.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Department_Name").ToString();
                this.RadGrid_Department.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address").ToString();
                this.RadGrid_Department.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Invoice_Address").ToString();
                this.RadGrid_Department.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address_Phone").ToString();
                this.RadGrid_Department.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Approver").ToString();
                this.RadGrid_Department.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                this.RadGrid_Department.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                this.RadGrid_Contact.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Name").ToString();
                this.RadGrid_Contact.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Department").ToString();
                this.RadGrid_Contact.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title1").ToString();
                this.RadGrid_Contact.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Email").ToString();
                this.RadGrid_Contact.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Department_Phone").ToString();
                this.RadGrid_Contact.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Mobile").ToString();
                this.RadGrid_Contact.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Status").ToString();
                this.RadGrid_Contact.Columns[10].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_and_Approver").ToString();
                this.RadGrid_Contact.Columns[11].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                this.RadGrid_Contact.Columns[12].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                this.RadGrid_Contact.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Phone").ToString();
                this.RadGrid_Contact.Columns[0].HeaderStyle.Width = 50;
                this.RadGrid_Contact.Columns[1].HeaderStyle.Width = 120;
                this.RadGrid_Contact.Columns[2].HeaderStyle.Width = 120;
                this.RadGrid_Contact.Columns[3].HeaderStyle.Width = 120;
                this.RadGrid_Contact.Columns[4].HeaderStyle.Width = 145;
                this.RadGrid_Contact.Columns[5].HeaderStyle.Width = 140;
                this.RadGrid_Contact.Columns[6].HeaderStyle.Width = 130;
                this.RadGrid_Contact.Columns[7].HeaderStyle.Width = 120;
                this.RadGrid_Contact.Columns[8].HeaderStyle.Width = 120;
                this.RadGrid_Contact.Columns[9].HeaderStyle.Width = 80;
                this.RadGrid_Contact.Columns[10].HeaderStyle.Width = 100;
                this.RadGrid_Contact.Columns[11].HeaderStyle.Width = 100;
                this.RadGrid_Contact.Columns[12].HeaderStyle.Width = 80;
                this.RadGrid_Contact.Columns[5].FilterControlWidth = 100;
            }
            else
            {
                if (!this.IsPerDept)
                {
                    this.RadGrid_Department.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Department_Name").ToString();
                    this.RadGrid_Department.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address").ToString();
                    this.RadGrid_Department.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Invoice_Address").ToString();
                    this.RadGrid_Department.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address_Phone").ToString();
                    this.RadGrid_Department.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Approver").ToString();
                    this.RadGrid_Department.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                    this.RadGrid_Department.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                    this.RadGrid_Department.MasterTableView.GetColumn("SpendLimit").Display = false;
                }
                else
                {
                    this.RadGrid_Department.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Department_Name").ToString();
                    this.RadGrid_Department.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address").ToString();
                    this.RadGrid_Department.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Invoice_Address").ToString();
                    this.RadGrid_Department.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Address_Phone").ToString();
                    this.RadGrid_Department.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Spend_Limit").ToString();
                    this.RadGrid_Department.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Approver").ToString();
                    this.RadGrid_Department.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                    this.RadGrid_Department.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                    this.RadGrid_Contact.MasterTableView.GetColumn("SpendLimit").Display = false;
                    this.DeptSpendlimit.Style.Add("display", "block");
                    this.DeptSpendlimitDeactivate.Style.Add("display", "block");
                    this.RadGrid_Department.Columns[0].HeaderStyle.Width = 50;
                    this.RadGrid_Department.Columns[1].HeaderStyle.Width = 125;
                    this.RadGrid_Department.Columns[2].HeaderStyle.Width = 125;
                    this.RadGrid_Department.Columns[3].HeaderStyle.Width = 125;
                    this.RadGrid_Department.Columns[4].HeaderStyle.Width = 145;
                    this.RadGrid_Department.Columns[5].HeaderStyle.Width = 120;
                    this.RadGrid_Department.Columns[6].HeaderStyle.Width = 100;
                    this.RadGrid_Department.Columns[7].HeaderStyle.Width = 80;
                    this.RadGrid_Department.Columns[8].HeaderStyle.Width = 60;
                }
                if (!this.IsPeruser)
                {
                    this.RadGrid_Contact.MasterTableView.GetColumn("SpendLimit").Display = false;
                    this.RadGrid_Contact.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Name").ToString();
                    this.RadGrid_Contact.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Department").ToString();
                    this.RadGrid_Contact.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title1").ToString();
                    this.RadGrid_Contact.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Email").ToString();
                    this.RadGrid_Contact.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Department_Phone").ToString();
                    this.RadGrid_Contact.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Mobile").ToString();
                    this.RadGrid_Contact.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Status").ToString();
                    this.RadGrid_Contact.Columns[10].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_and_Approver").ToString();
                    this.RadGrid_Contact.Columns[11].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                    this.RadGrid_Contact.Columns[12].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                    this.RadGrid_Contact.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Phone").ToString();
                    this.RadGrid_Contact.Columns[0].HeaderStyle.Width = 50;
                    this.RadGrid_Contact.Columns[1].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[2].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[3].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[4].HeaderStyle.Width = 145;
                    this.RadGrid_Contact.Columns[5].HeaderStyle.Width = 140;
                    this.RadGrid_Contact.Columns[6].HeaderStyle.Width = 130;
                    this.RadGrid_Contact.Columns[7].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[8].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[9].HeaderStyle.Width = 80;
                    this.RadGrid_Contact.Columns[10].HeaderStyle.Width = 100;
                    this.RadGrid_Contact.Columns[11].HeaderStyle.Width = 100;
                    this.RadGrid_Contact.Columns[12].HeaderStyle.Width = 80;
                    this.RadGrid_Contact.Columns[5].FilterControlWidth = 100;
                }
                else
                {
                    this.RadGrid_Contact.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Name").ToString();
                    this.RadGrid_Contact.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Department").ToString();
                    this.RadGrid_Contact.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title1").ToString();
                    this.RadGrid_Contact.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Email").ToString();
                    this.RadGrid_Contact.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Department_Phone").ToString();
                    this.RadGrid_Contact.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Mobile").ToString();
                    this.RadGrid_Contact.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Spend_Limit").ToString();
                    this.RadGrid_Contact.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Status").ToString();
                    this.RadGrid_Contact.Columns[10].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_and_Approver").ToString();
                    this.RadGrid_Contact.Columns[11].HeaderText = this.objLangClass.GetLanguageConversion("Default").ToString();
                    this.RadGrid_Contact.Columns[12].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
                    this.RadGrid_Contact.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Phone").ToString();
                    this.RadGrid_Department.MasterTableView.GetColumn("SpendLimit").Display = false;
                    this.ContactsSection.UserSpendlimit.Style.Add("display", "block");
                    this.ContactsSection.UserSpendlimitDeactivate.Style.Add("display", "block");
                    this.RadGrid_Contact.Columns[0].HeaderStyle.Width = 50;
                    this.RadGrid_Contact.Columns[1].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[2].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[3].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[4].HeaderStyle.Width = 145;
                    this.RadGrid_Contact.Columns[5].HeaderStyle.Width = 140;
                    this.RadGrid_Contact.Columns[6].HeaderStyle.Width = 130;
                    this.RadGrid_Contact.Columns[7].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[8].HeaderStyle.Width = 120;
                    this.RadGrid_Contact.Columns[9].HeaderStyle.Width = 80;
                    this.RadGrid_Contact.Columns[10].HeaderStyle.Width = 100;
                    this.RadGrid_Contact.Columns[11].HeaderStyle.Width = 100;
                    this.RadGrid_Contact.Columns[12].HeaderStyle.Width = 80;
                    this.RadGrid_Contact.Columns[5].FilterControlWidth = 100;
                }
            }
            foreach (DataRow row1 in DepartmentBaseClass.IsApprovalSystem_Enable(this.AccountID).Rows)
            {
                this.IsApprovalSystemEnable = Convert.ToBoolean(row1["IsActive"]);
            }
            if (!this.IsApprovalSystemEnable)
            {
                this.RadGrid_Department.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Approver").ToString();
            }
            if (!base.IsPostBack)
            {
                if (this.CompanyType != "customer")
                {
                    this.btnCreateAcc_Or_view.Visible = false;
                }
                else if (this.AccountID != 0)
                {
                    this.btnCreateAcc_Or_view.Text = this.objLangClass.GetLanguageConversion("View_Store_Account");
                }
                if (this.redirectFrom == "email")
                {
                    this.div_EmailMain.Style.Add("display", "block");
                    this.div_ClientMain.Style.Add("display", "none");
                    this.get_EmailsTab();
                }
                if (base.Request.Cookies["ContactFiterState"] != null)
                {
                    base.Request.Cookies["ContactFiterState"].Value = null;
                }
                if (base.Request.Cookies["DeptFiterState"] != null)
                {
                    base.Request.Cookies["DeptFiterState"].Value = null;
                }
                if (base.Request.Cookies["AddressFiterState"] != null)
                {
                    base.Request.Cookies["AddressFiterState"].Value = null;
                }
                if (base.Request.Cookies["NotesFiterState"] != null)
                {
                    base.Request.Cookies["NotesFiterState"].Value = null;
                }
                if (base.Session[string.Concat("searchContact", this.ClientID)] != null)
                {
                    DataTable item = new DataTable();
                    this.RadGrid_Contact.MasterTableView.FilterExpression = "";
                    try
                    {
                        item = (DataTable)base.Session[string.Concat("searchContact", this.ClientID)];
                        foreach (DataRow dataRow1 in item.Rows)
                        {
                            GridColumn columnSafe = this.RadGrid_Contact.MasterTableView.GetColumnSafe(dataRow1["ColumnName"].ToString());
                            columnSafe.CurrentFilterValue = dataRow1["FilterText"].ToString();
                        }
                        ClientContactsSubSection.WhereConditionContact = this.FilterFunction(item);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    // empty contacts 
                    foreach (GridColumn column in this.RadGrid_Contact.MasterTableView.Columns)
                    {
                        column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column.CurrentFilterValue = string.Empty;
                    }
                    base.Session[string.Concat("searchContact", this.ClientID)] = null;
                    ClientContactsSubSection.WhereConditionContact = "";
                    this.RadGrid_Contact.MasterTableView.FilterExpression = string.Empty;

                }
                if (base.Session[string.Concat("searchDepartment", this.ClientID)] != null)
                {
                    DataTable item1 = new DataTable();
                    this.RadGrid_Contact.MasterTableView.FilterExpression = "";
                    try
                    {
                        item1 = (DataTable)base.Session[string.Concat("searchDepartment", this.ClientID)];
                        foreach (DataRow row2 in item1.Rows)
                        {
                            GridColumn gridColumn = this.RadGrid_Department.MasterTableView.GetColumnSafe(row2["ColumnName"].ToString());
                            gridColumn.CurrentFilterValue = row2["FilterText"].ToString();
                        }
                        ClientSubSection.WhereConditionDepartment = this.FilterFunction(item1);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    // empty department
                    foreach (GridColumn column in this.RadGrid_Department.MasterTableView.Columns)
                    {
                        column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column.CurrentFilterValue = string.Empty;
                    }
                    base.Session[string.Concat("searchDepartment", this.ClientID)] = null;
                    ClientSubSection.WhereConditionDepartment = "";
                    this.RadGrid_Department.MasterTableView.FilterExpression = string.Empty;
                }
                if (base.Session[string.Concat("searchAddress", this.ClientID)] != null)
                {
                    DataTable item2 = new DataTable();
                    this.RadGrid_Contact.MasterTableView.FilterExpression = "";
                    try
                    {
                        item2 = (DataTable)base.Session[string.Concat("searchAddress", this.ClientID)];
                        foreach (DataRow dataRow2 in item2.Rows)
                        {
                            GridColumn columnSafe1 = this.RadGrid_Address.MasterTableView.GetColumnSafe(dataRow2["ColumnName"].ToString());
                            columnSafe1.CurrentFilterValue = dataRow2["FilterText"].ToString();
                        }
                        this.WhereConditionAddress = this.FilterFunction(item2);
                    }
                    catch
                    {
                    }
                }
                if (base.Session[string.Concat("searchCostcenter", this.ClientID)] != null)
                {
                    DataTable item3 = new DataTable();
                    this.RadGrid_Contact.MasterTableView.FilterExpression = "";
                    try
                    {
                        item3 = (DataTable)base.Session[string.Concat("searchCostcenter", this.ClientID)];
                        foreach (DataRow row3 in item3.Rows)
                        {
                            GridColumn str1 = this.grdcostcentre.MasterTableView.GetColumnSafe(row3["ColumnName"].ToString());
                            str1.CurrentFilterValue = row3["FilterText"].ToString();
                        }
                        this.WhereConditionCostcenter = this.FilterFunction(item3);
                    }
                    catch
                    {
                    }
                }
                //this.loadgrdcostcenter();

                //this.GridContact(this.CompanyID, this.ClientID, 1, this.RadGrid_Contact.PageSize);               
                // ClientSubSection.WhereConditionDepartment = string.Empty;
                //this.GridDepartment(this.CompanyID, this.ClientID, 1, this.RadGrid_Department.PageSize);

                //this.GridAddress(this.CompanyID, this.ClientID);
            }
            this.getAccountID(this.CompanyID, this.ClientID, this.CompanyType);
            this.NormalizeCustomerTabCookie();
            if (!base.IsPostBack && base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)] != null)
            {
                if (this.IsRestrictedCustomerTab(base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value))
                {
                    this.get_ClientTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "activities" || base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "jobs" || base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "invoices" || base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "estore")
                {
                    string str2 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                    string str3 = "&nbsp;>&nbsp;Customer Details > Records";
                    UserControl userControl = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label = (Label)userControl.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", str2, "</b></span><span class='navigatorpanel'><b>", str3, "</b></span>" };
                    label.Text = string.Concat(strArrays);
                    label.Text = label.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Records");
                    this.get_ActivitiesTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "client")
                {
                    string str4 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                    string str5 = "&nbsp;>&nbsp;Customer Details > Summary Information";
                    UserControl userControl1 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label1 = (Label)userControl1.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", str4, "</b></span><span class='navigatorpanel'><b>", str5, "</b></span>" };
                    label1.Text = string.Concat(strArrays);
                    label1.Text = label1.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.DivsearchButton.Style.Add("display", "block");
                    this.get_ClientTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "contacts")
                {
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    if (this.CompanyType != null)
                    {
                        if (this.CompanyType.ToString().ToLower() == "Supplier" || this.CompanyType.ToString().ToLower() == "supplier")
                        {
                            empty = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>Supplier View</a>";
                            empty1 = "&nbsp;>&nbsp;Supplier Details > Contacts";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Prospect" || this.CompanyType.ToString().ToLower() == "prospect")
                        {
                            empty = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>Prospect View</a>";
                            empty1 = "&nbsp;>&nbsp;Prospect Details > Contacts";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Customer" || this.CompanyType.ToString().ToLower() == "customer")
                        {
                            empty = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                            empty1 = "&nbsp;>&nbsp;Customer Details > Contacts";
                        }
                        this.PanelName.Text = this.objLangClass.GetLanguageConversion("Contacts");
                    }
                    UserControl userControl2 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label2 = (Label)userControl2.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", empty, "</b></span><span class='navigatorpanel'><b>", empty1, "</b></span>" };
                    label2.Text = string.Concat(strArrays);
                    label2.Text = label2.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.get_ContactTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "dept")
                {
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    if (this.CompanyType != null)
                    {
                        if (this.CompanyType.ToString().ToLower() == "Supplier" || this.CompanyType.ToString().ToLower() == "supplier")
                        {
                            empty2 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>Supplier View</a>";
                            empty3 = "&nbsp;>&nbsp;Supplier Details > Departments";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Prospect" || this.CompanyType.ToString().ToLower() == "prospect")
                        {
                            empty2 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>Prospect View</a>";
                            empty3 = "&nbsp;>&nbsp;Prospect Details > Departments";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Customer" || this.CompanyType.ToString().ToLower() == "customer")
                        {
                            empty2 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                            empty3 = "&nbsp;>&nbsp;Customer Details > Departments";
                        }
                        this.PanelName.Text = this.objLangClass.GetLanguageConversion("Departments");
                    }
                    UserControl userControl3 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label3 = (Label)userControl3.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", empty2, "</b></span><span class='navigatorpanel'><b>", empty3, "</b></span>" };
                    label3.Text = string.Concat(strArrays);
                    label3.Text = label3.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.get_DeptTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "address")
                {
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    if (this.CompanyType != null)
                    {
                        if (this.CompanyType.ToString().ToLower() == "Supplier" || this.CompanyType.ToString().ToLower() == "supplier")
                        {
                            empty4 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>Supplier View</a>";
                            empty5 = "&nbsp;>&nbsp;Supplier Details > Address Book";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Prospect" || this.CompanyType.ToString().ToLower() == "prospect")
                        {
                            empty4 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>Prospect View</a>";
                            empty5 = "&nbsp;>&nbsp;Prospect Details > Address Book";
                        }
                        if (this.CompanyType.ToString().ToLower() == "Customer" || this.CompanyType.ToString().ToLower() == "customer")
                        {
                            empty4 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                            empty5 = "&nbsp;>&nbsp;Customer Details > Address Book";
                        }
                        this.PanelName.Text = this.objLangClass.GetLanguageConversion("Address_Book");
                    }
                    UserControl userControl4 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label4 = (Label)userControl4.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", empty4, "</b></span><span class='navigatorpanel'><b>", empty5, "</b></span>" };
                    label4.Text = string.Concat(strArrays);
                    label4.Text = label4.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.get_AddressTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "b2b")
                {
                    string str6 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                    string str7 = "&nbsp;>&nbsp;Customer Details > eStore";
                    UserControl userControl5 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label5 = (Label)userControl5.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", str6, "</b></span><span class='navigatorpanel'><b>", str7, "</b></span>" };
                    label5.Text = string.Concat(strArrays);
                    label5.Text = label5.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("eStore");
                    this.get_b2bTab();
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:ClosePopFromDashboard();", true);
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "products")
                {
                    string str8 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                    string str9 = "&nbsp;>&nbsp;Customer Details > Products";
                    UserControl userControl6 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                    Label label6 = (Label)userControl6.FindControl("lblsitepath");
                    strArrays = new string[] { "<span class='navigatorpanel'><b>", str8, "</b></span><span class='navigatorpanel'><b>", str9, "</b></span>" };
                    label6.Text = string.Concat(strArrays);
                    label6.Text = label6.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                    this.divbtnedit.Style.Add("display", "none");
                    this.divbtndelete.Style.Add("display", "none");
                    this.DivsearchButton.Style.Add("display", "none");
                    this.PanelName.Text = this.objLangClass.GetLanguageConversion("Products");
                    this.get_ProductTab();
                }
                else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value != "notes")
                {
                    if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "emails")
                    {
                        string empty6 = string.Empty;
                        string empty7 = string.Empty;
                        if (this.CompanyType != null)
                        {
                            if (this.CompanyType.ToString().ToLower() == "Supplier" || this.CompanyType.ToString().ToLower() == "supplier")
                            {
                                empty6 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>Supplier View</a>";
                                empty7 = "&nbsp;>&nbsp;Supplier Details > Emails";
                            }
                            if (this.CompanyType.ToString().ToLower() == "Prospect" || this.CompanyType.ToString().ToLower() == "prospect")
                            {
                                empty6 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>Prospect View</a>";
                                empty7 = "&nbsp;>&nbsp;Prospect Details > Emails";
                            }
                            if (this.CompanyType.ToString().ToLower() == "Customer" || this.CompanyType.ToString().ToLower() == "customer")
                            {
                                empty6 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                                empty7 = "&nbsp;>&nbsp;Customer Details > Emails";
                            }
                            this.PanelName.Text = this.objLangClass.GetLanguageConversion("Emails");
                        }
                        UserControl userControl7 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                        Label label7 = (Label)userControl7.FindControl("lblsitepath");
                        if (!(this.CompanyType != "supplier") || !(this.CompanyType != "prospect"))
                        {
                            label7.Text = string.Concat(label7.Text, "<span class='navigatorpanelblack'><b> > Emails</b></span>");
                        }
                        else
                        {
                            strArrays = new string[] { "<span class='navigatorpanel'><b>", empty6, "</b></span><span class='navigatorpanel'><b>", empty7, "</b></span>" };
                            label7.Text = string.Concat(strArrays);
                            label7.Text = label7.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                        }
                        this.divbtnedit.Style.Add("display", "none");
                        this.divbtndelete.Style.Add("display", "none");
                        this.DivsearchButton.Style.Add("display", "none");
                        this.get_EmailsTab();
                    }
                    else if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "costcentre")
                    {
                        string empty8 = string.Empty;
                        string empty9 = string.Empty;
                        if (this.CompanyType != null)
                        {
                            if (this.CompanyType.ToString().ToLower() == "Supplier" || this.CompanyType.ToString().ToLower() == "supplier")
                            {
                                empty8 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>Supplier View</a>";
                                empty9 = "&nbsp;>&nbsp;Supplier Details > Cost Centres";
                            }
                            if (this.CompanyType.ToString().ToLower() == "Prospect" || this.CompanyType.ToString().ToLower() == "prospect")
                            {
                                empty8 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>Prospect View</a>";
                                empty9 = "&nbsp;>&nbsp;Prospect Details > Cost Centres";
                            }
                            if (this.CompanyType.ToString().ToLower() == "Customer" || this.CompanyType.ToString().ToLower() == "customer")
                            {
                                empty8 = "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>";
                                empty9 = "&nbsp;>&nbsp;Customer Details > Cost Centres";
                            }
                            this.PanelName.Text = this.objLangClass.GetLanguageConversion("Cost_Centres");
                        }
                        UserControl userControl8 = (UserControl)this.Parent.Page.Master.FindControl("header2");
                        Label label8 = (Label)userControl8.FindControl("lblsitepath");
                        strArrays = new string[] { "<span class='navigatorpanel'><b>", empty8, "</b></span><span class='navigatorpanel'><b>", empty9, "</b></span>" };
                        label8.Text = string.Concat(strArrays);
                        label8.Text = label8.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
                        this.divbtnedit.Style.Add("display", "none");
                        this.divbtndelete.Style.Add("display", "none");
                        this.DivsearchButton.Style.Add("display", "none");
                        this.get_CostcentreTabs();
                    }
                }
            }
            else if (!base.IsPostBack)
            {
                this.get_ClientTab();
            }

            if (base.IsPostBack)
            {
                this.HandleCrmTabPostBack();
            }

            this.RegisterCrmTabPostBackControls();
            this.bindEstoreDetails();
            this.getClientDetails(this.UserID, this.CompanyID, this.CompanyType, this.ClientID, this.AccountID);
            this.isView = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString());
            this.lbl1.Text = this.objLangClass.GetLanguageConversion("Company_Name");
            this.Label4.Text = this.objLangClass.GetLanguageConversion("Type");
            this.Label5.Text = this.objLangClass.GetLanguageConversion("Account_Status");
            this.Label6.Text = this.objLangClass.GetLanguageConversion("Account_Number");
            this.Label15.Text = this.objLangClass.GetLanguageConversion("Email");
            this.lbl_url.Text = this.objLangClass.GetLanguageConversion("URL");
            this.Label18.Text = this.objLangClass.GetLanguageConversion("Credit_Limit");
            this.Label19.Text = this.objLangClass.GetLanguageConversion("Credit_Reference");
            this.Label23.Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
            this.Label25.Text = this.objLangClass.GetLanguageConversion("Profit_Margin");
            this.Label22.Text = this.objLangClass.GetLanguageConversion("Tax_Reg_No");
            this.Label26.Text = this.objLangClass.GetLanguageConversion("A_C_Opened");
            this.Label27.Text = this.objLangClass.GetLanguageConversion("Bank_Code");
            this.Label28.Text = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
            this.Label29.Text = this.objLangClass.GetLanguageConversion("Account_Name");
            this.Label30.Text = this.objLangClass.GetLanguageConversion("Sales_Person");
            this.LabelReference.Text = this.objLangClass.GetLanguageConversion("Referred_By");
            this.lbl_desc.Text = this.objLangClass.GetLanguageConversion("Description");
            this.btnCreateAcc_Or_view.Text = this.objLangClass.GetLanguageConversion("Create_B2B_Estore");
            this.btn_print.Text = this.objLangClass.GetLanguageConversion("Print");
            this.btnsave.Text = this.objLangClass.GetLanguageConversion("Add_A_New_Note");
            if (dataTable2.Rows.Count > 0)
            {
                if (dataTable2.Rows[0]["CompanyType"].ToString().ToLower() != "customer")
                {
                    this.RadGrid_Department.MasterTableView.GetColumn("ApproverName").Visible = false;
                    this.RadGrid_Contact.MasterTableView.GetColumn("approverType").Visible = false;
                }
                else
                {
                    this.RadGrid_Department.MasterTableView.GetColumn("ApproverName").Visible = true;
                    this.RadGrid_Contact.MasterTableView.GetColumn("approverType").Visible = true;
                }
                DataTable dataTable4 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
                if (dataTable4.Rows.Count > 0)
                {
                    foreach (DataRow dataRow3 in dataTable4.Rows)
                    {
                        if (dataRow3["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                        {
                            this.RadGrid_Department.MasterTableView.GetColumn("ApproverName").Visible = true;
                            this.RadGrid_Contact.MasterTableView.GetColumn("approverType").Visible = true;
                        }
                        else
                        {
                            this.RadGrid_Department.MasterTableView.GetColumn("ApproverName").Visible = false;
                            this.RadGrid_Contact.MasterTableView.GetColumn("approverType").Visible = false;
                        }
                    }
                }
            }
            string empty10 = string.Empty;
            ClientSubSection.IsEditOnlyHisRecords = this.basecls.ReturnRoles_Privileges_Others("editrecords");
            if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.DivAddNewRecords.Visible = true;
            }
            else
            {
                this.DivAddNewRecords.Visible = false;
            }
            string str10 = string.Empty;
            if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                this.btnEdit.Visible = false;
            }
            else if (ClientSubSection.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != ClientSubSection.SalesPersonID)
            {
                this.btnEdit.Visible = false;
            }
            string empty11 = string.Empty;
            if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
            }
            string str11 = string.Empty;
            if (this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.ContactsSection.Delete_Hide.Style.Add("display", "block");
                this.btnDelete.Visible = true;
            }
            else
            {
                this.ContactsSection.Delete_Hide.Style.Add("display", "none");
                this.btnDelete.Visible = false;
            }
            if (!base.IsPostBack)
            {
                this.loadgrdcostcenter();
                this.BindSubJectDropdown();
                this.BindStatusDrop();
                this.BindPyortyDrop();
                this.BindEditSubJectDropdown();
                this.BindEditStatusDrop();
                this.BindEdirTaskPyorty();
                this.GroupCallPurpose();
                this.BintCallContact();
                this.BonDCallOwner();
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.TodayDate = DateTime.Today.ToString();
            this.txtduedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtcallstartdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtEditDueDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtEditCallStartdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtsearchstartdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtsearchenddate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            DataSet dataSet = DepartmentBaseClass.CRM_Select_Type_fromUsertype(this.UserID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row4 in dataSet.Tables[0].Rows)
                {
                    this.UserTypeID = Convert.ToInt32(row4["UsertypeID"].ToString());
                }
            }
            DataSet dataSet1 = DepartmentBaseClass.CRM_Select_Type_fromUsertype(this.CompanyID, this.UserTypeID);
            if (dataSet1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow4 in dataSet1.Tables[0].Rows)
                {
                    if (dataRow4["CompanyType"].ToString() != "")
                    {
                        this.CompanyTypeNew = dataRow4["CompanyType"].ToString().Substring(0, dataRow4["CompanyType"].ToString().Length - 1);
                    }
                    this.ShowRecords = dataRow4["ShowRecords"].ToString();
                }
            }
            //DataSet dataSet2 = DepartmentBaseClass.CRM_Select_Conversion_Persentage_Est_Job(this.ClientID, this.CompanyID);
            //if (dataSet2.Tables[0].Rows.Count <= 0)
            //{
            //    this.LblEstimateToJob1.Text = "0%";
            //}
            //else
            //{
            //    foreach (DataRow row5 in dataSet2.Tables[0].Rows)
            //    {
            //        Label lblEstimateToJob1 = this.LblEstimateToJob1;
            //        string languageConversion1 = this.objLangClass.GetLanguageConversion("Estimate_to_Job");
            //        decimal num = Math.Round(Convert.ToDecimal(dataSet2.Tables[0].Rows[0]["JobConversionPercentage"]), 0);
            //        lblEstimateToJob1.Text = string.Concat(languageConversion1, " ", num.ToString(), "%");
            //    }
            //}
            this.lblNotesTitle.Text = CRMNotes.ReturnNotes(this.CompanyID.ToString(), this.SectionID.ToString(), 1);
            this.hdnprintNotesValue.Value = CRMNotesPrint.ReturnNotesPrint(this.CompanyID.ToString(), this.SectionID.ToString());
            this.lblOpenActivities.Text = CRMCalls.ReturnCalls(this.CompanyID.ToString(), this.SectionID.ToString(), 1);
            this.lblcloseActivity.Text = CRMCloseActivity.ReturnCloseActivity(this.CompanyID.ToString(), this.SectionID.ToString(), 1);
            try
            {
                commonClass _commonClass = this.commclass;
                DateTime now = DateTime.Now;
                string str12 = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                string[] strArrays1 = str12.Split(new char[] { ' ' });
                this.hdntodaydate.Value = strArrays1[0].ToString();
                this.TodDate = this.hdntodaydate.Value;
            }
            catch
            {
            }
            if (base.Session["IsAdded"] != null && base.Session["IsAdded"] != null && base.Session["IsAdded"].ToString() == "yes")
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Department_added_successfully"), "msg-success", this.plhDepartment);
                base.Session["IsAdded"] = null;
            }
            if (base.Session["IsAddedCC"] != null && base.Session["IsAddedCC"] != null)
            {
                if (base.Session["IsAddedCC"].ToString() == "yes")
                {
                    this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("CostCenter_added_successfully"), "msg-success", this.plhCoceCEn);
                    base.Session["IsAddedCC"] = null;
                }
                else if (base.Session["IsAddedCC"].ToString() == "up")
                {
                    this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("CostCenter_Updated_successfully"), "msg-success", this.plhCoceCEn);
                    base.Session["IsAddedCC"] = null;
                }
            }
            if (base.Session["IsAddedContact"] != null && base.Session["IsAddedContact"] != null && base.Session["IsAddedContact"].ToString() == "yes1")
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_added_successfully"), "msg-success", this.ContactsSection.plhContact);
                base.Session["IsAddedContact"] = null;
            }
            if (base.Session["IsEditContact"] != null && base.Session["IsEditContact"] != null && base.Session["IsEditContact"].ToString() == "yes2")
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Contact_updated_successfully"), "msg-success", this.ContactsSection.plhContact);
                base.Session["IsEditContact"] = null;
            }
            if (base.Session["AddAddress"] != null && base.Session["AddAddress"] != null && base.Session["AddAddress"].ToString() == "AddAddress")
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Address_added_successfully"), "msg-success", this.plhAddress);
                base.Session["AddAddress"] = null;
            }
            if (base.Session["IsLastNextRecord"] != null && base.Session["IsLastNextRecord"] != null && base.Session["IsLastNextRecord"].ToString() == "true")
            {
                this.DivlnkNextClientRecord.Style.Add("display", "none");
                base.Session["IsLastNextRecord"] = null;
            }
            if (base.Session["IsLastPreviousRecord"] != null && base.Session["IsLastPreviousRecord"] != null && base.Session["IsLastPreviousRecord"].ToString() == "true")
            {
                this.DivlnkPreviousPage.Style.Add("display", "none");
                base.Session["IsLastPreviousRecord"] = null;
            }
            if (base.Session["NoMoreDateLoad"] != null && base.Session["NoMoreDateLoad"] != null && base.Session["NoMoreDateLoad"].ToString() == "Yes")
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:NextPreviousAlert();", true);
                base.Session["NoMoreDateLoad"] = null;
            }
            DataSet dataSet3 = DepartmentBaseClass.CRM_Select_SalesTarget(this.UserID, Convert.ToInt32(this.CompanyID));
            DataTable dataTable5 = new DataTable();
            if (dataSet3.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow5 in dataSet3.Tables[0].Rows)
                {
                    if (dataRow5["IsCustomAccessRight"].ToString().ToLower() == "false")
                    {
                        this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                        this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks_Calls");
                        dataTable5.Columns.Add("Value", typeof(string));
                        dataTable5.Columns.Add("Text", typeof(string));
                        DataRowCollection rows = dataTable5.Rows;
                        languageConversion = new object[] { "0", "None" };
                        rows.Add(languageConversion);
                        DataRowCollection dataRowCollection = dataTable5.Rows;
                        languageConversion = new object[] { "1", this.objLangClass.GetLanguageConversion("Call") };
                        dataRowCollection.Add(languageConversion);
                        DataRowCollection rows1 = dataTable5.Rows;
                        languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                        rows1.Add(languageConversion);
                        DataRowCollection dataRowCollection1 = dataTable5.Rows;
                        languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                        dataRowCollection1.Add(languageConversion);
                    }
                    else if (dataRow5["IsTaskEventCall"].ToString().ToLower() != "1")
                    {
                        this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks");
                        this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks");
                        dataTable5.Columns.Add("Value", typeof(string));
                        dataTable5.Columns.Add("Text", typeof(string));
                        DataRowCollection rows2 = dataTable5.Rows;
                        languageConversion = new object[] { "0", "None" };
                        rows2.Add(languageConversion);
                        DataRowCollection dataRowCollection2 = dataTable5.Rows;
                        languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                        dataRowCollection2.Add(languageConversion);
                        DataRowCollection rows3 = dataTable5.Rows;
                        languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                        rows3.Add(languageConversion);
                    }
                    else
                    {
                        this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                        this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks_Calls");
                        dataTable5.Columns.Add("Value", typeof(string));
                        dataTable5.Columns.Add("Text", typeof(string));
                        DataRowCollection dataRowCollection3 = dataTable5.Rows;
                        languageConversion = new object[] { "0", "None" };
                        dataRowCollection3.Add(languageConversion);
                        DataRowCollection rows4 = dataTable5.Rows;
                        languageConversion = new object[] { "1", this.objLangClass.GetLanguageConversion("Call") };
                        rows4.Add(languageConversion);
                        DataRowCollection dataRowCollection4 = dataTable5.Rows;
                        languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                        dataRowCollection4.Add(languageConversion);
                        DataRowCollection rows5 = dataTable5.Rows;
                        languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                        rows5.Add(languageConversion);
                    }
                }
            }
            this.btn_AddNewDepartment.Text = this.objLangClass.GetLanguageConversion("Add_New_Department");
            this.btn_AddNewDepartment.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Department");
            this.btn_AddNewDepartment.OnClientClick = string.Concat("javascript:addNewDepartment('dept','add','", this.ClientID, "','0');return false;");
            this.btn_AddNewCostCenter.Text = this.objLangClass.GetLanguageConversion("Add_New_Cost_Centre");
            this.btn_AddNewCostCenter.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Cost_Centre");
            this.btn_AddNewCostCenter.OnClientClick = string.Concat("javascript:addNewCostcenter('costcentre','add','", this.ClientID, "');return false;");
            this.btn_AddNewAddress.Text = this.objLangClass.GetLanguageConversion("Add_New_Address");
            this.btn_AddNewAddress.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Address");
            this.btn_AddNewAddress.OnClientClick = string.Concat("javascript:addNewAddress('Address','add','", this.ClientID, "','0');return false;");
            this.btn_AddNewProduct.Text = this.objLangClass.GetLanguageConversion("Add_New_Product");
            this.btn_AddNewProduct.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Product");
            this.btn_AddNewProduct.OnClientClick = string.Concat("javascript:addNewProduct('Product','add','", this.ClientID, "','0');return false;");
            this.btn_AddNewContact.Text = this.objLangClass.GetLanguageConversion("Add_New_Contact");
            this.btn_AddNewContact.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Contact");
            this.btn_AddNewContact.OnClientClick = string.Concat("javascript:addNewcontact('contact','add','", this.ClientID, "','0');return false;");
            string empty12 = string.Empty;
            empty12 = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
            Button btnAddNewEmail = this.btn_AddNewEmail;
            languageConversion = new object[] { "javascript:PopupCenter_Email('0','add','", this.ClientID, "','", empty12, "'); return false;" };
            btnAddNewEmail.OnClientClick = string.Concat(languageConversion);
            this.btn_AddNewEmail.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Email");
            this.btn_AddNewEmail.Text = this.objLangClass.GetLanguageConversion("Add_New_Email");
            this.lblcloseActivity.Style.Add("display", "none");
        }

        protected void RadGrid_Address_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                this.WhereConditionAddress = "";
                if (base.Session[string.Concat("searchAddress", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchAddress", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchAddress", this.ClientID)];
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
                base.Session[string.Concat("searchAddress", this.ClientID)] = dataTable;
                this.WhereConditionAddress = this.FilterFunction(dataTable);
                this.GridAddress(this.CompanyID, this.ClientID);
                this.RadGrid_Address.Rebind();
            }
        }

        protected void RadGrid_Address_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.CompanyID <= 0 || this.ClientID <= 0)
            {
                this.RadGrid_Address.DataSource = new DataTable();
                return;
            }
            this.dt_Address = DepartmentBaseClass.address_select_for_filter(this.ClientID, this.CompanyID, "Yes", this.WhereConditionAddress ?? string.Empty);
            this.RadGrid_Address.DataSource = this.dt_Address ?? new DataTable();
        }

        protected void RadGrid_Address_PreRender(object sender, EventArgs e)
        {
            if (this.div_AddressMain == null || this.div_AddressMain.Style["display"] == "none")
            {
                return;
            }
            this.EnsureCrmClientContext();
            if (this.CompanyID <= 0 || this.ClientID <= 0)
            {
                return;
            }
            if (this.dt_Address == null)
            {
                this.GridAddress(this.CompanyID, this.ClientID);
                this.RadGrid_Address.Rebind();
            }
        }

                        // Ticket #10210 by applying pagination upon contacts and departments will solve the problem
                protected void RadGrid_Department_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                ClientSubSection.WhereConditionDepartment = "";
                if (base.Session[string.Concat("searchDepartment", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchDepartment", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchDepartment", this.ClientID)];
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
                base.Session[string.Concat("searchDepartment", this.ClientID)] = dataTable;
                ClientSubSection.WhereConditionDepartment = this.FilterFunction(dataTable);
                this.GridDepartment(this.CompanyID, this.ClientID, 1, this.RadGrid_Department.PageSize);
                this.RadGrid_Department.Rebind();
            }
        }

        protected void RadGrid_Department_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid_Department.AllowCustomPaging = true;
            this.ds_Department = DepartmentBaseClass.department_getAllDetails_for_filter(this.CompanyID, this.UserID, this.ClientID, (long)0, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize, ClientSubSection.WhereConditionDepartment);
            this.RadGrid_Department.DataSource = this.ds_Department.Tables[0];
        }
        protected void RadGrid_Department_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid_Department.AllowCustomPaging = true;
            this.RadGrid_Department.CurrentPageIndex = e.NewPageIndex;
            this.ds_Department = DepartmentBaseClass.department_getAllDetails_for_filter(this.CompanyID, this.UserID, this.ClientID, (long)0, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize, ClientSubSection.WhereConditionDepartment);
            this.RadGrid_Department.DataSource = this.ds_Department.Tables[0];

            this.RadGrid_Department.VirtualItemCount = Convert.ToInt32(ds_Department.Tables[1].Rows[0][0].ToString());
            if (ds_Department.Tables[0].Rows.Count == 0)
            {
                this.RadGrid_Department.VirtualItemCount = 0;
                this.RadGrid_Department.AllowCustomPaging = false;
            }

            //this.RadGrid_Department.DataBind();
            this.RadGrid_Department.Rebind();
        }
        protected void RadGridAddress_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.CommandItem)
                {
                    string empty = string.Empty;
                    empty = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                    HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivAddNewRecord");
                    if (empty.Trim().ToLower() != "false")
                    {
                        if(htmlControl != null)
                        {
                            htmlControl.Attributes.Add("style", "display:block");
                        }
                    }
                    else
                    {
                        if (htmlControl != null)
                        {
                            htmlControl.Attributes.Add("style", "display:none");
                        }
                    }
                }
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    GridDataItem addressRow = (GridDataItem)e.Item;
                    for (int cellIndex = 0; cellIndex < addressRow.Cells.Count && cellIndex < this.RadGrid_Address.Columns.Count; cellIndex++)
                    {
                        string headerText = this.RadGrid_Address.Columns[cellIndex].HeaderText;
                        if (!string.IsNullOrEmpty(headerText))
                        {
                            addressRow.Cells[cellIndex].Attributes["data-label"] = headerText;
                        }
                    }
                    string str = string.Empty;
                    str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
                    Panel panel = (Panel)e.Item.FindControl("PanelDeleteAddress");
                    if (panel != null)
                    {
                        if (str.Trim().ToLower() != "false")
                        {
                            panel.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            panel.Attributes.Add("style", "display:none;");
                        }
                    }
                    HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdn_DefaultBilling");
                    HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hdn_DefaultPostBox");
                    Image image1 = (Image)e.Item.FindControl("img_DefaultBilling");
                    Image image2 = (Image)e.Item.FindControl("img_DefaultPostBox");
                    if (image1 != null && hiddenField8 != null)
                    {
                        if (hiddenField8.Value != "True")
                        {
                            image1.ImageUrl = string.Concat(this.ImgPath, "1t.gif");
                        }
                        else
                        {
                            image1.ImageUrl = string.Concat(this.ImgPath, "check.gif");
                        }
                    }
                    if (image2 != null && hiddenField9 != null)
                    {
                        if (hiddenField9.Value != "True")
                        {
                            image2.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                        }
                        else
                        {
                            image2.ImageUrl = string.Concat(this.ImgPath, "ICON_checkboxNew.gif");
                        }
                    }
                }
            }
            catch
            {
            }
        }

                                        protected void RadGridDepartment_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.CommandItem)
                {
                    string empty = string.Empty;
                    empty = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                    HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivDepartment");
                    if (empty.Trim().ToLower() != "false")
                    {
                        if(htmlControl != null)
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
                }
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    GridDataItem deptRow = (GridDataItem)e.Item;
                    for (int cellIndex = 0; cellIndex < deptRow.Cells.Count && cellIndex < this.RadGrid_Department.Columns.Count; cellIndex++)
                    {
                        string headerText = this.RadGrid_Department.Columns[cellIndex].HeaderText;
                        if (!string.IsNullOrEmpty(headerText))
                        {
                            deptRow.Cells[cellIndex].Attributes["data-label"] = headerText;
                        }
                    }
                    string str = string.Empty;
                    str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
                    HtmlControl htmlControl1 = (HtmlControl)e.Item.FindControl("DivDelete");
                    if (str.Trim().ToLower() != "false")
                    {
                        htmlControl1.Visible = true;
                        this.RadGrid_Department.MasterTableView.GetColumn("ChkDelete").Visible = true;
                    }
                    else
                    {
                        htmlControl1.Visible = false;
                        this.RadGrid_Department.MasterTableView.GetColumn("ChkDelete").Visible = false;
                    }
                    Label label = (Label)e.Item.FindControl("lbl_DeptName");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_DeptName");
                    HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkBox_Department");
                    Label text = (Label)e.Item.FindControl("lbl_AddressDelivery");
                    Label text1 = (Label)e.Item.FindControl("lbl_AddressInvoice");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_DeliveryAddress");
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_DeliveryAddressLine2");
                    HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_DeliveryCity");
                    HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_DeliveryState");
                    HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_DeliveryZipCode");
                    HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_DeliveryCountry");
                    HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdn_InvoiceAddress");
                    HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdn_InvoiceAddressLine2");
                    HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hdn_InvoiceCity");
                    HiddenField hiddenField10 = (HiddenField)e.Item.FindControl("hdn_InvoiceState");
                    HiddenField hiddenField11 = (HiddenField)e.Item.FindControl("hdn_InvoiceZipCode");
                    HiddenField hiddenField12 = (HiddenField)e.Item.FindControl("hdn_InvoiceCountry");
                    HiddenField hiddenField13 = (HiddenField)e.Item.FindControl("hdn_AddressType");
                    Image image = (Image)e.Item.FindControl("img_DefaultDept");
                    HiddenField hiddenField14 = (HiddenField)e.Item.FindControl("hdn_DefaultDept");
                    HiddenField hiddenField15 = (HiddenField)e.Item.FindControl("hdn_DefaultDeptID");
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonDeleteDept");
                    string[] strArrays = new string[] { this.basecls.SpecialDecode(hiddenField1.Value), " ", this.basecls.SpecialDecode(hiddenField2.Value), " ", this.basecls.SpecialDecode(hiddenField3.Value), " ", this.basecls.SpecialDecode(hiddenField4.Value), " ", this.basecls.SpecialDecode(hiddenField5.Value), " ", this.basecls.SpecialDecode(hiddenField6.Value) };
                    text.Text = string.Concat(strArrays);
                    string[] strArrays1 = new string[] { this.basecls.SpecialDecode(hiddenField7.Value), " ", this.basecls.SpecialDecode(hiddenField8.Value), " ", this.basecls.SpecialDecode(hiddenField9.Value), " ", this.basecls.SpecialDecode(hiddenField10.Value), " ", this.basecls.SpecialDecode(hiddenField11.Value), " ", this.basecls.SpecialDecode(hiddenField12.Value) };
                    text1.Text = string.Concat(strArrays1);
                    text.ToolTip = text.Text;
                    text1.ToolTip = text1.Text;
                    if (hiddenField14.Value != "True")
                    {
                        image.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                    }
                    else
                    {
                        this.DefDeptId = Convert.ToInt32(hiddenField15.Value);
                        image.ImageUrl = string.Concat(this.ImgPath, "ICON_checkboxNew.gif");
                        if (!this.IsSpendLimitEnable)
                        {
                            htmlInputCheckBox.Disabled = true;
                        }
                        else if (!this.IsPerDept)
                        {
                            htmlInputCheckBox.Disabled = true;
                        }
                        else
                        {
                            htmlInputCheckBox.Disabled = false;
                        }
                        imageButton.Visible = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadListBox_Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < this.RadGrid_Address.Items.Count; i++)
            {
                string empty = string.Empty;
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Address.Items[i].Cells[0].FindControl("checkBox_Address");
                if (base.Request.Cookies["RadListBoxAddressValue"] != null)
                {
                    empty = base.Request.Cookies["RadListBoxAddressValue"].Value;
                }
                if (empty.ToLower() == "delete" && this.hdn_AddressIDs.Value.Length > 0)
                {
                    string[] strArrays = this.hdn_AddressIDs.Value.Split(new char[] { ',' });
                    for (int j = 0; j < (int)strArrays.Length - 1; j++)
                    {
                        int num1 = Convert.ToInt32(strArrays[j]);
                        this.objcomm.address_delete(this.CompanyID, num1, this.UserID);
                        htmlInputCheckBox.Checked = false;
                        ClientSubSection usercontrolCrmClientSubSection = this;
                        usercontrolCrmClientSubSection.cntDelete = usercontrolCrmClientSubSection.cntDelete + 1;
                    }
                }
                if (empty.ToLower() == "set_postbox" && htmlInputCheckBox.Checked)
                {
                    num = Convert.ToInt32(htmlInputCheckBox.Value);
                    htmlInputCheckBox.Checked = false;
                    ClientSubSection usercontrolCrmClientSubSection1 = this;
                    usercontrolCrmClientSubSection1.cntPostbox = usercontrolCrmClientSubSection1.cntPostbox + 1;
                }
            }
            if (this.cntDelete != 0)
            {
                this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
                this.RadGrid_Department.Rebind();
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Address_deleted_successfully"), "msg-success", this.plhAddress);
            }
            if (this.cntPostbox != 1)
            {
                this.pnl_MoreThan1Selected_Address.Visible = true;
            }
            else
            {
                CompanyBasePage.SetDefaultAddressID(this.ClientID, num);
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Post_box_address_set_successfully"), "msg-success", this.plhAddress);
                this.cntPostbox = 0;
            }
            this.GridAddress(this.CompanyID, this.ClientID);
            this.RadGrid_Address.Rebind();
            this.RadListBox_Address.SelectedIndex = this.Index - 1;
            base.Request.Cookies["RadListBoxAddressValue"].Value = null;
        }

                protected void RadListBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            while (num < this.RadGrid_Department.Items.Count)
            {
                string empty = string.Empty;
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Department.Items[num].Cells[0].FindControl("checkBox_Department");
                if (base.Request.Cookies["RadListBoxDeptValue"] != null)
                {
                    empty = base.Request.Cookies["RadListBoxDeptValue"].Value;
                }
                if (empty.ToLower() == "delete" && this.hdn_deptIDs.Value.Length > 0)
                {
                    string[] strArrays = this.hdn_deptIDs.Value.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (Convert.ToInt32(strArrays[i]) == this.DefDeptId)
                        {
                            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Default_department_can_not_be_delete"), "msg-fail", this.plhDepartment);
                        }
                        else
                        {
                            int num1 = Convert.ToInt32(strArrays[i]);
                            this.objDept.departmentDelete(this.CompanyID, this.UserID, num1, 0);
                            htmlInputCheckBox.Checked = false;
                            ClientSubSection usercontrolCrmClientSubSection = this;
                            usercontrolCrmClientSubSection.cntDelete = usercontrolCrmClientSubSection.cntDelete + 1;
                        }
                    }
                }
                if (empty.ToLower() == "set default" && htmlInputCheckBox.Checked)
                {
                    this.SetDefaultDeptID = Convert.ToInt32(htmlInputCheckBox.Value);
                    ClientSubSection usercontrolCrmClientSubSection1 = this;
                    usercontrolCrmClientSubSection1.cntDefault = usercontrolCrmClientSubSection1.cntDefault + 1;
                    htmlInputCheckBox.Checked = false;
                }
                if (!(empty.ToLower() == "spendlimitdeactivate") || this.hdn_deptIDs.Value.Length <= 0)
                {
                    num++;
                }
                else
                {
                    this.objcomm.Deactivate_SpendLimitUser(this.CompanyID, this.hdn_deptIDs.Value, "dept");
                    break;
                }
            }
            if (this.cntDelete != 0)
            {
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Department_deleted_successfully"), "msg-success", this.plhDepartment);
            }
            else if (this.cntDefault != 1)
            {
                this.pnl_MoreThan1Selected_Dept.Visible = true;
            }
            else
            {
                CompanyBasePage companyBasePage = new CompanyBasePage();
                this.objDept.departmentSetDefault(this.CompanyID, this.SetDefaultDeptID, this.ClientID);
                this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Default_department_set_successfully"), "msg-success", this.plhDepartment);
                this.cntDefault = 0;
            }
            this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
            this.RadGrid_Department.Rebind();
            this.GridContact(this.CompanyID, this.ClientID, this.RadGrid_Contact.CurrentPageIndex + 1, this.RadGrid_Contact.PageSize);
            this.RadGrid_Contact.Rebind();
            this.RadListBox_Department.SelectedIndex = this.Index - 1;
            base.Request.Cookies["RadListBoxDeptValue"].Value = null;
        }

        protected void setDefaultAddress_OnClick(object sender, CommandEventArgs e)
        {
            CompanyBasePage.SetDefaultAddressID(this.ClientID, Convert.ToInt32(e.CommandArgument));
            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Post_box_address_set_successfully"), "msg-success", this.plhAddress);
            this.GridAddress(this.CompanyID, this.ClientID);
            this.RadGrid_Address.Rebind();
        }

                protected void setDefaultDept_OnClick(object sender, CommandEventArgs e)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            this.objDept.departmentSetDefault(this.CompanyID, Convert.ToInt32(e.CommandArgument), this.ClientID);
            this.basecls.Message_Display(this.objLangClass.GetLanguageConversion("Default_department_set_successfully"), "msg-success", this.plhDepartment);
            this.GridDepartment(this.CompanyID, this.ClientID, this.RadGrid_Department.CurrentPageIndex + 1, this.RadGrid_Department.PageSize);
            this.RadGrid_Department.Rebind();
        }




    }
}