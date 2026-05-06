using nmsCommon;
using nmsConnectionClass;
using nmsContact;
using nmsLanguage;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
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

namespace ePrint.common
{
    public partial class selecttaskcontact : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_callclass_ascx Estyle1;

        //protected Label lblquickviewerror;

        //protected Label lblfirstname;

        //protected TextBox txtfirstname;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator1;

        //protected Label lblname;

        //protected TextBox txtname;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator2;

        //protected Label lblalias;

        //protected TextBox txtalias;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator3;

        //protected Label lblmailcity;

        //protected TextBox txtmailcity;

        //protected Label lblmailstate;

        //protected TextBox txtmailstate;

        //protected Label lblmailzip;

        //protected TextBox txtmailzip;

        //protected Label lblothercity;

        //protected TextBox txtothercity;

        //protected Label lblotherstate;

        //protected TextBox txtotherstate;

        //protected Label lblotherzip;

        //protected TextBox txtotherzip;

        //protected Button btnsave;

        //protected Button btnCancel;

        //protected Panel pnlcreatecontact;

        //protected Label lblfirstlead;

        //protected TextBox txtfirstlead;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator4;

        //protected Label lbllastlead;

        //protected TextBox txtlastlead;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator5;

        //protected Label lblcompanylead;

        //protected TextBox txtcompanylead;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator6;

        //protected Label lblleadalias;

        //protected TextBox txtleadalias;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator7;

        //protected Button Button2;

        //protected Button Button1;

        //protected Panel pnlcreatelead;

        //protected usercontrol_callclass_ascx Estyle3;

        //protected Label lblletter;

        //protected GridView GridView1;

        //protected Panel pnllead;

        //protected SqlDataSource SqlDataSource1;

        //protected LinkButton btnclrFilters;

        //protected RadGrid GridView2;

        //protected Panel Panel_Contact;

        //protected Panel Up1;

        private CompanyBasePage objcomm = new CompanyBasePage();

        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        public string contacttype = "";

        public BaseClass objBase = new BaseClass();

        public string tabcolor = "";

        public string forecolor = "";

        public int ClientID;

        public int CompanyID;

        public int PageSize = 25;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage objpage = new BasePage();

        public commonClass cmn = new commonClass();

        private Global gloobj = new Global();

        private DataTable dt_Contact;

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

        public selecttaskcontact()
        {
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            string str = "";
            string lower = this.contacttype.ToLower();
            string str1 = lower;
            if (lower != null)
            {
                if (str1 != "contact")
                {
                    return;
                }
                str = "contact";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                string str10 = "";
                str2 = base.ReplaceSingleQuote(this.txtfirstname.Text.Trim());
                str3 = base.ReplaceSingleQuote(this.txtalias.Text.Trim());
                str4 = base.ReplaceSingleQuote(this.txtname.Text);
                str5 = base.ReplaceSingleQuote(this.txtmailcity.Text.Trim());
                str6 = base.ReplaceSingleQuote(this.txtmailstate.Text.Trim());
                str7 = base.ReplaceSingleQuote(this.txtmailzip.Text.Trim());
                str8 = base.ReplaceSingleQuote(this.txtothercity.Text.Trim());
                str9 = base.ReplaceSingleQuote(this.txtotherstate.Text.Trim());
                str10 = base.ReplaceSingleQuote(this.txtotherzip.Text.Trim());
                if (str4.Trim() == "" || str3.Trim() == "")
                {
                    this.lblquickviewerror.Visible = true;
                    this.lblquickviewerror.Text = this.objLanguage.convert("Please enter last name and alias.");
                    return;
                }
                if (_commonClass.check_aliasfield_duplicacy(str3, str, 0, int.Parse(this.Session["companyID"].ToString())))
                {
                    this.lblquickviewerror.Visible = true;
                    this.lblquickviewerror.Text = string.Concat("Duplicate ", this.objBase.ReturnScreenName("CONTACTS", 2, "l"), " alias.");
                    this.pnlcreatecontact.Visible = true;
                    this.Panel_Contact.Visible = false;
                    return;
                }
                contactClass _contactClass = new contactClass();
                int num = int.Parse(this.Session["companyID"].ToString());
                int num1 = int.Parse(this.Session["userid"].ToString());
                int num2 = int.Parse(this.Session["userid"].ToString());
                string str11 = DateTime.Now.ToString();
                string str12 = DateTime.Now.ToString();
                DateTime now = DateTime.Now;
                int num3 = _contactClass.contact_Add(str3, num, 0, "", str2, str4, "", "", "", "", "", "", "", "", "", 0, "", "", "", 0, num1, num2, str11, str12, now.ToString(), 0, 0, "", str5, str6, str7, "", "", str8, str9, str10, "", false, false, false);
                string str13 = base.ReplaceSingleQuote(this.txtalias.Text.Trim());
                string str14 = string.Concat("", "<script language=javascript>");
                str14 = string.Concat(str14, " window.close(); ");
                object obj = string.Concat(str14, "eval(\"opener.window.document.forms[0]['ctl00_ContentPlaceHolder1_txtcontacttype'].value='", str13, "'\");");
                object[] objArray = new object[] { obj, "eval(\"opener.window.document.forms[0]['ctl00_ContentPlaceHolder1_contactid_hidden'].value='", num3, "'\");" };
                str14 = string.Concat(objArray);
                str14 = string.Concat(str14, "eval(\"opener.window.document.forms[0]['ctl00_ContentPlaceHolder1_contacttxt_hidden'].value='", str13, "'\");");
                str14 = string.Concat(str14, "</script>");
                base.Response.Write(str14);
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridView2.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView2.MasterTableView.FilterExpression = string.Empty;
            this.GridView2.MasterTableView.Rebind();
        }

        protected void ddlpageno1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.GridView1.BottomPagerRow;
            DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
            this.GridView1.PageIndex = dropDownList.SelectedIndex;
            this.GridView1.DataSourceID = "SqlDataSource1";
            this.GridView1.DataBind();
        }

        public void GridContact(int CompanyID)
        {
            this.dt_Contact = CompanyBasePage.client_contact_selectnew(CompanyID);
            for (int i = 0; i < this.dt_Contact.Columns.Count; i++)
            {
                this.dt_Contact.Columns[i].ReadOnly = false;
            }
            if (this.dt_Contact != null)
            {
                foreach (DataRow row in this.dt_Contact.Rows)
                {
                    if (row.Table.Columns.Contains("FirstName"))
                    {
                        row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                    }
                    if (row.Table.Columns.Contains("LastName"))
                    {
                        row["LastName"] = this.objBase.SpecialDecode(row["LastName"].ToString());
                    }
                    if (!row.Table.Columns.Contains("email"))
                    {
                        continue;
                    }
                    row["email"] = this.objBase.SpecialDecode(row["email"].ToString());
                }
            }
            this.GridView2.DataSource = this.dt_Contact;
            this.GridView2.VirtualItemCount = this.dt_Contact.Rows.Count;
            this.GridView2.DataBind();
        }

        private void GridStateLoad()
        {
            this.cmn.GridStateLoadNew("Task", "TaskContact", this.GridView2, "no");
        }

        private void GridStateSave()
        {
            this.cmn.GridStateSaveNew("Task", "TaskContact", this.GridView2);
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridViewRow bottomPagerRow = this.GridView1.BottomPagerRow;
            if (this.GridView1.Rows.Count != 0)
            {
                DropDownList dropDownList = (DropDownList)bottomPagerRow.Cells[0].FindControl("ddlpageno");
                Label str = (Label)bottomPagerRow.Cells[0].FindControl("lblpageno");
                if (dropDownList != null)
                {
                    for (int i = 0; i < this.GridView1.PageCount; i++)
                    {
                        ListItem listItem = new ListItem((i + 1).ToString());
                        if (i == this.GridView1.PageIndex)
                        {
                            listItem.Selected = true;
                        }
                        dropDownList.Items.Add(listItem);
                    }
                }
                if (str != null)
                {
                    int pageIndex = this.GridView1.PageIndex + 1;
                    int pageCount = this.GridView1.PageCount;
                    str.Text = pageCount.ToString();
                    ImageButton imageButton = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnFirst");
                    ImageButton imageButton1 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnLast");
                    ImageButton imageButton2 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnPrev");
                    ImageButton imageButton3 = (ImageButton)this.GridView1.BottomPagerRow.FindControl("lbtnNext");
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSourceID = "SqlDataSource1";
            this.GridView1.DataBind();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            Label str = (Label)this.GridView1.BottomPagerRow.Cells[0].FindControl("lblpageno");
            if (this.GridView1.BottomPagerRow != null)
            {
                int pageIndex = this.GridView1.PageIndex + 1;
                int pageCount = this.GridView1.PageCount;
                str.Text = pageIndex.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            if (e.Row.RowType == DataControlRowType.Header)
            {
                setProperty.MakeGridViewHeaderClickable(this.GridView1, e.Row, this.companyid, base.Request.Params["contacttype"].ToString());
            }
            DataControlRowType rowType = e.Row.RowType;
        }

        protected void GridView2_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_Contact = CompanyBasePage.client_contact_selectnew(this.CompanyID);
            this.GridView2.DataSource = this.dt_Contact;
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
                    string[] strArrays = new string[] { "javascript:f1('", this.objBase.SpecialEncode(hiddenField.Value), " ", this.objBase.SpecialEncode(hiddenField1.Value), "','", hiddenField2.Value, "');" };
                    attributes.Add("onclick", string.Concat(strArrays));
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView2.FilterMenu;
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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView2.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
            this.GridView2.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Email");
            this.gloobj.setpagename("home");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.SqlDataSource1.ConnectionString = this.cmn.strConnection;
            this.btnsave.Text = this.objLanguage.GetLanguageConversion(this.btnsave.Text);
            this.RequiredFieldValidator1.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator1.ErrorMessage);
            this.RequiredFieldValidator2.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator2.ErrorMessage);
            this.RequiredFieldValidator3.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator3.ErrorMessage);
            this.RequiredFieldValidator4.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator4.ErrorMessage);
            this.RequiredFieldValidator5.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator5.ErrorMessage);
            this.RequiredFieldValidator6.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator6.ErrorMessage);
            this.RequiredFieldValidator7.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator7.ErrorMessage);
            this.Button2.Text = this.objLanguage.convert(this.Button2.Text);
            this.RequiredFieldValidator7.ErrorMessage = string.Concat("Please enter ", this.objBase.ReturnScreenName("LEADS", 2, "l"), " alias");
            this.RequiredFieldValidator3.ErrorMessage = string.Concat("Please enter ", this.objBase.ReturnScreenName("CONTACTS", 2, "l"), " alias");
            this.lblalias.Text = string.Concat(this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " Alias");
            this.lblquickviewerror.Visible = false;
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            base.Title = this.objLanguage.GetLanguageConversion(global.pageTitle(string.Concat("Select Task ", this.objBase.ReturnScreenName("CONTACTS", 2, "p")), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.lblfirstlead.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "First Name", "lead");
            this.lbllastlead.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Last Name", "lead");
            this.lblcompanylead.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Company Name", "lead");
            this.lblleadalias.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Lead Alias", "lead");
            this.lblfirstname.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "First Name", "contact");
            this.lblname.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Last Name", "contact");
            this.lblmailcity.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Mailing City", "contact");
            this.lblmailstate.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Mailing State", "contact");
            this.lblmailzip.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Mailing Zip", "contact");
            this.lblothercity.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Alternate City", "contact");
            this.lblotherstate.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Alternate State", "contact");
            this.lblotherzip.Text = global.GetScreenName(int.Parse(this.Session["companyid"].ToString()), "Alternate Zip", "contact");
            this.contacttype = base.Request.Params["contacttype"].ToString();
            this.pnlcreatecontact.Visible = false;
            this.pnlcreatelead.Visible = false;
            this.Panel_Contact.Visible = false;
            this.pnllead.Visible = false;
            string lower = this.contacttype.ToLower();
            if (lower != null && lower == "contact")
            {
                this.Panel_Contact.Visible = true;
            }
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                this.ClientID = int.Parse(arrayLists[1].ToString());
            }
            catch
            {
            }
            this.GridContact(this.CompanyID);
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
        }
    }
}