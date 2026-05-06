using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class Othercost_sequence : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblheader;

        //protected Label lblphrase;

        //protected HiddenField hdn;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected Label lbl_LargeFormate;

        //protected UpdatePanel update_EstTypes;

        //protected Label Label1;

        //protected DropDownList ddlCategory;

        //protected HiddenField hid_CategoryID;

        //protected RadGrid GridAvailableOtherCost;

        //protected LinkButton btnMove;

        //protected LinkButton btnReMove;

        //protected RadGrid GridSelectedOtherCost;

        //protected HiddenField hidGridCount;

        //protected Button btnSave;

        //protected HtmlTable Table1;

        //protected LinkButton lnkShowSequence;

        //protected UpdatePanel UP1;

        //protected HtmlGenericControl div_category;

        //protected HiddenField hdn_Estimatetype;

        //protected HiddenField hdn_Actiontype;

        //protected HiddenField hid_OtherCostMoveOrders;

        //protected HiddenField hid_OtherCostRemoveOrders;

        public int CompanyID;

        public long OtherCostCategoryID;

        public int OtherCostID;

        private Global gloobj = new Global();

        private SettingsBasePage objSet = new SettingsBasePage();

        public string strImagepath = global.imagePath();

        public string EstimateType = string.Empty;

        public long CategoryID;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<Othercost_sequence.OrderNew> AvailableOtherCost
        {
            get
            {
                IList<Othercost_sequence.OrderNew> orderNews;
                try
                {
                    object item = this.Session["AvailableOtherCost"];
                    if (item == null)
                    {
                        item = this.GetAvailableOtherCost();
                        if (item == null)
                        {
                            item = new List<Othercost_sequence.OrderNew>();
                        }
                        else
                        {
                            this.Session["AvailableOtherCost"] = item;
                        }
                    }
                    orderNews = (IList<Othercost_sequence.OrderNew>)item;
                }
                catch
                {
                    this.Session["AvailableOtherCost"] = null;
                    return new List<Othercost_sequence.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["AvailableOtherCost"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        protected IList<Othercost_sequence.OrderNew> SelectedOtherCost
        {
            get
            {
                IList<Othercost_sequence.OrderNew> orderNews;
                try
                {
                    object item = this.Session["SelectedOtherCost"];
                    if (item == null)
                    {
                        item = this.GetSelectedOtherCost();
                        if (item == null)
                        {
                            item = new List<Othercost_sequence.OrderNew>();
                        }
                        else
                        {
                            this.Session["SelectedOtherCost"] = item;
                        }
                    }
                    orderNews = (IList<Othercost_sequence.OrderNew>)item;
                }
                catch
                {
                    this.Session["SelectedOtherCost"] = null;
                    return new List<Othercost_sequence.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["SelectedOtherCost"] = value;
            }
        }

        public Othercost_sequence()
        {
        }

        protected void BtnMove_Onclick(object sender, EventArgs e)
        {
            this.Session["AvailableOtherCost"] = null;
            if (this.ddlCategory.SelectedIndex <= 0)
            {
                this.CategoryID = (long)0;
            }
            else
            {
                this.CategoryID = Convert.ToInt64(this.ddlCategory.SelectedValue);
            }
            IList<Othercost_sequence.OrderNew> selectedOtherCost = this.SelectedOtherCost;
            IList<Othercost_sequence.OrderNew> availableOtherCost = this.AvailableOtherCost;
            if (base.Request.Cookies["OtherCostMoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["OtherCostMoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        Othercost_sequence.OrderNew order = Othercost_sequence.GetOrder(availableOtherCost, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            selectedOtherCost.Add(order);
                        }
                    }
                }
            }
            this.SelectedOtherCost = selectedOtherCost;
            this.GridSelectedOtherCost.Rebind();
        }

        protected void BtnReMove_Onclick(object sender, EventArgs e)
        {
            IList<Othercost_sequence.OrderNew> selectedOtherCost = this.SelectedOtherCost;
            if (base.Request.Cookies["OtherCostRemoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["OtherCostRemoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        Othercost_sequence.OrderNew order = Othercost_sequence.GetOrder(selectedOtherCost, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            selectedOtherCost.Remove(order);
                        }
                    }
                }
            }
            this.SelectedOtherCost = selectedOtherCost;
            this.GridSelectedOtherCost.Rebind();
        }

        protected void BtnSave_Onclick(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.ddlCategory.SelectedIndex == 0)
            {
                flag = true;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "ValidateOtherCostSequanceCategory", "ValidateOtherCostSequanceCategory();", true);
            }
            if (!flag)
            {
                int num = 0;
                SettingsBasePage.othercost_sequence_Delete((long)this.CompanyID, this.hdn_Estimatetype.Value);
                foreach (GridDataItem item in this.GridSelectedOtherCost.MasterTableView.Items)
                {
                    Label label = (Label)item.FindControl("lblid");
                    CheckBox checkBox = (CheckBox)item.FindControl("Id_3");
                    SettingsBasePage.othercost_oncategory_Insert((long)this.CompanyID, Convert.ToInt64(label.Text), this.hdn_Estimatetype.Value, (long)(num + 1), checkBox.Checked);
                    num++;
                }
                base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Sequence_saved_successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void ddlcategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["AvailableOtherCost"] = null;
            if (this.ddlCategory.SelectedIndex <= 0)
            {
                this.CategoryID = (long)0;
            }
            else
            {
                this.CategoryID = Convert.ToInt64(this.ddlCategory.SelectedValue);
            }
            this.GridAvailableOtherCost.Rebind();
        }

        protected IList<Othercost_sequence.OrderNew> GetAvailableOtherCost()
        {
            IList<Othercost_sequence.OrderNew> orderNews = new List<Othercost_sequence.OrderNew>();
            DataTable dataTable = SettingsBasePage.othercost_oncategory_select(this.CompanyID, this.CategoryID);
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["OtherCostID"].ToString());
                        string str = base.SpecialDecode(row["OtherCostName"].ToString());
                        string str1 = base.SpecialDecode(row["Description"].ToString());
                        orderNews.Add(new Othercost_sequence.OrderNew(num, str, false, str1));
                    }
                    this.Session["AvailableOtherCost"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        private static Othercost_sequence.OrderNew GetOrder(IEnumerable<Othercost_sequence.OrderNew> ordersToSearchIn, long ID)
        {
            Othercost_sequence.OrderNew orderNew;
            using (IEnumerator<Othercost_sequence.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Othercost_sequence.OrderNew current = enumerator.Current;
                    if (current.OtherCostID != ID)
                    {
                        continue;
                    }
                    orderNew = current;
                    return orderNew;
                }
                return null;
            }
            return orderNew;
        }

        protected IList<Othercost_sequence.OrderNew> GetSelectedOtherCost()
        {
            IList<Othercost_sequence.OrderNew> orderNews = new List<Othercost_sequence.OrderNew>();
            DataTable dataTable = SettingsBasePage.othercost_sequence_select((long)this.CompanyID, this.EstimateType);
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["OtherCostID"].ToString());
                        string str = base.SpecialDecode(row["OtherCostName"].ToString());
                        bool flag = Convert.ToBoolean(row["isMandatory"]);
                        orderNews.Add(new Othercost_sequence.OrderNew(num, str, flag, ""));
                    }
                    this.Session["AvailableOtherCost"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        protected void grdAvailableOtherCost_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridAvailableOtherCost.ClientID)
            {
                if (e.DestDataItem == null && this.SelectedOtherCost.Count == 0 || e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridSelectedOtherCost.ClientID)
                {
                    IList<Othercost_sequence.OrderNew> selectedOtherCost = this.SelectedOtherCost;
                    IList<Othercost_sequence.OrderNew> availableOtherCost = this.AvailableOtherCost;
                    int num = -1;
                    if (e.DestDataItem != null)
                    {
                        Othercost_sequence.OrderNew order = Othercost_sequence.GetOrder(selectedOtherCost, (long)e.DestDataItem.GetDataKeyValue("OtherCostID"));
                        num = (order != null ? selectedOtherCost.IndexOf(order) : -1);
                    }
                    foreach (GridDataItem draggedItem in e.DraggedItems)
                    {
                        Othercost_sequence.OrderNew orderNew = Othercost_sequence.GetOrder(availableOtherCost, (long)draggedItem.GetDataKeyValue("OtherCostID"));
                        if (orderNew == null)
                        {
                            continue;
                        }
                        if (num <= -1)
                        {
                            selectedOtherCost.Add(orderNew);
                        }
                        else
                        {
                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                num++;
                            }
                            selectedOtherCost.Insert(num, orderNew);
                        }
                        availableOtherCost.Remove(orderNew);
                    }
                    this.SelectedOtherCost = selectedOtherCost;
                    this.AvailableOtherCost = availableOtherCost;
                    this.GridAvailableOtherCost.Rebind();
                    this.GridSelectedOtherCost.Rebind();
                    return;
                }
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridAvailableOtherCost.ClientID)
                {
                    IList<Othercost_sequence.OrderNew> orderNews = this.AvailableOtherCost;
                    Othercost_sequence.OrderNew order1 = Othercost_sequence.GetOrder(orderNews, (long)e.DestDataItem.GetDataKeyValue("OtherCostID"));
                    int num1 = orderNews.IndexOf(order1);
                    if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                    {
                        num1--;
                    }
                    if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                    {
                        num1++;
                    }
                    List<Othercost_sequence.OrderNew> orderNews1 = new List<Othercost_sequence.OrderNew>();
                    foreach (GridDataItem gridDataItem in e.DraggedItems)
                    {
                        Othercost_sequence.OrderNew orderNew1 = Othercost_sequence.GetOrder(orderNews, (long)gridDataItem.GetDataKeyValue("OtherCostID"));
                        if (orderNew1 == null)
                        {
                            continue;
                        }
                        orderNews1.Add(orderNew1);
                    }
                    foreach (Othercost_sequence.OrderNew orderNew2 in orderNews1)
                    {
                        orderNews.Remove(orderNew2);
                        orderNews.Insert(num1, orderNew2);
                    }
                    this.AvailableOtherCost = orderNews;
                    this.GridAvailableOtherCost.Rebind();
                    int pageSize = num1 - this.GridAvailableOtherCost.PageSize * this.GridAvailableOtherCost.CurrentPageIndex;
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
            }
        }

        protected void grdSelectedOtherCost_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridSelectedOtherCost.DataSource = this.SelectedOtherCost;
        }

        protected void grdSelectedOtherCost_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridSelectedOtherCost.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridSelectedOtherCost.ClientID)
            {
                IList<Othercost_sequence.OrderNew> selectedOtherCost = this.SelectedOtherCost;
                Othercost_sequence.OrderNew order = Othercost_sequence.GetOrder(selectedOtherCost, (long)e.DestDataItem.GetDataKeyValue("OtherCostID"));
                int num = selectedOtherCost.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<Othercost_sequence.OrderNew> orderNews = new List<Othercost_sequence.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    Othercost_sequence.OrderNew orderNew = Othercost_sequence.GetOrder(selectedOtherCost, (long)draggedItem.GetDataKeyValue("OtherCostID"));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (Othercost_sequence.OrderNew orderNew1 in orderNews)
                {
                    selectedOtherCost.Remove(orderNew1);
                    selectedOtherCost.Insert(num, orderNew1);
                }
                this.SelectedOtherCost = selectedOtherCost;
                this.GridSelectedOtherCost.Rebind();
                int pageSize = num - this.GridSelectedOtherCost.PageSize * this.GridSelectedOtherCost.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void GridAvailableOtherCost_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridAvailableOtherCost.DataSource = this.AvailableOtherCost;
        }

        protected void lnkShowSequence_OnClick(object sender, EventArgs e)
        {
            this.Session["SelectedOtherCost"] = null;
            this.Session["AvailableOtherCost"] = null;
            this.EstimateType = this.hdn_Estimatetype.Value;
            if (this.ddlCategory.SelectedIndex <= 0)
            {
                this.CategoryID = (long)0;
            }
            else
            {
                this.CategoryID = Convert.ToInt64(this.ddlCategory.SelectedValue);
            }
            this.GridAvailableOtherCost.Rebind();
            this.GridSelectedOtherCost.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridAvailableOtherCost.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "lesshanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
            GridFilterMenu gridFilterMenu = this.GridSelectedOtherCost.FilterMenu;
            for (int j = gridFilterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (gridFilterMenu.Items[j].Text == "Custom")
                {
                    gridFilterMenu.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "between")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lesshanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnMove.ToolTip = this.objLanguage.GetLanguageConversion("Move");
            this.btnReMove.ToolTip = this.objLanguage.GetLanguageConversion("Remove");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.GridAvailableOtherCost.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_display");
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/othercost_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Othercost_Sequence"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Othercost_Sequence")));
            base.Title = this.objLanguage.convert(global.pageTitle("Othercost sequence", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Othercost_Sequence");
            if (base.Request.Params["EstType"].ToString() != null)
            {
                this.EstimateType = base.Request.Params["EstType"].ToString();
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["su"] != null)
                {
                    if (base.Request.Params["su"].ToString().ToLower() != "in")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Othercost_Sequence_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                    else
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Othercost_Sequence_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---"));
                this.Session["AvailableOtherCost"] = null;
                this.Session["SelectedOtherCost"] = null;
            }
            this.GridSelectedOtherCost.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Other_Cost_Name");
        }

        protected class OrderNew
        {
            private long _OtherCostID;

            private string _OtherCostName;

            private bool _IsMandatory;

            private string _Description;

            public string Description
            {
                get
                {
                    return this._Description;
                }
            }

            public bool IsMandatory
            {
                get
                {
                    return this._IsMandatory;
                }
            }

            public long OtherCostID
            {
                get
                {
                    return this._OtherCostID;
                }
            }

            public string OtherCostName
            {
                get
                {
                    return this._OtherCostName;
                }
            }

            public OrderNew(long OtherCostID, string OtherCostName, bool IsMandatory, string Description)
            {
                this._OtherCostID = OtherCostID;
                this._OtherCostName = OtherCostName;
                this._IsMandatory = IsMandatory;
                this._Description = Description;
            }
        }
    }
}