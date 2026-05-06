using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Order;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class notes : UsercontrolBasePage
    {


        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long NotesID;

        public long EstimateID;

        public long JobsID;

        public long InvoiceID;

        public long POID;

        public long DelivryId;

        public string type = string.Empty;

        public long NotesTypeID;

        public string ModuleType = string.Empty;

        public string NotesTag = string.Empty;

        public string SystemNotes = string.Empty;

        public string TagName = string.Empty;

        public string VariableName = string.Empty;

        public string NotesDate = string.Empty;

        public long ModuleID;

        public int CreatedBy;

        public DateTime CreatedDate;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private commonClass commclass = new commonClass();

        public languageClass objLanguage = new languageClass();

        public long ItemID;

        public int OrderItemApprovalStatus = 1;

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

        public notes()
        {
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (base.Request.Params["estid"] == null)
                {
                    if (base.Request.Params["id"] != null)
                    {
                        if (base.Request.Url.ToString().ToLower().Contains("purchase/"))
                        {
                            this.POID = Convert.ToInt64(base.Request.Params["id"].ToString());
                            this.ModuleType = "purchase";
                            this.ModuleID = this.POID;
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("delivery/"))
                        {
                            this.DelivryId = Convert.ToInt64(base.Request.Params["id"].ToString());
                            this.ModuleType = "delivery";
                            this.ModuleID = this.DelivryId;
                        }
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.ModuleType = "estimate";
                    this.ModuleID = this.EstimateID;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
                {
                    this.JobsID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.ModuleType = "job";
                    this.ModuleID = this.JobsID;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
                {
                    this.InvoiceID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.ModuleType = "invoice";
                    this.ModuleID = this.InvoiceID;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("orders/"))
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.ModuleType = "webstoreorder";
                    this.ModuleID = this.EstimateID;
                }
            }
            catch
            {
            }
        }

        protected void OnItemDataBound_RadGrid2(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                Button languageConversion = item.FindControl("btnOk") as Button;
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Save");
                Button button = item.FindControl("RadButton1") as Button;
                button.Text = this.objLanguage.GetLanguageConversion("Cancel");
                RadioButton radioButton = item.FindControl("rdoGeneral") as RadioButton;
                RadioButton languageConversion1 = item.FindControl("rdoError") as RadioButton;
                DropDownList str = item.FindControl("ddlErrorType") as DropDownList;
                button.Text = this.objLanguage.GetLanguageConversion("Cancel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Save");
                radioButton.Text = this.objLanguage.GetLanguageConversion("General");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Error");
                radioButton.Attributes.Add("onclick", string.Concat("javascript:ErrorCheck('General','", str.ClientID, "');"));
                languageConversion1.Attributes.Add("onclick", string.Concat("javascript:ErrorCheck('Error','", str.ClientID, "');"));
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActivityHistory_ErrorList_Select");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, this.CompanyID);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                str.DataSource = dataTable;
                str.DataTextField = "PhraseText";
                str.DataValueField = "PhraseBookID";
                str.DataBind();
                str.Enabled = false;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["IsDefaultPhrase"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                    str.SelectedValue = row["PhraseBookID"].ToString();
                }
                ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirmShowNotesOnAdd", "; ShowNotes();", true);
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_IsError");
                if (gridDataItem["Type"].Text.ToLower() != "error")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.gif' border='0' title='Error' />")));
                }
                if (gridDataItem["NoteType"].Text.ToLower() == "s")
                {
                    gridDataItem["Type"].Text = "System";
                }
                TableCell tableCell = gridDataItem["CreateDate"];
                DateTime dateTime = Convert.ToDateTime(gridDataItem["CreateDate"].Text);
                tableCell.Text = Convert.ToString(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                string text = gridDataItem["CreateDate"].Text;
                char[] chrArray = new char[] { ' ' };
                string str1 = text.Split(chrArray)[0];
                string text1 = gridDataItem["CreateDate"].Text;
                char[] chrArray1 = new char[] { ' ' };
                string str2 = text1.Split(chrArray1)[1];
                string text2 = gridDataItem["CreateDate"].Text;
                char[] chrArray2 = new char[] { ' ' };
                string str3 = text2.Split(chrArray2)[2];
                string str4 = this.commclass.Eprint_return_Date_Before_View(str1, this.CompanyID, this.UserID, false);
                TableCell item1 = gridDataItem["CreateDate"];
                object[] objArray = new object[] { str4, ' ', str2, ' ', str3 };
                item1.Text = string.Concat(objArray);
                gridDataItem["Description"].Text = gridDataItem["Description"].Text.Replace("`", "'");
            }
            if (e.Item.ItemType == GridItemType.CommandItem)
            {
                if (this.OrderItemApprovalStatus != 1 && this.ItemID != (long)0)
                {
                    HtmlTable htmlTable = (HtmlTable)e.Item.FindControl("act_hist");
                    htmlTable.Style.Add("display", "none");
                }
                if (base.Request.Params["contactid"] != null && base.Request.Url.ToString().ToLower().Contains("contacthistory"))
                {
                    HtmlTable htmlTable1 = (HtmlTable)e.Item.FindControl("act_hist");
                    htmlTable1.Style.Add("display", "none");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid2.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid2.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (!base.IsPostBack)
            {
                this.RadGrid2.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Notes");
                this.RadGrid2.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Type");
                this.RadGrid2.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("System_User");
                this.RadGrid2.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Created_Date");
                this.RadGrid2.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
                if (base.Request.Params["estid"] != null && base.Request.Params["id"] == null)
                {
                    if (base.Request.Url.ToString().ToLower().Contains("estimate"))
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "estimate";
                        this.ModuleID = this.EstimateID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("job"))
                    {
                        this.JobsID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "job";
                        this.ModuleID = this.JobsID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("invoice"))
                    {
                        this.InvoiceID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "invoice";
                        this.ModuleID = this.InvoiceID;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("orders"))
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "webstoreorder";
                        this.ModuleID = this.EstimateID;
                    }
                }
                else if (base.Request.Params["id"] == null)
                {
                    if (base.Request.Params["contactid"] != null && base.Request.Url.ToString().ToLower().Contains("contacthistory"))
                    {
                        this.ModuleType = "contact";
                        this.ModuleID = Convert.ToInt64(base.Request.Params["contactid"].ToString());
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("purchase"))
                {
                    this.POID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.ModuleType = "purchase";
                    this.ModuleID = this.POID;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("delivery"))
                {
                    this.DelivryId = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.ModuleType = "delivery";
                    this.ModuleID = this.DelivryId;
                }
                this.ObjectDataSource1.SelectParameters.Add("CompanyID", this.CompanyID.ToString());
                this.ObjectDataSource1.SelectParameters.Add("ModuleType", this.ModuleType.ToString());
                this.ObjectDataSource1.SelectParameters.Add("ModuleID", this.ModuleID.ToString());
                this.ObjectDataSource1.SelectParameters.Add("ItemID", this.ItemID.ToString());
                this.ObjectDataSource1.SelectParameters.Add("NotesType", "s");
                this.ObjectDataSource1.TypeName = "Printcenter.UI.Estimates.EstimateBasePage";
                this.ObjectDataSource1.SelectMethod = "estimates_notes_select_PerItem";
            }
            this.CreatedBy = this.UserID;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            this.CreatedDate = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "activityhistory")
                {
                    this.div_notes.Attributes.Add("style", "display:block");
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "contacthistory")
                {
                    this.div_notes.Attributes.Add("style", "display:block");
                }
            }
            if (this.ItemID != (long)0)
            {
                this.OrderItemApprovalStatus = OrderBasePage.OrderItemApprovalStatus_Select(this.ItemID);
            }
        }

        protected void RadGrid2_InsertCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (base.Request.Params["estid"] != null)
                {
                    if (base.Request.Url.ToString().ToLower().Contains("estimate"))
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "estimate";
                        this.ModuleID = this.EstimateID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("job"))
                    {
                        this.JobsID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "job";
                        this.ModuleID = this.JobsID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("invoice"))
                    {
                        this.InvoiceID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "invoice";
                        this.ModuleID = this.InvoiceID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("order"))
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                        this.ModuleType = "webstoreorder";
                        this.ModuleID = this.EstimateID;
                    }
                }
                if (base.Request.Params["id"] != null)
                {
                    if (base.Request.Url.ToString().ToLower().Contains("purchase"))
                    {
                        this.POID = Convert.ToInt64(base.Request.Params["id"].ToString());
                        this.ModuleType = "purchase";
                        this.ModuleID = this.POID;
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("delivery"))
                    {
                        this.DelivryId = Convert.ToInt64(base.Request.Params["id"].ToString());
                        this.ModuleType = "delivery";
                        this.ModuleID = this.DelivryId;
                    }
                }
                GridItem item = e.Item;
                TextBox textBox = (TextBox)e.Item.FindControl("txtUserNotes");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlErrorType");
                RadioButton radioButton = (RadioButton)e.Item.FindControl("rdoGeneral");
                RadioButton radioButton1 = (RadioButton)e.Item.FindControl("rdoError");
                string empty = string.Empty;
                string str = string.Empty;
                if (!radioButton1.Checked)
                {
                    empty = "General";
                    str = " ";
                }
                else
                {
                    empty = "Error";
                    if (dropDownList.SelectedItem == null)
                    {
                        str = " ";
                    }
                    else
                    {
                        str = (dropDownList.SelectedItem.Text == "" ? " " : dropDownList.SelectedItem.Text);
                    }
                }
                this.ObjectDataSource1.InsertParameters.Add("CompanyID", this.CompanyID.ToString());
                this.ObjectDataSource1.InsertParameters.Add("NotesID", "0");
                this.ObjectDataSource1.InsertParameters.Add("ModuleType", this.ModuleType.ToString());
                this.ObjectDataSource1.InsertParameters.Add("ModuleID", this.ModuleID.ToString());
                this.ObjectDataSource1.InsertParameters.Add("Type", empty);
                this.ObjectDataSource1.InsertParameters.Add("ErrorType", str);
                this.ObjectDataSource1.InsertParameters.Add("NotesType", "U");
                this.ObjectDataSource1.InsertParameters.Add("Description", this.objBase.SpecialEncode(textBox.Text));
                this.ObjectDataSource1.InsertParameters.Add("CreatedBy", this.UserID.ToString());
                this.ObjectDataSource1.InsertParameters.Add("CreatedDate", this.CreatedDate.ToString());
                this.ObjectDataSource1.InsertParameters.Add("ItemID", this.ItemID.ToString());
                this.ObjectDataSource1.TypeName = "Printcenter.UI.Estimates.EstimateBasePage";
                this.ObjectDataSource1.InsertMethod = "etimates_notes_insert";
            }
            catch
            {
            }
        }
    }
}