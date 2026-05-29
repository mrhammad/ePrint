using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.contact
{
    public partial class contact_view : BaseClass, IRequiresSessionState
    {

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        private string para = string.Empty;

        public int totalrec;

        public int CompanyID;

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private commonClass objJava = new commonClass();

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        private DataTable dtsearch = new DataTable();

        public string strSitePath = string.Empty;

        public languageClass objLangClass = new languageClass();

        public string isView = string.Empty;

        public int UserID;

        public static int PageSize;

        public string pg;

        public string Imagepath;

        public string DefContactids = string.Empty;

        public string IsDefaultContact = "false";

        public string strRedirect = string.Empty;

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

        static contact_view()
        {
            contact_view.WhereCondition = string.Empty;
            contact_view.sortdirection = string.Empty;
            contact_view.SortedBy = string.Empty;
            contact_view.PageSize = 50;
        }

        public contact_view()
        {
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)base.Master.FindControl("keywordsearch");
            if (textBox.Text != "")
            {
                this.para = textBox.Text;
                this.GridBind(this.CompanyID, "Yes", this.para, 1, this.GridView1.PageSize, "ContactID", "desc");
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            contact_view.WhereCondition = "";
            this.Session["searchContact"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, "Yes", contact_view.WhereCondition, 1, this.GridView1.PageSize, contact_view.SortedBy, contact_view.sortdirection);
            this.GridView1.MasterTableView.Rebind();
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            foreach (DataRow row in dtsearch.Rows)
            {
                if (row["filter"].ToString().ToLower() != "nofilter" && contact_view.WhereCondition != "")
                {
                    contact_view.WhereCondition = string.Concat(contact_view.WhereCondition, " and ");
                }
                if (row["ColumnName"].ToString().ToLower() == "contactname")
                {
                    empty = "(FirstName +' '+ LastName)";
                }
                else if (row["ColumnName"].ToString().ToLower() == "phone")
                {
                    empty = "HomeTelephone";
                }
                else if (row["ColumnName"].ToString().ToLower() == "department")
                {
                    empty = "deptname";
                }
                else if (row["ColumnName"].ToString().ToLower() == "mobile")
                {
                    empty = "a.mobile";
                }
                else if (row["ColumnName"].ToString().ToLower() != "defaultcontactjobtitle1")
                {
                    empty = (row["ColumnName"].ToString().ToLower() != "defaultcontactjobtitle2" ? row["ColumnName"].ToString() : "a.JobTitle2");
                }
                else
                {
                    empty = "a.JobTitle";
                }
                string lower = row["filter"].ToString().ToLower();
                string str = lower;
                if (lower == null)
                {
                    continue;
                }
                //if (<PrivateImplementationDetails>{5CFCCC8A-30AA-43BA-A3AB-1ECE05B3D44E}.$$method0x600000f-1 == null)
                //{
                //    <PrivateImplementationDetails>{5CFCCC8A-30AA-43BA-A3AB-1ECE05B3D44E}.$$method0x600000f-1 = new Dictionary<string, int>(16)
                //    {
                //        { "startswith", 0 },
                //        { "endswith", 1 },
                //        { "equalto", 2 },
                //        { "notequalto", 3 },
                //        { "contains", 4 },
                //        { "doesnotcontain", 5 },
                //        { "greaterthan", 6 },
                //        { "lessthan", 7 },
                //        { "greaterthanorequalto", 8 },
                //        { "lessthanorequalto", 9 },
                //        { "isempty", 10 },
                //        { "notisempty", 11 },
                //        { "isnull", 12 },
                //        { "notisnull", 13 },
                //        { "between", 14 },
                //        { "notbetween", 15 }
                //    };
                //}
                //if (!<PrivateImplementationDetails>{5CFCCC8A-30AA-43BA-A3AB-1ECE05B3D44E}.$$method0x600000f-1.TryGetValue(str, out num))
                //{
                //    continue;
                //}
                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = contact_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = contact_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", row["FilterText"].ToString().Trim(), "'" };
                            contact_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string str1 = contact_view.WhereCondition;
                            string[] strArrays2 = new string[] { str1, " ", empty, " = '", row["FilterText"].ToString().Trim(), "'" };
                            contact_view.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition2 = contact_view.WhereCondition;
                            string[] strArrays3 = new string[] { whereCondition2, " ", empty, " != '", row["FilterText"].ToString().Trim(), "'" };
                            contact_view.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 4:
                        {
                            string str2 = contact_view.WhereCondition;
                            string[] strArrays4 = new string[] { str2, " ", empty, " like '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition3 = contact_view.WhereCondition;
                            string[] strArrays5 = new string[] { whereCondition3, " ", empty, " not like '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 6:
                        {
                            string str3 = contact_view.WhereCondition;
                            string[] strArrays6 = new string[] { str3, " ", empty, " > '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 7:
                        {
                            string whereCondition4 = contact_view.WhereCondition;
                            string[] strArrays7 = new string[] { whereCondition4, " ", empty, " < '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 8:
                        {
                            string str4 = contact_view.WhereCondition;
                            string[] strArrays8 = new string[] { str4, " ", empty, " >= '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays8);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition5 = contact_view.WhereCondition;
                            string[] strArrays9 = new string[] { whereCondition5, " ", empty, " <= '%", row["FilterText"].ToString().Trim(), "%'" };
                            contact_view.WhereCondition = string.Concat(strArrays9);
                            continue;
                        }
                    case 10:
                        {
                            contact_view.WhereCondition = string.Concat(contact_view.WhereCondition, " ", empty, " = ''");
                            continue;
                        }
                    case 11:
                        {
                            contact_view.WhereCondition = string.Concat(contact_view.WhereCondition, " ", empty, " != ''");
                            continue;
                        }
                    case 12:
                        {
                            contact_view.WhereCondition = string.Concat(contact_view.WhereCondition, " ", empty, " is null");
                            continue;
                        }
                    case 13:
                        {
                            contact_view.WhereCondition = string.Concat(contact_view.WhereCondition, " ", empty, " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str5 = contact_view.WhereCondition;
                            string[] strArrays10 = new string[] { str5, " ", empty, " between '", row["FilterText"].ToString().Trim(), "' and '", row["FilterText"].ToString().Trim(), "'" };
                            contact_view.WhereCondition = string.Concat(strArrays10);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition6 = contact_view.WhereCondition;
                            string[] strArrays11 = new string[] { whereCondition6, " ", empty, " not between '", row["FilterText"].ToString().Trim(), "' and '", row["FilterText"].ToString().Trim(), "'" };
                            contact_view.WhereCondition = string.Concat(strArrays11);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return contact_view.WhereCondition;
        }

        private string GetSortDirection(string column)
        {
            string str = "ASC";
            string item = this.ViewState["SortExpression"] as string;
            if (item != null && item == column)
            {
                string item1 = this.ViewState["SortDirection"] as string;
                if (item1 != null && item1 == "ASC")
                {
                    str = "DESC";
                }
            }
            this.ViewState["SortDirection"] = str;
            this.ViewState["SortExpression"] = column;
            return str;
        }

        public void GridBind(int CompanyID, string Selectall, string para, int PageNumber, int PageSize, string SortBy, string SortDirection)
        {
            DataSet dataSet = CompanyBasePage.ViewContacts(CompanyID, Selectall, para, PageNumber, PageSize, SortBy, SortDirection);
            DataTable item = dataSet.Tables[0];
            this.Session["view"] = item;
            if (item.Rows.Count > 0)
            {
                for (int i = 0; i < item.Rows.Count; i++)
                {
                    item.Rows[i]["company"] = this.objBase.SpecialDecode(item.Rows[i]["company"].ToString());
                    item.Rows[i]["clientname"] = this.objBase.SpecialDecode(item.Rows[i]["clientname"].ToString());
                    item.Rows[i]["customerType"] = this.objBase.SpecialDecode(item.Rows[i]["customerType"].ToString());
                    item.Rows[i]["Salutation"] = this.objBase.SpecialDecode(item.Rows[i]["Salutation"].ToString());
                    item.Rows[i]["FirstName"] = this.objBase.SpecialDecode(item.Rows[i]["FirstName"].ToString());
                    item.Rows[i]["MiddleName"] = this.objBase.SpecialDecode(item.Rows[i]["MiddleName"].ToString());
                    item.Rows[i]["LastName"] = this.objBase.SpecialDecode(item.Rows[i]["LastName"].ToString());
                    item.Rows[i]["ContactName"] = this.objBase.SpecialDecode(item.Rows[i]["ContactName"].ToString());
                    item.Rows[i]["Name"] = this.objBase.SpecialDecode(item.Rows[i]["Name"].ToString());
                    item.Rows[i]["ContactAlias"] = this.objBase.SpecialDecode(item.Rows[i]["ContactAlias"].ToString());
                    item.Rows[i]["Department"] = this.objBase.SpecialDecode(item.Rows[i]["Department"].ToString());
                    item.Rows[i]["Title"] = this.objBase.SpecialDecode(item.Rows[i]["Title"].ToString());
                    item.Rows[i]["HomeTelephone"] = this.objBase.SpecialDecode(item.Rows[i]["HomeTelephone"].ToString());
                    item.Rows[i]["Mobile"] = this.objBase.SpecialDecode(item.Rows[i]["Mobile"].ToString());
                    item.Rows[i]["Phone"] = this.objBase.SpecialDecode(item.Rows[i]["Phone"].ToString());
                    item.Rows[i]["Email"] = this.objBase.SpecialDecode(item.Rows[i]["Email"].ToString());
                    item.Rows[i]["DefaultContactJobTitle1"] = this.objBase.SpecialDecode(item.Rows[i]["DefaultContactJobTitle1"].ToString());
                    item.Rows[i]["DefaultContactJobTitle2"] = this.objBase.SpecialDecode(item.Rows[i]["DefaultContactJobTitle2"].ToString());
                }
            }
            this.GridView1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = false;
                return;
            }
            this.div_Main.Style.Add("display", "block");
            this.GridView1.AllowCustomPaging = true;
            this.GridView1.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = base.ReplaceSingleQuote(item.Text);
                contact_view.WhereCondition = "";
                if (this.Session["searchContact"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["searchContact"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["searchContact"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(second);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                this.Session["searchContact"] = this.dtsearch;
                contact_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, "Yes", contact_view.WhereCondition, 1, this.GridView1.PageSize, contact_view.SortedBy, contact_view.sortdirection);
                this.GridView1.Rebind();
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, "yes", contact_view.WhereCondition, this.GridView1.CurrentPageIndex + 1, this.GridView1.PageSize, contact_view.SortedBy, contact_view.sortdirection);
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            contact_view.SortedBy = e.SortExpression;
            contact_view.sortdirection = e.NewSortOrder.ToString();
            if (contact_view.sortdirection.ToLower() == "ascending")
            {
                contact_view.sortdirection = "ASC";
            }
            else if (contact_view.sortdirection.ToLower() != "descending")
            {
                contact_view.sortdirection = "ASC";
            }
            else
            {
                contact_view.sortdirection = "DESC";
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, "Yes", contact_view.WhereCondition, this.GridView1.CurrentPageIndex + 1, this.GridView1.PageSize, e.SortExpression, contact_view.sortdirection);
        }

        protected void lnkDeleteSelected_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            DataTable dataTable = new DataTable();
            if (this.Session["view"] != null)
            {
                dataTable = (DataTable)this.Session["view"];
            }
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            DateTime dateTime = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["DefaultContact"].ToString().ToLower() != "true")
                {
                    continue;
                }
                if (this.DefContactids != "")
                {
                    this.DefContactids = string.Concat(this.DefContactids, ",", row["ContactID"].ToString());
                }
                else
                {
                    this.DefContactids = row["ContactID"].ToString();
                }
            }
            string[] strArrays = this.DefContactids.Split(new char[] { ',' });
            if (this.hdn_Type.Value.ToLower() == "delete")
            {
                string empty = string.Empty;
                string[] strArrays1 = this.hdn_ContactIDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays1.Length - 1; i++)
                {
                    int num1 = 0;
                    while (num1 < (int)strArrays.Length)
                    {
                        if (Convert.ToInt32(strArrays1[i]) != Convert.ToInt32(strArrays[num1]))
                        {
                            this.IsDefaultContact = "false";
                            num1++;
                        }
                        else
                        {
                            this.IsDefaultContact = "true";
                            break;
                        }
                    }
                    if (this.IsDefaultContact != "false")
                    {
                        this.objBase.Message_Display("Default contact can not be delete", "msg-fail", this.plhmsg);
                    }
                    else
                    {
                        companyBasePage.contact_delete(Convert.ToInt32(this.Session["companyId"]), strArrays1[i], Convert.ToInt32(this.Session["userId"]));
                        this.objBase.Message_Display("Deleted sucessfully", "msg-success", this.plhmsg);
                    }
                }
            }
            else
            {
                bool flag = false;
                if (this.hdn_Type.Value.ToLower() == "subscribe")
                {
                    flag = true;
                    num++;
                }
                companyBasePage.contact_Subscribe_Unsubscribe(Convert.ToInt32(this.Session["companyId"]), this.hdn_ContactIDs.Value, Convert.ToInt32(this.Session["userId"]), flag, dateTime);
                try
                {
                    if (num != 0)
                    {
                        this.objBase.Message_Display("Subscribe sucessfully", "msg-success", this.plhmsg);
                    }
                    else
                    {
                        this.objBase.Message_Display("Unsubscribe sucessfully", "msg-success", this.plhmsg);
                    }
                }
                catch
                {
                }
            }
            this.GridView1.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                string lower = filterMenu.Items[i].Text.ToLower();
                string str = lower;
                if (lower != null)
                {
                    switch (str)
                    {
                        case "custom":
                            {
                                filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                                break;
                            }
                        case "isempty":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notisempty":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "isnull":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notisnull":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "between":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notbetween":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "greaterthan":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "lessthan":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "greaterthanorequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "lessthanorequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "nofilter":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                                break;
                            }
                        case "contains":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                                break;
                            }
                        case "doesnotcontain":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                                break;
                            }
                        case "startswith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                                break;
                            }
                        case "EndsWith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                                break;
                            }
                        case "equalto":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                                break;
                            }
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["mobile"].HorizontalAlign = HorizontalAlign.Right;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["Phone"].HorizontalAlign = HorizontalAlign.Right;
            }
            if (empty.Trim().ToLower() != "false")
            {
                this.GridView1.MasterTableView.GetColumn("DeleteColume").Visible = true;
            }
            else
            {
                this.GridView1.MasterTableView.GetColumn("DeleteColume").Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                QueryString queryString = new QueryString()
			{
				{ "clientid", ((DataRowView)e.Item.DataItem)["ClientID"].ToString() },
				{ "isnew", "2" },
				{ "bypass", "1" },
				{ "type", ((DataRowView)e.Item.DataItem)["customerType"].ToString() }
			};
                this.strRedirect = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                contact_view contactContactView = this;
                contactContactView.strRedirect = string.Concat(contactContactView.strRedirect, queryString1.ToString());
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                item["mobile"].Attributes.Add("align", "right");
                item["Phone"].Attributes.Add("align", "right");
                TableCell tableCell = item["ContactName"];
                object[] str = new object[] { "<a style='color:#10357F' href=javascript:void(0); onclick=javascript:popupContact(", ((DataRowView)e.Item.DataItem)["ClientID"].ToString(), ",", ((DataRowView)e.Item.DataItem)["ContactID"].ToString(), ",'", this.isView, "');>", ((DataRowView)e.Item.DataItem)["firstname"], "&nbsp;", ((DataRowView)e.Item.DataItem)["lastname"], " </a>" };
                tableCell.Text = string.Concat(str);
                TableCell item1 = item["clientname"];
                string[] strArrays = new string[] { "<a style='color:#10357F;' href=", this.strRedirect, ">", ((DataRowView)e.Item.DataItem)["company"].ToString(), "</a>" };
                item1.Text = string.Concat(strArrays);
                ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plhHistory")).Controls;
                string[] str1 = new string[] { "<id='contact' style='padding-top:3px;position:absolute;' onclick='javascript:ShowHistory(", ((DataRowView)e.Item.DataItem)["ContactID"].ToString(), ")'><img src='", this.Imagepath, "' title = 'Subscribe History' style='cursor:pointer;' class='viewicon_margin' />" };
                controls.Add(new LiteralControl(string.Concat(str1)));
            }
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl htmlControl = base.Master.FindControl("DivLeftpanel") as HtmlControl;
            HtmlControl htmlControl1 = base.Master.FindControl("DivLeftpanel1") as HtmlControl;
            HtmlControl htmlControl2 = base.Master.FindControl("RightPanel") as HtmlControl;
            HtmlGenericControl contextPanel = base.Master.FindControl("contextPanel") as HtmlGenericControl;
            this.pg = "contactvw";
            if (htmlControl != null)
            {
                htmlControl.Style.Add("display", "none");
            }
            if (htmlControl1 != null)
            {
                htmlControl1.Style.Add("display", "none");
            }
            if (contextPanel != null)
            {
                contextPanel.Visible = false;
            }
            if (htmlControl2 != null)
            {
                htmlControl2.Style.Add("width", "100%");
            }
            this.objBase.ReturnRoles_Privileges_Tabs("clients", "isview", "");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.GridView1.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Name").ToString();
            this.GridView1.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Company").ToString();
            this.GridView1.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Department").ToString();
            this.GridView1.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Contact_Email").ToString();
            this.GridView1.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Mobile").ToString();
            this.GridView1.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Phone").ToString();
            this.GridView1.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("DefaultConatct_JobTitle1").ToString();
            this.GridView1.Columns[10].HeaderText = this.objLangClass.GetLanguageConversion("DefaultConatct_JobTitle2").ToString();
            this.strSitePath = global.sitePath();
            this.Imagepath = string.Concat(global.imagePath(), "plus_contact.gif");
            this.gloobj.setpagename("client");
            languageClass _languageClass = new languageClass();
            base.Title = _languageClass.convert(global.pageTitle(string.Concat(this.objBase.ReturnScreenName("CONTACTS", 2, "p"), " View"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx style=text-decoration:underline class='subnavigator'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Contact_View")));
            this.plhmsg.Visible = true;
            ImageButton imageButton = (ImageButton)base.Master.FindControl("ImageButton1");
            imageButton.Click += new ImageClickEventHandler(this.btnFreeTextSearch_Click);
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            if (!base.IsPostBack)
            {
                this.GridView1.PageSize = 50;
                contact_view.WhereCondition = "";
                contact_view.sortdirection = "asc";
                contact_view.SortedBy = "ContactName";
            }
            if (!base.IsPostBack && this.Session["searchContact"] != null)
            {
                this.GridStateLoad();
                DataTable item = (DataTable)this.Session["searchContact"];
                this.FilterFunction(item);
                contact_view.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                this.GridView1.PageSize = contact_view.PageSize;
                this.GridBind(this.CompanyID, "Yes", contact_view.WhereCondition, 1, this.GridView1.PageSize, contact_view.SortedBy, contact_view.sortdirection);
                this.GridStateLoad();
                this.GridView1.Rebind();
            }
            BaseClass baseClass = new BaseClass();
            this.isView = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString());
            this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
        }
    }
}