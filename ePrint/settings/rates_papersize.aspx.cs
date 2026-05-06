using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class rates_papersize : BaseClass, IRequiresSessionState
    {
        //protected Label lblHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadCodeBlock RadCodeBlock1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected LinkButton lnkDelete;

        //protected RadGrid RadGrid1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor2;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        private BaseClass objBC = new BaseClass();

        public int CompanyID;

        public int UserID;

        private commonClass objJava = new commonClass();

        public string PaperMeasure = "";

        private BasePage ObjPage = new BasePage();

        public languageClass objLanguage = new languageClass();

        public static Hashtable ht;

        private string gridMessage;

        public bool chk3DecimalPlaces;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<rates_papersize.OrderNew> PendingOrders
        {
            get
            {
                IList<rates_papersize.OrderNew> orderNews;
                try
                {
                    object item = this.Session["UserPaper"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<rates_papersize.OrderNew>();
                        }
                        else
                        {
                            this.Session["UserPaper"] = item;
                        }
                    }
                    orderNews = (IList<rates_papersize.OrderNew>)item;
                }
                catch
                {
                    this.Session["UserPaper"] = null;
                    return new List<rates_papersize.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["UserPaper"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static rates_papersize()
        {
            rates_papersize.ht = new Hashtable();
        }

        public rates_papersize()
        {
        }

        protected void btnCancel_Clicked(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Header };
            GridHeaderItem items = masterTableView.GetItems(gridItemTypeArray)[0] as GridHeaderItem;
            items["Width"].Text = string.Concat("Width (", this.PaperMeasure, ")");
            items["Height"].Text = string.Concat("Height (", this.PaperMeasure, ")");
        }

        private void DisplayMessage(string text)
        {
            this.RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        private static rates_papersize.OrderNew GetOrder(IEnumerable<rates_papersize.OrderNew> ordersToSearchIn, long PaperSizeID)
        {
            rates_papersize.OrderNew orderNew;
            using (IEnumerator<rates_papersize.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    rates_papersize.OrderNew current = enumerator.Current;
                    if (current.PaperSizeID != PaperSizeID)
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

        protected IList<rates_papersize.OrderNew> GetOrders()
        {
            IList<rates_papersize.OrderNew> orderNews = new List<rates_papersize.OrderNew>();
            DataTable dataTable = this.GridBind();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    int num = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num1 = Convert.ToInt64(row["PaperSizeID"].ToString());
                        int num2 = num;
                        num++;
                        orderNews.Add(new rates_papersize.OrderNew(num1, num2));
                    }
                    this.Session["UserPaper"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        public DataTable GridBind()
        {
            this.PaperMeasure = base.SpecialDecode(this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure"));
            this.SessionDataSource1.TypeName = "Printcenter.UI.Setting.SettingsBasePage";
            this.SessionDataSource1.SelectMethod = "settings_papersize_selectall";
            this.SessionDataSource1.SelectParameters.Clear();
            this.SessionDataSource1.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.RadGrid1.Rebind();
            return ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_delete");
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.String, e.CommandArgument);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersize_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.MasterTableView.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("Id1");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_papersize_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.GridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersizes_deleted_successfully"), "msg-success", this.plhMessage);
        }

        protected void ObjDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersize_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersize_Successfully_Inserted"), "msg-success", this.plhMessage);
            }
            GridTableView masterTableView = this.RadGrid1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Header };
            GridHeaderItem items = masterTableView.GetItems(gridItemTypeArray)[0] as GridHeaderItem;
            items["Width"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Width"), " (", this.PaperMeasure, ")");
            items["Height"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Height"), " (", this.PaperMeasure, ")");
        }

        protected void ObjDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersize_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("rates_papersize_Successfully_Updated"), "msg-success", this.plhMessage);
            }
            GridTableView masterTableView = this.RadGrid1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Header };
            GridHeaderItem items = masterTableView.GetItems(gridItemTypeArray)[0] as GridHeaderItem;
            items["Width"].Text = string.Concat("Width (", this.PaperMeasure, ")");
            items["Height"].Text = string.Concat("Height (", this.PaperMeasure, ")");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("rates_papersizes")));
            this.RadGrid1.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Name");
            this.RadGrid1.Columns[2].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Width"), " (", this.PaperMeasure, ")");
            this.RadGrid1.Columns[3].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Height"), " (", this.PaperMeasure, ")");
            this.lnkDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.lblHeader.Text = this.objLanguage.GetLanguageConversion("Settings_rates_papersizes");
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("rates_papersizes");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("rates_papersizes"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            this.Session["UserPaper"] = null;
            LoadDecimalSetting();
            if (!base.IsPostBack)
            {
                this.GridBind();
                this.Session["UserPaper"] = null;
            }
            this.lnkDelete.Attributes.Add("onclick", "javascript:return CallDelete();");
        }
        public void LoadDecimalSetting()
        {
            DataTable dt = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
            bool decimal3ForPaperSize = false; // Default value

            foreach (DataRow row in dt.Rows)
            {
                decimal3ForPaperSize = row["Decimal3ForPaperSizes"] != DBNull.Value
                            ? Convert.ToBoolean(row["Decimal3ForPaperSizes"])
                            : false;
            }

            this.chk3DecimalPlaces = decimal3ForPaperSize;
        }
        protected void Page_PreRender(object o, EventArgs e)
        {
            this.PaperMeasure = base.SpecialDecode(this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure"));
            GridTableView masterTableView = this.RadGrid1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Header };
            GridHeaderItem items = masterTableView.GetItems(gridItemTypeArray)[0] as GridHeaderItem;
            items["Width"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Width"), " (", this.PaperMeasure, ")");
            items["Height"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Height"), " (", this.PaperMeasure, ")");
        }

        protected void RadGrid1_DataBound(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridMessage))
            {
                this.DisplayMessage(this.gridMessage);
            }
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtPaperSizeName");
            base.ReplaceSingleQuote(radTextBox.Text);
            this.SessionDataSource1.InsertParameters.Add("CompanyID", this.CompanyID.ToString());
        }

        protected void radGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                RadTextBox radTextBox = item.FindControl("txtPaperSizeName") as RadTextBox;
                radTextBox.Focus();
                GridTableView masterTableView = this.RadGrid1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Header };
                GridHeaderItem items = masterTableView.GetItems(gridItemTypeArray)[0] as GridHeaderItem;
                items["Width"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Width"), " (", this.PaperMeasure, ")");
                items["Height"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Height"), " (", this.PaperMeasure, ")");
                RadButton languageConversion = item.FindControl("RadButton8") as RadButton;
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Cancel");
                RadButton radButton = item.FindControl("RadButton1") as RadButton;
                radButton.Text = this.objLanguage.GetLanguageConversion("Save");
                RequiredFieldValidator requiredFieldValidator = item.FindControl("RequiredFieldValidator2") as RequiredFieldValidator;
                requiredFieldValidator.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Paper_Name");
                RequiredFieldValidator languageConversion1 = item.FindControl("RequiredFieldValidator1") as RequiredFieldValidator;
                languageConversion1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Paper_Width");
                RequiredFieldValidator requiredFieldValidator1 = item.FindControl("RequiredFieldValidator3") as RequiredFieldValidator;
                requiredFieldValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Paper_Height");
                Label label = item.FindControl("lblNote") as Label;
                label.Text = this.objLanguage.GetLanguageConversion("PaperSize_Insert_Note");
                radTextBox.Text = base.SpecialDecode(radTextBox.Text);

                RadNumericTextBox tbWidth = item.FindControl("tbTaxRate") as RadNumericTextBox;
                RadNumericTextBox tbHeight = item.FindControl("RadNumericTextBox1") as RadNumericTextBox;
                int decimalPlaces = this.chk3DecimalPlaces ? 3 : 2;

                if (tbWidth != null) tbWidth.NumberFormat.DecimalDigits = decimalPlaces;
                if (tbHeight != null) tbHeight.NumberFormat.DecimalDigits = decimalPlaces;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                gridDataItem["papersizename"].ToolTip = base.SpecialDecode(gridDataItem["papersizename"].Text);
                gridDataItem["papersizename"].Text = string.Concat("<div style='width:99%;overflow:hidden;max-height:15px;height:15px; cursor:pointer;'>", base.SpecialDecode(gridDataItem["papersizename"].Text), "</div>");
            }
            try
            {
                int decimalPlaces = 0;
                if(this.chk3DecimalPlaces)
                {
                    decimalPlaces = 3;
                }
                GridDataItem item1 = (GridDataItem)e.Item;
                Label removeDecimalPlacesIfZero = (Label)item1["Height"].FindControl("lblHeight");
                removeDecimalPlacesIfZero.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero.Text), decimalPlaces, "", false, false, true);
                Label removeDecimalPlacesIfZero1 = (Label)item1["Width"].FindControl("lblName");
                removeDecimalPlacesIfZero1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero1.Text), decimalPlaces, "", false, false, true);
                removeDecimalPlacesIfZero1.Text = this.objJava.ToRemoveDecimalPlacesIfZero(removeDecimalPlacesIfZero1.Text);
                removeDecimalPlacesIfZero.Text = this.objJava.ToRemoveDecimalPlacesIfZero(removeDecimalPlacesIfZero.Text);
            }
            catch
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label label1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.RadGrid1.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGrid1_ItemDeleted(object source, GridDeletedEventArgs e)
        {
            this.GridBind();
        }

        protected void RadGrid1_ItemUpdated(object source, GridUpdatedEventArgs e)
        {
            GridEditableItem item = e.Item;
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtPaperSizeName");
            base.SpecialEncode(radTextBox.Text);
        }

        protected void radGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid1.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid1.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGrid1_PazeIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_PazeSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_RowDrop(object sender, GridDragDropEventArgs e)
        {
            rates_papersize.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid1.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid1.ClientID)
            {
                IList<rates_papersize.OrderNew> pendingOrders = this.PendingOrders;
                rates_papersize.OrderNew order = rates_papersize.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("PaperSizeID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<rates_papersize.OrderNew> orderNews = new List<rates_papersize.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    rates_papersize.OrderNew orderNew = rates_papersize.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("PaperSizeID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (rates_papersize.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    rates_papersize.ht.Add(pendingOrders[i].PaperSizeID, i + 1);
                }
                int pageSize = num - this.RadGrid1.PageSize * this.RadGrid1.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
                foreach (long key in rates_papersize.ht.Keys)
                {
                    SettingsBasePage.settings_PaperSize_update(Convert.ToInt16(this.Session["CompanyID"].ToString()), Convert.ToInt32(rates_papersize.ht[key]), Convert.ToInt32(key));
                }
                this.GridBind();
            }
        }

        private void SetMessage(string message)
        {
            this.gridMessage = message;
        }

        protected class OrderNew
        {
            private long _PaperSizeID;

            private int _OrderNumber;

            public int OrderNumber
            {
                get
                {
                    return this._OrderNumber;
                }
            }

            public long PaperSizeID
            {
                get
                {
                    return this._PaperSizeID;
                }
            }

            public OrderNew(long PaperSizeID, int OrderNumber)
            {
                this._PaperSizeID = PaperSizeID;
                this._OrderNumber = OrderNumber;
            }
        }
    }
}