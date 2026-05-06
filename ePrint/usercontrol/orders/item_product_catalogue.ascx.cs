using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.orders
{
    public partial class item_product_catalogue : UserControl
    {
        //protected usercontrol_settings_Loading ucLoadings;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label Label2;

        //protected TextBox txtJobName;

        //protected HtmlGenericControl div_JobName;

        //protected Label Label3;

        //protected Label lblProductName;

        //protected HtmlGenericControl Div2;

        //protected Label lblCampaign;

        //protected DropDownList ddlCampaign;

        //protected HtmlGenericControl div_CampaignErrorMsg;

        //protected HtmlGenericControl divCampaign;

        //protected PlaceHolder plhquantity;

        //protected HtmlGenericControl artwork_div;

        //protected UpdatePanel UpdatePanel2;

        //protected Label Label1;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Button btnUpdate;

        //protected Image Image3;

        //protected HiddenField txtPriceCatalogueSerach;

        //protected HiddenField hdnEnabledCampaign;

        //protected HiddenField hdn_param;

        //protected HiddenField hidCatalogueCount;

        //protected LinkButton lnkLoadPriceCatalogue;

        //protected Label lblTest;

        //protected UpdatePanel UpdatePanel1;

        //protected UpdateProgress UPPro;

        //protected HiddenField hidCatalogueID;

        //protected ImageButton ImageButton2;

        //protected HiddenField hid_query_details;

        //protected DropDownList ddlCategoryBind;

        //protected Panel Pnl_ddl;

        //protected LinkButton btnclrFilters;

        //protected Panel Pnl_btnclrall;

        //protected UpdatePanel UPID12;

        //protected RadGrid GridPriceCatalogue;

        //protected Panel Panel1;

        //protected HtmlGenericControl Grid_Disp;

        //protected Panel pnlCatalogue;

        //protected LinkButton lnkProductCatalogue;

        //protected HiddenField hid_matixType;

        //protected HiddenField hid_PriceCatalogueID;

        //protected HiddenField hid_QuestionLenght;

        //protected HiddenField hid_MultipleLenght;

        //protected HiddenField hid_MatrixLenght;

        //protected HiddenField hid_qtyFromList;

        //protected HiddenField hid_qtyToList;

        //protected HiddenField hid_CostExcMarkupList;

        //protected HiddenField hid_MarkupList;

        //protected HiddenField hid_Markup;

        //protected HiddenField hid_priceList;

        //protected HiddenField hid_Maxquantity;

        //protected HiddenField hid_QuantityPrice;

        //protected HiddenField hid_QuantityPriceExcMarkup;

        //protected HiddenField hid_SaveToAdditionalItems;

        //protected HiddenField hid_UpdateToOrderItems;

        //protected HiddenField hid_artwork1;

        //protected HiddenField hid_artwork2;

        //protected HiddenField hid_artwork3;

        //protected HiddenField hid_OldPriceCatalogueID;

        //protected HiddenField hdn_stockBackwarehoue;

        //protected HiddenField hdn_orderedquantity;

        //protected HiddenField hdn_soldPackOV;

        //protected HiddenField hdnDrawStockFrom;

        //protected HiddenField hdnIsStockItem;

        //protected HiddenField hdnStockAdditionalOption;

        //protected HiddenField hdn_orderedheight;

        //protected HiddenField hdn_orderedwidth;

        //protected HiddenField hdn_orderedarea;

        //protected HiddenField hid_catalogue_items;

        //protected usercontrol_settings_Loading ucLoading2;

        //protected HiddenField hid_Price_CustomerID;

        //protected HiddenField hid_Customer_Name;

        //protected HiddenField hidCatalogueDataOnEdit;

        //protected Panel pnlCatalogueOnEdit;

        //protected HiddenField hid_GetItemDescription;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private BaseClass ObjClass = new BaseClass();

        public int CustID;

        public int CustomerID;

        public static int Customer_ID;

        public string ClearFilter = string.Empty;

        private commonClass commclass = new commonClass();

        public BaseClass objBase = new BaseClass();

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objLanguage = new languageClass();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public long EstSingleItemID;

        public long TypeID;

        public string EstType = string.Empty;

        private string CatalogueProfitAndTax = string.Empty;

        private string CatalogueProfit = string.Empty;

        private string CatalogueTax = string.Empty;

        public int PageSize = 1000000;

        public int ClientID;

        public string companytype = string.Empty;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private commonClass objJava = new commonClass();

        public string QueryType = string.Empty;

        public string tabtype = "webstoreorder";

        public string widthsize = string.Empty;

        public string modulename = "webstoreorder";

        public string submodulename = "webstoreorder";

        public string Pub_CustomerID = "0";

        public string Pub_CustomerName = "";

        private Global gloobj = new Global();

        public string EstTypeFromSP = string.Empty;

        public string subedit = string.Empty;

        public decimal defaultvalue;

        public string MainType = string.Empty;

        public bool Check_SpecialPrivilege;

        private Label txt_lblItemtitle = new Label();

        private Label txt_lblDescription = new Label();

        private Label txt_lblArtwork = new Label();

        private Label txt_lblColour = new Label();

        private Label txt_lblSize = new Label();

        private Label txt_lblMaterial = new Label();

        private Label txt_lblDelivery = new Label();

        private Label txt_lblFinishing = new Label();

        private Label txt_lblProofs = new Label();

        private Label txt_lblPacking = new Label();

        private Label txt_lblNotes = new Label();

        private Label txt_lblInstructions = new Label();

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        private int IsDirectJob;

        private int IsForInvoice;

        public string Webstore = string.Empty;

        public long OrderID;

        public long OrderItemID;

        public string artworkFile = string.Empty;

        public static string eprintDocumentName;

        public static long AccountID;

        public string strFilepath = global.filePath();

        private FileUpload fp_artwork1 = new FileUpload();

        private FileUpload fp_artwork2 = new FileUpload();

        private FileUpload fp_artwork3 = new FileUpload();

        private Label lbl_reqartworkFile = new Label();

        private Label lblartwork1 = new Label();

        private Label lblartwork2 = new Label();

        private Label lblartwork3 = new Label();

        private SummaryClass summry = new SummaryClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public string ServerName = string.Empty;

        public string SecureSitePath = global.SecureSitePath();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureDocFilepath = global.SecureDocFilepath();

        public string MeasurementValue = string.Empty;

        public int RoundOff;

        private long IsCampaignSelected;

        public string WhereConditionEstimateProdouct = string.Empty;

        public long jobID;

        public string jID = string.Empty;

        public long InvoiceID;

        public string InvID = string.Empty;

        public bool IsCumulative;

        public string noofCartItems;

        public string ProductName = string.Empty;

        public int ProguctGroupID;

        public string AdditionalOptionCalculationType = string.Empty;

        public long MainGroupAdditionalOptionCount;

        public string SubAdditionalOptionValue = string.Empty;

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

        static item_product_catalogue()
        {
            item_product_catalogue.Customer_ID = -1;
            item_product_catalogue.eprintDocumentName = string.Empty;
            item_product_catalogue.AccountID = (long)0;
            item_product_catalogue.ManageStockPermission = 0;
        }

        public item_product_catalogue()
        {
        }

        public void artwork_file(FileUpload fileUpload, long AccountID, long OrderItemID, int count, out string fileName)
        {
            string[] strArrays = fileUpload.FileName.ToString().Trim().Split(new char[] { '.' });
            string str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            string str1 = this.ReplaceAllBlankSpace(this.ObjClass.ReplaceSingleQuote(fileUpload.FileName));
            if (str.ToLower() != ".exe" || str.ToLower() != ".jar" || str.ToLower() != ".dll" || str.ToLower() != ".zip" || str.ToLower() != ".asmx" || str.ToLower() != ".asmx.cs" || str.ToLower() != ".aspx" || str.ToLower() != ".aspx.cs" || str.ToLower() != ".ascx" || str.ToLower() != ".ascx.cs" || str.ToLower() != ".asax" || str.ToLower() != ".asax.cs")
            {
                if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//store")))
                {
                    Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//store"));
                }
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", AccountID };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//store//", AccountID };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                if (count == 1)
                {
                    object[] orderItemID = new object[] { OrderItemID, "_", count, "_", str1 };
                    item_product_catalogue.eprintDocumentName = string.Concat(orderItemID);
                    FileUpload fpArtwork1 = this.fp_artwork1;
                    object[] secureDocFilepath = new object[] { this.SecureDocFilepath, this.ServerName, "//store//", AccountID, "//", item_product_catalogue.eprintDocumentName };
                    fpArtwork1.SaveAs(string.Concat(secureDocFilepath));
                }
                else if (count == 2)
                {
                    object[] orderItemID1 = new object[] { OrderItemID, "_", count, "_", str1 };
                    item_product_catalogue.eprintDocumentName = string.Concat(orderItemID1);
                    FileUpload fpArtwork2 = this.fp_artwork2;
                    object[] secureDocFilepath1 = new object[] { this.SecureDocFilepath, this.ServerName, "//store//", AccountID, "//", item_product_catalogue.eprintDocumentName };
                    fpArtwork2.SaveAs(string.Concat(secureDocFilepath1));
                }
                else if (count == 3)
                {
                    object[] objArray1 = new object[] { OrderItemID, "_", count, "_", str1 };
                    item_product_catalogue.eprintDocumentName = string.Concat(objArray1);
                    FileUpload fpArtwork3 = this.fp_artwork3;
                    object[] secureDocFilepath2 = new object[] { this.SecureDocFilepath, this.ServerName, "//store//", AccountID, "//", item_product_catalogue.eprintDocumentName };
                    fpArtwork3.SaveAs(string.Concat(secureDocFilepath2));
                }
            }
            else
            {
                this.lbl_reqartworkFile.Text = string.Concat("Please select valid file, your file extension is '", str, "'.");
            }
            fileName = item_product_catalogue.eprintDocumentName;
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridPriceCatalogue.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridPriceCatalogue.MasterTableView.FilterExpression = string.Empty;
            this.GridPriceCatalogue.MasterTableView.Rebind();
        }

        public void Common_PriceCatalogue_Call(string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, string fromType, string SortExpression, string SortDirection, int PageSize, int PageNumber)
        {
            HiddenField hidQueryDetails = this.hid_query_details;
            object[] queryType = new object[] { QueryType, "±", CustomerID, "±", CustomerName, "±", ItemTitle, "±" };
            hidQueryDetails.Value = string.Concat(queryType);
            HiddenField hiddenField = this.hid_query_details;
            string[] value = new string[] { this.hid_query_details.Value, Description, "±", SortExpression, "±", SortDirection };
            hiddenField.Value = string.Concat(value);
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.price_catalogue_select_search(this.CompanyID, QueryType, CustomerID, CustomerName, ItemTitle, Description, PageSize, PageNumber, SortExpression, SortDirection, this.Webstore, this.WhereConditionEstimateProdouct);
            this.GridPriceCatalogue.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.GridPriceCatalogue.DataBind();
            }
            HiddenField str = this.hidCatalogueCount;
            int count = this.GridPriceCatalogue.MasterTableView.Items.Count;
            str.Value = count.ToString();
        }

        public void Common_PriceCatalogue_Call_new(string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, string fromType, string SortExpression, string SortDirection, int PageSize, int PageNumber)
        {
            HiddenField hidQueryDetails = this.hid_query_details;
            object[] queryType = new object[] { QueryType, "±", CustomerID, "±", CustomerName, "±", ItemTitle, "±" };
            hidQueryDetails.Value = string.Concat(queryType);
            HiddenField hiddenField = this.hid_query_details;
            string[] value = new string[] { this.hid_query_details.Value, Description, "±", SortExpression, "±", SortDirection };
            hiddenField.Value = string.Concat(value);
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.price_catalogue_select_search(this.CompanyID, QueryType, CustomerID, CustomerName, ItemTitle, Description, PageSize, PageNumber, SortExpression, SortDirection, this.Webstore, this.WhereConditionEstimateProdouct);
            this.GridPriceCatalogue.DataSource = dataSet;
        }

        public void ddlCategoryBind_Onchange(object sender, EventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            if (this.ddlCategoryBind.Items[1].Selected)
            {
                HiddenField hdnParam = this.hdn_param;
                object[] pageSize = new object[] { "A±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam.Value = string.Concat(pageSize);
                this.Common_PriceCatalogue_Call("A", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
                return;
            }
            if (this.ddlCategoryBind.Items[2].Selected)
            {
                HiddenField hiddenField = this.hdn_param;
                object[] objArray = new object[] { "U±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hiddenField.Value = string.Concat(objArray);
                this.Common_PriceCatalogue_Call("U", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
                return;
            }
            if (this.ddlCategoryBind.Items[0].Selected)
            {
                str = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
                HiddenField hdnParam1 = this.hdn_param;
                object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam1.Value = string.Concat(num);
                this.Common_PriceCatalogue_Call("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
            }
        }

        public void GetCampaignsValue()
        {
            DataTable dataTable = OrderBasePage.Select_CampaignValues(item_product_catalogue.AccountID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            bool flag = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["EventName"] = this.objBase.SpecialDecode(row["EventName"].ToString());
                if ((long)Convert.ToInt32(row["ManageID"]) != this.IsCampaignSelected)
                {
                    continue;
                }
                flag = true;
            }
            this.ddlCampaign.DataSource = dataTable;
            this.ddlCampaign.DataTextField = "EventName";
            this.ddlCampaign.DataValueField = "ManageID";
            this.ddlCampaign.DataBind();
            this.ddlCampaign.Items.Insert(0, new ListItem("-- Select --", "0"));
            this.ddlCampaign.SelectedValue = "0";
            if (flag)
            {
                this.ddlCampaign.SelectedValue = this.IsCampaignSelected.ToString();
            }
        }

        protected void GridPriceCatalogue_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            if (this.ddlCategoryBind.Items[1].Selected)
            {
                HiddenField hdnParam = this.hdn_param;
                object[] pageSize = new object[] { "A±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam.Value = string.Concat(pageSize);
                this.Common_PriceCatalogue_Call_new("A", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                return;
            }
            if (this.ddlCategoryBind.Items[2].Selected)
            {
                HiddenField hiddenField = this.hdn_param;
                object[] objArray = new object[] { "U±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hiddenField.Value = string.Concat(objArray);
                this.Common_PriceCatalogue_Call_new("U", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                return;
            }
            if (this.ddlCategoryBind.Items[0].Selected)
            {
                str = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
                HiddenField hdnParam1 = this.hdn_param;
                object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam1.Value = string.Concat(num);
                this.Common_PriceCatalogue_Call_new("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
            }
        }

        private void GridStateLoad()
        {
            this.commclass.GridStateLoadNew("Order", "OrderProductCatalogue", this.GridPriceCatalogue, "no");
        }

        private void GridStateSave()
        {
            this.commclass.GridStateSaveNew("Order", "OrderProductCatalogue", this.GridPriceCatalogue);
        }

        protected void lnkLoadPriceCatalogue_OnClick(object sender, EventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            HiddenField hdnParam = this.hdn_param;
            object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
            hdnParam.Value = string.Concat(num);
            this.Common_PriceCatalogue_Call("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
        }

        protected void lnkProductCatalogue_OnClick(object sender, EventArgs e)
        {
            this.plhquantity.Controls.Clear();
            this.Product_catalogueDetails();
        }

        public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type, string ActionType, int SelectedID)
        {
            if (Type != "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "Label";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            else
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["SelectedID"]) == SelectedID)
                    {
                        ddlMutiple.SelectedIndex = num;
                    }
                    num++;
                }
            }
        }

        public void SetDDItems(DropDownList ddl, string selectedText, PlaceHolder plhPriceCalculator, Boolean IsMandatory)
        {
            try
            {
                //if (IsMandatory)
                //{
                //    ddl.Items.Add("--select--");

                //}
                ddl.Items.Add("No");
                ddl.Items.Add("Yes");
              
                ListItem listItem = ddl.Items.FindByValue(selectedText);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
                plhPriceCalculator.Controls.Add(ddl);

            }
            catch
            {
            }
        }

        protected void Onclick_btnUpdate(object sender, EventArgs e)
        {
            object[] orderID;
            int num = 0;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            string empty = string.Empty;
            string value = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            long num9 = (long)0;
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            bool flag = false;
            int num12 = 0;
            string value1 = this.hid_UpdateToOrderItems.Value;
            char[] chrArray = new char[] { '»' };
            string[] strArrays = value1.Split(chrArray);
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                if (strArrays[i] != "")
                {
                    num = Convert.ToInt32(strArrays[0]);
                    num1 = Convert.ToDecimal(strArrays[1]);
                    num2 = Convert.ToDecimal(strArrays[2]);
                    num4 = Convert.ToDecimal(strArrays[3]);
                    num3 = Convert.ToDecimal(strArrays[4]);
                    num5 = Convert.ToDecimal(strArrays[5]);
                    num6 = Convert.ToDecimal(strArrays[6]);
                    num7 = Convert.ToDecimal(strArrays[7]);
                    num8 = Convert.ToDecimal(strArrays[8]);
                    num10 = Convert.ToDecimal(strArrays[9]);
                    num11 = Convert.ToDecimal(strArrays[10]);
                    flag = Convert.ToBoolean(strArrays[11]);
                    num12 = Convert.ToInt32(strArrays[12]);
                }
            }
            if (this.ddlCampaign.SelectedValue != "0")
            {
                num9 = Convert.ToInt64(this.ddlCampaign.SelectedItem.Value);
            }
            if (this.lblartwork1.Text != "")
            {
                value = this.hid_artwork1.Value;
            }
            else if (this.fp_artwork1.HasFile)
            {
                this.artwork_file(this.fp_artwork1, item_product_catalogue.AccountID, this.OrderItemID, 1, out empty);
                value = empty;
            }
            if (this.lblartwork2.Text != "")
            {
                str = this.hid_artwork2.Value;
            }
            else if (this.fp_artwork2.HasFile)
            {
                this.artwork_file(this.fp_artwork2, item_product_catalogue.AccountID, this.OrderItemID, 2, out empty);
                str = empty;
            }
            if (this.lblartwork3.Text != "")
            {
                empty1 = this.hid_artwork3.Value;
            }
            else if (this.fp_artwork3.HasFile)
            {
                this.artwork_file(this.fp_artwork3, item_product_catalogue.AccountID, this.OrderItemID, 3, out empty);
                empty1 = empty;
            }
            if (string.IsNullOrEmpty(this.hid_Markup.Value))
            {
                this.hid_Markup.Value = "0";
            }
            OrderBasePage.Update_OrdersItems((long)this.CompanyID, this.OrderID, this.OrderItemID, Convert.ToInt64(this.hid_PriceCatalogueID.Value), this.ObjClass.ReplaceSingleQuote(this.txtJobName.Text), num, num1, value, str, empty1, num2, num3, num4, num5, num6, num7, "", num8, num9, num10, num11, Convert.ToDecimal(this.hid_Markup.Value), num12);
            string str1 = string.Empty;
            int num13 = 0;
            decimal num14 = new decimal(0);
            decimal num15 = new decimal(0);
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            decimal num18 = new decimal(0);
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            decimal num21 = new decimal(0);
            decimal num22 = new decimal(0);
            decimal num23 = new decimal(0);
            foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
            {
                str1 = string.Concat(row["OrderItemIDs"].ToString(), "±");
            }
            chrArray = new char[] { '±' };
            string[] strArrays1 = str1.Split(chrArray);
            Convert.ToInt32(strArrays1[0]);
            for (int j = 0; j < (int)strArrays1.Length; j++)
            {
                if (strArrays1[j] != "")
                {
                    DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(Convert.ToInt64(strArrays1[j]));
                    DataTable item = dataSet.Tables[0];
                    DataTable dataTable = dataSet.Tables[1];
                    foreach (DataRow dataRow in item.Rows)
                    {
                        Convert.ToDecimal(dataRow["Tax"]);
                        num13 = num13 + Convert.ToInt32(dataRow["Quantity"]);
                        num18 = Convert.ToDecimal(dataRow["MainItemPrice"]) - Convert.ToDecimal(dataRow["MainItemMarkupPrice"]);
                        num4 = Convert.ToDecimal(dataRow["MainItemMarkupPrice"]);
                        int num24 = 0;
                        decimal num25 = new decimal(0);
                        decimal num26 = new decimal(0);
                        decimal num27 = new decimal(0);
                        foreach (DataRow row1 in dataTable.Rows)
                        {
                            num26 = Convert.ToDecimal(row1["TotalPrice"]) - Convert.ToDecimal(row1["MarkupValue"]);
                            num25 = num25 + num26;
                            num27 = num27 + Convert.ToDecimal(row1["MarkupValue"]);
                            num24++;
                        }
                        num14 = num18 + num25;
                        num15 = num4 + num27;
                        num16 = num14 + num15;
                        num6 = Convert.ToDecimal(dataRow["OrderItemTax"]);
                        num17 = num16 + num6;
                        num20 = num20 + num15;
                        num22 = num22 + num6;
                        num21 = num21 + num16;
                        num19 = num19 + num14;
                        num23 = num23 + num17;
                    }
                }
            }
            int num28 = 0;
            int num29 = 0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            DataTable dataTable1 = OrderBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, item_product_catalogue.AccountID, "no");
            foreach (DataRow dataRow1 in dataTable1.Rows)
            {
                long num30 = Convert.ToInt64(dataRow1["WebOtherCostID"].ToString());
                DataTable dataTable2 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.OrderID);
                this.hid_MultipleLenght.Value = dataTable2.Rows.Count.ToString();
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    if ((long)Convert.ToInt32(row2["OptionID"]) == num30)
                    {
                        num28 = Convert.ToInt32(row2["OptionID"]);
                        num29 = Convert.ToInt32(row2["SelectedID"]);
                    }
                    DataSet dataSet1 = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(num30);
                    DataTable item1 = dataSet1.Tables[0];
                    DataTable item2 = dataSet1.Tables[1];
                    int count = item2.Rows.Count;
                    int num31 = 0;
                    foreach (DataRow dataRow2 in item2.Rows)
                    {
                        if ((long)num28 == num30)
                        {
                            empty2 = Convert.ToString(dataRow2["FormulaNew"]);
                            if (empty2.Contains("[$TotalEx.GST$]") || empty2.Contains("[$TotalQty$]") || empty2.Contains("[$TotalInc.GST$]") || empty2.Contains("[$TotalNo.ofCartItems$]"))
                            {
                                chrArray = new char[] { '~' };
                                string[] strArrays2 = empty2.Split(chrArray);
                                int num32 = Convert.ToInt32(strArrays2[2]);
                                Convert.ToInt32(dataRow2["SortOrder"]);
                                num29 = num29;
                                string empty3 = string.Empty;
                                string str3 = string.Empty;
                                if (num32 == num29)
                                {
                                    dataRow2["Label"].ToString();
                                    Convert.ToString(num32);
                                    if (this.hid_MultipleLenght.Value != "0")
                                    {
                                        for (int k = 0; k <= Convert.ToInt16(this.hid_MultipleLenght.Value) - 1; k++)
                                        {
                                            string str4 = empty2;
                                            chrArray = new char[] { '~' };
                                            string[] strArrays3 = str4.Split(chrArray);
                                            string str5 = strArrays3[0];
                                            str2 = strArrays3[0].ToString();
                                            for (int l = 0; l <= (int)strArrays3.Length; l++)
                                            {
                                                str2 = str2.ToLower().Replace("[$totalex.gst$]", Convert.ToString(num16)).Replace("[$totalinc.gst$]", Convert.ToString(num17)).Replace("[$totalqty$]", Convert.ToString(num13)).Replace("[$totalno.ofcartitems$]", this.noofCartItems.ToString());
                                                str2 = this.SplitFormula(str2);
                                            }
                                            str2 = Convert.ToString(decimal.Parse(str2.Trim()) + ((decimal.Parse(str2.Trim()) * decimal.Parse(strArrays3[1])) / new decimal(100)));
                                            OrderBasePage.CartAdditionalValues_Update(this.OrderID, (long)num28, decimal.Parse(str2.Trim()), num29);
                                        }
                                    }
                                }
                            }
                        }
                        num31++;
                    }
                }
            }
            string value2 = this.hid_SaveToAdditionalItems.Value;
            chrArray = new char[] { 'µ' };
            string[] strArrays4 = value2.Split(chrArray);
            for (int m = 0; m <= (int)strArrays4.Length - 1; m++)
            {
                long num33 = (long)0;
                decimal num34 = new decimal(0);
                decimal num35 = new decimal(0);
                long num36 = (long)0;
                decimal num37 = new decimal(0);
                decimal num38 = new decimal(0);
                string empty4 = string.Empty;
                int num39 = 0;
                long num40 = (long)0;
                string empty5 = string.Empty;
                if (strArrays4[m] != "")
                {
                    string str6 = strArrays4[m].ToString();
                    chrArray = new char[] { '±' };
                    string[] strArrays5 = str6.Split(chrArray);
                    string freeTextQuestionLong = string.Empty;
                    string calculation_type = string.Empty;
                    for (int n = 0; n <= (int)strArrays5.Length - 1; n++)
                    {
                        if (strArrays5[n] != "")
                        {
                            string str7 = strArrays5[n];
                            chrArray = new char[] { '»' };
                            string[] strArrays6 = str7.Split(chrArray);
                            if (strArrays6[0] != "")
                            {
                                if (strArrays6[0] == "OthercostID")
                                {
                                    num33 = Convert.ToInt64(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "Formula")
                                {
                                    empty2 = strArrays6[1];
                                }
                                else if (strArrays6[0] == "MarkUp")
                                {
                                    num34 = Convert.ToDecimal(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "TotalPrice")
                                {
                                    num35 = Convert.ToDecimal(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "SelectedID")
                                {
                                    num36 = Convert.ToInt64(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "SelectedValue")
                                {
                                    empty4 = strArrays6[1];
                                }
                                else if (strArrays6[0] == "MarkUpValue")
                                {
                                    num37 = Convert.ToDecimal(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "SelectedPrice")
                                {
                                    num38 = Convert.ToDecimal(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "SortOrderNo")
                                {
                                    num39 = Convert.ToInt32(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "ParentWebOtherCostID")
                                {
                                    num40 = Convert.ToInt64(strArrays6[1]);
                                }
                                else if (strArrays6[0] == "WebOtherCostType")
                                {
                                    empty5 = strArrays6[1];
                                }
                                else if (strArrays6[0] == "CalculationType")
                                {
                                    calculation_type = strArrays6[1];
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(calculation_type))
                    {
                        if (calculation_type == "l")
                        {
                            freeTextQuestionLong = empty4;
                        }
                    }
                    OrderBasePage.Insert_OrderAdditionalItems(this.OrderID, this.OrderItemID, num33, empty2, num34, num35, num36, empty4, num38, num37, num39, num40, empty5,freeTextQuestionLong);
                }
            }
            if (string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "invoice", true) == 0)
            {
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "X");
            }
            string empty6 = string.Empty;
            this.objnotes.ItemID = this.EstimateItemID;
            if (this.modulename.ToLower() == "jobs")
            {
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                this.objnotes.ModuleID = this.jobID;
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(this.jobID, this.EstimateItemID, this.modulename);
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    empty6 = row3["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty6;
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                this.objnotes.ModuleID = this.InvoiceID;
                DataTable dataTable4 = Notes.select_item_number_for_Activity_History(this.InvoiceID, this.EstimateItemID, this.modulename);
                foreach (DataRow dataRow3 in dataTable4.Rows)
                {
                    empty6 = dataRow3["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty6;
            }
            else if (this.modulename.ToLower() == "webstoreorder")
            {
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                this.objnotes.ModuleID = this.OrderID;
                DataTable dataTable5 = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, this.modulename);
                foreach (DataRow row4 in dataTable5.Rows)
                {
                    empty6 = row4["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty6;
            }
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.Chk_ItemDescn.Checked)
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "X", true);
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                }
            }
            if (base.Session["ProductStockManagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
            {
                string empty7 = string.Empty;
                foreach (DataRow dataRow4 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty7 = dataRow4["StatusID"].ToString();
                }
                BaseClass baseClass = new BaseClass();
                string lower = string.Empty;
                string lower1 = string.Empty;
                string empty8 = string.Empty;
                string str8 = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                string str9 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                string str10 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                DataTable dataTable6 = new DataTable();
                DataTable dataTable7 = new DataTable();
                DataTable dataTable8 = new DataTable();
                if (this.hid_OldPriceCatalogueID.Value == this.hid_PriceCatalogueID.Value)
                {
                    long num41 = Convert.ToInt64(this.hid_PriceCatalogueID.Value);
                    dataTable7 = baseClass.ProductStockType_Select((long)this.CompanyID, num41);
                    foreach (DataRow row5 in dataTable7.Rows)
                    {
                        lower1 = row5["DrawStockFrom"].ToString().ToLower();
                        if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num41, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                        }
                        else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select((long)0, num41, (long)this.CompanyID, "others", this.EstimateItemID);
                        }
                        else if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                continue;
                            }
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num41, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                        }
                        else
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num41, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                        }
                    }
                    foreach (DataRow dataRow5 in dataTable6.Rows)
                    {
                        if (Convert.ToInt32(dataRow5["TotalOldQty"].ToString()) == num && !flag)
                        {
                            continue;
                        }
                        if (str8 != "c" && str8 != "p" && str8 != "a")
                        {
                            if (!(str8 == "j") || !(baseClass.Return_StockManagementSettings("SA_EstoreJobStatusID") == empty7.ToString()))
                            {
                                continue;
                            }
                            if (lower1 == "s")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty8.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess((long)this.CompanyID, num41, (long)0, num, str9, "self", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 == "o")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num41, "other", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty8.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocation_Others((long)this.CompanyID, num41, num, str9, Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 != "a")
                            {
                                if (lower1 != "m")
                                {
                                    continue;
                                }
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty8.ToLower() != "success")
                                {
                                    continue;
                                }
                                foreach (DataRow row6 in PurchaseBasePage.OtherMultipleProductDetails_Select(num41, num, true).Rows)
                                {
                                    baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(row6["KitItemID"].ToString()), num41, num, str9, "multiple", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                                }
                            }
                            else
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty8.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num41, num, str9, "additional option", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                        }
                        else if (lower1 == "s")
                        {
                            empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty8.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass.StockAllocationProcess((long)this.CompanyID, num41, (long)0, num, str9, "self", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                        }
                        else if (lower1 == "o")
                        {
                            empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num41, "other", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty8.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass.StockAllocation_Others((long)this.CompanyID, num41, num, str9, Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                        }
                        else if (lower1 != "a")
                        {
                            if (lower1 != "m")
                            {
                                continue;
                            }
                            empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty8.ToLower() != "success")
                            {
                                continue;
                            }
                            foreach (DataRow dataRow6 in PurchaseBasePage.OtherMultipleProductDetails_Select(num41, num, true).Rows)
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow6["KitItemID"].ToString()), num41, num, str9, "multiple", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                        }
                        else
                        {
                            empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num41, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty8.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num41, num, str9, "additional option", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                        }
                    }
                }
                else
                {
                    long num42 = Convert.ToInt64(this.hid_PriceCatalogueID.Value);
                    long num43 = Convert.ToInt64(this.hid_OldPriceCatalogueID.Value);
                    dataTable7 = baseClass.ProductStockType_Select((long)this.CompanyID, num42);
                    foreach (DataRow row7 in dataTable7.Rows)
                    {
                        lower1 = row7["DrawStockFrom"].ToString().ToLower();
                        if (row7["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num43, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                        }
                        else if (row7["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select((long)0, num43, (long)this.CompanyID, "others", this.EstimateItemID);
                        }
                        else if (row7["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            if (row7["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                continue;
                            }
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num43, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                        }
                        else
                        {
                            dataTable6 = baseClass.StockProductRerunDetails_Select(num43, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                        }
                    }
                    dataTable8 = baseClass.ProductStockType_Select((long)this.CompanyID, num43);
                    foreach (DataRow dataRow7 in dataTable8.Rows)
                    {
                        lower = dataRow7["DrawStockFrom"].ToString().ToLower();
                    }
                    foreach (DataRow row8 in dataTable6.Rows)
                    {
                        if (str8 == "c" || str8 == "p" || str8 == "a")
                        {
                            if (lower == "s")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "o")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num43, "other", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "a")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "m")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            if (empty8.ToLower() != "success")
                            {
                                continue;
                            }
                            if (lower1 == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num42, (long)0, num, str9, "self", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num42, num, str9, Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 != "a")
                            {
                                if (lower1 != "m")
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow8 in PurchaseBasePage.OtherMultipleProductDetails_Select(num42, num, true).Rows)
                                {
                                    baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow8["KitItemID"].ToString()), num42, num, str9, "multiple", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                                }
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num42, num, str9, "additional option", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                        }
                        else
                        {
                            if (!(str8 == "j") || !(baseClass.Return_StockManagementSettings("SA_EstoreJobStatusID") == empty7.ToString()))
                            {
                                continue;
                            }
                            if (lower == "s")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "o")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num43, "other", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "a")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            else if (lower == "m")
                            {
                                empty8 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num43, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            }
                            if (lower1 == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num42, (long)0, num, str9, "self", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num42, num, str9, Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                            else if (lower1 != "a")
                            {
                                if (lower1 != "m")
                                {
                                    continue;
                                }
                                foreach (DataRow row9 in PurchaseBasePage.OtherMultipleProductDetails_Select(num42, num, true).Rows)
                                {
                                    baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(row9["KitItemID"].ToString()), num42, num, str9, "multiple", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                                }
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num42, num, str9, "additional option", Convert.ToBoolean(str10), this.EstimateItemID, "Job", num1, (long)this.UserID);
                            }
                        }
                    }
                }
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && (this.hdn_stockBackwarehoue.Value == "yes" || this.StockCancellationType == "a" && this.hid_OldPriceCatalogueID.Value != this.hid_PriceCatalogueID.Value))
                {
                    DataTable dataTable9 = this.ObjClass.ProductStockType_Select((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value));
                    foreach (DataRow dataRow9 in dataTable9.Rows)
                    {
                        if (dataRow9["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                        }
                        else if (dataRow9["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), "other", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                        }
                        else if (dataRow9["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (dataRow9["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                        }
                        else
                        {
                            this.ObjClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), "additional option", num, this.EstimateItemID, "Job", (long)this.UserID, num2);
                        }
                    }
                }
            }
            long num44 = (long)0;
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                num44 = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(num44);
            }
            if (this.modulename.ToLower() == "jobs")
            {
                HttpResponse response = base.Response;
                orderID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=edit&ordid=", this.OrderID, "&estid=", this.EstimateID, this.jID, "&EstItemID=", this.EstimateItemID };
                response.Redirect(string.Concat(orderID));
                return;
            }
            if (this.modulename == "invoice")
            {
                HttpResponse httpResponse = base.Response;
                orderID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=edit&ordid=", this.OrderID, "&estid=", this.EstimateID, this.InvID, "&EstItemID=", this.EstimateItemID };
                httpResponse.Redirect(string.Concat(orderID));
                return;
            }
            if (this.modulename == "webstoreorder")
            {
                HttpResponse response1 = base.Response;
                orderID = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=edit&ordid=", this.OrderID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID };
                response1.Redirect(string.Concat(orderID));
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridPriceCatalogue.FilterMenu;
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

        protected void OnSorting_GridPriceCatalogue(object sender, GridViewSortEventArgs e)
        {
            string str = (e.SortDirection.ToString() == "Ascending" ? "ASC" : "DESC");
            string str1 = e.SortExpression.ToString();
            string[] strArrays = this.hid_query_details.Value.Split(new char[] { '±' });
            try
            {
                if (string.Compare(str1, strArrays[5], true) == 0)
                {
                    if (string.Compare(strArrays[6], "ASC", true) == 0)
                    {
                        str = "DESC";
                    }
                    else if (string.Compare(str, "DESC", true) == 0)
                    {
                        str = "ASC";
                    }
                }
                this.Common_PriceCatalogue_Call(strArrays[0], Convert.ToInt32(strArrays[1]), strArrays[2], strArrays[3], strArrays[4], "sort", str1, str, this.PageSize, 1);
            }
            catch
            {
                str = "ASC";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ddlCategoryBind.Items[1].Text = this.objLanguage.GetLanguageConversion("All_Items");
            this.ddlCategoryBind.Items[2].Text = this.objLanguage.GetLanguageConversion("Unallocated_Items");
            this.btnUpdate.Text = this.objLanguage.GetLanguageConversion("Update");
            this.txt_lblItemtitle.Text = "Item Title";
            this.txt_lblDescription.Text = "Description";
            this.txt_lblArtwork.Text = "Artwork";
            this.txt_lblColour.Text = "Colour";
            this.txt_lblSize.Text = "Size";
            this.txt_lblMaterial.Text = "Material";
            this.txt_lblDescription.Text = "Delivery";
            this.txt_lblFinishing.Text = "Finishing";
            this.txt_lblProofs.Text = "Proofs";
            this.txt_lblPacking.Text = "Packing";
            this.txt_lblNotes.Text = "Notes";
            this.txt_lblInstructions.Text = "Instructions";
            this.gloobj.setpagename("estimate");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            DataTable dataTable = EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID);
            if (dataTable.Rows.Count > 0)
            {
                this.OrderID = Convert.ToInt64(dataTable.Rows[0]["EstimateID"]);
                this.EstimateID = this.OrderID;
            }
            int count = EstimatesBasePage.EstimateitemIDList_PerEstID(this.EstimateID).Rows.Count;
            this.noofCartItems = count.ToString();
            this.defaultvalue = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.defaultvalue), 0, "", false, false, true));
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            global.pgName = string.Empty;
            this.MeasurementValue = CompanyBasePage.Measurment(this.CompanyID);
            this.RoundOff = OrderBasePage.Company_RoundOff_Value(this.CompanyID);
            if (ConnectionClass.WebStore != null)
            {
                this.Webstore = ConnectionClass.WebStore.ToString();
            }
            this.Check_SpecialPrivilege = false;
            this.Check_SpecialPrivilege = this.Objclss.Check_SpecialPrivilege_For_User((long)this.UserID, (long)this.CompanyID);
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.tabtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx"))
            {
                this.tabtype = "webstoreorder";
            }
            else
            {
                this.tabtype = "invoice";
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "webstoreorder";
                this.submodulename = "webstoreorder";
            }
            else
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
            }
            DataSet dataSet = new DataSet();
            if (string.Compare(this.QueryType, "edit", true) == 0 && base.Request.QueryString["esttype"] != null)
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
            }
            foreach (DataRow row in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
            {
                this.Pub_CustomerID = row["CustomerID"].ToString();
                this.Pub_CustomerName = row["ClientName"].ToString();
                this.hid_Price_CustomerID.Value = this.Pub_CustomerID;
                this.hid_Customer_Name.Value = this.Pub_CustomerName;
                this.IsDirectJob = Convert.ToInt32(row["IsDirectJob"]);
                this.IsForInvoice = Convert.ToInt32(row["IsForInvoice"]);
            }
            if (base.Request.QueryString["esttype"] != null)
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                this.Select_Catalogue_Item();
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.ddlCategoryBind.Items[0].Text = this.hid_Customer_Name.Value;
            string value = this.hid_Price_CustomerID.Value;
            value = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
            string str = this.txtPriceCatalogueSerach.Value.ToString();
            string str1 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            if (!base.IsPostBack)
            {
                this.Common_PriceCatalogue_Call("C", Convert.ToInt32(value), str1, str, "", "search", "CatalogueName", "asc", this.PageSize, 1);
                HiddenField hdnParam = this.hdn_param;
                object[] num = new object[] { "C±", Convert.ToInt32(value), "±", str1, "±", str, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam.Value = string.Concat(num);
            }
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
            foreach (DataRow dataRow in OrderBasePage.OrderItemID_Select(this.OrderID, this.EstimateItemID).Rows)
            {
                this.OrderItemID = Convert.ToInt64(dataRow["OrderItemID"]);
                this.ProductName = dataRow["ItemTitle"].ToString();
                if (base.IsPostBack)
                {
                    continue;
                }
                this.hid_PriceCatalogueID.Value = dataRow["ProductID"].ToString();
            }
            if (!base.IsPostBack)
            {
                this.Product_catalogueDetails_Edit();
                if (string.Compare(this.QueryType, "edit", true) == 0)
                {
                    foreach (DataRow row1 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (row1["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_ItemDescn.Checked = false;
                        }
                        else
                        {
                            this.Chk_ItemDescn.Checked = true;
                        }
                    }
                }
            }
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            item_product_catalogue.ManageStockPermission = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            if (item_product_catalogue.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (this.IsCampaignSelected > (long)0)
            {
                this.divCampaign.Style.Add("display", "block");
                this.hdnEnabledCampaign.Value = "true";
            }
            if (!base.IsPostBack)
            {
                this.GetCampaignsValue();
            }
        }

        public void Price_Area(int CompanyID, PlaceHolder plh, string QueryType, string AdditionItem, decimal OrderItemTotalPrice, decimal OrderItemTax, decimal TaxRate, long TaxID, string TaxName)
        {
            decimal orderItemTotalPrice = OrderItemTotalPrice + OrderItemTax;
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' >"));
            plh.Controls.Add(new LiteralControl(string.Concat("<label>", this.objLanguage.GetLanguageConversion("Total"), " </label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle'></div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lbltotal' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</label>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' id='hdnlbltotal' value='", OrderItemTotalPrice, "'></input>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
            plh.Controls.Add(new LiteralControl("</div>"));
            if (QueryType == "add")
            {
                TaxID = (long)EstimatesBasePage.GetTaxIDByProductID(CompanyID, Convert.ToInt64(this.hid_PriceCatalogueID.Value));
                foreach (DataRow row in SettingsBasePage.settings_taxrate_selectbyID(CompanyID, Convert.ToInt32(TaxID)).Rows)
                {
                    TaxName = this.objBase.SpecialDecode(row["TaxName"].ToString());
                    TaxRate = Convert.ToDecimal(row["TaxRate"].ToString());
                }
            }
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel'>"));
            ControlCollection controls = plh.Controls;
            string[] languageConversion = new string[] { "<label id='lblTax'>", this.objLanguage.GetLanguageConversion("Tax"), " : ", TaxName, " ( ", this.commclass.ToRemoveDecimalPlacesIfZero(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(TaxRate), 2, "", false, false, true)), " %) </label>" };
            controls.Add(new LiteralControl(string.Concat(languageConversion)));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle'></div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
            ControlCollection controlCollections = plh.Controls;
            object[] taxRate = new object[] { "<label id='lblTaxRate' style='display:none;'>", TaxRate, "</label><label id='lblTotalTax'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTax, 0, "", false, false, true), "</label>" };
            controlCollections.Add(new LiteralControl(string.Concat(taxRate)));
            ControlCollection controls1 = plh.Controls;
            object[] orderItemTax = new object[] { "<input type='hidden' id='hdnlblTotalTax' value='", OrderItemTax, "'></input><input type='hidden' id='hdnTaxId' value='", TaxID, "'></input>" };
            controls1.Add(new LiteralControl(string.Concat(orderItemTax)));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel'>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblSellingPrice' class='lblSellingPrice'>", this.objLanguage.GetLanguageConversion("Total_Price_inc_Tax"), " </label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle'></div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblTotalSellingPrice' class='lblTotalSellingPrice'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, orderItemTotalPrice, 0, "", false, false, true), "</label>")));
            plh.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' id='hdnlblTotalSellingPrice' value='", orderItemTotalPrice, "'></input>")));
            plh.Controls.Add(new LiteralControl("</div>"));
        }

        public void Product_catalogueDetails()
        {
            this.fp_artwork1.ID = "fp_artwork1";
            this.fp_artwork2.ID = "fp_artwork2";
            this.fp_artwork3.ID = "fp_artwork3";
            this.lblartwork1.ID = "lblartwork1";
            this.lblartwork2.ID = "lblartwork2";
            this.lblartwork3.ID = "lblartwork3";
            this.lblartwork1.Style.Add("display", "none");
            this.lblartwork2.Style.Add("display", "none");
            this.lblartwork3.Style.Add("display", "none");
            this.hid_qtyFromList.Value = "";
            this.hid_qtyToList.Value = "";
            this.hid_CostExcMarkupList.Value = "";
            this.hid_MarkupList.Value = "";
            this.hid_priceList.Value = "";
            long num = Convert.ToInt64(this.hid_PriceCatalogueID.Value);
            foreach (DataRow row in OrderBasePage.productsDetails_Select(num).Rows)
            {
                this.lblProductName.Text = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                this.hid_matixType.Value = row["MatrixType"].ToString();
                this.artworkFile = row["ArtworkFile"].ToString();
                Convert.ToInt32(row["ArtworkCount"]);
                if (this.artworkFile.ToLower().Trim() != "n")
                {
                    this.artwork_div.Style.Add("display", "block");
                }
                else
                {
                    this.artwork_div.Style.Add("display", "none");
                }
                if (Convert.ToInt32(row["ArtworkCount"].ToString()) == 1)
                {
                    this.fp_artwork2.Visible = false;
                    this.fp_artwork3.Visible = false;
                }
                else if (Convert.ToInt32(row["ArtworkCount"].ToString()) == 2)
                {
                    this.fp_artwork3.Visible = false;
                }
                if (Convert.ToBoolean(row["IsCumulativePricing"]))
                {
                    this.IsCumulative = true;
                }
                if (Convert.ToInt32(row["SoldInPacksOf"]) == 0)
                {
                    this.hdn_soldPackOV.Value = "1";
                }
                else
                {
                    this.hdn_soldPackOV.Value = row["SoldInPacksOf"].ToString();
                }
            }
            DataTable dataTable = OrderBasePage.Product_CatalogueQty_Select(num);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                HiddenField hidQtyFromList = this.hid_qtyFromList;
                hidQtyFromList.Value = string.Concat(hidQtyFromList.Value, dataRow["FromQuantity"].ToString(), "µ");
                HiddenField hidQtyToList = this.hid_qtyToList;
                hidQtyToList.Value = string.Concat(hidQtyToList.Value, dataRow["ToQuantity"].ToString(), "µ");
                HiddenField hidCostExcMarkupList = this.hid_CostExcMarkupList;
                hidCostExcMarkupList.Value = string.Concat(hidCostExcMarkupList.Value, dataRow["Price"].ToString(), "µ");
                HiddenField hidMarkupList = this.hid_MarkupList;
                hidMarkupList.Value = string.Concat(hidMarkupList.Value, dataRow["Markup"].ToString(), "µ");
                HiddenField hidPriceList = this.hid_priceList;
                hidPriceList.Value = string.Concat(hidPriceList.Value, dataRow["SellingPrice"].ToString(), "µ");
            }
            this.plhquantity.Controls.Add(new LiteralControl("<div >"));
            if (this.hid_matixType.Value == "P")
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div  class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);' maxlength='8'/>"));
            }
            else if (this.hid_matixType.Value == "G")
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div  class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<input id='txtqty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);' maxlength='8'/>"));
            }
            else if (!this.IsCumulative)
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Select_Quantity_to_Order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin:0px 0px 0px 5px'>"));
                DropDownList dropDownList = new DropDownList()
                {
                    ID = "ddlPriceQty",
                    CssClass = "dropDownMultiple75"
                };
                dropDownList.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');");
                dropDownList.Attributes.Add("onblur", "javascript:Tocalculate_totalPrice('0');");
                this.SimpleMatrix_DropDownBind(dataTable, dropDownList, this.plhquantity, "", 0);
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<input id='txt_Cumulative_PriceQty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript: CheckIsDecimal_Textbox(this,this.value);Tocalculate_totalPrice(this.value);' onkeyup='javascript: CheckIsDecimal_Textbox(this,this.value);Tocalculate_totalPrice(this.value);' maxlength='8'/>"));
                DropDownList dropDownList1 = new DropDownList()
                {
                    ID = "ddlPriceQty",
                    CssClass = "dropDownMultiple75"
                };
                dropDownList1.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');");
                dropDownList1.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                dropDownList1.Style.Add("display", "none");
                this.SimpleMatrix_DropDownBind(dataTable, dropDownList1, this.plhquantity, "", 0);
            }
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty' class='spanerrorMsg' style='display:none;margin-top: -26px;margin-left: 75px;width: auto;'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_quantity"), "</span></div>")));
            if (this.hid_matixType.Value == "G")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<div >"));
                ControlCollection controls = this.plhquantity.Controls;
                string[] languageConversion = new string[] { "<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></div>" };
                controls.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding-left:5px;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divWeight' style='font-size:11px;padding:2px 5px 0px 0px;'><span>", this.objLanguage.GetLanguageConversion("Width"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<input id='txtWidth' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' maxlength='8'/>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding-left:5px;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divHeight' style='font-size:11px;padding:2px 5px 0px 10px;'><span>", this.objLanguage.GetLanguageConversion("Height"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<input id='txtHeight' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' maxlength='8'/>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_Dimensn' class='spanerrorMsg' style='display:none;width: auto;margin-top: -1px;'><span id='spnDimensn'>", this.objLanguage.GetLanguageConversion("Please_enter_dimension"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int length = 0;
            int num4 = 0;
            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row1 in OrderBasePage.Select_OtherCostAdditional_ItemsIDs(num).Rows)
            {
                DataSet dataSet = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(row1["WebOtherCostID"].ToString()));
                DataTable item = dataSet.Tables[0];
                DataTable item1 = dataSet.Tables[1];
                long num5 = Convert.ToInt64(row1["WebOtherCostID"].ToString());
                long num6 = Convert.ToInt64(row1["AdditionalGroupID"].ToString());
                num4++;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                foreach (DataRow dataRow1 in item.Rows)
                {
                    this.MainCalculationtype = dataRow1["MainCalculationType"].ToString();
                    if (this.MainCalculationtype.ToLower() == "c")
                    {
                        int num7 = Convert.ToInt32(dataRow1["IsCartmandatory"]);
                        str1 = num7.ToString();
                    }
                    dataRow1["Description"].ToString().Replace("\n", "<br>");
                    this.OtherCostName = dataRow1["UserFriendlyName"].ToString();
                    try
                    {
                        this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                    }
                    catch
                    {
                    }
                }
                int num8 = 0;
                if (num6 == (long)0)
                {
                    empty1 = "1";
                }
                else if (empty == "")
                {
                    empty1 = "1";
                }
                else
                {
                    string[] strArrays = empty.Split(new char[] { '±' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (strArrays[i] == "")
                        {
                            empty1 = "1";
                        }
                        else
                        {
                            empty1 = (num6 == (long)0 || Convert.ToInt64(strArrays[i]) != num6 ? "1" : "0");
                        }
                    }
                }
                empty = string.Concat(empty, row1["AdditionalGroupID"].ToString(), "±");
                foreach (DataRow row2 in item1.Rows)
                {
                    if (this.MainCalculationtype.ToLower() == "q")
                    {
                        string str2 = row2["formula"].ToString();
                        string str3 = row2["Question"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                        ControlCollection controlCollections = this.plhquantity.Controls;
                        object[] objArray = new object[] { "<label id='lblQuestion_", num1, "' > ", this.objBase.SpecialDecode(this.OtherCostName), "<br/>", this.objBase.SpecialDecode(str3), "</label>" };
                        controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                        ControlCollection controls1 = this.plhquantity.Controls;
                        object[] objArray1 = new object[] { "<input id='txtQuestion_", num1, "' grpvalue='", empty1, "'  onkeyup='ForAdditional_Grouping(", num6, ",", num5, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num6, ",", num5, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                        controls1.Add(new LiteralControl(string.Concat(objArray1)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                        ControlCollection controlCollections1 = this.plhquantity.Controls;
                        object[] currencyinRequiredFormate = new object[] { "<br/><label id='lblPrice_", num1, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00 </label><label id='lblQuestionID_", num1, "' style='display:none'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num1, "'  style='display:none;'>", str2, " </label><label id='lblQuestionGroupID_", num1, "' style='display:none'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionSortOrderNo_", num1, "' style='display:none'>", num4, "</label>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        num1++;
                    }
                    else if (this.MainCalculationtype.ToLower() == "c")
                    {
                        if (num8 == 0)
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                            ControlCollection controls2 = this.plhquantity.Controls;
                            object[] objArray2 = new object[] { "<input id='chkMultiple_", num2, "' style='display:none' type='checkbox' title='", this.objBase.SpecialDecode(this.OtherCostName), "' onclick='javascript:Onchange_MultipleChoice(", num2, ");'/>" };
                            controls2.Add(new LiteralControl(string.Concat(objArray2)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            length = this.OtherCostName.Length;
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                            if (str1 != "1")
                            {
                                ControlCollection controlCollections2 = this.plhquantity.Controls;
                                object[] objArray3 = new object[] { "<label id='lblMatrixName_", num2, "' > ", this.objBase.SpecialDecode(this.OtherCostName), "</label>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(objArray3)));
                            }
                            else
                            {
                                ControlCollection controls3 = this.plhquantity.Controls;
                                object[] objArray4 = new object[] { "<label id='lblMatrixName_", num2, "' > ", this.objBase.SpecialDecode(this.OtherCostName), "</label><span style='color:Red;'> *</span>" };
                                controls3.Add(new LiteralControl(string.Concat(objArray4)));
                            }
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            if (length <= 80)
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                            }
                            length = 0;
                            DropDownList dropDownList2 = new DropDownList()
                            {
                                ID = string.Concat("ddlMultiple_", num2),
                                CssClass = "dropDownMultiple150",
                                Width = 300
                            };
                            AttributeCollection attributes = dropDownList2.Attributes;
                            object[] objArray5 = new object[] { "javascript:ForAdditional_Grouping(", num6, ",", num5, ");Tocall_mainFunc();" };
                            attributes.Add("onchange", string.Concat(objArray5));
                            dropDownList2.Attributes.Add("grpvalue", empty1);
                            dropDownList2.Attributes.Add("IsMandatory", str1);
                            this.MultipleChoice_DropDownBind(item1, dropDownList2, this.plhquantity, row2["CalculationType"].ToString(), "", 0);
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                            ControlCollection controlCollections3 = this.plhquantity.Controls;
                            object[] str4 = new object[] { "<label id='lblMultipleID_", num2, "' style='display:none'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num2, "' style='display:none'></label><label id='lblMultipleMarkup_", num2, "' style='display:none'></label><label id='lblMultiplePrice_", num2, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label><label id='lblMultipleGroupID_", num2, "' style='display:none'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleSortOrderNo_", num2, "' style='display:none;'>", num4, "</label>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(str4)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            num2++;
                            item_product_catalogue mainGroupAdditionalOptionCount = this;
                            mainGroupAdditionalOptionCount.MainGroupAdditionalOptionCount = mainGroupAdditionalOptionCount.MainGroupAdditionalOptionCount + (long)1;
                        }
                    }
                    else if (this.MainCalculationtype.ToLower() == "m" && num8 == 0)
                    {
                        row2["matrixType"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;width:100%;'>"));
                        ControlCollection controls4 = this.plhquantity.Controls;
                        object[] objArray6 = new object[] { "<div style='float:left;padding:0px 0px 0px 0px;width:90%;' ><label id='lblMatrixName_", num3, "' > ", this.objBase.SpecialDecode(this.OtherCostName), "</label>" };
                        controls4.Add(new LiteralControl(string.Concat(objArray6)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div></div></div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                        ControlCollection controlCollections4 = this.plhquantity.Controls;
                        object[] objArray7 = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;width:3%;'><input id='chkMatrix_", num3, "' style='display:block' type='checkbox' title='", this.objBase.SpecialDecode(this.OtherCostName), "' grpvalue=", empty1, " onclick='ForAdditional_Grouping(", num6, ",", num5, ");Tocall_mainFunc();'/></div>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(objArray7)));
                        if (row2["matrixType"].ToString().ToLower() != "pricebands")
                        {
                            DropDownList dropDownList3 = new DropDownList();
                            this.MultipleChoice_DropDownBind(item1, dropDownList3, this.plhquantity, "matrix", "", 0);
                            dropDownList3.ID = string.Concat("ddlMatrix_", num3);
                            dropDownList3.CssClass = "dropDownMultiple150";
                            dropDownList3.Width = 300;
                            dropDownList3.Style.Add("display", "none");
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'><div>"));
                        ControlCollection controls5 = this.plhquantity.Controls;
                        object[] str5 = new object[] { "<label id='lblMatrixID_", num3, "' style='display:none;'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num3, "' style='display:none;'>", row2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num3, "' style='display:none;'></label><label id='lblMatrixGroupID_", num3, "' style='display:none'>", row1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num3, "' style='display:none'>0.00</label><label id='lblMatrixSortOrderNo_", num3, "' style='display:none;'>", num4, "</label>" };
                        controls5.Add(new LiteralControl(string.Concat(str5)));
                        ControlCollection controlCollections5 = this.plhquantity.Controls;
                        object[] currencyinRequiredFormate1 = new object[] { "<label id='lblMatrixPrice_", num3, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label></div>" };
                        controlCollections5.Add(new LiteralControl(string.Concat(currencyinRequiredFormate1)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        num3++;
                    }
                    num8++;
                }
            }
            this.hid_QuestionLenght.Value = num1.ToString();
            this.hid_MultipleLenght.Value = num2.ToString();
            this.hid_MatrixLenght.Value = num3.ToString();
            if (num1 == 0 && num2 == 0 && num3 == 0)
            {
                this.Price_Area(this.CompanyID, this.plhquantity, "add", "no", new decimal(0), new decimal(0), new decimal(0), (long)0, "");
                return;
            }
            this.Price_Area(this.CompanyID, this.plhquantity, "add", "yes", new decimal(0), new decimal(0), new decimal(0), (long)0, "");
        }

        public void Product_catalogueDetails_Edit()
        {
            string[] secureSitePath;
            object[] roundOff;
            int num;
            IEnumerator enumerator;
            this.fp_artwork1.ID = "fp_artwork1";
            this.fp_artwork2.ID = "fp_artwork2";
            this.fp_artwork3.ID = "fp_artwork3";
            this.lblartwork1.ID = "lblartwork1";
            this.lblartwork2.ID = "lblartwork2";
            this.lblartwork3.ID = "lblartwork3";
            this.lblartwork1.Style.Add("display", "none");
            this.lblartwork2.Style.Add("display", "none");
            this.lblartwork3.Style.Add("display", "none");
            long num1 = Convert.ToInt64(this.hid_PriceCatalogueID.Value);
            this.hid_OldPriceCatalogueID.Value = num1.ToString();
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            long num5 = (long)0;
            string empty = string.Empty;
            int num6 = 0;
            foreach (DataRow row in OrderBasePage.productsDetails_Select(num1).Rows)
            {
                this.lblProductName.Text = this.objBase.SpecialDecode(this.ProductName);
                this.hid_matixType.Value = row["MatrixType"].ToString();
                this.artworkFile = row["ArtworkFile"].ToString();
                num6 = Convert.ToInt32(row["ArtworkCount"]);
                if (this.artworkFile.ToLower().Trim() == "n")
                {
                    this.artwork_div.Style.Add("display", "none");
                }
                if (Convert.ToInt32(row["ArtworkCount"].ToString()) == 1)
                {
                    this.fp_artwork2.Visible = false;
                    this.fp_artwork3.Visible = false;
                }
                else if (Convert.ToInt32(row["ArtworkCount"].ToString()) == 2)
                {
                    this.fp_artwork3.Visible = false;
                }
                if (Convert.ToBoolean(row["IsCumulativePricing"]))
                {
                    this.IsCumulative = true;
                }
                if (Convert.ToInt32(row["SoldInPacksOf"]) == 0)
                {
                    this.hdn_soldPackOV.Value = "1";
                }
                else
                {
                    this.hdn_soldPackOV.Value = row["SoldInPacksOf"].ToString();
                }
                this.hdnIsStockItem.Value = row["IsStockItem"].ToString().ToLower();
                this.hdnDrawStockFrom.Value = row["DrawStockFrom"].ToString().Trim().ToLower();
            }
            DataTable dataTable = OrderBasePage.Product_CatalogueQty_Select(num1);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.hid_qtyFromList.Value = string.Concat(this.hid_qtyFromList.Value, dataRow["FromQuantity"].ToString(), "µ");
                this.hid_qtyToList.Value = string.Concat(this.hid_qtyToList.Value, dataRow["ToQuantity"].ToString(), "µ");
                this.hid_CostExcMarkupList.Value = string.Concat(this.hid_CostExcMarkupList.Value, dataRow["Price"].ToString(), "µ");
                this.hid_MarkupList.Value = string.Concat(this.hid_MarkupList.Value, dataRow["Markup"].ToString(), "µ");
                this.hid_priceList.Value = string.Concat(this.hid_priceList.Value, dataRow["SellingPrice"].ToString(), "µ");
                this.hid_Maxquantity.Value = dataRow["ToQuantity"].ToString();
            }
            int num7 = 0;
            string str = "0";
            string str1 = "0";
            DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(this.OrderItemID);
            DataTable item = dataSet.Tables[0];
            DataTable item1 = dataSet.Tables[1];
            foreach (DataRow row1 in item.Rows)
            {
                num7 = Convert.ToInt32(row1["Quantity"]);
                str = row1["Height"].ToString();
                str1 = row1["Width"].ToString();
                this.hid_QuantityPrice.Value = row1["TotalMarkupPrice"].ToString();
                this.hid_QuantityPriceExcMarkup.Value = Convert.ToString(Convert.ToDecimal(row1["TotalMarkupPrice"]) - Convert.ToDecimal(row1["MainItemMarkupPrice"]));
                num2 = Convert.ToDecimal(row1["OrderItemTotalPrice"]);
                num3 = Convert.ToDecimal(row1["OrderItemTax"]);
                num4 = Convert.ToDecimal(row1["Tax"]);
                num5 = Convert.ToInt64(row1["TaxID"]);
                empty = this.objBase.SpecialDecode(row1["TaxName"].ToString());
                if (row1["ManageID"].ToString() != "")
                {
                    this.IsCampaignSelected = Convert.ToInt64(row1["ManageID"]);
                }
                this.txtJobName.Text = this.objBase.SpecialDecode(row1["JobName"].ToString());
                item_product_catalogue.AccountID = Convert.ToInt64(row1["AccountID"]);
                if (this.artworkFile.ToLower().Trim() == "n")
                {
                    continue;
                }
                if (num6 == 2)
                {
                    this.fp_artwork2.Style.Add("display", "block");
                }
                else if (num6 == 3)
                {
                    this.fp_artwork3.Style.Add("display", "block");
                }
                if (row1["UploadFile"].ToString() != "")
                {
                    this.fp_artwork1.Style.Add("display", "none");
                    this.fp_artwork1.CssClass = "fp_artwork";
                    this.lblartwork1.Style.Add("display", "block");
                    this.lblartwork1.CssClass = "Normaltext";
                    this.hid_artwork1.Value = row1["UploadFile"].ToString();
                    Label label = this.lblartwork1;
                    secureSitePath = new string[] { "<a href=", this.SecureSitePath, this.ServerName, "//store//", row1["AccountID"].ToString(), "//artwork//", row1["UploadFile"].ToString(), " target='_blank'>", row1["UploadFile"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/close.gif' onclick='RemoveImage(1);' title='Close'>" };
                    label.Text = string.Concat(secureSitePath);
                }
                if (row1["UploadFile1"].ToString() != "")
                {
                    this.hid_artwork2.Value = row1["UploadFile1"].ToString();
                    this.fp_artwork2.Style.Add("display", "none");
                    this.fp_artwork2.CssClass = "fp_artwork";
                    this.lblartwork2.Style.Add("display", "block");
                    Label label1 = this.lblartwork2;
                    secureSitePath = new string[] { "<a href=", this.SecureSitePath, this.ServerName, "//store//", row1["AccountID"].ToString(), "//artwork//", row1["UploadFile1"].ToString(), " target='_blank'>", row1["UploadFile1"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/close.gif' onclick='RemoveImage(2);' title='Close'>" };
                    label1.Text = string.Concat(secureSitePath);
                    this.lblartwork2.CssClass = "Normaltext";
                }
                if (row1["UploadFile2"].ToString() == "")
                {
                    continue;
                }
                this.hid_artwork3.Value = row1["UploadFile2"].ToString();
                this.fp_artwork3.Style.Add("display", "none");
                this.fp_artwork3.CssClass = "fp_artwork";
                this.lblartwork3.Style.Add("display", "block");
                Label label2 = this.lblartwork3;
                secureSitePath = new string[] { "<a href=", this.SecureSitePath, this.ServerName, "//store//", row1["AccountID"].ToString(), "//artwork//", row1["UploadFile2"].ToString(), " target='_blank'>", row1["UploadFile2"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/close.gif' onclick='RemoveImage(3);' title='Close'>" };
                label2.Text = string.Concat(secureSitePath);
                this.lblartwork3.CssClass = "Normaltext";
            }
            this.plhquantity.Controls.Add(new LiteralControl("<div >"));
            if (this.hid_matixType.Value == "P")
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label >", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div  class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<input value='", num7, "' id='txtqty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);' maxlength='8'/>")));
            }
            else if (this.hid_matixType.Value == "G")
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label >", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div  class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<input value='", num7, "' id='txtqty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:Tocalculate_totalPrice(this.value);' onkeyup='javascript:Tocalculate_totalPrice(this.value);' maxlength='8'/>")));
            }
            else if (!this.IsCumulative)
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Select_Quantity_to_Order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin:0px 0px 0px 5px'>"));
                DropDownList dropDownList = new DropDownList()
                {
                    ID = "ddlPriceQty",
                    CssClass = "dropDownMultiple75"
                };
                dropDownList.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');");
                dropDownList.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                this.SimpleMatrix_DropDownBind(dataTable, dropDownList, this.plhquantity, "edit", num7);
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Enter_quantity_to_order"), " </label></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<input value='", num7, "' id='txt_Cumulative_PriceQty' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript: CheckIsDecimal_Textbox(this,this.value);Tocalculate_totalPrice(this.value);' onkeyup='javascript: CheckIsDecimal_Textbox(this,this.value);Tocalculate_totalPrice(this.value);' maxlength='8'/>")));
                DropDownList dropDownList1 = new DropDownList()
                {
                    ID = "ddlPriceQty",
                    CssClass = "dropDownMultiple75"
                };
                dropDownList1.Attributes.Add("onchange", "javascript:Tocalculate_totalPrice('0');");
                dropDownList1.Attributes.Add("onmouseout", "javascript:Tocalculate_totalPrice('0');");
                dropDownList1.Style.Add("display", "none");
                this.SimpleMatrix_DropDownBind(dataTable, dropDownList1, this.plhquantity, "edit", num7);
            }
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_qty' class='spanerrorMsg' style='display:none;margin-top: -26px;margin-left: 75px;width: auto;'><span id='spnQty'>", this.objLanguage.GetLanguageConversion("Please_Enter_quantity"), "</span></div>")));
            if (this.hid_matixType.Value == "G")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<div >"));
                ControlCollection controls = this.plhquantity.Controls;
                secureSitePath = new string[] { "<div style='float:left;' id='qty_div' class='price_table_content_left bglabel'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></div>" };
                controls.Add(new LiteralControl(string.Concat(secureSitePath)));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding-left:5px;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divWeight' style='font-size:11px;padding:2px 5px 0px 0px;'><span>", this.objLanguage.GetLanguageConversion("Width"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                ControlCollection controlCollections = this.plhquantity.Controls;
                roundOff = new object[] { "<input value='", str1, "' id='txtWidth' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' maxlength='8'/>" };
                controlCollections.Add(new LiteralControl(string.Concat(roundOff)));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding-left:5px;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='divHeight' style='font-size:11px;padding:2px 5px 0px 10px;'><span>", this.objLanguage.GetLanguageConversion("Height"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                ControlCollection controls1 = this.plhquantity.Controls;
                roundOff = new object[] { "<input value='", str, "' id='txtHeight' type='text' style='margin:0px 5px 0px 0px' class='txtStyle' onblur='javascript:roundUp(this.id,this.value,", this.RoundOff, "); Tocalculate_totalPrice(this.id);' maxlength='8'/>" };
                controls1.Add(new LiteralControl(string.Concat(roundOff)));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='spn_Dimensn' class='spanerrorMsg' style='display:none;width: auto;margin-top: -1px;'><span id='spnDimensn'>", this.objLanguage.GetLanguageConversion("Please_enter_dimension"), " </span></div>")));
                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            }
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int length = 0;
            int num11 = 0;
            int freeTextQuestionCount = 0;
            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            foreach (DataRow dataRow1 in OrderBasePage.Select_OtherCostAdditional_ItemsIDs(num1).Rows)
            {
                int num12 = 0;
                int num13 = 0;
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                string str2 = string.Empty;
                DataSet dataSet1 = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataRow1["WebOtherCostID"].ToString()));
                DataTable dataTable1 = dataSet1.Tables[0];
                DataTable item2 = dataSet1.Tables[1];
                long num18 = Convert.ToInt64(dataRow1["WebOtherCostID"].ToString());
                long num19 = Convert.ToInt64(dataRow1["AdditionalGroupID"].ToString());
                num11++;
                string str3 = "0";
                string empty3 = string.Empty;
                foreach (DataRow row2 in dataTable1.Rows)
                {
                    this.MainCalculationtype = row2["MainCalculationType"].ToString();
                    if (this.MainCalculationtype.ToLower() == "c")
                    {
                        num = Convert.ToInt32(row2["IsCartmandatory"]);
                        empty3 = num.ToString();
                    }
                    row2["Description"].ToString().Replace("\n", "<br>");
                    this.OtherCostName = this.objBase.SpecialDecode(row2["UserFriendlyName"].ToString());
                    try
                    {
                        this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                    }
                    catch
                    {
                    }
                }
                int num20 = 0;
                if (num19 == (long)0)
                {
                    str3 = "1";
                }
                else if (empty1 == "")
                {
                    str3 = "1";
                }
                else
                {
                    string[] strArrays = empty1.Split(new char[] { '±' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (strArrays[i] == "")
                        {
                            str3 = "1";
                        }
                        else
                        {
                            str3 = (num19 == (long)0 || Convert.ToInt64(strArrays[i]) != num19 ? "1" : "0");
                        }
                    }
                }
                empty1 = string.Concat(empty1, dataRow1["AdditionalGroupID"].ToString(), "±");
                foreach (DataRow dataRow2 in item2.Rows)
                {
                    if (this.MainCalculationtype.ToLower() == "q")
                    {
                        string str4 = dataRow2["formula"].ToString();
                        string str5 = dataRow2["Question"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                        ControlCollection controlCollections1 = this.plhquantity.Controls;
                        roundOff = new object[] { "<label id='lblQuestion_", num8, "' > ", this.objBase.SpecialDecode(this.OtherCostName), "<br/>", str5, "</label>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(roundOff)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        foreach (DataRow row3 in item1.Rows)
                        {
                            if (Convert.ToInt32(row3["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                continue;
                            }
                            num12 = Convert.ToInt32(row3["OptionID"]);
                            num13 = Convert.ToInt32(row3["SelectedID"]);
                            num14 = Convert.ToDecimal(row3["MarkupValue"]);
                            num15 = Convert.ToDecimal(row3["TotalPrice"]);
                            str2 = row3["SelectedValue"].ToString();
                            num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                            num17 = Convert.ToDecimal(row3["Markup"]);
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' >"));
                        if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            if (num19 != (long)0)
                            {
                                str3 = "0";
                            }
                            ControlCollection controls2 = this.plhquantity.Controls;
                            roundOff = new object[] { "<input id='txtQuestion_", num8, "' grpvalue='", str3, "'  onkeyup='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                            controls2.Add(new LiteralControl(string.Concat(roundOff)));
                        }
                        else
                        {
                            str3 = "1";
                            ControlCollection controlCollections2 = this.plhquantity.Controls;
                            roundOff = new object[] { "<input value='", str2, "' id='txtQuestion_", num8, "' grpvalue='", str3, "'  onkeyup='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                            controlCollections2.Add(new LiteralControl(string.Concat(roundOff)));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                        ControlCollection controls3 = this.plhquantity.Controls;
                        roundOff = new object[] { "<br/><label id='lblPrice_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), " </label><label id='lblQuestionID_", num8, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num8, "'  style='display:none;'>", str4, " </label><label id='lblQuestionGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num8, "' style='display:none'>", num14, "</label><label id='lblQuestionSortOrderNo_", num8, "' style='display:none'>", num11, "</label>" };
                        controls3.Add(new LiteralControl(string.Concat(roundOff)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        num8++;
                    }

                    //if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                    //{
                    //    string str4 = dataRow2["formula"].ToString();
                    //    string str5 = dataRow2["Question"].ToString();
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                    //    ControlCollection controlCollections1 = this.plhquantity.Controls;
                    //    roundOff = new object[] { "<label id='lblFreeTextQuestion_", freeTextQuestionCount, "' > " , str5, "</label>" };
                    //    controlCollections1.Add(new LiteralControl(string.Concat(roundOff)));
                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    //    foreach (DataRow row3 in item1.Rows)
                    //    {
                    //        if (Convert.ToInt32(row3["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                    //        {
                    //            continue;
                    //        }
                    //        num12 = Convert.ToInt32(row3["OptionID"]);
                    //        num13 = Convert.ToInt32(row3["SelectedID"]);
                    //        num14 = Convert.ToDecimal(row3["MarkupValue"]);
                    //        num15 = Convert.ToDecimal(row3["TotalPrice"]);
                    //        str2 = row3["SelectedValue"].ToString();
                    //        num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                    //        num17 = Convert.ToDecimal(row3["Markup"]);
                    //    }
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' >"));
                    //    if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                    //    {
                    //        if (num19 != (long)0)
                    //        {
                    //            str3 = "0";
                    //        }
                    //        ControlCollection controls2 = this.plhquantity.Controls;
                    //        roundOff = new object[] { "<input id='txtFreeTextQuestion_", freeTextQuestionCount, "' grpvalue='", str3, "'  onkeyup='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                    //        controls2.Add(new LiteralControl(string.Concat(roundOff)));
                    //    }
                    //    else
                    //    {
                    //        str3 = "1";
                    //        ControlCollection controlCollections2 = this.plhquantity.Controls;
                    //        roundOff = new object[] { "<input value='", str2, "' id='txtFreeTextQuestion_", freeTextQuestionCount, "' grpvalue='", str3, "'  onkeyup='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' onblur='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                    //        controlCollections2.Add(new LiteralControl(string.Concat(roundOff)));
                    //    }
                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                    //    ControlCollection controls3 = this.plhquantity.Controls;
                    //    roundOff = new object[] { "<br/><label id='lblFreeTextPrice_", freeTextQuestionCount, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", freeTextQuestionCount, "'  style='display:none;'>", str4, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num14, "</label><label id='lblQuestionSortOrderNo_", num8, "' style='display:none'>", num11, "</label>" };
                    //    controls3.Add(new LiteralControl(string.Concat(roundOff)));
                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    //    freeTextQuestionCount++;
                    //}



                    if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                    {
                        string str4 = dataRow2["formula"].ToString();
                        string str5 = dataRow2["Question"].ToString();

                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:53px;'>"));

                        ControlCollection controlCollections1 = this.plhquantity.Controls;
                        roundOff = new object[] { "<label id='lblFreeTextQuestion_", freeTextQuestionCount, "'>", str5, "</label>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(roundOff)));

                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                        foreach (DataRow row3 in item1.Rows)
                        {
                            if (Convert.ToInt32(row3["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                continue;
                            }
                            num12 = Convert.ToInt32(row3["OptionID"]);
                            num13 = Convert.ToInt32(row3["SelectedID"]);
                            num14 = Convert.ToDecimal(row3["MarkupValue"]);
                            num15 = Convert.ToDecimal(row3["TotalPrice"]);
                            //str2 = row3["SelectedValue"].ToString();
                            if (this.MainCalculationtype.ToLower() == "l")
                            {
                                str2 = row3["FreeTextQuestionLong"].ToString();
                            }
                            else
                            {
                                str2 = row3["SelectedValue"].ToString();
                            }
                            num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                            num17 = Convert.ToDecimal(row3["Markup"]);
                        }

                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));

                        if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            if (num19 != (long)0)
                            {
                                str3 = "0";
                            }

                            ControlCollection controls2 = this.plhquantity.Controls;

                            roundOff = new object[]
                            {
                                "<textarea id='txtFreeTextQuestion_", freeTextQuestionCount,
                                "' grpvalue='", str3,
                                "' onkeyup='ForAdditional_Grouping(", num19, ",", num18,
                                ");Tocall_mainFunc();UpdateCount(this,", freeTextQuestionCount, ");' onblur='ForAdditional_Grouping(", num19, ",", num18,
                                ");Tocall_mainFunc();UpdateCount(this,", freeTextQuestionCount, ");' onfocus='UpdateCount(this,", freeTextQuestionCount, ");' class='txtStyle' rows='2' style='width:92%;height:48px;text-align:left;resize:vertical;'></textarea><span id='cnt_txtFreeTextQuestion_", freeTextQuestionCount, "' class='charCount'></span><input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", freeTextQuestionCount,
                "' value='", this.MainCalculationtype.ToLower() , "'/>"
                            };

                            controls2.Add(new LiteralControl(string.Concat(roundOff)));
                        }
                        else
                        {
                            str3 = "1";

                            ControlCollection controls2 = this.plhquantity.Controls;

                            roundOff = new object[]
                            {
                                "<textarea id='txtFreeTextQuestion_", freeTextQuestionCount,
                                "' grpvalue='", str3,
                                "' onkeyup='ForAdditional_Grouping(", num19, ",", num18,
                                ");Tocall_mainFunc();UpdateCount(this,", freeTextQuestionCount, ");' onblur='ForAdditional_Grouping(", num19, ",", num18,
                                ");Tocall_mainFunc();UpdateCount(this,", freeTextQuestionCount, ");' onfocus='UpdateCount(this,", freeTextQuestionCount, ");' class='txtStyle' rows='2' style='width:92%;height:48px;text-align:left;resize:vertical;'>",
                                str2,
                                "</textarea> <span id='cnt_txtFreeTextQuestion_", freeTextQuestionCount, "' class='charCount'></span> <input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", freeTextQuestionCount,
                "' value='", this.MainCalculationtype.ToLower() , "'/>"
                            };

                            controls2.Add(new LiteralControl(string.Concat(roundOff)));
                        }

                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                        // RIGHT SIDE PRICE & HIDDEN LABELS
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));

                        ControlCollection controls3 = this.plhquantity.Controls;

                        roundOff = new object[]
                        {
                            "<br/><label id='lblFreeTextPrice_", freeTextQuestionCount, "'>",
                            this.commclass.GetCurrencyinRequiredFormate("", true),
                            this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true),
                            "</label>",
                            "<label id='lblFreeTextQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label>",
                            "<label id='lblQuestionFormula_", freeTextQuestionCount, "' style='display:none'>", str4, "</label>",
                            "<label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label>",
                            "<label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num14, "</label>",
                            "<label id='lblQuestionSortOrderNo_", num8, "' style='display:none'>", num11, "</label>"
                        };

                        controls3.Add(new LiteralControl(string.Concat(roundOff)));

                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                        freeTextQuestionCount++;
                    }


                    else if (this.MainCalculationtype.ToLower() == "c")
                    {
                        if (num20 == 0)
                        {
                            if (dataRow2["CalculationType"].ToString().ToLower().Trim() != "groups")
                            {
                                foreach (DataRow dataRow3 in item1.Rows)
                                {
                                    if (Convert.ToInt32(dataRow3["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                    {
                                        continue;
                                    }
                                    if (Convert.ToInt32(dataRow3["IsStockAddType"]) == 1)
                                    {
                                        this.hdnStockAdditionalOption.Value = string.Concat(Convert.ToInt32(dataRow3["OptionID"]), "@", Convert.ToInt32(dataRow3["SelectedID"]));
                                    }
                                    num12 = Convert.ToInt32(dataRow3["OptionID"]);
                                    num13 = Convert.ToInt32(dataRow3["SelectedID"]);
                                    num14 = Convert.ToDecimal(dataRow3["MarkupValue"]);
                                    num15 = Convert.ToDecimal(dataRow3["TotalPrice"]);
                                    str2 = dataRow3["SelectedValue"].ToString();
                                    num16 = Convert.ToDecimal(dataRow3["SelectedPrice"]);
                                    num17 = Convert.ToDecimal(dataRow3["Markup"]);
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections3 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controlCollections3.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls4 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controls4.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                length = this.OtherCostName.Length;
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                                if (empty3 != "1")
                                {
                                    ControlCollection controlCollections4 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "' > ", this.OtherCostName, "</label>" };
                                    controlCollections4.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls5 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "' > ", this.OtherCostName, "<span style='color:Red;'> *</span></label>" };
                                    controls5.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                if (length <= 80)
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                }
                                else
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin: 0px 0px 0px 15px;'>"));
                                }
                                length = 0;
                                DropDownList dropDownList2 = new DropDownList()
                                {
                                    ID = string.Concat("ddlMultiple_", num9),
                                    CssClass = "dropDownMultiple150",
                                    Width = 300
                                };
                                AttributeCollection attributes = dropDownList2.Attributes;
                                roundOff = new object[] { "javascript:ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();" };
                                attributes.Add("onchange", string.Concat(roundOff));
                                dropDownList2.Attributes.Add("IsMandatory", empty3);
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    if (num19 != (long)0)
                                    {
                                        str3 = "0";
                                    }
                                    ControlCollection controlCollections5 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    str3 = "1";
                                    ControlCollection controls6 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controls6.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                dropDownList2.Attributes.Add("grpvalue", str3);
                                this.MultipleChoice_DropDownBind(item2, dropDownList2, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num13);
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections6 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label><label id='lblMultipleGroupID_", num9, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "' style='display:none'>", num14, "</label><label id='lblMultipleSortOrderNo_", num9, "' style='display:none;'>", num11, "</label>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls7 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num9, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "' style='display:none'>", num14, "</label><label id='lblMultipleSortOrderNo_", num9, "' style='display:none;'>", num11, "</label>" };
                                    controls7.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div><br/>"));
                            }
                            else
                            {
                                string empty4 = string.Empty;
                                DataTable dataTable2 = new DataTable();
                                DataSet dataSet2 = new DataSet();
                                DataTable dataTable3 = new DataTable();
                                DataTable item3 = new DataTable();
                                foreach (DataRow row4 in item1.Rows)
                                {
                                    if (Convert.ToInt32(row4["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                    {
                                        continue;
                                    }
                                    if (Convert.ToInt32(row4["IsStockAddType"]) == 1)
                                    {
                                        this.hdnStockAdditionalOption.Value = string.Concat(Convert.ToInt32(row4["OptionID"]), "@", Convert.ToInt32(row4["SelectedID"]));
                                    }
                                    if(Convert.ToInt32(row4["SelectedID"]) > 0)
                                    {
                                        num12 = Convert.ToInt32(row4["OptionID"]);
                                        num13 = Convert.ToInt32(row4["SelectedID"]);
                                        num14 = Convert.ToDecimal(row4["MarkupValue"]);
                                        num15 = Convert.ToDecimal(row4["TotalPrice"]);
                                        str2 = row4["SelectedValue"].ToString();
                                        num16 = Convert.ToDecimal(row4["SelectedPrice"]);
                                        num17 = Convert.ToDecimal(row4["Markup"]);
                                    }
                               
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections7 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls8 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controls8.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                length = this.OtherCostName.Length;
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                                if (empty3 != "1")
                                {
                                    ControlCollection controlCollections8 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "' > ", this.OtherCostName, "</label>" };
                                    controlCollections8.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls9 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "' > ", this.OtherCostName, "<span style='color:Red;'> *</span></label>" };
                                    controls9.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                if (length <= 80)
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                }
                                else
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin: 0px 0px 0px 15px;'>"));
                                }
                                length = 0;
                                DropDownList dropDownList3 = new DropDownList()
                                {
                                    ID = string.Concat("ddlMultiple_", num9),
                                    CssClass = "dropDownMultiple150",
                                    Width = 300
                                };
                                dropDownList3.Attributes.Add("onchange", string.Concat("javascript:VisibleAdditionaloption_ForOrder('", dataRow1["WebOtherCostID"].ToString(), "');Tocall_mainFunc();"));
                                dropDownList3.Attributes.Add("isgroup", "maingroup");
                                dropDownList3.Attributes.Add("IsMandatory", empty3);
                                dropDownList3.Attributes.Add("WeotherCostID", dataRow1["WebOtherCostID"].ToString());
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    if (num19 != (long)0)
                                    {
                                        str3 = "0";
                                    }
                                    ControlCollection controlCollections9 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controlCollections9.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    str3 = "1";
                                    ControlCollection controls10 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<input id='chkMultiple_", num9, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num9, ");'/>" };
                                    controls10.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                dropDownList3.Attributes.Add("grpvalue", str3);
                                this.MultipleChoice_DropDownBind(item2, dropDownList3, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num13);
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections10 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label><label id='lblMultipleGroupID_", num9, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "' style='display:none'>", num14, "</label><label id='lblMultipleSortOrderNo_", num9, "' style='display:none;'>", num11, "</label>" };
                                    controlCollections10.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                else
                                {
                                    ControlCollection controls11 = this.plhquantity.Controls;
                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num9, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "' style='display:none'>", num14, "</label><label id='lblMultipleSortOrderNo_", num9, "' style='display:none;'>", num11, "</label>" };
                                    controls11.Add(new LiteralControl(string.Concat(roundOff)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div><br/>"));
                                for (int j = 0; j < item2.Rows.Count; j++)
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='display:none;' id='div_SubAdditionalsddl_", Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), "'>")));
                                    dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(item2.Rows[j]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                    if (dataTable2.Rows.Count > 0 && Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) != (long)0)
                                    {
                                        int pIndex = 0;
                                        for (int k = 0; k < dataTable2.Rows.Count; k++)
                                        {
                                            num11++;
                                            dataSet2 = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataTable2.Rows[k]["WebOtherCostID"].ToString()));
                                            dataTable3 = dataSet2.Tables[0];
                                            item3 = dataSet2.Tables[1];
                                            enumerator = dataTable3.Rows.GetEnumerator();
                                            try
                                            {
                                                if (enumerator.MoveNext())
                                                {
                                                    DataRow current = (DataRow)enumerator.Current;
                                                    num = Convert.ToInt32(current["IsCartmandatory"]);
                                                    empty4 = num.ToString();
                                                }
                                            }
                                            finally
                                            {
                                                IDisposable disposable = enumerator as IDisposable;
                                                if (disposable != null)
                                                {
                                                    disposable.Dispose();
                                                }
                                            }

                                            if (dataTable3.Rows[0]["MainCalculationType"].ToString() == "f" || dataTable3.Rows[0]["MainCalculationType"].ToString() == "l")
                                            {
                                                string str4 = item3.Rows[0]["formula"].ToString();
                                                string str5 = item3.Rows[0]["Question"].ToString();

                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:53px;'>"));

                                                ControlCollection controlCollections1 = this.plhquantity.Controls;
                                                roundOff = new object[] { "<label id='lblFreeTextQuestion_", freeTextQuestionCount, "'>", str5, "</label>" };
                                                controlCollections1.Add(new LiteralControl(string.Concat(roundOff)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                                int parentId = Convert.ToInt32(dataRow1["WebOtherCostID"]);

                                                var filteredRows = item1.AsEnumerable()
                                                    .Where(r => Convert.ToInt32(r["OptionID"]) == parentId &&
                                                                Convert.ToInt32(r["SelectedID"]) == 0);

                                                DataTable childTable = new DataTable() ;

                                                if (filteredRows.Any())
                                                {
                                                    childTable = filteredRows.CopyToDataTable();
                                                }
                                                else
                                                {
                                                    childTable = item1.Clone(); // create an empty table with same structure
                                                }
                                                //foreach (DataRow row3 in childTable.Rows[pIndex])
                                                //{
                                                //    //if (Convert.ToInt32(row3["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                                //    //{
                                                //    //    continue;
                                                //    //}
                                                //    num12 = Convert.ToInt32(row3["OptionID"]);
                                                //    num13 = Convert.ToInt32(row3["SelectedID"]);
                                                //    num14 = Convert.ToDecimal(row3["MarkupValue"]);
                                                //    num15 = Convert.ToDecimal(row3["TotalPrice"]);
                                                //    str2 = row3["SelectedValue"].ToString();
                                                //    num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                                                //    num17 = Convert.ToDecimal(row3["Markup"]);
                                                //    pIndex++;
                                                //    break;

                                                //}
                                                if (pIndex < childTable.Rows.Count)
                                                {
                                                    DataRow row3 = childTable.Rows[pIndex];

                                                    // Now use row3
                                                    num12 = Convert.ToInt32(row3["OptionID"]);
                                                    num13 = Convert.ToInt32(row3["SelectedID"]);
                                                    num14 = Convert.ToDecimal(row3["MarkupValue"]);
                                                    num15 = Convert.ToDecimal(row3["TotalPrice"]);
                                                    if(dataTable3.Rows[0]["MainCalculationType"].ToString() == "l")
                                                    {
                                                        str2 = row3["FreeTextQuestionLong"].ToString();
                                                    }
                                                    else
                                                    {
                                                        str2 = row3["SelectedValue"].ToString();
                                                    }
                                                    num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                                                    num17 = Convert.ToDecimal(row3["Markup"]);
                                                    pIndex++;
                                                }

                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));

                                                str3 = "1";

                                                ControlCollection controls2 = this.plhquantity.Controls;

                                                roundOff = new object[]
                                                {
                                                        "<textarea id='txtFreeTextQuestion_", freeTextQuestionCount,
                                                        "' grpvalue='", str3,
                                                        "' onkeyup='UpdateCount(this,", freeTextQuestionCount, ");' onblur='UpdateCount(this,", freeTextQuestionCount, ");' onfocus='UpdateCount(this,", freeTextQuestionCount, ");'  class='txtStyle' rows='2' style='width:92%;height:48px;text-align:left;resize:vertical;'>",
                                                        str2,
                                                        "</textarea> <span id='cnt_txtFreeTextQuestion_", freeTextQuestionCount, "' class='charCount'></span> <input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", freeTextQuestionCount,
                                                        "' value='", dataTable3.Rows[0]["MainCalculationType"].ToString() , "'/> <label id='lblFreeTextQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label>"
                                                };

                                                controls2.Add(new LiteralControl(string.Concat(roundOff)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                                                // RIGHT SIDE PRICE & HIDDEN LABELS
                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));

                                                ControlCollection controls3 = this.plhquantity.Controls;

                                                roundOff = new object[]
                                                {
                                                    "<br/><label id='lblFreeTextPrice_", freeTextQuestionCount, "'>",
                                                    this.commclass.GetCurrencyinRequiredFormate("", true),
                                                    this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true),
                                                    "</label>",
                                                    "<label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label>",
                                                    //"<label id='lblQuestionFormula_", freeTextQuestionCount, "' style='display:none'>", str4, "</label>",
                                                    //"<label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label>",
                                                    //"<label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num14, "</label>",
                                                    //"<label id='lblQuestionSortOrderNo_", num8, "' style='display:none'>", num11, "</label>"
                                                };

                                                controls3.Add(new LiteralControl(string.Concat(roundOff)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                                                freeTextQuestionCount++;
                                            }
                                            else
                                            {
                                                foreach (DataRow dataRow4 in item1.Rows)
                                                {
                                                    if (Convert.ToInt32(dataRow4["OptionID"].ToString()) != Convert.ToInt32(dataTable2.Rows[k]["WebOtherCostID"].ToString()))
                                                    {
                                                        continue;
                                                    }
                                                    num12 = Convert.ToInt32(dataRow4["OptionID"]);
                                                    num13 = Convert.ToInt32(dataRow4["SelectedID"]);
                                                    num14 = Convert.ToDecimal(dataRow4["MarkupValue"]);
                                                    num15 = Convert.ToDecimal(dataRow4["TotalPrice"]);
                                                    str2 = dataRow4["SelectedValue"].ToString();
                                                    num16 = Convert.ToDecimal(dataRow4["SelectedPrice"]);
                                                    num17 = Convert.ToDecimal(dataRow4["Markup"]);
                                                }
                                                length = dataTable3.Rows[0]["UserFriendlyName"].ToString().Replace("\n", "<br>").Length;
                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                                                if (empty4 != "1")
                                                {
                                                    ControlCollection controlCollections11 = this.plhquantity.Controls;
                                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", dataTable3.Rows[0]["UserFriendlyName"].ToString().Replace("\n", "<br>"), "</label>" };
                                                    controlCollections11.Add(new LiteralControl(string.Concat(roundOff)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls12 = this.plhquantity.Controls;
                                                    roundOff = new object[] { "<label id='lblMatrixName_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' > ", dataTable3.Rows[0]["UserFriendlyName"].ToString().Replace("\n", "<br>"), "</span><span style='color:Red;'> *</span></label>" };
                                                    controls12.Add(new LiteralControl(string.Concat(roundOff)));
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                                if (length <= 80)
                                                {
                                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                                                }
                                                else
                                                {
                                                    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin: 0px 0px 0px 15px;'>"));
                                                }
                                                length = 0;
                                                DropDownList dropDownList4 = new DropDownList();
                                                roundOff = new object[] { "ddlMultiple_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k };
                                                dropDownList4.ID = string.Concat(roundOff);
                                                dropDownList4.CssClass = "dropDownMultiple150";
                                                dropDownList4.Width = 300;
                                                dropDownList4.Attributes.Add("onchange", "Tocall_mainFunc();");
                                                dropDownList4.Attributes.Add("grpvalue", str3);
                                                dropDownList4.Attributes.Add("isgroup", "subgroup");
                                                dropDownList4.Attributes.Add("IsMandatory", empty4);
                                                dropDownList4.Attributes.Add("WeotherCostID", dataTable2.Rows[k]["WebOtherCostID"].ToString());
                                                this.MultipleChoice_DropDownBind(item3, dropDownList4, this.plhquantity, item3.Rows[0]["CalculationType"].ToString(), "edit", num13);
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
                                                if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                                {
                                                    ControlCollection controlCollections12 = this.plhquantity.Controls;
                                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", dataTable2.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label><label id='lblMultipleGroupID_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", Convert.ToInt32(num14), "</label><label id='lblMultipleSortOrderNo_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none;'>", num11, "</label>" };
                                                    controlCollections12.Add(new LiteralControl(string.Concat(roundOff)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls13 = this.plhquantity.Controls;
                                                    roundOff = new object[] { "<label id='lblMultipleID_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", dataTable2.Rows[k]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'></label><label id='lblMultipleMarkup_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'></label><label id='lblMultiplePrice_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToInt32(num15), 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none'>", Convert.ToInt32(num14), "</label><label id='lblMultipleSortOrderNo_", num9, "_", item2.Rows[j]["SelectedID"].ToString(), "_", k, "' style='display:none;'>", num11, "</label>" };
                                                    controls13.Add(new LiteralControl(string.Concat(roundOff)));
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div><br/>"));
                                            }


                                            
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            num9++;
                        }
                    }


                    else if (this.MainCalculationtype.ToLower() == "m" && num20 == 0)
                    {
                        dataRow2["matrixType"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;width:100%;'>"));
                        foreach (DataRow row5 in item1.Rows)
                        {
                            if (Convert.ToInt32(row5["OptionID"]) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                continue;
                            }
                            num12 = Convert.ToInt32(row5["OptionID"]);
                            num13 = Convert.ToInt32(row5["SelectedID"]);
                            num14 = Convert.ToDecimal(row5["MarkupValue"]);
                            num15 = Convert.ToDecimal(row5["TotalPrice"]);
                            str2 = row5["SelectedValue"].ToString();
                            num16 = Convert.ToDecimal(row5["SelectedPrice"]);
                            num17 = Convert.ToDecimal(row5["Markup"]);
                        }
                        ControlCollection controlCollections13 = this.plhquantity.Controls;
                        roundOff = new object[] { "<div style='float:left;padding:0px 0px 0px 0px;width:90%;' ><label id='lblMatrixName_", num10, "' > ", this.OtherCostName, "</label>" };
                        controlCollections13.Add(new LiteralControl(string.Concat(roundOff)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div></div></div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
                        string empty5 = string.Empty;
                        if (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            if (num19 != (long)0)
                            {
                                str3 = "0";
                            }
                            ControlCollection controls14 = this.plhquantity.Controls;
                            roundOff = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;width:3%;'><input id='chkMatrix_", num10, "' style='display:block' type='checkbox' title='", this.OtherCostName, "' grpvalue=", str3, " onclick='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();'/></div>" };
                            controls14.Add(new LiteralControl(string.Concat(roundOff)));
                        }
                        else
                        {
                            str3 = "1";
                            roundOff = new object[] { num16, "~", num17, "~", num13, "~", num7 };
                            empty5 = string.Concat(roundOff);
                            ControlCollection controlCollections14 = this.plhquantity.Controls;
                            roundOff = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;width:3%;'><input id='chkMatrix_", num10, "' style='display:block' type='checkbox' checked='checked' title='", this.OtherCostName, "' grpvalue=", str3, " onclick='ForAdditional_Grouping(", num19, ",", num18, ");Tocall_mainFunc();'/></div>" };
                            controlCollections14.Add(new LiteralControl(string.Concat(roundOff)));
                        }
                        if (dataRow2["matrixType"].ToString().ToLower() != "pricebands")
                        {
                            DropDownList dropDownList5 = new DropDownList();
                            this.MultipleChoice_DropDownBind(item2, dropDownList5, this.plhquantity, "matrix", "edit", num13);
                            dropDownList5.ID = string.Concat("ddlMatrix_", num10);
                            dropDownList5.CssClass = "dropDownMultiple150";
                            dropDownList5.Width = 300;
                            dropDownList5.Style.Add("display", "none");
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'><div>"));
                        ControlCollection controls15 = this.plhquantity.Controls;
                        roundOff = new object[] { "<label id='lblMatrixID_", num10, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num10, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num10, "' style='display:none;'>", empty5, "</label><label id='lblMatrixGroupID_", num10, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num10, "' style='display:none'>", num14, "</label><label id='lblMatrixSortOrderNo_", num10, "' style='display:none;'>", num11, "</label>" };
                        controls15.Add(new LiteralControl(string.Concat(roundOff)));
                        ControlCollection controlCollections15 = this.plhquantity.Controls;
                        roundOff = new object[] { "<label id='lblMatrixPrice_", num10, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</label></div>" };
                        controlCollections15.Add(new LiteralControl(string.Concat(roundOff)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        num10++;
                    }
                    num20++;
                }
            }
            ////////////////////////////////////////Decoration Work By Amin//////////////////////////
            ///



            var dt = OrderBasePage.productsDetails_Select(num1);
            foreach (DataRow row in dt.Rows)
            {
                string decoration1Value = "No";
                string decoration2Value = "No";
                string decoration3Value = "No";
                string decoration4Value = "No";
                string decoration5Value = "No";
                string decoration6Value = "No";


                foreach (DataRow dtitem in item1.Rows)
                {
                    if (Convert.ToString( dtitem["WebOtherCostType"])== "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"])==101)
                    {
                        string[] strSelectedValue  = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration1Value = strSelectedValue[1];


                    }
                    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 102)
                    {
                        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration2Value = strSelectedValue[1];

                        
                    }
                    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 103)
                    {
                        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration3Value = strSelectedValue[1];

                       
                    }
                    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 104)
                    {
                        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration4Value = strSelectedValue[1];

                         
                    }
                    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 105)
                    {
                        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration5Value = strSelectedValue[1];

                       
                    }
                    if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 106)
                    {
                        string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                        decoration6Value = strSelectedValue[1];

                         
                    }


                }


                var name1 = row["Decoration1_Name"].ToString();
                var name2 = row["Decoration2_Name"].ToString();
                var name3 = row["Decoration3_Name"].ToString();
                var name4 = row["Decoration4_Name"].ToString();
                var name5 = row["Decoration5_Name"].ToString();
                var name6 = row["Decoration6_Name"].ToString();

                var Decoration1_Mandadory = Convert.ToBoolean(0);
                var Decoration2_Mandadory = Convert.ToBoolean(0);// Convert.ToBoolean(row["Decoration2_Mandadory"]);
                var Decoration3_Mandadory = Convert.ToBoolean(0);// Convert.ToBoolean(row["Decoration3_Mandadory"]);
                var Decoration4_Mandadory = Convert.ToBoolean(0);//Convert.ToBoolean(row["Decoration4_Mandadory"]);
                var Decoration5_Mandadory = Convert.ToBoolean(0);// Convert.ToBoolean(row["Decoration5_Mandadory"]);
                var Decoration6_Mandadory = Convert.ToBoolean(0);//Convert.ToBoolean(row["Decoration6_Mandadory"]);

                if (string.IsNullOrEmpty(name1) != true)
                {
                    hdnDecoration1.Value = Convert.ToDouble(row["Decoration1_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration1_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration1_MinimiumCost"]);
                    name1 = Decoration1_Mandadory ? name1 + "*" : name1;
                    if (Decoration1_Mandadory && decoration1Value=="No")
                    {
                        decoration1Value = "--select--";
                    }
                    AddDecorations(length, name1, 1, Decoration1_Mandadory, decoration1Value);
                }
                if (string.IsNullOrEmpty(name2) != true)
                {
                    if (Decoration2_Mandadory && decoration2Value == "No")
                    {
                        decoration2Value = "--select--";
                    }

                    name2 = Decoration2_Mandadory ? name2 + "*" : name2;
                    AddDecorations(length, name2, 2, Decoration2_Mandadory, decoration2Value);
                    hdnDecoration2.Value = Convert.ToDouble(row["Decoration2_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration2_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration2_MinimiumCost"]);
                }

                if (string.IsNullOrEmpty(name3) != true)
                {
                    if (Decoration3_Mandadory && decoration3Value == "No")
                    {
                        decoration3Value = "--select--";
                    }

                    name3 = Decoration3_Mandadory ? name3 + "*" : name3;
                    AddDecorations(length, name3, 3, Decoration3_Mandadory, decoration3Value);
                    hdnDecoration3.Value = Convert.ToDouble(row["Decoration3_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration3_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration3_MinimiumCost"]);
                }
                if (string.IsNullOrEmpty(name4) != true)
                {
                    if (Decoration4_Mandadory && decoration4Value == "No")
                    {
                        decoration4Value = "--select--";
                    }
                    name4 = Decoration4_Mandadory ? name4 + "*" : name4;
                    AddDecorations(length, name4, 4, Decoration4_Mandadory, decoration4Value);
                    hdnDecoration4.Value = Convert.ToDouble(row["Decoration4_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration4_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration4_MinimiumCost"]);
                }

                if (string.IsNullOrEmpty(name5) != true)
                {
                    if (Decoration5_Mandadory && decoration5Value == "No")
                    {
                        decoration5Value = "--select--";
                    }

                    name5 = Decoration5_Mandadory ? name5 + "*" : name5;
                    AddDecorations(length, name5, 5, Decoration5_Mandadory, decoration5Value);
                    hdnDecoration5.Value = Convert.ToDouble(row["Decoration5_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration5_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration5_MinimiumCost"]);
                }

                if (string.IsNullOrEmpty(name6) != true)
                {
                    if (Decoration6_Mandadory && decoration6Value == "No")
                    {
                        decoration6Value = "--select--";
                    }

                    name6 = Decoration6_Mandadory ? name6 + "*" : name6;
                    AddDecorations(length, name6, 6, Decoration6_Mandadory, decoration6Value);
                    hdnDecoration6.Value = Convert.ToDouble(row["Decoration6_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration6_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration6_MinimiumCost"]);
                }

            }



            ////////////////////////////////////////End Decoration by Amin//////////////////////////
            this.hid_QuestionLenght.Value = num8.ToString();
            this.hid_MultipleLenght.Value = num9.ToString();
            this.hid_MatrixLenght.Value = num10.ToString();
            this.hid_QuestionTextFreeLenght.Value = freeTextQuestionCount.ToString();
            if (num8 == 0 && num9 == 0 && num10 == 0)
            {
                this.Price_Area(this.CompanyID, this.plhquantity, "edit", "no", num2, num3, num4, num5, empty);
                return;
            }
            this.Price_Area(this.CompanyID, this.plhquantity, "edit", "yes", num2, num3, num4, num5, empty);
        }


        public string ReplaceAllBlankSpace(string OriginalString)
        {
            return OriginalString.Replace(" ", "_");
        }

        private void Select_Catalogue_Item()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            int num = 0;
            foreach (DataRow row in EstimateBasePage.price_catalogue_select_by_estimateitem_id(this.CompanyID, this.EstimateItemID).Rows)
            {
                row["ItemDescription"].ToString();
                stringBuilder.AppendFormat("PriceCatalogueID»{0}±", row["PriceCatalogueID"].ToString());
                stringBuilder.AppendFormat("CatalogueName»{0}±", row["ItemTitle"].ToString());
                stringBuilder.AppendFormat("Quantity»{0}±", row["Quantity"].ToString());
                double num1 = Convert.ToDouble(row["Price"]) + Convert.ToDouble(row["Markup"]) * Convert.ToDouble(row["Price"]) / 100;
                stringBuilder.AppendFormat("Price»{0}±", num1);
                stringBuilder.AppendFormat("Markup»{0}±", row["Markup"].ToString());
                stringBuilder.AppendFormat("Cost»{0}±", row["Price"].ToString());
                stringBuilder.AppendFormat("MultipleOf»{0}µ", row["MultipleOf"].ToString());
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    if (num == 0)
                    {
                        this.CatalogueProfit = row["ProfitMargin"].ToString();
                        this.CatalogueTax = row["Tax"].ToString();
                        str = row["TaxID"].ToString();
                    }
                    string[] strArrays = new string[] { ",", this.CatalogueProfit.ToString(), ",", row["SubTotal"].ToString(), ",", this.CatalogueTax.ToString(), ",", str.ToString() };
                    this.CatalogueProfitAndTax = string.Concat(strArrays);
                }
                else
                {
                    string[] str1 = new string[] { ",", row["ProfitMargin"].ToString(), ",", row["SubTotal"].ToString(), ",", row["Tax"].ToString(), ",", row["TaxID"].ToString() };
                    this.CatalogueProfitAndTax = string.Concat(str1);
                    this.CatalogueProfit = row["ProfitMargin"].ToString();
                    decimal num2 = EstimateBasePage.Estimate_Summary_TaxRate(this.CompanyID);
                    this.CatalogueTax = num2.ToString();
                }
                num++;
            }
            this.hidCatalogueDataOnEdit.Value = stringBuilder.ToString();
            this.pnlCatalogueOnEdit.Visible = true;
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix, PlaceHolder plhquantity, string ActionType, int MainItemQuantity)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
            plhquantity.Controls.Add(ddlMatrix);
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["ToQuantity"]) == MainItemQuantity)
                    {
                        ddlMatrix.SelectedIndex = num;
                    }
                    num++;
                }
            }
        }

        public string SplitFormula(string Formula)
        {
            if (Formula.Contains("*"))
            {
                string[] strArrays = Formula.Split(new char[] { '*' });
                decimal num = decimal.Parse(strArrays[0]);
                decimal num1 = decimal.Parse(strArrays[1]);
                Formula = Convert.ToString(num * num1);
            }
            else if (Formula.Contains("/"))
            {
                string[] strArrays1 = Formula.Split(new char[] { '/' });
                decimal num2 = decimal.Parse(strArrays1[0]);
                decimal num3 = decimal.Parse(strArrays1[1]);
                Formula = Convert.ToString(num2 / num3);
            }
            else if (Formula.Contains("+"))
            {
                string[] strArrays2 = Formula.Split(new char[] { '+' });
                decimal num4 = decimal.Parse(strArrays2[0]);
                decimal num5 = decimal.Parse(strArrays2[1]);
                Formula = Convert.ToString(num4 + num5);
            }
            else if (Formula.Contains("-"))
            {
                string[] strArrays3 = Formula.Split(new char[] { '-' });
                decimal num6 = decimal.Parse(strArrays3[0]);
                decimal num7 = decimal.Parse(strArrays3[1]);
                Formula = Convert.ToString(num6 - num7);
            }
            return Formula;
        }

        private void TakeItemDesc()
        {
            try
            {
                DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
                if (dataSet.Tables[0].Rows.Count > 0 && dataSet != null)
                {
                    if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle")
                    {
                        this.txt_lblItemtitle.Text = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
                    }
                    if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description")
                    {
                        if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblDescription.Text = dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblDescription.Text = dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork")
                    {
                        if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblArtwork.Text = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblArtwork.Text = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour")
                    {
                        if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblColour.Text = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblColour.Text = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size")
                    {
                        if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblSize.Text = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblSize.Text = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material")
                    {
                        if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblMaterial.Text = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblMaterial.Text = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery")
                    {
                        if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblDelivery.Text = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblDelivery.Text = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing")
                    {
                        if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblFinishing.Text = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblFinishing.Text = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs")
                    {
                        if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblProofs.Text = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblProofs.Text = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing")
                    {
                        if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblPacking.Text = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblPacking.Text = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes")
                    {
                        if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblNotes.Text = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblNotes.Text = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions")
                    {
                        if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblInstructions.Text = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblInstructions.Text = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void AddDecorations(Int32 length, string Label, Int32 DecorationNo, Boolean IsMandatory,string Selectevalue)
        {

            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:auto;'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;width:100%;'>"));
            ControlCollection controls44 = this.plhquantity.Controls;
            object[] objArray6 = new object[] { "<div style='float:left;padding:0px 0px 0px 0px;width:90%;' ><label id='lblDecoration_", DecorationNo, "' > ", this.objBase.SpecialDecode(Label), "</label>" };
            controls44.Add(new LiteralControl(string.Concat(objArray6)));
            this.plhquantity.Controls.Add(new LiteralControl("</div></div></div>"));

            if (length <= 80)
            {
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='margin: 0px 0px 0px 15px;'>"));
            }
            length = 0;
            DropDownList dropDownList41 = new DropDownList();
            var roundOff = new object[] { "ddlDecoration_", DecorationNo, };
            dropDownList41.ID = string.Concat(roundOff);
            dropDownList41.CssClass = "dropDownMultiple150";
            dropDownList41.Width = 300;
            dropDownList41.Attributes.Add("onchange", "calculateDecoration('1');Tocall_mainFunc();");
            this.SetDDItems(dropDownList41, Selectevalue, this.plhquantity, IsMandatory);
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));
            ControlCollection controlCollections121 = this.plhquantity.Controls;
            roundOff = new object[] { "<label id='lblDecorationCost_", DecorationNo, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00</label>" };
            controlCollections121.Add(new LiteralControl(string.Concat(roundOff)));


            this.plhquantity.Controls.Add(new LiteralControl("</div><br/>"));
        }


    }
}