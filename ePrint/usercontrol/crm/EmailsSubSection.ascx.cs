using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
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


namespace ePrint.usercontrol.crm
{
    public partial class EmailsSubSection : System.Web.UI.UserControl
    {
        //protected PlaceHolder plhEmail;

        //protected UpdatePanel UpdatePanel4;

        //protected RadListBox RadListBox_Email;

        //protected LinkButton lnk_EmailRadList;

        //protected RadGrid RadGrid_Email;

        //protected UpdatePanel UpdatePanel_Email;

        //protected HtmlGenericControl div_EmailMain;

        //protected RadWindowManager RadWindowManager1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objcomm = new CompanyBasePage();

        private commonClass objcom = new commonClass();

        public static BaseClass objBase;

        private BasePage objPage = new BasePage();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int cntDelete;

        public int cntDefault;

        public int SetDefaultContactID;

        public int Index;

        public int Noof_Recipients;

        public static int FilteringEmail;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string isView = string.Empty;

        public languageClass objLangClass = new languageClass();

        public string isadd = string.Empty;

        private DataTable dt_Email;

        public string WhereCondition = string.Empty;

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

        static EmailsSubSection()
        {
            EmailsSubSection.objBase = new BaseClass();
            EmailsSubSection.FilteringEmail = 0;
        }

        public EmailsSubSection()
        {
        }

        protected void clrFiltersEmail_Click(object sender, EventArgs e)
        {
            base.Session["CRMDateFilterEmail"] = "";
            foreach (GridColumn column in this.RadGrid_Email.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchEmail", this.ClientID)] = null;
            this.WhereCondition = "";
            this.RadGrid_Email.MasterTableView.FilterExpression = string.Empty;
            this.GridEmail(this.CompanyID, this.ClientID, "Yes");
        }

        protected void DeleteImgEmail_OnClick(object sender, CommandEventArgs e)
        {
            this.objcomm.crm_common_email_delete("lead", Convert.ToInt32(e.CommandArgument), 0, this.CompanyID);
            EmailsSubSection.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Email_Deleted_Successfully"), "msg-success", this.plhEmail);
            this.GridEmail(this.CompanyID, this.ClientID, "Yes");
            this.RadGrid_Email.Rebind();
        }

        public string FilterFunction(DataTable dt)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dt.Rows)
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
                    string[] strArrays = new string[] { str2, " [", row["ColumnName"].ToString(), "] like '", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays);
                }
                else if (str1 == "endswith")
                {
                    string str3 = empty1;
                    string[] strArrays1 = new string[] { str3, " [", row["ColumnName"].ToString(), "] like '%", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays1);
                }
                else if (str1 == "equalto")
                {
                    string str4 = empty1;
                    string[] strArrays2 = new string[] { str4, " [", row["ColumnName"].ToString(), "] = '", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays2);
                }
                else if (str1 == "contains")
                {
                    string str5 = empty1;
                    string[] strArrays3 = new string[] { str5, " [", row["ColumnName"].ToString(), "] like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays3);
                }
                else if (str1 == "doesnotcontain")
                {
                    string str6 = empty1;
                    string[] strArrays4 = new string[] { str6, " [", row["ColumnName"].ToString(), "] not like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays4);
                }
                else if (str1 == "nofilter")
                {
                    string str7 = empty1;
                    string[] strArrays5 = new string[] { str7, " [", row["ColumnName"].ToString(), "] > '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays5);
                }
            }
            return empty1;
        }

        public void FilterStatus()
        {
            this.GridEmail(this.CompanyID, this.ClientID, "yes");
            GridTableView masterTableView = this.RadGrid_Email.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
        }

        public void GridEmail(int CompanyID, int ClientID, string SelectAll)
        {
            this.dt_Email = CompanyBasePage.crm_common_select_all_email_new_filter(CompanyID, ClientID, SelectAll, this.WhereCondition);
            for (int i = 0; i < this.dt_Email.Columns.Count; i++)
            {
                this.dt_Email.Columns[i].ReadOnly = false;
            }
            this.RadGrid_Email.DataSource = this.dt_Email;
            this.RadGrid_Email.DataBind();
        }

        protected void lnkEmailSub_OnClick(object sender, CommandEventArgs e)
        {
            string str = e.CommandArgument.ToString();
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("clients", "isview", this.Page.Request.Url.ToString());
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] clientID = new object[] { ";PopupCenter_Email(", str, ",'edit',", this.ClientID, ");" };
            ScriptManager.RegisterStartupScript(page, type, "__showConfirm", string.Concat(clientID), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid_Email.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Subject").ToString();
            this.RadGrid_Email.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Recipients").ToString();
            this.RadGrid_Email.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("No_Of_Email_Sent").ToString();
            this.RadGrid_Email.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Sent_On1").ToString();
            this.RadGrid_Email.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
            this.RadListBox_Email.Items[0].Text = this.objLangClass.GetLanguageConversion("Delete");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                this.ClientID = int.Parse(arrayLists[1].ToString());
                this.CompanyName = arrayLists[3].ToString();
                this.CompanyType = arrayLists[7].ToString();
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                if (base.Session[string.Concat("searchEmail", this.ClientID)] != null)
                {
                    DataTable dataTable = new DataTable();
                    this.RadGrid_Email.MasterTableView.FilterExpression = "";
                    try
                    {
                        dataTable = (DataTable)base.Session[string.Concat("searchEmail", this.ClientID)];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            GridColumn columnSafe = this.RadGrid_Email.MasterTableView.GetColumnSafe(row["ColumnName"].ToString());
                            columnSafe.CurrentFilterValue = row["FilterText"].ToString();
                        }
                        this.WhereCondition = this.FilterFunction(dataTable);
                    }
                    catch
                    {
                    }
                }
                this.GridEmail(this.CompanyID, this.ClientID, "yes");
            }
            if (!base.IsPostBack && base.Request.Cookies["EmailFiterState"] != null)
            {
                base.Request.Cookies["EmailFiterState"].Value = null;
            }
            this.FilterStatus();
            BaseClass baseClass = new BaseClass();
            this.isView = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString());
            this.isadd = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
        }

        protected void RadGrid_Email_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = EmailsSubSection.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (base.Session[string.Concat("searchEmail", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchEmail", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchEmail", this.ClientID)];
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
                base.Session[string.Concat("searchEmail", this.ClientID)] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                this.GridEmail(this.CompanyID, this.ClientID, "Yes");
                this.RadGrid_Email.Rebind();
                if (str.ToLower() == "datesent")
                {
                    base.Session["CRMDateFilterEmail"] = item.Text;
                    item.Text = this.objcom.Eprint_return_Date_Before_View(item.Text, this.CompanyID, this.UserID, false);
                }
            }
        }

        protected void RadGrid_Email_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_Email = CompanyBasePage.crm_common_select_all_email_new_filter(this.CompanyID, this.ClientID, "Yes", this.WhereCondition);
            this.RadGrid_Email.DataSource = this.dt_Email;
        }

        protected void RadGridEmail_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                BaseClass baseClass = new BaseClass();
                string empty = string.Empty;
                if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.RadGrid_Email.MasterTableView.GetColumn("Delete_Emails").Visible = true;
                    this.RadGrid_Email.MasterTableView.GetColumn("restoreDefault").Visible = true;
                }
                else
                {
                    this.RadGrid_Email.MasterTableView.GetColumn("Delete_Emails").Visible = false;
                    this.RadGrid_Email.MasterTableView.GetColumn("restoreDefault").Visible = false;
                }
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Label str = (Label)e.Item.FindControl("lbl_NoEmailSent");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Recipients");
                    Label label = (Label)e.Item.FindControl("lbl_dateSent");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_dateSent");
                    label.Text = this.objcom.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, false);
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_sl");
                    string[] strArrays = hiddenField.Value.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (strArrays[i] != "")
                        {
                            this.Noof_Recipients = this.Noof_Recipients + 1;
                        }
                    }
                    str.Text = this.Noof_Recipients.ToString();
                    this.Noof_Recipients = 0;
                    GridTableView masterTableView = this.RadGrid_Email.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                    GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    ((LinkButton)items.FindControl("btnclrFilters_Email")).Visible = true;
                }
                if (e.Item.ItemType == GridItemType.FilteringItem)
                {
                    GridFilteringItem item = (GridFilteringItem)e.Item;
                    TextBox textBox = (e.Item as GridFilteringItem)["dateSent"].Controls[0] as TextBox;
                    string regionalSettings = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
                    if (base.Session["CRMDateFilterEmail"] != null && regionalSettings == "dd/mm/yyyy")
                    {
                        textBox.Text = base.Session["CRMDateFilterEmail"].ToString();
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadListBox_Email_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_Email.Items.Count; i++)
            {
                string empty = string.Empty;
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Email.Items[i].Cells[0].FindControl("checkBox_Email");
                if (base.Request.Cookies["RadListBoxEmailsValue"] != null)
                {
                    empty = base.Request.Cookies["RadListBoxEmailsValue"].Value;
                }
                if (empty.ToLower() == "delete" && htmlInputCheckBox.Checked)
                {
                    int num = Convert.ToInt32(htmlInputCheckBox.Value);
                    this.objcomm.crm_common_email_delete("lead", num, 0, this.CompanyID);
                    htmlInputCheckBox.Checked = false;
                    EmailsSubSection usercontrolCrmEmailsSubSection = this;
                    usercontrolCrmEmailsSubSection.cntDelete = usercontrolCrmEmailsSubSection.cntDelete + 1;
                }
            }
            if (this.cntDelete != 0)
            {
                EmailsSubSection.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Email_Deleted_Successfully"), "msg-success", this.plhEmail);
            }
            this.GridEmail(this.CompanyID, this.ClientID, "Yes");
            this.RadGrid_Email.Rebind();
            this.RadListBox_Email.SelectedIndex = this.Index - 1;
            base.Request.Cookies["RadListBoxEmailsValue"].Value = null;
        }
    }
}