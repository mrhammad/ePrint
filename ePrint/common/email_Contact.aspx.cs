using nmsCampaign;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsLead;
using nmsMassdelete;
using nmsView;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class email_Contact : BaseClass, IRequiresSessionState
    {
        public string test = string.Empty;

        public string strImagepath = global.imagePath();

        public string pg = "lead";

        public string rowColor = "";

        public string lblDate = DateTime.Now.ToString();

        public commonClass objCommon = new commonClass();

        public massdeleteClass objMassdelete = new massdeleteClass();

        public languageClass objLanguage = new languageClass();

        public int companyId;

        public int userId;

        public int adminRight;

        public string sectionname = "";

        public int sectionid;

        public string section = "Campaign";

        public string subsection = "Search Lead Email";

        public static int sortedType;

        public viewClass objView = new viewClass();

        public string strRedirect = string.Empty;

        public string MixLeadEmail = string.Empty;

        public string MixContactEmail = string.Empty;

        public string LeadidEmail = string.Empty;

        public string ContactidEmail = string.Empty;

        public string MixLeadidEmail = string.Empty;

        public string MixContactidEmail = string.Empty;

        public string tabcolor = "";

        public string forecolor = "";

        public int companyid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage objpage = new BasePage();

        private Global gloobj = new Global();

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

        static email_Contact()
        {
        }

        public email_Contact()
        {
        }

        protected void btn_Command(object sender, CommandEventArgs e)
        {
            this.lblLeadSection.Text = "Lead";
            this.lblletter.Text = e.CommandArgument.ToString();
            this.CheckRecord("Lead");
        }

        protected void btnContact_Command(object sender, CommandEventArgs e)
        {
            this.lblContactSection.Text = "Contact";
            this.lblletterContact.Text = e.CommandArgument.ToString();
            this.CheckRecord("Contact");
        }

        protected void btnFriend_Command(object sender, CommandEventArgs e)
        {
            this.lblFriendSection.Text = "Friend";
            this.lblletterFriend.Text = e.CommandArgument.ToString();
            this.CheckRecord("Friend");
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string str = "";
            leadClass _leadClass = new leadClass();
            if (this.hdnTabSelect.Value == "Lead")
            {
                for (int i = 0; i < this.dgrLead.Rows.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.dgrLead.Rows[i].Cells[0].FindControl("leadId");
                    Label label = (Label)this.dgrLead.Rows[i].Cells[0].FindControl("lblLead");
                    if (htmlInputCheckBox.Checked)
                    {
                        str = string.Concat(str, base.ReplaceSingleQuote(htmlInputCheckBox.Value.ToString()), ",");
                        email_Contact campaignTest = this;
                        campaignTest.LeadidEmail = string.Concat(campaignTest.LeadidEmail, base.ReplaceSingleQuote(label.Text.ToString()), ",");
                    }
                }
                try
                {
                    str = str.Substring(0, str.Length - 1);
                    this.LeadidEmail = this.LeadidEmail.Substring(0, this.LeadidEmail.Length - 1);
                }
                catch
                {
                }
            }
            else if (this.hdnTabSelect.Value == "Contact")
            {
                for (int j = 0; j < this.dgrContact.Items.Count; j++)
                {
                    HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox();
                    htmlInputCheckBox1 = (HtmlInputCheckBox)this.dgrContact.Items[j].Cells[0].FindControl("contactId");
                    Label label1 = (Label)this.dgrContact.Items[j].Cells[0].FindControl("lblContact");
                    if (htmlInputCheckBox1.Checked && htmlInputCheckBox1.Value.ToString() != "")
                    {
                        str = string.Concat(str, base.ReplaceSingleQuote(htmlInputCheckBox1.Value.ToString()), ",");
                        email_Contact campaignTest1 = this;
                        campaignTest1.ContactidEmail = string.Concat(campaignTest1.ContactidEmail, base.ReplaceSingleQuote(label1.Text.ToString()), ",");
                    }
                }
                str = str.Substring(0, str.Length - 1);
                this.ContactidEmail = this.ContactidEmail.Substring(0, this.ContactidEmail.Length - 1);
            }
            else if (this.hdnTabSelect.Value == "Friend")
            {
                for (int k = 0; k < this.dgrFriend.Rows.Count; k++)
                {
                    HtmlInputCheckBox htmlInputCheckBox2 = new HtmlInputCheckBox();
                    htmlInputCheckBox2 = (HtmlInputCheckBox)this.dgrFriend.Rows[k].Cells[0].FindControl("addressListId");
                    if (htmlInputCheckBox2.Checked)
                    {
                        commonClass _commonClass = new commonClass();
                        SqlCommand sqlCommand = new SqlCommand("sp_Select_AddressListVale", _commonClass.openConnection());
                        sqlCommand.Parameters.Add("@AddressListID", int.Parse(htmlInputCheckBox2.Value.ToString()));
                        sqlCommand.Parameters.Add("@CompanyID", int.Parse(this.Session["companyID"].ToString()));
                        sqlCommand.Parameters.Add("@UserID", int.Parse(this.Session["userID"].ToString()));
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        while (sqlDataReader.Read())
                        {
                            str = string.Concat(str, sqlDataReader["Email"].ToString(), ",");
                            email_Contact campaignTest2 = this;
                            campaignTest2.MixLeadEmail = string.Concat(campaignTest2.MixLeadEmail, sqlDataReader["Email"].ToString(), ",");
                            email_Contact campaignTest3 = this;
                            campaignTest3.MixLeadidEmail = string.Concat(campaignTest3.MixLeadidEmail, sqlDataReader["leadid"].ToString(), ",");
                        }
                        sqlDataReader.NextResult();
                        while (sqlDataReader.Read())
                        {
                            str = string.Concat(str, sqlDataReader["Email"].ToString(), ",");
                            email_Contact campaignTest4 = this;
                            campaignTest4.MixContactEmail = string.Concat(campaignTest4.MixContactEmail, sqlDataReader["Email"].ToString(), ",");
                            email_Contact campaignTest5 = this;
                            campaignTest5.MixContactidEmail = string.Concat(campaignTest5.MixContactidEmail, sqlDataReader["contactid"].ToString(), ",");
                        }
                        sqlDataReader.Close();
                        _commonClass.closeConnection();
                    }
                }
                try
                {
                    this.MixLeadEmail = this.MixLeadEmail.Substring(0, this.MixLeadEmail.Length - 1);
                    this.MixLeadidEmail = this.MixLeadidEmail.Substring(0, this.MixLeadidEmail.Length - 1);
                }
                catch
                {
                }
                try
                {
                    this.MixContactEmail = this.MixContactEmail.Substring(0, this.MixContactEmail.Length - 1);
                    this.MixContactidEmail = this.MixContactidEmail.Substring(0, this.MixContactidEmail.Length - 1);
                }
                catch
                {
                }
            }
            this.strRedirect = str;
            this.pnl_WinClose.Visible = true;
        }

        protected void btngocontact_OnClick(object sender, EventArgs e)
        {
            this.lblContactSection.Text = "Contact";
            this.CheckRecord("Contact");
        }

        protected void btngofriend_OnClick(object sender, EventArgs e)
        {
            this.lblFriendSection.Text = "Friend";
            this.lblletterFriend.Text = base.ReplaceSingleQuote(this.keywordsearchFriend.Text);
            this.CheckRecord("Friend");
        }

        protected void btngolead_OnClick(object sender, EventArgs e)
        {
            this.lblLeadSection.Text = "Lead";
            this.lblletter.Text = base.ReplaceSingleQuote(this.keywordsearch.Text);
            this.CheckRecord("Lead");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.CheckRecord(base.ReplaceSingleQuote(this.hdnTabSelect.Value));
            campaignClass _campaignClass = new campaignClass();
            if (this.hdnTabSelect.Value == "Lead")
            {
                if (this.ddlLeadMoreAction.SelectedValue != "5")
                {
                    this.lblConfirmation.Visible = true;
                    this.lblConfirmation.Text = "Record has been added";
                    for (int i = 0; i < this.dgrLead.Rows.Count; i++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                        Label label = (Label)this.dgrLead.Rows[i].Cells[0].FindControl("lblLead");
                        if (((HtmlInputCheckBox)this.dgrLead.Rows[i].Cells[0].FindControl("leadId")).Checked)
                        {
                            _campaignClass.InsertAddressListValue(int.Parse(this.ddlAddressList.SelectedValue), int.Parse(label.Text.ToString()), "Lead", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                        }
                    }
                }
                else
                {
                    int num = _campaignClass.InsertAddressList(base.ReplaceSingleQuote(this.txtAddtrssList.Text), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                    if (num == -1)
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "AddressListName already exists";
                    }
                    else
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "Record has been added";
                        for (int j = 0; j < this.dgrLead.Rows.Count; j++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox();
                            Label label1 = (Label)this.dgrLead.Rows[j].Cells[0].FindControl("lblLead");
                            if (((HtmlInputCheckBox)this.dgrLead.Rows[j].Cells[0].FindControl("leadId")).Checked)
                            {
                                _campaignClass.InsertAddressListValue(num, int.Parse(label1.Text.ToString()), "Lead", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                            }
                        }
                    }
                }
            }
            else if (this.hdnTabSelect.Value == "Contact")
            {
                if (this.ddlLeadMoreAction.SelectedValue != "5")
                {
                    this.lblConfirmation.Visible = true;
                    this.lblConfirmation.Text = "Record has been added";
                    for (int k = 0; k < this.dgrContact.Items.Count; k++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox2 = new HtmlInputCheckBox();
                        Label label2 = (Label)this.dgrContact.Items[k].Cells[0].FindControl("lblContact");
                        if (((HtmlInputCheckBox)this.dgrContact.Items[k].Cells[0].FindControl("contactId")).Checked)
                        {
                            _campaignClass.InsertAddressListValue(int.Parse(this.ddlAddressList.SelectedValue), int.Parse(label2.Text.ToString()), "Contact", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                        }
                    }
                }
                else
                {
                    int num1 = _campaignClass.InsertAddressList(base.ReplaceSingleQuote(this.txtAddtrssList.Text), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                    if (num1 == -1)
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "AddressListName already exists";
                    }
                    else
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "Record has been added";
                        for (int l = 0; l < this.dgrContact.Items.Count; l++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox3 = new HtmlInputCheckBox();
                            Label label3 = (Label)this.dgrContact.Items[l].Cells[0].FindControl("lblContact");
                            if (((HtmlInputCheckBox)this.dgrContact.Items[l].Cells[0].FindControl("contactId")).Checked)
                            {
                                _campaignClass.InsertAddressListValue(num1, int.Parse(label3.Text.ToString()), "Contact", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                            }
                        }
                    }
                }
            }
            else if (this.hdnTabSelect.Value == "Friend")
            {
                if (this.ddlLeadMoreAction.SelectedValue != "5")
                {
                    this.lblConfirmation.Visible = true;
                    this.lblConfirmation.Text = "Record has been added";
                    for (int m = 0; m < this.dgrFriend.Rows.Count; m++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox4 = new HtmlInputCheckBox();
                        htmlInputCheckBox4 = (HtmlInputCheckBox)this.dgrFriend.Rows[m].Cells[0].FindControl("addressListId");
                        if (htmlInputCheckBox4.Checked)
                        {
                            commonClass _commonClass = new commonClass();
                            SqlCommand sqlCommand = new SqlCommand("sp_Select_AddressListVale_for_insert", _commonClass.openConnection());
                            sqlCommand.Parameters.Add("@AddressListID", int.Parse(htmlInputCheckBox4.Value.ToString()));
                            sqlCommand.Parameters.Add("@CompanyID", int.Parse(this.Session["companyID"].ToString()));
                            sqlCommand.Parameters.Add("@UserID", int.Parse(this.Session["userID"].ToString()));
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                            while (sqlDataReader.Read())
                            {
                                _campaignClass.InsertAddressListValue(int.Parse(this.ddlAddressList.SelectedValue), int.Parse(sqlDataReader["leadid"].ToString()), "Lead", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                            }
                            sqlDataReader.NextResult();
                            while (sqlDataReader.Read())
                            {
                                _campaignClass.InsertAddressListValue(int.Parse(this.ddlAddressList.SelectedValue), int.Parse(sqlDataReader["contactid"].ToString()), "Contact", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                            }
                            sqlDataReader.Close();
                            _commonClass.closeConnection();
                        }
                    }
                }
                else
                {
                    int num2 = _campaignClass.InsertAddressList(base.ReplaceSingleQuote(this.txtAddtrssList.Text), int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                    if (num2 == -1)
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "AddressListName already exists";
                    }
                    else
                    {
                        this.lblConfirmation.Visible = true;
                        this.lblConfirmation.Text = "Record has been added";
                        for (int n = 0; n < this.dgrFriend.Rows.Count; n++)
                        {
                            HtmlInputCheckBox htmlInputCheckBox5 = new HtmlInputCheckBox();
                            htmlInputCheckBox5 = (HtmlInputCheckBox)this.dgrFriend.Rows[n].Cells[0].FindControl("addressListId");
                            if (htmlInputCheckBox5.Checked)
                            {
                                commonClass _commonClass1 = new commonClass();
                                SqlCommand sqlCommand1 = new SqlCommand("sp_Select_AddressListVale_for_insert", _commonClass1.openConnection());
                                sqlCommand1.Parameters.Add("@AddressListID", int.Parse(htmlInputCheckBox5.Value.ToString()));
                                sqlCommand1.Parameters.Add("@CompanyID", int.Parse(this.Session["companyID"].ToString()));
                                sqlCommand1.Parameters.Add("@UserID", int.Parse(this.Session["userID"].ToString()));
                                sqlCommand1.CommandType = CommandType.StoredProcedure;
                                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
                                while (sqlDataReader1.Read())
                                {
                                    _campaignClass.InsertAddressListValue(num2, int.Parse(sqlDataReader1["leadid"].ToString()), "Lead", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                                }
                                sqlDataReader1.NextResult();
                                while (sqlDataReader1.Read())
                                {
                                    _campaignClass.InsertAddressListValue(num2, int.Parse(sqlDataReader1["contactid"].ToString()), "Contact", int.Parse(this.Session["companyid"].ToString()), int.Parse(this.Session["userID"].ToString()));
                                }
                                sqlDataReader1.Close();
                                _commonClass1.closeConnection();
                            }
                        }
                    }
                }
            }
            _campaignClass.BindAddressList(this.ddlAddressList, int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userID"].ToString()));
            this.dgrLead.DataSourceID = "SqlDataSourceLead";
            this.dgrContact.DataSourceID = "SqlDataSourceContact";
            this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
            this.dgrLead.DataBind();
            this.dgrContact.DataBind();
            this.dgrFriend.DataBind();
        }

        public void CheckRecord(string Section)
        {
            string section = Section;
            string str = section;
            if (section != null)
            {
                if (str == "Lead")
                {
                    if (this.lblLeadSection.Text.Length == 0)
                    {
                        this.lblCounterLead.Visible = false;
                    }
                    else
                    {
                        this.lblCounterLead.Visible = true;
                        Label label = this.lblCounterLead;
                        int count = this.dgrLead.Rows.Count;
                        label.Text = string.Concat(count.ToString(), " records found with this search parameter.");
                    }
                    if (this.dgrLead.Rows.Count == 0)
                    {
                        this.ddlNoOfRecord_Lead.Visible = false;
                        this.tableMoreAction.Style.Add("display", "none");
                        return;
                    }
                    this.ddlNoOfRecord_Lead.Visible = true;
                    this.tableMoreAction.Style.Add("display", "block");
                    return;
                }
                if (str == "Contact")
                {
                    int length = this.lblContactSection.Text.Length;
                    if (this.dgrContact.Items.Count == 0)
                    {
                        this.tableMoreAction.Style.Add("display", "none");
                        return;
                    }
                    this.tableMoreAction.Style.Add("display", "block");
                    return;
                }
                if (str != "Friend")
                {
                    return;
                }
                if (this.lblFriendSection.Text.Length == 0)
                {
                    this.lblCounterFrend.Visible = false;
                }
                else
                {
                    this.lblCounterFrend.Visible = true;
                    Label label1 = this.lblCounterFrend;
                    int num = this.dgrFriend.Rows.Count;
                    label1.Text = string.Concat(num.ToString(), " records found with this search parameter.");
                }
                if (this.dgrFriend.Rows.Count == 0)
                {
                    this.ddlNoOfRecord_Friend.Visible = false;
                    this.tableMoreAction.Style.Add("display", "none");
                    return;
                }
                this.ddlNoOfRecord_Friend.Visible = true;
                this.tableMoreAction.Style.Add("display", "block");
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.dgrContact.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.dgrContact.MasterTableView.FilterExpression = string.Empty;
            this.dgrContact.MasterTableView.Rebind();
        }

        protected void ddlnoofrecordsperpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Lead");
            this.dgrLead.PageSize = int.Parse(this.ddlnoofrecordsperpage.SelectedValue.ToString());
            this.dgrLead.PageIndex = 0;
            this.dgrLead.DataSourceID = "SqlDataSourceLead";
            this.dgrLead.DataBind();
        }

        protected void ddlnoofrecordsperpageContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Contact");
            this.dgrContact.DataSourceID = "SqlDataSourceContact";
            this.dgrContact.DataBind();
        }

        protected void ddlnoofrecordsperpageFriend_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Friend");
            this.dgrFriend.PageSize = int.Parse(this.ddlnoofrecordsperpageFriend.SelectedValue.ToString());
            this.dgrFriend.PageIndex = 0;
            this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
            this.dgrFriend.DataBind();
        }

        protected void ddlpageno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Lead");
            GridViewRow bottomPagerRow = this.dgrLead.BottomPagerRow;
            DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
            this.dgrLead.PageIndex = dropDownList.SelectedIndex;
            this.dgrLead.DataSourceID = "SqlDataSourceLead";
            this.dgrLead.DataBind();
        }

        protected void ddlpagenoContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Contact");
            this.dgrContact.DataSourceID = "SqlDataSourceContact";
            this.dgrContact.DataBind();
        }

        protected void ddlpagenoFriend_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckRecord("Friend");
            GridViewRow bottomPagerRow = this.dgrFriend.BottomPagerRow;
            DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpagenoFriend");
            this.dgrFriend.PageIndex = dropDownList.SelectedIndex;
            this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
            this.dgrFriend.DataBind();
        }

        protected void dgrContact_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataSourceSelectArguments dataSourceSelectArgument = new DataSourceSelectArguments();
            dataTable = (DataTable)this.SqlDataSourceContact.Select(dataSourceSelectArgument);
            foreach (DataRow row in dataTable.Rows)
            {
                row["email"] = base.SpecialDecode(row["email"].ToString());
                row["Name"] = base.SpecialDecode(row["Name"].ToString());
                row["ClientName"] = base.SpecialDecode(row["ClientNAme"].ToString());
            }
            this.dgrContact.DataSource = dataTable;
            this.dgrContact.DataBind();
        }

        protected void dgrContact_RowDataBound(object sender, GridItemEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lblEmail");
                label.Text = base.SpecialDecode(label.Text);
            }
            GridItemType itemType = e.Item.ItemType;
        }

        protected void dgrFriend_DataBound(object sender, EventArgs e)
        {
            this.CheckRecord("Friend");
            GridViewRow bottomPagerRow = this.dgrFriend.BottomPagerRow;
            if (this.dgrFriend.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpagenoFriend");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpagenoFriend");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.dgrFriend.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.dgrFriend.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.dgrFriend.PageIndex + 1;
                    int pageCount = this.dgrFriend.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.dgrFriend.BottomPagerRow.FindControl("lbtnFirstFriend");
                    ImageButton imageButton1 = (ImageButton)this.dgrFriend.BottomPagerRow.FindControl("lbtnLastFriend");
                    ImageButton imageButton2 = (ImageButton)this.dgrFriend.BottomPagerRow.FindControl("lbtnPrevFriend");
                    ImageButton imageButton3 = (ImageButton)this.dgrFriend.BottomPagerRow.FindControl("lbtnNextFriend");
                    imageButton.ToolTip = this.objLanguage.convert("First");
                    imageButton1.ToolTip = this.objLanguage.convert("Last");
                    imageButton2.ToolTip = this.objLanguage.convert("Previous");
                    imageButton3.ToolTip = this.objLanguage.convert("Next");
                    if (pageIndex < pageCount)
                    {
                        imageButton3.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton.Enabled = false;
                        imageButton2.Enabled = false;
                    }
                    if (pageIndex == pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = false;
                        imageButton3.Enabled = false;
                    }
                    if (pageIndex > 1 && pageIndex < pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton3.Enabled = true;
                    }
                }
            }
        }

        protected void dgrFriend_PageIndexChanging(object source, GridViewPageEventArgs e)
        {
            this.CheckRecord("Friend");
            this.dgrFriend.PageIndex = e.NewPageIndex;
            this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
            this.dgrFriend.DataBind();
        }

        protected void dgrFriend_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.dgrFriend.BottomPagerRow.Cells[0].FindControl("lblpagenoFriend");
            if (this.dgrFriend.BottomPagerRow != null)
            {
                int pageIndex = this.dgrFriend.PageIndex + 1;
                int pageCount = this.dgrFriend.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void dgrFriend_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            DataControlRowType rowType = e.Row.RowType;
            DataControlRowType dataControlRowType = e.Row.RowType;
        }

        protected void dgrLead_DataBound(object sender, EventArgs e)
        {
            this.CheckRecord("Lead");
            GridViewRow bottomPagerRow = this.dgrLead.BottomPagerRow;
            if (this.dgrLead.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpagenoLead");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.dgrLead.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.dgrLead.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.dgrLead.PageIndex + 1;
                    int pageCount = this.dgrLead.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.dgrLead.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.dgrLead.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.dgrLead.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.dgrLead.BottomPagerRow.FindControl("lbtnNext");
                    imageButton.ToolTip = this.objLanguage.convert("First");
                    imageButton1.ToolTip = this.objLanguage.convert("Last");
                    imageButton2.ToolTip = this.objLanguage.convert("Previous");
                    imageButton3.ToolTip = this.objLanguage.convert("Next");
                    if (pageIndex < pageCount)
                    {
                        imageButton3.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton.Enabled = false;
                        imageButton2.Enabled = false;
                    }
                    if (pageIndex == pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = false;
                        imageButton3.Enabled = false;
                    }
                    if (pageIndex > 1 && pageIndex < pageCount)
                    {
                        imageButton.Enabled = true;
                        imageButton2.Enabled = true;
                        imageButton1.Enabled = true;
                        imageButton3.Enabled = true;
                    }
                }
            }
        }

        protected void dgrLead_PageIndexChanging(object source, GridViewPageEventArgs e)
        {
            this.CheckRecord("Lead");
            this.dgrLead.PageIndex = e.NewPageIndex;
            this.dgrLead.DataSourceID = "SqlDataSourceLead";
            this.dgrLead.DataBind();
        }

        protected void dgrLead_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.dgrLead.BottomPagerRow.Cells[0].FindControl("lblpagenoLead");
            if (this.dgrLead.BottomPagerRow != null)
            {
                int pageIndex = this.dgrLead.PageIndex + 1;
                int pageCount = this.dgrLead.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void dgrLead_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            DataControlRowType rowType = e.Row.RowType;
            DataControlRowType dataControlRowType = e.Row.RowType;
        }

        protected void LinkButton_Select(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Lead")
            {
                this.CheckRecord("Lead");
                this.maindivLead.Attributes.Add("class", "searchTab selectedSearchTab");
                this.maindivLead.Attributes.Add("onmouseover", "javascript:handleTabRollover('over','a','ctl00_ContentPlaceHolder1_maindivLead');");
                this.maindivLead.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','a','ctl00_ContentPlaceHolder1_maindivLead');");
                this.maindivContact.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivContact');");
                this.maindivFriend.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivFriend');");
                this.maindivContact.Attributes.Add("class", "searchTab");
                this.maindivFriend.Attributes.Add("class", "searchTab");
                this.pnlLead.Visible = true;
                this.pnlContact.Visible = false;
                this.pnlFriend.Visible = false;
                this.hdnTabSelect.Value = "Lead";
                return;
            }
            if (e.CommandArgument.ToString() == "Contact")
            {
                this.maindivContact.Attributes.Add("class", "searchTab selectedSearchTab");
                this.maindivContact.Attributes.Add("onmouseover", "javascript:handleTabRollover('over','a','ctl00_ContentPlaceHolder1_maindivContact');");
                this.maindivContact.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','a','ctl00_ContentPlaceHolder1_maindivContact');");
                this.maindivLead.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivLead');");
                this.maindivFriend.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivFriend');");
                this.maindivLead.Attributes.Add("class", "searchTab");
                this.maindivFriend.Attributes.Add("class", "searchTab");
                this.CheckRecord("Contact");
                this.pnlLead.Visible = false;
                this.pnlContact.Visible = true;
                this.pnlFriend.Visible = false;
                this.hdnTabSelect.Value = "Contact";
                return;
            }
            this.maindivLead.Attributes.Add("class", "searchTab");
            this.maindivContact.Attributes.Add("class", "searchTab");
            this.maindivFriend.Attributes.Add("class", "searchTab selectedSearchTab");
            this.maindivFriend.Attributes.Add("onmouseover", "javascript:handleTabRollover('over','a','ctl00_ContentPlaceHolder1_maindivFriend');");
            this.maindivFriend.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','a','ctl00_ContentPlaceHolder1_maindivFriend');");
            this.maindivContact.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivContact');");
            this.maindivLead.Attributes.Add("onmouseout", "javascript:handleTabRollover('out','c','ctl00_ContentPlaceHolder1_maindivLead');");
            this.CheckRecord("Friend");
            this.pnlLead.Visible = false;
            this.pnlContact.Visible = false;
            this.pnlFriend.Visible = true;
            this.hdnTabSelect.Value = "Friend";
        }

        protected void lnkDeleteCommand_Click(object sender, CommandEventArgs e)
        {
            campaignClass _campaignClass = new campaignClass();
            SqlCommand sqlCommand = new SqlCommand("sp_AddressList_delete", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@AddressListID", int.Parse(e.CommandArgument.ToString()));
            sqlCommand.Parameters.Add("@CompanyID", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.Parameters.Add("@UserID", int.Parse(this.Session["userID"].ToString()));
            sqlCommand.ExecuteNonQuery();
            this.lblDeleteConfirmation.Visible = true;
            this.lblDeleteConfirmation.Text = "AddressList has been deleted";
            _campaignClass.BindAddressList(this.ddlAddressList, int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userID"].ToString()));
            this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
            this.dgrFriend.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.dgrContact.FilterMenu;
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = int.Parse(this.Session["companyID"].ToString());
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            global.pgDetail = "Campaign >> Search leads email";
            this.gloobj.setpagename(base.Request.Params["sectionname"].ToString());
            this.sectionid = int.Parse(base.Request.Params["sectionid"].ToString());
            this.sectionname = base.Request.Params["sectionname"].ToString();
            if (this.sectionname.ToLower() == "printbroker")
            {
                this.gloobj.setpagename("Estimate");
            }
            this.SqlDataSourceLead.ConnectionString = this.objCommon.strConnection;
            this.SqlDataSourceContact.ConnectionString = this.objCommon.strConnection;
            this.SqlDataSourceFriend.ConnectionString = this.objCommon.strConnection;
            if (!base.IsPostBack)
            {
                for (int i = 1; i < this.ddlLeadMoreAction.Items.Count; i++)
                {
                    this.ddlLeadMoreAction.Items[i].Text = string.Concat(this.Padding, base.ReplaceSingleQuote(this.ddlLeadMoreAction.Items[i].Text));
                }
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Search  Email", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.companyId = int.Parse(this.Session["companyID"].ToString());
            this.userId = int.Parse(this.Session["userID"].ToString());
            this.adminRight = int.Parse(this.Session["admin"].ToString());
            SetProperties setProperty = new SetProperties();
            this.tabcolor = this.objpage.colorCode(this.companyid, this.sectionname);
            this.forecolor = this.objpage.Forecolor(this.companyid, this.sectionname);
            this.btnGo.BackColor = Color.FromName(this.tabcolor);
            this.btngolead.BackColor = Color.FromName(this.tabcolor);
            this.btngofriend.BackColor = Color.FromName(this.tabcolor);
            this.btnSave.BackColor = Color.FromName(this.tabcolor);
            this.dgrLead.HeaderStyle.BackColor = Color.FromName(this.tabcolor);
            this.dgrFriend.HeaderStyle.BackColor = Color.FromName(this.tabcolor);
            this.dgrLead.HeaderStyle.ForeColor = Color.FromName(this.forecolor);
            this.dgrFriend.HeaderStyle.ForeColor = Color.FromName(this.forecolor);
            if (!base.IsPostBack)
            {
                this.lblshow.Text = this.objLanguage.convert(this.lblshow.Text);
                this.lblshowFriend.Text = this.objLanguage.convert(this.lblshowFriend.Text);
                this.lblrecordsperpage.Text = this.objLanguage.convert(this.lblrecordsperpage.Text);
                this.lblrecordsperpageFriend.Text = this.objLanguage.convert(this.lblrecordsperpageFriend.Text);
                for (int j = 0; j < this.dgrLead.Columns.Count; j++)
                {
                    this.dgrLead.Columns[j].HeaderText = this.objLanguage.convert(this.dgrLead.Columns[j].HeaderText);
                }
                for (int k = 0; k < this.dgrContact.Columns.Count; k++)
                {
                    this.dgrContact.Columns[k].HeaderText = this.objLanguage.convert(this.dgrContact.Columns[k].HeaderText);
                }
                for (int l = 0; l < this.dgrFriend.Columns.Count; l++)
                {
                    this.dgrFriend.Columns[l].HeaderText = this.objLanguage.convert(this.dgrFriend.Columns[l].HeaderText);
                }
                this.objView.initialize_noOfRecordsPerPage(this.ddlnoofrecordsperpage);
                this.objView.initialize_noOfRecordsPerPage(this.ddlnoofrecordsperpageFriend);
                this.dgrLead.DataSourceID = "SqlDataSourceLead";
                this.dgrContact.DataSourceID = "SqlDataSourceContact";
                this.dgrFriend.DataSourceID = "SqlDataSourceFriend";
                this.dgrLead.DataBind();
                this.dgrContact.DataBind();
                this.dgrFriend.DataBind();
                this.ddlnoofrecordsperpage.SelectedIndex = 1;
                this.ddlnoofrecordsperpageFriend.SelectedIndex = 1;
                campaignClass _campaignClass = new campaignClass();
                _campaignClass.BindAddressList(this.ddlAddressList, int.Parse(this.Session["companyID"].ToString()), int.Parse(this.Session["userID"].ToString()));
                if (this.ddlAddressList.Items.Count > 1)
                {
                    this.lnkAddressList.Visible = false;
                }
                this.lblDeleteConfirmation.Visible = false;
                this.CheckRecord(base.ReplaceSingleQuote(this.hdnTabSelect.Value));
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objMassdelete.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objMassdelete.functionCheckChange());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAllButton"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAllButton", this.objMassdelete.functionCheckAllButton());
            }
            this.ddlLeadMoreAction.Attributes.Add("onchange", "javascript:return HideShowAddressList(); return true;");
            this.lnkLead.Text = base.ReturnScreenName("LEADS", 1, "p");
            this.lnkContact.Text = base.ReturnScreenName("CONTACTS", 1, "p");
            this.lnkSavedAddress.Text = this.objLanguage.convert("Saved Address");
            this.lnkLead.Attributes.Add("onclick", "javascript:HideButton();");
            this.lnkContact.Attributes.Add("onclick", "javascript:HideButton();");
            this.lnkAddressList.Attributes.Add("onclick", "javascript:HideButton();");
        }
    }
}